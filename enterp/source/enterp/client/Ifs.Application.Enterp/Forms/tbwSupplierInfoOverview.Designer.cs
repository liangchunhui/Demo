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
#region History
// Date     By      Notes
// -----    ------  ---------------------------------------------------------------------------------
// 150528   RoJalk  ORA-499, Changed the connected view SUPPLIER_INFO to SUPPLIER_INFO_GENERAL.
// 150612   RoJalk  ORA-700, Changed the LOV reference of SUPPLIER_INFO id from SUPPLIER_INFO_GENERAL. 
// 150707   RoJalk  ORA-776, Added the RMB to Change Supplier Category. 
#endregion
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
	
	public partial class tbwSupplierInfoOverview
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cColumn colsSupplierId;
		public cColumn colsName;
		public cColumn colsAssociationNo;
		public cLookupColumn colsDefaultLanguage;
		public cLookupColumn colsCountry;
		public cColumn coldCreationDate;
		public cColumn colsParty;
		public cColumn colsPartyType;
		public cCheckBoxColumn colDefaultDomain;
		public cColumn colsExist;
		public cLookupColumn colsIdReferenceValidation;
		public cColumn colsCorporateForm;
		public cColumn colsOldCountry;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwSupplierInfoOverview));
            this.menuTbwMethods_menu_Details___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.colsSupplierId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsAssociationNo = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsDefaultLanguage = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.colsCountry = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.coldCreationDate = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsParty = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsPartyType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colDefaultDomain = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.colsExist = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsIdReferenceValidation = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.colsCorporateForm = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsOldCountry = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuTbwMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem__Details = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem__Chg_Supp_Category = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuTbwMethods_menu_Chg_Supp_Category___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.tsMenuItemSeparator = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.menuItem__Personal_Data_Consent = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.cmdManageDataProcessingPurposes = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.colsSupplierCategory = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.colValidDataProcessingPurpose = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.menuTbwMethods.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuTbwMethods_menu_Details___);
            this.commandManager.Commands.Add(this.menuTbwMethods_menu_Chg_Supp_Category___);
            this.commandManager.Commands.Add(this.cmdManageDataProcessingPurposes);
            this.commandManager.ContextMenus.Add(this.menuTbwMethods);
            // 
            // menuTbwMethods_menu_Details___
            // 
            resources.ApplyResources(this.menuTbwMethods_menu_Details___, "menuTbwMethods_menu_Details___");
            this.menuTbwMethods_menu_Details___.Name = "menuTbwMethods_menu_Details___";
            this.menuTbwMethods_menu_Details___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Details_Execute);
            this.menuTbwMethods_menu_Details___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Details_Inquire);
            // 
            // colsSupplierId
            // 
            this.colsSupplierId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsSupplierId.MaxLength = 20;
            this.colsSupplierId.Name = "colsSupplierId";
            this.colsSupplierId.NamedProperties.Put("EnumerateMethod", "");
            this.colsSupplierId.NamedProperties.Put("FieldFlags", "162");
            this.colsSupplierId.NamedProperties.Put("LovReference", "SUPPLIER_INFO_GENERAL");
            this.colsSupplierId.NamedProperties.Put("ResizeableChildObject", "");
            this.colsSupplierId.NamedProperties.Put("SqlColumn", "SUPPLIER_ID");
            this.colsSupplierId.NamedProperties.Put("ValidateMethod", "");
            this.colsSupplierId.Position = 3;
            resources.ApplyResources(this.colsSupplierId, "colsSupplierId");
            // 
            // colsName
            // 
            this.colsName.Name = "colsName";
            this.colsName.NamedProperties.Put("EnumerateMethod", "");
            this.colsName.NamedProperties.Put("FieldFlags", "295");
            this.colsName.NamedProperties.Put("LovReference", "");
            this.colsName.NamedProperties.Put("SqlColumn", "NAME");
            this.colsName.Position = 4;
            resources.ApplyResources(this.colsName, "colsName");
            // 
            // colsAssociationNo
            // 
            this.colsAssociationNo.MaxLength = 50;
            this.colsAssociationNo.Name = "colsAssociationNo";
            this.colsAssociationNo.NamedProperties.Put("EnumerateMethod", "");
            this.colsAssociationNo.NamedProperties.Put("FieldFlags", "294");
            this.colsAssociationNo.NamedProperties.Put("LovReference", "");
            this.colsAssociationNo.NamedProperties.Put("SqlColumn", "ASSOCIATION_NO");
            this.colsAssociationNo.Position = 5;
            resources.ApplyResources(this.colsAssociationNo, "colsAssociationNo");
            this.colsAssociationNo.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsAssociationNo_WindowActions);
            // 
            // colsDefaultLanguage
            // 
            this.colsDefaultLanguage.MaxLength = 20;
            this.colsDefaultLanguage.Name = "colsDefaultLanguage";
            this.colsDefaultLanguage.NamedProperties.Put("EnumerateMethod", "ISO_LANGUAGE_API.Enumerate");
            this.colsDefaultLanguage.NamedProperties.Put("FieldFlags", "294");
            this.colsDefaultLanguage.NamedProperties.Put("LovReference", "");
            this.colsDefaultLanguage.NamedProperties.Put("ResizeableChildObject", "");
            this.colsDefaultLanguage.NamedProperties.Put("SqlColumn", "DEFAULT_LANGUAGE");
            this.colsDefaultLanguage.NamedProperties.Put("ValidateMethod", "");
            this.colsDefaultLanguage.Position = 6;
            resources.ApplyResources(this.colsDefaultLanguage, "colsDefaultLanguage");
            // 
            // colsCountry
            // 
            this.colsCountry.MaxLength = 50;
            this.colsCountry.Name = "colsCountry";
            this.colsCountry.NamedProperties.Put("EnumerateMethod", "ISO_COUNTRY_API.Enumerate");
            this.colsCountry.NamedProperties.Put("FieldFlags", "294");
            this.colsCountry.NamedProperties.Put("LovReference", "");
            this.colsCountry.NamedProperties.Put("ResizeableChildObject", "");
            this.colsCountry.NamedProperties.Put("SqlColumn", "COUNTRY");
            this.colsCountry.NamedProperties.Put("ValidateMethod", "");
            this.colsCountry.Position = 7;
            resources.ApplyResources(this.colsCountry, "colsCountry");
            this.colsCountry.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsCountry_WindowActions);
            // 
            // coldCreationDate
            // 
            this.coldCreationDate.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.coldCreationDate.Format = "d";
            this.coldCreationDate.Name = "coldCreationDate";
            this.coldCreationDate.NamedProperties.Put("EnumerateMethod", "");
            this.coldCreationDate.NamedProperties.Put("FieldFlags", "289");
            this.coldCreationDate.NamedProperties.Put("LovReference", "");
            this.coldCreationDate.NamedProperties.Put("ResizeableChildObject", "");
            this.coldCreationDate.NamedProperties.Put("SqlColumn", "CREATION_DATE");
            this.coldCreationDate.NamedProperties.Put("ValidateMethod", "");
            this.coldCreationDate.Position = 9;
            resources.ApplyResources(this.coldCreationDate, "coldCreationDate");
            // 
            // colsParty
            // 
            resources.ApplyResources(this.colsParty, "colsParty");
            this.colsParty.MaxLength = 20;
            this.colsParty.Name = "colsParty";
            this.colsParty.NamedProperties.Put("EnumerateMethod", "");
            this.colsParty.NamedProperties.Put("FieldFlags", "262");
            this.colsParty.NamedProperties.Put("LovReference", "");
            this.colsParty.NamedProperties.Put("ResizeableChildObject", "");
            this.colsParty.NamedProperties.Put("SqlColumn", "PARTY");
            this.colsParty.NamedProperties.Put("ValidateMethod", "");
            this.colsParty.Position = 10;
            // 
            // colsPartyType
            // 
            resources.ApplyResources(this.colsPartyType, "colsPartyType");
            this.colsPartyType.MaxLength = 20;
            this.colsPartyType.Name = "colsPartyType";
            this.colsPartyType.NamedProperties.Put("EnumerateMethod", "");
            this.colsPartyType.NamedProperties.Put("FieldFlags", "263");
            this.colsPartyType.NamedProperties.Put("LovReference", "");
            this.colsPartyType.NamedProperties.Put("SqlColumn", "PARTY_TYPE");
            this.colsPartyType.NamedProperties.Put("ValidateMethod", "");
            this.colsPartyType.Position = 11;
            // 
            // colDefaultDomain
            // 
            resources.ApplyResources(this.colDefaultDomain, "colDefaultDomain");
            this.colDefaultDomain.Name = "colDefaultDomain";
            this.colDefaultDomain.NamedProperties.Put("EnumerateMethod", "");
            this.colDefaultDomain.NamedProperties.Put("FieldFlags", "263");
            this.colDefaultDomain.NamedProperties.Put("LovReference", "");
            this.colDefaultDomain.NamedProperties.Put("SqlColumn", "DEFAULT_DOMAIN");
            this.colDefaultDomain.NamedProperties.Put("ValidateMethod", "");
            this.colDefaultDomain.Position = 12;
            // 
            // colsExist
            // 
            resources.ApplyResources(this.colsExist, "colsExist");
            this.colsExist.Name = "colsExist";
            this.colsExist.Position = 14;
            // 
            // colsIdReferenceValidation
            // 
            this.colsIdReferenceValidation.MaxLength = 200;
            this.colsIdReferenceValidation.Name = "colsIdReferenceValidation";
            this.colsIdReferenceValidation.NamedProperties.Put("EnumerateMethod", "IDENTIFIER_REF_VALIDATION_API.Enumerate");
            this.colsIdReferenceValidation.NamedProperties.Put("FieldFlags", "294");
            this.colsIdReferenceValidation.NamedProperties.Put("LovReference", "");
            this.colsIdReferenceValidation.NamedProperties.Put("ResizeableChildObject", "");
            this.colsIdReferenceValidation.NamedProperties.Put("SqlColumn", "IDENTIFIER_REF_VALIDATION");
            this.colsIdReferenceValidation.NamedProperties.Put("ValidateMethod", "");
            this.colsIdReferenceValidation.Position = 15;
            resources.ApplyResources(this.colsIdReferenceValidation, "colsIdReferenceValidation");
            // 
            // colsCorporateForm
            // 
            resources.ApplyResources(this.colsCorporateForm, "colsCorporateForm");
            this.colsCorporateForm.MaxLength = 8;
            this.colsCorporateForm.Name = "colsCorporateForm";
            this.colsCorporateForm.NamedProperties.Put("EnumerateMethod", "");
            this.colsCorporateForm.NamedProperties.Put("FieldFlags", "262");
            this.colsCorporateForm.NamedProperties.Put("LovReference", "");
            this.colsCorporateForm.NamedProperties.Put("ResizeableChildObject", "");
            this.colsCorporateForm.NamedProperties.Put("SqlColumn", "CORPORATE_FORM");
            this.colsCorporateForm.NamedProperties.Put("ValidateMethod", "");
            this.colsCorporateForm.Position = 16;
            // 
            // colsOldCountry
            // 
            resources.ApplyResources(this.colsOldCountry, "colsOldCountry");
            this.colsOldCountry.MaxLength = 50;
            this.colsOldCountry.Name = "colsOldCountry";
            this.colsOldCountry.NamedProperties.Put("EnumerateMethod", "");
            this.colsOldCountry.NamedProperties.Put("LovReference", "");
            this.colsOldCountry.NamedProperties.Put("ResizeableChildObject", "");
            this.colsOldCountry.NamedProperties.Put("SqlColumn", "");
            this.colsOldCountry.NamedProperties.Put("ValidateMethod", "");
            this.colsOldCountry.Position = 17;
            // 
            // menuTbwMethods
            // 
            this.menuTbwMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem__Details,
            this.menuItem__Chg_Supp_Category,
            this.tsMenuItemSeparator,
            this.menuItem__Personal_Data_Consent});
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
            // menuItem__Chg_Supp_Category
            // 
            this.menuItem__Chg_Supp_Category.Command = this.menuTbwMethods_menu_Chg_Supp_Category___;
            this.menuItem__Chg_Supp_Category.Name = "menuItem__Chg_Supp_Category";
            resources.ApplyResources(this.menuItem__Chg_Supp_Category, "menuItem__Chg_Supp_Category");
            this.menuItem__Chg_Supp_Category.Text = "Change Supplier Category...";
            // 
            // menuTbwMethods_menu_Chg_Supp_Category___
            // 
            resources.ApplyResources(this.menuTbwMethods_menu_Chg_Supp_Category___, "menuTbwMethods_menu_Chg_Supp_Category___");
            this.menuTbwMethods_menu_Chg_Supp_Category___.Name = "menuTbwMethods_menu_Chg_Supp_Category___";
            this.menuTbwMethods_menu_Chg_Supp_Category___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Chg_Supp_Category_Execute);
            this.menuTbwMethods_menu_Chg_Supp_Category___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Chg_Supp_Category_Inquire);
            // 
            // tsMenuItemSeparator
            // 
            this.tsMenuItemSeparator.Name = "tsMenuItemSeparator";
            resources.ApplyResources(this.tsMenuItemSeparator, "tsMenuItemSeparator");
            // 
            // menuItem__Personal_Data_Consent
            // 
            this.menuItem__Personal_Data_Consent.Command = this.cmdManageDataProcessingPurposes;
            this.menuItem__Personal_Data_Consent.Name = "menuItem__Personal_Data_Consent";
            resources.ApplyResources(this.menuItem__Personal_Data_Consent, "menuItem__Personal_Data_Consent");
            this.menuItem__Personal_Data_Consent.Text = "Manage Data Processing Purposes...";
            // 
            // cmdManageDataProcessingPurposes
            // 
            resources.ApplyResources(this.cmdManageDataProcessingPurposes, "cmdManageDataProcessingPurposes");
            this.cmdManageDataProcessingPurposes.Name = "cmdManageDataProcessingPurposes";
            this.cmdManageDataProcessingPurposes.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.cmdManageDataProcessingPurposes_Execute);
            this.cmdManageDataProcessingPurposes.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.cmdManageDataProcessingPurposes_Inquire);
            // 
            // colsSupplierCategory
            // 
            this.colsSupplierCategory.MaxLength = 200;
            this.colsSupplierCategory.Name = "colsSupplierCategory";
            this.colsSupplierCategory.NamedProperties.Put("EnumerateMethod", "SUPPLIER_INFO_CATEGORY_API.Enumerate");
            this.colsSupplierCategory.NamedProperties.Put("FieldFlags", "291");
            this.colsSupplierCategory.NamedProperties.Put("LovReference", "");
            this.colsSupplierCategory.NamedProperties.Put("SqlColumn", "SUPPLIER_CATEGORY");
            this.colsSupplierCategory.Position = 8;
            resources.ApplyResources(this.colsSupplierCategory, "colsSupplierCategory");
            // 
            // colValidDataProcessingPurpose
            // 
            this.colValidDataProcessingPurpose.Name = "colValidDataProcessingPurpose";
            this.colValidDataProcessingPurpose.NamedProperties.Put("FieldFlags", "4384");
            this.colValidDataProcessingPurpose.NamedProperties.Put("SqlColumn", "Personal_Data_Man_Util_API.Is_Valid_Consent_By_Keys(\'SUPPLIER\',SUPPLIER_ID, NULL," +
        " trunc(SYSDATE))");
            this.colValidDataProcessingPurpose.Position = 13;
            resources.ApplyResources(this.colValidDataProcessingPurpose, "colValidDataProcessingPurpose");
            // 
            // tbwSupplierInfoOverview
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colsSupplierId);
            this.Controls.Add(this.colsName);
            this.Controls.Add(this.colsAssociationNo);
            this.Controls.Add(this.colsDefaultLanguage);
            this.Controls.Add(this.colsCountry);
            this.Controls.Add(this.colsSupplierCategory);
            this.Controls.Add(this.coldCreationDate);
            this.Controls.Add(this.colsParty);
            this.Controls.Add(this.colsPartyType);
            this.Controls.Add(this.colDefaultDomain);
            this.Controls.Add(this.colValidDataProcessingPurpose);
            this.Controls.Add(this.colsExist);
            this.Controls.Add(this.colsIdReferenceValidation);
            this.Controls.Add(this.colsCorporateForm);
            this.Controls.Add(this.colsOldCountry);
            this.Name = "tbwSupplierInfoOverview";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "SupplierInfoGeneral");
            this.NamedProperties.Put("PackageName", "SUPPLIER_INFO_GENERAL_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "0");
            this.NamedProperties.Put("ViewName", "SUPPLIER_INFO_GENERAL");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tbwSupplierInfoOverview_WindowActions);
            this.Controls.SetChildIndex(this.colsOldCountry, 0);
            this.Controls.SetChildIndex(this.colsCorporateForm, 0);
            this.Controls.SetChildIndex(this.colsIdReferenceValidation, 0);
            this.Controls.SetChildIndex(this.colsExist, 0);
            this.Controls.SetChildIndex(this.colValidDataProcessingPurpose, 0);
            this.Controls.SetChildIndex(this.colDefaultDomain, 0);
            this.Controls.SetChildIndex(this.colsPartyType, 0);
            this.Controls.SetChildIndex(this.colsParty, 0);
            this.Controls.SetChildIndex(this.coldCreationDate, 0);
            this.Controls.SetChildIndex(this.colsSupplierCategory, 0);
            this.Controls.SetChildIndex(this.colsCountry, 0);
            this.Controls.SetChildIndex(this.colsDefaultLanguage, 0);
            this.Controls.SetChildIndex(this.colsAssociationNo, 0);
            this.Controls.SetChildIndex(this.colsName, 0);
            this.Controls.SetChildIndex(this.colsSupplierId, 0);
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
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTbwMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Details;
        protected cLookupColumn colsSupplierCategory;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Chg_Supp_Category;
        protected Fnd.Windows.Forms.FndCommand menuTbwMethods_menu_Chg_Supp_Category___;
        public cCheckBoxColumn colValidDataProcessingPurpose;
        protected Fnd.Windows.Forms.FndCommand cmdManageDataProcessingPurposes;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Personal_Data_Consent;
        protected Fnd.Windows.Forms.FndToolStripSeparator tsMenuItemSeparator;
	}
}
