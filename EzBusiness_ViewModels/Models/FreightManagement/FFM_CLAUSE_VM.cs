using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_ViewModels.Models.FreightManagement
{
   public class FFM_CLAUSE_VM
    {
        public string CREATED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }
        public string UPDATED_BY { get; set; }
        public DateTime UPDATED_ON { get; set; }
        public string CMPYCODE { get; set; }
      
        public string FFM_CLAUSE_CODE { get; set; }
        public string NAME { get; set; }
        public bool SaveFlag { get; set; }
        public bool EditFlag { get; set; }
        public string ErrorMessage { get; set; }
        public string UserName { get; set; }
        public List<FFM_CLAUSE_NewDetails> FFM_CLAUSE_Detail { get; set; }
        public FFM_CLAUSE_NewDetails FFM_CLAUSEDetailnew { get; set; }
    }
    public class FFM_CLAUSE_NewDetails
    {
        public string CREATED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }
        public string UPDATED_BY { get; set; }
        public DateTime UPDATED_ON { get; set; }
        public string CMPYCODE { get; set; }

        public string FFM_CLAUSE_CODE { get; set; }
        public string NAME { get; set; }
    }
}
