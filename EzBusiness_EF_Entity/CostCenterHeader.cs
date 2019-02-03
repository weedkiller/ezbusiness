using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_EF_Entity
{
    public partial class CostCenterHeader
    {
        public string CmpyCode { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string ConsultantCode { get; set; }
        public string WorkType { get; set; }
        public string Sector { get; set; }
        public int Active { get; set; }
        public int Budget { get; set; }
        public string ClientCode { get; set; }
        public string BankAcc { get; set; }
        public string Address { get; set; }
        public string CtPerson { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public decimal ProjectValue { get; set; }
        public decimal ApprovedValue { get; set; }
        public decimal AdvancePerc { get; set; }
        public decimal RetentionPerc { get; set; }
        public int LastPCNo { get; set; }
        public decimal OpBalance { get; set; }
        public string ParentID { get; set; }
        public int Levels { get; set; }
        public int Sno { get; set; }
        public string GenDet { get; set; }
        public string ResourceType { get; set; }
        public int ChildApplicable { get; set; }
        public string ApprovalYN { get; set; }
        public string CmpyUnitCode { get; set; }
        public string SONumber { get; set; }
        public decimal CompletePerCentage { get; set; }
        public string PaymentMode { get; set; }
        public decimal InstallmentNumber { get; set; }
        public decimal ContractAmount { get; set; }
        public decimal Advance { get; set; }
        public decimal BalanceAmount { get; set; }
        public decimal InstallmentAmount { get; set; }
        public Nullable<System.DateTime> InstallmentStartDate { get; set; }
        public Nullable<System.DateTime> InstallmentEndDate { get; set; }
        public int AlertDays { get; set; }
        public int LastPay { get; set; }
        public string AllocatedFor { get; set; }
    }
}
