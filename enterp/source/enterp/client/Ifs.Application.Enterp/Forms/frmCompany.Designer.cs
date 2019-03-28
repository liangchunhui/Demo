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
	
	public partial class frmCompany
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		protected cBackgroundText labelcmbIdentity;
		public cRecListDataField cmbIdentity;
		protected cBackgroundText labeldfName;
		public cDataField dfName;
		protected cBackgroundText labeldfsAssociationNo;
		public cDataField dfsAssociationNo;
		protected cBackgroundText labelcmbDefaultLanguage;
		public cComboBoxOnTab cmbDefaultLanguage;
		protected cBackgroundText labeldfsLogotype;
		public cDataField dfsLogotype;
		protected cBackgroundText labelcmbCountry;
		public cComboBoxOnTab cmbCountry;
		// ! Bug 81196, Begin
		protected cBackgroundText labelcmbPositioning;
		public cComboBox cmbPositioning;
		// ! Bug 81196, End
		protected cBackgroundText labeldfsCorporateForm;
		public cDataField dfsCorporateForm;
		protected cBackgroundText labeldfsCorporateFormDesc;
		public cDataField dfsCorporateFormDesc;
		protected cBackgroundText labeldfdCreationDate;
		public cDataFieldOnTab dfdCreationDate;
		protected cBackgroundText labeldfdActivityStartDate;
		public cDataField dfdActivityStartDate;
		protected cBackgroundText labeldfsAuthorizationId;
		public cDataField dfsAuthorizationId;
		protected cBackgroundText labeldfdAuthIdExpireDate;
		public cDataField dfdAuthIdExpireDate;
		protected cBackgroundText labeldfsFromCompany;
		public cDataField dfsFromCompany;
		protected cBackgroundText labeldfsFromTemplateId;
		public cDataField dfsFromTemplateId;
		protected cBackgroundText labeldfsIdentifierReference;
		public cDataField dfsIdentifierReference;
		public cCheckBox cbTemplateCompany;
		protected cBackgroundText labelcmbIdentifierRefValidation;
		public cComboBox cmbIdentifierRefValidation;
		// ! Bug 79336, End
		public cDataField dfsCountryDb;
		public cDataField dfsParty;
		public cCheckBox cbDefaultDomain;
		public cDataField dfsPartyType;
		public cDataField dfsDomainId;
		public cDataField dfsExist;
		protected cBackgroundText label18;
		protected cBackgroundText labeldfsCreatedBy;
		public cDataField dfsCreatedBy;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCompany));
            this.cmdUpdatedCompany = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.cmdUpdatedCompanyTranslation = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.cmdCreateCompany = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.labelcmbIdentity = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbIdentity = new Ifs.Fnd.ApplicationForms.cRecListDataField();
            this.labeldfName = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfName = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsAssociationNo = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsAssociationNo = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelcmbDefaultLanguage = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.labeldfsLogotype = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsLogotype = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelcmbCountry = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.labelcmbPositioning = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbPositioning = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.labeldfsCorporateForm = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsCorporateForm = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsCorporateFormDesc = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsCorporateFormDesc = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfdCreationDate = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.labeldfdActivityStartDate = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfdActivityStartDate = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsAuthorizationId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsAuthorizationId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfdAuthIdExpireDate = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfdAuthIdExpireDate = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsFromCompany = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsFromCompany = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsFromTemplateId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsFromTemplateId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsIdentifierReference = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsIdentifierReference = new Ifs.Fnd.ApplicationForms.cDataField();
            this.cbTemplateCompany = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.labelcmbIdentifierRefValidation = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbIdentifierRefValidation = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.dfsCountryDb = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsParty = new Ifs.Fnd.ApplicationForms.cDataField();
            this.cbDefaultDomain = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.dfsPartyType = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsDomainId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsExist = new Ifs.Fnd.ApplicationForms.cDataField();
            this.label18 = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.labeldfsCreatedBy = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsCreatedBy = new Ifs.Fnd.ApplicationForms.cDataField();
            this.menuFrmMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_UpdatedCompany = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem_UpdatedCompanyTranslation = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem_CreateCompany = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.cbPrintSendersAddress = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.cbMasterCompany = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.labelcmbLocalizationCountryCode = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbLocalizationCountryCode = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.dfdCreationDate = new Ifs.Application.Enterp.cDataFieldOnTab();
            this.cmbCountry = new Ifs.Application.Enterp.cComboBoxOnTab();
            this.cmbDefaultLanguage = new Ifs.Application.Enterp.cComboBoxOnTab();
            this.menuFrmMethods.SuspendLayout();
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
            this.commandManager.Commands.Add(this.cmdUpdatedCompany);
            this.commandManager.Commands.Add(this.cmdUpdatedCompanyTranslation);
            this.commandManager.Commands.Add(this.cmdCreateCompany);
            this.commandManager.ContextMenus.Add(this.menuFrmMethods);
            // 
            // cmdUpdatedCompany
            // 
            resources.ApplyResources(this.cmdUpdatedCompany, "cmdUpdatedCompany");
            this.cmdUpdatedCompany.Name = "cmdUpdatedCompany";
            this.cmdUpdatedCompany.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.cmdUpdatedCompany_Execute);
            this.cmdUpdatedCompany.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.cmdUpdatedCompany_Inquire);
            // 
            // cmdUpdatedCompanyTranslation
            // 
            resources.ApplyResources(this.cmdUpdatedCompanyTranslation, "cmdUpdatedCompanyTranslation");
            this.cmdUpdatedCompanyTranslation.Name = "cmdUpdatedCompanyTranslation";
            this.cmdUpdatedCompanyTranslation.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.cmdUpdatedCompanyTranslation_Execute);
            this.cmdUpdatedCompanyTranslation.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.cmdUpdatedCompanyTranslation_Inquire);
            // 
            // cmdCreateCompany
            // 
            resources.ApplyResources(this.cmdCreateCompany, "cmdCreateCompany");
            this.cmdCreateCompany.Name = "cmdCreateCompany";
            this.cmdCreateCompany.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.cmdCreateCompany_Execute);
            this.cmdCreateCompany.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.cmdCreateCompany_Inquire);
            // 
            // labelcmbIdentity
            // 
            resources.ApplyResources(this.labelcmbIdentity, "labelcmbIdentity");
            this.labelcmbIdentity.Name = "labelcmbIdentity";
            // 
            // cmbIdentity
            // 
            this.cmbIdentity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.cmbIdentity, "cmbIdentity");
            this.cmbIdentity.Name = "cmbIdentity";
            this.cmbIdentity.NamedProperties.Put("EnumerateMethod", "");
            this.cmbIdentity.NamedProperties.Put("FieldFlags", "162");
            this.cmbIdentity.NamedProperties.Put("Format", "9");
            this.cmbIdentity.NamedProperties.Put("LovReference", "COMPANY");
            this.cmbIdentity.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbIdentity.NamedProperties.Put("SqlColumn", "COMPANY");
            this.cmbIdentity.NamedProperties.Put("ValidateMethod", "");
            this.cmbIdentity.NamedProperties.Put("XDataLength", "20");
            this.cmbIdentity.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbIdentity_WindowActions);
            // 
            // labeldfName
            // 
            resources.ApplyResources(this.labeldfName, "labeldfName");
            this.labeldfName.Name = "labeldfName";
            // 
            // dfName
            // 
            resources.ApplyResources(this.dfName, "dfName");
            this.dfName.Name = "dfName";
            this.dfName.NamedProperties.Put("EnumerateMethod", "");
            this.dfName.NamedProperties.Put("FieldFlags", "295");
            this.dfName.NamedProperties.Put("LovReference", "");
            this.dfName.NamedProperties.Put("ParentName", "cmbIdentity");
            this.dfName.NamedProperties.Put("ResizeableChildObject", "");
            this.dfName.NamedProperties.Put("SqlColumn", "NAME");
            this.dfName.NamedProperties.Put("ValidateMethod", "");
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
            this.dfsAssociationNo.NamedProperties.Put("LovReference", "ASSOCIATION_INFO");
            this.dfsAssociationNo.NamedProperties.Put("ParentName", "cmbIdentity");
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
            // labeldfsLogotype
            // 
            resources.ApplyResources(this.labeldfsLogotype, "labeldfsLogotype");
            this.labeldfsLogotype.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfsLogotype, "Name0");
            this.labeldfsLogotype.Name = "labeldfsLogotype";
            // 
            // dfsLogotype
            // 
            this.picTab.SetControlTabPages(this.dfsLogotype, "Name0");
            resources.ApplyResources(this.dfsLogotype, "dfsLogotype");
            this.dfsLogotype.Name = "dfsLogotype";
            this.dfsLogotype.NamedProperties.Put("EnumerateMethod", "");
            this.dfsLogotype.NamedProperties.Put("FieldFlags", "294");
            this.dfsLogotype.NamedProperties.Put("LovReference", "");
            this.dfsLogotype.NamedProperties.Put("SqlColumn", "LOGOTYPE");
            this.dfsLogotype.NamedProperties.Put("ValidateMethod", "");
            // 
            // labelcmbCountry
            // 
            resources.ApplyResources(this.labelcmbCountry, "labelcmbCountry");
            this.labelcmbCountry.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labelcmbCountry, "Name0");
            this.labelcmbCountry.Name = "labelcmbCountry";
            // 
            // labelcmbPositioning
            // 
            resources.ApplyResources(this.labelcmbPositioning, "labelcmbPositioning");
            this.labelcmbPositioning.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labelcmbPositioning, "Name0");
            this.labelcmbPositioning.Name = "labelcmbPositioning";
            // 
            // cmbPositioning
            // 
            this.picTab.SetControlTabPages(this.cmbPositioning, "Name0");
            resources.ApplyResources(this.cmbPositioning, "cmbPositioning");
            this.cmbPositioning.Name = "cmbPositioning";
            this.cmbPositioning.NamedProperties.Put("EnumerateMethod", "POSITIONING_TYPE_API.Enumerate");
            this.cmbPositioning.NamedProperties.Put("FieldFlags", "295");
            this.cmbPositioning.NamedProperties.Put("LovReference", "");
            this.cmbPositioning.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbPositioning.NamedProperties.Put("SqlColumn", "DOC_RECIP_ADDRESS_POS");
            this.cmbPositioning.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsCorporateForm
            // 
            resources.ApplyResources(this.labeldfsCorporateForm, "labeldfsCorporateForm");
            this.labeldfsCorporateForm.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfsCorporateForm, "Name0");
            this.labeldfsCorporateForm.Name = "labeldfsCorporateForm";
            // 
            // dfsCorporateForm
            // 
            this.picTab.SetControlTabPages(this.dfsCorporateForm, "Name0");
            resources.ApplyResources(this.dfsCorporateForm, "dfsCorporateForm");
            this.dfsCorporateForm.Name = "dfsCorporateForm";
            this.dfsCorporateForm.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCorporateForm.NamedProperties.Put("FieldFlags", "294");
            this.dfsCorporateForm.NamedProperties.Put("LovReference", "CORPORATE_FORM(COUNTRY_DB)");
            this.dfsCorporateForm.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsCorporateForm.NamedProperties.Put("SqlColumn", "CORPORATE_FORM");
            this.dfsCorporateForm.NamedProperties.Put("ValidateMethod", "");
            this.dfsCorporateForm.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsCorporateForm_WindowActions);
            // 
            // labeldfsCorporateFormDesc
            // 
            resources.ApplyResources(this.labeldfsCorporateFormDesc, "labeldfsCorporateFormDesc");
            this.labeldfsCorporateFormDesc.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfsCorporateFormDesc, "Name0");
            this.labeldfsCorporateFormDesc.Name = "labeldfsCorporateFormDesc";
            // 
            // dfsCorporateFormDesc
            // 
            this.dfsCorporateFormDesc.BackColor = System.Drawing.SystemColors.Control;
            this.picTab.SetControlTabPages(this.dfsCorporateFormDesc, "Name0");
            resources.ApplyResources(this.dfsCorporateFormDesc, "dfsCorporateFormDesc");
            this.dfsCorporateFormDesc.Name = "dfsCorporateFormDesc";
            this.dfsCorporateFormDesc.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCorporateFormDesc.NamedProperties.Put("LovReference", "");
            this.dfsCorporateFormDesc.NamedProperties.Put("ParentName", "dfsCorporateForm");
            this.dfsCorporateFormDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsCorporateFormDesc.NamedProperties.Put("SqlColumn", "CORPORATE_FORM_API.Get_Corporate_Form_Desc(COUNTRY_DB, CORPORATE_FORM)");
            this.dfsCorporateFormDesc.NamedProperties.Put("ValidateMethod", "");
            this.dfsCorporateFormDesc.ReadOnly = true;
            // 
            // labeldfdCreationDate
            // 
            resources.ApplyResources(this.labeldfdCreationDate, "labeldfdCreationDate");
            this.labeldfdCreationDate.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfdCreationDate, "Name0");
            this.labeldfdCreationDate.Name = "labeldfdCreationDate";
            // 
            // labeldfdActivityStartDate
            // 
            resources.ApplyResources(this.labeldfdActivityStartDate, "labeldfdActivityStartDate");
            this.labeldfdActivityStartDate.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfdActivityStartDate, "Name0");
            this.labeldfdActivityStartDate.Name = "labeldfdActivityStartDate";
            // 
            // dfdActivityStartDate
            // 
            this.picTab.SetControlTabPages(this.dfdActivityStartDate, "Name0");
            this.dfdActivityStartDate.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            resources.ApplyResources(this.dfdActivityStartDate, "dfdActivityStartDate");
            this.dfdActivityStartDate.Format = "d";
            this.dfdActivityStartDate.Name = "dfdActivityStartDate";
            this.dfdActivityStartDate.NamedProperties.Put("EnumerateMethod", "");
            this.dfdActivityStartDate.NamedProperties.Put("FieldFlags", "294");
            this.dfdActivityStartDate.NamedProperties.Put("LovReference", "");
            this.dfdActivityStartDate.NamedProperties.Put("SqlColumn", "ACTIVITY_START_DATE");
            this.dfdActivityStartDate.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsAuthorizationId
            // 
            resources.ApplyResources(this.labeldfsAuthorizationId, "labeldfsAuthorizationId");
            this.labeldfsAuthorizationId.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfsAuthorizationId, "Name0");
            this.labeldfsAuthorizationId.Name = "labeldfsAuthorizationId";
            // 
            // dfsAuthorizationId
            // 
            this.picTab.SetControlTabPages(this.dfsAuthorizationId, "Name0");
            resources.ApplyResources(this.dfsAuthorizationId, "dfsAuthorizationId");
            this.dfsAuthorizationId.Name = "dfsAuthorizationId";
            this.dfsAuthorizationId.NamedProperties.Put("EnumerateMethod", "");
            this.dfsAuthorizationId.NamedProperties.Put("FieldFlags", "294");
            this.dfsAuthorizationId.NamedProperties.Put("LovReference", "");
            this.dfsAuthorizationId.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsAuthorizationId.NamedProperties.Put("SqlColumn", "AUTHORIZATION_ID");
            this.dfsAuthorizationId.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfdAuthIdExpireDate
            // 
            resources.ApplyResources(this.labeldfdAuthIdExpireDate, "labeldfdAuthIdExpireDate");
            this.labeldfdAuthIdExpireDate.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfdAuthIdExpireDate, "Name0");
            this.labeldfdAuthIdExpireDate.Name = "labeldfdAuthIdExpireDate";
            // 
            // dfdAuthIdExpireDate
            // 
            this.picTab.SetControlTabPages(this.dfdAuthIdExpireDate, "Name0");
            this.dfdAuthIdExpireDate.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            resources.ApplyResources(this.dfdAuthIdExpireDate, "dfdAuthIdExpireDate");
            this.dfdAuthIdExpireDate.Format = "d";
            this.dfdAuthIdExpireDate.Name = "dfdAuthIdExpireDate";
            this.dfdAuthIdExpireDate.NamedProperties.Put("EnumerateMethod", "");
            this.dfdAuthIdExpireDate.NamedProperties.Put("FieldFlags", "294");
            this.dfdAuthIdExpireDate.NamedProperties.Put("LovReference", "");
            this.dfdAuthIdExpireDate.NamedProperties.Put("SqlColumn", "AUTH_ID_EXPIRE_DATE");
            this.dfdAuthIdExpireDate.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsFromCompany
            // 
            resources.ApplyResources(this.labeldfsFromCompany, "labeldfsFromCompany");
            this.labeldfsFromCompany.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfsFromCompany, "Name0");
            this.labeldfsFromCompany.Name = "labeldfsFromCompany";
            // 
            // dfsFromCompany
            // 
            this.dfsFromCompany.BackColor = System.Drawing.SystemColors.Control;
            this.picTab.SetControlTabPages(this.dfsFromCompany, "Name0");
            resources.ApplyResources(this.dfsFromCompany, "dfsFromCompany");
            this.dfsFromCompany.Name = "dfsFromCompany";
            this.dfsFromCompany.NamedProperties.Put("EnumerateMethod", "");
            this.dfsFromCompany.NamedProperties.Put("FieldFlags", "290");
            this.dfsFromCompany.NamedProperties.Put("LovReference", "");
            this.dfsFromCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsFromCompany.NamedProperties.Put("SqlColumn", "FROM_COMPANY");
            this.dfsFromCompany.NamedProperties.Put("ValidateMethod", "");
            this.dfsFromCompany.ReadOnly = true;
            // 
            // labeldfsFromTemplateId
            // 
            resources.ApplyResources(this.labeldfsFromTemplateId, "labeldfsFromTemplateId");
            this.labeldfsFromTemplateId.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfsFromTemplateId, "Name0");
            this.labeldfsFromTemplateId.Name = "labeldfsFromTemplateId";
            // 
            // dfsFromTemplateId
            // 
            this.dfsFromTemplateId.BackColor = System.Drawing.SystemColors.Control;
            this.picTab.SetControlTabPages(this.dfsFromTemplateId, "Name0");
            resources.ApplyResources(this.dfsFromTemplateId, "dfsFromTemplateId");
            this.dfsFromTemplateId.Name = "dfsFromTemplateId";
            this.dfsFromTemplateId.NamedProperties.Put("EnumerateMethod", "");
            this.dfsFromTemplateId.NamedProperties.Put("FieldFlags", "290");
            this.dfsFromTemplateId.NamedProperties.Put("LovReference", "");
            this.dfsFromTemplateId.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsFromTemplateId.NamedProperties.Put("SqlColumn", "FROM_TEMPLATE_ID");
            this.dfsFromTemplateId.NamedProperties.Put("ValidateMethod", "");
            this.dfsFromTemplateId.ReadOnly = true;
            // 
            // labeldfsIdentifierReference
            // 
            resources.ApplyResources(this.labeldfsIdentifierReference, "labeldfsIdentifierReference");
            this.labeldfsIdentifierReference.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labeldfsIdentifierReference, "Name0");
            this.labeldfsIdentifierReference.Name = "labeldfsIdentifierReference";
            // 
            // dfsIdentifierReference
            // 
            this.picTab.SetControlTabPages(this.dfsIdentifierReference, "Name0");
            resources.ApplyResources(this.dfsIdentifierReference, "dfsIdentifierReference");
            this.dfsIdentifierReference.Name = "dfsIdentifierReference";
            this.dfsIdentifierReference.NamedProperties.Put("EnumerateMethod", "");
            this.dfsIdentifierReference.NamedProperties.Put("FieldFlags", "294");
            this.dfsIdentifierReference.NamedProperties.Put("LovReference", "");
            this.dfsIdentifierReference.NamedProperties.Put("SqlColumn", "IDENTIFIER_REFERENCE");
            // 
            // cbTemplateCompany
            // 
            resources.ApplyResources(this.cbTemplateCompany, "cbTemplateCompany");
            this.cbTemplateCompany.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.cbTemplateCompany, "Name0");
            this.cbTemplateCompany.Name = "cbTemplateCompany";
            this.cbTemplateCompany.NamedProperties.Put("DataType", "5");
            this.cbTemplateCompany.NamedProperties.Put("EnumerateMethod", "");
            this.cbTemplateCompany.NamedProperties.Put("FieldFlags", "291");
            this.cbTemplateCompany.NamedProperties.Put("LovReference", "");
            this.cbTemplateCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.cbTemplateCompany.NamedProperties.Put("SqlColumn", "TEMPLATE_COMPANY");
            this.cbTemplateCompany.NamedProperties.Put("ValidateMethod", "");
            this.cbTemplateCompany.NamedProperties.Put("XDataLength", "5");
            this.cbTemplateCompany.UseVisualStyleBackColor = false;
            // 
            // labelcmbIdentifierRefValidation
            // 
            resources.ApplyResources(this.labelcmbIdentifierRefValidation, "labelcmbIdentifierRefValidation");
            this.labelcmbIdentifierRefValidation.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labelcmbIdentifierRefValidation, "Name0");
            this.labelcmbIdentifierRefValidation.Name = "labelcmbIdentifierRefValidation";
            // 
            // cmbIdentifierRefValidation
            // 
            this.picTab.SetControlTabPages(this.cmbIdentifierRefValidation, "Name0");
            resources.ApplyResources(this.cmbIdentifierRefValidation, "cmbIdentifierRefValidation");
            this.cmbIdentifierRefValidation.Name = "cmbIdentifierRefValidation";
            this.cmbIdentifierRefValidation.NamedProperties.Put("EnumerateMethod", "IDENTIFIER_REF_VALIDATION_API.Enumerate");
            this.cmbIdentifierRefValidation.NamedProperties.Put("FieldFlags", "295");
            this.cmbIdentifierRefValidation.NamedProperties.Put("LovReference", "");
            this.cmbIdentifierRefValidation.NamedProperties.Put("SqlColumn", "IDENTIFIER_REF_VALIDATION");
            // 
            // dfsCountryDb
            // 
            resources.ApplyResources(this.dfsCountryDb, "dfsCountryDb");
            this.dfsCountryDb.Name = "dfsCountryDb";
            this.dfsCountryDb.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCountryDb.NamedProperties.Put("FieldFlags", "262");
            this.dfsCountryDb.NamedProperties.Put("LovReference", "");
            this.dfsCountryDb.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsCountryDb.NamedProperties.Put("SqlColumn", "COUNTRY_DB");
            this.dfsCountryDb.NamedProperties.Put("ValidateMethod", "");
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
            // dfsPartyType
            // 
            resources.ApplyResources(this.dfsPartyType, "dfsPartyType");
            this.dfsPartyType.Name = "dfsPartyType";
            this.dfsPartyType.NamedProperties.Put("EnumerateMethod", "");
            this.dfsPartyType.NamedProperties.Put("FieldFlags", "263");
            this.dfsPartyType.NamedProperties.Put("LovReference", "");
            this.dfsPartyType.NamedProperties.Put("SqlColumn", "PARTY_TYPE");
            this.dfsPartyType.NamedProperties.Put("ValidateMethod", "");
            // 
            // dfsDomainId
            // 
            resources.ApplyResources(this.dfsDomainId, "dfsDomainId");
            this.dfsDomainId.Name = "dfsDomainId";
            this.dfsDomainId.NamedProperties.Put("EnumerateMethod", "");
            this.dfsDomainId.NamedProperties.Put("LovReference", "");
            this.dfsDomainId.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsDomainId.NamedProperties.Put("SqlColumn", "DOMAIN_ID");
            this.dfsDomainId.NamedProperties.Put("ValidateMethod", "");
            // 
            // dfsExist
            // 
            resources.ApplyResources(this.dfsExist, "dfsExist");
            this.dfsExist.Name = "dfsExist";
            // 
            // label18
            // 
            resources.ApplyResources(this.label18, "label18");
            this.label18.Name = "label18";
            // 
            // labeldfsCreatedBy
            // 
            resources.ApplyResources(this.labeldfsCreatedBy, "labeldfsCreatedBy");
            this.labeldfsCreatedBy.Name = "labeldfsCreatedBy";
            // 
            // dfsCreatedBy
            // 
            this.dfsCreatedBy.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsCreatedBy, "dfsCreatedBy");
            this.dfsCreatedBy.Name = "dfsCreatedBy";
            this.dfsCreatedBy.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCreatedBy.NamedProperties.Put("FieldFlags", "288");
            this.dfsCreatedBy.NamedProperties.Put("LovReference", "");
            this.dfsCreatedBy.NamedProperties.Put("ParentName", "cmbIdentity");
            this.dfsCreatedBy.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsCreatedBy.NamedProperties.Put("SqlColumn", "CREATED_BY");
            this.dfsCreatedBy.NamedProperties.Put("ValidateMethod", "");
            // 
            // menuFrmMethods
            // 
            this.menuFrmMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_UpdatedCompany,
            this.menuItem_UpdatedCompanyTranslation,
            this.menuItem_CreateCompany});
            this.menuFrmMethods.Name = "menuFrmMethods";
            resources.ApplyResources(this.menuFrmMethods, "menuFrmMethods");
            // 
            // menuItem_UpdatedCompany
            // 
            this.menuItem_UpdatedCompany.Command = this.cmdUpdatedCompany;
            this.menuItem_UpdatedCompany.Name = "menuItem_UpdatedCompany";
            resources.ApplyResources(this.menuItem_UpdatedCompany, "menuItem_UpdatedCompany");
            this.menuItem_UpdatedCompany.Text = "&Update Company...";
            // 
            // menuItem_UpdatedCompanyTranslation
            // 
            this.menuItem_UpdatedCompanyTranslation.Command = this.cmdUpdatedCompanyTranslation;
            this.menuItem_UpdatedCompanyTranslation.Name = "menuItem_UpdatedCompanyTranslation";
            resources.ApplyResources(this.menuItem_UpdatedCompanyTranslation, "menuItem_UpdatedCompanyTranslation");
            this.menuItem_UpdatedCompanyTranslation.Text = "Update Company &Translation...";
            // 
            // menuItem_CreateCompany
            // 
            this.menuItem_CreateCompany.Command = this.cmdCreateCompany;
            this.menuItem_CreateCompany.Name = "menuItem_CreateCompany";
            resources.ApplyResources(this.menuItem_CreateCompany, "menuItem_CreateCompany");
            this.menuItem_CreateCompany.Text = "&Create Company...";
            // 
            // cbPrintSendersAddress
            // 
            resources.ApplyResources(this.cbPrintSendersAddress, "cbPrintSendersAddress");
            this.cbPrintSendersAddress.CheckedValue = "TRUE";
            this.picTab.SetControlTabPages(this.cbPrintSendersAddress, "Name0");
            this.cbPrintSendersAddress.Name = "cbPrintSendersAddress";
            this.cbPrintSendersAddress.NamedProperties.Put("EnumerateMethod", "");
            this.cbPrintSendersAddress.NamedProperties.Put("FieldFlags", "294");
            this.cbPrintSendersAddress.NamedProperties.Put("LovReference", "");
            this.cbPrintSendersAddress.NamedProperties.Put("SqlColumn", "PRINT_SENDERS_ADDRESS_DB");
            this.cbPrintSendersAddress.UncheckedValue = "FALSE";
            // 
            // cbMasterCompany
            // 
            resources.ApplyResources(this.cbMasterCompany, "cbMasterCompany");
            this.cbMasterCompany.BackColor = System.Drawing.Color.Transparent;
            this.cbMasterCompany.CheckedValue = "TRUE";
            this.picTab.SetControlTabPages(this.cbMasterCompany, "Name0");
            this.cbMasterCompany.Name = "cbMasterCompany";
            this.cbMasterCompany.NamedProperties.Put("EnumerateMethod", "");
            this.cbMasterCompany.NamedProperties.Put("FieldFlags", "288");
            this.cbMasterCompany.NamedProperties.Put("LovReference", "");
            this.cbMasterCompany.NamedProperties.Put("SqlColumn", "MASTER_COMPANY_DB");
            this.cbMasterCompany.UncheckedValue = "FALSE";
            this.cbMasterCompany.UseVisualStyleBackColor = false;
            // 
            // labelcmbLocalizationCountryCode
            // 
            resources.ApplyResources(this.labelcmbLocalizationCountryCode, "labelcmbLocalizationCountryCode");
            this.labelcmbLocalizationCountryCode.BackColor = System.Drawing.Color.Transparent;
            this.picTab.SetControlTabPages(this.labelcmbLocalizationCountryCode, "Name0");
            this.labelcmbLocalizationCountryCode.Name = "labelcmbLocalizationCountryCode";
            // 
            // cmbLocalizationCountryCode
            // 
            this.picTab.SetControlTabPages(this.cmbLocalizationCountryCode, "Name0");
            resources.ApplyResources(this.cmbLocalizationCountryCode, "cmbLocalizationCountryCode");
            this.cmbLocalizationCountryCode.FormattingEnabled = true;
            this.cmbLocalizationCountryCode.Name = "cmbLocalizationCountryCode";
            this.cmbLocalizationCountryCode.NamedProperties.Put("EnumerateMethod", "LOCALIZATION_COUNTRY_API.Enumerate");
            this.cmbLocalizationCountryCode.NamedProperties.Put("FieldFlags", "295");
            this.cmbLocalizationCountryCode.NamedProperties.Put("LovReference", "");
            this.cmbLocalizationCountryCode.NamedProperties.Put("SqlColumn", "LOCALIZATION_COUNTRY");
            // 
            // dfdCreationDate
            // 
            this.dfdCreationDate.BackColor = System.Drawing.SystemColors.Control;
            this.picTab.SetControlTabPages(this.dfdCreationDate, "Name0");
            this.dfdCreationDate.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            resources.ApplyResources(this.dfdCreationDate, "dfdCreationDate");
            this.dfdCreationDate.Format = "d";
            this.dfdCreationDate.Name = "dfdCreationDate";
            this.dfdCreationDate.NamedProperties.Put("EnumerateMethod", "");
            this.dfdCreationDate.NamedProperties.Put("FieldFlags", "289");
            this.dfdCreationDate.NamedProperties.Put("LovReference", "");
            this.dfdCreationDate.NamedProperties.Put("ResizeableChildObject", "");
            this.dfdCreationDate.NamedProperties.Put("SqlColumn", "CREATION_DATE");
            this.dfdCreationDate.NamedProperties.Put("ValidateMethod", "");
            this.dfdCreationDate.ReadOnly = true;
            // 
            // cmbCountry
            // 
            this.picTab.SetControlTabPages(this.cmbCountry, "Name0");
            resources.ApplyResources(this.cmbCountry, "cmbCountry");
            this.cmbCountry.Name = "cmbCountry";
            this.cmbCountry.NamedProperties.Put("EnumerateMethod", "ISO_COUNTRY_API.Enumerate");
            this.cmbCountry.NamedProperties.Put("FieldFlags", "295");
            this.cmbCountry.NamedProperties.Put("LovReference", "");
            this.cmbCountry.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbCountry.NamedProperties.Put("SqlColumn", "COUNTRY");
            this.cmbCountry.NamedProperties.Put("ValidateMethod", "");
            this.cmbCountry.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbCountry_WindowActions);
            // 
            // cmbDefaultLanguage
            // 
            this.picTab.SetControlTabPages(this.cmbDefaultLanguage, "Name0");
            resources.ApplyResources(this.cmbDefaultLanguage, "cmbDefaultLanguage");
            this.cmbDefaultLanguage.Name = "cmbDefaultLanguage";
            this.cmbDefaultLanguage.NamedProperties.Put("EnumerateMethod", "ISO_LANGUAGE_API.Enumerate");
            this.cmbDefaultLanguage.NamedProperties.Put("FieldFlags", "295");
            this.cmbDefaultLanguage.NamedProperties.Put("LovReference", "");
            this.cmbDefaultLanguage.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbDefaultLanguage.NamedProperties.Put("SqlColumn", "DEFAULT_LANGUAGE");
            this.cmbDefaultLanguage.NamedProperties.Put("ValidateMethod", "");
            // 
            // frmCompany
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.cmbDefaultLanguage);
            this.Controls.Add(this.cmbCountry);
            this.Controls.Add(this.dfdCreationDate);
            this.Controls.Add(this.cmbLocalizationCountryCode);
            this.Controls.Add(this.labelcmbLocalizationCountryCode);
            this.Controls.Add(this.cbMasterCompany);
            this.Controls.Add(this.cbPrintSendersAddress);
            this.Controls.Add(this.dfsCreatedBy);
            this.Controls.Add(this.dfsExist);
            this.Controls.Add(this.dfsDomainId);
            this.Controls.Add(this.dfsPartyType);
            this.Controls.Add(this.cbDefaultDomain);
            this.Controls.Add(this.dfsParty);
            this.Controls.Add(this.dfsCountryDb);
            this.Controls.Add(this.cmbIdentifierRefValidation);
            this.Controls.Add(this.cbTemplateCompany);
            this.Controls.Add(this.dfsIdentifierReference);
            this.Controls.Add(this.dfsFromTemplateId);
            this.Controls.Add(this.dfsFromCompany);
            this.Controls.Add(this.dfdAuthIdExpireDate);
            this.Controls.Add(this.dfsAuthorizationId);
            this.Controls.Add(this.dfdActivityStartDate);
            this.Controls.Add(this.dfsCorporateFormDesc);
            this.Controls.Add(this.dfsCorporateForm);
            this.Controls.Add(this.cmbPositioning);
            this.Controls.Add(this.dfsLogotype);
            this.Controls.Add(this.dfsAssociationNo);
            this.Controls.Add(this.dfName);
            this.Controls.Add(this.cmbIdentity);
            this.Controls.Add(this.labeldfsCreatedBy);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.labelcmbIdentifierRefValidation);
            this.Controls.Add(this.labeldfsIdentifierReference);
            this.Controls.Add(this.labeldfsFromTemplateId);
            this.Controls.Add(this.labeldfsFromCompany);
            this.Controls.Add(this.labeldfdAuthIdExpireDate);
            this.Controls.Add(this.labeldfsAuthorizationId);
            this.Controls.Add(this.labeldfdActivityStartDate);
            this.Controls.Add(this.labeldfdCreationDate);
            this.Controls.Add(this.labeldfsCorporateFormDesc);
            this.Controls.Add(this.labeldfsCorporateForm);
            this.Controls.Add(this.labelcmbPositioning);
            this.Controls.Add(this.labelcmbCountry);
            this.Controls.Add(this.labeldfsLogotype);
            this.Controls.Add(this.labelcmbDefaultLanguage);
            this.Controls.Add(this.labeldfsAssociationNo);
            this.Controls.Add(this.labeldfName);
            this.Controls.Add(this.labelcmbIdentity);
            this.Name = "frmCompany";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "Company");
            this.NamedProperties.Put("PackageName", "COMPANY_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "4225");
            this.NamedProperties.Put("ViewName", "COMPANY");
            this.NamedProperties.Put("Warnings", "TRUE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.frmCompany_WindowActions);
            this.Controls.SetChildIndex(this.picTab, 0);
            this.Controls.SetChildIndex(this.labelcmbIdentity, 0);
            this.Controls.SetChildIndex(this.labeldfName, 0);
            this.Controls.SetChildIndex(this.labeldfsAssociationNo, 0);
            this.Controls.SetChildIndex(this.labelcmbDefaultLanguage, 0);
            this.Controls.SetChildIndex(this.labeldfsLogotype, 0);
            this.Controls.SetChildIndex(this.labelcmbCountry, 0);
            this.Controls.SetChildIndex(this.labelcmbPositioning, 0);
            this.Controls.SetChildIndex(this.labeldfsCorporateForm, 0);
            this.Controls.SetChildIndex(this.labeldfsCorporateFormDesc, 0);
            this.Controls.SetChildIndex(this.labeldfdCreationDate, 0);
            this.Controls.SetChildIndex(this.labeldfdActivityStartDate, 0);
            this.Controls.SetChildIndex(this.labeldfsAuthorizationId, 0);
            this.Controls.SetChildIndex(this.labeldfdAuthIdExpireDate, 0);
            this.Controls.SetChildIndex(this.labeldfsFromCompany, 0);
            this.Controls.SetChildIndex(this.labeldfsFromTemplateId, 0);
            this.Controls.SetChildIndex(this.labeldfsIdentifierReference, 0);
            this.Controls.SetChildIndex(this.labelcmbIdentifierRefValidation, 0);
            this.Controls.SetChildIndex(this.label18, 0);
            this.Controls.SetChildIndex(this.labeldfsCreatedBy, 0);
            this.Controls.SetChildIndex(this.cmbIdentity, 0);
            this.Controls.SetChildIndex(this.dfName, 0);
            this.Controls.SetChildIndex(this.dfsAssociationNo, 0);
            this.Controls.SetChildIndex(this.dfsLogotype, 0);
            this.Controls.SetChildIndex(this.cmbPositioning, 0);
            this.Controls.SetChildIndex(this.dfsCorporateForm, 0);
            this.Controls.SetChildIndex(this.dfsCorporateFormDesc, 0);
            this.Controls.SetChildIndex(this.dfdActivityStartDate, 0);
            this.Controls.SetChildIndex(this.dfsAuthorizationId, 0);
            this.Controls.SetChildIndex(this.dfdAuthIdExpireDate, 0);
            this.Controls.SetChildIndex(this.dfsFromCompany, 0);
            this.Controls.SetChildIndex(this.dfsFromTemplateId, 0);
            this.Controls.SetChildIndex(this.dfsIdentifierReference, 0);
            this.Controls.SetChildIndex(this.cbTemplateCompany, 0);
            this.Controls.SetChildIndex(this.cmbIdentifierRefValidation, 0);
            this.Controls.SetChildIndex(this.dfsCountryDb, 0);
            this.Controls.SetChildIndex(this.dfsParty, 0);
            this.Controls.SetChildIndex(this.cbDefaultDomain, 0);
            this.Controls.SetChildIndex(this.dfsPartyType, 0);
            this.Controls.SetChildIndex(this.dfsDomainId, 0);
            this.Controls.SetChildIndex(this.dfsExist, 0);
            this.Controls.SetChildIndex(this.dfsCreatedBy, 0);
            this.Controls.SetChildIndex(this.cbPrintSendersAddress, 0);
            this.Controls.SetChildIndex(this.cbMasterCompany, 0);
            this.Controls.SetChildIndex(this.labelcmbLocalizationCountryCode, 0);
            this.Controls.SetChildIndex(this.cmbLocalizationCountryCode, 0);
            this.Controls.SetChildIndex(this.dfdCreationDate, 0);
            this.Controls.SetChildIndex(this.cmbCountry, 0);
            this.Controls.SetChildIndex(this.cmbDefaultLanguage, 0);
            this.menuFrmMethods.ResumeLayout(false);
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

        protected Fnd.Windows.Forms.FndCommand cmdUpdatedCompany;
        protected Fnd.Windows.Forms.FndCommand cmdUpdatedCompanyTranslation;
        protected Fnd.Windows.Forms.FndCommand cmdCreateCompany;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuFrmMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_UpdatedCompany;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_UpdatedCompanyTranslation;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_CreateCompany;
        protected cCheckBox cbPrintSendersAddress;
        protected cCheckBox cbMasterCompany;
        protected cBackgroundText labelcmbLocalizationCountryCode;
        public cComboBox cmbLocalizationCountryCode;
	}
}
