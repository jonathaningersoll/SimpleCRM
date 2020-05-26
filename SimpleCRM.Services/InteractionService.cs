using SimpleCRM.Data;
using SimpleCRM.Models.InteractionModel;
using SimpleCRM.Models.OrganizationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.Services
{
    public class InteractionService
    {
        private readonly Guid _userId;
        public InteractionService(Guid userId)
        {
            _userId = userId;
        }

        public bool InteractionCreate(InteractionCreate model)
        {
            var entity = new Interaction()
            {
                Event = model.Event,
                Customer = model.Customer,
                InteractionNotes = model.InteractionNotes,
                InteractionPointValue = model.PointValue,
                CreatedUtc = DateTimeOffset.Now
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Interactions.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<InteractionListItem> GetInteractions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Interactions.
                    Where(e => e.OwnerId == _userId)
                    .Select(
                        e => new InteractionListItem
                        {
                            InteractionId = e.InteractionId,
                            Customer = e.Customer.CustomerFullName
                        }
                    );
                return query.ToArray();
            }
        }

        public InteractionDetail GetInteractionById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Interactions
                        .Single(e => e.InteractionId == id && e.OwnerId == _userId);
                return
                    new InteractionDetail
                    {
                        InteractionId = entity.InteractionId,
                        Customer = entity.Customer.CustomerFullName,
                        Event = entity.Event.EventName,
                        InteractionPointValue = entity.InteractionPointValue,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

        public bool UpdateInteraction(InteractionEdit Model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Interactions
                        .Single(e => e.InteractionId == Model.InteractionId && e.OwnerId == _userId);

                entity.InteractionNotes = Model.InteractionNotes;
                entity.InteractionPointValue = Model.InteractionPointValue;
                entity.ModifiedUtc = DateTime.Now;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteInteraction(int InteractionId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Interactions
                        .Single(e => e.InteractionId == InteractionId && e.OwnerId == _userId);

                ctx.Interactions.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
