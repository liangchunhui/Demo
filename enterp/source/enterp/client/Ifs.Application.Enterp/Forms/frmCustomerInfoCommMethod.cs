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
//  Date    By      Notes
//  ----    ------  -------------------------------------------------------------------------------------
//  111201  JANBLK  EDEL-210, added validations to colsMethodId
//  120727  SWRALK  EDEL-1256, Added validations to coldValidFrom and coldValidTo.
//  130913  Nudilk  Bug 112434, Modified code in tblCommMethod_OnPM_DataRecordDuplicate.
//  131121  Pratlk  PBFI-2528 , ChilTable Refactoring in ENTERP.
//  140821  THPELK  PRFI-1220 - LCS Merge(Bug 117877).
//  161219  AmThLK  STRFI-4160, Merged Bug 132645, Modified tblCommMethod_DataSourcePrepareKeyTransfer().
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
	[FndWindowRegistration("COMM_METHOD", "CommMethod")]
	[FndDynamicTabPage("frmCustomer360.picTab", "tbCustomerInfoCommMethod", "TAB_NAME_CustomerInfoCommMethod", 19)]
	public partial class frmCustomerInfoCommMethod : cFormWindow
	{
        #region Window Variables
        public SalString sExist_;
        #endregion 

		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		public frmCustomerInfoCommMethod()
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
		public new static frmCustomerInfoCommMethod FromHandle(SalWindowHandle handle)
		{
			return ((frmCustomerInfoCommMethod)SalWindow.FromHandle(handle, typeof(frmCustomerInfoCommMethod)));
		}
		#endregion

        #region Methods

        #endregion

        #region Late Bind Methods
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
				
				
				case Sys.SAM_CreateComplete:
					this.tblCommMethod_OnSAM_CreateComplete(sender, e);
					break;
				
                case Sys.SAM_FetchRowDone:
                    this.tblCommMethod_OnSAM_FetchRowDone(sender, e);
                    break;
			}
			#endregion
		}

        private void tblCommMethod_OnSAM_FetchRowDone(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.tblCommMethod_coldValidFromOld.DateTime = this.tblCommMethod.coldValidFrom.DateTime;
            this.tblCommMethod_coldValidToOld.DateTime   = this.tblCommMethod.coldValidTo.DateTime;
            Sal.SendClassMessage(Sys.SAM_FetchRowDone, Sys.wParam, Sys.lParam);
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
                    this.tblCommMethod.colsPartyTypeDb.Text = "CUSTOMER";
					this.tblCommMethod.colsIdentity.Text = this.tblCommMethod_GetIdentityFromGrandParent();
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
				this.tblCommMethod.colsPartyTypeDb.Text = "CUSTOMER";
				this.tblCommMethod.colsIdentity.Text = this.tblCommMethod_GetIdentityFromGrandParent();
				this.tblCommMethod.colsPartyTypeDb.EditDataItemSetEdited();
				this.tblCommMethod.colsIdentity.EditDataItemSetEdited();
				e.Return = true;
				return;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_CreateComplete event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblCommMethod_OnSAM_CreateComplete(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Sys.SAM_CreateComplete, Sys.wParam, Sys.lParam)) 
			{
				this.tblCommMethod_sGrandParentName = Ifs.Fnd.ApplicationForms.Int.PalGetItemNameX(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndSelf));
				if (this.tblCommMethod_sGrandParentName == Pal.GetActiveInstanceName("frmCustomerInfo")) 
				{
					this.tblCommMethod.p_lsDefaultWhere = "PARTY_TYPE_DB = 'CUSTOMER' AND IDENTITY = :Int.GetParent( i_hWndParent ).frmCustomerInfo.cmbCustomerId.i_sMyValue";
				}
				else if (this.tblCommMethod_sGrandParentName == Pal.GetActiveInstanceName("frmCustomer360")) 
				{
					this.tblCommMethod.p_lsDefaultWhere = "PARTY_TYPE_DB = 'CUSTOMER' AND IDENTITY = :Int.GetParent( i_hWndParent ).frmCustomer360.ecmbCustomerNo.i_sMyValue";
				}
				e.Return = true;
				return;
			}
			e.Return = false;
			return;
			#endregion
		}

        private void tblCommMethod_colsMethodId_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.colsMethodId_OnPM_PM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        private void colsMethodId_OnPM_PM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);

            if (Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Comm_Method_API.Comm_Id_Exist"))
            {
                using (new SalContext(this))
                {
                    DbPLSQLBlock(cSessionManager.c_hSql, " BEGIN :i_hWndFrame.frmCustomsInfoCommMethod.sExist_ := &AO.Comm_Method_API.Comm_Id_Exist(\r\n" +
                                                         "		:i_hWndFrame.frmCustomsInfoCommMethod.tblCommMethod.colsIdentity IN,\r\n" +
                                                         "		:i_hWndFrame.frmCustomsInfoCommMethod.tblCommMethod.colsPartyType IN,\r\n" +
                                                         "		:i_hWndFrame.frmCustomsInfoCommMethod.tblCommMethod.colnCommId IN); END;\r\n");
                    if (sExist_ == "TRUE")
                    {
                        Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_CommMethodExistARCContact, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                        this.tblCommMethod.colsMethodId.Text = this.tblCommMethod.colsMethodId.__sOldValue;
                        e.Return = Sys.VALIDATE_Cancel;
                        return;
                    }
                }
            }
            return;
            #endregion
        }

        private void tblCommMethod_coldValidFrom_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.coldValidFrom_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        private void coldValidFrom_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Local Variables
            SalArray<SalString> sDefMethList = new SalArray<SalString>(1);
            #endregion

            #region Actions
            e.Handled = true;
            sDefMethList[0] = Ifs.Fnd.ApplicationForms.Const.strNULL;
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);

            if (Sys.wParam == 1 && this.tblCommMethod.coldValidFrom.DateTime != this.tblCommMethod_coldValidFromOld.DateTime)
            {
                if (Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Comm_Method_API.Comm_Id_Exist"))
                {
                    using (new SalContext(this))
                    {
                        DbPLSQLBlock(cSessionManager.c_hSql, " BEGIN :i_hWndFrame.frmCustomsInfoCommMethod.sExist_ := &AO.Comm_Method_API.Comm_Id_Exist(\r\n" +
                                                             "		:i_hWndFrame.frmCustomsInfoCommMethod.tblCommMethod.colsIdentity IN,\r\n" +
                                                             "		:i_hWndFrame.frmCustomsInfoCommMethod.tblCommMethod.colsPartyType IN,\r\n" +
                                                             "		:i_hWndFrame.frmCustomsInfoCommMethod.tblCommMethod.colnCommId IN); END;\r\n");
                        if (sExist_ == "TRUE")
                        {
                            sDefMethList[0] = this.tblCommMethod.colnCommId.Text;
                            if (Ifs.Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.TEXT_CannotChangeValidFromDate, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Warning, Ifs.Fnd.ApplicationForms.Const.WARNING_YesNo, sDefMethList) == Sys.IDNO)
                            {
                                this.tblCommMethod.coldValidFrom.DateTime = this.tblCommMethod_coldValidFromOld.DateTime;
                                e.Return = Sys.VALIDATE_Cancel;
                            }
                        }
                        this.tblCommMethod_coldValidFromOld.DateTime = this.tblCommMethod.coldValidFrom.DateTime;
                    }
                }
            }
            return;
            #endregion
        }

        private void tblCommMethod_coldValidTo_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.coldValidTo_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        private void coldValidTo_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Local Variables
            SalArray<SalString> sDefMethList = new SalArray<SalString>(1);
            #endregion

            #region Actions
            e.Handled = true;
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
            sDefMethList[0] = Ifs.Fnd.ApplicationForms.Const.strNULL;

            if (Sys.wParam == 1 && this.tblCommMethod.coldValidTo.DateTime != this.tblCommMethod_coldValidToOld.DateTime)
            {
                if (Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Comm_Method_API.Comm_Id_Exist"))
                {
                    using (new SalContext(this))
                    {
                        DbPLSQLBlock(cSessionManager.c_hSql, " BEGIN :i_hWndFrame.frmCustomsInfoCommMethod.sExist_ := &AO.Comm_Method_API.Comm_Id_Exist(\r\n" +
                                                             "		:i_hWndFrame.frmCustomsInfoCommMethod.tblCommMethod.colsIdentity IN,\r\n" +
                                                             "		:i_hWndFrame.frmCustomsInfoCommMethod.tblCommMethod.colsPartyType IN,\r\n" +
                                                             "		:i_hWndFrame.frmCustomsInfoCommMethod.tblCommMethod.colnCommId IN); END;\r\n");
                        if (sExist_ == "TRUE")
                        {
                            sDefMethList[0] = this.tblCommMethod.colnCommId.Text;
                            if (Ifs.Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.TEXT_CannotChangeValidToDate, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Warning, Ifs.Fnd.ApplicationForms.Const.WARNING_YesNo, sDefMethList) == Sys.IDNO)
                            {
                                this.tblCommMethod.coldValidTo.DateTime = this.tblCommMethod_coldValidToOld.DateTime;
                                e.Return = Sys.VALIDATE_Cancel; ;
                            }
                        }
                        this.tblCommMethod_coldValidToOld.DateTime = this.tblCommMethod.coldValidTo.DateTime;
                    }
                }
            }            
            return;
            #endregion
        }
		#endregion

        #region ChildTable - tblCommMethod

            #region Window Variables
            public SalString tblCommMethod_sGrandParentName = "";
            #endregion

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
                    tblCommMethod.colsPartyTypeDb.Text = "CUSTOMER";
                    tblCommMethod.colsIdentity.Text = tblCommMethod_GetIdentityFromGrandParent();
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
                    tblCommMethod.colsPartyTypeDb.Text = "CUSTOMER";
                    tblCommMethod.colsIdentity.Text = tblCommMethod_GetIdentityFromGrandParent();
                    tblCommMethod.colsPartyTypeDb.EditDataItemSetEdited();
                    tblCommMethod.colsIdentity.EditDataItemSetEdited();
                    return ((cTableManager)this.tblCommMethod).DataRecordExecuteModify(hSql);
                }
                #endregion
            }
            /// <summary>
            /// </summary>
            /// <returns></returns>
            public virtual SalString tblCommMethod_GetIdentityFromGrandParent()
            {
                #region Actions
                using (new SalContext(this))
                {
                    if ((tblCommMethod_sGrandParentName == Pal.GetActiveInstanceName("frmCustomerInfo")) || (tblCommMethod_sGrandParentName == Pal.GetActiveInstanceName("frmCustomer360")))
                    {
                        return SalString.FromHandle(Sal.SendMsg(Ifs.Fnd.ApplicationForms.Int.GetParent(Sys.hWndForm), Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ((SalString)
                                "GetIdentity").ToHandle()));
                    }
                    return SalString.Null;
                }
                #endregion
            }

            /// <summary>
            /// </summary>
            /// <param name="sWindowName">
            /// Window name
            /// Intendend receiver window of the data transfer. When overriding tblCommMethod_DataSourcePrepareKeyTransfer,
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
                        sSourceName = tblCommMethod.p_sLogicalUnit;
                        hWndSource = tblCommMethod;
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

            private void tblCommMethod_DataRecordExecuteModifyEvent(object sender, cDataSource.DataRecordExecuteModifyEventArgs e)
            {
                e.Handled = true;
                e.ReturnValue = tblCommMethod_DataRecordExecuteModify(e.hSql);
            }

            private void tblCommMethod_DataRecordExecuteNewEvent(object sender, cDataSource.DataRecordExecuteNewEventArgs e)
            {
                e.Handled = true;
                e.ReturnValue = tblCommMethod_DataRecordExecuteNew(e.hSql);
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
