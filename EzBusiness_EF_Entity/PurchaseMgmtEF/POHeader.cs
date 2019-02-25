using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace EzBusiness_EF_Entity
{
    public partial class POHeader
    {
        public string CmpyCode { get; set; }
        public string PONumber { get; set; }
        public string LocCode { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> Dates { get; set; }
        public string SupplierCode { get; set; }
        public string Status { get; set; }
        public string GrnStat { get; set; }
        public string CurCode { get; set; }
        public decimal CurRate { get; set; }
        public string YourRef { get; set; }
        public decimal GAmount { get; set; }
        public decimal DiscountP { get; set; }
        public decimal Discount { get; set; }
        public decimal NetAmount { get; set; }
        public decimal LAmount { get; set; }
        public string Remarks { get; set; }
        public string Att { get; set; }
        public string ProjectCode { get; set; }
        public string DivisionCode { get; set; }
        public string PerformaInvYN { get; set; }
        public Nullable<System.DateTime> ShipDate { get; set; }
        public string SoNumber { get; set; }
        public string SalesManCode { get; set; }
        public Nullable<System.DateTime> ProformaDates { get; set; }
        public string PaymentCode { get; set; }
        public string ModeOfPay { get; set; }
        public decimal DiscPerc { get; set; }
        public string PerformaInvNo { get; set; }
        public string ConsultCode { get; set; }
        public string ContractCode { get; set; }
        public string CC { get; set; }
        public string InquiryNo { get; set; }
        public string FullClear { get; set; }
        public string PoConfirm { get; set; }
        public string ReadyToShip { get; set; }
        public string Weight { get; set; }
        public string FollowUpStatus { get; set; }
        public string PoSchedule { get; set; }
        public string PoType { get; set; }
        public string POCloseManual { get; set; }
        public string AdditionalTerms { get; set; }
        public string InvStatus { get; set; }
        public decimal OnOrderTax { get; set; }
        public string POFrom { get; set; }
        public string QuotCode { get; set; }
        public string ApprovalYN { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> ExpectedDeliveryDate { get; set; }
        public string TaxCalculationCode { get; set; }
        public decimal Asses_Amt { get; set; }
        public decimal Ex_Duty_Per { get; set; }
        public decimal Ex_Duty_Amt { get; set; }
        public decimal Ex_Ed_Cess_Per { get; set; }
        public decimal Ex_Ed_Cess_Amt { get; set; }
        public decimal Ex_H_Ed_Cess_Per { get; set; }
        public decimal Ex_H_Ed_Cess_Amt { get; set; }
        public decimal Ser_Duty_Per { get; set; }
        public decimal Ser_Duty_Amt { get; set; }
        public decimal Ser_Ed_Cess_Per { get; set; }
        public decimal Ser_Ed_Cess_Amt { get; set; }
        public decimal Ser_H_Ed_Cess_Per { get; set; }
        public decimal Ser_H_Ed_Cess_Amt { get; set; }
        public decimal Taxable_Amt { get; set; }
        public decimal Tax_per { get; set; }
        public decimal Tax_Amt { get; set; }
        public decimal Round_Off { get; set; }
        public string Insurance_Policy { get; set; }
        public string POScheduleTYpe { get; set; }
        public string IsSubContractor { get; set; }
        public string LCCode { get; set; }
        public decimal LCAmount { get; set; }
        public decimal LCBalanceAmount { get; set; }
        public decimal TotCharges { get; set; }
        public string IsInternal { get; set; }
        public string ResourceType { get; set; }
        public string PreparedBy { get; set; }
        public string PrepareDate { get; set; }
        public int RevisionNo { get; set; }
        public string Scope { get; set; }
        public string ContractType { get; set; }
        public decimal RetentionPer { get; set; }
        public string IsNotLastPCRetention { get; set; }
        public decimal ContractValue { get; set; }
        public decimal SecurityDepositPer { get; set; }
        public decimal AdvancePer { get; set; }
        public string LCurCode { get; set; }
        public decimal LGAmount { get; set; }
        public decimal LNetAmount { get; set; }
        public decimal DisAmount { get; set; }
        public string DiscountType { get; set; }
        public string SupplierContactPerson { get; set; }
        public decimal OnOrderDisc { get; set; }
        public decimal InterNetValue { get; set; }
        public string WONO { get; set; }
        public string POPriority { get; set; }
        public Nullable<System.DateTime> ValidityDate { get; set; }
        public string ReqtBy { get; set; }
        public string ProjectLocation { get; set; }
    }
}
