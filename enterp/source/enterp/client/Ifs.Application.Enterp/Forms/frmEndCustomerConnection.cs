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
// Date     By      Notes
// -----    ------  ---------------------------------------------------------------------------------
// 121030   MaRalk  PBR-563, Created.
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
    [FndWindowRegistration("CUSTOMER_INFO", "CustomerInfo", FndWindowRegistrationFlags.NoSecurity)]
    public partial class frmEndCustomerConnection : cFormWindow
    {
        #region Member Variables

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public frmEndCustomerConnection()
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
        public new static frmEndCustomerConnection FromHandle(SalWindowHandle handle)
        {
            return ((frmEndCustomerConnection)SalWindow.FromHandle(handle, typeof(frmEndCustomerConnection)));
        }
        #endregion

        #region Properties

        #endregion

        #region Methods

        #endregion

        #region Overrides

        #endregion

        #region Window Actions

        private void tblEndCustomers_colsEndCustAddrId_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom:
                    this.tblEndCustomers_colsEndCustAddrId_OnPM_DataItemZoom(sender, e);
                    break;
            }
            #endregion
        }

        private void tblEndCustomers_colsEndCustAddrId_OnPM_DataItemZoom(object sender, WindowActionsEventArgs e)
        {
            #region Local Variables
            SalArray<SalString> sItemNames = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
            #endregion

            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
                sItemNames[0] = "CUSTOMER_ID";
                hWndItems[0] = this.colsEndCustomerId;
                sItemNames[1] = "ADDRESS_ID";
                hWndItems[1] = this.colsEndCustAddrId;
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init(Pal.GetActiveInstanceName("frmCustomerInfoAddress"), tblEndCustomers, sItemNames, hWndItems);
                SessionNavigate(Pal.GetActiveInstanceName("frmCustomerInfo"));
                e.Return = true;
                return;
            }
            if (Ifs.Fnd.ApplicationForms.Var.Component.IsWindowAvailable(Pal.GetActiveInstanceName("frmCustomerInfo")))
            {
                e.Return = true;
                return;
            }
            e.Return = false;
            return;
            #endregion
        }

        #endregion

        #region Event Handlers

        #endregion

        #region Menu Event Handlers

        #endregion
    }
}
