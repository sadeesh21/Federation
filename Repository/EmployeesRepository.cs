using Federation.Models;
using Federation.Models.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace Federation.Repository
{
    public class EmployeesRepository : IEmployees
    {
        FerderationDbContext _context;
        public EmployeesRepository(FerderationDbContext context)
        {
            _context = context;
        }
        public Employees Create(Employees objEmployee)
        {
            _context.Employees.Add(objEmployee);
            _context.SaveChanges();
            return objEmployee;
        }
        public async Task<Employees> GetEmployee(int employeeId)
        {
            return await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
        }
        public async Task<Employees> DeleteEmployee(int employeeId)
        {
            var result = await _context.Employees
                .FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
            if (result != null)
            {
                _context.Employees.Remove(result);
                await _context.SaveChangesAsync();
                return result;
            }

            return null;
        }
       
        public async Task<IEnumerable<Employees>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        public Employees Update(Employees objEmployee)
        {
            _context.Employees.Update(objEmployee);
            // await
            var obj = _context.SaveChanges();
            return objEmployee;
        }
    }
}
