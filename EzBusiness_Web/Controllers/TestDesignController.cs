using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EzBusiness_Web.Controllers
{
    public class TestDesignController : Controller
    {
        // GET: TestDesign
        [Route("TestDesign")]
        public ActionResult TestDesign()
        {
            return View();
        }
    }
}