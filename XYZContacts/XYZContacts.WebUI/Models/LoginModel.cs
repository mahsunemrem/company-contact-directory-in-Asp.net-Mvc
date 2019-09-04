using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace XYZContacts.WebUI.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Username alanı boş geçilemez.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password alanı boş geçilemez.")]
        public string Password { get; set; }
    }
}