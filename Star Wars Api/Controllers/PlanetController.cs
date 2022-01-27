using Microsoft.AspNetCore.Mvc;
using Star_Wars_Api.Models;
using Star_Wars_Api.Repository;

namespace Star_Wars_Api.Controllers
{
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiController]
    [Route("[action]")]
    public class PlanetController : ControllerBase
    {
        public PlanetController(MainRepository repo)
        {
            repository = repo;
        }

        [HttpGet]
        public async Task<Planet> SearchPlanet(uint id)
        {
            string url = string.Format("{0}/{1}", "planets", id);
            return await repository.GetEntity<Planet>(url);
        }


        private MainRepository repository;
    }
}
