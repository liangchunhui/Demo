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
	
	public partial class dlgDetailedCompanyAddress
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		protected cBackgroundText labeldfsCompany;
		public cDataField dfsCompany;
		protected cBackgroundText labeldfsAddressId;
		public cDataField dfsAddressId;
		protected cBackgroundText labeldfsStreet;
		public cDataField dfsStreet;
		protected cBackgroundText labeldfsHouseNo;
		public cDataField dfsHouseNo;
		protected cBackgroundText labeldfsCommunity;
		public cDataField dfsCommunity;
		protected cBackgroundText labeldfsDistrict;
		public cDataField dfsDistrict;
		public cPushButton pbOK;
		public cPushButton pbCancel;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgDetailedCompanyAddress));
            this.labeldfsCompany = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsCompany = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsAddressId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsAddressId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsStreet = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsStreet = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsHouseNo = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsHouseNo = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsCommunity = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsCommunity = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsDistrict = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsDistrict = new Ifs.Fnd.ApplicationForms.cDataField();
            this.pbOK = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbCancel = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.ClientArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // ClientArea
            // 
            this.ClientArea.Controls.Add(this.pbCancel);
            this.ClientArea.Controls.Add(this.pbOK);
            this.ClientArea.Controls.Add(this.dfsDistrict);
            this.ClientArea.Controls.Add(this.dfsCommunity);
            this.ClientArea.Controls.Add(this.dfsHouseNo);
            this.ClientArea.Controls.Add(this.dfsStreet);
            this.ClientArea.Controls.Add(this.dfsAddressId);
            this.ClientArea.Controls.Add(this.dfsCompany);
            this.ClientArea.Controls.Add(this.labeldfsDistrict);
            this.ClientArea.Controls.Add(this.labeldfsCommunity);
            this.ClientArea.Controls.Add(this.labeldfsHouseNo);
            this.ClientArea.Controls.Add(this.labeldfsStreet);
            this.ClientArea.Controls.Add(this.labeldfsAddressId);
            this.ClientArea.Controls.Add(this.labeldfsCompany);
            resources.ApplyResources(this.ClientArea, "ClientArea");
            // 
            // commandManager
            // 
            this.commandManager.Components.Add(this.pbCancel);
            this.commandManager.Components.Add(this.pbOK);
            // 
            // labeldfsCompany
            // 
            resources.ApplyResources(this.labeldfsCompany, "labeldfsCompany");
            this.labeldfsCompany.Name = "labeldfsCompany";
            // 
            // dfsCompany
            // 
            this.dfsCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsCompany, "dfsCompany");
            this.dfsCompany.Name = "dfsCompany";
            this.dfsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCompany.NamedProperties.Put("FieldFlags", "67");
            this.dfsCompany.NamedProperties.Put("LovReference", "COMPANY");
            this.dfsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            // 
            // labeldfsAddressId
            // 
            resources.ApplyResources(this.labeldfsAddressId, "labeldfsAddressId");
            this.labeldfsAddressId.Name = "labeldfsAddressId";
            // 
            // dfsAddressId
            // 
            this.dfsAddressId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsAddressId, "dfsAddressId");
            this.dfsAddressId.Name = "dfsAddressId";
            this.dfsAddressId.NamedProperties.Put("EnumerateMethod", "");
            this.dfsAddressId.NamedProperties.Put("FieldFlags", "163");
            this.dfsAddressId.NamedProperties.Put("LovReference", "");
            this.dfsAddressId.NamedProperties.Put("SqlColumn", "ADDRESS_ID");
            // 
            // labeldfsStreet
            // 
            resources.ApplyResources(this.labeldfsStreet, "labeldfsStreet");
            this.labeldfsStreet.Name = "labeldfsStreet";
            // 
            // dfsStreet
            // 
            resources.ApplyResources(this.dfsStreet, "dfsStreet");
            this.dfsStreet.Name = "dfsStreet";
            this.dfsStreet.NamedProperties.Put("EnumerateMethod", "");
            this.dfsStreet.NamedProperties.Put("FieldFlags", "294");
            this.dfsStreet.NamedProperties.Put("LovReference", "");
            this.dfsStreet.NamedProperties.Put("SqlColumn", "STREET");
            this.dfsStreet.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsStreet_WindowActions);
            // 
            // labeldfsHouseNo
            // 
            resources.ApplyResources(this.labeldfsHouseNo, "labeldfsHouseNo");
            this.labeldfsHouseNo.Name = "labeldfsHouseNo";
            // 
            // dfsHouseNo
            // 
            resources.ApplyResources(this.dfsHouseNo, "dfsHouseNo");
            this.dfsHouseNo.Name = "dfsHouseNo";
            this.dfsHouseNo.NamedProperties.Put("EnumerateMethod", "");
            this.dfsHouseNo.NamedProperties.Put("FieldFlags", "294");
            this.dfsHouseNo.NamedProperties.Put("LovReference", "");
            this.dfsHouseNo.NamedProperties.Put("SqlColumn", "HOUSE_NO");
            this.dfsHouseNo.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsHouseNo_WindowActions);
            // 
            // labeldfsCommunity
            // 
            resources.ApplyResources(this.labeldfsCommunity, "labeldfsCommunity");
            this.labeldfsCommunity.Name = "labeldfsCommunity";
            // 
            // dfsCommunity
            // 
            resources.ApplyResources(this.dfsCommunity, "dfsCommunity");
            this.dfsCommunity.Name = "dfsCommunity";
            this.dfsCommunity.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCommunity.NamedProperties.Put("FieldFlags", "294");
            this.dfsCommunity.NamedProperties.Put("LovReference", "");
            this.dfsCommunity.NamedProperties.Put("SqlColumn", "COMMUNITY");
            this.dfsCommunity.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsCommunity_WindowActions);
            // 
            // labeldfsDistrict
            // 
            resources.ApplyResources(this.labeldfsDistrict, "labeldfsDistrict");
            this.labeldfsDistrict.Name = "labeldfsDistrict";
            // 
            // dfsDistrict
            // 
            resources.ApplyResources(this.dfsDistrict, "dfsDistrict");
            this.dfsDistrict.Name = "dfsDistrict";
            this.dfsDistrict.NamedProperties.Put("EnumerateMethod", "");
            this.dfsDistrict.NamedProperties.Put("FieldFlags", "294");
            this.dfsDistrict.NamedProperties.Put("LovReference", "");
            this.dfsDistrict.NamedProperties.Put("SqlColumn", "DISTRICT");
            this.dfsDistrict.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsDistrict_WindowActions);
            // 
            // pbOK
            // 
            resources.ApplyResources(this.pbOK, "pbOK");
            this.pbOK.Name = "pbOK";
            this.pbOK.NamedProperties.Put("MethodId", "18385");
            this.pbOK.NamedProperties.Put("MethodParameter", "OK");
            this.pbOK.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // pbCancel
            // 
            resources.ApplyResources(this.pbCancel, "pbCancel");
            this.pbCancel.Name = "pbCancel";
            this.pbCancel.NamedProperties.Put("MethodId", "18385");
            this.pbCancel.NamedProperties.Put("MethodParameter", "Cancel");
            this.pbCancel.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // dlgDetailedCompanyAddress
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "dlgDetailedCompanyAddress";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "COMPANY = :i_hWndFrame.dlgDetailedCompanyAddress.dfsCompany AND\r\nADDRESS_ID = :i_" +
                    "hWndFrame.dlgDetailedCompanyAddress.dfsAddressId");
            this.NamedProperties.Put("LogicalUnit", "CompanyAddress");
            this.NamedProperties.Put("PackageName", "COMPANY_ADDRESS_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "129");
            this.NamedProperties.Put("ViewName", "COMPANY_ADDRESS");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.ShowIcon = false;
            this.ClientArea.ResumeLayout(false);
            this.ClientArea.PerformLayout();
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
	}
}