using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;
using System.Web.Mvc;

namespace EzBusiness_ViewModels.Models.Humanresourcepayroll
{
    public class BranchVM
    {
        public string Code { get; set; }

        public string DivCode { get; set; }

        public string Name { get; set; }

        public string CmpyCode { get; set; }
        
        public bool SaveFlag { get; set; }

        public bool EditFlag { get; set; }

        public string ErrorMessage { get; set; }
        public List<Division> DivisionCodeList { get; set; }  
        public List<BranchDdetailnew> BranchDdetailnew { get; set; }
        public BranchDdetailnew BranchDdetail { get; set; }
        public List<string> Drecord { get; set; }
        public string Username { get; set; }

    }

    public class BranchDdetailnew
    {
        public string CmpyCode { get; set; }
        public string DivCode { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

    }

}