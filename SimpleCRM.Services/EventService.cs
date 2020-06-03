using SimpleCRM.Data;
using SimpleCRM.Models.EventModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.Services
{
    public class EventService
    {
        private readonly Guid _userId;
        public EventService(Guid userId)
        {
            _userId = userId;
        }

        public bool EventCreate(EventCreate model)
        {
            var entity = new Event()
            {
                OwnerId = _userId,
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
                    .Events.
                    Where(e => e.OwnerId == _userId)
                    .Select(
                        e => new EventListItem
                        {
                            EventId = e.EventId,
                            EventName = e.EventName
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
                        .Events
                        .Single(e => e.EventId == id && e.OwnerId == _userId);
                return
                    new EventDetail
                    {
                        EventId = entity.EventId,
                        EventStartTime = entity.EventStartTime,
                        EventEndTime = entity.EventEndTime,
                        EventName = entity.EventName,
                        EventTopic = entity.EventTopic,
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
                        .Events
                        .Single(e => e.EventId == Model.EventId && e.OwnerId == _userId);

                entity.EventName = Model.EventName;
                entity.EventStartTime = Model.EventStartTime;
                entity.EventEndTime = Model.EventEndTime;
                entity.EventTopic = Model.EventTopic;
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
                        .Events
                        .Single(e => e.EventId == EventId && e.OwnerId == _userId);

                ctx.Events.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
