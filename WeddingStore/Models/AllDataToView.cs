using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeddingStore.Domain.Models;

namespace WeddingStore.Models
{
    public class AllDataToView
    {
        public IEnumerable<Product> Products { get; set; }
        public string SelectedCategory { get; set; }
        public PageLink PageLink { get; set; }

    }
}