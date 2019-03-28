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
//  161219  AmThLK  STRFI-4160, Merged Bug 132645, Modified tblCommMethod_DataSourcePrepareKeyTransfer().
//  150911  Wahelk  AFT-4714, Modified tblCommMethod_CreateWhereStmt to add correct where clause for frmCustomerInfoCrmContact
//  150615  SudJlk  ORA-746, Modified tblCommMethod_CreateWhereStmt to fetch IDENTITY when parent is frmSupplierInfoSrmContact.
//  140715  Maabse  PRSC-1787, Added code if parent is frmCustomerInfoCrmContact.
//  130913  Nudilk  Bug 112434, Modified code in tblCommMethod_OnPM_DataRecordDuplicate.
//  131121  PRatlk  PBFI-2545,  ChildTable Refactoring in ENTERP.
#endregion

using System.Windows.Forms;
using Ifs.Fnd.ApplicationForms;
using PPJ.Runtime;
using PPJ.Runtime.Sql;
using PPJ.Runtime.Windows;
using PPJ.Runtime.Vis;

namespace Ifs.Application.Enterp
{
	
	/// <summary>
	/// </summary>
	public partial class frmPersonInfoCommMethod : cFormWindow
    {
        #region Window Variables
        protected SalString sPersonId;
        protected SalString sPersonIdx;
        #endregion

        #region Constructors/Destructors

        /// <summary>
		/// Default Constructor.
		/// </summary>
		public frmPersonInfoCommMethod()
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
		public new static frmPersonInfoCommMethod FromHandle(SalWindowHandle handle)
		{
			return ((frmPersonInfoCommMethod)SalWindow.FromHandle(handle, typeof(frmPersonInfoCommMethod)));
		}
		#endregion

        #region Methods
        #endregion

        #region Late Bind Methods

        public override SalBoolean vrtFrameStartupUser()
        {
            #region Actions
            SalBoolean bReturn = base.vrtFrameStartupUser();
            return bReturn;
            #endregion
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
                    this.tblCommMethod.colsPartyTypeDb.Text = "PERSON";
				    this.tblCommMethod.colsIdentity.Text = this.tblCommMethod_GetPersonId();
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
				this.tblCommMethod.colsPartyTypeDb.Text = "PERSON";
				this.tblCommMethod.colsIdentity.Text = this.tblCommMethod_GetPersonId();
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
                    tblCommMethod.colsPartyTypeDb.Text = "PERSON";
                    tblCommMethod.colsIdentity.Text = tblCommMethod_GetPersonId();
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
                    tblCommMethod.colsPartyTypeDb.Text = "PERSON";
                    tblCommMethod.colsIdentity.Text = tblCommMethod_GetPersonId();
                    tblCommMethod.colsPartyTypeDb.EditDataItemSetEdited();
                    tblCommMethod.colsIdentity.EditDataItemSetEdited();
                    return ((cTableManager)this.tblCommMethod).DataRecordExecuteModify(hSql);
                }
                #endregion
            }

            /// <summary>
            /// Fetch the value of PERSON_ID from the parent window holding frmPersonInfoCommMethod.
            /// e.g. value of cmbPerson in frmPersonInfo or value of dfPerson in frmEmployees.
            /// </summary>
            /// <returns></returns>
            public virtual SalString tblCommMethod_GetPersonId()
            {
                #region Local Variables
                SalString sPersonId = "";
                SalWindowHandle hWndPersonId = SalWindowHandle.Null;
                SalString sMasterParent = "";
                SalString sFormNameParent = "";
                SalString sFormNameGrandParent = "";
                SalString sFormNameGrandGrand = "";
                #endregion

                #region Actions
                using (new SalContext(this))
                {
                    sMasterParent = Ifs.Fnd.ApplicationForms.Int.QualifiedItemNameGet(i_hWndParent);
                    sFormNameParent = Ifs.Fnd.ApplicationForms.Int.QualifiedItemNameGet(this.ParentForm);
                    sFormNameGrandParent = Ifs.Fnd.ApplicationForms.Int.QualifiedItemNameGet(this.ParentForm.ParentForm);
                    sFormNameGrandGrand = Ifs.Fnd.ApplicationForms.Int.QualifiedItemNameGet(this.ParentForm.ParentForm.ParentForm);
                    if (sMasterParent == Pal.GetActiveInstanceName("frmResourceContIndividual"))
                    {
                        // Called from component GENRES
                        hWndPersonId = Sal.SendMsg(i_hWndParent, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceQueryFieldName, Vis.DT_Handle, ((SalString)"RESOURCE_ID").ToHandle()).ToWindowHandle();
                        sPersonId = SalString.FromHandle(Sal.SendMsg(hWndPersonId, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueGet, 0, 0));
                    }
                    else
                    {
                        hWndPersonId = Sal.SendMsg(i_hWndParent, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceQueryFieldName, Vis.DT_Handle, ((SalString)"PERSON_ID").ToHandle()).ToWindowHandle();
                        sPersonId = SalString.FromHandle(Sal.SendMsg(hWndPersonId, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueGet, 0, 0));
                    }
                    return sPersonId;
                }
                #endregion
            }

