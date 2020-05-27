using Microsoft.AspNet.Identity;
using SimpleCRM.Models.CustomerModel;
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
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            var service = CreateCustomerService();
            var model = service.GetCustomers();

            return View(model);
        }

        public ActionResult Create()
        {
            var service = CreateOrganizationService();
            var list = service.GetOrganizations();

            ViewBag.OrganizationId = new SelectList(list, "OrganizationId", "OrganizationName");

            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateCustomerService();

            if (service.CreateCustomer(model))
            {
                TempData["SaveResult"] = "Customer added.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Customer could not be added.");

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
                TempData["SaveResult"] = "The customer was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The customer could not be updated.");
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

            TempData["SaveResult"] = "The customer was removed";

            return RedirectToAction("Index");
        }

        private CustomerService CreateCustomerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CustomerService(userId);
            return service;
        }

        private OrganizationService CreateOrganizationService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new OrganizationService(userId);
            return service;
        }

    }
}