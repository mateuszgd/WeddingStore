using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WeddingStore.Domain.Models
{
    public class Product
    {
        [HiddenInput(DisplayValue = false)]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwę produktu.")]
        [Display(Name = "Nazwa")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Proszę podać cenę produktu.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Proszę podać prawidłową cenę.")]
        [Display(Name = "Cena")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwę kategorii.")]
        [Display(Name = "Kategoria")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Proszę podać opis produktu.")]
        [DataType(DataType.MultilineText), Display(Name = "Opis")]
        public string Description { get; set; }

        public byte[] DataImage { get; set; }
        public string TypeImage { get; set; }
    }
}
