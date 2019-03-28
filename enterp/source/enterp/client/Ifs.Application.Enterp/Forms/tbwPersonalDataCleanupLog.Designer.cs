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

    public partial class tbwPersonalDataCleanupLog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwPersonalDataCleanupLog));
            this.colsKeyRef = new Ifs.Fnd.ApplicationForms.cColumn();
            this.coldOperationDate = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colnPersDataManagementId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colnSeqNo = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colCompleted = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.colsErrorMessage = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsPersonalData = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsDataSubjectId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsDataSubject = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsAction = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.colsActionDb = new Ifs.Fnd.ApplicationForms.cColumn();
            this.SuspendLayout();
            // 
            // colsKeyRef
            // 
            this.colsKeyRef.Name = "colsKeyRef";
            this.colsKeyRef.NamedProperties.Put("EnumerateMethod", "");
            this.colsKeyRef.NamedProperties.Put("FieldFlags", "99");
            this.colsKeyRef.NamedProperties.Put("LovReference", "");
            this.colsKeyRef.NamedProperties.Put("SqlColumn", "KEY_REF");
            this.colsKeyRef.Position = 4;
            resources.ApplyResources(this.colsKeyRef, "colsKeyRef");
            // 
            // coldOperationDate
            // 
            this.coldOperationDate.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.coldOperationDate.Format = "G";
            this.coldOperationDate.Name = "coldOperationDate";
            this.coldOperationDate.NamedProperties.Put("EnumerateMethod", "");
            this.coldOperationDate.NamedProperties.Put("FieldFlags", "99");
            this.coldOperationDate.NamedProperties.Put("LovReference", "");
            this.coldOperationDate.NamedProperties.Put("SqlColumn", "OPERATION_DATE");
            this.coldOperationDate.Position = 9;
            resources.ApplyResources(this.coldOperationDate, "coldOperationDate");
            // 
            // colnPersDataManagementId
            // 
            this.colnPersDataManagementId.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnPersDataManagementId.Name = "colnPersDataManagementId";
            this.colnPersDataManagementId.NamedProperties.Put("EnumerateMethod", "");
            this.colnPersDataManagementId.NamedProperties.Put("FieldFlags", "99");
            this.colnPersDataManagementId.NamedProperties.Put("Format", "");
            this.colnPersDataManagementId.NamedProperties.Put("LovReference", "PERSONAL_DATA_MANAGEMENT");
            this.colnPersDataManagementId.NamedProperties.Put("SqlColumn", "PERS_DATA_MANAGEMENT_ID");
            this.colnPersDataManagementId.Position = 10;
            this.colnPersDataManagementId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.colnPersDataManagementId, "colnPersDataManagementId");
            // 
            // colnSeqNo
            // 
            this.colnSeqNo.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnSeqNo.Name = "colnSeqNo";
            this.colnSeqNo.NamedProperties.Put("EnumerateMethod", "");
            this.colnSeqNo.NamedProperties.Put("FieldFlags", "163");
            this.colnSeqNo.NamedProperties.Put("Format", "");
            this.colnSeqNo.NamedProperties.Put("LovReference", "");
            this.colnSeqNo.NamedProperties.Put("SqlColumn", "SEQ_NO");
            this.colnSeqNo.Position = 3;
            this.colnSeqNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.colnSeqNo, "colnSeqNo");
            // 
            // colCompleted
            // 
            this.colCompleted.MaxLength = 20;
            this.colCompleted.Name = "colCompleted";
            this.colCompleted.NamedProperties.Put("EnumerateMethod", "");
            this.colCompleted.NamedProperties.Put("FieldFlags", "288");
            this.colCompleted.NamedProperties.Put("LovReference", "");
            this.colCompleted.NamedProperties.Put("SqlColumn", "COMPLETED_DB");
            this.colCompleted.Position = 12;
            resources.ApplyResources(this.colCompleted, "colCompleted");
            // 
            // colsErrorMessage
            // 
            this.colsErrorMessage.MaxLength = 2000;
            this.colsErrorMessage.Name = "colsErrorMessage";
            this.colsErrorMessage.NamedProperties.Put("EnumerateMethod", "");
            this.colsErrorMessage.NamedProperties.Put("FieldFlags", "306");
            this.colsErrorMessage.NamedProperties.Put("LovReference", "");
            this.colsErrorMessage.NamedProperties.Put("SqlColumn", "ERROR_MESSAGE");
            this.colsErrorMessage.Position = 13;
            resources.ApplyResources(this.colsErrorMessage, "colsErrorMessage");
            // 
            // colsPersonalData
            // 
            this.colsPersonalData.MaxLength = 30;
            this.colsPersonalData.Name = "colsPersonalData";
            this.colsPersonalData.NamedProperties.Put("EnumerateMethod", "");
            this.colsPersonalData.NamedProperties.Put("FieldFlags", "288");
            this.colsPersonalData.NamedProperties.Put("LovReference", "");
            this.colsPersonalData.NamedProperties.Put("SqlColumn", "PERSONAL_DATA");
            this.colsPersonalData.Position = 11;
            resources.ApplyResources(this.colsPersonalData, "colsPersonalData");
            // 
            // colsDataSubjectId
            // 
            this.colsDataSubjectId.MaxLength = 50;
            this.colsDataSubjectId.Name = "colsDataSubjectId";
            this.colsDataSubjectId.NamedProperties.Put("EnumerateMethod", "");
            this.colsDataSubjectId.NamedProperties.Put("FieldFlags", "288");
            this.colsDataSubjectId.NamedProperties.Put("LovReference", "");
            this.colsDataSubjectId.NamedProperties.Put("SqlColumn", "DATA_SUBJECT_ID");
            this.colsDataSubjectId.Position = 5;
            resources.ApplyResources(this.colsDataSubjectId, "colsDataSubjectId");
            // 
            // colsDataSubject
            // 
            this.colsDataSubject.MaxLength = 20;
            this.colsDataSubject.Name = "colsDataSubject";
            this.colsDataSubject.NamedProperties.Put("EnumerateMethod", "");
            this.colsDataSubject.NamedProperties.Put("FieldFlags", "288");
            this.colsDataSubject.NamedProperties.Put("LovReference", "");
            this.colsDataSubject.NamedProperties.Put("SqlColumn", "DATA_SUBJECT");
            this.colsDataSubject.Position = 6;
            resources.ApplyResources(this.colsDataSubject, "colsDataSubject");
            // 
            // colsAction
            // 
            this.colsAction.MaxLength = 200;
            this.colsAction.Name = "colsAction";
            this.colsAction.NamedProperties.Put("EnumerateMethod", "DATA_SUB_CONSENT_ACTION_API.Enumerate");
            this.colsAction.NamedProperties.Put("FieldFlags", "99");
            this.colsAction.NamedProperties.Put("LovReference", "DATA_SUBJECT_CONSENT_OPER(KEY_REF,OPERATION_DATE)");
            this.colsAction.NamedProperties.Put("SqlColumn", "ACTION");
            this.colsAction.Position = 7;
            resources.ApplyResources(this.colsAction, "colsAction");
            // 
            // colsActionDb
            // 
            this.colsActionDb.MaxLength = 20;
            this.colsActionDb.Name = "colsActionDb";
            this.colsActionDb.NamedProperties.Put("EnumerateMethod", "");
            this.colsActionDb.NamedProperties.Put("FieldFlags", "288");
            this.colsActionDb.NamedProperties.Put("LovReference", "");
            this.colsActionDb.NamedProperties.Put("SqlColumn", "ACTION_DB");
            this.colsActionDb.Position = 8;
            resources.ApplyResources(this.colsActionDb, "colsActionDb");
            // 
            // tbwPersonalDataCleanupLog
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colnSeqNo);
            this.Controls.Add(this.colsKeyRef);
            this.Controls.Add(this.colsDataSubjectId);
            this.Controls.Add(this.colsDataSubject);
            this.Controls.Add(this.colsAction);
            this.Controls.Add(this.colsActionDb);
            this.Controls.Add(this.coldOperationDate);
            this.Controls.Add(this.colnPersDataManagementId);
            this.Controls.Add(this.colsPersonalData);
            this.Controls.Add(this.colCompleted);
            this.Controls.Add(this.colsErrorMessage);
            this.Name = "tbwPersonalDataCleanupLog";
            this.NamedProperties.Put("LogicalUnit", "PersonalDataCleanupLog");
            this.NamedProperties.Put("Module", "Enterp");
            this.NamedProperties.Put("PackageName", "PERSONAL_DATA_CLEANUP_LOG_API");
            this.NamedProperties.Put("SourceFlags", "1");
            this.NamedProperties.Put("ViewName", "PERSONAL_DATA_CLEANUP_LOG");
            this.Controls.SetChildIndex(this.colsErrorMessage, 0);
            this.Controls.SetChildIndex(this.colCompleted, 0);
            this.Controls.SetChildIndex(this.colsPersonalData, 0);
            this.Controls.SetChildIndex(this.colnPersDataManagementId, 0);
            this.Controls.SetChildIndex(this.coldOperationDate, 0);
            this.Controls.SetChildIndex(this.colsActionDb, 0);
            this.Controls.SetChildIndex(this.colsAction, 0);
            this.Controls.SetChildIndex(this.colsDataSubject, 0);
            this.Controls.SetChildIndex(this.colsDataSubjectId, 0);
            this.Controls.SetChildIndex(this.colsKeyRef, 0);
            this.Controls.SetChildIndex(this.colnSeqNo, 0);
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

        protected cColumn colsKeyRef;
        protected cColumn coldOperationDate;
        protected cColumn colnPersDataManagementId;
        protected cColumn colnSeqNo;
        protected cCheckBoxColumn colCompleted;
        protected cColumn colsErrorMessage;
        protected cColumn colsPersonalData;
        protected cColumn colsDataSubjectId;
        protected cColumn colsDataSubject;
        protected cLookupColumn colsAction;
        protected cColumn colsActionDb;
    }
}
