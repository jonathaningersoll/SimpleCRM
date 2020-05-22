using SimpleCRM.Models.CustomerModel;
using SimpleCRM.Models.OrganizationModel;
using SimpleCRM.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleCRM.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            ViewBag.Title = "Something New";
            var model = new CustomerListItem[0];
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        // SELECT LIST FOR ORGANIZATION
        //public ActionResult Create()
        //{
        //    //var service = new OrganizationService();
        //    var list = new List<OrganizationListItem> { new OrganizationListItem { OrganizationId = 1, OrgName = "First"},
        //    new OrganizationListItem{OrganizationId = 2, OrgName = "Second"}};
        //    ViewBag.OrganizationId = new SelectList(list, "OrganizationId", "OrgName");
        //    return View();
        //}
    }
}