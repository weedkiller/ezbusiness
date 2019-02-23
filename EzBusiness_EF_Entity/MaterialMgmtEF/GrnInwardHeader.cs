using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
namespace EzBusiness_EF_Entity.MaterialMgmtEF
{
   public partial  class GrnInwardHeader
    {
        public string CmpyCode { get; set; }
        public string GrnInNumber { get; set; }
        public DateTime Dates { get; set; }
        public string InType { get; set; }
        public string PartyCode { get; set; }
        public string PartyChallanNo { get; set; }
        public DateTime PartyChallanDate { get; set; }
        public string PartyBillNo { get; set; }
        public DateTime PartyBillDate { get; set; }
        public string GateEntryNo { get; set; }
        public string ExciseGatePassNo { get; set; }
        public string OctroiMemoNo { get; set; }
        public string Transporter { get; set; }
        public string VehicleNo { get; set; }
        public string LRNo { get; set; }
        public string PartyName { get; set; }
        public DateTime ExciseGatePassDate { get; set; }
        public DateTime OctroiDate { get; set; }
        public string Location { get; set; }
        public string ProjectCode { get; set; }
        public string ResourceType { get; set; }
        public string CurCode { get; set; }
        public decimal CurRate { get; set; }
        public DateTime ClosingDate { get; set; }
        public string Remark { get; set; }
        public int IsClosed { get; set; }
        public string WONo { get; set; }

    }
}
