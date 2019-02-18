using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_BL_Interface;
using EzBusiness_DL_Interface;
using EzBusiness_DL_Repository;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;
using System.Web.Mvc;
using EzBusiness_ViewModels;
using System.IO;
using System.Web;

namespace EzBusiness_BL_Service
{
    public class SalaryprocCondService : ISalaryprocCondService
    {

        ICodeGenRepository _CodeRep;
        public SalaryprocCondService()
        {            
            _CodeRep = new CodeGenRepository();
        }

        public decimal GetSalaryLast(string CmpyCode, string Empcode, DateTime dtmonthyy)
        {
            return _CodeRep.GetSalaryLast(CmpyCode, Empcode, dtmonthyy);
        }

        public bool GetSalaryProcess(string CmpyCode, string Empcode, DateTime dtmonthyy)
        {
            return _CodeRep.GetSalaryProcess(CmpyCode, Empcode, dtmonthyy);
        }
    }
}
