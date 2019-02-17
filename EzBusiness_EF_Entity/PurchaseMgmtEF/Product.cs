using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_EF_Entity
{
    public partial class Product
    {
        public string Cmpycode { get; set; }
        public string ItemCode { get; set; }
        public string ClassCode { get; set; }
        public string Description { get; set; }
        public string SubCategoryCode { get; set; }
        public decimal ClosingStock { get; set; }
        public decimal OpeningStock { get; set; }
        public decimal ClosingStockValue { get; set; }
        public decimal OpeningStockValue { get; set; }
        public decimal ClosingAvgCost { get; set; }
        public decimal OpeningAvgCost { get; set; }
        public string Notes { get; set; }
        public string Suppliercode { get; set; }
        public string Brand { get; set; }
        public string Sizes { get; set; }
        public string Unit { get; set; }
        public string ColorCode { get; set; }
        public decimal ReorderQty { get; set; }
        public decimal SalePrice { get; set; }
        public decimal MaxDiscPercent { get; set; }
        public int QtyInPOs { get; set; }
        public string UserId { get; set; }
        public string Ptype { get; set; }
        public decimal BoxPkt { get; set; }
        public string Model { get; set; }
        public string Packing { get; set; }
        public int SrNo { get; set; }
        public string SizeType { get; set; }
        public decimal ClosingStockInSqm { get; set; }
        public string Thickness { get; set; }
        public string FinishCode { get; set; }
        public string TypeCode { get; set; }
        public string CurCode { get; set; }
        public decimal PurCost { get; set; }
        public string BarCode { get; set; }
        public decimal VATPerc { get; set; }
        public decimal IncludingVAT { get; set; }
        public string TargetCode { get; set; }
        public decimal TargetQty { get; set; }
        public decimal COGSYN { get; set; }
        public int NonInventoryItem { get; set; }
        public string ProductType { get; set; }
        public string FGoodType { get; set; }
        public int BatchMandatory { get; set; }
        public int LeadTime { get; set; }
        public string TariffHeading { get; set; }
        public decimal MinimumLevel { get; set; }
        public decimal MaximumLevel { get; set; }
        public int Levels { get; set; }
        public string ParentID { get; set; }
        public int ProductYN { get; set; }
        public string SubOf { get; set; }
        public string PrdType { get; set; }
        public string QCYN { get; set; }
        public int POSTax { get; set; }
        public string POSTaxCode { get; set; }
        public decimal SurplusPerc { get; set; }
        public string Field1 { get; set; }
        public string Field2 { get; set; }
        public string Field3 { get; set; }
        public string Field4 { get; set; }
        public string Field5 { get; set; }
        public int SubCodeYN { get; set; }
        public string CustomerItemCode { get; set; }
        public string CustomerItemName { get; set; }
        public int ShowInPurchase { get; set; }
        public int ShowInSale { get; set; }
        public string AccNo { get; set; }
        public string HasSerial { get; set; }
        public string HasVariableCost { get; set; }
        public Nullable<System.DateTime> Expectedtime { get; set; }
        public string Expectedcomplitiontime { get; set; }
        public string PartNumber { get; set; }
    }
}
