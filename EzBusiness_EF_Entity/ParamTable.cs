using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_EF_Entity
{
    public partial class ParamTable
    {
        public string Cmpycode { get; set; }
        public string Code { get; set; }
        public string LocCode { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public int Nos { get; set; }
        public string DbAcc { get; set; }
        public string CrAcc { get; set; }
        public string DbAcc2 { get; set; }
        public string CrAcc2 { get; set; }
        public string DbAcc3 { get; set; }
        public string CrAcc3 { get; set; }
        public string DbAcc4 { get; set; }
        public string CrAcc4 { get; set; }
        public string Auto { get; set; }
        public int TotalDigits { get; set; }
        public string Voucher { get; set; }
        public string CaptionDescription { get; set; }
        public string AccTypes { get; set; }
        public string Suffix { get; set; }
        public string DeptCode { get; set; }
        public string FormatNo { get; set; }
        public string RevisionNo { get; set; }
        public string StorageLoc { get; set; }
        public string FileType { get; set; }
        public string FileId { get; set; }
        public Nullable<System.DateTime> FormatDate { get; set; }
        public Nullable<System.DateTime> RevisionDate { get; set; }
        public string DocCode { get; set; }
        public int UseProject { get; set; }
        public int UseYears { get; set; }
        public int UseLocation { get; set; }
    }
}
