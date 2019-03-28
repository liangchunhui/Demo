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
	
	public partial class tbwIncomeType
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cColumn colnInternalIncomeType;
		public cColumn colsCountryCode;
		public cColumn colsIncomeTypeId;
		public cColumn colsDescription;
		public cColumn colsCurrencyCode;
		public cColumn colnThresholdAmount;
		public cColumn colsIncomeReportingCode;
		public cColumn colsBlocked;
		public cLookupColumn colsTaxWithholdCode;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwIncomeType));
            this.colnInternalIncomeType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsCountryCode = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsIncomeTypeId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsCurrencyCode = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colnThresholdAmount = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsIncomeReportingCode = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsBlocked = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsTaxWithholdCode = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.SuspendLayout();
            // 
            // colnInternalIncomeType
            // 
            this.colnInternalIncomeType.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.colnInternalIncomeType, "colnInternalIncomeType");
            this.colnInternalIncomeType.Name = "colnInternalIncomeType";
            this.colnInternalIncomeType.NamedProperties.Put("EnumerateMethod", "");
            this.colnInternalIncomeType.NamedProperties.Put("FieldFlags", "130");
            this.colnInternalIncomeType.NamedProperties.Put("LovReference", "");
            this.colnInternalIncomeType.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colnInternalIncomeType.NamedProperties.Put("SqlColumn", "INTERNAL_INCOME_TYPE");
            this.colnInternalIncomeType.NamedProperties.Put("ValidateMethod", "");
            this.colnInternalIncomeType.Position = 3;
            // 
            // colsCountryCode
            // 
            this.colsCountryCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsCountryCode.MaxLength = 2;
            this.colsCountryCode.Name = "colsCountryCode";
            this.colsCountryCode.NamedProperties.Put("EnumerateMethod", "");
            this.colsCountryCode.NamedProperties.Put("FieldFlags", "291");
            this.colsCountryCode.NamedProperties.Put("LovReference", "ISO_COUNTRY");
            this.colsCountryCode.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsCountryCode.NamedProperties.Put("SqlColumn", "COUNTRY_CODE");
            this.colsCountryCode.NamedProperties.Put("ValidateMethod", "");
            this.colsCountryCode.Position = 4;
            resources.ApplyResources(this.colsCountryCode, "colsCountryCode");
            // 
            // colsIncomeTypeId
            // 
            this.colsIncomeTypeId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsIncomeTypeId.MaxLength = 20;
            this.colsIncomeTypeId.Name = "colsIncomeTypeId";
            this.colsIncomeTypeId.NamedProperties.Put("EnumerateMethod", "");
            this.colsIncomeTypeId.NamedProperties.Put("FieldFlags", "291");
            this.colsIncomeTypeId.NamedProperties.Put("LovReference", "");
            this.colsIncomeTypeId.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsIncomeTypeId.NamedProperties.Put("SqlColumn", "INCOME_TYPE_ID");
            this.colsIncomeTypeId.NamedProperties.Put("ValidateMethod", "");
            this.colsIncomeTypeId.Position = 5;
            resources.ApplyResources(this.colsIncomeTypeId, "colsIncomeTypeId");
            // 
            // colsDescription
            // 
            this.colsDescription.MaxLength = 200;
            this.colsDescription.Name = "colsDescription";
            this.colsDescription.NamedProperties.Put("EnumerateMethod", "");
            this.colsDescription.NamedProperties.Put("FieldFlags", "295");
            this.colsDescription.NamedProperties.Put("LovReference", "");
            this.colsDescription.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.colsDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.colsDescription.NamedProperties.Put("ValidateMethod", "");
            this.colsDescription.Position = 6;
            resources.ApplyResources(this.colsDescription, "colsDescription");
            // 
            // colsCurrencyCode
            // 
            this.colsCurrencyCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsCurrencyCode.MaxLength = 3;
            this.colsCurrencyCode.Name = "colsCurrencyCode";
            this.colsCurrencyCode.NamedProperties.Put("EnumerateMethod", "");
            this.colsCurrencyCode.NamedProperties.Put("FieldFlags", "291");
            this.colsCurrencyCode.NamedProperties.Put("LovReference", "ISO_CURRENCY");
            this.colsCurrencyCode.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsCurrencyCode.NamedProperties.Put("SqlColumn", "CURRENCY_CODE");
            this.colsCurrencyCode.NamedProperties.Put("ValidateMethod", "");
            this.colsCurrencyCode.Position = 7;
            resources.ApplyResources(this.colsCurrencyCode, "colsCurrencyCode");
            // 
            // colnThresholdAmount
            // 
            this.colnThresholdAmount.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnThresholdAmount.Name = "colnThresholdAmount";
            this.colnThresholdAmount.NamedProperties.Put("EnumerateMethod", "");
            this.colnThresholdAmount.NamedProperties.Put("FieldFlags", "295");
            this.colnThresholdAmount.NamedProperties.Put("Format", "20");
            this.colnThresholdAmount.NamedProperties.Put("LovReference", "");
            this.colnThresholdAmount.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colnThresholdAmount.NamedProperties.Put("SqlColumn", "THRESHOLD_AMOUNT");
            this.colnThresholdAmount.Position = 8;
            this.colnThresholdAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.colnThresholdAmount, "colnThresholdAmount");
            // 
            // colsIncomeReportingCode
            // 
            this.colsIncomeReportingCode.MaxLength = 20;
            this.colsIncomeReportingCode.Name = "colsIncomeReportingCode";
            this.colsIncomeReportingCode.NamedProperties.Put("EnumerateMethod", "");
            this.colsIncomeReportingCode.NamedProperties.Put("FieldFlags", "294");
            this.colsIncomeReportingCode.NamedProperties.Put("LovReference", "");
            this.colsIncomeReportingCode.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsIncomeReportingCode.NamedProperties.Put("SqlColumn", "INCOME_REPORTING_CODE");
            this.colsIncomeReportingCode.Position = 9;
            resources.ApplyResources(this.colsIncomeReportingCode, "colsIncomeReportingCode");
            // 
            // colsBlocked
            // 
            resources.ApplyResources(this.colsBlocked, "colsBlocked");
            this.colsBlocked.MaxLength = 5;
            this.colsBlocked.Name = "colsBlocked";
            this.colsBlocked.NamedProperties.Put("EnumerateMethod", "");
            this.colsBlocked.NamedProperties.Put("FieldFlags", "263");
            this.colsBlocked.NamedProperties.Put("LovReference", "");
            this.colsBlocked.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsBlocked.NamedProperties.Put("ResizeableChildObject", "");
            this.colsBlocked.NamedProperties.Put("SqlColumn", "BLOCKED");
            this.colsBlocked.NamedProperties.Put("ValidateMethod", "");
            this.colsBlocked.Position = 10;
            // 
            // colsTaxWithholdCode
            // 
            this.colsTaxWithholdCode.MaxLength = 200;
            this.colsTaxWithholdCode.Name = "colsTaxWithholdCode";
            this.colsTaxWithholdCode.NamedProperties.Put("EnumerateMethod", "TAX_WITHHOLD_CODE_API.Enumerate");
            this.colsTaxWithholdCode.NamedProperties.Put("FieldFlags", "295");
            this.colsTaxWithholdCode.NamedProperties.Put("LovReference", "");
            this.colsTaxWithholdCode.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsTaxWithholdCode.NamedProperties.Put("ResizeableChildObject", "");
            this.colsTaxWithholdCode.NamedProperties.Put("SqlColumn", "TAX_WITHHOLD_CODE");
            this.colsTaxWithholdCode.NamedProperties.Put("ValidateMethod", "");
            this.colsTaxWithholdCode.Position = 11;
            resources.ApplyResources(this.colsTaxWithholdCode, "colsTaxWithholdCode");
            // 
            // tbwIncomeType
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colnInternalIncomeType);
            this.Controls.Add(this.colsCountryCode);
            this.Controls.Add(this.colsIncomeTypeId);
            this.Controls.Add(this.colsDescription);
            this.Controls.Add(this.colsCurrencyCode);
            this.Controls.Add(this.colnThresholdAmount);
            this.Controls.Add(this.colsIncomeReportingCode);
            this.Controls.Add(this.colsBlocked);
            this.Controls.Add(this.colsTaxWithholdCode);
            this.Name = "tbwIncomeType";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "IncomeType");
            this.NamedProperties.Put("PackageName", "INCOME_TYPE_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "449");
            this.NamedProperties.Put("ViewName", "INCOME_TYPE");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.Controls.SetChildIndex(this.colsTaxWithholdCode, 0);
            this.Controls.SetChildIndex(this.colsBlocked, 0);
            this.Controls.SetChildIndex(this.colsIncomeReportingCode, 0);
            this.Controls.SetChildIndex(this.colnThresholdAmount, 0);
            this.Controls.SetChildIndex(this.colsCurrencyCode, 0);
            this.Controls.SetChildIndex(this.colsDescription, 0);
            this.Controls.SetChildIndex(this.colsIncomeTypeId, 0);
            this.Controls.SetChildIndex(this.colsCountryCode, 0);
            this.Controls.SetChildIndex(this.colnInternalIncomeType, 0);
            this.Controls.SetChildIndex(this.@__colObjversion, 0);
            this.Controls.SetChildIndex(this.@__colObjid, 0);
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
