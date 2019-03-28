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

using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using Ifs.Fnd.ApplicationForms;
using Ifs.Fnd.Windows.Forms;
using PPJ.Runtime;
using PPJ.Runtime.Windows;
using System;

namespace Ifs.Application.Enterp
{

    /// <summary>
    /// </summary>
    [FndWindowRegistration("DATA_SUBJECT_CONSENT_OPER, DATA_SUBJECT_CONSENT_PURP", "DataSubjectConsentOper,DataSubjectConsentPurp")]
    public partial class dlgPersonalDataConsent : cDialog
    {
        #region Member Variables
        protected SalString sContexKeyRef;
        protected SalString sContexDataSubject;
        protected SalString sContexIdentityName;
        protected SalDateTime dPurposeEffectiveOn;
        protected SalDateTime dPurposeEffectiveUntil;
        protected SalNumber nPurposeId;
        protected SalNumber nConsentRowSelected = -1;
        protected SalString sKeyRefSelected = "";
        protected SalDateTime dOperationDateSelected = Sys.DATETIME_Null;
        protected SalString sOperationDate = SalString.Null;
        protected SalString sActionSelected = "";
        protected SalString sDataSubjectSelected = "";
        protected SalString sAction = "";
        protected SalString sKeyRefList = "";
        protected SalDateTime dOperationDate = Sys.DATETIME_Null;
        protected SalBoolean bAnyPurposeSelected = false;
        protected SalString sSelected = "";
        protected SalString sAnyNotConnectedDataExists = "";
        protected Action resetDisplayedLabelsAndTexts;
        protected SalString sErasedCategories = SalString.Null;
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        protected dlgPersonalDataConsent()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();
            resetDisplayedLabelsAndTexts += EnableRadioButtons;
            resetDisplayedLabelsAndTexts += SetValidColumnTitle;
        }

        #endregion

        #region System Methods/Properties

        /// <summary>
        /// Shows the modal dialog.
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        public static SalNumber ModalDialog(Control owner, SalString sKeyRef, SalString sDataSubject, SalString sIdentityName)
        {
            dlgPersonalDataConsent dlg = DialogFactory.CreateInstance<dlgPersonalDataConsent>();
            dlg.sContexKeyRef = sKeyRef;
            dlg.sContexDataSubject = sDataSubject;
            dlg.sContexIdentityName = sIdentityName;
            SalNumber ret = dlg.ShowDialog(owner);
            return ret;
        }

        /// <summary>
        /// Returns the object instance associated with the window handle.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public new static dlgPersonalDataConsent FromHandle(SalWindowHandle handle)
        {
            return ((dlgPersonalDataConsent)SalWindow.FromHandle(handle, typeof(dlgPersonalDataConsent)));
        }

        #endregion

        #region Methods
        public virtual void SetIdentity()
        {
            #region Actions
            IDictionary<string, string> namedBindVariables = new Dictionary<string, string>();
            namedBindVariables.Add("KeyRef", dfsKeyRef.QualifiedBindName);
            namedBindVariables.Add("DataSubject", dfsDataSubject.QualifiedBindName);
            namedBindVariables.Add("Identity", dfsIdentity.QualifiedBindName);
            DbPLSQLBlock(@"{Identity} := &AO.Data_Subject_Consent_API.Get_Identity({KeyRef} IN, 
                                                                                   {DataSubject} IN);", namedBindVariables);
            #endregion
        }

        public virtual void SetValidColumnTitle()
        {
            #region Actions
            if (!string.IsNullOrWhiteSpace(sActionSelected))
            {
                tblDataProcessPurpose_colsValid.Title = (sActionSelected == "DATA_ERASED") ? Properties.Resources.TEXT_ColumnValidTextWithdrawn : Properties.Resources.TEXT_ColumnValidTextValid;            
            }
            else
            {
                tblDataProcessPurpose_colsValid.Title = Properties.Resources.TEXT_ColumnValidTextValid;
            }
            #endregion

        }

