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

    public partial class tbwPersDataProcessPurpose
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwPersDataProcessPurpose));
            this.colnPurposeId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsPurposeName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.cmdDataProcessingPersonalData = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.tbwPersDataProcessPurp_menu = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.tsMenu_DataProcessingPersonalData = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.tbwPersDataProcessPurp_menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.cmdDataProcessingPersonalData);
            this.commandManager.ContextMenus.Add(this.tbwPersDataProcessPurp_menu);
            // 
            // colnPurposeId
            // 
            this.colnPurposeId.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnPurposeId.Name = "colnPurposeId";
            this.colnPurposeId.NamedProperties.Put("EnumerateMethod", "");
            this.colnPurposeId.NamedProperties.Put("FieldFlags", "131");
            this.colnPurposeId.NamedProperties.Put("Format", "");
            this.colnPurposeId.NamedProperties.Put("LovReference", "");
            this.colnPurposeId.NamedProperties.Put("SqlColumn", "PURPOSE_ID");
            this.colnPurposeId.Position = 3;
            this.colnPurposeId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.colnPurposeId, "colnPurposeId");
            // 
            // colsPurposeName
            // 
            this.colsPurposeName.Name = "colsPurposeName";
            this.colsPurposeName.NamedProperties.Put("EnumerateMethod", "");
            this.colsPurposeName.NamedProperties.Put("FieldFlags", "295");
            this.colsPurposeName.NamedProperties.Put("LovReference", "");
            this.colsPurposeName.NamedProperties.Put("SqlColumn", "PURPOSE_NAME");
            this.colsPurposeName.Position = 4;
            resources.ApplyResources(this.colsPurposeName, "colsPurposeName");
            // 
            // colsDescription
            // 
            this.colsDescription.MaxLength = 2000;
            this.colsDescription.Name = "colsDescription";
            this.colsDescription.NamedProperties.Put("EnumerateMethod", "");
            this.colsDescription.NamedProperties.Put("FieldFlags", "295");
            this.colsDescription.NamedProperties.Put("LovReference", "");
            this.colsDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.colsDescription.Position = 5;
            resources.ApplyResources(this.colsDescription, "colsDescription");
            // 
            // cmdDataProcessingPersonalData
            // 
            resources.ApplyResources(this.cmdDataProcessingPersonalData, "cmdDataProcessingPersonalData");
            this.cmdDataProcessingPersonalData.Name = "cmdDataProcessingPersonalData";
            this.cmdDataProcessingPersonalData.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.cmdDataProcessingPersonalData_Execute);
            this.cmdDataProcessingPersonalData.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.cmdDataProcessingPersonalData_Inquire);
            // 
            // tbwPersDataProcessPurp_menu
            // 
            this.tbwPersDataProcessPurp_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMenu_DataProcessingPersonalData});
            this.tbwPersDataProcessPurp_menu.Name = "tbwPersDataProcessPurp_menu";
            resources.ApplyResources(this.tbwPersDataProcessPurp_menu, "tbwPersDataProcessPurp_menu");
            // 
            // tsMenu_DataProcessingPersonalData
            // 
            this.tsMenu_DataProcessingPersonalData.Command = this.cmdDataProcessingPersonalData;
            this.tsMenu_DataProcessingPersonalData.Name = "tsMenu_DataProcessingPersonalData";
            resources.ApplyResources(this.tsMenu_DataProcessingPersonalData, "tsMenu_DataProcessingPersonalData");
            this.tsMenu_DataProcessingPersonalData.Text = "Configure Purpose...";
            // 
            // tbwPersDataProcessPurpose
            // 
            resources.ApplyResources(this, "$this");
            this.ContextMenuStrip = this.tbwPersDataProcessPurp_menu;
            this.Controls.Add(this.colnPurposeId);
            this.Controls.Add(this.colsPurposeName);
            this.Controls.Add(this.colsDescription);
            this.Name = "tbwPersDataProcessPurpose";
            this.NamedProperties.Put("DefaultOrderBy", "PURPOSE_ID");
            this.NamedProperties.Put("LogicalUnit", "PersDataProcessPurpose");
            this.NamedProperties.Put("Module", "ENTERP");
            this.NamedProperties.Put("PackageName", "PERS_DATA_PROCESS_PURPOSE_API");
            this.NamedProperties.Put("ViewName", "PERS_DATA_PROCESS_PURPOSE");
            this.Controls.SetChildIndex(this.colsDescription, 0);
            this.Controls.SetChildIndex(this.colsPurposeName, 0);
            this.Controls.SetChildIndex(this.colnPurposeId, 0);
            this.Controls.SetChildIndex(this.@__colObjversion, 0);
            this.Controls.SetChildIndex(this.@__colObjid, 0);
            this.tbwPersDataProcessPurp_menu.ResumeLayout(false);
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

        protected cColumn colnPurposeId;
        protected cColumn colsPurposeName;
        protected cColumn colsDescription;
        protected Fnd.Windows.Forms.FndCommand cmdDataProcessingPersonalData;
        protected Fnd.Windows.Forms.FndContextMenuStrip tbwPersDataProcessPurp_menu;
        protected Fnd.Windows.Forms.FndToolStripMenuItem tsMenu_DataProcessingPersonalData;
    }
}
