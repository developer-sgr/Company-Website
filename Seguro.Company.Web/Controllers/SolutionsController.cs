using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Seguro.Company.Web.Models;

namespace Seguro.Company.Web.Controllers
{
    public class SolutionsController : BaseController
    {
        // GET: Solutions
        
        public ActionResult Index(string urlKeyword)
        {
            var model = new CommonModel();
            model.UrlKeyword = urlKeyword;
           // ViewBag.UrlKeyword = model.UrlKeyword;
            return View(model);
        }
    }
}