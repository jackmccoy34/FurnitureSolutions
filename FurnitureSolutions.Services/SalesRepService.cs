using FurnitureSolutions.Data;
using FurnitureSolutions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureSolutions.Services
{
    public class SalesRepService
    {
        private readonly Guid _userId;

        public SalesRepService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateSalesRep(SalesRepCreate model)
        {
            var entity =
                new SalesRep()
                {
                    RepName = model.RepName,
                    Territory = model.Territory,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.SalesReps.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<SalesRepListItem> GetSalesRep()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .SalesReps
                        .Select(
                            e =>
                                new SalesRepListItem
                                {
                                    RepId = e.RepId,
                                    RepName = e.RepName,
                                    Territory = e.Territory
                                }
                        );

                return query.ToArray();
            }
        }

        public SalesRepDetail GetSalesRepById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .SalesReps
                        .Single(e => e.RepId == id);
                return
                    new SalesRepDetail
                    {
                        RepId = entity.RepId,
                        RepName = entity.RepName,
                        Territory = entity.Territory
                    };
            }
        }

        public bool UpdateSalesRep(SalesRepEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .SalesReps
                        .Single(e => e.RepId == model.RepId);

                entity.RepName = model.RepName;
                entity.Territory = model.Territory;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteSalesRep(int repId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .SalesReps
                        .Single(e => e.RepId == repId);

                ctx.SalesReps.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
