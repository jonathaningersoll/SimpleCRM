using SimpleCRM.Data;
using SimpleCRM.Models.CustomerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.Services
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
            var entity = new Customer()
            {
                OwnerId = _userId,
                CustomerFirstName = model.CustFirstName,
                CustomerLastName = model.CustLastName,
                OrganizationId = model.OrganizationId,
                Role = model.Role,
                Points = model.Points,
                Status = model.Status,
                CreatedUtc = DateTimeOffset.Now
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Customers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CustomerListItem> GetCustomers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Customers.
                    Where(e => e.OwnerId == _userId)
                    .Select(
                        e => new CustomerListItem
                        {
                            CustomerId = e.CustomerId,
                            FullName = e.CustomerFullName,
                            OrganizationId = e.OrganizationId,
                            Points = e.Points
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
                        .Single(e => e.CustomerId == id && e.OwnerId == _userId);
                return
                    new CustomerDetail
                    {
                        CustomerId = entity.CustomerId,
                        CustomerFirstName = entity.CustomerFirstName,
                        CustomerLastName = entity.CustomerLastName,
                        OrganizationName = entity.Organization.OrganizationName,
                        OrganizationId = entity.OrganizationId,
                        Role = entity.Role,
                        Points = entity.Points,
                        Status = entity.Status,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc,
                    };
            }
        }

        public bool UpdateCustomer(CustomerEdit Model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Customers
                        .Single(e => e.CustomerId == Model.CustomerId && e.OwnerId == _userId);

                entity.CustomerFirstName = Model.CustomerFirstName;
                entity.CustomerLastName = Model.CustomerLastName;
                entity.OrganizationId = Model.OrganizationId;
                entity.Points = Model.Points;
                entity.Status = Model.Status;
                entity.Role = Model.Role;
                entity.ModifiedUtc = DateTime.Now;

                return ctx.SaveChanges() == 1;
            }
        }

        // NEEDS FIXED
        public bool DeleteCustomer(int CustomerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Customers
                        .Single(e => e.CustomerId == CustomerId && e.OwnerId == _userId);

                ctx.Customers.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
