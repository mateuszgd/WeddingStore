using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingStore.Domain.Models;

namespace WeddingStore.Domain.ConnectDb
{
    public class DbContextEF : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}
