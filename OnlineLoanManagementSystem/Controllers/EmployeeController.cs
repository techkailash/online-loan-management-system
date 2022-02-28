using Newtonsoft.Json;
using OnlineLoanManagementSystem.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineLoanManagementSystem.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Employee()
        {
            return View();
        }
        public string GetEmployee()
        {
            var employeeData = JsonConvert.SerializeObject(DatabaseCon.GetData("select * from tblCustomer Where Type = 'Employee' "));

            return employeeData;
        }

        [HttpPost]
        public int AddUpdateEmployee(int CId, string Name, string Email, double Phone, string Address)
        {
            int isQueryRun = 0;
            if (CId != 0)
            {
                isQueryRun = DatabaseCon.RunCmd($"update tblCustomer set Name='{Name}', Email='{Email}', Phone='{Phone}', Address='{Address}', Type='Employee' where CId={CId}");
            }
            else
            {
                isQueryRun = DatabaseCon.RunCmd($"insert into tblCustomer values('{Name}','{Email}', '{Phone}', '{Address}', 'Employee' )");
            }

            return isQueryRun;
        }
    }
}