using EzBusiness_DL_Repository;
using Microsoft.Reporting.WebForms;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EzBusiness_Web
{
    public partial class ReportViewerWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
if (!IsPostBack)
    {
                //EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();
                //DataSet ds = null;
                //ds = _EzBusinessHelper.ExecuteDataSet("select * from PRLA001 where PRLA001_CODE ='PRLA-71' and CmpyCode='UM'");
                //var rptviewer = new ReportViewer();
                //rptviewer.ProcessingMode = ProcessingMode.Local;
                //// rptviewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Report/LoanApp.rdlc";
                //rptviewer.LocalReport.ReportPath = Server.MapPath("~/Report/LoanApp.rdlc");
                ////ReportParameter[] param = new ReportParameter[1];
                ////param[0] = new ReportParameter("statename", name);
                ////rptviewer.LocalReport.SetParameters(param);
                //ReportDataSource rptdatasource = new ReportDataSource("DataSet1", ds.Tables[0]);
                //rptviewer.LocalReport.DataSources.Clear();
                //rptviewer.LocalReport.DataSources.Add(rptdatasource);
                //rptviewer.LocalReport.Refresh();
                //rptviewer.ProcessingMode = ProcessingMode.Local;
                //rptviewer.AsyncRendering = false;
                //rptviewer.SizeToReportContent = true;
                //rptviewer.ZoomMode = ZoomMode.FullPage;


            }
        }
    }
}