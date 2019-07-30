using EzBusiness_BL_Interface.FreightManagementBLI.SEA_Export;
using EzBusiness_DL_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity.FreightManagementEF.SEA_Export;
using EzBusiness_ViewModels.Models.FreightManagement.SEA_Export;
using System.Web.Mvc;
using EzBusiness_DL_Interface.FreightManagementDLI.SEA_Export;
using EzBusiness_DL_Repository.FreightManagementDLR.SEA_Export;
using EzBusiness_ViewModels;
using EzBusiness_DL_Interface;
using EzBusiness_EF_Entity;

namespace EzBusiness_BL_Service.FreightManagementBLS.SEA_Export
{ 
    public class FF_QTNService : IFF_QTNService
    {

        IFF_QTNRepository _FF_QTNRepo;
        ICodeGenRepository _CodeRep;

        public FF_QTNService()
        {
            _FF_QTNRepo = new FF_QTNRepository();
            _CodeRep = new CodeGenRepository();

        }
        DropListFillFun drop = new DropListFillFun();
        public bool DeleteFF_QTN(string CmpyCode, string FF_QTN001_CODE, string UserName,string BRANCH_CODE)
        {
            return _FF_QTNRepo.DeleteFF_QTN(CmpyCode, FF_QTN001_CODE, UserName, BRANCH_CODE);
        }

        public List<FF_QTN_VM> GetFF_QTN(string CmpyCode,string Branchcode)
        {
            return _FF_QTNRepo.GetFF_QTN(CmpyCode, Branchcode);
        }

        public List<FF_QTN002New> GetFF_QTN002DetailList(string CmpyCode, string FF_QTN001_CODE, string BRANCH_CODE)
        {
            var FF_QTN002DetailList = _FF_QTNRepo.GetFF_QTN002DetailList(CmpyCode, FF_QTN001_CODE,BRANCH_CODE);
            return FF_QTN002DetailList.Select(m => new FF_QTN002New
            {
                CBM = m.CBM,
                CFT = m.CFT,
                Container=m.Container,
                Contents=m.Contents,
                Cont_Type=m.Cont_Type,
                KG=m.KG,
                LBS=m.LBS,
                No_of_qty=m.No_of_qty,
                Seal1=m.Seal1,
                sno=m.sno,
                Commodity_code=m.Commodity_code,
                //ConTypList1=GetContTypEdit(CmpyCode,m.Cont_Type),
                //Commodityist1=GetCommodityistListEdit(CmpyCode,m.Commodity_code)
            }).ToList();
        }

        public List<FF_QTN003New> GetFF_QTN003DetailList(string CmpyCode, string FF_QTN001_CODE, string BRANCH_CODE)
        {
            var FF_QTN003DetailList = _FF_QTNRepo.GetFF_QTN003DetailList(CmpyCode, FF_QTN001_CODE,BRANCH_CODE);
            return FF_QTN003DetailList.Select(m => new FF_QTN003New
            {
               Act_LBS=m.Act_LBS,
               Dime_weight=m.Dime_weight,
               Height=m.Height,
               inside_Unit=m.inside_Unit,
               No_of_qty=m.No_of_qty,
               Pkg_No=m.Pkg_No,
               Sno=m.Sno,
               unit_type=m.unit_type,
               Volume=m.Volume,
               Width=m.Width

            }).ToList();
        }

        public List<FF_QTN004New> GetFF_QTN004DetailList(string CmpyCode, string FF_QTN001_CODE, string BRANCH_CODE)
        {
            var FF_QTN004DetailList = _FF_QTNRepo.GetFF_QTN004DetailList(CmpyCode, FF_QTN001_CODE,BRANCH_CODE);
            return FF_QTN004DetailList.Select(m => new FF_QTN004New
            {
            CLUASE_CODE=m.CLUASE_CODE,
            CLUASE_NAME=m.CLUASE_NAME,
            //CLAUSEList4=GetCLAUSEEdit(CmpyCode,m.CLUASE_CODE)
            }).ToList();
        }

