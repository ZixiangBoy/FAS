using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ultra.Surface.Form;
using Ultra.Surface.Lanuch;

namespace Ultra.FAS.Login
{
    public partial class SysInfoView : BaseSurface
    {
        public SysInfoView()
        {
            InitializeComponent();
        }

        private void SysInfoView_Load(object sender, EventArgs e)
        {
            lblMode.Text = Lanucher.IsBSMode ? "BS" : "CS";
            lblimgsrv.Text = Regex.Replace(Lanucher.ImgSvrURL, @"(\d+.)+(?=.\d+:\d+)", "*.");// Lanucher.ImgSvrURL;
            if (!Lanucher.IsBSMode)
            {
                SqlConnectionStringBuilder bld = new SqlConnectionStringBuilder(Lanucher.ConnectonString);

                var cnsl = bld.DataSource.ToString().Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                cnsl[0] = Regex.Replace(cnsl[0], @"(\d+.)(?=.\d+)", "*."); 
                lblcsbsdb.Text = string.Format("{0} {1}", cnsl[0], bld.InitialCatalog);
            }
            else
            {
                lblcsbsdb.Text = Regex.Replace(Lanucher.SvrURL, @"(\d+.)(?=.\d+)", "*."); 
            }
            lblcsbsdb.Visible = true;

        }
    }
}
