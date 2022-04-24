using Newtonsoft.Json;
using OnlineLoanManagementSystem.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineLoanManagementSystem.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Register()
        {
            return View();
        }
        public string GetEmployee()
        {
            var data = JsonConvert.SerializeObject(DatabaseCon.GetData("select * from tblRegister"));

            return data;
        }
        [HttpPost]
        public ActionResult AddRegister(string fullName, string userName, string password)
        {
            var data = DatabaseCon.GetData($"select * from tblRegister where userName = '{userName}'");
            if(data.Rows.Count == 0)
            {
                int isQueryRun = DatabaseCon.RunCmd($"insert into tblRegister values('{fullName}','{userName}', '{password}')");
                DatabaseCon.RunCmd($"insert into tblLogin values('{userName}', '{password}', 'Customer')");
                return RedirectToAction("Login", "Account");
            }
            else
            {
                return RedirectToAction("Register", "Register");
            }
        }
    }
}