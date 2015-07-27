using DevExpress.XtraEditors.Controls;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ultra.FASControls.Caller;
using Ultra.Surface.Common;
using Ultra.Surface.Lanuch;
using Ultra.Web.Core.Common;

namespace Ultra.FASControls.BusControls {
    public class ItemGridEdit : EntityGridEditEx<UltraDbEntity.T_ERP_Item> {
        public ItemGridEdit() : base() { }

        protected override List<UltraDbEntity.T_ERP_Item> GetData() {
            return SerNoCaller.Calr_Item.Get("where IsUsing=1 ");
        }
    }
    public class UserGridEdit : EntityGridEditEx<UltraDbEntity.T_ERP_User>
    {
        public UserGridEdit() : base() { }

        protected override List<UltraDbEntity.T_ERP_User> GetData()
        {
            return SerNoCaller.Calr_User.Get("where IsUsing=1 and UserName!='admin'");
        }
    }
    public class WorkerGridEdit : EntityGridEditEx<UltraDbEntity.T_ERP_Worker>
    {
        public WorkerGridEdit() : base() { }

        protected override List<UltraDbEntity.T_ERP_Worker> GetData()
        {
            return SerNoCaller_WL.Calr_Worker.Get("where IsUsing=1 ");
        }
    }
    public class ProcedureGridEdit : EntityGridEditEx<UltraDbEntity.T_ERP_Procedure> {
        public ProcedureGridEdit() : base() { }

        protected override List<UltraDbEntity.T_ERP_Procedure> GetData() {
            return SerNoCaller.Calr_Procedure.Get("where IsUsing=1 ");
        }
    }

    public class LocEdtGridEdit : EntityGridEditEx<UltraDbEntity.T_ERP_WareLoc> {
        public LocEdtGridEdit()
            : base() {
            base.ColumnCaption = "库位";
        }
        protected override List<UltraDbEntity.T_ERP_WareLoc> GetData() {
            return SerNoCaller.Calr_WareLoc.Get("where IsUsing=1");
        }
    }
    public class WareHouseGridEdit : EntityGridEditEx<UltraDbEntity.T_ERP_WareHouse> {
        public WareHouseGridEdit()
            : base() {
            base.ColumnCaption = "仓库";
        }

        protected override List<UltraDbEntity.T_ERP_WareHouse> GetData() {
            return SerNoCaller.Calr_WareHouse.Get("where IsUsing=1");
        }

        public static List<UltraDbEntity.T_ERP_WareHouse> GetNotVirtualWare() {
            return SerNoCaller.Calr_WareHouse.Get("where IsUsing=1 and IsNull(IsVirtual,0)=0 and IsNull(IsOut,0)=0");
        }
    }
    public class WareAreaGridEdit : EntityGridEditEx<UltraDbEntity.T_ERP_WareArea> {
        protected override List<UltraDbEntity.T_ERP_WareArea> GetData() {
            //using (var db = new PetaPoco.Database(Lanucher.ConnectonString))
            //{
            //    return db.Fetch<UltraDbEntity.T_ERP_WareArea>("where IsUsing=1");
            //}
            return SerNoCaller.Calr_WareArea.Get("where IsUsing=1");
        }
    }


    public class SuppliersGridEdt : EntityGridEditEx<UltraDbEntity.T_ERP_Suppliers>
    {
        protected override string DefText
        {
            get
            {
                return "供应商";
            }
        }

        protected override List<UltraDbEntity.T_ERP_Suppliers> GetData()
        {
            return SerNoCaller.Calr_Suppliers.Get("where IsUsing=1");
        }
    }

    public class MaterialGridEdt : EntityGridEditEx<UltraDbEntity.T_ERP_Material> {
        protected override string DefText {
            get {
                return "物料";
            }
        }

        protected override List<UltraDbEntity.T_ERP_Material> GetData() {
            return SerNoCaller.Calr_Material.Get("where IsUsing=1");
        }
    }

    public class CompanyGridEdt : EntityGridEditEx<UltraDbEntity.T_ERP_Company> {
        protected override string DefText {
            get {
                return "公司名称";
            }
        }

        protected override List<UltraDbEntity.T_ERP_Company> GetData() {
            return SerNoCaller.Calr_Company.Get("where IsUsing=1");
        }
    }

    public class TradeMarkGridEdt : EntityGridEditEx<UltraDbEntity.T_ERP_TradeMark> {
        protected override string DefText {
            get {
                return "商标信息";
            }
        }

