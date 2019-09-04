using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYZContacts.Entities
{
    public class Title
    {
        public Guid ID { get; set; }
        [Required(ErrorMessage = "Rol açıklaması boş geçilemez")]
        [MaxLength(30)]
        public string TitleName { get; set; }

        public virtual ICollection<Employee> Emloyees { get; set; }

    }
}
