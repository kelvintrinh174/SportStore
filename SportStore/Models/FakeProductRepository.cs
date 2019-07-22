using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportStore.Models
{
    /*
    public class FakeProductRepository : IProductRepository
    {
        //AsQueryable<Product>() convert the fixed collection object to list IQueryable<Product> 
        public IQueryable<Product> Products => new List<Product>
        {
            new Product { Name="Football",Price=25},
            new Product { Name="Surf board",Price=179},
            new Product { Name="Running shoe",Price=95}
        }.AsQueryable<Product>();

        public void SaveProduct(Product product)
        {
            if (product.ProductID == 0)
            {
                context.Products.Add(product);
            }
            else
            {
                Product dbEntry = context.Products
                    .FirstOrDefault(p => p.ProductID == product.ProductID);
                if (dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.Price = product.Price;
                    dbEntry.Category = product.Category;
                }
            }
            context.SaveChanges();
        }

    }*/
}
