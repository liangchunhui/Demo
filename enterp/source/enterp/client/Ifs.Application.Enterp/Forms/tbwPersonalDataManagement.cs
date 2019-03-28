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
    [FndWindowRegistration("PERSONAL_DATA_MANAGEMENT", "PersonalDataManagement")]
    public partial class tbwPersonalDataManagement : cTableWindow
    {
        #region Member Variables
        public SalArray<SalString> sItemNames = new SalArray<SalString>();
        public SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
        protected SalString sAnyDetailsAreFields;
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public tbwPersonalDataManagement()
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
        public new static tbwPersonalDataManagement FromHandle(SalWindowHandle handle)
        {
            return ((tbwPersonalDataManagement)SalWindow.FromHandle(handle, typeof(tbwPersonalDataManagement)));
        }

        #endregion

        

        #region Properties

        #endregion

        #region Methods
        protected virtual SalBoolean AnyDetailsAreFields()
        {
            SalBoolean bReturn = SalBoolean.False;

            IDictionary<string, string> namedBindVariables = new Dictionary<string, string>();
            namedBindVariables.Add("sAnyDetailsAreFields", QualifiedVarBindName("sAnyDetailsAreFields"));
            namedBindVariables.Add("PersDataManagementId", colnPersDataManagementId.QualifiedBindName);

            if (DbPLSQLBlock(@"{sAnyDetailsAreFields} := &AO.Personal_Data_Man_Det_API.Any_Details_Are_Fields({PersDataManagementId} IN);", namedBindVariables))
            {
                bReturn = (sAnyDetailsAreFields == "TRUE") ? SalBoolean.True : SalBoolean.False;                
            }
            return bReturn;
        }
        #endregion

        #region Overrides

        #endregion

        #region Window Actions
        private void tbwPersonalDataManagement_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove:
                    this.tbwPersonalDataManagement_OnPM_DataRecordRemove(sender, e);
                    break;                
            }
            #endregion
        }

        private void tbwPersonalDataManagement_OnPM_DataRecordRemove(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)
            {
                if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove, Sys.wParam, Sys.lParam))
                {
                    if (this.colsSystemDefinedDb.Text == "TRUE")
                    {
                        e.Return = false;
                        return;
                    }
                    else
                    {
                        e.Return = true;
                        return;
                    }
                }
                else
                {
                    e.Return = false;
                    return;
                }
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }
        #endregion

        #region Event Handlers

        #endregion

        #region Menu Event Handlers

        private void cmdDetails_Inquire(object sender, Fnd.Windows.Forms.FndCommandInquireEventArgs e)
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
                    ((FndCommand)sender).Enabled = AnyDetailsAreFields();
                }
            }
            #endregion            
        }

        

        private void cmdDetails_Execute(object sender, Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            this.sItemNames[0] = "PERS_DATA_MANAGEMENT_ID";
            this.hWndItems[0] = this.colnPersDataManagementId;
            Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("PersonalDataManDet", this, this.sItemNames, this.hWndItems);

            SessionNavigate(Pal.GetActiveInstanceName("tbwPersonalDataManDet"));
        }

        private void cmdDataProcessingPurpose_Inquire(object sender, FndCommandInquireEventArgs e)
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

        private void cmdDataProcessingPurpose_Execute(object sender, FndCommandExecuteEventArgs e)
        {
            #region Action
            
            if (dlgDataProcessingPurpose.ModalDialog(this, this.colnPersDataManagementId.Number, this.colsPersonalData.Text) == Sys.IDOK)
            {
                Sal.SendMsg(i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceRefresh, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                return;
            }
            #endregion
        }

        private void cmdPropertyCode_Inquire(object sender, FndCommandInquireEventArgs e)
        {

            #region Action
            ((FndCommand)sender).Enabled = Ifs.Fnd.ApplicationForms.Var.Security.IsViewAvailable("PROPERTY_RULE_PERSONAL");
            #endregion
        }

        private void cmdPropertyCode_Execute(object sender, FndCommandExecuteEventArgs e)
        {
            #region Action

            if (dlgPersonalDataManPropertyCode.ModalDialog(this) == Sys.IDOK)
            {
                Sal.SendMsg(i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceRefresh, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                return;
            }
            #endregion
        }
        #endregion

        
    }
}
