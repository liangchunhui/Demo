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
	
	public partial class tbwCompanyComponentLog
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cColumn colsCompany;
		public cColumn colsModule;
		public cColumn colsStatus;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwCompanyComponentLog));
            this.menuOperations_menuCompany_Log__Details___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods_menuCompany_Log__Details___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.colsCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsModule = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsStatus = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuTbwMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Company = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuOperations = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Company_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuTbwMethods.SuspendLayout();
            this.menuOperations.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuTbwMethods_menuCompany_Log__Details___);
            this.commandManager.Commands.Add(this.menuOperations_menuCompany_Log__Details___);
            this.commandManager.ContextMenus.Add(this.menuTbwMethods);
            this.commandManager.ContextMenus.Add(this.menuOperations);
            // 
            // menuOperations_menuCompany_Log__Details___
            // 
            resources.ApplyResources(this.menuOperations_menuCompany_Log__Details___, "menuOperations_menuCompany_Log__Details___");
            this.menuOperations_menuCompany_Log__Details___.Name = "menuOperations_menuCompany_Log__Details___";
            this.menuOperations_menuCompany_Log__Details___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Company_1_Execute);
            this.menuOperations_menuCompany_Log__Details___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Company_1_Inquire);
            // 
            // menuTbwMethods_menuCompany_Log__Details___
            // 
            resources.ApplyResources(this.menuTbwMethods_menuCompany_Log__Details___, "menuTbwMethods_menuCompany_Log__Details___");
            this.menuTbwMethods_menuCompany_Log__Details___.Name = "menuTbwMethods_menuCompany_Log__Details___";
            this.menuTbwMethods_menuCompany_Log__Details___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Company_Execute);
            this.menuTbwMethods_menuCompany_Log__Details___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Company_Inquire);
            // 
            // colsCompany
            // 
            this.colsCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsCompany.MaxLength = 20;
            this.colsCompany.Name = "colsCompany";
            this.colsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.colsCompany.NamedProperties.Put("FieldFlags", "161");
            this.colsCompany.NamedProperties.Put("LovReference", "COMPANY");
            this.colsCompany.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.colsCompany.NamedProperties.Put("ValidateMethod", "");
            this.colsCompany.Position = 3;
            resources.ApplyResources(this.colsCompany, "colsCompany");
            // 
            // colsModule
            // 
            this.colsModule.MaxLength = 6;
            this.colsModule.Name = "colsModule";
            this.colsModule.NamedProperties.Put("EnumerateMethod", "");
            this.colsModule.NamedProperties.Put("FieldFlags", "289");
            this.colsModule.NamedProperties.Put("LovReference", "");
            this.colsModule.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsModule.NamedProperties.Put("SqlColumn", "MODULE");
            this.colsModule.NamedProperties.Put("ValidateMethod", "");
            this.colsModule.Position = 4;
            resources.ApplyResources(this.colsModule, "colsModule");
            // 
            // colsStatus
            // 
            this.colsStatus.MaxLength = 200;
            this.colsStatus.Name = "colsStatus";
            this.colsStatus.NamedProperties.Put("EnumerateMethod", "");
            this.colsStatus.NamedProperties.Put("FieldFlags", "289");
            this.colsStatus.NamedProperties.Put("LovReference", "");
            this.colsStatus.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsStatus.NamedProperties.Put("SqlColumn", "STATUS");
            this.colsStatus.NamedProperties.Put("ValidateMethod", "");
            this.colsStatus.Position = 5;
            resources.ApplyResources(this.colsStatus, "colsStatus");
            // 
            // menuTbwMethods
            // 
            this.menuTbwMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_Company});
            this.menuTbwMethods.Name = "menuTbwMethods";
            resources.ApplyResources(this.menuTbwMethods, "menuTbwMethods");
            // 
            // menuItem_Company
            // 
            this.menuItem_Company.Command = this.menuTbwMethods_menuCompany_Log__Details___;
            this.menuItem_Company.Name = "menuItem_Company";
            resources.ApplyResources(this.menuItem_Company, "menuItem_Company");
            this.menuItem_Company.Text = "Company Log &Details...";
            // 
            // menuOperations
            // 
            this.menuOperations.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_Company_1});
            this.menuOperations.Name = "menuOperations";
            resources.ApplyResources(this.menuOperations, "menuOperations");
            // 
            // menuItem_Company_1
            // 
            this.menuItem_Company_1.Command = this.menuOperations_menuCompany_Log__Details___;
            this.menuItem_Company_1.Name = "menuItem_Company_1";
            resources.ApplyResources(this.menuItem_Company_1, "menuItem_Company_1");
            this.menuItem_Company_1.Text = "Company Log &Details...";
            // 
            // tbwCompanyComponentLog
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colsCompany);
            this.Controls.Add(this.colsModule);
            this.Controls.Add(this.colsStatus);
            this.Name = "tbwCompanyComponentLog";
            this.NamedProperties.Put("DefaultOrderBy", "Company");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "CreateCompanyLog");
            this.NamedProperties.Put("PackageName", "CREATE_COMPANY_LOG_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "1");
            this.NamedProperties.Put("ViewName", "CREATE_COMPANY_LOG3");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.Controls.SetChildIndex(this.colsStatus, 0);
            this.Controls.SetChildIndex(this.colsModule, 0);
            this.Controls.SetChildIndex(this.colsCompany, 0);
            this.Controls.SetChildIndex(this.@__colObjversion, 0);
            this.Controls.SetChildIndex(this.@__colObjid, 0);
            this.menuTbwMethods.ResumeLayout(false);
            this.menuOperations.ResumeLayout(false);
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

        public Fnd.Windows.Forms.FndCommand menuOperations_menuCompany_Log__Details___;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menuCompany_Log__Details___;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTbwMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Company;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuOperations;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Company_1;
	}
}
