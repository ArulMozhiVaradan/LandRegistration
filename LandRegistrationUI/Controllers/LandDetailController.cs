using LandRegistrationUI.Models;
using LandRegistrationUI.Models.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
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
            LandSearchViewModel model = new LandSearchViewModel();
            var regions = db.RegionMasters.ToList();
            model.RegionList = regions.Select(x => new SelectListItem() { Text = x.Region, Value = x.Id.ToString() }).ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(LandSearchViewModel model)
        {
            model.RegionList = db.RegionMasters.Select(x => new SelectListItem() { Text = x.Region, Value = x.Id.ToString() }).ToList();
            model.TalukList = db.TalukMasters.Where(x => x.RegionID == model.Region).Select(x => new SelectListItem() { Value = x.TalukID.ToString(), Text = x.TalukName }).ToList();
            model.RevenueList = db.RevenueVillageMasters.Where(x => x.Id == model.Revenue).Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.RevenueVillageName }).ToList();
            model.WardList = db.WardMasters.Where(x => x.WardID == model.Ward).Select(x => new SelectListItem() { Value = x.WardID.ToString(), Text = x.WardName }).ToList();
            model.BlockList = db.BlockMasters.Where(x => x.BlockID == model.Block).Select(x => new SelectListItem() { Value = x.BlockID.ToString(), Text = x.BlockName }).ToList();

            model.LandDetails = db.UsersDatas
                .Include(x => x.TalukMaster)
                .Include(x => x.RevenueVillageMaster)
                .Include(x => x.BlockMaster)
                .Include(x => x.RegionMaster)
                .Where(x =>
                (x.RegionID == model.Region || model.Region == 0) &&
                (x.TalukID == model.Taluk || model.Taluk == 0) &&
                (x.RevenueVillageID == model.Revenue || model.Revenue == 0) &&
                (x.WardID == model.Ward || model.Ward == 0) &&
                (x.BlockID == model.Block || model.Block == 0) &&
                (x.TSNo == model.TSNo || string.IsNullOrEmpty(model.TSNo))
            )
                .Select(x => new LandDetailsModel()
                {
                    ID = x.ID,
                    AddressLine1 = x.AddressLine1,
                    AddressLine2 = x.AddressLine2,
                    AddressLine3 = x.AddressLine3,
                    BlockID = x.BlockID,
                    BlockName = x.BlockMaster.BlockName,
                    OwnerName = x.OwnerName,
                    PattaNo = x.PattaNo,
                    PreviousOwnerAddLine1 = x.PreviousOwnerAddLine1,
                    PreviousOwnerAddLine2 = x.PreviousOwnerAddLine2,
                    PreviousOwnerAddLine3 = x.PreviousOwnerAddLine3,
                    RegionID = x.RegionID,
                    RegionName = x.RegionMaster.Region,
                    Remarks = x.Remarks,
                    RevenueVillageID = x.RevenueVillageID,
                    RevenueVillageName = x.RevenueVillageMaster.RevenueVillageName,
                    RSNo = x.RSNo,
                    SubDivisionNo = x.SubDivisionNo,
                    TalukID = x.TalukID,
                    TalukName = x.TalukMaster.TalukName,
                    TenantName = x.TenantName,
                    TSNo = x.TSNo,
                    WardID = x.WardID,
                    WardName = ""
                })
                .ToList();
            return View(model);
        }
        public JsonResult GetTaluks(int regionId)
        {
            var taluks = db.TalukMasters.Where(x => x.RegionID == regionId).Select(x => new { x.TalukID, x.TalukName }).ToList();

            return Json(taluks, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetRevenue(int talukId)
        {
            var revenues = db.RevenueVillageMasters.Where(x => x.TalukID == talukId).Select(x => new { x.RevenueVillageName, x.Id }).ToList();

            return Json(revenues, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetWardAndBlock(int revenueId)
        {
            var wards = db.WardMasters.Where(x => x.RevenueVillageID == revenueId).Select(x => new { x.WardID, x.WardName }).ToList();
            var blocks = db.BlockMasters.Where(x => x.RevenueVillageId == revenueId).Select(x => new { x.BlockID, x.BlockName }).ToList();
            var output = new
            {
                Ward = wards,
                Block = blocks
            };
            return Json(output, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetWards(int revenueId)
        {
            var wards = db.WardMasters.Where(x => x.RevenueVillageID == revenueId).Select(x => new { x.WardID, x.WardName }).ToList();

            return Json(wards, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetBlocks(int revenueId)
        {
            var blocks = db.BlockMasters.Where(x => x.RevenueVillageId == revenueId).Select(x => new { x.BlockID, x.BlockName }).ToList();

            return Json(blocks, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UserRecord()
        {

            return View();
        }

        public ActionResult UserDetails(int id)
        {
            var details = db.UsersDatas.Include(x=>x.UserImages).FirstOrDefault(x => x.ID == id);
            return View(details);
        }

        public ActionResult AddUserData()
        {
            LandSearchViewModel model = new LandSearchViewModel();
            var regions = db.RegionMasters.ToList();
            model.RegionList = regions.Select(x => new SelectListItem() { Text = x.Region, Value = x.Id.ToString() }).ToList();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddUserData(LandSearchViewModel model)
        {
            UsersData data = new UsersData()
            {
                RegionID = (byte)model.Region,
                TalukID = model.Taluk,
                RevenueVillageID = model.Revenue,
                OwnerName = model.Details.OwnerName,
                TenantName = model.Details.TenantName,
                AddressLine1 = model.Details.AddressLine1,
                AddressLine2 = model.Details.AddressLine2,
                AddressLine3 = model.Details.AddressLine3,
                PreviousOwnerAddLine1 = model.Details.PreviousOwnerAddLine1,
                PreviousOwnerAddLine2 = model.Details.PreviousOwnerAddLine2,
                PreviousOwnerAddLine3 = model.Details.PreviousOwnerAddLine3,
                PattaNo = model.LGR,
                RSNo = model.RSNo,
                TSNo = model.TSNo,
                Remarks = model.Details.Remarks,

            };
            if (model.Ward != 0)
                data.WardID = model.Ward;
            if (model.Block != 0)
                data.BlockID = model.Block;
            var id = db.UsersDatas.Add(data);
            db.SaveChanges();
            List<UserImage> images = new List<UserImage>();
            foreach (HttpPostedFileBase file in model.files)
            {
                if (file != null)
                {
                    var InputFileName = Path.GetFileName(file.FileName);
                    var ServerSavePath = Path.Combine(Server.MapPath("~/Images/") + InputFileName);
                    var path = "/Images/"+InputFileName;
                    file.SaveAs(ServerSavePath);
                    UserImage image = new UserImage()
                    {
                        UserDataID = id.ID,
                        ImagePath = path
                    };
                    images.Add(image);
                }
            }
            db.UserImages.AddRange(images);
            db.SaveChanges();
            TempData[Constants.SuccessAlert] = "Updated Successfully";
            return RedirectToAction(nameof(AddUserData));
        }

    }
}