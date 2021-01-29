using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingStore.Domain.Models
{
    public class Order
    {
        [Required(ErrorMessage = "Proszę podać imię.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwisko.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Proszę podać adres e-mail.")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwę ulicy.")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Proszę podać numer domu.")]
        public string House { get; set; }
        public string Apartment { get; set; }

        [Required(ErrorMessage = "Proszę podać kod pocztowy.")]
        public string Zip { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwę miasta.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Proszę podać numer telefonu.")]
        public string Phone { get; set; } 
        public CartFunctions cartFunctions { get; set; }
    }
}