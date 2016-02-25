using OdeToFood.Models;
using OdeToFood.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OdeToFood.Controllers
{
    public class AdministrationController : Controller
    {
        //
        // GET: /Administration/
        private OdeToFoodDb _db = new OdeToFoodDb();

        public ActionResult Index()
        {

            var viewModel = new List<EditUserRolesViewModel>();

            var UserRoles = Roles.GetAllRoles();
            SelectList UserRolesList = new SelectList(UserRoles);
            using (var db = _db)
            {
                viewModel = db.UserProfiles
                        .ToList()
                        .Select(x => new EditUserRolesViewModel
                         {
                             UserName = x.UserName,
                             CurrentRoles = new List<String>(Roles.GetRolesForUser(x.UserName)),
                             Roles = new List<String>(Roles.GetAllRoles())
                         }).ToList();
            }
            ViewBag.UserRolesList = UserRolesList;
            return View(viewModel);
        }

    }
}
