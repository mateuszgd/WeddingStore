using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeddingStore.Models
{
    public class Account
    {
        [Required(ErrorMessage = "Proszę podać nazwę użytkownika.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Proszę podać hasło.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}