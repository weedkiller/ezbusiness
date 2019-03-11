using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EzBusiness_ViewModels.Models.MaterialMgmt
{
    public class GrnInwardVM
    {

        public bool IsEditMode { get; set; }
        public bool IsSavedFlag { get; set; }
        public string ErrorMessage { get; set; }
        public string CmpyCode { get; set; }
        public string GrnInNumber { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Dates { get; set; }
        public string InType { get; set; }
        public string PartyCode { get; set; }
        public List<SelectListItem> PartyCodeList { get; set; }
        public string PartyChallanNo { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PartyChallanDate { get; set; }
        public string PartyBillNo { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PartyBillDate { get; set; }
        public string GateEntryNo { get; set; }
        public string ExciseGatePassNo { get; set; }
        public string OctroiMemoNo { get; set; }
        public string Transporter { get; set; }
        public string VehicleNo { get; set; }
        public string LRNo { get; set; }
        public string PartyName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ExciseGatePassDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime OctroiDate { get; set; }
        public string Location { get; set; }

        public List<SelectListItem> LocationList { get; set; }

        public string ProjectCode { get; set; }
        public List<SelectListItem> ProjectCodeList { get; set; }

        public string ResourceType { get; set; }
        public string CurCode { get; set; }

        public List<SelectListItem> CurCodeList { get; set; }
        public decimal CurRate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ClosingDate { get; set; }
        public string Remark { get; set; }
        public int IsClosed { get; set; }
        public string WONo { get; set; }
        public List<SelectListItem> WONoList { get; set; }

        public List<GrnInwardDetailnew> GrnInwardDetailnew { get; set; }

        public GrnInwardDetailnew GrnInwardDetail { get; set; }
    }
    public class GrnInwardDetailnew
    {
        public int SNo { get; set; }
        public string ItemCode { get; set; }
        public string Description { get; set; }
        public string PONo { get; set; }
        public decimal POBalQty { get; set; }
        public decimal ChallanQty { get; set; }
        public decimal ReceivedQty { get; set; }
        public decimal PORate { get; set; }
        public string POUnit { get; set; }
        public string QCYN { get; set; }
        public decimal BaseUnitQty { get; set; }
        public decimal QCQty { get; set; }
        public decimal FOCQty { get; set; }
        public decimal ActReceivedQty { get; set; }
        public decimal SurplusQty { get; set; }
        public decimal ReceivedBaseQty { get; set; }
        public decimal ActReceivedBaseQty { get; set; }
        public decimal SurplusBaseQty { get; set; }
        public decimal POBalBaseQty { get; set; }
        public decimal ChallanBaseQty { get; set; }
        public int PoSNo { get; set; }
        public int ItemSNo { get; set; }
        public int InvItemSNo { get; set; }
        public string Specification { get; set; }
        public string FUNo { get; set; }
        public decimal QtyShip { get; set; }
        public int BOQSno { get; set; }
        public int PackageSno { get; set; }
        public string CostCode { get; set; }
        public string RevisionNo { get; set; }
    }
}