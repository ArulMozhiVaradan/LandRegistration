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

        public List<SelectListItem> GetRegionList()
        {
            List<SelectListItem> regionList = new List<SelectListItem>();
            var regions = db.RegionMasters.ToList();
            foreach (var item in regions)
            {
                SelectListItem o = new SelectListItem();
                o.Text = item.Region;
                o.Value = item.Id.ToString();
                regionList.Add(o);
            }
            return regionList;
        }

        public ActionResult UpdateTaluk()
        {
            ViewBag.regionList = GetRegionList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateTaluk(TalukMaster model)
        {
            db.TalukMasters.Add(model);
            db.SaveChanges();
            return RedirectToAction(nameof(UpdateTaluk));
        }

        public ActionResult UpdateRevenueVillage()
        {
            ViewBag.regionList = GetTalukList();
            return View();
        }

        private List<SelectListItem> GetTalukList()
        {
            List<SelectListItem> talukList = new List<SelectListItem>();
            var taluks = db.TalukMasters.ToList();
            foreach (var item in taluks)
            {
                SelectListItem o = new SelectListItem();
                o.Text = item.TalukName;
                o.Value = item.TalukID.ToString();
                talukList.Add(o);
            }
            return talukList;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateRevenueVillage(RevenueVillageMaster model)
        {
            db.RevenueVillageMasters.Add(model);
            db.SaveChanges();
            return RedirectToAction(nameof(UpdateRevenueVillage));
        }

        public ActionResult UpdateWard()
        {
            ViewBag.regionList = GetRevenueVillage();
            return View();
        }

        private List<SelectListItem> GetRevenueVillage()
        {
            List<SelectListItem> revenueList = new List<SelectListItem>();
            var taluks = db.RevenueVillageMasters.ToList();
            foreach (var item in taluks)
            {
                SelectListItem o = new SelectListItem();
                o.Text = item.RevenueVillageName;
                o.Value = item.Id.ToString();
                revenueList.Add(o);
            }
            return revenueList;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateWard(WardMaster model)
        {
            db.WardMasters.Add(model);
            db.SaveChanges();
            return RedirectToAction(nameof(UpdateWard));
        }

        public ActionResult UpdateBlock()
        {
            ViewBag.regionList = GetRevenueVillage();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateBlock(BlockMaster model)
        {
            db.BlockMasters.Add(model);
            db.SaveChanges();
            return RedirectToAction(nameof(UpdateBlock));
        }

    }
}