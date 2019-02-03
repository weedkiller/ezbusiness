using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_EF_Entity
{
    public partial class WorkOrderHeader
    {
        public string CmpyCode { get; set; }
        public string WoCode { get; set; }
        public Nullable<System.DateTime> Dates { get; set; }
        public string PmServiceCode { get; set; }
        public string ComplaintAgainstPC { get; set; }
        public string LocCode { get; set; }
        public string WorkDetails { get; set; }
        public Nullable<System.DateTime> CreatedON { get; set; }
        public string AgainstCode { get; set; }
        public string LoggedTime { get; set; }
        public string PropertyType { get; set; }
        public string PropertyCode { get; set; }
        public string SiteEngineer { get; set; }
        public string AssignTo { get; set; }
        public string WoStatus { get; set; }
        public decimal ContractAmount { get; set; }
        public string PreparedBy { get; set; }
        public int IsPopUpCheckedByUser { get; set; }
        public string ProjectCode { get; set; }
        public string Remark { get; set; }
        public string IssueCategory { get; set; }
        public string ProgressStatus { get; set; }
        public string SendSms { get; set; }
        public string MailSend { get; set; }
        public string StartDate { get; set; }
        public string StartTime { get; set; }
        public string EndDate { get; set; }
        public string EndTime { get; set; }
        public int WOCompleted { get; set; }
        public string Priority { get; set; }
        public string IsSubContractorWork { get; set; }
        public string CustMobNo { get; set; }
        public string SupMobNo { get; set; }
    }
}
