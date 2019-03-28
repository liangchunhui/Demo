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
	
	public partial class frmCompanyInfo
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		protected cBackgroundText labeldfsCompanyId;
		public cDataField dfsCompanyId;
		public cDataField dfsCompanyName;
		protected cBackgroundText labeldfsCalendarCreationMethod;
		public cDataField dfsCalendarCreationMethod;
		protected cBackgroundText labeldfAccYear;
		public cDataField dfAccYear;
		protected cBackgroundText labeldfStartYear;
		public cDataField dfStartYear;
		protected cBackgroundText labeldfStartMonth;
		public cDataField dfStartMonth;
		protected cBackgroundText labeldfNumberOfYears;
		public cDataField dfNumberOfYears;
		public cCheckBox cbTemplateCompany;
		protected cBackgroundText labeldfsAccountingCurrency;
		public cDataField dfsAccountingCurrency;
		protected cBackgroundText labeldfsParallelCurrBase;
		public cDataField dfsParallelCurrBase;
		protected cBackgroundText labeldfsParallelAccCurrency;
		public cDataField dfsParallelAccCurrency;
		protected cBackgroundText labeldfdtTimeStamp;
		public cDataField dfdtTimeStamp;
		public cDataField dfsAction;
		protected cBackgroundText labeldfsDefaultLanguage;
		public cDataField dfsDefaultLanguage;
		protected cBackgroundText labeldfsCountry;
		public cDataField dfsCountry;
		protected SalGroupBox gbCreate_From;
		protected cBackgroundText labeldfsTemplateId;
		public cDataField dfsTemplateId;
		protected cBackgroundText labeldfsSourceCompanyId;
		public cDataField dfsSourceCompanyId;
		public cDataField dfsMakeCompany;
		protected cBackgroundText labelmlSelectedLanguages;
		public cMultilineField mlSelectedLanguages;
		public cCheckBox cbUsePeriod;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCompanyInfo));
            this.labeldfsCompanyId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsCompanyId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsCompanyName = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsCalendarCreationMethod = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsCalendarCreationMethod = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfAccYear = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfAccYear = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfStartYear = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfStartYear = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfStartMonth = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfStartMonth = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfNumberOfYears = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfNumberOfYears = new Ifs.Fnd.ApplicationForms.cDataField();
            this.cbTemplateCompany = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.labeldfsAccountingCurrency = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsAccountingCurrency = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsParallelCurrBase = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsParallelCurrBase = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsParallelAccCurrency = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsParallelAccCurrency = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfdtTimeStamp = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfdtTimeStamp = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsAction = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsDefaultLanguage = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsDefaultLanguage = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsCountry = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsCountry = new Ifs.Fnd.ApplicationForms.cDataField();
            this.gbCreate_From = new PPJ.Runtime.Windows.SalGroupBox();
            this.labeldfsTemplateId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsTemplateId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsSourceCompanyId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsSourceCompanyId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsMakeCompany = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelmlSelectedLanguages = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.mlSelectedLanguages = new Ifs.Fnd.ApplicationForms.cMultilineField();
            this.cbUsePeriod = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.cbMasterCompany = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.labeldfsCurrBalCodePart = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsCurrBalCodePart = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsInternalName = new Ifs.Fnd.ApplicationForms.cDataField();
            this.SuspendLayout();
            // 
            // labeldfsCompanyId
            // 
            resources.ApplyResources(this.labeldfsCompanyId, "labeldfsCompanyId");
            this.labeldfsCompanyId.Name = "labeldfsCompanyId";
            // 
            // dfsCompanyId
            // 
            resources.ApplyResources(this.dfsCompanyId, "dfsCompanyId");
            this.dfsCompanyId.Name = "dfsCompanyId";
            this.dfsCompanyId.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCompanyId.NamedProperties.Put("LovReference", "");
            this.dfsCompanyId.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsCompanyId.NamedProperties.Put("SqlColumn", "COMPANY");
            this.dfsCompanyId.NamedProperties.Put("ValidateMethod", "");
            // 
            // dfsCompanyName
            // 
            resources.ApplyResources(this.dfsCompanyName, "dfsCompanyName");
            this.dfsCompanyName.Name = "dfsCompanyName";
            this.dfsCompanyName.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCompanyName.NamedProperties.Put("LovReference", "");
            this.dfsCompanyName.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsCompanyName.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.dfsCompanyName.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsCalendarCreationMethod
            // 
            resources.ApplyResources(this.labeldfsCalendarCreationMethod, "labeldfsCalendarCreationMethod");
            this.labeldfsCalendarCreationMethod.Name = "labeldfsCalendarCreationMethod";
            // 
            // dfsCalendarCreationMethod
            // 
            resources.ApplyResources(this.dfsCalendarCreationMethod, "dfsCalendarCreationMethod");
            this.dfsCalendarCreationMethod.Name = "dfsCalendarCreationMethod";
            // 
            // labeldfAccYear
            // 
            resources.ApplyResources(this.labeldfAccYear, "labeldfAccYear");
            this.labeldfAccYear.Name = "labeldfAccYear";
            // 
            // dfAccYear
            // 
            this.dfAccYear.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfAccYear, "dfAccYear");
            this.dfAccYear.Name = "dfAccYear";
            // 
            // labeldfStartYear
            // 
            resources.ApplyResources(this.labeldfStartYear, "labeldfStartYear");
            this.labeldfStartYear.Name = "labeldfStartYear";
            // 
            // dfStartYear
            // 
            this.dfStartYear.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfStartYear, "dfStartYear");
            this.dfStartYear.Name = "dfStartYear";
            // 
            // labeldfStartMonth
            // 
            resources.ApplyResources(this.labeldfStartMonth, "labeldfStartMonth");
            this.labeldfStartMonth.Name = "labeldfStartMonth";
            // 
            // dfStartMonth
            // 
            this.dfStartMonth.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfStartMonth, "dfStartMonth");
            this.dfStartMonth.Name = "dfStartMonth";
            // 
            // labeldfNumberOfYears
            // 
            resources.ApplyResources(this.labeldfNumberOfYears, "labeldfNumberOfYears");
            this.labeldfNumberOfYears.Name = "labeldfNumberOfYears";
            // 
            // dfNumberOfYears
            // 
            this.dfNumberOfYears.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfNumberOfYears, "dfNumberOfYears");
            this.dfNumberOfYears.Name = "dfNumberOfYears";
            // 
            // cbTemplateCompany
            // 
            resources.ApplyResources(this.cbTemplateCompany, "cbTemplateCompany");
            this.cbTemplateCompany.Name = "cbTemplateCompany";
            // 
            // labeldfsAccountingCurrency
            // 
            resources.ApplyResources(this.labeldfsAccountingCurrency, "labeldfsAccountingCurrency");
            this.labeldfsAccountingCurrency.Name = "labeldfsAccountingCurrency";
            // 
            // dfsAccountingCurrency
            // 
            resources.ApplyResources(this.dfsAccountingCurrency, "dfsAccountingCurrency");
            this.dfsAccountingCurrency.Name = "dfsAccountingCurrency";
            this.dfsAccountingCurrency.NamedProperties.Put("EnumerateMethod", "");
            this.dfsAccountingCurrency.NamedProperties.Put("LovReference", "");
            this.dfsAccountingCurrency.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsAccountingCurrency.NamedProperties.Put("SqlColumn", "CURRENCY_CODE");
            this.dfsAccountingCurrency.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsParallelCurrBase
            // 
            resources.ApplyResources(this.labeldfsParallelCurrBase, "labeldfsParallelCurrBase");
            this.labeldfsParallelCurrBase.Name = "labeldfsParallelCurrBase";
            // 
            // dfsParallelCurrBase
            // 
            this.dfsParallelCurrBase.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.dfsParallelCurrBase.Format = "d";
            resources.ApplyResources(this.dfsParallelCurrBase, "dfsParallelCurrBase");
            this.dfsParallelCurrBase.Name = "dfsParallelCurrBase";
            this.dfsParallelCurrBase.NamedProperties.Put("EnumerateMethod", "");
            this.dfsParallelCurrBase.NamedProperties.Put("LovReference", "");
            this.dfsParallelCurrBase.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsParallelCurrBase.NamedProperties.Put("SqlColumn", "PARALLEL_BASE");
            this.dfsParallelCurrBase.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsParallelAccCurrency
            // 
            resources.ApplyResources(this.labeldfsParallelAccCurrency, "labeldfsParallelAccCurrency");
            this.labeldfsParallelAccCurrency.Name = "labeldfsParallelAccCurrency";
            // 
            // dfsParallelAccCurrency
            // 
            resources.ApplyResources(this.dfsParallelAccCurrency, "dfsParallelAccCurrency");
            this.dfsParallelAccCurrency.Name = "dfsParallelAccCurrency";
            this.dfsParallelAccCurrency.NamedProperties.Put("EnumerateMethod", "");
            this.dfsParallelAccCurrency.NamedProperties.Put("LovReference", "");
            this.dfsParallelAccCurrency.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsParallelAccCurrency.NamedProperties.Put("SqlColumn", "PARALLEL_ACC_CURRENCY");
            this.dfsParallelAccCurrency.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfdtTimeStamp
            // 
            resources.ApplyResources(this.labeldfdtTimeStamp, "labeldfdtTimeStamp");
            this.labeldfdtTimeStamp.Name = "labeldfdtTimeStamp";
            // 
            // dfdtTimeStamp
            // 
            this.dfdtTimeStamp.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.dfdtTimeStamp.Format = "d";
            resources.ApplyResources(this.dfdtTimeStamp, "dfdtTimeStamp");
            this.dfdtTimeStamp.Name = "dfdtTimeStamp";
            this.dfdtTimeStamp.NamedProperties.Put("EnumerateMethod", "");
            this.dfdtTimeStamp.NamedProperties.Put("LovReference", "");
            this.dfdtTimeStamp.NamedProperties.Put("ResizeableChildObject", "");
            this.dfdtTimeStamp.NamedProperties.Put("SqlColumn", "");
            this.dfdtTimeStamp.NamedProperties.Put("ValidateMethod", "");
            // 
            // dfsAction
            // 
            resources.ApplyResources(this.dfsAction, "dfsAction");
            this.dfsAction.Name = "dfsAction";
            // 
            // labeldfsDefaultLanguage
            // 
            resources.ApplyResources(this.labeldfsDefaultLanguage, "labeldfsDefaultLanguage");
            this.labeldfsDefaultLanguage.Name = "labeldfsDefaultLanguage";
            // 
            // dfsDefaultLanguage
            // 
            resources.ApplyResources(this.dfsDefaultLanguage, "dfsDefaultLanguage");
            this.dfsDefaultLanguage.Name = "dfsDefaultLanguage";
            this.dfsDefaultLanguage.NamedProperties.Put("EnumerateMethod", "");
            this.dfsDefaultLanguage.NamedProperties.Put("LovReference", "");
            this.dfsDefaultLanguage.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsDefaultLanguage.NamedProperties.Put("SqlColumn", "");
            this.dfsDefaultLanguage.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsCountry
            // 
            resources.ApplyResources(this.labeldfsCountry, "labeldfsCountry");
            this.labeldfsCountry.Name = "labeldfsCountry";
            // 
            // dfsCountry
            // 
            resources.ApplyResources(this.dfsCountry, "dfsCountry");
            this.dfsCountry.Name = "dfsCountry";
            this.dfsCountry.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCountry.NamedProperties.Put("LovReference", "");
            this.dfsCountry.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsCountry.NamedProperties.Put("SqlColumn", "");
            this.dfsCountry.NamedProperties.Put("ValidateMethod", "");
            // 
            // gbCreate_From
            // 
            resources.ApplyResources(this.gbCreate_From, "gbCreate_From");
            this.gbCreate_From.Name = "gbCreate_From";
            this.gbCreate_From.TabStop = false;
            // 
            // labeldfsTemplateId
            // 
            resources.ApplyResources(this.labeldfsTemplateId, "labeldfsTemplateId");
            this.labeldfsTemplateId.Name = "labeldfsTemplateId";
            // 
            // dfsTemplateId
            // 
            resources.ApplyResources(this.dfsTemplateId, "dfsTemplateId");
            this.dfsTemplateId.Name = "dfsTemplateId";
            this.dfsTemplateId.NamedProperties.Put("EnumerateMethod", "");
            this.dfsTemplateId.NamedProperties.Put("LovReference", "");
            this.dfsTemplateId.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsTemplateId.NamedProperties.Put("SqlColumn", "");
            this.dfsTemplateId.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsSourceCompanyId
            // 
            resources.ApplyResources(this.labeldfsSourceCompanyId, "labeldfsSourceCompanyId");
            this.labeldfsSourceCompanyId.Name = "labeldfsSourceCompanyId";
            // 
            // dfsSourceCompanyId
            // 
            resources.ApplyResources(this.dfsSourceCompanyId, "dfsSourceCompanyId");
            this.dfsSourceCompanyId.Name = "dfsSourceCompanyId";
            // 
            // dfsMakeCompany
            // 
            resources.ApplyResources(this.dfsMakeCompany, "dfsMakeCompany");
            this.dfsMakeCompany.Name = "dfsMakeCompany";
            // 
            // labelmlSelectedLanguages
            // 
            resources.ApplyResources(this.labelmlSelectedLanguages, "labelmlSelectedLanguages");
            this.labelmlSelectedLanguages.Name = "labelmlSelectedLanguages";
            // 
            // mlSelectedLanguages
            // 
            resources.ApplyResources(this.mlSelectedLanguages, "mlSelectedLanguages");
            this.mlSelectedLanguages.Name = "mlSelectedLanguages";
            // 
            // cbUsePeriod
            // 
            resources.ApplyResources(this.cbUsePeriod, "cbUsePeriod");
            this.cbUsePeriod.Name = "cbUsePeriod";
            this.cbUsePeriod.NamedProperties.Put("DataType", "5");
            this.cbUsePeriod.NamedProperties.Put("EnumerateMethod", "");
            this.cbUsePeriod.NamedProperties.Put("LovReference", "");
            this.cbUsePeriod.NamedProperties.Put("ResizeableChildObject", "");
            this.cbUsePeriod.NamedProperties.Put("SqlColumn", "");
            this.cbUsePeriod.NamedProperties.Put("ValidateMethod", "");
            this.cbUsePeriod.NamedProperties.Put("XDataLength", "5");
            // 
            // cbMasterCompany
            // 
            resources.ApplyResources(this.cbMasterCompany, "cbMasterCompany");
            this.cbMasterCompany.Name = "cbMasterCompany";
            this.cbMasterCompany.NamedProperties.Put("DataType", "5");
            this.cbMasterCompany.NamedProperties.Put("EnumerateMethod", "");
            this.cbMasterCompany.NamedProperties.Put("LovReference", "");
            this.cbMasterCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.cbMasterCompany.NamedProperties.Put("SqlColumn", "");
            this.cbMasterCompany.NamedProperties.Put("ValidateMethod", "");
            this.cbMasterCompany.NamedProperties.Put("XDataLength", "");
            // 
            // labeldfsCurrBalCodePart
            // 
            resources.ApplyResources(this.labeldfsCurrBalCodePart, "labeldfsCurrBalCodePart");
            this.labeldfsCurrBalCodePart.Name = "labeldfsCurrBalCodePart";
            // 
            // dfsCurrBalCodePart
            // 
            resources.ApplyResources(this.dfsCurrBalCodePart, "dfsCurrBalCodePart");
            this.dfsCurrBalCodePart.Name = "dfsCurrBalCodePart";
            // 
            // dfsInternalName
            // 
            resources.ApplyResources(this.dfsInternalName, "dfsInternalName");
            this.dfsInternalName.Name = "dfsInternalName";
            // 
            // frmCompanyInfo
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.dfsInternalName);
            this.Controls.Add(this.dfsCurrBalCodePart);
            this.Controls.Add(this.labeldfsCurrBalCodePart);
            this.Controls.Add(this.cbMasterCompany);
            this.Controls.Add(this.cbUsePeriod);
            this.Controls.Add(this.mlSelectedLanguages);
            this.Controls.Add(this.dfsMakeCompany);
            this.Controls.Add(this.dfsSourceCompanyId);
            this.Controls.Add(this.dfsTemplateId);
            this.Controls.Add(this.dfsCountry);
            this.Controls.Add(this.dfsDefaultLanguage);
            this.Controls.Add(this.dfsAction);
            this.Controls.Add(this.dfdtTimeStamp);
            this.Controls.Add(this.dfsParallelAccCurrency);
            this.Controls.Add(this.dfsParallelCurrBase);
            this.Controls.Add(this.dfsAccountingCurrency);
            this.Controls.Add(this.cbTemplateCompany);
            this.Controls.Add(this.dfNumberOfYears);
            this.Controls.Add(this.dfStartMonth);
            this.Controls.Add(this.dfStartYear);
            this.Controls.Add(this.dfAccYear);
            this.Controls.Add(this.dfsCalendarCreationMethod);
            this.Controls.Add(this.dfsCompanyName);
            this.Controls.Add(this.dfsCompanyId);
            this.Controls.Add(this.labelmlSelectedLanguages);
            this.Controls.Add(this.labeldfsSourceCompanyId);
            this.Controls.Add(this.labeldfsTemplateId);
            this.Controls.Add(this.labeldfsCountry);
            this.Controls.Add(this.labeldfsDefaultLanguage);
            this.Controls.Add(this.labeldfdtTimeStamp);
            this.Controls.Add(this.labeldfsParallelAccCurrency);
            this.Controls.Add(this.labeldfsParallelCurrBase);
            this.Controls.Add(this.labeldfsAccountingCurrency);
            this.Controls.Add(this.labeldfNumberOfYears);
            this.Controls.Add(this.labeldfStartMonth);
            this.Controls.Add(this.labeldfStartYear);
            this.Controls.Add(this.labeldfAccYear);
            this.Controls.Add(this.labeldfsCalendarCreationMethod);
            this.Controls.Add(this.labeldfsCompanyId);
            this.Controls.Add(this.gbCreate_From);
            this.Name = "frmCompanyInfo";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "");
            this.NamedProperties.Put("PackageName", "");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("ViewName", "");
            this.NamedProperties.Put("Warnings", "TRUE");
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

        public cCheckBox cbMasterCompany;
        protected cBackgroundText labeldfsCurrBalCodePart;
        protected cDataField dfsCurrBalCodePart;
        protected cDataField dfsInternalName;
	}
}
