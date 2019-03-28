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
using System.Diagnostics;
using Ifs.Fnd.ApplicationForms;
using PPJ.Runtime;
using PPJ.Runtime.Windows;

namespace Ifs.Application.Enterp
{

    /// <summary>
    /// </summary>
    /// 
    [FndWindowRegistration("PERS_DATA_MAN_PROC_PURPOSE", "PersDataManProcPurpose")]
    public partial class dlgDataProcessingPurpose : cDialog
    {
        #region Member Variables
        protected SalString sPersonalData;
        protected SalNumber nPersDataManagementId;
        protected SalNumber nPurposeId;
        protected SalBoolean bAnyPurposeEdited = SalBoolean.False;
        protected SalBoolean bDbTransactionOk = SalBoolean.False;
        protected SalString sDataSubjectClientValues;
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        protected dlgDataProcessingPurpose()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();
        }

        #endregion

        #region System Methods/Properties

        /// <summary>
        /// Shows the modal dialog.
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        public static SalNumber ModalDialog(Control owner)
        {
            dlgDataProcessingPurpose dlg = DialogFactory.CreateInstance<dlgDataProcessingPurpose>();
            SalNumber ret = dlg.ShowDialog(owner);
            return ret;
        }

        /// <summary>
        /// Shows the modal dialog.
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        public static SalNumber ModalDialog(Control owner, SalNumber nPersDataManagementId, SalString sPersonalData)
        {
            dlgDataProcessingPurpose dlg = DialogFactory.CreateInstance<dlgDataProcessingPurpose>();
            dlg.sPersonalData = sPersonalData;
            dlg.nPersDataManagementId = nPersDataManagementId;
            SalNumber ret = dlg.ShowDialog(owner);
            return ret;
        }
        

        /// <summary>
        /// Returns the object instance associated with the window handle.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public new static dlgDataProcessingPurpose FromHandle(SalWindowHandle handle)
        {
            return ((dlgDataProcessingPurpose)SalWindow.FromHandle(handle, typeof(dlgDataProcessingPurpose)));
        }

        #endregion

        #region Properties

        #endregion

        #region Methods

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber SetWindowTitle()
        {
            #region Actions
            using (new SalContext(this))
            {
                Sal.SetWindowText(i_hWndFrame, Properties.Resources.TEXT_ProcOfPersDataPurp + " - " + sPersonalData);
            }

            return 0;
            #endregion
        }

