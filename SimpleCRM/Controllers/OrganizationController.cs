using SimpleCRM.Models.OrganizationModel;
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
    }
}