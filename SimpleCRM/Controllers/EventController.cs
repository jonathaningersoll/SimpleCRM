using Microsoft.AspNet.Identity;
using SimpleCRM.Models.EventModel;
using SimpleCRM.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleCRM.Controllers
{
    public class EventController : Controller
    {
        // GET: Event
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateEventService();

            if (service.EventCreate(model))
            {
                TempData["SaveResult"] = "Event added.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Event could not be added.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var service = CreateEventService();
            var model = service.GetEventById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateEventService();
            var detail = service.GetEventById(id);
            var model =
                new EventEdit
                {
                    EventId = detail.EventId,
                    EventName = detail.EventName,
                    EventStartTime = detail.EventEndTime,
                    EventEndTime = detail.EventEndTime,
                    EventTopic = detail.EventTopic
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EventEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.EventId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateEventService();

            if (service.UpdateEvent(model))
            {
                TempData["SaveResult"] = "Your event was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your event could not be updated.");
            return View();
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateEventService();
            var model = svc.GetEventById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateOrganizationService();

            service.DeleteOrganization(id);

            TempData["SaveResult"] = "Your Organization was removed";

            return RedirectToAction("Index");
        }

        private EventService CreateEventService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new EventService(userId);
            return service;
        }

    }
}