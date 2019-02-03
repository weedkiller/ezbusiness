using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_EF_Entity
{
    public partial class Supplier
    {
        public string Cmpycode { get; set; }
        public string Suppliercode { get; set; }
        public string InventoryCode { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PoBox { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Others { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public int CreditLimitInDays { get; set; }
        public decimal CreditLimitAmount { get; set; }
        public decimal TotalInvoiceAmounts { get; set; }
        public decimal OutstandingBalance { get; set; }
        public Nullable<System.DateTime> LastPurchaseDate { get; set; }
        public Nullable<System.DateTime> LastPaymentDate { get; set; }
        public decimal TotalAmountPaid { get; set; }
        public string CtPersonOne { get; set; }
        public string CtPersonTwo { get; set; }
        public string CtPhoneOne { get; set; }
        public string Emailid { get; set; }
        public string Notes { get; set; }
        public decimal OBAmt { get; set; }
        public string Stype { get; set; }
        public string IsClient { get; set; }
        public string AccNo { get; set; }
        public string CurCode { get; set; }
        public string ClassCode { get; set; }
        public string ECCNo { get; set; }
        public string ExciseRange { get; set; }
        public string ExciseDivision { get; set; }
        public string Commissionarate { get; set; }
        public string PLANo { get; set; }
        public string RangeAddress { get; set; }
        public string DivisionAddreess { get; set; }
        public string CommAddress { get; set; }
        public string VATTINNo { get; set; }
        public string CSTTINNo { get; set; }
        public string AllotedCode { get; set; }
        public string ServiceTaxNo { get; set; }
        public string ServiceProviding { get; set; }
        public string ExciseType { get; set; }
        public string MobileNo { get; set; }
        public string BillAdjForPayment { get; set; }
        public decimal RateOfInt { get; set; }
        public string IntType { get; set; }
        public string OnAmt { get; set; }
        public string CalOn { get; set; }
        public string CalFrom { get; set; }
        public string ApplyIntCalYN { get; set; }
        public string AreaCode { get; set; }
        public string BankName { get; set; }
        public string BankBranch { get; set; }
        public string BankAccNo { get; set; }
        public string IFSCCode { get; set; }
        public int IsTDSApplicable { get; set; }
        public string TDSType { get; set; }
        public string PaymentNature { get; set; }
        public string TDSSection { get; set; }
        public decimal TDSPerc { get; set; }
        public string SupplierType { get; set; }
        public string Designation { get; set; }
        public string Website { get; set; }
        public string ChequeBeneficiary { get; set; }
        public bool IsCommon { get; set; }
        public int Approved { get; set; }
    }
}
