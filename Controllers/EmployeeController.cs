using Federation.Models;
using Federation.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Federation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly FerderationDbContext _context;
        private readonly IEmployees _employeeRespository;

        public EmployeeController(IEmployees employee, FerderationDbContext context)
        {
            _context = context;
            _employeeRespository = employee;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _employeeRespository.GetAllEmployee();

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