        public virtual void EnableRadioButtons()
        {
            #region Actions
            if (nConsentRowSelected >= 0)
            {
                Sal.EnableWindow(rbShowSelected);
                rbNewConsent.Text = Properties.Resources.TEXT_ConsentUpdate;
                if (tblUpdateHistory_colsLastUpdateAction.Text != "TRUE")
                    Sal.DisableWindow(rbNewConsent);
                else
                    Sal.EnableWindow(rbNewConsent);
            }
            else
            {
                rbNewConsent.Text = Properties.Resources.TEXT_ConsentNew;
                Sal.EnableWindow(rbNewConsent);
                Sal.DisableWindow(rbShowSelected);
                if (!(rbNewConsent.Checked || rbNoConsent.Checked))
                    rbNewConsent.Checked = true;
            }
            #endregion
        }

        public virtual void UnselectConsent()
        {
            #region Actions
            Sal.TblSetContext(tblUpdateHistory, nConsentRowSelected);
            tblUpdateHistory_colsSelected.Text = "FALSE";
            nConsentRowSelected = -1;
            dfsIdentity.Text = "";
            dfdUpdateDate.DateTime = Sys.DATETIME_Null;
            dfsRemark.Text = "";
            sKeyRefSelected = "";
            dOperationDateSelected = Sys.DATETIME_Null;
            sActionSelected = "";
            resetDisplayedLabelsAndTexts();
            #endregion
        }

        public virtual void ConsentSelected()
        {
            #region Local Variables
            SalNumber nCurrentRow = 0;
            #endregion

            #region Actions
            nCurrentRow = Sal.TblQueryContext(tblUpdateHistory);
            if (tblUpdateHistory_colsSelected.Text == "TRUE")
            {
                if (nConsentRowSelected >= 0 && nCurrentRow != nConsentRowSelected)
                {
                    Sal.TblSetContext(tblUpdateHistory, nConsentRowSelected);
                    this.tblUpdateHistory_colsSelected.Text = "FALSE";
                    Sal.TblSetContext(tblUpdateHistory, nCurrentRow);
                    nConsentRowSelected = nCurrentRow;
                }
                else
                {
                    nConsentRowSelected = nCurrentRow;
                }
                rbShowSelected.Checked = true;
                sActionSelected = tblUpdateHistory_colsActionDb.Text;
            }
            else
            {
                nConsentRowSelected = -1;
                dfsIdentity.Text = "";
                dfdUpdateDate.DateTime = Sys.DATETIME_Null;
                dfsRemark.Text = "";
                sKeyRefSelected = "";
                dOperationDateSelected = Sys.DATETIME_Null;
                sActionSelected = "";
            }
            resetDisplayedLabelsAndTexts();
            ChangeOptions();
            #endregion
        }

