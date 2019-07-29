using EzBusiness_BL_Interface.FreightManagementBLI.SEA_Export;
using EzBusiness_DL_Interface;
using EzBusiness_DL_Interface.FreightManagementDLI.SEA_Export;
using EzBusiness_DL_Repository;
using EzBusiness_DL_Repository.FreightManagementDLR.SEA_Export;
using EzBusiness_ViewModels;
using EzBusiness_ViewModels.Models.FreightManagement.SEA_Export;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EzBusiness_BL_Service.FreightManagementBLS.SEA_Export
{
    public class FF_BOKService : IFF_BOKService
    {

        IFF_BOKRepository _FF_BOKRepo;
        ICodeGenRepository _CodeRep;
        IFF_BLRepository __FF_BLRepo;
        public FF_BOKService()
        {
            _FF_BOKRepo = new FF_BOKRepository();
            _CodeRep = new CodeGenRepository();
            __FF_BLRepo = new FF_BLRepository();
        }
        DropListFillFun drop = new DropListFillFun();
        public bool DeleteFF_BOK(string CmpyCode, string FF_BOK001_CODE, string UserName, string BRANCH_CODE )
        {
            return _FF_BOKRepo.DeleteFF_BOK(CmpyCode, FF_BOK001_CODE, UserName, BRANCH_CODE);
        }

        public List<FF_BOK_VM> GetFF_BOK(string CmpyCode,string BranchCode)
        {
            return _FF_BOKRepo.GetFF_BOK(CmpyCode,BranchCode);
        }

        public List<FF_BOK002New> GetFF_BOK002DetailList(string CmpyCode, string FF_BOK001_CODE,string typ, string BRANCH_CODE)
        {
            var FF_BOK002DetailList = _FF_BOKRepo.GetFF_BOK002DetailList(CmpyCode, FF_BOK001_CODE, typ,BRANCH_CODE);
            return FF_BOK002DetailList.Select(m => new FF_BOK002New
            {
                CBM = m.CBM,
                CFT = m.CFT,
                Container = m.Container,
                Contents = m.Contents,
                Cont_Type = m.Cont_Type,
                KG = m.KG,
                LBS = m.LBS,
                No_of_qty = m.No_of_qty,
                Seal1 = m.Seal1,
                sno = m.sno,
                Commodity_code=m.Commodity_code,
                //ConTypList1 = GetContTypEdit(CmpyCode, m.Cont_Type),
                //Commodityist1 = GetCommodityistListEdit(CmpyCode, m.Commodity_code)

            }).ToList();
        }

        public List<FF_BOK003New> GetFF_BOK003DetailList(string CmpyCode, string FF_BOK001_CODE,string typ, string BRANCH_CODE)
        {
            var FF_BOK003DetailList = _FF_BOKRepo.GetFF_BOK003DetailList(CmpyCode, FF_BOK001_CODE, typ,BRANCH_CODE);
            return FF_BOK003DetailList.Select(m => new FF_BOK003New
            {
                Act_LBS = m.Act_LBS,
                Dime_weight = m.Dime_weight,
                Height = m.Height,
                inside_Unit = m.inside_Unit,
                No_of_qty = m.No_of_qty,
                Pkg_No = m.Pkg_No,
                Sno = m.Sno,
                unit_type = m.unit_type,
                Volume = m.Volume,
                Width = m.Width

            }).ToList();
        }

        public List<FF_BOK004New> GetFF_BOK004DetailList(string CmpyCode, string FF_BOK001_CODE,string typ, string BRANCH_CODE)
        {
            var FF_BOK004DetailList = _FF_BOKRepo.GetFF_BOK004DetailList(CmpyCode, FF_BOK001_CODE, typ,BRANCH_CODE);
            return FF_BOK004DetailList.Select(m => new FF_BOK004New
            {
                CLUASE_CODE = m.CLUASE_CODE,
                CLUASE_NAME = m.CLUASE_NAME,
                sno=m.sno
                //CLAUSEList4 = GetCLAUSEEdit(CmpyCode, m.CLUASE_CODE)
            }).ToList();
        }

        public List<FF_BOK005New> GetFF_BOK005DetailList(string CmpyCode, string FF_BOK001_CODE,string typ, string BRANCH_CODE)
        {
            var FF_BOK005DetailList = _FF_BOKRepo.GetFF_BOK005DetailList(CmpyCode, FF_BOK001_CODE, typ,BRANCH_CODE);
            return FF_BOK005DetailList.Select(m => new FF_BOK005New
            {
                Crg_code = m.Crg_code,
                Crg_name = m.Crg_name,
                Cust_code = m.Cust_code,
                Cust_Ctrl_Act = m.Cust_Ctrl_Act,
                Cust_Curr_Code = m.Cust_Curr_Code,
                Cust_Curr_Rate = m.Cust_Curr_Rate,
                Cust_Local_amt = m.Cust_Local_amt,
                Cust_name = m.Cust_name,
                Cust_Net_Amt = m.Cust_Net_Amt,
                Cust_Rate = m.Cust_Rate,
                Cust_Total_amt = m.Cust_Total_amt,
                Cust_Var_Amt = m.Cust_Var_Amt,
                Expense_GL_Code = m.Expense_GL_Code,
                Income_GL_Code = m.Income_GL_Code,
                PAY_MODE = m.PAY_MODE,
                Sno = m.Sno,
                Unit_Code = m.Unit_Code,
                VendVar_Amt = m.VendVar_Amt,
                Vend_code = m.Vend_code,
                Vend_Ctrl_Act = m.Vend_Ctrl_Act,
                Vend_Curr_Code = m.Vend_Curr_Code,
                Vend_Curr_Rate = m.Vend_Curr_Rate,
                Vend_Local_amt = m.Vend_Local_amt,
                Vend_name = m.Vend_name,
                Vend_Net_Amt = m.Vend_Net_Amt,
                Vend_Rate = m.Vend_Rate,
                Vend_Total_amt = m.Vend_Total_amt,
                //VendorList5 = GetVendorEdit(CmpyCode, m.Vend_code),
                //CVendorList5 = GetVendorEdit(CmpyCode, m.Cust_code),
                //VCurList5 = GetCurcodeEdit(CmpyCode, m.Vend_Curr_Code),
                //UnitcodeList5 = GetUnitcodeEdit(CmpyCode, m.Unit_Code),
                //CRG_002List5 = GetCRG_002Edit(CmpyCode, m.Crg_code),
                //CCurList5 = GetCurcodeEdit(CmpyCode, m.Cust_Curr_Code)

            }).ToList();
        }

        public FF_BOK_VM GetFF_BOKDetailsEdit(string CmpyCode, string FF_BOK001_CODE,string BranchCode)
        {
            var poEdit = _FF_BOKRepo.GetFF_BOKDetailsEdit(CmpyCode, FF_BOK001_CODE, BranchCode);
            poEdit.FF_BOK002Detail = GetFF_BOK002DetailList(CmpyCode, FF_BOK001_CODE,"B", BranchCode);
            poEdit.FF_BOK003Detail = GetFF_BOK003DetailList(CmpyCode, FF_BOK001_CODE, "B", BranchCode);
            poEdit.FF_BOK004Detail = GetFF_BOK004DetailList(CmpyCode, FF_BOK001_CODE, "B", BranchCode);
            poEdit.FF_BOK005Detail = GetFF_BOK005DetailList(CmpyCode, FF_BOK001_CODE, "B", BranchCode);

            //poEdit.PortList1 = GetPortListEdit(CmpyCode, poEdit.POL);
            //poEdit.PortList2 = GetPortListEdit(CmpyCode, poEdit.POD);
            //poEdit.PortList3 = GetPortListEdit(CmpyCode, poEdit.FND);

            //poEdit.PortList4 = GetPortListEdit(CmpyCode, poEdit.PLACE_OF_RCPT);


            //poEdit.PortList5 = GetPortListEdit(CmpyCode, poEdit.PICKUP_PLACE);

            //poEdit.CustList = GetCustEdit(CmpyCode, poEdit.BILL_TO);
            //poEdit.DEPARTMENTList = GetDepartEdit(CmpyCode, poEdit.DEPARTMENT);
            //poEdit.MoveCodeList = GetMoveCodeEdit(CmpyCode, poEdit.MOVE_TYPE);

            //poEdit.SLList = GetSLEdit(CmpyCode, poEdit.CARRIER,"FM");

            //poEdit.VESSELList = GetVESSELListEdit(CmpyCode, poEdit.VESSEL);
            //poEdit.VOYAGEList = GetVOYAGEList(CmpyCode, poEdit.VESSEL);
            //poEdit.Commodityist = GetCommodityistListEdit(CmpyCode, poEdit.Commodity_code);


            //poEdit.BILL_TOList = GetSLEdit(CmpyCode,poEdit.BILL_TO, "FM");
            //poEdit.SHIPPERList = GetSLEdit(CmpyCode, poEdit.SHIPPER, "OP");
            //poEdit.CONSIGNEEList = GetSLEdit(CmpyCode, poEdit.CONSIGNEE, "OP");
            //poEdit.FORWARDERList = GetSLEdit(CmpyCode, poEdit.FORWARDER, "OP");

            //poEdit.JobTypList = GETJobTypListEdit(CmpyCode, poEdit.JOB_TYPE);

            //poEdit.PortList = GetPortList(CmpyCode);
            //poEdit.CustList = GetCust(CmpyCode);
            //poEdit.VendorList = GetVendor(CmpyCode);
            //poEdit.CurList = GetCurcode(CmpyCode);
            //poEdit.UnitcodeList = GetUnitcode(CmpyCode);
            //poEdit.JobTypList = GETJobTypList(CmpyCode);
            //poEdit.DEPARTMENTList = GetDepart(CmpyCode);
            //poEdit.MoveCodeList = GetMoveCode(CmpyCode);
            //poEdit.ConTypList = GetContTyp(CmpyCode);
            //poEdit.CLAUSEList = GetCLAUSE(CmpyCode);
            //poEdit.CRG_002List = GetCRG_002(CmpyCode);
            //poEdit.Commodityist = GetCommodityistList(CmpyCode);
            //poEdit.SLList = GetSL(CmpyCode,"FM");
            //poEdit.BILL_TOList = GetSL(CmpyCode, "FM");
            //poEdit.SHIPPERList = GetSL(CmpyCode, "OP");
            //poEdit.CONSIGNEEList = GetSL(CmpyCode, "OP");
            //poEdit.FORWARDERList= GetSL(CmpyCode, "OP");

            //poEdit.VESSELList = GetVESSELList(CmpyCode);
            poEdit.FNMBRANCH_CODE = BranchCode;
            poEdit.VOYAGEList = GetVOYAGEList(CmpyCode, poEdit.VESSEL);
            poEdit.EditFlag = true;
            return poEdit;
        }

        //public List<SelectListItem> GETJobTypListEdit(string CmpyCode,string code)
        //{
        //    var UnitcodeList = _FF_BOKRepo.GETJobTypList(CmpyCode).Where(m => m.Code.ToString() == code).ToList()
        //                                           .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.CodeName) })
        //                                           .ToList();
        //    return InsertFirstElementDDL(UnitcodeList);
        //}
        public List<SelectListItem> GetMoveCode(string CmpyCode)
        {
            var CurrencyList = _FF_BOKRepo.GetMOVEList(CmpyCode)
                                          .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.CodeName) })
                                          .ToList();
            return InsertFirstElementDDL(CurrencyList);
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

        public FF_BOK_VM SaveFF_BOK_VM(FF_BOK_VM FQV)
        {
            return _FF_BOKRepo.SaveFF_BOK_VM(FQV);
        }

        public List<SelectListItem> GetDepart(string CmpyCode)
        {
            var DepartList = _FF_BOKRepo.GetDepart(CmpyCode)
                                          .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.CodeName) })
                                          .ToList();
            return InsertFirstElementDDL(DepartList);
        }

        public List<SelectListItem> GetVESSELList(string CmpyCode)
        {
            var VESSELList = _FF_BOKRepo.GetVESSELList(CmpyCode)
                                                 .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.CodeName) })
                                                 .ToList();
            return InsertFirstElementDDL(VESSELList);
        }

        public List<SelectListItem> GetVOYAGEList(string CmpyCode, string FFM_VESSEL_CODE)
        {
            var VOYAGEList = _FF_BOKRepo.GetVOYAGEList(CmpyCode, FFM_VESSEL_CODE)
                                                  .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.CodeName) })
                                                  .ToList();
            return InsertFirstElementDDL(VOYAGEList);
        }

        public List<SelectListItem> GetSL(string CmpyCode, string typ1,string Prefix)
        {
            var SLList = _FF_BOKRepo.GetSL(CmpyCode, typ1, Prefix)//.Where(m => m.CodeName.ToString().ToLower().Contains(Prefix.ToLower()) || m.Code.ToString().ToLower().Contains(Prefix.ToLower())).ToList()
                                                  .Select(m => new SelectListItem { Value = m.CodeName, Text = m.Code })
                                                  .ToList();
            return SLList;
        }

        public List<SelectListItem> GetCLAUSE(string CmpyCode)
        {
            var CLAUSEList = _FF_BOKRepo.GetCLAUSE(CmpyCode)
                                                .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.CodeName) })
                                                .ToList();
            return InsertFirstElementDDL(CLAUSEList);
        }
        public List<SelectListItem> GetContTyp(string CmpyCode)
        {
            var ContTypList = _FF_BOKRepo.GetContTyp(CmpyCode)
                                                  .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.CodeName) })
                                                  .ToList();
            return InsertFirstElementDDL(ContTypList);
        }
        public List<SelectListItem> GetCRG_002(string CmpyCode)
        {
            var CRG_002List = _FF_BOKRepo.GetCRG_002(CmpyCode)
                                          .Select(m => new SelectListItem { Value = m.FFM_CRG_JOB_CODE, Text = string.Concat(m.FFM_CRG_JOB_CODE, " - ", m.FFM_CRG_JOB_NAME, " - ", m.INCOME_ACT, " - ", m.EXPENSE_ACGT) })
                                          .ToList();
            return InsertFirstElementDDL(CRG_002List);
        }

        public FF_BOK_VM GetFF_BOK_AddNew(string Cmpycode, string branchcode)
        {
            return new FF_BOK_VM
            {
                FNMBRANCH_CODE=branchcode,
                //     CustList = GetCust(Cmpycode),
                //     CurList = GetCurcode(Cmpycode),
                //     UnitcodeList = GetUnitcode(Cmpycode),
                //     VendorList = GetVendor(Cmpycode),
                //     VOYAGEList = GetVOYAGEList(Cmpycode, "NA"),
                //     SLList = GetVendor(Cmpycode),
                //     JobTypList=GETJobTypList(Cmpycode),
                //     CLAUSEList = GetCLAUSE(Cmpycode),
                //     CRG_002List = GetCRG_002(Cmpycode),
                //     DEPARTMENTList = GetDepart(Cmpycode),
                //     MoveCodeList = GetMoveCode(Cmpycode),
                //     VESSELList = GetVESSELList(Cmpycode),
                //     PortList = GetPortList(Cmpycode),               
                // BILL_TOList = GetSL(Cmpycode, "FM"),
                // SHIPPERList = GetSL(Cmpycode, "OP"),
                //CONSIGNEEList = GetSL(Cmpycode, "OP"),
                // FORWARDERList = GetSL(Cmpycode, "OP"),
                // ConTypList=GetContTyp(Cmpycode),
                //FF_BOK001_CODE = _CodeRep.GetCode(Cmpycode, "SupplierBooking"),

                FF_BOK001_CODE = _CodeRep.GetCodeNew(Cmpycode, branchcode, "FF_BOK001"),

           // GetBOKCODEList = GetQTNCODE(Cmpycode,System.DateTime.Now),
                GetCustomerList = GetSL1(Cmpycode,"FM"),
            EditFlag = false
            };
        }
        public List<SelectListItem> GetSL1(string CmpyCode, string typ1)
        {
            var SLList = __FF_BLRepo.GetSL(CmpyCode, typ1)
                                                  .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.CodeName) })
                                                  .ToList();
            return InsertFirstElementDDL(SLList);
        }

        public List<SelectListItem> GetPortList(string CmpyCode)
        {
            var PortList = _FF_BOKRepo.GetPortList(CmpyCode)
                                                 .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.CodeName) })
                                                 .ToList();
            return InsertFirstElementDDL(PortList);
        }

        public List<SelectListItem> GetCust(string CmpyCode)
        {
            var CustList = _FF_BOKRepo.GetCust(CmpyCode)
                                                     .Select(m => new SelectListItem { Value = m.CUSTOMER_CODE, Text = string.Concat(m.CUSTOMER_CODE, " - ", m.CUSTOMER_NAME, " - ", m.CONTROL_ACT) })
                                                     .ToList();
            return InsertFirstElementDDL(CustList);
        }

        public List<SelectListItem> GetVendor(string CmpyCode)
        {
            var VendorList = _FF_BOKRepo.GetCust(CmpyCode)
                                                      .Select(m => new SelectListItem { Value = m.CUSTOMER_CODE, Text = string.Concat(m.CUSTOMER_CODE, " - ", m.CUSTOMER_NAME, " - ", m.CONTROL_ACT) })
                                                      .ToList();
            return InsertFirstElementDDL(VendorList);
        }

        public List<SelectListItem> GetCurcode(string CmpyCode)
        {
            var CurList = _FF_BOKRepo.GetCurcode(CmpyCode)
                                                    .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.CodeName) })
                                                    .ToList();
            return InsertFirstElementDDL(CurList);
        }

        public List<SelectListItem> GetUnitcode(string CmpyCode)
        {
            var UnitcodeList = _FF_BOKRepo.GetUnitcode(CmpyCode)
                                                    .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.CodeName) })
                                                    .ToList();
            return InsertFirstElementDDL(UnitcodeList);
        }

        public decimal GetCurRate(string CmpyCode, string CurCode)
        {
            return _FF_BOKRepo.GetCurRate(CmpyCode, CurCode);
        }

        public List<SelectListItem> GETJobTypList(string CmpyCode,string Prefix)
        {
            var JobTypList = _FF_BOKRepo.GETJobTypList(CmpyCode, Prefix)//.Where(m => m.CodeName.ToString().ToLower().Contains(Prefix.ToLower()) || m.Code.ToString().ToLower().Contains(Prefix.ToLower())).ToList()
                                                    .Select(m => new SelectListItem { Value = m.CodeName, Text = m.Code })
                                                    .ToList();
            return JobTypList;
        }
        public List<SelectListItem> GetCommodityistList(string CmpyCode)
        {
            var CommodityList = _FF_BOKRepo.GetCommodityistList(CmpyCode)
                                                  .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.CodeName) })
                                                  .ToList();
            return InsertFirstElementDDL(CommodityList);
        }
        //public List<SelectListItem> GetMoveCodeEdit(string CmpyCode, string code)
        //{
        //    var CurrencyList = _FF_BOKRepo.GetMOVEList(CmpyCode).Where(m => m.Code.ToString() == code).ToList()
        //                                  .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.CodeName) })
        //                                  .ToList();
        //    return InsertFirstElementDDL(CurrencyList);
        //}
        //public List<SelectListItem> GetPortListEdit(string CmpyCode, string code)
        //{
        //    var PortList = _FF_BOKRepo.GetPortList(CmpyCode).Where(m => m.Code.ToString() == code).ToList()
        //                                         .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.CodeName) })
        //                                         .ToList();
        //    return InsertFirstElementDDL(PortList);
        //}

        //public List<SelectListItem> GetCustEdit(string CmpyCode, string code)
        //{
        //    var CustList = _FF_BOKRepo.GetCust(CmpyCode).Where(m => m.CUSTOMER_CODE.ToString() == code).ToList()
        //                                             .Select(m => new SelectListItem { Value = m.CUSTOMER_CODE, Text = string.Concat(m.CUSTOMER_CODE, " - ", m.CUSTOMER_NAME, " - ", m.CONTROL_ACT) })
        //                                             .ToList();
        //    return InsertFirstElementDDL(CustList);
        //}

        //public List<SelectListItem> GetVendorEdit(string CmpyCode, string code)
        //{
        //    var VendorList = _FF_BOKRepo.GetCust(CmpyCode).Where(m => m.CUSTOMER_CODE.ToString() == code).ToList()
        //                                              .Select(m => new SelectListItem { Value = m.CUSTOMER_CODE, Text = string.Concat(m.CUSTOMER_CODE, " - ", m.CUSTOMER_NAME, " - ", m.CONTROL_ACT) })
        //                                              .ToList();
        //    return InsertFirstElementDDL(VendorList);
        //}

        //public List<SelectListItem> GetCurcodeEdit(string CmpyCode, string code)
        //{
        //    var CurList = _FF_BOKRepo.GetCurcode(CmpyCode).Where(m => m.Code.ToString() == code).ToList()
        //                                            .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.CodeName) })
        //                                            .ToList();
        //    return InsertFirstElementDDL(CurList);
        //}

        //public List<SelectListItem> GetUnitcodeEdit(string CmpyCode, string code)
        //{
        //    var UnitcodeList = _FF_BOKRepo.GetUnitcode(CmpyCode).Where(m => m.Code.ToString() == code).ToList()
        //                                            .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.CodeName) })
        //                                            .ToList();
        //    return InsertFirstElementDDL(UnitcodeList);
        //}

        //public List<SelectListItem> GetContTypEdit(string CmpyCode, string code)
        //{
        //    var ContTypList = _FF_BOKRepo.GetContTyp(CmpyCode).Where(m => m.Code.ToString() == code).ToList()
        //                                          .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.CodeName) })
        //                                          .ToList();
        //    return InsertFirstElementDDL(ContTypList);
        //}
        //public List<SelectListItem> GetCommodityistListEdit(string CmpyCode, string code)
        //{
        //    var CommodityList = _FF_BOKRepo.GetCommodityistList(CmpyCode).Where(m => m.Code.ToString() == code).ToList()
        //                                          .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.CodeName) })
        //                                          .ToList();
        //    return InsertFirstElementDDL(CommodityList);
        //}

        //public List<SelectListItem> GetDepartEdit(string CmpyCode, string code)
        //{
        //    var DepartList = _FF_BOKRepo.GetDepart(CmpyCode).Where(m => m.Code.ToString() == code).ToList()
        //                                  .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.CodeName) })
        //                                  .ToList();
        //    return InsertFirstElementDDL(DepartList);
        //}
        //public List<SelectListItem> GetVESSELListEdit(string CmpyCode, string code)
        //{
        //    var VESSELList = _FF_BOKRepo.GetVESSELList(CmpyCode).Where(m => m.Code.ToString() == code).ToList()
        //                                         .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.CodeName) })
        //                                         .ToList();
        //    return InsertFirstElementDDL(VESSELList);
        //}
        //public List<SelectListItem> GetSLEdit(string CmpyCode, string code, string typ1)
        //{
        //    var SLList = _FF_BOKRepo.GetSL(CmpyCode, typ1).Where(m => m.Code.ToString() == code).ToList()
        //                                          .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.CodeName) })
        //                                          .ToList();
        //    return InsertFirstElementDDL(SLList);
        //}

        //public List<SelectListItem> GetCLAUSEEdit(string CmpyCode, string code)
        //{
        //    var CLAUSEList = _FF_BOKRepo.GetCLAUSE(CmpyCode).Where(m => m.Code.ToString() == code).ToList()
        //                                        .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.CodeName) })
        //                                        .ToList();
        //    return InsertFirstElementDDL(CLAUSEList);
        //}

        //public List<SelectListItem> GetCRG_002Edit(string CmpyCode, string code)
        //{
        //    var CRG_002List = _FF_BOKRepo.GetCRG_002(CmpyCode).Where(m => m.FFM_CRG_JOB_CODE.ToString() == code).ToList()
        //                                  .Select(m => new SelectListItem { Value = m.FFM_CRG_JOB_CODE, Text = string.Concat(m.FFM_CRG_JOB_CODE, " - ", m.FFM_CRG_JOB_NAME, " - ", m.INCOME_ACT, " - ", m.EXPENSE_ACGT) })
        //                                  .ToList();
        //    return InsertFirstElementDDL(CRG_002List);
        //}
        public List<SelectListItem> GetQTNCODE(string CmpyCode, DateTime dt)
        {
            var CRG_002List = _FF_BOKRepo.GetQTNCODE(CmpyCode,dt)
                                         .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.CodeName) })
                                         .ToList();
            return InsertFirstElementDDL(CRG_002List);
        }

        public List<SelectListItem> GetQTNCODEbycusto(string CmpyCode,string custocode, DateTime vdate, string BranchCode)
        {
            var CRG_002List = _FF_BOKRepo.GetQTNCODEbucusto(CmpyCode, custocode, vdate, BranchCode)
                                         .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.CodeName) })
                                         .ToList();
            return InsertFirstElementDDL(CRG_002List);
        }

        public FF_BOK_VM GetFF_BOKDetailsQuot(string CmpyCode, string FF_BOK001_CODE1,string BranchCode)
        {
            var poEdit = _FF_BOKRepo.GetFF_BOKDetailsQuot(CmpyCode, FF_BOK001_CODE1, BranchCode);
            poEdit.FF_BOK002Detail = GetFF_BOK002DetailList(CmpyCode, FF_BOK001_CODE1, "Q", BranchCode);
            poEdit.FF_BOK003Detail = GetFF_BOK003DetailList(CmpyCode, FF_BOK001_CODE1, "Q", BranchCode);
            poEdit.FF_BOK004Detail = GetFF_BOK004DetailList(CmpyCode, FF_BOK001_CODE1, "Q", BranchCode);
            poEdit.FF_BOK005Detail = GetFF_BOK005DetailList(CmpyCode, FF_BOK001_CODE1, "Q", BranchCode);
            //poEdit.FF_BOK001_CODE = _CodeRep.GetCode(CmpyCode, "SupplierBooking");

            poEdit.FF_BOK001_CODE = _CodeRep.GetCodeNew(CmpyCode, BranchCode, "FF_BOK001");
            //poEdit.PortList1 = GetPortListEdit(CmpyCode, poEdit.POL);
            //poEdit.PortList2 = GetPortListEdit(CmpyCode, poEdit.POD);
            //poEdit.PortList3 = GetPortListEdit(CmpyCode, poEdit.FND);

            //poEdit.PortList4 = GetPortListEdit(CmpyCode, poEdit.PLACE_OF_RCPT);


            //poEdit.PortList5 = GetPortListEdit(CmpyCode, poEdit.PICKUP_PLACE);

            //poEdit.CustList = GetCustEdit(CmpyCode, poEdit.BILL_TO);
            //poEdit.DEPARTMENTList = GetDepartEdit(CmpyCode, poEdit.DEPARTMENT);
            //poEdit.MoveCodeList = GetMoveCodeEdit(CmpyCode, poEdit.MOVE_TYPE);

            //poEdit.SLList = GetSLEdit(CmpyCode, poEdit.CARRIER, "FM");

            //poEdit.VESSELList = GetVESSELListEdit(CmpyCode, poEdit.VESSEL);
            //poEdit.VOYAGEList = GetVOYAGEList(CmpyCode, poEdit.VESSEL);
            //poEdit.Commodityist = GetCommodityistListEdit(CmpyCode, poEdit.Commodity_code);


            //poEdit.BILL_TOList = GetSLEdit(CmpyCode, poEdit.BILL_TO, "FM");
            //poEdit.SHIPPERList = GetSLEdit(CmpyCode, poEdit.SHIPPER, "OP");
            //poEdit.CONSIGNEEList = GetSLEdit(CmpyCode, poEdit.CONSIGNEE, "OP");
            //poEdit.FORWARDERList = GetSLEdit(CmpyCode, poEdit.FORWARDER, "OP");

            //poEdit.JobTypList = GETJobTypListEdit(CmpyCode, poEdit.JOB_TYPE);

            //poEdit.PortList = GetPortList(CmpyCode);
            //poEdit.CustList = GetCust(CmpyCode);
            //poEdit.VendorList = GetVendor(CmpyCode);
            //poEdit.CurList = GetCurcode(CmpyCode);
            //poEdit.UnitcodeList = GetUnitcode(CmpyCode);
            //poEdit.JobTypList = GETJobTypList(CmpyCode);
            //poEdit.DEPARTMENTList = GetDepart(CmpyCode);
            //poEdit.MoveCodeList = GetMoveCode(CmpyCode);
            //poEdit.ConTypList = GetContTyp(CmpyCode);
            //poEdit.CLAUSEList = GetCLAUSE(CmpyCode);
            //poEdit.CRG_002List = GetCRG_002(CmpyCode);
            //poEdit.Commodityist = GetCommodityistList(CmpyCode);
            //poEdit.SLList = GetSL(CmpyCode,"FM");
            //poEdit.BILL_TOList = GetSL(CmpyCode, "FM");
            //poEdit.SHIPPERList = GetSL(CmpyCode, "OP");
            //poEdit.CONSIGNEEList = GetSL(CmpyCode, "OP");
            //poEdit.FORWARDERList= GetSL(CmpyCode, "OP");

            //poEdit.VESSELList = GetVESSELList(CmpyCode);
            poEdit.VOYAGEList = GetVOYAGEList(CmpyCode, poEdit.VESSEL);
            poEdit.EditFlag = false;
            return poEdit;
        }

        public List<SelectListItem> GetSLNew(string CmpyCode, string Typ1, string Prefix)
        {
            var SLNewList = _FF_BOKRepo.GetSLNew(CmpyCode, Typ1,Prefix)
                                                .Select(m => new SelectListItem { Value = m.CodeName, Text = m.Code })
                                                .ToList();
            return SLNewList;
        }

        public List<SelectListItem> GetSalesman(string cmpycode, string Prefix)
        {
            var SLList = _FF_BOKRepo.GetSalesman(cmpycode, Prefix)//.Where(m => m.CodeName.ToString().ToLower().Contains(Prefix.ToLower()) || m.Code.ToString().ToLower().Contains(Prefix.ToLower())).ToList()
                                                  .Select(m => new SelectListItem { Value = m.CodeName, Text = m.Code })
                                                  .ToList();
            return SLList;
        }

        public string Aprrove_QTN(string CmpyCode, string FF_BOK001_CODE, string UserName, string Typ, string BranchCode, string Tablename)
        {
            return _CodeRep.Aprrove_QTN(CmpyCode, FF_BOK001_CODE, UserName, Typ, BranchCode, Tablename);
        }
    }
}
