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
using PPJ.Runtime.Sql;
using Ifs.Fnd.Windows.Forms;

namespace Ifs.Application.Enterp
{

    /// <summary>
    /// Default window for connection of B2B Users to Customers
    /// </summary>
    [FndWindowRegistration("B2B_CUSTOMER_USER", "B2bCustomerUser", FndWindowRegistrationFlags.HomePage)]
    public partial class tbwB2BCustomerUser : cTableWindow
    {
        #region Member Variables

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public tbwB2BCustomerUser()
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
        [DebuggerStepThrough]
        public new static tbwB2BCustomerUser FromHandle(SalWindowHandle handle)
        {
            return ((tbwB2BCustomerUser)SalWindow.FromHandle(handle, typeof(tbwB2BCustomerUser)));
        }

        #endregion

        #region Properties

        #endregion

        #region Methods



        /// <summary>
        /// Returns TRUE if one and only one record is selected, FALSE otherwise
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean SingleRecordSelected()
        {
            #region Local Variables
            SalNumber nIndex = 0;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                if (!(Sal.TblAnyRows(i_hWndSelf, Sys.ROW_Selected, 0)))
                {
                    return false;
                }
                nIndex = Sys.TBL_MinRow;
                if (Sal.TblFindNextRow(i_hWndSelf, ref nIndex, Sys.ROW_Selected, 0))
                {
                    if (Sal.TblFindNextRow(i_hWndSelf, ref nIndex, Sys.ROW_Selected, 0))
                    {
                        return false;
                    }
                }
                return true;
            }
            #endregion
        }


        #endregion

        #region Overrides
        #endregion

        #region Late Bind Methods
        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        #endregion

        #region Window Actions
        private void tableWindow_colsCustomerId_WindowActions(object sender, WindowActionsEventArgs e)
        {
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovUserWhere:
                    e.Handled = true;
                    e.Return = Sal.HStringToNumber("B2B_CUSTOMER_DB = 'TRUE'");
                    return;
            }

        }
        #endregion

        #region Event Handlers

        #endregion

        #region Menu Event Handlers
        private void cmdSetDefault_Execute(object sender, FndCommandExecuteEventArgs e)
        {
            SalBoolean bOk = false;
            using (new SalContext(this))
            {
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("B2B_Customer_User_API.Set_Default__", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                    bOk = DbPLSQLTransaction(cSessionManager.c_hSql, "&AO.B2B_Customer_User_API.Set_Default__( :i_hWndFrame.tbwB2BCustomerUser.colsCustomerId, :i_hWndFrame.tbwB2BCustomerUser.colsUserId)");
                }
                if (bOk)
                {
                    Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceRefresh, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                }
            }
        }

        private void cmdSetDefault_Inquire(object sender, FndCommandInquireEventArgs e)
        {
            #region Local Variables
            SalBoolean bOk = false;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                bOk = Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("B2B_Customer_User_API.Set_Default__");
                bOk = bOk && SingleRecordSelected();
                bOk = bOk && (!(Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceIsDirty, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0)));
                bOk = bOk && (colsDefaultCustomer.Text == "FALSE");
                ((FndCommand)sender).Enabled = bOk;
            }
            #endregion
        }
        #endregion
    }
}
