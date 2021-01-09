using EzBusiness_BL_Service.FreightManagementBLS.SEA_Export;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.FreightManagement.SEA_Export;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EzBusiness_Web.Controllers.FFM.SEA_Export
{
    public class FF_BOKController : Controller
    {
        // GET: FFM_BOK

        FF_BOKService _BOKService;

        public FF_BOKController()
        {
            _BOKService = new FF_BOKService();
        }


        [Route("Aprrove_BOK")]
        public ActionResult Aprrove_QTN(string FF_BOK001_CODE, string Typ)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { StatusFlag = _BOKService.Aprrove_QTN(list[0].CmpyCode, FF_BOK001_CODE, list[0].user_name, Typ, list[0].BraCode, "FF_BOK001") }, JsonRequestBehavior.AllowGet);
            }
        }

        [Route("BOOKING")]
        public ActionResult FF_BOK()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return View(_BOKService.GetFF_BOK_AddNew(list[0].CmpyCode, list[0].BraCode));
            }
        }



        [Route("DeleteBOK")]
        public ActionResult DeleteFF_BOK(string FF_BOK001_CODE)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { DeleteFlag = _BOKService.DeleteFF_BOK(FF_BOK001_CODE, list[0].CmpyCode, list[0].user_name, list[0].BraCode) }, JsonRequestBehavior.AllowGet);
            }
        }
        [Route("EditFF_BOKDetails")]
        public ActionResult FF_BOKDetailsEdit(string FF_BOK001_CODE)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_BOKService.GetFF_BOKDetailsEdit(list[0].CmpyCode, FF_BOK001_CODE,list[0].BraCode));
            }
        }

        [Route("QuotFF_BOKDetails")]
        public ActionResult FF_BOKDetailsQuot(string FF_BOK001_CODE1)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_BOKService.GetFF_BOKDetailsQuot(list[0].CmpyCode, FF_BOK001_CODE1,list[0].BraCode));
            }
        }

        [Route("AddFF_BOKDetails")]
        public ActionResult AddFF_BOKDetails()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_BOKService.GetFF_BOK_AddNew(list[0].CmpyCode, list[0].BraCode));
            }
        }

        public  ActionResult GetBill_No_Data()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_BOKService.GetPortList(list[0].CmpyCode), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetFF_BOK002DetailList()
        {
            //List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            //if (list == null)
            //{
            //    return Redirect("Login/InLogin");
            //}
            //else
            //{

            //    return PartialView(_BOKService.GetFF_BOK(list[0].CmpyCode,list[0].BraCode));
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

                    string FF_BOK001_CODE1 = Request.Form.GetValues("columns[0][search][value]").FirstOrDefault();
                    string FF_BOK001_DATE1 = Request.Form.GetValues("columns[1][search][value]").FirstOrDefault();
                    string FF_QTN001_CODE1 = Request.Form.GetValues("columns[2][search][value]").FirstOrDefault();
                    string BILL_TO1 = Request.Form.GetValues("columns[3][search][value]").FirstOrDefault();
                    string SHIPPER1 = Request.Form.GetValues("columns[4][search][value]").FirstOrDefault();
                    string CONSIGNEE1 = Request.Form.GetValues("columns[5][search][value]").FirstOrDefault();
                    string FORWARDER1 = Request.Form.GetValues("columns[6][search][value]").FirstOrDefault();
                    string PICKUP_PLACE1 = Request.Form.GetValues("columns[7][search][value]").FirstOrDefault();
                    string POL1 = Request.Form.GetValues("columns[8][search][value]").FirstOrDefault();
                    string POD1 = Request.Form.GetValues("columns[9][search][value]").FirstOrDefault();
                    string FND1 = Request.Form.GetValues("columns[10][search][value]").FirstOrDefault();
                    string PLACE_OF_RCPT1 = Request.Form.GetValues("columns[11][search][value]").FirstOrDefault();
                    string MOVE_TYPE1 = Request.Form.GetValues("columns[12][search][value]").FirstOrDefault();
                    string DELIVERY_AT1 = Request.Form.GetValues("columns[13][search][value]").FirstOrDefault();
                    string REF_NO1 = Request.Form.GetValues("columns[14][search][value]").FirstOrDefault();
                    string VESSEL1 = Request.Form.GetValues("columns[15][search][value]").FirstOrDefault();
                    string VOYAGE1 = Request.Form.GetValues("columns[16][search][value]").FirstOrDefault();
                    string ETD1 = Request.Form.GetValues("columns[17][search][value]").FirstOrDefault();
                    string ETA1 = Request.Form.GetValues("columns[18][search][value]").FirstOrDefault();
                    string CARRIER1 = Request.Form.GetValues("columns[19][search][value]").FirstOrDefault();
                    string DEPARTMENT1 = Request.Form.GetValues("columns[20][search][value]").FirstOrDefault();
                    string Total_Cost1 = Request.Form.GetValues("columns[21][search][value]").FirstOrDefault();
                    string Total_Billed1 = Request.Form.GetValues("columns[22][search][value]").FirstOrDefault();
                    string Total_Profit1 = Request.Form.GetValues("columns[23][search][value]").FirstOrDefault();


                    if (pageSize == -1)
                    {
                        draw = "2";
                    }

                    List<FF_BOK_VM> data = _BOKService.GetFF_BOK(list[0].CmpyCode, list[0].BraCode);
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
                        data = data.Where(p => p.FF_BOK001_CODE.ToString().ToLower().Contains(search.ToLower()) ||
                                              Convert.ToDateTime(p.FF_BOK001_DATE).ToString("dd-MM-yyyy").ToLower().Contains(search.ToLower()) ||
                                               p.FF_QTN001_CODE.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.BILL_TO.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.SHIPPER.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.CONSIGNEE.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.FORWARDER.ToString().ToLower().Contains(search.ToLower()) ||
                                                p.PICKUP_PLACE.ToLower().Contains(search.ToLower()) ||
                                               p.POL.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.POD.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.FND.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.PLACE_OF_RCPT.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.MOVE_TYPE.ToString().ToLower().Contains(search.ToLower()) ||
                                                  p.DELIVERY_AT.ToString().ToLower().Contains(search.ToLower())||
                                                  p.REF_NO.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.VESSEL.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.VOYAGE.ToString().ToLower().Contains(search.ToLower()) ||
                                                Convert.ToDateTime(p.ETA).ToString("dd-MM-yyyy").ToLower().Contains(search.ToLower()) ||
                                               Convert.ToDateTime(p.ETD).ToString("dd-MM-yyyy").ToLower().Contains(search.ToLower()) ||
                                                  p.CARRIER.ToString().ToLower().Contains(search.ToLower())||
                                                    p.DEPARTMENT.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.Total_Cost.ToString().ToLower().Contains(search.ToLower()) ||
                                                  p.Total_Billed.ToString().ToLower().Contains(search.ToLower())||
                                                   p.Total_Profit.ToString().ToLower().Contains(search.ToLower())

                                              ).ToList();

                    }

                    if (!string.IsNullOrEmpty(FF_BOK001_CODE1) &&
                        !string.IsNullOrWhiteSpace(FF_BOK001_CODE1))
                    {
                        data = data.Where(p => p.FF_BOK001_CODE.ToString().ToLower().Contains(FF_BOK001_CODE1.ToLower())
                                              ).ToList();
                    }

                    if (!string.IsNullOrEmpty(FF_BOK001_DATE1) &&
                       !string.IsNullOrWhiteSpace(FF_BOK001_DATE1))
                    {
                        data = data.Where(p => Convert.ToDateTime(p.FF_BOK001_DATE).ToString("dd-MM-yyyy").ToLower().Contains(FF_BOK001_DATE1.ToLower())
                                              ).ToList();
                    }

                    if (!string.IsNullOrEmpty(FF_QTN001_CODE1) &&
                       !string.IsNullOrWhiteSpace(FF_QTN001_CODE1))
                    {
                        data = data.Where(p => p.FF_QTN001_CODE.ToString().ToLower().Contains(FF_QTN001_CODE1.ToLower())
                                              ).ToList();
                    }
                    if (!string.IsNullOrEmpty(BILL_TO1) &&
                      !string.IsNullOrWhiteSpace(BILL_TO1))
                    {
                        data = data.Where(p => p.BILL_TO.ToString().ToLower().Contains(BILL_TO1.ToLower())
                                              ).ToList();
                    }
                    if (!string.IsNullOrEmpty(SHIPPER1) &&
                     !string.IsNullOrWhiteSpace(SHIPPER1))
                    {
                        data = data.Where(p => p.SHIPPER.ToString().ToLower().Contains(SHIPPER1.ToLower())
                                              ).ToList();
                    }
                    if (!string.IsNullOrEmpty(CONSIGNEE1) &&
                     !string.IsNullOrWhiteSpace(CONSIGNEE1))
                    {
                        data = data.Where(p => p.CONSIGNEE.ToString().ToLower().Contains(CONSIGNEE1.ToLower())
                                              ).ToList();
                    }
                    if (!string.IsNullOrEmpty(FORWARDER1) &&
                   !string.IsNullOrWhiteSpace(FORWARDER1))
                    {
                        data = data.Where(p => p.FORWARDER.ToString().ToLower().Contains(FORWARDER1.ToLower())
                                              ).ToList();
                    }

                    if (!string.IsNullOrEmpty(PICKUP_PLACE1) &&
                   !string.IsNullOrWhiteSpace(PICKUP_PLACE1))
                    {
                        data = data.Where(p => p.PICKUP_PLACE.ToString().ToLower().Contains(PICKUP_PLACE1.ToLower())
                                              ).ToList();
                    }

                    if (!string.IsNullOrEmpty(POL1) &&
                  !string.IsNullOrWhiteSpace(POL1))
                    {
                        data = data.Where(p => p.POL.ToString().ToLower().Contains(POL1.ToLower())
                                              ).ToList();
                    }

                    if (!string.IsNullOrEmpty(POD1) &&
                 !string.IsNullOrWhiteSpace(POD1))
                    {
                        data = data.Where(p => p.POD.ToString().ToLower().Contains(POD1.ToLower())
                                              ).ToList();
                    }


                    if (!string.IsNullOrEmpty(FND1) &&
                 !string.IsNullOrWhiteSpace(FND1))
                    {
                        data = data.Where(p => p.FND.ToString().ToLower().Contains(FND1.ToLower())
                                              ).ToList();
                    }

                    if (!string.IsNullOrEmpty(PLACE_OF_RCPT1) &&
               !string.IsNullOrWhiteSpace(PLACE_OF_RCPT1))
                    {
                        data = data.Where(p => p.PLACE_OF_RCPT.ToString().ToLower().Contains(PLACE_OF_RCPT1.ToLower())
                                              ).ToList();
                    }



                    if (!string.IsNullOrEmpty(MOVE_TYPE1) &&
               !string.IsNullOrWhiteSpace(MOVE_TYPE1))
                    {
                        data = data.Where(p => p.MOVE_TYPE.ToString().ToLower().Contains(MOVE_TYPE1.ToLower())
                                              ).ToList();
                    }
                    if (!string.IsNullOrEmpty(DELIVERY_AT1) &&
                    !string.IsNullOrWhiteSpace(DELIVERY_AT1))
                    {
                        data = data.Where(p => p.DELIVERY_AT.ToString().ToLower().Contains(DELIVERY_AT1.ToLower())
                                              ).ToList();
                    }


                    if (!string.IsNullOrEmpty(REF_NO1) &&
                   !string.IsNullOrWhiteSpace(REF_NO1))
                    {
                        data = data.Where(p => p.REF_NO.ToString().ToLower().Contains(REF_NO1.ToLower())
                                              ).ToList();
                    }

                    if (!string.IsNullOrEmpty(VESSEL1) &&
                   !string.IsNullOrWhiteSpace(VESSEL1))
                    {
                        data = data.Where(p => p.VESSEL.ToString().ToLower().Contains(VESSEL1.ToLower())
                                              ).ToList();
                    }

                    if (!string.IsNullOrEmpty(VOYAGE1) &&
                   !string.IsNullOrWhiteSpace(VOYAGE1))
                    {
                        data = data.Where(p => p.VOYAGE.ToString().ToLower().Contains(VOYAGE1.ToLower())
                                              ).ToList();
                    }
                    if (!string.IsNullOrEmpty(ETD1) &&
                   !string.IsNullOrWhiteSpace(ETD1))
                    {
                        data = data.Where(p=>Convert.ToDateTime(p.ETD).ToString("dd-MM-yyyy").ToLower().Contains(ETD1.ToLower())
                                              ).ToList();
                    }
                    if (!string.IsNullOrEmpty(ETA1) &&
                   !string.IsNullOrWhiteSpace(ETA1))
                    {
                        data = data.Where(p => Convert.ToDateTime(p.ETA).ToString("dd-MM-yyyy").ToLower().Contains(ETA1.ToLower())
                                              ).ToList();
                    }
                    if (!string.IsNullOrEmpty(CARRIER1) &&
                   !string.IsNullOrWhiteSpace(CARRIER1))
                    {
                        data = data.Where(p => p.CARRIER.ToString().ToLower().Contains(CARRIER1.ToLower())
                                              ).ToList();
                    }
                    if (!string.IsNullOrEmpty(DEPARTMENT1) &&
                   !string.IsNullOrWhiteSpace(DEPARTMENT1))
                    {
                        data = data.Where(p => p.DEPARTMENT.ToString().ToLower().Contains(DEPARTMENT1.ToLower())
                                              ).ToList();
                    }
                    if (!string.IsNullOrEmpty(Total_Cost1) &&
                   !string.IsNullOrWhiteSpace(Total_Cost1))
                    {
                        data = data.Where(p => p.Total_Cost.ToString().ToLower().Contains(Total_Cost1.ToLower())
                                              ).ToList();
                    }
                    if (!string.IsNullOrEmpty(Total_Billed1) &&
                   !string.IsNullOrWhiteSpace(Total_Billed1))
                    {
                        data = data.Where(p => p.Total_Billed.ToString().ToLower().Contains(Total_Billed1.ToLower())
                                              ).ToList();
                    }
                    if (!string.IsNullOrEmpty(Total_Profit1) &&
                   !string.IsNullOrWhiteSpace(Total_Profit1))
                    {
                        data = data.Where(p => p.Total_Profit.ToString().ToLower().Contains(Total_Profit1.ToLower())
                                              ).ToList();
                    }

                    // Sorting.
                    data = this.salaryprocessColumnWithOrder(order, orderDir, data);

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

        private List<FF_BOK_VM> salaryprocessColumnWithOrder(string order, string orderDir, List<FF_BOK_VM> data)
        {
            // Initialization.
            List<FF_BOK_VM> lst = new List<FF_BOK_VM>();
            try
            {
                // Sorting
                switch (order)
                {
                    case "0":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.FF_BOK001_CODE).ToList()
                                                                                                 : data.OrderBy(p => p.FF_BOK001_CODE).ToList();
                        break;

                    case "1":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.FF_BOK001_DATE).ToList()
                                                                                                 : data.OrderBy(p => p.FF_BOK001_DATE).ToList();
                        break;

                    case "2":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.FF_QTN001_CODE).ToList()
                                                                                                 : data.OrderBy(p => p.FF_QTN001_CODE).ToList();
                        break;

                    case "3":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.BILL_TO).ToList()
                                                                                                 : data.OrderBy(p => p.BILL_TO).ToList();
                        break;

                    case "4":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.SHIPPER).ToList()
                                                                                                   : data.OrderBy(p => p.SHIPPER).ToList();
                        break;
                    case "5":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.CONSIGNEE).ToList()
                                                                                                   : data.OrderBy(p => p.CONSIGNEE).ToList();
                        break;

                    case "6":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.FORWARDER).ToList()
                                                                                                   : data.OrderBy(p => p.FORWARDER).ToList();
                        break;

                    case "7":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.PICKUP_PLACE).ToList()
                                                                                                   : data.OrderBy(p => p.PICKUP_PLACE).ToList();
                        break;
                    case "8":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.POL).ToList()
                                                                                                   : data.OrderBy(p => p.POL).ToList();
                        break;
                    case "9":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.POD).ToList()
                                                                                                   : data.OrderBy(p => p.POD).ToList();
                        break;
                    case "10":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.FND).ToList()
                                                                                                   : data.OrderBy(p => p.FND).ToList();
                        break;
                    case "11":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.PLACE_OF_RCPT).ToList()
                                                                                                   : data.OrderBy(p => p.PLACE_OF_RCPT).ToList();
                        break;
                    case "12":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.MOVE_TYPE).ToList()
                                                                                                   : data.OrderBy(p => p.MOVE_TYPE).ToList();
                        break;

                    case "13":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.DELIVERY_AT).ToList()
                                                                                                   : data.OrderBy(p => p.DELIVERY_AT).ToList();
                        break;
                    case "14":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.REF_NO).ToList()
                                                                                                   : data.OrderBy(p => p.REF_NO).ToList();
                        break;
                    case "15":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.VESSEL).ToList()
                                                                                                   : data.OrderBy(p => p.VESSEL).ToList();
                        break;
                    case "16":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.VOYAGE).ToList()
                                                                                                   : data.OrderBy(p => p.VOYAGE).ToList();
                        break;
                    case "17":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.ETD).ToList()
                                                                                                   : data.OrderBy(p => p.ETD).ToList();
                        break;
                    case "18":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.ETA).ToList()
                                                                                                   : data.OrderBy(p => p.ETA).ToList();
                        break;
                    case "19":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.DEPARTMENT).ToList()
                                                                                                   : data.OrderBy(p => p.DEPARTMENT).ToList();
                        break;
                    case "20":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Total_Cost).ToList()
                                                                                                   : data.OrderBy(p => p.Total_Cost).ToList();
                        break;

                    case "21":
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
        [Route("SaveFFM_BOK")]
        public ActionResult saveFFM_BOK(FF_BOK_VM FBV)
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
                return Json(_BOKService.SaveFF_BOK_VM(FBV), JsonRequestBehavior.AllowGet);
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
                return Json(_BOKService.GetVOYAGEList(list[0].CmpyCode, VESSEL), JsonRequestBehavior.AllowGet);
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
                return Json(_BOKService.GetCurRate(list[0].CmpyCode, CurCode), JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetBookCustomerData(string Custcode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_BOKService.GetQTNCODEbycusto(list[0].CmpyCode, Custcode, System.DateTime.Now, list[0].BraCode), JsonRequestBehavior.AllowGet);
            }
        }
        //public ActionResult GetSLList1(string Prefix)
        //{
        //    List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
        //    if (list == null)
        //    {
        //        return Redirect("Login/InLogin");
        //    }
        //    else
        //    {
        //        return Json(_BOKService.GetSL(list[0].CmpyCode,"FM", Prefix), JsonRequestBehavior.AllowGet);
        //    }
        //}

        //public ActionResult GetSLList2(string Prefix)
        //{
        //    List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
        //    if (list == null)
        //    {
        //        return Redirect("Login/InLogin");
        //    }
        //    else
        //    {
        //        return Json(_BOKService.GetSL(list[0].CmpyCode, "OP", Prefix), JsonRequestBehavior.AllowGet);
        //    }
        //}

        public ActionResult GetQTNCODE()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                DateTime dt = System.DateTime.Now;
                return Json(_BOKService.GetQTNCODE(list[0].CmpyCode, dt), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GETJobTypList(string Prefix)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_BOKService.GETJobTypList(list[0].CmpyCode, Prefix), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetSLNew(string PVal1, string Prefix)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_BOKService.GetSLNew(list[0].CmpyCode,list[0].BraCode, PVal1, Prefix), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetSalesman(string Prefix)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_BOKService.GetSalesman(list[0].CmpyCode, Prefix), JsonRequestBehavior.AllowGet);
            }
        }
       

    }
}