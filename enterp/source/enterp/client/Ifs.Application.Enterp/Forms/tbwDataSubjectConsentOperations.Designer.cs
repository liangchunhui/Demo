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

    public partial class tbwDataSubjectConsentOperations
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwDataSubjectConsentOperations));
            this.colsKeyRef = new Ifs.Fnd.ApplicationForms.cColumn();
            this.coldOperationDate = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsAction = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.colsDataSubject = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsIdentity = new Ifs.Fnd.ApplicationForms.cColumn();
            this.coldUpdateDate = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsRemark = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsPerformedBy = new Ifs.Fnd.ApplicationForms.cColumn();
            this.cmdDataCleanupLog = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.contextMenu = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.tsMenuItem_DataCleanupLog = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.colsCleanupFailure = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsActionDb = new Ifs.Fnd.ApplicationForms.cColumn();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.cmdDataCleanupLog);
            this.commandManager.ContextMenus.Add(this.contextMenu);
            // 
            // colsKeyRef
            // 
            this.colsKeyRef.Name = "colsKeyRef";
            this.colsKeyRef.NamedProperties.Put("EnumerateMethod", "");
            this.colsKeyRef.NamedProperties.Put("FieldFlags", "67");
            this.colsKeyRef.NamedProperties.Put("LovReference", "");
            this.colsKeyRef.NamedProperties.Put("SqlColumn", "KEY_REF");
            this.colsKeyRef.Position = 3;
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
            this.coldOperationDate.Position = 11;
            resources.ApplyResources(this.coldOperationDate, "coldOperationDate");
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
            // colsDataSubject
            // 
            this.colsDataSubject.MaxLength = 200;
            this.colsDataSubject.Name = "colsDataSubject";
            this.colsDataSubject.NamedProperties.Put("EnumerateMethod", "DATA_SUBJECT_API.Enumerate_Active");
            this.colsDataSubject.NamedProperties.Put("FieldFlags", "99");
            this.colsDataSubject.NamedProperties.Put("LovReference", "");
            this.colsDataSubject.NamedProperties.Put("SqlColumn", "DATA_SUBJECT");
            this.colsDataSubject.Position = 5;
            resources.ApplyResources(this.colsDataSubject, "colsDataSubject");
            // 
            // colsIdentity
            // 
            this.colsIdentity.MaxLength = 200;
            this.colsIdentity.Name = "colsIdentity";
            this.colsIdentity.NamedProperties.Put("EnumerateMethod", "");
            this.colsIdentity.NamedProperties.Put("FieldFlags", "288");
            this.colsIdentity.NamedProperties.Put("LovReference", "");
            this.colsIdentity.NamedProperties.Put("SqlColumn", "IDENTITY");
            this.colsIdentity.Position = 4;
            resources.ApplyResources(this.colsIdentity, "colsIdentity");
            // 
            // coldUpdateDate
            // 
            this.coldUpdateDate.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.coldUpdateDate.Format = "d";
            this.coldUpdateDate.Name = "coldUpdateDate";
            this.coldUpdateDate.NamedProperties.Put("EnumerateMethod", "");
            this.coldUpdateDate.NamedProperties.Put("FieldFlags", "288");
            this.coldUpdateDate.NamedProperties.Put("LovReference", "");
            this.coldUpdateDate.NamedProperties.Put("SqlColumn", "UPDATE_DATE");
            this.coldUpdateDate.Position = 6;
            resources.ApplyResources(this.coldUpdateDate, "coldUpdateDate");
            // 
            // colsRemark
            // 
            this.colsRemark.MaxLength = 2000;
            this.colsRemark.Name = "colsRemark";
            this.colsRemark.NamedProperties.Put("EnumerateMethod", "");
            this.colsRemark.NamedProperties.Put("FieldFlags", "304");
            this.colsRemark.NamedProperties.Put("LovReference", "");
            this.colsRemark.NamedProperties.Put("SqlColumn", "REMARK");
            this.colsRemark.Position = 9;
            resources.ApplyResources(this.colsRemark, "colsRemark");
            // 
            // colsPerformedBy
            // 
            this.colsPerformedBy.MaxLength = 30;
            this.colsPerformedBy.Name = "colsPerformedBy";
            this.colsPerformedBy.NamedProperties.Put("EnumerateMethod", "");
            this.colsPerformedBy.NamedProperties.Put("FieldFlags", "288");
            this.colsPerformedBy.NamedProperties.Put("LovReference", "");
            this.colsPerformedBy.NamedProperties.Put("SqlColumn", "PERFORMED_BY");
            this.colsPerformedBy.Position = 12;
            resources.ApplyResources(this.colsPerformedBy, "colsPerformedBy");
            // 
            // cmdDataCleanupLog
            // 
            resources.ApplyResources(this.cmdDataCleanupLog, "cmdDataCleanupLog");
            this.cmdDataCleanupLog.Name = "cmdDataCleanupLog";
            this.cmdDataCleanupLog.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.cmdDataCleanupLog_Execute);
            this.cmdDataCleanupLog.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.cmdDataCleanupLog_Inquire);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMenuItem_DataCleanupLog});
            this.contextMenu.Name = "contextMenu";
            resources.ApplyResources(this.contextMenu, "contextMenu");
            // 
            // tsMenuItem_DataCleanupLog
            // 
            this.tsMenuItem_DataCleanupLog.Command = this.cmdDataCleanupLog;
            this.tsMenuItem_DataCleanupLog.Name = "tsMenuItem_DataCleanupLog";
            resources.ApplyResources(this.tsMenuItem_DataCleanupLog, "tsMenuItem_DataCleanupLog");
            this.tsMenuItem_DataCleanupLog.Text = "Data Cleanup Log...";
            // 
            // colsCleanupFailure
            // 
            this.colsCleanupFailure.AllowFiltering = true;
            this.colsCleanupFailure.CellType = PPJ.Runtime.Windows.CellType.CheckBox;
            this.colsCleanupFailure.CheckBox.CheckedValue = "TRUE";
            this.colsCleanupFailure.CheckBox.IgnoreCase = true;
            this.colsCleanupFailure.CheckBox.UncheckedValue = "FALSE";
            this.colsCleanupFailure.MaxLength = 5;
            this.colsCleanupFailure.Name = "colsCleanupFailure";
            this.colsCleanupFailure.NamedProperties.Put("EnumerateMethod", "");
            this.colsCleanupFailure.NamedProperties.Put("FieldFlags", "288");
            this.colsCleanupFailure.NamedProperties.Put("LovReference", "");
            this.colsCleanupFailure.NamedProperties.Put("SqlColumn", "CLEANUP_FAILURE");
            this.colsCleanupFailure.Position = 10;
            resources.ApplyResources(this.colsCleanupFailure, "colsCleanupFailure");
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
            // tbwDataSubjectConsentOperations
            // 
            resources.ApplyResources(this, "$this");
            this.ContextMenuStrip = this.contextMenu;
            this.Controls.Add(this.colsKeyRef);
            this.Controls.Add(this.colsIdentity);
            this.Controls.Add(this.colsDataSubject);
            this.Controls.Add(this.coldUpdateDate);
            this.Controls.Add(this.colsAction);
            this.Controls.Add(this.colsActionDb);
            this.Controls.Add(this.colsRemark);
            this.Controls.Add(this.colsCleanupFailure);
            this.Controls.Add(this.coldOperationDate);
            this.Controls.Add(this.colsPerformedBy);
            this.Name = "tbwDataSubjectConsentOperations";
            this.NamedProperties.Put("DefaultOrderBy", "OPERATION_DATE DESC");
            this.NamedProperties.Put("LogicalUnit", "DataSubjectConsentOper");
            this.NamedProperties.Put("Module", "ENTERP");
            this.NamedProperties.Put("PackageName", "Data_Subject_Consent_Oper_API");
            this.NamedProperties.Put("SourceFlags", "1");
            this.NamedProperties.Put("ViewName", "DATA_SUB_CONSENT_OPERATIONS");
            this.Controls.SetChildIndex(this.colsPerformedBy, 0);
            this.Controls.SetChildIndex(this.coldOperationDate, 0);
            this.Controls.SetChildIndex(this.colsCleanupFailure, 0);
            this.Controls.SetChildIndex(this.colsRemark, 0);
            this.Controls.SetChildIndex(this.colsActionDb, 0);
            this.Controls.SetChildIndex(this.colsAction, 0);
            this.Controls.SetChildIndex(this.coldUpdateDate, 0);
            this.Controls.SetChildIndex(this.colsDataSubject, 0);
            this.Controls.SetChildIndex(this.colsIdentity, 0);
            this.Controls.SetChildIndex(this.colsKeyRef, 0);
            this.Controls.SetChildIndex(this.@__colObjversion, 0);
            this.Controls.SetChildIndex(this.@__colObjid, 0);
            this.contextMenu.ResumeLayout(false);
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
        protected cLookupColumn colsAction;
        protected cColumn colsDataSubject;
        protected cColumn colsIdentity;
        protected cColumn coldUpdateDate;
        protected cColumn colsRemark;
        protected cColumn colsPerformedBy;
        protected Fnd.Windows.Forms.FndCommand cmdDataCleanupLog;
        protected Fnd.Windows.Forms.FndContextMenuStrip contextMenu;
        protected Fnd.Windows.Forms.FndToolStripMenuItem tsMenuItem_DataCleanupLog;
        protected cColumn colsCleanupFailure;
        protected cColumn colsActionDb;
    }
}
