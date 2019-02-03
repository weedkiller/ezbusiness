using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_EF_Entity
{
    public partial class MReqHeader
    {
        public string CmpyCode { get; set; }
        public string MRCode { get; set; }

        //public string POReq { get; set; }
        //public string POFrom { get; set; }
        
        public Nullable<System.DateTime> Dates { get; set; }
        public string LocCode { get; set; }
        public string Description { get; set; }
        public string EmpCode { get; set; }
        public string PreparedBy { get; set; }
        public string ProjectCode { get; set; }
        public string ResourceType { get; set; }
        public string ApprovalYN { get; set; }
        public string Status { get; set; }
        public string MRFrom { get; set; }
        public string JobNo { get; set; }
        public string Priority { get; set; }
        public string RType { get; set; }
        public string WONo { get; set; }
        public int IsPopUpCheckedByUser { get; set; }
        public int DontShowJobInList { get; set; }
        public string GenerateInquiry { get; set; }
    }
}
