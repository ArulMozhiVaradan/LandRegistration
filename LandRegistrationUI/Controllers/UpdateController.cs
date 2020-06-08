using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LandRegistrationUI.Models;

namespace LandRegistrationUI.Controllers
{
    public class UpdateController : Controller
    {
        LandDetailsEntities1 db = new LandDetailsEntities1();
        // GET: Update
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UpdateRegion()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateRegion(RegionMaster model)
        {
            db.RegionMasters.Add(model);
            db.SaveChanges();
            return RedirectToAction(nameof(UpdateRegion));
        }

    }
}