using Newtonsoft.Json;
using NUnit.Framework;
using Star_Wars_Api.Controllers;
using Star_Wars_Api.Models;
using Star_Wars_Api.Repository;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Star_Wars_Api_Tests.EntitiesUnitTests
{
    public class PeopleTests
    {
        MainRepository repository;
        PersonController controller;
        string path;
        uint testId;

        [SetUp]
        public void Setup()
        {
            repository = new MainRepository();
            controller = new PersonController(repository);
            testId = 1;
            path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

        }



        [Test]
        public async Task CheckIfTheRightPersonIsReturnedById()
        {
            Person actualPerson = await controller.SearchPerson(testId);

            string expectedPersonJson;
            using (StreamReader r = new StreamReader(path + @"\EntitiesTestJsons\Person.json"))
            {
                expectedPersonJson = r.ReadToEnd();
            }

            var actualPersonJson = JsonConvert.SerializeObject(actualPerson, Formatting.Indented);

            StringAssert.AreEqualIgnoringCase(expectedPersonJson, actualPersonJson);

        }

    }
}
