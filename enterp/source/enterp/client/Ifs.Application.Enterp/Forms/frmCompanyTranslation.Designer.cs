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
	
	public partial class frmCompanyTranslation
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cDataField dfsKeyName;
		protected cBackgroundText labelcmbCompany;
		public cRecListDataField cmbCompany;
		protected cBackgroundText labeldfCompanyName;
		public cDataField dfCompanyName;
		protected cBackgroundText labeldfsModule;
		public cDataField dfsModule;
		protected cBackgroundText labeldfsLu;
		public cDataField dfsLu;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCompanyTranslation));
            this.menuTblMethods_menu_Copy_Installation_Translations = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuFrmMethods_menu_Copy_Installation_Translation_T = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.dfsKeyName = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelcmbCompany = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbCompany = new Ifs.Fnd.ApplicationForms.cRecListDataField();
            this.labeldfCompanyName = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfCompanyName = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsModule = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsModule = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsLu = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsLu = new Ifs.Fnd.ApplicationForms.cDataField();
            this.menuFrmMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem__Copy = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuTblMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem__Copy_1 = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuItem_Copy_to_Companies = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.menuTbwMethods_menuCopy_To_Companies___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.tblCompanyTranslationDetail = new Ifs.Application.Enterp.cChildTableEntBase();
            this.tblCompanyTranslationDetail_colsKeyName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblCompanyTranslationDetail_colsKeyValue = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblCompanyTranslationDetail_colsModule = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblCompanyTranslationDetail_colsLu = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblCompanyTranslationDetail_colsAttributeKey = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblCompanyTranslationDetail_colsLanguageCodeDb = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblCompanyTranslationDetail_colsLanguageCodeDesc = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblCompanyTranslationDetail_colsCurrentTranslation = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblCompanyTranslationDetail_colsInstallationTranslation = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblCompanyTranslationDetail_colsSystemDefined = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.menuFrmMethods.SuspendLayout();
            this.menuTblMethods.SuspendLayout();
            this.tblCompanyTranslationDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuFrmMethods_menu_Copy_Installation_Translation_T);
            this.commandManager.Commands.Add(this.menuTblMethods_menu_Copy_Installation_Translations);
            this.commandManager.Commands.Add(this.menuTbwMethods_menuCopy_To_Companies___);
            this.commandManager.ContextMenus.Add(this.menuFrmMethods);
            this.commandManager.ContextMenus.Add(this.menuTblMethods);
            // 
            // menuTblMethods_menu_Copy_Installation_Translations
            // 
            resources.ApplyResources(this.menuTblMethods_menu_Copy_Installation_Translations, "menuTblMethods_menu_Copy_Installation_Translations");
            this.menuTblMethods_menu_Copy_Installation_Translations.Name = "menuTblMethods_menu_Copy_Installation_Translations";
            this.menuTblMethods_menu_Copy_Installation_Translations.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Copy_1_Execute);
            this.menuTblMethods_menu_Copy_Installation_Translations.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Copy_1_Inquire);
            // 
            // menuFrmMethods_menu_Copy_Installation_Translation_T
            // 
            resources.ApplyResources(this.menuFrmMethods_menu_Copy_Installation_Translation_T, "menuFrmMethods_menu_Copy_Installation_Translation_T");
            this.menuFrmMethods_menu_Copy_Installation_Translation_T.Name = "menuFrmMethods_menu_Copy_Installation_Translation_T";
            this.menuFrmMethods_menu_Copy_Installation_Translation_T.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Copy_Execute);
            this.menuFrmMethods_menu_Copy_Installation_Translation_T.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Copy_Inquire);
            // 
            // dfsKeyName
            // 
            resources.ApplyResources(this.dfsKeyName, "dfsKeyName");
            this.dfsKeyName.Name = "dfsKeyName";
            this.dfsKeyName.NamedProperties.Put("EnumerateMethod", "");
            this.dfsKeyName.NamedProperties.Put("FieldFlags", "131");
            this.dfsKeyName.NamedProperties.Put("LovReference", "");
            this.dfsKeyName.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsKeyName.NamedProperties.Put("SqlColumn", "KEY_NAME");
            this.dfsKeyName.NamedProperties.Put("ValidateMethod", "");
            // 
            // labelcmbCompany
            // 
            resources.ApplyResources(this.labelcmbCompany, "labelcmbCompany");
            this.labelcmbCompany.Name = "labelcmbCompany";
            // 
            // cmbCompany
            // 
            resources.ApplyResources(this.cmbCompany, "cmbCompany");
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.NamedProperties.Put("EnumerateMethod", "");
            this.cmbCompany.NamedProperties.Put("FieldFlags", "163");
            this.cmbCompany.NamedProperties.Put("LovReference", "COMPANY");
            this.cmbCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbCompany.NamedProperties.Put("SqlColumn", "KEY_VALUE");
            this.cmbCompany.NamedProperties.Put("ValidateMethod", "");
            this.cmbCompany.NamedProperties.Put("XDataLength", "30");
            this.cmbCompany.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbCompany_WindowActions);
            // 
            // labeldfCompanyName
            // 
            resources.ApplyResources(this.labeldfCompanyName, "labeldfCompanyName");
            this.labeldfCompanyName.Name = "labeldfCompanyName";
            // 
            // dfCompanyName
            // 
            resources.ApplyResources(this.dfCompanyName, "dfCompanyName");
            this.dfCompanyName.Name = "dfCompanyName";
            this.dfCompanyName.NamedProperties.Put("EnumerateMethod", "");
            this.dfCompanyName.NamedProperties.Put("FieldFlags", "288");
            this.dfCompanyName.NamedProperties.Put("LovReference", "");
            this.dfCompanyName.NamedProperties.Put("ParentName", "cmbCompany");
            this.dfCompanyName.NamedProperties.Put("ResizeableChildObject", "");
            this.dfCompanyName.NamedProperties.Put("SqlColumn", "COMPANY_API.Get_Name(KEY_VALUE)");
            this.dfCompanyName.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsModule
            // 
            resources.ApplyResources(this.labeldfsModule, "labeldfsModule");
            this.labeldfsModule.Name = "labeldfsModule";
            // 
            // dfsModule
            // 
            this.dfsModule.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsModule, "dfsModule");
            this.dfsModule.Name = "dfsModule";
            this.dfsModule.NamedProperties.Put("EnumerateMethod", "");
            this.dfsModule.NamedProperties.Put("FieldFlags", "99");
            this.dfsModule.NamedProperties.Put("LovReference", "");
            this.dfsModule.NamedProperties.Put("ParentName", "cmbCompany");
            this.dfsModule.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsModule.NamedProperties.Put("SqlColumn", "MODULE");
            this.dfsModule.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsLu
            // 
            resources.ApplyResources(this.labeldfsLu, "labeldfsLu");
            this.labeldfsLu.Name = "labeldfsLu";
            // 
            // dfsLu
            // 
            resources.ApplyResources(this.dfsLu, "dfsLu");
            this.dfsLu.Name = "dfsLu";
            this.dfsLu.NamedProperties.Put("EnumerateMethod", "");
            this.dfsLu.NamedProperties.Put("FieldFlags", "99");
            this.dfsLu.NamedProperties.Put("LovReference", "MODULE_LU(MODULE)");
            this.dfsLu.NamedProperties.Put("ParentName", "cmbCompany");
            this.dfsLu.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsLu.NamedProperties.Put("SqlColumn", "LU");
            this.dfsLu.NamedProperties.Put("ValidateMethod", "");
            // 
            // menuFrmMethods
            // 
            this.menuFrmMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem__Copy});
            this.menuFrmMethods.Name = "menuFrmMethods";
            resources.ApplyResources(this.menuFrmMethods, "menuFrmMethods");
            // 
            // menuItem__Copy
            // 
            this.menuItem__Copy.Command = this.menuFrmMethods_menu_Copy_Installation_Translation_T;
            this.menuItem__Copy.Name = "menuItem__Copy";
            resources.ApplyResources(this.menuItem__Copy, "menuItem__Copy");
            this.menuItem__Copy.Text = "&Copy Installation Translation Text for chosen Company, Module and Logical Unit";
            // 
            // menuTblMethods
            // 
            this.menuTblMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem__Copy_1,
            this.menuItem_Copy_to_Companies});
            this.menuTblMethods.Name = "menuTblMethods";
            resources.ApplyResources(this.menuTblMethods, "menuTblMethods");
            // 
            // menuItem__Copy_1
            // 
            this.menuItem__Copy_1.Command = this.menuTblMethods_menu_Copy_Installation_Translations;
            this.menuItem__Copy_1.Name = "menuItem__Copy_1";
            resources.ApplyResources(this.menuItem__Copy_1, "menuItem__Copy_1");
            this.menuItem__Copy_1.Text = "&Copy Installation Translations Text";
            // 
            // menuItem_Copy_to_Companies
            // 
            this.menuItem_Copy_to_Companies.Command = this.menuTbwMethods_menuCopy_To_Companies___;
            this.menuItem_Copy_to_Companies.Name = "menuItem_Copy_to_Companies";
            resources.ApplyResources(this.menuItem_Copy_to_Companies, "menuItem_Copy_to_Companies");
            this.menuItem_Copy_to_Companies.Text = "Copy to Companies...";
            // 
            // menuTbwMethods_menuCopy_To_Companies___
            // 
            resources.ApplyResources(this.menuTbwMethods_menuCopy_To_Companies___, "menuTbwMethods_menuCopy_To_Companies___");
            this.menuTbwMethods_menuCopy_To_Companies___.Name = "menuTbwMethods_menuCopy_To_Companies___";
            this.menuTbwMethods_menuCopy_To_Companies___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuTbwMethods_menuCopy_To_Companies____Execute);
            this.menuTbwMethods_menuCopy_To_Companies___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuTbwMethods_menuCopy_To_Companies____Inquire);
            // 
            // tblCompanyTranslationDetail
            // 
            this.tblCompanyTranslationDetail.ContextMenuStrip = this.menuTblMethods;
            this.tblCompanyTranslationDetail.Controls.Add(this.tblCompanyTranslationDetail_colsKeyName);
            this.tblCompanyTranslationDetail.Controls.Add(this.tblCompanyTranslationDetail_colsKeyValue);
            this.tblCompanyTranslationDetail.Controls.Add(this.tblCompanyTranslationDetail_colsModule);
            this.tblCompanyTranslationDetail.Controls.Add(this.tblCompanyTranslationDetail_colsLu);
            this.tblCompanyTranslationDetail.Controls.Add(this.tblCompanyTranslationDetail_colsAttributeKey);
            this.tblCompanyTranslationDetail.Controls.Add(this.tblCompanyTranslationDetail_colsLanguageCodeDb);
            this.tblCompanyTranslationDetail.Controls.Add(this.tblCompanyTranslationDetail_colsLanguageCodeDesc);
            this.tblCompanyTranslationDetail.Controls.Add(this.tblCompanyTranslationDetail_colsCurrentTranslation);
            this.tblCompanyTranslationDetail.Controls.Add(this.tblCompanyTranslationDetail_colsInstallationTranslation);
            this.tblCompanyTranslationDetail.Controls.Add(this.tblCompanyTranslationDetail_colsSystemDefined);
            resources.ApplyResources(this.tblCompanyTranslationDetail, "tblCompanyTranslationDetail");
            this.tblCompanyTranslationDetail.Name = "tblCompanyTranslationDetail";
            this.tblCompanyTranslationDetail.NamedProperties.Put("DefaultOrderBy", "");
            this.tblCompanyTranslationDetail.NamedProperties.Put("DefaultWhere", "");
            this.tblCompanyTranslationDetail.NamedProperties.Put("LogicalUnit", "CompanyKeyLuTranslation");
            this.tblCompanyTranslationDetail.NamedProperties.Put("PackageName", "COMPANY_KEY_LU_TRANSLATION_API");
            this.tblCompanyTranslationDetail.NamedProperties.Put("ResizeableChildObject", "LLMM");
            this.tblCompanyTranslationDetail.NamedProperties.Put("ViewName", "COMPANY_KEY_LU_TRANSLATION");
            this.tblCompanyTranslationDetail.NamedProperties.Put("Warnings", "FALSE");
            this.tblCompanyTranslationDetail.UserMethodEvent += new Ifs.Fnd.ApplicationForms.cMethodManager.UserMethodEventHandler(this.tblCompanyTranslationDetail_UserMethodEvent);
            this.tblCompanyTranslationDetail.DataRecordFetchEditedUserEvent += new Ifs.Fnd.ApplicationForms.cDataSource.DataRecordFetchEditedUserEventHandler(this.tblCompanyTranslationDetail_DataRecordFetchEditedUserEvent);
            this.tblCompanyTranslationDetail.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblCompanyTranslationDetail_WindowActions);
            this.tblCompanyTranslationDetail.Controls.SetChildIndex(this.tblCompanyTranslationDetail_colsSystemDefined, 0);
            this.tblCompanyTranslationDetail.Controls.SetChildIndex(this.tblCompanyTranslationDetail_colsInstallationTranslation, 0);
            this.tblCompanyTranslationDetail.Controls.SetChildIndex(this.tblCompanyTranslationDetail_colsCurrentTranslation, 0);
            this.tblCompanyTranslationDetail.Controls.SetChildIndex(this.tblCompanyTranslationDetail_colsLanguageCodeDesc, 0);
            this.tblCompanyTranslationDetail.Controls.SetChildIndex(this.tblCompanyTranslationDetail_colsLanguageCodeDb, 0);
            this.tblCompanyTranslationDetail.Controls.SetChildIndex(this.tblCompanyTranslationDetail_colsAttributeKey, 0);
            this.tblCompanyTranslationDetail.Controls.SetChildIndex(this.tblCompanyTranslationDetail_colsLu, 0);
            this.tblCompanyTranslationDetail.Controls.SetChildIndex(this.tblCompanyTranslationDetail_colsModule, 0);
            this.tblCompanyTranslationDetail.Controls.SetChildIndex(this.tblCompanyTranslationDetail_colsKeyValue, 0);
            this.tblCompanyTranslationDetail.Controls.SetChildIndex(this.tblCompanyTranslationDetail_colsKeyName, 0);
            // 
            // tblCompanyTranslationDetail_colsKeyName
            // 
            resources.ApplyResources(this.tblCompanyTranslationDetail_colsKeyName, "tblCompanyTranslationDetail_colsKeyName");
            this.tblCompanyTranslationDetail_colsKeyName.MaxLength = 30;
            this.tblCompanyTranslationDetail_colsKeyName.Name = "tblCompanyTranslationDetail_colsKeyName";
            this.tblCompanyTranslationDetail_colsKeyName.NamedProperties.Put("EnumerateMethod", "");
            this.tblCompanyTranslationDetail_colsKeyName.NamedProperties.Put("FieldFlags", "67");
            this.tblCompanyTranslationDetail_colsKeyName.NamedProperties.Put("LovReference", "");
            this.tblCompanyTranslationDetail_colsKeyName.NamedProperties.Put("ResizeableChildObject", "");
            this.tblCompanyTranslationDetail_colsKeyName.NamedProperties.Put("SqlColumn", "KEY_NAME");
            this.tblCompanyTranslationDetail_colsKeyName.NamedProperties.Put("ValidateMethod", "");
            this.tblCompanyTranslationDetail_colsKeyName.Position = 3;
            // 
            // tblCompanyTranslationDetail_colsKeyValue
            // 
            resources.ApplyResources(this.tblCompanyTranslationDetail_colsKeyValue, "tblCompanyTranslationDetail_colsKeyValue");
            this.tblCompanyTranslationDetail_colsKeyValue.MaxLength = 30;
            this.tblCompanyTranslationDetail_colsKeyValue.Name = "tblCompanyTranslationDetail_colsKeyValue";
            this.tblCompanyTranslationDetail_colsKeyValue.NamedProperties.Put("EnumerateMethod", "");
            this.tblCompanyTranslationDetail_colsKeyValue.NamedProperties.Put("FieldFlags", "67");
            this.tblCompanyTranslationDetail_colsKeyValue.NamedProperties.Put("LovReference", "");
            this.tblCompanyTranslationDetail_colsKeyValue.NamedProperties.Put("SqlColumn", "KEY_VALUE");
            this.tblCompanyTranslationDetail_colsKeyValue.Position = 4;
            // 
            // tblCompanyTranslationDetail_colsModule
            // 
            this.tblCompanyTranslationDetail_colsModule.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblCompanyTranslationDetail_colsModule, "tblCompanyTranslationDetail_colsModule");
            this.tblCompanyTranslationDetail_colsModule.MaxLength = 6;
            this.tblCompanyTranslationDetail_colsModule.Name = "tblCompanyTranslationDetail_colsModule";
            this.tblCompanyTranslationDetail_colsModule.NamedProperties.Put("EnumerateMethod", "");
            this.tblCompanyTranslationDetail_colsModule.NamedProperties.Put("FieldFlags", "67");
            this.tblCompanyTranslationDetail_colsModule.NamedProperties.Put("LovReference", "");
            this.tblCompanyTranslationDetail_colsModule.NamedProperties.Put("SqlColumn", "MODULE");
            this.tblCompanyTranslationDetail_colsModule.Position = 5;
            // 
            // tblCompanyTranslationDetail_colsLu
            // 
            resources.ApplyResources(this.tblCompanyTranslationDetail_colsLu, "tblCompanyTranslationDetail_colsLu");
            this.tblCompanyTranslationDetail_colsLu.MaxLength = 30;
            this.tblCompanyTranslationDetail_colsLu.Name = "tblCompanyTranslationDetail_colsLu";
            this.tblCompanyTranslationDetail_colsLu.NamedProperties.Put("EnumerateMethod", "");
            this.tblCompanyTranslationDetail_colsLu.NamedProperties.Put("FieldFlags", "67");
            this.tblCompanyTranslationDetail_colsLu.NamedProperties.Put("LovReference", "");
            this.tblCompanyTranslationDetail_colsLu.NamedProperties.Put("SqlColumn", "LU");
            this.tblCompanyTranslationDetail_colsLu.Position = 6;
            // 
            // tblCompanyTranslationDetail_colsAttributeKey
            // 
            this.tblCompanyTranslationDetail_colsAttributeKey.MaxLength = 500;
            this.tblCompanyTranslationDetail_colsAttributeKey.Name = "tblCompanyTranslationDetail_colsAttributeKey";
            this.tblCompanyTranslationDetail_colsAttributeKey.NamedProperties.Put("EnumerateMethod", "");
            this.tblCompanyTranslationDetail_colsAttributeKey.NamedProperties.Put("FieldFlags", "179");
            this.tblCompanyTranslationDetail_colsAttributeKey.NamedProperties.Put("LovReference", "COMPANY_KEY_LU_ATTRIBUTE(KEY_NAME,KEY_VALUE,MODULE,LU)");
            this.tblCompanyTranslationDetail_colsAttributeKey.NamedProperties.Put("ResizeableChildObject", "");
            this.tblCompanyTranslationDetail_colsAttributeKey.NamedProperties.Put("SqlColumn", "ATTRIBUTE_KEY");
            this.tblCompanyTranslationDetail_colsAttributeKey.NamedProperties.Put("ValidateMethod", "");
            this.tblCompanyTranslationDetail_colsAttributeKey.Position = 7;
            resources.ApplyResources(this.tblCompanyTranslationDetail_colsAttributeKey, "tblCompanyTranslationDetail_colsAttributeKey");
            this.tblCompanyTranslationDetail_colsAttributeKey.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsAttributeKey_WindowActions);
            // 
            // tblCompanyTranslationDetail_colsLanguageCodeDb
            // 
            this.tblCompanyTranslationDetail_colsLanguageCodeDb.MaxLength = 2;
            this.tblCompanyTranslationDetail_colsLanguageCodeDb.Name = "tblCompanyTranslationDetail_colsLanguageCodeDb";
            this.tblCompanyTranslationDetail_colsLanguageCodeDb.NamedProperties.Put("EnumerateMethod", "");
            this.tblCompanyTranslationDetail_colsLanguageCodeDb.NamedProperties.Put("FieldFlags", "163");
            this.tblCompanyTranslationDetail_colsLanguageCodeDb.NamedProperties.Put("LovReference", "ISO_LANGUAGE");
            this.tblCompanyTranslationDetail_colsLanguageCodeDb.NamedProperties.Put("ResizeableChildObject", "");
            this.tblCompanyTranslationDetail_colsLanguageCodeDb.NamedProperties.Put("SqlColumn", "LANGUAGE_CODE");
            this.tblCompanyTranslationDetail_colsLanguageCodeDb.NamedProperties.Put("ValidateMethod", "");
            this.tblCompanyTranslationDetail_colsLanguageCodeDb.Position = 8;
            resources.ApplyResources(this.tblCompanyTranslationDetail_colsLanguageCodeDb, "tblCompanyTranslationDetail_colsLanguageCodeDb");
            this.tblCompanyTranslationDetail_colsLanguageCodeDb.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsLanguageCodeDb_WindowActions);
            // 
            // tblCompanyTranslationDetail_colsLanguageCodeDesc
            // 
            this.tblCompanyTranslationDetail_colsLanguageCodeDesc.MaxLength = 2000;
            this.tblCompanyTranslationDetail_colsLanguageCodeDesc.Name = "tblCompanyTranslationDetail_colsLanguageCodeDesc";
            this.tblCompanyTranslationDetail_colsLanguageCodeDesc.NamedProperties.Put("EnumerateMethod", "");
            this.tblCompanyTranslationDetail_colsLanguageCodeDesc.NamedProperties.Put("LovReference", "");
            this.tblCompanyTranslationDetail_colsLanguageCodeDesc.NamedProperties.Put("ResizeableChildObject", "");
            this.tblCompanyTranslationDetail_colsLanguageCodeDesc.NamedProperties.Put("SqlColumn", "Iso_Language_API.Decode(LANGUAGE_CODE)");
            this.tblCompanyTranslationDetail_colsLanguageCodeDesc.NamedProperties.Put("ValidateMethod", "");
            this.tblCompanyTranslationDetail_colsLanguageCodeDesc.Position = 9;
            resources.ApplyResources(this.tblCompanyTranslationDetail_colsLanguageCodeDesc, "tblCompanyTranslationDetail_colsLanguageCodeDesc");
            // 
            // tblCompanyTranslationDetail_colsCurrentTranslation
            // 
            this.tblCompanyTranslationDetail_colsCurrentTranslation.MaxLength = 2000;
            this.tblCompanyTranslationDetail_colsCurrentTranslation.Name = "tblCompanyTranslationDetail_colsCurrentTranslation";
            this.tblCompanyTranslationDetail_colsCurrentTranslation.NamedProperties.Put("EnumerateMethod", "");
            this.tblCompanyTranslationDetail_colsCurrentTranslation.NamedProperties.Put("FieldFlags", "310");
            this.tblCompanyTranslationDetail_colsCurrentTranslation.NamedProperties.Put("LovReference", "");
            this.tblCompanyTranslationDetail_colsCurrentTranslation.NamedProperties.Put("ResizeableChildObject", "");
            this.tblCompanyTranslationDetail_colsCurrentTranslation.NamedProperties.Put("SqlColumn", "CURRENT_TRANSLATION");
            this.tblCompanyTranslationDetail_colsCurrentTranslation.NamedProperties.Put("ValidateMethod", "");
            this.tblCompanyTranslationDetail_colsCurrentTranslation.Position = 10;
            resources.ApplyResources(this.tblCompanyTranslationDetail_colsCurrentTranslation, "tblCompanyTranslationDetail_colsCurrentTranslation");
            // 
            // tblCompanyTranslationDetail_colsInstallationTranslation
            // 
            resources.ApplyResources(this.tblCompanyTranslationDetail_colsInstallationTranslation, "tblCompanyTranslationDetail_colsInstallationTranslation");
            this.tblCompanyTranslationDetail_colsInstallationTranslation.MaxLength = 2000;
            this.tblCompanyTranslationDetail_colsInstallationTranslation.Name = "tblCompanyTranslationDetail_colsInstallationTranslation";
            this.tblCompanyTranslationDetail_colsInstallationTranslation.NamedProperties.Put("EnumerateMethod", "");
            this.tblCompanyTranslationDetail_colsInstallationTranslation.NamedProperties.Put("FieldFlags", "304");
            this.tblCompanyTranslationDetail_colsInstallationTranslation.NamedProperties.Put("LovReference", "");
            this.tblCompanyTranslationDetail_colsInstallationTranslation.NamedProperties.Put("ResizeableChildObject", "");
            this.tblCompanyTranslationDetail_colsInstallationTranslation.NamedProperties.Put("SqlColumn", "INSTALLATION_TRANSLATION");
            this.tblCompanyTranslationDetail_colsInstallationTranslation.NamedProperties.Put("ValidateMethod", "");
            this.tblCompanyTranslationDetail_colsInstallationTranslation.Position = 11;
            // 
            // tblCompanyTranslationDetail_colsSystemDefined
            // 
            resources.ApplyResources(this.tblCompanyTranslationDetail_colsSystemDefined, "tblCompanyTranslationDetail_colsSystemDefined");
            this.tblCompanyTranslationDetail_colsSystemDefined.MaxLength = 5;
            this.tblCompanyTranslationDetail_colsSystemDefined.Name = "tblCompanyTranslationDetail_colsSystemDefined";
            this.tblCompanyTranslationDetail_colsSystemDefined.NamedProperties.Put("EnumerateMethod", "");
            this.tblCompanyTranslationDetail_colsSystemDefined.NamedProperties.Put("FieldFlags", "289");
            this.tblCompanyTranslationDetail_colsSystemDefined.NamedProperties.Put("LovReference", "");
            this.tblCompanyTranslationDetail_colsSystemDefined.NamedProperties.Put("ResizeableChildObject", "");
            this.tblCompanyTranslationDetail_colsSystemDefined.NamedProperties.Put("SqlColumn", "SYSTEM_DEFINED");
            this.tblCompanyTranslationDetail_colsSystemDefined.NamedProperties.Put("ValidateMethod", "");
            this.tblCompanyTranslationDetail_colsSystemDefined.Position = 12;
            // 
            // frmCompanyTranslation
            // 
            resources.ApplyResources(this, "$this");
            this.ContextMenuStrip = this.menuFrmMethods;
            this.Controls.Add(this.tblCompanyTranslationDetail);
            this.Controls.Add(this.dfsLu);
            this.Controls.Add(this.dfsModule);
            this.Controls.Add(this.dfCompanyName);
            this.Controls.Add(this.cmbCompany);
            this.Controls.Add(this.dfsKeyName);
            this.Controls.Add(this.labeldfsLu);
            this.Controls.Add(this.labeldfsModule);
            this.Controls.Add(this.labeldfCompanyName);
            this.Controls.Add(this.labelcmbCompany);
            this.Name = "frmCompanyTranslation";
            this.NamedProperties.Put("DefaultOrderBy", "key_value,module,lu");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "CompanyKeyLu");
            this.NamedProperties.Put("PackageName", "COMPANY_KEY_LU_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "448");
            this.NamedProperties.Put("ViewName", "COMPANY_KEY_LU");
            this.NamedProperties.Put("Warnings", "TRUE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.frmCompanyTranslation_WindowActions);
            this.menuFrmMethods.ResumeLayout(false);
            this.menuTblMethods.ResumeLayout(false);
            this.tblCompanyTranslationDetail.ResumeLayout(false);
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

        public Fnd.Windows.Forms.FndCommand menuTblMethods_menu_Copy_Installation_Translations;
        public Fnd.Windows.Forms.FndCommand menuFrmMethods_menu_Copy_Installation_Translation_T;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuFrmMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Copy;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTblMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Copy_1;
        public cChildTableEntBase tblCompanyTranslationDetail;
        protected cColumn tblCompanyTranslationDetail_colsKeyName;
        protected cColumn tblCompanyTranslationDetail_colsKeyValue;
        protected cColumn tblCompanyTranslationDetail_colsModule;
        protected cColumn tblCompanyTranslationDetail_colsLu;
        protected cColumn tblCompanyTranslationDetail_colsAttributeKey;
        protected cColumn tblCompanyTranslationDetail_colsLanguageCodeDb;
        protected cColumn tblCompanyTranslationDetail_colsLanguageCodeDesc;
        protected cColumn tblCompanyTranslationDetail_colsCurrentTranslation;
        protected cColumn tblCompanyTranslationDetail_colsInstallationTranslation;
        protected cCheckBoxColumn tblCompanyTranslationDetail_colsSystemDefined;
        protected Fnd.Windows.Forms.FndCommand menuTbwMethods_menuCopy_To_Companies___;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_Copy_to_Companies;
	}
}