            /// <summary>
            /// Creates a where clause for this child table based on the parent window holding frmPersonInfoCommMethod.
            /// </summary>
            /// <returns></returns>
            public virtual SalString tblCommMethod_CreateWhereStmt()
            {
                #region Local Variables
                SalString sWhereStmt = "";
                SalString sMasterParent = "";
                
                #endregion

                #region Actions
                using (new SalContext(this))
                {
                    sMasterParent = Ifs.Fnd.ApplicationForms.Int.QualifiedItemNameGet(i_hWndParent);
                    if (sMasterParent == Pal.GetActiveInstanceName("frmPersonInfo"))
                    {
                        sWhereStmt = "IDENTITY = :Int.GetParent( i_hWndParent ).frmPersonInfo.cmbPerson.i_sMyValue";
                    }
                    else if (sMasterParent == Pal.GetActiveInstanceName("frmEmployees"))
                    {
                        sWhereStmt = "IDENTITY = :Int.GetParent( i_hWndParent ).frmEmployees.dfPerson";
                    }
                    else if (sMasterParent == Pal.GetActiveInstanceName("frmCustomerInfoCrmContact"))
                    {
                        sPersonId = GetParentIdentity();
                        sWhereStmt = "IDENTITY =  :i_hWndFrame.frmPersonInfoCommMethod.sPersonId";
 
                    }
                    else if (sMasterParent == Pal.GetActiveInstanceName("frmSupplierInfoSrmContact"))
                    {
                        sPersonId = GetParentIdentity();
                        sWhereStmt = "IDENTITY = :i_hWndFrame.frmPersonInfoCommMethod.sPersonId";
                    }
                    else if (sMasterParent == Pal.GetActiveInstanceName("frmResourceContIndividual"))
                    {
                        sWhereStmt = "IDENTITY = :Int.GetParent( i_hWndParent ).frmResourceContIndividual.dfsResourceId";
                    }
                    else
                    {
                        sWhereStmt = SalString.Null;
                    }
                    return sWhereStmt;
                }
                #endregion
            }

            public virtual SalString GetParentIdentity()
            {
                #region Actions
                using (new SalContext(this))
                {
                    return SalString.FromHandle(SendMessageToParent(Const.PAM_GetParentIdentity, 0, 0));
                }
                #endregion
            }
            /// <summary>
            /// </summary>
            /// <returns></returns>
            public virtual SalString tblCommMethod_DataSourceFormatSqlWhere()
            {
                #region Local Variables
                SalString lsStmt = "";
                #endregion

                #region Actions
                using (new SalContext(this))
                {
                    lsStmt = ((cChildTableCommMethod)this.tblCommMethod).DataSourceFormatSqlWhere();
                    if (lsStmt != SalString.Null)
                    {
                        lsStmt = lsStmt + " AND " + tblCommMethod_CreateWhereStmt();
                    }
                    return lsStmt;
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

            private void tblCommMethod_DataSourceFormatSqlWhereEvent(object sender, FndReturnEventArgsSalString e)
            {
                e.Handled = true;
                e.ReturnValue = tblCommMethod_DataSourceFormatSqlWhere();
            }

            #endregion

        #endregion

	}
}
