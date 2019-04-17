using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Seguro.Company.Web.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
            ViewBag.PageCssClass = "subpage";
        }
    }
}