using Newtonsoft.Json;
using OnlineLoanManagementSystem.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineLoanManagementSystem.Controllers
{
    public class CompanyController : Controller
    {
        // GET: Company
        public ActionResult Company()
        {
            return View();
        }
        public string GetCompany()
        {
            var companyData = JsonConvert.SerializeObject(DatabaseCon.GetData("select * from tblCompany"));

            return companyData;
        }

        [HttpPost]
        public int AddUpdateCompany(int CompanyId, string CompanyName, string StartDate, double Trunover, string OwenerName)
        {
            int isQueryRun = 0;
            if (CompanyId != 0)
            {
                isQueryRun = DatabaseCon.RunCmd($"update tblCompany set CompanyName='{CompanyName}', StartDate='{StartDate}', Trunover='{Trunover}', OwenerName='{OwenerName}' where CompanyId={CompanyId}");
            }
            else
            {
                isQueryRun = DatabaseCon.RunCmd($"insert into tblCompany values('{CompanyName}','{StartDate}', '{Trunover}', '{OwenerName}' )");
            }

            return isQueryRun;
        }
    }
}