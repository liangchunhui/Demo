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
	
	public partial class dlgCreateCompany
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		// Step 1
		protected cBackgroundText labeldfHeading1;
		// Just because a data field is necessary to have a background text
		public cDataField dfHeading1;
		protected cBackgroundText labeldfsNewCompanyId;
		public cDataField dfsNewCompanyId;
		protected cBackgroundText labeldfsNewCompanyName;
		public cDataField dfsNewCompanyName;
		public cCheckBox cbTemplateCompany;		
		// Step 2
		protected cBackgroundText labeldfHeading2;
		// Just because a data field is necessary to have a background text
		public cDataField dfHeading2;
		protected SalGroupBox gbCreate_From;
		public cRadioButton rbCopyCompany;
		public cRadioButton rbImportTemplate;
		protected cBackgroundText labeldfsSourceCompanyId;
		public cDataField dfsSourceCompanyId;
		protected cBackgroundText labeldfsSourceCompanyName;
		public cDataField dfsSourceCompanyName;
		protected cBackgroundText labeldfsTemplateId;
		public cDataField dfsTemplateId;
		protected cBackgroundText labeldfsTemplateName;
		public cDataField dfsTemplateName;
		protected cBackgroundText labeldfsDomainId;
		public cDataField dfsDomainId;
		// Step 3
		protected cBackgroundText labellbLanguages;
		public VisRadioListBox lbLanguages;
		protected cBackgroundText labeldfsDummyLang;
		public cDataField dfsDummyLang;
		// Step 4
		protected cBackgroundText labeldfsAccountingCurrency;
		public cDataField dfsAccountingCurrency;
		protected cBackgroundText labeldfdtValidFrom;
		public cDataField dfdtValidFrom;
		protected cBackgroundText labeldfsParallelAccCurrency;
        public cDataField dfsParallelAccCurrency;
		public cDataField dfdtTimeStamp;
		protected cBackgroundText labelcmbDefaultLanguage;
		public cComboBox cmbDefaultLanguage;
		protected cBackgroundText labelcmbCountry;
		public cComboBox cmbCountry;
		public cCheckBox cbUsePeriod;
		public cRadioButton rbSourceTemplateCompany;
		public cRadioButton rbUserDefined;
		protected cBackgroundText labeldfAccYear;
		public cDataField dfAccYear;
		protected cBackgroundText labeldfStartYear;
		public cDataField dfStartYear;
		public cDataField dfStartMonth;
		protected cBackgroundText labeldfNumberOfYears;
		public cDataField dfNumberOfYears;
		protected SalGroupBox gbCalendar_Creation_Method;
		// Step 5 is form frmCompanyInfo
		public cPushButton pbSelectAll;
		public cPushButton pbUnSelectAll;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgCreateCompany));
            this.labeldfHeading1 = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfHeading1 = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsNewCompanyId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsNewCompanyId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsNewCompanyName = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsNewCompanyName = new Ifs.Fnd.ApplicationForms.cDataField();
            this.cbTemplateCompany = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.labeldfHeading2 = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfHeading2 = new Ifs.Fnd.ApplicationForms.cDataField();
            this.gbCreate_From = new PPJ.Runtime.Windows.SalGroupBox();
            this.rbCopyCompany = new Ifs.Fnd.ApplicationForms.cRadioButton();
            this.rbImportTemplate = new Ifs.Fnd.ApplicationForms.cRadioButton();
            this.labeldfsSourceCompanyId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsSourceCompanyId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsSourceCompanyName = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsSourceCompanyName = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsTemplateId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsTemplateId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsTemplateName = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsTemplateName = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsDomainId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsDomainId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labellbLanguages = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.lbLanguages = new PPJ.Runtime.Vis.VisRadioListBox();
            this.labeldfsDummyLang = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsDummyLang = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsAccountingCurrency = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsAccountingCurrency = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfdtValidFrom = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfdtValidFrom = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsParallelAccCurrency = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsParallelAccCurrency = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfdtTimeStamp = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelcmbDefaultLanguage = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbDefaultLanguage = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.labelcmbCountry = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbCountry = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.cbUsePeriod = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.rbSourceTemplateCompany = new Ifs.Fnd.ApplicationForms.cRadioButton();
            this.rbUserDefined = new Ifs.Fnd.ApplicationForms.cRadioButton();
            this.labeldfAccYear = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfAccYear = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfStartYear = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfStartYear = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfStartMonth = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfNumberOfYears = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfNumberOfYears = new Ifs.Fnd.ApplicationForms.cDataField();
            this.gbCalendar_Creation_Method = new PPJ.Runtime.Windows.SalGroupBox();
            this.pbSelectAll = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbUnSelectAll = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.StepOne = new Ifs.Fnd.ApplicationForms.@__cWizardStep();
            this.StepTwo = new Ifs.Fnd.ApplicationForms.@__cWizardStep();
            this.StepThree = new Ifs.Fnd.ApplicationForms.@__cWizardStep();
            this.StepFour = new Ifs.Fnd.ApplicationForms.@__cWizardStep();
            this.StepFive = new Ifs.Fnd.ApplicationForms.@__cWizardStep();
            this.cbMasterCompany = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.labelParallelCurrBase = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbParallelCurBase = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.dfHeading3 = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfHeading3 = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.StepSix = new Ifs.Fnd.ApplicationForms.@__cWizardStep();
            this.gbCurrBalSelected = new Ifs.Fnd.ApplicationForms.cGroupBox();
            this.dfsInternalName = new Ifs.Fnd.ApplicationForms.cDataField();
            this.lblInternalName = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsCodePart = new Ifs.Fnd.ApplicationForms.cDataField();
            this.lblCodePart = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.lblCurrBalCodePart = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.rbNo = new Ifs.Fnd.ApplicationForms.cRadioButton();
            this.rbYes = new Ifs.Fnd.ApplicationForms.cRadioButton();
            this.gbCurrBalAccountsEnable = new Ifs.Fnd.ApplicationForms.cGroupBox();
            this.cbStatOpenBal = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.cbStatistics = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.cbCost = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.cbRevenues = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.cbLiabilities = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.cbAssets = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.lblCurrBalHeader = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            ((System.ComponentModel.ISupportInitialize)(this.picWizard)).BeginInit();
            this.ToolBar.SuspendLayout();
            this.ClientArea.SuspendLayout();
            this.gbCurrBalSelected.SuspendLayout();
            this.gbCurrBalAccountsEnable.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbFinish
            // 
            resources.ApplyResources(this.pbFinish, "pbFinish");
            // 
            // pbNext
            // 
            resources.ApplyResources(this.pbNext, "pbNext");
            // 
            // pbBack
            // 
            resources.ApplyResources(this.pbBack, "pbBack");
            // 
            // pbCancel
            // 
            resources.ApplyResources(this.pbCancel, "pbCancel");
            // 
            // pbList
            // 
            resources.ApplyResources(this.pbList, "pbList");
            // 
            // picWizard
            // 
            resources.ApplyResources(this.picWizard, "picWizard");
            // 
            // ToolBar
            // 
            resources.ApplyResources(this.ToolBar, "ToolBar");
            // 
            // ClientArea
            // 
            this.ClientArea.Controls.Add(this.lblCurrBalHeader);
            this.ClientArea.Controls.Add(this.gbCurrBalAccountsEnable);
            this.ClientArea.Controls.Add(this.gbCurrBalSelected);
            this.ClientArea.Controls.Add(this.dfHeading3);
            this.ClientArea.Controls.Add(this.cbMasterCompany);
            this.ClientArea.Controls.Add(this.cbTemplateCompany);
            this.ClientArea.Controls.Add(this.dfsNewCompanyName);
            this.ClientArea.Controls.Add(this.labeldfsNewCompanyName);
            this.ClientArea.Controls.Add(this.labeldfsNewCompanyId);
            this.ClientArea.Controls.Add(this.dfsNewCompanyId);
            this.ClientArea.Controls.Add(this.cmbParallelCurBase);
            this.ClientArea.Controls.Add(this.labelParallelCurrBase);
            this.ClientArea.Controls.Add(this.pbUnSelectAll);
            this.ClientArea.Controls.Add(this.pbSelectAll);
            this.ClientArea.Controls.Add(this.dfNumberOfYears);
            this.ClientArea.Controls.Add(this.dfStartMonth);
            this.ClientArea.Controls.Add(this.dfStartYear);
            this.ClientArea.Controls.Add(this.dfAccYear);
            this.ClientArea.Controls.Add(this.rbUserDefined);
            this.ClientArea.Controls.Add(this.rbSourceTemplateCompany);
            this.ClientArea.Controls.Add(this.cbUsePeriod);
            this.ClientArea.Controls.Add(this.cmbCountry);
            this.ClientArea.Controls.Add(this.cmbDefaultLanguage);
            this.ClientArea.Controls.Add(this.dfdtTimeStamp);
            this.ClientArea.Controls.Add(this.dfsParallelAccCurrency);
            this.ClientArea.Controls.Add(this.dfdtValidFrom);
            this.ClientArea.Controls.Add(this.dfsAccountingCurrency);
            this.ClientArea.Controls.Add(this.dfsDummyLang);
            this.ClientArea.Controls.Add(this.dfsDomainId);
            this.ClientArea.Controls.Add(this.dfsTemplateName);
            this.ClientArea.Controls.Add(this.dfsTemplateId);
            this.ClientArea.Controls.Add(this.dfsSourceCompanyName);
            this.ClientArea.Controls.Add(this.dfsSourceCompanyId);
            this.ClientArea.Controls.Add(this.rbImportTemplate);
            this.ClientArea.Controls.Add(this.rbCopyCompany);
            this.ClientArea.Controls.Add(this.dfHeading2);
            this.ClientArea.Controls.Add(this.dfHeading1);
            this.ClientArea.Controls.Add(this.labeldfNumberOfYears);
            this.ClientArea.Controls.Add(this.labeldfStartYear);
            this.ClientArea.Controls.Add(this.labeldfAccYear);
            this.ClientArea.Controls.Add(this.labelcmbCountry);
            this.ClientArea.Controls.Add(this.labelcmbDefaultLanguage);
            this.ClientArea.Controls.Add(this.labeldfsParallelAccCurrency);
            this.ClientArea.Controls.Add(this.labeldfdtValidFrom);
            this.ClientArea.Controls.Add(this.labeldfsAccountingCurrency);
            this.ClientArea.Controls.Add(this.labeldfsDummyLang);
            this.ClientArea.Controls.Add(this.labellbLanguages);
            this.ClientArea.Controls.Add(this.labeldfsDomainId);
            this.ClientArea.Controls.Add(this.labeldfsTemplateName);
            this.ClientArea.Controls.Add(this.labeldfsTemplateId);
            this.ClientArea.Controls.Add(this.labeldfsSourceCompanyName);
            this.ClientArea.Controls.Add(this.labeldfsSourceCompanyId);
            this.ClientArea.Controls.Add(this.labeldfHeading2);
            this.ClientArea.Controls.Add(this.labeldfHeading1);
            this.ClientArea.Controls.Add(this.gbCreate_From);
            this.ClientArea.Controls.Add(this.lbLanguages);
            this.ClientArea.Controls.Add(this.labeldfHeading3);
            this.ClientArea.Controls.Add(this.gbCalendar_Creation_Method);
            resources.ApplyResources(this.ClientArea, "ClientArea");
            this.ClientArea.Controls.SetChildIndex(this.gbCalendar_Creation_Method, 0);
            this.ClientArea.Controls.SetChildIndex(this.labeldfHeading3, 0);
            this.ClientArea.Controls.SetChildIndex(this.lbLanguages, 0);
            this.ClientArea.Controls.SetChildIndex(this.picWizard, 0);
            this.ClientArea.Controls.SetChildIndex(this.gbCreate_From, 0);
            this.ClientArea.Controls.SetChildIndex(this.labeldfHeading1, 0);
            this.ClientArea.Controls.SetChildIndex(this.labeldfHeading2, 0);
            this.ClientArea.Controls.SetChildIndex(this.labeldfsSourceCompanyId, 0);
            this.ClientArea.Controls.SetChildIndex(this.labeldfsSourceCompanyName, 0);
            this.ClientArea.Controls.SetChildIndex(this.labeldfsTemplateId, 0);
            this.ClientArea.Controls.SetChildIndex(this.labeldfsTemplateName, 0);
            this.ClientArea.Controls.SetChildIndex(this.labeldfsDomainId, 0);
            this.ClientArea.Controls.SetChildIndex(this.labellbLanguages, 0);
            this.ClientArea.Controls.SetChildIndex(this.labeldfsDummyLang, 0);
            this.ClientArea.Controls.SetChildIndex(this.labeldfsAccountingCurrency, 0);
            this.ClientArea.Controls.SetChildIndex(this.labeldfdtValidFrom, 0);
            this.ClientArea.Controls.SetChildIndex(this.labeldfsParallelAccCurrency, 0);
            this.ClientArea.Controls.SetChildIndex(this.labelcmbDefaultLanguage, 0);
            this.ClientArea.Controls.SetChildIndex(this.labelcmbCountry, 0);
            this.ClientArea.Controls.SetChildIndex(this.labeldfAccYear, 0);
            this.ClientArea.Controls.SetChildIndex(this.labeldfStartYear, 0);
            this.ClientArea.Controls.SetChildIndex(this.labeldfNumberOfYears, 0);
            this.ClientArea.Controls.SetChildIndex(this.dfHeading1, 0);
            this.ClientArea.Controls.SetChildIndex(this.dfHeading2, 0);
            this.ClientArea.Controls.SetChildIndex(this.rbCopyCompany, 0);
            this.ClientArea.Controls.SetChildIndex(this.rbImportTemplate, 0);
            this.ClientArea.Controls.SetChildIndex(this.dfsSourceCompanyId, 0);
            this.ClientArea.Controls.SetChildIndex(this.dfsSourceCompanyName, 0);
            this.ClientArea.Controls.SetChildIndex(this.dfsTemplateId, 0);
            this.ClientArea.Controls.SetChildIndex(this.dfsTemplateName, 0);
            this.ClientArea.Controls.SetChildIndex(this.dfsDomainId, 0);
            this.ClientArea.Controls.SetChildIndex(this.dfsDummyLang, 0);
            this.ClientArea.Controls.SetChildIndex(this.dfsAccountingCurrency, 0);
            this.ClientArea.Controls.SetChildIndex(this.dfdtValidFrom, 0);
            this.ClientArea.Controls.SetChildIndex(this.dfsParallelAccCurrency, 0);
            this.ClientArea.Controls.SetChildIndex(this.dfdtTimeStamp, 0);
            this.ClientArea.Controls.SetChildIndex(this.cmbDefaultLanguage, 0);
            this.ClientArea.Controls.SetChildIndex(this.cmbCountry, 0);
            this.ClientArea.Controls.SetChildIndex(this.cbUsePeriod, 0);
            this.ClientArea.Controls.SetChildIndex(this.rbSourceTemplateCompany, 0);
            this.ClientArea.Controls.SetChildIndex(this.rbUserDefined, 0);
            this.ClientArea.Controls.SetChildIndex(this.dfAccYear, 0);
            this.ClientArea.Controls.SetChildIndex(this.dfStartYear, 0);
            this.ClientArea.Controls.SetChildIndex(this.dfStartMonth, 0);
            this.ClientArea.Controls.SetChildIndex(this.dfNumberOfYears, 0);
            this.ClientArea.Controls.SetChildIndex(this.pbSelectAll, 0);
            this.ClientArea.Controls.SetChildIndex(this.pbUnSelectAll, 0);
            this.ClientArea.Controls.SetChildIndex(this.labelParallelCurrBase, 0);
            this.ClientArea.Controls.SetChildIndex(this.cmbParallelCurBase, 0);
            this.ClientArea.Controls.SetChildIndex(this.dfsNewCompanyId, 0);
            this.ClientArea.Controls.SetChildIndex(this.labeldfsNewCompanyId, 0);
            this.ClientArea.Controls.SetChildIndex(this.labeldfsNewCompanyName, 0);
            this.ClientArea.Controls.SetChildIndex(this.dfsNewCompanyName, 0);
            this.ClientArea.Controls.SetChildIndex(this.cbTemplateCompany, 0);
            this.ClientArea.Controls.SetChildIndex(this.cbMasterCompany, 0);
            this.ClientArea.Controls.SetChildIndex(this.dfHeading3, 0);
            this.ClientArea.Controls.SetChildIndex(this.gbCurrBalSelected, 0);
            this.ClientArea.Controls.SetChildIndex(this.gbCurrBalAccountsEnable, 0);
            this.ClientArea.Controls.SetChildIndex(this.lblCurrBalHeader, 0);
            // 
            // StatusBar
            // 
            this.StatusBar.ShowKeyboardStatus = false;
            // 
            // commandManager
            // 
            this.commandManager.Components.Add(this.pbUnSelectAll);
            this.commandManager.Components.Add(this.pbSelectAll);
            this.commandManager.ImageList = null;
            // 
            // labeldfHeading1
            // 
            resources.ApplyResources(this.labeldfHeading1, "labeldfHeading1");
            this.labeldfHeading1.Name = "labeldfHeading1";
            // 
            // dfHeading1
            // 
            resources.ApplyResources(this.dfHeading1, "dfHeading1");
            this.dfHeading1.Name = "dfHeading1";
            // 
            // labeldfsNewCompanyId
            // 
            resources.ApplyResources(this.labeldfsNewCompanyId, "labeldfsNewCompanyId");
            this.labeldfsNewCompanyId.Name = "labeldfsNewCompanyId";
            // 
            // dfsNewCompanyId
            // 
            this.dfsNewCompanyId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsNewCompanyId, "dfsNewCompanyId");
            this.dfsNewCompanyId.Name = "dfsNewCompanyId";
            this.dfsNewCompanyId.NamedProperties.Put("EnumerateMethod", "");
            this.dfsNewCompanyId.NamedProperties.Put("FieldFlags", "262");
            this.dfsNewCompanyId.NamedProperties.Put("LovReference", "COMPANY");
            this.dfsNewCompanyId.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsNewCompanyId.NamedProperties.Put("SqlColumn", "COMPANY");
            this.dfsNewCompanyId.NamedProperties.Put("ValidateMethod", "");
            this.dfsNewCompanyId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsNewCompanyId_WindowActions);
            // 
            // labeldfsNewCompanyName
            // 
            resources.ApplyResources(this.labeldfsNewCompanyName, "labeldfsNewCompanyName");
            this.labeldfsNewCompanyName.Name = "labeldfsNewCompanyName";
            // 
            // dfsNewCompanyName
            // 
            resources.ApplyResources(this.dfsNewCompanyName, "dfsNewCompanyName");
            this.dfsNewCompanyName.Name = "dfsNewCompanyName";
            this.dfsNewCompanyName.NamedProperties.Put("EnumerateMethod", "");
            this.dfsNewCompanyName.NamedProperties.Put("FieldFlags", "263");
            this.dfsNewCompanyName.NamedProperties.Put("LovReference", "");
            this.dfsNewCompanyName.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsNewCompanyName.NamedProperties.Put("SqlColumn", "");
            this.dfsNewCompanyName.NamedProperties.Put("ValidateMethod", "");
            this.dfsNewCompanyName.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsNewCompanyName_WindowActions);
            // 
            // cbTemplateCompany
            // 
            resources.ApplyResources(this.cbTemplateCompany, "cbTemplateCompany");
            this.cbTemplateCompany.Name = "cbTemplateCompany";
            this.cbTemplateCompany.NamedProperties.Put("DataType", "5");
            this.cbTemplateCompany.NamedProperties.Put("EnumerateMethod", "");
            this.cbTemplateCompany.NamedProperties.Put("FieldFlags", "260");
            this.cbTemplateCompany.NamedProperties.Put("LovReference", "");
            this.cbTemplateCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.cbTemplateCompany.NamedProperties.Put("SqlColumn", "");
            this.cbTemplateCompany.NamedProperties.Put("ValidateMethod", "");
            this.cbTemplateCompany.NamedProperties.Put("XDataLength", "");
            // 
            // labeldfHeading2
            // 
            resources.ApplyResources(this.labeldfHeading2, "labeldfHeading2");
            this.labeldfHeading2.Name = "labeldfHeading2";
            // 
            // dfHeading2
            // 
            resources.ApplyResources(this.dfHeading2, "dfHeading2");
            this.dfHeading2.Name = "dfHeading2";
            // 
            // gbCreate_From
            // 
            resources.ApplyResources(this.gbCreate_From, "gbCreate_From");
            this.gbCreate_From.Name = "gbCreate_From";
            this.gbCreate_From.TabStop = false;
            // 
            // rbCopyCompany
            // 
            resources.ApplyResources(this.rbCopyCompany, "rbCopyCompany");
            this.rbCopyCompany.Name = "rbCopyCompany";
            this.rbCopyCompany.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.rbCopyCompany_WindowActions);
            // 
            // rbImportTemplate
            // 
            resources.ApplyResources(this.rbImportTemplate, "rbImportTemplate");
            this.rbImportTemplate.Name = "rbImportTemplate";
            this.rbImportTemplate.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.rbImportTemplate_WindowActions);
            // 
            // labeldfsSourceCompanyId
            // 
            resources.ApplyResources(this.labeldfsSourceCompanyId, "labeldfsSourceCompanyId");
            this.labeldfsSourceCompanyId.Name = "labeldfsSourceCompanyId";
            // 
            // dfsSourceCompanyId
            // 
            this.dfsSourceCompanyId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsSourceCompanyId, "dfsSourceCompanyId");
            this.dfsSourceCompanyId.Name = "dfsSourceCompanyId";
            this.dfsSourceCompanyId.NamedProperties.Put("EnumerateMethod", "");
            this.dfsSourceCompanyId.NamedProperties.Put("FieldFlags", "262");
            this.dfsSourceCompanyId.NamedProperties.Put("LovReference", "COMPANY");
            this.dfsSourceCompanyId.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsSourceCompanyId.NamedProperties.Put("SqlColumn", "COMPANY");
            this.dfsSourceCompanyId.NamedProperties.Put("ValidateMethod", "");
            this.dfsSourceCompanyId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsSourceCompanyId_WindowActions);
            // 
            // labeldfsSourceCompanyName
            // 
            resources.ApplyResources(this.labeldfsSourceCompanyName, "labeldfsSourceCompanyName");
            this.labeldfsSourceCompanyName.Name = "labeldfsSourceCompanyName";
            // 
            // dfsSourceCompanyName
            // 
            resources.ApplyResources(this.dfsSourceCompanyName, "dfsSourceCompanyName");
            this.dfsSourceCompanyName.Name = "dfsSourceCompanyName";
            this.dfsSourceCompanyName.NamedProperties.Put("EnumerateMethod", "");
            this.dfsSourceCompanyName.NamedProperties.Put("FieldFlags", "259");
            this.dfsSourceCompanyName.NamedProperties.Put("LovReference", "");
            this.dfsSourceCompanyName.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsSourceCompanyName.NamedProperties.Put("SqlColumn", "");
            this.dfsSourceCompanyName.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsTemplateId
            // 
            resources.ApplyResources(this.labeldfsTemplateId, "labeldfsTemplateId");
            this.labeldfsTemplateId.Name = "labeldfsTemplateId";
            // 
            // dfsTemplateId
            // 
            this.dfsTemplateId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsTemplateId, "dfsTemplateId");
            this.dfsTemplateId.Name = "dfsTemplateId";
            this.dfsTemplateId.NamedProperties.Put("EnumerateMethod", "");
            this.dfsTemplateId.NamedProperties.Put("FieldFlags", "262");
            this.dfsTemplateId.NamedProperties.Put("LovReference", "CREATE_COMPANY_TEM_VALID");
            this.dfsTemplateId.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsTemplateId.NamedProperties.Put("SqlColumn", "TEMPLATE_ID");
            this.dfsTemplateId.NamedProperties.Put("ValidateMethod", "");
            this.dfsTemplateId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsTemplateId_WindowActions);
            // 
            // labeldfsTemplateName
            // 
            resources.ApplyResources(this.labeldfsTemplateName, "labeldfsTemplateName");
            this.labeldfsTemplateName.Name = "labeldfsTemplateName";
            // 
            // dfsTemplateName
            // 
            resources.ApplyResources(this.dfsTemplateName, "dfsTemplateName");
            this.dfsTemplateName.Name = "dfsTemplateName";
            this.dfsTemplateName.NamedProperties.Put("EnumerateMethod", "");
            this.dfsTemplateName.NamedProperties.Put("FieldFlags", "259");
            this.dfsTemplateName.NamedProperties.Put("LovReference", "");
            this.dfsTemplateName.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsTemplateName.NamedProperties.Put("SqlColumn", "");
            this.dfsTemplateName.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsDomainId
            // 
            resources.ApplyResources(this.labeldfsDomainId, "labeldfsDomainId");
            this.labeldfsDomainId.Name = "labeldfsDomainId";
            // 
            // dfsDomainId
            // 
            resources.ApplyResources(this.dfsDomainId, "dfsDomainId");
            this.dfsDomainId.Name = "dfsDomainId";
            this.dfsDomainId.NamedProperties.Put("EnumerateMethod", "");
            this.dfsDomainId.NamedProperties.Put("FieldFlags", "260");
            this.dfsDomainId.NamedProperties.Put("LovReference", "");
            this.dfsDomainId.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsDomainId.NamedProperties.Put("SqlColumn", "DOMAIN_ID");
            this.dfsDomainId.NamedProperties.Put("ValidateMethod", "");
            // 
            // labellbLanguages
            // 
            resources.ApplyResources(this.labellbLanguages, "labellbLanguages");
            this.labellbLanguages.Name = "labellbLanguages";
            // 
            // lbLanguages
            // 
            resources.ApplyResources(this.lbLanguages, "lbLanguages");
            this.lbLanguages.Name = "lbLanguages";
            this.lbLanguages.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbLanguages.UseCustomTabOffsets = true;
            this.lbLanguages.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.lbLanguages_WindowActions);
            // 
            // labeldfsDummyLang
            // 
            resources.ApplyResources(this.labeldfsDummyLang, "labeldfsDummyLang");
            this.labeldfsDummyLang.Name = "labeldfsDummyLang";
            // 
            // dfsDummyLang
            // 
            resources.ApplyResources(this.dfsDummyLang, "dfsDummyLang");
            this.dfsDummyLang.Name = "dfsDummyLang";
            // 
            // labeldfsAccountingCurrency
            // 
            resources.ApplyResources(this.labeldfsAccountingCurrency, "labeldfsAccountingCurrency");
            this.labeldfsAccountingCurrency.Name = "labeldfsAccountingCurrency";
            // 
            // dfsAccountingCurrency
            // 
            this.dfsAccountingCurrency.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsAccountingCurrency, "dfsAccountingCurrency");
            this.dfsAccountingCurrency.Name = "dfsAccountingCurrency";
            this.dfsAccountingCurrency.NamedProperties.Put("EnumerateMethod", "");
            this.dfsAccountingCurrency.NamedProperties.Put("FieldFlags", "263");
            this.dfsAccountingCurrency.NamedProperties.Put("LovReference", "ISO_CURRENCY");
            this.dfsAccountingCurrency.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsAccountingCurrency.NamedProperties.Put("SqlColumn", "CURRENCY_CODE");
            this.dfsAccountingCurrency.NamedProperties.Put("ValidateMethod", "");
            this.dfsAccountingCurrency.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsAccountingCurrency_WindowActions);
            // 
            // labeldfdtValidFrom
            // 
            resources.ApplyResources(this.labeldfdtValidFrom, "labeldfdtValidFrom");
            this.labeldfdtValidFrom.Name = "labeldfdtValidFrom";
            // 
            // dfdtValidFrom
            // 
            this.dfdtValidFrom.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.dfdtValidFrom.Format = "d";
            resources.ApplyResources(this.dfdtValidFrom, "dfdtValidFrom");
            this.dfdtValidFrom.Name = "dfdtValidFrom";
            this.dfdtValidFrom.NamedProperties.Put("EnumerateMethod", "");
            this.dfdtValidFrom.NamedProperties.Put("FieldFlags", "263");
            this.dfdtValidFrom.NamedProperties.Put("LovReference", "");
            this.dfdtValidFrom.NamedProperties.Put("ResizeableChildObject", "");
            this.dfdtValidFrom.NamedProperties.Put("SqlColumn", "");
            this.dfdtValidFrom.NamedProperties.Put("ValidateMethod", "");
            this.dfdtValidFrom.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfdtValidFrom_WindowActions);
            // 
            // labeldfsParallelAccCurrency
            // 
            resources.ApplyResources(this.labeldfsParallelAccCurrency, "labeldfsParallelAccCurrency");
            this.labeldfsParallelAccCurrency.Name = "labeldfsParallelAccCurrency";
            // 
            // dfsParallelAccCurrency
            // 
            this.dfsParallelAccCurrency.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsParallelAccCurrency, "dfsParallelAccCurrency");
            this.dfsParallelAccCurrency.Name = "dfsParallelAccCurrency";
            this.dfsParallelAccCurrency.NamedProperties.Put("EnumerateMethod", "ISO_CURRENCY_API.Enumerate");
            this.dfsParallelAccCurrency.NamedProperties.Put("FieldFlags", "262");
            this.dfsParallelAccCurrency.NamedProperties.Put("LovReference", "ISO_CURRENCY");
            this.dfsParallelAccCurrency.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsParallelAccCurrency.NamedProperties.Put("SqlColumn", "PARALLEL_ACC_CURRENCY");
            this.dfsParallelAccCurrency.NamedProperties.Put("ValidateMethod", "");
            this.dfsParallelAccCurrency.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsParallelAccCurrency_WindowActions);
            // 
            // dfdtTimeStamp
            // 
            this.dfdtTimeStamp.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.dfdtTimeStamp.Format = "d";
            resources.ApplyResources(this.dfdtTimeStamp, "dfdtTimeStamp");
            this.dfdtTimeStamp.Name = "dfdtTimeStamp";
            this.dfdtTimeStamp.NamedProperties.Put("EnumerateMethod", "");
            this.dfdtTimeStamp.NamedProperties.Put("FieldFlags", "263");
            this.dfdtTimeStamp.NamedProperties.Put("LovReference", "");
            this.dfdtTimeStamp.NamedProperties.Put("ResizeableChildObject", "");
            this.dfdtTimeStamp.NamedProperties.Put("SqlColumn", "");
            this.dfdtTimeStamp.NamedProperties.Put("ValidateMethod", "");
            // 
            // labelcmbDefaultLanguage
            // 
            resources.ApplyResources(this.labelcmbDefaultLanguage, "labelcmbDefaultLanguage");
            this.labelcmbDefaultLanguage.Name = "labelcmbDefaultLanguage";
            // 
            // cmbDefaultLanguage
            // 
            this.cmbDefaultLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cmbDefaultLanguage, "cmbDefaultLanguage");
            this.cmbDefaultLanguage.Name = "cmbDefaultLanguage";
            this.cmbDefaultLanguage.NamedProperties.Put("EnumerateMethod", "ISO_LANGUAGE_API.Enumerate");
            this.cmbDefaultLanguage.NamedProperties.Put("FieldFlags", "263");
            this.cmbDefaultLanguage.NamedProperties.Put("LovReference", "");
            this.cmbDefaultLanguage.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbDefaultLanguage.NamedProperties.Put("SqlColumn", "DEFAULT_LANGUAGE");
            this.cmbDefaultLanguage.NamedProperties.Put("ValidateMethod", "");
            this.cmbDefaultLanguage.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbDefaultLanguage_WindowActions);
            // 
            // labelcmbCountry
            // 
            resources.ApplyResources(this.labelcmbCountry, "labelcmbCountry");
            this.labelcmbCountry.Name = "labelcmbCountry";
            // 
            // cmbCountry
            // 
            this.cmbCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cmbCountry, "cmbCountry");
            this.cmbCountry.Name = "cmbCountry";
            this.cmbCountry.NamedProperties.Put("EnumerateMethod", "ISO_COUNTRY_API.Enumerate");
            this.cmbCountry.NamedProperties.Put("FieldFlags", "263");
            this.cmbCountry.NamedProperties.Put("LovReference", "");
            this.cmbCountry.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbCountry.NamedProperties.Put("SqlColumn", "COUNTRY");
            this.cmbCountry.NamedProperties.Put("ValidateMethod", "");
            this.cmbCountry.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbCountry_WindowActions);
            // 
            // cbUsePeriod
            // 
            resources.ApplyResources(this.cbUsePeriod, "cbUsePeriod");
            this.cbUsePeriod.Name = "cbUsePeriod";
            this.cbUsePeriod.NamedProperties.Put("DataType", "5");
            this.cbUsePeriod.NamedProperties.Put("EnumerateMethod", "");
            this.cbUsePeriod.NamedProperties.Put("FieldFlags", "262");
            this.cbUsePeriod.NamedProperties.Put("LovReference", "");
            this.cbUsePeriod.NamedProperties.Put("ResizeableChildObject", "");
            this.cbUsePeriod.NamedProperties.Put("SqlColumn", "USE_VOU_NO_PERIOD");
            this.cbUsePeriod.NamedProperties.Put("ValidateMethod", "");
            this.cbUsePeriod.NamedProperties.Put("XDataLength", "5");
            // 
            // rbSourceTemplateCompany
            // 
            resources.ApplyResources(this.rbSourceTemplateCompany, "rbSourceTemplateCompany");
            this.rbSourceTemplateCompany.Name = "rbSourceTemplateCompany";
            this.rbSourceTemplateCompany.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.rbSourceTemplateCompany_WindowActions);
            // 
            // rbUserDefined
            // 
            resources.ApplyResources(this.rbUserDefined, "rbUserDefined");
            this.rbUserDefined.Name = "rbUserDefined";
            this.rbUserDefined.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.rbUserDefined_WindowActions);
            // 
            // labeldfAccYear
            // 
            resources.ApplyResources(this.labeldfAccYear, "labeldfAccYear");
            this.labeldfAccYear.Name = "labeldfAccYear";
            // 
            // dfAccYear
            // 
            this.dfAccYear.BackColor = System.Drawing.SystemColors.Control;
            this.dfAccYear.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfAccYear, "dfAccYear");
            this.dfAccYear.Name = "dfAccYear";
            this.dfAccYear.NamedProperties.Put("EnumerateMethod", "");
            this.dfAccYear.NamedProperties.Put("FieldFlags", "262");
            this.dfAccYear.NamedProperties.Put("LovReference", "");
            this.dfAccYear.NamedProperties.Put("ResizeableChildObject", "");
            this.dfAccYear.NamedProperties.Put("SqlColumn", "");
            this.dfAccYear.NamedProperties.Put("ValidateMethod", "");
            this.dfAccYear.ReadOnly = true;
            this.dfAccYear.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfAccYear_WindowActions);
            // 
            // labeldfStartYear
            // 
            resources.ApplyResources(this.labeldfStartYear, "labeldfStartYear");
            this.labeldfStartYear.Name = "labeldfStartYear";
            // 
            // dfStartYear
            // 
            this.dfStartYear.BackColor = System.Drawing.SystemColors.Control;
            this.dfStartYear.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfStartYear, "dfStartYear");
            this.dfStartYear.Name = "dfStartYear";
            this.dfStartYear.NamedProperties.Put("EnumerateMethod", "");
            this.dfStartYear.NamedProperties.Put("FieldFlags", "262");
            this.dfStartYear.NamedProperties.Put("LovReference", "");
            this.dfStartYear.NamedProperties.Put("ResizeableChildObject", "");
            this.dfStartYear.NamedProperties.Put("SqlColumn", "");
            this.dfStartYear.NamedProperties.Put("ValidateMethod", "");
            this.dfStartYear.ReadOnly = true;
            this.dfStartYear.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfStartYear_WindowActions);
            // 
            // dfStartMonth
            // 
            this.dfStartMonth.BackColor = System.Drawing.SystemColors.Control;
            this.dfStartMonth.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfStartMonth, "dfStartMonth");
            this.dfStartMonth.Name = "dfStartMonth";
            this.dfStartMonth.NamedProperties.Put("EnumerateMethod", "");
            this.dfStartMonth.NamedProperties.Put("FieldFlags", "262");
            this.dfStartMonth.NamedProperties.Put("LovReference", "");
            this.dfStartMonth.NamedProperties.Put("ResizeableChildObject", "");
            this.dfStartMonth.NamedProperties.Put("SqlColumn", "");
            this.dfStartMonth.NamedProperties.Put("ValidateMethod", "");
            this.dfStartMonth.ReadOnly = true;
            this.dfStartMonth.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfStartMonth_WindowActions);
            // 
            // labeldfNumberOfYears
            // 
            resources.ApplyResources(this.labeldfNumberOfYears, "labeldfNumberOfYears");
            this.labeldfNumberOfYears.Name = "labeldfNumberOfYears";
            // 
            // dfNumberOfYears
            // 
            this.dfNumberOfYears.BackColor = System.Drawing.SystemColors.Control;
            this.dfNumberOfYears.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfNumberOfYears, "dfNumberOfYears");
            this.dfNumberOfYears.Name = "dfNumberOfYears";
            this.dfNumberOfYears.NamedProperties.Put("EnumerateMethod", "");
            this.dfNumberOfYears.NamedProperties.Put("FieldFlags", "262");
            this.dfNumberOfYears.NamedProperties.Put("LovReference", "");
            this.dfNumberOfYears.NamedProperties.Put("ResizeableChildObject", "");
            this.dfNumberOfYears.NamedProperties.Put("SqlColumn", "");
            this.dfNumberOfYears.NamedProperties.Put("ValidateMethod", "");
            this.dfNumberOfYears.ReadOnly = true;
            this.dfNumberOfYears.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfNumberOfYears_WindowActions);
            // 
            // gbCalendar_Creation_Method
            // 
            resources.ApplyResources(this.gbCalendar_Creation_Method, "gbCalendar_Creation_Method");
            this.gbCalendar_Creation_Method.Name = "gbCalendar_Creation_Method";
            this.gbCalendar_Creation_Method.TabStop = false;
            // 
            // pbSelectAll
            // 
            resources.ApplyResources(this.pbSelectAll, "pbSelectAll");
            this.pbSelectAll.Name = "pbSelectAll";
            this.pbSelectAll.NamedProperties.Put("MethodId", "18385");
            this.pbSelectAll.NamedProperties.Put("MethodParameter", "select");
            this.pbSelectAll.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // pbUnSelectAll
            // 
            resources.ApplyResources(this.pbUnSelectAll, "pbUnSelectAll");
            this.pbUnSelectAll.Name = "pbUnSelectAll";
            this.pbUnSelectAll.NamedProperties.Put("MethodId", "18385");
            this.pbUnSelectAll.NamedProperties.Put("MethodParameter", "unselect");
            this.pbUnSelectAll.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // StepOne
            // 
            this.StepOne.Controls = new string[] {
        "cbTemplateCompany",
        "dfHeading1",
        "dfsNewCompanyId",
        "dfsNewCompanyName",
        "cbMasterCompany",
        "dfHeading3"};
            this.StepOne.StepDescription = "StepOne";
            resources.ApplyResources(this.StepOne, "StepOne");
            this.StepOne.UseInternalControls = true;
            // 
            // StepTwo
            // 
            this.StepTwo.Controls = new string[] {
        "gbCreate_From",
        "dfHeading2",
        "dfsSourceCompanyId",
        "dfsSourceCompanyName",
        "dfsTemplateId",
        "dfsTemplateName",
        "rbCopyCompany",
        "rbImportTemplate"};
            this.StepTwo.StepDescription = "StepTwo";
            resources.ApplyResources(this.StepTwo, "StepTwo");
            this.StepTwo.UseInternalControls = true;
            // 
            // StepThree
            // 
            this.StepThree.Controls = new string[] {
        "dfsDummyLang",
        "lbLanguages",
        "pbSelectAll",
        "pbUnSelectAll"};
            this.StepThree.StepDescription = "StepThree";
            resources.ApplyResources(this.StepThree, "StepThree");
            this.StepThree.UseInternalControls = true;
            // 
            // StepFour
            // 
            this.StepFour.Controls = new string[] {
        "gbCalendar_Creation_Method",
        "cbUsePeriod",
        "cmbCountry",
        "cmbDefaultLanguage",
        "dfAccYear",
        "dfdtValidFrom",
        "dfNumberOfYears",
        "dfsAccountingCurrency",
        "dfsParallelAccCurrency",
        "dfStartMonth",
        "dfStartYear",
        "rbSourceTemplateCompany",
        "rbUserDefined",
        "cmbParallelCurBase",
        "labelParallelCurrBase"};
            this.StepFour.StepDescription = "StepFour";
            resources.ApplyResources(this.StepFour, "StepFour");
            this.StepFour.UseInternalControls = true;
            // 
            // StepFive
            // 
            this.StepFive.Controls = new string[] {
        "frmCompanyInfo",
        "gbCurrBalSelected",
        "rbNo",
        "rbYes",
        "cbAssets",
        "cbCost",
        "cbLiabilities",
        "cbStatOpenBal",
        "cbStatistics",
        "cbRevenues",
        "gbCurrBalAccountsEnable",
        "dfsInternalName",
        "dfsCodePart",
        "lblInternalName",
        "lblCurrBalCodePart",
        "lblCodePart",
        "lblCurrBalHeader"};
            this.StepFive.StepDescription = "StepFive";
            resources.ApplyResources(this.StepFive, "StepFive");
            this.StepFive.UseInternalControls = true;
            // 
            // cbMasterCompany
            // 
            resources.ApplyResources(this.cbMasterCompany, "cbMasterCompany");
            this.cbMasterCompany.Name = "cbMasterCompany";
            this.cbMasterCompany.NamedProperties.Put("DataType", "5");
            this.cbMasterCompany.NamedProperties.Put("EnumerateMethod", "");
            this.cbMasterCompany.NamedProperties.Put("FieldFlags", "260");
            this.cbMasterCompany.NamedProperties.Put("LovReference", "");
            this.cbMasterCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.cbMasterCompany.NamedProperties.Put("SqlColumn", "");
            this.cbMasterCompany.NamedProperties.Put("ValidateMethod", "");
            this.cbMasterCompany.NamedProperties.Put("XDataLength", "");
            // 
            // labelParallelCurrBase
            // 
            resources.ApplyResources(this.labelParallelCurrBase, "labelParallelCurrBase");
            this.labelParallelCurrBase.Name = "labelParallelCurrBase";
            // 
            // cmbParallelCurBase
            // 
            this.cmbParallelCurBase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cmbParallelCurBase, "cmbParallelCurBase");
            this.cmbParallelCurBase.Name = "cmbParallelCurBase";
            this.cmbParallelCurBase.NamedProperties.Put("EnumerateMethod", "PARALLEL_BASE_API.Enumerate");
            this.cmbParallelCurBase.NamedProperties.Put("FieldFlags", "262");
            this.cmbParallelCurBase.NamedProperties.Put("LovReference", "");
            this.cmbParallelCurBase.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbParallelCurBase.NamedProperties.Put("SqlColumn", "");
            this.cmbParallelCurBase.NamedProperties.Put("ValidateMethod", "");
            this.cmbParallelCurBase.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbParallelCurBase_WindowActions);
            // 
            // dfHeading3
            // 
            resources.ApplyResources(this.dfHeading3, "dfHeading3");
            this.dfHeading3.Name = "dfHeading3";
            // 
            // labeldfHeading3
            // 
            resources.ApplyResources(this.labeldfHeading3, "labeldfHeading3");
            this.labeldfHeading3.Name = "labeldfHeading3";
            // 
            // StepSix
            // 
            this.StepSix.Controls = new string[] {
        "frmCompanyInfo"};
            this.StepSix.StepDescription = "StepSix";
            resources.ApplyResources(this.StepSix, "StepSix");
            // 
            // gbCurrBalSelected
            // 
            this.gbCurrBalSelected.Controls.Add(this.dfsInternalName);
            this.gbCurrBalSelected.Controls.Add(this.lblInternalName);
            this.gbCurrBalSelected.Controls.Add(this.dfsCodePart);
            this.gbCurrBalSelected.Controls.Add(this.lblCodePart);
            this.gbCurrBalSelected.Controls.Add(this.lblCurrBalCodePart);
            this.gbCurrBalSelected.Controls.Add(this.rbNo);
            this.gbCurrBalSelected.Controls.Add(this.rbYes);
            resources.ApplyResources(this.gbCurrBalSelected, "gbCurrBalSelected");
            this.gbCurrBalSelected.Name = "gbCurrBalSelected";
            this.gbCurrBalSelected.TabStop = false;
            // 
            // dfsInternalName
            // 
            resources.ApplyResources(this.dfsInternalName, "dfsInternalName");
            this.dfsInternalName.Name = "dfsInternalName";
            this.dfsInternalName.NamedProperties.Put("EnumerateMethod", "");
            this.dfsInternalName.NamedProperties.Put("FieldFlags", "292");
            this.dfsInternalName.NamedProperties.Put("LovReference", "");
            this.dfsInternalName.NamedProperties.Put("LovTimeReference", "");
            this.dfsInternalName.NamedProperties.Put("SqlColumn", "");
            // 
            // lblInternalName
            // 
            resources.ApplyResources(this.lblInternalName, "lblInternalName");
            this.lblInternalName.Name = "lblInternalName";
            // 
            // dfsCodePart
            // 
            this.dfsCodePart.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsCodePart, "dfsCodePart");
            this.dfsCodePart.Name = "dfsCodePart";
            this.dfsCodePart.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCodePart.NamedProperties.Put("FieldFlags", "288");
            this.dfsCodePart.NamedProperties.Put("LovReference", "CURR_BAL_CODE_PART_LOV(TEMPLATE_ID)");
            this.dfsCodePart.NamedProperties.Put("LovTimeReference", "");
            this.dfsCodePart.NamedProperties.Put("SqlColumn", "");
            this.dfsCodePart.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsCodePart_WindowActions);
            // 
            // lblCodePart
            // 
            resources.ApplyResources(this.lblCodePart, "lblCodePart");
            this.lblCodePart.Name = "lblCodePart";
            // 
            // lblCurrBalCodePart
            // 
            resources.ApplyResources(this.lblCurrBalCodePart, "lblCurrBalCodePart");
            this.lblCurrBalCodePart.Name = "lblCurrBalCodePart";
            // 
            // rbNo
            // 
            resources.ApplyResources(this.rbNo, "rbNo");
            this.rbNo.Name = "rbNo";
            this.rbNo.TabStop = true;
            this.rbNo.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.rbNo_WindowActions);
            // 
            // rbYes
            // 
            resources.ApplyResources(this.rbYes, "rbYes");
            this.rbYes.Name = "rbYes";
            this.rbYes.TabStop = true;
            this.rbYes.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.rbYes_WindowActions);
            // 
            // gbCurrBalAccountsEnable
            // 
            this.gbCurrBalAccountsEnable.Controls.Add(this.cbStatOpenBal);
            this.gbCurrBalAccountsEnable.Controls.Add(this.cbStatistics);
            this.gbCurrBalAccountsEnable.Controls.Add(this.cbCost);
            this.gbCurrBalAccountsEnable.Controls.Add(this.cbRevenues);
            this.gbCurrBalAccountsEnable.Controls.Add(this.cbLiabilities);
            this.gbCurrBalAccountsEnable.Controls.Add(this.cbAssets);
            resources.ApplyResources(this.gbCurrBalAccountsEnable, "gbCurrBalAccountsEnable");
            this.gbCurrBalAccountsEnable.Name = "gbCurrBalAccountsEnable";
            this.gbCurrBalAccountsEnable.TabStop = false;
            // 
            // cbStatOpenBal
            // 
            resources.ApplyResources(this.cbStatOpenBal, "cbStatOpenBal");
            this.cbStatOpenBal.Name = "cbStatOpenBal";
            this.cbStatOpenBal.NamedProperties.Put("FieldFlags", "260");
            // 
            // cbStatistics
            // 
            resources.ApplyResources(this.cbStatistics, "cbStatistics");
            this.cbStatistics.Name = "cbStatistics";
            this.cbStatistics.NamedProperties.Put("FieldFlags", "260");
            // 
            // cbCost
            // 
            resources.ApplyResources(this.cbCost, "cbCost");
            this.cbCost.Name = "cbCost";
            this.cbCost.NamedProperties.Put("FieldFlags", "260");
            // 
            // cbRevenues
            // 
            resources.ApplyResources(this.cbRevenues, "cbRevenues");
            this.cbRevenues.Name = "cbRevenues";
            this.cbRevenues.NamedProperties.Put("FieldFlags", "260");
            // 
            // cbLiabilities
            // 
            resources.ApplyResources(this.cbLiabilities, "cbLiabilities");
            this.cbLiabilities.Name = "cbLiabilities";
            this.cbLiabilities.NamedProperties.Put("FieldFlags", "260");
            // 
            // cbAssets
            // 
            resources.ApplyResources(this.cbAssets, "cbAssets");
            this.cbAssets.Name = "cbAssets";
            this.cbAssets.NamedProperties.Put("FieldFlags", "260");
            // 
            // lblCurrBalHeader
            // 
            resources.ApplyResources(this.lblCurrBalHeader, "lblCurrBalHeader");
            this.lblCurrBalHeader.Name = "lblCurrBalHeader";
            // 
            // dlgCreateCompany
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "dlgCreateCompany";
            this.NamedProperties.Put("Module", "%");
            this.NamedProperties.Put("SourceFlags", "449");
            this.ShowIcon = false;
            this.ShowList = true;
            this.ShowPicture = true;
            this.WizardSteps.Add(this.StepOne);
            this.WizardSteps.Add(this.StepTwo);
            this.WizardSteps.Add(this.StepThree);
            this.WizardSteps.Add(this.StepFour);
            this.WizardSteps.Add(this.StepFive);
            this.WizardSteps.Add(this.StepSix);
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dlgCreateCompany_WindowActions);
            ((System.ComponentModel.ISupportInitialize)(this.picWizard)).EndInit();
            this.ToolBar.ResumeLayout(false);
            this.ClientArea.ResumeLayout(false);
            this.ClientArea.PerformLayout();
            this.gbCurrBalSelected.ResumeLayout(false);
            this.gbCurrBalSelected.PerformLayout();
            this.gbCurrBalAccountsEnable.ResumeLayout(false);
            this.gbCurrBalAccountsEnable.PerformLayout();
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

        protected __cWizardStep StepOne;
        protected __cWizardStep StepTwo;
        protected __cWizardStep StepThree;
        protected __cWizardStep StepFour;
        protected __cWizardStep StepFive;
        public cCheckBox cbMasterCompany;
        public cComboBox cmbParallelCurBase;
        protected cBackgroundText labelParallelCurrBase;
        public cDataField dfHeading3;
        protected cBackgroundText labeldfHeading3;
        protected __cWizardStep StepSix;
        protected cGroupBox gbCurrBalSelected;
        protected cGroupBox gbCurrBalAccountsEnable;
        protected cCheckBox cbStatOpenBal;
        protected cCheckBox cbStatistics;
        protected cCheckBox cbCost;
        protected cCheckBox cbRevenues;
        protected cCheckBox cbAssets;
        protected cBackgroundText lblCurrBalCodePart;
        protected cBackgroundText lblInternalName;
        protected cBackgroundText lblCodePart;
        protected cBackgroundText lblCurrBalHeader;
        public cRadioButton rbNo;
        public cRadioButton rbYes;
        public cDataField dfsInternalName;
        public cDataField dfsCodePart;
        protected cCheckBox cbLiabilities;
	}
}
