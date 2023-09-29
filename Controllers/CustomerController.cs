using Api.db.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _123Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase 
    {
        private ICustomerRepository _custrepo;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _custrepo = customerRepository;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public string Get()
        {

         
            return "";          
        }

    }
}
