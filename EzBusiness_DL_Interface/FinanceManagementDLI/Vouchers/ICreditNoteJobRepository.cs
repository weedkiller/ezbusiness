using EzBusiness_EF_Entity;
using EzBusiness_EF_Entity.FreightManagementEF;
using EzBusiness_EF_Entity.FreightManagementEF.SEA_Export;
using EzBusiness_ViewModels.Models.FreightManagement.SEA_Export;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_DL_Interface.FinanceManagementDLI.Vouchers
{
   public  interface ICreditNoteJobRepository
    {

        List<FNINV001_VM> GetFNINV(string CmpyCode, string Branchcode, string Module_Type);
        FNINV001_VM GetFNINVDetailsEdit(string CmpyCode, string FNINV001_CODE, string Branchcode);

        FNINV001_VM GetFNINVDetailsBL(string CmpyCode, string FF_BL001_CODE, string Branchcode);
        FNINV001_VM SaveFNINV_VM(FNINV001_VM FNINV);
        List<FNINV002New> GetFNINV002DetailList(string CmpyCode, string FNINV001_CODE, string BRANCHCODE);

        FNINV001 GetHeaderDetail(string CmpyCode, string FNINV001_CODE, string BRANCHCODE);

       

        List<ComDropTbl> GETBLNO(string CmpyCode, string Branchcode, string Customercode, string Module_Type,string Type_Choose);


        FNINV001_VM Credit_Debit_NoteForJob(string CmpyCode, string Branchcode, string InvCode,string Module_Type);
        //List<FNINV002New> GetFNINV002DetailListN(string CmpyCode, string Branchcode, string InvCode, string Module_Type);


        List<ComDropTbl> GetCustSupp(string CmpyCode, string Branchcode, string Module_Type,string Type_Choose, string Prefix);



       

        bool Bl_InvoiceGenerateLates(string CmpyCode, string Branchcode, string BLCode, string Customer_code, string ExCode, string ExRate, string Table_Name, string Module_Type, string UserName);

        bool BlCrdr_InvoiceGenerateLates(string CmpyCode, string Branchcode, string InvCode, string Table_Name, string Module_Type,string InvModule_Type, string UserName);

        bool DeleteFNINV(string CmpyCode, string FNINV001_CODE, string UserName, string BRANCHCODE);
    }
}
