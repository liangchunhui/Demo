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
// Date     By      Notes
// -----    ------  ---------------------------------------------------------------------------------
// 120913   MaRalk  PBR-446, Added labeldfsCategory, dfsCategory, labeldfsNewCategory, cmbNewCustomerCategory to represent the customer category.
// 120928   MaRalk  PBR-508, Added window actions to the cmbNewCustomerCategory field.
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
	
	public partial class dlgCopyCustomer
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		protected cBackgroundText labeldfsIdentity;
		public cDataField dfsIdentity;
		protected cBackgroundText labeldfsName;
		public cDataField dfsName;
		protected cBackgroundText labeldfsNewIdentity;
		public cDataField dfsNewIdentity;
		protected cBackgroundText labeldfsNewName;
		public cDataField dfsNewName;
		protected cBackgroundText labeldfsAssocNo;
		public cDataField dfsAssocNo;
		public cPushButton pbOk;
		public cPushButton pbCancel;
		public cPushButton pbList;
		protected SalGroupBox gbCopy_To;
		protected SalGroupBox gbCopy_From;
		public cDataField dfsExist;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgCopyCustomer));
            this.labeldfsIdentity = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsIdentity = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsName = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsName = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsNewIdentity = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsNewIdentity = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsNewName = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsNewName = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsAssocNo = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsAssocNo = new Ifs.Fnd.ApplicationForms.cDataField();
            this.pbOk = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbCancel = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbList = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.gbCopy_To = new PPJ.Runtime.Windows.SalGroupBox();
            this.gbCopy_From = new PPJ.Runtime.Windows.SalGroupBox();
            this.dfsExist = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsCategory = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.labeldfsNewCategory = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbNewCustomerCategory = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.dfsCategory = new Ifs.Fnd.ApplicationForms.cDataField();
            this.ClientArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // ClientArea
            // 
            this.ClientArea.Controls.Add(this.cmbNewCustomerCategory);
            this.ClientArea.Controls.Add(this.labeldfsNewCategory);
            this.ClientArea.Controls.Add(this.labeldfsCategory);
            this.ClientArea.Controls.Add(this.dfsCategory);
            this.ClientArea.Controls.Add(this.dfsExist);
            this.ClientArea.Controls.Add(this.pbList);
            this.ClientArea.Controls.Add(this.pbCancel);
            this.ClientArea.Controls.Add(this.pbOk);
            this.ClientArea.Controls.Add(this.dfsAssocNo);
            this.ClientArea.Controls.Add(this.dfsNewName);
            this.ClientArea.Controls.Add(this.dfsNewIdentity);
            this.ClientArea.Controls.Add(this.dfsName);
            this.ClientArea.Controls.Add(this.dfsIdentity);
            this.ClientArea.Controls.Add(this.labeldfsAssocNo);
            this.ClientArea.Controls.Add(this.labeldfsNewName);
            this.ClientArea.Controls.Add(this.labeldfsNewIdentity);
            this.ClientArea.Controls.Add(this.labeldfsName);
            this.ClientArea.Controls.Add(this.labeldfsIdentity);
            this.ClientArea.Controls.Add(this.gbCopy_From);
            this.ClientArea.Controls.Add(this.gbCopy_To);
            resources.ApplyResources(this.ClientArea, "ClientArea");
            // 
            // commandManager
            // 
            this.commandManager.Components.Add(this.pbList);
            this.commandManager.Components.Add(this.pbCancel);
            this.commandManager.Components.Add(this.pbOk);
            // 
            // labeldfsIdentity
            // 
            resources.ApplyResources(this.labeldfsIdentity, "labeldfsIdentity");
            this.labeldfsIdentity.Name = "labeldfsIdentity";
            // 
            // dfsIdentity
            // 
            this.dfsIdentity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsIdentity, "dfsIdentity");
            this.dfsIdentity.Name = "dfsIdentity";
            this.dfsIdentity.NamedProperties.Put("EnumerateMethod", "");
            this.dfsIdentity.NamedProperties.Put("FieldFlags", "167");
            this.dfsIdentity.NamedProperties.Put("LovReference", "CUSTOMER_INFO");
            this.dfsIdentity.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsIdentity.NamedProperties.Put("SqlColumn", "");
            this.dfsIdentity.NamedProperties.Put("ValidateMethod", "");
            this.dfsIdentity.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsIdentity_WindowActions);
            // 
            // labeldfsName
            // 
            resources.ApplyResources(this.labeldfsName, "labeldfsName");
            this.labeldfsName.Name = "labeldfsName";
            // 
            // dfsName
            // 
            this.dfsName.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.dfsName, "dfsName");
            this.dfsName.Name = "dfsName";
            this.dfsName.NamedProperties.Put("EnumerateMethod", "");
            this.dfsName.NamedProperties.Put("FieldFlags", "295");
            this.dfsName.NamedProperties.Put("LovReference", "");
            this.dfsName.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsName.NamedProperties.Put("SqlColumn", "CUSTOMER_INFO_API.Get_Name(dfsIdentity)");
            this.dfsName.NamedProperties.Put("ValidateMethod", "");
            this.dfsName.ReadOnly = true;
            // 
            // labeldfsNewIdentity
            // 
            resources.ApplyResources(this.labeldfsNewIdentity, "labeldfsNewIdentity");
            this.labeldfsNewIdentity.Name = "labeldfsNewIdentity";
            // 
            // dfsNewIdentity
            // 
            this.dfsNewIdentity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsNewIdentity, "dfsNewIdentity");
            this.dfsNewIdentity.Name = "dfsNewIdentity";
            this.dfsNewIdentity.NamedProperties.Put("EnumerateMethod", "");
            this.dfsNewIdentity.NamedProperties.Put("FieldFlags", "262");
            this.dfsNewIdentity.NamedProperties.Put("LovReference", "");
            this.dfsNewIdentity.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsNewIdentity.NamedProperties.Put("SqlColumn", "");
            this.dfsNewIdentity.NamedProperties.Put("ValidateMethod", "");
            this.dfsNewIdentity.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsNewIdentity_WindowActions);
            // 
            // labeldfsNewName
            // 
            resources.ApplyResources(this.labeldfsNewName, "labeldfsNewName");
            this.labeldfsNewName.Name = "labeldfsNewName";
            // 
            // dfsNewName
            // 
            resources.ApplyResources(this.dfsNewName, "dfsNewName");
            this.dfsNewName.Name = "dfsNewName";
            this.dfsNewName.NamedProperties.Put("EnumerateMethod", "");
            this.dfsNewName.NamedProperties.Put("FieldFlags", "263");
            this.dfsNewName.NamedProperties.Put("LovReference", "");
            this.dfsNewName.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsNewName.NamedProperties.Put("SqlColumn", "");
            this.dfsNewName.NamedProperties.Put("ValidateMethod", "");
            this.dfsNewName.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsNewName_WindowActions);
            // 
            // labeldfsAssocNo
            // 
            resources.ApplyResources(this.labeldfsAssocNo, "labeldfsAssocNo");
            this.labeldfsAssocNo.Name = "labeldfsAssocNo";
            // 
            // dfsAssocNo
            // 
            resources.ApplyResources(this.dfsAssocNo, "dfsAssocNo");
            this.dfsAssocNo.Name = "dfsAssocNo";
            this.dfsAssocNo.NamedProperties.Put("EnumerateMethod", "");
            this.dfsAssocNo.NamedProperties.Put("FieldFlags", "262");
            this.dfsAssocNo.NamedProperties.Put("LovReference", "");
            this.dfsAssocNo.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsAssocNo.NamedProperties.Put("SqlColumn", "");
            this.dfsAssocNo.NamedProperties.Put("ValidateMethod", "");
            this.dfsAssocNo.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsAssocNo_WindowActions);
            // 
            // pbOk
            // 
            this.pbOk.AcceleratorKey = System.Windows.Forms.Keys.Return;
            resources.ApplyResources(this.pbOk, "pbOk");
            this.pbOk.Name = "pbOk";
            this.pbOk.NamedProperties.Put("MethodId", "18385");
            this.pbOk.NamedProperties.Put("MethodParameter", "ok");
            this.pbOk.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // pbCancel
            // 
            this.pbCancel.AcceleratorKey = System.Windows.Forms.Keys.Escape;
            resources.ApplyResources(this.pbCancel, "pbCancel");
            this.pbCancel.Name = "pbCancel";
            this.pbCancel.NamedProperties.Put("MethodId", "18385");
            this.pbCancel.NamedProperties.Put("MethodParameter", "cancel");
            this.pbCancel.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // pbList
            // 
            this.pbList.AcceleratorKey = System.Windows.Forms.Keys.Escape;
            resources.ApplyResources(this.pbList, "pbList");
            this.pbList.Name = "pbList";
            this.pbList.NamedProperties.Put("MethodId", "18385");
            this.pbList.NamedProperties.Put("MethodParameter", "list");
            this.pbList.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // gbCopy_To
            // 
            resources.ApplyResources(this.gbCopy_To, "gbCopy_To");
            this.gbCopy_To.Name = "gbCopy_To";
            this.gbCopy_To.TabStop = false;
            // 
            // gbCopy_From
            // 
            resources.ApplyResources(this.gbCopy_From, "gbCopy_From");
            this.gbCopy_From.Name = "gbCopy_From";
            this.gbCopy_From.TabStop = false;
            // 
            // dfsExist
            // 
            resources.ApplyResources(this.dfsExist, "dfsExist");
            this.dfsExist.Name = "dfsExist";
            // 
            // labeldfsCategory
            // 
            resources.ApplyResources(this.labeldfsCategory, "labeldfsCategory");
            this.labeldfsCategory.Name = "labeldfsCategory";
            // 
            // labeldfsNewCategory
            // 
            resources.ApplyResources(this.labeldfsNewCategory, "labeldfsNewCategory");
            this.labeldfsNewCategory.Name = "labeldfsNewCategory";
            // 
            // cmbNewCustomerCategory
            // 
            resources.ApplyResources(this.cmbNewCustomerCategory, "cmbNewCustomerCategory");
            this.cmbNewCustomerCategory.FormattingEnabled = true;
            this.cmbNewCustomerCategory.Name = "cmbNewCustomerCategory";
            this.cmbNewCustomerCategory.NamedProperties.Put("EnumerateMethod", "CUSTOMER_CATEGORY_API.Enumerate");
            this.cmbNewCustomerCategory.NamedProperties.Put("FieldFlags", "263");
            this.cmbNewCustomerCategory.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbNewCustomerCategory_WindowActions);
            // 
            // dfsCategory
            // 
            resources.ApplyResources(this.dfsCategory, "dfsCategory");
            this.dfsCategory.Name = "dfsCategory";
            // 
            // dlgCopyCustomer
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "dlgCopyCustomer";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "");
            this.NamedProperties.Put("PackageName", "");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "129");
            this.NamedProperties.Put("ViewName", "");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.ShowIcon = false;
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dlgCopyCustomer_WindowActions);
            this.ClientArea.ResumeLayout(false);
            this.ClientArea.PerformLayout();
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

        protected cBackgroundText labeldfsCategory;
        protected cBackgroundText labeldfsNewCategory;
        protected cComboBox cmbNewCustomerCategory;
        protected cDataField dfsCategory;
	}
}
