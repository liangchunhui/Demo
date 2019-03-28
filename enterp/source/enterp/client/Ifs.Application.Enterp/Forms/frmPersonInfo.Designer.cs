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
// 120921   MaRalk  PBR-225, Added column colsCustomerCategory to tblContactCustomer child table to represent the customer category.
// 130515   MaRalk  PBR-1602, Made name field link enabled and allow user to edit title, initials, first name, middle name and last name.
// 130522   MaRalk  PBR-1605, Added check boxes cbCustomerContactDb and cbBlockedForCrmObjectsDb.
// 131010   MaRalk  PBR-1751, Added columns colsRole, colsCustomerAddress, colsManager, colsDepartment, colsBlockedForCrmObjectsDb to 
// 131010           tblContactCustomer child table.
// 150512   SudJlk  ORA-288, Added checkboxes cbSupplierContactDb and cbBlockedForUseSuppDb, groupbox gbSuppContactIntegration.
// 150512           Re-designed the layout to have the customer contact data in gbCustContactIntegration and supplier contact data in gbSuppContactIntegration.
// 150610   SudJlk  ORA-690, Added columns colsSupplierAddress, colsRole and colsDepartment to tblContactSupplier.
// 150602   RoJalk  ORA-499, Changed the main WindowRegistration entry to the view SUPPLIER_INFO_GENERAL.
// 150619   RoJalk  ORA-802, Added the column colSupplierCategory. 
// 150629   SudJlk  ORA-752, Renamed group boxes.
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
    
    public partial class frmPersonInfo
    {
        
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        
        #region Window Controls
        protected cBackgroundText labelcmbPerson;
        public cDataField dfsName;
        protected cBackgroundText labeldfsTitle;
        public cDataField dfsTitle;
        protected cBackgroundText labeldfsUserId;
        public cDataField dfsUserId;
        protected cBackgroundText labelcmbDefaultLanguage;
        public cComboBoxOnTab cmbDefaultLanguage;
        protected cBackgroundText labelcmbCountry;
        public cComboBoxOnTab cmbCountry;
        protected cBackgroundText labeldfdCreationDate;
        public cDataFieldOnTab dfdCreationDate;
        // ! Bug 79336, End
        public cCheckBox cbProtected;
        // (+) DME-DMPR316, start
        // (+/-) DME-DMPR316, Issue ID: 154986, start
        public cCheckBox cbInactive;
        // (+/-) DME-DMPR316, Issue ID: 154986, end
        // (+) DME-DMPR316, end
        protected cBackgroundText labeltblContactCustomer;
        protected cBackgroundText labeltblContactSupplier;
        public cDataField dfsPartyType;
        public cCheckBox cbDefaultDomain;
        public cDataField dfsParty;
        public cPictureDataItem picPicture;
        #endregion
        
        #region Windows Form Designer generated code
        
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPersonInfo));
            this.labelcmbPerson = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsName = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsTitle = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsTitle = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsUserId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsUserId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelcmbDefaultLanguage = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.labelcmbCountry = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.labeldfdCreationDate = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cbProtected = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.cbInactive = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.labeltblContactCustomer = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.labeltblContactSupplier = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsPartyType = new Ifs.Fnd.ApplicationForms.cDataField();
            this.cbDefaultDomain = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.dfsParty = new Ifs.Fnd.ApplicationForms.cDataField();
            this.picPicture = new Ifs.Fnd.ApplicationForms.cPictureDataItem();
            this.dfsInitials = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsFirstName = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsMiddleName = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsLastName = new Ifs.Fnd.ApplicationForms.cDataField();
            this.gbCustContactIntegration = new Ifs.Fnd.ApplicationForms.cGroupBox();
            this.cbBlockedForUseDb = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.cbCustomerContactDb = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.labelName = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.commandEdit = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.cmbPerson = new Ifs.Fnd.ApplicationForms.cRecListDataField();
            this.cCommandButtonEdit = new Ifs.Fnd.ApplicationForms.cCommandButton();
            this.dfsAlternativeName = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelAlternativeName = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.gbSuppContactIntegration = new Ifs.Fnd.ApplicationForms.cGroupBox();
            this.cbSupplierContactDb = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.cbBlockedForUseSuppDb = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.commandViewUser = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.cmPersonInfo = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.tsMenuItemViewUser = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.tsMenuItemSeparator = new Ifs.Fnd.Windows.Forms.FndToolStripSeparator(this.components);
            this.tsMenuItemManageDataProcessingPurposes = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.cmdManageDataProcessingPurposes = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.dfsState = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelState = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cbValidDataProcessingPurpose = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.cmbDefaultLanguage = new Ifs.Application.Enterp.cComboBoxOnTab();
            this.cmbCountry = new Ifs.Application.Enterp.cComboBoxOnTab();
            this.dfdCreationDate = new Ifs.Application.Enterp.cDataFieldOnTab();
            this.tblContactSupplier = new Ifs.Application.Enterp.cChildTableOnTab();
            this.tblContactSupplier_colsSupplierId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblContactSupplier_colSupplierInfoName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblContactSupplier_colSupplierCategory = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblContactSupplier_colsSupplierAddress = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblContactSupplier_colsRole = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblContactSupplier_colsDepartment = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblContactCustomer = new Ifs.Application.Enterp.cChildTableOnTab();
            this.tblContactCustomer_colsCustomerId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblContactCustomer_colCustomerInfoName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblContactCustomer_colsCustomerCategory = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblContactCustomer_colsCustomerAddress = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblContactCustomer_colsRole = new Ifs.Fnd.ApplicationForms.cMultiSelectionColumn();
            this.tblContactCustomer_colsDepartment = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblContactCustomer_colsManager = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblContactCustomer_colsBlockedForCrmObjectsDb = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.picPicture)).BeginInit();
            this.gbCustContactIntegration.SuspendLayout();
            this.gbSuppContactIntegration.SuspendLayout();
            this.cmPersonInfo.SuspendLayout();
            this.tblContactSupplier.SuspendLayout();
            this.tblContactCustomer.SuspendLayout();
            this.SuspendLayout();
            // 
            // _cTabManager
            // 
            resources.ApplyResources(this._cTabManager, "_cTabManager");
            // 
            // picTab
            // 
            resources.ApplyResources(this.picTab, "picTab");
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.commandEdit);
            this.commandManager.Commands.Add(this.commandViewUser);
            this.commandManager.Commands.Add(this.cmdManageDataProcessingPurposes);
            this.commandManager.Components.Add(this.cCommandButtonEdit);
            this.commandManager.ContextMenus.Add(this.cmPersonInfo);
            // 
            // labelcmbPerson
            // 
            resources.ApplyResources(this.labelcmbPerson, "labelcmbPerson");
            this.labelcmbPerson.Name = "labelcmbPerson";
            // 
            // dfsName
            // 
            resources.ApplyResources(this.dfsName, "dfsName");
            this.dfsName.Name = "dfsName";
            this.dfsName.NamedProperties.Put("EnumerateMethod", "");
            this.dfsName.NamedProperties.Put("FieldFlags", "291");
            this.dfsName.NamedProperties.Put("LovReference", "");
            this.dfsName.NamedProperties.Put("ParentName", "cmbPerson");
            this.dfsName.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsName.NamedProperties.Put("SqlColumn", "NAME");
            this.dfsName.NamedProperties.Put("ValidateMethod", "");
            this.dfsName.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsName_WindowActions);
            // 
            // labeldfsTitle
            // 
            resources.ApplyResources(this.labeldfsTitle, "labeldfsTitle");
            this.labeldfsTitle.Name = "labeldfsTitle";
            // 
            // dfsTitle
            // 
            resources.ApplyResources(this.dfsTitle, "dfsTitle");
            this.dfsTitle.Name = "dfsTitle";
            this.dfsTitle.NamedProperties.Put("EnumerateMethod", "");
            this.dfsTitle.NamedProperties.Put("FieldFlags", "294");
            this.dfsTitle.NamedProperties.Put("LovReference", "");
            this.dfsTitle.NamedProperties.Put("SqlColumn", "TITLE");
            // 
            // labeldfsUserId
            // 
            resources.ApplyResources(this.labeldfsUserId, "labeldfsUserId");
            this.labeldfsUserId.Name = "labeldfsUserId";
            // 
            // dfsUserId
            // 
            this.dfsUserId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsUserId, "dfsUserId");
            this.dfsUserId.Name = "dfsUserId";
            this.dfsUserId.NamedProperties.Put("EnumerateMethod", "");
            this.dfsUserId.NamedProperties.Put("FieldFlags", "294");
            this.dfsUserId.NamedProperties.Put("LovReference", "PERSON_INFO_FREE_USER");
            this.dfsUserId.NamedProperties.Put("ParentName", "cmbPerson");
            this.dfsUserId.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsUserId.NamedProperties.Put("SqlColumn", "USER_ID");
            this.dfsUserId.NamedProperties.Put("ValidateMethod", "");
            // 
            // labelcmbDefaultLanguage
            // 
            resources.ApplyResources(this.labelcmbDefaultLanguage, "labelcmbDefaultLanguage");
            this.labelcmbDefaultLanguage.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labelcmbDefaultLanguage, "Name0");
            this.labelcmbDefaultLanguage.Name = "labelcmbDefaultLanguage";
            // 
            // labelcmbCountry
            // 
            resources.ApplyResources(this.labelcmbCountry, "labelcmbCountry");
            this.labelcmbCountry.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labelcmbCountry, "Name0");
            this.labelcmbCountry.Name = "labelcmbCountry";
            // 
            // labeldfdCreationDate
            // 
            resources.ApplyResources(this.labeldfdCreationDate, "labeldfdCreationDate");
            this.labeldfdCreationDate.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfdCreationDate, "Name0");
            this.labeldfdCreationDate.Name = "labeldfdCreationDate";
            // 
            // cbProtected
            // 
            resources.ApplyResources(this.cbProtected, "cbProtected");
            this.cbProtected.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.cbProtected, "Name0");
            this.cbProtected.Name = "cbProtected";
            this.cbProtected.NamedProperties.Put("DataType", "5");
            this.cbProtected.NamedProperties.Put("EnumerateMethod", "");
            this.cbProtected.NamedProperties.Put("FieldFlags", "295");
            this.cbProtected.NamedProperties.Put("LovReference", "");
            this.cbProtected.NamedProperties.Put("SqlColumn", "PROTECTED");
            this.cbProtected.NamedProperties.Put("ValidateMethod", "");
            this.cbProtected.NamedProperties.Put("XDataLength", "");
            this.cbProtected.UseVisualStyleBackColor = false;
            // 
            // cbInactive
            // 
            resources.ApplyResources(this.cbInactive, "cbInactive");
            this.cbInactive.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.cbInactive, "Name0");
            this.cbInactive.Name = "cbInactive";
            this.cbInactive.NamedProperties.Put("DataType", "5");
            this.cbInactive.NamedProperties.Put("EnumerateMethod", "");
            this.cbInactive.NamedProperties.Put("FieldFlags", "294");
            this.cbInactive.NamedProperties.Put("LovReference", "");
            this.cbInactive.NamedProperties.Put("ResizeableChildObject", "");
            this.cbInactive.NamedProperties.Put("SqlColumn", "INACTIVE");
            this.cbInactive.NamedProperties.Put("ValidateMethod", "");
            this.cbInactive.NamedProperties.Put("XDataLength", "20");
            this.cbInactive.UseVisualStyleBackColor = false;
            // 
            // labeltblContactCustomer
            // 
            resources.ApplyResources(this.labeltblContactCustomer, "labeltblContactCustomer");
            this.labeltblContactCustomer.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeltblContactCustomer, "Name0");
            this.labeltblContactCustomer.Name = "labeltblContactCustomer";
            // 
            // labeltblContactSupplier
            // 
            resources.ApplyResources(this.labeltblContactSupplier, "labeltblContactSupplier");
            this.labeltblContactSupplier.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeltblContactSupplier, "Name0");
            this.labeltblContactSupplier.Name = "labeltblContactSupplier";
            // 
            // dfsPartyType
            // 
            resources.ApplyResources(this.dfsPartyType, "dfsPartyType");
            this.dfsPartyType.Name = "dfsPartyType";
            this.dfsPartyType.NamedProperties.Put("EnumerateMethod", "");
            this.dfsPartyType.NamedProperties.Put("FieldFlags", "263");
            this.dfsPartyType.NamedProperties.Put("LovReference", "");
            this.dfsPartyType.NamedProperties.Put("SqlColumn", "PARTY_TYPE");
            this.dfsPartyType.NamedProperties.Put("ValidateMethod", "");
            // 
            // cbDefaultDomain
            // 
            resources.ApplyResources(this.cbDefaultDomain, "cbDefaultDomain");
            this.cbDefaultDomain.Name = "cbDefaultDomain";
            this.cbDefaultDomain.NamedProperties.Put("DataType", "5");
            this.cbDefaultDomain.NamedProperties.Put("EnumerateMethod", "");
            this.cbDefaultDomain.NamedProperties.Put("FieldFlags", "263");
            this.cbDefaultDomain.NamedProperties.Put("LovReference", "");
            this.cbDefaultDomain.NamedProperties.Put("SqlColumn", "DEFAULT_DOMAIN");
            this.cbDefaultDomain.NamedProperties.Put("ValidateMethod", "");
            this.cbDefaultDomain.NamedProperties.Put("XDataLength", "");
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
            // picPicture
            // 
            this.picTab.SetControlTabPages(this.picPicture, "Name0");
            resources.ApplyResources(this.picPicture, "picPicture");
            this.picPicture.Name = "picPicture";
            this.picPicture.NamedProperties.Put("EnumerateMethod", "");
            this.picPicture.NamedProperties.Put("FieldFlags", "262");
            this.picPicture.NamedProperties.Put("LovReference", "");
            this.picPicture.NamedProperties.Put("ResizeableChildObject", "");
            this.picPicture.NamedProperties.Put("SqlColumn", "PICTURE_ID");
            this.picPicture.NamedProperties.Put("ValidateMethod", "");
            this.picPicture.NamedProperties.Put("XDataLength", "");
            this.picPicture.TabStop = false;
            // 
            // dfsInitials
            // 
            resources.ApplyResources(this.dfsInitials, "dfsInitials");
            this.dfsInitials.Name = "dfsInitials";
            this.dfsInitials.NamedProperties.Put("EnumerateMethod", "");
            this.dfsInitials.NamedProperties.Put("FieldFlags", "294");
            this.dfsInitials.NamedProperties.Put("LovReference", "");
            this.dfsInitials.NamedProperties.Put("SqlColumn", "INITIALS");
            // 
            // dfsFirstName
            // 
            resources.ApplyResources(this.dfsFirstName, "dfsFirstName");
            this.dfsFirstName.Name = "dfsFirstName";
            this.dfsFirstName.NamedProperties.Put("EnumerateMethod", "");
            this.dfsFirstName.NamedProperties.Put("FieldFlags", "294");
            this.dfsFirstName.NamedProperties.Put("LovReference", "");
            this.dfsFirstName.NamedProperties.Put("SqlColumn", "FIRST_NAME");
            // 
            // dfsMiddleName
            // 
            resources.ApplyResources(this.dfsMiddleName, "dfsMiddleName");
            this.dfsMiddleName.Name = "dfsMiddleName";
            this.dfsMiddleName.NamedProperties.Put("EnumerateMethod", "");
            this.dfsMiddleName.NamedProperties.Put("FieldFlags", "294");
            this.dfsMiddleName.NamedProperties.Put("LovReference", "");
            this.dfsMiddleName.NamedProperties.Put("SqlColumn", "MIDDLE_NAME");
            // 
            // dfsLastName
            // 
            resources.ApplyResources(this.dfsLastName, "dfsLastName");
            this.dfsLastName.Name = "dfsLastName";
            this.dfsLastName.NamedProperties.Put("EnumerateMethod", "");
            this.dfsLastName.NamedProperties.Put("FieldFlags", "294");
            this.dfsLastName.NamedProperties.Put("LovReference", "");
            this.dfsLastName.NamedProperties.Put("SqlColumn", "LAST_NAME");
            // 
            // gbCustContactIntegration
            // 
            resources.ApplyResources(this.gbCustContactIntegration, "gbCustContactIntegration");
            this.gbCustContactIntegration.BackColor = System.Drawing.Color.Transparent;
            this.gbCustContactIntegration.Controls.Add(this.tblContactCustomer);
            this.gbCustContactIntegration.Controls.Add(this.cbBlockedForUseDb);
            this.gbCustContactIntegration.Controls.Add(this.cbCustomerContactDb);
            this.gbCustContactIntegration.Controls.Add(this.labeltblContactCustomer);
            this.picTab.SetControlTabPages(this.gbCustContactIntegration, "Name0");
            this.gbCustContactIntegration.Name = "gbCustContactIntegration";
            this.gbCustContactIntegration.TabStop = false;
            // 
            // cbBlockedForUseDb
            // 
            resources.ApplyResources(this.cbBlockedForUseDb, "cbBlockedForUseDb");
            this.cbBlockedForUseDb.Name = "cbBlockedForUseDb";
            this.cbBlockedForUseDb.NamedProperties.Put("EnumerateMethod", "");
            this.cbBlockedForUseDb.NamedProperties.Put("FieldFlags", "294");
            this.cbBlockedForUseDb.NamedProperties.Put("LovReference", "");
            this.cbBlockedForUseDb.NamedProperties.Put("SqlColumn", "BLOCKED_FOR_USE_DB");
            // 
            // cbCustomerContactDb
            // 
            resources.ApplyResources(this.cbCustomerContactDb, "cbCustomerContactDb");
            this.cbCustomerContactDb.Name = "cbCustomerContactDb";
            this.cbCustomerContactDb.NamedProperties.Put("EnumerateMethod", "");
            this.cbCustomerContactDb.NamedProperties.Put("FieldFlags", "294");
            this.cbCustomerContactDb.NamedProperties.Put("LovReference", "");
            this.cbCustomerContactDb.NamedProperties.Put("SqlColumn", "CUSTOMER_CONTACT_DB");
            this.cbCustomerContactDb.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbCustomerContactDb_WindowActions);
            // 
            // labelName
            // 
            resources.ApplyResources(this.labelName, "labelName");
            this.labelName.Name = "labelName";
            // 
            // commandEdit
            // 
            resources.ApplyResources(this.commandEdit, "commandEdit");
            this.commandEdit.Name = "commandEdit";
            this.commandEdit.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.commandEdit_Execute);
            // 
            // cmbPerson
            // 
            this.cmbPerson.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.cmbPerson, "cmbPerson");
            this.cmbPerson.Name = "cmbPerson";
            this.cmbPerson.NamedProperties.Put("EnumerateMethod", "");
            this.cmbPerson.NamedProperties.Put("FieldFlags", "162");
            this.cmbPerson.NamedProperties.Put("LovReference", "");
            this.cmbPerson.NamedProperties.Put("SqlColumn", "PERSON_ID");
            // 
            // cCommandButtonEdit
            // 
            this.cCommandButtonEdit.Command = this.commandEdit;
            resources.ApplyResources(this.cCommandButtonEdit, "cCommandButtonEdit");
            this.cCommandButtonEdit.Name = "cCommandButtonEdit";
            // 
            // dfsAlternativeName
            // 
            this.picTab.SetControlTabPages(this.dfsAlternativeName, "Name0");
            resources.ApplyResources(this.dfsAlternativeName, "dfsAlternativeName");
            this.dfsAlternativeName.Name = "dfsAlternativeName";
            this.dfsAlternativeName.NamedProperties.Put("EnumerateMethod", "");
            this.dfsAlternativeName.NamedProperties.Put("FieldFlags", "294");
            this.dfsAlternativeName.NamedProperties.Put("LovReference", "");
            this.dfsAlternativeName.NamedProperties.Put("SqlColumn", "ALTERNATIVE_NAME");
            // 
            // labelAlternativeName
            // 
            resources.ApplyResources(this.labelAlternativeName, "labelAlternativeName");
            this.picTab.SetControlTabPages(this.labelAlternativeName, "Name0");
            this.labelAlternativeName.Name = "labelAlternativeName";
            // 
            // gbSuppContactIntegration
            // 
            resources.ApplyResources(this.gbSuppContactIntegration, "gbSuppContactIntegration");
            this.gbSuppContactIntegration.BackColor = System.Drawing.Color.Transparent;
            this.gbSuppContactIntegration.Controls.Add(this.tblContactSupplier);
            this.gbSuppContactIntegration.Controls.Add(this.cbSupplierContactDb);
            this.gbSuppContactIntegration.Controls.Add(this.cbBlockedForUseSuppDb);
            this.gbSuppContactIntegration.Controls.Add(this.labeltblContactSupplier);
            this.picTab.SetControlTabPages(this.gbSuppContactIntegration, "Name0");
            this.gbSuppContactIntegration.Name = "gbSuppContactIntegration";
            this.gbSuppContactIntegration.TabStop = false;
            // 
            // cbSupplierContactDb
            // 
            resources.ApplyResources(this.cbSupplierContactDb, "cbSupplierContactDb");
            this.cbSupplierContactDb.Name = "cbSupplierContactDb";
            this.cbSupplierContactDb.NamedProperties.Put("EnumerateMethod", "");
            this.cbSupplierContactDb.NamedProperties.Put("FieldFlags", "292");
            this.cbSupplierContactDb.NamedProperties.Put("LovReference", "");
            this.cbSupplierContactDb.NamedProperties.Put("SqlColumn", "SUPPLIER_CONTACT_DB");
            this.cbSupplierContactDb.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbSupplierContactDb_WindowActions);
            // 
            // cbBlockedForUseSuppDb
            // 
            resources.ApplyResources(this.cbBlockedForUseSuppDb, "cbBlockedForUseSuppDb");
            this.cbBlockedForUseSuppDb.Name = "cbBlockedForUseSuppDb";
            this.cbBlockedForUseSuppDb.NamedProperties.Put("EnumerateMethod", "");
            this.cbBlockedForUseSuppDb.NamedProperties.Put("FieldFlags", "292");
            this.cbBlockedForUseSuppDb.NamedProperties.Put("LovReference", "");
            this.cbBlockedForUseSuppDb.NamedProperties.Put("SqlColumn", "BLOCKED_FOR_USE_SUPPLIER_DB");
            this.cbBlockedForUseSuppDb.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbBlockedForUseSuppDb_WindowActions);
            // 
            // commandViewUser
            // 
            resources.ApplyResources(this.commandViewUser, "commandViewUser");
            this.commandViewUser.Name = "commandViewUser";
            this.commandViewUser.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.commandViewUser_Execute);
            this.commandViewUser.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.commandViewUser_Inquire);
            // 
            // cmPersonInfo
            // 
            this.cmPersonInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMenuItemViewUser,
            this.tsMenuItemSeparator,
            this.tsMenuItemManageDataProcessingPurposes});
            this.cmPersonInfo.Name = "cmPersonInfo";
            resources.ApplyResources(this.cmPersonInfo, "cmPersonInfo");
            // 
            // tsMenuItemViewUser
            // 
            this.tsMenuItemViewUser.Command = this.commandViewUser;
            this.tsMenuItemViewUser.Name = "tsMenuItemViewUser";
            resources.ApplyResources(this.tsMenuItemViewUser, "tsMenuItemViewUser");
            this.tsMenuItemViewUser.Text = "View User";
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
            // dfsState
            // 
            resources.ApplyResources(this.dfsState, "dfsState");
            this.dfsState.Name = "dfsState";
            this.dfsState.NamedProperties.Put("EnumerateMethod", "");
            this.dfsState.NamedProperties.Put("FieldFlags", "288");
            this.dfsState.NamedProperties.Put("LovReference", "");
            this.dfsState.NamedProperties.Put("SqlColumn", "STATE");
            // 
            // labelState
            // 
            resources.ApplyResources(this.labelState, "labelState");
            this.labelState.Name = "labelState";
            // 
            // cbValidDataProcessingPurpose
            // 
            resources.ApplyResources(this.cbValidDataProcessingPurpose, "cbValidDataProcessingPurpose");
            this.cbValidDataProcessingPurpose.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.cbValidDataProcessingPurpose, "Name0");
            this.cbValidDataProcessingPurpose.Name = "cbValidDataProcessingPurpose";
            this.cbValidDataProcessingPurpose.NamedProperties.Put("FieldFlags", "288");
            this.cbValidDataProcessingPurpose.NamedProperties.Put("SqlColumn", "Personal_Data_Man_Util_API.Is_Valid_Consent_By_Keys(\'PERSON\',PERSON_ID, NULL, tru" +
        "nc(SYSDATE))");
            this.cbValidDataProcessingPurpose.UseVisualStyleBackColor = false;
            // 
            // cmbDefaultLanguage
            // 
            this.picTab.SetControlTabPages(this.cmbDefaultLanguage, "Name0");
            resources.ApplyResources(this.cmbDefaultLanguage, "cmbDefaultLanguage");
            this.cmbDefaultLanguage.Name = "cmbDefaultLanguage";
            this.cmbDefaultLanguage.NamedProperties.Put("EnumerateMethod", "ISO_LANGUAGE_API.Enumerate");
            this.cmbDefaultLanguage.NamedProperties.Put("FieldFlags", "294");
            this.cmbDefaultLanguage.NamedProperties.Put("LovReference", "");
            this.cmbDefaultLanguage.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbDefaultLanguage.NamedProperties.Put("SqlColumn", "DEFAULT_LANGUAGE");
            this.cmbDefaultLanguage.NamedProperties.Put("ValidateMethod", "");
            // 
            // cmbCountry
            // 
            this.picTab.SetControlTabPages(this.cmbCountry, "Name0");
            resources.ApplyResources(this.cmbCountry, "cmbCountry");
            this.cmbCountry.Name = "cmbCountry";
            this.cmbCountry.NamedProperties.Put("EnumerateMethod", "ISO_COUNTRY_API.Enumerate");
            this.cmbCountry.NamedProperties.Put("FieldFlags", "294");
            this.cmbCountry.NamedProperties.Put("LovReference", "");
            this.cmbCountry.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbCountry.NamedProperties.Put("SqlColumn", "COUNTRY");
            this.cmbCountry.NamedProperties.Put("ValidateMethod", "");
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
            // tblContactSupplier
            // 
            resources.ApplyResources(this.tblContactSupplier, "tblContactSupplier");
            this.tblContactSupplier.Controls.Add(this.tblContactSupplier_colsSupplierId);
            this.tblContactSupplier.Controls.Add(this.tblContactSupplier_colSupplierInfoName);
            this.tblContactSupplier.Controls.Add(this.tblContactSupplier_colSupplierCategory);
            this.tblContactSupplier.Controls.Add(this.tblContactSupplier_colsSupplierAddress);
            this.tblContactSupplier.Controls.Add(this.tblContactSupplier_colsRole);
            this.tblContactSupplier.Controls.Add(this.tblContactSupplier_colsDepartment);
            this.picTab.SetControlTabPages(this.tblContactSupplier, "Name0");
            this.tblContactSupplier.Name = "tblContactSupplier";
            this.tblContactSupplier.NamedProperties.Put("DefaultOrderBy", "");
            this.tblContactSupplier.NamedProperties.Put("DefaultWhere", "PERSON_ID = :i_hWndFrame.frmPersonInfo.cmbPerson.i_sMyValue");
            this.tblContactSupplier.NamedProperties.Put("LogicalUnit", "SupplierInfoContact");
            this.tblContactSupplier.NamedProperties.Put("PackageName", "SUPPLIER_INFO_CONTAT_API");
            this.tblContactSupplier.NamedProperties.Put("ResizeableChildObject", "LLLL");
            this.tblContactSupplier.NamedProperties.Put("SourceFlags", "448");
            this.tblContactSupplier.NamedProperties.Put("ViewName", "CONTACT_SUPPLIER");
            this.tblContactSupplier.NamedProperties.Put("Warnings", "FALSE");
            this.tblContactSupplier.Controls.SetChildIndex(this.tblContactSupplier_colsDepartment, 0);
            this.tblContactSupplier.Controls.SetChildIndex(this.tblContactSupplier_colsRole, 0);
            this.tblContactSupplier.Controls.SetChildIndex(this.tblContactSupplier_colsSupplierAddress, 0);
            this.tblContactSupplier.Controls.SetChildIndex(this.tblContactSupplier_colSupplierCategory, 0);
            this.tblContactSupplier.Controls.SetChildIndex(this.tblContactSupplier_colSupplierInfoName, 0);
            this.tblContactSupplier.Controls.SetChildIndex(this.tblContactSupplier_colsSupplierId, 0);
            // 
            // tblContactSupplier_colsSupplierId
            // 
            this.tblContactSupplier_colsSupplierId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblContactSupplier_colsSupplierId.MaxLength = 20;
            this.tblContactSupplier_colsSupplierId.Name = "tblContactSupplier_colsSupplierId";
            this.tblContactSupplier_colsSupplierId.NamedProperties.Put("EnumerateMethod", "");
            this.tblContactSupplier_colsSupplierId.NamedProperties.Put("FieldFlags", "67");
            this.tblContactSupplier_colsSupplierId.NamedProperties.Put("LovReference", "SUPPLIER_INFO_GENERAL");
            this.tblContactSupplier_colsSupplierId.NamedProperties.Put("SqlColumn", "SUPPLIER_ID");
            this.tblContactSupplier_colsSupplierId.Position = 3;
            resources.ApplyResources(this.tblContactSupplier_colsSupplierId, "tblContactSupplier_colsSupplierId");
            // 
            // tblContactSupplier_colSupplierInfoName
            // 
            this.tblContactSupplier_colSupplierInfoName.MaxLength = 2000;
            this.tblContactSupplier_colSupplierInfoName.Name = "tblContactSupplier_colSupplierInfoName";
            this.tblContactSupplier_colSupplierInfoName.NamedProperties.Put("EnumerateMethod", "");
            this.tblContactSupplier_colSupplierInfoName.NamedProperties.Put("FieldFlags", "288");
            this.tblContactSupplier_colSupplierInfoName.NamedProperties.Put("LovReference", "");
            this.tblContactSupplier_colSupplierInfoName.NamedProperties.Put("SqlColumn", "SUPPLIER_INFO_GENERAL_API.Get_Name(SUPPLIER_ID)");
            this.tblContactSupplier_colSupplierInfoName.Position = 4;
            resources.ApplyResources(this.tblContactSupplier_colSupplierInfoName, "tblContactSupplier_colSupplierInfoName");
            // 
            // tblContactSupplier_colSupplierCategory
            // 
            this.tblContactSupplier_colSupplierCategory.MaxLength = 2000;
            this.tblContactSupplier_colSupplierCategory.Name = "tblContactSupplier_colSupplierCategory";
            this.tblContactSupplier_colSupplierCategory.NamedProperties.Put("EnumerateMethod", "");
            this.tblContactSupplier_colSupplierCategory.NamedProperties.Put("FieldFlags", "288");
            this.tblContactSupplier_colSupplierCategory.NamedProperties.Put("LovReference", "");
            this.tblContactSupplier_colSupplierCategory.NamedProperties.Put("SqlColumn", "Supplier_Info_General_API.Get_Supplier_Category(SUPPLIER_ID)");
            this.tblContactSupplier_colSupplierCategory.Position = 5;
            resources.ApplyResources(this.tblContactSupplier_colSupplierCategory, "tblContactSupplier_colSupplierCategory");
            // 
            // tblContactSupplier_colsSupplierAddress
            // 
            this.tblContactSupplier_colsSupplierAddress.MaxLength = 50;
            this.tblContactSupplier_colsSupplierAddress.Name = "tblContactSupplier_colsSupplierAddress";
            this.tblContactSupplier_colsSupplierAddress.NamedProperties.Put("EnumerateMethod", "");
            this.tblContactSupplier_colsSupplierAddress.NamedProperties.Put("FieldFlags", "288");
            this.tblContactSupplier_colsSupplierAddress.NamedProperties.Put("LovReference", "");
            this.tblContactSupplier_colsSupplierAddress.NamedProperties.Put("SqlColumn", "SUPPLIER_ADDRESS");
            this.tblContactSupplier_colsSupplierAddress.Position = 6;
            resources.ApplyResources(this.tblContactSupplier_colsSupplierAddress, "tblContactSupplier_colsSupplierAddress");
            // 
            // tblContactSupplier_colsRole
            // 
            this.tblContactSupplier_colsRole.MaxLength = 4000;
            this.tblContactSupplier_colsRole.Name = "tblContactSupplier_colsRole";
            this.tblContactSupplier_colsRole.NamedProperties.Put("EnumerateMethod", "CONTACT_ROLE_API.Enumerate");
            this.tblContactSupplier_colsRole.NamedProperties.Put("FieldFlags", "288");
            this.tblContactSupplier_colsRole.NamedProperties.Put("LovReference", "");
            this.tblContactSupplier_colsRole.NamedProperties.Put("SqlColumn", "ROLE");
            this.tblContactSupplier_colsRole.Position = 7;
            resources.ApplyResources(this.tblContactSupplier_colsRole, "tblContactSupplier_colsRole");
            // 
            // tblContactSupplier_colsDepartment
            // 
            this.tblContactSupplier_colsDepartment.IsLookup = true;
            this.tblContactSupplier_colsDepartment.Name = "tblContactSupplier_colsDepartment";
            this.tblContactSupplier_colsDepartment.NamedProperties.Put("EnumerateMethod", "CONTACT_DEPARTMENT_API.Enumerate");
            this.tblContactSupplier_colsDepartment.NamedProperties.Put("FieldFlags", "288");
            this.tblContactSupplier_colsDepartment.NamedProperties.Put("LovReference", "");
            this.tblContactSupplier_colsDepartment.NamedProperties.Put("SqlColumn", "DEPARTMENT");
            this.tblContactSupplier_colsDepartment.Position = 8;
            resources.ApplyResources(this.tblContactSupplier_colsDepartment, "tblContactSupplier_colsDepartment");
            // 
            // tblContactCustomer
            // 
            resources.ApplyResources(this.tblContactCustomer, "tblContactCustomer");
            this.tblContactCustomer.Controls.Add(this.tblContactCustomer_colsCustomerId);
            this.tblContactCustomer.Controls.Add(this.tblContactCustomer_colCustomerInfoName);
            this.tblContactCustomer.Controls.Add(this.tblContactCustomer_colsCustomerCategory);
            this.tblContactCustomer.Controls.Add(this.tblContactCustomer_colsCustomerAddress);
            this.tblContactCustomer.Controls.Add(this.tblContactCustomer_colsRole);
            this.tblContactCustomer.Controls.Add(this.tblContactCustomer_colsDepartment);
            this.tblContactCustomer.Controls.Add(this.tblContactCustomer_colsManager);
            this.tblContactCustomer.Controls.Add(this.tblContactCustomer_colsBlockedForCrmObjectsDb);
            this.picTab.SetControlTabPages(this.tblContactCustomer, "Name0");
            this.tblContactCustomer.Name = "tblContactCustomer";
            this.tblContactCustomer.NamedProperties.Put("DefaultOrderBy", "");
            this.tblContactCustomer.NamedProperties.Put("DefaultWhere", "PERSON_ID = :i_hWndFrame.frmPersonInfo.cmbPerson.i_sMyValue");
            this.tblContactCustomer.NamedProperties.Put("LogicalUnit", "CustomerInfoContact");
            this.tblContactCustomer.NamedProperties.Put("PackageName", "CUSTOMER_INFO_CONTACT_API");
            this.tblContactCustomer.NamedProperties.Put("ResizeableChildObject", "LLLL");
            this.tblContactCustomer.NamedProperties.Put("SourceFlags", "448");
            this.tblContactCustomer.NamedProperties.Put("ViewName", "CONTACT_CUSTOMER");
            this.tblContactCustomer.NamedProperties.Put("Warnings", "FALSE");
            this.tblContactCustomer.Controls.SetChildIndex(this.tblContactCustomer_colsBlockedForCrmObjectsDb, 0);
            this.tblContactCustomer.Controls.SetChildIndex(this.tblContactCustomer_colsManager, 0);
            this.tblContactCustomer.Controls.SetChildIndex(this.tblContactCustomer_colsDepartment, 0);
            this.tblContactCustomer.Controls.SetChildIndex(this.tblContactCustomer_colsRole, 0);
            this.tblContactCustomer.Controls.SetChildIndex(this.tblContactCustomer_colsCustomerAddress, 0);
            this.tblContactCustomer.Controls.SetChildIndex(this.tblContactCustomer_colsCustomerCategory, 0);
            this.tblContactCustomer.Controls.SetChildIndex(this.tblContactCustomer_colCustomerInfoName, 0);
            this.tblContactCustomer.Controls.SetChildIndex(this.tblContactCustomer_colsCustomerId, 0);
            // 
            // tblContactCustomer_colsCustomerId
            // 
            this.tblContactCustomer_colsCustomerId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblContactCustomer_colsCustomerId.MaxLength = 20;
            this.tblContactCustomer_colsCustomerId.Name = "tblContactCustomer_colsCustomerId";
            this.tblContactCustomer_colsCustomerId.NamedProperties.Put("EnumerateMethod", "");
            this.tblContactCustomer_colsCustomerId.NamedProperties.Put("FieldFlags", "67");
            this.tblContactCustomer_colsCustomerId.NamedProperties.Put("LovReference", "CUSTOMER_INFO");
            this.tblContactCustomer_colsCustomerId.NamedProperties.Put("SqlColumn", "CUSTOMER_ID");
            this.tblContactCustomer_colsCustomerId.Position = 3;
            resources.ApplyResources(this.tblContactCustomer_colsCustomerId, "tblContactCustomer_colsCustomerId");
            // 
            // tblContactCustomer_colCustomerInfoName
            // 
            this.tblContactCustomer_colCustomerInfoName.MaxLength = 2000;
            this.tblContactCustomer_colCustomerInfoName.Name = "tblContactCustomer_colCustomerInfoName";
            this.tblContactCustomer_colCustomerInfoName.NamedProperties.Put("EnumerateMethod", "");
            this.tblContactCustomer_colCustomerInfoName.NamedProperties.Put("FieldFlags", "304");
            this.tblContactCustomer_colCustomerInfoName.NamedProperties.Put("LovReference", "");
            this.tblContactCustomer_colCustomerInfoName.NamedProperties.Put("SqlColumn", "CUSTOMER_INFO_API.Get_Name(CUSTOMER_ID)");
            this.tblContactCustomer_colCustomerInfoName.Position = 4;
            resources.ApplyResources(this.tblContactCustomer_colCustomerInfoName, "tblContactCustomer_colCustomerInfoName");
            // 
            // tblContactCustomer_colsCustomerCategory
            // 
            this.tblContactCustomer_colsCustomerCategory.MaxLength = 2000;
            this.tblContactCustomer_colsCustomerCategory.Name = "tblContactCustomer_colsCustomerCategory";
            this.tblContactCustomer_colsCustomerCategory.NamedProperties.Put("EnumerateMethod", "");
            this.tblContactCustomer_colsCustomerCategory.NamedProperties.Put("FieldFlags", "288");
            this.tblContactCustomer_colsCustomerCategory.NamedProperties.Put("LovReference", "");
            this.tblContactCustomer_colsCustomerCategory.NamedProperties.Put("SqlColumn", "CUSTOMER_INFO_API.Get_Customer_Category(CUSTOMER_ID)");
            this.tblContactCustomer_colsCustomerCategory.Position = 5;
            resources.ApplyResources(this.tblContactCustomer_colsCustomerCategory, "tblContactCustomer_colsCustomerCategory");
            // 
            // tblContactCustomer_colsCustomerAddress
            // 
            this.tblContactCustomer_colsCustomerAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblContactCustomer_colsCustomerAddress.MaxLength = 50;
            this.tblContactCustomer_colsCustomerAddress.Name = "tblContactCustomer_colsCustomerAddress";
            this.tblContactCustomer_colsCustomerAddress.NamedProperties.Put("EnumerateMethod", "");
            this.tblContactCustomer_colsCustomerAddress.NamedProperties.Put("FieldFlags", "288");
            this.tblContactCustomer_colsCustomerAddress.NamedProperties.Put("LovReference", "CUSTOMER_INFO_ADDRESS(CUSTOMER_ID)");
            this.tblContactCustomer_colsCustomerAddress.NamedProperties.Put("SqlColumn", "CUSTOMER_ADDRESS");
            this.tblContactCustomer_colsCustomerAddress.Position = 6;
            resources.ApplyResources(this.tblContactCustomer_colsCustomerAddress, "tblContactCustomer_colsCustomerAddress");
            // 
            // tblContactCustomer_colsRole
            // 
            this.tblContactCustomer_colsRole.MaxLength = 4000;
            this.tblContactCustomer_colsRole.Name = "tblContactCustomer_colsRole";
            this.tblContactCustomer_colsRole.NamedProperties.Put("EnumerateMethod", "CONTACT_ROLE_API.Enumerate");
            this.tblContactCustomer_colsRole.NamedProperties.Put("FieldFlags", "288");
            this.tblContactCustomer_colsRole.NamedProperties.Put("LovReference", "");
            this.tblContactCustomer_colsRole.NamedProperties.Put("SqlColumn", "ROLE");
            this.tblContactCustomer_colsRole.Position = 7;
            resources.ApplyResources(this.tblContactCustomer_colsRole, "tblContactCustomer_colsRole");
            // 
            // tblContactCustomer_colsDepartment
            // 
            this.tblContactCustomer_colsDepartment.IsLookup = true;
            this.tblContactCustomer_colsDepartment.Name = "tblContactCustomer_colsDepartment";
            this.tblContactCustomer_colsDepartment.NamedProperties.Put("EnumerateMethod", "");
            this.tblContactCustomer_colsDepartment.NamedProperties.Put("FieldFlags", "288");
            this.tblContactCustomer_colsDepartment.NamedProperties.Put("LovReference", "");
            this.tblContactCustomer_colsDepartment.NamedProperties.Put("SqlColumn", "DEPARTMENT");
            this.tblContactCustomer_colsDepartment.Position = 8;
            resources.ApplyResources(this.tblContactCustomer_colsDepartment, "tblContactCustomer_colsDepartment");
            // 
            // tblContactCustomer_colsManager
            // 
            this.tblContactCustomer_colsManager.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblContactCustomer_colsManager.MaxLength = 20;
            this.tblContactCustomer_colsManager.Name = "tblContactCustomer_colsManager";
            this.tblContactCustomer_colsManager.NamedProperties.Put("EnumerateMethod", "");
            this.tblContactCustomer_colsManager.NamedProperties.Put("FieldFlags", "288");
            this.tblContactCustomer_colsManager.NamedProperties.Put("LovReference", "");
            this.tblContactCustomer_colsManager.NamedProperties.Put("SqlColumn", "MANAGER");
            this.tblContactCustomer_colsManager.Position = 9;
            resources.ApplyResources(this.tblContactCustomer_colsManager, "tblContactCustomer_colsManager");
            // 
            // tblContactCustomer_colsBlockedForCrmObjectsDb
            // 
            this.tblContactCustomer_colsBlockedForCrmObjectsDb.MaxLength = 20;
            this.tblContactCustomer_colsBlockedForCrmObjectsDb.Name = "tblContactCustomer_colsBlockedForCrmObjectsDb";
            this.tblContactCustomer_colsBlockedForCrmObjectsDb.NamedProperties.Put("EnumerateMethod", "");
            this.tblContactCustomer_colsBlockedForCrmObjectsDb.NamedProperties.Put("FieldFlags", "288");
            this.tblContactCustomer_colsBlockedForCrmObjectsDb.NamedProperties.Put("LovReference", "");
            this.tblContactCustomer_colsBlockedForCrmObjectsDb.NamedProperties.Put("SqlColumn", "BLOCKED_FOR_CRM_OBJECTS_DB");
            this.tblContactCustomer_colsBlockedForCrmObjectsDb.Position = 10;
            resources.ApplyResources(this.tblContactCustomer_colsBlockedForCrmObjectsDb, "tblContactCustomer_colsBlockedForCrmObjectsDb");
            // 
            // frmPersonInfo
            // 
            resources.ApplyResources(this, "$this");
            this.ContextMenuStrip = this.cmPersonInfo;
            this.Controls.Add(this.cmbDefaultLanguage);
            this.Controls.Add(this.cmbCountry);
            this.Controls.Add(this.dfdCreationDate);
            this.Controls.Add(this.cbValidDataProcessingPurpose);
            this.Controls.Add(this.dfsState);
            this.Controls.Add(this.labelState);
            this.Controls.Add(this.gbSuppContactIntegration);
            this.Controls.Add(this.dfsAlternativeName);
            this.Controls.Add(this.labelAlternativeName);
            this.Controls.Add(this.cCommandButtonEdit);
            this.Controls.Add(this.cmbPerson);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.gbCustContactIntegration);
            this.Controls.Add(this.dfsLastName);
            this.Controls.Add(this.dfsMiddleName);
            this.Controls.Add(this.dfsFirstName);
            this.Controls.Add(this.dfsInitials);
            this.Controls.Add(this.dfsParty);
            this.Controls.Add(this.cbDefaultDomain);
            this.Controls.Add(this.dfsPartyType);
            this.Controls.Add(this.cbInactive);
            this.Controls.Add(this.cbProtected);
            this.Controls.Add(this.dfsUserId);
            this.Controls.Add(this.dfsTitle);
            this.Controls.Add(this.dfsName);
            this.Controls.Add(this.labeldfdCreationDate);
            this.Controls.Add(this.labelcmbCountry);
            this.Controls.Add(this.labelcmbDefaultLanguage);
            this.Controls.Add(this.labeldfsUserId);
            this.Controls.Add(this.labeldfsTitle);
            this.Controls.Add(this.labelcmbPerson);
            this.Controls.Add(this.picPicture);
            this.Name = "frmPersonInfo";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "PersonInfo");
            this.NamedProperties.Put("PackageName", "PERSON_INFO_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "12737");
            this.NamedProperties.Put("ViewName", "PERSON_INFO_ALL");
            this.NamedProperties.Put("Warnings", "TRUE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.frmPersonInfo_WindowActions);
            this.Controls.SetChildIndex(this.picTab, 0);
            this.Controls.SetChildIndex(this.picPicture, 0);
            this.Controls.SetChildIndex(this.labelcmbPerson, 0);
            this.Controls.SetChildIndex(this.labeldfsTitle, 0);
            this.Controls.SetChildIndex(this.labeldfsUserId, 0);
            this.Controls.SetChildIndex(this.labelcmbDefaultLanguage, 0);
            this.Controls.SetChildIndex(this.labelcmbCountry, 0);
            this.Controls.SetChildIndex(this.labeldfdCreationDate, 0);
            this.Controls.SetChildIndex(this.dfsName, 0);
            this.Controls.SetChildIndex(this.dfsTitle, 0);
            this.Controls.SetChildIndex(this.dfsUserId, 0);
            this.Controls.SetChildIndex(this.cbProtected, 0);
            this.Controls.SetChildIndex(this.cbInactive, 0);
            this.Controls.SetChildIndex(this.dfsPartyType, 0);
            this.Controls.SetChildIndex(this.cbDefaultDomain, 0);
            this.Controls.SetChildIndex(this.dfsParty, 0);
            this.Controls.SetChildIndex(this.dfsInitials, 0);
            this.Controls.SetChildIndex(this.dfsFirstName, 0);
            this.Controls.SetChildIndex(this.dfsMiddleName, 0);
            this.Controls.SetChildIndex(this.dfsLastName, 0);
            this.Controls.SetChildIndex(this.gbCustContactIntegration, 0);
            this.Controls.SetChildIndex(this.labelName, 0);
            this.Controls.SetChildIndex(this.cmbPerson, 0);
            this.Controls.SetChildIndex(this.cCommandButtonEdit, 0);
            this.Controls.SetChildIndex(this.labelAlternativeName, 0);
            this.Controls.SetChildIndex(this.dfsAlternativeName, 0);
            this.Controls.SetChildIndex(this.gbSuppContactIntegration, 0);
            this.Controls.SetChildIndex(this.labelState, 0);
            this.Controls.SetChildIndex(this.dfsState, 0);
            this.Controls.SetChildIndex(this.cbValidDataProcessingPurpose, 0);
            this.Controls.SetChildIndex(this.dfdCreationDate, 0);
            this.Controls.SetChildIndex(this.cmbCountry, 0);
            this.Controls.SetChildIndex(this.cmbDefaultLanguage, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picPicture)).EndInit();
            this.gbCustContactIntegration.ResumeLayout(false);
            this.gbCustContactIntegration.PerformLayout();
            this.gbSuppContactIntegration.ResumeLayout(false);
            this.gbSuppContactIntegration.PerformLayout();
            this.cmPersonInfo.ResumeLayout(false);
            this.tblContactSupplier.ResumeLayout(false);
            this.tblContactCustomer.ResumeLayout(false);
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

        protected cDataField dfsInitials;
        protected cDataField dfsFirstName;
        protected cDataField dfsMiddleName;
        protected cDataField dfsLastName;
        protected cGroupBox gbCustContactIntegration;
        protected cCheckBox cbBlockedForUseDb;
        protected cCheckBox cbCustomerContactDb;
        public cChildTableOnTab tblContactCustomer;
        protected cColumn tblContactCustomer_colsCustomerId;
        protected cColumn tblContactCustomer_colCustomerInfoName;
        protected cColumn tblContactCustomer_colsCustomerCategory;
        public cChildTableOnTab tblContactSupplier;
        protected cColumn tblContactSupplier_colsSupplierId;
        protected cColumn tblContactSupplier_colSupplierInfoName;
		protected cMultiSelectionColumn tblContactCustomer_colsRole;
        protected cCheckBoxColumn tblContactCustomer_colsBlockedForCrmObjectsDb;
        protected cColumn tblContactCustomer_colsCustomerAddress;
        protected cColumn tblContactCustomer_colsManager;
        protected cColumn tblContactCustomer_colsDepartment;
        protected cBackgroundText labelName;
        protected Fnd.Windows.Forms.FndCommand commandEdit;
        protected cRecListDataField cmbPerson;
        protected cCommandButton cCommandButtonEdit;
        protected cDataField dfsAlternativeName;
        protected cBackgroundText labelAlternativeName;
        protected cGroupBox gbSuppContactIntegration;
        protected cCheckBox cbSupplierContactDb;
        protected cCheckBox cbBlockedForUseSuppDb;
        protected cColumn tblContactSupplier_colsSupplierAddress;
        protected cColumn tblContactSupplier_colsRole;
        protected cColumn tblContactSupplier_colsDepartment;
        protected cColumn tblContactSupplier_colSupplierCategory;
        protected Fnd.Windows.Forms.FndCommand commandViewUser;
        protected Fnd.Windows.Forms.FndContextMenuStrip cmPersonInfo;
        protected Fnd.Windows.Forms.FndToolStripMenuItem tsMenuItemViewUser;
        protected cDataField dfsState;
        protected cBackgroundText labelState;
        protected cCheckBox cbValidDataProcessingPurpose;
        protected Fnd.Windows.Forms.FndCommand cmdManageDataProcessingPurposes;
        protected Fnd.Windows.Forms.FndToolStripSeparator tsMenuItemSeparator;
        protected Fnd.Windows.Forms.FndToolStripMenuItem tsMenuItemManageDataProcessingPurposes;
    }
}
