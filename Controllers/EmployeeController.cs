using Federation.Models;
using Federation.Models.Data;
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
        public async Task<ActionResult> GetEmployees()
        {
            try
            {
                return Ok(await _employeeRespository.GetEmployees());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Employees objEmployees)
        {
            var result = _employeeRespository.Create(objEmployees);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Employees objEmployees)
        {
            var result = _employeeRespository.Update(objEmployees);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Employees>> DeleteEmployee(int id)
        {
            try
            {
                var employeeToDelete = await _employeeRespository.GetEmployee(id);

                if (employeeToDelete == null)
                {
                    return NotFound($"Employee with Id = {id} not found");
                }

                return await _employeeRespository.DeleteEmployee(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }

        //[HttpGet]
        //public async Task<IActionResult> GetAsync()
        //{
        //    var result = await _employeeRespository.GetAllEmployee();
        //    return Ok(result);
        //}
    }
}
