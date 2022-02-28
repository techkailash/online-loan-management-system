using Newtonsoft.Json;
using OnlineLoanManagementSystem.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineLoanManagementSystem.Controllers
{
    public class LoanApplicationController : Controller
    {
        // GET: LoanApplication
        public ActionResult LoanApplication()
        {
            var companyData = DatabaseCon.GetData("select * from tblCompany");
            var loanTypeData = DatabaseCon.GetData("select * from tblLoanType");
            var loanMasterData = DatabaseCon.GetData("select * from tblLoan_Master");

            var customerList = new List<Object>();

            for (int i = 0; i < companyData.Rows.Count; i++)
            {
                customerList.Add(new
                {
                    value = companyData.Rows[i]["CompanyId"].ToString(),
                    text = companyData.Rows[i]["CompanyName"].ToString()
                });
            }

            var loanTypeList = new List<Object>();

            for (int i = 0; i < loanTypeData.Rows.Count; i++)
            {
                loanTypeList.Add(new
                {
                    value = loanTypeData.Rows[i]["LoanTypeId"].ToString(),
                    text = loanTypeData.Rows[i]["LoanType"].ToString()
                });
            }

            var loanMasterList = new List<Object>();

            for (int i = 0; i < loanMasterData.Rows.Count; i++)
            {
                loanMasterList.Add(new
                {
                    value = loanMasterData.Rows[i]["LoanId"].ToString(),
                    text = loanMasterData.Rows[i]["LoanTypeId"].ToString()
                });
            }

            ViewBag.customerData = new SelectList(customerList, "value", "text");
            ViewBag.loanTypeData = new SelectList(loanTypeList, "value", "text");
            ViewBag.loanMasterData = new SelectList(loanMasterList, "value", "text");
            return View();
        }
        public string GetLoanApplicationsType()
        {
            var loanTypeData = JsonConvert.SerializeObject(DatabaseCon.GetData($"select * from tblLoanApplication where loginId='{Session["loginId"]}'"));

            return loanTypeData;
        }

        [HttpPost]
        public int AddUpdateLoanApplication(int loanApplicationId, int CompanyId, int LoanTypeId, int LoanId)
        {
            int isQueryRun = 0;
            if (loanApplicationId != 0)
            {
                isQueryRun = DatabaseCon.RunCmd($"update tblLoanApplication set companyid='{CompanyId}', LoanTypeId='{LoanTypeId}', LoanId='{LoanId}' where loanApplicationId={loanApplicationId}");
            }
            else
            {
                isQueryRun = DatabaseCon.RunCmd($"insert into tblLoanApplication values('{CompanyId}','{LoanTypeId}', '{LoanId}', {Session["loginId"]} 'pending' )");
            }

            return isQueryRun;
        }
    }
}