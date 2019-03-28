#region Copyright (c) IFS Research & Development
// ======================================================================================================
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
// ======================================================================================================
#endregion
#region History
// Date   By      Notes
// ----   -----   ---------------------------------------------------
// 120419 Chgulk  EASTRTM-6962, Merged LCS patch 101624.
// 140728 Kagalk  PRFI-1290, Merged Bug 117813, Enable to validate association no when using object copy/paste.
// 140812 Kagalk  PRFI-1491, Merged Bug 118101, Enable to validate association no when using object copy/paste.
// 150602 RoJalk  ORA-499, Changed the main WindowRegistration entry to the view SUPPLIER_INFO_GENERAL.
// 150707 RoJalk  ORA-776, Added the RMB to Change Supplier Category. 
// 150811 RoJalk  ORA-1181, Added the method DummyProcedureCalls.
// 150908 SudJlk  AFT-3014, Modified DataSourceValidate to remove unnecessary return, so that validation for mandatory fields is not fired twice.
#endregion

using System.Windows.Forms;
using Ifs.Fnd.ApplicationForms;
using Ifs.Fnd.Windows.Forms;
using PPJ.Runtime;
using PPJ.Runtime.Sql;
using PPJ.Runtime.Windows;
using System.Collections.Generic;

namespace Ifs.Application.Enterp
{
	
	/// <summary>
	/// </summary>
    [FndWindowRegistration("SUPPLIER_INFO_GENERAL", "SupplierInfoGeneral")]
    public partial class tbwSupplierInfoOverview : cTableWindowEntBase
    {
        #region Window Variables
        public SalString sFullFormName = "";
        public SalBoolean bAssociationNoEdited = false;
        public SalString sProspectClient = "";
        public SalString sDataSubjectKeyRef = "";
        public SalString sDataSubjectEnable = "FALSE";
        public static SalString sDataSubjectDb = "SUPPLIER";
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public tbwSupplierInfoOverview()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();
        }
        #endregion

        #region System Methods/Properties

        /// <summary>
        /// Returns the object instance associated with the window handle.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public new static tbwSupplierInfoOverview FromHandle(SalWindowHandle handle)
        {
            return ((tbwSupplierInfoOverview)SalWindow.FromHandle(handle, typeof(tbwSupplierInfoOverview)));
        }
        #endregion

