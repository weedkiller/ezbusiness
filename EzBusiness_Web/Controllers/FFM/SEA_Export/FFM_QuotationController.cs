using EzBusiness_BL_Service.FreightManagementBLS.SEA_Export;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.FreightManagement;
using EzBusiness_ViewModels.Models.FreightManagement.SEA_Export;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EzBusiness_Web.Controllers.FFM.SEA_Export
{
    public class FFM_QuotationController : Controller
    {
        // GET: FFM_Quotation

       FF_QTNService _QTNService;

        public FFM_QuotationController()
        {
            _QTNService = new FF_QTNService();
        }

        [Route("Quotation")]
        public ActionResult FFM_Quotation()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return View();
            }
        }



        [Route("DeleteQuotation")]
        public ActionResult DeleteFF_QTN(string FF_QTN001_CODE)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { DeleteFlag = _QTNService.DeleteFF_QTN(FF_QTN001_CODE, list[0].CmpyCode, list[0].user_name, list[0].BraCode) }, JsonRequestBehavior.AllowGet);
            }
        }

        [Route("Aprrove_QTN")]
        public ActionResult Aprrove_QTN(string FF_QTN001_CODE,string Typ)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { StatusFlag = _QTNService.Aprrove_QTN(list[0].CmpyCode,FF_QTN001_CODE, list[0].user_name, Typ, list[0].BraCode, "FF_QTN001") }, JsonRequestBehavior.AllowGet);
            }
        }
        [Route("EditFF_QTNDetails")]
        public ActionResult FF_QTNDetailsEdit(string FF_QTN001_CODE)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_QTNService.GetFF_QTNDetailsEdit(list[0].CmpyCode, FF_QTN001_CODE,list[0].BraCode));
            }
        }

        [Route("AddFF_QTNDetails")]
        public ActionResult AddFF_QTNDetails()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_QTNService.GetFF_QTN_AddNew(list[0].CmpyCode, list[0].BraCode));
            }
        }

        public ActionResult GetFF_QTN002DetailList()
        {
            //List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            //if (list == null)
            //{
            //    return Redirect("Login/InLogin");
            //}
            //else
            //{

            //    return PartialView(_QTNService.GetFF_QTN(list[0].CmpyCode,list[0].BraCode));
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

                    string FF_QTN001_CODE1 = Request.Form.GetValues("columns[0][search][value]").FirstOrDefault();
                    string CUST_CODE1 = Request.Form.GetValues("columns[1][search][value]").FirstOrDefault();
                    string CONTACT1 = Request.Form.GetValues("columns[2][search][value]").FirstOrDefault();
                    string TELEPHONE1 = Request.Form.GetValues("columns[3][search][value]").FirstOrDefault();
                    string EMAIL1 = Request.Form.GetValues("columns[4][search][value]").FirstOrDefault();
                    string CUSTOMER_REF1 = Request.Form.GetValues("columns[5][search][value]").FirstOrDefault();
                    string PICKUP_PLACE1 = Request.Form.GetValues("columns[6][search][value]").FirstOrDefault();
                    string POL1 = Request.Form.GetValues("columns[7][search][value]").FirstOrDefault();
                    string POD1 = Request.Form.GetValues("columns[8][search][value]").FirstOrDefault();
                    string FND1 = Request.Form.GetValues("columns[9][search][value]").FirstOrDefault();
                    string MOVE_TYPE1 = Request.Form.GetValues("columns[10][search][value]").FirstOrDefault();
                    string REF_NO1 = Request.Form.GetValues("columns[11][search][value]").FirstOrDefault();
                    string VESSEL1 = Request.Form.GetValues("columns[12][search][value]").FirstOrDefault();
                    string VOYAGE1 = Request.Form.GetValues("columns[13][search][value]").FirstOrDefault();


                    if (pageSize == -1)
                    {
                        draw = "2";
                    }

                    List<FF_QTN_VM> data = _QTNService.GetFF_QTN(list[0].CmpyCode, list[0].BraCode);
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
                        data = data.Where(p => p.FF_QTN001_CODE.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.CUST_CODE.ToLower().Contains(search.ToLower()) ||
                                               p.CONTACT.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.TELEPHONE.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.EMAIL.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.CUSTOMER_REF.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.PICKUP_PLACE.ToString().ToLower().Contains(search.ToLower()) ||
                                                p.POL.ToLower().Contains(search.ToLower()) ||
                                               p.POD.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.FND.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.MOVE_TYPE.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.REF_NO.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.VESSEL.ToString().ToLower().Contains(search.ToLower()) ||
                                                  p.VOYAGE.ToString().ToLower().Contains(search.ToLower()) 
                                              ).ToList();

                    }

                    if (!string.IsNullOrEmpty(FF_QTN001_CODE1) &&
                        !string.IsNullOrWhiteSpace(FF_QTN001_CODE1))
                    {
                        data = data.Where(p => p.FF_QTN001_CODE.ToString().ToLower().Contains(FF_QTN001_CODE1.ToLower())
                                              ).ToList();
                    }

                    if (!string.IsNullOrEmpty(CUST_CODE1) &&
                       !string.IsNullOrWhiteSpace(CUST_CODE1))
                    {
                        data = data.Where(p => p.CUST_CODE.ToString().ToLower().Contains(CUST_CODE1.ToLower())
                                              ).ToList();
                    }

                    if (!string.IsNullOrEmpty(CONTACT1) &&
                       !string.IsNullOrWhiteSpace(CONTACT1))
                    {
                        data = data.Where(p => p.CONTACT.ToString().ToLower().Contains(CONTACT1.ToLower())
                                              ).ToList();
                    }
                    if (!string.IsNullOrEmpty(TELEPHONE1) &&
                      !string.IsNullOrWhiteSpace(TELEPHONE1))
                    {
                        data = data.Where(p => p.TELEPHONE.ToString().ToLower().Contains(TELEPHONE1.ToLower())
                                              ).ToList();
                    }
                    if (!string.IsNullOrEmpty(EMAIL1) &&
                     !string.IsNullOrWhiteSpace(EMAIL1))
                    {
                        data = data.Where(p => p.EMAIL.ToString().ToLower().Contains(EMAIL1.ToLower())
                                              ).ToList();
                    }
                    if (!string.IsNullOrEmpty(CUSTOMER_REF1) &&
                     !string.IsNullOrWhiteSpace(CUSTOMER_REF1))
                    {
                        data = data.Where(p => p.CUSTOMER_REF.ToString().ToLower().Contains(CUSTOMER_REF1.ToLower())
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


                    if (!string.IsNullOrEmpty(MOVE_TYPE1) &&
                 !string.IsNullOrWhiteSpace(MOVE_TYPE1))
                    {
                        data = data.Where(p => p.MOVE_TYPE.ToString().ToLower().Contains(MOVE_TYPE1.ToLower())
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

        private List<FF_QTN_VM> salaryprocessColumnWithOrder(string order, string orderDir, List<FF_QTN_VM> data)
        {
            // Initialization.
            List<FF_QTN_VM> lst = new List<FF_QTN_VM>();
            try
            {
                // Sorting
                switch (order)
                {
                    case "0":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.FF_QTN001_CODE).ToList()
                                                                                                 : data.OrderBy(p => p.FF_QTN001_CODE).ToList();
                        break;

                    case "1":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.CUST_CODE).ToList()
                                                                                                 : data.OrderBy(p => p.CUST_CODE).ToList();
                        break;

                    case "2":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.CONTACT).ToList()
                                                                                                 : data.OrderBy(p => p.CONTACT).ToList();
                        break;

                    case "3":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.TELEPHONE).ToList()
                                                                                                 : data.OrderBy(p => p.TELEPHONE).ToList();
                        break;

                    case "4":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.EMAIL).ToList()
                                                                                                   : data.OrderBy(p => p.EMAIL).ToList();
                        break;
                    case "5":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.CUSTOMER_REF).ToList()
                                                                                                   : data.OrderBy(p => p.CUSTOMER_REF).ToList();
                        break;

                    case "6":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.PICKUP_PLACE).ToList()
                                                                                                   : data.OrderBy(p => p.PICKUP_PLACE).ToList();
                        break;

                    case "7":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.POL).ToList()
                                                                                                   : data.OrderBy(p => p.POL).ToList();
                        break;
                    case "8":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.POD).ToList()
                                                                                                   : data.OrderBy(p => p.POD).ToList();
                        break;
                    case "9":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.FND).ToList()
                                                                                                   : data.OrderBy(p => p.FND).ToList();
                        break;
                    case "10":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.MOVE_TYPE).ToList()
                                                                                                   : data.OrderBy(p => p.MOVE_TYPE).ToList();
                        break;
                    case "11":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.REF_NO).ToList()
                                                                                                   : data.OrderBy(p => p.REF_NO).ToList();
                        break;
                    case "12":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.VESSEL).ToList()
                                                                                                   : data.OrderBy(p => p.VESSEL).ToList();
                        break;


                    default:
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.VOYAGE).ToList()
                                                                                                 : data.OrderBy(p => p.VOYAGE).ToList();
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
        [Route("SaveFFM_Quotation")]
        public ActionResult saveFFM_CLAUSE(FF_QTN_VM FQV)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                FQV.CMPYCODE = list[0].CmpyCode;
                FQV.UserName = list[0].user_name;
                return Json(_QTNService.SaveFF_QTN_VM(FQV), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetVESSELCodeList(string VESSEL,string Prefix)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_QTNService.GetVOYAGEList(list[0].CmpyCode, VESSEL, Prefix), JsonRequestBehavior.AllowGet);
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
                return Json(_QTNService.GetCurRate(list[0].CmpyCode, CurCode), JsonRequestBehavior.AllowGet);
            }
        }

        //public ActionResult GetApproveRej(string FF_QTN001_CODE)
        //{
        //    List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
        //    if (list == null)
        //    {
        //        return Redirect("Login/InLogin");
        //    }
        //    else
        //    {
        //        return Json(_QTNService.GetApproveRej(list[0].CmpyCode, list[0].BraCode,FF_QTN001_CODE), JsonRequestBehavior.AllowGet);
        //    }
        //}

        //
        public ActionResult GetCust(string Prefix)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_QTNService.GetCust(list[0].CmpyCode, list[0].BraCode, Prefix), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetCustT(string Prefix)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_QTNService.GetCustT(list[0].CmpyCode, list[0].BraCode, Prefix), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetCurcode(string Prefix)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_QTNService.GetCurcode(list[0].CmpyCode, Prefix), JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetCurcodeList(string Prefix)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_QTNService.GetCurcodeList(list[0].CmpyCode, Prefix), JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetUnitcode(string Prefix)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_QTNService.GetUnitcode(list[0].CmpyCode, Prefix), JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetVendor(string Prefix)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_QTNService.GetVendor(list[0].CmpyCode, list[0].BraCode, Prefix), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetCLAUSE(string Prefix)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_QTNService.GetCLAUSE(list[0].CmpyCode, Prefix), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetCRG_002(string Prefix)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_QTNService.GetCRG_002(list[0].CmpyCode, Prefix), JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetDepart(string Prefix)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_QTNService.GetDepart(list[0].CmpyCode, Prefix), JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetMoveCode(string Prefix)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_QTNService.GetMoveCode(list[0].CmpyCode, Prefix), JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetVESSELList(string Prefix)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_QTNService.GetVESSELList(list[0].CmpyCode, Prefix), JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetPortList(string Prefix)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_QTNService.GetPortList(list[0].CmpyCode, Prefix), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetContTyp(string Prefix)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_QTNService.GetContTyp(list[0].CmpyCode, Prefix), JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetCommodityistList(string Prefix)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_QTNService.GetCommodityistList(list[0].CmpyCode, Prefix), JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetCommodityistListT(string Prefix)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_QTNService.GetCommodityistListT(list[0].CmpyCode, Prefix), JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetSLList(string Prefix)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_QTNService.GetSL(list[0].CmpyCode, Prefix), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetBranchList(string Prefix)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_QTNService.GetBranchListN(list[0].CmpyCode, Prefix), JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult GetCurCodebranch()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_QTNService.GetCurCodebranch(list[0].CmpyCode, list[0].BraCode), JsonRequestBehavior.AllowGet);
            }
        }

        [Route("FF_QuotCopy")]
        public ActionResult FF_QuotCopy(string FF_QTN001_CODE)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_QTNService.GetFF_QuotCopy(list[0].CmpyCode, FF_QTN001_CODE, list[0].BraCode));
            }
        }

    }
}