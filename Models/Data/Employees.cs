using System.ComponentModel.DataAnnotations;

namespace Federation.Models.Data
{
    public class Employees
    {
       
        [Key]
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; } //= string.Empty;
        public string EmailID { get; set; }
        public string Designation { get; set; } //= string.Empty;

        public ICollection<EmpAddressDtl> EmpAddressDtl { get; set; } = new List<EmpAddressDtl>();
    }
}
