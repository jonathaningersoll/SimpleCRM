using Microsoft.AspNet.Identity;
using SimpleCRM.Models.OrganizationModel;
using SimpleCRM.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleCRM.Controllers
{
    public class OrganizationController : Controller
    {
        // GET: Organization
        public ActionResult Index()
        {
            var model = new OrganizationListItem[0];
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
            var service = CreateCustomerService();
            var model = service.GetCustomerById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateCustomerService();
            var detail = service.GetCustomerById(id);
            var model =
                new CustomerEdit
                {
                    CustomerId = detail.CustomerId,
                    CustomerFirstName = detail.CustomerFirstName,
                    CustomerLastName = detail.CustomerLastName,
                    Organization = detail.Organization,
                    Role = detail.Role,
                    Points = detail.Points,
                    Status = detail.Status,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CustomerEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.CustomerId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateCustomerService();

            if (service.UpdateCustomer(model))
            {
                TempData["SaveResult"] = "Your note was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your note could not be updated.");
            return View();
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateCustomerService();
            var model = svc.GetCustomerById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateCustomerService();

            service.DeleteCustomer(id);

            TempData["SaveResult"] = "Your note was deleted";

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