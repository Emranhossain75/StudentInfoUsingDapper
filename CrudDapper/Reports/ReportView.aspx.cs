using CrudDapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CrudDapper.Reports
{
    public partial class ReportView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Student> IsDatsa = new List<Student>();
                DALStudent dALStudent = new DALStudent();
                IsDatsa = dALStudent.GetStudent();
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("ListOfStudent.rdlc");
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add
                    (new Microsoft.Reporting.WebForms.ReportDataSource("DsData",IsDatsa));
            }
        }
    }
}