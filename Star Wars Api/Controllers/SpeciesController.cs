using Microsoft.AspNetCore.Mvc;
using Star_Wars_Api.Models;
using Star_Wars_Api.Repository;

namespace Star_Wars_Api.Controllers
{
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiController]
    [Route("[action]")]
    public class SpeciesController : ControllerBase
    {
        public SpeciesController(MainRepository repo)
        {
            repository = repo;
        }

        [HttpGet]
        public async Task<Species> SearchSpecies(uint id)
        {
            string url = string.Format("{0}/{1}", "species", id);
            return await repository.GetEntity<Species>(url);
        }

        private MainRepository repository;
    }
}
