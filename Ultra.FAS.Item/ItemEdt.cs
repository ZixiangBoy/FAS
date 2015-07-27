using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ultra.Surface.Form;
using Ultra.Web.Core.Common;
using Ultra.CoreCaller;
using Ultra.Surface.Common;
using Ultra.FASControls.BusControls;
using Ultra.FASControls.Extend;
using Ultra.FASControls;
using Ultra.Win.Core.Common;
using System.Threading;

namespace Ultra.FAS.Item
{
    public partial class ItemEdt : DialogViewEx
    {
        public ItemEdt()
        {
            InitializeComponent();
        }

        private void ItemEdt_Load(object sender, EventArgs e)
        {
            InitPropData();
            SetEntData();
        }

        void SetEntData()
        {
            if (EditMode == Business.Core.Define.EnViewEditMode.Edit && Ent != null)
            {
                txtouterid.Properties.ReadOnly = txtouterskuid.Properties.ReadOnly = true;
                txtouterid.Text = Ent.OuterIid;
                txtouterskuid.Text = Ent.OuterSkuId;
                txtitemname.Text = Ent.ItemName;
                txtskuname.Text = Ent.SkuName;

                spframeprice.SetValue(Ent.FramePrice);
                sppackpostfee.SetValue(Ent.PackagePostFee);
                splen.SetValue(Ent.Length);
                spwid.SetValue(Ent.Width);
                sphei.SetValue(Ent.Height);
                sptSalePrice.SetValue(Ent.SalePrice);
                sptCostPrice.SetValue(Ent.CostPrice);

                spvolume.SetValue(Ent.Volume);
                spframevolume.SetValue(Ent.FrameVolume);
                spframepackpostfee.SetValue(Ent.FramePackagePostFee);

                sppackcount.EditValue = Ent.PackageCount;
                chkIsStoped.Checked = Ent.IsStoped;
                chkIsUsing.Checked = Ent.IsUsing;

                sgdl.SelectedValue = sgdl.DataSource.FirstOrDefault(k => k.StyleData == Ent.Category);
                sgfg.SelectedValue = sgfg.DataSource.FirstOrDefault(k => k.StyleData == Ent.Style);
                sggn.SelectedValue = sggn.DataSource.FirstOrDefault(k => k.StyleData == Ent.Func);
                sgfx.SelectedValue = sgfx.DataSource.FirstOrDefault(k => k.StyleData == Ent.Direction);
                sgys.SelectedValue = sgys.DataSource.FirstOrDefault(k => k.StyleData == Ent.Color);
                sgsize.SelectedValue = sgsize.DataSource.FirstOrDefault(k => k.StyleData == Ent.Size);
                sgcz.SelectedValue = sgcz.DataSource.FirstOrDefault(k => k.StyleData == Ent.Material);
                sgws.SelectedValue = sgws.DataSource.FirstOrDefault(k => k.StyleData == Ent.Seat);
                sgpl.SelectedValue = sgpl.DataSource.FirstOrDefault(k => k.StyleData == Ent.Surface);
                sgph.SelectedValue = sgph.DataSource.FirstOrDefault(k => k.StyleData == Ent.SurfaceNums);
                sgbl.SelectedValue = sgbl.DataSource.FirstOrDefault(k => k.StyleData == Ent.Textile);
                sgbh.SelectedValue = sgbh.DataSource.FirstOrDefault(k => k.StyleData == Ent.TextileNums);
                sgxl.SelectedValue = sgxl.DataSource.FirstOrDefault(k => k.StyleData == Ent.Series);
                sgfl.SelectedValue = sgfl.DataSource.FirstOrDefault(k => k.StyleData == Ent.Class);

            }
        }

        public UltraDbEntity.T_ERP_Item Ent { get; set; }
        public EFCaller<UltraDbEntity.T_ERP_Item> Calr { get; set; }

