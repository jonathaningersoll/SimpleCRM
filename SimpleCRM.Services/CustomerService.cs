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
                CustFirstName = model.CustFirstName,
                CustLastName = model.CustLastName,
                Organization = model.Organization,
                Role = model.Role,
                Points = model.Points,
                Status = model.Status,
                CreatedUtc = DateTimeOffset.Now
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Notes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<NoteListItem> GetNotes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Notes.
                    Where(e => e.OwnerId == _userId)
                    .Select(
                        e => new NoteListItem
                        {
                            NoteId = e.NoteId,
                            Title = e.Title,
                            IsStarred = e.IsStarred,
                            CreatedUtc = e.CreatedUtc
                        }
                    );
                return query.ToArray();
            }
        }

        public NoteDetail GetNoteById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Notes
                        .Single(e => e.NoteId == id && e.OwnerId == _userId);
                return
                    new NoteDetail
                    {
                        NoteId = entity.NoteId,
                        Title = entity.Title,
                        Content = entity.Content,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

        public bool UpdateNote(NoteEdit Model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Notes
                        .Single(e => e.NoteId == Model.NoteId && e.OwnerId == _userId);

                entity.Title = Model.Title;
                entity.Content = Model.Content;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;
                entity.IsStarred = Model.IsStarred;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteNote(int noteId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Notes
                        .Single(e => e.NoteId == noteId && e.OwnerId == _userId);

                ctx.Notes.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
