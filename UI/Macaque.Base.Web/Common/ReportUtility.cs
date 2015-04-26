using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Macaque.Base.Web.Common
{
    public class ReportUtility
    {
        public static byte[] GenerateReport(string reportName, List<KeyValuePair<string, string>> paraList, List<KeyValuePair<string, DataTable>> dataList, out string mimeType)
        {
            ReportViewer report = new ReportViewer();
            report.ProcessingMode = ProcessingMode.Local;
            report.LocalReport.ReportPath = System.Web.HttpContext.Current.Server.MapPath(string.Format("~/Reports/{0}.rdlc", reportName));
            report.LocalReport.Refresh();

            if (paraList != null && paraList.Count > 0)
            {
                List<ReportParameter> reportParaList = new List<ReportParameter>();
                foreach (var item in paraList)
                {
                    reportParaList.Add(new ReportParameter(item.Key, item.Value));
                }
                report.LocalReport.SetParameters(reportParaList);
            }

            for (int i = 0; i < dataList.Count; i++)
            {
                if (dataList[i].Value != null && dataList[i].Value != null)
                {
                    ReportDataSource dataSource = new ReportDataSource();
                    dataSource.Name = dataList[i].Key;
                    dataSource.Value = dataList[i].Value;

                    report.LocalReport.DataSources.Add(dataSource);
                }
            }

            mimeType = "";
            string encoding = "";
            string filenameExtension = "";
            string[] streamids = null;
            Warning[] warnings = null;

            var stream = report.LocalReport.Render("PDF", null, out mimeType, out encoding, out filenameExtension, out streamids, out warnings);

            return stream;
        }
    }
}