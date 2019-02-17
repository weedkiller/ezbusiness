using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EzBusiness_ViewModels.Models.PurchaseMgmt
{
    public class PurchaseReqVM
    {
        public bool IsEditMode { get; set; }

        public bool IsSavedFlag { get; set; }

        public string ErrorMessage { get; set; }

        public string CmpyCode { get; set; }

        public string MRCode { get; set; }

        public List<SelectListItem> ProjectList { get; set; }

        public string ProjectCode { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? PODate { get; set; }

        public string ResourceType { get; set; }

        public List<SelectListItem> LocationList { get; set; }

        public string LocationCode { get; set; }

        public List<SelectListItem> RequesterList { get; set; }

        public string RequesterCode { get; set; }

        public string PreparedBy { get; set; }

        public string Description { get; set; }

        public List<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }

        public PurchaseOrderDetail PODetail { get; set; }

        public List<SelectListItem> UnitList { get; set; }

        public List<SelectListItem> ItemCodeList { get; set; }

    }
    public class PurchaseOrderDetail
    {
        public string ItemCode { get; set; }

        public string Description { get; set; }

        public string Specification { get; set; }

        public string Unit { get; set; }

        public decimal? Quantity { get; set; }
    }
}
