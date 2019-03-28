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

    public partial class tbwDataSubjectConsentAnalysis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwDataSubjectConsentAnalysis));
            this.colsDataSubjectId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsDataSubjectName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colValidDataProcessingPurpose = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.colPersonalDataConsentHistory = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.cmdManageDataProcessingPurposes = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTblMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem_PersonalDataConsent = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.colsDataSubjectDb = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsDataSubject = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.colsDataSubjectPart1 = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsDataSubPart1Desc = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsDataSubjectPart2 = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsDataSubPart2Desc = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuTblMethods.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.cmdManageDataProcessingPurposes);
            this.commandManager.ContextMenus.Add(this.menuTblMethods);
            // 
            // __colObjid
            // 
            this.@__colObjid.Position = 2;
            // 
            // __colObjversion
            // 
            this.@__colObjversion.Position = 1;
            // 
            // colsDataSubjectId
            // 
            this.colsDataSubjectId.MaxLength = 41;
            this.colsDataSubjectId.Name = "colsDataSubjectId";
            this.colsDataSubjectId.NamedProperties.Put("EnumerateMethod", "");
            this.colsDataSubjectId.NamedProperties.Put("FieldFlags", "288");
            this.colsDataSubjectId.NamedProperties.Put("LovReference", "");
            this.colsDataSubjectId.NamedProperties.Put("SqlColumn", "DATA_SUBJECT_ID");
            this.colsDataSubjectId.Position = 5;
            resources.ApplyResources(this.colsDataSubjectId, "colsDataSubjectId");
            // 
            // colsDataSubjectName
            // 
            this.colsDataSubjectName.Name = "colsDataSubjectName";
            this.colsDataSubjectName.NamedProperties.Put("EnumerateMethod", "");
            this.colsDataSubjectName.NamedProperties.Put("FieldFlags", "288");
            this.colsDataSubjectName.NamedProperties.Put("LovReference", "");
            this.colsDataSubjectName.NamedProperties.Put("SqlColumn", "DATA_SUBJECT_NAME");
            this.colsDataSubjectName.Position = 6;
            resources.ApplyResources(this.colsDataSubjectName, "colsDataSubjectName");
            // 
            // colValidDataProcessingPurpose
            // 
            this.colValidDataProcessingPurpose.Name = "colValidDataProcessingPurpose";
            this.colValidDataProcessingPurpose.NamedProperties.Put("EnumerateMethod", "");
            this.colValidDataProcessingPurpose.NamedProperties.Put("FieldFlags", "288");
            this.colValidDataProcessingPurpose.NamedProperties.Put("LovReference", "");
            this.colValidDataProcessingPurpose.NamedProperties.Put("SqlColumn", "VALID_PERSONAL_DATA_CONSENT");
            this.colValidDataProcessingPurpose.Position = 11;
            resources.ApplyResources(this.colValidDataProcessingPurpose, "colValidDataProcessingPurpose");
            // 
            // colPersonalDataConsentHistory
            // 
            this.colPersonalDataConsentHistory.Name = "colPersonalDataConsentHistory";
            this.colPersonalDataConsentHistory.NamedProperties.Put("EnumerateMethod", "");
            this.colPersonalDataConsentHistory.NamedProperties.Put("FieldFlags", "288");
            this.colPersonalDataConsentHistory.NamedProperties.Put("LovReference", "");
            this.colPersonalDataConsentHistory.NamedProperties.Put("SqlColumn", "PERSONAL_DATA_CONSENT_HISTORY");
            this.colPersonalDataConsentHistory.Position = 12;
            resources.ApplyResources(this.colPersonalDataConsentHistory, "colPersonalDataConsentHistory");
            // 
            // cmdManageDataProcessingPurposes
            // 
            resources.ApplyResources(this.cmdManageDataProcessingPurposes, "cmdManageDataProcessingPurposes");
            this.cmdManageDataProcessingPurposes.Name = "cmdManageDataProcessingPurposes";
            this.cmdManageDataProcessingPurposes.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.cmdManageDataProcessingPurposes_Execute);
            this.cmdManageDataProcessingPurposes.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.cmdManageDataProcessingPurposes_Inquire);
            // 
            // menuTblMethods
            // 
            this.menuTblMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_PersonalDataConsent});
            this.menuTblMethods.Name = "menuTblMethods";
            resources.ApplyResources(this.menuTblMethods, "menuTblMethods");
            // 
            // menuItem_PersonalDataConsent
            // 
            this.menuItem_PersonalDataConsent.Command = this.cmdManageDataProcessingPurposes;
            this.menuItem_PersonalDataConsent.Name = "menuItem_PersonalDataConsent";
            resources.ApplyResources(this.menuItem_PersonalDataConsent, "menuItem_PersonalDataConsent");
            this.menuItem_PersonalDataConsent.Text = "Manage Data Processing Purposes...";
            // 
            // colsDataSubjectDb
            // 
            this.colsDataSubjectDb.MaxLength = 20;
            this.colsDataSubjectDb.Name = "colsDataSubjectDb";
            this.colsDataSubjectDb.NamedProperties.Put("EnumerateMethod", "");
            this.colsDataSubjectDb.NamedProperties.Put("LovReference", "");
            this.colsDataSubjectDb.NamedProperties.Put("SqlColumn", "DATA_SUBJECT_DB");
            this.colsDataSubjectDb.Position = 3;
            resources.ApplyResources(this.colsDataSubjectDb, "colsDataSubjectDb");
            // 
            // colsDataSubject
            // 
            this.colsDataSubject.MaxLength = 50;
            this.colsDataSubject.Name = "colsDataSubject";
            this.colsDataSubject.NamedProperties.Put("EnumerateMethod", "DATA_SUBJECT_API.Enumerate_Active");
            this.colsDataSubject.NamedProperties.Put("FieldFlags", "288");
            this.colsDataSubject.NamedProperties.Put("LovReference", "");
            this.colsDataSubject.NamedProperties.Put("SqlColumn", "DATA_SUBJECT");
            this.colsDataSubject.Position = 4;
            resources.ApplyResources(this.colsDataSubject, "colsDataSubject");
            // 
            // colsDataSubjectPart1
            // 
            this.colsDataSubjectPart1.MaxLength = 40;
            this.colsDataSubjectPart1.Name = "colsDataSubjectPart1";
            this.colsDataSubjectPart1.NamedProperties.Put("EnumerateMethod", "");
            this.colsDataSubjectPart1.NamedProperties.Put("FieldFlags", "288");
            this.colsDataSubjectPart1.NamedProperties.Put("LovReference", "");
            this.colsDataSubjectPart1.NamedProperties.Put("SqlColumn", "DATA_SUBJECT_PART1");
            this.colsDataSubjectPart1.Position = 7;
            resources.ApplyResources(this.colsDataSubjectPart1, "colsDataSubjectPart1");
            // 
            // colsDataSubPart1Desc
            // 
            this.colsDataSubPart1Desc.MaxLength = 40;
            this.colsDataSubPart1Desc.Name = "colsDataSubPart1Desc";
            this.colsDataSubPart1Desc.NamedProperties.Put("EnumerateMethod", "");
            this.colsDataSubPart1Desc.NamedProperties.Put("FieldFlags", "288");
            this.colsDataSubPart1Desc.NamedProperties.Put("LovReference", "");
            this.colsDataSubPart1Desc.NamedProperties.Put("SqlColumn", "DATA_SUB_PART1_DESC");
            this.colsDataSubPart1Desc.Position = 8;
            resources.ApplyResources(this.colsDataSubPart1Desc, "colsDataSubPart1Desc");
            // 
            // colsDataSubjectPart2
            // 
            this.colsDataSubjectPart2.MaxLength = 40;
            this.colsDataSubjectPart2.Name = "colsDataSubjectPart2";
            this.colsDataSubjectPart2.NamedProperties.Put("EnumerateMethod", "");
            this.colsDataSubjectPart2.NamedProperties.Put("FieldFlags", "288");
            this.colsDataSubjectPart2.NamedProperties.Put("LovReference", "");
            this.colsDataSubjectPart2.NamedProperties.Put("SqlColumn", "DATA_SUBJECT_PART2");
            this.colsDataSubjectPart2.Position = 9;
            resources.ApplyResources(this.colsDataSubjectPart2, "colsDataSubjectPart2");
            // 
            // colsDataSubPart2Desc
            // 
            this.colsDataSubPart2Desc.MaxLength = 40;
            this.colsDataSubPart2Desc.Name = "colsDataSubPart2Desc";
            this.colsDataSubPart2Desc.NamedProperties.Put("EnumerateMethod", "");
            this.colsDataSubPart2Desc.NamedProperties.Put("FieldFlags", "288");
            this.colsDataSubPart2Desc.NamedProperties.Put("LovReference", "");
            this.colsDataSubPart2Desc.NamedProperties.Put("SqlColumn", "DATA_SUB_PART2_DESC");
            this.colsDataSubPart2Desc.Position = 10;
            resources.ApplyResources(this.colsDataSubPart2Desc, "colsDataSubPart2Desc");
            // 
            // tbwDataSubjectConsentAnalysis
            // 
            resources.ApplyResources(this, "$this");
            this.ContextMenuStrip = this.menuTblMethods;
            this.Controls.Add(this.colsDataSubjectDb);
            this.Controls.Add(this.colsDataSubject);
            this.Controls.Add(this.colsDataSubjectId);
            this.Controls.Add(this.colsDataSubjectName);
            this.Controls.Add(this.colsDataSubjectPart1);
            this.Controls.Add(this.colsDataSubPart1Desc);
            this.Controls.Add(this.colsDataSubjectPart2);
            this.Controls.Add(this.colsDataSubPart2Desc);
            this.Controls.Add(this.colValidDataProcessingPurpose);
            this.Controls.Add(this.colPersonalDataConsentHistory);
            this.Name = "tbwDataSubjectConsentAnalysis";
            this.NamedProperties.Put("LogicalUnit", "DataSubjectConsent");
            this.NamedProperties.Put("Module", "ENTERP");
            this.NamedProperties.Put("PackageName", "DATA_SUBJECT_CONSENT_API");
            this.NamedProperties.Put("SourceFlags", "16385");
            this.NamedProperties.Put("ViewName", "DATA_SUBJECT_CONSENT_OV");
            this.Controls.SetChildIndex(this.colPersonalDataConsentHistory, 0);
            this.Controls.SetChildIndex(this.colValidDataProcessingPurpose, 0);
            this.Controls.SetChildIndex(this.colsDataSubPart2Desc, 0);
            this.Controls.SetChildIndex(this.colsDataSubjectPart2, 0);
            this.Controls.SetChildIndex(this.colsDataSubPart1Desc, 0);
            this.Controls.SetChildIndex(this.colsDataSubjectPart1, 0);
            this.Controls.SetChildIndex(this.colsDataSubjectName, 0);
            this.Controls.SetChildIndex(this.colsDataSubjectId, 0);
            this.Controls.SetChildIndex(this.colsDataSubject, 0);
            this.Controls.SetChildIndex(this.colsDataSubjectDb, 0);
            this.Controls.SetChildIndex(this.@__colObjid, 0);
            this.Controls.SetChildIndex(this.@__colObjversion, 0);
            this.menuTblMethods.ResumeLayout(false);
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
        protected cColumn colsDataSubjectName;
        protected cCheckBoxColumn colValidDataProcessingPurpose;
        protected cCheckBoxColumn colPersonalDataConsentHistory;
        protected Fnd.Windows.Forms.FndCommand cmdManageDataProcessingPurposes;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTblMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem_PersonalDataConsent;
        protected cColumn colsDataSubjectDb;
        protected cLookupColumn colsDataSubject;
        protected cColumn colsDataSubjectPart1;
        protected cColumn colsDataSubPart1Desc;
        protected cColumn colsDataSubjectPart2;
        protected cColumn colsDataSubPart2Desc;
    }
}
