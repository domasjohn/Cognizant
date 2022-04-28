using Cognizant.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cognizant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        //retrieve all cars from all Warehouses
        [HttpGet]
        public IEnumerable<Warehouse> Get()
        {
            using (var context = new CognizantContext())
            {
                return context.Warehouses.ToList();
            }
        }

        //Retrieve car list ordered by descending added date
        [HttpGet("DESC")]
        public IEnumerable<Warehouse> DESC()
        {
            using (var context = new CognizantContext())
            {
                return context.Warehouses.OrderByDescending(c=>c.DateAdded).ToList();
            }
        }
    }
}
