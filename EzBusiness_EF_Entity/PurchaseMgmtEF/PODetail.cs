using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_EF_Entity
{
    public partial class PODetail
    {
        public string CmpyCode { get; set; }
        public string PoNumber { get; set; }
        public string LocCode { get; set; }
        public int Sno { get; set; }
        public string ItemCode { get; set; }
        public string Description { get; set; }
        public string Packing { get; set; }
        public Nullable<decimal> BaseUnitQty { get; set; }
        public string Unit { get; set; }
        public decimal QtyOrdered { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal ItemTotal { get; set; }
        public decimal? DiscountP { get; set; }
        public decimal? Discount { get; set; }
        public decimal? IncludingVAT { get; set; }
        public decimal? VATPerc { get; set; }
        public decimal VATAmount { get; set; }
        public decimal NetAmount { get; set; }
        public decimal QtyReceived { get; set; }
        public decimal NetPurchase { get; set; }
        public decimal QtyShip { get; set; }
        public decimal PoQtyShort { get; set; }
        public decimal QtyDamage { get; set; }
        public string InqNumber { get; set; }
        public string PerformaInvNo { get; set; }
        public string Notes { get; set; }
        public decimal PoQtyAdd { get; set; }
        public decimal BoxOrdered { get; set; }
        public decimal BaseOrder { get; set; }
        public decimal BaseReceived { get; set; }
        public decimal BaseDamage { get; set; }
        public string ProjectCode { get; set; }
        public string AnalysisCode { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal NetAmountWithTax { get; set; }
        public decimal ItemActualCost { get; set; }
        public string Cust_Item_Code { get; set; }
        public string Cust_Item_Name { get; set; }
        public decimal Other_Amt { get; set; }
        public decimal Other_Per { get; set; }
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
        public decimal GrnInQty { get; set; }
        public int ItemSno { get; set; }
        public string ProcessCode { get; set; }
        public string ProcessName { get; set; }
        public int InvItemSno { get; set; }
        public decimal ReOpenQty { get; set; }
        public string ReOpenReason { get; set; }
        public string Specification { get; set; }
        public int BOQSno { get; set; }
        public int PackageSno { get; set; }
        public string CostCode { get; set; }
        public int OverBudget { get; set; }
        public int RevisionNo { get; set; }
        public decimal OnOrderDiscPerc { get; set; }
        public decimal OnOrderDiscAmt { get; set; }
        public decimal LNetAmount { get; set; }
        public decimal AvgCost { get; set; }
        public byte[] Product_Img { get; set; }
        public string Select_Img { get; set; }
        public string FileType { get; set; }
        public string WoNumber { get; set; }
    }
}
