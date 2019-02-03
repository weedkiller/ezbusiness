using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_EF_Entity
{
    public partial class MReqDetail
    {
        public string CmpyCode { get; set; }
        public string MRCode { get; set; }
        public int SNo { get; set; }
        public int BOQSno { get; set; }
        public int PackageSno { get; set; }
        public string CostCode { get; set; }
        public string ItemCode { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public Nullable<decimal> Qty { get; set; }
        public Nullable<decimal> BaseUnitQty { get; set; }
        public decimal BaseQtyReq { get; set; }
        public decimal QtyReceived { get; set; }
        public string Specification { get; set; }
        public int OverBudget { get; set; }
        public string PartNumber { get; set; }
        public byte[] Product_Img { get; set; }
        public string Select_Img { get; set; }
        public string FileType { get; set; }
        public string ImgDesc { get; set; }
    }
}
