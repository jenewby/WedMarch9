using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WedMarch9.Controllers
{
    [RequireHttps]

    public class JENController : Controller
    {
        // GET: JEN
        public ActionResult Index()
        {
            return View();
        }
    }
}