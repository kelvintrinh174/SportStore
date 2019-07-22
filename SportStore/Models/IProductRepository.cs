using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportStore.Models
{
    public interface IProductRepository
    {
        //this allows to obtain a sequence of Product objects
        IQueryable<Product> Products { get; }

        void SaveProduct(Product product);

        Product DeleteProduct(int ProductID);
    }
}
