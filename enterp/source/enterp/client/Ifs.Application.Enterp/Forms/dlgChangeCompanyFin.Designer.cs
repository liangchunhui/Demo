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
	
	public partial class dlgChangeCompanyFin
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cPushButton pbOk;
		public cPushButton pbCancel;
		public cPushButton pbDefault;
		protected cBackgroundText labeldfsCompany;
		public cDataField dfsCompany;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgChangeCompanyFin));
            this.pbOk = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbCancel = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbDefault = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.labeldfsCompany = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsCompany = new Ifs.Fnd.ApplicationForms.cDataField();
            this.tblChangeCompany = new Ifs.Application.Enterp.cChildTableEntBase();
            this.tblChangeCompany_colsCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblChangeCompany_colsDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblChangeCompany_colsSelectGlobal = new Ifs.Fnd.ApplicationForms.cColumn();
            this.ClientArea.SuspendLayout();
            this.tblChangeCompany.SuspendLayout();
            this.SuspendLayout();
            // 
            // ClientArea
            // 
            this.ClientArea.Controls.Add(this.tblChangeCompany);
            this.ClientArea.Controls.Add(this.dfsCompany);
            this.ClientArea.Controls.Add(this.pbDefault);
            this.ClientArea.Controls.Add(this.pbCancel);
            this.ClientArea.Controls.Add(this.pbOk);
            this.ClientArea.Controls.Add(this.labeldfsCompany);
            resources.ApplyResources(this.ClientArea, "ClientArea");
            // 
            // StatusBar
            // 
            resources.ApplyResources(this.StatusBar, "StatusBar");
            // 
            // commandManager
            // 
            this.commandManager.Components.Add(this.pbDefault);
            this.commandManager.Components.Add(this.pbCancel);
            this.commandManager.Components.Add(this.pbOk);
            // 
            // pbOk
            // 
            this.pbOk.AcceleratorKey = System.Windows.Forms.Keys.Return;
            resources.ApplyResources(this.pbOk, "pbOk");
            this.pbOk.Name = "pbOk";
            this.pbOk.NamedProperties.Put("MethodId", "18385");
            this.pbOk.NamedProperties.Put("MethodParameter", "Ok");
            this.pbOk.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // pbCancel
            // 
            this.pbCancel.AcceleratorKey = System.Windows.Forms.Keys.Escape;
            resources.ApplyResources(this.pbCancel, "pbCancel");
            this.pbCancel.Name = "pbCancel";
            this.pbCancel.NamedProperties.Put("MethodId", "18385");
            this.pbCancel.NamedProperties.Put("MethodParameter", "Cancel");
            this.pbCancel.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // pbDefault
            // 
            resources.ApplyResources(this.pbDefault, "pbDefault");
            this.pbDefault.Name = "pbDefault";
            this.pbDefault.NamedProperties.Put("MethodId", "18385");
            this.pbDefault.NamedProperties.Put("MethodParameter", "Default");
            this.pbDefault.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // labeldfsCompany
            // 
            resources.ApplyResources(this.labeldfsCompany, "labeldfsCompany");
            this.labeldfsCompany.Name = "labeldfsCompany";
            // 
            // dfsCompany
            // 
            resources.ApplyResources(this.dfsCompany, "dfsCompany");
            this.dfsCompany.Name = "dfsCompany";
            this.dfsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCompany.NamedProperties.Put("LovReference", "");
            this.dfsCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsCompany.NamedProperties.Put("SqlColumn", "");
            this.dfsCompany.NamedProperties.Put("ValidateMethod", "");
            // 
            // tblChangeCompany
            // 
            resources.ApplyResources(this.tblChangeCompany, "tblChangeCompany");
            this.tblChangeCompany.Controls.Add(this.tblChangeCompany_colsCompany);
            this.tblChangeCompany.Controls.Add(this.tblChangeCompany_colsDescription);
            this.tblChangeCompany.Controls.Add(this.tblChangeCompany_colsSelectGlobal);
            this.tblChangeCompany.Name = "tblChangeCompany";
            this.tblChangeCompany.NamedProperties.Put("DefaultOrderBy", "COMPANY");
            this.tblChangeCompany.NamedProperties.Put("DefaultWhere", "");
            this.tblChangeCompany.NamedProperties.Put("LogicalUnit", "CompanyFinance");
            this.tblChangeCompany.NamedProperties.Put("PackageName", "COMPANY_FINANCE_API");
            this.tblChangeCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.tblChangeCompany.NamedProperties.Put("SourceFlags", "448");
            this.tblChangeCompany.NamedProperties.Put("ViewName", "COMPANY_FINANCE");
            this.tblChangeCompany.NamedProperties.Put("Warnings", "FALSE");
            this.tblChangeCompany.Controls.SetChildIndex(this.tblChangeCompany_colsSelectGlobal, 0);
            this.tblChangeCompany.Controls.SetChildIndex(this.tblChangeCompany_colsDescription, 0);
            this.tblChangeCompany.Controls.SetChildIndex(this.tblChangeCompany_colsCompany, 0);
            // 
            // tblChangeCompany_colsCompany
            // 
            this.tblChangeCompany_colsCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblChangeCompany_colsCompany.MaxLength = 20;
            this.tblChangeCompany_colsCompany.Name = "tblChangeCompany_colsCompany";
            this.tblChangeCompany_colsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.tblChangeCompany_colsCompany.NamedProperties.Put("FieldFlags", "160");
            this.tblChangeCompany_colsCompany.NamedProperties.Put("LovReference", "");
            this.tblChangeCompany_colsCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.tblChangeCompany_colsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.tblChangeCompany_colsCompany.NamedProperties.Put("ValidateMethod", "");
            this.tblChangeCompany_colsCompany.Position = 3;
            resources.ApplyResources(this.tblChangeCompany_colsCompany, "tblChangeCompany_colsCompany");
            // 
            // tblChangeCompany_colsDescription
            // 
            this.tblChangeCompany_colsDescription.Name = "tblChangeCompany_colsDescription";
            this.tblChangeCompany_colsDescription.NamedProperties.Put("EnumerateMethod", "");
            this.tblChangeCompany_colsDescription.NamedProperties.Put("FieldFlags", "288");
            this.tblChangeCompany_colsDescription.NamedProperties.Put("LovReference", "");
            this.tblChangeCompany_colsDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.tblChangeCompany_colsDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.tblChangeCompany_colsDescription.NamedProperties.Put("ValidateMethod", "");
            this.tblChangeCompany_colsDescription.Position = 4;
            resources.ApplyResources(this.tblChangeCompany_colsDescription, "tblChangeCompany_colsDescription");
            // 
            // tblChangeCompany_colsSelectGlobal
            // 
            this.tblChangeCompany_colsSelectGlobal.CellType = PPJ.Runtime.Windows.CellType.CheckBox;
            this.tblChangeCompany_colsSelectGlobal.CheckBox.CheckedValue = "TRUE";
            this.tblChangeCompany_colsSelectGlobal.CheckBox.IgnoreCase = true;
            this.tblChangeCompany_colsSelectGlobal.CheckBox.UncheckedValue = "FALSE";
            this.tblChangeCompany_colsSelectGlobal.Name = "tblChangeCompany_colsSelectGlobal";
            this.tblChangeCompany_colsSelectGlobal.NamedProperties.Put("EnumerateMethod", "");
            this.tblChangeCompany_colsSelectGlobal.NamedProperties.Put("LovReference", "");
            this.tblChangeCompany_colsSelectGlobal.NamedProperties.Put("ResizeableChildObject", "");
            this.tblChangeCompany_colsSelectGlobal.NamedProperties.Put("SqlColumn", "");
            this.tblChangeCompany_colsSelectGlobal.NamedProperties.Put("ValidateMethod", "");
            this.tblChangeCompany_colsSelectGlobal.Position = 5;
            resources.ApplyResources(this.tblChangeCompany_colsSelectGlobal, "tblChangeCompany_colsSelectGlobal");
            this.tblChangeCompany_colsSelectGlobal.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsSelectGlobal_WindowActions);
            // 
            // dlgChangeCompanyFin
            // 
            resources.ApplyResources(this, "$this");
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "dlgChangeCompanyFin";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "");
            this.NamedProperties.Put("PackageName", "");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("ViewName", "");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.ShowIcon = false;
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dlgChangeCompanyFin_WindowActions);
            this.ClientArea.ResumeLayout(false);
            this.ClientArea.PerformLayout();
            this.tblChangeCompany.ResumeLayout(false);
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

        public cChildTableEntBase tblChangeCompany;
        protected cColumn tblChangeCompany_colsCompany;
        protected cColumn tblChangeCompany_colsDescription;
        protected cColumn tblChangeCompany_colsSelectGlobal;
		
	}
}
