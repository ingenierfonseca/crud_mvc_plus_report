using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace crud_mvc_plus_report.SRSS
{
    public partial class AdapterReportPage : System.Web.UI.Page
    {
        Database db = DatabaseFactory.CreateDatabase("DataBase");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RenderReport();
            }
        }

        void RenderReport()
        {
            appReportViewer.Reset();
            appReportViewer.LocalReport.EnableExternalImages = true;
            appReportViewer.LocalReport.ReportPath = Server.MapPath("~/SRSS/ProvinciasReport.rdlc");
            //appReportViewer.LocalReport.SetParameters(new Microsoft.Reporting.WebForms.ReportParameter("", ""));

            DataSet ds = db.ExecuteDataSet("spProvinciasPais", 3);
            appReportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", ds.Tables[0]));
        }
    }
}