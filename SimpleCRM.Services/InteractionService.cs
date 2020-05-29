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

        // Declare the _userId field of type Guid
        private readonly Guid _userId;
        // Constructor for InteractionService class with the parameter 'userId' of type Guid.
        public InteractionService(Guid userId){ _userId = userId; }


        // CREATE INTERACTION
        public bool InteractionCreate(InteractionCreate model)
        {
            var entity = new Interaction()
            {
                OwnerId = _userId,
                EventId = model.EventId,
                CustomerId = model.CustomerId,
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


        // GET LIST OF INTERACTIONS
        public IEnumerable<InteractionListItem> GetInteractions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Interactions.Where(e => e.OwnerId == _userId).Select(e => new InteractionListItem
                        {
                            InteractionId = e.InteractionId,
                            CustomerId = e.CustomerId,
                            CustomerFullName = e.Customer.CustomerFullName,
                            EventId = e.EventId,
                            EventName = e.Event.EventName
                        }
                    );
                return query.ToArray();
            }
        }


        // GET AN INTERACTION'S DETAILS
        public InteractionDetail GetInteractionById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Interactions.Single(e => e.InteractionId == id && e.OwnerId == _userId);
                return
                    new InteractionDetail
                    {
                        InteractionId = entity.InteractionId,
                        CustomerId = entity.CustomerId,
                        CustomerFullName = entity.Customer.CustomerFullName,
                        EventId = entity.EventId,
                        Event = entity.Event.EventName,
                        InteractionNotes = entity.InteractionNotes,
                        InteractionPointValue = entity.InteractionPointValue,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }


        // EDIT AN INTERACTION
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
                entity.CustomerId = Model.CustomerId;
                entity.EventId = Model.EventId;
                entity.ModifiedUtc = DateTime.Now;

                return ctx.SaveChanges() == 1;
            }
        }


        // DELETE AN INTERACTION
        public bool DeleteInteraction(int InteractionId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Interactions.Single(e => e.InteractionId == InteractionId && e.OwnerId == _userId);

                ctx.Interactions.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
