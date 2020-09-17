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
                    UserId = _userId,
                    Quantity = model.Quantity,
                    TotalPrice = model.TotalPrice,
                    CustomerId = model.CustomerId,
                    RepId = model.RepId,
                    ProductId = model.ProductId,
                    DeliveryDate = model.DeliveryDate
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
                        .Where(e=> e.UserId == _userId)
                        .Select(e => new OrderListItem
                        {
                            OrderId = e.OrderId,
                            Quantity = e.Quantity,
                            TotalPrice = e.TotalPrice,
                            ProductId = e.ProductId,
                            CustomerId = e.CustomerId,
                            RepId = e.RepId,
                            DeliveryDate = e.DeliveryDate
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
                        .Single(e => e.OrderId == id && e.UserId == _userId);
                return
                    new OrderDetail
                    {
                        OrderId = entity.OrderId,
                        Quantity = entity.Quantity,
                        TotalPrice = entity.TotalPrice,
                        ProductId = entity.ProductId,
                        CustomerId = entity.CustomerId,
                        RepId = entity.RepId,
                        DeliveryDate = entity.DeliveryDate
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
                        .Single(e => e.OrderId == model.OrderId && e.UserId == _userId);
                entity.CustomerId = model.CustomerId;
                entity.ProductId = model.ProductId;
                entity.RepId = model.RepId;
                entity.Quantity = model.Quantity;
                entity.TotalPrice = model.TotalPrice;
                entity.DeliveryDate = model.DeliveryDate;

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
                        .Single(e => e.OrderId == id && e.UserId == _userId);

                ctx.Orders.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
