using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Ultra.FAS.ERP
{
    public partial class PrtTemplate : Form
    {
        public PrtTemplate()
        {
            InitializeComponent();
        }
        Assembly asm = null;
        private void PrtTemplate_Load(object sender, EventArgs e)
        {
            var pth = AppDomain.CurrentDomain.BaseDirectory;
            var fi = Path.Combine(pth, "Ultra.WLSys.ERP.Report.dll");
            if (!File.Exists(fi)) return;
            asm = Assembly.LoadFile(fi);
            var tps = asm.GetTypes();
            listBox1.Items.Clear();
            foreach (var tp in tps)
            {
                listBox1.Items.Add(tp.FullName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           var obj= asm.CreateInstance(listBox1.SelectedItem.ToString());
           var rpt = obj as DevExpress.XtraReports.UI.XtraReport;
           if (null == rpt) return;
           rpt.ShowDesignerDialog();
        }
    }
}
