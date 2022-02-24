using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineLoanManagementSystem.App_Code;

namespace OnlineLoanManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string userName, string Password)
        {
            var checkLoginDetails = DatabaseCon.GetData($"select * from tblLogin where userName='{userName}' and password='{Password}'");

            if (checkLoginDetails.Rows.Count > 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Login");
        }
    }
}