        public virtual void ChangeOptions()
        {
            #region Actions
            if (nConsentRowSelected >= 0)
            {
                Sal.TblSetContext(tblUpdateHistory, nConsentRowSelected);
                sKeyRefSelected = tblUpdateHistory_colsKeyRef.Text;
                dOperationDateSelected = tblUpdateHistory_coldOperationDate.DateTime;
                sActionSelected = tblUpdateHistory_colsActionDb.Text;
                sDataSubjectSelected = tblUpdateHistory_colsDataSubjectDb.Text;
                tblDataProcessPurpose.p_lsDefaultWhere = "DATA_SUBJECT_DB = :i_hWndParent.dlgPersonalDataConsent.dfsDataSubject "
                                                          + "AND KEY_REF = :i_hWndParent.dlgPersonalDataConsent.sKeyRefSelected "
                                                          + "AND OPERATION_DATE = :i_hWndParent.dlgPersonalDataConsent.dOperationDateSelected "
                                                          + "AND ACTION = :i_hWndParent.dlgPersonalDataConsent.sActionSelected";
            }
            if (rbShowSelected.Checked)
            {
                dfsKeyRef.Text = sKeyRefSelected;
                dfsIdentity.Text = tblUpdateHistory_colsDataSubjectId.Text;                
                dfsDataSubject.Text = tblUpdateHistory_colsDataSubjectDb.Text;
                dfdUpdateDate.DateTime = tblUpdateHistory_coldUpdateDate.DateTime;
                dfsRemark.Text = tblUpdateHistory_colsRemark.Text;
                Sal.DisableWindow(dfdUpdateDate);
                Sal.DisableWindow(dfsRemark);
                tblDataProcessPurpose.ReadOnly = true;
                tblDataProcessPurpose.DataSourcePopulateIt(Ifs.Fnd.ApplicationForms.Const.POPULATE_NoConfirm);
            }
            else if (rbNewConsent.Checked)
            {                
                if (sKeyRefSelected == "")
                {
                    dfsKeyRef.Text = sContexKeyRef;                    
                    dfsDataSubject.Text = sContexDataSubject;
                    SetIdentity();
                    dOperationDateSelected = Sys.DATETIME_Null;
                    tblDataProcessPurpose.p_lsDefaultWhere = "DATA_SUBJECT_DB = :i_hWndParent.dlgPersonalDataConsent.dfsDataSubject AND KEY_REF IS NULL";
                }
                dfdUpdateDate.DateTime = SalDateTime.Current;
                dfsRemark.Text = "";
                Sal.EnableWindow(dfdUpdateDate);                         
                Sal.EnableWindow(dfsRemark);
                tblDataProcessPurpose.ReadOnly = false;
                tblDataProcessPurpose.DataSourcePopulateIt(Ifs.Fnd.ApplicationForms.Const.POPULATE_NoConfirm);
            }
            else if (rbNoConsent.Checked)
            {
                if (nConsentRowSelected >= 0)
                {
                    UnselectConsent();
                }
                dfsKeyRef.Text = sContexKeyRef;
                dfsDataSubject.Text = sContexDataSubject;
                SetIdentity();                
                dfdUpdateDate.DateTime = SalDateTime.Current;
                dfsRemark.Text = "";
                Sal.EnableWindow(dfdUpdateDate);           
                Sal.EnableWindow(dfsRemark);                
                tblDataProcessPurpose.ReadOnly = true;
                tblDataProcessPurpose.p_lsDefaultWhere = "DATA_SUBJECT_DB = :i_hWndParent.dlgPersonalDataConsent.dfsDataSubject AND KEY_REF IS NULL";
                tblDataProcessPurpose.DataSourcePopulateIt(Ifs.Fnd.ApplicationForms.Const.POPULATE_NoConfirm);
            }
            if (nConsentRowSelected >= 0)
            {
                Sal.TblClearSelection(tblUpdateHistory);
                Sal.TblSetFocusRow(tblUpdateHistory, nConsentRowSelected);
            }
            #endregion
        }

        public virtual SalBoolean AnyPurposeSelected()
        {
            #region Local Variables
			SalNumber nIndex = 0;
            #endregion

            #region Actions
            nIndex = Sys.TBL_MinRow;
            while (Sal.TblFindNextRow(tblDataProcessPurpose, ref nIndex, 0, 0))
            {
                Sal.TblSetContext(tblDataProcessPurpose, nIndex);
                if (tblDataProcessPurpose_colsValid.Text == "TRUE")
                {
                    return true;
                }
            }
            return false;
            #endregion
        }

        public virtual SalBoolean CheckRequiredFields()
        {
            #region Actions
            if (!(Sal.IsNull(dfdUpdateDate)) && !rbShowSelected.Checked)
                return true;
            else
                return false;
            #endregion
        }

        public virtual SalNumber SetWindowTitle()
        {
            #region Actions
            using (new SalContext(this))
            {
                Sal.SetWindowText(i_hWndFrame, Properties.Resources.WH_dlgPersonalDataConsent);
            }

            return 0;
            #endregion
        }

        public virtual SalNumber GetLastUpdateRow()
        {
            #region Local Variables
            SalNumber nIndex = 0;
            #endregion

            #region Actions
            nIndex = Sys.TBL_MinRow;
            while (Sal.TblFindNextRow(tblUpdateHistory, ref nIndex, 0, 0))
            {
                Sal.TblSetContext(tblUpdateHistory, nIndex);
                if (tblUpdateHistory_colsLastUpdateAction.Text == "TRUE")
                {
                    return nIndex;
                }
            }
            return 0;
            #endregion
        }