        protected override List<UltraDbEntity.T_ERP_TradeMark> GetData() {
            return SerNoCaller.Calr_TradeMark.Get("where IsUsing=1");
        }
    }

    public class CmbPrinter : DevExpress.XtraEditors.ComboBoxEdit
    {
        public CmbPrinter()
            : base()
        {
            base.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            base.Properties.Items.Clear();
            base.Properties.Buttons.Clear();
            var btn = new EditorButton(ButtonPredefines.Glyph);
            btn.Caption = "打印机";
            btn.Visible = true;
            btn.IsLeft = true;
            btn.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            base.Properties.Buttons.Add(new EditorButton(ButtonPredefines.Combo));
            base.Properties.Buttons.Add(btn);
            if (!DesignMode)
            {
                //LoadPrinter();
            }
        }

        public void LoadPrinter()
        {
            var ets = Ultra.Common.Util.EnumPrinter();
            base.Properties.Items.AddRange(ets);
            if (ets.Count > 0)
                base.SelectedIndex = 0;
        }
    }
    
    public class ReportEdtTmp
    {
        public string Name { get; set; }
        public XtraReport Rpt { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }

    public class RptMonthDate : DevExpress.XtraEditors.ComboBoxEdit
    {
        protected DateTime _startTime = DateTime.Parse("2014-2-1 00:00:00");
        public RptMonthDate()
            : base()
        {

        }

        public void LoadDate()
        {
            int Value = (DateTime.Now.Year * 12 + DateTime.Now.Month) - (_startTime.Year * 12 + _startTime.Month);

            while (Value > 0)
                this.Properties.Items.Add(_startTime.AddMonths(Value--).ToString("yyyy-MM"));
            this.Properties.Items.Add(_startTime.ToString("yyyy-MM"));
        }

        public DateTime? GetDate()
        {
            if (string.IsNullOrEmpty(Text)) return null;
            DateTime de;
            if (!DateTime.TryParse(Text + "-1 00:00:00", out de)) return null;
            return de;
        }
    }


    public class BusLabelText : DevExpress.XtraEditors.ButtonEdit
    {
        public BusLabelText()
            : base()
        {
            base.Properties.Buttons.Clear();
            LabelButton = new EditorButton(ButtonPredefines.Glyph);
            LabelButton.IsLeft = true;
            LabelButton.Visible = true;
            LabelButton.Caption = DefText;
            LabelButton.Width = DefWidth;
            LabelButton.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            base.Properties.Buttons.Add(LabelButton);
            var btn = new EditorButton(ButtonPredefines.Ellipsis);
            btn.Visible = true;
            base.Properties.Buttons.Add(btn);
            var bdel = new EditorButton(ButtonPredefines.Delete);
            bdel.Visible = false;
            base.Properties.Buttons.Add(bdel);
            base.Properties.ButtonClick += Properties_ButtonClick;
        }

        /// <summary>
        /// 标签按钮按下时触发事件
        /// </summary>
        [Description("标签按钮按下时触发事件"),
        Browsable(true),
        Category("Ultra")]
        public event EventHandler<ButtonPressedEventArgs> OnLabelClick;

        /// <summary>
        /// 详情按钮按下时触发事件
        /// </summary>
        [Description("详情按钮按下时触发事件"),
        Browsable(true),
        Category("Ultra")]
        public event EventHandler<ButtonPressedEventArgs> OnEllipsClick;

        void Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Caption == LabelButton.Caption)
            {
                this.SelectAll();
                if (null != OnLabelClick)
                    OnLabelClick(sender, e);
            }
            else if (e.Button.Kind == ButtonPredefines.Delete)
            {
                this.Text = string.Empty;
                this.EditValue = null;
                this.SelectAll();
            }
            else if (e.Button.Kind == ButtonPredefines.Ellipsis)
            {
                if (this.OnEllipsClick != null)
                    this.OnEllipsClick(sender, e);
            }
        }
        EditorButton LabelButton { get; set; }

        protected virtual string DefText { get; set; }

        int _DefWidth = 50;
        protected virtual int DefWidth { get { return _DefWidth; } set { _DefWidth = value; } }
    }

    public class FinNameGridEdit : EntityGridEditEx<UltraDbEntity.T_ERP_FinName>
    {
        public FinNameGridEdit() : base() { }

        protected override List<UltraDbEntity.T_ERP_FinName> GetData()
        {
            return SerNoCaller_GC.Calr_FinName.Get("where IsUsing=1");
        }
    }

}