        public List<FF_QTN005New> GetFF_QTN005DetailList(string CmpyCode, string FF_QTN001_CODE, string BRANCH_CODE)
        {
            var FF_QTN005DetailList = _FF_QTNRepo.GetFF_QTN005DetailList(CmpyCode, FF_QTN001_CODE,BRANCH_CODE);
            return FF_QTN005DetailList.Select(m => new FF_QTN005New
            {
                Crg_code = m.Crg_code,
                Crg_name = m.Crg_name,
                Cust_code=m.Cust_code,
                Cust_Ctrl_Act=m.Cust_Ctrl_Act,
                Cust_Curr_Code=m.Cust_Curr_Code,
                Cust_Curr_Rate=m.Cust_Curr_Rate,
                Cust_Local_amt=m.Cust_Local_amt,
                Cust_name=m.Cust_name,
                Cust_Net_Amt=m.Cust_Net_Amt,
                Cust_Rate=m.Cust_Rate,
                Cust_Total_amt=m.Cust_Total_amt,
                Cust_Var_Amt=m.Cust_Var_Amt,
                Expense_GL_Code=m.Expense_GL_Code,
                Income_GL_Code=m.Income_GL_Code,
                PAY_MODE=m.PAY_MODE,
                Sno=m.Sno,
                Unit_Code=m.Unit_Code,
                VendVar_Amt=m.VendVar_Amt,
                Vend_code=m.Vend_code,
                Vend_Ctrl_Act=m.Vend_Ctrl_Act,
                Vend_Curr_Code=m.Vend_Curr_Code,
                Vend_Curr_Rate=m.Vend_Curr_Rate,
                Vend_Local_amt=m.Vend_Local_amt,
                Vend_name=m.Vend_name,
                Vend_Net_Amt=m.Vend_Net_Amt,
                Vend_Rate=m.Vend_Rate,
                Vend_Total_amt=m.Vend_Total_amt,
                //VendorList5=GetVendorEdit(CmpyCode,m.Vend_code),
                //CVendorList5=GetVendorEdit(CmpyCode,m.Cust_code),
                //VCurList5=GetCurcodeEdit(CmpyCode,m.Vend_Curr_Code),
                //UnitcodeList5=GetUnitcodeEdit(CmpyCode,m.Unit_Code),
                //CRG_002List5=GetCRG_002Edit(CmpyCode,m.Crg_code),
                //CCurList5=GetCurcodeEdit(CmpyCode,m.Cust_Curr_Code)
            }).ToList();
        }

