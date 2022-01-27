using Newtonsoft.Json;
using NUnit.Framework;
using Star_Wars_Api.Controllers;
using Star_Wars_Api.Models;
using Star_Wars_Api.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Star_Wars_Api_Tests.EntitiesUnitTests
{
    public class FilmTests
    {

        FilmRepository repository;
        FilmController controller;
        string path;
        uint testId;

        [SetUp]
        public void Setup()
        {
            repository = new FilmRepository();
            controller = new FilmController(repository);
            testId = 1;
            path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

        }

        [Test]
        public async Task CheckIfTheRightFilmIsReturnedById()
        {
            Film actualFilm = await controller.SearchFilm(testId);

            string expectedFilmJson;
            using (StreamReader r = new StreamReader(path + @"\EntitiesTestJsons\Film.json"))
            {
                expectedFilmJson = r.ReadToEnd();
            }

            var actualFilmJson = JsonConvert.SerializeObject(actualFilm, Formatting.Indented);

            StringAssert.AreEqualIgnoringCase(expectedFilmJson, actualFilmJson);

        }

        [Test]
        [TestCase(0u)]
        public void CheckIfErrorIsThrown(uint faultyValue)
        {
            Assert.That(async()=> await controller.SearchFilm(faultyValue), Throws.Exception);
        }

        [Test]
        public void CheckIfRightCharactersOfMovie()
        {
            List<Person> characters =controller.SearchCharactersOfFilm(testId).Result;

            string expectedCharactersJson;
            using (StreamReader r = new StreamReader(path + @"\FilmEntitiesTestJsons\FilmCharactersList.json"))
            {
                expectedCharactersJson = r.ReadToEnd();
            }

            string actualCharactersJson=JsonConvert.SerializeObject(characters,Formatting.Indented);

            StringAssert.AreEqualIgnoringCase(expectedCharactersJson, actualCharactersJson);
        }

        [Test]
        public void CheckIfRightPlanetsOfMovie()
        {
            List<Planet> planets = controller.SearchPlanetsOfFilm(testId).Result;

            string expectedPlanetsJson;
            using (StreamReader r = new StreamReader(path + @"\FilmEntitiesTestJsons\FilmPlanetsList.json"))
            {
                expectedPlanetsJson = r.ReadToEnd();
            }

            string actualPlanetsJson = JsonConvert.SerializeObject(planets, Formatting.Indented);

            StringAssert.AreEqualIgnoringCase(expectedPlanetsJson, actualPlanetsJson);
        }

        [Test]
        public void CheckIfRightSpeciesOfMovie()
        {
            List<Species> species = controller.SearchSpeciesOfFilm(testId).Result;

            string expectedSpeciesJson;
            using (StreamReader r = new StreamReader(path + @"\FilmEntitiesTestJsons\FilmSpeciesList.json"))
            {
                expectedSpeciesJson = r.ReadToEnd();
            }

            string actualSpeciesJson = JsonConvert.SerializeObject(species, Formatting.Indented);

            StringAssert.AreEqualIgnoringCase(expectedSpeciesJson, actualSpeciesJson);
        }

        [Test]
        public void CheckIfRightVehiclesOfMovie()
        {
            List<Vehicle> vehicles = controller.SearchVehiclesOfFilm(testId).Result;

            string expectedVehiclesJson;
            using (StreamReader r = new StreamReader(path + @"\FilmEntitiesTestJsons\FilmVehiclesList.json"))
            {
                expectedVehiclesJson = r.ReadToEnd();
            }

            string actualVehiclesJson = JsonConvert.SerializeObject(vehicles, Formatting.Indented);

            StringAssert.AreEqualIgnoringCase(expectedVehiclesJson, actualVehiclesJson);
        }

        [Test]
        public void CheckIfRightCStarshipsOfMovie()
        {
            List<Starship> starships = controller.SearchStarshipsOfFilm(testId).Result;

            string expectedStarshipsJson;
            using (StreamReader r = new StreamReader(path + @"\FilmEntitiesTestJsons\FilmStarshipsList.json"))
            {
                expectedStarshipsJson = r.ReadToEnd();
            }

            string actualStarshipsJson = JsonConvert.SerializeObject(starships, Formatting.Indented);

            StringAssert.AreEqualIgnoringCase(expectedStarshipsJson, actualStarshipsJson);
        }

    }
}