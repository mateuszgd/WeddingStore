using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingStore.Domain.Models;

namespace WeddingStore.Domain.Logic
{
    public interface IProcessOrder
    {
        void OrderProcess(CartFunctions cartFunctions, Order order);
    }
}
