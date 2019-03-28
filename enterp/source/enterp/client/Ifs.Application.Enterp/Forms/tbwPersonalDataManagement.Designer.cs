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

    public partial class tbwPersonalDataManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwPersonalDataManagement));
            this.colsDataCleanupMethod = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.colsDataCleanupMethodDb = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colDataCleanup = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.cmdDetails = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.tbwMenu = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.tsMenuItem_Details = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.tsMenuItem_DataProcessingPurpose = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.cmdDataProcessingPurpose = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.tsMenuItemPropertyCode = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.cmdPropertyCode = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.colnPersDataManagementId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsPersonalData = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsAnonymizationMethodId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsSystemDefinedDb = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tbwMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.cmdDetails);
            this.commandManager.Commands.Add(this.cmdDataProcessingPurpose);
            this.commandManager.Commands.Add(this.cmdPropertyCode);
            this.commandManager.ContextMenus.Add(this.tbwMenu);
            // 
            // colsDataCleanupMethod
            // 
            this.colsDataCleanupMethod.MaxLength = 200;
            this.colsDataCleanupMethod.Name = "colsDataCleanupMethod";
            this.colsDataCleanupMethod.NamedProperties.Put("EnumerateMethod", "DATA_CLEANUP_METHOD_API.Enumerate");
            this.colsDataCleanupMethod.NamedProperties.Put("FieldFlags", "295");
            this.colsDataCleanupMethod.NamedProperties.Put("LovReference", "");
            this.colsDataCleanupMethod.NamedProperties.Put("SqlColumn", "DATA_CLEANUP_METHOD");
            this.colsDataCleanupMethod.Position = 7;
            resources.ApplyResources(this.colsDataCleanupMethod, "colsDataCleanupMethod");
            // 
            // colsDataCleanupMethodDb
            // 
            this.colsDataCleanupMethodDb.MaxLength = 20;
            this.colsDataCleanupMethodDb.Name = "colsDataCleanupMethodDb";
            this.colsDataCleanupMethodDb.NamedProperties.Put("EnumerateMethod", "");
            this.colsDataCleanupMethodDb.NamedProperties.Put("FieldFlags", "288");
            this.colsDataCleanupMethodDb.NamedProperties.Put("LovReference", "");
            this.colsDataCleanupMethodDb.NamedProperties.Put("SqlColumn", "DATA_CLEANUP_METHOD_DB");
            this.colsDataCleanupMethodDb.Position = 6;
            resources.ApplyResources(this.colsDataCleanupMethodDb, "colsDataCleanupMethodDb");
            // 
            // colDataCleanup
            // 
            this.colDataCleanup.MaxLength = 20;
            this.colDataCleanup.Name = "colDataCleanup";
            this.colDataCleanup.NamedProperties.Put("EnumerateMethod", "");
            this.colDataCleanup.NamedProperties.Put("FieldFlags", "295");
            this.colDataCleanup.NamedProperties.Put("LovReference", "");
            this.colDataCleanup.NamedProperties.Put("SqlColumn", "DATA_CLEANUP_DB");
            this.colDataCleanup.Position = 5;
            resources.ApplyResources(this.colDataCleanup, "colDataCleanup");
            // 
            // cmdDetails
            // 
            resources.ApplyResources(this.cmdDetails, "cmdDetails");
            this.cmdDetails.Name = "cmdDetails";
            this.cmdDetails.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.cmdDetails_Execute);
            this.cmdDetails.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.cmdDetails_Inquire);
            // 
            // tbwMenu
            // 
            this.tbwMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMenuItem_Details,
            this.tsMenuItem_DataProcessingPurpose,
            this.tsMenuItemPropertyCode});
            this.tbwMenu.Name = "tbwMenu";
            resources.ApplyResources(this.tbwMenu, "tbwMenu");
            // 
            // tsMenuItem_Details
            // 
            this.tsMenuItem_Details.Command = this.cmdDetails;
            this.tsMenuItem_Details.Name = "tsMenuItem_Details";
            resources.ApplyResources(this.tsMenuItem_Details, "tsMenuItem_Details");
            this.tsMenuItem_Details.Text = "&Customize Anonymization...";
            // 
            // tsMenuItem_DataProcessingPurpose
            // 
            this.tsMenuItem_DataProcessingPurpose.Command = this.cmdDataProcessingPurpose;
            this.tsMenuItem_DataProcessingPurpose.Name = "tsMenuItem_DataProcessingPurpose";
            resources.ApplyResources(this.tsMenuItem_DataProcessingPurpose, "tsMenuItem_DataProcessingPurpose");
            this.tsMenuItem_DataProcessingPurpose.Text = "Data Processing Purpose...";
            // 
            // cmdDataProcessingPurpose
            // 
            resources.ApplyResources(this.cmdDataProcessingPurpose, "cmdDataProcessingPurpose");
            this.cmdDataProcessingPurpose.Name = "cmdDataProcessingPurpose";
            this.cmdDataProcessingPurpose.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.cmdDataProcessingPurpose_Execute);
            this.cmdDataProcessingPurpose.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.cmdDataProcessingPurpose_Inquire);
            // 
            // tsMenuItemPropertyCode
            // 
            this.tsMenuItemPropertyCode.Command = this.cmdPropertyCode;
            this.tsMenuItemPropertyCode.Name = "tsMenuItemPropertyCode";
            resources.ApplyResources(this.tsMenuItemPropertyCode, "tsMenuItemPropertyCode");
            this.tsMenuItemPropertyCode.Text = "Add Personal Data...";
            // 
            // cmdPropertyCode
            // 
            resources.ApplyResources(this.cmdPropertyCode, "cmdPropertyCode");
            this.cmdPropertyCode.Name = "cmdPropertyCode";
            this.cmdPropertyCode.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.cmdPropertyCode_Execute);
            this.cmdPropertyCode.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.cmdPropertyCode_Inquire);
            // 
            // colnPersDataManagementId
            // 
            this.colnPersDataManagementId.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnPersDataManagementId.Name = "colnPersDataManagementId";
            this.colnPersDataManagementId.NamedProperties.Put("EnumerateMethod", "");
            this.colnPersDataManagementId.NamedProperties.Put("FieldFlags", "131");
            this.colnPersDataManagementId.NamedProperties.Put("Format", "");
            this.colnPersDataManagementId.NamedProperties.Put("LovReference", "");
            this.colnPersDataManagementId.NamedProperties.Put("SqlColumn", "PERS_DATA_MANAGEMENT_ID");
            this.colnPersDataManagementId.Position = 3;
            this.colnPersDataManagementId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.colnPersDataManagementId, "colnPersDataManagementId");
            // 
            // colsPersonalData
            // 
            this.colsPersonalData.MaxLength = 30;
            this.colsPersonalData.Name = "colsPersonalData";
            this.colsPersonalData.NamedProperties.Put("EnumerateMethod", "");
            this.colsPersonalData.NamedProperties.Put("FieldFlags", "291");
            this.colsPersonalData.NamedProperties.Put("LovReference", "");
            this.colsPersonalData.NamedProperties.Put("SqlColumn", "PERSONAL_DATA");
            this.colsPersonalData.Position = 4;
            resources.ApplyResources(this.colsPersonalData, "colsPersonalData");
            // 
            // colsAnonymizationMethodId
            // 
            this.colsAnonymizationMethodId.MaxLength = 35;
            this.colsAnonymizationMethodId.Name = "colsAnonymizationMethodId";
            this.colsAnonymizationMethodId.NamedProperties.Put("EnumerateMethod", "");
            this.colsAnonymizationMethodId.NamedProperties.Put("FieldFlags", "294");
            this.colsAnonymizationMethodId.NamedProperties.Put("LovReference", "ANONYMIZATION_SETUP");
            this.colsAnonymizationMethodId.NamedProperties.Put("SqlColumn", "ANONYMIZATION_METHOD_ID");
            this.colsAnonymizationMethodId.Position = 8;
            resources.ApplyResources(this.colsAnonymizationMethodId, "colsAnonymizationMethodId");
            // 
            // colsSystemDefinedDb
            // 
            this.colsSystemDefinedDb.CellType = PPJ.Runtime.Windows.CellType.CheckBox;
            this.colsSystemDefinedDb.CheckBox.CheckedValue = "TRUE";
            this.colsSystemDefinedDb.CheckBox.IgnoreCase = true;
            this.colsSystemDefinedDb.CheckBox.UncheckedValue = "FALSE";
            resources.ApplyResources(this.colsSystemDefinedDb, "colsSystemDefinedDb");
            this.colsSystemDefinedDb.MaxLength = 20;
            this.colsSystemDefinedDb.Name = "colsSystemDefinedDb";
            this.colsSystemDefinedDb.NamedProperties.Put("EnumerateMethod", "");
            this.colsSystemDefinedDb.NamedProperties.Put("FieldFlags", "288");
            this.colsSystemDefinedDb.NamedProperties.Put("LovReference", "");
            this.colsSystemDefinedDb.NamedProperties.Put("SqlColumn", "SYSTEM_DEFINED_DB");
            this.colsSystemDefinedDb.Position = 9;
            this.colsSystemDefinedDb.ReadOnly = true;
            // 
            // tbwPersonalDataManagement
            // 
            resources.ApplyResources(this, "$this");
            this.ContextMenuStrip = this.tbwMenu;
            this.Controls.Add(this.colnPersDataManagementId);
            this.Controls.Add(this.colsPersonalData);
            this.Controls.Add(this.colDataCleanup);
            this.Controls.Add(this.colsDataCleanupMethodDb);
            this.Controls.Add(this.colsDataCleanupMethod);
            this.Controls.Add(this.colsAnonymizationMethodId);
            this.Controls.Add(this.colsSystemDefinedDb);
            this.Name = "tbwPersonalDataManagement";
            this.NamedProperties.Put("DefaultOrderBy", "PERSONAL_DATA");
            this.NamedProperties.Put("LogicalUnit", "PersonalDataManagement");
            this.NamedProperties.Put("Module", "ENTERP");
            this.NamedProperties.Put("PackageName", "PERSONAL_DATA_MANAGEMENT_API");
            this.NamedProperties.Put("SourceFlags", "16769");
            this.NamedProperties.Put("ViewName", "PERSONAL_DATA_MANAGEMENT");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tbwPersonalDataManagement_WindowActions);
            this.Controls.SetChildIndex(this.colsSystemDefinedDb, 0);
            this.Controls.SetChildIndex(this.colsAnonymizationMethodId, 0);
            this.Controls.SetChildIndex(this.colsDataCleanupMethod, 0);
            this.Controls.SetChildIndex(this.colsDataCleanupMethodDb, 0);
            this.Controls.SetChildIndex(this.colDataCleanup, 0);
            this.Controls.SetChildIndex(this.colsPersonalData, 0);
            this.Controls.SetChildIndex(this.colnPersDataManagementId, 0);
            this.Controls.SetChildIndex(this.@__colObjversion, 0);
            this.Controls.SetChildIndex(this.@__colObjid, 0);
            this.tbwMenu.ResumeLayout(false);
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

        protected cLookupColumn colsDataCleanupMethod;
        protected cColumn colsDataCleanupMethodDb;
        protected cCheckBoxColumn colDataCleanup;
        protected Fnd.Windows.Forms.FndCommand cmdDetails;
        protected Fnd.Windows.Forms.FndContextMenuStrip tbwMenu;
        protected Fnd.Windows.Forms.FndToolStripMenuItem tsMenuItem_Details;
        protected cColumn colnPersDataManagementId;
        protected cColumn colsPersonalData;
        protected Fnd.Windows.Forms.FndCommand cmdDataProcessingPurpose;
        protected Fnd.Windows.Forms.FndToolStripMenuItem tsMenuItem_DataProcessingPurpose;
        protected Fnd.Windows.Forms.FndCommand cmdPropertyCode;
        protected Fnd.Windows.Forms.FndToolStripMenuItem tsMenuItemPropertyCode;
        protected cColumn colsAnonymizationMethodId;
        protected cColumn colsSystemDefinedDb;

    }
}
