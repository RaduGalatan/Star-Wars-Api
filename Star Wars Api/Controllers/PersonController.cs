using Microsoft.AspNetCore.Mvc;
using Star_Wars_Api.Models;
using Star_Wars_Api.Repository;

namespace Star_Wars_Api.Controllers
{
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiController]
    [Route("[action]")]
    public class PersonController : ControllerBase
    {

        public PersonController(MainRepository repo)
        {
            repository = repo;
        }

        [HttpGet]
        public async Task<Person> SearchPerson(uint id)
        {
            string url = string.Format("{0}/{1}", "people", id);

            var result = await repository.GetEntity<Person>(url);

            return result;

        }

        private MainRepository repository;

    }
}
