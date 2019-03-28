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
	
	public partial class frmForwarderInfoAddress
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
		public cDataField dfsForwarderId;
		protected cBackgroundText labelcmbCountry;
		public cComboBox cmbCountry;
		protected cBackgroundText labelamlAddress;
		public cAddressMultilineField amlAddress;
		protected cBackgroundText labeldfdValidFrom;
		public cDataField dfdValidFrom;
		protected cBackgroundText labeldfdValidTo;
        public cDataField dfdValidTo;
        // ! Bug 79336, Begin, tblCommMethod implemented from cChildTableCommMethod
		// ! Bug 79336, End
		public cCheckBox cbDefaultDomain;
		public cComboBox cmbPartyType;
		public cDataField dfsParty;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmForwarderInfoAddress));
            this.tblCommMethod = new Ifs.Application.Enterp.cChildTableCommMethod();
            this.labelcmbAddressId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbAddressId = new Ifs.Fnd.ApplicationForms.cRecSelExtComboBox();
            this.labeldfsEanLocation = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsEanLocation = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsForwarderId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelcmbCountry = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbCountry = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.labelamlAddress = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.amlAddress = new Ifs.Fnd.ApplicationForms.cAddressMultilineField();
            this.labeldfdValidFrom = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfdValidFrom = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfdValidTo = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfdValidTo = new Ifs.Fnd.ApplicationForms.cDataField();
            this.cbDefaultDomain = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.cmbPartyType = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.dfsParty = new Ifs.Fnd.ApplicationForms.cDataField();
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
            this.tblAddressType = new Ifs.Application.Enterp.cChildTableOnTab();
            this.tblAddressType_colsForwarderId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblAddressType_colsAddressId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblAddressType_colsAddressTypeCode = new Ifs.Application.Enterp.cLookupColumnTypeCode();
            this.tblAddressType_colsAddressTypeCodeDb = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblAddressType_colDefAddress = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.tblAddressType_colsParty = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblAddressType_colDefaultDomain = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.labeltblCommMethod = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsAddress3 = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelAddress3 = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsAddress4 = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelAddress4 = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsAddress5 = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelAddress5 = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsAddress6 = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelAddress6 = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.tblCommMethod.SuspendLayout();
            this.tblAddressType.SuspendLayout();
            this.SuspendLayout();
            // 
            // picTab
            // 
            resources.ApplyResources(this.picTab, "picTab");
            // 
            // tblCommMethod
            // 
            // 
            // tblCommMethod.colsAddressId
            // 
            resources.ApplyResources(this.tblCommMethod.colsAddressId, "tblCommMethod.colsAddressId");
            resources.ApplyResources(this.tblCommMethod, "tblCommMethod");
            this.tblCommMethod.Name = "tblCommMethod";
            this.tblCommMethod.NamedProperties.Put("DefaultOrderBy", "");
            this.tblCommMethod.NamedProperties.Put("DefaultWhere", "PARTY_TYPE_DB = \'FORWARDER\' AND\r\nIDENTITY = :i_hWndFrame.frmForwarderInfoAddress." +
        "dfsForwarderId AND\r\nADDRESS_ID = :i_hWndFrame.frmForwarderInfoAddress.cmbAddress" +
        "Id.i_sMyValue");
            this.tblCommMethod.NamedProperties.Put("LogicalUnit", "CommMethod");
            this.tblCommMethod.NamedProperties.Put("PackageName", "COMM_METHOD_API");
            this.tblCommMethod.NamedProperties.Put("ResizeableChildObject", "LLRR");
            this.tblCommMethod.NamedProperties.Put("ViewName", "COMM_METHOD");
            this.tblCommMethod.NamedProperties.Put("Warnings", "FALSE");
            this.tblCommMethod.DataRecordExecuteModifyEvent += new Ifs.Fnd.ApplicationForms.cDataSource.DataRecordExecuteModifyEventHandler(this.tblCommMethod_DataRecordExecuteModifyEvent);
            this.tblCommMethod.DataRecordExecuteNewEvent += new Ifs.Fnd.ApplicationForms.cDataSource.DataRecordExecuteNewEventHandler(this.tblCommMethod_DataRecordExecuteNewEvent);
            this.tblCommMethod.DataSourcePrepareKeyTransferEvent += new Ifs.Fnd.ApplicationForms.cDataSource.DataSourcePrepareKeyTransferEventHandler(this.tblCommMethod_DataSourcePrepareKeyTransferEvent);
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
            // dfsForwarderId
            // 
            this.dfsForwarderId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsForwarderId, "dfsForwarderId");
            this.dfsForwarderId.Name = "dfsForwarderId";
            this.dfsForwarderId.NamedProperties.Put("EnumerateMethod", "");
            this.dfsForwarderId.NamedProperties.Put("FieldFlags", "67");
            this.dfsForwarderId.NamedProperties.Put("LovReference", "FORWARDER_INFO");
            this.dfsForwarderId.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsForwarderId.NamedProperties.Put("SqlColumn", "FORWARDER_ID");
            this.dfsForwarderId.NamedProperties.Put("ValidateMethod", "");
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
            resources.ApplyResources(this.cmbCountry, "cmbCountry");
            this.cmbCountry.Name = "cmbCountry";
            this.cmbCountry.NamedProperties.Put("EnumerateMethod", "ISO_COUNTRY_API.Enumerate");
            this.cmbCountry.NamedProperties.Put("FieldFlags", "295");
            this.cmbCountry.NamedProperties.Put("Format", "9");
            this.cmbCountry.NamedProperties.Put("LovReference", "");
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
            this.dfdValidFrom.Format = "d";
            resources.ApplyResources(this.dfdValidFrom, "dfdValidFrom");
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
            this.dfdValidTo.Format = "d";
            resources.ApplyResources(this.dfdValidTo, "dfdValidTo");
            this.dfdValidTo.Name = "dfdValidTo";
            this.dfdValidTo.NamedProperties.Put("EnumerateMethod", "");
            this.dfdValidTo.NamedProperties.Put("FieldFlags", "294");
            this.dfdValidTo.NamedProperties.Put("LovReference", "");
            this.dfdValidTo.NamedProperties.Put("SqlColumn", "VALID_TO");
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
            // tblAddressType
            // 
            this.tblAddressType.Controls.Add(this.tblAddressType_colsForwarderId);
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
            this.tblAddressType.NamedProperties.Put("LogicalUnit", "ForwInfoAddrType");
            this.tblAddressType.NamedProperties.Put("PackageName", "FORW_INFO_ADDR_TYPE_API");
            this.tblAddressType.NamedProperties.Put("ResizeableChildObject", "LLLL");
            this.tblAddressType.NamedProperties.Put("ViewName", "FORW_INFO_ADDR_TYPE");
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
            this.tblAddressType.Controls.SetChildIndex(this.tblAddressType_colsForwarderId, 0);
            // 
            // tblAddressType_colsForwarderId
            // 
            this.tblAddressType_colsForwarderId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblAddressType_colsForwarderId, "tblAddressType_colsForwarderId");
            this.tblAddressType_colsForwarderId.MaxLength = 20;
            this.tblAddressType_colsForwarderId.Name = "tblAddressType_colsForwarderId";
            this.tblAddressType_colsForwarderId.NamedProperties.Put("EnumerateMethod", "");
            this.tblAddressType_colsForwarderId.NamedProperties.Put("FieldFlags", "67");
            this.tblAddressType_colsForwarderId.NamedProperties.Put("LovReference", "");
            this.tblAddressType_colsForwarderId.NamedProperties.Put("ResizeableChildObject", "");
            this.tblAddressType_colsForwarderId.NamedProperties.Put("SqlColumn", "FORWARDER_ID");
            this.tblAddressType_colsForwarderId.NamedProperties.Put("ValidateMethod", "");
            this.tblAddressType_colsForwarderId.Position = 3;
            // 
            // tblAddressType_colsAddressId
            // 
            this.tblAddressType_colsAddressId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblAddressType_colsAddressId, "tblAddressType_colsAddressId");
            this.tblAddressType_colsAddressId.MaxLength = 50;
            this.tblAddressType_colsAddressId.Name = "tblAddressType_colsAddressId";
            this.tblAddressType_colsAddressId.NamedProperties.Put("EnumerateMethod", "");
            this.tblAddressType_colsAddressId.NamedProperties.Put("FieldFlags", "66");
            this.tblAddressType_colsAddressId.NamedProperties.Put("LovReference", "FORWARDER_INFO_ADDRESS(FORWARDER_ID)");
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
            // labeltblCommMethod
            // 
            resources.ApplyResources(this.labeltblCommMethod, "labeltblCommMethod");
            this.picTab.SetControlTabPages(this.labeltblCommMethod, "Name0");
            this.labeltblCommMethod.Name = "labeltblCommMethod";
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
            // frmForwarderInfoAddress
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.dfsAddress6);
            this.Controls.Add(this.labelAddress6);
            this.Controls.Add(this.dfsAddress5);
            this.Controls.Add(this.labelAddress5);
            this.Controls.Add(this.dfsAddress4);
            this.Controls.Add(this.labelAddress4);
            this.Controls.Add(this.dfsAddress3);
            this.Controls.Add(this.labelAddress3);
            this.Controls.Add(this.labeltblCommMethod);
            this.Controls.Add(this.dfsCountryCode);
            this.Controls.Add(this.dfsState);
            this.Controls.Add(this.dfsCounty);
            this.Controls.Add(this.dfsCity);
            this.Controls.Add(this.dfsZipCode);
            this.Controls.Add(this.dfsAddress2);
            this.Controls.Add(this.dfsAddress1);
            this.Controls.Add(this.dfsParty);
            this.Controls.Add(this.cmbPartyType);
            this.Controls.Add(this.cbDefaultDomain);
            this.Controls.Add(this.tblCommMethod);
            this.Controls.Add(this.tblAddressType);
            this.Controls.Add(this.dfdValidTo);
            this.Controls.Add(this.dfdValidFrom);
            this.Controls.Add(this.cmbCountry);
            this.Controls.Add(this.dfsForwarderId);
            this.Controls.Add(this.dfsEanLocation);
            this.Controls.Add(this.cmbAddressId);
            this.Controls.Add(this.labeldfsCountryCode);
            this.Controls.Add(this.labeldfsState);
            this.Controls.Add(this.labeldfsCounty);
            this.Controls.Add(this.labeldfsCity);
            this.Controls.Add(this.labeldfsZipCode);
            this.Controls.Add(this.labeldfsAddress2);
            this.Controls.Add(this.labeldfsAddress1);
            this.Controls.Add(this.labeldfdValidTo);
            this.Controls.Add(this.labeldfdValidFrom);
            this.Controls.Add(this.labelamlAddress);
            this.Controls.Add(this.labelcmbCountry);
            this.Controls.Add(this.labeldfsEanLocation);
            this.Controls.Add(this.labelcmbAddressId);
            this.Controls.Add(this.amlAddress);
            this.Name = "frmForwarderInfoAddress";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "ForwarderInfoAddress");
            this.NamedProperties.Put("PackageName", "FORWARDER_INFO_ADDRESS_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "4545");
            this.NamedProperties.Put("ViewName", "FORWARDER_INFO_ADDRESS");
            this.NamedProperties.Put("Warnings", "TRUE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.frmForwarderInfoAddress_WindowActions);
            this.Controls.SetChildIndex(this.picTab, 0);
            this.Controls.SetChildIndex(this.amlAddress, 0);
            this.Controls.SetChildIndex(this.labelcmbAddressId, 0);
            this.Controls.SetChildIndex(this.labeldfsEanLocation, 0);
            this.Controls.SetChildIndex(this.labelcmbCountry, 0);
            this.Controls.SetChildIndex(this.labelamlAddress, 0);
            this.Controls.SetChildIndex(this.labeldfdValidFrom, 0);
            this.Controls.SetChildIndex(this.labeldfdValidTo, 0);
            this.Controls.SetChildIndex(this.labeldfsAddress1, 0);
            this.Controls.SetChildIndex(this.labeldfsAddress2, 0);
            this.Controls.SetChildIndex(this.labeldfsZipCode, 0);
            this.Controls.SetChildIndex(this.labeldfsCity, 0);
            this.Controls.SetChildIndex(this.labeldfsCounty, 0);
            this.Controls.SetChildIndex(this.labeldfsState, 0);
            this.Controls.SetChildIndex(this.labeldfsCountryCode, 0);
            this.Controls.SetChildIndex(this.cmbAddressId, 0);
            this.Controls.SetChildIndex(this.dfsEanLocation, 0);
            this.Controls.SetChildIndex(this.dfsForwarderId, 0);
            this.Controls.SetChildIndex(this.cmbCountry, 0);
            this.Controls.SetChildIndex(this.dfdValidFrom, 0);
            this.Controls.SetChildIndex(this.dfdValidTo, 0);
            this.Controls.SetChildIndex(this.tblAddressType, 0);
            this.Controls.SetChildIndex(this.tblCommMethod, 0);
            this.Controls.SetChildIndex(this.cbDefaultDomain, 0);
            this.Controls.SetChildIndex(this.cmbPartyType, 0);
            this.Controls.SetChildIndex(this.dfsParty, 0);
            this.Controls.SetChildIndex(this.dfsAddress1, 0);
            this.Controls.SetChildIndex(this.dfsAddress2, 0);
            this.Controls.SetChildIndex(this.dfsZipCode, 0);
            this.Controls.SetChildIndex(this.dfsCity, 0);
            this.Controls.SetChildIndex(this.dfsCounty, 0);
            this.Controls.SetChildIndex(this.dfsState, 0);
            this.Controls.SetChildIndex(this.dfsCountryCode, 0);
            this.Controls.SetChildIndex(this.labeltblCommMethod, 0);
            this.Controls.SetChildIndex(this.labelAddress3, 0);
            this.Controls.SetChildIndex(this.dfsAddress3, 0);
            this.Controls.SetChildIndex(this.labelAddress4, 0);
            this.Controls.SetChildIndex(this.dfsAddress4, 0);
            this.Controls.SetChildIndex(this.labelAddress5, 0);
            this.Controls.SetChildIndex(this.dfsAddress5, 0);
            this.Controls.SetChildIndex(this.labelAddress6, 0);
            this.Controls.SetChildIndex(this.dfsAddress6, 0);
            this.tblCommMethod.ResumeLayout(false);
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

        public cChildTableOnTab tblAddressType;
        protected cColumn tblAddressType_colsForwarderId;
        protected cColumn tblAddressType_colsAddressId;
        protected cLookupColumnTypeCode tblAddressType_colsAddressTypeCode;
        protected cColumn tblAddressType_colsAddressTypeCodeDb;
        protected cCheckBoxColumn tblAddressType_colDefAddress;
        protected cColumn tblAddressType_colsParty;
        protected cCheckBoxColumn tblAddressType_colDefaultDomain;
        public cChildTableCommMethod tblCommMethod;
        protected cBackgroundText labeltblCommMethod;
        protected cDataField dfsAddress3;
        protected cBackgroundText labelAddress3;
        protected cDataField dfsAddress4;
        protected cBackgroundText labelAddress4;
        protected cDataField dfsAddress5;
        protected cBackgroundText labelAddress5;
        protected cDataField dfsAddress6;
        protected cBackgroundText labelAddress6;
		
	}
}
