using SimpleCRM.Data;
using SimpleCRM.Models.OrganizationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.Services
{
    class OrganizationService
    {
        private readonly Guid _userId;
        public OrganizationService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateOrganization(OrganizationCreate model)
        {
            var entity = new Organization()
            {
                OrganizationName = model.OrganizationName,
                OrganizationAddress = model.OrganizationAddress,
                OrganizationIndustry = model.OrgaizationIndustry,
                CreatedUtc = DateTimeOffset.Now
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Customers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<OrganizationListItem> GetOrganizations()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Customers.
                    Where(e => e.OwnerId == _userId)
                    .Select(
                        e => new OrganizationListItem
                        {
                            OrganizationId = e.OrganizationId,
                            OrganizationName = e.Organization.OrganizationName
                        }
                    );
                return query.ToArray();
            }
        }

        public OrganizationDetail GetOrganizationById(int id)
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
                        CustomerFullName = entity.CustomerFullName,
                        Organization = entity.Organization,
                        Role = entity.Role,
                        Points = entity.Points,
                        Status = entity.Status,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc,
                    };
            }
        }

        public bool UpdateOrganization(OrganizationEdit Model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Customers
                        .Single(e => e.CustomerId == Model.CustomerId && e.OwnerId == _userId);

                entity.CustomerFirstName = Model.CustomerFirstName;
                entity.CustomerLastName = Model.CustomerLastName;
                entity.Organization = Model.Organization;
                entity.Points = Model.Points;
                entity.Status = Model.Status;
                entity.Role = Model.Role;
                entity.ModifiedUtc = DateTime.Now;

                return ctx.SaveChanges() == 1;
            }
        }

        // NEEDS FIXED
        public bool DeleteOrganization(int OrganizationId)
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
