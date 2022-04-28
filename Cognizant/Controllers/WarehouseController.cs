using Cognizant.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cognizant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Warehouse> Get()
        {
            using (var context = new CognizantContext())
            {
                return context.Warehouses.ToList();
            }
        }

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
