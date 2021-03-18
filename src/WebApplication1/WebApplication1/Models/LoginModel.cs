using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "El nombre de usuario es requerido")]
        public string UserLogin { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida")]
        public string Password { get; set; }


    }
}