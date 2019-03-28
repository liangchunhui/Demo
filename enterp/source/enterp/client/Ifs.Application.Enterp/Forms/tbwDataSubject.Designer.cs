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

    public partial class tbwDataSubject
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwDataSubject));
            this.colsDataSubjectId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsDataSubject = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colPersonalDataManagement = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.colNoHistoryDataCleanup = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.SuspendLayout();
            // 
            // colsDataSubjectId
            // 
            this.colsDataSubjectId.MaxLength = 20;
            this.colsDataSubjectId.Name = "colsDataSubjectId";
            this.colsDataSubjectId.NamedProperties.Put("EnumerateMethod", "");
            this.colsDataSubjectId.NamedProperties.Put("FieldFlags", "131");
            this.colsDataSubjectId.NamedProperties.Put("LovReference", "");
            this.colsDataSubjectId.NamedProperties.Put("SqlColumn", "DATA_SUBJECT_ID");
            this.colsDataSubjectId.Position = 3;
            resources.ApplyResources(this.colsDataSubjectId, "colsDataSubjectId");
            // 
            // colsDataSubject
            // 
            this.colsDataSubject.MaxLength = 50;
            this.colsDataSubject.Name = "colsDataSubject";
            this.colsDataSubject.NamedProperties.Put("EnumerateMethod", "DATA_SUBJECT_API.Enumerate_Active");
            this.colsDataSubject.NamedProperties.Put("FieldFlags", "291");
            this.colsDataSubject.NamedProperties.Put("LovReference", "");
            this.colsDataSubject.NamedProperties.Put("SqlColumn", "DATA_SUBJECT");
            this.colsDataSubject.Position = 4;
            resources.ApplyResources(this.colsDataSubject, "colsDataSubject");
            // 
            // colPersonalDataManagement
            // 
            this.colPersonalDataManagement.MaxLength = 20;
            this.colPersonalDataManagement.Name = "colPersonalDataManagement";
            this.colPersonalDataManagement.NamedProperties.Put("EnumerateMethod", "");
            this.colPersonalDataManagement.NamedProperties.Put("FieldFlags", "293");
            this.colPersonalDataManagement.NamedProperties.Put("LovReference", "");
            this.colPersonalDataManagement.NamedProperties.Put("SqlColumn", "PERSONAL_DATA_MANAGEMENT_DB");
            this.colPersonalDataManagement.Position = 5;
            resources.ApplyResources(this.colPersonalDataManagement, "colPersonalDataManagement");
            // 
            // colNoHistoryDataCleanup
            // 
            this.colNoHistoryDataCleanup.MaxLength = 20;
            this.colNoHistoryDataCleanup.Name = "colNoHistoryDataCleanup";
            this.colNoHistoryDataCleanup.NamedProperties.Put("EnumerateMethod", "");
            this.colNoHistoryDataCleanup.NamedProperties.Put("FieldFlags", "293");
            this.colNoHistoryDataCleanup.NamedProperties.Put("LovReference", "");
            this.colNoHistoryDataCleanup.NamedProperties.Put("SqlColumn", "NO_HISTORY_DATA_CLEANUP_DB");
            this.colNoHistoryDataCleanup.Position = 6;
            resources.ApplyResources(this.colNoHistoryDataCleanup, "colNoHistoryDataCleanup");
            // 
            // tbwDataSubject
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colsDataSubjectId);
            this.Controls.Add(this.colsDataSubject);
            this.Controls.Add(this.colPersonalDataManagement);
            this.Controls.Add(this.colNoHistoryDataCleanup);
            this.Name = "tbwDataSubject";
            this.NamedProperties.Put("LogicalUnit", "DataSubject");
            this.NamedProperties.Put("Module", "Enterp");
            this.NamedProperties.Put("PackageName", "DATA_SUBJECT_API");
            this.NamedProperties.Put("SourceFlags", "16513");
            this.NamedProperties.Put("ViewName", "DATA_SUBJECT_OV");
            this.Controls.SetChildIndex(this.colNoHistoryDataCleanup, 0);
            this.Controls.SetChildIndex(this.colPersonalDataManagement, 0);
            this.Controls.SetChildIndex(this.colsDataSubject, 0);
            this.Controls.SetChildIndex(this.colsDataSubjectId, 0);
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

        protected cColumn colsDataSubjectId;
        protected cColumn colsDataSubject;
        protected cCheckBoxColumn colPersonalDataManagement;
        protected cCheckBoxColumn colNoHistoryDataCleanup;
    }
}
