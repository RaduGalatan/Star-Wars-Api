using Microsoft.AspNetCore.Mvc;
using Star_Wars_Api.Models;
using Star_Wars_Api.Repository;

namespace Star_Wars_Api.Controllers
{
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiController]
    [Route("[action]")]
    public class StarshipController : ControllerBase
    {
        public StarshipController(MainRepository repo)
        {
            repository = repo;
        }

        [HttpGet]
        public async Task<Starship> SearchStarship(uint id)
        {
            string url = string.Format("{0}/{1}", "starships", id);
            return await repository.GetEntity<Starship>(url);
        }

        private MainRepository repository;
    }
}