        protected virtual void BuildDataSubjectEnumeration()
        {
            #region Actions
            sDataSubjectClientValues = SalString.Null;
            if (DbPLSQLBlock("&AO.Data_Subject_API.Enumerate_Pers_Data_Management( :i_hWndFrame.dlgPersonalDataConsent.sDataSubjectClientValues OUT, " +
                " :i_hWndFrame.dlgPersonalDataConsent.nPersDataManagementId IN)"))
            {
                foreach (SalString sValue in sDataSubjectClientValues.Tokenize(Ifs.Fnd.ApplicationForms.Var.g_sCHAR_US, Ifs.Fnd.ApplicationForms.Var.g_sCHAR_US))
                    this.cmbDataSubject.AddListItem(sValue);

                int listItemsCount = cmbDataSubject.GetListItemsCount();
                if (listItemsCount > 0)
                {
                    cmbDataSubject.SelectedIndex = 0; // Selects the first populated Data Subject
                    tblDataProcessPurpose.DataSourcePopulate(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                }
                else
                {
                    Sal.DisableWindow(tblDataProcessPurpose);
                }
                
            }            
            #endregion
        }

        protected virtual SalBoolean AddOrRemovePersDataPurpose(SalBoolean bAnyPurposeEdited)
        {         

            IDictionary<string, string> namedBindVariables = new Dictionary<string, string>();
            namedBindVariables.Add("PurposeId", QualifiedVarBindName("nPurposeId"));
            namedBindVariables.Add("PersDataManagementId", QualifiedVarBindName("nPersDataManagementId"));
            namedBindVariables.Add("DataSubject", cmbDataSubject.QualifiedBindName);
                       
            nPurposeId = tblDataProcessPurpose_colnPurposeId.Number;
            if (tblDataProcessPurpose_colsSelected.Text == "TRUE")
            {                        
                if (DbPLSQLBlock(@"&AO.Pers_Data_Man_Proc_Purpose_API.New_Data_Proc_Purpose({PurposeId} IN, 
                                                                                             {PersDataManagementId} IN,
                                                                                             {DataSubject} IN);", namedBindVariables))
                {
                    bAnyPurposeEdited = SalBoolean.True;
                }
            }
            else if (tblDataProcessPurpose_colsSelected.Text == "FALSE")
            {
                if (DbPLSQLBlock(@"&AO.Pers_Data_Man_Proc_Purpose_API.Remove_Data_Proc_Purpose({PurposeId} IN, 
                                                                                             {PersDataManagementId} IN,
                                                                                             {DataSubject} IN);", namedBindVariables))
                {
                    bAnyPurposeEdited = SalBoolean.True;
                }
            }

            return bAnyPurposeEdited;
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
                if (tblDataProcessPurpose_colsSelected.Text == "TRUE")
                {
                    return true;
                }
            }
            return false;
            #endregion
        }

        #endregion

        #region Overrides

        #endregion

        #region Window Actions

        private void dlgDataProcessingPurpose_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {

                case Sys.SAM_Create:
                    this.dlgDataProcessingPurpose_OnSAM_Create(sender, e);
                    break;

                case Sys.SAM_CreateComplete:
                    this.dlgDataProcessingPurpose_OnSAM_CreateComplete(sender, e);
                    break;
            }
            #endregion

        }

        private void dlgDataProcessingPurpose_OnSAM_CreateComplete(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Sys.SAM_CreateComplete, Sys.wParam, Sys.lParam);
            tblDataProcessPurpose.DataSourcePopulate(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
            if(DbTransactionBegin(ref cSessionManager.c_hSql)) {
                bDbTransactionOk = SalBoolean.True;
            }            
            BuildDataSubjectEnumeration();                        
            #endregion
        }

        private void dlgDataProcessingPurpose_OnSAM_Create(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam);
            this.SetWindowTitle();
            Sal.CenterWindow(this.i_hWndFrame);
            #endregion
        }

        private void cmbDataSubject_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_AnyEdit:
                    e.Handled = true;
                    
                    tblDataProcessPurpose.DataSourcePopulate(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
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
                    this.tblDataProcessPurpose_colsSelected_OnSAM_AnyEdit(sender, e);
                    break;
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.tblDataProcessPurpose_colsSelected_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion

        }

        private void tblDataProcessPurpose_colsSelected_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            e.Handled = true;
            if (cmbDataSubject.IsEmpty())
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
            }
            else
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldEnabled;
            }
        }

        private void tblDataProcessPurpose_colsSelected_OnSAM_AnyEdit(object sender, WindowActionsEventArgs e)
        {
            e.Handled = true;
            if (bDbTransactionOk == SalBoolean.True)
            {
                bAnyPurposeEdited = AddOrRemovePersDataPurpose(bAnyPurposeEdited);
            }

            if (bAnyPurposeEdited)
            {
                Sal.EnableWindow(cCommandButtonOK);
            }
            else
            {
                Sal.DisableWindow(cCommandButtonOK);
            }
        }



        #endregion

        #region Event Handlers

        private void commandOk_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            // Dialog class have AcceptButton set to run this logic if the user ends the dialog using the Return button.
            // PPJ dialog close trough Sal.EndDialog so we set DialogResult to prevent the dialog from closing premature.
            DialogResult = DialogResult.None;
            if (bDbTransactionOk == SalBoolean.True)
            {
                DbTransactionEnd(cSessionManager.c_hSql);
            }
            Sal.EndDialog(this, Sys.IDOK);
        }

        private void commandCancel_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            // Dialog class have CancelButton set to run this logic even if the user close the dialog trough the esc button.
            // PPJ dialog close trough Sal.EndDialog so we set DialogResult to prevent the dialog from closing premature.
            DialogResult = DialogResult.None;
            if (bDbTransactionOk == SalBoolean.True)
            {
                DbTransactionClear(cSessionManager.c_hSql);
            }
            Sal.EndDialog(this, Sys.IDCANCEL);
        }


        #endregion       

        #region Menu Event Handlers

        #endregion
    }
}
