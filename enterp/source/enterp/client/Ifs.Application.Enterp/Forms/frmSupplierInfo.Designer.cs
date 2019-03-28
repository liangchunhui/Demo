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
// 150528   RoJalk  ORA-499, Changed the connected view SUPPLIER_INFO to SUPPLIER_INFO_GENERAL.
// 150609   RoJalk  ORA-496, Added cmbSupplierCategory.
// 160610   SudJlk  ORA-570, Added window action picTab_OnSAM_Create.
// 150602   RoJalk  ORA-499, Changed the main WindowRegistration entry to the view SUPPLIER_INFO_GENERAL.
// 150707   RoJalk  ORA-775, Added the RMB to Change Supplier Category.
// 150801   RoJalk  AFT-1657, Added the hidden column dfsSuppCategory to be used in RMB enable logic in frmSupplier.
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
	
	public partial class frmSupplierInfo
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		protected cBackgroundText labelcmbSupplierId;
		public cRecListDataField cmbSupplierId;
		protected cBackgroundText labeldfsName;
		public cDataField dfsName;
		protected cBackgroundText labeldfsAssociationNo;
		public cDataField dfsAssociationNo;
		protected cBackgroundText labelcmbDefaultLanguage;
		public cComboBox cmbDefaultLanguage;
		protected cBackgroundText labelcmbCountry;
		public cComboBox cmbCountry;
		protected cBackgroundText labeldfsSuppliersOwnId;
		public cDataField dfsSuppliersOwnId;
        protected SalGroupBox gbOur_ID_at_Supplier;
		protected cBackgroundText labeldfdCreationDate;
		public cDataField dfdCreationDate;
		protected cBackgroundText labeldfsCorporateForm;
		public cDataField dfsCorporateForm;
		protected cBackgroundText labeldfsCorporateFormDesc;
		public cDataField dfsCorporateFormDesc;
		protected cBackgroundText labeldfsIdentifierReference;
		public cDataField dfsIdentifierReference;
		protected cBackgroundText labelcmbIdentifierRefValidation;
		public cComboBox cmbIdentifierRefValidation;
		// ! Bug 79336, End
		public cDataField dfsExist;
		public cDataField dfsParty;
		protected cBackgroundText labeldfsCountryDb;
		public cDataField dfsCountryDb;
		public cCheckBox cbDefaultDomain;
		public cComboBox cmbPartyType;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSupplierInfo));
            this.menuFrmMethods_menu_Copy_Supplier___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.labelcmbSupplierId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbSupplierId = new Ifs.Fnd.ApplicationForms.cRecListDataField();
            this.labeldfsName = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsName = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsAssociationNo = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsAssociationNo = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelcmbDefaultLanguage = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbDefaultLanguage = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.labelcmbCountry = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbCountry = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.labeldfsSuppliersOwnId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsSuppliersOwnId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.gbOur_ID_at_Supplier = new PPJ.Runtime.Windows.SalGroupBox();
            this.labeldfdCreationDate = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfdCreationDate = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsCorporateForm = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsCorporateForm = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsCorporateFormDesc = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsCorporateFormDesc = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsIdentifierReference = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsIdentifierReference = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelcmbIdentifierRefValidation = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbIdentifierRefValidation = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.dfsExist = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsParty = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsCountryDb = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsCountryDb = new Ifs.Fnd.ApplicationForms.cDataField();
            this.cbDefaultDomain = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.cmbPartyType = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.menuFrmMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem__Copy = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem__Chg_Supp_Category = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuFrmMethods_menu_Chg_Supp_Category___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.tsMenuItemViewB2BUsers = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.cmdViewB2BUsers = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.tsMenuItemSeparator = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.tsMenuItemManageDataProcessingPurposes = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.cmdManageDataProcessingPurposes = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.picPicture = new Ifs.Fnd.ApplicationForms.cPictureDataItem();
            this.gbLogo = new PPJ.Runtime.Windows.SalGroupBox();
            this.cbOneTimeDb = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.labelcmbSupplierCategory = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbSupplierCategory = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.dfsSuppCategory = new Ifs.Fnd.ApplicationForms.cDataField();
            this.cbB2bSupplier = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.tblOurId = new Ifs.Application.Enterp.cChildTableOnTab();
            this.tblOurId_colsCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblOurId_colsOurId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblOurId_colsSupplierId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.cbValidDataProcessingPurpose = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.menuFrmMethods.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPicture)).BeginInit();
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
            this.commandManager.Commands.Add(this.menuFrmMethods_menu_Copy_Supplier___);
            this.commandManager.Commands.Add(this.menuFrmMethods_menu_Chg_Supp_Category___);
            this.commandManager.Commands.Add(this.cmdViewB2BUsers);
            this.commandManager.Commands.Add(this.cmdManageDataProcessingPurposes);
            this.commandManager.ContextMenus.Add(this.menuFrmMethods);
            // 
            // menuFrmMethods_menu_Copy_Supplier___
            // 
            resources.ApplyResources(this.menuFrmMethods_menu_Copy_Supplier___, "menuFrmMethods_menu_Copy_Supplier___");
            this.menuFrmMethods_menu_Copy_Supplier___.Name = "menuFrmMethods_menu_Copy_Supplier___";
            this.menuFrmMethods_menu_Copy_Supplier___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Copy_Execute);
            this.menuFrmMethods_menu_Copy_Supplier___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Copy_Inquire);
            // 
            // labelcmbSupplierId
            // 
            resources.ApplyResources(this.labelcmbSupplierId, "labelcmbSupplierId");
            this.labelcmbSupplierId.Name = "labelcmbSupplierId";
            // 
            // cmbSupplierId
            // 
            this.cmbSupplierId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.cmbSupplierId, "cmbSupplierId");
            this.cmbSupplierId.Name = "cmbSupplierId";
            this.cmbSupplierId.NamedProperties.Put("EnumerateMethod", "");
            this.cmbSupplierId.NamedProperties.Put("FieldFlags", "162");
            this.cmbSupplierId.NamedProperties.Put("Format", "9");
            this.cmbSupplierId.NamedProperties.Put("LovReference", "SUPPLIER_INFO_GENERAL");
            this.cmbSupplierId.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbSupplierId.NamedProperties.Put("SqlColumn", "SUPPLIER_ID");
            this.cmbSupplierId.NamedProperties.Put("ValidateMethod", "");
            this.cmbSupplierId.NamedProperties.Put("XDataLength", "20");
            this.cmbSupplierId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbSupplierId_WindowActions);
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
            this.dfsName.NamedProperties.Put("ParentName", "cmbSupplierId");
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
            this.dfsAssociationNo.NamedProperties.Put("ParentName", "cmbSupplierId");
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
            // labeldfsSuppliersOwnId
            // 
            resources.ApplyResources(this.labeldfsSuppliersOwnId, "labeldfsSuppliersOwnId");
            this.labeldfsSuppliersOwnId.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfsSuppliersOwnId, "Name0");
            this.labeldfsSuppliersOwnId.Name = "labeldfsSuppliersOwnId";
            // 
            // dfsSuppliersOwnId
            // 
            this.picTab.SetControlTabPages(this.dfsSuppliersOwnId, "Name0");
            resources.ApplyResources(this.dfsSuppliersOwnId, "dfsSuppliersOwnId");
            this.dfsSuppliersOwnId.Name = "dfsSuppliersOwnId";
            this.dfsSuppliersOwnId.NamedProperties.Put("EnumerateMethod", "");
            this.dfsSuppliersOwnId.NamedProperties.Put("FieldFlags", "294");
            this.dfsSuppliersOwnId.NamedProperties.Put("LovReference", "");
            this.dfsSuppliersOwnId.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsSuppliersOwnId.NamedProperties.Put("SqlColumn", "SUPPLIERS_OWN_ID");
            this.dfsSuppliersOwnId.NamedProperties.Put("ValidateMethod", "");
            // 
            // gbOur_ID_at_Supplier
            // 
            this.gbOur_ID_at_Supplier.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.gbOur_ID_at_Supplier, "Name0");
            resources.ApplyResources(this.gbOur_ID_at_Supplier, "gbOur_ID_at_Supplier");
            this.gbOur_ID_at_Supplier.Name = "gbOur_ID_at_Supplier";
            this.gbOur_ID_at_Supplier.TabStop = false;
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
            // labeldfsCountryDb
            // 
            resources.ApplyResources(this.labeldfsCountryDb, "labeldfsCountryDb");
            this.labeldfsCountryDb.Name = "labeldfsCountryDb";
            // 
            // dfsCountryDb
            // 
            resources.ApplyResources(this.dfsCountryDb, "dfsCountryDb");
            this.dfsCountryDb.Name = "dfsCountryDb";
            this.dfsCountryDb.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCountryDb.NamedProperties.Put("LovReference", "");
            this.dfsCountryDb.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsCountryDb.NamedProperties.Put("SqlColumn", "COUNTRY_DB");
            this.dfsCountryDb.NamedProperties.Put("ValidateMethod", "");
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
            // menuFrmMethods
            // 
            this.menuFrmMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem__Copy,
            this.menuItem__Chg_Supp_Category,
            this.tsMenuItemViewB2BUsers,
            this.tsMenuItemSeparator,
            this.tsMenuItemManageDataProcessingPurposes});
            this.menuFrmMethods.Name = "menuFrmMethods";
            resources.ApplyResources(this.menuFrmMethods, "menuFrmMethods");
            // 
            // menuItem__Copy
            // 
            this.menuItem__Copy.Command = this.menuFrmMethods_menu_Copy_Supplier___;
            this.menuItem__Copy.Name = "menuItem__Copy";
            resources.ApplyResources(this.menuItem__Copy, "menuItem__Copy");
            this.menuItem__Copy.Text = "&Copy Supplier...";
            // 
            // menuItem__Chg_Supp_Category
            // 
            this.menuItem__Chg_Supp_Category.Command = this.menuFrmMethods_menu_Chg_Supp_Category___;
            this.menuItem__Chg_Supp_Category.Name = "menuItem__Chg_Supp_Category";
            resources.ApplyResources(this.menuItem__Chg_Supp_Category, "menuItem__Chg_Supp_Category");
            this.menuItem__Chg_Supp_Category.Text = "C&hange Supplier Category...";
            // 
            // menuFrmMethods_menu_Chg_Supp_Category___
            // 
            resources.ApplyResources(this.menuFrmMethods_menu_Chg_Supp_Category___, "menuFrmMethods_menu_Chg_Supp_Category___");
            this.menuFrmMethods_menu_Chg_Supp_Category___.Name = "menuFrmMethods_menu_Chg_Supp_Category___";
            this.menuFrmMethods_menu_Chg_Supp_Category___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Chg_Supp_Category_Execute);
            this.menuFrmMethods_menu_Chg_Supp_Category___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Chg_Supp_Category_Inquire);
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
            // tsMenuItemSeparator
            // 
            this.tsMenuItemSeparator.Name = "tsMenuItemSeparator";
            resources.ApplyResources(this.tsMenuItemSeparator, "tsMenuItemSeparator");
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
            // picPicture
            // 
            this.picTab.SetControlTabPages(this.picPicture, "Name0");
            resources.ApplyResources(this.picPicture, "picPicture");
            this.picPicture.Name = "picPicture";
            this.picPicture.NamedProperties.Put("FieldFlags", "6");
            this.picPicture.NamedProperties.Put("SqlColumn", "PICTURE_ID");
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
            // labelcmbSupplierCategory
            // 
            resources.ApplyResources(this.labelcmbSupplierCategory, "labelcmbSupplierCategory");
            this.picTab.SetControlTabPages(this.labelcmbSupplierCategory, "Name0");
            this.labelcmbSupplierCategory.Name = "labelcmbSupplierCategory";
            // 
            // cmbSupplierCategory
            // 
            this.picTab.SetControlTabPages(this.cmbSupplierCategory, "Name0");
            resources.ApplyResources(this.cmbSupplierCategory, "cmbSupplierCategory");
            this.cmbSupplierCategory.Name = "cmbSupplierCategory";
            this.cmbSupplierCategory.NamedProperties.Put("EnumerateMethod", "SUPPLIER_INFO_CATEGORY_API.Enumerate");
            this.cmbSupplierCategory.NamedProperties.Put("FieldFlags", "291");
            this.cmbSupplierCategory.NamedProperties.Put("LovReference", "");
            this.cmbSupplierCategory.NamedProperties.Put("ParentName", "cmbSupplierId");
            this.cmbSupplierCategory.NamedProperties.Put("SqlColumn", "SUPPLIER_CATEGORY");
            // 
            // dfsSuppCategory
            // 
            resources.ApplyResources(this.dfsSuppCategory, "dfsSuppCategory");
            this.dfsSuppCategory.Name = "dfsSuppCategory";
            this.dfsSuppCategory.NamedProperties.Put("EnumerateMethod", "");
            this.dfsSuppCategory.NamedProperties.Put("LovReference", "");
            this.dfsSuppCategory.NamedProperties.Put("SqlColumn", "SUPPLIER_CATEGORY_DB");
            // 
            // cbB2bSupplier
            // 
            resources.ApplyResources(this.cbB2bSupplier, "cbB2bSupplier");
            this.picTab.SetControlTabPages(this.cbB2bSupplier, "Name0");
            this.cbB2bSupplier.Name = "cbB2bSupplier";
            this.cbB2bSupplier.NamedProperties.Put("EnumerateMethod", "");
            this.cbB2bSupplier.NamedProperties.Put("FieldFlags", "292");
            this.cbB2bSupplier.NamedProperties.Put("LovReference", "");
            this.cbB2bSupplier.NamedProperties.Put("LovTimeReference", "");
            this.cbB2bSupplier.NamedProperties.Put("SqlColumn", "B2B_SUPPLIER_DB");
            // 
            // tblOurId
            // 
            this.tblOurId.Controls.Add(this.tblOurId_colsCompany);
            this.tblOurId.Controls.Add(this.tblOurId_colsOurId);
            this.tblOurId.Controls.Add(this.tblOurId_colsSupplierId);
            this.picTab.SetControlTabPages(this.tblOurId, "Name0");
            resources.ApplyResources(this.tblOurId, "tblOurId");
            this.tblOurId.Name = "tblOurId";
            this.tblOurId.NamedProperties.Put("DefaultOrderBy", "");
            this.tblOurId.NamedProperties.Put("DefaultWhere", "");
            this.tblOurId.NamedProperties.Put("LogicalUnit", "SupplierInfoOurId");
            this.tblOurId.NamedProperties.Put("PackageName", "SUPPLIER_INFO_OUR_ID_API");
            this.tblOurId.NamedProperties.Put("ResizeableChildObject", "");
            this.tblOurId.NamedProperties.Put("ViewName", "SUPPLIER_INFO_OUR_ID_FIN_AUTH");
            this.tblOurId.NamedProperties.Put("Warnings", "FALSE");
            this.tblOurId.Controls.SetChildIndex(this.tblOurId_colsSupplierId, 0);
            this.tblOurId.Controls.SetChildIndex(this.tblOurId_colsOurId, 0);
            this.tblOurId.Controls.SetChildIndex(this.tblOurId_colsCompany, 0);
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
            this.tblOurId_colsCompany.Position = 3;
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
            this.tblOurId_colsOurId.Position = 4;
            resources.ApplyResources(this.tblOurId_colsOurId, "tblOurId_colsOurId");
            // 
            // tblOurId_colsSupplierId
            // 
            this.tblOurId_colsSupplierId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblOurId_colsSupplierId, "tblOurId_colsSupplierId");
            this.tblOurId_colsSupplierId.MaxLength = 20;
            this.tblOurId_colsSupplierId.Name = "tblOurId_colsSupplierId";
            this.tblOurId_colsSupplierId.NamedProperties.Put("EnumerateMethod", "");
            this.tblOurId_colsSupplierId.NamedProperties.Put("FieldFlags", "67");
            this.tblOurId_colsSupplierId.NamedProperties.Put("LovReference", "SUPPLIER_INFO");
            this.tblOurId_colsSupplierId.NamedProperties.Put("SqlColumn", "SUPPLIER_ID");
            this.tblOurId_colsSupplierId.Position = 5;
            // 
            // cbValidDataProcessingPurpose
            // 
            resources.ApplyResources(this.cbValidDataProcessingPurpose, "cbValidDataProcessingPurpose");
            this.picTab.SetControlTabPages(this.cbValidDataProcessingPurpose, "Name0");
            this.cbValidDataProcessingPurpose.Name = "cbValidDataProcessingPurpose";
            this.cbValidDataProcessingPurpose.NamedProperties.Put("FieldFlags", "288");
            this.cbValidDataProcessingPurpose.NamedProperties.Put("SqlColumn", "Personal_Data_Man_Util_API.Is_Valid_Consent_By_Keys(\'SUPPLIER\',SUPPLIER_ID, NULL," +
        " trunc(SYSDATE))");
            // 
            // frmSupplierInfo
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.cbValidDataProcessingPurpose);
            this.Controls.Add(this.tblOurId);
            this.Controls.Add(this.cbB2bSupplier);
            this.Controls.Add(this.dfsSuppCategory);
            this.Controls.Add(this.cmbSupplierCategory);
            this.Controls.Add(this.labelcmbSupplierCategory);
            this.Controls.Add(this.cbOneTimeDb);
            this.Controls.Add(this.gbLogo);
            this.Controls.Add(this.picPicture);
            this.Controls.Add(this.cmbPartyType);
            this.Controls.Add(this.cbDefaultDomain);
            this.Controls.Add(this.dfsCountryDb);
            this.Controls.Add(this.dfsParty);
            this.Controls.Add(this.dfsExist);
            this.Controls.Add(this.cmbIdentifierRefValidation);
            this.Controls.Add(this.dfsIdentifierReference);
            this.Controls.Add(this.dfsCorporateFormDesc);
            this.Controls.Add(this.dfsCorporateForm);
            this.Controls.Add(this.dfdCreationDate);
            this.Controls.Add(this.dfsSuppliersOwnId);
            this.Controls.Add(this.cmbCountry);
            this.Controls.Add(this.cmbDefaultLanguage);
            this.Controls.Add(this.dfsAssociationNo);
            this.Controls.Add(this.dfsName);
            this.Controls.Add(this.cmbSupplierId);
            this.Controls.Add(this.labeldfsCountryDb);
            this.Controls.Add(this.labelcmbIdentifierRefValidation);
            this.Controls.Add(this.labeldfsIdentifierReference);
            this.Controls.Add(this.labeldfsCorporateFormDesc);
            this.Controls.Add(this.labeldfsCorporateForm);
            this.Controls.Add(this.labeldfdCreationDate);
            this.Controls.Add(this.labeldfsSuppliersOwnId);
            this.Controls.Add(this.labelcmbCountry);
            this.Controls.Add(this.labelcmbDefaultLanguage);
            this.Controls.Add(this.labeldfsAssociationNo);
            this.Controls.Add(this.labeldfsName);
            this.Controls.Add(this.labelcmbSupplierId);
            this.Controls.Add(this.gbOur_ID_at_Supplier);
            this.Name = "frmSupplierInfo";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "SupplierInfoGeneral");
            this.NamedProperties.Put("PackageName", "SUPPLIER_INFO_GENERAL_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "4545");
            this.NamedProperties.Put("ViewName", "SUPPLIER_INFO_GENERAL");
            this.NamedProperties.Put("Warnings", "TRUE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.frmSupplierInfo_WindowActions);
            this.Controls.SetChildIndex(this.picTab, 0);
            this.Controls.SetChildIndex(this.gbOur_ID_at_Supplier, 0);
            this.Controls.SetChildIndex(this.labelcmbSupplierId, 0);
            this.Controls.SetChildIndex(this.labeldfsName, 0);
            this.Controls.SetChildIndex(this.labeldfsAssociationNo, 0);
            this.Controls.SetChildIndex(this.labelcmbDefaultLanguage, 0);
            this.Controls.SetChildIndex(this.labelcmbCountry, 0);
            this.Controls.SetChildIndex(this.labeldfsSuppliersOwnId, 0);
            this.Controls.SetChildIndex(this.labeldfdCreationDate, 0);
            this.Controls.SetChildIndex(this.labeldfsCorporateForm, 0);
            this.Controls.SetChildIndex(this.labeldfsCorporateFormDesc, 0);
            this.Controls.SetChildIndex(this.labeldfsIdentifierReference, 0);
            this.Controls.SetChildIndex(this.labelcmbIdentifierRefValidation, 0);
            this.Controls.SetChildIndex(this.labeldfsCountryDb, 0);
            this.Controls.SetChildIndex(this.cmbSupplierId, 0);
            this.Controls.SetChildIndex(this.dfsName, 0);
            this.Controls.SetChildIndex(this.dfsAssociationNo, 0);
            this.Controls.SetChildIndex(this.cmbDefaultLanguage, 0);
            this.Controls.SetChildIndex(this.cmbCountry, 0);
            this.Controls.SetChildIndex(this.dfsSuppliersOwnId, 0);
            this.Controls.SetChildIndex(this.dfdCreationDate, 0);
            this.Controls.SetChildIndex(this.dfsCorporateForm, 0);
            this.Controls.SetChildIndex(this.dfsCorporateFormDesc, 0);
            this.Controls.SetChildIndex(this.dfsIdentifierReference, 0);
            this.Controls.SetChildIndex(this.cmbIdentifierRefValidation, 0);
            this.Controls.SetChildIndex(this.dfsExist, 0);
            this.Controls.SetChildIndex(this.dfsParty, 0);
            this.Controls.SetChildIndex(this.dfsCountryDb, 0);
            this.Controls.SetChildIndex(this.cbDefaultDomain, 0);
            this.Controls.SetChildIndex(this.cmbPartyType, 0);
            this.Controls.SetChildIndex(this.picPicture, 0);
            this.Controls.SetChildIndex(this.gbLogo, 0);
            this.Controls.SetChildIndex(this.cbOneTimeDb, 0);
            this.Controls.SetChildIndex(this.labelcmbSupplierCategory, 0);
            this.Controls.SetChildIndex(this.cmbSupplierCategory, 0);
            this.Controls.SetChildIndex(this.dfsSuppCategory, 0);
            this.Controls.SetChildIndex(this.cbB2bSupplier, 0);
            this.Controls.SetChildIndex(this.tblOurId, 0);
            this.Controls.SetChildIndex(this.cbValidDataProcessingPurpose, 0);
            this.menuFrmMethods.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picPicture)).EndInit();
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

        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menu_Copy_Supplier___;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuFrmMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Copy;
        protected cPictureDataItem picPicture;
        protected SalGroupBox gbLogo;
        public cCheckBox cbOneTimeDb;
        public cChildTableOnTab tblOurId;
        protected cColumn tblOurId_colsCompany;
        protected cColumn tblOurId_colsOurId;
        protected cColumn tblOurId_colsSupplierId;
        protected cBackgroundText labelcmbSupplierCategory;
        protected cComboBox cmbSupplierCategory;
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menu_Chg_Supp_Category___;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Chg_Supp_Category;
        protected cDataField dfsSuppCategory;
        protected cCheckBox cbB2bSupplier;
        protected Fnd.Windows.Forms.FndToolStripMenuItem tsMenuItemViewB2BUsers;
        protected Fnd.Windows.Forms.FndCommand cmdViewB2BUsers;
        public cCheckBox cbValidDataProcessingPurpose;
        protected Fnd.Windows.Forms.FndCommand cmdManageDataProcessingPurposes;
        protected Fnd.Windows.Forms.FndToolStripSeparator tsMenuItemSeparator;
        protected Fnd.Windows.Forms.FndToolStripMenuItem tsMenuItemManageDataProcessingPurposes;
	}
}
