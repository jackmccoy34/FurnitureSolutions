using FurnitureSolutions.Data;
using FurnitureSolutions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSolutions.Services
{
    public class OrderService
    {
        private readonly Guid _userId;

        public OrderService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateOrder(OrderCreate model)
        {
            var entity =
                new Order()
                {
                    Quantity = model.Quantity,
                    TotalPrice = model.TotalPrice,
                    CustomerId = model.CustomerId,
                    RepId = model.RepId,
                    ProductId = model.ProductId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Orders.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<OrderListItem> GetOrders()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Orders
                        .Select(e => new OrderListItem
                        {
                            OrderId = e.OrderId,
                            Quantity = e.Quantity,
                            TotalPrice = e.TotalPrice,
                            Product = e.Product,
                            Customer = e.Customer,
                            SalesRep = e.SalesRep
                        });
                return query.ToArray();
            }
        }

        public OrderDetail GetOrderById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Orders
                        .Single(e => e.OrderId == id);
                return
                    new OrderDetail
                    {
                        OrderId = entity.OrderId,
                        Quantity = entity.Quantity,
                        TotalPrice = entity.TotalPrice,
                        Product = entity.Product,
                        Customer = entity.Customer,
                        SalesRep = entity.SalesRep
                    };
            }
        }

        public bool EditOrder(OrderEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Orders
                        .Single(e => e.OrderId == model.OrderId);
                entity.CustomerId = model.CustomerId;
                entity.ProductId = model.ProductId;
                entity.RepId = model.RepId;
                entity.Quantity = model.Quantity;
                entity.TotalPrice = model.TotalPrice;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteOrder(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Orders
                        .Single(e => e.OrderId == id);

                ctx.Orders.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
