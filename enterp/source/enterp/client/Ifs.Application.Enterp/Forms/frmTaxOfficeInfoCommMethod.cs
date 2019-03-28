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
//  130913  Nudilk  Bug 112434, Modified code in tblCommMethod_OnPM_DataRecordDuplicate.
//  131121  PRatlk  PBFI-2553, ChildTable Refactoring in ENTERP.
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
	public partial class frmTaxOfficeInfoCommMethod : cFormWindow
	{
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		public frmTaxOfficeInfoCommMethod()
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
		public new static frmTaxOfficeInfoCommMethod FromHandle(SalWindowHandle handle)
		{
			return ((frmTaxOfficeInfoCommMethod)SalWindow.FromHandle(handle, typeof(frmTaxOfficeInfoCommMethod)));
		}
		#endregion
		
		#region Window Actions
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void tblCommMethod_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew:
					this.tblCommMethod_OnPM_DataRecordNew(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate:
					this.tblCommMethod_OnPM_DataRecordDuplicate(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// PM_DataRecordNew event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblCommMethod_OnPM_DataRecordNew(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Sys.wParam, Sys.lParam)) 
            {
                if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
                {
                    this.tblCommMethod.colsPartyTypeDb.Text = "TAX";
                    this.tblCommMethod.colsIdentity.Text = frmTaxOfficeInfo.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndSelf)).cmbTaxOfficeId.i_sMyValue;
                    this.tblCommMethod.colsPartyTypeDb.EditDataItemSetEdited();
                    this.tblCommMethod.colsIdentity.EditDataItemSetEdited();
                    e.Return = true;
                    return;
                }
                e.Return = true;
                return;
            }
            else
            {
                e.Return = false;
                return;
            } 
            #endregion
        }
		
		/// <summary>
		/// PM_DataRecordDuplicate event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblCommMethod_OnPM_DataRecordDuplicate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire) 
			{
                if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate, Sys.wParam, Sys.lParam))
                {
                    e.Return = true;
                    return;
                }
                else
                {
                    e.Return = false;
                    return;
                }
			}
			if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
			{
				Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate, Sys.wParam, Sys.lParam);
				this.tblCommMethod.colsPartyTypeDb.Text = "TAX";
				this.tblCommMethod.colsIdentity.Text = frmTaxOfficeInfo.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndSelf)).cmbTaxOfficeId.i_sMyValue;
				this.tblCommMethod.colsPartyTypeDb.EditDataItemSetEdited();
				this.tblCommMethod.colsIdentity.EditDataItemSetEdited();
				e.Return = true;
				return;
			}
			#endregion
		}

		#endregion

        #region ChildTable - tblCommMethod

            #region Methods

            /// <summary>
            /// Late bound function in cDataSource
            /// </summary>
            /// <param name="hSql"></param>
            /// <returns></returns>
            public virtual SalBoolean tblCommMethod_DataRecordExecuteNew(SalSqlHandle hSql)
            {
                #region Actions
                using (new SalContext(this))
                {
                    tblCommMethod.colsPartyTypeDb.Text = "TAX";
                    tblCommMethod.colsIdentity.Text = frmTaxOfficeInfo.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndSelf)).cmbTaxOfficeId.i_sMyValue;
                    tblCommMethod.colsPartyTypeDb.EditDataItemSetEdited();
                    tblCommMethod.colsIdentity.EditDataItemSetEdited();
                    return ((cTableManager)this.tblCommMethod).DataRecordExecuteNew(hSql);
                }
                #endregion
            }

            /// <summary>
            /// Late bound function in cDataSource
            /// </summary>
            /// <param name="hSql"></param>
            /// <returns></returns>
            public virtual SalBoolean tblCommMethod_DataRecordExecuteModify(SalSqlHandle hSql)
            {
                #region Actions
                using (new SalContext(this))
                {
                    tblCommMethod.colsPartyTypeDb.Text = "TAX";
                    tblCommMethod.colsIdentity.Text = frmTaxOfficeInfo.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndSelf)).cmbTaxOfficeId.i_sMyValue;
                    tblCommMethod.colsPartyTypeDb.EditDataItemSetEdited();
                    tblCommMethod.colsIdentity.EditDataItemSetEdited();
                    return ((cTableManager)this.tblCommMethod).DataRecordExecuteModify(hSql);
                }
                #endregion
            }
            /// <summary>
            /// </summary>
            /// <param name="sWindowName">
            /// Window name
            /// Intendend receiver window of the data transfer. When overriding DataSourcePrepareKeyTransfer,
            /// applications can use this parameter to initialize data transfer in different ways for
            /// different receiver windows.
            /// </param>
            /// <returns></returns>
            public virtual SalNumber tblCommMethod_DataSourcePrepareKeyTransfer(SalString sWindowName)
            {
                #region Local Variables
                SalString sSourceName = "";
                SalWindowHandle hWndSource = SalWindowHandle.Null;
                SalArray<SalString> sItemNames = new SalArray<SalString>();
                SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
                #endregion

                #region Actions
                using (new SalContext(this))
                {
                    if (sWindowName == Pal.GetActiveInstanceName("frmHistoryLog"))
                    {
                        sSourceName = p_sLogicalUnit;
                        hWndSource = i_hWndSelf;
                        sItemNames[0] = "COMM_ID";
                        sItemNames[1] = "IDENTITY";
                        sItemNames[2] = "PARTY_TYPE";
                        hWndItems[0] = tblCommMethod.colnCommId;
                        hWndItems[1] = tblCommMethod.colsIdentity;
                        hWndItems[2] = tblCommMethod.colsPartyTypeDb;
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init(sSourceName, hWndSource, sItemNames, hWndItems);
                        return Ifs.Fnd.ApplicationForms.Var.DataTransfer.TypeSet("CREATE_WINDOW");
                    }
                    return ((cChildTableCommMethod)this.tblCommMethod).DataSourcePrepareKeyTransfer(sWindowName);
                }
                #endregion
            }
            #endregion

            #region Event Handlers

            private void tblCommMethod_DataRecordExecuteNewEvent(object sender, cDataSource.DataRecordExecuteNewEventArgs e)
            {
                e.Handled = true;
                e.ReturnValue = tblCommMethod_DataRecordExecuteNew(e.hSql);
            }

            private void tblCommMethod_DataRecordExecuteModifyEvent(object sender, cDataSource.DataRecordExecuteModifyEventArgs e)
            {
                e.Handled = true;
                e.ReturnValue = tblCommMethod_DataRecordExecuteModify(e.hSql);
            }

            private void tblCommMethod_DataSourcePrepareKeyTransferEvent(object sender, cDataSource.DataSourcePrepareKeyTransferEventArgs e)
            {
                e.Handled = true;
                e.ReturnValue = tblCommMethod_DataSourcePrepareKeyTransfer(e.sWindowName);
            }

            #endregion

        #endregion

    }
}
