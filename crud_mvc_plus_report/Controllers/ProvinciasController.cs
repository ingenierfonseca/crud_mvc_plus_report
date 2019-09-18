using Domain.Class;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Reporting.WebForms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace crud_mvc_plus_report.Controllers
{
    public class ProvinciasController : Controller
    {
        Database db = DatabaseFactory.CreateDatabase("DataBase");
        // GET: Provincias
        public ActionResult Index()
        {
            DataSet ds = db.ExecuteDataSet("spProvinciasPais", 1);
            DataTable dt = new DataTable();
            List<Provincia> items = new List<Provincia>();

            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                items = JsonConvert.DeserializeObject<List<Provincia>>(JsonConvert.SerializeObject(dt));
            }

            return View(items);
        }

        public ActionResult ProvinciasPais(int id)
        {
            DataSet ds = db.ExecuteDataSet("spProvinciasPais", id);
            DataTable dt = new DataTable();
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return Json(JsonConvert.SerializeObject(dt));
        }

        public ActionResult Report(string ReportType, int Id)
        {
            LocalReport report = new LocalReport();
            report.ReportPath = Server.MapPath("~/SRSS/ProvinciasReport.rdlc");

            DataSet ds = db.ExecuteDataSet("spProvinciasPais", Id);
            ReportDataSource datasource = new ReportDataSource("DataSet1", ds.Tables[0]);
            //datasource.Name = "ProvinciasDataSource";
            //datasource.Value = JsonConvert.DeserializeObject<List<Provincia>>(ProvinciasPais(Id).ToString());
            report.DataSources.Add(datasource);

            //ReportParameter param = new ReportParameter("IdPais", Id.ToString());
            //param.Values.Add(Id);
            //report.LocalReport.SetParameters(param);

            string mimeType;
            string encoding;
            string fileNameExtension;

            switch (ReportType)
            {
                case "Excel":
                    fileNameExtension = "xlsx";
                    break;
                case "Pdf":
                    fileNameExtension = "pdf";
                    break;
                case "Word":
                default:
                    fileNameExtension = "docx";
                    break;
            }

            string[] streams;
            Warning[] warnings;
            byte[] renderedByte;
            renderedByte = report.Render(ReportType, "", out mimeType, out encoding, out fileNameExtension, out streams, out warnings);
            Response.AddHeader("content-disposition", "attachment;filename=provincias_report." + fileNameExtension);
            return File(renderedByte, fileNameExtension);
            //return View();
        }
    }
}