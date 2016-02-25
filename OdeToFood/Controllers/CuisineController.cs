using OdeToFood.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Controllers
{
    //[Authorize]
    [Log]
    public class CuisineController : Controller
    {
        //
        // GET: /Cuisine/
        
        public ActionResult Search(string name)
        {
            throw new Exception("ERRO");
            var message = Server.HtmlEncode(name);
            return Content(message);
            //return RedirectPermanent("http://google.com");
            //return RedirectToAction("Index", "Home", new { tipo = "lala" });
            //return RedirectToRoute("Default", new { controller = "Home", action = "About" });
            //return File(Server.MapPath("~/Content/site.css"), "text/css");
            //return Json(new { Message = message, Name = "Bernas" }, JsonRequestBehavior.AllowGet);
        }

    }
}
