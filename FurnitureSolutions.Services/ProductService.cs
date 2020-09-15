using FurnitureSolutions.Data;
using FurnitureSolutions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSolutions.Services
{
    public class ProductService
    {
        private readonly Guid _userId;

        public ProductService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateProduct(ProductCreate model)
        {
            var entity =
                new Product()
                {
                    ProductName = model.ProductName,
                    FurnitureType = model.FurnitureType,
                    Price = model.Price
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Products.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ProductListItem> GetProducts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Products
                        .Select(e =>
                            new ProductListItem()
                            {
                                ProductId = e.ProductId,
                                ProductName = e.ProductName,
                                FurnitureType = e.FurnitureType,
                                Price = e.Price
                            }
                        );
                return query.ToArray();
            }
        }
    }
}
