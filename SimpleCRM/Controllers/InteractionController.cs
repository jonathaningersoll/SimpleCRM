using Microsoft.AspNet.Identity;
using SimpleCRM.Models.InteractionModel;
using SimpleCRM.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleCRM.Controllers
{
    public class InteractionController : Controller
    {
        // GET: Interaction
        public ActionResult Index()
        {
            var service = CreateInteractionService();
            var model = service.GetInteractions();

            return View(model);
        }

        public ActionResult Create()
        {
            ViewBag.CustomerId = GetListOfCustomers();
            ViewBag.EventId = GetListOfEvents();
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InteractionCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateInteractionService();

            if (service.InteractionCreate(model))
            {
                TempData["SaveResult"] = "Interaction recorded!";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Interaction could not be recorded.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var service = CreateInteractionService();
            var model = service.GetInteractionById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateInteractionService();
            var detail = service.GetInteractionById(id);

            ViewBag.CustomerId = GetListOfCustomers();
            ViewBag.EventId = GetListOfEvents();

            var model =
                new InteractionEdit
                {
                    CustomerId = detail.CustomerId,
                    EventId = detail.EventId,
                    InteractionId = detail.InteractionId,
                    InteractionNotes = detail.InteractionNotes,
                    InteractionPointValue = detail.InteractionPointValue
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, InteractionEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.InteractionId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateInteractionService();

            if (service.UpdateInteraction(model))
            {
                TempData["SaveResult"] = "Your Interaction was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Interaction could not be updated.");
            return View();
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateInteractionService();
            var model = svc.GetInteractionById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateInteractionService();

            service.DeleteInteraction(id);

            TempData["SaveResult"] = "Your Interaction was removed";

            return RedirectToAction("Index");
        }

        private InteractionService CreateInteractionService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new InteractionService(userId);
            return service;
        }

        private CustomerService CreateCustomerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CustomerService(userId);
            return service;
        }

        private EventService CreateEventService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new EventService(userId);
            return service;
        }

        private IEnumerable<SelectListItem> GetListOfCustomers()
        {
            var orgService = CreateCustomerService();
            var editList = orgService.GetCustomers();

            IEnumerable<SelectListItem> list = new SelectList(editList, "CustomerId", "CustomerFullName");
            return list;
        }

        private IEnumerable<SelectListItem> GetListOfEvents()
        {
            var orgService = CreateEventService();
            var editList = orgService.GetEvents();

            IEnumerable<SelectListItem> list = new SelectList(editList, "EventId", "EventName");
            return list;
        }

    }
}