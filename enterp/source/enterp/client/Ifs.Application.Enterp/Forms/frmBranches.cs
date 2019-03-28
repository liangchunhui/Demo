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
// Date     By      Notes
// -----    ------  ---------------------------------------------------------
// 131114  Pratlk  PBFI-2518, Refactor client windows in component ENTERP
#endregion

using System.Windows.Forms;
using Ifs.Fnd.ApplicationForms;
using Ifs.Fnd.Windows.Forms;
using PPJ.Runtime;
using PPJ.Runtime.Windows;
using PPJ.Runtime.Vis;

namespace Ifs.Application.Enterp
{
	
	/// <summary>
	/// </summary>
    [FndWindowRegistration("BRANCH", "Branch", FndWindowRegistrationFlags.HomePage)]
    [FndWindowRegistration("COMPANY", "Company")]
    public partial class frmBranches : cFormWindow
    {
        #region Local Variables
        public SalString sBranchSelection = "";
        protected SalArray<SalString> sItemNames = new SalArray<SalString>();
        protected SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public frmBranches()
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
        public new static frmBranches FromHandle(SalWindowHandle handle)
        {
            return ((frmBranches)SalWindow.FromHandle(handle, typeof(frmBranches)));
        }
        #endregion

        #region Methods
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override SalNumber vrtActivate(fcURL URL)
        {
            using (new SalContext(this))
            {
                SetWindowTitle();
                if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.RecCountGet() > 0)
                {
                    Sal.WaitCursor(true);
                    if (InitFromTransferredData()) //local definition called
                    {
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
                    }
                    cmbsCompany.RecordSelectionListSetSelect(0);
                    Sal.SendMsgToChildren(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                    Sal.WaitCursor(false);
                    return false;
                }
            }
            return base.Activate(URL);
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual new SalBoolean InitFromTransferredData()
        {
            #region Local Variables
            SalArray<SalString> sSqlColumn = new SalArray<SalString>();
            SalString lsWhereStmt = "";
            SalNumber nRows = 0;
            SalNumber nColumns = 0;
            SalString sDelim = "";
            SalString sCompanyId = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                nColumns = Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemNamesGet(sSqlColumn);
                nRows = Ifs.Fnd.ApplicationForms.Var.DataTransfer.RecCountGet();
                if ((nRows == 1) && (nColumns == 2) && (Vis.ArrayFindString(sSqlColumn, "COMPANY") >= 0) && (Vis.ArrayFindString(sSqlColumn, "BRANCH") >= 0))
                {
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemValueStrGet(Vis.ArrayFindString(sSqlColumn, "COMPANY"), 0, ref sCompanyId);
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemValueStrGet(Vis.ArrayFindString(sSqlColumn, "BRANCH"), 0, ref sBranchSelection);
                    sDelim = "";
                    lsWhereStmt = "COMPANY = ";
                    lsWhereStmt = lsWhereStmt + sDelim + "'" + sCompanyId + "'";
                    Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceUserWhere, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, lsWhereStmt.ToHandle());
                    Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                    return true;
                }
                return ((cFormWindow)this).InitFromTransferredData();
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber SetWindowTitle()
        {
            #region Actions
            using (new SalContext(this))
            {
                Sal.SetWindowText(i_hWndFrame, Properties.Resources.WH_frmBranches);
            }

            return 0;
            #endregion
        }
        #endregion

        #region ChildTable - tblBranches

            #region Methods

            /// <summary>
            /// </summary>
            /// <returns></returns>
            public virtual SalNumber SetBranchSelection()
            {
                #region Local Variables
                SalString sDelim = "";
                SalString lsWhereStmt = "";
                #endregion

                #region Actions
                using (new SalContext(tblBranches))
                {
                    sDelim = "";
                    lsWhereStmt = "BRANCH = " + sDelim + "'" + sBranchSelection + "'";
                    Sal.SendMsg(tblBranches, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceUserWhere, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, lsWhereStmt.ToHandle());
                    sBranchSelection = Ifs.Fnd.ApplicationForms.Const.strNULL;
                }

                return 0;
                #endregion
            }

            /// <summary>
            /// </summary>
            /// <param name="nWhat"></param>
            /// <param name="sMethod"></param>
            /// <returns></returns>
            public virtual SalNumber UserMethod(SalNumber nWhat, SalString sMethod)
            {
                #region Actions
                using (new SalContext(this))
                {
                    switch (nWhat)
                    {
                        case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                            if (sMethod == "DelivNoteNumberSeries")
                            {
                                if (Ifs.Fnd.ApplicationForms.Var.Component.IsWindowAvailable(Pal.GetActiveInstanceName("frmDelivNoteNumberSeries")) && Ifs.Fnd.ApplicationForms.Var.Security.IsPresObjectAvailable(Pal.GetActiveInstanceName("frmDelivNoteNumberSeries")))
                                {
                                    return Sal.TblAnyRows(tblBranches, Sys.ROW_Selected, 0);
                                }
                                else
                                {
                                    return 0;
                                }
                            }
                            goto case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute;

                        case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                            if (sMethod == "DelivNoteNumberSeries")
                            {
                                Sal.SendMsg(tblBranches, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceCreateWindow, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ((SalString)Pal.GetActiveInstanceName("frmDelivNoteNumberSeries")).ToHandle());
                                return 1;
                            }
                            else
                            {
                                return 0;
                            }
                            break;
                    }
                }

                return 0;
                #endregion
            }
            #endregion

            #region Event Handlers

            private void tblBranches_UserMethodEvent(object sender, cMethodManager.UserMethodEventArgs e)
            {
                e.Handled = true;
                e.ReturnValue = UserMethod(e.nWhat, e.sMethod);
            }

            #endregion

        #endregion

        #region Window Actions

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblBranches_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate:
                    this.tblBranches_OnPM_DataSourcePopulate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataSourcePopulate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblBranches_OnPM_DataSourcePopulate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.sBranchSelection != Ifs.Fnd.ApplicationForms.Const.strNULL && Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                this.SetBranchSelection();
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        private void tblBranches_colsCompanyAddressId_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom:
                    this.tblBranches_colsCompanyAddressId_OnPM_DataItemZoom(sender, e);
                    break;
            }
            #endregion
        }

        private void tblBranches_colsCompanyAddressId_OnPM_DataItemZoom(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                this.sItemNames[0] = "COMPANY";
                this.hWndItems[0] = this.tblBranches_colsCompany;
                this.sItemNames[1] = "ADDRESS_ID";
                this.hWndItems[1] = this.tblBranches_colsCompanyAddressId;
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("COMPANY", this.tblBranches, this.sItemNames, this.hWndItems);
                SessionNavigate(Pal.GetActiveInstanceName("frmCompany"));
                e.Return = true;
                return;
            }
            else
            {
                e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom, Sys.wParam, Sys.lParam);
                return;
            }
            #endregion
        }
        #endregion

        #region Late Bind Methods
        #endregion

        #region Event Handlers

        private void menuItem__Delivery_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            // TODO: Rewrite command event handler not to use UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            ((FndCommand)sender).Enabled = Sal.SendMsg(tblBranches, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, ((SalString)"DelivNoteNumberSeries").ToHandle());
        }

        private void menuItem__Delivery_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            // TODO: Rewrite command event handler not to make use of UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            Ifs.Fnd.ApplicationForms.Int.PostMessage(tblBranches, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, "DelivNoteNumberSeries");
        }

        #endregion

    }
}
