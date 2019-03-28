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
	
	public partial class frmManufacturerInfo
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		protected cBackgroundText labelcmbManufacturerId;
		public cRecListDataField cmbManufacturerId;
		protected cBackgroundText labeldfsName;
		public cDataField dfsName;
		protected cBackgroundText labeldfsAssociationNo;
		public cDataField dfsAssociationNo;
		protected cBackgroundText labelcmbDefaultLanguage;
		public cComboBox cmbDefaultLanguage;
		protected cBackgroundText labelcmbCountry;
		public cComboBox cmbCountry;
		protected cBackgroundText labeldfdCreationDate;
		public cDataField dfdCreationDate;
		public cDataField dfsParty;
		public cCheckBox cbDefaultDomain;
		public cComboBox cmbPartyType;
		// ! Bug 79336, End
		protected SalGroupBox gbOur_ID_at_Manufacturer;
        public cDataField dfsExist;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManufacturerInfo));
            this.labelcmbManufacturerId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbManufacturerId = new Ifs.Fnd.ApplicationForms.cRecListDataField();
            this.labeldfsName = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsName = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsAssociationNo = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsAssociationNo = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelcmbDefaultLanguage = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbDefaultLanguage = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.labelcmbCountry = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbCountry = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.labeldfdCreationDate = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfdCreationDate = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsParty = new Ifs.Fnd.ApplicationForms.cDataField();
            this.cbDefaultDomain = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.cmbPartyType = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.gbOur_ID_at_Manufacturer = new PPJ.Runtime.Windows.SalGroupBox();
            this.dfsExist = new Ifs.Fnd.ApplicationForms.cDataField();
            this.tblOurId = new Ifs.Application.Enterp.cChildTableOnTab();
            this.tblOurId_colsCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblOurId_colsOurId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblOurId_colsManufacturerId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblOurId.SuspendLayout();
            this.SuspendLayout();
            // 
            // picTab
            // 
            resources.ApplyResources(this.picTab, "picTab");
            // 
            // labelcmbManufacturerId
            // 
            resources.ApplyResources(this.labelcmbManufacturerId, "labelcmbManufacturerId");
            this.labelcmbManufacturerId.Name = "labelcmbManufacturerId";
            // 
            // cmbManufacturerId
            // 
            this.cmbManufacturerId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.cmbManufacturerId, "cmbManufacturerId");
            this.cmbManufacturerId.Name = "cmbManufacturerId";
            this.cmbManufacturerId.NamedProperties.Put("EnumerateMethod", "");
            this.cmbManufacturerId.NamedProperties.Put("FieldFlags", "162");
            this.cmbManufacturerId.NamedProperties.Put("Format", "9");
            this.cmbManufacturerId.NamedProperties.Put("LovReference", "");
            this.cmbManufacturerId.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbManufacturerId.NamedProperties.Put("SqlColumn", "MANUFACTURER_ID");
            this.cmbManufacturerId.NamedProperties.Put("ValidateMethod", "");
            this.cmbManufacturerId.NamedProperties.Put("XDataLength", "20");
            this.cmbManufacturerId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbManufacturerId_WindowActions);
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
            this.dfsName.NamedProperties.Put("ParentName", "cmbManufacturerId");
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
            this.dfsAssociationNo.NamedProperties.Put("LovReference", "");
            this.dfsAssociationNo.NamedProperties.Put("ParentName", "cmbManufacturerId");
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
            this.cmbDefaultLanguage.NamedProperties.Put("FieldFlags", "294");
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
            resources.ApplyResources(this.cmbCountry, "cmbCountry");
            this.cmbCountry.Name = "cmbCountry";
            this.cmbCountry.NamedProperties.Put("EnumerateMethod", "ISO_COUNTRY_API.Enumerate");
            this.cmbCountry.NamedProperties.Put("FieldFlags", "294");
            this.cmbCountry.NamedProperties.Put("LovReference", "");
            this.cmbCountry.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbCountry.NamedProperties.Put("SqlColumn", "COUNTRY");
            this.cmbCountry.NamedProperties.Put("ValidateMethod", "");
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
            this.dfdCreationDate.Format = "d";
            resources.ApplyResources(this.dfdCreationDate, "dfdCreationDate");
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
            // gbOur_ID_at_Manufacturer
            // 
            this.gbOur_ID_at_Manufacturer.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.gbOur_ID_at_Manufacturer, "Name0");
            resources.ApplyResources(this.gbOur_ID_at_Manufacturer, "gbOur_ID_at_Manufacturer");
            this.gbOur_ID_at_Manufacturer.Name = "gbOur_ID_at_Manufacturer";
            this.gbOur_ID_at_Manufacturer.TabStop = false;
            // 
            // dfsExist
            // 
            resources.ApplyResources(this.dfsExist, "dfsExist");
            this.dfsExist.Name = "dfsExist";
            // 
            // tblOurId
            // 
            this.tblOurId.Controls.Add(this.tblOurId_colsCompany);
            this.tblOurId.Controls.Add(this.tblOurId_colsOurId);
            this.tblOurId.Controls.Add(this.tblOurId_colsManufacturerId);
            this.picTab.SetControlTabPages(this.tblOurId, "Name0");
            resources.ApplyResources(this.tblOurId, "tblOurId");
            this.tblOurId.Name = "tblOurId";
            this.tblOurId.NamedProperties.Put("DefaultOrderBy", "");
            this.tblOurId.NamedProperties.Put("DefaultWhere", "");
            this.tblOurId.NamedProperties.Put("LogicalUnit", "ManufacturerInfoOurId");
            this.tblOurId.NamedProperties.Put("PackageName", "MANUFACTURER_INFO_OUR_ID_API");
            this.tblOurId.NamedProperties.Put("ResizeableChildObject", "");
            this.tblOurId.NamedProperties.Put("ViewName", "MANUFACT_INFO_OUR_ID_FIN_AUTH");
            this.tblOurId.NamedProperties.Put("Warnings", "FALSE");
            this.tblOurId.Controls.SetChildIndex(this.tblOurId_colsManufacturerId, 0);
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
            this.tblOurId_colsCompany.NamedProperties.Put("LovReference", "COMPANY");
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
            // tblOurId_colsManufacturerId
            // 
            this.tblOurId_colsManufacturerId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblOurId_colsManufacturerId, "tblOurId_colsManufacturerId");
            this.tblOurId_colsManufacturerId.MaxLength = 20;
            this.tblOurId_colsManufacturerId.Name = "tblOurId_colsManufacturerId";
            this.tblOurId_colsManufacturerId.NamedProperties.Put("EnumerateMethod", "");
            this.tblOurId_colsManufacturerId.NamedProperties.Put("FieldFlags", "67");
            this.tblOurId_colsManufacturerId.NamedProperties.Put("LovReference", "MANUFACTURER_INFO");
            this.tblOurId_colsManufacturerId.NamedProperties.Put("SqlColumn", "MANUFACTURER_ID");
            this.tblOurId_colsManufacturerId.Position = 5;
            // 
            // frmManufacturerInfo
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.tblOurId);
            this.Controls.Add(this.dfsExist);
            this.Controls.Add(this.cmbPartyType);
            this.Controls.Add(this.cbDefaultDomain);
            this.Controls.Add(this.dfsParty);
            this.Controls.Add(this.dfdCreationDate);
            this.Controls.Add(this.cmbDefaultLanguage);
            this.Controls.Add(this.cmbCountry);
            this.Controls.Add(this.dfsAssociationNo);
            this.Controls.Add(this.dfsName);
            this.Controls.Add(this.cmbManufacturerId);
            this.Controls.Add(this.labelcmbDefaultLanguage);
            this.Controls.Add(this.labelcmbCountry);
            this.Controls.Add(this.labeldfdCreationDate);
            this.Controls.Add(this.labeldfsAssociationNo);
            this.Controls.Add(this.labeldfsName);
            this.Controls.Add(this.labelcmbManufacturerId);
            this.Controls.Add(this.gbOur_ID_at_Manufacturer);
            this.Name = "frmManufacturerInfo";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "ManufacturerInfo");
            this.NamedProperties.Put("PackageName", "MANUFACTURER_INFO_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "4545");
            this.NamedProperties.Put("ViewName", "MANUFACTURER_INFO");
            this.NamedProperties.Put("Warnings", "TRUE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.frmManufacturerInfo_WindowActions);
            this.Controls.SetChildIndex(this.picTab, 0);
            this.Controls.SetChildIndex(this.gbOur_ID_at_Manufacturer, 0);
            this.Controls.SetChildIndex(this.labelcmbManufacturerId, 0);
            this.Controls.SetChildIndex(this.labeldfsName, 0);
            this.Controls.SetChildIndex(this.labeldfsAssociationNo, 0);
            this.Controls.SetChildIndex(this.labeldfdCreationDate, 0);
            this.Controls.SetChildIndex(this.labelcmbCountry, 0);
            this.Controls.SetChildIndex(this.labelcmbDefaultLanguage, 0);
            this.Controls.SetChildIndex(this.cmbManufacturerId, 0);
            this.Controls.SetChildIndex(this.dfsName, 0);
            this.Controls.SetChildIndex(this.dfsAssociationNo, 0);
            this.Controls.SetChildIndex(this.cmbCountry, 0);
            this.Controls.SetChildIndex(this.cmbDefaultLanguage, 0);
            this.Controls.SetChildIndex(this.dfdCreationDate, 0);
            this.Controls.SetChildIndex(this.dfsParty, 0);
            this.Controls.SetChildIndex(this.cbDefaultDomain, 0);
            this.Controls.SetChildIndex(this.cmbPartyType, 0);
            this.Controls.SetChildIndex(this.dfsExist, 0);
            this.Controls.SetChildIndex(this.tblOurId, 0);
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

        public cChildTableOnTab tblOurId;
        protected cColumn tblOurId_colsCompany;
        protected cColumn tblOurId_colsOurId;
        protected cColumn tblOurId_colsManufacturerId;
		
	}
}
