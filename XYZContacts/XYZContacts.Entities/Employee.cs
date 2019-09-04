using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYZContacts.Entities
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage ="İsim alanı boş geçilemez.")]
        public string Name { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Surname alanı boş geçilemez.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Email adres alanı boş geçilemez.")]
        [EmailAddress(ErrorMessage ="Geçerli bir Email adresi giriniz.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefon numarası alanı geçilemez.")]        
        [Phone(ErrorMessage ="Geçerli bir Telefon numarası giriniz.")]
        public string PhoneNumbersI { get; set; }

        [Required(ErrorMessage = "Telefon numarası alanı geçilemez.")]
        [Phone(ErrorMessage = "Geçerli bir Telefon numarası giriniz.")]
        public string PhoneNumbersII { get; set; }

        
        

        [Required(ErrorMessage = "Hakkınız da alanı boş geçilemez.")]
        [StringLength(300,MinimumLength =5,ErrorMessage ="5-300")]
        public string About { get; set; }


        public virtual AppIdentity AppIdentity { get; set; }

        [Required]
        public Guid DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        [Required]
        public Guid TitleId { get; set; }
        public virtual Title Title { get; set; }
        

        


    }
}
