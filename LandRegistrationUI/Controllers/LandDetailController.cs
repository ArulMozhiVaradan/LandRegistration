using LandRegistrationUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LandRegistrationUI.Controllers
{
    public class LandDetailController : Controller
    {
        LandDetailsEntities1 db = new LandDetailsEntities1();
        // GET: LandDetail
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserRecord()
        {

            return View();
        }

        public ActionResult UserDetails()
        {
            var details = db.UsersDatas
                .FirstOrDefault();
            return View(details);
        }
    }
}