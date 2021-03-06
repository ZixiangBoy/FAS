﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ultra.Surface.Common;
using Ultra.Surface.Form;
using Ultra.Surface.Interfaces;
using Ultra.Surface.Lanuch;
using Ultra.FASControls;
using Ultra.FASControls.Extend;

namespace FAS.User {
    public partial class MainView : MainSurface, ISurfacePermission {
        public MainView() {
            InitializeComponent();
        }


        public List<DevExpress.XtraBars.BarButtonItem> ToolBarItems {
            get {
                return new List<DevExpress.XtraBars.BarButtonItem> { 
                this.barBtnNew,this.barBtnEdt
            };
            }
        }

        public List<Control> ButtonItems {
            get { return null; }
        }

        public List<Control> MenuItems {
            get { return null; }
        }

        public List<PermitGridView> Grids {
            get {
                return new List<PermitGridView> { 
                new PermitGridView(this.gridView1,"用户列表")
            };
            }
        }

        public List<Ultra.Surface.Form.BaseSurface> DialogForms {
            get { return null; }
        }



        void DbgSet() {
#if DEBUG
            //this.barBtnNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            //this.barBtnEdt.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            //this.barBtnDel.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
#endif
        }

        private void MainView_Load(object sender, EventArgs e) {
            //Lgc = new Logic(ConnString);
            //DbgSet();

            this.barBtnRefresh.ItemClick += barBtnRefresh_ItemClick;
            this.barBtnNew.ItemClick += barBtnNew_ItemClick;
            this.barBtnEdt.ItemClick += barBtnEdt_ItemClick;
            //this.barBtnDel.ItemClick += barBtnDel_ItemClick;
        }


        void barBtnDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            //var et = gridView1.GetFocusedDataSource<UltraDbEntity.T_ERP_User>();
            //if (null == et) return;
            //if (MsgBox.ShowYesNoMessage("删除确认", "确定要删除该项吗?") == System.Windows.Forms.DialogResult.Yes)
            //{
            //    Lgc.Del(et);
            //    barBtnRefresh_ItemClick(null, null);
            //}
        }

        void barBtnEdt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var et = gridView1.GetFocusedDataSource<UltraDbEntity.T_ERP_User>();
            if (null == et) return;
            var vw = new EdtView();
            //vw.Lgc = Lgc;
            vw.EditMode = Ultra.Business.Core.Define.EnViewEditMode.Edit;
            vw.Entity = et;
            InitView(vw);
            if (vw.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                gridControlEx1.RefreshDataSource();
            }
        }

        void barBtnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            this.gridControlEx1.DataSource = SerNoCaller.Calr_User.Get();
        }

        void barBtnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            var vw = new EdtView();
            //vw.Lgc = Lgc;
            vw.EditMode = Ultra.Business.Core.Define.EnViewEditMode.New;
            InitView(vw);
            if (vw.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                var et = vw.Entity;
                if (null != et) {
                    var d = gridControlEx1.GetDataSource<UltraDbEntity.T_ERP_User>();
                    d = d ?? new List<UltraDbEntity.T_ERP_User>();
                    d.Insert(0, et);
                    gridControlEx1.DataSource = d;
                    gridControlEx1.RefreshDataSource();
                }
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) {
            var et = gridControlEx1.GetFocusedDataSource<UltraDbEntity.T_ERP_User>();
            if (null == et) {
                gridControlEx2.DataSource = null; return;
            }
            gridControlEx2.DataSource = SerNoCaller.Calr_RoleUser.Get("where UserName=@0", et.UserName);
        }
    }
}
