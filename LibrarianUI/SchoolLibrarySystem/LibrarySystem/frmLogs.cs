using System;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using LibrarySystem.Includes;
using LibrarySystem.Properties;

namespace LibrarySystem
{
    public partial class frmLogs : Form
    {
        private readonly SQLConfig config = new SQLConfig();
        private usableFunction funct = new usableFunction();
        private string sql;

        public frmLogs()
        {
            InitializeComponent();
        }

        private void reports(string sql, string rptname)
        {
            try
            {
                config.loadReports(sql);
                string reportname, strReportPath;

                reportname = rptname;
                var reportdoc = new ReportDocument();

                strReportPath = Application.StartupPath + "\\report\\" + reportname + ".rpt";
                reportdoc.Load(strReportPath);
                reportdoc.SetDataSource(config.dt);

                crystalReportViewer1.ReportSource = reportdoc;
                crystalReportViewer1.ShowRefreshButton = false;
                crystalReportViewer1.ShowCloseButton = false;
                crystalReportViewer1.ShowGroupTreeButton = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " No crytal reports installed.");
            }
        }

        private void frmLogs_Load(object sender, EventArgs e)
        {
            sql =
                "SELECT `Fullname`, `User_name`, `UserRole`,`LogDate`, `LogMode` FROM `tbllogs` l, `tbluser` u WHERE l.`UserId`=u.`UserId`";
            reports(sql, "LogsReport");
        }
    }
}