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
    public class SpeciesTests
    {
        MainRepository repository;
        SpeciesController controller;
        string path;
        uint testId;

        [SetUp]
        public void Setup()
        {
            repository = new MainRepository();
            controller = new SpeciesController(repository);
            testId = 1;
            path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

        }



        [Test]
        public async Task CheckIfTheRightSpeciesIsReturnedById()
        {
            Species actualSpecies = await controller.SearchSpecies(testId);

            string expectedSpeciesJson;
            using (StreamReader r = new StreamReader(path + @"\EntitiesTestJsons\Species.json"))
            {
                expectedSpeciesJson = r.ReadToEnd();
            }

            var actualSpeciesJson = JsonConvert.SerializeObject(actualSpecies, Formatting.Indented);

            StringAssert.AreEqualIgnoringCase(expectedSpeciesJson, actualSpeciesJson);

        }
    }
}
