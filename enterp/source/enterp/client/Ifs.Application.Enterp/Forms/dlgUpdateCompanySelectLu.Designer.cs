#region Copyright (c) IFS Research & Development
// ======================================================================================================
//
//                 IFS Research & Development
//
//  This program is protected by copyright law and by international
//  conventions. All licensing, renting, lending or copying (including
//  for private use), and all other use of the program, which is not
//  explicitly permitted by IFS, is a violation of the rights
//  of IFS. Such violations will be reported to the
//  appropriate authorities.
//
//  VIOLATIONS OF ANY COPYRIGHT IS PUNISHABLE BY LAW AND CAN LEAD
//  TO UP TO TWO YEARS OF IMPRISONMENT AND LIABILITY TO PAY DAMAGES.
// ======================================================================================================
#endregion
#region History
#endregion

using System;
using System.Text;
using System.Drawing;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel;
using Ifs.Application.Appsrv;
using Ifs.Fnd.ApplicationForms;
using PPJ.Runtime;
using PPJ.Runtime.Sql;
using PPJ.Runtime.Vis;
using PPJ.Runtime.Windows;
using PPJ.Runtime.Windows.QO;

namespace Ifs.Application.Enterp
{
	
	public partial class dlgUpdateCompanySelectLu
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cPushButton pbOk;
		public cPushButton pbCancel;
		public cPushButton pbSave;
		protected cBackgroundText labeldfCompany;
		public cDataField dfCompany;
		public cDataField dfDescription;
		public cPushButton pbSelectAll;
		public cPushButton pbUnselectAll;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgUpdateCompanySelectLu));
            this.pbOk = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbCancel = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbSave = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.labeldfCompany = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfCompany = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfDescription = new Ifs.Fnd.ApplicationForms.cDataField();
            this.pbSelectAll = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbUnselectAll = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.tblUpdateCompanySelectLu = new Ifs.Application.Enterp.cChildTableEntBase();
            this.tblUpdateCompanySelectLu_colsUpdateId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblUpdateCompanySelectLu_colsModule = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblUpdateCompanySelectLu_colsLu = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblUpdateCompanySelectLu_colAccountRelated = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.tblUpdateCompanySelectLu_colSelected = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.ClientArea.SuspendLayout();
            this.tblUpdateCompanySelectLu.SuspendLayout();
            this.SuspendLayout();
            // 
            // ClientArea
            // 
            this.ClientArea.Controls.Add(this.pbUnselectAll);
            this.ClientArea.Controls.Add(this.pbSelectAll);
            this.ClientArea.Controls.Add(this.dfDescription);
            this.ClientArea.Controls.Add(this.dfCompany);
            this.ClientArea.Controls.Add(this.tblUpdateCompanySelectLu);
            this.ClientArea.Controls.Add(this.pbSave);
            this.ClientArea.Controls.Add(this.pbCancel);
            this.ClientArea.Controls.Add(this.pbOk);
            this.ClientArea.Controls.Add(this.labeldfCompany);
            resources.ApplyResources(this.ClientArea, "ClientArea");
            // 
            // commandManager
            // 
            this.commandManager.Components.Add(this.pbUnselectAll);
            this.commandManager.Components.Add(this.pbSelectAll);
            this.commandManager.Components.Add(this.pbSave);
            this.commandManager.Components.Add(this.pbCancel);
            this.commandManager.Components.Add(this.pbOk);
            // 
            // pbOk
            // 
            this.pbOk.AcceleratorKey = System.Windows.Forms.Keys.Return;
            resources.ApplyResources(this.pbOk, "pbOk");
            this.pbOk.Name = "pbOk";
            this.pbOk.NamedProperties.Put("MethodId", "18385");
            this.pbOk.NamedProperties.Put("MethodParameter", "OkButton");
            this.pbOk.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // pbCancel
            // 
            this.pbCancel.AcceleratorKey = System.Windows.Forms.Keys.Escape;
            resources.ApplyResources(this.pbCancel, "pbCancel");
            this.pbCancel.Name = "pbCancel";
            this.pbCancel.NamedProperties.Put("MethodId", "18385");
            this.pbCancel.NamedProperties.Put("MethodParameter", "CancelButton");
            this.pbCancel.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // pbSave
            // 
            resources.ApplyResources(this.pbSave, "pbSave");
            this.pbSave.Name = "pbSave";
            this.pbSave.NamedProperties.Put("MethodId", "18385");
            this.pbSave.NamedProperties.Put("MethodParameter", "SaveButton");
            this.pbSave.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // labeldfCompany
            // 
            resources.ApplyResources(this.labeldfCompany, "labeldfCompany");
            this.labeldfCompany.Name = "labeldfCompany";
            // 
            // dfCompany
            // 
            resources.ApplyResources(this.dfCompany, "dfCompany");
            this.dfCompany.Name = "dfCompany";
            // 
            // dfDescription
            // 
            resources.ApplyResources(this.dfDescription, "dfDescription");
            this.dfDescription.Name = "dfDescription";
            // 
            // pbSelectAll
            // 
            resources.ApplyResources(this.pbSelectAll, "pbSelectAll");
            this.pbSelectAll.Name = "pbSelectAll";
            this.pbSelectAll.NamedProperties.Put("MethodId", "18385");
            this.pbSelectAll.NamedProperties.Put("MethodParameter", "SelectAll");
            this.pbSelectAll.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // pbUnselectAll
            // 
            resources.ApplyResources(this.pbUnselectAll, "pbUnselectAll");
            this.pbUnselectAll.Name = "pbUnselectAll";
            this.pbUnselectAll.NamedProperties.Put("MethodId", "18385");
            this.pbUnselectAll.NamedProperties.Put("MethodParameter", "UnSelectAll");
            this.pbUnselectAll.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // tblUpdateCompanySelectLu
            // 
            this.tblUpdateCompanySelectLu.Controls.Add(this.tblUpdateCompanySelectLu_colsUpdateId);
            this.tblUpdateCompanySelectLu.Controls.Add(this.tblUpdateCompanySelectLu_colsModule);
            this.tblUpdateCompanySelectLu.Controls.Add(this.tblUpdateCompanySelectLu_colsLu);
            this.tblUpdateCompanySelectLu.Controls.Add(this.tblUpdateCompanySelectLu_colAccountRelated);
            this.tblUpdateCompanySelectLu.Controls.Add(this.tblUpdateCompanySelectLu_colSelected);
            resources.ApplyResources(this.tblUpdateCompanySelectLu, "tblUpdateCompanySelectLu");
            this.tblUpdateCompanySelectLu.Name = "tblUpdateCompanySelectLu";
            this.tblUpdateCompanySelectLu.NamedProperties.Put("DefaultOrderBy", "");
            this.tblUpdateCompanySelectLu.NamedProperties.Put("DefaultWhere", "UPDATE_ID = :i_hWndFrame.dlgUpdateCompanySelectLu.sCurrentUpdateId");
            this.tblUpdateCompanySelectLu.NamedProperties.Put("LogicalUnit", "UpdateCompanySelectLu");
            this.tblUpdateCompanySelectLu.NamedProperties.Put("PackageName", "UPDATE_COMPANY_SELECT_LU_API");
            this.tblUpdateCompanySelectLu.NamedProperties.Put("ResizeableChildObject", "");
            this.tblUpdateCompanySelectLu.NamedProperties.Put("SourceFlags", "129");
            this.tblUpdateCompanySelectLu.NamedProperties.Put("ViewName", "UPDATE_COMPANY_SELECT_LU_CL");
            this.tblUpdateCompanySelectLu.NamedProperties.Put("Warnings", "FALSE");
            this.tblUpdateCompanySelectLu.FrameStartupUserEvent += new System.EventHandler<Ifs.Fnd.ApplicationForms.FndReturnEventArgsSalBoolean>(this.tblUpdateCompanySelectLu_FrameStartupUserEvent);
            this.tblUpdateCompanySelectLu.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblUpdateCompanySelectLu_WindowActions);
            this.tblUpdateCompanySelectLu.Controls.SetChildIndex(this.tblUpdateCompanySelectLu_colSelected, 0);
            this.tblUpdateCompanySelectLu.Controls.SetChildIndex(this.tblUpdateCompanySelectLu_colAccountRelated, 0);
            this.tblUpdateCompanySelectLu.Controls.SetChildIndex(this.tblUpdateCompanySelectLu_colsLu, 0);
            this.tblUpdateCompanySelectLu.Controls.SetChildIndex(this.tblUpdateCompanySelectLu_colsModule, 0);
            this.tblUpdateCompanySelectLu.Controls.SetChildIndex(this.tblUpdateCompanySelectLu_colsUpdateId, 0);
            // 
            // tblUpdateCompanySelectLu_colsUpdateId
            // 
            resources.ApplyResources(this.tblUpdateCompanySelectLu_colsUpdateId, "tblUpdateCompanySelectLu_colsUpdateId");
            this.tblUpdateCompanySelectLu_colsUpdateId.MaxLength = 30;
            this.tblUpdateCompanySelectLu_colsUpdateId.Name = "tblUpdateCompanySelectLu_colsUpdateId";
            this.tblUpdateCompanySelectLu_colsUpdateId.NamedProperties.Put("EnumerateMethod", "");
            this.tblUpdateCompanySelectLu_colsUpdateId.NamedProperties.Put("FieldFlags", "131");
            this.tblUpdateCompanySelectLu_colsUpdateId.NamedProperties.Put("LovReference", "");
            this.tblUpdateCompanySelectLu_colsUpdateId.NamedProperties.Put("ResizeableChildObject", "");
            this.tblUpdateCompanySelectLu_colsUpdateId.NamedProperties.Put("SqlColumn", "UPDATE_ID");
            this.tblUpdateCompanySelectLu_colsUpdateId.NamedProperties.Put("ValidateMethod", "");
            this.tblUpdateCompanySelectLu_colsUpdateId.Position = 3;
            // 
            // tblUpdateCompanySelectLu_colsModule
            // 
            this.tblUpdateCompanySelectLu_colsModule.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblUpdateCompanySelectLu_colsModule.MaxLength = 6;
            this.tblUpdateCompanySelectLu_colsModule.Name = "tblUpdateCompanySelectLu_colsModule";
            this.tblUpdateCompanySelectLu_colsModule.NamedProperties.Put("EnumerateMethod", "");
            this.tblUpdateCompanySelectLu_colsModule.NamedProperties.Put("FieldFlags", "163");
            this.tblUpdateCompanySelectLu_colsModule.NamedProperties.Put("LovReference", "");
            this.tblUpdateCompanySelectLu_colsModule.NamedProperties.Put("SqlColumn", "MODULE");
            this.tblUpdateCompanySelectLu_colsModule.Position = 4;
            resources.ApplyResources(this.tblUpdateCompanySelectLu_colsModule, "tblUpdateCompanySelectLu_colsModule");
            // 
            // tblUpdateCompanySelectLu_colsLu
            // 
            this.tblUpdateCompanySelectLu_colsLu.MaxLength = 30;
            this.tblUpdateCompanySelectLu_colsLu.Name = "tblUpdateCompanySelectLu_colsLu";
            this.tblUpdateCompanySelectLu_colsLu.NamedProperties.Put("EnumerateMethod", "");
            this.tblUpdateCompanySelectLu_colsLu.NamedProperties.Put("FieldFlags", "163");
            this.tblUpdateCompanySelectLu_colsLu.NamedProperties.Put("LovReference", "");
            this.tblUpdateCompanySelectLu_colsLu.NamedProperties.Put("SqlColumn", "LU");
            this.tblUpdateCompanySelectLu_colsLu.Position = 5;
            resources.ApplyResources(this.tblUpdateCompanySelectLu_colsLu, "tblUpdateCompanySelectLu_colsLu");
            // 
            // tblUpdateCompanySelectLu_colAccountRelated
            // 
            this.tblUpdateCompanySelectLu_colAccountRelated.Name = "tblUpdateCompanySelectLu_colAccountRelated";
            this.tblUpdateCompanySelectLu_colAccountRelated.NamedProperties.Put("EnumerateMethod", "");
            this.tblUpdateCompanySelectLu_colAccountRelated.NamedProperties.Put("FieldFlags", "288");
            this.tblUpdateCompanySelectLu_colAccountRelated.NamedProperties.Put("LovReference", "");
            this.tblUpdateCompanySelectLu_colAccountRelated.NamedProperties.Put("SqlColumn", "ACCOUNT_RELATED");
            this.tblUpdateCompanySelectLu_colAccountRelated.Position = 6;
            resources.ApplyResources(this.tblUpdateCompanySelectLu_colAccountRelated, "tblUpdateCompanySelectLu_colAccountRelated");
            // 
            // tblUpdateCompanySelectLu_colSelected
            // 
            this.tblUpdateCompanySelectLu_colSelected.Name = "tblUpdateCompanySelectLu_colSelected";
            this.tblUpdateCompanySelectLu_colSelected.NamedProperties.Put("EnumerateMethod", "");
            this.tblUpdateCompanySelectLu_colSelected.NamedProperties.Put("FieldFlags", "295");
            this.tblUpdateCompanySelectLu_colSelected.NamedProperties.Put("LovReference", "");
            this.tblUpdateCompanySelectLu_colSelected.NamedProperties.Put("SqlColumn", "SELECTED");
            this.tblUpdateCompanySelectLu_colSelected.Position = 7;
            resources.ApplyResources(this.tblUpdateCompanySelectLu_colSelected, "tblUpdateCompanySelectLu_colSelected");
            this.tblUpdateCompanySelectLu_colSelected.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colSelected_WindowActions);
            // 
            // dlgUpdateCompanySelectLu
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "dlgUpdateCompanySelectLu";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "CreateCompanyTem");
            this.NamedProperties.Put("PackageName", "CREATE_COMPANY_TEM_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("ViewName", "CREATE_COMPANY_TEM");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.ShowIcon = false;
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dlgUpdateCompanySelectLu_WindowActions);
            this.ClientArea.ResumeLayout(false);
            this.ClientArea.PerformLayout();
            this.tblUpdateCompanySelectLu.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion
		
		#region System Methods/Properties
		
		/// <summary>
		/// Release global reference.
		/// </summary>
		/// <param name="disposing"></param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null)) 
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}
		#endregion

        public cChildTableEntBase tblUpdateCompanySelectLu;
        protected cColumn tblUpdateCompanySelectLu_colsUpdateId;
        protected cColumn tblUpdateCompanySelectLu_colsModule;
        protected cColumn tblUpdateCompanySelectLu_colsLu;
        protected cCheckBoxColumn tblUpdateCompanySelectLu_colAccountRelated;
        protected cCheckBoxColumn tblUpdateCompanySelectLu_colSelected;
		
	}
}
