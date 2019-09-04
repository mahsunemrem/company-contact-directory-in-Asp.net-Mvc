using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYZContacts.Entities
{
    public class AppIdentity
    {
        
        [Key]
        [ForeignKey("Employee")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Username alanı boş geçilemez.")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Parolanız 5-20 karakter arasında olmalı !")]
        public string Username { get; set; }

        [Required(ErrorMessage ="Parola alanı boş geçilemez.")]
        [StringLength(20,MinimumLength =5, ErrorMessage = "Parolanız 5-20 karakter arasında olmalı !")]
        public string Password { get; set; }

        
        public IdentityState IdentityState { get; set; }

        [Required]
        public Guid AppRoleId { get; set; }
        public virtual AppRole AppRole { get; set; }


        public virtual Employee Employee { get; set; }
        

    }
}