        void InitPropData()
        {
            var t = new Thread(() =>
            {
                this.Invoke(new MethodInvoker(() =>
                {
                    var styles = SerNoCaller_WL.Calr_ItemStyle.Get("select * from T_ERP_ItemStyle");
                    foreach (var ctl in tpstyle.Controls)
                    {
                        StyleGridEdit edt = ctl as StyleGridEdit;
                        if (null == edt) continue;
                        edt.SetData(styles.Where(j => j.StyleName == edt.LabelText).ToList());
                    }
                }));
            });
            t.IsBackground = true;
            t.Start();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!dxValidationProvider1.Validate()) return;
            switch (this.EditMode)
            {
                case Ultra.Business.Core.Define.EnViewEditMode.Edit:
                    {
                        Ent.OuterIid = txtouterid.Text;
                        Ent.OuterSkuId = txtouterskuid.Text;
                        Ent.ItemName = txtitemname.Text;
                        Ent.Updator = this.CurUser;
                        Ent.UpdateDate = TimeSync.Default.CurrentSyncTime;
                        Ent.FramePrice = spframeprice.Value;
                        Ent.PackagePostFee = sppackpostfee.Value;
                        Ent.Length = splen.Value;
                        Ent.Width = spwid.Value;
                        Ent.Height = sphei.Value;
                        Ent.Volume = spvolume.Value;
                        Ent.FrameVolume = spframevolume.Value;
                        Ent.FramePackagePostFee = spframepackpostfee.Value;
                        Ent.PackageCount = sppackcount.EditValue == null ? null : (int?)sppackcount.Value;

                        Ent.IsStoped = chkIsStoped.Checked;
                        Ent.IsUsing = chkIsUsing.Checked ;

                        Ent.Category = sgdl.SelectedValue == null ? string.Empty : sgdl.SelectedValue.StyleData;
                        Ent.Style = sgfg.SelectedValue == null ? string.Empty : sgfg.SelectedValue.StyleData;
                        Ent.Func = sggn.SelectedValue == null ? string.Empty : sggn.SelectedValue.StyleData;
                        Ent.Direction = sgfx.SelectedValue == null ? string.Empty : sgfx.SelectedValue.StyleData;
                        Ent.Color = sgys.SelectedValue == null ? string.Empty : sgys.SelectedValue.StyleData;
                        Ent.Material = sgcz.SelectedValue == null ? string.Empty : sgcz.SelectedValue.StyleData;
                        Ent.Seat = sgws.SelectedValue == null ? string.Empty : sgws.SelectedValue.StyleData;
                        Ent.Surface = sgpl.SelectedValue == null ? string.Empty : sgpl.SelectedValue.StyleData;
                        Ent.SurfaceNums = sgph.SelectedValue == null ? string.Empty : sgph.SelectedValue.StyleData;
                        Ent.Textile = sgbl.SelectedValue == null ? string.Empty : sgbl.SelectedValue.StyleData;
                        Ent.TextileNums = sgbh.SelectedValue == null ? string.Empty : sgbh.SelectedValue.StyleData;
                        Ent.Series = sgxl.SelectedValue == null ? string.Empty : sgxl.SelectedValue.StyleData;
                        Ent.Class = sgfl.SelectedValue == null ? string.Empty : sgfl.SelectedValue.StyleData;

                        Ent.SkuName = txtskuname.Text.Trim();
                        Ent.SkuProperties = Ent.GetSkuProperties();

                        Ent.SalePrice = sptSalePrice.Value;
                        Ent.CostPrice = sptCostPrice.Value;
                        var rd = Calr.Edt(Ent);
                        if (!rd.IsOK) { Ultra.Surface.Common.MsgBox.ShowMessage(string.Empty, rd.ErrMsg); return; }
                        DialogResult = System.Windows.Forms.DialogResult.OK;
                        Close();
                    }
                    break;
                case Ultra.Business.Core.Define.EnViewEditMode.New:
                    {
                        Ent = new UltraDbEntity.T_ERP_Item
                        {
                            Guid = Guid.NewGuid(),
                            IsAudit = false,
                            Remark = string.Empty,
                            Creator = this.CurUser,
                            Updator = this.CurUser,
                            Reserved1 = 0,
                            Reserved2 = string.Empty,
                            Reserved3 = false
                        };
                        Ent.OuterIid = txtouterid.Text;
                        Ent.OuterSkuId = txtouterskuid.Text;
                        Ent.ItemName = txtitemname.Text;

                        Ent.FramePrice = spframeprice.Value;
                        Ent.PackagePostFee = sppackpostfee.Value;
                        Ent.Length = splen.Value;
                        Ent.Width = spwid.Value;
                        Ent.Height = sphei.Value;
                        Ent.Volume = spvolume.Value;
                        Ent.FrameVolume = spframevolume.Value;
                        Ent.FramePackagePostFee = spframepackpostfee.Value;

                        Ent.IsStoped = chkIsStoped.Checked;
                        Ent.IsUsing = chkIsUsing.Checked;

                        Ent.Category = sgdl.SelectedValue == null ? string.Empty : sgdl.SelectedValue.StyleData;
                        Ent.Style = sgfg.SelectedValue == null ? string.Empty : sgfg.SelectedValue.StyleData;
                        Ent.Func = sggn.SelectedValue == null ? string.Empty : sggn.SelectedValue.StyleData;
                        Ent.Direction = sgfx.SelectedValue == null ? string.Empty : sgfx.SelectedValue.StyleData;
                        Ent.Color = sgys.SelectedValue == null ? string.Empty : sgys.SelectedValue.StyleData;
                        Ent.Material = sgcz.SelectedValue == null ? string.Empty : sgcz.SelectedValue.StyleData;
                        Ent.Seat = sgws.SelectedValue == null ? string.Empty : sgws.SelectedValue.StyleData;
                        Ent.Surface = sgpl.SelectedValue == null ? string.Empty : sgpl.SelectedValue.StyleData;
                        Ent.SurfaceNums = sgph.SelectedValue == null ? string.Empty : sgph.SelectedValue.StyleData;
                        Ent.Textile = sgbl.SelectedValue == null ? string.Empty : sgbl.SelectedValue.StyleData;
                        Ent.TextileNums = sgbh.SelectedValue == null ? string.Empty : sgbh.SelectedValue.StyleData;
                        Ent.Series = sgxl.SelectedValue == null ? string.Empty : sgxl.SelectedValue.StyleData;
                        Ent.Class = sgfl.SelectedValue == null ? string.Empty : sgfl.SelectedValue.StyleData;

                        Ent.SkuName = txtskuname.Text.Trim();
                        Ent.SkuProperties = Ent.GetSkuProperties();

                        Ent.IsAudit = true;

                        var rd = Calr.Add(Ent);
                        if (!rd.IsOK)
                        {
                            MsgBox.ShowErrMsg(rd.ErrMsg);
                            return;
                        }
                        DialogResult = System.Windows.Forms.DialogResult.OK;
                        Close(); return;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