        #region Methods

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean CheckAssociationNumber()
        {
            #region Actions
            using (new SalContext(this))
            {
                Sal.WaitCursor(true);
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("Association_Info_API.Association_No_Exist", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                    DbPLSQLBlock(cSessionManager.c_hSql, sFullFormName + ".colsExist :=\r\n" +
                        "                                 &AO.Association_Info_API.Association_No_Exist( " + sFullFormName + ".colsAssociationNo, 'SUPPLIER' )");
                }
                Sal.WaitCursor(false);
                if (colsExist.Text == "TRUE")
                {
                    if (Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_WarnSameAssocNo, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Warning, Ifs.Fnd.ApplicationForms.Const.WARNING_OkCancel) == Sys.IDCANCEL)
                    {
                        return false;
                    }
                }
                return true;
            }
            #endregion
        }

        public virtual SalNumber GetIIDValues()
        {
            #region Actions
            IDictionary<string, string> vars = new Dictionary<string, string>();
            vars.Add("ProspectClient", QualifiedVarBindName("sProspectClient"));
            DbPLSQLBlock(@"{ProspectClient} := &AO.Supplier_Info_Category_API.Decode('PROSPECT')", vars);
            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public new SalBoolean FrameStartupUser()
        {
            #region Actions
            using (new SalContext(this))
            {
                Sal.SetWindowText(i_hWndFrame, Properties.Resources.HEAD_OverviewSupplierInfo);
                return ((cDataSource)this).FrameStartupUser();
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <param name="sMethod"></param>
        /// <returns></returns>
        public new SalNumber UserMethod(SalNumber nWhat, SalString sMethod)
        {
            #region Actions
            using (new SalContext(this))
            {
                if (sMethod == "mnuDetail")
                {
                    switch (nWhat)
                    {
                        case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                            return Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("frmSupplierInfo"));

                        case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                            DataSourcePrepareKeyTransfer(Pal.GetActiveInstanceName("frmSupplierInfo"));
                            SessionCreateWindow(Pal.GetActiveInstanceName("frmSupplierInfo"), Sys.hWndMDI);
                            break;
                    }
                }
                else
                {
                    return false;
                }
            }

            return 0;
            #endregion
        }
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber CountryChanged()
        {
            #region Actions
            using (new SalContext(this))
            {
                if (colsCorporateForm.Text != Sys.STRING_Null)
                {
                    Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_FormOfBusinessSupplier, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Warning, Ifs.Fnd.ApplicationForms.Const.WARNING_Ok);
                    colsCorporateForm.Text = Sys.STRING_Null;
                    colsCorporateForm.EditDataItemSetEdited();
                }
                colsOldCountry.Text = colsCountry.Text;
            }

            return 0;
            #endregion
        }
        public new SalBoolean DataSourceValidate()
        {
            if (this.colsAssociationNo.Text != Sys.STRING_Null)
            {
                Sal.SetFocus(this.colsAssociationNo);
                if (!(Sal.SendMsg(this.colsAssociationNo, Sys.SAM_Validate, Sys.wParam, Sys.lParam)))
                {
                    return false;
                }
            }
            return base.DataSourceValidate();
        }

        protected virtual void DummyProcedureCalls()
        {
            //Added this dummy call to make the method granted by default when granting this form
            DbPLSQLBlock(@"&AO.SUPPLIER_INFO_API.Create_Supplier__();");
        }

        public virtual void HandleDataSubjectConsentColumns()
        {
            #region Actions
            DbPLSQLBlock(@"{0} := &AO.Data_Subject_API.Get_Personal_Data_Managemen_Db({1});", this.QualifiedVarBindName("sDataSubjectEnable"), this.QualifiedVarBindName("sDataSubjectDb"));
            if (sDataSubjectEnable == "TRUE")
            {
                colValidDataProcessingPurpose.Visible = true;
                cmdManageDataProcessingPurposes.Visible = true;
            }
            else
            {
                colValidDataProcessingPurpose.Visible = false;
                cmdManageDataProcessingPurposes.Visible = false;
            }
            #endregion
        }
        #endregion

        #region Window Actions

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tbwSupplierInfoOverview_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_Create:
                    this.tbwSupplierInfoOverview_OnSAM_Create(sender, e);
                    break;

                case Sys.SAM_FetchRowDone:
                    this.tbwSupplierInfoOverview_OnSAM_FetchRowDone(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate:
                    this.tbwSupplierInfoOverview_OnPM_DataRecordDuplicate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordPaste:
                    this.tbwSupplierInfoOverview_OnPM_DataRecordPaste(sender, e);
                    break;

            }
            #endregion
        }

        /// <summary>
        /// SAM_Create event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwSupplierInfoOverview_OnSAM_Create(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam);
            this.sFullFormName = ":i_hWndFrame." + Ifs.Fnd.ApplicationForms.Int.QualifiedItemNameGet(this);
            GetIIDValues();
            #endregion
        }

        /// <summary>
        /// SAM_FetchRowDone event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwSupplierInfoOverview_OnSAM_FetchRowDone(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.colsOldCountry.Text = this.colsCountry.Text;
            Sal.SendClassMessage(Sys.SAM_FetchRowDone, Sys.wParam, Sys.lParam);
            #endregion
        }

        private void tbwSupplierInfoOverview_OnPM_DataRecordDuplicate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate, Sys.wParam, Sys.lParam))
            {
                if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                {
                    if (this.colsAssociationNo.Text != Sys.STRING_Null)
                    {
                        Sal.SetFocus(this.colsAssociationNo);
                        e.Return = Sal.SendMsg(this.colsAssociationNo, Sys.SAM_Validate, Sys.wParam, Sys.lParam);
                        return;                                  
                    }
                }
                e.Return = true;
                return;
            }
            e.Return = false;
            return;
            #endregion
        }


        private void tbwSupplierInfoOverview_OnPM_DataRecordPaste(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordPaste, Sys.wParam, Sys.lParam))
            {
                if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                {
                    if (this.colsAssociationNo.Text != Sys.STRING_Null)
                    {
                        Sal.SetFocus(this.colsAssociationNo);
                        e.Return = Sal.SendMsg(this.colsAssociationNo, Sys.SAM_Validate, Sys.wParam, Sys.lParam);
                        return;
                    }
                }
                e.Return = true;
                return;
            }
            e.Return = false;
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colsAssociationNo_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_Validate:
                    this.colsAssociationNo_OnSAM_Validate(sender, e);
                    break;

                case Sys.SAM_AnyEdit:
                    this.colsAssociationNo_OnSAM_AnyEdit(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_Validate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colsAssociationNo_OnSAM_Validate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.bAssociationNoEdited)
            {
                if (this.CheckAssociationNumber())
                {
                    this.bAssociationNoEdited = false;
                    e.Return = Sys.VALIDATE_Ok;
                    return;
                }
                else
                {
                    e.Return = Sys.VALIDATE_Cancel;
                    return;
                }
            }
            e.Return = Sys.VALIDATE_Ok;
            return;
            #endregion
        }

        /// <summary>
        /// SAM_AnyEdit event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colsAssociationNo_OnSAM_AnyEdit(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.bAssociationNoEdited = true;
            e.Return = Sal.SendClassMessage(Sys.SAM_AnyEdit, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }    
        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void colsCountry_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {

                case Sys.SAM_AnyEdit:
                    this.colsCountry_OnSAM_AnyEdit(sender, e);
                    break;



                case Sys.SAM_DropDown:
                    e.Handled = true;
                    this.colsCountry.LookupInit();
                    break;

            }
            #endregion
        }

        /// <summary>
        /// SAM_AnyEdit event handler.
        /// </summary>
        /// <param name="message"></param>
        private void colsCountry_OnSAM_AnyEdit(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Sys.SAM_AnyEdit, Sys.wParam, Sys.lParam))
            {
                if (this.colsOldCountry.Text != this.colsCountry.Text)
                {
                    this.CountryChanged();
                }
            }
            #endregion
        }
        #endregion

        #region Late Bind Methods

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalBoolean vrtFrameStartupUser()
        {
            return this.FrameStartupUser();
        }

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalNumber vrtUserMethod(SalNumber nWhat, SalString sMethod)
        {
            return this.UserMethod(nWhat, sMethod);
        }
        public override SalBoolean vrtDataSourceValidate()
        {
            return this.DataSourceValidate();
        }
        public override SalNumber vrtActivate(fcURL URL)
        {
            #region Actions
            HandleDataSubjectConsentColumns();
            return base.vrtActivate(URL);
            #endregion
        }
        #endregion

        #region Event Handlers

        private void menuItem__Details_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            // TODO: Rewrite command event handler not to use UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            ((FndCommand)sender).Enabled = Sal.SendMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, ((SalString)"mnuDetail").ToHandle());
        }

        private void menuItem__Details_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            // TODO: Rewrite command event handler not to make use of UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            Ifs.Fnd.ApplicationForms.Int.PostMessage(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, "mnuDetail");
        }

        private void menuItem__Chg_Supp_Category_Inquire(object sender, FndCommandInquireEventArgs e)
        {
            #region Local Variables
            SalNumber nRow = 0;
            #endregion

            #region Action
            if (Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0))
            {
                ((FndCommand)sender).Enabled = false;
                return;
            }
            if (!(Sal.TblAnyRows(this, Sys.ROW_Selected, 0)))
            {
                ((FndCommand)sender).Enabled = false;
                return;
            }
            nRow = Sys.TBL_MinRow;
            if (Sal.TblFindNextRow(this, ref nRow, Sys.ROW_Selected, 0))
            {
                if (Sal.TblFindNextRow(this, ref nRow, Sys.ROW_Selected, 0))
                {
                    ((FndCommand)sender).Enabled = false;
                    return;
                }
                else
                {
                    ((FndCommand)sender).Enabled = ((!(Sal.IsNull(colsSupplierId))) && (colsSupplierCategory.Text == sProspectClient));
                }
            }
            #endregion
        }

        private void menuItem__Chg_Supp_Category_Execute(object sender, FndCommandExecuteEventArgs e)
        {
            if (dlgChangeSupplierCategory.ModalDialog(Ifs.Fnd.ApplicationForms.Int.Explorer.ExplorerForm, colsSupplierId.Text, colsName.Text, colsAssociationNo.Text) == Sys.IDOK)
            {
                Sal.PostMsg(i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceRefresh, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
            }     
        }

        private void cmdManageDataProcessingPurposes_Inquire(object sender, FndCommandInquireEventArgs e)
        {
            #region Local Variable
            SalNumber nRow = Sys.TBL_MinRow;
            #endregion

            #region Action
            if (!(Sal.TblAnyRows(this, Sys.ROW_Selected, 0)))
            {
                ((FndCommand)sender).Enabled = false;
                return;
            }
            nRow = Sys.TBL_MinRow;
            if (Sal.TblFindNextRow(this, ref nRow, Sys.ROW_Selected, 0))
            {
                if (Sal.TblFindNextRow(this, ref nRow, Sys.ROW_Selected, 0))
                {
                    ((FndCommand)sender).Enabled = false;
                    return;
                }
            }
            if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Data_Subject_Consent_Oper_API.Consent_Action")) || sDataSubjectEnable == "FALSE")
            {
                ((FndCommand)sender).Enabled = false;
                return;
            }
            ((FndCommand)sender).Enabled = true;
            #endregion
        }

        private void cmdManageDataProcessingPurposes_Execute(object sender, FndCommandExecuteEventArgs e)
        {
            #region Action
            DbPLSQLBlock(@"{0} := &AO.Data_Subject_Consent_API.Get_Subject_Key_Ref({1} IN, {2} IN, NULL);", this.QualifiedVarBindName("sDataSubjectKeyRef"), this.QualifiedVarBindName("sDataSubjectDb"), this.colsSupplierId.QualifiedBindName);
            if (dlgPersonalDataConsent.ModalDialog(this, this.sDataSubjectKeyRef, sDataSubjectDb, colsName.Text) == Sys.IDOK)
            {
                Sal.SendMsg(i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceRefresh, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                return;
            }
            #endregion
        }
        #endregion



    }
}
