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
	
	public partial class tbwCustomerInfoOverview
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cColumn colsCustomerId;
		public cColumn colsName;
		public cColumn colsAssociationNo;
		public cLookupColumn colsDefaultLanguage;
		public cLookupColumn colsCountry;
		public cColumn coldCreationDate;
		public cColumn colsParty;
		public cColumn colsPartyType;
		public cCheckBoxColumn colDefaultDomain;
		public cColumn colsExist;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwCustomerInfoOverview));
            this.menuTbwMethods_menu_Details___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.colsCustomerId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsAssociationNo = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsDefaultLanguage = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.colsCountry = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.coldCreationDate = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsParty = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsPartyType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colDefaultDomain = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.colsExist = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsCorporateForm = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsOldCountry = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuTbwMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem__Details = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.tsMenuItemChangeCategory = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.cmdChangeCategory = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.tsMenuItemSeparator = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.tsMenuItemPersonalDataConsent = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.cmdManageDataProcessingPurposes = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.colsCustomerCategory = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.colValidDataProcessingPurpose = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.menuTbwMethods.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuTbwMethods_menu_Details___);
            this.commandManager.Commands.Add(this.cmdChangeCategory);
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
            // colsCustomerId
            // 
            this.colsCustomerId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsCustomerId.MaxLength = 20;
            this.colsCustomerId.Name = "colsCustomerId";
            this.colsCustomerId.NamedProperties.Put("EnumerateMethod", "");
            this.colsCustomerId.NamedProperties.Put("FieldFlags", "162");
            this.colsCustomerId.NamedProperties.Put("LovReference", "CUSTOMER_INFO");
            this.colsCustomerId.NamedProperties.Put("ResizeableChildObject", "");
            this.colsCustomerId.NamedProperties.Put("SqlColumn", "CUSTOMER_ID");
            this.colsCustomerId.NamedProperties.Put("ValidateMethod", "");
            this.colsCustomerId.Position = 3;
            resources.ApplyResources(this.colsCustomerId, "colsCustomerId");
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
            this.colsCorporateForm.Position = 15;
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
            this.colsOldCountry.Position = 16;
            // 
            // menuTbwMethods
            // 
            this.menuTbwMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem__Details,
            this.tsMenuItemChangeCategory,
            this.tsMenuItemSeparator,
            this.tsMenuItemPersonalDataConsent});
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
            // tsMenuItemChangeCategory
            // 
            this.tsMenuItemChangeCategory.Command = this.cmdChangeCategory;
            this.tsMenuItemChangeCategory.Name = "tsMenuItemChangeCategory";
            resources.ApplyResources(this.tsMenuItemChangeCategory, "tsMenuItemChangeCategory");
            this.tsMenuItemChangeCategory.Text = "Change Cus&tomer Category...";
            // 
            // cmdChangeCategory
            // 
            resources.ApplyResources(this.cmdChangeCategory, "cmdChangeCategory");
            this.cmdChangeCategory.Name = "cmdChangeCategory";
            this.cmdChangeCategory.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.cmdChangeCategory_Execute);
            this.cmdChangeCategory.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.cmdChangeCategory_Inquire);
            // 
            // tsMenuItemSeparator
            // 
            this.tsMenuItemSeparator.Name = "tsMenuItemSeparator";
            resources.ApplyResources(this.tsMenuItemSeparator, "tsMenuItemSeparator");
            // 
            // tsMenuItemPersonalDataConsent
            // 
            this.tsMenuItemPersonalDataConsent.Command = this.cmdManageDataProcessingPurposes;
            this.tsMenuItemPersonalDataConsent.Name = "tsMenuItemPersonalDataConsent";
            resources.ApplyResources(this.tsMenuItemPersonalDataConsent, "tsMenuItemPersonalDataConsent");
            this.tsMenuItemPersonalDataConsent.Text = "Manage Data Processing Purposes...";
            // 
            // cmdManageDataProcessingPurposes
            // 
            resources.ApplyResources(this.cmdManageDataProcessingPurposes, "cmdManageDataProcessingPurposes");
            this.cmdManageDataProcessingPurposes.Name = "cmdManageDataProcessingPurposes";
            this.cmdManageDataProcessingPurposes.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.cmdManageDataProcessingPurposes_Execute);
            this.cmdManageDataProcessingPurposes.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.cmdManageDataProcessingPurposes_Inquire);
            // 
            // colsCustomerCategory
            // 
            this.colsCustomerCategory.MaxLength = 200;
            this.colsCustomerCategory.Name = "colsCustomerCategory";
            this.colsCustomerCategory.NamedProperties.Put("EnumerateMethod", "CUSTOMER_CATEGORY_API.Enumerate");
            this.colsCustomerCategory.NamedProperties.Put("FieldFlags", "291");
            this.colsCustomerCategory.NamedProperties.Put("LovReference", "");
            this.colsCustomerCategory.NamedProperties.Put("SqlColumn", "CUSTOMER_CATEGORY");
            this.colsCustomerCategory.Position = 8;
            resources.ApplyResources(this.colsCustomerCategory, "colsCustomerCategory");
            // 
            // colValidDataProcessingPurpose
            // 
            this.colValidDataProcessingPurpose.Name = "colValidDataProcessingPurpose";
            this.colValidDataProcessingPurpose.NamedProperties.Put("FieldFlags", "4384");
            this.colValidDataProcessingPurpose.NamedProperties.Put("SqlColumn", "Personal_Data_Man_Util_API.Is_Valid_Consent_By_Keys(\'CUSTOMER\',CUSTOMER_ID, NULL," +
        " trunc(SYSDATE))");
            this.colValidDataProcessingPurpose.Position = 13;
            resources.ApplyResources(this.colValidDataProcessingPurpose, "colValidDataProcessingPurpose");
            // 
            // tbwCustomerInfoOverview
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colsCustomerId);
            this.Controls.Add(this.colsName);
            this.Controls.Add(this.colsAssociationNo);
            this.Controls.Add(this.colsDefaultLanguage);
            this.Controls.Add(this.colsCountry);
            this.Controls.Add(this.colsCustomerCategory);
            this.Controls.Add(this.coldCreationDate);
            this.Controls.Add(this.colsParty);
            this.Controls.Add(this.colsPartyType);
            this.Controls.Add(this.colDefaultDomain);
            this.Controls.Add(this.colValidDataProcessingPurpose);
            this.Controls.Add(this.colsExist);
            this.Controls.Add(this.colsCorporateForm);
            this.Controls.Add(this.colsOldCountry);
            this.Name = "tbwCustomerInfoOverview";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "CustomerInfo");
            this.NamedProperties.Put("PackageName", "CUSTOMER_INFO_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "0");
            this.NamedProperties.Put("ViewName", "CUSTOMER_INFO");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tbwCustomerInfoOverview_WindowActions);
            this.Controls.SetChildIndex(this.colsOldCountry, 0);
            this.Controls.SetChildIndex(this.colsCorporateForm, 0);
            this.Controls.SetChildIndex(this.colsExist, 0);
            this.Controls.SetChildIndex(this.colValidDataProcessingPurpose, 0);
            this.Controls.SetChildIndex(this.colDefaultDomain, 0);
            this.Controls.SetChildIndex(this.colsPartyType, 0);
            this.Controls.SetChildIndex(this.colsParty, 0);
            this.Controls.SetChildIndex(this.coldCreationDate, 0);
            this.Controls.SetChildIndex(this.colsCustomerCategory, 0);
            this.Controls.SetChildIndex(this.colsCountry, 0);
            this.Controls.SetChildIndex(this.colsDefaultLanguage, 0);
            this.Controls.SetChildIndex(this.colsAssociationNo, 0);
            this.Controls.SetChildIndex(this.colsName, 0);
            this.Controls.SetChildIndex(this.colsCustomerId, 0);
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
        protected cLookupColumn colsCustomerCategory;
        protected Fnd.Windows.Forms.FndCommand cmdChangeCategory;
        protected Fnd.Windows.Forms.FndToolStripMenuItem tsMenuItemChangeCategory;
        protected Fnd.Windows.Forms.FndCommand cmdManageDataProcessingPurposes;
        protected Fnd.Windows.Forms.FndToolStripMenuItem tsMenuItemPersonalDataConsent;
        protected cCheckBoxColumn colValidDataProcessingPurpose;
        protected Fnd.Windows.Forms.FndToolStripSeparator tsMenuItemSeparator;
	}
}
