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
	
	public partial class tbwCompanyEmp
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cColumn colsCompany;
		public cColumn colsEmployeeId;
		public cColumn colsPersonId;
		public cColumn colsName;
		public cColumn coldExpireDate;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwCompanyEmp));
            this.menuTbwMethods_menu_Details___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menu_Only_Show_Employees_Valid_Today = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.colsCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsEmployeeId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsPersonId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.coldExpireDate = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuTbwMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem__Details = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem__Only = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem__PersonalDataConsent = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.cmdManageDataProcessingPurposes = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.colValidDataProcessingPurpose = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.menuTbwMethods.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuTbwMethods_menu_Details___);
            this.commandManager.Commands.Add(this.menuTbwMethods_menu_Only_Show_Employees_Valid_Today);
            this.commandManager.Commands.Add(this.cmdManageDataProcessingPurposes);
            this.commandManager.ContextMenus.Add(this.menuTbwMethods);
            // 
            // __colObjversion
            // 
            resources.ApplyResources(this.@__colObjversion, "__colObjversion");
            // 
            // menuTbwMethods_menu_Details___
            // 
            resources.ApplyResources(this.menuTbwMethods_menu_Details___, "menuTbwMethods_menu_Details___");
            this.menuTbwMethods_menu_Details___.Name = "menuTbwMethods_menu_Details___";
            this.menuTbwMethods_menu_Details___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Details_Execute);
            this.menuTbwMethods_menu_Details___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Details_Inquire);
            // 
            // menuTbwMethods_menu_Only_Show_Employees_Valid_Today
            // 
            resources.ApplyResources(this.menuTbwMethods_menu_Only_Show_Employees_Valid_Today, "menuTbwMethods_menu_Only_Show_Employees_Valid_Today");
            this.menuTbwMethods_menu_Only_Show_Employees_Valid_Today.Name = "menuTbwMethods_menu_Only_Show_Employees_Valid_Today";
            this.menuTbwMethods_menu_Only_Show_Employees_Valid_Today.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Only_Execute);
            this.menuTbwMethods_menu_Only_Show_Employees_Valid_Today.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Only_Inquire);
            // 
            // colsCompany
            // 
            this.colsCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.colsCompany, "colsCompany");
            this.colsCompany.MaxLength = 20;
            this.colsCompany.Name = "colsCompany";
            this.colsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.colsCompany.NamedProperties.Put("FieldFlags", "67");
            this.colsCompany.NamedProperties.Put("LovReference", "COMPANY");
            this.colsCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.colsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.colsCompany.NamedProperties.Put("ValidateMethod", "");
            this.colsCompany.Position = 3;
            // 
            // colsEmployeeId
            // 
            this.colsEmployeeId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsEmployeeId.MaxLength = 11;
            this.colsEmployeeId.Name = "colsEmployeeId";
            this.colsEmployeeId.NamedProperties.Put("EnumerateMethod", "");
            this.colsEmployeeId.NamedProperties.Put("FieldFlags", "162");
            this.colsEmployeeId.NamedProperties.Put("LovReference", "");
            this.colsEmployeeId.NamedProperties.Put("ResizeableChildObject", "");
            this.colsEmployeeId.NamedProperties.Put("SqlColumn", "EMPLOYEE_ID");
            this.colsEmployeeId.NamedProperties.Put("ValidateMethod", "");
            this.colsEmployeeId.Position = 4;
            resources.ApplyResources(this.colsEmployeeId, "colsEmployeeId");
            // 
            // colsPersonId
            // 
            this.colsPersonId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsPersonId.Name = "colsPersonId";
            this.colsPersonId.NamedProperties.Put("EnumerateMethod", "");
            this.colsPersonId.NamedProperties.Put("FieldFlags", "291");
            this.colsPersonId.NamedProperties.Put("LovReference", "PERSON_INFO");
            this.colsPersonId.NamedProperties.Put("ResizeableChildObject", "");
            this.colsPersonId.NamedProperties.Put("SqlColumn", "PERSON_ID");
            this.colsPersonId.NamedProperties.Put("ValidateMethod", "");
            this.colsPersonId.Position = 5;
            resources.ApplyResources(this.colsPersonId, "colsPersonId");
            // 
            // colsName
            // 
            this.colsName.Name = "colsName";
            this.colsName.NamedProperties.Put("EnumerateMethod", "");
            this.colsName.NamedProperties.Put("FieldFlags", "304");
            this.colsName.NamedProperties.Put("LovReference", "");
            this.colsName.NamedProperties.Put("ParentName", "colsPersonId");
            this.colsName.NamedProperties.Put("ResizeableChildObject", "");
            this.colsName.NamedProperties.Put("SqlColumn", "PERSON_INFO_API.Get_Name(PERSON_ID)");
            this.colsName.NamedProperties.Put("ValidateMethod", "");
            this.colsName.Position = 6;
            resources.ApplyResources(this.colsName, "colsName");
            // 
            // coldExpireDate
            // 
            this.coldExpireDate.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.coldExpireDate.Format = "d";
            this.coldExpireDate.Name = "coldExpireDate";
            this.coldExpireDate.NamedProperties.Put("EnumerateMethod", "");
            this.coldExpireDate.NamedProperties.Put("FieldFlags", "294");
            this.coldExpireDate.NamedProperties.Put("LovReference", "");
            this.coldExpireDate.NamedProperties.Put("ResizeableChildObject", "");
            this.coldExpireDate.NamedProperties.Put("SqlColumn", "EXPIRE_DATE");
            this.coldExpireDate.NamedProperties.Put("ValidateMethod", "");
            this.coldExpireDate.Position = 7;
            resources.ApplyResources(this.coldExpireDate, "coldExpireDate");
            // 
            // menuTbwMethods
            // 
            this.menuTbwMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem__Details,
            this.menuItem__Only,
            this.menuItem__PersonalDataConsent});
            this.menuTbwMethods.Name = "menuTbwMethods";
            resources.ApplyResources(this.menuTbwMethods, "menuTbwMethods");
            // 
            // menuItem__Details
            // 
            this.menuItem__Details.Command = this.menuTbwMethods_menu_Details___;
            this.menuItem__Details.Name = "menuItem__Details";
            resources.ApplyResources(this.menuItem__Details, "menuItem__Details");
            this.menuItem__Details.Text = "&Details...";
            // 
            // menuItem__Only
            // 
            this.menuItem__Only.Command = this.menuTbwMethods_menu_Only_Show_Employees_Valid_Today;
            this.menuItem__Only.Name = "menuItem__Only";
            resources.ApplyResources(this.menuItem__Only, "menuItem__Only");
            this.menuItem__Only.Text = "&Only Show Employees Valid Today";
            // 
            // menuItem__PersonalDataConsent
            // 
            this.menuItem__PersonalDataConsent.Command = this.cmdManageDataProcessingPurposes;
            this.menuItem__PersonalDataConsent.Name = "menuItem__PersonalDataConsent";
            resources.ApplyResources(this.menuItem__PersonalDataConsent, "menuItem__PersonalDataConsent");
            this.menuItem__PersonalDataConsent.Text = "Manage Data Processing Purposes...";
            // 
            // cmdManageDataProcessingPurposes
            // 
            resources.ApplyResources(this.cmdManageDataProcessingPurposes, "cmdManageDataProcessingPurposes");
            this.cmdManageDataProcessingPurposes.Name = "cmdManageDataProcessingPurposes";
            this.cmdManageDataProcessingPurposes.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.cmdManageDataProcessingPurposes_Execute);
            this.cmdManageDataProcessingPurposes.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.cmdManageDataProcessingPurposes_Inquire);
            // 
            // colValidDataProcessingPurpose
            // 
            this.colValidDataProcessingPurpose.Name = "colValidDataProcessingPurpose";
            this.colValidDataProcessingPurpose.NamedProperties.Put("FieldFlags", "288");
            this.colValidDataProcessingPurpose.NamedProperties.Put("SqlColumn", "Personal_Data_Man_Util_API.Is_Valid_Consent_By_Keys(\'EMPLOYEE\',COMPANY,EMPLOYEE_I" +
        "D, trunc(SYSDATE))");
            this.colValidDataProcessingPurpose.Position = 8;
            resources.ApplyResources(this.colValidDataProcessingPurpose, "colValidDataProcessingPurpose");
            // 
            // tbwCompanyEmp
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colsCompany);
            this.Controls.Add(this.colsEmployeeId);
            this.Controls.Add(this.colsPersonId);
            this.Controls.Add(this.colsName);
            this.Controls.Add(this.coldExpireDate);
            this.Controls.Add(this.colValidDataProcessingPurpose);
            this.Name = "tbwCompanyEmp";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "CompanyEmp");
            this.NamedProperties.Put("PackageName", "COMPANY_EMP_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "0");
            this.NamedProperties.Put("ViewName", "COMPANY_EMP");
            this.NamedProperties.Put("Warnings", "TRUE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tbwCompanyEmp_WindowActions);
            this.Controls.SetChildIndex(this.colValidDataProcessingPurpose, 0);
            this.Controls.SetChildIndex(this.coldExpireDate, 0);
            this.Controls.SetChildIndex(this.colsName, 0);
            this.Controls.SetChildIndex(this.colsPersonId, 0);
            this.Controls.SetChildIndex(this.colsEmployeeId, 0);
            this.Controls.SetChildIndex(this.colsCompany, 0);
            this.Controls.SetChildIndex(this.@__colObjversion, 0);
            this.Controls.SetChildIndex(this.@__colObjid, 0);
            this.menuTbwMethods.ResumeLayout(false);
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

        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menu_Details___;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menu_Only_Show_Employees_Valid_Today;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTbwMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Details;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Only;
        public cCheckBoxColumn colValidDataProcessingPurpose;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__PersonalDataConsent;
        protected Fnd.Windows.Forms.FndCommand cmdManageDataProcessingPurposes;
	}
}
