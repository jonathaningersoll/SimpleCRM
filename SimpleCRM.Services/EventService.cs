using SimpleCRM.Data;
using SimpleCRM.Models.EventModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.Services
{
    class EventService
    {
        private readonly Guid _userId;
        public EventService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateEvent(EventCreate model)
        {
            var entity = new Event()
            {
                EventStartTime = model.EventStartTime,
                EventEndTime = model.EventEndTime,
                EventName = model.EventName,
                EventTopic = model.EventTopic,
                CreatedUtc = DateTimeOffset.Now
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Events.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<EventListItem> GetEvents()
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

        public EventDetail GetEventById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Organizations
                        .Single(e => e.OrganizationId == id && e.OwnerId == _userId);
                return
                    new OrganizationDetail
                    {
                        OrganizationId = entity.OrganizationId,
                        OrganizationName = entity.OrganizationName,
                        OrganizationAddress = entity.OrganizationAddress,
                        OrganizationIndustry = entity.OrganizationIndustry,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

        public bool UpdateEvent(EventEdit Model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Organizations
                        .Single(e => e.OrganizationId == Model.OrganizationId && e.OwnerId == _userId);

                entity.OrganizationName = Model.OrganizationName;
                entity.OrganizationAddress = Model.OrganizationAddress;
                entity.OrganizationIndustry = Model.OrganizationIndustry;
                entity.ModifiedUtc = DateTime.Now;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteEvent(int EventId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Organizations
                        .Single(e => e.OrganizationId == OrganizationId && e.OwnerId == _userId);

                ctx.Organizations.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
