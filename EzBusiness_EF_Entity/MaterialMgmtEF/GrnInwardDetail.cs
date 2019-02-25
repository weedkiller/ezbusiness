using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_EF_Entity.MaterialMgmtEF
{
    public partial class GrnInwardDetail
    {

        public string CmpyCode { get; set; }
        public string GrnInNumber { get; set; }
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
