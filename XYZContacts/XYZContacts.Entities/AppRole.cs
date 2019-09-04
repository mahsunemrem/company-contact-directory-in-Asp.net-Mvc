using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYZContacts.Entities
{
    public class AppRole
    {
        [Required]
        public Guid ID { get; set; }
       
        [StringLength(20)]
        [Required(ErrorMessage ="Rol adı boş geçilemez")]
        public string RoleName { get; set; }
        
        [StringLength(20)]
        [Required(ErrorMessage = "Rol açıklaması boş geçilemez")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Rol limiti boş geçilemez")]
        public int RoleLimit { get; set; }

        public virtual ICollection<AppIdentity> AppIdentities { get; set; }
    }
}
