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
    public class BranchPayrollService : IBranchPayrollService
    {
        IBranchResourceRepository _BrRepo;
        public BranchPayrollService()
        {
            _BrRepo = new BranchResourcesPayrollRepository();
        }
        public bool DeleteBrnc(string Code, string CmpyCode, string UserName)
        {
            return _BrRepo.DeleteBrch(Code, CmpyCode, UserName);
        }

        public List<BranchVM> GetBrnc(string CmpyCode)
        {
            return _BrRepo.GetBrch(CmpyCode).Select(m => new BranchVM
            {
                CmpyCode = m.CmpyCode,
                Code = m.Code,
                Name = m.Name,
                DivCode = m.DivCode

            }).ToList();
        }

        public BranchVM SaveBrnc(BranchVM Grs)
        {
            return _BrRepo.SaveBrch(Grs);
        }
        public List<Division> GetDivisionList(string CmpyCode)
        {

            var Division = _BrRepo.GetDivisionList(CmpyCode);
            Division.Insert(0, new Division { DivisionCode = "", DivisionName = "-Select Division Code-" });
            return Division;
        }
    }
}