        #endregion

        #region Window Actions
        private void dlgPersonalDataConsent_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_CreateComplete:
                    this.dlgPersonalDataConsent_OnSAM_CreateComplete(sender, e);
                    break;

                case Sys.SAM_Create:
					this.dlgPersonalDataConsent_OnSAM_Create(sender, e);
                    break;
            }
            #endregion
        }

        private void dlgPersonalDataConsent_OnSAM_Create(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam);
            SetWindowTitle();
            Sal.CenterWindow(this.i_hWndFrame);
            Sal.DisableWindow(dfsIdentity);
            Sal.DisableWindow(dfsIdentityName);
            dfsIdentityName.Text = this.sContexIdentityName;      
            #endregion
        }

        private void dlgPersonalDataConsent_OnSAM_CreateComplete(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Sys.SAM_CreateComplete, Sys.wParam, Sys.lParam);
            this.nConsentRowSelected = -1;

            IDictionary<string, string> namedBindVariables = new Dictionary<string, string>();
            namedBindVariables.Add("KeyRef", QualifiedVarBindName("sContexKeyRef"));
            namedBindVariables.Add("DataSubject", QualifiedVarBindName("sContexDataSubject"));
            namedBindVariables.Add("KeyRefList", QualifiedVarBindName("sKeyRefList"));
            DbPLSQLBlock(@"{KeyRefList} := &AO.Data_Subject_Consent_API.Get_Connected_Key_Ref({KeyRef} IN, 
                                                                                   {DataSubject} IN);", namedBindVariables);
            tblUpdateHistory.p_lsDefaultWhere = "KEY_REF IN ("+sKeyRefList+")";
            tblUpdateHistory.DataSourcePopulate(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
             
            if (Sal.TblAnyRows(tblUpdateHistory,0,0))
            {
                nConsentRowSelected = GetLastUpdateRow();
                sKeyRefSelected = tblUpdateHistory_colsKeyRef.Text;
                dOperationDateSelected = tblUpdateHistory_coldOperationDate.DateTime;
                sActionSelected = tblUpdateHistory_colsActionDb.Text;
                tblUpdateHistory_colsSelected.Text = "TRUE";
            }
            resetDisplayedLabelsAndTexts();
            ChangeOptions();
            #endregion
        }

        private void tblUpdateHistory_colsSelected_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_AnyEdit:
                    this.ConsentSelected();
                    break;
            }
            #endregion
        }

        private void rbShowSelected_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_Click:
                    e.Handled = true;
                    ChangeOptions();
                    break;
            }
            #endregion
        }

        private void rbNewConsent_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_Click:
                    e.Handled = true;
                    ChangeOptions();
                    break;
            }
            #endregion
        }

        private void rbNoConsent_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_Click:
                    e.Handled = true;
                    ChangeOptions();
                    break;
            }
            #endregion
        }

        private void tblDataProcessPurpose_colsSelected_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_AnyEdit:
                    e.Handled = true;
                    if (tblDataProcessPurpose_colsValid.Text == "FALSE")
                    {
                        tblDataProcessPurpose_coldEffectiveOn.DateTime = Sys.DATETIME_Null;
                        tblDataProcessPurpose_coldEffectiveUntil.DateTime = Sys.DATETIME_Null;
                    }
                    bAnyPurposeSelected = AnyPurposeSelected();
                    if (CheckRequiredFields())
                    {
                        Sal.EnableWindow(cCommandButtonOK);
                    }
                    else
                    {
                        Sal.DisableWindow(cCommandButtonOK);
                    }                    
                    break;
            }
            #endregion
        }

        private void tblDataProcessPurpose_coldEffectiveOn_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    e.Handled = true;
                    if (tblDataProcessPurpose_colsValid.Text == "TRUE")
                    {
                        e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldEnabled;
                        return;
                    }
                    else
                    {
                        e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                        return;
                    }
                    break;
            }
            #endregion
        }

        private void tblDataProcessPurpose_coldEffectiveUntil_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    e.Handled = true;
                    if (tblDataProcessPurpose_colsValid.Text == "TRUE")
                    {
                        e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldEnabled;
                        return;
                    }
                    else
                    {
                        e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                        return;
                    }
                    break;
            }
            #endregion
        }
        #endregion

        #region Event Handlers

        private void commandOk_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            #region Local Variables
			SalNumber nIndex = 0;
            #endregion

            #region Action            
            if (rbNewConsent.Checked)
                if (nConsentRowSelected >= 0)
                    sAction = "UPDATED_PURPOSES";
                else
                    sAction = "NEW_PURPOSE";
            else if (rbNoConsent.Checked)
                sAction = "PURPOSES_WITHDRAWN";
            else
                sAction = "";
            
            DialogResult = DialogResult.None;
            IDictionary<string, string> namedBindVariables = new Dictionary<string, string>();
            namedBindVariables.Add("KeyRef", dfsKeyRef.QualifiedBindName);
            namedBindVariables.Add("OperationDate", QualifiedVarBindName("dOperationDate"));
            namedBindVariables.Add("DataSubject", dfsDataSubject.QualifiedBindName);            
            namedBindVariables.Add("StatementDate", dfdUpdateDate.QualifiedBindName);
            namedBindVariables.Add("Action", QualifiedVarBindName("sAction"));
            namedBindVariables.Add("Remark", QualifiedVarBindName("dfsRemark"));
            namedBindVariables.Add("PurposeId", QualifiedVarBindName("nPurposeId"));
            namedBindVariables.Add("PurposeEffectiveOn", QualifiedVarBindName("dPurposeEffectiveOn"));
            namedBindVariables.Add("PurposeEffectiveUntil", QualifiedVarBindName("dPurposeEffectiveUntil"));
            namedBindVariables.Add("Selected", QualifiedVarBindName("sSelected"));
            namedBindVariables.Add("AnyNotConnectedDataExists", QualifiedVarBindName("sAnyNotConnectedDataExists"));
            namedBindVariables.Add("ErasedCategories", QualifiedVarBindName("sErasedCategories"));

            if (DbTransactionBegin(ref cSessionManager.c_hSql))
            {
                if (DbPLSQLBlock(@"&AO.Data_Subject_Consent_Oper_API.Consent_Action({OperationDate} INOUT,
                                                                                    {KeyRef} IN, 
                                                                                    {DataSubject} IN,                                                                                   
                                                                                    {StatementDate} IN,
                                                                                    {Action} IN,
                                                                                    {Remark} IN);", namedBindVariables))
                {

                    nIndex = Sys.TBL_MinRow;
                    while (Sal.TblFindNextRow(tblDataProcessPurpose, ref nIndex, 0, 0))
                    {
                        Sal.TblSetContext(tblDataProcessPurpose, nIndex);
                        nPurposeId = tblDataProcessPurpose_colnPurposeId.Number;
                        dPurposeEffectiveOn = tblDataProcessPurpose_coldEffectiveOn.DateTime;
                        dPurposeEffectiveUntil = tblDataProcessPurpose_coldEffectiveUntil.DateTime;
                        sSelected = tblDataProcessPurpose_colsValid.Text;
                        
                        if (!DbPLSQLBlock(@"&AO.Data_Subject_Consent_Purp_API.Consent_Action_Purpose({KeyRef} IN, 
                                                                                                        {OperationDate} IN,
                                                                                                        {Action} IN,
                                                                                                        {PurposeId} IN,
                                                                                                        {Selected} IN,
                                                                                                        {PurposeEffectiveOn} IN,
                                                                                                        {PurposeEffectiveUntil} IN);", namedBindVariables))
                        {
                            DbTransactionClear(cSessionManager.c_hSql);
                            return;
                        }
                    }

                    if (!DbPLSQLBlock(@"&AO.Data_Subject_Consent_Oper_API.Erase_Action_Check_Log({ErasedCategories} OUT,
                                                                                                 {KeyRef} IN, 
                                                                                                 {OperationDate} IN,
                                                                                                 {StatementDate} IN);", namedBindVariables))
                    {
                        DbTransactionClear(cSessionManager.c_hSql);
                        return;
                    }
                    else
                    {
                        if (!sErasedCategories.IsNull)
                        {
                            SalArray<SalString> sParam = new SalArray<SalString>();
                            sParam[0] = sErasedCategories;

                            if (Ifs.Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.TEXT_DataPersonalConsentRevokeParams, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Question, Ifs.Fnd.ApplicationForms.Const.QUESTION_YesNo, sParam) != Sys.IDYES)
                            {
                                DbTransactionClear(cSessionManager.c_hSql);
                                return;
                            }
                        }
                    }

                    DbTransactionEnd(cSessionManager.c_hSql);
                    Sal.EndDialog(this, Sys.IDOK);
                }
                else
                {
                   DbTransactionClear(cSessionManager.c_hSql);
                }                
            }
            #endregion
        }

        private void commandOk_Inquire(object sender, Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            #region Action
            ((FndCommand)sender).Enabled = CheckRequiredFields();
            #endregion
        }

        private void commandCancel_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            #region Action
            DialogResult = DialogResult.None;
            Sal.EndDialog(this, Sys.IDCANCEL);
            #endregion
        }

        private void commandPrint_Execute(object sender, FndCommandExecuteEventArgs e)
        {
            #region Local Variables
            SalString sParameterAttr = "";
            SalString sReportAttr = "";
            SalNumber nResultKey = 0;
            IDictionary<string, string> namedBindVariables = new Dictionary<string, string>();
            SalString sStmt;
            SalBoolean bRes;
            #endregion

            #region Actions
            if (rbNewConsent.Checked)
                if (nConsentRowSelected >= 0)
                    sAction = "UPDATED_PURPOSES";
                else
                    sAction = "NEW_PURPOSE";
            else if (rbNoConsent.Checked)
                sAction = "PURPOSES_WITHDRAWN";
            else
                sAction = "";

            sStmt = "{DateStr} := PERSONAL_DATA_RPI.Date_To_String({DateDate})";
            namedBindVariables.Add("DateStr", QualifiedVarBindName("sOperationDate"));
            namedBindVariables.Add("DateDate", QualifiedVarBindName("dOperationDateSelected"));
            Sal.WaitCursor(SalBoolean.True);
            bRes = DbPLSQLBlock(sStmt, namedBindVariables);
            Sal.WaitCursor(SalBoolean.False);
            if (!bRes) return;

            sReportAttr = Ifs.Fnd.ApplicationForms.Const.strNULL;
            Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("REPORT_ID", "PERSONAL_DATA_REP", ref sReportAttr);
            sParameterAttr = Ifs.Fnd.ApplicationForms.Const.strNULL;
            Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("KEY_REF", dfsKeyRef.Text, ref sParameterAttr);
            Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("DATA_SUBJECT_DB", dfsDataSubject.Text, ref sParameterAttr);
            Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("OPERATION_DATE", sOperationDate, ref sParameterAttr);
            Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("ACTION", tblUpdateHistory_colsActionDb.Text, ref sParameterAttr);
            Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("IDENTITY", dfsIdentity.Text, ref sParameterAttr);
            Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("NAME", dfsIdentityName.Text, ref sParameterAttr);
            Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("REMARK", dfsRemark.Text, ref sParameterAttr);
            Ifs.Fnd.ApplicationForms.Var.InfoService.ReportExecuteAndPrint(ref nResultKey, sReportAttr, sParameterAttr, Ifs.Fnd.ApplicationForms.Const.strNULL, Ifs.Fnd.ApplicationForms.Int.PalAttrCreate("OUTPUT", "DIALOG"));

            #endregion
        }
        private void commandPrint_Inquire(object sender, FndCommandInquireEventArgs e)
        {
            #region Action
            ((FndCommand)sender).Enabled = true;
            if (nConsentRowSelected < 0) ((FndCommand)sender).Enabled = false;
            if (this.tblUpdateHistory_colsActionDb.Text == "DATA_ERASED") 
                ((FndCommand)sender).Enabled = false;
            #endregion
        }

        #endregion
    }
}