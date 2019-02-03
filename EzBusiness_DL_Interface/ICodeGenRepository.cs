using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_DL_Interface
{
    public interface ICodeGenRepository
    {
        string GetCode(string CmpyCode, string LocCode);

    }
}
