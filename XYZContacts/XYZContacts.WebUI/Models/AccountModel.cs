using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace XYZContacts.WebUI.Models
{
    public class AccountModel
    {
        [Required(ErrorMessage = "Username alanı boş geçilemez.")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Parolanız 5-20 karakter arasında olmalı !")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Parola alanı boş geçilemez.")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Parolanız 5-20 karakter arasında olmalı !")]
        public string Password { get; set; }

        [Required(ErrorMessage = "RePassword alanı boş geçilemez.")]       
        [Compare("Password", ErrorMessage = "şifreler uyuşmuyor")]
        public string RePassword { get; set; }

    }
}