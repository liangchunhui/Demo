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
#endregion

using System.Windows.Forms;
using Ifs.Fnd.ApplicationForms;
using PPJ.Runtime;
using PPJ.Runtime.Sql;
using PPJ.Runtime.Windows;

namespace Ifs.Application.Enterp
{

    /// <summary>
    /// </summary>
    /// <param name="p_sTaxIdType"></param>
    public partial class dlgLayoutFormat : cDialogBox
    {
        #region Window Parameters

        protected string taxIdType;
        protected string layoutFormat;

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        protected dlgLayoutFormat()
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
        public static SalNumber ModalDialog(Control owner, SalString sTaxIdType, SalString sLayoutFormat)
        {
            dlgLayoutFormat dlg = DialogFactory.CreateInstance<dlgLayoutFormat>();
            dlg.taxIdType = sTaxIdType;
            dlg.layoutFormat = sLayoutFormat;
            SalNumber ret = dlg.ShowDialog(owner);
            return ret;
        }

        /// <summary>
        /// Returns the object instance associated with the window handle.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public new static dlgLayoutFormat FromHandle(SalWindowHandle handle)
        {
            return ((dlgLayoutFormat)SalWindow.FromHandle(handle, typeof(dlgLayoutFormat)));
        }
        #endregion

        #region Methods

        /// <summary>
        /// </summary>
        public virtual void SetWindowTitle()
        {
            this.Text = Properties.Resources.WH_dlgLayoutFormat;
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
                if (sMethod == "OK")
                {
                    return UM_Ok(nWhat);
                }
                else if (sMethod == "Cancel")
                {
                    return UM_Cancel(nWhat);
                }
                return false;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalBoolean UM_Ok(SalNumber nWhat)
        {
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        return true;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        using (SignatureHints hints = SignatureHints.NewContext())
                        {
                            hints.Add("Tax_Id_Type_API.Update_Layout__", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                            SalBoolean bRes = DbPLSQLTransaction(cSessionManager.c_hSql, "&AO.Tax_Id_Type_API.Update_Layout__(\r\n" +
                                "					:i_hWndFrame.dlgLayoutFormat.dfsTaxIdType,\r\n" +
                                "					:i_hWndFrame.dlgLayoutFormat.dfsLayoutFormat)");
                        }
                        Sal.EndDialog(this, Ifs.Fnd.ApplicationForms.Var.bReturn);
                        Sal.SendMsg(i_hWndParent, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceRefresh, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                        return true;
                }
            }

            return false;
        }

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalBoolean UM_Cancel(SalNumber nWhat)
        {
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        return true;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        Sal.EndDialog(this, Ifs.Fnd.ApplicationForms.Var.bReturn);
                        return true;
                }
            }

            return false;
        }

        #endregion

        #region Window Actions

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void dlgLayoutFormat_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_CreateComplete:
                    this.dlgLayoutFormat_OnSAM_CreateComplete(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_CreateComplete event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dlgLayoutFormat_OnSAM_CreateComplete(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Sys.SAM_CreateComplete, Sys.wParam, Sys.lParam);
            this.SetWindowTitle();

            this.dfsTaxIdType.Text = taxIdType;
            this.dfsTaxIdType.EditDataItemStateSet(Ifs.Fnd.ApplicationForms.Const.EDIT_Changed);
            this.dfsLayoutFormat.Text = layoutFormat;
            this.dfsLayoutFormat.EditDataItemStateSet(Ifs.Fnd.ApplicationForms.Const.EDIT_Changed);
            #endregion
        }
        #endregion

        #region Late Bind Methods

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalNumber vrtUserMethod(SalNumber nWhat, SalString sMethod)
        {
            return this.UserMethod(nWhat, sMethod);
        }
        #endregion
    }
}
