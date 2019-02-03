using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_EF_Entity
{
    public partial class JobHeader
    {
        public string CmpyCode { get; set; }
        public string JobNo { get; set; }
        public Nullable<System.DateTime> Dates { get; set; }
        public string SoNumber { get; set; }
        public Nullable<System.DateTime> SoDate { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<System.DateTime> DeliveryDate { get; set; }
        public string JType { get; set; }
        public string ItemCode { get; set; }
        public string BomCode { get; set; }
        public string Description { get; set; }
        public string CustomerCode { get; set; }
        public decimal SOQty { get; set; }
        public decimal JobQty { get; set; }
        public string Status { get; set; }
        public decimal TotalRM { get; set; }
        public decimal TotalIndirectCost { get; set; }
        public decimal TotalCost { get; set; }
        public decimal TotalRMT { get; set; }
        public decimal TotalIndirectCostT { get; set; }
        public decimal TotalCostT { get; set; }
        public string Apvd { get; set; }
        public Nullable<System.DateTime> ApvDate { get; set; }
        public Nullable<System.DateTime> ApvTime { get; set; }
        public string ApvBy { get; set; }
        public string QcStatus { get; set; }
        public string QStatus { get; set; }
        public string JobStatus { get; set; }
        public string RStatus { get; set; }
        public string WStatus { get; set; }
        public string MRStatus { get; set; }
        public string ReceiptStatus { get; set; }
        public decimal JobDays { get; set; }
        public string VehicleNo { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string MYear { get; set; }
        public string FuelType { get; set; }
        public string ColorCode { get; set; }
        public string TypeSize { get; set; }
        public string EngineSize { get; set; }
        public string Color { get; set; }
        public string EngineNo { get; set; }
        public string ChasisNo { get; set; }
        public string ServiceDate { get; set; }
        public string MeterReading { get; set; }
        public string Remarks { get; set; }
        public string Rev { get; set; }
        public string ServiceCode { get; set; }
        public string EmpCode { get; set; }
        public string WarrentyYN { get; set; }
        public string OldWStatus { get; set; }
        public string ReleaseDateTime { get; set; }
        public string ProcessDateTime { get; set; }
        public string HoldDateTime { get; set; }
        public string CompleteDateTime { get; set; }
        public string JOReleaseDateTime { get; set; }
        public string JOHoldDateTime { get; set; }
        public string JOQCDateTime { get; set; }
        public string JOCompleteDateTime { get; set; }
        public string JOReceiptDateTime { get; set; }
        public string PriorityCode { get; set; }
        public int JobReleased { get; set; }
        public int WorkCenterReleased { get; set; }
        public int WorkCenterProcessed { get; set; }
        public int WorkCenterCompleted { get; set; }
        public int QCApproved { get; set; }
        public int JobCompleted { get; set; }
        public int JobReceived { get; set; }
        public string LocCode { get; set; }
        public string CrAcc { get; set; }
        public string DbAcc { get; set; }
        public int TransNo { get; set; }
        public string ApprovalYN { get; set; }
        public string DivisionCode { get; set; }
        public string ProjectCode { get; set; }
        public string PPNo { get; set; }
        public string RevNo { get; set; }
        public Nullable<System.DateTime> RevDate { get; set; }
        public string OpenYN { get; set; }
        public string Unit { get; set; }
        public string BOMNumber { get; set; }
        public decimal BalanceJobQty { get; set; }
        public string JobStatusFromWIP { get; set; }
    }
}
