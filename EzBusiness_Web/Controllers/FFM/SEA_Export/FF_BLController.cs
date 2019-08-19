﻿using EzBusiness_BL_Service.FreightManagementBLS.SEA_Export;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.FreightManagement.SEA_Export;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EzBusiness_Web.Controllers.FFM.SEA_Export
{
    public class FF_BLController : Controller
    {
        // GET: FFM_BL

        FF_BLService _BLService;
        FF_BOKService _bkservice;
        public FF_BLController()
        {
            _BLService = new FF_BLService();
        }


        [Route("Aprrove_BLL")]
        public ActionResult Aprrove_QTN(string FF_BL001_CODE, string Typ)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { StatusFlag = _BLService.Aprrove_QTN(list[0].CmpyCode, FF_BL001_CODE, list[0].user_name, Typ, list[0].BraCode, "FF_BL001") }, JsonRequestBehavior.AllowGet);
            }
        }

        [Route("BILL")]
        public ActionResult FF_BL()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return View(_BLService.GetFF_BL_AddNew(list[0].CmpyCode, list[0].BraCode));
            }
        }

        [Route("DeleteBL")]
        public ActionResult DeleteFF_BL(string FF_BL001_CODE)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { DeleteFlag = _BLService.DeleteFF_BL(FF_BL001_CODE, list[0].CmpyCode, list[0].user_name, list[0].BraCode) }, JsonRequestBehavior.AllowGet);
            }
        }
        [Route("EditFF_BLDetails")]
        public ActionResult FF_BLDetailsEdit(string FF_BL001_CODE)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_BLService.GetFF_BLDetailsEdit(list[0].CmpyCode, FF_BL001_CODE,list[0].BraCode));
            }
        }

        [Route("AddFF_BLDetails")]
        public ActionResult AddFF_BLDetails()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_BLService.GetFF_BL_AddNew(list[0].CmpyCode, list[0].BraCode));
            }
        }
        [Route("GetCustomerList")]
        public ActionResult GetCustomerList(string Prefix)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_BLService.GetSL(list[0].CmpyCode,Prefix), JsonRequestBehavior.AllowGet);
            }
        }
      
        public ActionResult GetFF_BLDetailList()
        {
            //List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            //if (list == null)
            //{
            //    return Redirect("Login/InLogin");
            //}
            //else
            //{

            //    return PartialView(_BLService.GetFF_BL(list[0].CmpyCode,list[0].BraCode,"EXP"));
            //}

            JsonResult result = new JsonResult();
            try
            {
                List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
                if (list == null)
                {
                    return Redirect("Login/InLogin");
                }
                else
                {
                    // Initialization.
                    string search = Request.Form.GetValues("search[value]")[0];
                    string draw = Request.Form.GetValues("draw")[0];
                    string order = Request.Form.GetValues("order[0][column]")[0];
                    string orderDir = Request.Form.GetValues("order[0][dir]")[0];
                    int startRec = Convert.ToInt32(Request.Form.GetValues("start")[0]);
                    int pageSize = Convert.ToInt32(Request.Form.GetValues("length")[0]);

                    string BILLCode = Request.Form.GetValues("columns[0][search][value]").FirstOrDefault();
                    string BILLDate = Request.Form.GetValues("columns[1][search][value]").FirstOrDefault();
                    string QTNCode = Request.Form.GetValues("columns[2][search][value]").FirstOrDefault();
                    string BookCode = Request.Form.GetValues("columns[3][search][value]").FirstOrDefault();
                    string BILLTO = Request.Form.GetValues("columns[4][search][value]").FirstOrDefault();
                    string SHIPPER = Request.Form.GetValues("columns[5][search][value]").FirstOrDefault();
                    string CONSIGNEE = Request.Form.GetValues("columns[6][search][value]").FirstOrDefault();
                    string FORWARDER = Request.Form.GetValues("columns[7][search][value]").FirstOrDefault();
                    string PICKUP_PLACE = Request.Form.GetValues("columns[8][search][value]").FirstOrDefault();
                    string POL = Request.Form.GetValues("columns[9][search][value]").FirstOrDefault();
                    string POD = Request.Form.GetValues("columns[10][search][value]").FirstOrDefault();
                    string FND = Request.Form.GetValues("columns[11][search][value]").FirstOrDefault();
                    string PLACEOFRCPT = Request.Form.GetValues("columns[12][search][value]").FirstOrDefault();
                    string MOVETYPE = Request.Form.GetValues("columns[13][search][value]").FirstOrDefault();
                    string DELIVERYAT = Request.Form.GetValues("columns[14][search][value]").FirstOrDefault();
                    string REFNo = Request.Form.GetValues("columns[15][search][value]").FirstOrDefault();
                    string Vessal = Request.Form.GetValues("columns[16][search][value]").FirstOrDefault();
                    string Voyage = Request.Form.GetValues("columns[17][search][value]").FirstOrDefault();
                    string ETD = Request.Form.GetValues("columns[18][search][value]").FirstOrDefault();
                    string ETA = Request.Form.GetValues("columns[19][search][value]").FirstOrDefault();
                    string CARRIER = Request.Form.GetValues("columns[20][search][value]").FirstOrDefault();
                    string DEPARTMENT = Request.Form.GetValues("columns[21][search][value]").FirstOrDefault();
                    string TotalCost = Request.Form.GetValues("columns[22][search][value]").FirstOrDefault();
                    string TotalBilled = Request.Form.GetValues("columns[23][search][value]").FirstOrDefault();
                    string TotalProfit = Request.Form.GetValues("columns[24][search][value]").FirstOrDefault();


                    if (pageSize == -1)
                    {
                        draw = "2";
                    }

                    List<FF_BL_VM> data = _BLService.GetFF_BL(list[0].CmpyCode, list[0].BraCode, "EXP");
                    // Total record count.
                    int totalRecords = 0;
                    if (data != null)
                    {
                        totalRecords = data.Count;
                    }
                    else
                        totalRecords = 0;
                    // Verification.
                    if (!string.IsNullOrEmpty(search) &&
                        !string.IsNullOrWhiteSpace(search))
                    {
                        // Apply search
                        data = data.Where(p => p.AGENT.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.BILL_TO.ToLower().Contains(search.ToLower()) ||
                                               p.CARRIER.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.Commodity_code.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.CONSIGNEE.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.DELIVERY_AT.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.DG.ToLower().Contains(search.ToLower()) ||
                                               p.ETA.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.ETD.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.FND.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.FORWARDER.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.JOB_TYPE.ToString().ToLower().Contains(search.ToLower())||
                                               p.MOVE_TYPE.ToLower().Contains(search.ToLower()) ||
                                               p.notifypart1.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.notifypart2.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.PICKUP_PLACE.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.PLACE_OF_RCPT.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.POD.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.VOYAGE.ToLower().Contains(search.ToLower()) ||
                                               p.VESSEL.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.Total_Profit.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.Total_Cost.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.Total_Billed.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.Salesman.ToLower().Contains(search.ToLower()) ||
                                               p.REF_NO.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.POL.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.FF_QTN001_CODE.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.FF_BOK001_CODE.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.FF_BL001_CODE.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.SHIPPER.ToString().ToLower().Contains(search.ToLower())
                                              ).ToList();

                    }

                    if (!string.IsNullOrEmpty(BILLCode) &&
                        !string.IsNullOrWhiteSpace(BILLCode))
                    {
                        data = data.Where(p => p.FF_BL001_CODE.ToString().ToLower().Contains(BILLCode.ToLower())
                                              ).ToList();
                    }

                    if (!string.IsNullOrEmpty(BILLDate) &&
                       !string.IsNullOrWhiteSpace(BILLDate))
                    {
                        data = data.Where(p => Convert.ToDateTime(p.FF_BL001_DATE).ToString("dd-MM-yyyy").ToLower().Contains(BILLDate.ToLower())
                                              ).ToList();
                    }

                    if (!string.IsNullOrEmpty(QTNCode) &&
                       !string.IsNullOrWhiteSpace(QTNCode))
                    {
                        data = data.Where(p => p.FF_QTN001_CODE.ToString().ToLower().Contains(QTNCode.ToLower())
                                              ).ToList();
                    }
                    if (!string.IsNullOrEmpty(BookCode) &&
                      !string.IsNullOrWhiteSpace(BookCode))
                    {
                        data = data.Where(p => p.FF_BOK001_CODE.ToString().ToLower().Contains(BookCode.ToLower())
                                              ).ToList();
                    }
                    if (!string.IsNullOrEmpty(BILLTO) &&
                     !string.IsNullOrWhiteSpace(BILLTO))
                    {
                        data = data.Where(p => p.BILL_TO.ToString().ToLower().Contains(BILLTO.ToLower())
                                              ).ToList();
                    }
                    if (!string.IsNullOrEmpty(SHIPPER) &&
                     !string.IsNullOrWhiteSpace(SHIPPER))
                    {
                        data = data.Where(p => p.SHIPPER.ToString().ToLower().Contains(SHIPPER.ToLower())
                                              ).ToList();
                    }
                    if (!string.IsNullOrEmpty(CONSIGNEE) &&
                   !string.IsNullOrWhiteSpace(CONSIGNEE))
                    {
                        data = data.Where(p => p.CONSIGNEE.ToString().ToLower().Contains(CONSIGNEE.ToLower())
                                              ).ToList();
                    }

                    if (!string.IsNullOrEmpty(FORWARDER) &&
                  !string.IsNullOrWhiteSpace(FORWARDER))
                    {
                        data = data.Where(p => p.FORWARDER.ToString().ToLower().Contains(FORWARDER.ToLower())
                                              ).ToList();
                    }
                    if (!string.IsNullOrEmpty(PICKUP_PLACE) &&
                 !string.IsNullOrWhiteSpace(PICKUP_PLACE))
                    {
                        data = data.Where(p => p.PICKUP_PLACE.ToString().ToLower().Contains(PICKUP_PLACE.ToLower())
                                              ).ToList();
                    }
                    if (!string.IsNullOrEmpty(POL) &&
                !string.IsNullOrWhiteSpace(POL))
                    {
                        data = data.Where(p => p.POL.ToString().ToLower().Contains(POL.ToLower())
                                              ).ToList();
                    }
                    if (!string.IsNullOrEmpty(POD) &&
                !string.IsNullOrWhiteSpace(POD))
                    {
                        data = data.Where(p => p.POD.ToString().ToLower().Contains(POD.ToLower())
                                              ).ToList();
                    }
                    if (!string.IsNullOrEmpty(FND) &&
               !string.IsNullOrWhiteSpace(FND))
                    {
                        data = data.Where(p => p.FND.ToString().ToLower().Contains(FND.ToLower())
                                              ).ToList();
                    }
                    if (!string.IsNullOrEmpty(PLACEOFRCPT) &&
             !string.IsNullOrWhiteSpace(PLACEOFRCPT))
                    {
                        data = data.Where(p => p.PLACE_OF_RCPT.ToString().ToLower().Contains(PLACEOFRCPT.ToLower())
                                              ).ToList();
                    }
                    if (!string.IsNullOrEmpty(MOVETYPE) &&
           !string.IsNullOrWhiteSpace(MOVETYPE))
                    {
                        data = data.Where(p => p.MOVE_TYPE.ToString().ToLower().Contains(MOVETYPE.ToLower())
                                              ).ToList();
                    }
                    if (!string.IsNullOrEmpty(DELIVERYAT) &&
           !string.IsNullOrWhiteSpace(DELIVERYAT))
                    {
                        data = data.Where(p => p.DELIVERY_AT.ToString().ToLower().Contains(DELIVERYAT.ToLower())
                                              ).ToList();
                    }
                    if (!string.IsNullOrEmpty(REFNo) &&
          !string.IsNullOrWhiteSpace(REFNo))
                    {
                        data = data.Where(p => p.REF_NO.ToString().ToLower().Contains(REFNo.ToLower())
                                              ).ToList();
                    }
                    if (!string.IsNullOrEmpty(Vessal) &&
          !string.IsNullOrWhiteSpace(Vessal))
                    {
                        data = data.Where(p => p.VESSEL.ToString().ToLower().Contains(Vessal.ToLower())
                                              ).ToList();
                    }
                    if (!string.IsNullOrEmpty(Voyage) &&
         !string.IsNullOrWhiteSpace(Voyage))
                    {
                        data = data.Where(p => p.VOYAGE.ToString().ToLower().Contains(Voyage.ToLower())
                                              ).ToList();
                    }
                    if (!string.IsNullOrEmpty(ETD) &&
       !string.IsNullOrWhiteSpace(ETD))
                    {
                        data = data.Where(p => Convert.ToDateTime(p.ETD).ToString("dd-MM-yyyy").ToLower().Contains(ETD.ToLower())
                                              ).ToList();
                    }
                    if (!string.IsNullOrEmpty(ETA) &&
       !string.IsNullOrWhiteSpace(ETA))
                    {
                        data = data.Where(p => Convert.ToDateTime(p.ETA).ToString("dd-MM-yyyy").ToLower().Contains(ETA.ToLower())
                                              ).ToList();
                    }
                    if (!string.IsNullOrEmpty(CARRIER) &&
     !string.IsNullOrWhiteSpace(CARRIER))
                    {
                        data = data.Where(p => p.CARRIER.ToString().ToLower().Contains(CARRIER.ToLower())
                                              ).ToList();
                    }
                    if (!string.IsNullOrEmpty(DEPARTMENT) &&
   !string.IsNullOrWhiteSpace(DEPARTMENT))
                    {
                        data = data.Where(p => p.DEPARTMENT.ToString().ToLower().Contains(DEPARTMENT.ToLower())
                                              ).ToList();
                    }
                    if (!string.IsNullOrEmpty(TotalCost) &&
  !string.IsNullOrWhiteSpace(TotalCost))
                    {
                        data = data.Where(p => p.Total_Cost.ToString().ToLower().Contains(TotalCost.ToLower())
                                              ).ToList();
                    }
                    if (!string.IsNullOrEmpty(TotalBilled) &&
 !string.IsNullOrWhiteSpace(TotalBilled))
                    {
                        data = data.Where(p => p.Total_Billed.ToString().ToLower().Contains(TotalBilled.ToLower())
                                              ).ToList();
                    }
                    if (!string.IsNullOrEmpty(TotalProfit) &&
 !string.IsNullOrWhiteSpace(TotalProfit))
                    {
                        data = data.Where(p => p.Total_Profit.ToString().ToLower().Contains(TotalProfit.ToLower())
                                              ).ToList();
                    }
                    // Sorting.
                    data = this.BLColumnWithOrder(order, orderDir, data);

                    // Filter record count.
                    int recFilter = data.Count;


                    if (pageSize != -1)
                    {
                        data = data.Skip(startRec).Take(pageSize).ToList();
                    }
                    else
                    {
                        data = data.ToList();
                    }

                    // Loading drop down lists.
                    result = this.Json(new { draw = Convert.ToInt32(draw), recordsTotal = totalRecords, recordsFiltered = recFilter, data = data }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                // Info
                Console.Write(ex);
            }

            // Return info.
            return result;
        }

        private List<FF_BL_VM> BLColumnWithOrder(string order, string orderDir, List<FF_BL_VM> data)
        {
            // Initialization.
            List<FF_BL_VM> lst = new List<FF_BL_VM>();
            try
            {
                // Sorting
                switch (order)
                {
                    case "0":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.FF_BL001_CODE).ToList()
                                                                                                 : data.OrderBy(p => p.FF_BL001_CODE).ToList();
                        break;

                    case "1":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.FF_BL001_DATE).ToList()
                                                                                                 : data.OrderBy(p => p.FF_BL001_DATE).ToList();
                        break;

                    case "2":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.FF_QTN001_CODE).ToList()
                                                                                                : data.OrderBy(p => p.FF_QTN001_CODE).ToList();
                        break;

                    case "3":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.FF_BOK001_CODE).ToList()
                                                                                                : data.OrderBy(p => p.FF_BOK001_CODE).ToList();
                        break;

                    case "4":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.BILL_TO).ToList()
                                                                                                  : data.OrderBy(p => p.BILL_TO).ToList();
                        break;
                    case "5":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.SHIPPER).ToList()
                                                                                                  : data.OrderBy(p => p.SHIPPER).ToList();
                        break;
                    case "6":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.CONSIGNEE).ToList()
                                                                                                  : data.OrderBy(p => p.CONSIGNEE).ToList();
                        break;

                    case "7":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.FORWARDER).ToList()
                                                                                                  : data.OrderBy(p => p.FORWARDER).ToList();
                        break;

                    case "8":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.PICKUP_PLACE).ToList()
                                                                                                  : data.OrderBy(p => p.PICKUP_PLACE).ToList();
                        break;
                    case "9":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.POL).ToList()
                                                                                                  : data.OrderBy(p => p.POL).ToList();
                        break;
                    case "10":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.POD).ToList()
                                                                                                  : data.OrderBy(p => p.POD).ToList();
                        break;
                    case "11":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.FND).ToList()
                                                                                                  : data.OrderBy(p => p.FND).ToList();
                        break;
                    case "12":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.PLACE_OF_RCPT).ToList()
                                                                                                  : data.OrderBy(p => p.PLACE_OF_RCPT).ToList();
                        break;
                    case "13":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.MOVE_TYPE).ToList()
                                                                                                  : data.OrderBy(p => p.MOVE_TYPE).ToList();
                        break;
                    case "14":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.DELIVERY_AT).ToList()
                                                                                                  : data.OrderBy(p => p.DELIVERY_AT).ToList();
                        break;
                    case "15":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.REF_NO).ToList()
                                                                                                  : data.OrderBy(p => p.REF_NO).ToList();
                        break;
                    case "16":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.VESSEL).ToList()
                                                                                                  : data.OrderBy(p => p.VESSEL).ToList();
                        break;
                    case "17":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.VOYAGE).ToList()
                                                                                                  : data.OrderBy(p => p.VOYAGE).ToList();
                        break;
                    case "18":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.ETD).ToList()
                                                                                                  : data.OrderBy(p => p.ETD).ToList();
                        break;
                    case "19":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.ETA).ToList()
                                                                                                  : data.OrderBy(p => p.ETA).ToList();
                        break;
                    case "20":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.CARRIER).ToList()
                                                                                                  : data.OrderBy(p => p.CARRIER).ToList();
                        break;
                    case "21":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.DEPARTMENT).ToList()
                                                                                                  : data.OrderBy(p => p.DEPARTMENT).ToList();
                        break;

                    case "22":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Total_Cost).ToList()
                                                                                                  : data.OrderBy(p => p.Total_Cost).ToList();
                        break;
                    case "23":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Total_Billed).ToList()
                                                                                                  : data.OrderBy(p => p.Total_Billed).ToList();
                        break;                    

                    default:
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Total_Profit).ToList()
                                                                                                 : data.OrderBy(p => p.Total_Profit).ToList();
                        break;

                }
            }
            catch (Exception ex)
            {
                // info.
                Console.Write(ex);
            }

            // info.
            return lst;

        }
        [Route("SaveFFM_BL")]
        public ActionResult saveFFM_BL(FF_BL_VM FBV)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                FBV.CMPYCODE = list[0].CmpyCode;
                FBV.UserName = list[0].user_name;
                return Json(_BLService.SaveFF_BL_VM(FBV), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetVESSELCodeList(string VESSEL)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_BLService.GetVOYAGEList(list[0].CmpyCode, VESSEL), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetCurRate(string CurCode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_BLService.GetCurRate(list[0].CmpyCode, CurCode), JsonRequestBehavior.AllowGet);
            }
        }

        [Route("BLFF_BOKDetails")]
        public ActionResult FF_BOKDetailsBL(string FF_BOK001_CODE1)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_BLService.GetFF_BLDetailsBk(list[0].CmpyCode, FF_BOK001_CODE1, list[0].BraCode));
            }
        }

        public ActionResult GetBillCustomerData(string Custcode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_BLService.GetBOOKCODEbycusto(list[0].CmpyCode, Custcode, System.DateTime.Now, list[0].BraCode), JsonRequestBehavior.AllowGet);
            }
        }
    }
}