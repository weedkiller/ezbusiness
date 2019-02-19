using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_BL_Interface
{
    public interface ISalaryprocCondService
    {
        bool GetSalaryProcess(string CmpyCode, string Empcode, DateTime dtmonthyy);

        bool GetSalaryLast(string CmpyCode, string Empcode, DateTime dtmonthyy, string InpAmt);
    }
}
