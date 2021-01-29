using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WeddingStore.Domain.Models
{
    public class CartProperties
    {
        public int Number { get; set; }
        public Product Product { get; set; }
    }

    public class CartFunctions
    {
        private List<CartProperties> listItems = new List<CartProperties>();

        public void AddItem(Product product, int number)
        {
            CartProperties list = listItems.Where(m => m.Product.ProductId == product.ProductId).FirstOrDefault();

            if(list == null)
            {
                listItems.Add(new CartProperties { Product = product, Number = number });
            }
            else
            {
                list.Number += number;
            }
        }

        public void RemoveItem(Product product)
        {
            listItems.RemoveAll(k => k.Product.ProductId == product.ProductId);
        }

        public void Clear()
        {
            listItems.Clear();
        }

        public decimal SumItem()
        {
            return listItems.Sum(p => p.Product.Price * p.Number);
        }

        public IEnumerable<CartProperties> Cart
        {
            get { return listItems; }
        }
    }
}
