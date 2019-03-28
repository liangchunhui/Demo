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
// 150708    Maabse  BLU-879, Added tblCustomerInfoContact_colsMainRepresentativeId and colsMainRepresentativeName.
// 130115    MaRalk  PBR-1203, Removed LOV reference CUSTOMER_INFO in dfsCustomerId and tblCustomerInfoContact-colsCustomerId.
// 121221    Nirplk  Merged Bug 106346.
// 121023    MaRalk  PBR-561, Added End customer Id and Address information.
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
	
	public partial class frmCustomerInfoAddress
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		protected cBackgroundText labelcmbAddressId;
		public cRecSelExtComboBox cmbAddressId;
		protected cBackgroundText labeldfsEanLocation;
		public cDataField dfsEanLocation;
		protected cBackgroundText labelcmbCountry;
		public cComboBox cmbCountry;
		protected cBackgroundText labelamlAddress;
		public cAddressMultilineField amlAddress;
		public cCheckBox cbWithinCityLimit;
		protected cBackgroundText labeldfsJurisdictionCode;
		public cDataField dfsJurisdictionCode;
		protected cBackgroundText labeldfdValidFrom;
		public cDataField dfdValidFrom;
		protected cBackgroundText labeldfdValidTo;
		public cDataField dfdValidTo;
		protected cBackgroundText labeldfsPrimaryContact;
		public cDataField dfsPrimaryContact;
		protected cBackgroundText labeldfsSecondaryContact;
        public cDataField dfsSecondaryContact;
		protected cBackgroundText labeltblCommMethod;
        protected cBackgroundText labeltblCustomerInfoContact;
		protected cBackgroundText labeldfsAddress1;
		public cDataField dfsAddress1;
		protected cBackgroundText labeldfsAddress2;
		public cDataField dfsAddress2;
		protected cBackgroundText labeldfsZipCode;
		public cDataField dfsZipCode;
		protected cBackgroundText labeldfsCounty;
		public cDataField dfsCounty;
		protected cBackgroundText labeldfsState;
		public cDataField dfsState;
		protected cBackgroundText labeldfsCountryCode;
		public cDataField dfsCountryCode;
		public cDataField dfsCustomerId;
		protected cBackgroundText labeldfsCity;
		public cDataField dfsCity;
		public cCheckBox cbDefaultDomain;
		public cComboBox cmbPartyType;
		public cDataField dfsParty;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomerInfoAddress));
            this.tblCommMethod = new Ifs.Application.Enterp.cChildTableCommMethod();
            this.tblCommMethod_coldValidFromOld = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblCommMethod_coldValidToOld = new Ifs.Fnd.ApplicationForms.cColumn();
            this.labelcmbAddressId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbAddressId = new Ifs.Fnd.ApplicationForms.cRecSelExtComboBox();
            this.labeldfsEanLocation = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsEanLocation = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelcmbCountry = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbCountry = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.labelamlAddress = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.amlAddress = new Ifs.Fnd.ApplicationForms.cAddressMultilineField();
            this.cbWithinCityLimit = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.labeldfsJurisdictionCode = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsJurisdictionCode = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfdValidFrom = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfdValidFrom = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfdValidTo = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfdValidTo = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsPrimaryContact = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsPrimaryContact = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsSecondaryContact = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsSecondaryContact = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeltblCommMethod = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.labeltblCustomerInfoContact = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.labeldfsAddress1 = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsAddress1 = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsAddress2 = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsAddress2 = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsZipCode = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsZipCode = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsCounty = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsCounty = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsState = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsState = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsCountryCode = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsCountryCode = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsCustomerId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsCity = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsCity = new Ifs.Fnd.ApplicationForms.cDataField();
            this.cbDefaultDomain = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.cmbPartyType = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.dfsParty = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsName = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelName = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.gbEnd_Customer = new Ifs.Fnd.ApplicationForms.cGroupBox();
            this.dfsEndCustomerName = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelEndCustomerName = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsEndCustAddrId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelEndCustAddrId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsEndCustomerId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelEndCustomerId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsAddress3 = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelAddress3 = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsAddress4 = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelAddress4 = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsAddress5 = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelAddress5 = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsAddress6 = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelAddress6 = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsCustomerBranch = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelCustomerBranch = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.tblCustomerInfoContact = new Ifs.Application.Enterp.cChildTableOnTab();
            this.tblCustomerInfoContact_colsCustomerId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblCustomerInfoContact_colsCustomerAddress = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblCustomerInfoContact_colsPersonId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblCustomerInfoContact_colPersonInfoName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblCustomerInfoContact_colPersonInfoTitle = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblCustomerInfoContact_colsRole = new Ifs.Fnd.ApplicationForms.cMultiSelectionColumn();
            this.tblCustomerInfoContact_colsContactAddress = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblCustomerInfoContact_colsBlockedForCrmObjectsDb = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.tblCustomerInfoContact_colsMainRepresentativeId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblCustomerInfoContact_colsMainRepresentativeName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblCustomerInfoContact_colsPersonalInterest = new Ifs.Fnd.ApplicationForms.cMultiSelectionColumn();
            this.tblCustomerInfoContact_colsCampaignInterest = new Ifs.Fnd.ApplicationForms.cMultiSelectionColumn();
            this.tblCustomerInfoContact_colsDecisionPowerType = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.tblCustomerInfoContact_colsDepartment = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.tblCustomerInfoContact_colsManager = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblCustomerInfoContact_colsManagerName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblCustomerInfoContact_colsManagerGuid = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblCustomerInfoContact_colsManagerCustAddress = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblCustomerInfoContact_colsConnectAllCustAddrDb = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.tblCustomerInfoContact_colAddressPrimary = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.tblCustomerInfoContact_colAddressSecondary = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.tblCustomerInfoContact_colCustomerPrimary = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.tblCustomerInfoContact_colCustomerSecondary = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.tblCustomerInfoContact_colPersonInfoAddressPhone = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblCustomerInfoContact_colPersonInfoAddressMobile = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblCustomerInfoContact_colPersonInfoAddressE_Mail = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblCustomerInfoContact_colPersonInfoAddressFax = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblCustomerInfoContact_colPersonInfoAddressPager = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblCustomerInfoContact_colPersonInfoAddressIntercom = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblCustomerInfoContact_colNoteText = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblAddressType = new Ifs.Application.Enterp.cChildTableOnTab();
            this.tblAddressType_colsCustomerId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblAddressType_colsAddressId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblAddressType_colsAddressTypeCode = new Ifs.Application.Enterp.cLookupColumnTypeCode();
            this.tblAddressType_colsAddressTypeCodeDb = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblAddressType_colDefAddress = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.tblAddressType_colsParty = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblAddressType_colDefaultDomain = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.tblCommMethod.SuspendLayout();
            this.gbEnd_Customer.SuspendLayout();
            this.tblCustomerInfoContact.SuspendLayout();
            this.tblAddressType.SuspendLayout();
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
            this.commandManager.ImageList = null;
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
            this.picTab.SetControlTabPages(this.tblCommMethod, "Name0");
            resources.ApplyResources(this.tblCommMethod, "tblCommMethod");
            this.tblCommMethod.Name = "tblCommMethod";
            this.tblCommMethod.NamedProperties.Put("DefaultOrderBy", "");
            this.tblCommMethod.NamedProperties.Put("DefaultWhere", "PARTY_TYPE_DB = \'CUSTOMER\' AND\r\nIDENTITY = :i_hWndFrame.frmCustomerInfoAddress.df" +
        "sCustomerId AND\r\nADDRESS_ID = :i_hWndFrame.frmCustomerInfoAddress.cmbAddressId.i" +
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
            this.dfsEanLocation.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsEanLocation.NamedProperties.Put("SqlColumn", "EAN_LOCATION");
            this.dfsEanLocation.NamedProperties.Put("ValidateMethod", "");
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
            // cbWithinCityLimit
            // 
            resources.ApplyResources(this.cbWithinCityLimit, "cbWithinCityLimit");
            this.cbWithinCityLimit.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.cbWithinCityLimit, "Name0");
            this.cbWithinCityLimit.Name = "cbWithinCityLimit";
            this.cbWithinCityLimit.NamedProperties.Put("DataType", "5");
            this.cbWithinCityLimit.NamedProperties.Put("EnumerateMethod", "");
            this.cbWithinCityLimit.NamedProperties.Put("FieldFlags", "295");
            this.cbWithinCityLimit.NamedProperties.Put("LovReference", "");
            this.cbWithinCityLimit.NamedProperties.Put("ResizeableChildObject", "");
            this.cbWithinCityLimit.NamedProperties.Put("SqlColumn", "IN_CITY");
            this.cbWithinCityLimit.NamedProperties.Put("ValidateMethod", "");
            this.cbWithinCityLimit.NamedProperties.Put("XDataLength", "5");
            this.cbWithinCityLimit.UseVisualStyleBackColor = false;
            // 
            // labeldfsJurisdictionCode
            // 
            resources.ApplyResources(this.labeldfsJurisdictionCode, "labeldfsJurisdictionCode");
            this.labeldfsJurisdictionCode.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfsJurisdictionCode, "Name0");
            this.labeldfsJurisdictionCode.Name = "labeldfsJurisdictionCode";
            // 
            // dfsJurisdictionCode
            // 
            this.picTab.SetControlTabPages(this.dfsJurisdictionCode, "Name0");
            resources.ApplyResources(this.dfsJurisdictionCode, "dfsJurisdictionCode");
            this.dfsJurisdictionCode.Name = "dfsJurisdictionCode";
            this.dfsJurisdictionCode.NamedProperties.Put("EnumerateMethod", "");
            this.dfsJurisdictionCode.NamedProperties.Put("FieldFlags", "288");
            this.dfsJurisdictionCode.NamedProperties.Put("LovReference", "");
            this.dfsJurisdictionCode.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsJurisdictionCode.NamedProperties.Put("SqlColumn", "JURISDICTION_CODE");
            this.dfsJurisdictionCode.NamedProperties.Put("ValidateMethod", "");
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
            // labeldfsPrimaryContact
            // 
            resources.ApplyResources(this.labeldfsPrimaryContact, "labeldfsPrimaryContact");
            this.labeldfsPrimaryContact.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfsPrimaryContact, "Name0");
            this.labeldfsPrimaryContact.Name = "labeldfsPrimaryContact";
            // 
            // dfsPrimaryContact
            // 
            this.picTab.SetControlTabPages(this.dfsPrimaryContact, "Name0");
            resources.ApplyResources(this.dfsPrimaryContact, "dfsPrimaryContact");
            this.dfsPrimaryContact.Name = "dfsPrimaryContact";
            this.dfsPrimaryContact.NamedProperties.Put("EnumerateMethod", "");
            this.dfsPrimaryContact.NamedProperties.Put("FieldFlags", "294");
            this.dfsPrimaryContact.NamedProperties.Put("LovReference", "");
            this.dfsPrimaryContact.NamedProperties.Put("SqlColumn", "PRIMARY_CONTACT");
            // 
            // labeldfsSecondaryContact
            // 
            resources.ApplyResources(this.labeldfsSecondaryContact, "labeldfsSecondaryContact");
            this.labeldfsSecondaryContact.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfsSecondaryContact, "Name0");
            this.labeldfsSecondaryContact.Name = "labeldfsSecondaryContact";
            // 
            // dfsSecondaryContact
            // 
            this.picTab.SetControlTabPages(this.dfsSecondaryContact, "Name0");
            resources.ApplyResources(this.dfsSecondaryContact, "dfsSecondaryContact");
            this.dfsSecondaryContact.Name = "dfsSecondaryContact";
            this.dfsSecondaryContact.NamedProperties.Put("EnumerateMethod", "");
            this.dfsSecondaryContact.NamedProperties.Put("FieldFlags", "294");
            this.dfsSecondaryContact.NamedProperties.Put("LovReference", "");
            this.dfsSecondaryContact.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsSecondaryContact.NamedProperties.Put("SqlColumn", "SECONDARY_CONTACT");
            this.dfsSecondaryContact.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeltblCommMethod
            // 
            resources.ApplyResources(this.labeltblCommMethod, "labeltblCommMethod");
            this.labeltblCommMethod.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeltblCommMethod, "Name0");
            this.labeltblCommMethod.Name = "labeltblCommMethod";
            // 
            // labeltblCustomerInfoContact
            // 
            resources.ApplyResources(this.labeltblCustomerInfoContact, "labeltblCustomerInfoContact");
            this.labeltblCustomerInfoContact.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeltblCustomerInfoContact, "Name0");
            this.labeltblCustomerInfoContact.Name = "labeltblCustomerInfoContact";
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
            // dfsCustomerId
            // 
            this.dfsCustomerId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsCustomerId, "dfsCustomerId");
            this.dfsCustomerId.Name = "dfsCustomerId";
            this.dfsCustomerId.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCustomerId.NamedProperties.Put("FieldFlags", "67");
            this.dfsCustomerId.NamedProperties.Put("LovReference", "");
            this.dfsCustomerId.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsCustomerId.NamedProperties.Put("SqlColumn", "CUSTOMER_ID");
            this.dfsCustomerId.NamedProperties.Put("ValidateMethod", "");
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
            // gbEnd_Customer
            // 
            this.gbEnd_Customer.Controls.Add(this.dfsEndCustomerName);
            this.gbEnd_Customer.Controls.Add(this.labelEndCustomerName);
            this.gbEnd_Customer.Controls.Add(this.dfsEndCustAddrId);
            this.gbEnd_Customer.Controls.Add(this.labelEndCustAddrId);
            this.gbEnd_Customer.Controls.Add(this.dfsEndCustomerId);
            this.gbEnd_Customer.Controls.Add(this.labelEndCustomerId);
            resources.ApplyResources(this.gbEnd_Customer, "gbEnd_Customer");
            this.gbEnd_Customer.Name = "gbEnd_Customer";
            this.gbEnd_Customer.TabStop = false;
            // 
            // dfsEndCustomerName
            // 
            resources.ApplyResources(this.dfsEndCustomerName, "dfsEndCustomerName");
            this.dfsEndCustomerName.Name = "dfsEndCustomerName";
            this.dfsEndCustomerName.NamedProperties.Put("EnumerateMethod", "");
            this.dfsEndCustomerName.NamedProperties.Put("FieldFlags", "288");
            this.dfsEndCustomerName.NamedProperties.Put("LovReference", "");
            this.dfsEndCustomerName.NamedProperties.Put("ParentName", "dfsEndCustomerId");
            this.dfsEndCustomerName.NamedProperties.Put("SqlColumn", "Customer_Info_API.Get_Name(END_CUSTOMER_ID)");
            // 
            // labelEndCustomerName
            // 
            resources.ApplyResources(this.labelEndCustomerName, "labelEndCustomerName");
            this.labelEndCustomerName.Name = "labelEndCustomerName";
            // 
            // dfsEndCustAddrId
            // 
            this.dfsEndCustAddrId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsEndCustAddrId, "dfsEndCustAddrId");
            this.dfsEndCustAddrId.Name = "dfsEndCustAddrId";
            this.dfsEndCustAddrId.NamedProperties.Put("EnumerateMethod", "");
            this.dfsEndCustAddrId.NamedProperties.Put("FieldFlags", "294");
            this.dfsEndCustAddrId.NamedProperties.Put("LovReference", "CUSTOMER_INFO_ADDR_DEL_PUB_LOV(END_CUSTOMER_ID)");
            this.dfsEndCustAddrId.NamedProperties.Put("SqlColumn", "END_CUST_ADDR_ID");
            this.dfsEndCustAddrId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsEndCustAddrId_WindowActions);
            // 
            // labelEndCustAddrId
            // 
            resources.ApplyResources(this.labelEndCustAddrId, "labelEndCustAddrId");
            this.labelEndCustAddrId.Name = "labelEndCustAddrId";
            // 
            // dfsEndCustomerId
            // 
            this.dfsEndCustomerId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsEndCustomerId, "dfsEndCustomerId");
            this.dfsEndCustomerId.Name = "dfsEndCustomerId";
            this.dfsEndCustomerId.NamedProperties.Put("EnumerateMethod", "");
            this.dfsEndCustomerId.NamedProperties.Put("FieldFlags", "294");
            this.dfsEndCustomerId.NamedProperties.Put("LovReference", "CUSTOMER_INFO");
            this.dfsEndCustomerId.NamedProperties.Put("ParentName", "cmbAddressId");
            this.dfsEndCustomerId.NamedProperties.Put("SqlColumn", "END_CUSTOMER_ID");
            this.dfsEndCustomerId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsEndCustomerId_WindowActions);
            // 
            // labelEndCustomerId
            // 
            resources.ApplyResources(this.labelEndCustomerId, "labelEndCustomerId");
            this.labelEndCustomerId.Name = "labelEndCustomerId";
            // 
            // dfsAddress3
            // 
            this.picTab.SetControlTabPages(this.dfsAddress3, "Name0");
            resources.ApplyResources(this.dfsAddress3, "dfsAddress3");
            this.dfsAddress3.Name = "dfsAddress3";
            this.dfsAddress3.NamedProperties.Put("EnumerateMethod", "");
            this.dfsAddress3.NamedProperties.Put("FieldFlags", "294");
            this.dfsAddress3.NamedProperties.Put("LovReference", "");
            this.dfsAddress3.NamedProperties.Put("SqlColumn", "ADDRESS3");
            // 
            // labelAddress3
            // 
            resources.ApplyResources(this.labelAddress3, "labelAddress3");
            this.picTab.SetControlTabPages(this.labelAddress3, "Name0");
            this.labelAddress3.Name = "labelAddress3";
            // 
            // dfsAddress4
            // 
            this.picTab.SetControlTabPages(this.dfsAddress4, "Name0");
            resources.ApplyResources(this.dfsAddress4, "dfsAddress4");
            this.dfsAddress4.Name = "dfsAddress4";
            this.dfsAddress4.NamedProperties.Put("EnumerateMethod", "");
            this.dfsAddress4.NamedProperties.Put("FieldFlags", "294");
            this.dfsAddress4.NamedProperties.Put("LovReference", "");
            this.dfsAddress4.NamedProperties.Put("SqlColumn", "ADDRESS4");
            // 
            // labelAddress4
            // 
            resources.ApplyResources(this.labelAddress4, "labelAddress4");
            this.picTab.SetControlTabPages(this.labelAddress4, "Name0");
            this.labelAddress4.Name = "labelAddress4";
            // 
            // dfsAddress5
            // 
            this.picTab.SetControlTabPages(this.dfsAddress5, "Name0");
            resources.ApplyResources(this.dfsAddress5, "dfsAddress5");
            this.dfsAddress5.Name = "dfsAddress5";
            this.dfsAddress5.NamedProperties.Put("EnumerateMethod", "");
            this.dfsAddress5.NamedProperties.Put("FieldFlags", "294");
            this.dfsAddress5.NamedProperties.Put("LovReference", "");
            this.dfsAddress5.NamedProperties.Put("SqlColumn", "ADDRESS5");
            // 
            // labelAddress5
            // 
            resources.ApplyResources(this.labelAddress5, "labelAddress5");
            this.picTab.SetControlTabPages(this.labelAddress5, "Name0");
            this.labelAddress5.Name = "labelAddress5";
            // 
            // dfsAddress6
            // 
            this.picTab.SetControlTabPages(this.dfsAddress6, "Name0");
            resources.ApplyResources(this.dfsAddress6, "dfsAddress6");
            this.dfsAddress6.Name = "dfsAddress6";
            this.dfsAddress6.NamedProperties.Put("EnumerateMethod", "");
            this.dfsAddress6.NamedProperties.Put("FieldFlags", "294");
            this.dfsAddress6.NamedProperties.Put("LovReference", "");
            this.dfsAddress6.NamedProperties.Put("SqlColumn", "ADDRESS6");
            // 
            // labelAddress6
            // 
            resources.ApplyResources(this.labelAddress6, "labelAddress6");
            this.picTab.SetControlTabPages(this.labelAddress6, "Name0");
            this.labelAddress6.Name = "labelAddress6";
            // 
            // dfsCustomerBranch
            // 
            this.dfsCustomerBranch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.picTab.SetControlTabPages(this.dfsCustomerBranch, "Name0");
            resources.ApplyResources(this.dfsCustomerBranch, "dfsCustomerBranch");
            this.dfsCustomerBranch.Name = "dfsCustomerBranch";
            this.dfsCustomerBranch.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCustomerBranch.NamedProperties.Put("FieldFlags", "294");
            this.dfsCustomerBranch.NamedProperties.Put("LovReference", "");
            this.dfsCustomerBranch.NamedProperties.Put("LovTimeReference", "");
            this.dfsCustomerBranch.NamedProperties.Put("SqlColumn", "CUSTOMER_BRANCH");
            // 
            // labelCustomerBranch
            // 
            resources.ApplyResources(this.labelCustomerBranch, "labelCustomerBranch");
            this.picTab.SetControlTabPages(this.labelCustomerBranch, "Name0");
            this.labelCustomerBranch.Name = "labelCustomerBranch";
            // 
            // tblCustomerInfoContact
            // 
            this.tblCustomerInfoContact.Controls.Add(this.tblCustomerInfoContact_colsCustomerId);
            this.tblCustomerInfoContact.Controls.Add(this.tblCustomerInfoContact_colsCustomerAddress);
            this.tblCustomerInfoContact.Controls.Add(this.tblCustomerInfoContact_colsPersonId);
            this.tblCustomerInfoContact.Controls.Add(this.tblCustomerInfoContact_colPersonInfoName);
            this.tblCustomerInfoContact.Controls.Add(this.tblCustomerInfoContact_colPersonInfoTitle);
            this.tblCustomerInfoContact.Controls.Add(this.tblCustomerInfoContact_colsRole);
            this.tblCustomerInfoContact.Controls.Add(this.tblCustomerInfoContact_colsContactAddress);
            this.tblCustomerInfoContact.Controls.Add(this.tblCustomerInfoContact_colsBlockedForCrmObjectsDb);
            this.tblCustomerInfoContact.Controls.Add(this.tblCustomerInfoContact_colsMainRepresentativeId);
            this.tblCustomerInfoContact.Controls.Add(this.tblCustomerInfoContact_colsMainRepresentativeName);
            this.tblCustomerInfoContact.Controls.Add(this.tblCustomerInfoContact_colsPersonalInterest);
            this.tblCustomerInfoContact.Controls.Add(this.tblCustomerInfoContact_colsCampaignInterest);
            this.tblCustomerInfoContact.Controls.Add(this.tblCustomerInfoContact_colsDecisionPowerType);
            this.tblCustomerInfoContact.Controls.Add(this.tblCustomerInfoContact_colsDepartment);
            this.tblCustomerInfoContact.Controls.Add(this.tblCustomerInfoContact_colsManager);
            this.tblCustomerInfoContact.Controls.Add(this.tblCustomerInfoContact_colsManagerName);
            this.tblCustomerInfoContact.Controls.Add(this.tblCustomerInfoContact_colsManagerGuid);
            this.tblCustomerInfoContact.Controls.Add(this.tblCustomerInfoContact_colsManagerCustAddress);
            this.tblCustomerInfoContact.Controls.Add(this.tblCustomerInfoContact_colsConnectAllCustAddrDb);
            this.tblCustomerInfoContact.Controls.Add(this.tblCustomerInfoContact_colAddressPrimary);
            this.tblCustomerInfoContact.Controls.Add(this.tblCustomerInfoContact_colAddressSecondary);
            this.tblCustomerInfoContact.Controls.Add(this.tblCustomerInfoContact_colCustomerPrimary);
            this.tblCustomerInfoContact.Controls.Add(this.tblCustomerInfoContact_colCustomerSecondary);
            this.tblCustomerInfoContact.Controls.Add(this.tblCustomerInfoContact_colPersonInfoAddressPhone);
            this.tblCustomerInfoContact.Controls.Add(this.tblCustomerInfoContact_colPersonInfoAddressMobile);
            this.tblCustomerInfoContact.Controls.Add(this.tblCustomerInfoContact_colPersonInfoAddressE_Mail);
            this.tblCustomerInfoContact.Controls.Add(this.tblCustomerInfoContact_colPersonInfoAddressFax);
            this.tblCustomerInfoContact.Controls.Add(this.tblCustomerInfoContact_colPersonInfoAddressPager);
            this.tblCustomerInfoContact.Controls.Add(this.tblCustomerInfoContact_colPersonInfoAddressIntercom);
            this.tblCustomerInfoContact.Controls.Add(this.tblCustomerInfoContact_colNoteText);
            this.picTab.SetControlTabPages(this.tblCustomerInfoContact, "Name0");
            resources.ApplyResources(this.tblCustomerInfoContact, "tblCustomerInfoContact");
            this.tblCustomerInfoContact.Name = "tblCustomerInfoContact";
            this.tblCustomerInfoContact.NamedProperties.Put("DefaultOrderBy", "");
            this.tblCustomerInfoContact.NamedProperties.Put("DefaultWhere", "CUSTOMER_ID = :i_hWndFrame.frmCustomerInfoAddress.dfsCustomerId AND (CUSTOMER_ADD" +
        "RESS = :i_hWndFrame.frmCustomerInfoAddress.cmbAddressId.i_sMyValue OR CONNECT_AL" +
        "L_CUST_ADDR_DB = \'TRUE\')");
            this.tblCustomerInfoContact.NamedProperties.Put("LogicalUnit", "CustomerInfoContact");
            this.tblCustomerInfoContact.NamedProperties.Put("PackageName", "CUSTOMER_INFO_CONTACT_API");
            this.tblCustomerInfoContact.NamedProperties.Put("ResizeableChildObject", "LLMR");
            this.tblCustomerInfoContact.NamedProperties.Put("ViewName", "CUSTOMER_INFO_CONTACT");
            this.tblCustomerInfoContact.NamedProperties.Put("Warnings", "FALSE");
            this.tblCustomerInfoContact.DataRecordExecuteNewEvent += new Ifs.Fnd.ApplicationForms.cDataSource.DataRecordExecuteNewEventHandler(this.tblCustomerInfoContact_DataRecordExecuteNewEvent);
            this.tblCustomerInfoContact.DataRecordFetchEditedUserEvent += new Ifs.Fnd.ApplicationForms.cDataSource.DataRecordFetchEditedUserEventHandler(this.tblCustomerInfoContact_DataRecordFetchEditedUserEvent);
            this.tblCustomerInfoContact.Controls.SetChildIndex(this.tblCustomerInfoContact_colNoteText, 0);
            this.tblCustomerInfoContact.Controls.SetChildIndex(this.tblCustomerInfoContact_colPersonInfoAddressIntercom, 0);
            this.tblCustomerInfoContact.Controls.SetChildIndex(this.tblCustomerInfoContact_colPersonInfoAddressPager, 0);
            this.tblCustomerInfoContact.Controls.SetChildIndex(this.tblCustomerInfoContact_colPersonInfoAddressFax, 0);
            this.tblCustomerInfoContact.Controls.SetChildIndex(this.tblCustomerInfoContact_colPersonInfoAddressE_Mail, 0);
            this.tblCustomerInfoContact.Controls.SetChildIndex(this.tblCustomerInfoContact_colPersonInfoAddressMobile, 0);
            this.tblCustomerInfoContact.Controls.SetChildIndex(this.tblCustomerInfoContact_colPersonInfoAddressPhone, 0);
            this.tblCustomerInfoContact.Controls.SetChildIndex(this.tblCustomerInfoContact_colCustomerSecondary, 0);
            this.tblCustomerInfoContact.Controls.SetChildIndex(this.tblCustomerInfoContact_colCustomerPrimary, 0);
            this.tblCustomerInfoContact.Controls.SetChildIndex(this.tblCustomerInfoContact_colAddressSecondary, 0);
            this.tblCustomerInfoContact.Controls.SetChildIndex(this.tblCustomerInfoContact_colAddressPrimary, 0);
            this.tblCustomerInfoContact.Controls.SetChildIndex(this.tblCustomerInfoContact_colsConnectAllCustAddrDb, 0);
            this.tblCustomerInfoContact.Controls.SetChildIndex(this.tblCustomerInfoContact_colsManagerCustAddress, 0);
            this.tblCustomerInfoContact.Controls.SetChildIndex(this.tblCustomerInfoContact_colsManagerGuid, 0);
            this.tblCustomerInfoContact.Controls.SetChildIndex(this.tblCustomerInfoContact_colsManagerName, 0);
            this.tblCustomerInfoContact.Controls.SetChildIndex(this.tblCustomerInfoContact_colsManager, 0);
            this.tblCustomerInfoContact.Controls.SetChildIndex(this.tblCustomerInfoContact_colsDepartment, 0);
            this.tblCustomerInfoContact.Controls.SetChildIndex(this.tblCustomerInfoContact_colsDecisionPowerType, 0);
            this.tblCustomerInfoContact.Controls.SetChildIndex(this.tblCustomerInfoContact_colsCampaignInterest, 0);
            this.tblCustomerInfoContact.Controls.SetChildIndex(this.tblCustomerInfoContact_colsPersonalInterest, 0);
            this.tblCustomerInfoContact.Controls.SetChildIndex(this.tblCustomerInfoContact_colsMainRepresentativeName, 0);
            this.tblCustomerInfoContact.Controls.SetChildIndex(this.tblCustomerInfoContact_colsMainRepresentativeId, 0);
            this.tblCustomerInfoContact.Controls.SetChildIndex(this.tblCustomerInfoContact_colsBlockedForCrmObjectsDb, 0);
            this.tblCustomerInfoContact.Controls.SetChildIndex(this.tblCustomerInfoContact_colsContactAddress, 0);
            this.tblCustomerInfoContact.Controls.SetChildIndex(this.tblCustomerInfoContact_colsRole, 0);
            this.tblCustomerInfoContact.Controls.SetChildIndex(this.tblCustomerInfoContact_colPersonInfoTitle, 0);
            this.tblCustomerInfoContact.Controls.SetChildIndex(this.tblCustomerInfoContact_colPersonInfoName, 0);
            this.tblCustomerInfoContact.Controls.SetChildIndex(this.tblCustomerInfoContact_colsPersonId, 0);
            this.tblCustomerInfoContact.Controls.SetChildIndex(this.tblCustomerInfoContact_colsCustomerAddress, 0);
            this.tblCustomerInfoContact.Controls.SetChildIndex(this.tblCustomerInfoContact_colsCustomerId, 0);
            // 
            // tblCustomerInfoContact_colsCustomerId
            // 
            this.tblCustomerInfoContact_colsCustomerId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblCustomerInfoContact_colsCustomerId, "tblCustomerInfoContact_colsCustomerId");
            this.tblCustomerInfoContact_colsCustomerId.MaxLength = 20;
            this.tblCustomerInfoContact_colsCustomerId.Name = "tblCustomerInfoContact_colsCustomerId";
            this.tblCustomerInfoContact_colsCustomerId.NamedProperties.Put("EnumerateMethod", "");
            this.tblCustomerInfoContact_colsCustomerId.NamedProperties.Put("FieldFlags", "67");
            this.tblCustomerInfoContact_colsCustomerId.NamedProperties.Put("LovReference", "");
            this.tblCustomerInfoContact_colsCustomerId.NamedProperties.Put("SqlColumn", "CUSTOMER_ID");
            this.tblCustomerInfoContact_colsCustomerId.Position = 3;
            // 
            // tblCustomerInfoContact_colsCustomerAddress
            // 
            this.tblCustomerInfoContact_colsCustomerAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblCustomerInfoContact_colsCustomerAddress, "tblCustomerInfoContact_colsCustomerAddress");
            this.tblCustomerInfoContact_colsCustomerAddress.MaxLength = 50;
            this.tblCustomerInfoContact_colsCustomerAddress.Name = "tblCustomerInfoContact_colsCustomerAddress";
            this.tblCustomerInfoContact_colsCustomerAddress.NamedProperties.Put("EnumerateMethod", "");
            this.tblCustomerInfoContact_colsCustomerAddress.NamedProperties.Put("FieldFlags", "102");
            this.tblCustomerInfoContact_colsCustomerAddress.NamedProperties.Put("LovReference", "CUSTOMER_INFO_ADDRESS(CUSTOMER_ID)");
            this.tblCustomerInfoContact_colsCustomerAddress.NamedProperties.Put("ResizeableChildObject", "");
            this.tblCustomerInfoContact_colsCustomerAddress.NamedProperties.Put("SqlColumn", "CUSTOMER_ADDRESS");
            this.tblCustomerInfoContact_colsCustomerAddress.NamedProperties.Put("ValidateMethod", "");
            this.tblCustomerInfoContact_colsCustomerAddress.Position = 4;
            // 
            // tblCustomerInfoContact_colsPersonId
            // 
            this.tblCustomerInfoContact_colsPersonId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblCustomerInfoContact_colsPersonId.MaxLength = 20;
            this.tblCustomerInfoContact_colsPersonId.Name = "tblCustomerInfoContact_colsPersonId";
            this.tblCustomerInfoContact_colsPersonId.NamedProperties.Put("EnumerateMethod", "");
            this.tblCustomerInfoContact_colsPersonId.NamedProperties.Put("FieldFlags", "67");
            this.tblCustomerInfoContact_colsPersonId.NamedProperties.Put("LovReference", "PERSON_INFO_ALL");
            this.tblCustomerInfoContact_colsPersonId.NamedProperties.Put("SqlColumn", "PERSON_ID");
            this.tblCustomerInfoContact_colsPersonId.NamedProperties.Put("ValidateMethod", "");
            this.tblCustomerInfoContact_colsPersonId.Position = 5;
            resources.ApplyResources(this.tblCustomerInfoContact_colsPersonId, "tblCustomerInfoContact_colsPersonId");
            this.tblCustomerInfoContact_colsPersonId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblCustomerInfoContact_colsPersonId_WindowActions);
            // 
            // tblCustomerInfoContact_colPersonInfoName
            // 
            this.tblCustomerInfoContact_colPersonInfoName.MaxLength = 2000;
            this.tblCustomerInfoContact_colPersonInfoName.Name = "tblCustomerInfoContact_colPersonInfoName";
            this.tblCustomerInfoContact_colPersonInfoName.NamedProperties.Put("EnumerateMethod", "");
            this.tblCustomerInfoContact_colPersonInfoName.NamedProperties.Put("FieldFlags", "304");
            this.tblCustomerInfoContact_colPersonInfoName.NamedProperties.Put("LovReference", "");
            this.tblCustomerInfoContact_colPersonInfoName.NamedProperties.Put("ParentName", "tblCustomerInfoContact.tblCustomerInfoContact_colsPersonId");
            this.tblCustomerInfoContact_colPersonInfoName.NamedProperties.Put("ResizeableChildObject", "");
            this.tblCustomerInfoContact_colPersonInfoName.NamedProperties.Put("SqlColumn", "PERSON_INFO_API.Get_Name(PERSON_ID)");
            this.tblCustomerInfoContact_colPersonInfoName.NamedProperties.Put("ValidateMethod", "");
            this.tblCustomerInfoContact_colPersonInfoName.Position = 6;
            resources.ApplyResources(this.tblCustomerInfoContact_colPersonInfoName, "tblCustomerInfoContact_colPersonInfoName");
            // 
            // tblCustomerInfoContact_colPersonInfoTitle
            // 
            this.tblCustomerInfoContact_colPersonInfoTitle.MaxLength = 2000;
            this.tblCustomerInfoContact_colPersonInfoTitle.Name = "tblCustomerInfoContact_colPersonInfoTitle";
            this.tblCustomerInfoContact_colPersonInfoTitle.NamedProperties.Put("EnumerateMethod", "");
            this.tblCustomerInfoContact_colPersonInfoTitle.NamedProperties.Put("FieldFlags", "304");
            this.tblCustomerInfoContact_colPersonInfoTitle.NamedProperties.Put("LovReference", "");
            this.tblCustomerInfoContact_colPersonInfoTitle.NamedProperties.Put("ParentName", "tblCustomerInfoContact.tblCustomerInfoContact_colsPersonId");
            this.tblCustomerInfoContact_colPersonInfoTitle.NamedProperties.Put("ResizeableChildObject", "");
            this.tblCustomerInfoContact_colPersonInfoTitle.NamedProperties.Put("SqlColumn", "PERSON_INFO_API.Get_Title(PERSON_ID)");
            this.tblCustomerInfoContact_colPersonInfoTitle.NamedProperties.Put("ValidateMethod", "");
            this.tblCustomerInfoContact_colPersonInfoTitle.Position = 7;
            resources.ApplyResources(this.tblCustomerInfoContact_colPersonInfoTitle, "tblCustomerInfoContact_colPersonInfoTitle");
            // 
            // tblCustomerInfoContact_colsRole
            // 
            this.tblCustomerInfoContact_colsRole.MaxLength = 4000;
            this.tblCustomerInfoContact_colsRole.Name = "tblCustomerInfoContact_colsRole";
            this.tblCustomerInfoContact_colsRole.NamedProperties.Put("EnumerateMethod", "CONTACT_ROLE_API.Enumerate");
            this.tblCustomerInfoContact_colsRole.NamedProperties.Put("FieldFlags", "294");
            this.tblCustomerInfoContact_colsRole.NamedProperties.Put("LovReference", "");
            this.tblCustomerInfoContact_colsRole.NamedProperties.Put("SqlColumn", "ROLE");
            this.tblCustomerInfoContact_colsRole.Position = 8;
            resources.ApplyResources(this.tblCustomerInfoContact_colsRole, "tblCustomerInfoContact_colsRole");
            // 
            // tblCustomerInfoContact_colsContactAddress
            // 
            this.tblCustomerInfoContact_colsContactAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblCustomerInfoContact_colsContactAddress.MaxLength = 50;
            this.tblCustomerInfoContact_colsContactAddress.Name = "tblCustomerInfoContact_colsContactAddress";
            this.tblCustomerInfoContact_colsContactAddress.NamedProperties.Put("EnumerateMethod", "");
            this.tblCustomerInfoContact_colsContactAddress.NamedProperties.Put("FieldFlags", "294");
            this.tblCustomerInfoContact_colsContactAddress.NamedProperties.Put("LovReference", "PERSON_INFO_ADDRESS1(PERSON_ID)");
            this.tblCustomerInfoContact_colsContactAddress.NamedProperties.Put("SqlColumn", "CONTACT_ADDRESS");
            this.tblCustomerInfoContact_colsContactAddress.Position = 9;
            resources.ApplyResources(this.tblCustomerInfoContact_colsContactAddress, "tblCustomerInfoContact_colsContactAddress");
            // 
            // tblCustomerInfoContact_colsBlockedForCrmObjectsDb
            // 
            this.tblCustomerInfoContact_colsBlockedForCrmObjectsDb.Name = "tblCustomerInfoContact_colsBlockedForCrmObjectsDb";
            this.tblCustomerInfoContact_colsBlockedForCrmObjectsDb.NamedProperties.Put("EnumerateMethod", "");
            this.tblCustomerInfoContact_colsBlockedForCrmObjectsDb.NamedProperties.Put("FieldFlags", "288");
            this.tblCustomerInfoContact_colsBlockedForCrmObjectsDb.NamedProperties.Put("LovReference", "");
            this.tblCustomerInfoContact_colsBlockedForCrmObjectsDb.NamedProperties.Put("SqlColumn", "BLOCKED_FOR_CRM_OBJECTS_DB");
            this.tblCustomerInfoContact_colsBlockedForCrmObjectsDb.Position = 10;
            resources.ApplyResources(this.tblCustomerInfoContact_colsBlockedForCrmObjectsDb, "tblCustomerInfoContact_colsBlockedForCrmObjectsDb");
            // 
            // tblCustomerInfoContact_colsMainRepresentativeId
            // 
            this.tblCustomerInfoContact_colsMainRepresentativeId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblCustomerInfoContact_colsMainRepresentativeId.MaxLength = 20;
            this.tblCustomerInfoContact_colsMainRepresentativeId.Name = "tblCustomerInfoContact_colsMainRepresentativeId";
            this.tblCustomerInfoContact_colsMainRepresentativeId.NamedProperties.Put("EnumerateMethod", "");
            this.tblCustomerInfoContact_colsMainRepresentativeId.NamedProperties.Put("FieldFlags", "290");
            this.tblCustomerInfoContact_colsMainRepresentativeId.NamedProperties.Put("LovReference", "BUSINESS_REPRESENTATIVE_LOV");
            this.tblCustomerInfoContact_colsMainRepresentativeId.NamedProperties.Put("SqlColumn", "MAIN_REPRESENTATIVE_ID");
            this.tblCustomerInfoContact_colsMainRepresentativeId.Position = 11;
            resources.ApplyResources(this.tblCustomerInfoContact_colsMainRepresentativeId, "tblCustomerInfoContact_colsMainRepresentativeId");
            this.tblCustomerInfoContact_colsMainRepresentativeId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblCustomerInfoContact_colsMainRepresentativeId_WindowActions);
            // 
            // tblCustomerInfoContact_colsMainRepresentativeName
            // 
            this.tblCustomerInfoContact_colsMainRepresentativeName.MaxLength = 2000;
            this.tblCustomerInfoContact_colsMainRepresentativeName.Name = "tblCustomerInfoContact_colsMainRepresentativeName";
            this.tblCustomerInfoContact_colsMainRepresentativeName.NamedProperties.Put("EnumerateMethod", "");
            this.tblCustomerInfoContact_colsMainRepresentativeName.NamedProperties.Put("FieldFlags", "288");
            this.tblCustomerInfoContact_colsMainRepresentativeName.NamedProperties.Put("LovReference", "");
            this.tblCustomerInfoContact_colsMainRepresentativeName.NamedProperties.Put("ParentName", "tblCustomerInfoContact.tblCustomerInfoContact_colsMainRepresentativeId");
            this.tblCustomerInfoContact_colsMainRepresentativeName.NamedProperties.Put("SqlColumn", "Person_Info_API.Get_Name(MAIN_REPRESENTATIVE_ID)");
            this.tblCustomerInfoContact_colsMainRepresentativeName.Position = 12;
            resources.ApplyResources(this.tblCustomerInfoContact_colsMainRepresentativeName, "tblCustomerInfoContact_colsMainRepresentativeName");
            // 
            // tblCustomerInfoContact_colsPersonalInterest
            // 
            this.tblCustomerInfoContact_colsPersonalInterest.IsLookup = true;
            this.tblCustomerInfoContact_colsPersonalInterest.MaxLength = 4000;
            this.tblCustomerInfoContact_colsPersonalInterest.Name = "tblCustomerInfoContact_colsPersonalInterest";
            this.tblCustomerInfoContact_colsPersonalInterest.NamedProperties.Put("EnumerateMethod", "PERSONAL_INTEREST_API.Enumerate");
            this.tblCustomerInfoContact_colsPersonalInterest.NamedProperties.Put("FieldFlags", "294");
            this.tblCustomerInfoContact_colsPersonalInterest.NamedProperties.Put("LovReference", "");
            this.tblCustomerInfoContact_colsPersonalInterest.NamedProperties.Put("SqlColumn", "PERSONAL_INTEREST");
            this.tblCustomerInfoContact_colsPersonalInterest.Position = 13;
            resources.ApplyResources(this.tblCustomerInfoContact_colsPersonalInterest, "tblCustomerInfoContact_colsPersonalInterest");
            // 
            // tblCustomerInfoContact_colsCampaignInterest
            // 
            this.tblCustomerInfoContact_colsCampaignInterest.IsLookup = true;
            this.tblCustomerInfoContact_colsCampaignInterest.MaxLength = 4000;
            this.tblCustomerInfoContact_colsCampaignInterest.Name = "tblCustomerInfoContact_colsCampaignInterest";
            this.tblCustomerInfoContact_colsCampaignInterest.NamedProperties.Put("EnumerateMethod", "BUSINESS_CAMPAIGN_INTEREST_API.Enumerate");
            this.tblCustomerInfoContact_colsCampaignInterest.NamedProperties.Put("FieldFlags", "294");
            this.tblCustomerInfoContact_colsCampaignInterest.NamedProperties.Put("LovReference", "");
            this.tblCustomerInfoContact_colsCampaignInterest.NamedProperties.Put("SqlColumn", "CAMPAIGN_INTEREST");
            this.tblCustomerInfoContact_colsCampaignInterest.Position = 14;
            resources.ApplyResources(this.tblCustomerInfoContact_colsCampaignInterest, "tblCustomerInfoContact_colsCampaignInterest");
            // 
            // tblCustomerInfoContact_colsDecisionPowerType
            // 
            this.tblCustomerInfoContact_colsDecisionPowerType.IsLookup = true;
            this.tblCustomerInfoContact_colsDecisionPowerType.MaxLength = 200;
            this.tblCustomerInfoContact_colsDecisionPowerType.Name = "tblCustomerInfoContact_colsDecisionPowerType";
            this.tblCustomerInfoContact_colsDecisionPowerType.NamedProperties.Put("EnumerateMethod", "DECISION_POWER_TYPE_API.Enumerate");
            this.tblCustomerInfoContact_colsDecisionPowerType.NamedProperties.Put("FieldFlags", "294");
            this.tblCustomerInfoContact_colsDecisionPowerType.NamedProperties.Put("LovReference", "");
            this.tblCustomerInfoContact_colsDecisionPowerType.NamedProperties.Put("SqlColumn", "DECISION_POWER_TYPE");
            this.tblCustomerInfoContact_colsDecisionPowerType.Position = 15;
            resources.ApplyResources(this.tblCustomerInfoContact_colsDecisionPowerType, "tblCustomerInfoContact_colsDecisionPowerType");
            // 
            // tblCustomerInfoContact_colsDepartment
            // 
            this.tblCustomerInfoContact_colsDepartment.IsLookup = true;
            this.tblCustomerInfoContact_colsDepartment.MaxLength = 200;
            this.tblCustomerInfoContact_colsDepartment.Name = "tblCustomerInfoContact_colsDepartment";
            this.tblCustomerInfoContact_colsDepartment.NamedProperties.Put("EnumerateMethod", "CONTACT_DEPARTMENT_API.Enumerate");
            this.tblCustomerInfoContact_colsDepartment.NamedProperties.Put("FieldFlags", "294");
            this.tblCustomerInfoContact_colsDepartment.NamedProperties.Put("LovReference", "");
            this.tblCustomerInfoContact_colsDepartment.NamedProperties.Put("SqlColumn", "DEPARTMENT");
            this.tblCustomerInfoContact_colsDepartment.Position = 16;
            resources.ApplyResources(this.tblCustomerInfoContact_colsDepartment, "tblCustomerInfoContact_colsDepartment");
            // 
            // tblCustomerInfoContact_colsManager
            // 
            this.tblCustomerInfoContact_colsManager.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblCustomerInfoContact_colsManager.MaxLength = 20;
            this.tblCustomerInfoContact_colsManager.Name = "tblCustomerInfoContact_colsManager";
            this.tblCustomerInfoContact_colsManager.NamedProperties.Put("EnumerateMethod", "");
            this.tblCustomerInfoContact_colsManager.NamedProperties.Put("FieldFlags", "294");
            this.tblCustomerInfoContact_colsManager.NamedProperties.Put("LovReference", "CUST_INFO_CONTACT_LOV2_PUB(CUSTOMER_ID)");
            this.tblCustomerInfoContact_colsManager.NamedProperties.Put("SqlColumn", "MANAGER");
            this.tblCustomerInfoContact_colsManager.Position = 17;
            resources.ApplyResources(this.tblCustomerInfoContact_colsManager, "tblCustomerInfoContact_colsManager");
            this.tblCustomerInfoContact_colsManager.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblCustomerInfoContact_colsManager_WindowActions);
            // 
            // tblCustomerInfoContact_colsManagerName
            // 
            this.tblCustomerInfoContact_colsManagerName.MaxLength = 2000;
            this.tblCustomerInfoContact_colsManagerName.Name = "tblCustomerInfoContact_colsManagerName";
            this.tblCustomerInfoContact_colsManagerName.NamedProperties.Put("EnumerateMethod", "");
            this.tblCustomerInfoContact_colsManagerName.NamedProperties.Put("FieldFlags", "288");
            this.tblCustomerInfoContact_colsManagerName.NamedProperties.Put("LovReference", "");
            this.tblCustomerInfoContact_colsManagerName.NamedProperties.Put("ParentName", "tblCustomerInfoContact.tblCustomerInfoContact_colsManager");
            this.tblCustomerInfoContact_colsManagerName.NamedProperties.Put("SqlColumn", "PERSON_INFO_API.Get_Name(MANAGER)");
            this.tblCustomerInfoContact_colsManagerName.Position = 18;
            resources.ApplyResources(this.tblCustomerInfoContact_colsManagerName, "tblCustomerInfoContact_colsManagerName");
            // 
            // tblCustomerInfoContact_colsManagerGuid
            // 
            this.tblCustomerInfoContact_colsManagerGuid.MaxLength = 50;
            this.tblCustomerInfoContact_colsManagerGuid.Name = "tblCustomerInfoContact_colsManagerGuid";
            this.tblCustomerInfoContact_colsManagerGuid.NamedProperties.Put("EnumerateMethod", "");
            this.tblCustomerInfoContact_colsManagerGuid.NamedProperties.Put("FieldFlags", "294");
            this.tblCustomerInfoContact_colsManagerGuid.NamedProperties.Put("LovReference", "");
            this.tblCustomerInfoContact_colsManagerGuid.NamedProperties.Put("SqlColumn", "MANAGER_GUID");
            this.tblCustomerInfoContact_colsManagerGuid.Position = 19;
            resources.ApplyResources(this.tblCustomerInfoContact_colsManagerGuid, "tblCustomerInfoContact_colsManagerGuid");
            // 
            // tblCustomerInfoContact_colsManagerCustAddress
            // 
            this.tblCustomerInfoContact_colsManagerCustAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblCustomerInfoContact_colsManagerCustAddress.MaxLength = 50;
            this.tblCustomerInfoContact_colsManagerCustAddress.Name = "tblCustomerInfoContact_colsManagerCustAddress";
            this.tblCustomerInfoContact_colsManagerCustAddress.NamedProperties.Put("EnumerateMethod", "");
            this.tblCustomerInfoContact_colsManagerCustAddress.NamedProperties.Put("FieldFlags", "294");
            this.tblCustomerInfoContact_colsManagerCustAddress.NamedProperties.Put("LovReference", "CUST_INFO_CONTACT_LOV2_PUB(CUSTOMER_ID)");
            this.tblCustomerInfoContact_colsManagerCustAddress.NamedProperties.Put("SqlColumn", "MANAGER_CUST_ADDRESS");
            this.tblCustomerInfoContact_colsManagerCustAddress.Position = 20;
            resources.ApplyResources(this.tblCustomerInfoContact_colsManagerCustAddress, "tblCustomerInfoContact_colsManagerCustAddress");
            this.tblCustomerInfoContact_colsManagerCustAddress.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblCustomerInfoContact_colsManagerCustAddress_WindowActions);
            // 
            // tblCustomerInfoContact_colsConnectAllCustAddrDb
            // 
            resources.ApplyResources(this.tblCustomerInfoContact_colsConnectAllCustAddrDb, "tblCustomerInfoContact_colsConnectAllCustAddrDb");
            this.tblCustomerInfoContact_colsConnectAllCustAddrDb.MaxLength = 20;
            this.tblCustomerInfoContact_colsConnectAllCustAddrDb.Name = "tblCustomerInfoContact_colsConnectAllCustAddrDb";
            this.tblCustomerInfoContact_colsConnectAllCustAddrDb.NamedProperties.Put("EnumerateMethod", "");
            this.tblCustomerInfoContact_colsConnectAllCustAddrDb.NamedProperties.Put("FieldFlags", "288");
            this.tblCustomerInfoContact_colsConnectAllCustAddrDb.NamedProperties.Put("LovReference", "");
            this.tblCustomerInfoContact_colsConnectAllCustAddrDb.NamedProperties.Put("LovTimeReference", "");
            this.tblCustomerInfoContact_colsConnectAllCustAddrDb.NamedProperties.Put("SqlColumn", "CONNECT_ALL_CUST_ADDR_DB");
            this.tblCustomerInfoContact_colsConnectAllCustAddrDb.Position = 21;
            // 
            // tblCustomerInfoContact_colAddressPrimary
            // 
            this.tblCustomerInfoContact_colAddressPrimary.Name = "tblCustomerInfoContact_colAddressPrimary";
            this.tblCustomerInfoContact_colAddressPrimary.NamedProperties.Put("EnumerateMethod", "");
            this.tblCustomerInfoContact_colAddressPrimary.NamedProperties.Put("FieldFlags", "295");
            this.tblCustomerInfoContact_colAddressPrimary.NamedProperties.Put("LovReference", "");
            this.tblCustomerInfoContact_colAddressPrimary.NamedProperties.Put("SqlColumn", "ADDRESS_PRIMARY");
            this.tblCustomerInfoContact_colAddressPrimary.Position = 22;
            resources.ApplyResources(this.tblCustomerInfoContact_colAddressPrimary, "tblCustomerInfoContact_colAddressPrimary");
            // 
            // tblCustomerInfoContact_colAddressSecondary
            // 
            this.tblCustomerInfoContact_colAddressSecondary.Name = "tblCustomerInfoContact_colAddressSecondary";
            this.tblCustomerInfoContact_colAddressSecondary.NamedProperties.Put("EnumerateMethod", "");
            this.tblCustomerInfoContact_colAddressSecondary.NamedProperties.Put("FieldFlags", "295");
            this.tblCustomerInfoContact_colAddressSecondary.NamedProperties.Put("LovReference", "");
            this.tblCustomerInfoContact_colAddressSecondary.NamedProperties.Put("SqlColumn", "ADDRESS_SECONDARY");
            this.tblCustomerInfoContact_colAddressSecondary.Position = 23;
            resources.ApplyResources(this.tblCustomerInfoContact_colAddressSecondary, "tblCustomerInfoContact_colAddressSecondary");
            // 
            // tblCustomerInfoContact_colCustomerPrimary
            // 
            this.tblCustomerInfoContact_colCustomerPrimary.Name = "tblCustomerInfoContact_colCustomerPrimary";
            this.tblCustomerInfoContact_colCustomerPrimary.NamedProperties.Put("EnumerateMethod", "");
            this.tblCustomerInfoContact_colCustomerPrimary.NamedProperties.Put("FieldFlags", "295");
            this.tblCustomerInfoContact_colCustomerPrimary.NamedProperties.Put("LovReference", "");
            this.tblCustomerInfoContact_colCustomerPrimary.NamedProperties.Put("SqlColumn", "CUSTOMER_PRIMARY");
            this.tblCustomerInfoContact_colCustomerPrimary.Position = 24;
            resources.ApplyResources(this.tblCustomerInfoContact_colCustomerPrimary, "tblCustomerInfoContact_colCustomerPrimary");
            // 
            // tblCustomerInfoContact_colCustomerSecondary
            // 
            this.tblCustomerInfoContact_colCustomerSecondary.Name = "tblCustomerInfoContact_colCustomerSecondary";
            this.tblCustomerInfoContact_colCustomerSecondary.NamedProperties.Put("EnumerateMethod", "");
            this.tblCustomerInfoContact_colCustomerSecondary.NamedProperties.Put("FieldFlags", "295");
            this.tblCustomerInfoContact_colCustomerSecondary.NamedProperties.Put("LovReference", "");
            this.tblCustomerInfoContact_colCustomerSecondary.NamedProperties.Put("SqlColumn", "CUSTOMER_SECONDARY");
            this.tblCustomerInfoContact_colCustomerSecondary.Position = 25;
            resources.ApplyResources(this.tblCustomerInfoContact_colCustomerSecondary, "tblCustomerInfoContact_colCustomerSecondary");
            // 
            // tblCustomerInfoContact_colPersonInfoAddressPhone
            // 
            this.tblCustomerInfoContact_colPersonInfoAddressPhone.MaxLength = 2000;
            this.tblCustomerInfoContact_colPersonInfoAddressPhone.Name = "tblCustomerInfoContact_colPersonInfoAddressPhone";
            this.tblCustomerInfoContact_colPersonInfoAddressPhone.NamedProperties.Put("EnumerateMethod", "");
            this.tblCustomerInfoContact_colPersonInfoAddressPhone.NamedProperties.Put("FieldFlags", "304");
            this.tblCustomerInfoContact_colPersonInfoAddressPhone.NamedProperties.Put("LovReference", "");
            this.tblCustomerInfoContact_colPersonInfoAddressPhone.NamedProperties.Put("ParentName", "tblCustomerInfoContact.tblCustomerInfoContact_colsContactAddress");
            this.tblCustomerInfoContact_colPersonInfoAddressPhone.NamedProperties.Put("SqlColumn", "Comm_Method_API.Get_Value(\'PERSON\', person_id, &AO.Comm_Method_Code_API.Decode(\'P" +
        "HONE\'), 1, CONTACT_ADDRESS)");
            this.tblCustomerInfoContact_colPersonInfoAddressPhone.NamedProperties.Put("ValidateMethod", "");
            this.tblCustomerInfoContact_colPersonInfoAddressPhone.Position = 26;
            resources.ApplyResources(this.tblCustomerInfoContact_colPersonInfoAddressPhone, "tblCustomerInfoContact_colPersonInfoAddressPhone");
            // 
            // tblCustomerInfoContact_colPersonInfoAddressMobile
            // 
            this.tblCustomerInfoContact_colPersonInfoAddressMobile.MaxLength = 2000;
            this.tblCustomerInfoContact_colPersonInfoAddressMobile.Name = "tblCustomerInfoContact_colPersonInfoAddressMobile";
            this.tblCustomerInfoContact_colPersonInfoAddressMobile.NamedProperties.Put("EnumerateMethod", "");
            this.tblCustomerInfoContact_colPersonInfoAddressMobile.NamedProperties.Put("FieldFlags", "304");
            this.tblCustomerInfoContact_colPersonInfoAddressMobile.NamedProperties.Put("LovReference", "");
            this.tblCustomerInfoContact_colPersonInfoAddressMobile.NamedProperties.Put("ParentName", "tblCustomerInfoContact.tblCustomerInfoContact_colsContactAddress");
            this.tblCustomerInfoContact_colPersonInfoAddressMobile.NamedProperties.Put("SqlColumn", "Comm_Method_API.Get_Value(\'PERSON\', person_id, &AO.Comm_Method_Code_API.Decode(\'M" +
        "OBILE\'), 1, CONTACT_ADDRESS)");
            this.tblCustomerInfoContact_colPersonInfoAddressMobile.NamedProperties.Put("ValidateMethod", "");
            this.tblCustomerInfoContact_colPersonInfoAddressMobile.Position = 27;
            resources.ApplyResources(this.tblCustomerInfoContact_colPersonInfoAddressMobile, "tblCustomerInfoContact_colPersonInfoAddressMobile");
            // 
            // tblCustomerInfoContact_colPersonInfoAddressE_Mail
            // 
            this.tblCustomerInfoContact_colPersonInfoAddressE_Mail.MaxLength = 2000;
            this.tblCustomerInfoContact_colPersonInfoAddressE_Mail.Name = "tblCustomerInfoContact_colPersonInfoAddressE_Mail";
            this.tblCustomerInfoContact_colPersonInfoAddressE_Mail.NamedProperties.Put("EnumerateMethod", "");
            this.tblCustomerInfoContact_colPersonInfoAddressE_Mail.NamedProperties.Put("FieldFlags", "304");
            this.tblCustomerInfoContact_colPersonInfoAddressE_Mail.NamedProperties.Put("LovReference", "");
            this.tblCustomerInfoContact_colPersonInfoAddressE_Mail.NamedProperties.Put("ParentName", "tblCustomerInfoContact.tblCustomerInfoContact_colsContactAddress");
            this.tblCustomerInfoContact_colPersonInfoAddressE_Mail.NamedProperties.Put("SqlColumn", "Comm_Method_API.Get_Value(\'PERSON\', person_id, &AO.Comm_Method_Code_API.Decode(\'E" +
        "_MAIL\'), 1, CONTACT_ADDRESS)");
            this.tblCustomerInfoContact_colPersonInfoAddressE_Mail.NamedProperties.Put("ValidateMethod", "");
            this.tblCustomerInfoContact_colPersonInfoAddressE_Mail.Position = 28;
            resources.ApplyResources(this.tblCustomerInfoContact_colPersonInfoAddressE_Mail, "tblCustomerInfoContact_colPersonInfoAddressE_Mail");
            // 
            // tblCustomerInfoContact_colPersonInfoAddressFax
            // 
            this.tblCustomerInfoContact_colPersonInfoAddressFax.MaxLength = 2000;
            this.tblCustomerInfoContact_colPersonInfoAddressFax.Name = "tblCustomerInfoContact_colPersonInfoAddressFax";
            this.tblCustomerInfoContact_colPersonInfoAddressFax.NamedProperties.Put("EnumerateMethod", "");
            this.tblCustomerInfoContact_colPersonInfoAddressFax.NamedProperties.Put("FieldFlags", "304");
            this.tblCustomerInfoContact_colPersonInfoAddressFax.NamedProperties.Put("LovReference", "");
            this.tblCustomerInfoContact_colPersonInfoAddressFax.NamedProperties.Put("ParentName", "tblCustomerInfoContact.tblCustomerInfoContact_colsContactAddress");
            this.tblCustomerInfoContact_colPersonInfoAddressFax.NamedProperties.Put("SqlColumn", "Comm_Method_API.Get_Value(\'PERSON\', person_id, Comm_Method_Code_API.Decode(\'FAX\')" +
        ", 1, CONTACT_ADDRESS, sysdate)");
            this.tblCustomerInfoContact_colPersonInfoAddressFax.NamedProperties.Put("ValidateMethod", "");
            this.tblCustomerInfoContact_colPersonInfoAddressFax.Position = 29;
            resources.ApplyResources(this.tblCustomerInfoContact_colPersonInfoAddressFax, "tblCustomerInfoContact_colPersonInfoAddressFax");
            // 
            // tblCustomerInfoContact_colPersonInfoAddressPager
            // 
            this.tblCustomerInfoContact_colPersonInfoAddressPager.MaxLength = 2000;
            this.tblCustomerInfoContact_colPersonInfoAddressPager.Name = "tblCustomerInfoContact_colPersonInfoAddressPager";
            this.tblCustomerInfoContact_colPersonInfoAddressPager.NamedProperties.Put("EnumerateMethod", "");
            this.tblCustomerInfoContact_colPersonInfoAddressPager.NamedProperties.Put("FieldFlags", "304");
            this.tblCustomerInfoContact_colPersonInfoAddressPager.NamedProperties.Put("LovReference", "");
            this.tblCustomerInfoContact_colPersonInfoAddressPager.NamedProperties.Put("ParentName", "tblCustomerInfoContact.tblCustomerInfoContact_colsContactAddress");
            this.tblCustomerInfoContact_colPersonInfoAddressPager.NamedProperties.Put("SqlColumn", "Comm_Method_API.Get_Value(\'PERSON\', person_id, &AO.Comm_Method_Code_API.Decode(\'P" +
        "AGER\'), 1, CONTACT_ADDRESS)");
            this.tblCustomerInfoContact_colPersonInfoAddressPager.NamedProperties.Put("ValidateMethod", "");
            this.tblCustomerInfoContact_colPersonInfoAddressPager.Position = 30;
            resources.ApplyResources(this.tblCustomerInfoContact_colPersonInfoAddressPager, "tblCustomerInfoContact_colPersonInfoAddressPager");
            // 
            // tblCustomerInfoContact_colPersonInfoAddressIntercom
            // 
            this.tblCustomerInfoContact_colPersonInfoAddressIntercom.MaxLength = 2000;
            this.tblCustomerInfoContact_colPersonInfoAddressIntercom.Name = "tblCustomerInfoContact_colPersonInfoAddressIntercom";
            this.tblCustomerInfoContact_colPersonInfoAddressIntercom.NamedProperties.Put("EnumerateMethod", "");
            this.tblCustomerInfoContact_colPersonInfoAddressIntercom.NamedProperties.Put("FieldFlags", "304");
            this.tblCustomerInfoContact_colPersonInfoAddressIntercom.NamedProperties.Put("LovReference", "");
            this.tblCustomerInfoContact_colPersonInfoAddressIntercom.NamedProperties.Put("ParentName", "tblCustomerInfoContact.tblCustomerInfoContact_colsContactAddress");
            this.tblCustomerInfoContact_colPersonInfoAddressIntercom.NamedProperties.Put("SqlColumn", "Comm_Method_API.Get_Value(\'PERSON\', person_id, &AO.Comm_Method_Code_API.Decode(\'I" +
        "NTERCOM\'), 1, CONTACT_ADDRESS)");
            this.tblCustomerInfoContact_colPersonInfoAddressIntercom.NamedProperties.Put("ValidateMethod", "");
            this.tblCustomerInfoContact_colPersonInfoAddressIntercom.Position = 31;
            resources.ApplyResources(this.tblCustomerInfoContact_colPersonInfoAddressIntercom, "tblCustomerInfoContact_colPersonInfoAddressIntercom");
            // 
            // tblCustomerInfoContact_colNoteText
            // 
            this.tblCustomerInfoContact_colNoteText.MaxLength = 50000;
            this.tblCustomerInfoContact_colNoteText.Name = "tblCustomerInfoContact_colNoteText";
            this.tblCustomerInfoContact_colNoteText.NamedProperties.Put("EnumerateMethod", "");
            this.tblCustomerInfoContact_colNoteText.NamedProperties.Put("FieldFlags", "310");
            this.tblCustomerInfoContact_colNoteText.NamedProperties.Put("LovReference", "");
            this.tblCustomerInfoContact_colNoteText.NamedProperties.Put("SqlColumn", "NOTE_TEXT");
            this.tblCustomerInfoContact_colNoteText.Position = 32;
            resources.ApplyResources(this.tblCustomerInfoContact_colNoteText, "tblCustomerInfoContact_colNoteText");
            // 
            // tblAddressType
            // 
            this.tblAddressType.Controls.Add(this.tblAddressType_colsCustomerId);
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
            this.tblAddressType.NamedProperties.Put("DefaultWhere", "CUSTOMER_ID = :i_hWndFrame.frmCustomerInfoAddress.dfsCustomerId");
            this.tblAddressType.NamedProperties.Put("LogicalUnit", "CustomerInfoAddressType");
            this.tblAddressType.NamedProperties.Put("PackageName", "CUSTOMER_INFO_ADDRESS_TYPE_API");
            this.tblAddressType.NamedProperties.Put("ResizeableChildObject", "LLLL");
            this.tblAddressType.NamedProperties.Put("ViewName", "CUSTOMER_INFO_ADDRESS_TYPE");
            this.tblAddressType.NamedProperties.Put("Warnings", "FALSE");
            this.tblAddressType.DataRecordExecuteNewEvent += new Ifs.Fnd.ApplicationForms.cDataSource.DataRecordExecuteNewEventHandler(this.tblAddressType_DataRecordExecuteNewEvent);
            this.tblAddressType.DataSourcePopulateItEvent += new Ifs.Fnd.ApplicationForms.cDataSource.DataSourcePopulateItEventHandler(this.tblAddressType_DataSourcePopulateItEvent);
            this.tblAddressType.DataSourcePrepareKeyTransferEvent += new Ifs.Fnd.ApplicationForms.cDataSource.DataSourcePrepareKeyTransferEventHandler(this.tblAddressType_DataSourcePrepareKeyTransferEvent);
            this.tblAddressType.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblAddressType_WindowActions);
            this.tblAddressType.Load += new System.EventHandler(this.tblAddressType_Load);
            this.tblAddressType.Controls.SetChildIndex(this.tblAddressType_colDefaultDomain, 0);
            this.tblAddressType.Controls.SetChildIndex(this.tblAddressType_colsParty, 0);
            this.tblAddressType.Controls.SetChildIndex(this.tblAddressType_colDefAddress, 0);
            this.tblAddressType.Controls.SetChildIndex(this.tblAddressType_colsAddressTypeCodeDb, 0);
            this.tblAddressType.Controls.SetChildIndex(this.tblAddressType_colsAddressTypeCode, 0);
            this.tblAddressType.Controls.SetChildIndex(this.tblAddressType_colsAddressId, 0);
            this.tblAddressType.Controls.SetChildIndex(this.tblAddressType_colsCustomerId, 0);
            // 
            // tblAddressType_colsCustomerId
            // 
            this.tblAddressType_colsCustomerId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblAddressType_colsCustomerId, "tblAddressType_colsCustomerId");
            this.tblAddressType_colsCustomerId.MaxLength = 20;
            this.tblAddressType_colsCustomerId.Name = "tblAddressType_colsCustomerId";
            this.tblAddressType_colsCustomerId.NamedProperties.Put("EnumerateMethod", "");
            this.tblAddressType_colsCustomerId.NamedProperties.Put("FieldFlags", "67");
            this.tblAddressType_colsCustomerId.NamedProperties.Put("LovReference", "");
            this.tblAddressType_colsCustomerId.NamedProperties.Put("ResizeableChildObject", "");
            this.tblAddressType_colsCustomerId.NamedProperties.Put("SqlColumn", "CUSTOMER_ID");
            this.tblAddressType_colsCustomerId.NamedProperties.Put("ValidateMethod", "");
            this.tblAddressType_colsCustomerId.Position = 3;
            // 
            // tblAddressType_colsAddressId
            // 
            this.tblAddressType_colsAddressId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblAddressType_colsAddressId, "tblAddressType_colsAddressId");
            this.tblAddressType_colsAddressId.MaxLength = 50;
            this.tblAddressType_colsAddressId.Name = "tblAddressType_colsAddressId";
            this.tblAddressType_colsAddressId.NamedProperties.Put("EnumerateMethod", "");
            this.tblAddressType_colsAddressId.NamedProperties.Put("FieldFlags", "66");
            this.tblAddressType_colsAddressId.NamedProperties.Put("LovReference", "CUSTOMER_INFO_ADDRESS(CUSTOMER_ID)");
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
            // frmCustomerInfoAddress
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.tblAddressType);
            this.Controls.Add(this.tblCustomerInfoContact);
            this.Controls.Add(this.tblCommMethod);
            this.Controls.Add(this.dfsCustomerBranch);
            this.Controls.Add(this.labelCustomerBranch);
            this.Controls.Add(this.dfsAddress6);
            this.Controls.Add(this.labelAddress6);
            this.Controls.Add(this.dfsAddress5);
            this.Controls.Add(this.labelAddress5);
            this.Controls.Add(this.dfsAddress4);
            this.Controls.Add(this.labelAddress4);
            this.Controls.Add(this.dfsAddress3);
            this.Controls.Add(this.labelAddress3);
            this.Controls.Add(this.dfsName);
            this.Controls.Add(this.gbEnd_Customer);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.dfsParty);
            this.Controls.Add(this.cmbPartyType);
            this.Controls.Add(this.cbDefaultDomain);
            this.Controls.Add(this.dfsCity);
            this.Controls.Add(this.dfsCustomerId);
            this.Controls.Add(this.dfsCountryCode);
            this.Controls.Add(this.dfsState);
            this.Controls.Add(this.dfsCounty);
            this.Controls.Add(this.dfsZipCode);
            this.Controls.Add(this.dfsAddress2);
            this.Controls.Add(this.dfsAddress1);
            this.Controls.Add(this.dfsSecondaryContact);
            this.Controls.Add(this.dfsPrimaryContact);
            this.Controls.Add(this.dfdValidTo);
            this.Controls.Add(this.dfdValidFrom);
            this.Controls.Add(this.dfsJurisdictionCode);
            this.Controls.Add(this.cbWithinCityLimit);
            this.Controls.Add(this.amlAddress);
            this.Controls.Add(this.cmbCountry);
            this.Controls.Add(this.dfsEanLocation);
            this.Controls.Add(this.cmbAddressId);
            this.Controls.Add(this.labeldfsCity);
            this.Controls.Add(this.labeldfsCountryCode);
            this.Controls.Add(this.labeldfsState);
            this.Controls.Add(this.labeldfsCounty);
            this.Controls.Add(this.labeldfsZipCode);
            this.Controls.Add(this.labeldfsAddress2);
            this.Controls.Add(this.labeldfsAddress1);
            this.Controls.Add(this.labeltblCustomerInfoContact);
            this.Controls.Add(this.labeltblCommMethod);
            this.Controls.Add(this.labeldfsSecondaryContact);
            this.Controls.Add(this.labeldfsPrimaryContact);
            this.Controls.Add(this.labeldfdValidTo);
            this.Controls.Add(this.labeldfdValidFrom);
            this.Controls.Add(this.labeldfsJurisdictionCode);
            this.Controls.Add(this.labelamlAddress);
            this.Controls.Add(this.labelcmbCountry);
            this.Controls.Add(this.labeldfsEanLocation);
            this.Controls.Add(this.labelcmbAddressId);
            this.Name = "frmCustomerInfoAddress";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "CustomerInfoAddress");
            this.NamedProperties.Put("PackageName", "CUSTOMER_INFO_ADDRESS_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "4545");
            this.NamedProperties.Put("ViewName", "CUSTOMER_INFO_ADDRESS");
            this.NamedProperties.Put("Warnings", "TRUE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.frmCustomerInfoAddress_WindowActions);
            this.Controls.SetChildIndex(this.picTab, 0);
            this.Controls.SetChildIndex(this.labelcmbAddressId, 0);
            this.Controls.SetChildIndex(this.labeldfsEanLocation, 0);
            this.Controls.SetChildIndex(this.labelcmbCountry, 0);
            this.Controls.SetChildIndex(this.labelamlAddress, 0);
            this.Controls.SetChildIndex(this.labeldfsJurisdictionCode, 0);
            this.Controls.SetChildIndex(this.labeldfdValidFrom, 0);
            this.Controls.SetChildIndex(this.labeldfdValidTo, 0);
            this.Controls.SetChildIndex(this.labeldfsPrimaryContact, 0);
            this.Controls.SetChildIndex(this.labeldfsSecondaryContact, 0);
            this.Controls.SetChildIndex(this.labeltblCommMethod, 0);
            this.Controls.SetChildIndex(this.labeltblCustomerInfoContact, 0);
            this.Controls.SetChildIndex(this.labeldfsAddress1, 0);
            this.Controls.SetChildIndex(this.labeldfsAddress2, 0);
            this.Controls.SetChildIndex(this.labeldfsZipCode, 0);
            this.Controls.SetChildIndex(this.labeldfsCounty, 0);
            this.Controls.SetChildIndex(this.labeldfsState, 0);
            this.Controls.SetChildIndex(this.labeldfsCountryCode, 0);
            this.Controls.SetChildIndex(this.labeldfsCity, 0);
            this.Controls.SetChildIndex(this.cmbAddressId, 0);
            this.Controls.SetChildIndex(this.dfsEanLocation, 0);
            this.Controls.SetChildIndex(this.cmbCountry, 0);
            this.Controls.SetChildIndex(this.amlAddress, 0);
            this.Controls.SetChildIndex(this.cbWithinCityLimit, 0);
            this.Controls.SetChildIndex(this.dfsJurisdictionCode, 0);
            this.Controls.SetChildIndex(this.dfdValidFrom, 0);
            this.Controls.SetChildIndex(this.dfdValidTo, 0);
            this.Controls.SetChildIndex(this.dfsPrimaryContact, 0);
            this.Controls.SetChildIndex(this.dfsSecondaryContact, 0);
            this.Controls.SetChildIndex(this.dfsAddress1, 0);
            this.Controls.SetChildIndex(this.dfsAddress2, 0);
            this.Controls.SetChildIndex(this.dfsZipCode, 0);
            this.Controls.SetChildIndex(this.dfsCounty, 0);
            this.Controls.SetChildIndex(this.dfsState, 0);
            this.Controls.SetChildIndex(this.dfsCountryCode, 0);
            this.Controls.SetChildIndex(this.dfsCustomerId, 0);
            this.Controls.SetChildIndex(this.dfsCity, 0);
            this.Controls.SetChildIndex(this.cbDefaultDomain, 0);
            this.Controls.SetChildIndex(this.cmbPartyType, 0);
            this.Controls.SetChildIndex(this.dfsParty, 0);
            this.Controls.SetChildIndex(this.labelName, 0);
            this.Controls.SetChildIndex(this.gbEnd_Customer, 0);
            this.Controls.SetChildIndex(this.dfsName, 0);
            this.Controls.SetChildIndex(this.labelAddress3, 0);
            this.Controls.SetChildIndex(this.dfsAddress3, 0);
            this.Controls.SetChildIndex(this.labelAddress4, 0);
            this.Controls.SetChildIndex(this.dfsAddress4, 0);
            this.Controls.SetChildIndex(this.labelAddress5, 0);
            this.Controls.SetChildIndex(this.dfsAddress5, 0);
            this.Controls.SetChildIndex(this.labelAddress6, 0);
            this.Controls.SetChildIndex(this.dfsAddress6, 0);
            this.Controls.SetChildIndex(this.labelCustomerBranch, 0);
            this.Controls.SetChildIndex(this.dfsCustomerBranch, 0);
            this.Controls.SetChildIndex(this.tblCommMethod, 0);
            this.Controls.SetChildIndex(this.tblCustomerInfoContact, 0);
            this.Controls.SetChildIndex(this.tblAddressType, 0);
            this.tblCommMethod.ResumeLayout(false);
            this.gbEnd_Customer.ResumeLayout(false);
            this.gbEnd_Customer.PerformLayout();
            this.tblCustomerInfoContact.ResumeLayout(false);
            this.tblAddressType.ResumeLayout(false);
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

        protected cDataField dfsName;
        protected cBackgroundText labelName;

        protected cGroupBox gbEnd_Customer;
        protected cDataField dfsEndCustAddrId;
        protected cBackgroundText labelEndCustAddrId;
        protected cDataField dfsEndCustomerId;
        protected cBackgroundText labelEndCustomerId;
        protected cBackgroundText labelEndCustomerName;
        protected cDataField dfsEndCustomerName;
        public cChildTableOnTab tblAddressType;
        protected cColumn tblAddressType_colsCustomerId;
        protected cColumn tblAddressType_colsAddressId;
        protected cLookupColumnTypeCode tblAddressType_colsAddressTypeCode;
        protected cColumn tblAddressType_colsAddressTypeCodeDb;
        protected cCheckBoxColumn tblAddressType_colDefAddress;
        protected cColumn tblAddressType_colsParty;
        protected cCheckBoxColumn tblAddressType_colDefaultDomain;
        public cChildTableCommMethod tblCommMethod;
        protected cColumn tblCommMethod_coldValidFromOld;
        protected cColumn tblCommMethod_coldValidToOld;
        public cChildTableOnTab tblCustomerInfoContact;
        protected cColumn tblCustomerInfoContact_colsCustomerId;
        protected cColumn tblCustomerInfoContact_colsCustomerAddress;
        protected cColumn tblCustomerInfoContact_colsPersonId;
        protected cColumn tblCustomerInfoContact_colPersonInfoName;
        protected cColumn tblCustomerInfoContact_colPersonInfoTitle;
        protected cMultiSelectionColumn tblCustomerInfoContact_colsRole;
        protected cColumn tblCustomerInfoContact_colsContactAddress;
        protected cCheckBoxColumn tblCustomerInfoContact_colsBlockedForCrmObjectsDb;
		protected cMultiSelectionColumn tblCustomerInfoContact_colsPersonalInterest;
		protected cMultiSelectionColumn tblCustomerInfoContact_colsCampaignInterest;
        protected cLookupColumn tblCustomerInfoContact_colsDecisionPowerType;
        protected cLookupColumn tblCustomerInfoContact_colsDepartment;
        protected cColumn tblCustomerInfoContact_colsManager;
        protected cColumn tblCustomerInfoContact_colsManagerName;
        protected cColumn tblCustomerInfoContact_colsManagerGuid;
        protected cColumn tblCustomerInfoContact_colsManagerCustAddress;
        protected cCheckBoxColumn tblCustomerInfoContact_colAddressPrimary;
        protected cCheckBoxColumn tblCustomerInfoContact_colAddressSecondary;
        protected cCheckBoxColumn tblCustomerInfoContact_colCustomerPrimary;
        protected cCheckBoxColumn tblCustomerInfoContact_colCustomerSecondary;
        protected cColumn tblCustomerInfoContact_colPersonInfoAddressPhone;
        protected cColumn tblCustomerInfoContact_colPersonInfoAddressMobile;
        protected cColumn tblCustomerInfoContact_colPersonInfoAddressE_Mail;
        protected cColumn tblCustomerInfoContact_colPersonInfoAddressFax;
        protected cColumn tblCustomerInfoContact_colPersonInfoAddressPager;
        protected cColumn tblCustomerInfoContact_colPersonInfoAddressIntercom;
        protected cColumn tblCustomerInfoContact_colNoteText;
        protected cColumn tblCustomerInfoContact_colsMainRepresentativeId;
        protected cColumn tblCustomerInfoContact_colsMainRepresentativeName;
        protected cDataField dfsAddress3;
        protected cBackgroundText labelAddress3;
        protected cDataField dfsAddress4;
        protected cBackgroundText labelAddress4;
        protected cDataField dfsAddress5;
        protected cBackgroundText labelAddress5;
        protected cDataField dfsAddress6;
        protected cBackgroundText labelAddress6;
        protected cCheckBoxColumn tblCustomerInfoContact_colsConnectAllCustAddrDb;
        protected cDataField dfsCustomerBranch;
        protected cBackgroundText labelCustomerBranch;
		
	}
}
