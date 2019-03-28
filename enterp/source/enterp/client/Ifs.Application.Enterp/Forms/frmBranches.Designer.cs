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
	
	public partial class frmBranches
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		protected cBackgroundText labelcmbsCompany;
		public cRecListDataField cmbsCompany;
		protected cBackgroundText labeldfsName;
		public cDataField dfsName;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBranches));
            this.menuTblMethods_menu_Delivery_Note_Number_Series___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.labelcmbsCompany = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbsCompany = new Ifs.Fnd.ApplicationForms.cRecListDataField();
            this.labeldfsName = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsName = new Ifs.Fnd.ApplicationForms.cDataField();
            this.menuTblMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem__Delivery = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.tblBranches = new Ifs.Application.Enterp.cChildTableEntBase();
            this.tblBranches_colsCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblBranches_colsBranch = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblBranches_colsBranchDesc = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblBranches_colsCompanyAddressId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuTblMethods.SuspendLayout();
            this.tblBranches.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuTblMethods_menu_Delivery_Note_Number_Series___);
            this.commandManager.ContextMenus.Add(this.menuTblMethods);
            // 
            // menuTblMethods_menu_Delivery_Note_Number_Series___
            // 
            resources.ApplyResources(this.menuTblMethods_menu_Delivery_Note_Number_Series___, "menuTblMethods_menu_Delivery_Note_Number_Series___");
            this.menuTblMethods_menu_Delivery_Note_Number_Series___.Name = "menuTblMethods_menu_Delivery_Note_Number_Series___";
            this.menuTblMethods_menu_Delivery_Note_Number_Series___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Delivery_Execute);
            this.menuTblMethods_menu_Delivery_Note_Number_Series___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Delivery_Inquire);
            // 
            // labelcmbsCompany
            // 
            resources.ApplyResources(this.labelcmbsCompany, "labelcmbsCompany");
            this.labelcmbsCompany.Name = "labelcmbsCompany";
            // 
            // cmbsCompany
            // 
            resources.ApplyResources(this.cmbsCompany, "cmbsCompany");
            this.cmbsCompany.Name = "cmbsCompany";
            this.cmbsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.cmbsCompany.NamedProperties.Put("FieldFlags", "160");
            this.cmbsCompany.NamedProperties.Put("LovReference", "");
            this.cmbsCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.cmbsCompany.NamedProperties.Put("ValidateMethod", "");
            this.cmbsCompany.NamedProperties.Put("XDataLength", "");
            // 
            // labeldfsName
            // 
            resources.ApplyResources(this.labeldfsName, "labeldfsName");
            this.labeldfsName.Name = "labeldfsName";
            // 
            // dfsName
            // 
            resources.ApplyResources(this.dfsName, "dfsName");
            this.dfsName.Name = "dfsName";
            this.dfsName.NamedProperties.Put("EnumerateMethod", "");
            this.dfsName.NamedProperties.Put("LovReference", "");
            this.dfsName.NamedProperties.Put("ResizeableChildObject", "LLML");
            this.dfsName.NamedProperties.Put("SqlColumn", "NAME");
            this.dfsName.NamedProperties.Put("ValidateMethod", "");
            // 
            // menuTblMethods
            // 
            this.menuTblMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem__Delivery});
            this.menuTblMethods.Name = "menuTblMethods";
            resources.ApplyResources(this.menuTblMethods, "menuTblMethods");
            // 
            // menuItem__Delivery
            // 
            this.menuItem__Delivery.Command = this.menuTblMethods_menu_Delivery_Note_Number_Series___;
            this.menuItem__Delivery.Name = "menuItem__Delivery";
            resources.ApplyResources(this.menuItem__Delivery, "menuItem__Delivery");
            this.menuItem__Delivery.Text = "&Delivery Note Number Series...";
            // 
            // tblBranches
            // 
            this.tblBranches.Controls.Add(this.tblBranches_colsCompany);
            this.tblBranches.Controls.Add(this.tblBranches_colsBranch);
            this.tblBranches.Controls.Add(this.tblBranches_colsBranchDesc);
            this.tblBranches.Controls.Add(this.tblBranches_colsCompanyAddressId);
            resources.ApplyResources(this.tblBranches, "tblBranches");
            this.tblBranches.Name = "tblBranches";
            this.tblBranches.NamedProperties.Put("DefaultOrderBy", "");
            this.tblBranches.NamedProperties.Put("DefaultWhere", "");
            this.tblBranches.NamedProperties.Put("LogicalUnit", "Branch");
            this.tblBranches.NamedProperties.Put("PackageName", "BRANCH_API");
            this.tblBranches.NamedProperties.Put("ResizeableChildObject", "LLMM");
            this.tblBranches.NamedProperties.Put("ViewName", "BRANCH");
            this.tblBranches.NamedProperties.Put("Warnings", "FALSE");
            this.tblBranches.UserMethodEvent += new Ifs.Fnd.ApplicationForms.cMethodManager.UserMethodEventHandler(this.tblBranches_UserMethodEvent);
            this.tblBranches.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblBranches_WindowActions);
            this.tblBranches.Controls.SetChildIndex(this.tblBranches_colsCompanyAddressId, 0);
            this.tblBranches.Controls.SetChildIndex(this.tblBranches_colsBranchDesc, 0);
            this.tblBranches.Controls.SetChildIndex(this.tblBranches_colsBranch, 0);
            this.tblBranches.Controls.SetChildIndex(this.tblBranches_colsCompany, 0);
            // 
            // tblBranches_colsCompany
            // 
            this.tblBranches_colsCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblBranches_colsCompany, "tblBranches_colsCompany");
            this.tblBranches_colsCompany.MaxLength = 20;
            this.tblBranches_colsCompany.Name = "tblBranches_colsCompany";
            this.tblBranches_colsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.tblBranches_colsCompany.NamedProperties.Put("FieldFlags", "67");
            this.tblBranches_colsCompany.NamedProperties.Put("LovReference", "COMPANY");
            this.tblBranches_colsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.tblBranches_colsCompany.Position = 3;
            // 
            // tblBranches_colsBranch
            // 
            this.tblBranches_colsBranch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblBranches_colsBranch.MaxLength = 20;
            this.tblBranches_colsBranch.Name = "tblBranches_colsBranch";
            this.tblBranches_colsBranch.NamedProperties.Put("EnumerateMethod", "");
            this.tblBranches_colsBranch.NamedProperties.Put("FieldFlags", "163");
            this.tblBranches_colsBranch.NamedProperties.Put("LovReference", "");
            this.tblBranches_colsBranch.NamedProperties.Put("SqlColumn", "BRANCH");
            this.tblBranches_colsBranch.Position = 4;
            resources.ApplyResources(this.tblBranches_colsBranch, "tblBranches_colsBranch");
            // 
            // tblBranches_colsBranchDesc
            // 
            this.tblBranches_colsBranchDesc.MaxLength = 200;
            this.tblBranches_colsBranchDesc.Name = "tblBranches_colsBranchDesc";
            this.tblBranches_colsBranchDesc.NamedProperties.Put("EnumerateMethod", "");
            this.tblBranches_colsBranchDesc.NamedProperties.Put("FieldFlags", "295");
            this.tblBranches_colsBranchDesc.NamedProperties.Put("LovReference", "");
            this.tblBranches_colsBranchDesc.NamedProperties.Put("SqlColumn", "BRANCH_DESC");
            this.tblBranches_colsBranchDesc.NamedProperties.Put("ValidateMethod", "");
            this.tblBranches_colsBranchDesc.Position = 5;
            resources.ApplyResources(this.tblBranches_colsBranchDesc, "tblBranches_colsBranchDesc");
            // 
            // tblBranches_colsCompanyAddressId
            // 
            this.tblBranches_colsCompanyAddressId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblBranches_colsCompanyAddressId.MaxLength = 50;
            this.tblBranches_colsCompanyAddressId.Name = "tblBranches_colsCompanyAddressId";
            this.tblBranches_colsCompanyAddressId.NamedProperties.Put("EnumerateMethod", "");
            this.tblBranches_colsCompanyAddressId.NamedProperties.Put("FieldFlags", "294");
            this.tblBranches_colsCompanyAddressId.NamedProperties.Put("LovReference", "COMPANY_DOC_ADDRESS_LOV_PUB(COMPANY)");
            this.tblBranches_colsCompanyAddressId.NamedProperties.Put("SqlColumn", "COMPANY_ADDRESS_ID");
            this.tblBranches_colsCompanyAddressId.Position = 6;
            resources.ApplyResources(this.tblBranches_colsCompanyAddressId, "tblBranches_colsCompanyAddressId");
            this.tblBranches_colsCompanyAddressId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblBranches_colsCompanyAddressId_WindowActions);
            // 
            // frmBranches
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.tblBranches);
            this.Controls.Add(this.dfsName);
            this.Controls.Add(this.cmbsCompany);
            this.Controls.Add(this.labeldfsName);
            this.Controls.Add(this.labelcmbsCompany);
            this.Name = "frmBranches";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "Company");
            this.NamedProperties.Put("PackageName", "COMPANY_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "1");
            this.NamedProperties.Put("ViewName", "COMPANY");
            this.NamedProperties.Put("Warnings", "TRUE");
            this.menuTblMethods.ResumeLayout(false);
            this.tblBranches.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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

        public Fnd.Windows.Forms.FndCommand menuTblMethods_menu_Delivery_Note_Number_Series___;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTblMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Delivery;
        public cChildTableEntBase tblBranches;
        protected cColumn tblBranches_colsCompany;
        protected cColumn tblBranches_colsBranch;
        protected cColumn tblBranches_colsBranchDesc;
        protected cColumn tblBranches_colsCompanyAddressId;
	}
}
