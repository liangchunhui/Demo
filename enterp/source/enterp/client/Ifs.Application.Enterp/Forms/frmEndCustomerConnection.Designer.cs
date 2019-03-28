#region Copyright (c) IFS Research & Development
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
#endregion
#region History
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ifs.Fnd.ApplicationForms;
using PPJ.Runtime;
using PPJ.Runtime.Windows;

namespace Ifs.Application.Enterp
{

    public partial class frmEndCustomerConnection
    {

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEndCustomerConnection));
            this.dfsName = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelName = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsCustomerId = new Ifs.Fnd.ApplicationForms.cRecListDataField();
            this.labelCustomerId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.tblEndCustomers = new Ifs.Fnd.ApplicationForms.cChildTable();
            this.colsCustomerId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsAddressId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsEndCustomerId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsEndCustomerName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsEndCustomerCountry = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsEndCustomerCategory = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsEndCustAddrId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsAddress1 = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsAddress2 = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsZipCode = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsCity = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsState = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsCounty = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsCountry = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblEndCustomers.SuspendLayout();
            this.SuspendLayout();
            // 
            // dfsName
            // 
            resources.ApplyResources(this.dfsName, "dfsName");
            this.dfsName.Name = "dfsName";
            this.dfsName.NamedProperties.Put("EnumerateMethod", "");
            this.dfsName.NamedProperties.Put("FieldFlags", "295");
            this.dfsName.NamedProperties.Put("LovReference", "");
            this.dfsName.NamedProperties.Put("SqlColumn", "NAME");
            // 
            // labelName
            // 
            resources.ApplyResources(this.labelName, "labelName");
            this.labelName.Name = "labelName";
            // 
            // dfsCustomerId
            // 
            this.dfsCustomerId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsCustomerId, "dfsCustomerId");
            this.dfsCustomerId.Name = "dfsCustomerId";
            this.dfsCustomerId.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCustomerId.NamedProperties.Put("FieldFlags", "163");
            this.dfsCustomerId.NamedProperties.Put("LovReference", "CUSTOMER_INFO");
            this.dfsCustomerId.NamedProperties.Put("SqlColumn", "CUSTOMER_ID");
            // 
            // labelCustomerId
            // 
            resources.ApplyResources(this.labelCustomerId, "labelCustomerId");
            this.labelCustomerId.Name = "labelCustomerId";
            // 
            // tblEndCustomers
            // 
            resources.ApplyResources(this.tblEndCustomers, "tblEndCustomers");
            this.tblEndCustomers.Controls.Add(this.colsCustomerId);
            this.tblEndCustomers.Controls.Add(this.colsAddressId);
            this.tblEndCustomers.Controls.Add(this.colsEndCustomerId);
            this.tblEndCustomers.Controls.Add(this.colsEndCustomerName);
            this.tblEndCustomers.Controls.Add(this.colsEndCustomerCountry);
            this.tblEndCustomers.Controls.Add(this.colsEndCustomerCategory);
            this.tblEndCustomers.Controls.Add(this.colsEndCustAddrId);
            this.tblEndCustomers.Controls.Add(this.colsAddress1);
            this.tblEndCustomers.Controls.Add(this.colsAddress2);
            this.tblEndCustomers.Controls.Add(this.colsZipCode);
            this.tblEndCustomers.Controls.Add(this.colsCity);
            this.tblEndCustomers.Controls.Add(this.colsState);
            this.tblEndCustomers.Controls.Add(this.colsCounty);
            this.tblEndCustomers.Controls.Add(this.colsCountry);
            this.tblEndCustomers.Name = "tblEndCustomers";
            this.tblEndCustomers.NamedProperties.Put("DefaultWhere", "END_CUSTOMER_ID IS NOT NULL");
            this.tblEndCustomers.NamedProperties.Put("LogicalUnit", "CustomerInfoAddress");
            this.tblEndCustomers.NamedProperties.Put("Module", "ENTERP");
            this.tblEndCustomers.NamedProperties.Put("PackageName", "CUSTOMER_INFO_ADDRESS_API");
            this.tblEndCustomers.NamedProperties.Put("SourceFlags", "1");
            this.tblEndCustomers.NamedProperties.Put("ViewName", "CUSTOMER_INFO_ADDRESS");
            this.tblEndCustomers.Controls.SetChildIndex(this.colsCountry, 0);
            this.tblEndCustomers.Controls.SetChildIndex(this.colsCounty, 0);
            this.tblEndCustomers.Controls.SetChildIndex(this.colsState, 0);
            this.tblEndCustomers.Controls.SetChildIndex(this.colsCity, 0);
            this.tblEndCustomers.Controls.SetChildIndex(this.colsZipCode, 0);
            this.tblEndCustomers.Controls.SetChildIndex(this.colsAddress2, 0);
            this.tblEndCustomers.Controls.SetChildIndex(this.colsAddress1, 0);
            this.tblEndCustomers.Controls.SetChildIndex(this.colsEndCustAddrId, 0);
            this.tblEndCustomers.Controls.SetChildIndex(this.colsEndCustomerCategory, 0);
            this.tblEndCustomers.Controls.SetChildIndex(this.colsEndCustomerCountry, 0);
            this.tblEndCustomers.Controls.SetChildIndex(this.colsEndCustomerName, 0);
            this.tblEndCustomers.Controls.SetChildIndex(this.colsEndCustomerId, 0);
            this.tblEndCustomers.Controls.SetChildIndex(this.colsAddressId, 0);
            this.tblEndCustomers.Controls.SetChildIndex(this.colsCustomerId, 0);
            // 
            // colsCustomerId
            // 
            this.colsCustomerId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsCustomerId.MaxLength = 20;
            this.colsCustomerId.Name = "colsCustomerId";
            this.colsCustomerId.NamedProperties.Put("EnumerateMethod", "");
            this.colsCustomerId.NamedProperties.Put("FieldFlags", "67");
            this.colsCustomerId.NamedProperties.Put("LovReference", "");
            this.colsCustomerId.NamedProperties.Put("SqlColumn", "CUSTOMER_ID");
            this.colsCustomerId.Position = 3;
            resources.ApplyResources(this.colsCustomerId, "colsCustomerId");
            // 
            // colsAddressId
            // 
            this.colsAddressId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsAddressId.MaxLength = 50;
            this.colsAddressId.Name = "colsAddressId";
            this.colsAddressId.NamedProperties.Put("EnumerateMethod", "");
            this.colsAddressId.NamedProperties.Put("FieldFlags", "163");
            this.colsAddressId.NamedProperties.Put("LovReference", "");
            this.colsAddressId.NamedProperties.Put("SqlColumn", "ADDRESS_ID");
            this.colsAddressId.Position = 4;
            resources.ApplyResources(this.colsAddressId, "colsAddressId");
            // 
            // colsEndCustomerId
            // 
            this.colsEndCustomerId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsEndCustomerId.MaxLength = 20;
            this.colsEndCustomerId.Name = "colsEndCustomerId";
            this.colsEndCustomerId.NamedProperties.Put("EnumerateMethod", "");
            this.colsEndCustomerId.NamedProperties.Put("FieldFlags", "294");
            this.colsEndCustomerId.NamedProperties.Put("LovReference", "CUSTOMER_INFO");
            this.colsEndCustomerId.NamedProperties.Put("SqlColumn", "END_CUSTOMER_ID");
            this.colsEndCustomerId.Position = 5;
            resources.ApplyResources(this.colsEndCustomerId, "colsEndCustomerId");
            // 
            // colsEndCustomerName
            // 
            this.colsEndCustomerName.MaxLength = 2000;
            this.colsEndCustomerName.Name = "colsEndCustomerName";
            this.colsEndCustomerName.NamedProperties.Put("EnumerateMethod", "");
            this.colsEndCustomerName.NamedProperties.Put("FieldFlags", "288");
            this.colsEndCustomerName.NamedProperties.Put("LovReference", "");
            this.colsEndCustomerName.NamedProperties.Put("SqlColumn", "Customer_Info_API.Get_Name(END_CUSTOMER_ID)");
            this.colsEndCustomerName.Position = 6;
            resources.ApplyResources(this.colsEndCustomerName, "colsEndCustomerName");
            // 
            // colsEndCustomerCountry
            // 
            this.colsEndCustomerCountry.Name = "colsEndCustomerCountry";
            this.colsEndCustomerCountry.NamedProperties.Put("SqlColumn", "Customer_Info_API.Get_Country(END_CUSTOMER_ID)");
            this.colsEndCustomerCountry.Position = 7;
            resources.ApplyResources(this.colsEndCustomerCountry, "colsEndCustomerCountry");
            // 
            // colsEndCustomerCategory
            // 
            this.colsEndCustomerCategory.MaxLength = 2000;
            this.colsEndCustomerCategory.Name = "colsEndCustomerCategory";
            this.colsEndCustomerCategory.NamedProperties.Put("EnumerateMethod", "");
            this.colsEndCustomerCategory.NamedProperties.Put("FieldFlags", "288");
            this.colsEndCustomerCategory.NamedProperties.Put("LovReference", "");
            this.colsEndCustomerCategory.NamedProperties.Put("SqlColumn", "Customer_Info_API.Get_Customer_Category(END_CUSTOMER_ID)");
            this.colsEndCustomerCategory.Position = 8;
            resources.ApplyResources(this.colsEndCustomerCategory, "colsEndCustomerCategory");
            // 
            // colsEndCustAddrId
            // 
            this.colsEndCustAddrId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsEndCustAddrId.MaxLength = 50;
            this.colsEndCustAddrId.Name = "colsEndCustAddrId";
            this.colsEndCustAddrId.NamedProperties.Put("EnumerateMethod", "");
            this.colsEndCustAddrId.NamedProperties.Put("FieldFlags", "294");
            this.colsEndCustAddrId.NamedProperties.Put("LovReference", "CUSTOMER_INFO_ADDRESS(END_CUSTOMER_ID)");
            this.colsEndCustAddrId.NamedProperties.Put("SqlColumn", "END_CUST_ADDR_ID");
            this.colsEndCustAddrId.Position = 9;
            resources.ApplyResources(this.colsEndCustAddrId, "colsEndCustAddrId");
            this.colsEndCustAddrId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblEndCustomers_colsEndCustAddrId_WindowActions);
            // 
            // colsAddress1
            // 
            this.colsAddress1.MaxLength = 35;
            this.colsAddress1.Name = "colsAddress1";
            this.colsAddress1.NamedProperties.Put("EnumerateMethod", "");
            this.colsAddress1.NamedProperties.Put("FieldFlags", "294");
            this.colsAddress1.NamedProperties.Put("LovReference", "");
            this.colsAddress1.NamedProperties.Put("SqlColumn", "ADDRESS1");
            this.colsAddress1.Position = 10;
            resources.ApplyResources(this.colsAddress1, "colsAddress1");
            // 
            // colsAddress2
            // 
            this.colsAddress2.MaxLength = 35;
            this.colsAddress2.Name = "colsAddress2";
            this.colsAddress2.NamedProperties.Put("EnumerateMethod", "");
            this.colsAddress2.NamedProperties.Put("FieldFlags", "294");
            this.colsAddress2.NamedProperties.Put("LovReference", "");
            this.colsAddress2.NamedProperties.Put("SqlColumn", "ADDRESS2");
            this.colsAddress2.Position = 11;
            resources.ApplyResources(this.colsAddress2, "colsAddress2");
            // 
            // colsZipCode
            // 
            this.colsZipCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsZipCode.MaxLength = 35;
            this.colsZipCode.Name = "colsZipCode";
            this.colsZipCode.NamedProperties.Put("EnumerateMethod", "");
            this.colsZipCode.NamedProperties.Put("FieldFlags", "294");
            this.colsZipCode.NamedProperties.Put("LovReference", "");
            this.colsZipCode.NamedProperties.Put("SqlColumn", "ZIP_CODE");
            this.colsZipCode.Position = 12;
            resources.ApplyResources(this.colsZipCode, "colsZipCode");
            // 
            // colsCity
            // 
            this.colsCity.MaxLength = 35;
            this.colsCity.Name = "colsCity";
            this.colsCity.NamedProperties.Put("EnumerateMethod", "");
            this.colsCity.NamedProperties.Put("FieldFlags", "294");
            this.colsCity.NamedProperties.Put("LovReference", "");
            this.colsCity.NamedProperties.Put("SqlColumn", "CITY");
            this.colsCity.Position = 13;
            resources.ApplyResources(this.colsCity, "colsCity");
            // 
            // colsState
            // 
            this.colsState.MaxLength = 35;
            this.colsState.Name = "colsState";
            this.colsState.NamedProperties.Put("EnumerateMethod", "");
            this.colsState.NamedProperties.Put("FieldFlags", "294");
            this.colsState.NamedProperties.Put("LovReference", "");
            this.colsState.NamedProperties.Put("SqlColumn", "STATE");
            this.colsState.Position = 14;
            resources.ApplyResources(this.colsState, "colsState");
            // 
            // colsCounty
            // 
            this.colsCounty.MaxLength = 35;
            this.colsCounty.Name = "colsCounty";
            this.colsCounty.NamedProperties.Put("EnumerateMethod", "");
            this.colsCounty.NamedProperties.Put("FieldFlags", "294");
            this.colsCounty.NamedProperties.Put("LovReference", "");
            this.colsCounty.NamedProperties.Put("SqlColumn", "COUNTY");
            this.colsCounty.Position = 15;
            resources.ApplyResources(this.colsCounty, "colsCounty");
            // 
            // colsCountry
            // 
            this.colsCountry.MaxLength = 200;
            this.colsCountry.Name = "colsCountry";
            this.colsCountry.NamedProperties.Put("EnumerateMethod", "ISO_COUNTRY_API.Enumerate");
            this.colsCountry.NamedProperties.Put("FieldFlags", "295");
            this.colsCountry.NamedProperties.Put("LovReference", "ISO_COUNTRY");
            this.colsCountry.NamedProperties.Put("SqlColumn", "COUNTRY");
            this.colsCountry.Position = 16;
            resources.ApplyResources(this.colsCountry, "colsCountry");
            // 
            // frmEndCustomerConnection
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.tblEndCustomers);
            this.Controls.Add(this.dfsCustomerId);
            this.Controls.Add(this.labelCustomerId);
            this.Controls.Add(this.dfsName);
            this.Controls.Add(this.labelName);
            this.Name = "frmEndCustomerConnection";
            this.NamedProperties.Put("DefaultWhere", "CUSTOMER_CATEGORY_DB = \'CUSTOMER\'");
            this.NamedProperties.Put("LogicalUnit", "CustomerInfo");
            this.NamedProperties.Put("Module", "ENTERP");
            this.NamedProperties.Put("PackageName", "CUSTOMER_INFO_API");
            this.NamedProperties.Put("SourceFlags", "1");
            this.NamedProperties.Put("ViewName", "CUSTOMER_INFO");
            this.tblEndCustomers.ResumeLayout(false);
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
        protected cRecListDataField dfsCustomerId;
        protected cBackgroundText labelCustomerId;
        protected cChildTable tblEndCustomers;
        protected cColumn colsAddressId;
        protected cColumn colsEndCustomerId;
        protected cColumn colsEndCustAddrId;
        protected cColumn colsEndCustomerName;
        protected cColumn colsEndCustomerCategory;
        protected cColumn colsAddress1;
        protected cColumn colsZipCode;
        protected cColumn colsCity;
        protected cColumn colsState;
        protected cColumn colsCounty;
        protected cColumn colsCountry;
        protected cColumn colsAddress2;
        protected cColumn colsCustomerId;
        protected cColumn colsEndCustomerCountry;
    }
}
