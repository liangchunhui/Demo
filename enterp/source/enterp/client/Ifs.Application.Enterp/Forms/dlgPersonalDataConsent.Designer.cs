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

    public partial class dlgPersonalDataConsent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgPersonalDataConsent));
            this.cCommandButtonOK = new Ifs.Fnd.ApplicationForms.cCommandButton();
            this.commandOk = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.cCommandButtonCancel = new Ifs.Fnd.ApplicationForms.cCommandButton();
            this.commandCancel = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.dfdUpdateDate = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelUpdateDate = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.labelRemark = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsIdentity = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsIdentityName = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelIdentity = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.labelIdentityName = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.tblUpdateHistory = new Ifs.Fnd.ApplicationForms.cChildTable();
            this.tblUpdateHistory_colsSelected = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.tblUpdateHistory_colsKeyRef = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblUpdateHistory_colsDataSubjectId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblUpdateHistory_colsDataSubject = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblUpdateHistory_colsDataSubjectDb = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblUpdateHistory_coldOperationDate = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblUpdateHistory_coldUpdateDate = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblUpdateHistory_colsAction = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblUpdateHistory_colsRemark = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblUpdateHistory_colsPerformedBy = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblUpdateHistory_colsActionDb = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblUpdateHistory_colsLastUpdateAction = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.dfsKeyRef = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelConsentGiven = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.tblDataProcessPurpose = new Ifs.Fnd.ApplicationForms.cChildTable();
            this.tblDataProcessPurpose_colnPurposeId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblDataProcessPurpose_colsValid = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.tblDataProcessPurpose_colsPurposeName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblDataProcessPurpose_coldEffectiveOn = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblDataProcessPurpose_coldEffectiveUntil = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblDataProcessPurpose_colsPurposePersonalDataList = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblDataProcessPurpose_colsDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dfsRemark = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsDataSubject = new Ifs.Fnd.ApplicationForms.cDataField();
            this.rbNoConsent = new Ifs.Fnd.ApplicationForms.cRadioButton();
            this.rbNewConsent = new Ifs.Fnd.ApplicationForms.cRadioButton();
            this.rbShowSelected = new Ifs.Fnd.ApplicationForms.cRadioButton();
            this.cCommandButtonPrint = new Ifs.Fnd.ApplicationForms.cCommandButton();
            this.commandPrint = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.tblUpdateHistory.SuspendLayout();
            this.tblDataProcessPurpose.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.commandOk);
            this.commandManager.Commands.Add(this.commandCancel);
            this.commandManager.Commands.Add(this.commandPrint);
            this.commandManager.Components.Add(this.cCommandButtonOK);
            this.commandManager.Components.Add(this.cCommandButtonCancel);
            this.commandManager.Components.Add(this.cCommandButtonPrint);
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
            this.commandOk.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.commandOk_Inquire);
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
            // dfdUpdateDate
            // 
            this.dfdUpdateDate.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.dfdUpdateDate.Format = "d";
            resources.ApplyResources(this.dfdUpdateDate, "dfdUpdateDate");
            this.dfdUpdateDate.Name = "dfdUpdateDate";
            this.dfdUpdateDate.NamedProperties.Put("FieldFlags", "263");
            // 
            // labelUpdateDate
            // 
            resources.ApplyResources(this.labelUpdateDate, "labelUpdateDate");
            this.labelUpdateDate.Name = "labelUpdateDate";
            // 
            // labelRemark
            // 
            resources.ApplyResources(this.labelRemark, "labelRemark");
            this.labelRemark.Name = "labelRemark";
            // 
            // dfsIdentity
            // 
            this.dfsIdentity.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.dfsIdentity, "dfsIdentity");
            this.dfsIdentity.Name = "dfsIdentity";
            // 
            // dfsIdentityName
            // 
            this.dfsIdentityName.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.dfsIdentityName, "dfsIdentityName");
            this.dfsIdentityName.Name = "dfsIdentityName";
            // 
            // labelIdentity
            // 
            resources.ApplyResources(this.labelIdentity, "labelIdentity");
            this.labelIdentity.Name = "labelIdentity";
            // 
            // labelIdentityName
            // 
            resources.ApplyResources(this.labelIdentityName, "labelIdentityName");
            this.labelIdentityName.Name = "labelIdentityName";
            // 
            // tblUpdateHistory
            // 
            this.tblUpdateHistory.Controls.Add(this.tblUpdateHistory_colsSelected);
            this.tblUpdateHistory.Controls.Add(this.tblUpdateHistory_colsKeyRef);
            this.tblUpdateHistory.Controls.Add(this.tblUpdateHistory_colsDataSubjectId);
            this.tblUpdateHistory.Controls.Add(this.tblUpdateHistory_colsDataSubject);
            this.tblUpdateHistory.Controls.Add(this.tblUpdateHistory_colsDataSubjectDb);
            this.tblUpdateHistory.Controls.Add(this.tblUpdateHistory_coldOperationDate);
            this.tblUpdateHistory.Controls.Add(this.tblUpdateHistory_coldUpdateDate);
            this.tblUpdateHistory.Controls.Add(this.tblUpdateHistory_colsAction);
            this.tblUpdateHistory.Controls.Add(this.tblUpdateHistory_colsRemark);
            this.tblUpdateHistory.Controls.Add(this.tblUpdateHistory_colsPerformedBy);
            this.tblUpdateHistory.Controls.Add(this.tblUpdateHistory_colsActionDb);
            this.tblUpdateHistory.Controls.Add(this.tblUpdateHistory_colsLastUpdateAction);
            resources.ApplyResources(this.tblUpdateHistory, "tblUpdateHistory");
            this.tblUpdateHistory.Name = "tblUpdateHistory";
            this.tblUpdateHistory.NamedProperties.Put("DefaultOrderBy", "OPERATION_DATE DESC, ACTION_DB");
            this.tblUpdateHistory.NamedProperties.Put("DefaultWhere", "");
            this.tblUpdateHistory.NamedProperties.Put("LogicalUnit", "DataSubjectConsentOper");
            this.tblUpdateHistory.NamedProperties.Put("Module", "ENTERP");
            this.tblUpdateHistory.NamedProperties.Put("PackageName", "DATA_SUBJECT_CONSENT_OPER_API");
            this.tblUpdateHistory.NamedProperties.Put("SourceFlags", "129");
            this.tblUpdateHistory.NamedProperties.Put("ViewName", "DATA_SUBJECT_CONSENT_OPER");
            this.tblUpdateHistory.Controls.SetChildIndex(this.tblUpdateHistory_colsLastUpdateAction, 0);
            this.tblUpdateHistory.Controls.SetChildIndex(this.tblUpdateHistory_colsActionDb, 0);
            this.tblUpdateHistory.Controls.SetChildIndex(this.tblUpdateHistory_colsPerformedBy, 0);
            this.tblUpdateHistory.Controls.SetChildIndex(this.tblUpdateHistory_colsRemark, 0);
            this.tblUpdateHistory.Controls.SetChildIndex(this.tblUpdateHistory_colsAction, 0);
            this.tblUpdateHistory.Controls.SetChildIndex(this.tblUpdateHistory_coldUpdateDate, 0);
            this.tblUpdateHistory.Controls.SetChildIndex(this.tblUpdateHistory_coldOperationDate, 0);
            this.tblUpdateHistory.Controls.SetChildIndex(this.tblUpdateHistory_colsDataSubjectDb, 0);
            this.tblUpdateHistory.Controls.SetChildIndex(this.tblUpdateHistory_colsDataSubject, 0);
            this.tblUpdateHistory.Controls.SetChildIndex(this.tblUpdateHistory_colsDataSubjectId, 0);
            this.tblUpdateHistory.Controls.SetChildIndex(this.tblUpdateHistory_colsKeyRef, 0);
            this.tblUpdateHistory.Controls.SetChildIndex(this.tblUpdateHistory_colsSelected, 0);
            // 
            // tblUpdateHistory_colsSelected
            // 
            this.tblUpdateHistory_colsSelected.Name = "tblUpdateHistory_colsSelected";
            this.tblUpdateHistory_colsSelected.NamedProperties.Put("FieldFlags", "262");
            this.tblUpdateHistory_colsSelected.Position = 3;
            resources.ApplyResources(this.tblUpdateHistory_colsSelected, "tblUpdateHistory_colsSelected");
            this.tblUpdateHistory_colsSelected.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblUpdateHistory_colsSelected_WindowActions);
            // 
            // tblUpdateHistory_colsKeyRef
            // 
            this.tblUpdateHistory_colsKeyRef.Name = "tblUpdateHistory_colsKeyRef";
            this.tblUpdateHistory_colsKeyRef.NamedProperties.Put("EnumerateMethod", "");
            this.tblUpdateHistory_colsKeyRef.NamedProperties.Put("FieldFlags", "4195");
            this.tblUpdateHistory_colsKeyRef.NamedProperties.Put("LovReference", "DATA_SUBJECT_CONSENT");
            this.tblUpdateHistory_colsKeyRef.NamedProperties.Put("SqlColumn", "KEY_REF");
            this.tblUpdateHistory_colsKeyRef.Position = 4;
            resources.ApplyResources(this.tblUpdateHistory_colsKeyRef, "tblUpdateHistory_colsKeyRef");
            // 
            // tblUpdateHistory_colsDataSubjectId
            // 
            this.tblUpdateHistory_colsDataSubjectId.MaxLength = 2000;
            this.tblUpdateHistory_colsDataSubjectId.Name = "tblUpdateHistory_colsDataSubjectId";
            this.tblUpdateHistory_colsDataSubjectId.NamedProperties.Put("EnumerateMethod", "");
            this.tblUpdateHistory_colsDataSubjectId.NamedProperties.Put("FieldFlags", "288");
            this.tblUpdateHistory_colsDataSubjectId.NamedProperties.Put("LovReference", "");
            this.tblUpdateHistory_colsDataSubjectId.NamedProperties.Put("SqlColumn", "Data_Subject_Consent_API.Get_Identity(KEY_REF,Data_Subject_Consent_API.Get_Data_S" +
        "ubject_Db(KEY_REF))");
            this.tblUpdateHistory_colsDataSubjectId.Position = 5;
            resources.ApplyResources(this.tblUpdateHistory_colsDataSubjectId, "tblUpdateHistory_colsDataSubjectId");
            // 
            // tblUpdateHistory_colsDataSubject
            // 
            this.tblUpdateHistory_colsDataSubject.MaxLength = 2000;
            this.tblUpdateHistory_colsDataSubject.Name = "tblUpdateHistory_colsDataSubject";
            this.tblUpdateHistory_colsDataSubject.NamedProperties.Put("EnumerateMethod", "");
            this.tblUpdateHistory_colsDataSubject.NamedProperties.Put("FieldFlags", "288");
            this.tblUpdateHistory_colsDataSubject.NamedProperties.Put("LovReference", "");
            this.tblUpdateHistory_colsDataSubject.NamedProperties.Put("SqlColumn", "Data_Subject_Consent_API.Get_Data_Subject(KEY_REF)");
            this.tblUpdateHistory_colsDataSubject.Position = 6;
            resources.ApplyResources(this.tblUpdateHistory_colsDataSubject, "tblUpdateHistory_colsDataSubject");
            // 
            // tblUpdateHistory_colsDataSubjectDb
            // 
            this.tblUpdateHistory_colsDataSubjectDb.MaxLength = 2000;
            this.tblUpdateHistory_colsDataSubjectDb.Name = "tblUpdateHistory_colsDataSubjectDb";
            this.tblUpdateHistory_colsDataSubjectDb.NamedProperties.Put("EnumerateMethod", "");
            this.tblUpdateHistory_colsDataSubjectDb.NamedProperties.Put("FieldFlags", "4384");
            this.tblUpdateHistory_colsDataSubjectDb.NamedProperties.Put("LovReference", "");
            this.tblUpdateHistory_colsDataSubjectDb.NamedProperties.Put("SqlColumn", "Data_Subject_Consent_API.Get_Data_Subject_Db(KEY_REF)");
            this.tblUpdateHistory_colsDataSubjectDb.Position = 7;
            resources.ApplyResources(this.tblUpdateHistory_colsDataSubjectDb, "tblUpdateHistory_colsDataSubjectDb");
            // 
            // tblUpdateHistory_coldOperationDate
            // 
            this.tblUpdateHistory_coldOperationDate.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.tblUpdateHistory_coldOperationDate.Format = "G";
            this.tblUpdateHistory_coldOperationDate.Name = "tblUpdateHistory_coldOperationDate";
            this.tblUpdateHistory_coldOperationDate.NamedProperties.Put("EnumerateMethod", "");
            this.tblUpdateHistory_coldOperationDate.NamedProperties.Put("FieldFlags", "163");
            this.tblUpdateHistory_coldOperationDate.NamedProperties.Put("LovReference", "");
            this.tblUpdateHistory_coldOperationDate.NamedProperties.Put("SqlColumn", "OPERATION_DATE");
            this.tblUpdateHistory_coldOperationDate.Position = 8;
            resources.ApplyResources(this.tblUpdateHistory_coldOperationDate, "tblUpdateHistory_coldOperationDate");
            // 
            // tblUpdateHistory_coldUpdateDate
            // 
            this.tblUpdateHistory_coldUpdateDate.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.tblUpdateHistory_coldUpdateDate.Format = "d";
            this.tblUpdateHistory_coldUpdateDate.Name = "tblUpdateHistory_coldUpdateDate";
            this.tblUpdateHistory_coldUpdateDate.NamedProperties.Put("EnumerateMethod", "");
            this.tblUpdateHistory_coldUpdateDate.NamedProperties.Put("FieldFlags", "163");
            this.tblUpdateHistory_coldUpdateDate.NamedProperties.Put("LovReference", "");
            this.tblUpdateHistory_coldUpdateDate.NamedProperties.Put("SqlColumn", "UPDATE_DATE");
            this.tblUpdateHistory_coldUpdateDate.Position = 9;
            resources.ApplyResources(this.tblUpdateHistory_coldUpdateDate, "tblUpdateHistory_coldUpdateDate");
            // 
            // tblUpdateHistory_colsAction
            // 
            this.tblUpdateHistory_colsAction.MaxLength = 20;
            this.tblUpdateHistory_colsAction.Name = "tblUpdateHistory_colsAction";
            this.tblUpdateHistory_colsAction.NamedProperties.Put("EnumerateMethod", "");
            this.tblUpdateHistory_colsAction.NamedProperties.Put("FieldFlags", "291");
            this.tblUpdateHistory_colsAction.NamedProperties.Put("LovReference", "");
            this.tblUpdateHistory_colsAction.NamedProperties.Put("SqlColumn", "ACTION");
            this.tblUpdateHistory_colsAction.Position = 10;
            resources.ApplyResources(this.tblUpdateHistory_colsAction, "tblUpdateHistory_colsAction");
            // 
            // tblUpdateHistory_colsRemark
            // 
            this.tblUpdateHistory_colsRemark.MaxLength = 2000;
            this.tblUpdateHistory_colsRemark.Name = "tblUpdateHistory_colsRemark";
            this.tblUpdateHistory_colsRemark.NamedProperties.Put("EnumerateMethod", "");
            this.tblUpdateHistory_colsRemark.NamedProperties.Put("FieldFlags", "290");
            this.tblUpdateHistory_colsRemark.NamedProperties.Put("LovReference", "");
            this.tblUpdateHistory_colsRemark.NamedProperties.Put("SqlColumn", "REMARK");
            this.tblUpdateHistory_colsRemark.Position = 11;
            resources.ApplyResources(this.tblUpdateHistory_colsRemark, "tblUpdateHistory_colsRemark");
            // 
            // tblUpdateHistory_colsPerformedBy
            // 
            this.tblUpdateHistory_colsPerformedBy.MaxLength = 30;
            this.tblUpdateHistory_colsPerformedBy.Name = "tblUpdateHistory_colsPerformedBy";
            this.tblUpdateHistory_colsPerformedBy.NamedProperties.Put("EnumerateMethod", "");
            this.tblUpdateHistory_colsPerformedBy.NamedProperties.Put("FieldFlags", "291");
            this.tblUpdateHistory_colsPerformedBy.NamedProperties.Put("LovReference", "");
            this.tblUpdateHistory_colsPerformedBy.NamedProperties.Put("SqlColumn", "PERFORMED_BY");
            this.tblUpdateHistory_colsPerformedBy.Position = 12;
            resources.ApplyResources(this.tblUpdateHistory_colsPerformedBy, "tblUpdateHistory_colsPerformedBy");
            // 
            // tblUpdateHistory_colsActionDb
            // 
            this.tblUpdateHistory_colsActionDb.MaxLength = 20;
            this.tblUpdateHistory_colsActionDb.Name = "tblUpdateHistory_colsActionDb";
            this.tblUpdateHistory_colsActionDb.NamedProperties.Put("EnumerateMethod", "");
            this.tblUpdateHistory_colsActionDb.NamedProperties.Put("FieldFlags", "288");
            this.tblUpdateHistory_colsActionDb.NamedProperties.Put("LovReference", "");
            this.tblUpdateHistory_colsActionDb.NamedProperties.Put("SqlColumn", "ACTION_DB");
            this.tblUpdateHistory_colsActionDb.Position = 13;
            resources.ApplyResources(this.tblUpdateHistory_colsActionDb, "tblUpdateHistory_colsActionDb");
            // 
            // tblUpdateHistory_colsLastUpdateAction
            // 
            this.tblUpdateHistory_colsLastUpdateAction.MaxLength = 2000;
            this.tblUpdateHistory_colsLastUpdateAction.Name = "tblUpdateHistory_colsLastUpdateAction";
            this.tblUpdateHistory_colsLastUpdateAction.NamedProperties.Put("EnumerateMethod", "");
            this.tblUpdateHistory_colsLastUpdateAction.NamedProperties.Put("FieldFlags", "288");
            this.tblUpdateHistory_colsLastUpdateAction.NamedProperties.Put("LovReference", "");
            this.tblUpdateHistory_colsLastUpdateAction.NamedProperties.Put("SqlColumn", "Data_Subject_Consent_Oper_API.Is_Last_Update_Action(KEY_REF,OPERATION_DATE,ACTION" +
        "_DB)");
            this.tblUpdateHistory_colsLastUpdateAction.Position = 14;
            resources.ApplyResources(this.tblUpdateHistory_colsLastUpdateAction, "tblUpdateHistory_colsLastUpdateAction");
            // 
            // dfsKeyRef
            // 
            resources.ApplyResources(this.dfsKeyRef, "dfsKeyRef");
            this.dfsKeyRef.Name = "dfsKeyRef";
            // 
            // labelConsentGiven
            // 
            resources.ApplyResources(this.labelConsentGiven, "labelConsentGiven");
            this.labelConsentGiven.Name = "labelConsentGiven";
            // 
            // tblDataProcessPurpose
            // 
            this.tblDataProcessPurpose.Controls.Add(this.tblDataProcessPurpose_colnPurposeId);
            this.tblDataProcessPurpose.Controls.Add(this.tblDataProcessPurpose_colsValid);
            this.tblDataProcessPurpose.Controls.Add(this.tblDataProcessPurpose_colsPurposeName);
            this.tblDataProcessPurpose.Controls.Add(this.tblDataProcessPurpose_coldEffectiveOn);
            this.tblDataProcessPurpose.Controls.Add(this.tblDataProcessPurpose_coldEffectiveUntil);
            this.tblDataProcessPurpose.Controls.Add(this.tblDataProcessPurpose_colsPurposePersonalDataList);
            this.tblDataProcessPurpose.Controls.Add(this.tblDataProcessPurpose_colsDescription);
            resources.ApplyResources(this.tblDataProcessPurpose, "tblDataProcessPurpose");
            this.tblDataProcessPurpose.Name = "tblDataProcessPurpose";
            this.tblDataProcessPurpose.NamedProperties.Put("DefaultOrderBy", "PURPOSE_ID");
            this.tblDataProcessPurpose.NamedProperties.Put("DefaultWhere", "\n");
            this.tblDataProcessPurpose.NamedProperties.Put("LogicalUnit", "DataSubjectConsentPurp");
            this.tblDataProcessPurpose.NamedProperties.Put("Module", "ENTERP");
            this.tblDataProcessPurpose.NamedProperties.Put("PackageName", "DATA_SUBJECT_CONSENT_PURP_API");
            this.tblDataProcessPurpose.NamedProperties.Put("SourceFlags", "129");
            this.tblDataProcessPurpose.NamedProperties.Put("ViewName", "PERS_DATA_PROC_PURPOSE_ASSIST");
            this.tblDataProcessPurpose.Controls.SetChildIndex(this.tblDataProcessPurpose_colsDescription, 0);
            this.tblDataProcessPurpose.Controls.SetChildIndex(this.tblDataProcessPurpose_colsPurposePersonalDataList, 0);
            this.tblDataProcessPurpose.Controls.SetChildIndex(this.tblDataProcessPurpose_coldEffectiveUntil, 0);
            this.tblDataProcessPurpose.Controls.SetChildIndex(this.tblDataProcessPurpose_coldEffectiveOn, 0);
            this.tblDataProcessPurpose.Controls.SetChildIndex(this.tblDataProcessPurpose_colsPurposeName, 0);
            this.tblDataProcessPurpose.Controls.SetChildIndex(this.tblDataProcessPurpose_colsValid, 0);
            this.tblDataProcessPurpose.Controls.SetChildIndex(this.tblDataProcessPurpose_colnPurposeId, 0);
            // 
            // tblDataProcessPurpose_colnPurposeId
            // 
            this.tblDataProcessPurpose_colnPurposeId.Name = "tblDataProcessPurpose_colnPurposeId";
            this.tblDataProcessPurpose_colnPurposeId.NamedProperties.Put("EnumerateMethod", "");
            this.tblDataProcessPurpose_colnPurposeId.NamedProperties.Put("LovReference", "");
            this.tblDataProcessPurpose_colnPurposeId.NamedProperties.Put("SqlColumn", "PURPOSE_ID");
            this.tblDataProcessPurpose_colnPurposeId.Position = 3;
            resources.ApplyResources(this.tblDataProcessPurpose_colnPurposeId, "tblDataProcessPurpose_colnPurposeId");
            // 
            // tblDataProcessPurpose_colsValid
            // 
            this.tblDataProcessPurpose_colsValid.MaxLength = 5;
            this.tblDataProcessPurpose_colsValid.Name = "tblDataProcessPurpose_colsValid";
            this.tblDataProcessPurpose_colsValid.NamedProperties.Put("EnumerateMethod", "");
            this.tblDataProcessPurpose_colsValid.NamedProperties.Put("FieldFlags", "288");
            this.tblDataProcessPurpose_colsValid.NamedProperties.Put("LovReference", "");
            this.tblDataProcessPurpose_colsValid.NamedProperties.Put("SqlColumn", "VALID");
            this.tblDataProcessPurpose_colsValid.Position = 4;
            resources.ApplyResources(this.tblDataProcessPurpose_colsValid, "tblDataProcessPurpose_colsValid");
            this.tblDataProcessPurpose_colsValid.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblDataProcessPurpose_colsSelected_WindowActions);
            // 
            // tblDataProcessPurpose_colsPurposeName
            // 
            this.tblDataProcessPurpose_colsPurposeName.Name = "tblDataProcessPurpose_colsPurposeName";
            this.tblDataProcessPurpose_colsPurposeName.NamedProperties.Put("EnumerateMethod", "");
            this.tblDataProcessPurpose_colsPurposeName.NamedProperties.Put("FieldFlags", "288");
            this.tblDataProcessPurpose_colsPurposeName.NamedProperties.Put("LovReference", "");
            this.tblDataProcessPurpose_colsPurposeName.NamedProperties.Put("SqlColumn", "PURPOSE_NAME");
            this.tblDataProcessPurpose_colsPurposeName.Position = 5;
            resources.ApplyResources(this.tblDataProcessPurpose_colsPurposeName, "tblDataProcessPurpose_colsPurposeName");
            // 
            // tblDataProcessPurpose_coldEffectiveOn
            // 
            this.tblDataProcessPurpose_coldEffectiveOn.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.tblDataProcessPurpose_coldEffectiveOn.Format = "d";
            this.tblDataProcessPurpose_coldEffectiveOn.Name = "tblDataProcessPurpose_coldEffectiveOn";
            this.tblDataProcessPurpose_coldEffectiveOn.NamedProperties.Put("EnumerateMethod", "");
            this.tblDataProcessPurpose_coldEffectiveOn.NamedProperties.Put("FieldFlags", "294");
            this.tblDataProcessPurpose_coldEffectiveOn.NamedProperties.Put("LovReference", "");
            this.tblDataProcessPurpose_coldEffectiveOn.NamedProperties.Put("SqlColumn", "EFFECTIVE_ON");
            this.tblDataProcessPurpose_coldEffectiveOn.Position = 6;
            resources.ApplyResources(this.tblDataProcessPurpose_coldEffectiveOn, "tblDataProcessPurpose_coldEffectiveOn");
            this.tblDataProcessPurpose_coldEffectiveOn.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblDataProcessPurpose_coldEffectiveOn_WindowActions);
            // 
            // tblDataProcessPurpose_coldEffectiveUntil
            // 
            this.tblDataProcessPurpose_coldEffectiveUntil.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.tblDataProcessPurpose_coldEffectiveUntil.Format = "d";
            this.tblDataProcessPurpose_coldEffectiveUntil.Name = "tblDataProcessPurpose_coldEffectiveUntil";
            this.tblDataProcessPurpose_coldEffectiveUntil.NamedProperties.Put("EnumerateMethod", "");
            this.tblDataProcessPurpose_coldEffectiveUntil.NamedProperties.Put("FieldFlags", "294");
            this.tblDataProcessPurpose_coldEffectiveUntil.NamedProperties.Put("LovReference", "");
            this.tblDataProcessPurpose_coldEffectiveUntil.NamedProperties.Put("SqlColumn", "EFFECTIVE_UNTIL");
            this.tblDataProcessPurpose_coldEffectiveUntil.Position = 7;
            resources.ApplyResources(this.tblDataProcessPurpose_coldEffectiveUntil, "tblDataProcessPurpose_coldEffectiveUntil");
            this.tblDataProcessPurpose_coldEffectiveUntil.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblDataProcessPurpose_coldEffectiveUntil_WindowActions);
            // 
            // tblDataProcessPurpose_colsPurposePersonalDataList
            // 
            this.tblDataProcessPurpose_colsPurposePersonalDataList.MaxLength = 2000;
            this.tblDataProcessPurpose_colsPurposePersonalDataList.Name = "tblDataProcessPurpose_colsPurposePersonalDataList";
            this.tblDataProcessPurpose_colsPurposePersonalDataList.NamedProperties.Put("EnumerateMethod", "");
            this.tblDataProcessPurpose_colsPurposePersonalDataList.NamedProperties.Put("FieldFlags", "304");
            this.tblDataProcessPurpose_colsPurposePersonalDataList.NamedProperties.Put("LovReference", "");
            this.tblDataProcessPurpose_colsPurposePersonalDataList.NamedProperties.Put("SqlColumn", "PURPOSE_PERSONAL_DATA_LIST");
            this.tblDataProcessPurpose_colsPurposePersonalDataList.Position = 8;
            resources.ApplyResources(this.tblDataProcessPurpose_colsPurposePersonalDataList, "tblDataProcessPurpose_colsPurposePersonalDataList");
            // 
            // tblDataProcessPurpose_colsDescription
            // 
            this.tblDataProcessPurpose_colsDescription.MaxLength = 2000;
            this.tblDataProcessPurpose_colsDescription.Name = "tblDataProcessPurpose_colsDescription";
            this.tblDataProcessPurpose_colsDescription.NamedProperties.Put("EnumerateMethod", "");
            this.tblDataProcessPurpose_colsDescription.NamedProperties.Put("FieldFlags", "304");
            this.tblDataProcessPurpose_colsDescription.NamedProperties.Put("LovReference", "");
            this.tblDataProcessPurpose_colsDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.tblDataProcessPurpose_colsDescription.Position = 9;
            resources.ApplyResources(this.tblDataProcessPurpose_colsDescription, "tblDataProcessPurpose_colsDescription");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbNoConsent);
            this.groupBox1.Controls.Add(this.dfsRemark);
            this.groupBox1.Controls.Add(this.dfsDataSubject);
            this.groupBox1.Controls.Add(this.rbNewConsent);
            this.groupBox1.Controls.Add(this.rbShowSelected);
            this.groupBox1.Controls.Add(this.dfsKeyRef);
            this.groupBox1.Controls.Add(this.labelIdentity);
            this.groupBox1.Controls.Add(this.labelIdentityName);
            this.groupBox1.Controls.Add(this.tblDataProcessPurpose);
            this.groupBox1.Controls.Add(this.dfsIdentityName);
            this.groupBox1.Controls.Add(this.dfsIdentity);
            this.groupBox1.Controls.Add(this.dfdUpdateDate);
            this.groupBox1.Controls.Add(this.labelUpdateDate);
            this.groupBox1.Controls.Add(this.labelRemark);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // dfsRemark
            // 
            resources.ApplyResources(this.dfsRemark, "dfsRemark");
            this.dfsRemark.Name = "dfsRemark";
            this.dfsRemark.NamedProperties.Put("FieldFlags", "278");
            // 
            // dfsDataSubject
            // 
            resources.ApplyResources(this.dfsDataSubject, "dfsDataSubject");
            this.dfsDataSubject.Name = "dfsDataSubject";
            // 
            // rbNoConsent
            // 
            resources.ApplyResources(this.rbNoConsent, "rbNoConsent");
            this.rbNoConsent.Name = "rbNoConsent";
            this.rbNoConsent.TabStop = true;
            this.rbNoConsent.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.rbNoConsent_WindowActions);
            // 
            // rbNewConsent
            // 
            resources.ApplyResources(this.rbNewConsent, "rbNewConsent");
            this.rbNewConsent.Name = "rbNewConsent";
            this.rbNewConsent.TabStop = true;
            this.rbNewConsent.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.rbNewConsent_WindowActions);
            // 
            // rbShowSelected
            // 
            resources.ApplyResources(this.rbShowSelected, "rbShowSelected");
            this.rbShowSelected.Name = "rbShowSelected";
            this.rbShowSelected.TabStop = true;
            this.rbShowSelected.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.rbShowSelected_WindowActions);
            // 
            // cCommandButtonPrint
            // 
            this.cCommandButtonPrint.Command = this.commandPrint;
            resources.ApplyResources(this.cCommandButtonPrint, "cCommandButtonPrint");
            this.cCommandButtonPrint.Name = "cCommandButtonPrint";
            // 
            // commandPrint
            // 
            resources.ApplyResources(this.commandPrint, "commandPrint");
            this.commandPrint.Name = "commandPrint";
            this.commandPrint.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.commandPrint_Execute);
            this.commandPrint.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.commandPrint_Inquire);
            // 
            // dlgPersonalDataConsent
            // 
            this.AcceptButton = this.cCommandButtonOK;
            this.CancelButton = this.cCommandButtonCancel;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.cCommandButtonPrint);
            this.Controls.Add(this.labelConsentGiven);
            this.Controls.Add(this.tblUpdateHistory);
            this.Controls.Add(this.cCommandButtonOK);
            this.Controls.Add(this.cCommandButtonCancel);
            this.Controls.Add(this.groupBox1);
            this.DataBound = false;
            this.Name = "dlgPersonalDataConsent";
            this.NamedProperties.Put("LogicalUnit", "");
            this.NamedProperties.Put("PackageName", "");
            this.NamedProperties.Put("ViewName", "");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dlgPersonalDataConsent_WindowActions);
            this.tblUpdateHistory.ResumeLayout(false);
            this.tblDataProcessPurpose.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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

        protected Ifs.Fnd.Windows.Forms.FndCommand commandOk;
        protected Ifs.Fnd.Windows.Forms.FndCommand commandCancel;
        protected cDataField dfdUpdateDate;
        protected cBackgroundText labelUpdateDate;
        protected cBackgroundText labelRemark;
        protected cDataField dfsIdentity;
        protected cDataField dfsIdentityName;
        protected cBackgroundText labelIdentity;
        protected cBackgroundText labelIdentityName;
        protected cChildTable tblUpdateHistory;
        protected cDataField dfsKeyRef;
        protected cBackgroundText labelConsentGiven;
        protected cCommandButton cCommandButtonOK;
        protected cCommandButton cCommandButtonCancel;
        protected cColumn tblUpdateHistory_coldUpdateDate;
        protected cColumn tblUpdateHistory_colsAction;
        protected cColumn tblUpdateHistory_colsRemark;
        protected cColumn tblUpdateHistory_coldOperationDate;
        protected cColumn tblUpdateHistory_colsPerformedBy;
        protected cChildTable tblDataProcessPurpose;
        protected cColumn tblDataProcessPurpose_colnPurposeId;
        protected cColumn tblDataProcessPurpose_colsPurposeName;
        protected cCheckBoxColumn tblDataProcessPurpose_colsValid;
        protected GroupBox groupBox1;
        protected cColumn tblUpdateHistory_colsKeyRef;
        protected cColumn tblUpdateHistory_colsDataSubject;
        protected cCheckBoxColumn tblUpdateHistory_colsSelected;
        protected cRadioButton rbShowSelected;
        protected cRadioButton rbNoConsent;
        protected cRadioButton rbNewConsent;
        protected cColumn tblUpdateHistory_colsDataSubjectId;
        protected cColumn tblUpdateHistory_colsDataSubjectDb;
        protected cDataField dfsDataSubject;
        protected cColumn tblDataProcessPurpose_coldEffectiveOn;
        protected cColumn tblDataProcessPurpose_coldEffectiveUntil;
        protected cColumn tblUpdateHistory_colsActionDb;
        protected cCheckBoxColumn tblUpdateHistory_colsLastUpdateAction;
        protected cDataField dfsRemark;
        protected cColumn tblDataProcessPurpose_colsPurposePersonalDataList;
        protected Fnd.Windows.Forms.FndCommand commandPrint;
        protected cCommandButton cCommandButtonPrint;
        protected cColumn tblDataProcessPurpose_colsDescription;

    }
}
