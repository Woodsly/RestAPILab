using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestAPILab.Models;

namespace RestAPILab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipperController : ControllerBase
    {
        public NorthwindContext northwindContext = new NorthwindContext();
        [HttpGet("GetAllShippers")]
        public List<Shipper> GetAllShippers()
        {
            return northwindContext.Shippers.ToList();
        }

        [HttpGet("GetShipperByID")]
        public Shipper GetShipperByID(int _shipperID)
        {
            return northwindContext.Shippers.FirstOrDefault(p => p.ShipperId == _shipperID);
        }
    }
}
