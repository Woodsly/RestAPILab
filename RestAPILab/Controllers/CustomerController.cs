using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestAPILab.Models;

namespace RestAPILab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public NorthwindContext northwindContext = new NorthwindContext();

        [HttpGet("GetAllCompanies")]
        public List<Customer> GetAllCompanies()
        {
            return northwindContext.Customers.ToList();
        }

        [HttpGet("GetCompaniesByCity")]
        public List<Customer> GetCompaniesByCity(string city)
        {
            return northwindContext.Customers.Where(p => p.City.ToLower() == city.ToLower()).ToList();
        }

        [HttpPost("AddACustomer")]
        public Customer AddACustomer(string CustomerId, string CompanyName, string? ContactName, string? ContactTitle, string? Address, string? City, string? Region, string? PostalCode, string? Country, string? Phone, string? Fax)
        {
            Customer newCustomer = new Customer()
            {
                CustomerId = CustomerId,
                CompanyName = CompanyName,
                ContactName = ContactName,
                ContactTitle = ContactTitle,
                Address = Address,
                City = City,
                Region = Region,
                PostalCode = PostalCode,
                Country = Country,
                Phone = Phone,
                Fax = Fax
            };
            northwindContext.Customers.Add(newCustomer);
            northwindContext.SaveChanges();
            return newCustomer;
        }

        //tried to get a delete working here, it seems the table references another so it wouldn't actually delete anything
        //[HttpDelete("RemoveACustomer")]
        //public Customer RemoveACustomer(string customerID)
        //{
        //    Customer CustomerToTerminate = northwindContext.Customers.FirstOrDefault(p => p.CustomerId == customerID.ToUpper());
        //    northwindContext.Customers.Remove(CustomerToTerminate);
        //    northwindContext.SaveChanges();
        //    return CustomerToTerminate;
        //}
    }
}