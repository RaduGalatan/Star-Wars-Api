using Star_Wars_Api.Models;

namespace Star_Wars_Api.Repository
{
    public class FilmRepository : MainRepository
    {
        public async Task<List<Person>> GetListOfCharacters(string url)
        {

            var film = GetEntity<Film>(url);

            var charactersLinks = film.Result.Characters;

            List<Person> characters = new List<Person>();

            foreach (string characterLink in charactersLinks)
            {
                Person character = await GetEntity<Person>(characterLink);
                characters.Add(character);
            }

            return characters;
        }

        public async Task<List<Planet>> GetListOfPlanets(string url)
        {

            var film = GetEntity<Film>(url);

            var planetsLinks = film.Result.Planets;

            List<Planet> planets = new List<Planet>();

            foreach (string planetLink in planetsLinks)
            {
                Planet planet = await GetEntity<Planet>(planetLink);
                planets.Add(planet);
            }

            return planets;
        }

        public async Task<List<Species>> GetListOfSpecies(string url)
        {

            var film = GetEntity<Film>(url);

            var speciesLinks = film.Result.Species;

            List<Species> characters = new List<Species>();

            foreach (string speciesLink in speciesLinks)
            {
                Species species = GetEntity<Species>(speciesLink).Result;
                characters.Add(species);
            }

            return characters;
        }

        public async Task<List<Vehicle>> GetListOfVehicles(string url)
        {

            var film = GetEntity<Film>(url);

            var vehiclesLinks = film.Result.Vehicles;

            List<Vehicle> characters = new List<Vehicle>();

            foreach (string vehicleLink in vehiclesLinks)
            {
                Vehicle vehicle = GetEntity<Vehicle>(vehicleLink).Result;
                characters.Add(vehicle);
            }

            return characters;
        }

        public async Task<List<Starship>> GetListOfStarships(string url)
        {

            var film = GetEntity<Film>(url);

            var starshipsLinks = film.Result.Starships;

            List<Starship> starships = new List<Starship>();

            foreach (string starshipLink in starshipsLinks)
            {
                Starship starship = GetEntity<Starship>(starshipLink).Result;
                starships.Add(starship);
            }

            return starships;
        }

    }
}
