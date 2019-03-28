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

    public partial class dlgDataProcessingPersonalData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgDataProcessingPersonalData));
            this.cCommandButtonOK = new Ifs.Fnd.ApplicationForms.cCommandButton();
            this.commandOk = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.cCommandButtonCancel = new Ifs.Fnd.ApplicationForms.cCommandButton();
            this.commandCancel = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.labelDataProcessPurpose = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.tblDataProcessPurpose = new Ifs.Fnd.ApplicationForms.cChildTable();
            this.tblDataProcessPurpose_colnPersDataManagementId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblDataProcessPurpose_colsPersonalData = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblDataProcessPurpose_colsSelected = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.cmbDataSubject = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.labelDataSubject = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.tblDataProcessPurpose.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.commandOk);
            this.commandManager.Commands.Add(this.commandCancel);
            this.commandManager.Components.Add(this.cCommandButtonOK);
            this.commandManager.Components.Add(this.cCommandButtonCancel);
            // 
            // cCommandButtonOK
            // 
            resources.ApplyResources(this.cCommandButtonOK, "cCommandButtonOK");
            this.cCommandButtonOK.Command = this.commandOk;
            this.cCommandButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cCommandButtonOK.Name = "cCommandButtonOK";
            this.cCommandButtonOK.NamedProperties.Put("MethodIdStr", "");
            this.cCommandButtonOK.NamedProperties.Put("MethodParameterType", "String");
            // 
            // commandOk
            // 
            resources.ApplyResources(this.commandOk, "commandOk");
            this.commandOk.Name = "commandOk";
            this.commandOk.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.commandOk_Execute);
            // 
            // cCommandButtonCancel
            // 
            resources.ApplyResources(this.cCommandButtonCancel, "cCommandButtonCancel");
            this.cCommandButtonCancel.Command = this.commandCancel;
            this.cCommandButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cCommandButtonCancel.Name = "cCommandButtonCancel";
            this.cCommandButtonCancel.NamedProperties.Put("MethodIdStr", "");
            this.cCommandButtonCancel.NamedProperties.Put("MethodParameterType", "String");
            // 
            // commandCancel
            // 
            resources.ApplyResources(this.commandCancel, "commandCancel");
            this.commandCancel.Name = "commandCancel";
            this.commandCancel.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.commandCancel_Execute);
            // 
            // labelDataProcessPurpose
            // 
            resources.ApplyResources(this.labelDataProcessPurpose, "labelDataProcessPurpose");
            this.labelDataProcessPurpose.Name = "labelDataProcessPurpose";
            // 
            // tblDataProcessPurpose
            // 
            this.tblDataProcessPurpose.Controls.Add(this.tblDataProcessPurpose_colnPersDataManagementId);
            this.tblDataProcessPurpose.Controls.Add(this.tblDataProcessPurpose_colsPersonalData);
            this.tblDataProcessPurpose.Controls.Add(this.tblDataProcessPurpose_colsSelected);
            resources.ApplyResources(this.tblDataProcessPurpose, "tblDataProcessPurpose");
            this.tblDataProcessPurpose.Name = "tblDataProcessPurpose";
            this.tblDataProcessPurpose.NamedProperties.Put("DefaultOrderBy", "PERS_DATA_MANAGEMENT_ID");
            this.tblDataProcessPurpose.NamedProperties.Put("DefaultWhere", "");
            this.tblDataProcessPurpose.NamedProperties.Put("LogicalUnit", "PersonalDataManagement");
            this.tblDataProcessPurpose.NamedProperties.Put("Module", "ENTERP");
            this.tblDataProcessPurpose.NamedProperties.Put("PackageName", "PERSONAL_DATA_MANAGEMENT_API");
            this.tblDataProcessPurpose.NamedProperties.Put("SourceFlags", "129");
            this.tblDataProcessPurpose.NamedProperties.Put("ViewName", "PERSONAL_DATA_MANAGEMENT");
            this.tblDataProcessPurpose.Controls.SetChildIndex(this.tblDataProcessPurpose_colsSelected, 0);
            this.tblDataProcessPurpose.Controls.SetChildIndex(this.tblDataProcessPurpose_colsPersonalData, 0);
            this.tblDataProcessPurpose.Controls.SetChildIndex(this.tblDataProcessPurpose_colnPersDataManagementId, 0);
            // 
            // tblDataProcessPurpose_colnPersDataManagementId
            // 
            this.tblDataProcessPurpose_colnPersDataManagementId.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.tblDataProcessPurpose_colnPersDataManagementId.Name = "tblDataProcessPurpose_colnPersDataManagementId";
            this.tblDataProcessPurpose_colnPersDataManagementId.NamedProperties.Put("EnumerateMethod", "");
            this.tblDataProcessPurpose_colnPersDataManagementId.NamedProperties.Put("FieldFlags", "163");
            this.tblDataProcessPurpose_colnPersDataManagementId.NamedProperties.Put("Format", "");
            this.tblDataProcessPurpose_colnPersDataManagementId.NamedProperties.Put("LovReference", "");
            this.tblDataProcessPurpose_colnPersDataManagementId.NamedProperties.Put("SqlColumn", "PERS_DATA_MANAGEMENT_ID");
            this.tblDataProcessPurpose_colnPersDataManagementId.Position = 3;
            this.tblDataProcessPurpose_colnPersDataManagementId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.tblDataProcessPurpose_colnPersDataManagementId, "tblDataProcessPurpose_colnPersDataManagementId");
            // 
            // tblDataProcessPurpose_colsPersonalData
            // 
            this.tblDataProcessPurpose_colsPersonalData.MaxLength = 30;
            this.tblDataProcessPurpose_colsPersonalData.Name = "tblDataProcessPurpose_colsPersonalData";
            this.tblDataProcessPurpose_colsPersonalData.NamedProperties.Put("EnumerateMethod", "");
            this.tblDataProcessPurpose_colsPersonalData.NamedProperties.Put("FieldFlags", "291");
            this.tblDataProcessPurpose_colsPersonalData.NamedProperties.Put("LovReference", "");
            this.tblDataProcessPurpose_colsPersonalData.NamedProperties.Put("SqlColumn", "PERSONAL_DATA");
            this.tblDataProcessPurpose_colsPersonalData.Position = 4;
            resources.ApplyResources(this.tblDataProcessPurpose_colsPersonalData, "tblDataProcessPurpose_colsPersonalData");
            // 
            // tblDataProcessPurpose_colsSelected
            // 
            this.tblDataProcessPurpose_colsSelected.MaxLength = 2000;
            this.tblDataProcessPurpose_colsSelected.Name = "tblDataProcessPurpose_colsSelected";
            this.tblDataProcessPurpose_colsSelected.NamedProperties.Put("EnumerateMethod", "");
            this.tblDataProcessPurpose_colsSelected.NamedProperties.Put("FieldFlags", "288");
            this.tblDataProcessPurpose_colsSelected.NamedProperties.Put("LovReference", "");
            this.tblDataProcessPurpose_colsSelected.NamedProperties.Put("SqlColumn", "Pers_Data_Man_Proc_Purpose_Api.Is_Pers_Data_Purpose_Selected(PERS_DATA_MANAGEMENT" +
        "_ID, :i_hWndParent.dlgDataProcessingPurpose.cmbDataSubject, :i_hWndParent.dlgDat" +
        "aProcessingPurpose.nPurposeId)");
            this.tblDataProcessPurpose_colsSelected.Position = 5;
            resources.ApplyResources(this.tblDataProcessPurpose_colsSelected, "tblDataProcessPurpose_colsSelected");
            this.tblDataProcessPurpose_colsSelected.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblDataProcessPurpose_colsSelected_WindowActions);
            // 
            // cmbDataSubject
            // 
            this.cmbDataSubject.FormattingEnabled = true;
            resources.ApplyResources(this.cmbDataSubject, "cmbDataSubject");
            this.cmbDataSubject.Name = "cmbDataSubject";
            this.cmbDataSubject.NamedProperties.Put("EnumerateMethod", "Data_Subject_Api.Enumerate_Active");
            this.cmbDataSubject.NamedProperties.Put("FieldFlags", "295");
            this.cmbDataSubject.NamedProperties.Put("LovReference", "");
            this.cmbDataSubject.NamedProperties.Put("SqlColumn", "");
            this.cmbDataSubject.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbDataSubject_WindowActions);
            // 
            // labelDataSubject
            // 
            resources.ApplyResources(this.labelDataSubject, "labelDataSubject");
            this.labelDataSubject.Name = "labelDataSubject";
            // 
            // dlgDataProcessingPersonalData
            // 
            this.AcceptButton = this.cCommandButtonOK;
            this.CancelButton = this.cCommandButtonCancel;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.labelDataProcessPurpose);
            this.Controls.Add(this.tblDataProcessPurpose);
            this.Controls.Add(this.cmbDataSubject);
            this.Controls.Add(this.labelDataSubject);
            this.Controls.Add(this.cCommandButtonOK);
            this.Controls.Add(this.cCommandButtonCancel);
            this.Name = "dlgDataProcessingPersonalData";
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dlgDataProcessingPersonalData_WindowActions);
            this.tblDataProcessPurpose.ResumeLayout(false);
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

        protected cCommandButton cCommandButtonOK;
        protected cCommandButton cCommandButtonCancel;
        protected Ifs.Fnd.Windows.Forms.FndCommand commandOk;
        protected Ifs.Fnd.Windows.Forms.FndCommand commandCancel;
        protected cBackgroundText labelDataProcessPurpose;
        protected cChildTable tblDataProcessPurpose;
        protected cCheckBoxColumn tblDataProcessPurpose_colsSelected;
        protected cComboBox cmbDataSubject;
        protected cBackgroundText labelDataSubject;
        protected cColumn tblDataProcessPurpose_colsPersonalData;
        protected cColumn tblDataProcessPurpose_colnPersDataManagementId;

    }
}
