using EzBusiness_EF_Entity.FreightManagementEF.SEA_Export;
using EzBusiness_ViewModels.Models.FreightManagement.SEA_Export;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EzBusiness_BL_Interface.FinanceManagementBLI.Vouchers
{
    public interface ICreditNoteJobService
    {
        List<FNINV001_VM> GetFNINV(string CmpyCode, string BRANCHCODE, string Module_Type);
        FNINV001_VM GetFNINVDetailsEdit(string CmpyCode, string FNINV001_CODE, string BRANCHCODE);

        FNINV001_VM GetFNINVDetailsBL(string CmpyCode, string FF_BL001_CODE, string BRANCHCODE);
        FNINV001_VM SaveFNINV_VM(FNINV001_VM FNINV);
        FNINV001_VM GetCredit_AddNew(string Cmpycode, string BRANCHCODE);

        FNINV001 GetHeaderDetail(string CmpyCode, string FNINV001_CODE, string BRANCHCODE);

        FNINV001_VM GetDebit_AddNew(string Cmpycode, string BRANCHCODE);

        FNINV001_VM  Credit_Debit_NoteForJob(string CmpyCode, string Branchcode, string InvCode, string Module_Type);

        List<SelectListItem> GETBLNO(string CmpyCode, string Branchcode, string Customercode, string Module_Type,string Type_Choose);

       

        bool DeleteFNINV(string CmpyCode, string FNINV001_CODE, string UserName, string BRANCHCODE);

        bool Bl_InvoiceGenerateLates(string CmpyCode, string Branchcode, string BLCode, string Customer_code, string ExCode, string ExRate, string Table_Name, string Module_Type, string UserName);

        bool BlCrdr_InvoiceGenerateLates(string CmpyCode, string Branchcode, string InvCode, string Table_Name, string Module_Type,string InvModule_Type, string UserName);
        List<FNINV002New> GetFNINV002DetailList(string CmpyCode, string FNINV001_CODE, string Branchcode);
        
        List<SelectListItem> GetCustSupp(string CmpyCode, string BRANCHCODE, string Module_Type,string Type_Choose, string Prefix);
    }
}
