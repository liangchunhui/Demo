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


namespace Ifs.Application.Enterp
{

    /// <summary>
    /// </summary>
    public partial class tbwPersDataProcessPurpose : cTableWindow
    {
        #region Member Variables

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public tbwPersDataProcessPurpose()
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
        public new static tbwPersDataProcessPurpose FromHandle(SalWindowHandle handle)
        {
            return ((tbwPersDataProcessPurpose)SalWindow.FromHandle(handle, typeof(tbwPersDataProcessPurpose)));
        }

        #endregion

        

        #region Properties

        #endregion

        #region Methods

        #endregion

        #region Overrides

        #endregion

        #region Window Actions

        #endregion

        #region Event Handlers

        #endregion

        #region Menu Event Handlers
        private void cmdDataProcessingPersonalData_Inquire(object sender, Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            #region Local Variables
            SalNumber nRow = 0;
            #endregion

            #region Action
            if (!(Sal.TblAnyRows(this, Sys.ROW_Selected, 0)))
            {
                ((FndCommand)sender).Enabled = SalBoolean.False;
                return;
            }

            nRow = Sys.TBL_MinRow;
            if (Sal.TblFindNextRow(this, ref nRow, Sys.ROW_Selected, 0))
            {
                if (Sal.TblFindNextRow(this, ref nRow, Sys.ROW_Selected, 0))
                {
                    ((FndCommand)sender).Enabled = SalBoolean.False;
                    return;
                }
                else
                {
                    ((FndCommand)sender).Enabled = Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Pers_Data_Man_Proc_Purpose_Api.New_Data_Proc_Purpose");
                }
            }
            #endregion

        }

        private void cmdDataProcessingPersonalData_Execute(object sender, Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            #region Action

            if (dlgDataProcessingPersonalData.ModalDialog(this, this.colnPurposeId.Number, this.colsPurposeName.Text) == Sys.IDOK)
            {
                Sal.SendMsg(i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceRefresh, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                return;
            }
            #endregion

        }
        #endregion
    }
}
