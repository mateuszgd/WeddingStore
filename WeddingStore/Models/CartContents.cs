using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeddingStore.Domain.Models;

namespace WeddingStore.Models
{
    public class CartContents
    {
        public CartFunctions cartFunctions { get; set; }
        public string Url { get; set; }
    }
}