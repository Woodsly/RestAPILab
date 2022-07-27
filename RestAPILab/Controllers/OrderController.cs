using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestAPILab.Models;

namespace RestAPILab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public NorthwindContext northwindContext = new NorthwindContext();

        [HttpGet("GetAllOrders")]
        public List<Order> GetAllOrders()
        {
            return northwindContext.Orders.ToList();
        }

        [HttpGet("GetAllOrdersByEmployeeID")]
        public List<Order> GetOrdersByEmployeeID(int employeeID)
        {
            return northwindContext.Orders.Where(p => p.EmployeeId == employeeID).ToList();
        }

        [HttpPost("AddAnOrder")]
        public Order AddAnOrder(string? _customerID, int? _employeeID, DateTime? _orderDate, DateTime? _requiredDate, DateTime? _shippedDate, int? _shipVia, decimal? _freight, string? _shipName, string? _shipAddress, string? _shipCity, string? _shipRegion, string? _shipPostalCode, string? _shipCountry)
        {
            Order newOrder = new Order()
            {
                //OrderId = _orderID,
                CustomerId = _customerID,
                EmployeeId = _employeeID,
                OrderDate = _orderDate,
                RequiredDate = _requiredDate,
                ShippedDate = _shippedDate,
                ShipVia = _shipVia,
                Freight = _freight,
                ShipName = _shipName,
                ShipAddress = _shipAddress,
                ShipCity = _shipCity,
                ShipRegion = _shipRegion,
                ShipPostalCode = _shipPostalCode,
                ShipCountry = _shipCountry
            };
            northwindContext.Orders.Add(newOrder);
            northwindContext.SaveChanges();
            return newOrder;
        }

        [HttpDelete("DeleteOrderByID")]
        public Order DeleteOrderByID(int _orderID)
        {
            Order OrderToTerminate = northwindContext.Orders.FirstOrDefault(p=>p.OrderId == _orderID);
            northwindContext.Orders.Remove(OrderToTerminate);
            northwindContext.SaveChanges();
            return OrderToTerminate;
        }
    }
}
