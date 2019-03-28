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
using Ifs.Fnd.Windows.Forms;

namespace Ifs.Application.Enterp_Cust
{

    /// <summary>
    /// </summary>
    public partial class tbwLchEmployee : cTableWindow
    {
        #region Member Variables
        SalString sEmployeeID;
        SalString sOldpassword;
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public tbwLchEmployee()
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
        public new static tbwLchEmployee FromHandle(SalWindowHandle handle)
        {
            return ((tbwLchEmployee)SalWindow.FromHandle(handle, typeof(tbwLchEmployee)));
        }

        #endregion

        #region RMB Methods
        private void cmdChangePassword_Execute(object sender, FndCommandExecuteEventArgs e)
        {
            #region Actions
            using (new SalContext(this))
            {
                this.sEmployeeID = colsEmployeeId.Text;
                this.sOldpassword = colsLoginPassword.Text;

                if (dlgLchChangePassword.ModalDialog(Sys.hWndForm, ref this.sEmployeeID, ref this.sOldpassword) == Sys.IDOK)
                {
                    Sal.SendMsg(i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceRefresh, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                    return;
                }
                return;
            }
            #endregion
        }

        private void cmdChangePassword_Inquire(object sender, FndCommandInquireEventArgs e)
        {
            #region Local Variables
            SalNumber nRow = 0;
            #endregion

            #region Actions
            if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("dlgLchChangePassword"))))
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
            }
            ((FndCommand)sender).Enabled = true;
            
            #endregion
        }
        #endregion


        private void coldBirthday_OnAM_FieldEdit(object sender, WindowActionsEventArgs e)
        {
            #region Actions  
            e.Handled = true;
            if (!Sal.IsNull(coldBirthday))
            {
                DbPLSQLBlock(cSessionManager.c_hSql, "SELECT TRUNC(Months_between(sysdate, to_date('" + coldBirthday.Text + "','yyyy-mm-dd'))/12) INTO :i_hWndFrame.colnAge FROM DUAL");
                this.colnAge.EditDataItemSetEdited();
                this.colnAge.Enabled = false;
            }
            else
            {
                this.colnAge.Clear();
            }
            #endregion
        }

        private void tableWindow_coldBirthday_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_FieldEdit:
                    this.coldBirthday_OnAM_FieldEdit(sender, e);
                    break;
            }
            #endregion
        }
    }
}
