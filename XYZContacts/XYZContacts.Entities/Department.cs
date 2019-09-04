using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYZContacts.Entities
{
    public class Department
    {
        [Required]
        public Guid ID { get; set; }

        [Required(ErrorMessage = "Departman adı boş geçilemez")]
        [MaxLength(30)]
        public string DepartmentName { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
