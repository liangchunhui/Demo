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
// 120711   maiklk  PBR-9, Added Customer Category field under General tab.
// 130115   MaRalk  PBR-1203, Removed LOV reference CUSTOMER_INFO from tblOurId-colsCustomerId column. 
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
	
	public partial class frmCustomerInfo
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		protected cBackgroundText labelcmbCustomerId;
		public cRecListDataField cmbCustomerId;
		protected cBackgroundText labeldfsName;
		public cDataField dfsName;
		protected cBackgroundText labeldfsAssociationNo;
		public cDataField dfsAssociationNo;
		protected cBackgroundText labelcmbDefaultLanguage;
		public cComboBox cmbDefaultLanguage;
		protected cBackgroundText labelcmbCountry;
		public cComboBox cmbCountry;
		public cDataField dfsCountryDb;
		protected cBackgroundText labeldfdCreationDate;
		public cDataField dfdCreationDate;
		public cDataField dfsParty;
		public cCheckBox cbDefaultDomain;
		public cComboBox cmbPartyType;
        protected SalGroupBox gbOur_ID_at_Customer;
		protected cBackgroundText labeldfsCorporateForm;
		public cDataField dfsCorporateForm;
		protected cBackgroundText labeldfsCorporateFormDesc;
		public cDataField dfsCorporateFormDesc;
		protected cBackgroundText labeldfsIdentifierReference;
		public cDataField dfsIdentifierReference;
		protected cBackgroundText labelcmbIdentifierRefValidation;
		public cComboBox cmbIdentifierRefValidation;
		public cDataField dfsExist;
		// ! Bug 79336, End
		public cPictureDataItem picPicture;
		protected SalGroupBox gbLogo;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomerInfo));
            this.menuFrmMethods_menu_Copy_Customer___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.labelcmbCustomerId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbCustomerId = new Ifs.Fnd.ApplicationForms.cRecListDataField();
            this.labeldfsName = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsName = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsAssociationNo = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsAssociationNo = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelcmbDefaultLanguage = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbDefaultLanguage = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.labelcmbCountry = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbCountry = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.dfsCountryDb = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfdCreationDate = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfdCreationDate = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsParty = new Ifs.Fnd.ApplicationForms.cDataField();
            this.cbDefaultDomain = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.cmbPartyType = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.gbOur_ID_at_Customer = new PPJ.Runtime.Windows.SalGroupBox();
            this.labeldfsCorporateForm = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsCorporateForm = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsCorporateFormDesc = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsCorporateFormDesc = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsIdentifierReference = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsIdentifierReference = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelcmbIdentifierRefValidation = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbIdentifierRefValidation = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.dfsExist = new Ifs.Fnd.ApplicationForms.cDataField();
            this.picPicture = new Ifs.Fnd.ApplicationForms.cPictureDataItem();
            this.gbLogo = new PPJ.Runtime.Windows.SalGroupBox();
            this.menuFrmMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem__Copy = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.tsMenuItemChangeCategory = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.cmdChangeCategory = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.tsMenuItemSeparator = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.tsMenuItemViewEndCustConnections = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.cmdEndCustConns = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.tsMenuItemViewB2BUsers = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.cmdViewB2BUsers = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.tsMenuItemSeparator1 = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.tsMenuItemManageDataProcessingPurposes = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.cmdManageDataProcessingPurposes = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.cbOneTimeDb = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.cmbCustomerCategory = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.labelcmbCustomerCategory = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cbB2bCustomer = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.tblOurId = new Ifs.Application.Enterp.cChildTableOnTab();
            this.tblOurId_colsCustomerId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblOurId_colsCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblOurId_colsOurId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.cbValidDataProcessingPurpose = new Ifs.Fnd.ApplicationForms.cCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.picPicture)).BeginInit();
            this.menuFrmMethods.SuspendLayout();
            this.tblOurId.SuspendLayout();
            this.SuspendLayout();
            // 
            // _cTabManager
            // 
            resources.ApplyResources(this._cTabManager, "_cTabManager");
            // 
            // picTab
            // 
            resources.ApplyResources(this.picTab, "picTab");
            this.picTab.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.picTab_WindowActions);
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuFrmMethods_menu_Copy_Customer___);
            this.commandManager.Commands.Add(this.cmdEndCustConns);
            this.commandManager.Commands.Add(this.cmdChangeCategory);
            this.commandManager.Commands.Add(this.cmdViewB2BUsers);
            this.commandManager.Commands.Add(this.cmdManageDataProcessingPurposes);
            this.commandManager.ContextMenus.Add(this.menuFrmMethods);
            this.commandManager.ImageList = null;
            // 
            // menuFrmMethods_menu_Copy_Customer___
            // 
            resources.ApplyResources(this.menuFrmMethods_menu_Copy_Customer___, "menuFrmMethods_menu_Copy_Customer___");
            this.menuFrmMethods_menu_Copy_Customer___.Name = "menuFrmMethods_menu_Copy_Customer___";
            this.menuFrmMethods_menu_Copy_Customer___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Copy_Execute);
            this.menuFrmMethods_menu_Copy_Customer___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Copy_Inquire);
            // 
            // labelcmbCustomerId
            // 
            resources.ApplyResources(this.labelcmbCustomerId, "labelcmbCustomerId");
            this.labelcmbCustomerId.Name = "labelcmbCustomerId";
            // 
            // cmbCustomerId
            // 
            this.cmbCustomerId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.cmbCustomerId, "cmbCustomerId");
            this.cmbCustomerId.Name = "cmbCustomerId";
            this.cmbCustomerId.NamedProperties.Put("EnumerateMethod", "");
            this.cmbCustomerId.NamedProperties.Put("FieldFlags", "162");
            this.cmbCustomerId.NamedProperties.Put("Format", "9");
            this.cmbCustomerId.NamedProperties.Put("LovReference", "CUSTOMER_INFO");
            this.cmbCustomerId.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbCustomerId.NamedProperties.Put("SqlColumn", "CUSTOMER_ID");
            this.cmbCustomerId.NamedProperties.Put("ValidateMethod", "");
            this.cmbCustomerId.NamedProperties.Put("XDataLength", "20");
            this.cmbCustomerId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbCustomerId_WindowActions);
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
            this.dfsName.NamedProperties.Put("FieldFlags", "295");
            this.dfsName.NamedProperties.Put("LovReference", "");
            this.dfsName.NamedProperties.Put("ParentName", "cmbCustomerId");
            this.dfsName.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsName.NamedProperties.Put("SqlColumn", "NAME");
            this.dfsName.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsAssociationNo
            // 
            resources.ApplyResources(this.labeldfsAssociationNo, "labeldfsAssociationNo");
            this.labeldfsAssociationNo.Name = "labeldfsAssociationNo";
            // 
            // dfsAssociationNo
            // 
            resources.ApplyResources(this.dfsAssociationNo, "dfsAssociationNo");
            this.dfsAssociationNo.Name = "dfsAssociationNo";
            this.dfsAssociationNo.NamedProperties.Put("EnumerateMethod", "");
            this.dfsAssociationNo.NamedProperties.Put("FieldFlags", "294");
            this.dfsAssociationNo.NamedProperties.Put("LovReference", "ASSOCIATION_INFO");
            this.dfsAssociationNo.NamedProperties.Put("ParentName", "cmbCustomerId");
            this.dfsAssociationNo.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsAssociationNo.NamedProperties.Put("SqlColumn", "ASSOCIATION_NO");
            this.dfsAssociationNo.NamedProperties.Put("ValidateMethod", "");
            this.dfsAssociationNo.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsAssociationNo_WindowActions);
            // 
            // labelcmbDefaultLanguage
            // 
            resources.ApplyResources(this.labelcmbDefaultLanguage, "labelcmbDefaultLanguage");
            this.labelcmbDefaultLanguage.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labelcmbDefaultLanguage, "Name0");
            this.labelcmbDefaultLanguage.Name = "labelcmbDefaultLanguage";
            // 
            // cmbDefaultLanguage
            // 
            this.picTab.SetControlTabPages(this.cmbDefaultLanguage, "Name0");
            resources.ApplyResources(this.cmbDefaultLanguage, "cmbDefaultLanguage");
            this.cmbDefaultLanguage.Name = "cmbDefaultLanguage";
            this.cmbDefaultLanguage.NamedProperties.Put("EnumerateMethod", "ISO_LANGUAGE_API.Enumerate");
            this.cmbDefaultLanguage.NamedProperties.Put("FieldFlags", "295");
            this.cmbDefaultLanguage.NamedProperties.Put("LovReference", "");
            this.cmbDefaultLanguage.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbDefaultLanguage.NamedProperties.Put("SqlColumn", "DEFAULT_LANGUAGE");
            this.cmbDefaultLanguage.NamedProperties.Put("ValidateMethod", "");
            // 
            // labelcmbCountry
            // 
            resources.ApplyResources(this.labelcmbCountry, "labelcmbCountry");
            this.labelcmbCountry.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labelcmbCountry, "Name0");
            this.labelcmbCountry.Name = "labelcmbCountry";
            // 
            // cmbCountry
            // 
            this.picTab.SetControlTabPages(this.cmbCountry, "Name0");
            this.cmbCountry.DropDownHeight = 336;
            resources.ApplyResources(this.cmbCountry, "cmbCountry");
            this.cmbCountry.Name = "cmbCountry";
            this.cmbCountry.NamedProperties.Put("EnumerateMethod", "ISO_COUNTRY_API.Enumerate");
            this.cmbCountry.NamedProperties.Put("FieldFlags", "295");
            this.cmbCountry.NamedProperties.Put("LovReference", "");
            this.cmbCountry.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbCountry.NamedProperties.Put("SqlColumn", "COUNTRY");
            this.cmbCountry.NamedProperties.Put("ValidateMethod", "");
            this.cmbCountry.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbCountry_WindowActions);
            // 
            // dfsCountryDb
            // 
            resources.ApplyResources(this.dfsCountryDb, "dfsCountryDb");
            this.dfsCountryDb.Name = "dfsCountryDb";
            this.dfsCountryDb.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCountryDb.NamedProperties.Put("FieldFlags", "262");
            this.dfsCountryDb.NamedProperties.Put("LovReference", "");
            this.dfsCountryDb.NamedProperties.Put("SqlColumn", "COUNTRY_DB");
            this.dfsCountryDb.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfdCreationDate
            // 
            resources.ApplyResources(this.labeldfdCreationDate, "labeldfdCreationDate");
            this.labeldfdCreationDate.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfdCreationDate, "Name0");
            this.labeldfdCreationDate.Name = "labeldfdCreationDate";
            // 
            // dfdCreationDate
            // 
            this.dfdCreationDate.BackColor = System.Drawing.SystemColors.Control;
            this.picTab.SetControlTabPages(this.dfdCreationDate, "Name0");
            this.dfdCreationDate.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            resources.ApplyResources(this.dfdCreationDate, "dfdCreationDate");
            this.dfdCreationDate.Format = "d";
            this.dfdCreationDate.Name = "dfdCreationDate";
            this.dfdCreationDate.NamedProperties.Put("EnumerateMethod", "");
            this.dfdCreationDate.NamedProperties.Put("FieldFlags", "288");
            this.dfdCreationDate.NamedProperties.Put("LovReference", "");
            this.dfdCreationDate.NamedProperties.Put("ResizeableChildObject", "");
            this.dfdCreationDate.NamedProperties.Put("SqlColumn", "CREATION_DATE");
            this.dfdCreationDate.NamedProperties.Put("ValidateMethod", "");
            this.dfdCreationDate.ReadOnly = true;
            // 
            // dfsParty
            // 
            resources.ApplyResources(this.dfsParty, "dfsParty");
            this.dfsParty.Name = "dfsParty";
            this.dfsParty.NamedProperties.Put("EnumerateMethod", "");
            this.dfsParty.NamedProperties.Put("FieldFlags", "262");
            this.dfsParty.NamedProperties.Put("LovReference", "");
            this.dfsParty.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsParty.NamedProperties.Put("SqlColumn", "PARTY");
            this.dfsParty.NamedProperties.Put("ValidateMethod", "");
            // 
            // cbDefaultDomain
            // 
            resources.ApplyResources(this.cbDefaultDomain, "cbDefaultDomain");
            this.cbDefaultDomain.Name = "cbDefaultDomain";
            this.cbDefaultDomain.NamedProperties.Put("DataType", "5");
            this.cbDefaultDomain.NamedProperties.Put("EnumerateMethod", "");
            this.cbDefaultDomain.NamedProperties.Put("FieldFlags", "263");
            this.cbDefaultDomain.NamedProperties.Put("LovReference", "");
            this.cbDefaultDomain.NamedProperties.Put("ResizeableChildObject", "");
            this.cbDefaultDomain.NamedProperties.Put("SqlColumn", "DEFAULT_DOMAIN");
            this.cbDefaultDomain.NamedProperties.Put("ValidateMethod", "");
            this.cbDefaultDomain.NamedProperties.Put("XDataLength", "");
            // 
            // cmbPartyType
            // 
            resources.ApplyResources(this.cmbPartyType, "cmbPartyType");
            this.cmbPartyType.Name = "cmbPartyType";
            this.cmbPartyType.NamedProperties.Put("EnumerateMethod", "PARTY_TYPE_API.Enumerate");
            this.cmbPartyType.NamedProperties.Put("FieldFlags", "263");
            this.cmbPartyType.NamedProperties.Put("LovReference", "");
            this.cmbPartyType.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbPartyType.NamedProperties.Put("SqlColumn", "PARTY_TYPE");
            this.cmbPartyType.NamedProperties.Put("ValidateMethod", "");
            // 
            // gbOur_ID_at_Customer
            // 
            this.gbOur_ID_at_Customer.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.gbOur_ID_at_Customer, "Name0");
            resources.ApplyResources(this.gbOur_ID_at_Customer, "gbOur_ID_at_Customer");
            this.gbOur_ID_at_Customer.Name = "gbOur_ID_at_Customer";
            this.gbOur_ID_at_Customer.TabStop = false;
            // 
            // labeldfsCorporateForm
            // 
            resources.ApplyResources(this.labeldfsCorporateForm, "labeldfsCorporateForm");
            this.labeldfsCorporateForm.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfsCorporateForm, "Name0");
            this.labeldfsCorporateForm.Name = "labeldfsCorporateForm";
            // 
            // dfsCorporateForm
            // 
            this.picTab.SetControlTabPages(this.dfsCorporateForm, "Name0");
            resources.ApplyResources(this.dfsCorporateForm, "dfsCorporateForm");
            this.dfsCorporateForm.Name = "dfsCorporateForm";
            this.dfsCorporateForm.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCorporateForm.NamedProperties.Put("FieldFlags", "294");
            this.dfsCorporateForm.NamedProperties.Put("LovReference", "CORPORATE_FORM(COUNTRY_DB)");
            this.dfsCorporateForm.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsCorporateForm.NamedProperties.Put("SqlColumn", "CORPORATE_FORM");
            this.dfsCorporateForm.NamedProperties.Put("ValidateMethod", "");
            this.dfsCorporateForm.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsCorporateForm_WindowActions);
            // 
            // labeldfsCorporateFormDesc
            // 
            resources.ApplyResources(this.labeldfsCorporateFormDesc, "labeldfsCorporateFormDesc");
            this.labeldfsCorporateFormDesc.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfsCorporateFormDesc, "Name0");
            this.labeldfsCorporateFormDesc.Name = "labeldfsCorporateFormDesc";
            // 
            // dfsCorporateFormDesc
            // 
            this.picTab.SetControlTabPages(this.dfsCorporateFormDesc, "Name0");
            resources.ApplyResources(this.dfsCorporateFormDesc, "dfsCorporateFormDesc");
            this.dfsCorporateFormDesc.Name = "dfsCorporateFormDesc";
            this.dfsCorporateFormDesc.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCorporateFormDesc.NamedProperties.Put("LovReference", "");
            this.dfsCorporateFormDesc.NamedProperties.Put("ParentName", "dfsCorporateForm");
            this.dfsCorporateFormDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsCorporateFormDesc.NamedProperties.Put("SqlColumn", "CORPORATE_FORM_API.Get_Corporate_Form_Desc(COUNTRY_DB, CORPORATE_FORM)");
            this.dfsCorporateFormDesc.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsIdentifierReference
            // 
            resources.ApplyResources(this.labeldfsIdentifierReference, "labeldfsIdentifierReference");
            this.labeldfsIdentifierReference.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfsIdentifierReference, "Name0");
            this.labeldfsIdentifierReference.Name = "labeldfsIdentifierReference";
            // 
            // dfsIdentifierReference
            // 
            this.picTab.SetControlTabPages(this.dfsIdentifierReference, "Name0");
            resources.ApplyResources(this.dfsIdentifierReference, "dfsIdentifierReference");
            this.dfsIdentifierReference.Name = "dfsIdentifierReference";
            this.dfsIdentifierReference.NamedProperties.Put("EnumerateMethod", "");
            this.dfsIdentifierReference.NamedProperties.Put("FieldFlags", "294");
            this.dfsIdentifierReference.NamedProperties.Put("LovReference", "");
            this.dfsIdentifierReference.NamedProperties.Put("SqlColumn", "IDENTIFIER_REFERENCE");
            // 
            // labelcmbIdentifierRefValidation
            // 
            resources.ApplyResources(this.labelcmbIdentifierRefValidation, "labelcmbIdentifierRefValidation");
            this.labelcmbIdentifierRefValidation.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labelcmbIdentifierRefValidation, "Name0");
            this.labelcmbIdentifierRefValidation.Name = "labelcmbIdentifierRefValidation";
            // 
            // cmbIdentifierRefValidation
            // 
            this.picTab.SetControlTabPages(this.cmbIdentifierRefValidation, "Name0");
            resources.ApplyResources(this.cmbIdentifierRefValidation, "cmbIdentifierRefValidation");
            this.cmbIdentifierRefValidation.Name = "cmbIdentifierRefValidation";
            this.cmbIdentifierRefValidation.NamedProperties.Put("EnumerateMethod", "IDENTIFIER_REF_VALIDATION_API.Enumerate");
            this.cmbIdentifierRefValidation.NamedProperties.Put("FieldFlags", "295");
            this.cmbIdentifierRefValidation.NamedProperties.Put("LovReference", "");
            this.cmbIdentifierRefValidation.NamedProperties.Put("SqlColumn", "IDENTIFIER_REF_VALIDATION");
            // 
            // dfsExist
            // 
            resources.ApplyResources(this.dfsExist, "dfsExist");
            this.dfsExist.Name = "dfsExist";
            // 
            // picPicture
            // 
            this.picTab.SetControlTabPages(this.picPicture, "Name0");
            resources.ApplyResources(this.picPicture, "picPicture");
            this.picPicture.Name = "picPicture";
            this.picPicture.NamedProperties.Put("EnumerateMethod", "");
            this.picPicture.NamedProperties.Put("FieldFlags", "294");
            this.picPicture.NamedProperties.Put("LovReference", "");
            this.picPicture.NamedProperties.Put("ResizeableChildObject", "");
            this.picPicture.NamedProperties.Put("SqlColumn", "PICTURE_ID");
            this.picPicture.NamedProperties.Put("ValidateMethod", "");
            this.picPicture.NamedProperties.Put("XDataLength", "");
            this.picPicture.TabStop = false;
            // 
            // gbLogo
            // 
            this.gbLogo.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.gbLogo, "Name0");
            resources.ApplyResources(this.gbLogo, "gbLogo");
            this.gbLogo.Name = "gbLogo";
            this.gbLogo.TabStop = false;
            // 
            // menuFrmMethods
            // 
            this.menuFrmMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem__Copy,
            this.tsMenuItemChangeCategory,
            this.tsMenuItemSeparator,
            this.tsMenuItemViewEndCustConnections,
            this.tsMenuItemViewB2BUsers,
            this.tsMenuItemSeparator1,
            this.tsMenuItemManageDataProcessingPurposes});
            this.menuFrmMethods.Name = "menuFrmMethods";
            resources.ApplyResources(this.menuFrmMethods, "menuFrmMethods");
            // 
            // menuItem__Copy
            // 
            this.menuItem__Copy.Command = this.menuFrmMethods_menu_Copy_Customer___;
            this.menuItem__Copy.Name = "menuItem__Copy";
            resources.ApplyResources(this.menuItem__Copy, "menuItem__Copy");
            this.menuItem__Copy.Text = "&Copy Customer...";
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
            // tsMenuItemViewEndCustConnections
            // 
            this.tsMenuItemViewEndCustConnections.Command = this.cmdEndCustConns;
            this.tsMenuItemViewEndCustConnections.Name = "tsMenuItemViewEndCustConnections";
            resources.ApplyResources(this.tsMenuItemViewEndCustConnections, "tsMenuItemViewEndCustConnections");
            this.tsMenuItemViewEndCustConnections.Text = "View End Customer Connections...";
            // 
            // cmdEndCustConns
            // 
            resources.ApplyResources(this.cmdEndCustConns, "cmdEndCustConns");
            this.cmdEndCustConns.Name = "cmdEndCustConns";
            this.cmdEndCustConns.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.cmdEndCustConns_Execute);
            this.cmdEndCustConns.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.cmdEndCustConns_Inquire);
            // 
            // tsMenuItemViewB2BUsers
            // 
            this.tsMenuItemViewB2BUsers.Command = this.cmdViewB2BUsers;
            this.tsMenuItemViewB2BUsers.Name = "tsMenuItemViewB2BUsers";
            resources.ApplyResources(this.tsMenuItemViewB2BUsers, "tsMenuItemViewB2BUsers");
            this.tsMenuItemViewB2BUsers.Text = "View B2B &Users...";
            // 
            // cmdViewB2BUsers
            // 
            resources.ApplyResources(this.cmdViewB2BUsers, "cmdViewB2BUsers");
            this.cmdViewB2BUsers.Name = "cmdViewB2BUsers";
            this.cmdViewB2BUsers.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.cmdViewB2BUsers_Execute);
            this.cmdViewB2BUsers.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.cmdViewB2BUsers_Inquire);
            // 
            // tsMenuItemSeparator1
            // 
            this.tsMenuItemSeparator1.Name = "tsMenuItemSeparator1";
            resources.ApplyResources(this.tsMenuItemSeparator1, "tsMenuItemSeparator1");
            // 
            // tsMenuItemManageDataProcessingPurposes
            // 
            this.tsMenuItemManageDataProcessingPurposes.Command = this.cmdManageDataProcessingPurposes;
            this.tsMenuItemManageDataProcessingPurposes.Name = "tsMenuItemManageDataProcessingPurposes";
            resources.ApplyResources(this.tsMenuItemManageDataProcessingPurposes, "tsMenuItemManageDataProcessingPurposes");
            this.tsMenuItemManageDataProcessingPurposes.Text = "Manage Data Processing Purposes...";
            // 
            // cmdManageDataProcessingPurposes
            // 
            resources.ApplyResources(this.cmdManageDataProcessingPurposes, "cmdManageDataProcessingPurposes");
            this.cmdManageDataProcessingPurposes.Name = "cmdManageDataProcessingPurposes";
            this.cmdManageDataProcessingPurposes.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.cmdManageDataProcessingPurposes_Execute);
            this.cmdManageDataProcessingPurposes.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.cmdManageDataProcessingPurposes_Inquire);
            // 
            // cbOneTimeDb
            // 
            resources.ApplyResources(this.cbOneTimeDb, "cbOneTimeDb");
            this.cbOneTimeDb.BackColor = System.Drawing.SystemColors.Control;
            this.picTab.SetControlTabPages(this.cbOneTimeDb, "Name0");
            this.cbOneTimeDb.Name = "cbOneTimeDb";
            this.cbOneTimeDb.NamedProperties.Put("EnumerateMethod", "");
            this.cbOneTimeDb.NamedProperties.Put("FieldFlags", "295");
            this.cbOneTimeDb.NamedProperties.Put("LovReference", "");
            this.cbOneTimeDb.NamedProperties.Put("SqlColumn", "ONE_TIME_DB");
            this.cbOneTimeDb.UseVisualStyleBackColor = false;
            this.cbOneTimeDb.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbOneTimeDb_WindowActions);
            // 
            // cmbCustomerCategory
            // 
            this.picTab.SetControlTabPages(this.cmbCustomerCategory, "Name0");
            resources.ApplyResources(this.cmbCustomerCategory, "cmbCustomerCategory");
            this.cmbCustomerCategory.Name = "cmbCustomerCategory";
            this.cmbCustomerCategory.NamedProperties.Put("EnumerateMethod", "CUSTOMER_CATEGORY_API.Enumerate");
            this.cmbCustomerCategory.NamedProperties.Put("FieldFlags", "291");
            this.cmbCustomerCategory.NamedProperties.Put("LovReference", "");
            this.cmbCustomerCategory.NamedProperties.Put("ParentName", "cmbCustomerId");
            this.cmbCustomerCategory.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbCustomerCategory.NamedProperties.Put("SqlColumn", "CUSTOMER_CATEGORY");
            this.cmbCustomerCategory.NamedProperties.Put("ValidateMethod", "");
            // 
            // labelcmbCustomerCategory
            // 
            resources.ApplyResources(this.labelcmbCustomerCategory, "labelcmbCustomerCategory");
            this.labelcmbCustomerCategory.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labelcmbCustomerCategory, "Name0");
            this.labelcmbCustomerCategory.Name = "labelcmbCustomerCategory";
            // 
            // cbB2bCustomer
            // 
            resources.ApplyResources(this.cbB2bCustomer, "cbB2bCustomer");
            this.picTab.SetControlTabPages(this.cbB2bCustomer, "Name0");
            this.cbB2bCustomer.Name = "cbB2bCustomer";
            this.cbB2bCustomer.NamedProperties.Put("EnumerateMethod", "");
            this.cbB2bCustomer.NamedProperties.Put("FieldFlags", "292");
            this.cbB2bCustomer.NamedProperties.Put("LovReference", "");
            this.cbB2bCustomer.NamedProperties.Put("LovTimeReference", "");
            this.cbB2bCustomer.NamedProperties.Put("SqlColumn", "B2B_CUSTOMER_DB");
            // 
            // tblOurId
            // 
            this.tblOurId.Controls.Add(this.tblOurId_colsCustomerId);
            this.tblOurId.Controls.Add(this.tblOurId_colsCompany);
            this.tblOurId.Controls.Add(this.tblOurId_colsOurId);
            this.picTab.SetControlTabPages(this.tblOurId, "Name0");
            resources.ApplyResources(this.tblOurId, "tblOurId");
            this.tblOurId.Name = "tblOurId";
            this.tblOurId.NamedProperties.Put("DefaultOrderBy", "");
            this.tblOurId.NamedProperties.Put("DefaultWhere", "");
            this.tblOurId.NamedProperties.Put("LogicalUnit", "CustomerInfoOurId");
            this.tblOurId.NamedProperties.Put("PackageName", "CUSTOMER_INFO_OUR_ID_API");
            this.tblOurId.NamedProperties.Put("ResizeableChildObject", "");
            this.tblOurId.NamedProperties.Put("ViewName", "CUSTOMER_INFO_OUR_ID_FIN_AUTH");
            this.tblOurId.NamedProperties.Put("Warnings", "FALSE");
            this.tblOurId.Controls.SetChildIndex(this.tblOurId_colsOurId, 0);
            this.tblOurId.Controls.SetChildIndex(this.tblOurId_colsCompany, 0);
            this.tblOurId.Controls.SetChildIndex(this.tblOurId_colsCustomerId, 0);
            // 
            // tblOurId_colsCustomerId
            // 
            this.tblOurId_colsCustomerId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblOurId_colsCustomerId, "tblOurId_colsCustomerId");
            this.tblOurId_colsCustomerId.MaxLength = 20;
            this.tblOurId_colsCustomerId.Name = "tblOurId_colsCustomerId";
            this.tblOurId_colsCustomerId.NamedProperties.Put("EnumerateMethod", "");
            this.tblOurId_colsCustomerId.NamedProperties.Put("FieldFlags", "67");
            this.tblOurId_colsCustomerId.NamedProperties.Put("LovReference", "");
            this.tblOurId_colsCustomerId.NamedProperties.Put("SqlColumn", "CUSTOMER_ID");
            this.tblOurId_colsCustomerId.Position = 3;
            // 
            // tblOurId_colsCompany
            // 
            this.tblOurId_colsCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblOurId_colsCompany.MaxLength = 20;
            this.tblOurId_colsCompany.Name = "tblOurId_colsCompany";
            this.tblOurId_colsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.tblOurId_colsCompany.NamedProperties.Put("FieldFlags", "167");
            this.tblOurId_colsCompany.NamedProperties.Put("LovReference", "COMPANY_FINANCE");
            this.tblOurId_colsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.tblOurId_colsCompany.Position = 4;
            resources.ApplyResources(this.tblOurId_colsCompany, "tblOurId_colsCompany");
            // 
            // tblOurId_colsOurId
            // 
            this.tblOurId_colsOurId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblOurId_colsOurId.MaxLength = 20;
            this.tblOurId_colsOurId.Name = "tblOurId_colsOurId";
            this.tblOurId_colsOurId.NamedProperties.Put("EnumerateMethod", "");
            this.tblOurId_colsOurId.NamedProperties.Put("FieldFlags", "295");
            this.tblOurId_colsOurId.NamedProperties.Put("LovReference", "");
            this.tblOurId_colsOurId.NamedProperties.Put("ResizeableChildObject", "");
            this.tblOurId_colsOurId.NamedProperties.Put("SqlColumn", "OUR_ID");
            this.tblOurId_colsOurId.NamedProperties.Put("ValidateMethod", "");
            this.tblOurId_colsOurId.Position = 5;
            resources.ApplyResources(this.tblOurId_colsOurId, "tblOurId_colsOurId");
            // 
            // cbValidDataProcessingPurpose
            // 
            resources.ApplyResources(this.cbValidDataProcessingPurpose, "cbValidDataProcessingPurpose");
            this.picTab.SetControlTabPages(this.cbValidDataProcessingPurpose, "Name0");
            this.cbValidDataProcessingPurpose.Name = "cbValidDataProcessingPurpose";
            this.cbValidDataProcessingPurpose.NamedProperties.Put("FieldFlags", "288");
            this.cbValidDataProcessingPurpose.NamedProperties.Put("SqlColumn", "Personal_Data_Man_Util_API.Is_Valid_Consent_By_Keys(\'CUSTOMER\',CUSTOMER_ID, NULL," +
        " trunc(SYSDATE))");
            // 
            // frmCustomerInfo
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.cbValidDataProcessingPurpose);
            this.Controls.Add(this.tblOurId);
            this.Controls.Add(this.cbB2bCustomer);
            this.Controls.Add(this.cmbCustomerCategory);
            this.Controls.Add(this.labelcmbCustomerCategory);
            this.Controls.Add(this.cbOneTimeDb);
            this.Controls.Add(this.dfsExist);
            this.Controls.Add(this.cmbIdentifierRefValidation);
            this.Controls.Add(this.dfsIdentifierReference);
            this.Controls.Add(this.dfsCorporateFormDesc);
            this.Controls.Add(this.dfsCorporateForm);
            this.Controls.Add(this.cmbPartyType);
            this.Controls.Add(this.cbDefaultDomain);
            this.Controls.Add(this.dfsParty);
            this.Controls.Add(this.dfdCreationDate);
            this.Controls.Add(this.dfsCountryDb);
            this.Controls.Add(this.cmbCountry);
            this.Controls.Add(this.cmbDefaultLanguage);
            this.Controls.Add(this.dfsAssociationNo);
            this.Controls.Add(this.dfsName);
            this.Controls.Add(this.cmbCustomerId);
            this.Controls.Add(this.labelcmbIdentifierRefValidation);
            this.Controls.Add(this.labeldfsIdentifierReference);
            this.Controls.Add(this.labeldfsCorporateFormDesc);
            this.Controls.Add(this.labeldfsCorporateForm);
            this.Controls.Add(this.labeldfdCreationDate);
            this.Controls.Add(this.labelcmbCountry);
            this.Controls.Add(this.labelcmbDefaultLanguage);
            this.Controls.Add(this.labeldfsAssociationNo);
            this.Controls.Add(this.labeldfsName);
            this.Controls.Add(this.labelcmbCustomerId);
            this.Controls.Add(this.gbLogo);
            this.Controls.Add(this.gbOur_ID_at_Customer);
            this.Controls.Add(this.picPicture);
            this.Name = "frmCustomerInfo";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "CustomerInfo");
            this.NamedProperties.Put("PackageName", "CUSTOMER_INFO_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "4545");
            this.NamedProperties.Put("ViewName", "CUSTOMER_INFO");
            this.NamedProperties.Put("Warnings", "TRUE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.frmCustomerInfo_WindowActions);
            this.Controls.SetChildIndex(this.picTab, 0);
            this.Controls.SetChildIndex(this.picPicture, 0);
            this.Controls.SetChildIndex(this.gbOur_ID_at_Customer, 0);
            this.Controls.SetChildIndex(this.gbLogo, 0);
            this.Controls.SetChildIndex(this.labelcmbCustomerId, 0);
            this.Controls.SetChildIndex(this.labeldfsName, 0);
            this.Controls.SetChildIndex(this.labeldfsAssociationNo, 0);
            this.Controls.SetChildIndex(this.labelcmbDefaultLanguage, 0);
            this.Controls.SetChildIndex(this.labelcmbCountry, 0);
            this.Controls.SetChildIndex(this.labeldfdCreationDate, 0);
            this.Controls.SetChildIndex(this.labeldfsCorporateForm, 0);
            this.Controls.SetChildIndex(this.labeldfsCorporateFormDesc, 0);
            this.Controls.SetChildIndex(this.labeldfsIdentifierReference, 0);
            this.Controls.SetChildIndex(this.labelcmbIdentifierRefValidation, 0);
            this.Controls.SetChildIndex(this.cmbCustomerId, 0);
            this.Controls.SetChildIndex(this.dfsName, 0);
            this.Controls.SetChildIndex(this.dfsAssociationNo, 0);
            this.Controls.SetChildIndex(this.cmbDefaultLanguage, 0);
            this.Controls.SetChildIndex(this.cmbCountry, 0);
            this.Controls.SetChildIndex(this.dfsCountryDb, 0);
            this.Controls.SetChildIndex(this.dfdCreationDate, 0);
            this.Controls.SetChildIndex(this.dfsParty, 0);
            this.Controls.SetChildIndex(this.cbDefaultDomain, 0);
            this.Controls.SetChildIndex(this.cmbPartyType, 0);
            this.Controls.SetChildIndex(this.dfsCorporateForm, 0);
            this.Controls.SetChildIndex(this.dfsCorporateFormDesc, 0);
            this.Controls.SetChildIndex(this.dfsIdentifierReference, 0);
            this.Controls.SetChildIndex(this.cmbIdentifierRefValidation, 0);
            this.Controls.SetChildIndex(this.dfsExist, 0);
            this.Controls.SetChildIndex(this.cbOneTimeDb, 0);
            this.Controls.SetChildIndex(this.labelcmbCustomerCategory, 0);
            this.Controls.SetChildIndex(this.cmbCustomerCategory, 0);
            this.Controls.SetChildIndex(this.cbB2bCustomer, 0);
            this.Controls.SetChildIndex(this.tblOurId, 0);
            this.Controls.SetChildIndex(this.cbValidDataProcessingPurpose, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picPicture)).EndInit();
            this.menuFrmMethods.ResumeLayout(false);
            this.tblOurId.ResumeLayout(false);
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

        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menu_Copy_Customer___;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuFrmMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Copy;
        public cCheckBox cbOneTimeDb;
        public cComboBox cmbCustomerCategory;
        protected cBackgroundText labelcmbCustomerCategory;
        protected Fnd.Windows.Forms.FndCommand cmdEndCustConns;
        protected Fnd.Windows.Forms.FndToolStripMenuItem tsMenuItemViewEndCustConnections;
        public cChildTableOnTab tblOurId;
        protected cColumn tblOurId_colsCustomerId;
        protected cColumn tblOurId_colsCompany;
        protected cColumn tblOurId_colsOurId;
        protected Fnd.Windows.Forms.FndCommand cmdChangeCategory;
        protected Fnd.Windows.Forms.FndToolStripMenuItem tsMenuItemChangeCategory;
        protected Fnd.Windows.Forms.FndToolStripSeparator tsMenuItemSeparator;
        protected Fnd.Windows.Forms.FndCommand cmdViewB2BUsers;
        protected Fnd.Windows.Forms.FndToolStripMenuItem tsMenuItemViewB2BUsers;
        protected cCheckBox cbB2bCustomer;
        public cCheckBox cbValidDataProcessingPurpose;
        protected Fnd.Windows.Forms.FndCommand cmdManageDataProcessingPurposes;
        protected Fnd.Windows.Forms.FndToolStripSeparator tsMenuItemSeparator1;
        protected Fnd.Windows.Forms.FndToolStripMenuItem tsMenuItemManageDataProcessingPurposes;
	}
}
