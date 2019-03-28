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
	
	public partial class frmClientMapping
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		protected cBackgroundText labelcmbModule;
		public cRecListDataField cmbModule;
		protected cBackgroundText labeldfsLu;
		public cDataField dfsLu;
		protected cBackgroundText labeldfsMappingId;
		public cDataField dfsMappingId;
		protected cBackgroundText labeldfsTranslationLink;
		public cDataField dfsTranslationLink;
		protected cBackgroundText labelcmbTranslationType;
		public cComboBox cmbTranslationType;
		protected cBackgroundText labeldfsClientWindow;
		public cDataField dfsClientWindow;
		protected cBackgroundText labeldfsDescription;
		public cDataField dfsDescription;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClientMapping));
            this.labelcmbModule = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbModule = new Ifs.Fnd.ApplicationForms.cRecListDataField();
            this.labeldfsLu = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsLu = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsMappingId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsMappingId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsTranslationLink = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsTranslationLink = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelcmbTranslationType = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmbTranslationType = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.labeldfsClientWindow = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsClientWindow = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsDescription = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsDescription = new Ifs.Fnd.ApplicationForms.cDataField();
            this.tblClientMappingDetail = new Ifs.Application.Enterp.cChildTableEntBase();
            this.tblClientMappingDetail_colsModule = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblClientMappingDetail_colsLu = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblClientMappingDetail_colsMappingId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblClientMappingDetail_colsColumnId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblClientMappingDetail_colsDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblClientMappingDetail_colsColumnType = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.tblClientMappingDetail_colTranslationLink = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblClientMappingDetail_colsTranslationType = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.tblClientMappingDetail_colsLovReference = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblClientMappingDetail_colsEnumerateMethod = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblClientMappingDetail_colsTranslationTypeDb = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblClientMappingDetail_colsEditFlag = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.tblClientMappingDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelcmbModule
            // 
            resources.ApplyResources(this.labelcmbModule, "labelcmbModule");
            this.labelcmbModule.Name = "labelcmbModule";
            // 
            // cmbModule
            // 
            this.cmbModule.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.cmbModule, "cmbModule");
            this.cmbModule.Name = "cmbModule";
            this.cmbModule.NamedProperties.Put("EnumerateMethod", "");
            this.cmbModule.NamedProperties.Put("FieldFlags", "97");
            this.cmbModule.NamedProperties.Put("Format", "9");
            this.cmbModule.NamedProperties.Put("LovReference", "");
            this.cmbModule.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbModule.NamedProperties.Put("SqlColumn", "MODULE");
            this.cmbModule.NamedProperties.Put("ValidateMethod", "");
            this.cmbModule.NamedProperties.Put("XDataLength", "30");
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
            this.dfsLu.NamedProperties.Put("FieldFlags", "97");
            this.dfsLu.NamedProperties.Put("LovReference", "MODULE_LU(MODULE)");
            this.dfsLu.NamedProperties.Put("ParentName", "cmbModule");
            this.dfsLu.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsLu.NamedProperties.Put("SqlColumn", "LU");
            this.dfsLu.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsMappingId
            // 
            resources.ApplyResources(this.labeldfsMappingId, "labeldfsMappingId");
            this.labeldfsMappingId.Name = "labeldfsMappingId";
            // 
            // dfsMappingId
            // 
            resources.ApplyResources(this.dfsMappingId, "dfsMappingId");
            this.dfsMappingId.Name = "dfsMappingId";
            this.dfsMappingId.NamedProperties.Put("EnumerateMethod", "");
            this.dfsMappingId.NamedProperties.Put("FieldFlags", "161");
            this.dfsMappingId.NamedProperties.Put("LovReference", "");
            this.dfsMappingId.NamedProperties.Put("ParentName", "cmbModule");
            this.dfsMappingId.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsMappingId.NamedProperties.Put("SqlColumn", "MAPPING_ID");
            this.dfsMappingId.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsTranslationLink
            // 
            resources.ApplyResources(this.labeldfsTranslationLink, "labeldfsTranslationLink");
            this.labeldfsTranslationLink.Name = "labeldfsTranslationLink";
            // 
            // dfsTranslationLink
            // 
            this.dfsTranslationLink.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsTranslationLink, "dfsTranslationLink");
            this.dfsTranslationLink.Name = "dfsTranslationLink";
            this.dfsTranslationLink.NamedProperties.Put("EnumerateMethod", "");
            this.dfsTranslationLink.NamedProperties.Put("FieldFlags", "310");
            this.dfsTranslationLink.NamedProperties.Put("LovReference", "");
            this.dfsTranslationLink.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsTranslationLink.NamedProperties.Put("SqlColumn", "TRANSLATION_LINK");
            this.dfsTranslationLink.NamedProperties.Put("ValidateMethod", "");
            // 
            // labelcmbTranslationType
            // 
            resources.ApplyResources(this.labelcmbTranslationType, "labelcmbTranslationType");
            this.labelcmbTranslationType.Name = "labelcmbTranslationType";
            // 
            // cmbTranslationType
            // 
            resources.ApplyResources(this.cmbTranslationType, "cmbTranslationType");
            this.cmbTranslationType.Name = "cmbTranslationType";
            this.cmbTranslationType.NamedProperties.Put("EnumerateMethod", "TRANSLATION_TYPE_API.Enumerate");
            this.cmbTranslationType.NamedProperties.Put("FieldFlags", "292");
            this.cmbTranslationType.NamedProperties.Put("LovReference", "");
            this.cmbTranslationType.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbTranslationType.NamedProperties.Put("SqlColumn", "TRANSLATION_TYPE");
            this.cmbTranslationType.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsClientWindow
            // 
            resources.ApplyResources(this.labeldfsClientWindow, "labeldfsClientWindow");
            this.labeldfsClientWindow.Name = "labeldfsClientWindow";
            // 
            // dfsClientWindow
            // 
            resources.ApplyResources(this.dfsClientWindow, "dfsClientWindow");
            this.dfsClientWindow.Name = "dfsClientWindow";
            this.dfsClientWindow.NamedProperties.Put("EnumerateMethod", "");
            this.dfsClientWindow.NamedProperties.Put("FieldFlags", "289");
            this.dfsClientWindow.NamedProperties.Put("LovReference", "");
            this.dfsClientWindow.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsClientWindow.NamedProperties.Put("SqlColumn", "CLIENT_WINDOW");
            this.dfsClientWindow.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsDescription
            // 
            resources.ApplyResources(this.labeldfsDescription, "labeldfsDescription");
            this.labeldfsDescription.Name = "labeldfsDescription";
            // 
            // dfsDescription
            // 
            resources.ApplyResources(this.dfsDescription, "dfsDescription");
            this.dfsDescription.Name = "dfsDescription";
            this.dfsDescription.NamedProperties.Put("EnumerateMethod", "");
            this.dfsDescription.NamedProperties.Put("FieldFlags", "294");
            this.dfsDescription.NamedProperties.Put("LovReference", "");
            this.dfsDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            // 
            // tblClientMappingDetail
            // 
            this.tblClientMappingDetail.Controls.Add(this.tblClientMappingDetail_colsModule);
            this.tblClientMappingDetail.Controls.Add(this.tblClientMappingDetail_colsLu);
            this.tblClientMappingDetail.Controls.Add(this.tblClientMappingDetail_colsMappingId);
            this.tblClientMappingDetail.Controls.Add(this.tblClientMappingDetail_colsColumnId);
            this.tblClientMappingDetail.Controls.Add(this.tblClientMappingDetail_colsDescription);
            this.tblClientMappingDetail.Controls.Add(this.tblClientMappingDetail_colsColumnType);
            this.tblClientMappingDetail.Controls.Add(this.tblClientMappingDetail_colTranslationLink);
            this.tblClientMappingDetail.Controls.Add(this.tblClientMappingDetail_colsTranslationType);
            this.tblClientMappingDetail.Controls.Add(this.tblClientMappingDetail_colsLovReference);
            this.tblClientMappingDetail.Controls.Add(this.tblClientMappingDetail_colsEnumerateMethod);
            this.tblClientMappingDetail.Controls.Add(this.tblClientMappingDetail_colsTranslationTypeDb);
            this.tblClientMappingDetail.Controls.Add(this.tblClientMappingDetail_colsEditFlag);
            resources.ApplyResources(this.tblClientMappingDetail, "tblClientMappingDetail");
            this.tblClientMappingDetail.Name = "tblClientMappingDetail";
            this.tblClientMappingDetail.NamedProperties.Put("DefaultOrderBy", "");
            this.tblClientMappingDetail.NamedProperties.Put("DefaultWhere", "");
            this.tblClientMappingDetail.NamedProperties.Put("LogicalUnit", "ClientMappingDetail");
            this.tblClientMappingDetail.NamedProperties.Put("PackageName", "CLIENT_MAPPING_DETAIL_API");
            this.tblClientMappingDetail.NamedProperties.Put("ResizeableChildObject", "LLMM");
            this.tblClientMappingDetail.NamedProperties.Put("SourceFlags", "129");
            this.tblClientMappingDetail.NamedProperties.Put("ViewName", "CLIENT_MAPPING_DETAIL");
            this.tblClientMappingDetail.NamedProperties.Put("Warnings", "FALSE");
            this.tblClientMappingDetail.Controls.SetChildIndex(this.tblClientMappingDetail_colsEditFlag, 0);
            this.tblClientMappingDetail.Controls.SetChildIndex(this.tblClientMappingDetail_colsTranslationTypeDb, 0);
            this.tblClientMappingDetail.Controls.SetChildIndex(this.tblClientMappingDetail_colsEnumerateMethod, 0);
            this.tblClientMappingDetail.Controls.SetChildIndex(this.tblClientMappingDetail_colsLovReference, 0);
            this.tblClientMappingDetail.Controls.SetChildIndex(this.tblClientMappingDetail_colsTranslationType, 0);
            this.tblClientMappingDetail.Controls.SetChildIndex(this.tblClientMappingDetail_colTranslationLink, 0);
            this.tblClientMappingDetail.Controls.SetChildIndex(this.tblClientMappingDetail_colsColumnType, 0);
            this.tblClientMappingDetail.Controls.SetChildIndex(this.tblClientMappingDetail_colsDescription, 0);
            this.tblClientMappingDetail.Controls.SetChildIndex(this.tblClientMappingDetail_colsColumnId, 0);
            this.tblClientMappingDetail.Controls.SetChildIndex(this.tblClientMappingDetail_colsMappingId, 0);
            this.tblClientMappingDetail.Controls.SetChildIndex(this.tblClientMappingDetail_colsLu, 0);
            this.tblClientMappingDetail.Controls.SetChildIndex(this.tblClientMappingDetail_colsModule, 0);
            // 
            // tblClientMappingDetail_colsModule
            // 
            this.tblClientMappingDetail_colsModule.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tblClientMappingDetail_colsModule, "tblClientMappingDetail_colsModule");
            this.tblClientMappingDetail_colsModule.MaxLength = 6;
            this.tblClientMappingDetail_colsModule.Name = "tblClientMappingDetail_colsModule";
            this.tblClientMappingDetail_colsModule.NamedProperties.Put("EnumerateMethod", "");
            this.tblClientMappingDetail_colsModule.NamedProperties.Put("FieldFlags", "65");
            this.tblClientMappingDetail_colsModule.NamedProperties.Put("LovReference", "");
            this.tblClientMappingDetail_colsModule.NamedProperties.Put("ResizeableChildObject", "");
            this.tblClientMappingDetail_colsModule.NamedProperties.Put("SqlColumn", "MODULE");
            this.tblClientMappingDetail_colsModule.NamedProperties.Put("ValidateMethod", "");
            this.tblClientMappingDetail_colsModule.Position = 3;
            // 
            // tblClientMappingDetail_colsLu
            // 
            resources.ApplyResources(this.tblClientMappingDetail_colsLu, "tblClientMappingDetail_colsLu");
            this.tblClientMappingDetail_colsLu.MaxLength = 30;
            this.tblClientMappingDetail_colsLu.Name = "tblClientMappingDetail_colsLu";
            this.tblClientMappingDetail_colsLu.NamedProperties.Put("EnumerateMethod", "");
            this.tblClientMappingDetail_colsLu.NamedProperties.Put("FieldFlags", "65");
            this.tblClientMappingDetail_colsLu.NamedProperties.Put("LovReference", "");
            this.tblClientMappingDetail_colsLu.NamedProperties.Put("ResizeableChildObject", "");
            this.tblClientMappingDetail_colsLu.NamedProperties.Put("SqlColumn", "LU");
            this.tblClientMappingDetail_colsLu.NamedProperties.Put("ValidateMethod", "");
            this.tblClientMappingDetail_colsLu.Position = 4;
            // 
            // tblClientMappingDetail_colsMappingId
            // 
            resources.ApplyResources(this.tblClientMappingDetail_colsMappingId, "tblClientMappingDetail_colsMappingId");
            this.tblClientMappingDetail_colsMappingId.MaxLength = 30;
            this.tblClientMappingDetail_colsMappingId.Name = "tblClientMappingDetail_colsMappingId";
            this.tblClientMappingDetail_colsMappingId.NamedProperties.Put("EnumerateMethod", "");
            this.tblClientMappingDetail_colsMappingId.NamedProperties.Put("FieldFlags", "65");
            this.tblClientMappingDetail_colsMappingId.NamedProperties.Put("LovReference", "CLIENT_MAPPING(MODULE,LU)");
            this.tblClientMappingDetail_colsMappingId.NamedProperties.Put("ResizeableChildObject", "");
            this.tblClientMappingDetail_colsMappingId.NamedProperties.Put("SqlColumn", "MAPPING_ID");
            this.tblClientMappingDetail_colsMappingId.NamedProperties.Put("ValidateMethod", "");
            this.tblClientMappingDetail_colsMappingId.Position = 5;
            // 
            // tblClientMappingDetail_colsColumnId
            // 
            this.tblClientMappingDetail_colsColumnId.MaxLength = 30;
            this.tblClientMappingDetail_colsColumnId.Name = "tblClientMappingDetail_colsColumnId";
            this.tblClientMappingDetail_colsColumnId.NamedProperties.Put("EnumerateMethod", "");
            this.tblClientMappingDetail_colsColumnId.NamedProperties.Put("FieldFlags", "161");
            this.tblClientMappingDetail_colsColumnId.NamedProperties.Put("LovReference", "");
            this.tblClientMappingDetail_colsColumnId.NamedProperties.Put("ResizeableChildObject", "");
            this.tblClientMappingDetail_colsColumnId.NamedProperties.Put("SqlColumn", "COLUMN_ID");
            this.tblClientMappingDetail_colsColumnId.NamedProperties.Put("ValidateMethod", "");
            this.tblClientMappingDetail_colsColumnId.Position = 6;
            resources.ApplyResources(this.tblClientMappingDetail_colsColumnId, "tblClientMappingDetail_colsColumnId");
            // 
            // tblClientMappingDetail_colsDescription
            // 
            this.tblClientMappingDetail_colsDescription.MaxLength = 200;
            this.tblClientMappingDetail_colsDescription.Name = "tblClientMappingDetail_colsDescription";
            this.tblClientMappingDetail_colsDescription.NamedProperties.Put("EnumerateMethod", "");
            this.tblClientMappingDetail_colsDescription.NamedProperties.Put("FieldFlags", "290");
            this.tblClientMappingDetail_colsDescription.NamedProperties.Put("LovReference", "");
            this.tblClientMappingDetail_colsDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.tblClientMappingDetail_colsDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.tblClientMappingDetail_colsDescription.NamedProperties.Put("ValidateMethod", "");
            this.tblClientMappingDetail_colsDescription.Position = 7;
            resources.ApplyResources(this.tblClientMappingDetail_colsDescription, "tblClientMappingDetail_colsDescription");
            // 
            // tblClientMappingDetail_colsColumnType
            // 
            this.tblClientMappingDetail_colsColumnType.MaxLength = 200;
            this.tblClientMappingDetail_colsColumnType.Name = "tblClientMappingDetail_colsColumnType";
            this.tblClientMappingDetail_colsColumnType.NamedProperties.Put("EnumerateMethod", "MAPPING_COLUMN_TYPE_API.Enumerate");
            this.tblClientMappingDetail_colsColumnType.NamedProperties.Put("FieldFlags", "289");
            this.tblClientMappingDetail_colsColumnType.NamedProperties.Put("LovReference", "");
            this.tblClientMappingDetail_colsColumnType.NamedProperties.Put("ResizeableChildObject", "");
            this.tblClientMappingDetail_colsColumnType.NamedProperties.Put("SqlColumn", "COLUMN_TYPE");
            this.tblClientMappingDetail_colsColumnType.NamedProperties.Put("ValidateMethod", "");
            this.tblClientMappingDetail_colsColumnType.Position = 8;
            resources.ApplyResources(this.tblClientMappingDetail_colsColumnType, "tblClientMappingDetail_colsColumnType");
            // 
            // tblClientMappingDetail_colTranslationLink
            // 
            this.tblClientMappingDetail_colTranslationLink.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblClientMappingDetail_colTranslationLink.MaxLength = 500;
            this.tblClientMappingDetail_colTranslationLink.Name = "tblClientMappingDetail_colTranslationLink";
            this.tblClientMappingDetail_colTranslationLink.NamedProperties.Put("EnumerateMethod", "");
            this.tblClientMappingDetail_colTranslationLink.NamedProperties.Put("FieldFlags", "310");
            this.tblClientMappingDetail_colTranslationLink.NamedProperties.Put("LovReference", "");
            this.tblClientMappingDetail_colTranslationLink.NamedProperties.Put("ResizeableChildObject", "");
            this.tblClientMappingDetail_colTranslationLink.NamedProperties.Put("SqlColumn", "TRANSLATION_LINK");
            this.tblClientMappingDetail_colTranslationLink.NamedProperties.Put("ValidateMethod", "");
            this.tblClientMappingDetail_colTranslationLink.Position = 9;
            resources.ApplyResources(this.tblClientMappingDetail_colTranslationLink, "tblClientMappingDetail_colTranslationLink");
            // 
            // tblClientMappingDetail_colsTranslationType
            // 
            this.tblClientMappingDetail_colsTranslationType.MaxLength = 200;
            this.tblClientMappingDetail_colsTranslationType.Name = "tblClientMappingDetail_colsTranslationType";
            this.tblClientMappingDetail_colsTranslationType.NamedProperties.Put("EnumerateMethod", "TRANSLATION_TYPE_API.Enumerate");
            this.tblClientMappingDetail_colsTranslationType.NamedProperties.Put("FieldFlags", "293");
            this.tblClientMappingDetail_colsTranslationType.NamedProperties.Put("LovReference", "");
            this.tblClientMappingDetail_colsTranslationType.NamedProperties.Put("ResizeableChildObject", "");
            this.tblClientMappingDetail_colsTranslationType.NamedProperties.Put("SqlColumn", "TRANSLATION_TYPE");
            this.tblClientMappingDetail_colsTranslationType.NamedProperties.Put("ValidateMethod", "");
            this.tblClientMappingDetail_colsTranslationType.Position = 10;
            resources.ApplyResources(this.tblClientMappingDetail_colsTranslationType, "tblClientMappingDetail_colsTranslationType");
            // 
            // tblClientMappingDetail_colsLovReference
            // 
            this.tblClientMappingDetail_colsLovReference.MaxLength = 200;
            this.tblClientMappingDetail_colsLovReference.Name = "tblClientMappingDetail_colsLovReference";
            this.tblClientMappingDetail_colsLovReference.NamedProperties.Put("EnumerateMethod", "");
            this.tblClientMappingDetail_colsLovReference.NamedProperties.Put("FieldFlags", "288");
            this.tblClientMappingDetail_colsLovReference.NamedProperties.Put("LovReference", "");
            this.tblClientMappingDetail_colsLovReference.NamedProperties.Put("ResizeableChildObject", "");
            this.tblClientMappingDetail_colsLovReference.NamedProperties.Put("SqlColumn", "LOV_REFERENCE");
            this.tblClientMappingDetail_colsLovReference.NamedProperties.Put("ValidateMethod", "");
            this.tblClientMappingDetail_colsLovReference.Position = 11;
            resources.ApplyResources(this.tblClientMappingDetail_colsLovReference, "tblClientMappingDetail_colsLovReference");
            // 
            // tblClientMappingDetail_colsEnumerateMethod
            // 
            this.tblClientMappingDetail_colsEnumerateMethod.MaxLength = 200;
            this.tblClientMappingDetail_colsEnumerateMethod.Name = "tblClientMappingDetail_colsEnumerateMethod";
            this.tblClientMappingDetail_colsEnumerateMethod.NamedProperties.Put("EnumerateMethod", "");
            this.tblClientMappingDetail_colsEnumerateMethod.NamedProperties.Put("FieldFlags", "288");
            this.tblClientMappingDetail_colsEnumerateMethod.NamedProperties.Put("LovReference", "");
            this.tblClientMappingDetail_colsEnumerateMethod.NamedProperties.Put("ResizeableChildObject", "");
            this.tblClientMappingDetail_colsEnumerateMethod.NamedProperties.Put("SqlColumn", "ENUMERATE_METHOD");
            this.tblClientMappingDetail_colsEnumerateMethod.NamedProperties.Put("ValidateMethod", "");
            this.tblClientMappingDetail_colsEnumerateMethod.Position = 12;
            resources.ApplyResources(this.tblClientMappingDetail_colsEnumerateMethod, "tblClientMappingDetail_colsEnumerateMethod");
            // 
            // tblClientMappingDetail_colsTranslationTypeDb
            // 
            resources.ApplyResources(this.tblClientMappingDetail_colsTranslationTypeDb, "tblClientMappingDetail_colsTranslationTypeDb");
            this.tblClientMappingDetail_colsTranslationTypeDb.MaxLength = 20;
            this.tblClientMappingDetail_colsTranslationTypeDb.Name = "tblClientMappingDetail_colsTranslationTypeDb";
            this.tblClientMappingDetail_colsTranslationTypeDb.NamedProperties.Put("EnumerateMethod", "");
            this.tblClientMappingDetail_colsTranslationTypeDb.NamedProperties.Put("FieldFlags", "4352");
            this.tblClientMappingDetail_colsTranslationTypeDb.NamedProperties.Put("LovReference", "");
            this.tblClientMappingDetail_colsTranslationTypeDb.NamedProperties.Put("ResizeableChildObject", "");
            this.tblClientMappingDetail_colsTranslationTypeDb.NamedProperties.Put("SqlColumn", "TRANSLATION_TYPE_DB");
            this.tblClientMappingDetail_colsTranslationTypeDb.NamedProperties.Put("ValidateMethod", "");
            this.tblClientMappingDetail_colsTranslationTypeDb.Position = 13;
            // 
            // tblClientMappingDetail_colsEditFlag
            // 
            this.tblClientMappingDetail_colsEditFlag.MaxLength = 5;
            this.tblClientMappingDetail_colsEditFlag.Name = "tblClientMappingDetail_colsEditFlag";
            this.tblClientMappingDetail_colsEditFlag.NamedProperties.Put("EnumerateMethod", "");
            this.tblClientMappingDetail_colsEditFlag.NamedProperties.Put("FieldFlags", "288");
            this.tblClientMappingDetail_colsEditFlag.NamedProperties.Put("LovReference", "");
            this.tblClientMappingDetail_colsEditFlag.NamedProperties.Put("ResizeableChildObject", "");
            this.tblClientMappingDetail_colsEditFlag.NamedProperties.Put("SqlColumn", "EDIT_FLAG");
            this.tblClientMappingDetail_colsEditFlag.NamedProperties.Put("ValidateMethod", "");
            this.tblClientMappingDetail_colsEditFlag.Position = 14;
            resources.ApplyResources(this.tblClientMappingDetail_colsEditFlag, "tblClientMappingDetail_colsEditFlag");
            // 
            // frmClientMapping
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.dfsDescription);
            this.Controls.Add(this.tblClientMappingDetail);
            this.Controls.Add(this.dfsClientWindow);
            this.Controls.Add(this.cmbTranslationType);
            this.Controls.Add(this.dfsTranslationLink);
            this.Controls.Add(this.dfsMappingId);
            this.Controls.Add(this.dfsLu);
            this.Controls.Add(this.cmbModule);
            this.Controls.Add(this.labeldfsDescription);
            this.Controls.Add(this.labeldfsClientWindow);
            this.Controls.Add(this.labelcmbTranslationType);
            this.Controls.Add(this.labeldfsTranslationLink);
            this.Controls.Add(this.labeldfsMappingId);
            this.Controls.Add(this.labeldfsLu);
            this.Controls.Add(this.labelcmbModule);
            this.Name = "frmClientMapping";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "ClientMapping");
            this.NamedProperties.Put("PackageName", "CLIENT_MAPPING_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "129");
            this.NamedProperties.Put("ViewName", "CLIENT_MAPPING");
            this.NamedProperties.Put("Warnings", "TRUE");
            this.tblClientMappingDetail.ResumeLayout(false);
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

        public cChildTableEntBase tblClientMappingDetail;
        protected cColumn tblClientMappingDetail_colsModule;
        protected cColumn tblClientMappingDetail_colsLu;
        protected cColumn tblClientMappingDetail_colsMappingId;
        protected cColumn tblClientMappingDetail_colsColumnId;
        protected cColumn tblClientMappingDetail_colsDescription;
        protected cLookupColumn tblClientMappingDetail_colsColumnType;
        protected cColumn tblClientMappingDetail_colTranslationLink;
        protected cLookupColumn tblClientMappingDetail_colsTranslationType;
        protected cColumn tblClientMappingDetail_colsLovReference;
        protected cColumn tblClientMappingDetail_colsEnumerateMethod;
        protected cColumn tblClientMappingDetail_colsTranslationTypeDb;
        protected cCheckBoxColumn tblClientMappingDetail_colsEditFlag;
		
	}
}
