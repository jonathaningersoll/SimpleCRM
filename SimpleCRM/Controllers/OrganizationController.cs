﻿using Microsoft.AspNet.Identity;
using SimpleCRM.Data;
using SimpleCRM.Models.OrganizationModel;
using SimpleCRM.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace SimpleCRM.Controllers
{
    [Authorize]
    public class OrganizationController : Controller
    {
        // GET: Organization
        public ActionResult Index()
        {
            var service = CreateOrganizationService();
            var model = service.GetOrganizations();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrganizationCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateOrganizationService();

            if (service.CreateOrganization(model))
            {
                TempData["SaveResult"] = "Organization added.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Organization could not be added.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var service = CreateOrganizationService();
            var model = service.GetOrganizationById(id);

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
                TempData["SaveResult"] = "the organization was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "the organization could not be updated.");
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

            TempData["SaveResult"] = "The organization was removed";

            return RedirectToAction("Index");
        }

        private OrganizationService CreateOrganizationService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new OrganizationService(userId);
            return service;
        }
    }
}