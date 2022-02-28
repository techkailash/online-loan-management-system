using Newtonsoft.Json;
using OnlineLoanManagementSystem.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineLoanManagementSystem.Controllers
{
    public class DocumentController : Controller
    {
        // GET: Document
        public ActionResult Document()
        {
            return View();
        }
        public string GetDocument()
        {
            var data = JsonConvert.SerializeObject(DatabaseCon.GetData("select * from tblUploadDocument"));

            return data;
        }

        [HttpPost]
        public int AddUpdateDocument(int DocumentId, string DocumentType, string DocumentName)
        {
            int isQueryRun = 0;
            if (DocumentId != 0)
            {
                isQueryRun = DatabaseCon.RunCmd($"update tblUploadDocument set documentType='{DocumentType}', documentName='{DocumentName}' where documentId={DocumentId}");
            }
            else
            {
                isQueryRun = DatabaseCon.RunCmd($"insert into tblUploadDocument (documentType, documentName) values('{DocumentType}','{DocumentName}')");
            }

            return isQueryRun;
        }
    }
}