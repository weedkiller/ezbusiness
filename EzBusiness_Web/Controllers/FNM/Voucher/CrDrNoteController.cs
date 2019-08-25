using EzBusiness_BL_Service.FinanceManagementBLS.Vouchers;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.FreightManagement.SEA_Export;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EzBusiness_Web.Controllers.FNM.Voucher
{
    public class CrDrNoteController : Controller
    {
        // GET: CrDrNote


        CreditNoteJobService _CrDrService;

        public CrDrNoteController()
        {
            _CrDrService = new CreditNoteJobService();
        }

        [Route("CreditNote")]
        public ActionResult CreditNote()
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

        [Route("DebitNote")]
        public ActionResult DebitNote()
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

        [Route("DeleteCrDrNote")]
        public ActionResult DeleteCrDrNote(string FNINV001_CODE)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { DeleteFlag = _CrDrService.DeleteFNINV(FNINV001_CODE, list[0].CmpyCode, list[0].user_name, list[0].BraCode) }, JsonRequestBehavior.AllowGet);
            }
        }

        [Route("EditCreditNoteDetails")]
        public ActionResult CreditNoteDetailsEdit(string FNINV001_CODE)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_CrDrService.GetFNINVDetailsEdit(list[0].CmpyCode, FNINV001_CODE, list[0].BraCode));
            }
        }

        [Route("AddCreditNoteDetails")]
        public ActionResult AddCreditNoteDetails()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_CrDrService.GetCredit_AddNew(list[0].CmpyCode, list[0].BraCode));
            }
        }


        [Route("AddDebitNoteDetails")]
        public ActionResult AddDebitNoteDetails()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_CrDrService.GetDebit_AddNew(list[0].CmpyCode, list[0].BraCode));
            }
        }


        [Route("EditDebitNoteDetails")]
        public ActionResult DebitNoteDetailsEdit(string FNINV001_CODE)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_CrDrService.GetFNINVDetailsEdit(list[0].CmpyCode, FNINV001_CODE, list[0].BraCode));
            }
        }

        public ActionResult GetCrDrDetailList(string Module_Type)
        {
            //List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            //if (list == null)
            //{
            //    return Redirect("Login/InLogin");
            //}
            //else
            //{

            //    return PartialView(_CrDrService.GetFNINV(list[0].CmpyCode, list[0].BraCode, Module_Type));
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

                    string FNINV001_CODE1 = Request.Form.GetValues("columns[0][search][value]").FirstOrDefault();
                    string BL_CODE1 = Request.Form.GetValues("columns[1][search][value]").FirstOrDefault();
                    string Invoice_No1 = Request.Form.GetValues("columns[2][search][value]").FirstOrDefault();
                    string vessel_code1 = Request.Form.GetValues("columns[3][search][value]").FirstOrDefault();
                    string SUBLEDGER_CODE1 = Request.Form.GetValues("columns[4][search][value]").FirstOrDefault();
                    string POD1 = Request.Form.GetValues("columns[5][search][value]").FirstOrDefault();
                    string POL1 = Request.Form.GetValues("columns[6][search][value]").FirstOrDefault();
                    string INV_DATE1 = Request.Form.GetValues("columns[7][search][value]").FirstOrDefault();

                    if (pageSize == -1)
                    {
                        draw = "2";
                    }

                    List<FNINV001_VM> data = _CrDrService.GetFNINV(list[0].CmpyCode,list[0].BraCode, Module_Type);
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
                        data = data.Where(p => p.FNINV001_CODE.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.BL_CODE.ToLower().Contains(search.ToLower()) ||
                                               p.Invoice_No.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.vessel_code.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.SUBLEDGER_CODE.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.POD.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.POL.ToString().ToLower().Contains(search.ToLower())||
                                               Convert.ToDateTime(p.INV_DATE).ToString("dd-MM-yyyy").ToLower().Contains(search.ToLower())
                                               
                                              ).ToList();

                    }

                    if (!string.IsNullOrEmpty(FNINV001_CODE1) &&
                        !string.IsNullOrWhiteSpace(FNINV001_CODE1))
                    {
                        data = data.Where(p => p.FNINV001_CODE.ToString().ToLower().Contains(FNINV001_CODE1.ToLower())
                                              ).ToList();
                    }

                    if (!string.IsNullOrEmpty(BL_CODE1) &&
                       !string.IsNullOrWhiteSpace(BL_CODE1))
                    {
                        data = data.Where(p => p.BL_CODE.ToString().ToLower().Contains(BL_CODE1.ToLower())
                                              ).ToList();
                    }

                    if (!string.IsNullOrEmpty(Invoice_No1) &&
                       !string.IsNullOrWhiteSpace(Invoice_No1))
                    {
                        data = data.Where(p => p.Invoice_No.ToString().ToLower().Contains(Invoice_No1.ToLower())
                                              ).ToList();
                    }
                    if (!string.IsNullOrEmpty(vessel_code1) &&
                      !string.IsNullOrWhiteSpace(vessel_code1))
                    {
                        data = data.Where(p => p.vessel_code.ToString().ToLower().Contains(vessel_code1.ToLower())
                                              ).ToList();
                    }
                    if (!string.IsNullOrEmpty(SUBLEDGER_CODE1) &&
                     !string.IsNullOrWhiteSpace(SUBLEDGER_CODE1))
                    {
                        data = data.Where(p => p.SUBLEDGER_CODE.ToString().ToLower().Contains(SUBLEDGER_CODE1.ToLower())
                                              ).ToList();
                    }
                    if (!string.IsNullOrEmpty(POD1) &&
                     !string.IsNullOrWhiteSpace(POD1))
                    {
                        data = data.Where(p => p.POD.ToString().ToLower().Contains(POD1.ToLower())
                                              ).ToList();
                    }
                    if (!string.IsNullOrEmpty(POL1) &&
                   !string.IsNullOrWhiteSpace(POL1))
                    {
                        data = data.Where(p => p.POL.ToString().ToLower().Contains(POL1.ToLower())
                                              ).ToList();
                    }

                    if (!string.IsNullOrEmpty(INV_DATE1) &&
                   !string.IsNullOrWhiteSpace(INV_DATE1))
                    {
                        data = data.Where(p => Convert.ToDateTime(p.INV_DATE).ToString("dd-MM-yyyy").ToLower().Contains(INV_DATE1.ToLower())
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
        private List<FNINV001_VM> salaryprocessColumnWithOrder(string order, string orderDir, List<FNINV001_VM> data)
        {
            // Initialization.
            List<FNINV001_VM> lst = new List<FNINV001_VM>();
            try
            {
                // Sorting
                switch (order)
                {
                    case "0":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.FNINV001_CODE).ToList()
                                                                                                 : data.OrderBy(p => p.FNINV001_CODE).ToList();
                        break;

                    case "1":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.BL_CODE).ToList()
                                                                                                 : data.OrderBy(p => p.BL_CODE).ToList();
                        break;

                    case "2":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Invoice_No).ToList()
                                                                                                 : data.OrderBy(p => p.Invoice_No).ToList();
                        break;

                    case "3":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.vessel_code).ToList()
                                                                                                 : data.OrderBy(p => p.vessel_code).ToList();
                        break;

                    case "4":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.SUBLEDGER_CODE).ToList()
                                                                                                   : data.OrderBy(p => p.SUBLEDGER_CODE).ToList();
                        break;
                    case "5":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.POD).ToList()
                                                                                                   : data.OrderBy(p => p.POD).ToList();
                        break;

                    case "6":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.POL).ToList()
                                                                                                   : data.OrderBy(p => p.POL).ToList();
                        break;

                    default:
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.INV_DATE).ToList()
                                                                                                 : data.OrderBy(p => p.INV_DATE).ToList();
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
        [Route("SaveCrDrNote")]
        public ActionResult SaveCrDrNote(FNINV001_VM FQV)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                FQV.cmpycode = list[0].CmpyCode;
                FQV.UserName = list[0].user_name;
                FQV.BRANCHCODE = list[0].BraCode;
                return Json(_CrDrService.SaveFNINV_VM(FQV), JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult GETBLNO(string CustCode, string Module_Type,string Type_Choose)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
               
                return Json(_CrDrService.GETBLNO(list[0].CmpyCode, list[0].BraCode, CustCode, Module_Type, Type_Choose), JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult GetCustSupp2(string Prefix,string Choose_Type)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_CrDrService.GetCustSupp(list[0].CmpyCode, list[0].BraCode, "DBNTJ", Choose_Type, Prefix), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetCustSupp1(string Prefix, string Choose_Type)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_CrDrService.GetCustSupp(list[0].CmpyCode, list[0].BraCode, "CRNTJ", Choose_Type, Prefix), JsonRequestBehavior.AllowGet);
            }
        }


        [Route("BLCrdrGE")]
        public ActionResult Bl_InvoiceGenerateLates(string BLCode, string Customer_code, string ExCode, string ExRate, string Table_Name, string Module_Type)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { BLGENFlag = _CrDrService.Bl_InvoiceGenerateLates(list[0].CmpyCode, list[0].BraCode, BLCode, Customer_code, ExCode, ExRate, Table_Name, Module_Type, list[0].user_name) }, JsonRequestBehavior.AllowGet);
            }
        }

        [Route("InvoiceCrdrGE")]
        public ActionResult BlCrdr_InvoiceGenerateLates(string InvCode, string Table_Name, string Module_Type,string InvModule_Type)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { BLGENFlag = _CrDrService.BlCrdr_InvoiceGenerateLates(list[0].CmpyCode, list[0].BraCode, InvCode,Table_Name, Module_Type, InvModule_Type, list[0].user_name) }, JsonRequestBehavior.AllowGet);
            }
        }

        

        public ActionResult GetHeaderDetail(string BLNO)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_CrDrService.GetHeaderDetail(list[0].CmpyCode, BLNO, list[0].BraCode), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetFNINV002DetailList(string BLNO)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_CrDrService.GetFNINV002DetailList(list[0].CmpyCode, BLNO, list[0].BraCode), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Credit_Debit_NoteForJob(string InvCode,string Module_Type)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_CrDrService.Credit_Debit_NoteForJob(list[0].CmpyCode, list[0].BraCode, InvCode,Module_Type), JsonRequestBehavior.AllowGet);
            }
        }

        

    }
}