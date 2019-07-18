using EzBusiness_BL_Interface.FreightManagementBLI.SEA_Export;
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
    public class FF_BLService : IFF_BLService
    {

        IFF_BLRepository _FF_BLRepo;
        public FF_BLService()
        {
            _FF_BLRepo = new FF_BLRepository();

        }
        DropListFillFun drop = new DropListFillFun();
        public bool DeleteFF_BL(string CmpyCode, string FF_BL001_CODE, string UserName)
        {
            return _FF_BLRepo.DeleteFF_BL(CmpyCode, FF_BL001_CODE, UserName);
        }

        public List<FF_BL_VM> GetFF_BL(string CmpyCode)
        {
            return _FF_BLRepo.GetFF_BL(CmpyCode);
        }

        public List<FF_BL002New> GetFF_BL002DetailList(string CmpyCode, string FF_BL001_CODE,string typ)
        {
            var FF_BL002DetailList = _FF_BLRepo.GetFF_BL002DetailList(CmpyCode, FF_BL001_CODE, typ);
            return FF_BL002DetailList.Select(m => new FF_BL002New
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

        public List<FF_BL003New> GetFF_BL003DetailList(string CmpyCode, string FF_BL001_CODE,string typ)
        {
            var FF_BL003DetailList = _FF_BLRepo.GetFF_BL003DetailList(CmpyCode, FF_BL001_CODE, typ);
            return FF_BL003DetailList.Select(m => new FF_BL003New
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

        public List<FF_BL004New> GetFF_BL004DetailList(string CmpyCode, string FF_BL001_CODE,string typ)
        {
            var FF_BL004DetailList = _FF_BLRepo.GetFF_BL004DetailList(CmpyCode, FF_BL001_CODE, typ);
            return FF_BL004DetailList.Select(m => new FF_BL004New
            {
                CLUASE_CODE = m.CLUASE_CODE,
                CLUASE_NAME = m.CLUASE_NAME,
                //CLAUSEList4 = GetCLAUSEEdit(CmpyCode, m.CLUASE_CODE)

            }).ToList();
        }

        public List<FF_BL005New> GetFF_BL005DetailList(string CmpyCode, string FF_BL001_CODE,string typ)
        {
            var FF_BL005DetailList = _FF_BLRepo.GetFF_BL005DetailList(CmpyCode, FF_BL001_CODE, typ);
            return FF_BL005DetailList.Select(m => new FF_BL005New
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

        public FF_BL_VM GetFF_BLDetailsEdit(string CmpyCode, string FF_BL001_CODE)
        {
            var poEdit = _FF_BLRepo.GetFF_BLDetailsEdit(CmpyCode, FF_BL001_CODE);
            poEdit.FF_BL002Detail = GetFF_BL002DetailList(CmpyCode, FF_BL001_CODE,"BL");
            poEdit.FF_BL003Detail = GetFF_BL003DetailList(CmpyCode, FF_BL001_CODE, "BL");
            poEdit.FF_BL004Detail = GetFF_BL004DetailList(CmpyCode, FF_BL001_CODE, "BL");
            poEdit.FF_BL005Detail = GetFF_BL005DetailList(CmpyCode, FF_BL001_CODE, "BL");
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
            //poEdit.CLAUSEList = GetCLAUSE(CmpyCode);
            //poEdit.CRG_002List = GetCRG_002(CmpyCode);
            //poEdit.ConTypList = GetContTyp(CmpyCode);
            //poEdit.SLList = GetSL(CmpyCode,"FM");
            //poEdit.BILL_TOList = GetSL(CmpyCode, "FM");
            //poEdit.SHIPPERList = GetSL(CmpyCode, "OP");
            //poEdit.CONSIGNEEList = GetSL(CmpyCode, "OP");
            //poEdit.FORWARDERList= GetSL(CmpyCode, "OP");
            //poEdit.Commodityist = GetCommodityistList(CmpyCode);
            //poEdit.VESSELList = GetVESSELList(CmpyCode);
            poEdit.VOYAGEList = GetVOYAGEList(CmpyCode, poEdit.VESSEL);
            poEdit.EditFlag = true;
            return poEdit;
        }
        public List<SelectListItem> GETJobTypListEdit(string CmpyCode, string code)
        {
            var UnitcodeList = _FF_BLRepo.GETJobTypList(CmpyCode).Where(m => m.Code.ToString() == code).ToList()
                                                   .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.CodeName) })
                                                   .ToList();
            return InsertFirstElementDDL(UnitcodeList);
        }

        public List<SelectListItem> GetMoveCode(string CmpyCode)
        {
            var CurrencyList = _FF_BLRepo.GetMOVEList(CmpyCode)
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

        public FF_BL_VM SaveFF_BL_VM(FF_BL_VM FQV)
        {
            return _FF_BLRepo.SaveFF_BL_VM(FQV);
        }

        public List<SelectListItem> GetDepart(string CmpyCode)
        {
            var DepartList = _FF_BLRepo.GetDepart(CmpyCode)
                                          .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.CodeName) })
                                          .ToList();
            return InsertFirstElementDDL(DepartList);
        }

        public List<SelectListItem> GetVESSELList(string CmpyCode)
        {
            var VESSELList = _FF_BLRepo.GetVESSELList(CmpyCode)
                                                 .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.CodeName) })
                                                 .ToList();
            return InsertFirstElementDDL(VESSELList);
        }

        public List<SelectListItem> GetVOYAGEList(string CmpyCode, string FFM_VESSEL_CODE)
        {
            var VOYAGEList = _FF_BLRepo.GetVOYAGEList(CmpyCode, FFM_VESSEL_CODE)
                                                  .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.CodeName) })
                                                  .ToList();
            return InsertFirstElementDDL(VOYAGEList);
        }

        public List<SelectListItem> GetSL(string CmpyCode, string typ1)
        {
            var SLList = _FF_BLRepo.GetSL(CmpyCode, typ1)
                                                  .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.CodeName) })
                                                  .ToList();
            return InsertFirstElementDDL(SLList);
        }

        public List<SelectListItem> GetCLAUSE(string CmpyCode)
        {
            var CLAUSEList = _FF_BLRepo.GetCLAUSE(CmpyCode)
                                                .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.CodeName) })
                                                .ToList();
            return InsertFirstElementDDL(CLAUSEList);
        }

        public List<SelectListItem> GetCRG_002(string CmpyCode)
        {
            var CRG_002List = _FF_BLRepo.GetCRG_002(CmpyCode)
                                           .Select(m => new SelectListItem { Value = m.FFM_CRG_JOB_CODE, Text = string.Concat(m.FFM_CRG_JOB_CODE, " - ", m.FFM_CRG_JOB_NAME, " - ", m.INCOME_ACT, " - ", m.EXPENSE_ACGT) })
                                           .ToList();
            return InsertFirstElementDDL(CRG_002List);
        }

        public FF_BL_VM GetFF_BL_AddNew(string Cmpycode)
        {
            return new FF_BL_VM
            {
           //     CustList = GetCust(Cmpycode),
           //     CurList = GetCurcode(Cmpycode),
           //     UnitcodeList = GetUnitcode(Cmpycode),
           //     VendorList = GetVendor(Cmpycode),
           //     VOYAGEList = GetVOYAGEList(Cmpycode, "NA"),
           //     JobTypList=GETJobTypList(Cmpycode),
           //     SLList = GetVendor(Cmpycode),
           //     CLAUSEList = GetCLAUSE(Cmpycode),
           //     CRG_002List = GetCRG_002(Cmpycode),
           //     DEPARTMENTList = GetDepart(Cmpycode),
           //     MoveCodeList = GetMoveCode(Cmpycode),
           //     VESSELList = GetVESSELList(Cmpycode),
           //     Commodityist=GetCommodityistList(Cmpycode),
           //     PortList = GetPortList(Cmpycode),               
           // BILL_TOList = GetSL(Cmpycode, "FM"),
           // SHIPPERList = GetSL(Cmpycode, "OP"),
           //CONSIGNEEList = GetSL(Cmpycode, "OP"),
           // FORWARDERList = GetSL(Cmpycode, "OP"),
           // ConTypList=GetContTyp(Cmpycode),
           GetBOKCODEList=GetBOKCODE(Cmpycode,System.DateTime.Now),
            EditFlag = false
            };
        }

        public List<SelectListItem> GetPortList(string CmpyCode)
        {
            var PortList = _FF_BLRepo.GetPortList(CmpyCode)
                                                 .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.CodeName) })
                                                 .ToList();
            return InsertFirstElementDDL(PortList);
        }

        public List<SelectListItem> GetCust(string CmpyCode)
        {
            var CustList = _FF_BLRepo.GetCust(CmpyCode)
                                                     .Select(m => new SelectListItem { Value = m.CUSTOMER_CODE, Text = string.Concat(m.CUSTOMER_CODE, " - ", m.CUSTOMER_NAME," - ",m.CONTROL_ACT) })
                                                     .ToList();
            return InsertFirstElementDDL(CustList);
        }

        public List<SelectListItem> GetVendor(string CmpyCode)
        {
            var VendorList = _FF_BLRepo.GetCust(CmpyCode)
                                                      .Select(m => new SelectListItem { Value = m.CUSTOMER_CODE, Text = string.Concat(m.CUSTOMER_CODE, " - ", m.CUSTOMER_NAME, " - ", m.CONTROL_ACT) })
                                                      .ToList();
            return InsertFirstElementDDL(VendorList);
        }

        public List<SelectListItem> GetCurcode(string CmpyCode)
        {
            var CurList = _FF_BLRepo.GetCurcode(CmpyCode)
                                                    .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.CodeName) })
                                                    .ToList();
            return InsertFirstElementDDL(CurList);
        }

        public List<SelectListItem> GetUnitcode(string CmpyCode)
        {
            var UnitcodeList = _FF_BLRepo.GetUnitcode(CmpyCode)
                                                    .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.CodeName) })
                                                    .ToList();
            return InsertFirstElementDDL(UnitcodeList);
        }

        public decimal GetCurRate(string CmpyCode, string CurCode)
        {
            return _FF_BLRepo.GetCurRate(CmpyCode, CurCode);
        }

        public List<SelectListItem> GETJobTypList(string CmpyCode)
        {
            var JobTypList = _FF_BLRepo.GETJobTypList(CmpyCode)
                                                   .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.CodeName) })
                                                   .ToList();
            return InsertFirstElementDDL(JobTypList);
        }

        public List<SelectListItem> GetContTyp(string CmpyCode)
        {
            var ContTypList = _FF_BLRepo.GetContTyp(CmpyCode)
                                                  .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.CodeName) })
                                                  .ToList();
            return InsertFirstElementDDL(ContTypList);
        }

        public List<SelectListItem> GetCommodityistList(string CmpyCode)
        {
            var CommodityList = _FF_BLRepo.GetCommodityistList(CmpyCode)
                                                  .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.CodeName) })
                                                  .ToList();
            return InsertFirstElementDDL(CommodityList);
        }
        public List<SelectListItem> GetMoveCodeEdit(string CmpyCode, string code)
        {
            var CurrencyList = _FF_BLRepo.GetMOVEList(CmpyCode).Where(m => m.Code.ToString() == code).ToList()
                                          .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.CodeName) })
                                          .ToList();
            return InsertFirstElementDDL(CurrencyList);
        }
        public List<SelectListItem> GetPortListEdit(string CmpyCode, string code)
        {
            var PortList = _FF_BLRepo.GetPortList(CmpyCode).Where(m => m.Code.ToString() == code).ToList()
                                                 .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.CodeName) })
                                                 .ToList();
            return InsertFirstElementDDL(PortList);
        }

        public List<SelectListItem> GetCustEdit(string CmpyCode, string code)
        {
            var CustList = _FF_BLRepo.GetCust(CmpyCode).Where(m => m.CUSTOMER_CODE.ToString() == code).ToList()
                                                     .Select(m => new SelectListItem { Value = m.CUSTOMER_CODE, Text = string.Concat(m.CUSTOMER_CODE, " - ", m.CUSTOMER_NAME, " - ", m.CONTROL_ACT) })
                                                     .ToList();
            return InsertFirstElementDDL(CustList);
        }

        public List<SelectListItem> GetVendorEdit(string CmpyCode, string code)
        {
            var VendorList = _FF_BLRepo.GetCust(CmpyCode).Where(m => m.CUSTOMER_CODE.ToString() == code).ToList()
                                                      .Select(m => new SelectListItem { Value = m.CUSTOMER_CODE, Text = string.Concat(m.CUSTOMER_CODE, " - ", m.CUSTOMER_NAME, " - ", m.CONTROL_ACT) })
                                                      .ToList();
            return InsertFirstElementDDL(VendorList);
        }

        public List<SelectListItem> GetCurcodeEdit(string CmpyCode, string code)
        {
            var CurList = _FF_BLRepo.GetCurcode(CmpyCode).Where(m => m.Code.ToString() == code).ToList()
                                                    .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.CodeName) })
                                                    .ToList();
            return InsertFirstElementDDL(CurList);
        }

        public List<SelectListItem> GetUnitcodeEdit(string CmpyCode, string code)
        {
            var UnitcodeList = _FF_BLRepo.GetUnitcode(CmpyCode).Where(m => m.Code.ToString() == code).ToList()
                                                    .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.CodeName) })
                                                    .ToList();
            return InsertFirstElementDDL(UnitcodeList);
        }

        public List<SelectListItem> GetContTypEdit(string CmpyCode, string code)
        {
            var ContTypList = _FF_BLRepo.GetContTyp(CmpyCode).Where(m => m.Code.ToString() == code).ToList()
                                                  .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.CodeName) })
                                                  .ToList();
            return InsertFirstElementDDL(ContTypList);
        }
        public List<SelectListItem> GetCommodityistListEdit(string CmpyCode, string code)
        {
            var CommodityList = _FF_BLRepo.GetCommodityistList(CmpyCode).Where(m => m.Code.ToString() == code).ToList()
                                                  .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.CodeName) })
                                                  .ToList();
            return InsertFirstElementDDL(CommodityList);
        }

        public List<SelectListItem> GetBOKCODE(string CmpyCode, DateTime dte)
        {
            var CommodityList = _FF_BLRepo.GetBOKCODE(CmpyCode, dte).ToList()
                                                  .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.CodeName) })
                                                  .ToList();
            return InsertFirstElementDDL(CommodityList);
        }

        public List<SelectListItem> GetDepartEdit(string CmpyCode, string code)
        {
            var DepartList = _FF_BLRepo.GetDepart(CmpyCode).Where(m => m.Code.ToString() == code).ToList()
                                          .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.CodeName) })
                                          .ToList();
            return InsertFirstElementDDL(DepartList);
        }
        public List<SelectListItem> GetVESSELListEdit(string CmpyCode, string code)
        {
            var VESSELList = _FF_BLRepo.GetVESSELList(CmpyCode).Where(m => m.Code.ToString() == code).ToList()
                                                 .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.CodeName) })
                                                 .ToList();
            return InsertFirstElementDDL(VESSELList);
        }
        public List<SelectListItem> GetSLEdit(string CmpyCode, string code, string typ1)
        {
            var SLList = _FF_BLRepo.GetSL(CmpyCode, typ1).Where(m => m.Code.ToString() == code).ToList()
                                                  .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.CodeName) })
                                                  .ToList();
            return InsertFirstElementDDL(SLList);
        }

        public List<SelectListItem> GetCLAUSEEdit(string CmpyCode, string code)
        {
            var CLAUSEList = _FF_BLRepo.GetCLAUSE(CmpyCode).Where(m => m.Code.ToString() == code).ToList()
                                                .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.CodeName) })
                                                .ToList();
            return InsertFirstElementDDL(CLAUSEList);
        }

        public List<SelectListItem> GetCRG_002Edit(string CmpyCode, string code)
        {
            var CRG_002List = _FF_BLRepo.GetCRG_002(CmpyCode).Where(m => m.FFM_CRG_JOB_CODE.ToString() == code).ToList()
                                          .Select(m => new SelectListItem { Value = m.FFM_CRG_JOB_CODE, Text = string.Concat(m.FFM_CRG_JOB_CODE, " - ", m.FFM_CRG_JOB_NAME, " - ", m.INCOME_ACT, " - ", m.EXPENSE_ACGT) })
                                          .ToList();
            return InsertFirstElementDDL(CRG_002List);
        }

        public FF_BL_VM GetFF_BLDetailsBk(string CmpyCode, string FF_BOK001_CODE)
        {
            var poEdit = _FF_BLRepo.GetFF_BLDetailsBk(CmpyCode, FF_BOK001_CODE);
            poEdit.FF_BL002Detail = GetFF_BL002DetailList(CmpyCode, FF_BOK001_CODE, "BK");
            poEdit.FF_BL003Detail = GetFF_BL003DetailList(CmpyCode, FF_BOK001_CODE, "BK");
            poEdit.FF_BL004Detail = GetFF_BL004DetailList(CmpyCode, FF_BOK001_CODE, "BK");
            poEdit.FF_BL005Detail = GetFF_BL005DetailList(CmpyCode, FF_BOK001_CODE, "BK");
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
            //poEdit.CLAUSEList = GetCLAUSE(CmpyCode);
            //poEdit.CRG_002List = GetCRG_002(CmpyCode);
            //poEdit.ConTypList = GetContTyp(CmpyCode);
            //poEdit.SLList = GetSL(CmpyCode,"FM");
            //poEdit.BILL_TOList = GetSL(CmpyCode, "FM");
            //poEdit.SHIPPERList = GetSL(CmpyCode, "OP");
            //poEdit.CONSIGNEEList = GetSL(CmpyCode, "OP");
            //poEdit.FORWARDERList= GetSL(CmpyCode, "OP");
            //poEdit.Commodityist = GetCommodityistList(CmpyCode);
            //poEdit.VESSELList = GetVESSELList(CmpyCode);
            poEdit.VOYAGEList = GetVOYAGEList(CmpyCode, poEdit.VESSEL);
            poEdit.EditFlag = true;
            return poEdit;
        }

    
    }
}
