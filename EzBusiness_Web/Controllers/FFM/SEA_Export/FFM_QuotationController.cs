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
        [Route("Quotation")]
        public ActionResult GetQuotation()
        {
            return View();
        }
    }
}