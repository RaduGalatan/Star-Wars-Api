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
    public class StarshipTests
    {
        MainRepository repository;
        StarshipController controller;
        string path;
        uint testId;

        [SetUp]
        public void Setup()
        {
            repository = new MainRepository();
            controller = new StarshipController(repository);
            testId = 9;
            path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

        }



        [Test]
        public async Task CheckIfTheRightStarshipIsReturnedById()
        {
            Starship actualStarship = await controller.SearchStarship(testId);

            string expectedStarshipJson;
            using (StreamReader r = new StreamReader(path + @"\EntitiesTestJsons\Starship.json"))
            {
                expectedStarshipJson = r.ReadToEnd();
            }

            var actualStarshipJson = JsonConvert.SerializeObject(actualStarship, Formatting.Indented);

            StringAssert.AreEqualIgnoringCase(expectedStarshipJson, actualStarshipJson);

        }

    }
}
