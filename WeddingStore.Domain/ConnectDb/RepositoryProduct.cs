using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingStore.Domain.Logic;
using WeddingStore.Domain.Models;

namespace WeddingStore.Domain.ConnectDb
{
    public class RepositoryProduct : IProduct
    {
        private DbContextEF db = new DbContextEF();

        public IEnumerable<Product> Products
        {
            get { return db.Products; }
        }

        public Product Delete(int productId)
        {
            Product deleteProduct = db.Products.Find(productId);
            if (deleteProduct != null)
            {
                db.Products.Remove(deleteProduct);
                db.SaveChanges();
            }
            return deleteProduct;
        }

        public void Save(Product product)
        {
            if (product.ProductId == 0)
            {
                db.Products.Add(product);
            }
            else
            {
                Product overwrite = db.Products.Find(product.ProductId);
                if (overwrite != null)
                {
                    overwrite.Name = product.Name;
                    overwrite.Price = product.Price;
                    overwrite.Category = product.Category;
                    overwrite.Description = product.Description;
                    overwrite.DataImage = product.DataImage;
                    overwrite.TypeImage = product.TypeImage;
                }
            }
            db.SaveChanges();
        }
    }
}