        public FF_QTN_VM GetFF_QTNDetailsEdit(string CmpyCode, string FF_QTN001_CODE,string BranchCode)
        {
            var poEdit = _FF_QTNRepo.GetFF_QTNDetailsEdit(CmpyCode, FF_QTN001_CODE, BranchCode);
            poEdit.FF_QTN002Detail = GetFF_QTN002DetailList(CmpyCode, FF_QTN001_CODE, BranchCode);
            poEdit.FF_QTN003Detail = GetFF_QTN003DetailList(CmpyCode, FF_QTN001_CODE,BranchCode);
            poEdit.FF_QTN004Detail = GetFF_QTN004DetailList(CmpyCode, FF_QTN001_CODE,BranchCode);
            poEdit.FF_QTN005Detail = GetFF_QTN005DetailList(CmpyCode, FF_QTN001_CODE, BranchCode);

            poEdit.FNMBRANCH_CODE = BranchCode;
           // poEdit.PortList1 = GetPortListEdit(CmpyCode,poEdit.POL);
           // poEdit.PortList2 = GetPortListEdit(CmpyCode, poEdit.POD);
           // poEdit.PortList3 = GetPortListEdit(CmpyCode,poEdit.FND);
           // poEdit.CustList = GetCustEdit(CmpyCode,poEdit.CUST_CODE);
           //// poEdit.VendorList = GetVendor(CmpyCode);
           // //poEdit.CurList = GetCurcode(CmpyCode);
           //// poEdit.UnitcodeList = GetUnitcode(CmpyCode);
           // //poEdit.ConTypList = GetContTyp(CmpyCode);
           // poEdit.DEPARTMENTList = GetDepartEdit(CmpyCode,poEdit.DEPARTMENT);
           // poEdit.MoveCodeList = GetMoveCodeEdit(CmpyCode,poEdit.MOVE_TYPE);
           // //poEdit.CLAUSEList = GetCLAUSE(CmpyCode);
           // //poEdit.CRG_002List = GetCRG_002(CmpyCode);
           // poEdit.SLList = GetSLEdit(CmpyCode, poEdit.CARRIER);
           // poEdit.VESSELList = GetVESSELListEdit(CmpyCode, poEdit.VESSEL);
           // //poEdit.VOYAGEList = GetVOYAGEList(CmpyCode,poEdit.VESSEL);
           // poEdit.Commodityist = GetCommodityistListEdit(CmpyCode,poEdit.Commodity_code);
            poEdit.EditFlag = true;
            return poEdit;
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

        public FF_QTN_VM SaveFF_QTN_VM(FF_QTN_VM FQV)

        {
            if (!FQV.EditFlag)
            {
                FQV.FF_QTN001_CODE = _CodeRep.GetCodeNew(FQV.CMPYCODE, FQV.FNMBRANCH_CODE, "FF_QTN001", "I");
            }
            return _FF_QTNRepo.SaveFF_QTN_VM(FQV);
        }

        public List<SelectListItem> GetVOYAGEList(string CmpyCode, string FFM_VESSEL_CODE, string Prefix)
        {
            var VOYAGEList = _FF_QTNRepo.GetVOYAGEList(CmpyCode, FFM_VESSEL_CODE, Prefix) //.Where(m => m.CodeName.ToString().ToLower().Contains(Prefix.ToLower()) || m.Code.ToString().ToLower().Contains(Prefix.ToLower())).ToList()
                                                  .Select(m => new SelectListItem { Value = m.CodeName, Text = m.Code })
                                                  .ToList();
            return VOYAGEList;
        }

       
        public FF_QTN_VM GetFF_QTN_AddNew(string Cmpycode, string branchcode)
        {
            //var FF_QTN001_CODE = _CodeRep.GetCode(Cmpycode, "SupplierQuotation");
            return new FF_QTN_VM
            {
                //CustList=GetCust(Cmpycode),
                ////CurList=GetCurcode(Cmpycode),
                ////UnitcodeList=GetUnitcode(Cmpycode),
                ////VendorList = GetVendor(Cmpycode),
                //VOYAGEList=GetVOYAGEList(Cmpycode,"NA"),
                //SLList=GetVendor(Cmpycode),
                ////CLAUSEList =GetCLAUSE(Cmpycode),
                ////CRG_002List=GetCRG_002(Cmpycode),
                //DEPARTMENTList=GetDepart(Cmpycode),
                //MoveCodeList=GetMoveCode(Cmpycode),
                //VESSELList=GetVESSELList(Cmpycode),
                //PortList=GetPortList(Cmpycode),
                ////ConTypList=GetContTyp(Cmpycode),
                ////Commodityist= GetCommodityistList(Cmpycode),
                //FF_QTN001_CODE = _CodeRep.GetCode(Cmpycode, "SupplierQuotation"),

                FF_QTN001_CODE = _CodeRep.GetCodeNew(Cmpycode, branchcode, "FF_QTN001","V"),
                FNMBRANCH_CODE = branchcode,
                EditFlag = false
            };
        }


        public List<SelectListItem> GetMoveCode(string CmpyCode,string Prefix)
        {
            var CurrencyList = _FF_QTNRepo.GetMOVEList(CmpyCode, Prefix)//.Where(m => m.CodeName.ToString().ToLower().Contains(Prefix.ToLower()) || m.Code.ToString().ToLower().Contains(Prefix.ToLower())).ToList()
                                          .Select(m => new SelectListItem { Value = m.CodeName, Text = m.Code })
                                          .ToList();
            return CurrencyList;
        }
        public IQueryable<SelectListItem> GetPortList(string CmpyCode, string Prefix)
        {
            var PortList = _FF_QTNRepo.GetPortList(CmpyCode, Prefix)//.Where(m => m.CodeName.ToString().ToLower().Contains(Prefix.ToLower()) || m.Code.ToString().ToLower().Contains(Prefix.ToLower())).AsQueryable()
                                                 .Select(m => new SelectListItem { Value = m.CodeName, Text = m.Code })
                                                 .AsQueryable();
            return PortList;
        }

        public List<SelectListItem> GetCust(string CmpyCode, string Prefix)
        {
            var CustList = _FF_QTNRepo.GetCust(CmpyCode, Prefix)//.Where(m => m.CUSTOMER_CODE.ToString().ToLower().Contains(Prefix.ToLower()) || m.CUSTOMER_NAME.ToString().ToLower().Contains(Prefix.ToLower())).ToList()
                                                     .Select(m => new SelectListItem { Value = m.CUSTOMER_NAME, Text = m.CUSTOMER_CODE })
                                                     .ToList();
            return CustList;
        }
        public List<SelectListItem> GetCustT(string CmpyCode, string Prefix)
        {
            var CustList = _FF_QTNRepo.GetCust(CmpyCode, Prefix)//.Where(m => m.CUSTOMER_CODE.ToString().ToLower().Contains(Prefix.ToLower()) || m.CUSTOMER_NAME.ToString().ToLower().Contains(Prefix.ToLower())).ToList()
                                                     .Select(m => new SelectListItem { Value = m.CUSTOMER_CODE, Text = string.Concat(m.CUSTOMER_CODE, " - ", m.CUSTOMER_NAME, " - ", m.CONTROL_ACT) })
                                                     .ToList();
            return CustList;
        }

        public List<SelectListItem> GetVendor(string CmpyCode, string Prefix)
        {
            var VendorList = _FF_QTNRepo.GetCust(CmpyCode, Prefix)//.Where(m => m.CUSTOMER_CODE.ToString().ToLower().Contains(Prefix.ToLower()) || m.CUSTOMER_NAME.ToString().ToLower().Contains(Prefix.ToLower())).ToList()
                                                      .Select(m => new SelectListItem { Value = m.CUSTOMER_CODE, Text = string.Concat(m.CUSTOMER_CODE, " - ", m.CUSTOMER_NAME, " - ", m.CONTROL_ACT) })
                                                      .ToList();
            return VendorList;
        }

        public List<SelectListItem> GetCurcode(string CmpyCode, string Prefix)
        {
            var CurList = _FF_QTNRepo.GetCurcode(CmpyCode, Prefix)//.Where(m => m.CodeName.ToString().ToLower().Contains(Prefix.ToLower()) || m.Code.ToString().ToLower().Contains(Prefix.ToLower())).ToList()
                                                    .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code+"-"+m.CodeName) })
                                                    .ToList();
            return CurList;
        }

        public List<SelectListItem> GetUnitcode(string CmpyCode, string Prefix)
        {
            var UnitcodeList = _FF_QTNRepo.GetUnitcode(CmpyCode, Prefix)//.Where(m => m.CodeName.ToString().ToLower().Contains(Prefix.ToLower()) || m.Code.ToString().ToLower().Contains(Prefix.ToLower())).ToList()
                                                    .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code + "-" + m.CodeName) })
                                                    .ToList();
            return UnitcodeList;
        }
       
         public List<SelectListItem> GetContTyp(string CmpyCode, string Prefix)
        {
            var ContTypList = _FF_QTNRepo.GetContTyp(CmpyCode, Prefix)//.Where(m => m.CodeName.ToString().ToLower().Contains(Prefix.ToLower()) || m.Code.ToString().ToLower().Contains(Prefix.ToLower())).ToList()
                                                  .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code + "-" + m.CodeName )})
                                                  .ToList();
            return ContTypList;
        }
        public List<SelectListItem> GetCommodityistList(string CmpyCode, string Prefix)
        {
            var CommodityList = _FF_QTNRepo.GetCommodityistList(CmpyCode, Prefix)//.Where(m => m.CodeName.ToString().ToLower().Contains(Prefix.ToLower()) || m.Code.ToString().ToLower().Contains(Prefix.ToLower())).ToList()
                                                  .Select(m => new SelectListItem { Value = m.CodeName, Text = m.Code })
                                                  .ToList();
            return CommodityList;
        }
        public List<SelectListItem> GetCommodityistListT(string CmpyCode, string Prefix)
        {
            var CommodityList = _FF_QTNRepo.GetCommodityistList(CmpyCode, Prefix)//.Where(m => m.CodeName.ToString().ToLower().Contains(Prefix.ToLower()) || m.Code.ToString().ToLower().Contains(Prefix.ToLower())).ToList()
                                                  .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code + "-" + m.CodeName )})
                                                  .ToList();
            return CommodityList;
        }

        public List<SelectListItem> GetDepart(string CmpyCode, string Prefix)
        {
            var DepartList = _FF_QTNRepo.GetDepart(CmpyCode, Prefix)//.Where(m => m.CodeName.ToString().ToLower().Contains(Prefix.ToLower()) || m.Code.ToString().ToLower().Contains(Prefix.ToLower())).ToList()
                                          .Select(m => new SelectListItem { Value = m.CodeName, Text = m.Code })
                                          .ToList();
            return DepartList;
        }
        public List<SelectListItem> GetVESSELList(string CmpyCode, string Prefix)
        {
            var VESSELList = _FF_QTNRepo.GetVESSELList(CmpyCode,Prefix)//.Where(m => m.CodeName.ToString().ToLower().Contains(Prefix.ToLower()) || m.Code.ToString().ToLower().Contains(Prefix.ToLower())).ToList()
                                                 .Select(m => new SelectListItem { Value = m.CodeName, Text = m.Code })
                                                 .ToList();
            return VESSELList;
        }    
        public List<SelectListItem> GetSL(string CmpyCode, string Prefix)
        {
            var SLList = _FF_QTNRepo.GetSL(CmpyCode,Prefix)//.Where(m => m.CodeName.ToString().ToLower().Contains(Prefix.ToLower()) || m.Code.ToString().ToLower().Contains(Prefix.ToLower())).ToList()
                                                  .Select(m => new SelectListItem { Value = m.CodeName, Text = m.Code })
                                                  .ToList();
            return SLList;
        }

        public List<SelectListItem> GetCLAUSE(string CmpyCode, string Prefix)
        {
            var CLAUSEList = _FF_QTNRepo.GetCLAUSE(CmpyCode, Prefix)//.Where(m => m.CodeName.ToString().ToLower().Contains(Prefix.ToLower()) || m.Code.ToString().ToLower().Contains(Prefix.ToLower())).ToList()
                                                .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code + "-" + m.CodeName) })
                                                .ToList();
            return CLAUSEList;
        }

        public List<SelectListItem> GetCRG_002(string CmpyCode,string Prefix)
        {
            var CRG_002List = _FF_QTNRepo.GetCRG_002(CmpyCode, Prefix)//.Where(m => m.FFM_CRG_JOB_CODE.ToString().ToLower().Contains(Prefix.ToLower()) || m.FFM_CRG_JOB_NAME.ToString().ToLower().Contains(Prefix.ToLower())).ToList()
                                          .Select(m => new SelectListItem { Value = m.FFM_CRG_JOB_CODE, Text = string.Concat(m.FFM_CRG_JOB_CODE, " - ", m.FFM_CRG_JOB_NAME, " - ", m.INCOME_ACT, " - ", m.EXPENSE_ACGT) })
                                          .ToList();
            return CRG_002List;
        }

        public decimal GetCurRate(string CmpyCode, string CurCode)
        {
            return _FF_QTNRepo.GetCurRate(CmpyCode, CurCode);
        }

        public List<SelectListItem> GetBranchListN(string CmpyCode, string Prefix)
        {
            var BranchList = _FF_QTNRepo.GetBranchListN(CmpyCode, Prefix)//.Where(m => m.FFM_CRG_JOB_CODE.ToString().ToLower().Contains(Prefix.ToLower()) || m.FFM_CRG_JOB_NAME.ToString().ToLower().Contains(Prefix.ToLower())).ToList()
                                           .Select(m => new SelectListItem { Value = m.CodeName, Text = m.Code } )
                                           .ToList();
            return BranchList;
        }

        public List<SelectListItem> GetCurCodebranch(string CmpyCode, string BranchCode)
        {
            var CurCode = _FF_QTNRepo.GetCurCodebranch(CmpyCode, BranchCode)//.Where(m => m.FFM_CRG_JOB_CODE.ToString().ToLower().Contains(Prefix.ToLower()) || m.FFM_CRG_JOB_NAME.ToString().ToLower().Contains(Prefix.ToLower())).ToList()
                                          .Select(m => new SelectListItem { Value = m.CodeName, Text = m.Code })
                                          .ToList();
            return CurCode;
        }

        public FF_QTN_VM GetFF_QuotCopy(string CmpyCode, string FF_QTN001_CODE, string BranchCode)
        {
            var poEdit = _FF_QTNRepo.GetFF_QTNDetailsEdit(CmpyCode, FF_QTN001_CODE, BranchCode);
            poEdit.FF_QTN002Detail = GetFF_QTN002DetailList(CmpyCode, FF_QTN001_CODE, BranchCode);
            poEdit.FF_QTN003Detail = GetFF_QTN003DetailList(CmpyCode, FF_QTN001_CODE, BranchCode);
            poEdit.FF_QTN004Detail = GetFF_QTN004DetailList(CmpyCode, FF_QTN001_CODE, BranchCode);
            poEdit.FF_QTN005Detail = GetFF_QTN005DetailList(CmpyCode, FF_QTN001_CODE, BranchCode);

            poEdit.FNMBRANCH_CODE = BranchCode;

            //poEdit.FF_QTN001_CODEN =  _CodeRep.GetCode(CmpyCode, "SupplierQuotation");

            poEdit.FF_QTN001_CODEN =  _CodeRep.GetCodeNew(CmpyCode, BranchCode, "FF_QTN001","V");
            // poEdit.PortList1 = GetPortListEdit(CmpyCode,poEdit.POL);
            // poEdit.PortList2 = GetPortListEdit(CmpyCode, poEdit.POD);
            // poEdit.PortList3 = GetPortListEdit(CmpyCode,poEdit.FND);
            // poEdit.CustList = GetCustEdit(CmpyCode,poEdit.CUST_CODE);
            //// poEdit.VendorList = GetVendor(CmpyCode);
            // //poEdit.CurList = GetCurcode(CmpyCode);
            //// poEdit.UnitcodeList = GetUnitcode(CmpyCode);
            // //poEdit.ConTypList = GetContTyp(CmpyCode);
            // poEdit.DEPARTMENTList = GetDepartEdit(CmpyCode,poEdit.DEPARTMENT);
            // poEdit.MoveCodeList = GetMoveCodeEdit(CmpyCode,poEdit.MOVE_TYPE);
            // //poEdit.CLAUSEList = GetCLAUSE(CmpyCode);
            // //poEdit.CRG_002List = GetCRG_002(CmpyCode);
            // poEdit.SLList = GetSLEdit(CmpyCode, poEdit.CARRIER);
            // poEdit.VESSELList = GetVESSELListEdit(CmpyCode, poEdit.VESSEL);
            // //poEdit.VOYAGEList = GetVOYAGEList(CmpyCode,poEdit.VESSEL);
            // poEdit.Commodityist = GetCommodityistListEdit(CmpyCode,poEdit.Commodity_code);
            poEdit.EditFlag = false;
            return poEdit;
        }

        public string Aprrove_QTN(string CmpyCode, string FF_QTN001_CODE, string UserName, string Typ, string BranchCode,string Tablename)
        {
            return _CodeRep.Aprrove_QTN(CmpyCode, FF_QTN001_CODE, UserName,Typ, BranchCode, Tablename);
        }

        //public List<ComDropTbl> GetApproveRej(string CmpyCode, string BranchCode, string FF_QTN001_CODE)
        //{
        //    return _FF_QTNRepo.GetApproveRej(CmpyCode, BranchCode, FF_QTN001_CODE);
        //}




        //public List<SelectListItem> GetMoveCodeEdit(string CmpyCode, string code)
        //{
        //    var CurrencyList = _FF_QTNRepo.GetMOVEList(CmpyCode, Prefix)//.Where(m => m.Code.ToString()==code).ToList()
        //                                  .Select(m => new SelectListItem { Value = m.Code, Text = m.CodeName })
        //                                  .ToList();
        //    return InsertFirstElementDDL(CurrencyList);
        //}
        //public List<SelectListItem> GetPortListEdit(string CmpyCode, string code)
        //{
        //    var PortList = _FF_QTNRepo.GetPortList(CmpyCode).Where(m => m.Code.ToString() == code).ToList()
        //                                         .Select(m => new SelectListItem { Value = m.Code, Text = m.CodeName })
        //                                         .ToList();
        //    return InsertFirstElementDDL(PortList);
        //}

        //public List<SelectListItem> GetCustEdit(string CmpyCode, string code)
        //{
        //    var CustList = _FF_QTNRepo.GetCust(CmpyCode).Where(m => m.CUSTOMER_CODE.ToString() == code).ToList()
        //                                             .Select(m => new SelectListItem { Value = m.CUSTOMER_CODE, Text = string.Concat(m.CUSTOMER_CODE, " - ", m.CUSTOMER_NAME, " - ", m.CONTROL_ACT) })
        //                                             .ToList();
        //    return InsertFirstElementDDL(CustList);
        //}

        //public List<SelectListItem> GetVendorEdit(string CmpyCode, string code)
        //{
        //    var VendorList = _FF_QTNRepo.GetCust(CmpyCode).Where(m => m.CUSTOMER_CODE.ToString() == code).ToList()
        //                                              .Select(m => new SelectListItem { Value = m.CUSTOMER_CODE, Text = string.Concat(m.CUSTOMER_CODE, " - ", m.CUSTOMER_NAME, " - ", m.CONTROL_ACT) })
        //                                              .ToList();
        //    return InsertFirstElementDDL(VendorList);
        //}

        //public List<SelectListItem> GetCurcodeEdit(string CmpyCode, string code)
        //{
        //    var CurList = _FF_QTNRepo.GetCurcode(CmpyCode).Where(m => m.Code.ToString() == code).ToList()
        //                                            .Select(m => new SelectListItem { Value = m.Code, Text = m.CodeName })
        //                                            .ToList();
        //    return InsertFirstElementDDL(CurList);
        //}

        //public List<SelectListItem> GetUnitcodeEdit(string CmpyCode, string code)
        //{
        //    var UnitcodeList = _FF_QTNRepo.GetUnitcode(CmpyCode).Where(m => m.Code.ToString() == code).ToList()
        //                                            .Select(m => new SelectListItem { Value = m.Code, Text = m.CodeName })
        //                                            .ToList();
        //    return InsertFirstElementDDL(UnitcodeList);
        //}

        //public List<SelectListItem> GetContTypEdit(string CmpyCode, string code)
        //{
        //    var ContTypList = _FF_QTNRepo.GetContTyp(CmpyCode).Where(m => m.Code.ToString() == code).ToList()
        //                                          .Select(m => new SelectListItem { Value = m.Code, Text = m.CodeName })
        //                                          .ToList();
        //    return ContTypList;
        //}
        //public List<SelectListItem> GetCommodityistListEdit(string CmpyCode, string code)
        //{
        //    var CommodityList = _FF_QTNRepo.GetCommodityistList(CmpyCode).Where(m => m.Code.ToString() == code).ToList()
        //                                          .Select(m => new SelectListItem { Value = m.Code, Text = m.CodeName })
        //                                          .ToList();
        //    return InsertFirstElementDDL(CommodityList);
        //}

        //public List<SelectListItem> GetDepartEdit(string CmpyCode, string code)
        //{
        //    var DepartList = _FF_QTNRepo.GetDepart(CmpyCode).Where(m => m.Code.ToString() == code).ToList()
        //                                  .Select(m => new SelectListItem { Value = m.Code, Text = m.CodeName })
        //                                  .ToList();
        //    return InsertFirstElementDDL(DepartList);
        //}
        //public List<SelectListItem> GetVESSELListEdit(string CmpyCode, string code)
        //{
        //    var VESSELList = _FF_QTNRepo.GetVESSELList(CmpyCode).Where(m => m.Code.ToString() == code).ToList()
        //                                         .Select(m => new SelectListItem { Value = m.Code, Text = m.CodeName })
        //                                         .ToList();
        //    return InsertFirstElementDDL(VESSELList);
        //}
        //public List<SelectListItem> GetSLEdit(string CmpyCode, string code)
        //{
        //    var SLList = _FF_QTNRepo.GetSL(CmpyCode).Where(m => m.Code.ToString() == code).ToList()
        //                                          .Select(m => new SelectListItem { Value = m.Code, Text = m.CodeName })
        //                                          .ToList();
        //    return InsertFirstElementDDL(SLList);
        //}

        //public List<SelectListItem> GetCLAUSEEdit(string CmpyCode, string code)
        //{
        //    var CLAUSEList = _FF_QTNRepo.GetCLAUSE(CmpyCode).Where(m => m.Code.ToString() == code).ToList()
        //                                        .Select(m => new SelectListItem { Value = m.Code, Text = m.CodeName })
        //                                        .ToList();
        //    return InsertFirstElementDDL(CLAUSEList);
        //}

        //public List<SelectListItem> GetCRG_002Edit(string CmpyCode, string code)
        //{
        //    var CRG_002List = _FF_QTNRepo.GetCRG_002(CmpyCode).Where(m => m.FFM_CRG_JOB_CODE.ToString() == code).ToList()
        //                                  .Select(m => new SelectListItem { Value = m.FFM_CRG_JOB_CODE, Text = string.Concat(m.FFM_CRG_JOB_CODE, " - ", m.FFM_CRG_JOB_NAME, " - ", m.INCOME_ACT, " - ", m.EXPENSE_ACGT) })
        //                                  .ToList();
        //    return InsertFirstElementDDL(CRG_002List);
        //}
    }
}
