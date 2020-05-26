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
            var service = CreateOrganizationService();
            var detail = service.GetOrganizationById(id);
            var model =
                new OrganizationEdit
                {
                    OrganizationId = detail.OrganizationId,
                    OrganizationName = detail.OrganizationName,
                    OrganizationAddress = detail.OrganizationAddress,
                    OrganizationIndustry = detail.OrganizationIndustry
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, OrganizationEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.OrganizationId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateOrganizationService();

            if (service.UpdateOrganization(model))
            {
                TempData["SaveResult"] = "Your Organization was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Organization could not be updated.");
            return View();
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateOrganizationService();
            var model = svc.GetOrganizationById(id);

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