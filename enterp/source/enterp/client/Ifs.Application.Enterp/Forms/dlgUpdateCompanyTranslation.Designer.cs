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
	
	public partial class dlgUpdateCompanyTranslation
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
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
		protected cBackgroundText labellbExistingLanguage;
		public VisRadioListBox lbExistingLanguage;
		public cPushButton pbOk;
		public cPushButton pbCancel;
		public cPushButton pbList;
		protected cBackgroundText labelpbPopulate;
		public cPushButton pbPopulate;
		protected cBackgroundText labellbAvailableLanguage;
		public VisRadioListBox lbAvailableLanguage;
		protected cBackgroundText labeldfsTemplateId;
		public cDataField dfsTemplateId;
		protected cBackgroundText labeldfsTemplateName;
		public cDataField dfsTemplateName;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgUpdateCompanyTranslation));
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
            this.labellbExistingLanguage = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.lbExistingLanguage = new PPJ.Runtime.Vis.VisRadioListBox();
            this.pbOk = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbCancel = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbList = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.labelpbPopulate = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.pbPopulate = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.labellbAvailableLanguage = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.lbAvailableLanguage = new PPJ.Runtime.Vis.VisRadioListBox();
            this.labeldfsTemplateId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsTemplateId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsTemplateName = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsTemplateName = new Ifs.Fnd.ApplicationForms.cDataField();
            this.ClientArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolBar
            // 
            resources.ApplyResources(this.ToolBar, "ToolBar");
            // 
            // ClientArea
            // 
            this.ClientArea.Controls.Add(this.dfsTemplateName);
            this.ClientArea.Controls.Add(this.dfsTemplateId);
            this.ClientArea.Controls.Add(this.lbAvailableLanguage);
            this.ClientArea.Controls.Add(this.pbPopulate);
            this.ClientArea.Controls.Add(this.pbList);
            this.ClientArea.Controls.Add(this.pbCancel);
            this.ClientArea.Controls.Add(this.pbOk);
            this.ClientArea.Controls.Add(this.lbExistingLanguage);
            this.ClientArea.Controls.Add(this.dfFromTemplateId);
            this.ClientArea.Controls.Add(this.dfFromCompany);
            this.ClientArea.Controls.Add(this.dfValidFrom);
            this.ClientArea.Controls.Add(this.dfCurrencyCode);
            this.ClientArea.Controls.Add(this.dfCompany);
            this.ClientArea.Controls.Add(this.labeldfsTemplateName);
            this.ClientArea.Controls.Add(this.labeldfsTemplateId);
            this.ClientArea.Controls.Add(this.labellbAvailableLanguage);
            this.ClientArea.Controls.Add(this.labelpbPopulate);
            this.ClientArea.Controls.Add(this.labellbExistingLanguage);
            this.ClientArea.Controls.Add(this.labeldfFromTemplateId);
            this.ClientArea.Controls.Add(this.labeldfFromCompany);
            this.ClientArea.Controls.Add(this.labeldfValidFrom);
            this.ClientArea.Controls.Add(this.labeldfCurrencyCode);
            this.ClientArea.Controls.Add(this.labeldfCompany);
            this.ClientArea.Controls.Add(this.gbCompany_Information);
            resources.ApplyResources(this.ClientArea, "ClientArea");
            // 
            // commandManager
            // 
            this.commandManager.Components.Add(this.pbPopulate);
            this.commandManager.Components.Add(this.pbList);
            this.commandManager.Components.Add(this.pbCancel);
            this.commandManager.Components.Add(this.pbOk);
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
            // labellbExistingLanguage
            // 
            resources.ApplyResources(this.labellbExistingLanguage, "labellbExistingLanguage");
            this.labellbExistingLanguage.Name = "labellbExistingLanguage";
            // 
            // lbExistingLanguage
            // 
            resources.ApplyResources(this.lbExistingLanguage, "lbExistingLanguage");
            this.lbExistingLanguage.Name = "lbExistingLanguage";
            this.lbExistingLanguage.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbExistingLanguage.UseCustomTabOffsets = true;
            // 
            // pbOk
            // 
            this.pbOk.AcceleratorKey = System.Windows.Forms.Keys.Return;
            resources.ApplyResources(this.pbOk, "pbOk");
            this.pbOk.Name = "pbOk";
            this.pbOk.NamedProperties.Put("MethodId", "18385");
            this.pbOk.NamedProperties.Put("MethodParameter", "OKButton");
            this.pbOk.NamedProperties.Put("ResizeableChildObject", "");
            this.pbOk.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.pbOk_WindowActions);
            // 
            // pbCancel
            // 
            this.pbCancel.AcceleratorKey = System.Windows.Forms.Keys.Escape;
            resources.ApplyResources(this.pbCancel, "pbCancel");
            this.pbCancel.Name = "pbCancel";
            this.pbCancel.NamedProperties.Put("MethodId", "18385");
            this.pbCancel.NamedProperties.Put("MethodParameter", "CancelButton");
            this.pbCancel.NamedProperties.Put("ResizeableChildObject", "");
            this.pbCancel.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.pbCancel_WindowActions);
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
            // labelpbPopulate
            // 
            resources.ApplyResources(this.labelpbPopulate, "labelpbPopulate");
            this.labelpbPopulate.Name = "labelpbPopulate";
            // 
            // pbPopulate
            // 
            resources.ApplyResources(this.pbPopulate, "pbPopulate");
            this.pbPopulate.Name = "pbPopulate";
            this.pbPopulate.NamedProperties.Put("MethodId", "18385");
            this.pbPopulate.NamedProperties.Put("MethodParameter", "Populate");
            this.pbPopulate.NamedProperties.Put("ResizeableChildObject", "");
            this.pbPopulate.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.pbPopulate_WindowActions);
            // 
            // labellbAvailableLanguage
            // 
            resources.ApplyResources(this.labellbAvailableLanguage, "labellbAvailableLanguage");
            this.labellbAvailableLanguage.Name = "labellbAvailableLanguage";
            // 
            // lbAvailableLanguage
            // 
            resources.ApplyResources(this.lbAvailableLanguage, "lbAvailableLanguage");
            this.lbAvailableLanguage.Name = "lbAvailableLanguage";
            this.lbAvailableLanguage.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbAvailableLanguage.UseCustomTabOffsets = true;
            this.lbAvailableLanguage.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.lbAvailableLanguage_WindowActions);
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
            this.dfsTemplateId.NamedProperties.Put("SqlColumn", "");
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
            this.dfsTemplateName.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.dfsTemplateName, "dfsTemplateName");
            this.dfsTemplateName.Name = "dfsTemplateName";
            this.dfsTemplateName.ReadOnly = true;
            // 
            // dlgUpdateCompanyTranslation
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "dlgUpdateCompanyTranslation";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "");
            this.NamedProperties.Put("PackageName", "");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("ViewName", "");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.ShowIcon = false;
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dlgUpdateCompanyTranslation_WindowActions);
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
