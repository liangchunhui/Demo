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
// Date      By      Notes
// ------    -----   ---------------------------------------------------
// 121221    Nirplk  Merged Bug 106346.
// 140703    MaRalk  PRSC-1619, Modified tblSupplierInfoContact_colsRole column as a multi selection column.
// 150602    RoJalk  ORA-499, Changed the main WindowRegistration entry to the view SUPPLIER_INFO_GENERAL.
// 150902    SudJlk  AFT-3038, Added new columns to show department, main representative and main representative name for supplier contacts.

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
	
	public partial class frmSupplierInfoAddress
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cDataField dfsSupplierId;
		protected cBackgroundText labelcmbAddressId;
		public cRecSelExtComboBox cmbAddressId;
		protected cBackgroundText labeldfsEanLocation;
		public cDataField dfsEanLocation;
		protected cBackgroundText labelcmbCountry;
		public cComboBox cmbCountry;
		protected cBackgroundText labelamlAddress;
		public cAddressMultilineField amlAddress;
		protected cBackgroundText labeldfdValidFrom;
		public cDataField dfdValidFrom;
		protected cBackgroundText labeldfdValidTo;
        public cDataField dfdValidTo;
		protected cBackgroundText labeltblCommMethod;
        protected cBackgroundText labeltblSupplierInfoContact;
		public cComboBox cmbPartyType;
		public cDataField dfsParty;
		public cCheckBox cbDefaultDomain;
		protected cBackgroundText labeldfsAddress1;
		public cDataField dfsAddress1;
		protected cBackgroundText labeldfsAddress2;
		public cDataField dfsAddress2;
		protected cBackgroundText labeldfsZipCode;
		public cDataField dfsZipCode;
		protected cBackgroundText labeldfsCity;
		public cDataField dfsCity;
		protected cBackgroundText labeldfsCounty;
		public cDataField dfsCounty;
		protected cBackgroundText labeldfsState;
		public cDataField dfsState;
		protected cBackgroundText labeldfsCountryCode;
		public cDataField dfsCountryCode;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSupplierInfoAddress));
            this.menuFrmMethods_menu_Tax_Code_Info___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.dfsSupplierId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelcmbAddressId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbAddressId = new Ifs.Fnd.ApplicationForms.cRecSelExtComboBox();
            this.labeldfsEanLocation = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsEanLocation = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelcmbCountry = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbCountry = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.labelamlAddress = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.amlAddress = new Ifs.Fnd.ApplicationForms.cAddressMultilineField();
            this.labeldfdValidFrom = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfdValidFrom = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfdValidTo = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfdValidTo = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeltblCommMethod = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.labeltblSupplierInfoContact = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbPartyType = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.dfsParty = new Ifs.Fnd.ApplicationForms.cDataField();
            this.cbDefaultDomain = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.labeldfsAddress1 = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsAddress1 = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsAddress2 = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsAddress2 = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsZipCode = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsZipCode = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsCity = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsCity = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsCounty = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsCounty = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsState = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsState = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsCountryCode = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsCountryCode = new Ifs.Fnd.ApplicationForms.cDataField();
            this.menuFrmMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem__Tax = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.dfsName = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelName = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsAddress3 = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsAddress4 = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsAddress5 = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsAddress6 = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsAddress3 = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.labeldfsAddress4 = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.labeldfsAddress5 = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.labeldfsAddress6 = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsSupplierBranch = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelSupplierBranch = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.tblAddressType = new Ifs.Application.Enterp.cChildTableOnTab();
            this.tblAddressType_colsSupplierId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblAddressType_colsAddressId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblAddressType_colsAddressTypeCode = new Ifs.Application.Enterp.cLookupColumnTypeCode();
            this.tblAddressType_colsAddressTypeCodeDb = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblAddressType_colDefAddress = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.tblAddressType_colsParty = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblAddressType_colDefaultDomain = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.tblCommMethod = new Ifs.Application.Enterp.cChildTableCommMethod();
            this.tblCommMethod_coldValidFromOld = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblCommMethod_coldValidToOld = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblSupplierInfoContact = new Ifs.Application.Enterp.cChildTableOnTab();
            this.tblSupplierInfoContact_colsSupplierId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblSupplierInfoContact_colsSupplierAddress = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblSupplierInfoContact_colsPersonId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblSupplierInfoContact_colPersonInfoName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblSupplierInfoContact_colPersonInfoTitle = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblSupplierInfoContact_colsRole = new Ifs.Fnd.ApplicationForms.cMultiSelectionColumn();
            this.tblSupplierInfoContact_colsContactAddress = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblSupplierInfoContact_colsMainRepresentativeId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblSupplierInfoContact_colsMainRepresentativeName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblSupplierInfoContact_colsDepartment = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.tblSupplierInfoContact_colsConnectAllSuppAddrDb = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.tblSupplierInfoContact_colAddressPrimary = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.tblSupplierInfoContact_colAddressSecondary = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.tblSupplierInfoContact_colSupplierPrimary = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.tblSupplierInfoContact_colSupplierSecondary = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.tblSupplierInfoContact_colPersonInfoAddressPhone = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblSupplierInfoContact_colPersonInfoAddressMobile = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblSupplierInfoContact_colPersonInfoAddressE_Mail = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblSupplierInfoContact_colPersonInfoAddressFax = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblSupplierInfoContact_colPersonInfoAddressPager = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblSupplierInfoContact_colPersonInfoAddressIntercom = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblSupplierInfoContact_colPersonInfoAddressWww = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblSupplierInfoContact_colNoteText = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuFrmMethods.SuspendLayout();
            this.tblAddressType.SuspendLayout();
            this.tblCommMethod.SuspendLayout();
            this.tblSupplierInfoContact.SuspendLayout();
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
            this.commandManager.Commands.Add(this.menuFrmMethods_menu_Tax_Code_Info___);
            this.commandManager.ContextMenus.Add(this.menuFrmMethods);
            // 
            // menuFrmMethods_menu_Tax_Code_Info___
            // 
            resources.ApplyResources(this.menuFrmMethods_menu_Tax_Code_Info___, "menuFrmMethods_menu_Tax_Code_Info___");
            this.menuFrmMethods_menu_Tax_Code_Info___.Name = "menuFrmMethods_menu_Tax_Code_Info___";
            this.menuFrmMethods_menu_Tax_Code_Info___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Tax_Execute);
            this.menuFrmMethods_menu_Tax_Code_Info___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Tax_Inquire);
            // 
            // dfsSupplierId
            // 
            this.dfsSupplierId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsSupplierId, "dfsSupplierId");
            this.dfsSupplierId.Name = "dfsSupplierId";
            this.dfsSupplierId.NamedProperties.Put("EnumerateMethod", "");
            this.dfsSupplierId.NamedProperties.Put("FieldFlags", "67");
            this.dfsSupplierId.NamedProperties.Put("LovReference", "SUPPLIER_INFO_GENERAL");
            this.dfsSupplierId.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsSupplierId.NamedProperties.Put("SqlColumn", "SUPPLIER_ID");
            this.dfsSupplierId.NamedProperties.Put("ValidateMethod", "");
            // 
            // labelcmbAddressId
            // 
            resources.ApplyResources(this.labelcmbAddressId, "labelcmbAddressId");
            this.labelcmbAddressId.Name = "labelcmbAddressId";
            // 
            // cmbAddressId
            // 
            resources.ApplyResources(this.cmbAddressId, "cmbAddressId");
            this.cmbAddressId.Name = "cmbAddressId";
            this.cmbAddressId.NamedProperties.Put("EnumerateMethod", "");
            this.cmbAddressId.NamedProperties.Put("FieldFlags", "163");
            this.cmbAddressId.NamedProperties.Put("Format", "9");
            this.cmbAddressId.NamedProperties.Put("LovReference", "");
            this.cmbAddressId.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbAddressId.NamedProperties.Put("SqlColumn", "ADDRESS_ID");
            this.cmbAddressId.NamedProperties.Put("ValidateMethod", "");
            this.cmbAddressId.NamedProperties.Put("XDataLength", "50");
            // 
            // labeldfsEanLocation
            // 
            resources.ApplyResources(this.labeldfsEanLocation, "labeldfsEanLocation");
            this.labeldfsEanLocation.Name = "labeldfsEanLocation";
            // 
            // dfsEanLocation
            // 
            resources.ApplyResources(this.dfsEanLocation, "dfsEanLocation");
            this.dfsEanLocation.Name = "dfsEanLocation";
            this.dfsEanLocation.NamedProperties.Put("EnumerateMethod", "");
            this.dfsEanLocation.NamedProperties.Put("FieldFlags", "294");
            this.dfsEanLocation.NamedProperties.Put("LovReference", "");
            this.dfsEanLocation.NamedProperties.Put("SqlColumn", "EAN_LOCATION");
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
            this.cmbCountry.NamedProperties.Put("Format", "9");
            this.cmbCountry.NamedProperties.Put("LovReference", "");
            this.cmbCountry.NamedProperties.Put("ParentName", "cmbAddressId");
            this.cmbCountry.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbCountry.NamedProperties.Put("SqlColumn", "COUNTRY");
            this.cmbCountry.NamedProperties.Put("ValidateMethod", "");
            this.cmbCountry.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbCountry_WindowActions);
            // 
            // labelamlAddress
            // 
            resources.ApplyResources(this.labelamlAddress, "labelamlAddress");
            this.labelamlAddress.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labelamlAddress, "Name0");
            this.labelamlAddress.Name = "labelamlAddress";
            // 
            // amlAddress
            // 
            this.amlAddress.BackColor = System.Drawing.SystemColors.ControlLight;
            this.picTab.SetControlTabPages(this.amlAddress, "Name0");
            resources.ApplyResources(this.amlAddress, "amlAddress");
            this.amlAddress.Name = "amlAddress";
            this.amlAddress.NamedProperties.Put("ButtonPos", "R");
            this.amlAddress.NamedProperties.Put("objAddress1", "dfsAddress1");
            this.amlAddress.NamedProperties.Put("objAddress2", "dfsAddress2");
            this.amlAddress.NamedProperties.Put("objAddress3", "dfsAddress3");
            this.amlAddress.NamedProperties.Put("objAddress4", "dfsAddress4");
            this.amlAddress.NamedProperties.Put("objAddress5", "dfsAddress5");
            this.amlAddress.NamedProperties.Put("objAddress6", "dfsAddress6");
            this.amlAddress.NamedProperties.Put("objCity", "dfsCity");
            this.amlAddress.NamedProperties.Put("objCountry", "cmbCountry");
            this.amlAddress.NamedProperties.Put("objCountryCode", "dfsCountryCode");
            this.amlAddress.NamedProperties.Put("objCounty", "dfsCounty");
            this.amlAddress.NamedProperties.Put("objState", "dfsState");
            this.amlAddress.NamedProperties.Put("objZipCode", "dfsZipCode");
            this.amlAddress.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // labeldfdValidFrom
            // 
            resources.ApplyResources(this.labeldfdValidFrom, "labeldfdValidFrom");
            this.labeldfdValidFrom.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfdValidFrom, "Name0");
            this.labeldfdValidFrom.Name = "labeldfdValidFrom";
            // 
            // dfdValidFrom
            // 
            this.picTab.SetControlTabPages(this.dfdValidFrom, "Name0");
            this.dfdValidFrom.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            resources.ApplyResources(this.dfdValidFrom, "dfdValidFrom");
            this.dfdValidFrom.Format = "d";
            this.dfdValidFrom.Name = "dfdValidFrom";
            this.dfdValidFrom.NamedProperties.Put("EnumerateMethod", "");
            this.dfdValidFrom.NamedProperties.Put("FieldFlags", "294");
            this.dfdValidFrom.NamedProperties.Put("LovReference", "");
            this.dfdValidFrom.NamedProperties.Put("ResizeableChildObject", "");
            this.dfdValidFrom.NamedProperties.Put("SqlColumn", "VALID_FROM");
            this.dfdValidFrom.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfdValidTo
            // 
            resources.ApplyResources(this.labeldfdValidTo, "labeldfdValidTo");
            this.labeldfdValidTo.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfdValidTo, "Name0");
            this.labeldfdValidTo.Name = "labeldfdValidTo";
            // 
            // dfdValidTo
            // 
            this.picTab.SetControlTabPages(this.dfdValidTo, "Name0");
            this.dfdValidTo.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            resources.ApplyResources(this.dfdValidTo, "dfdValidTo");
            this.dfdValidTo.Format = "d";
            this.dfdValidTo.Name = "dfdValidTo";
            this.dfdValidTo.NamedProperties.Put("EnumerateMethod", "");
            this.dfdValidTo.NamedProperties.Put("FieldFlags", "294");
            this.dfdValidTo.NamedProperties.Put("LovReference", "");
            this.dfdValidTo.NamedProperties.Put("SqlColumn", "VALID_TO");
            // 
            // labeltblCommMethod
            // 
            resources.ApplyResources(this.labeltblCommMethod, "labeltblCommMethod");
            this.labeltblCommMethod.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeltblCommMethod, "Name0");
            this.labeltblCommMethod.Name = "labeltblCommMethod";
            // 
            // labeltblSupplierInfoContact
            // 
            resources.ApplyResources(this.labeltblSupplierInfoContact, "labeltblSupplierInfoContact");
            this.labeltblSupplierInfoContact.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeltblSupplierInfoContact, "Name0");
            this.labeltblSupplierInfoContact.Name = "labeltblSupplierInfoContact";
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
            // labeldfsAddress1
            // 
            resources.ApplyResources(this.labeldfsAddress1, "labeldfsAddress1");
            this.labeldfsAddress1.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfsAddress1, "Name0");
            this.labeldfsAddress1.Name = "labeldfsAddress1";
            // 
            // dfsAddress1
            // 
            resources.ApplyResources(this.dfsAddress1, "dfsAddress1");
            this.dfsAddress1.Name = "dfsAddress1";
            this.dfsAddress1.NamedProperties.Put("EnumerateMethod", "");
            this.dfsAddress1.NamedProperties.Put("FieldFlags", "294");
            this.dfsAddress1.NamedProperties.Put("LovReference", "");
            this.dfsAddress1.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsAddress1.NamedProperties.Put("SqlColumn", "ADDRESS1");
            this.dfsAddress1.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsAddress2
            // 
            resources.ApplyResources(this.labeldfsAddress2, "labeldfsAddress2");
            this.labeldfsAddress2.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfsAddress2, "Name0");
            this.labeldfsAddress2.Name = "labeldfsAddress2";
            // 
            // dfsAddress2
            // 
            resources.ApplyResources(this.dfsAddress2, "dfsAddress2");
            this.dfsAddress2.Name = "dfsAddress2";
            this.dfsAddress2.NamedProperties.Put("EnumerateMethod", "");
            this.dfsAddress2.NamedProperties.Put("FieldFlags", "294");
            this.dfsAddress2.NamedProperties.Put("LovReference", "");
            this.dfsAddress2.NamedProperties.Put("SqlColumn", "ADDRESS2");
            // 
            // labeldfsZipCode
            // 
            resources.ApplyResources(this.labeldfsZipCode, "labeldfsZipCode");
            this.labeldfsZipCode.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfsZipCode, "Name0");
            this.labeldfsZipCode.Name = "labeldfsZipCode";
            // 
            // dfsZipCode
            // 
            this.dfsZipCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsZipCode, "dfsZipCode");
            this.dfsZipCode.Name = "dfsZipCode";
            this.dfsZipCode.NamedProperties.Put("EnumerateMethod", "");
            this.dfsZipCode.NamedProperties.Put("FieldFlags", "294");
            this.dfsZipCode.NamedProperties.Put("LovReference", "ZIP_CODE1_LOV(COUNTRY, STATE, COUNTY,CITY)");
            this.dfsZipCode.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsZipCode.NamedProperties.Put("SqlColumn", "ZIP_CODE");
            this.dfsZipCode.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsCity
            // 
            resources.ApplyResources(this.labeldfsCity, "labeldfsCity");
            this.labeldfsCity.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfsCity, "Name0");
            this.labeldfsCity.Name = "labeldfsCity";
            // 
            // dfsCity
            // 
            resources.ApplyResources(this.dfsCity, "dfsCity");
            this.dfsCity.Name = "dfsCity";
            this.dfsCity.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCity.NamedProperties.Put("FieldFlags", "294");
            this.dfsCity.NamedProperties.Put("LovReference", "CITY_CODE1_LOV(COUNTRY, STATE, COUNTY)");
            this.dfsCity.NamedProperties.Put("ParentName", "cmbAddressId");
            this.dfsCity.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsCity.NamedProperties.Put("SqlColumn", "CITY");
            this.dfsCity.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsCounty
            // 
            resources.ApplyResources(this.labeldfsCounty, "labeldfsCounty");
            this.labeldfsCounty.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfsCounty, "Name0");
            this.labeldfsCounty.Name = "labeldfsCounty";
            // 
            // dfsCounty
            // 
            resources.ApplyResources(this.dfsCounty, "dfsCounty");
            this.dfsCounty.Name = "dfsCounty";
            this.dfsCounty.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCounty.NamedProperties.Put("FieldFlags", "294");
            this.dfsCounty.NamedProperties.Put("LovReference", "COUNTY_CODE1_LOV(COUNTRY, STATE)");
            this.dfsCounty.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsCounty.NamedProperties.Put("SqlColumn", "COUNTY");
            this.dfsCounty.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsState
            // 
            resources.ApplyResources(this.labeldfsState, "labeldfsState");
            this.labeldfsState.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfsState, "Name0");
            this.labeldfsState.Name = "labeldfsState";
            // 
            // dfsState
            // 
            resources.ApplyResources(this.dfsState, "dfsState");
            this.dfsState.Name = "dfsState";
            this.dfsState.NamedProperties.Put("EnumerateMethod", "");
            this.dfsState.NamedProperties.Put("FieldFlags", "294");
            this.dfsState.NamedProperties.Put("LovReference", "STATE_CODE_LOV(COUNTRY)");
            this.dfsState.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsState.NamedProperties.Put("SqlColumn", "STATE");
            this.dfsState.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsCountryCode
            // 
            resources.ApplyResources(this.labeldfsCountryCode, "labeldfsCountryCode");
            this.labeldfsCountryCode.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfsCountryCode, "Name0");
            this.labeldfsCountryCode.Name = "labeldfsCountryCode";
            // 
            // dfsCountryCode
            // 
            resources.ApplyResources(this.dfsCountryCode, "dfsCountryCode");
            this.dfsCountryCode.Name = "dfsCountryCode";
            this.dfsCountryCode.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCountryCode.NamedProperties.Put("FieldFlags", "288");
            this.dfsCountryCode.NamedProperties.Put("LovReference", "ISO_COUNTRY");
            this.dfsCountryCode.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsCountryCode.NamedProperties.Put("SqlColumn", "COUNTRY_DB");
            this.dfsCountryCode.NamedProperties.Put("ValidateMethod", "");
            // 
            // menuFrmMethods
            // 
            this.menuFrmMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem__Tax});
            this.menuFrmMethods.Name = "menuFrmMethods";
            resources.ApplyResources(this.menuFrmMethods, "menuFrmMethods");
            // 
            // menuItem__Tax
            // 
            this.menuItem__Tax.Command = this.menuFrmMethods_menu_Tax_Code_Info___;
            this.menuItem__Tax.Name = "menuItem__Tax";
            resources.ApplyResources(this.menuItem__Tax, "menuItem__Tax");
            this.menuItem__Tax.Text = "&Tax Code Info...";
            // 
            // dfsName
            // 
            resources.ApplyResources(this.dfsName, "dfsName");
            this.dfsName.Name = "dfsName";
            this.dfsName.NamedProperties.Put("EnumerateMethod", "");
            this.dfsName.NamedProperties.Put("FieldFlags", "294");
            this.dfsName.NamedProperties.Put("LovReference", "");
            this.dfsName.NamedProperties.Put("ParentName", "cmbAddressId");
            this.dfsName.NamedProperties.Put("SqlColumn", "NAME");
            // 
            // labelName
            // 
            resources.ApplyResources(this.labelName, "labelName");
            this.labelName.Name = "labelName";
            // 
            // dfsAddress3
            // 
            resources.ApplyResources(this.dfsAddress3, "dfsAddress3");
            this.dfsAddress3.Name = "dfsAddress3";
            this.dfsAddress3.NamedProperties.Put("EnumerateMethod", "");
            this.dfsAddress3.NamedProperties.Put("FieldFlags", "294");
            this.dfsAddress3.NamedProperties.Put("LovReference", "");
            this.dfsAddress3.NamedProperties.Put("LovTimeReference", "");
            this.dfsAddress3.NamedProperties.Put("SqlColumn", "ADDRESS3");
            // 
            // dfsAddress4
            // 
            resources.ApplyResources(this.dfsAddress4, "dfsAddress4");
            this.dfsAddress4.Name = "dfsAddress4";
            this.dfsAddress4.NamedProperties.Put("EnumerateMethod", "");
            this.dfsAddress4.NamedProperties.Put("FieldFlags", "294");
            this.dfsAddress4.NamedProperties.Put("LovReference", "");
            this.dfsAddress4.NamedProperties.Put("LovTimeReference", "");
            this.dfsAddress4.NamedProperties.Put("SqlColumn", "ADDRESS4");
            // 
            // dfsAddress5
            // 
            resources.ApplyResources(this.dfsAddress5, "dfsAddress5");
            this.dfsAddress5.Name = "dfsAddress5";
            this.dfsAddress5.NamedProperties.Put("EnumerateMethod", "");
            this.dfsAddress5.NamedProperties.Put("FieldFlags", "294");
            this.dfsAddress5.NamedProperties.Put("LovReference", "");
            this.dfsAddress5.NamedProperties.Put("LovTimeReference", "");
            this.dfsAddress5.NamedProperties.Put("SqlColumn", "ADDRESS5");
            // 
            // dfsAddress6
            // 
            resources.ApplyResources(this.dfsAddress6, "dfsAddress6");
            this.dfsAddress6.Name = "dfsAddress6";
            this.dfsAddress6.NamedProperties.Put("EnumerateMethod", "");
            this.dfsAddress6.NamedProperties.Put("FieldFlags", "294");
            this.dfsAddress6.NamedProperties.Put("LovReference", "");
            this.dfsAddress6.NamedProperties.Put("LovTimeReference", "");
            this.dfsAddress6.NamedProperties.Put("SqlColumn", "ADDRESS6");
            // 
            // labeldfsAddress3
            // 
            resources.ApplyResources(this.labeldfsAddress3, "labeldfsAddress3");
            this.labeldfsAddress3.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfsAddress3, "Name0");
            this.labeldfsAddress3.Name = "labeldfsAddress3";
            // 
            // labeldfsAddress4
            // 
            resources.ApplyResources(this.labeldfsAddress4, "labeldfsAddress4");
            this.labeldfsAddress4.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfsAddress4, "Name0");
            this.labeldfsAddress4.Name = "labeldfsAddress4";
            // 
            // labeldfsAddress5
            // 
            resources.ApplyResources(this.labeldfsAddress5, "labeldfsAddress5");
            this.labeldfsAddress5.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfsAddress5, "Name0");
            this.labeldfsAddress5.Name = "labeldfsAddress5";
            // 
            // labeldfsAddress6
            // 
            resources.ApplyResources(this.labeldfsAddress6, "labeldfsAddress6");
            this.labeldfsAddress6.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfsAddress6, "Name0");
            this.labeldfsAddress6.Name = "labeldfsAddress6";
            // 
            // dfsSupplierBranch
            // 
            this.dfsSupplierBranch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.picTab.SetControlTabPages(this.dfsSupplierBranch, "Name0");
            resources.ApplyResources(this.dfsSupplierBranch, "dfsSupplierBranch");
            this.dfsSupplierBranch.Name = "dfsSupplierBranch";
            this.dfsSupplierBranch.NamedProperties.Put("EnumerateMethod", "");
            this.dfsSupplierBranch.NamedProperties.Put("FieldFlags", "294");
            this.dfsSupplierBranch.NamedProperties.Put("LovReference", "");
            this.dfsSupplierBranch.NamedProperties.Put("SqlColumn", "SUPPLIER_BRANCH");
            // 
            // labelSupplierBranch
            // 
            resources.ApplyResources(this.labelSupplierBranch, "labelSupplierBranch");
            this.picTab.SetControlTabPages(this.labelSupplierBranch, "Name0");
            this.labelSupplierBranch.Name = "labelSupplierBranch";
            // 
            // tblAddressType
            // 
            this.tblAddressType.Controls.Add(this.tblAddressType_colsSupplierId);
            this.tblAddressType.Controls.Add(this.tblAddressType_colsAddressId);
            this.tblAddressType.Controls.Add(this.tblAddressType_colsAddressTypeCode);
            this.tblAddressType.Controls.Add(this.tblAddressType_colsAddressTypeCodeDb);
            this.tblAddressType.Controls.Add(this.tblAddressType_colDefAddress);
            this.tblAddressType.Controls.Add(this.tblAddressType_colsParty);
            this.tblAddressType.Controls.Add(this.tblAddressType_colDefaultDomain);
            this.picTab.SetControlTabPages(this.tblAddressType, "Name0");
            resources.ApplyResources(this.tblAddressType, "tblAddressType");
            this.tblAddressType.Name = "tblAddressType";
            this.tblAddressType.NamedProperties.Put("DefaultOrderBy", "");
            this.tblAddressType.NamedProperties.Put("DefaultWhere", "");
            this.tblAddressType.NamedProperties.Put("LogicalUnit", "SupplierInfoAddressType");
            this.tblAddressType.NamedProperties.Put("PackageName", "SUPPLIER_INFO_ADDRESS_TYPE_API");
            this.tblAddressType.NamedProperties.Put("ResizeableChildObject", "LLLL");
            this.tblAddressType.NamedProperties.Put("ViewName", "SUPPLIER_INFO_ADDRESS_TYPE");
            this.tblAddressType.NamedProperties.Put("Warnings", "FALSE");
            this.tblAddressType.DataRecordExecuteNewEvent += new Ifs.Fnd.ApplicationForms.cDataSource.DataRecordExecuteNewEventHandler(this.tblAddressType_DataRecordExecuteNewEvent);
            this.tblAddressType.DataSourcePrepareKeyTransferEvent += new Ifs.Fnd.ApplicationForms.cDataSource.DataSourcePrepareKeyTransferEventHandler(this.tblAddressType_DataSourcePrepareKeyTransferEvent);
            this.tblAddressType.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblAddressType_WindowActions);
            this.tblAddressType.Controls.SetChildIndex(this.tblAddressType_colDefaultDomain, 0);
            this.tblAddressType.Controls.SetChildIndex(this.tblAddressType_colsParty, 0);
            this.tblAddressType.Controls.SetChildIndex(this.tblAddressType_colDefAddress, 0);
            this.tblAddressType.Controls.SetChildIndex(this.tblAddressType_colsAddressTypeCodeDb, 0);
            this.tblAddressType.Controls.SetChildIndex(this.tblAddressType_colsAddressTypeCode, 0);
            this.tblAddressType.Controls.SetChildIndex(this.tblAddressType_colsAddressId, 0);
            this.tblAddressType.Controls.SetChildIndex(this.tblAddressType_colsSupplierId, 0);
            // 
            // tblAddressType_colsSupplierId
            // 
            this.tblAddressType_colsSupplierId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblAddressType_colsSupplierId, "tblAddressType_colsSupplierId");
            this.tblAddressType_colsSupplierId.MaxLength = 20;
            this.tblAddressType_colsSupplierId.Name = "tblAddressType_colsSupplierId";
            this.tblAddressType_colsSupplierId.NamedProperties.Put("EnumerateMethod", "");
            this.tblAddressType_colsSupplierId.NamedProperties.Put("FieldFlags", "67");
            this.tblAddressType_colsSupplierId.NamedProperties.Put("LovReference", "");
            this.tblAddressType_colsSupplierId.NamedProperties.Put("ResizeableChildObject", "");
            this.tblAddressType_colsSupplierId.NamedProperties.Put("SqlColumn", "SUPPLIER_ID");
            this.tblAddressType_colsSupplierId.NamedProperties.Put("ValidateMethod", "");
            this.tblAddressType_colsSupplierId.Position = 3;
            // 
            // tblAddressType_colsAddressId
            // 
            this.tblAddressType_colsAddressId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblAddressType_colsAddressId, "tblAddressType_colsAddressId");
            this.tblAddressType_colsAddressId.MaxLength = 50;
            this.tblAddressType_colsAddressId.Name = "tblAddressType_colsAddressId";
            this.tblAddressType_colsAddressId.NamedProperties.Put("EnumerateMethod", "");
            this.tblAddressType_colsAddressId.NamedProperties.Put("FieldFlags", "66");
            this.tblAddressType_colsAddressId.NamedProperties.Put("LovReference", "SUPPLIER_INFO_ADDRESS(SUPPLIER_ID)");
            this.tblAddressType_colsAddressId.NamedProperties.Put("ResizeableChildObject", "");
            this.tblAddressType_colsAddressId.NamedProperties.Put("SqlColumn", "ADDRESS_ID");
            this.tblAddressType_colsAddressId.NamedProperties.Put("ValidateMethod", "");
            this.tblAddressType_colsAddressId.Position = 4;
            // 
            // tblAddressType_colsAddressTypeCode
            // 
            this.tblAddressType_colsAddressTypeCode.MaxLength = 20;
            this.tblAddressType_colsAddressTypeCode.Name = "tblAddressType_colsAddressTypeCode";
            this.tblAddressType_colsAddressTypeCode.NamedProperties.Put("EnumerateMethod", "ADDRESS_TYPE_CODE_API.Enumerate");
            this.tblAddressType_colsAddressTypeCode.NamedProperties.Put("FieldFlags", "167");
            this.tblAddressType_colsAddressTypeCode.NamedProperties.Put("LovReference", "");
            this.tblAddressType_colsAddressTypeCode.NamedProperties.Put("ResizeableChildObject", "");
            this.tblAddressType_colsAddressTypeCode.NamedProperties.Put("SqlColumn", "ADDRESS_TYPE_CODE");
            this.tblAddressType_colsAddressTypeCode.NamedProperties.Put("ValidateMethod", "");
            this.tblAddressType_colsAddressTypeCode.Position = 5;
            resources.ApplyResources(this.tblAddressType_colsAddressTypeCode, "tblAddressType_colsAddressTypeCode");
            this.tblAddressType_colsAddressTypeCode.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsAddressTypeCode_WindowActions);
            // 
            // tblAddressType_colsAddressTypeCodeDb
            // 
            this.tblAddressType_colsAddressTypeCodeDb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblAddressType_colsAddressTypeCodeDb, "tblAddressType_colsAddressTypeCodeDb");
            this.tblAddressType_colsAddressTypeCodeDb.MaxLength = 20;
            this.tblAddressType_colsAddressTypeCodeDb.Name = "tblAddressType_colsAddressTypeCodeDb";
            this.tblAddressType_colsAddressTypeCodeDb.NamedProperties.Put("EnumerateMethod", "");
            this.tblAddressType_colsAddressTypeCodeDb.NamedProperties.Put("FieldFlags", "258");
            this.tblAddressType_colsAddressTypeCodeDb.NamedProperties.Put("LovReference", "");
            this.tblAddressType_colsAddressTypeCodeDb.NamedProperties.Put("ResizeableChildObject", "");
            this.tblAddressType_colsAddressTypeCodeDb.NamedProperties.Put("SqlColumn", "ADDRESS_TYPE_CODE_DB");
            this.tblAddressType_colsAddressTypeCodeDb.NamedProperties.Put("ValidateMethod", "");
            this.tblAddressType_colsAddressTypeCodeDb.Position = 6;
            // 
            // tblAddressType_colDefAddress
            // 
            this.tblAddressType_colDefAddress.Name = "tblAddressType_colDefAddress";
            this.tblAddressType_colDefAddress.NamedProperties.Put("EnumerateMethod", "");
            this.tblAddressType_colDefAddress.NamedProperties.Put("FieldFlags", "294");
            this.tblAddressType_colDefAddress.NamedProperties.Put("LovReference", "");
            this.tblAddressType_colDefAddress.NamedProperties.Put("ResizeableChildObject", "");
            this.tblAddressType_colDefAddress.NamedProperties.Put("SqlColumn", "DEF_ADDRESS");
            this.tblAddressType_colDefAddress.NamedProperties.Put("ValidateMethod", "");
            this.tblAddressType_colDefAddress.Position = 7;
            resources.ApplyResources(this.tblAddressType_colDefAddress, "tblAddressType_colDefAddress");
            // 
            // tblAddressType_colsParty
            // 
            resources.ApplyResources(this.tblAddressType_colsParty, "tblAddressType_colsParty");
            this.tblAddressType_colsParty.MaxLength = 20;
            this.tblAddressType_colsParty.Name = "tblAddressType_colsParty";
            this.tblAddressType_colsParty.NamedProperties.Put("EnumerateMethod", "");
            this.tblAddressType_colsParty.NamedProperties.Put("FieldFlags", "262");
            this.tblAddressType_colsParty.NamedProperties.Put("LovReference", "");
            this.tblAddressType_colsParty.NamedProperties.Put("ResizeableChildObject", "");
            this.tblAddressType_colsParty.NamedProperties.Put("SqlColumn", "PARTY");
            this.tblAddressType_colsParty.NamedProperties.Put("ValidateMethod", "");
            this.tblAddressType_colsParty.Position = 8;
            // 
            // tblAddressType_colDefaultDomain
            // 
            resources.ApplyResources(this.tblAddressType_colDefaultDomain, "tblAddressType_colDefaultDomain");
            this.tblAddressType_colDefaultDomain.Name = "tblAddressType_colDefaultDomain";
            this.tblAddressType_colDefaultDomain.NamedProperties.Put("EnumerateMethod", "");
            this.tblAddressType_colDefaultDomain.NamedProperties.Put("FieldFlags", "262");
            this.tblAddressType_colDefaultDomain.NamedProperties.Put("LovReference", "");
            this.tblAddressType_colDefaultDomain.NamedProperties.Put("ResizeableChildObject", "");
            this.tblAddressType_colDefaultDomain.NamedProperties.Put("SqlColumn", "DEFAULT_DOMAIN");
            this.tblAddressType_colDefaultDomain.NamedProperties.Put("ValidateMethod", "");
            this.tblAddressType_colDefaultDomain.Position = 9;
            // 
            // tblCommMethod
            // 
            // 
            // tblCommMethod.colAddressDefault
            // 
            resources.ApplyResources(this.tblCommMethod.colAddressDefault, "tblCommMethod.colAddressDefault");
            // 
            // tblCommMethod.coldValidFrom
            // 
            resources.ApplyResources(this.tblCommMethod.coldValidFrom, "tblCommMethod.coldValidFrom");
            this.tblCommMethod.coldValidFrom.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblCommMethod_coldValidFrom_WindowActions);
            // 
            // tblCommMethod.coldValidTo
            // 
            resources.ApplyResources(this.tblCommMethod.coldValidTo, "tblCommMethod.coldValidTo");
            this.tblCommMethod.coldValidTo.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblCommMethod_coldValidTo_WindowActions);
            // 
            // tblCommMethod.colMethodDefault
            // 
            resources.ApplyResources(this.tblCommMethod.colMethodDefault, "tblCommMethod.colMethodDefault");
            // 
            // tblCommMethod.colnCommId
            // 
            resources.ApplyResources(this.tblCommMethod.colnCommId, "tblCommMethod.colnCommId");
            // 
            // tblCommMethod.colsAddressId
            // 
            resources.ApplyResources(this.tblCommMethod.colsAddressId, "tblCommMethod.colsAddressId");
            // 
            // tblCommMethod.colsDescription
            // 
            resources.ApplyResources(this.tblCommMethod.colsDescription, "tblCommMethod.colsDescription");
            // 
            // tblCommMethod.colsIdentity
            // 
            resources.ApplyResources(this.tblCommMethod.colsIdentity, "tblCommMethod.colsIdentity");
            // 
            // tblCommMethod.colsMethodId
            // 
            resources.ApplyResources(this.tblCommMethod.colsMethodId, "tblCommMethod.colsMethodId");
            // 
            // tblCommMethod.colsName
            // 
            resources.ApplyResources(this.tblCommMethod.colsName, "tblCommMethod.colsName");
            // 
            // tblCommMethod.colsPartyType
            // 
            resources.ApplyResources(this.tblCommMethod.colsPartyType, "tblCommMethod.colsPartyType");
            // 
            // tblCommMethod.colsPartyTypeDb
            // 
            resources.ApplyResources(this.tblCommMethod.colsPartyTypeDb, "tblCommMethod.colsPartyTypeDb");
            // 
            // tblCommMethod.colsPrevAddrId
            // 
            resources.ApplyResources(this.tblCommMethod.colsPrevAddrId, "tblCommMethod.colsPrevAddrId");
            // 
            // tblCommMethod.colsValue
            // 
            resources.ApplyResources(this.tblCommMethod.colsValue, "tblCommMethod.colsValue");
            this.tblCommMethod.Controls.Add(this.tblCommMethod_coldValidFromOld);
            this.tblCommMethod.Controls.Add(this.tblCommMethod_coldValidToOld);
            resources.ApplyResources(this.tblCommMethod, "tblCommMethod");
            this.tblCommMethod.Name = "tblCommMethod";
            this.tblCommMethod.NamedProperties.Put("DefaultOrderBy", "");
            this.tblCommMethod.NamedProperties.Put("DefaultWhere", "PARTY_TYPE_DB = \'SUPPLIER\' AND\r\nIDENTITY = :i_hWndFrame.frmSupplierInfoAddress.df" +
        "sSupplierId AND\r\nADDRESS_ID = :i_hWndFrame.frmSupplierInfoAddress.cmbAddressId.i" +
        "_sMyValue");
            this.tblCommMethod.NamedProperties.Put("LogicalUnit", "CommMethod");
            this.tblCommMethod.NamedProperties.Put("PackageName", "COMM_METHOD_API");
            this.tblCommMethod.NamedProperties.Put("ResizeableChildObject", "LLML");
            this.tblCommMethod.NamedProperties.Put("ViewName", "COMM_METHOD");
            this.tblCommMethod.NamedProperties.Put("Warnings", "FALSE");
            this.tblCommMethod.DataRecordExecuteModifyEvent += new Ifs.Fnd.ApplicationForms.cDataSource.DataRecordExecuteModifyEventHandler(this.tblCommMethod_DataRecordExecuteModifyEvent);
            this.tblCommMethod.DataRecordExecuteNewEvent += new Ifs.Fnd.ApplicationForms.cDataSource.DataRecordExecuteNewEventHandler(this.tblCommMethod_DataRecordExecuteNewEvent);
            this.tblCommMethod.DataSourcePrepareKeyTransferEvent += new Ifs.Fnd.ApplicationForms.cDataSource.DataSourcePrepareKeyTransferEventHandler(this.tblCommMethod_DataSourcePrepareKeyTransferEvent);
            this.tblCommMethod.Controls.SetChildIndex(this.tblCommMethod_coldValidToOld, 0);
            this.tblCommMethod.Controls.SetChildIndex(this.tblCommMethod_coldValidFromOld, 0);
            // 
            // tblCommMethod_coldValidFromOld
            // 
            this.tblCommMethod_coldValidFromOld.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.tblCommMethod_coldValidFromOld.Format = "d";
            this.tblCommMethod_coldValidFromOld.Name = "tblCommMethod_coldValidFromOld";
            this.tblCommMethod_coldValidFromOld.NamedProperties.Put("EnumerateMethod", "");
            this.tblCommMethod_coldValidFromOld.NamedProperties.Put("FieldFlags", "290");
            this.tblCommMethod_coldValidFromOld.NamedProperties.Put("LovReference", "");
            this.tblCommMethod_coldValidFromOld.NamedProperties.Put("SqlColumn", "VALID_FROM");
            this.tblCommMethod_coldValidFromOld.Position = 17;
            resources.ApplyResources(this.tblCommMethod_coldValidFromOld, "tblCommMethod_coldValidFromOld");
            // 
            // tblCommMethod_coldValidToOld
            // 
            this.tblCommMethod_coldValidToOld.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.tblCommMethod_coldValidToOld.Format = "d";
            this.tblCommMethod_coldValidToOld.Name = "tblCommMethod_coldValidToOld";
            this.tblCommMethod_coldValidToOld.NamedProperties.Put("EnumerateMethod", "");
            this.tblCommMethod_coldValidToOld.NamedProperties.Put("FieldFlags", "290");
            this.tblCommMethod_coldValidToOld.NamedProperties.Put("LovReference", "");
            this.tblCommMethod_coldValidToOld.NamedProperties.Put("SqlColumn", "VALID_TO");
            this.tblCommMethod_coldValidToOld.Position = 18;
            resources.ApplyResources(this.tblCommMethod_coldValidToOld, "tblCommMethod_coldValidToOld");
            // 
            // tblSupplierInfoContact
            // 
            this.tblSupplierInfoContact.Controls.Add(this.tblSupplierInfoContact_colsSupplierId);
            this.tblSupplierInfoContact.Controls.Add(this.tblSupplierInfoContact_colsSupplierAddress);
            this.tblSupplierInfoContact.Controls.Add(this.tblSupplierInfoContact_colsPersonId);
            this.tblSupplierInfoContact.Controls.Add(this.tblSupplierInfoContact_colPersonInfoName);
            this.tblSupplierInfoContact.Controls.Add(this.tblSupplierInfoContact_colPersonInfoTitle);
            this.tblSupplierInfoContact.Controls.Add(this.tblSupplierInfoContact_colsRole);
            this.tblSupplierInfoContact.Controls.Add(this.tblSupplierInfoContact_colsContactAddress);
            this.tblSupplierInfoContact.Controls.Add(this.tblSupplierInfoContact_colsMainRepresentativeId);
            this.tblSupplierInfoContact.Controls.Add(this.tblSupplierInfoContact_colsMainRepresentativeName);
            this.tblSupplierInfoContact.Controls.Add(this.tblSupplierInfoContact_colsDepartment);
            this.tblSupplierInfoContact.Controls.Add(this.tblSupplierInfoContact_colsConnectAllSuppAddrDb);
            this.tblSupplierInfoContact.Controls.Add(this.tblSupplierInfoContact_colAddressPrimary);
            this.tblSupplierInfoContact.Controls.Add(this.tblSupplierInfoContact_colAddressSecondary);
            this.tblSupplierInfoContact.Controls.Add(this.tblSupplierInfoContact_colSupplierPrimary);
            this.tblSupplierInfoContact.Controls.Add(this.tblSupplierInfoContact_colSupplierSecondary);
            this.tblSupplierInfoContact.Controls.Add(this.tblSupplierInfoContact_colPersonInfoAddressPhone);
            this.tblSupplierInfoContact.Controls.Add(this.tblSupplierInfoContact_colPersonInfoAddressMobile);
            this.tblSupplierInfoContact.Controls.Add(this.tblSupplierInfoContact_colPersonInfoAddressE_Mail);
            this.tblSupplierInfoContact.Controls.Add(this.tblSupplierInfoContact_colPersonInfoAddressFax);
            this.tblSupplierInfoContact.Controls.Add(this.tblSupplierInfoContact_colPersonInfoAddressPager);
            this.tblSupplierInfoContact.Controls.Add(this.tblSupplierInfoContact_colPersonInfoAddressIntercom);
            this.tblSupplierInfoContact.Controls.Add(this.tblSupplierInfoContact_colPersonInfoAddressWww);
            this.tblSupplierInfoContact.Controls.Add(this.tblSupplierInfoContact_colNoteText);
            this.picTab.SetControlTabPages(this.tblSupplierInfoContact, "Name0");
            resources.ApplyResources(this.tblSupplierInfoContact, "tblSupplierInfoContact");
            this.tblSupplierInfoContact.Name = "tblSupplierInfoContact";
            this.tblSupplierInfoContact.NamedProperties.Put("DefaultOrderBy", "");
            this.tblSupplierInfoContact.NamedProperties.Put("DefaultWhere", "SUPPLIER_ID = :i_hWndFrame.frmSupplierInfoAddress.dfsSupplierId AND (SUPPLIER_ADD" +
        "RESS = :i_hWndFrame.frmSupplierInfoAddress.cmbAddressId.i_sMyValue OR CONNECT_AL" +
        "L_SUPP_ADDR_DB = \'TRUE\')");
            this.tblSupplierInfoContact.NamedProperties.Put("LogicalUnit", "SupplierInfoContact");
            this.tblSupplierInfoContact.NamedProperties.Put("PackageName", "SUPPLIER_INFO_CONTACT_API");
            this.tblSupplierInfoContact.NamedProperties.Put("ResizeableChildObject", "LLMR");
            this.tblSupplierInfoContact.NamedProperties.Put("ViewName", "SUPPLIER_INFO_CONTACT");
            this.tblSupplierInfoContact.NamedProperties.Put("Warnings", "FALSE");
            this.tblSupplierInfoContact.DataRecordExecuteNewEvent += new Ifs.Fnd.ApplicationForms.cDataSource.DataRecordExecuteNewEventHandler(this.tblSupplierInfoContact_DataRecordExecuteNewEvent);
            this.tblSupplierInfoContact.Controls.SetChildIndex(this.tblSupplierInfoContact_colNoteText, 0);
            this.tblSupplierInfoContact.Controls.SetChildIndex(this.tblSupplierInfoContact_colPersonInfoAddressWww, 0);
            this.tblSupplierInfoContact.Controls.SetChildIndex(this.tblSupplierInfoContact_colPersonInfoAddressIntercom, 0);
            this.tblSupplierInfoContact.Controls.SetChildIndex(this.tblSupplierInfoContact_colPersonInfoAddressPager, 0);
            this.tblSupplierInfoContact.Controls.SetChildIndex(this.tblSupplierInfoContact_colPersonInfoAddressFax, 0);
            this.tblSupplierInfoContact.Controls.SetChildIndex(this.tblSupplierInfoContact_colPersonInfoAddressE_Mail, 0);
            this.tblSupplierInfoContact.Controls.SetChildIndex(this.tblSupplierInfoContact_colPersonInfoAddressMobile, 0);
            this.tblSupplierInfoContact.Controls.SetChildIndex(this.tblSupplierInfoContact_colPersonInfoAddressPhone, 0);
            this.tblSupplierInfoContact.Controls.SetChildIndex(this.tblSupplierInfoContact_colSupplierSecondary, 0);
            this.tblSupplierInfoContact.Controls.SetChildIndex(this.tblSupplierInfoContact_colSupplierPrimary, 0);
            this.tblSupplierInfoContact.Controls.SetChildIndex(this.tblSupplierInfoContact_colAddressSecondary, 0);
            this.tblSupplierInfoContact.Controls.SetChildIndex(this.tblSupplierInfoContact_colAddressPrimary, 0);
            this.tblSupplierInfoContact.Controls.SetChildIndex(this.tblSupplierInfoContact_colsConnectAllSuppAddrDb, 0);
            this.tblSupplierInfoContact.Controls.SetChildIndex(this.tblSupplierInfoContact_colsDepartment, 0);
            this.tblSupplierInfoContact.Controls.SetChildIndex(this.tblSupplierInfoContact_colsMainRepresentativeName, 0);
            this.tblSupplierInfoContact.Controls.SetChildIndex(this.tblSupplierInfoContact_colsMainRepresentativeId, 0);
            this.tblSupplierInfoContact.Controls.SetChildIndex(this.tblSupplierInfoContact_colsContactAddress, 0);
            this.tblSupplierInfoContact.Controls.SetChildIndex(this.tblSupplierInfoContact_colsRole, 0);
            this.tblSupplierInfoContact.Controls.SetChildIndex(this.tblSupplierInfoContact_colPersonInfoTitle, 0);
            this.tblSupplierInfoContact.Controls.SetChildIndex(this.tblSupplierInfoContact_colPersonInfoName, 0);
            this.tblSupplierInfoContact.Controls.SetChildIndex(this.tblSupplierInfoContact_colsPersonId, 0);
            this.tblSupplierInfoContact.Controls.SetChildIndex(this.tblSupplierInfoContact_colsSupplierAddress, 0);
            this.tblSupplierInfoContact.Controls.SetChildIndex(this.tblSupplierInfoContact_colsSupplierId, 0);
            // 
            // tblSupplierInfoContact_colsSupplierId
            // 
            this.tblSupplierInfoContact_colsSupplierId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblSupplierInfoContact_colsSupplierId, "tblSupplierInfoContact_colsSupplierId");
            this.tblSupplierInfoContact_colsSupplierId.MaxLength = 20;
            this.tblSupplierInfoContact_colsSupplierId.Name = "tblSupplierInfoContact_colsSupplierId";
            this.tblSupplierInfoContact_colsSupplierId.NamedProperties.Put("EnumerateMethod", "");
            this.tblSupplierInfoContact_colsSupplierId.NamedProperties.Put("FieldFlags", "67");
            this.tblSupplierInfoContact_colsSupplierId.NamedProperties.Put("LovReference", "SUPPLIER_INFO_GENERAL");
            this.tblSupplierInfoContact_colsSupplierId.NamedProperties.Put("SqlColumn", "SUPPLIER_ID");
            this.tblSupplierInfoContact_colsSupplierId.Position = 3;
            // 
            // tblSupplierInfoContact_colsSupplierAddress
            // 
            this.tblSupplierInfoContact_colsSupplierAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblSupplierInfoContact_colsSupplierAddress, "tblSupplierInfoContact_colsSupplierAddress");
            this.tblSupplierInfoContact_colsSupplierAddress.MaxLength = 50;
            this.tblSupplierInfoContact_colsSupplierAddress.Name = "tblSupplierInfoContact_colsSupplierAddress";
            this.tblSupplierInfoContact_colsSupplierAddress.NamedProperties.Put("EnumerateMethod", "");
            this.tblSupplierInfoContact_colsSupplierAddress.NamedProperties.Put("FieldFlags", "294");
            this.tblSupplierInfoContact_colsSupplierAddress.NamedProperties.Put("LovReference", "SUPPLIER_INFO_ADDRESS(SUPPLIER_ID)");
            this.tblSupplierInfoContact_colsSupplierAddress.NamedProperties.Put("SqlColumn", "SUPPLIER_ADDRESS");
            this.tblSupplierInfoContact_colsSupplierAddress.Position = 4;
            // 
            // tblSupplierInfoContact_colsPersonId
            // 
            this.tblSupplierInfoContact_colsPersonId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblSupplierInfoContact_colsPersonId.MaxLength = 20;
            this.tblSupplierInfoContact_colsPersonId.Name = "tblSupplierInfoContact_colsPersonId";
            this.tblSupplierInfoContact_colsPersonId.NamedProperties.Put("EnumerateMethod", "");
            this.tblSupplierInfoContact_colsPersonId.NamedProperties.Put("FieldFlags", "67");
            this.tblSupplierInfoContact_colsPersonId.NamedProperties.Put("LovReference", "PERSON_INFO_ALL");
            this.tblSupplierInfoContact_colsPersonId.NamedProperties.Put("SqlColumn", "PERSON_ID");
            this.tblSupplierInfoContact_colsPersonId.Position = 5;
            resources.ApplyResources(this.tblSupplierInfoContact_colsPersonId, "tblSupplierInfoContact_colsPersonId");
            this.tblSupplierInfoContact_colsPersonId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsPersonId_WindowActions);
            // 
            // tblSupplierInfoContact_colPersonInfoName
            // 
            this.tblSupplierInfoContact_colPersonInfoName.MaxLength = 2000;
            this.tblSupplierInfoContact_colPersonInfoName.Name = "tblSupplierInfoContact_colPersonInfoName";
            this.tblSupplierInfoContact_colPersonInfoName.NamedProperties.Put("EnumerateMethod", "");
            this.tblSupplierInfoContact_colPersonInfoName.NamedProperties.Put("FieldFlags", "304");
            this.tblSupplierInfoContact_colPersonInfoName.NamedProperties.Put("LovReference", "");
            this.tblSupplierInfoContact_colPersonInfoName.NamedProperties.Put("ParentName", "tblSupplierInfoContact.tblSupplierInfoContact_colsPersonId");
            this.tblSupplierInfoContact_colPersonInfoName.NamedProperties.Put("SqlColumn", "PERSON_INFO_API.Get_Name(PERSON_ID)");
            this.tblSupplierInfoContact_colPersonInfoName.NamedProperties.Put("ValidateMethod", "");
            this.tblSupplierInfoContact_colPersonInfoName.Position = 6;
            resources.ApplyResources(this.tblSupplierInfoContact_colPersonInfoName, "tblSupplierInfoContact_colPersonInfoName");
            // 
            // tblSupplierInfoContact_colPersonInfoTitle
            // 
            this.tblSupplierInfoContact_colPersonInfoTitle.MaxLength = 2000;
            this.tblSupplierInfoContact_colPersonInfoTitle.Name = "tblSupplierInfoContact_colPersonInfoTitle";
            this.tblSupplierInfoContact_colPersonInfoTitle.NamedProperties.Put("EnumerateMethod", "");
            this.tblSupplierInfoContact_colPersonInfoTitle.NamedProperties.Put("FieldFlags", "304");
            this.tblSupplierInfoContact_colPersonInfoTitle.NamedProperties.Put("LovReference", "");
            this.tblSupplierInfoContact_colPersonInfoTitle.NamedProperties.Put("ParentName", "tblSupplierInfoContact.tblSupplierInfoContact_colsPersonId");
            this.tblSupplierInfoContact_colPersonInfoTitle.NamedProperties.Put("SqlColumn", "PERSON_INFO_API.Get_Title(PERSON_ID)");
            this.tblSupplierInfoContact_colPersonInfoTitle.NamedProperties.Put("ValidateMethod", "");
            this.tblSupplierInfoContact_colPersonInfoTitle.Position = 7;
            resources.ApplyResources(this.tblSupplierInfoContact_colPersonInfoTitle, "tblSupplierInfoContact_colPersonInfoTitle");
            // 
            // tblSupplierInfoContact_colsRole
            // 
            this.tblSupplierInfoContact_colsRole.MaxLength = 4000;
            this.tblSupplierInfoContact_colsRole.Name = "tblSupplierInfoContact_colsRole";
            this.tblSupplierInfoContact_colsRole.NamedProperties.Put("EnumerateMethod", "CONTACT_ROLE_API.Enumerate");
            this.tblSupplierInfoContact_colsRole.NamedProperties.Put("FieldFlags", "294");
            this.tblSupplierInfoContact_colsRole.NamedProperties.Put("SqlColumn", "ROLE");
            this.tblSupplierInfoContact_colsRole.Position = 8;
            resources.ApplyResources(this.tblSupplierInfoContact_colsRole, "tblSupplierInfoContact_colsRole");
            // 
            // tblSupplierInfoContact_colsContactAddress
            // 
            this.tblSupplierInfoContact_colsContactAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblSupplierInfoContact_colsContactAddress.MaxLength = 50;
            this.tblSupplierInfoContact_colsContactAddress.Name = "tblSupplierInfoContact_colsContactAddress";
            this.tblSupplierInfoContact_colsContactAddress.NamedProperties.Put("EnumerateMethod", "");
            this.tblSupplierInfoContact_colsContactAddress.NamedProperties.Put("FieldFlags", "294");
            this.tblSupplierInfoContact_colsContactAddress.NamedProperties.Put("LovReference", "PERSON_INFO_ADDRESS1(PERSON_ID)");
            this.tblSupplierInfoContact_colsContactAddress.NamedProperties.Put("SqlColumn", "CONTACT_ADDRESS");
            this.tblSupplierInfoContact_colsContactAddress.Position = 9;
            resources.ApplyResources(this.tblSupplierInfoContact_colsContactAddress, "tblSupplierInfoContact_colsContactAddress");
            // 
            // tblSupplierInfoContact_colsMainRepresentativeId
            // 
            this.tblSupplierInfoContact_colsMainRepresentativeId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblSupplierInfoContact_colsMainRepresentativeId.MaxLength = 20;
            this.tblSupplierInfoContact_colsMainRepresentativeId.Name = "tblSupplierInfoContact_colsMainRepresentativeId";
            this.tblSupplierInfoContact_colsMainRepresentativeId.NamedProperties.Put("EnumerateMethod", "");
            this.tblSupplierInfoContact_colsMainRepresentativeId.NamedProperties.Put("FieldFlags", "290");
            this.tblSupplierInfoContact_colsMainRepresentativeId.NamedProperties.Put("LovReference", "BUSINESS_REPRESENTATIVE_LOV");
            this.tblSupplierInfoContact_colsMainRepresentativeId.NamedProperties.Put("SqlColumn", "MAIN_REPRESENTATIVE_ID");
            this.tblSupplierInfoContact_colsMainRepresentativeId.Position = 10;
            resources.ApplyResources(this.tblSupplierInfoContact_colsMainRepresentativeId, "tblSupplierInfoContact_colsMainRepresentativeId");
            // 
            // tblSupplierInfoContact_colsMainRepresentativeName
            // 
            this.tblSupplierInfoContact_colsMainRepresentativeName.MaxLength = 2000;
            this.tblSupplierInfoContact_colsMainRepresentativeName.Name = "tblSupplierInfoContact_colsMainRepresentativeName";
            this.tblSupplierInfoContact_colsMainRepresentativeName.NamedProperties.Put("EnumerateMethod", "");
            this.tblSupplierInfoContact_colsMainRepresentativeName.NamedProperties.Put("FieldFlags", "288");
            this.tblSupplierInfoContact_colsMainRepresentativeName.NamedProperties.Put("LovReference", "");
            this.tblSupplierInfoContact_colsMainRepresentativeName.NamedProperties.Put("ParentName", "tblSupplierInfoContact.tblSupplierInfoContact_colsMainRepresentativeId");
            this.tblSupplierInfoContact_colsMainRepresentativeName.NamedProperties.Put("SqlColumn", "Person_Info_API.Get_Name(MAIN_REPRESENTATIVE_ID)");
            this.tblSupplierInfoContact_colsMainRepresentativeName.Position = 11;
            resources.ApplyResources(this.tblSupplierInfoContact_colsMainRepresentativeName, "tblSupplierInfoContact_colsMainRepresentativeName");
            // 
            // tblSupplierInfoContact_colsDepartment
            // 
            this.tblSupplierInfoContact_colsDepartment.IsLookup = true;
            this.tblSupplierInfoContact_colsDepartment.MaxLength = 200;
            this.tblSupplierInfoContact_colsDepartment.Name = "tblSupplierInfoContact_colsDepartment";
            this.tblSupplierInfoContact_colsDepartment.NamedProperties.Put("EnumerateMethod", "CONTACT_DEPARTMENT_API.Enumerate");
            this.tblSupplierInfoContact_colsDepartment.NamedProperties.Put("FieldFlags", "294");
            this.tblSupplierInfoContact_colsDepartment.NamedProperties.Put("LovReference", "");
            this.tblSupplierInfoContact_colsDepartment.NamedProperties.Put("SqlColumn", "DEPARTMENT");
            this.tblSupplierInfoContact_colsDepartment.Position = 12;
            resources.ApplyResources(this.tblSupplierInfoContact_colsDepartment, "tblSupplierInfoContact_colsDepartment");
            // 
            // tblSupplierInfoContact_colsConnectAllSuppAddrDb
            // 
            this.tblSupplierInfoContact_colsConnectAllSuppAddrDb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblSupplierInfoContact_colsConnectAllSuppAddrDb, "tblSupplierInfoContact_colsConnectAllSuppAddrDb");
            this.tblSupplierInfoContact_colsConnectAllSuppAddrDb.MaxLength = 20;
            this.tblSupplierInfoContact_colsConnectAllSuppAddrDb.Name = "tblSupplierInfoContact_colsConnectAllSuppAddrDb";
            this.tblSupplierInfoContact_colsConnectAllSuppAddrDb.NamedProperties.Put("EnumerateMethod", "");
            this.tblSupplierInfoContact_colsConnectAllSuppAddrDb.NamedProperties.Put("FieldFlags", "288");
            this.tblSupplierInfoContact_colsConnectAllSuppAddrDb.NamedProperties.Put("LovReference", "");
            this.tblSupplierInfoContact_colsConnectAllSuppAddrDb.NamedProperties.Put("LovTimeReference", "");
            this.tblSupplierInfoContact_colsConnectAllSuppAddrDb.NamedProperties.Put("SqlColumn", "CONNECT_ALL_SUPP_ADDR_DB");
            this.tblSupplierInfoContact_colsConnectAllSuppAddrDb.Position = 13;
            // 
            // tblSupplierInfoContact_colAddressPrimary
            // 
            this.tblSupplierInfoContact_colAddressPrimary.Name = "tblSupplierInfoContact_colAddressPrimary";
            this.tblSupplierInfoContact_colAddressPrimary.NamedProperties.Put("EnumerateMethod", "");
            this.tblSupplierInfoContact_colAddressPrimary.NamedProperties.Put("FieldFlags", "295");
            this.tblSupplierInfoContact_colAddressPrimary.NamedProperties.Put("LovReference", "");
            this.tblSupplierInfoContact_colAddressPrimary.NamedProperties.Put("SqlColumn", "ADDRESS_PRIMARY");
            this.tblSupplierInfoContact_colAddressPrimary.Position = 14;
            resources.ApplyResources(this.tblSupplierInfoContact_colAddressPrimary, "tblSupplierInfoContact_colAddressPrimary");
            // 
            // tblSupplierInfoContact_colAddressSecondary
            // 
            this.tblSupplierInfoContact_colAddressSecondary.Name = "tblSupplierInfoContact_colAddressSecondary";
            this.tblSupplierInfoContact_colAddressSecondary.NamedProperties.Put("EnumerateMethod", "");
            this.tblSupplierInfoContact_colAddressSecondary.NamedProperties.Put("FieldFlags", "295");
            this.tblSupplierInfoContact_colAddressSecondary.NamedProperties.Put("LovReference", "");
            this.tblSupplierInfoContact_colAddressSecondary.NamedProperties.Put("SqlColumn", "ADDRESS_SECONDARY");
            this.tblSupplierInfoContact_colAddressSecondary.Position = 15;
            resources.ApplyResources(this.tblSupplierInfoContact_colAddressSecondary, "tblSupplierInfoContact_colAddressSecondary");
            // 
            // tblSupplierInfoContact_colSupplierPrimary
            // 
            this.tblSupplierInfoContact_colSupplierPrimary.Name = "tblSupplierInfoContact_colSupplierPrimary";
            this.tblSupplierInfoContact_colSupplierPrimary.NamedProperties.Put("EnumerateMethod", "");
            this.tblSupplierInfoContact_colSupplierPrimary.NamedProperties.Put("FieldFlags", "295");
            this.tblSupplierInfoContact_colSupplierPrimary.NamedProperties.Put("LovReference", "");
            this.tblSupplierInfoContact_colSupplierPrimary.NamedProperties.Put("SqlColumn", "SUPPLIER_PRIMARY");
            this.tblSupplierInfoContact_colSupplierPrimary.Position = 16;
            resources.ApplyResources(this.tblSupplierInfoContact_colSupplierPrimary, "tblSupplierInfoContact_colSupplierPrimary");
            // 
            // tblSupplierInfoContact_colSupplierSecondary
            // 
            this.tblSupplierInfoContact_colSupplierSecondary.Name = "tblSupplierInfoContact_colSupplierSecondary";
            this.tblSupplierInfoContact_colSupplierSecondary.NamedProperties.Put("EnumerateMethod", "");
            this.tblSupplierInfoContact_colSupplierSecondary.NamedProperties.Put("FieldFlags", "295");
            this.tblSupplierInfoContact_colSupplierSecondary.NamedProperties.Put("LovReference", "");
            this.tblSupplierInfoContact_colSupplierSecondary.NamedProperties.Put("SqlColumn", "SUPPLIER_SECONDARY");
            this.tblSupplierInfoContact_colSupplierSecondary.Position = 17;
            resources.ApplyResources(this.tblSupplierInfoContact_colSupplierSecondary, "tblSupplierInfoContact_colSupplierSecondary");
            // 
            // tblSupplierInfoContact_colPersonInfoAddressPhone
            // 
            this.tblSupplierInfoContact_colPersonInfoAddressPhone.MaxLength = 2000;
            this.tblSupplierInfoContact_colPersonInfoAddressPhone.Name = "tblSupplierInfoContact_colPersonInfoAddressPhone";
            this.tblSupplierInfoContact_colPersonInfoAddressPhone.NamedProperties.Put("EnumerateMethod", "");
            this.tblSupplierInfoContact_colPersonInfoAddressPhone.NamedProperties.Put("FieldFlags", "304");
            this.tblSupplierInfoContact_colPersonInfoAddressPhone.NamedProperties.Put("LovReference", "");
            this.tblSupplierInfoContact_colPersonInfoAddressPhone.NamedProperties.Put("ParentName", "tblSupplierInfoContact.tblSupplierInfoContact_colsContactAddress");
            this.tblSupplierInfoContact_colPersonInfoAddressPhone.NamedProperties.Put("SqlColumn", "Comm_Method_API.Get_Value(\'PERSON\', person_id, &AO.Comm_Method_Code_API.Decode(\'P" +
        "HONE\'), 1, CONTACT_ADDRESS, sysdate)");
            this.tblSupplierInfoContact_colPersonInfoAddressPhone.NamedProperties.Put("ValidateMethod", "");
            this.tblSupplierInfoContact_colPersonInfoAddressPhone.Position = 18;
            resources.ApplyResources(this.tblSupplierInfoContact_colPersonInfoAddressPhone, "tblSupplierInfoContact_colPersonInfoAddressPhone");
            // 
            // tblSupplierInfoContact_colPersonInfoAddressMobile
            // 
            this.tblSupplierInfoContact_colPersonInfoAddressMobile.MaxLength = 2000;
            this.tblSupplierInfoContact_colPersonInfoAddressMobile.Name = "tblSupplierInfoContact_colPersonInfoAddressMobile";
            this.tblSupplierInfoContact_colPersonInfoAddressMobile.NamedProperties.Put("EnumerateMethod", "");
            this.tblSupplierInfoContact_colPersonInfoAddressMobile.NamedProperties.Put("FieldFlags", "304");
            this.tblSupplierInfoContact_colPersonInfoAddressMobile.NamedProperties.Put("LovReference", "");
            this.tblSupplierInfoContact_colPersonInfoAddressMobile.NamedProperties.Put("ParentName", "tblSupplierInfoContact.tblSupplierInfoContact_colsContactAddress");
            this.tblSupplierInfoContact_colPersonInfoAddressMobile.NamedProperties.Put("SqlColumn", "Comm_Method_API.Get_Value(\'PERSON\', person_id, &AO.Comm_Method_Code_API.Decode(\'M" +
        "OBILE\'), 1, CONTACT_ADDRESS)");
            this.tblSupplierInfoContact_colPersonInfoAddressMobile.Position = 19;
            resources.ApplyResources(this.tblSupplierInfoContact_colPersonInfoAddressMobile, "tblSupplierInfoContact_colPersonInfoAddressMobile");
            // 
            // tblSupplierInfoContact_colPersonInfoAddressE_Mail
            // 
            this.tblSupplierInfoContact_colPersonInfoAddressE_Mail.MaxLength = 2000;
            this.tblSupplierInfoContact_colPersonInfoAddressE_Mail.Name = "tblSupplierInfoContact_colPersonInfoAddressE_Mail";
            this.tblSupplierInfoContact_colPersonInfoAddressE_Mail.NamedProperties.Put("EnumerateMethod", "");
            this.tblSupplierInfoContact_colPersonInfoAddressE_Mail.NamedProperties.Put("FieldFlags", "304");
            this.tblSupplierInfoContact_colPersonInfoAddressE_Mail.NamedProperties.Put("LovReference", "");
            this.tblSupplierInfoContact_colPersonInfoAddressE_Mail.NamedProperties.Put("ParentName", "tblSupplierInfoContact.tblSupplierInfoContact_colsContactAddress");
            this.tblSupplierInfoContact_colPersonInfoAddressE_Mail.NamedProperties.Put("SqlColumn", "Comm_Method_API.Get_Value(\'PERSON\', person_id, &AO.Comm_Method_Code_API.Decode(\'E" +
        "_MAIL\'), 1, CONTACT_ADDRESS)");
            this.tblSupplierInfoContact_colPersonInfoAddressE_Mail.NamedProperties.Put("ValidateMethod", "");
            this.tblSupplierInfoContact_colPersonInfoAddressE_Mail.Position = 20;
            resources.ApplyResources(this.tblSupplierInfoContact_colPersonInfoAddressE_Mail, "tblSupplierInfoContact_colPersonInfoAddressE_Mail");
            // 
            // tblSupplierInfoContact_colPersonInfoAddressFax
            // 
            this.tblSupplierInfoContact_colPersonInfoAddressFax.MaxLength = 2000;
            this.tblSupplierInfoContact_colPersonInfoAddressFax.Name = "tblSupplierInfoContact_colPersonInfoAddressFax";
            this.tblSupplierInfoContact_colPersonInfoAddressFax.NamedProperties.Put("EnumerateMethod", "");
            this.tblSupplierInfoContact_colPersonInfoAddressFax.NamedProperties.Put("FieldFlags", "304");
            this.tblSupplierInfoContact_colPersonInfoAddressFax.NamedProperties.Put("LovReference", "");
            this.tblSupplierInfoContact_colPersonInfoAddressFax.NamedProperties.Put("ParentName", "tblSupplierInfoContact.tblSupplierInfoContact_colsContactAddress");
            this.tblSupplierInfoContact_colPersonInfoAddressFax.NamedProperties.Put("SqlColumn", "Comm_Method_API.Get_Value(\'PERSON\', person_id, Comm_Method_Code_API.Decode(\'FAX\')" +
        ", 1, CONTACT_ADDRESS, sysdate)");
            this.tblSupplierInfoContact_colPersonInfoAddressFax.NamedProperties.Put("ValidateMethod", "");
            this.tblSupplierInfoContact_colPersonInfoAddressFax.Position = 21;
            resources.ApplyResources(this.tblSupplierInfoContact_colPersonInfoAddressFax, "tblSupplierInfoContact_colPersonInfoAddressFax");
            // 
            // tblSupplierInfoContact_colPersonInfoAddressPager
            // 
            this.tblSupplierInfoContact_colPersonInfoAddressPager.MaxLength = 2000;
            this.tblSupplierInfoContact_colPersonInfoAddressPager.Name = "tblSupplierInfoContact_colPersonInfoAddressPager";
            this.tblSupplierInfoContact_colPersonInfoAddressPager.NamedProperties.Put("EnumerateMethod", "");
            this.tblSupplierInfoContact_colPersonInfoAddressPager.NamedProperties.Put("FieldFlags", "304");
            this.tblSupplierInfoContact_colPersonInfoAddressPager.NamedProperties.Put("LovReference", "");
            this.tblSupplierInfoContact_colPersonInfoAddressPager.NamedProperties.Put("ParentName", "tblSupplierInfoContact.tblSupplierInfoContact_colsContactAddress");
            this.tblSupplierInfoContact_colPersonInfoAddressPager.NamedProperties.Put("SqlColumn", "Comm_Method_API.Get_Value(\'PERSON\', person_id, &AO.Comm_Method_Code_API.Decode(\'P" +
        "AGER\'), 1, CONTACT_ADDRESS)");
            this.tblSupplierInfoContact_colPersonInfoAddressPager.NamedProperties.Put("ValidateMethod", "");
            this.tblSupplierInfoContact_colPersonInfoAddressPager.Position = 22;
            resources.ApplyResources(this.tblSupplierInfoContact_colPersonInfoAddressPager, "tblSupplierInfoContact_colPersonInfoAddressPager");
            // 
            // tblSupplierInfoContact_colPersonInfoAddressIntercom
            // 
            this.tblSupplierInfoContact_colPersonInfoAddressIntercom.MaxLength = 2000;
            this.tblSupplierInfoContact_colPersonInfoAddressIntercom.Name = "tblSupplierInfoContact_colPersonInfoAddressIntercom";
            this.tblSupplierInfoContact_colPersonInfoAddressIntercom.NamedProperties.Put("EnumerateMethod", "");
            this.tblSupplierInfoContact_colPersonInfoAddressIntercom.NamedProperties.Put("FieldFlags", "304");
            this.tblSupplierInfoContact_colPersonInfoAddressIntercom.NamedProperties.Put("LovReference", "");
            this.tblSupplierInfoContact_colPersonInfoAddressIntercom.NamedProperties.Put("ParentName", "tblSupplierInfoContact.tblSupplierInfoContact_colsContactAddress");
            this.tblSupplierInfoContact_colPersonInfoAddressIntercom.NamedProperties.Put("SqlColumn", "Comm_Method_API.Get_Value(\'PERSON\', person_id, &AO.Comm_Method_Code_API.Decode(\'I" +
        "NTERCOM\'), 1, CONTACT_ADDRESS)");
            this.tblSupplierInfoContact_colPersonInfoAddressIntercom.NamedProperties.Put("ValidateMethod", "");
            this.tblSupplierInfoContact_colPersonInfoAddressIntercom.Position = 23;
            resources.ApplyResources(this.tblSupplierInfoContact_colPersonInfoAddressIntercom, "tblSupplierInfoContact_colPersonInfoAddressIntercom");
            // 
            // tblSupplierInfoContact_colPersonInfoAddressWww
            // 
            this.tblSupplierInfoContact_colPersonInfoAddressWww.MaxLength = 2000;
            this.tblSupplierInfoContact_colPersonInfoAddressWww.Name = "tblSupplierInfoContact_colPersonInfoAddressWww";
            this.tblSupplierInfoContact_colPersonInfoAddressWww.NamedProperties.Put("EnumerateMethod", "");
            this.tblSupplierInfoContact_colPersonInfoAddressWww.NamedProperties.Put("FieldFlags", "272");
            this.tblSupplierInfoContact_colPersonInfoAddressWww.NamedProperties.Put("LovReference", "");
            this.tblSupplierInfoContact_colPersonInfoAddressWww.NamedProperties.Put("ParentName", "tblSupplierInfoContact.tblSupplierInfoContact_colsContactAddress");
            this.tblSupplierInfoContact_colPersonInfoAddressWww.NamedProperties.Put("SqlColumn", "Comm_Method_API.Get_Value(\'PERSON\', person_id, &AO.Comm_Method_Code_API.Decode(\'W" +
        "WW\'), 1, CONTACT_ADDRESS)");
            this.tblSupplierInfoContact_colPersonInfoAddressWww.NamedProperties.Put("ValidateMethod", "");
            this.tblSupplierInfoContact_colPersonInfoAddressWww.Position = 24;
            resources.ApplyResources(this.tblSupplierInfoContact_colPersonInfoAddressWww, "tblSupplierInfoContact_colPersonInfoAddressWww");
            // 
            // tblSupplierInfoContact_colNoteText
            // 
            this.tblSupplierInfoContact_colNoteText.MaxLength = 2000;
            this.tblSupplierInfoContact_colNoteText.Name = "tblSupplierInfoContact_colNoteText";
            this.tblSupplierInfoContact_colNoteText.NamedProperties.Put("EnumerateMethod", "");
            this.tblSupplierInfoContact_colNoteText.NamedProperties.Put("FieldFlags", "310");
            this.tblSupplierInfoContact_colNoteText.NamedProperties.Put("LovReference", "");
            this.tblSupplierInfoContact_colNoteText.NamedProperties.Put("SqlColumn", "NOTE_TEXT");
            this.tblSupplierInfoContact_colNoteText.Position = 25;
            resources.ApplyResources(this.tblSupplierInfoContact_colNoteText, "tblSupplierInfoContact_colNoteText");
            // 
            // frmSupplierInfoAddress
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.tblAddressType);
            this.Controls.Add(this.tblSupplierInfoContact);
            this.Controls.Add(this.tblCommMethod);
            this.Controls.Add(this.dfsSupplierBranch);
            this.Controls.Add(this.labelSupplierBranch);
            this.Controls.Add(this.labeldfsAddress6);
            this.Controls.Add(this.labeldfsAddress5);
            this.Controls.Add(this.labeldfsAddress4);
            this.Controls.Add(this.labeldfsAddress3);
            this.Controls.Add(this.dfsAddress6);
            this.Controls.Add(this.dfsAddress5);
            this.Controls.Add(this.dfsAddress4);
            this.Controls.Add(this.dfsAddress3);
            this.Controls.Add(this.amlAddress);
            this.Controls.Add(this.dfsSupplierId);
            this.Controls.Add(this.dfsName);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.dfsCountryCode);
            this.Controls.Add(this.dfsState);
            this.Controls.Add(this.dfsCounty);
            this.Controls.Add(this.dfsCity);
            this.Controls.Add(this.dfsZipCode);
            this.Controls.Add(this.dfsAddress2);
            this.Controls.Add(this.dfsAddress1);
            this.Controls.Add(this.cbDefaultDomain);
            this.Controls.Add(this.dfsParty);
            this.Controls.Add(this.cmbPartyType);
            this.Controls.Add(this.dfdValidTo);
            this.Controls.Add(this.dfdValidFrom);
            this.Controls.Add(this.cmbCountry);
            this.Controls.Add(this.dfsEanLocation);
            this.Controls.Add(this.cmbAddressId);
            this.Controls.Add(this.labeldfsCountryCode);
            this.Controls.Add(this.labeldfsState);
            this.Controls.Add(this.labeldfsCounty);
            this.Controls.Add(this.labeldfsCity);
            this.Controls.Add(this.labeldfsZipCode);
            this.Controls.Add(this.labeldfsAddress2);
            this.Controls.Add(this.labeldfsAddress1);
            this.Controls.Add(this.labeltblSupplierInfoContact);
            this.Controls.Add(this.labeltblCommMethod);
            this.Controls.Add(this.labeldfdValidTo);
            this.Controls.Add(this.labeldfdValidFrom);
            this.Controls.Add(this.labelamlAddress);
            this.Controls.Add(this.labelcmbCountry);
            this.Controls.Add(this.labeldfsEanLocation);
            this.Controls.Add(this.labelcmbAddressId);
            this.Name = "frmSupplierInfoAddress";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "SupplierInfoAddress");
            this.NamedProperties.Put("PackageName", "SUPPLIER_INFO_ADDRESS_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "4545");
            this.NamedProperties.Put("ViewName", "SUPPLIER_INFO_ADDRESS");
            this.NamedProperties.Put("Warnings", "TRUE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.frmSupplierInfoAddress_WindowActions);
            this.Controls.SetChildIndex(this.picTab, 0);
            this.Controls.SetChildIndex(this.labelcmbAddressId, 0);
            this.Controls.SetChildIndex(this.labeldfsEanLocation, 0);
            this.Controls.SetChildIndex(this.labelcmbCountry, 0);
            this.Controls.SetChildIndex(this.labelamlAddress, 0);
            this.Controls.SetChildIndex(this.labeldfdValidFrom, 0);
            this.Controls.SetChildIndex(this.labeldfdValidTo, 0);
            this.Controls.SetChildIndex(this.labeltblCommMethod, 0);
            this.Controls.SetChildIndex(this.labeltblSupplierInfoContact, 0);
            this.Controls.SetChildIndex(this.labeldfsAddress1, 0);
            this.Controls.SetChildIndex(this.labeldfsAddress2, 0);
            this.Controls.SetChildIndex(this.labeldfsZipCode, 0);
            this.Controls.SetChildIndex(this.labeldfsCity, 0);
            this.Controls.SetChildIndex(this.labeldfsCounty, 0);
            this.Controls.SetChildIndex(this.labeldfsState, 0);
            this.Controls.SetChildIndex(this.labeldfsCountryCode, 0);
            this.Controls.SetChildIndex(this.cmbAddressId, 0);
            this.Controls.SetChildIndex(this.dfsEanLocation, 0);
            this.Controls.SetChildIndex(this.cmbCountry, 0);
            this.Controls.SetChildIndex(this.dfdValidFrom, 0);
            this.Controls.SetChildIndex(this.dfdValidTo, 0);
            this.Controls.SetChildIndex(this.cmbPartyType, 0);
            this.Controls.SetChildIndex(this.dfsParty, 0);
            this.Controls.SetChildIndex(this.cbDefaultDomain, 0);
            this.Controls.SetChildIndex(this.dfsAddress1, 0);
            this.Controls.SetChildIndex(this.dfsAddress2, 0);
            this.Controls.SetChildIndex(this.dfsZipCode, 0);
            this.Controls.SetChildIndex(this.dfsCity, 0);
            this.Controls.SetChildIndex(this.dfsCounty, 0);
            this.Controls.SetChildIndex(this.dfsState, 0);
            this.Controls.SetChildIndex(this.dfsCountryCode, 0);
            this.Controls.SetChildIndex(this.labelName, 0);
            this.Controls.SetChildIndex(this.dfsName, 0);
            this.Controls.SetChildIndex(this.dfsSupplierId, 0);
            this.Controls.SetChildIndex(this.amlAddress, 0);
            this.Controls.SetChildIndex(this.dfsAddress3, 0);
            this.Controls.SetChildIndex(this.dfsAddress4, 0);
            this.Controls.SetChildIndex(this.dfsAddress5, 0);
            this.Controls.SetChildIndex(this.dfsAddress6, 0);
            this.Controls.SetChildIndex(this.labeldfsAddress3, 0);
            this.Controls.SetChildIndex(this.labeldfsAddress4, 0);
            this.Controls.SetChildIndex(this.labeldfsAddress5, 0);
            this.Controls.SetChildIndex(this.labeldfsAddress6, 0);
            this.Controls.SetChildIndex(this.labelSupplierBranch, 0);
            this.Controls.SetChildIndex(this.dfsSupplierBranch, 0);
            this.Controls.SetChildIndex(this.tblCommMethod, 0);
            this.Controls.SetChildIndex(this.tblSupplierInfoContact, 0);
            this.Controls.SetChildIndex(this.tblAddressType, 0);
            this.menuFrmMethods.ResumeLayout(false);
            this.tblAddressType.ResumeLayout(false);
            this.tblCommMethod.ResumeLayout(false);
            this.tblSupplierInfoContact.ResumeLayout(false);
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

        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menu_Tax_Code_Info___;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuFrmMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Tax;
        protected cDataField dfsName;
        protected cBackgroundText labelName;
        public cChildTableOnTab tblAddressType;
        protected cColumn tblAddressType_colsSupplierId;
        protected cColumn tblAddressType_colsAddressId;
        protected cLookupColumnTypeCode tblAddressType_colsAddressTypeCode;
        protected cColumn tblAddressType_colsAddressTypeCodeDb;
        protected cCheckBoxColumn tblAddressType_colDefAddress;
        protected cColumn tblAddressType_colsParty;
        protected cCheckBoxColumn tblAddressType_colDefaultDomain;
        public cChildTableCommMethod tblCommMethod;
        protected cColumn tblCommMethod_coldValidFromOld;
        protected cColumn tblCommMethod_coldValidToOld;
        public cChildTableOnTab tblSupplierInfoContact;
        protected cColumn tblSupplierInfoContact_colsSupplierId;
        protected cColumn tblSupplierInfoContact_colsSupplierAddress;
        protected cColumn tblSupplierInfoContact_colsPersonId;
        protected cColumn tblSupplierInfoContact_colPersonInfoName;
        protected cColumn tblSupplierInfoContact_colPersonInfoTitle;
        protected cColumn tblSupplierInfoContact_colsContactAddress;
        protected cCheckBoxColumn tblSupplierInfoContact_colAddressPrimary;
        protected cCheckBoxColumn tblSupplierInfoContact_colAddressSecondary;
        protected cCheckBoxColumn tblSupplierInfoContact_colSupplierPrimary;
        protected cCheckBoxColumn tblSupplierInfoContact_colSupplierSecondary;
        protected cColumn tblSupplierInfoContact_colPersonInfoAddressPhone;
        protected cColumn tblSupplierInfoContact_colPersonInfoAddressMobile;
        protected cColumn tblSupplierInfoContact_colPersonInfoAddressE_Mail;
        protected cColumn tblSupplierInfoContact_colPersonInfoAddressFax;
        protected cColumn tblSupplierInfoContact_colPersonInfoAddressPager;
        protected cColumn tblSupplierInfoContact_colPersonInfoAddressIntercom;
        protected cColumn tblSupplierInfoContact_colNoteText;
        protected cMultiSelectionColumn tblSupplierInfoContact_colsRole;
        protected cColumn tblSupplierInfoContact_colPersonInfoAddressWww;
        protected cColumn tblSupplierInfoContact_colsMainRepresentativeId;
        protected cColumn tblSupplierInfoContact_colsMainRepresentativeName;
        protected cLookupColumn tblSupplierInfoContact_colsDepartment;
        public cDataField dfsAddress3;
        public cDataField dfsAddress4;
        public cDataField dfsAddress5;
        public cDataField dfsAddress6;
        public cBackgroundText labeldfsAddress3;
        public cBackgroundText labeldfsAddress4;
        protected cBackgroundText labeldfsAddress5;
        protected cBackgroundText labeldfsAddress6;
        protected cCheckBoxColumn tblSupplierInfoContact_colsConnectAllSuppAddrDb;
        protected cDataField dfsSupplierBranch;
        protected cBackgroundText labelSupplierBranch;
	}
}
