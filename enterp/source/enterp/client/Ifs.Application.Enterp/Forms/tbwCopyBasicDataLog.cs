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
    [FndWindowRegistration("COPY_BASIC_DATA_LOG", "CopyBasicDataLog", FndWindowRegistrationFlags.HomePage)]
    public partial class tbwCopyBasicDataLog : cTableWindowEntBase
    {
        #region Member Variables
        public SalArray<SalString> sItemValues = new SalArray<SalString>();
        public SalNumber nLogId;
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public tbwCopyBasicDataLog()
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
        public new static tbwCopyBasicDataLog FromHandle(SalWindowHandle handle)
        {
            return ((tbwCopyBasicDataLog)SalWindow.FromHandle(handle, typeof(tbwCopyBasicDataLog)));
        }

        #endregion

        #region Properties

        #endregion

        #region Methods

        public virtual SalBoolean Details(SalNumber nWhat)
        {
            #region Local Variables
            SalNumber nRow = 0;
            SalArray<SalString> sItemNames = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        nRow = Sys.TBL_MinRow;
                        if (Sal.TblFindNextRow(i_hWndFrame, ref nRow, Sys.ROW_Selected, 0))
                        {
                            if (Sal.TblFindNextRow(i_hWndFrame, ref nRow, Sys.ROW_Selected, 0))
                            {
                                return false;
                            }
                            else
                            {
                                return true;
                            }
                        }
                        return false;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        Sal.WaitCursor(true);
                        sItemNames[0] = "LOG_ID";
                        hWndItems[0] = colnLogId;
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init(Pal.GetActiveInstanceName("tbwCopyBasicDataLog"), i_hWndFrame, sItemNames, hWndItems);
                        SessionCreateWindow(Pal.GetActiveInstanceName("frmCopyBasicDataLogDetail"), Sys.hWndMDI);
                        Sal.WaitCursor(false);
                        break;
                }
            }

            return false;
            #endregion
        }

        #endregion

        #region Overrides
        public override SalNumber vrtActivate(fcURL URL)
        {
                if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.RecCountGet() > 0)
                {
                    Sal.WaitCursor(true);
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("LOG_ID", sItemValues);
                    nLogId = sItemValues[0].ToNumber();
                    DataSourceUserWhere(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ((SalString)"LOG_ID = (:i_hWndFrame.tbwCopyBasicDataLog.nLogId) ").ToHandle());
                    Sal.SendMsg(i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute,Sys.lParam);      
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
                }
                
            return base.Activate(URL);
        }

        #endregion

        #region Window Actions

        #endregion

        #region Event Handlers

        #endregion

        #region Menu Event Handlers

        private void menuTbwMethods_menu_Details____Execute(object sender, Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            Details(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void menuTbwMethods_menu_Details____Inquire(object sender, Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = Details(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        #endregion
    }
}
