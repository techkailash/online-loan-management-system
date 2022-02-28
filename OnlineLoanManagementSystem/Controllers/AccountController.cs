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
                var empType = checkLoginDetails.Rows[0][3];
                Session["loginEmpType"] = empType;
                Session["loginId"] = checkLoginDetails.Rows[0][0];
                Session["loginUserName"] = userName;
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Login");
        }
    }
}