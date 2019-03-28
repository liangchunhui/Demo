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

namespace Ifs.Application.Enterp_Cust
{

    /// <summary>
    /// </summary>
    public partial class dlgLchChangePassword : cDialog
    {
        #region Member Variables
        SalString sEmployeeID;
        SalString sOldpassword;
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        protected dlgLchChangePassword()
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
        public static SalNumber ModalDialog(Control owner, ref SalString sEmployeeID, ref SalString sOldpassword)
        {
            dlgLchChangePassword dlg = DialogFactory.CreateInstance<dlgLchChangePassword>();
            dlg.sEmployeeID = sEmployeeID;
            dlg.sOldpassword = sOldpassword;
            dlg.sID.Text = dlg.sEmployeeID;
            SalNumber ret = dlg.ShowDialog(owner);
            return ret;
        }

        /// <summary>
        /// Returns the object instance associated with the window handle.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public new static dlgLchChangePassword FromHandle(SalWindowHandle handle)
        {
            return ((dlgLchChangePassword)SalWindow.FromHandle(handle, typeof(dlgLchChangePassword)));
        }

        #endregion

        #region Methods
        public new SalNumber UserMethod(SalNumber nWhat, SalString sMethod)
        {
            #region Actions
            using (new SalContext(this))
            {
                if (sMethod == "ok")
                {
                    switch (nWhat)
                    {
                        case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                            return 1;

                        case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                            if (!(CheckPassword()))
                            {
                                
                                return 0;
                            }
                            else
                            {
                                SavePassword();
                                return Sal.EndDialog(this, Sys.IDOK);
                            }
                    }
                }
                else if (sMethod == "cancel")
                {
                    switch (nWhat)
                    {
                        case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                            return 1;

                        case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                            Sal.EndDialog(this, Sys.IDCANCEL);
                            break;
                    }
                }
            }

            return 0;
            #endregion
        }

        public virtual SalBoolean CheckPassword()
        {
            #region Actions
            using (new SalContext(this))
            {
                if (sOldPasswordInput.Text != sOldpassword)
                {
                    this.sOldPasswordInput.Focus();
                    Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_PasswordNotSame, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.WARNING_Ok);
                    return false;
                }
                else if(Sal.IsNull(this.sNewPassword))
                {
                    this.sNewPassword.Focus(); 
                    Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_PasswordMustInput, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.WARNING_Ok);
                    return false;
                }
                else
                {
                    return true;
                }
            }
            #endregion
        }

        public virtual SalBoolean SavePassword()
        {
            using (new SalContext(this))
            {
                SalString stmt = "&AO.Lch_Employee_API.ChangePassword(:i_hWndFrame.sEmployeeID,:i_hWndFrame.sNewPassword.Text.Trim())";
                return DbPLSQLBlock(cSessionManager.c_hSql, stmt); 
            }
        }
        #endregion

        public override SalNumber vrtUserMethod(SalNumber nWhat, SalString sMethod)
        {
            return this.UserMethod(nWhat, sMethod);
        }
    }
}
