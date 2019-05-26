using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EzBusiness_ViewModels.Models.FreightManagement
{
   public class FFM_CRG_VM
    {
        public string CREATED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }
        public string UPDATED_BY { get; set; }
        public DateTime UPDATED_ON { get; set; }
        public string CMPYCODE { get; set; }       
        public string FFM_CRG_001_CODE { get; set; }
        public string NAME { get; set; }
        public List<SelectListItem> CRG_GROUP_CODEList { get; set; }
        public List<SelectListItem> CRG_job_CODEList { get; set; }

        public string INCOME_ACT { get; set; }
        public List<SelectListItem> IncomeACTList { get; set; }
        public string FFM_CRG_GROUP_CODE { get; set; }
        public string DISPLAY_STATUS { get; set; }
        public bool SaveFlag { get; set; }
        public bool EditFlag { get; set; }
        public string ErrorMessage { get; set; }
        public string UserName { get; set; }
        public string OPERATION_TYPE { get; set; }
        public string JOB_CODE { get; set; }
       public List<FFM_CRG_Details> crgnewDetails { get; set; }
        public FFM_CRG_Details newdetails { get; set; }
    }
    public class FFM_CRG_Details
    {
       public Int64 SNO { get; set; }
       public string CMPYCODE { get; set; }
        public string FFM_CRG_001_CODE { get; set; }
     
       public string FFM_CRG_JOB_CODE { get; set; }
        public string FFM_CRG_JOB_NAME { get; set; }
        public string OPERATION_TYPE { get; set; }
        public string DISPLAY_STATUS { get; set; }
        public string INCOME_ACT { get; set; }
        public string EXPENSE_ACGT { get; set; }
     
    }
}
