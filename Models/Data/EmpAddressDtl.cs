using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Federation.Models.Data
{
    public class EmpAddressDtl
    {
        [Key]
        public int AddrId { get; set; }
        public string Address1 { get; set; }

        [ForeignKey("EmployeeId")]
        public Employees Employees { get; set; }
        public int EmployeeId { get; set; }
    }
}
