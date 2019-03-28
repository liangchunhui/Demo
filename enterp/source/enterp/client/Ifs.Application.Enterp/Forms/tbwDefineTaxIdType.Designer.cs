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
	
	public partial class tbwDefineTaxIdType
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cColumn colsTaxIdType;
		public cColumn colsCountryCode;
		public cColumn colsReportCode;
		public cColumn colsDescription;
		public cColumn colsLayoutFormat;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwDefineTaxIdType));
            this.menuTbwMethods_menuTax_Id_Number_Layout___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.colsTaxIdType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsCountryCode = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsReportCode = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsLayoutFormat = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuTbwMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_Tax = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuTbwMethods.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuTbwMethods_menuTax_Id_Number_Layout___);
            this.commandManager.ContextMenus.Add(this.menuTbwMethods);
            // 
            // menuTbwMethods_menuTax_Id_Number_Layout___
            // 
            resources.ApplyResources(this.menuTbwMethods_menuTax_Id_Number_Layout___, "menuTbwMethods_menuTax_Id_Number_Layout___");
            this.menuTbwMethods_menuTax_Id_Number_Layout___.Name = "menuTbwMethods_menuTax_Id_Number_Layout___";
            this.menuTbwMethods_menuTax_Id_Number_Layout___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem_Tax_Execute);
            this.menuTbwMethods_menuTax_Id_Number_Layout___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem_Tax_Inquire);
            // 
            // colsTaxIdType
            // 
            this.colsTaxIdType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsTaxIdType.MaxLength = 10;
            this.colsTaxIdType.Name = "colsTaxIdType";
            this.colsTaxIdType.NamedProperties.Put("EnumerateMethod", "");
            this.colsTaxIdType.NamedProperties.Put("FieldFlags", "163");
            this.colsTaxIdType.NamedProperties.Put("LovReference", "");
            this.colsTaxIdType.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsTaxIdType.NamedProperties.Put("ResizeableChildObject", "");
            this.colsTaxIdType.NamedProperties.Put("SqlColumn", "TAX_ID_TYPE");
            this.colsTaxIdType.NamedProperties.Put("ValidateMethod", "");
            this.colsTaxIdType.Position = 3;
            resources.ApplyResources(this.colsTaxIdType, "colsTaxIdType");
            // 
            // colsCountryCode
            // 
            this.colsCountryCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsCountryCode.MaxLength = 2;
            this.colsCountryCode.Name = "colsCountryCode";
            this.colsCountryCode.NamedProperties.Put("EnumerateMethod", "ISO_COUNTRY_API.Enumerate");
            this.colsCountryCode.NamedProperties.Put("FieldFlags", "295");
            this.colsCountryCode.NamedProperties.Put("LovReference", "ISO_COUNTRY");
            this.colsCountryCode.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsCountryCode.NamedProperties.Put("ResizeableChildObject", "");
            this.colsCountryCode.NamedProperties.Put("SqlColumn", "COUNTRY_CODE");
            this.colsCountryCode.NamedProperties.Put("ValidateMethod", "");
            this.colsCountryCode.Position = 4;
            resources.ApplyResources(this.colsCountryCode, "colsCountryCode");
            // 
            // colsReportCode
            // 
            this.colsReportCode.MaxLength = 10;
            this.colsReportCode.Name = "colsReportCode";
            this.colsReportCode.NamedProperties.Put("EnumerateMethod", "");
            this.colsReportCode.NamedProperties.Put("FieldFlags", "294");
            this.colsReportCode.NamedProperties.Put("LovReference", "");
            this.colsReportCode.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsReportCode.NamedProperties.Put("SqlColumn", "REPORT_CODE");
            this.colsReportCode.NamedProperties.Put("ValidateMethod", "");
            this.colsReportCode.Position = 5;
            resources.ApplyResources(this.colsReportCode, "colsReportCode");
            // 
            // colsDescription
            // 
            this.colsDescription.Name = "colsDescription";
            this.colsDescription.NamedProperties.Put("EnumerateMethod", "");
            this.colsDescription.NamedProperties.Put("FieldFlags", "294");
            this.colsDescription.NamedProperties.Put("LovReference", "");
            this.colsDescription.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.colsDescription.NamedProperties.Put("ValidateMethod", "");
            this.colsDescription.Position = 6;
            resources.ApplyResources(this.colsDescription, "colsDescription");
            // 
            // colsLayoutFormat
            // 
            resources.ApplyResources(this.colsLayoutFormat, "colsLayoutFormat");
            this.colsLayoutFormat.MaxLength = 50;
            this.colsLayoutFormat.Name = "colsLayoutFormat";
            this.colsLayoutFormat.NamedProperties.Put("EnumerateMethod", "");
            this.colsLayoutFormat.NamedProperties.Put("FieldFlags", "294");
            this.colsLayoutFormat.NamedProperties.Put("LovReference", "");
            this.colsLayoutFormat.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsLayoutFormat.NamedProperties.Put("SqlColumn", "LAYOUT_FORMAT");
            this.colsLayoutFormat.Position = 7;
            // 
            // menuTbwMethods
            // 
            this.menuTbwMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_Tax});
            this.menuTbwMethods.Name = "menuTbwMethods";
            resources.ApplyResources(this.menuTbwMethods, "menuTbwMethods");
            // 
            // menuItem_Tax
            // 
            this.menuItem_Tax.Command = this.menuTbwMethods_menuTax_Id_Number_Layout___;
            this.menuItem_Tax.Name = "menuItem_Tax";
            resources.ApplyResources(this.menuItem_Tax, "menuItem_Tax");
            this.menuItem_Tax.Text = "Tax Id Number Layout...";
            // 
            // tbwDefineTaxIdType
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colsTaxIdType);
            this.Controls.Add(this.colsCountryCode);
            this.Controls.Add(this.colsReportCode);
            this.Controls.Add(this.colsDescription);
            this.Controls.Add(this.colsLayoutFormat);
            this.Name = "tbwDefineTaxIdType";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "TaxIdType");
            this.NamedProperties.Put("PackageName", "TAX_ID_TYPE_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "449");
            this.NamedProperties.Put("ViewName", "TAX_ID_TYPE");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.Controls.SetChildIndex(this.colsLayoutFormat, 0);
            this.Controls.SetChildIndex(this.colsDescription, 0);
            this.Controls.SetChildIndex(this.colsReportCode, 0);
            this.Controls.SetChildIndex(this.colsCountryCode, 0);
            this.Controls.SetChildIndex(this.colsTaxIdType, 0);
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

        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menuTax_Id_Number_Layout___;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTbwMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Tax;
	}
}
