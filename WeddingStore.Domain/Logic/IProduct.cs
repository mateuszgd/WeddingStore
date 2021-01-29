using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingStore.Domain.Models;

namespace WeddingStore.Domain.Logic
{
    public interface IProduct
    {
        IEnumerable<Product> Products { get; }

        void Save(Product product);

        Product Delete(int productId);
    }
}
