using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;
using System.Web.Mvc;
namespace EzBusiness_ViewModels.Models.Humanresourcepayroll
{
    public class ProjectMasterVM
    {
        public string CmpyCode { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }        
        public string Active { get; set; }        
        public bool SaveFlag { get; set; }

        public bool EditFlag { get; set; }

        public string ErrorMessage { get; set; }
        public List<ProjectNew> ProjectNew { get; set; }
        public ProjectNew ProjectDetail { get; set; }

        public List<string> Drecord { get; set; }

        public string UserName { get; set; }
    }
    public class ProjectNew
    {
        public string CmpyCode { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Active { get; set; }

    }
}
