﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using EzBusiness_BL_Interface;
using EzBusiness_BL_Service;
using EzBusiness_Web.Pdf;
using EzBusiness_EF_Entity;
using System.Configuration;

namespace EzBusiness_Web.Controllers
{
    public class CrystalReportController : Controller
    {
        IEmployeeMgmtService _employeeService;
        public CrystalReportController()
        {
            _employeeService = new EmployeeMgmtService();

        }

        public ActionResult HomeIndex()
        {
            return View();
        }
       
        public ActionResult ShowCustomerList()
        {
            string ServerName = ConfigurationManager.AppSettings["DSN"];
            string DatabaseName = ConfigurationManager.AppSettings["DB"];
            string UserName = ConfigurationManager.AppSettings["ID"];
            string Password = ConfigurationManager.AppSettings["PWD"];
            //ReportDocument rdt = new ReportDocument();
            //rdt.Load("D:\\sharyu\\tfs mvc\\EzBusiness_Web\\EzBusiness_Web\\crystal\\CrystalReport1.rpt", OpenReportMethod.OpenReportByDefault);
            ReportDocument rptDoc = new ReportDocument();
            rptDoc.Load(Path.Combine(Server.MapPath("~/crystal"), "Report1.rpt"), OpenReportMethod.OpenReportByDefault);
            setDbInfo(rptDoc, ServerName, DatabaseName, UserName, Password);
            //rd.SetDataSource(allCustomer);
                      
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();

            Stream stream = rptDoc.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "CustomerList.pdf");

            //List<EzBusiness_ViewModels.Models.Humanresourcepayroll.Employee_VM> emp = _employeeService.GetEmployeeList("UM");
            //string reportPath = Path.Combine(Server.MapPath("~/crystal"), "Report1.rpt");
            //return new CrystalReportPdfResult(reportPath, emp);
        }
        protected void setDbInfo(ReportDocument rpt, string ServerName, string DatabaseName, string UserName, string Password)
        {
            TableLogOnInfo logoninfo = new TableLogOnInfo();
            foreach (CrystalDecisions.CrystalReports.Engine.Table t in rpt.Database.Tables)
            {
                logoninfo = t.LogOnInfo;
                logoninfo.ReportName = rpt.Name;
                logoninfo.ConnectionInfo.ServerName = ServerName;
                logoninfo.ConnectionInfo.DatabaseName = DatabaseName;
                logoninfo.ConnectionInfo.UserID = UserName;
                logoninfo.ConnectionInfo.Password = Password;
                logoninfo.TableName = t.Name;
                t.ApplyLogOnInfo(logoninfo);
                //t.Location = t.Name;
            }
        }

    }

}