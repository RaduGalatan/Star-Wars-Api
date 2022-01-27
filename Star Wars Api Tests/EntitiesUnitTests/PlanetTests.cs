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
    public class PlanetTests
    {
        MainRepository repository;
        PlanetController controller;
        string path;
        uint testId;

        [SetUp]
        public void Setup()
        {
            repository = new MainRepository();
            controller = new PlanetController(repository);
            testId = 1;
            path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

        }



        [Test]
        public async Task CheckIfTheRightPlanetIsReturnedById()
        {
            Planet actualPlanet = await controller.SearchPlanet(testId);

            string expectedPlanetJson;
            using (StreamReader r = new StreamReader(path + @"\EntitiesTestJsons\Planet.json"))
            {
                expectedPlanetJson = r.ReadToEnd();
            }

            var actualPlanetJson = JsonConvert.SerializeObject(actualPlanet, Formatting.Indented);

            StringAssert.AreEqualIgnoringCase(expectedPlanetJson, actualPlanetJson);

        }
    }
}
