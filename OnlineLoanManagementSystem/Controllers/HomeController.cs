using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineLoanManagementSystem.App_Code;

namespace OnlineLoanManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var dashboarData = DatabaseCon.GetData("select COUNT(loanTypeId) as Sales, SUM(Rate) as Revenue, (select COUNT(loginid) as totalUser from tblLogin) as Customers from tblLoanType");

            ViewBag.Sales = dashboarData.Rows[0]["Sales"];
            ViewBag.Revenue = dashboarData.Rows[0]["Revenue"];
            ViewBag.Customers = dashboarData.Rows[0]["Customers"];
            return View();
        }

        public ActionResult LoanType()
        {
            return View();
        }

        public string GetLoanType()
        {
            var loanTypeData = JsonConvert.SerializeObject(DatabaseCon.GetData("select * from tblLoanType"));

            return loanTypeData;
        }

        [HttpPost]
        public int AddUpdateLoanType(string loanType, string duration, int rate, int loanTypeId)
        {
            int isQueryRun = 0;
            if (loanTypeId != 0)
            {
                isQueryRun = DatabaseCon.RunCmd($"update tblLoanType set Loantype='{loanType}', Duration='{duration}', Rate='{rate}' where loantypeid={loanTypeId}");
            }
            else
            {
                isQueryRun = DatabaseCon.RunCmd($"insert into tblLoanType values('{loanType}','{duration}', '{rate}' )");
            }

            return isQueryRun;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult MyProfile()
        {
            ViewBag.Message = "My Profile";

            return View();
        }
    }
}