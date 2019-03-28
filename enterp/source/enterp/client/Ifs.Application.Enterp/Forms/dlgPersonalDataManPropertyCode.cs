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
    [FndWindowRegistration("PERSONAL_DATA_MAN_DET", "PersonalDataManDet")]
    public partial class dlgPersonalDataManPropertyCode : cDialog
    {
        #region Member Variables
        protected SalWindowHandle hWndFocus;
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        protected dlgPersonalDataManPropertyCode()
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
            dlgPersonalDataManPropertyCode dlg = DialogFactory.CreateInstance<dlgPersonalDataManPropertyCode>();
            SalNumber ret = dlg.ShowDialog(owner);
            return ret;
        }

        /// <summary>
        /// Returns the object instance associated with the window handle.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public new static dlgPersonalDataManPropertyCode FromHandle(SalWindowHandle handle)
        {
            return ((dlgPersonalDataManPropertyCode)SalWindow.FromHandle(handle, typeof(dlgPersonalDataManPropertyCode)));
        }

        #endregion

        #region Properties

        #endregion

        #region Methods

        protected virtual SalBoolean AddPropertyCodeToPersonalDataManagement()
        {
            IDictionary<string, string> namedBindVariables = new Dictionary<string, string>();            
            namedBindVariables.Add("PropertyCode", dfsPropertyCode.QualifiedBindName);

            SalBoolean bOk = DbPLSQLTransaction(@"&AO.Personal_Data_Man_Det_Api.New_Pers_Data_Man_Prop_Code({PropertyCode} IN);", namedBindVariables);

            return bOk;

        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber SetWindowTitle()
        {
            #region Actions
            using (new SalContext(this))
            {
                Sal.SetWindowText(i_hWndFrame, Properties.Resources.TEXT_PersonalDataManPropertyCode);
            }

            return 0;
            #endregion
        }

        #endregion

        #region Overrides

        #endregion

        #region Window Actions

        private void dfsPropertyCode_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.dfsPropertyCode_OnPM_DataItemValidate(sender, e);
                    break;
                
                case Sys.SAM_SetFocus:
                    this.dfsPropertyCode_OnSAM_SetFocus(sender, e);
                    break;
            }
            #endregion
        }



        private void dfsPropertyCode_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
            hWndFocus = this.dfsPropertyCode.i_hWndSelf;            
            e.Return = true;
            return;
            #endregion
        }

        private void dfsPropertyCode_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam)
            {
                if (dfsPropertyCode.Text != Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    DbPLSQLBlock(@"{0}:= &AO.Property_Description_API.Get_Property_Desc({1} IN);", dfsDefaultDescription.QualifiedBindName, dfsPropertyCode.QualifiedBindName);
                }
            }
            this.dfsPropertyCode.EditDataItemSetEdited();
            e.Return = Sys.VALIDATE_Ok;
            return;
            #endregion
        }
        
        private void dlgPersonalDataManPropertyCode_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {

                case Sys.SAM_Create:
                    this.dlgPersonalDataManPropertyCode_OnSAM_Create(sender, e);
                    break;
            }
            #endregion
        }

        private void dlgPersonalDataManPropertyCode_OnSAM_Create(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam);
            this.SetWindowTitle();
            Sal.CenterWindow(this.i_hWndFrame);
            #endregion
        }

        #endregion

        #region Event Handlers

        private void commandOk_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            int returnValue;
            SalBoolean bOk = SalBoolean.True;
            // Dialog class have AcceptButton set to run this logic if the user ends the dialog using the Return button.
            // PPJ dialog close trough Sal.EndDialog so we set DialogResult to prevent the dialog from closing premature.
            DialogResult = DialogResult.None;
            if (dfsPropertyCode.Text != SalString.Null)
            {
                bOk = AddPropertyCodeToPersonalDataManagement();
            }
            
            returnValue = (bOk == SalBoolean.True) ? Sys.IDOK :  Sys.IDNO;
            Sal.EndDialog(this, returnValue);
        }

        private void commandCancel_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            // Dialog class have CancelButton set to run this logic even if the user close the dialog trough the esc button.
            // PPJ dialog close trough Sal.EndDialog so we set DialogResult to prevent the dialog from closing premature.
            DialogResult = DialogResult.None;

            Sal.EndDialog(this, Sys.IDCANCEL);
        }        

        private void commandList_Execute(object sender, Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            e.Handled = true;
            Sal.SendMsg(hWndFocus, Ifs.Fnd.ApplicationForms.Const.PM_DataItemLov, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);            
        }

        private void commandOk_Inquire(object sender, Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = dfsPropertyCode.Text != Ifs.Fnd.ApplicationForms.Const.strNULL;
        }

        private void commandList_Inquire(object sender, Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            e.Handled = true;
            if (hWndFocus != null)
            { 
                ((FndCommand)sender).Enabled = SalBoolean.True;
            }
            else
            {
                ((FndCommand)sender).Enabled = SalBoolean.False;
            }


        }

        #endregion





        #region Menu Event Handlers

        #endregion
    }
}
