using EzBusiness_BL_Interface;
using EzBusiness_BL_Service;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;
using System;
using System.IO;
using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;
using EzBusiness_EF_Entity;
using System.Collections.Generic;
using System.Web;

namespace EzBusiness_Web.Controllers
{
    public class EmployeeMasterController : Controller
    {          
        IEmployeeMgmtService _employeeService;   
        public EmployeeMasterController()
        {
            _employeeService = new EmployeeMgmtService();
           
        }
        // GET: EmployeeMaster
        [Route("EmployeeMaster")]    
        public ActionResult EmployeeMaster()
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

        
        public ActionResult GetEmployeeMasterList()
      {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_employeeService.GetEmployeeList(list[0].CmpyCode));
            }           
        }

        [Route("EditEmployeeMasternew")]
        public ActionResult EditEmployeeMaster(string EmpCode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;

            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_employeeService.GetEmployeeMasterDetailsEdit(list[0].CmpyCode, EmpCode));
            }
        }

        public ActionResult AddEmployeeMaster()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;

            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_employeeService.GetEmployeeMasterDetailsNew(list[0].CmpyCode));
            }
        }
      

        [HttpPost]
        [Route("SaveEmployeeMaster")]
        public ActionResult SaveEmployeeMaster(Employee_VM employeemaster)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;

            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
              
                employeemaster.Cmpycode = list[0].CmpyCode;
                employeemaster.UserName = list[0].user_name;
                return Json(_employeeService.SavePurchaseOrder(employeemaster), JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult UploadFile()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            string _imgname = string.Empty;
            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var pic = System.Web.HttpContext.Current.Request.Files["MyImages"];
                if (pic.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(pic.FileName);
                    var _ext = Path.GetExtension(pic.FileName);

                    _imgname = DateTime.Now.ToString("ddMMyyyyhhmmss");
                    var _comPath = Server.MapPath("/Images/Emp_") + _imgname + list[0].CmpyCode + _ext;
                    _imgname = "Emp_" + _imgname + list[0].CmpyCode + _ext;

                    ViewBag.Msg = _comPath;
                    var path = _comPath;

                    // Saving Image in Original Mode
                    pic.SaveAs(path);

                    // resizing image
                    MemoryStream ms = new MemoryStream();
                    WebImage img = new WebImage(_comPath);

                    if (img.Width > 200)
                        img.Resize(200, 200);
                    img.Save(_comPath);
                    // end resize
                }
            }
            return Json(Convert.ToString(_imgname), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult UploadDoc()
        {
            string fname = "";
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            string _imgname = string.Empty;
            if (Request.Files.Count > 0)
            {
               
                try
                {
                    //  Get all files from Request object  
                    System.Web.HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        //string path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/";  
                        //string filename = Path.GetFileName(Request.Files[i].FileName);  

                        HttpPostedFileBase file = files[i];
                       

                        // Checking for Internet Explorer  
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            fname = file.FileName;
                            var _ext = Path.GetExtension(fname);
                        }

                        // Get the complete folder path and store the file inside it.  
                        _imgname = Path.Combine(Server.MapPath("/Uploads/"), fname);
                        file.SaveAs(_imgname);
                    }
                    // Returns message that successfully uploaded  
                    return Json(fname, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    return Json("Error occurred. Error details: " + ex.Message);
                }
            }
            else
            {
                return Json(fname, JsonRequestBehavior.AllowGet);
            }
           // return Json(Convert.ToString(_imgname), JsonRequestBehavior.AllowGet);
        }

        [Route("DeleteEmployeeMaster")]
        public ActionResult DeleteEmployeeMaster(string EmpCode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { DeleteFlag = _employeeService.DeleteEmployee(list[0].CmpyCode, EmpCode,list[0].user_name) }, JsonRequestBehavior.AllowGet);
            }
        }      
        public ActionResult GetBankList()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_employeeService.GetBankList(list[0].CmpyCode), JsonRequestBehavior.AllowGet);
            }           
        }
        public ActionResult GetBankBranchList(string BankCode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_employeeService.GetBankBranchList(list[0].CmpyCode, BankCode), JsonRequestBehavior.AllowGet);
            }               
        }
        public ActionResult GetDepartmentList(string divcode, string Brancode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_employeeService.GetDepartmentList(list[0].CmpyCode,divcode,Brancode), JsonRequestBehavior.AllowGet);
            }             
        }

        public ActionResult GetBranchCodeList()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_employeeService.GetBranchCodeList(list[0].CmpyCode,list[0].Divcode), JsonRequestBehavior.AllowGet);
            }

        }
        public FileResult Download(string parentPartId)
        {
            byte[] fileBytes = null;
            string fileName = null;
            if (parentPartId != null)
            {
                fileBytes = System.IO.File.ReadAllBytes(Server.MapPath(parentPartId));
                fileName = parentPartId;

            }
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);

            //string filePath = Server.MapPath(parentPartId);
            //return File(filePath, "application/pdf");
        }

        public ActionResult GetBranchCodeList1(string divcode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_employeeService.GetBranchCodeList(list[0].CmpyCode, divcode), JsonRequestBehavior.AllowGet);
            }

        }
        //public ActionResult GetDisciplineList()
        //{
        //    List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
        //    if (list == null)
        //    {
        //        return Redirect("Login/InLogin");
        //    }
        //    else
        //    {
        //        return Json(_employeeService.GetDisciplineList(list[0].CmpyCode), JsonRequestBehavior.AllowGet);
        //    }               
        //}
        public ActionResult GetDivisionList()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_employeeService.GetDivisionList(list[0].CmpyCode), JsonRequestBehavior.AllowGet);
            }           
        }
        //public ActionResult GetEmployeeTypeMasterList()
        //{
        //    List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
        //    if (list == null)
        //    {
        //        return Redirect("Login/InLogin");
        //    }
        //    else
        //    {
        //        return Json(_employeeService.GetEmployeeTypeMasterList(list[0].CmpyCode), JsonRequestBehavior.AllowGet);
        //    }            
        //}
        public ActionResult GetWeekdaysList()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_employeeService.GetWeekdaysList(list[0].CmpyCode), JsonRequestBehavior.AllowGet);
            }            
        }
        public ActionResult GetProfList()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_employeeService.GetProfList(list[0].CmpyCode), JsonRequestBehavior.AllowGet);
            }             
        }
        public ActionResult GetVisaLocationList()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_employeeService.GetVisaLocationList(list[0].CmpyCode), JsonRequestBehavior.AllowGet);
            }             
        }
        public ActionResult GetTDSTypesList()

        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_employeeService.GetTDSTypesList(list[0].CmpyCode), JsonRequestBehavior.AllowGet);
            }             
        }
        public ActionResult GetTDSSection()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_employeeService.GetTDSSection(list[0].CmpyCode), JsonRequestBehavior.AllowGet);
            }             
        }
        public ActionResult GetSubTrademaster()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_employeeService.GetSubTrademaster(list[0].CmpyCode), JsonRequestBehavior.AllowGet);
            }             
        }
        public ActionResult GetShiftMasterList()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_employeeService.GetShiftMasterList(list[0].CmpyCode), JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetCommList( )
        {           
                return Json(_employeeService.GetCommList("ATTTYPE"), JsonRequestBehavior.AllowGet);                       
        }
        public ActionResult GetCommList1()
        {
            return Json(_employeeService.GetCommList("OTMULTIPLIER"), JsonRequestBehavior.AllowGet);

        }
        public ActionResult GetCommList2()
        {
            return Json(_employeeService.GetCommList("BLOODGROUP"), JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetCommList3()
        {            
            return Json(_employeeService.GetCommList("BLOODGROUP"), JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetCommList4()
        {           
            return Json(_employeeService.GetCommList("REGION"), JsonRequestBehavior.AllowGet);                  
        }
    }
}