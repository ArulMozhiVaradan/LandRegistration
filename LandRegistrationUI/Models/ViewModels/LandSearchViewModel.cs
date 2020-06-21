using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LandRegistrationUI.Models.ViewModels
{
    public class LandSearchViewModel
    {
        public int Region { get; set; }
        public int Taluk { get; set; }
        public int Revenue { get; set; }
        public string LGR { get; set; }
        public int Ward { get; set; }
        public int Block { get; set; }
        public string TSNo { get; set; }
        public string RSNo { get; set; }
        public string SubDivision { get; set; }
        public List<LandDetailsModel> LandDetails { get; set; }
        public LandDetailsModel Details { get; set; }
        public IEnumerable<SelectListItem> RegionList { get; set; } = new List<SelectListItem>();
        public IEnumerable<SelectListItem> TalukList { get; set; } = new List<SelectListItem>();
        public IEnumerable<SelectListItem> RevenueList { get; set; } = new List<SelectListItem>();
        public IEnumerable<SelectListItem> WardList { get; set; } = new List<SelectListItem>();
        public IEnumerable<SelectListItem> BlockList { get; set; } = new List<SelectListItem>();
        [Display(Name = "Browse File")]
        public HttpPostedFileBase[] files { get; set; }

    }

    public class LandDetailsModel
    {
        public int ID { get; set; }
        public byte RegionID { get; set; }
        public string RegionName { get; set; }
        public int TalukID { get; set; }
        public string TalukName { get; set; }
        public int? WardID { get; set; }
        public string WardName { get; set; }
        public int? BlockID { get; set; }
        public string BlockName { get; set; }
        public int RevenueVillageID { get; set; }
        public string RevenueVillageName { get; set; }
        public string TSNo { get; set; }
        public string SubDivisionNo { get; set; }
        public string RSNo { get; set; }
        public string PattaNo { get; set; }
        public string OwnerName { get; set; }
        public string TenantName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string PreviousOwnerAddLine1 { get; set; }
        public string PreviousOwnerAddLine2 { get; set; }
        public string PreviousOwnerAddLine3 { get; set; }
        public string Remarks { get; set; }
    }
}