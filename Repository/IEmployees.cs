using Federation.Models.Data;
using Microsoft.AspNetCore.Mvc;

namespace Federation.Repository
{
    public interface IEmployees
    {
        Task<Employees> GetEmployee(int employeeId);
        Employees Create(Employees objEmployee);
        Employees Update(Employees objEmployee);
        Task<IEnumerable<Employees>> GetEmployees();
        Task<Employees> DeleteEmployee(int employeeId);
    }
}
