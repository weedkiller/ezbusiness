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

namespace EzBusiness_BL_Service
{
    public class DocumentsPayrollService : IDocumentsPayrollService
    {
        IDocumentsPayrollRepository _DokRepo;

        public DocumentsPayrollService()
        {
            _DokRepo = new DocumentsPayrollRepository();
        }

        public bool DeleteDoks(string DocCode, string CmpyCode, string UserName)
        {
            return _DokRepo.DeleteDoks(DocCode, CmpyCode, UserName);
        }

        public List<DocumentsVM> GetDoks(string CmpyCode)
        {
            return _DokRepo.GetDoks(CmpyCode).Select(m => new DocumentsVM
            {
                CmpyCode = m.Cmpycode,
                DocCode = m.DocCode,
                DocName = m.DocName,
               // UniCodeName = m.UniCodeName

            }).ToList();
        }

        public DocumentsVM SaveDoks(DocumentsVM Doks)
        {
            return _DokRepo.SaveDoks(Doks);
        }
    }
}
