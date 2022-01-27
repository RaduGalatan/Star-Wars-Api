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
    public class VehicleTests
    {
        MainRepository repository;
        VehicleController controller;
        string path;
        uint testId;

        [SetUp]
        public void Setup()
        {
            repository = new MainRepository();
            controller = new VehicleController(repository);
            testId = 8;
            path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

        }



        [Test]
        public async Task CheckIfTheRightVehicleIsReturnedById()
        {
            Vehicle actualVehicle = await controller.SearchVehicle(testId);

            string expectedVehicleJson;
            using (StreamReader r = new StreamReader(path + @"\EntitiesTestJsons\Vehicle.json"))
            {
                expectedVehicleJson = r.ReadToEnd();
            }

            var actualVehicleJson = JsonConvert.SerializeObject(actualVehicle, Formatting.Indented);

            StringAssert.AreEqualIgnoringCase(expectedVehicleJson, actualVehicleJson);

        }
    }
}
