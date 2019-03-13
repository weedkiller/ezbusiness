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

namespace EzBusiness_BL_Service
{
    public class FinalsettalmentService : IFinalsettalmentService
    {
        IFinalsettalmentRepository _FinRepo;
        ICodeGenRepository _CodeRep;
        public FinalsettalmentService()
        {
            _FinRepo = new FinalsettalmentRepository();
            _CodeRep = new CodeGenRepository();
        }
        public bool DeleteFinalSettalment(string CmpyCode, string Code, string UserName)
        {
            return _FinRepo.DeleteFinalSettalment(CmpyCode,Code,UserName);
        }

        public List<SelectListItem> GetEmpCodes(string CmpyCode,string typ)
        {
            var EmpList = _FinRepo.GetEmpCodes(CmpyCode,typ)
                                       .Select(m => new SelectListItem { Value = m.EmpCode, Text = string.Concat(m.EmpCode, " - ", m.Empname) })
                                       .ToList();
            return InsertFirstElementDDL(EmpList);
        }
        private List<SelectListItem> InsertFirstElementDDL(List<SelectListItem> items)
        {
            items.Insert(0, new SelectListItem
            {
                Value = PurchaseMgmtConstants.DDLFirstVal,
                Text = PurchaseMgmtConstants.DDLFirstText
            });
            return items;
        }

        public List<Finalsettalment_VM> GetFinalSettalment(string CmpyCode)
        {         
            var poFinalSettalmentList = _FinRepo.GetFinalSettalment(CmpyCode);
            return poFinalSettalmentList.Select(m => new Finalsettalment_VM
            {
               Cmpycode=m.Cmpycode,
               PRFSET001_code=m.PRFSET001_code,
               EmpCode=m.EmpCode,
               SettledDate=m.SettledDate,
               Dates=m.Dates,
            }).ToList();
        }
        public Finalsettalment_VM GetFinalSettalmentEdit(string CmpyCode, string Code)
        {           
            var finEdit = _FinRepo.GetFinalsettalmentEdit(CmpyCode, Code);
            finEdit.EmpCodeList = GetEmpCodes(CmpyCode,"A");
            finEdit.EditFlag = true;
            return finEdit;
        }
        public Finalsettalment_VM GetFinalSettalmentNew(string CmpyCode)
        {
            return new Finalsettalment_VM
            {
                EmpCodeList = GetEmpCodes(CmpyCode,"Y"),
                PRFSET001_code = _CodeRep.GetCode(CmpyCode, "FinalSettalment"),
                EditFlag = false
            };
        }
        public Finalsettalment_VM SaveFinalSettalment(Finalsettalment_VM Fins)
        {
            if (!Fins.EditFlag)
            {
                Fins.PRFSET001_code = _CodeRep.GetCode(Fins.Cmpycode, "FinalSettalment");
            }
           
            
            return _FinRepo.SaveFinalSettalment(Fins);
        }

        public List<FinalSettI> GetFinalSetI(string CmpyCode, string EmpCode)
        {
            var FinalSetIList = _FinRepo.GetFinalSetI(CmpyCode, EmpCode);
            return FinalSetIList.Select(m => new FinalSettI
            {
               Basic=m.Basic,
               Food=m.Food,
               Conveyance=m.Conveyance,
               Housing=m.Housing,
               JoiningDate=m.JoiningDate,
               Other_Allow=m.Other_Allow,
               Tele_Allow=m.Tele_Allow,
                LastRetDate=m.LastRetDate,
                LLSDate=m.LLSDate,
               LBasic=m.LBasic,
                BalLeave = m.BalLeave,
            }).ToList();
        }

        public List<FinalSetII> GetFinalSetII(string Cmpycode, string Empcode, DateTime joiingdte, DateTime Reldate, float deducdays, string F1_type, float basicper, DateTime LLSdate, float Ldeducdays, string emptyp, float bleave, float Lbasic, float Housing, float Food, float Tele, float Transport, float Other_Allow)
        {
            var FinalSetIIList = _FinRepo.GetFinalSetII(Cmpycode,Empcode,joiingdte,Reldate,deducdays,F1_type,basicper,LLSdate,Ldeducdays,emptyp,bleave,Lbasic,Housing,Food,Tele,Transport,Other_Allow);
            return FinalSetIIList.Select(m => new FinalSetII
            {
               absent=m.absent,
               BasicL=m.BasicL,
               deduct=m.deduct,
               FoodL=m.FoodL,
               Gratuity=m.Gratuity,
               GratuityEntitled=m.GratuityEntitled,
               HousingL=m.HousingL,
               labsentday=m.labsentday,
               LAppDays=m.LAppDays,
               LeaveSalary=m.LeaveSalary,
               loanamt=m.loanamt,
               lTotalnoday=m.lTotalnoday,
               lTotalnoWeekday=m.lTotalnoWeekday,
               NetAmount=m.NetAmount,
               Other_AllowL=m.Other_AllowL,
               TeleL=m.TeleL,
               totaldays=m.totaldays,
               TotalEntiled=m.TotalEntiled,
               totalnowek=m.totalnowek,
               TransportL=m.TransportL,
                
            }).ToList();
        }
    }
}
