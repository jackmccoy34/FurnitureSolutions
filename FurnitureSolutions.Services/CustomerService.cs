using FurnitureSolutions.Data;
using FurnitureSolutions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSolutions.Services
{
    public class CustomerService
    {
        private readonly Guid _userId;

        public CustomerService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCustomer(CustomerCreate model)
        {
            var entity =
                new Customer()
                {
                    
                    CustomerName = model.CustomerName,
                    Address = model.Address,
                    Contact = model.Contact
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Customers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CustomerListItem> GetCustomer()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Customers
                        .Select(
                            e =>
                                new CustomerListItem
                                {
                                    CustomerId = e.CustomerId,
                                    CustomerName = e.CustomerName,
                                    Address = e.Address,
                                    Contact = e.Contact
                                }
                        );

                return query.ToArray();
            }
        }

        public CustomerDetail GetCustomerById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Customers
                        .Single(e => e.CustomerId == id);
                return
                    new CustomerDetail
                    {
                        CustomerId = entity.CustomerId,
                        CustomerName = entity.CustomerName,
                        Address = entity.Address,
                        Contact = entity.Contact
                    };
            }
        }

        public bool EditCustomer(CustomerEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Customers
                        .Single(e => e.CustomerId == model.CustomerId);
                entity.CustomerName = model.CustomerName;
                entity.Address = model.Address;
                entity.Contact = model.Contact;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCustomer(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Customers
                        .Single(e => e.CustomerId == id);

                ctx.Customers.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
