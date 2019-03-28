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
	
	public partial class dlgUpdateCompany
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cPushButton pbOk;
		public cPushButton pbCancel;
		public cPushButton pbList;
		public cPushButton pbSpecifyLu;
		protected SalGroupBox gbCompany_Information;
		protected cBackgroundText labeldfCompany;
		public SalDataField dfCompany;
		protected cBackgroundText labeldfCurrencyCode;
		public SalDataField dfCurrencyCode;
		protected cBackgroundText labeldfValidFrom;
		public SalDataField dfValidFrom;
		protected cBackgroundText labeldfFromCompany;
		public SalDataField dfFromCompany;
		protected cBackgroundText labeldfFromTemplateId;
		public SalDataField dfFromTemplateId;
		protected SalGroupBox gbChoose_update_of_existing_Logica;
		public cCheckBox cbNonAccRelData;
		public cCheckBox cbAccRelData;
		protected SalGroupBox gb_no_name_;
		public cCheckBox cbTemplateAsSource;
		protected cBackgroundText labeldfUpdateTemplateId;
		public cDataField dfUpdateTemplateId;
		public cPushButton pbGenerateDiff;
		protected cBackgroundText labeldfOldSourceTemplate;
		public SalDataField dfOldSourceTemplate;
		public cCheckBox cbDifferenceTemplate;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgUpdateCompany));
            this.pbOk = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbCancel = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbList = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbSpecifyLu = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.gbCompany_Information = new PPJ.Runtime.Windows.SalGroupBox();
            this.labeldfCompany = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfCompany = new PPJ.Runtime.Windows.SalDataField();
            this.labeldfCurrencyCode = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfCurrencyCode = new PPJ.Runtime.Windows.SalDataField();
            this.labeldfValidFrom = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfValidFrom = new PPJ.Runtime.Windows.SalDataField();
            this.labeldfFromCompany = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfFromCompany = new PPJ.Runtime.Windows.SalDataField();
            this.labeldfFromTemplateId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfFromTemplateId = new PPJ.Runtime.Windows.SalDataField();
            this.gbChoose_update_of_existing_Logica = new PPJ.Runtime.Windows.SalGroupBox();
            this.cbNonAccRelData = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.cbAccRelData = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.gb_no_name_ = new PPJ.Runtime.Windows.SalGroupBox();
            this.cbTemplateAsSource = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.labeldfUpdateTemplateId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfUpdateTemplateId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.pbGenerateDiff = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.labeldfOldSourceTemplate = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfOldSourceTemplate = new PPJ.Runtime.Windows.SalDataField();
            this.cbDifferenceTemplate = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.ClientArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolBar
            // 
            resources.ApplyResources(this.ToolBar, "ToolBar");
            // 
            // ClientArea
            // 
            this.ClientArea.Controls.Add(this.cbDifferenceTemplate);
            this.ClientArea.Controls.Add(this.dfOldSourceTemplate);
            this.ClientArea.Controls.Add(this.pbGenerateDiff);
            this.ClientArea.Controls.Add(this.dfUpdateTemplateId);
            this.ClientArea.Controls.Add(this.cbTemplateAsSource);
            this.ClientArea.Controls.Add(this.cbAccRelData);
            this.ClientArea.Controls.Add(this.cbNonAccRelData);
            this.ClientArea.Controls.Add(this.dfFromTemplateId);
            this.ClientArea.Controls.Add(this.dfFromCompany);
            this.ClientArea.Controls.Add(this.dfValidFrom);
            this.ClientArea.Controls.Add(this.dfCurrencyCode);
            this.ClientArea.Controls.Add(this.dfCompany);
            this.ClientArea.Controls.Add(this.pbSpecifyLu);
            this.ClientArea.Controls.Add(this.pbList);
            this.ClientArea.Controls.Add(this.pbCancel);
            this.ClientArea.Controls.Add(this.pbOk);
            this.ClientArea.Controls.Add(this.labeldfOldSourceTemplate);
            this.ClientArea.Controls.Add(this.labeldfUpdateTemplateId);
            this.ClientArea.Controls.Add(this.labeldfFromTemplateId);
            this.ClientArea.Controls.Add(this.labeldfFromCompany);
            this.ClientArea.Controls.Add(this.labeldfValidFrom);
            this.ClientArea.Controls.Add(this.labeldfCurrencyCode);
            this.ClientArea.Controls.Add(this.labeldfCompany);
            this.ClientArea.Controls.Add(this.gb_no_name_);
            this.ClientArea.Controls.Add(this.gbChoose_update_of_existing_Logica);
            this.ClientArea.Controls.Add(this.gbCompany_Information);
            resources.ApplyResources(this.ClientArea, "ClientArea");
            // 
            // commandManager
            // 
            this.commandManager.Components.Add(this.pbGenerateDiff);
            this.commandManager.Components.Add(this.pbSpecifyLu);
            this.commandManager.Components.Add(this.pbList);
            this.commandManager.Components.Add(this.pbCancel);
            this.commandManager.Components.Add(this.pbOk);
            // 
            // pbOk
            // 
            this.pbOk.AcceleratorKey = System.Windows.Forms.Keys.Return;
            resources.ApplyResources(this.pbOk, "pbOk");
            this.pbOk.Name = "pbOk";
            this.pbOk.NamedProperties.Put("MethodId", "18385");
            this.pbOk.NamedProperties.Put("MethodParameter", "OKButton");
            this.pbOk.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // pbCancel
            // 
            this.pbCancel.AcceleratorKey = System.Windows.Forms.Keys.Escape;
            resources.ApplyResources(this.pbCancel, "pbCancel");
            this.pbCancel.Name = "pbCancel";
            this.pbCancel.NamedProperties.Put("MethodId", "18385");
            this.pbCancel.NamedProperties.Put("MethodParameter", "CancelButton");
            this.pbCancel.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // pbList
            // 
            this.pbList.AcceleratorKey = System.Windows.Forms.Keys.F8;
            resources.ApplyResources(this.pbList, "pbList");
            this.pbList.Name = "pbList";
            this.pbList.NamedProperties.Put("MethodId", "18385");
            this.pbList.NamedProperties.Put("MethodParameter", "ListButton");
            this.pbList.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // pbSpecifyLu
            // 
            resources.ApplyResources(this.pbSpecifyLu, "pbSpecifyLu");
            this.pbSpecifyLu.Name = "pbSpecifyLu";
            this.pbSpecifyLu.NamedProperties.Put("MethodId", "18385");
            this.pbSpecifyLu.NamedProperties.Put("MethodParameter", "SpecifyLu");
            this.pbSpecifyLu.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // gbCompany_Information
            // 
            resources.ApplyResources(this.gbCompany_Information, "gbCompany_Information");
            this.gbCompany_Information.Name = "gbCompany_Information";
            this.gbCompany_Information.TabStop = false;
            // 
            // labeldfCompany
            // 
            resources.ApplyResources(this.labeldfCompany, "labeldfCompany");
            this.labeldfCompany.Name = "labeldfCompany";
            // 
            // dfCompany
            // 
            resources.ApplyResources(this.dfCompany, "dfCompany");
            this.dfCompany.Name = "dfCompany";
            this.dfCompany.NamedProperties.Put("EnumerateMethod", "");
            this.dfCompany.NamedProperties.Put("FieldFlags", "258");
            this.dfCompany.NamedProperties.Put("LovReference", "COMPANY");
            this.dfCompany.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.dfCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.dfCompany.NamedProperties.Put("SqlColumn", "");
            this.dfCompany.NamedProperties.Put("ValidateMethod", "");
            this.dfCompany.ReadOnly = true;
            // 
            // labeldfCurrencyCode
            // 
            resources.ApplyResources(this.labeldfCurrencyCode, "labeldfCurrencyCode");
            this.labeldfCurrencyCode.Name = "labeldfCurrencyCode";
            // 
            // dfCurrencyCode
            // 
            resources.ApplyResources(this.dfCurrencyCode, "dfCurrencyCode");
            this.dfCurrencyCode.Name = "dfCurrencyCode";
            this.dfCurrencyCode.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.dfCurrencyCode.ReadOnly = true;
            // 
            // labeldfValidFrom
            // 
            resources.ApplyResources(this.labeldfValidFrom, "labeldfValidFrom");
            this.labeldfValidFrom.Name = "labeldfValidFrom";
            // 
            // dfValidFrom
            // 
            this.dfValidFrom.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            resources.ApplyResources(this.dfValidFrom, "dfValidFrom");
            this.dfValidFrom.Format = "d";
            this.dfValidFrom.Name = "dfValidFrom";
            this.dfValidFrom.NamedProperties.Put("EnumerateMethod", "");
            this.dfValidFrom.NamedProperties.Put("FieldFlags", "256");
            this.dfValidFrom.NamedProperties.Put("LovReference", "");
            this.dfValidFrom.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.dfValidFrom.NamedProperties.Put("ResizeableChildObject", "");
            this.dfValidFrom.NamedProperties.Put("SqlColumn", "");
            this.dfValidFrom.NamedProperties.Put("ValidateMethod", "");
            this.dfValidFrom.ReadOnly = true;
            // 
            // labeldfFromCompany
            // 
            resources.ApplyResources(this.labeldfFromCompany, "labeldfFromCompany");
            this.labeldfFromCompany.Name = "labeldfFromCompany";
            // 
            // dfFromCompany
            // 
            resources.ApplyResources(this.dfFromCompany, "dfFromCompany");
            this.dfFromCompany.Name = "dfFromCompany";
            this.dfFromCompany.ReadOnly = true;
            // 
            // labeldfFromTemplateId
            // 
            resources.ApplyResources(this.labeldfFromTemplateId, "labeldfFromTemplateId");
            this.labeldfFromTemplateId.Name = "labeldfFromTemplateId";
            // 
            // dfFromTemplateId
            // 
            resources.ApplyResources(this.dfFromTemplateId, "dfFromTemplateId");
            this.dfFromTemplateId.Name = "dfFromTemplateId";
            this.dfFromTemplateId.ReadOnly = true;
            // 
            // gbChoose_update_of_existing_Logica
            // 
            resources.ApplyResources(this.gbChoose_update_of_existing_Logica, "gbChoose_update_of_existing_Logica");
            this.gbChoose_update_of_existing_Logica.Name = "gbChoose_update_of_existing_Logica";
            this.gbChoose_update_of_existing_Logica.TabStop = false;
            // 
            // cbNonAccRelData
            // 
            resources.ApplyResources(this.cbNonAccRelData, "cbNonAccRelData");
            this.cbNonAccRelData.Name = "cbNonAccRelData";
            this.cbNonAccRelData.NamedProperties.Put("DataType", "5");
            this.cbNonAccRelData.NamedProperties.Put("EnumerateMethod", "");
            this.cbNonAccRelData.NamedProperties.Put("FieldFlags", "262");
            this.cbNonAccRelData.NamedProperties.Put("LovReference", "");
            this.cbNonAccRelData.NamedProperties.Put("ResizeableChildObject", "");
            this.cbNonAccRelData.NamedProperties.Put("SqlColumn", "");
            this.cbNonAccRelData.NamedProperties.Put("ValidateMethod", "");
            this.cbNonAccRelData.NamedProperties.Put("XDataLength", "");
            this.cbNonAccRelData.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbNonAccRelData_WindowActions);
            // 
            // cbAccRelData
            // 
            resources.ApplyResources(this.cbAccRelData, "cbAccRelData");
            this.cbAccRelData.Name = "cbAccRelData";
            this.cbAccRelData.NamedProperties.Put("DataType", "5");
            this.cbAccRelData.NamedProperties.Put("EnumerateMethod", "");
            this.cbAccRelData.NamedProperties.Put("FieldFlags", "262");
            this.cbAccRelData.NamedProperties.Put("LovReference", "");
            this.cbAccRelData.NamedProperties.Put("ResizeableChildObject", "");
            this.cbAccRelData.NamedProperties.Put("SqlColumn", "");
            this.cbAccRelData.NamedProperties.Put("ValidateMethod", "");
            this.cbAccRelData.NamedProperties.Put("XDataLength", "");
            this.cbAccRelData.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbAccRelData_WindowActions);
            // 
            // gb_no_name_
            // 
            resources.ApplyResources(this.gb_no_name_, "gb_no_name_");
            this.gb_no_name_.Name = "gb_no_name_";
            this.gb_no_name_.TabStop = false;
            // 
            // cbTemplateAsSource
            // 
            resources.ApplyResources(this.cbTemplateAsSource, "cbTemplateAsSource");
            this.cbTemplateAsSource.Name = "cbTemplateAsSource";
            this.cbTemplateAsSource.NamedProperties.Put("DataType", "5");
            this.cbTemplateAsSource.NamedProperties.Put("EnumerateMethod", "");
            this.cbTemplateAsSource.NamedProperties.Put("FieldFlags", "262");
            this.cbTemplateAsSource.NamedProperties.Put("LovReference", "");
            this.cbTemplateAsSource.NamedProperties.Put("ResizeableChildObject", "");
            this.cbTemplateAsSource.NamedProperties.Put("SqlColumn", "");
            this.cbTemplateAsSource.NamedProperties.Put("ValidateMethod", "");
            this.cbTemplateAsSource.NamedProperties.Put("XDataLength", "");
            this.cbTemplateAsSource.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbTemplateAsSource_WindowActions);
            // 
            // labeldfUpdateTemplateId
            // 
            resources.ApplyResources(this.labeldfUpdateTemplateId, "labeldfUpdateTemplateId");
            this.labeldfUpdateTemplateId.Name = "labeldfUpdateTemplateId";
            // 
            // dfUpdateTemplateId
            // 
            this.dfUpdateTemplateId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfUpdateTemplateId, "dfUpdateTemplateId");
            this.dfUpdateTemplateId.Name = "dfUpdateTemplateId";
            this.dfUpdateTemplateId.NamedProperties.Put("EnumerateMethod", "");
            this.dfUpdateTemplateId.NamedProperties.Put("FieldFlags", "262");
            this.dfUpdateTemplateId.NamedProperties.Put("LovReference", "CREATE_COMPANY_TEM_VALID");
            this.dfUpdateTemplateId.NamedProperties.Put("ResizeableChildObject", "");
            this.dfUpdateTemplateId.NamedProperties.Put("SqlColumn", "");
            this.dfUpdateTemplateId.NamedProperties.Put("ValidateMethod", "");
            this.dfUpdateTemplateId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfUpdateTemplateId_WindowActions);
            // 
            // pbGenerateDiff
            // 
            resources.ApplyResources(this.pbGenerateDiff, "pbGenerateDiff");
            this.pbGenerateDiff.Name = "pbGenerateDiff";
            this.pbGenerateDiff.NamedProperties.Put("MethodId", "18385");
            this.pbGenerateDiff.NamedProperties.Put("MethodParameter", "GenerateDiff");
            this.pbGenerateDiff.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // labeldfOldSourceTemplate
            // 
            resources.ApplyResources(this.labeldfOldSourceTemplate, "labeldfOldSourceTemplate");
            this.labeldfOldSourceTemplate.Name = "labeldfOldSourceTemplate";
            // 
            // dfOldSourceTemplate
            // 
            resources.ApplyResources(this.dfOldSourceTemplate, "dfOldSourceTemplate");
            this.dfOldSourceTemplate.Name = "dfOldSourceTemplate";
            this.dfOldSourceTemplate.ReadOnly = true;
            // 
            // cbDifferenceTemplate
            // 
            resources.ApplyResources(this.cbDifferenceTemplate, "cbDifferenceTemplate");
            this.cbDifferenceTemplate.Name = "cbDifferenceTemplate";
            // 
            // dlgUpdateCompany
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "dlgUpdateCompany";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "");
            this.NamedProperties.Put("PackageName", "");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("ViewName", "");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.ShowIcon = false;
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dlgUpdateCompany_WindowActions);
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
