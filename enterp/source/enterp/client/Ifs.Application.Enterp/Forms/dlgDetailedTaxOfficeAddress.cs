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
// 120403   Hiralk  EASTRTM-3059, Merged bug 101459
#endregion

using System.Diagnostics;
using System.Windows.Forms;
using Ifs.Fnd.ApplicationForms;
using PPJ.Runtime;
using PPJ.Runtime.Windows;

namespace Ifs.Application.Enterp
{

    /// <summary>
    /// </summary>
    [FndWindowRegistration("TAX_OFFICE_INFO_ADDRESS", "TaxOfficeInfoAddress")]
    public partial class dlgDetailedTaxOfficeAddress : cDialog
    {
        #region Member Variables
        public SalString sEditMode = "";
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        protected dlgDetailedTaxOfficeAddress()
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
            dlgDetailedTaxOfficeAddress dlg = DialogFactory.CreateInstance<dlgDetailedTaxOfficeAddress>();
            SalNumber ret = dlg.ShowDialog(owner);
            return ret;
        }

        /// <summary>
        /// Returns the object instance associated with the window handle.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public new static dlgDetailedTaxOfficeAddress FromHandle(SalWindowHandle handle)
        {
            return ((dlgDetailedTaxOfficeAddress)SalWindow.FromHandle(handle, typeof(dlgDetailedTaxOfficeAddress)));
        }
        #endregion

        #region Properties

        #endregion

        #region Methods

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalNumber UM_Ok(SalNumber nWhat)
        {
            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        if (sEditMode == "EditableAddress")
                        {
                            if (Sal.SendMsg(i_hWndFrame, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0) == false)
                            {
                                return 0;
                            }
                        }
                        return 1;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        if (sEditMode == "EditableAddress")
                        {
                            Sal.WaitCursor(true);
                            Sal.SendMsg(i_hWndFrame, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                            Sal.WaitCursor(false);
                        }
                        return Sal.EndDialog(this, Sys.IDOK);
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalNumber UM_Cancel(SalNumber nWhat)
        {
            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        return 1;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        return Sal.EndDialog(this, 0);
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// Applications should return FALSE to skip standard window startup logic (such
        /// as exectuing the "startup behavior" settings), or TRUE to allow standard logic.
        /// </returns>
        public new SalBoolean FrameStartupUser()
        {
            #region Local Variables
            SalArray<SalString> sItemValues = new SalArray<SalString>();
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.RecCountGet() > 0)
                {
                    sEditMode = Ifs.Fnd.ApplicationForms.Var.DataTransfer.SourceNameGet();
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("TAX_OFFICE_ID", sItemValues);
                    dfsTaxOfficeId.Text = sItemValues[0];
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("ADDRESS_ID", sItemValues);
                    dfsAddressId.Text = sItemValues[0];
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
                    pbOk.DisableWindow();
                    Sal.SendMsg(i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Ifs.Fnd.ApplicationForms.Const.POPULATE_Single);
                }
                return true;
            }
            #endregion
        }

        #endregion

        #region Overrides

        #endregion
                
       
        #region Window Actions
        private void dfsStreet_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.dfsStreet_OnPM_DataItemQueryEnabled(sender, e);
                    break;
                case Sys.SAM_AnyEdit:
                    this.dfsStreet_OnSAM_AnyEdit(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsStreet_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.sEditMode == "EditableAddress")
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldEnabled;
                return;
            }
            else
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                return;
            }
            #endregion
        }

        private void dfsStreet_OnSAM_AnyEdit(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.sEditMode == "EditableAddress")
            {
                pbOk.EnableWindow();
   
            }
            e.Return = Sal.SendClassMessage(Sys.SAM_AnyEdit, Sys.wParam, Sys.lParam);
            return;
     
            #endregion
        }

        private void dfsHouseNo_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.dfsHouseNo_OnPM_DataItemQueryEnabled(sender, e);
                    break;
                case Sys.SAM_AnyEdit:
                    this.dfsHouseNo_OnSAM_AnyEdit(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsHouseNo_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.sEditMode == "EditableAddress")
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldEnabled;
                return;
            }
            else
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                return;
            }
            #endregion
        }

        private void dfsHouseNo_OnSAM_AnyEdit(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.sEditMode == "EditableAddress")
            {
                pbOk.EnableWindow();
     
            }
            e.Return = Sal.SendClassMessage(Sys.SAM_AnyEdit, Sys.wParam, Sys.lParam);
            return;
 
            #endregion
        }

        private void dfsCommunity_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.dfsCommunity_OnPM_DataItemQueryEnabled(sender, e);
                    break;
                case Sys.SAM_AnyEdit:
                    this.dfsCommunity_OnSAM_AnyEdit(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsCommunity_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.sEditMode == "EditableAddress")
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldEnabled;
                return;
            }
            else
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                return;
            }
            #endregion
        }

        private void dfsCommunity_OnSAM_AnyEdit(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.sEditMode == "EditableAddress")
            {
                pbOk.EnableWindow();
            }
            e.Return = Sal.SendClassMessage(Sys.SAM_AnyEdit, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        private void dfsDistrict_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.dfsDistrict_OnPM_DataItemQueryEnabled(sender, e);
                    break;
                case Sys.SAM_AnyEdit:
                    this.dfsDistrict_OnSAM_AnyEdit(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsDistrict_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.sEditMode == "EditableAddress")
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldEnabled;
                return;
            }
            else
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                return;
            }
            #endregion
        }

        private void dfsDistrict_OnSAM_AnyEdit(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.sEditMode == "EditableAddress")
            {
                pbOk.EnableWindow();
   
            }
            e.Return = Sal.SendClassMessage(Sys.SAM_AnyEdit, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        #endregion

        #region Menu Event Handlers

        #endregion

        #region Late Bind Methods
        public override SalBoolean vrtFrameStartupUser()
        {
            return this.FrameStartupUser();
        }

               
        #endregion

        private void pbOk_Execute(object sender, Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            UM_Ok(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void pbOk_Inquire(object sender, Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            UM_Ok(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        private void pbCancel_Execute(object sender, Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            UM_Cancel(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
        }

        private void pbCancel_Inquire(object sender, Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            UM_Cancel(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire);
        }

        
    }
}
