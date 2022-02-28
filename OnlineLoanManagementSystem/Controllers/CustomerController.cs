using Newtonsoft.Json;
using OnlineLoanManagementSystem.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineLoanManagementSystem.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Customer()
        {
            return View();
        }

        public ActionResult GetCustomer()
        {
            var CustomerData = JsonConvert.SerializeObject(DatabaseCon.GetData("select * from tblCustomer Where Type = 'Customer' "));
            return Json(CustomerData, JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        public int AddUpdateCustomer(int CId, string Name, string Email, double Phone, string Address)
        {
            int isQueryRun = 0;
            if (CId != 0)
            {
                isQueryRun = DatabaseCon.RunCmd($"update tblCustomer set Name='{Name}', Email='{Email}', Phone='{Phone}', Address='{Address}', Type='Customer' where CId={CId}");
            }
            else
            {
                isQueryRun = DatabaseCon.RunCmd($"insert into tblCustomer values('{Name}','{Email}', '{Phone}', '{Address}', 'Customer' )");
            }

            return isQueryRun;
        }
    }
}