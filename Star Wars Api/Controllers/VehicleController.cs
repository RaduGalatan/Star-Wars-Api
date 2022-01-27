using Microsoft.AspNetCore.Mvc;
using Star_Wars_Api.Models;
using Star_Wars_Api.Repository;

namespace Star_Wars_Api.Controllers
{
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiController]
    [Route("[action]")]
    public class VehicleController : ControllerBase
    {
        public VehicleController(MainRepository repo)
        {
            repository = repo;
        }

        [HttpGet]
        public async Task<Vehicle> SearchVehicle(uint id)
        {
            string url = string.Format("{0}/{1}", "vehicles", id);
            return await repository.GetEntity<Vehicle>(url);
        }


        private MainRepository repository;
    }
}
