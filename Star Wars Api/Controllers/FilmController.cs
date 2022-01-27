using Microsoft.AspNetCore.Mvc;
using Star_Wars_Api.Models;
using Star_Wars_Api.Repository;

namespace Star_Wars_Api.Controllers
{
    [ApiExplorerSettings(GroupName = "v2")]
    [ApiController]
    [Route("[action]")]
    public class FilmController : ControllerBase
    {


        public FilmController(FilmRepository repo)
        {
            repository = repo;
        }

        [ApiExplorerSettings(GroupName = "v1")]
        [HttpGet]
        public async Task<Film> SearchFilm(uint id)
        {
            string url = "films/" + id.ToString();

            var result = await repository.GetEntity<Film>(url);

            return result;

        }

        [HttpGet]
        public async Task<List<Person>> SearchCharactersOfFilm(uint id)
        {
            string url = "films/" + id.ToString();

            var result = await repository.GetListOfCharacters(url);

            return result;
        }

        [HttpGet]
        public async Task<List<Planet>> SearchPlanetsOfFilm(uint id)
        {
            string url = "films/" + id.ToString();

            var result = await repository.GetListOfPlanets(url);

            return result;
        }

        [HttpGet]
        public async Task<List<Species>> SearchSpeciesOfFilm(uint id)
        {
            string url = "films/" + id.ToString();

            var result = await repository.GetListOfSpecies(url);

            return result;
        }

        [HttpGet]
        public async Task<List<Vehicle>> SearchVehiclesOfFilm(uint id)
        {
            string url = "films/" + id.ToString();

            var result = await repository.GetListOfVehicles(url);

            return result;
        }

        [HttpGet]
        public async Task<List<Starship>> SearchStarshipsOfFilm(uint id)
        {
            string url = "films/" + id.ToString();

            var result = await repository.GetListOfStarships(url);

            return result;
        }

        private FilmRepository repository;
    }
}
