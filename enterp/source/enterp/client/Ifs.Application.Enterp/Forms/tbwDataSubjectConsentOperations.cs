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
    /// 
    [FndWindowRegistration("DATA_SUB_CONSENT_OPERATIONS", "DataSubjectConsentOper")]
    public partial class tbwDataSubjectConsentOperations : cTableWindow
    {
        #region Member Variables

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public tbwDataSubjectConsentOperations()
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
        public new static tbwDataSubjectConsentOperations FromHandle(SalWindowHandle handle)
        {
            return ((tbwDataSubjectConsentOperations)SalWindow.FromHandle(handle, typeof(tbwDataSubjectConsentOperations)));
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

        private void cmdDataCleanupLog_Inquire(object sender, Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            #region Actions
            if (!(Sal.TblAnyRows(this, Sys.ROW_Selected, 0)))
            {
                ((FndCommand)sender).Enabled = SalBoolean.False;
                return;
            }
            else
            {
                if (this.colsActionDb.Text == "DATA_ERASED")
                {
                    ((FndCommand)sender).Enabled = Ifs.Fnd.ApplicationForms.Var.Security.IsViewAvailable("PERSONAL_DATA_CLEANUP_LOG");
                }
                else
                {
                    ((FndCommand)sender).Enabled = SalBoolean.False;
                }                
            }            
            #endregion

        }

        private void cmdDataCleanupLog_Execute(object sender, Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            #region Local Variables
            SalArray<SalString> sItemNames = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
            #endregion

            #region Actions
            
            sItemNames[0] = "KEY_REF";
            hWndItems[0] = this.colsKeyRef;
            sItemNames[1] = "OPERATION_DATE";
            hWndItems[1] = this.coldOperationDate;
            sItemNames[2] = "ACTION";
            hWndItems[2] = this.colsAction;
            Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("PersonalDataCleanupLog", this, sItemNames, hWndItems);

            SessionNavigate(Pal.GetActiveInstanceName("tbwPersonalDataCleanupLog"));

            #endregion

        }

        #endregion
    }
}
