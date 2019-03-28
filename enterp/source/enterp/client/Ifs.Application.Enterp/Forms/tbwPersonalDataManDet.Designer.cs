#region Copyright (c) IFS Research & Development
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
#endregion
#region History
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ifs.Fnd.ApplicationForms;
using PPJ.Runtime;
using PPJ.Runtime.Windows;

namespace Ifs.Application.Enterp
{

    public partial class tbwPersonalDataManDet
    {

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwPersonalDataManDet));
            this.colsDataSubject = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.colsFieldValue = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colnPersDataManagementId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colMandatory = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.colsStorageType = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.colsMaskedValue = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsReference = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.colsSkipAnonymize = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.colsFieldType = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.colnFieldDataLength = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsFieldDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsApplicationArea = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colnReportOrder = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsExcludeFromCleanupDb = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsPersonalData = new Ifs.Fnd.ApplicationForms.cColumn();
            this.SuspendLayout();
            // 
            // __colObjid
            // 
            this.@__colObjid.Position = 2;
            // 
            // __colObjversion
            // 
            this.@__colObjversion.Position = 1;
            // 
            // colsDataSubject
            // 
            this.colsDataSubject.MaxLength = 200;
            this.colsDataSubject.Name = "colsDataSubject";
            this.colsDataSubject.NamedProperties.Put("EnumerateMethod", "DATA_SUBJECT_API.Enumerate");
            this.colsDataSubject.NamedProperties.Put("FieldFlags", "291");
            this.colsDataSubject.NamedProperties.Put("LovReference", "");
            this.colsDataSubject.NamedProperties.Put("SqlColumn", "DATA_SUBJECT");
            this.colsDataSubject.Position = 5;
            resources.ApplyResources(this.colsDataSubject, "colsDataSubject");
            // 
            // colsFieldValue
            // 
            this.colsFieldValue.MaxLength = 200;
            this.colsFieldValue.Name = "colsFieldValue";
            this.colsFieldValue.NamedProperties.Put("EnumerateMethod", "");
            this.colsFieldValue.NamedProperties.Put("FieldFlags", "258");
            this.colsFieldValue.NamedProperties.Put("LovReference", "");
            this.colsFieldValue.NamedProperties.Put("SqlColumn", "FIELD_VALUE");
            this.colsFieldValue.Position = 11;
            resources.ApplyResources(this.colsFieldValue, "colsFieldValue");
            // 
            // colnPersDataManagementId
            // 
            this.colnPersDataManagementId.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnPersDataManagementId.Name = "colnPersDataManagementId";
            this.colnPersDataManagementId.NamedProperties.Put("EnumerateMethod", "");
            this.colnPersDataManagementId.NamedProperties.Put("FieldFlags", "67");
            this.colnPersDataManagementId.NamedProperties.Put("Format", "");
            this.colnPersDataManagementId.NamedProperties.Put("LovReference", "PERSONAL_DATA_MANAGEMENT");
            this.colnPersDataManagementId.NamedProperties.Put("SqlColumn", "PERS_DATA_MANAGEMENT_ID");
            this.colnPersDataManagementId.Position = 3;
            this.colnPersDataManagementId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.colnPersDataManagementId, "colnPersDataManagementId");
            // 
            // colMandatory
            // 
            this.colMandatory.MaxLength = 20;
            this.colMandatory.Name = "colMandatory";
            this.colMandatory.NamedProperties.Put("EnumerateMethod", "");
            this.colMandatory.NamedProperties.Put("FieldFlags", "295");
            this.colMandatory.NamedProperties.Put("LovReference", "");
            this.colMandatory.NamedProperties.Put("SqlColumn", "MANDATORY_DB");
            this.colMandatory.Position = 13;
            resources.ApplyResources(this.colMandatory, "colMandatory");
            // 
            // colsStorageType
            // 
            this.colsStorageType.MaxLength = 200;
            this.colsStorageType.Name = "colsStorageType";
            this.colsStorageType.NamedProperties.Put("EnumerateMethod", "STORAGE_TYPE_API.Enumerate");
            this.colsStorageType.NamedProperties.Put("FieldFlags", "259");
            this.colsStorageType.NamedProperties.Put("LovReference", "");
            this.colsStorageType.NamedProperties.Put("SqlColumn", "STORAGE_TYPE");
            this.colsStorageType.Position = 6;
            resources.ApplyResources(this.colsStorageType, "colsStorageType");
            // 
            // colsMaskedValue
            // 
            this.colsMaskedValue.MaxLength = 200;
            this.colsMaskedValue.Name = "colsMaskedValue";
            this.colsMaskedValue.NamedProperties.Put("EnumerateMethod", "");
            this.colsMaskedValue.NamedProperties.Put("FieldFlags", "294");
            this.colsMaskedValue.NamedProperties.Put("LovReference", "");
            this.colsMaskedValue.NamedProperties.Put("SqlColumn", "MASKED_VALUE");
            this.colsMaskedValue.Position = 17;
            resources.ApplyResources(this.colsMaskedValue, "colsMaskedValue");
            // 
            // colsReference
            // 
            this.colsReference.CellType = PPJ.Runtime.Windows.CellType.CheckBox;
            this.colsReference.CheckBox.CheckedValue = "TRUE";
            this.colsReference.CheckBox.IgnoreCase = true;
            this.colsReference.CheckBox.UncheckedValue = "FALSE";
            this.colsReference.MaxLength = 20;
            this.colsReference.Name = "colsReference";
            this.colsReference.NamedProperties.Put("EnumerateMethod", "");
            this.colsReference.NamedProperties.Put("FieldFlags", "263");
            this.colsReference.NamedProperties.Put("LovReference", "");
            this.colsReference.NamedProperties.Put("SqlColumn", "REFERENCE_DB");
            this.colsReference.Position = 14;
            resources.ApplyResources(this.colsReference, "colsReference");
            // 
            // colsSkipAnonymize
            // 
            this.colsSkipAnonymize.CellType = PPJ.Runtime.Windows.CellType.CheckBox;
            this.colsSkipAnonymize.CheckBox.CheckedValue = "TRUE";
            this.colsSkipAnonymize.CheckBox.IgnoreCase = true;
            this.colsSkipAnonymize.CheckBox.UncheckedValue = "FALSE";
            this.colsSkipAnonymize.MaxLength = 20;
            this.colsSkipAnonymize.Name = "colsSkipAnonymize";
            this.colsSkipAnonymize.NamedProperties.Put("EnumerateMethod", "");
            this.colsSkipAnonymize.NamedProperties.Put("FieldFlags", "261");
            this.colsSkipAnonymize.NamedProperties.Put("LovReference", "");
            this.colsSkipAnonymize.NamedProperties.Put("SqlColumn", "SKIP_ANONYMIZE_DB");
            this.colsSkipAnonymize.Position = 15;
            resources.ApplyResources(this.colsSkipAnonymize, "colsSkipAnonymize");
            // 
            // colsFieldType
            // 
            this.colsFieldType.MaxLength = 200;
            this.colsFieldType.Name = "colsFieldType";
            this.colsFieldType.NamedProperties.Put("EnumerateMethod", "DATA_TYPE_API.Enumerate");
            this.colsFieldType.NamedProperties.Put("FieldFlags", "290");
            this.colsFieldType.NamedProperties.Put("LovReference", "");
            this.colsFieldType.NamedProperties.Put("SqlColumn", "FIELD_TYPE");
            this.colsFieldType.Position = 10;
            resources.ApplyResources(this.colsFieldType, "colsFieldType");
            // 
            // colnFieldDataLength
            // 
            this.colnFieldDataLength.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnFieldDataLength.Name = "colnFieldDataLength";
            this.colnFieldDataLength.NamedProperties.Put("EnumerateMethod", "");
            this.colnFieldDataLength.NamedProperties.Put("FieldFlags", "290");
            this.colnFieldDataLength.NamedProperties.Put("Format", "");
            this.colnFieldDataLength.NamedProperties.Put("LovReference", "");
            this.colnFieldDataLength.NamedProperties.Put("SqlColumn", "FIELD_DATA_LENGTH");
            this.colnFieldDataLength.Position = 12;
            this.colnFieldDataLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.colnFieldDataLength, "colnFieldDataLength");
            // 
            // colsFieldDescription
            // 
            this.colsFieldDescription.MaxLength = 200;
            this.colsFieldDescription.Name = "colsFieldDescription";
            this.colsFieldDescription.NamedProperties.Put("EnumerateMethod", "");
            this.colsFieldDescription.NamedProperties.Put("FieldFlags", "288");
            this.colsFieldDescription.NamedProperties.Put("LovReference", "");
            this.colsFieldDescription.NamedProperties.Put("SqlColumn", "FIELD_DESCRIPTION");
            this.colsFieldDescription.Position = 8;
            resources.ApplyResources(this.colsFieldDescription, "colsFieldDescription");
            // 
            // colsApplicationArea
            // 
            this.colsApplicationArea.MaxLength = 200;
            this.colsApplicationArea.Name = "colsApplicationArea";
            this.colsApplicationArea.NamedProperties.Put("EnumerateMethod", "");
            this.colsApplicationArea.NamedProperties.Put("FieldFlags", "288");
            this.colsApplicationArea.NamedProperties.Put("LovReference", "");
            this.colsApplicationArea.NamedProperties.Put("SqlColumn", "APPLICATION_AREA");
            this.colsApplicationArea.Position = 7;
            resources.ApplyResources(this.colsApplicationArea, "colsApplicationArea");
            // 
            // colnReportOrder
            // 
            this.colnReportOrder.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnReportOrder.Name = "colnReportOrder";
            this.colnReportOrder.NamedProperties.Put("EnumerateMethod", "");
            this.colnReportOrder.NamedProperties.Put("FieldFlags", "258");
            this.colnReportOrder.NamedProperties.Put("LovReference", "");
            this.colnReportOrder.NamedProperties.Put("SqlColumn", "REPORT_ORDER");
            this.colnReportOrder.Position = 9;
            resources.ApplyResources(this.colnReportOrder, "colnReportOrder");
            // 
            // colsExcludeFromCleanupDb
            // 
            this.colsExcludeFromCleanupDb.CellType = PPJ.Runtime.Windows.CellType.CheckBox;
            this.colsExcludeFromCleanupDb.CheckBox.CheckedValue = "TRUE";
            this.colsExcludeFromCleanupDb.CheckBox.IgnoreCase = true;
            this.colsExcludeFromCleanupDb.CheckBox.UncheckedValue = "FALSE";
            this.colsExcludeFromCleanupDb.MaxLength = 20;
            this.colsExcludeFromCleanupDb.Name = "colsExcludeFromCleanupDb";
            this.colsExcludeFromCleanupDb.NamedProperties.Put("EnumerateMethod", "");
            this.colsExcludeFromCleanupDb.NamedProperties.Put("FieldFlags", "257");
            this.colsExcludeFromCleanupDb.NamedProperties.Put("LovReference", "");
            this.colsExcludeFromCleanupDb.NamedProperties.Put("SqlColumn", "EXCLUDE_FROM_CLEANUP_DB");
            this.colsExcludeFromCleanupDb.Position = 16;
            resources.ApplyResources(this.colsExcludeFromCleanupDb, "colsExcludeFromCleanupDb");
            // 
            // colsPersonalData
            // 
            this.colsPersonalData.MaxLength = 30;
            this.colsPersonalData.Name = "colsPersonalData";
            this.colsPersonalData.NamedProperties.Put("EnumerateMethod", "");
            this.colsPersonalData.NamedProperties.Put("FieldFlags", "288");
            this.colsPersonalData.NamedProperties.Put("LovReference", "");
            this.colsPersonalData.NamedProperties.Put("SqlColumn", "PERSONAL_DATA");
            this.colsPersonalData.Position = 4;
            resources.ApplyResources(this.colsPersonalData, "colsPersonalData");
            // 
            // tbwPersonalDataManDet
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colnPersDataManagementId);
            this.Controls.Add(this.colsPersonalData);
            this.Controls.Add(this.colsDataSubject);
            this.Controls.Add(this.colsStorageType);
            this.Controls.Add(this.colsApplicationArea);
            this.Controls.Add(this.colsFieldDescription);
            this.Controls.Add(this.colnReportOrder);
            this.Controls.Add(this.colsFieldType);
            this.Controls.Add(this.colsFieldValue);
            this.Controls.Add(this.colnFieldDataLength);
            this.Controls.Add(this.colMandatory);
            this.Controls.Add(this.colsReference);
            this.Controls.Add(this.colsSkipAnonymize);
            this.Controls.Add(this.colsExcludeFromCleanupDb);
            this.Controls.Add(this.colsMaskedValue);
            this.Name = "tbwPersonalDataManDet";
            this.NamedProperties.Put("DefaultWhere", "storage_type_db  = \'FIELD\'");
            this.NamedProperties.Put("LogicalUnit", "PersonalDataManDet");
            this.NamedProperties.Put("Module", "ENTERP");
            this.NamedProperties.Put("PackageName", "PERSONAL_DATA_MAN_DET_API");
            this.NamedProperties.Put("SourceFlags", "129");
            this.NamedProperties.Put("ViewName", "PERSONAL_DATA_MAN_DET");
            this.Controls.SetChildIndex(this.colsMaskedValue, 0);
            this.Controls.SetChildIndex(this.colsExcludeFromCleanupDb, 0);
            this.Controls.SetChildIndex(this.colsSkipAnonymize, 0);
            this.Controls.SetChildIndex(this.colsReference, 0);
            this.Controls.SetChildIndex(this.colMandatory, 0);
            this.Controls.SetChildIndex(this.colnFieldDataLength, 0);
            this.Controls.SetChildIndex(this.colsFieldValue, 0);
            this.Controls.SetChildIndex(this.colsFieldType, 0);
            this.Controls.SetChildIndex(this.colnReportOrder, 0);
            this.Controls.SetChildIndex(this.colsFieldDescription, 0);
            this.Controls.SetChildIndex(this.colsApplicationArea, 0);
            this.Controls.SetChildIndex(this.colsStorageType, 0);
            this.Controls.SetChildIndex(this.colsDataSubject, 0);
            this.Controls.SetChildIndex(this.colsPersonalData, 0);
            this.Controls.SetChildIndex(this.colnPersDataManagementId, 0);
            this.Controls.SetChildIndex(this.@__colObjid, 0);
            this.Controls.SetChildIndex(this.@__colObjversion, 0);
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

        protected cLookupColumn colsDataSubject;
        protected cColumn colsFieldValue;
        protected cColumn colnPersDataManagementId;
        protected cCheckBoxColumn colMandatory;
        protected cLookupColumn colsStorageType;
        protected cColumn colsMaskedValue;
        protected cLookupColumn colsReference;
        protected cLookupColumn colsSkipAnonymize;
        protected cLookupColumn colsFieldType;
        protected cColumn colnFieldDataLength;
        protected cColumn colsFieldDescription;
        protected cColumn colsApplicationArea;
        protected cColumn colnReportOrder;
        protected cColumn colsExcludeFromCleanupDb;
        protected cColumn colsPersonalData;
    }
}
