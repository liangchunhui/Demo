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
// Date     By      Notes
// -----    ------  ---------------------------------------------------------------------------------
// 131114  Pratlk  PBFI-2537, Refactor client windows in component ENTERP
// 140401  Machlk  PBFI-5564 Merged Bug 115353
// 140401  Kagalk  PBFI-4142, Merged Bug 113712, Modified to give a warning when deleting the last address type.
// 140409  Ajpelk  PBFI-4140, Merged Bug 112894, Added TabActivateFinish()
// 140704  Hawalk  Bug 116673, Changed view of tblOurId from OWNER_INFO_OUR_ID to OWNER_INFO_OUR_ID_FIN_AUTH (user-company authorization rests in ACCRUL,
// 140704          that cannot be directly referenced in the server - hence a new view).
// 140728  Kagalk  PRFI-1290, Merged Bug 117813, Enable to validate association no when using object copy/paste.
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
	[FndWindowRegistration("OWNER_INFO", "OwnerInfo", FndWindowRegistrationFlags.HomePage)]
	public partial class frmOwnerInfo : cMasterDetailTabFormWindow
	{
		#region Window Variables
		public SalString sFullFormName = "";
		public SalBoolean bAssociationNoEdited = false;
		public SalString sCommMethodTabActive = "";
		public SalString sAddressTabActive = "";
		public SalBoolean bTabName1Edited = false;
		public SalBoolean bTabName2Edited = false;
		public SalBoolean bAddressType = false;
		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		public frmOwnerInfo()
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
		public new static frmOwnerInfo FromHandle(SalWindowHandle handle)
		{
			return ((frmOwnerInfo)SalWindow.FromHandle(handle, typeof(frmOwnerInfo)));
		}
		#endregion
		
		#region Methods
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public new SalBoolean FrameStartupUser()
		{
			#region Actions
			using (new SalContext(this))
			{
				Sal.SetWindowText(i_hWndFrame, Properties.Resources.HEAD_DetailOwnerInfo);
                return true;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean CheckAssociationNumber()
		{
			#region Actions
			using (new SalContext(this))
			{
				Sal.WaitCursor(true);
				using(SignatureHints hints = SignatureHints.NewContext())
				{
					hints.Add("Association_Info_API.Association_No_Exist", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
					DbPLSQLBlock(cSessionManager.c_hSql, sFullFormName + ".dfsExist :=\r\n" +
						"                                 &AO.Association_Info_API.Association_No_Exist( " + sFullFormName + ".dfsAssociationNo, 'OWNER' )");
				}
				Sal.WaitCursor(false);
				if (dfsExist.Text == "TRUE") 
				{
					if (Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_WarnSameAssocNo, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Warning, Ifs.Fnd.ApplicationForms.Const.WARNING_OkCancel) == Sys.IDCANCEL) 
					{
						return false;
					}
				}
				return true;
			}
			#endregion
		}
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public new SalBoolean DataSourceSaveCheckOk()
		{
			#region Local Variables
			SalWindowHandle hWndAddress = SalWindowHandle.Null;
			SalWindowHandle hWndComMethod = SalWindowHandle.Null;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				hWndAddress = TabAttachedWindowHandleGet(picTab.FindName("Address"));
				hWndComMethod = TabAttachedWindowHandleGet(picTab.FindName("Name2"));
				if (sAddressTabActive == "TRUE") 
				{
					if (Sal.SendMsg(frmOwnerInfoAddress.FromHandle(hWndAddress).tblCommMethod, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceIsDirty, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam)) 
					{
						if (!(frmOwnerInfoAddress.FromHandle(hWndAddress).tblCommMethod.CheckDefault())) 
						{
							return false;
						}
					}
				}
				if (sCommMethodTabActive == "TRUE") 
				{
					if (Sal.SendMsg(frmOwnerInfo.FromHandle(i_hWndFrame).TabAttachedWindowHandleGet(picTab.FindName("Name2")), Ifs.Fnd.ApplicationForms.Const.PM_DataSourceIsDirty, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam)) 
					{
						if (!(frmOwnerInfoCommMethod.FromHandle(hWndComMethod).tblCommMethod.CheckDefault())) 
						{
							return false;
						}
					}
				}
				return ((cDataSource)this).DataSourceSaveCheckOk();
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="hWnd"></param>
		/// <param name="nTab"></param>
		/// <returns></returns>
		public new SalNumber TabActivateStart(SalWindowHandle hWnd, SalNumber nTab)
		{
            #region Local Variables
            SalString sName = "";
            #endregion

			#region Actions
			using (new SalContext(this))
			{
                picTab.GetName(nTab, ref sName);
                if (sName == "Address")
                {
                    sAddressTabActive = "TRUE";
                }
                else if (sName == "Name2")
                {
                    sCommMethodTabActive = "TRUE";
                }
			}

			return 0;
			#endregion
		}
		/// <summary>
		/// The DataSourceSaveCheck function performs server validation of the complete
		/// master-detail chain of data sources.
		/// COMMENTS:
		/// DataSourceSaveCheck is called by the DataSourceSave function during the save
		/// process. To perform validation, DataSourceSaveCheck first calls DataSourceCheck
		/// to validate the current data source, and then calls DataSourceSaveCheck in all
		/// child data sources.
		/// </summary>
		/// <returns>The return value is TRUE if validation is successful, FALSE otherwise.</returns>
		public new SalBoolean DataSourceSaveCheck()
		{
			#region Local Variables
			SalWindowHandle hWndAddress = SalWindowHandle.Null;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
                hWndAddress = TabAttachedWindowHandleGet(picTab.FindName("Address"));
				if (sAddressTabActive == "TRUE") 
				{
					if (((bool)Sal.SendMsg(frmOwnerInfoAddress.FromHandle(hWndAddress).tblAddressType, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceIsDirty, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam)) || (Sal.QueryFieldEdit(frmOwnerInfoAddress.FromHandle(hWndAddress).dfdValidFrom) || 
					Sal.QueryFieldEdit(frmOwnerInfoAddress.FromHandle(hWndAddress).dfdValidTo))) 
					{
						if (!(frmOwnerInfoAddress.FromHandle(hWndAddress).tblAddressType_CheckDefaultAddress())) 
						{
							return false;
						}
                        if (!(frmOwnerInfoAddress.FromHandle(hWndAddress).tblAddressType_CheckLastAddressType()))
                        {
                            return false;
                        }
					}
				}
				return ((cMasterDetailTabFormWindow)this).DataSourceSaveCheck();
			}
			#endregion
		}
        /// <summary>
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="nTab"></param>
        /// <returns></returns>
        public virtual new SalNumber TabActivateFinish(SalWindowHandle hWnd, SalNumber nTab)
        {
            #region Local Variables
            SalWindowHandle hWndInfoCommMethod = SalWindowHandle.Null;
            SalNumber retVal = 0;
            SalString sTabName = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                retVal = base.TabActivateFinish(hWnd, nTab);
                picTab.GetName(nTab, ref sTabName);
                if (sTabName == "Name2")
                {
                    hWndInfoCommMethod = TabAttachedWindowHandleGet(picTab.FindName("Name2"));
                    Sal.SetFocus(frmOwnerInfoCommMethod.FromHandle(hWndInfoCommMethod).tblCommMethod);
                }
            }
            return retVal;
            #endregion
        }
        
		#endregion
		
		#region Window Actions
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void frmOwnerInfo_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Create:
					this.frmOwnerInfo_OnSAM_Create(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate:
					this.frmOwnerInfo_OnPM_DataSourcePopulate(sender, e);
					break;
				
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave:
					this.frmOwnerInfo_OnPM_DataSourceSave(sender, e);
					break;
				
                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate:
                    this.frmOwnerInfo_OnPM_DataRecordDuplicate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordPaste:
                    this.frmOwnerInfo_OnPM_DataRecordPaste(sender, e);
                    break;                


			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Create event handler.
		/// </summary>
		/// <param name="message"></param>
		private void frmOwnerInfo_OnSAM_Create(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam);
			this.sFullFormName = ":i_hWndFrame." + Ifs.Fnd.ApplicationForms.Int.QualifiedItemNameGet(this);
			this.bAddressType = false;
			#endregion
		}
		
		/// <summary>
		/// PM_DataSourcePopulate event handler.
		/// </summary>
		/// <param name="message"></param>
		private void frmOwnerInfo_OnPM_DataSourcePopulate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
			{
				if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Sys.wParam, Sys.lParam)) 
				{
					e.Return = Sal.SendMsgToChildren(this.i_hWndFrame, Ifs.Fnd.ApplicationForms.Const.PM_User, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ((SalString)"POPULATE").ToHandle());
					return;
				}
			}
			else
			{
				e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Sys.wParam, Sys.lParam);
				return;
			}
			#endregion
		}
		
		/// <summary>
		/// PM_DataSourceSave event handler.
		/// </summary>
		/// <param name="message"></param>
		private void frmOwnerInfo_OnPM_DataSourceSave(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Sys.wParam, Sys.lParam)) 
			{
				if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
				{
					if (!(this.bAddressType)) 
					{
						this.bTabName2Edited = Sal.SendMsgToChildren(this.TabAttachedWindowHandleGet(this.picTab.FindName("Name2")), Ifs.Fnd.ApplicationForms.Const.PM_DataSourceIsDirty, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam);
						if (this.bTabName2Edited) 
						{
							this.TabInvalidateData(this.picTab.FindName("Address"));
						}
						this.bTabName1Edited = Sal.SendMsgToChildren(this.TabAttachedWindowHandleGet(this.picTab.FindName("Address")), Ifs.Fnd.ApplicationForms.Const.PM_DataSourceIsDirty, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam);
						if (this.bTabName1Edited) 
						{
							this.TabInvalidateData(this.picTab.FindName("Name2"));
							Sal.SendMsg(this.TabAttachedWindowHandleGet(this.picTab.FindName("Address")), Ifs.Fnd.ApplicationForms.Const.PM_DataSourceRefresh, Sys.wParam, Sys.lParam);
						}
					}
					this.bAddressType = false;
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


        
        private void frmOwnerInfo_OnPM_DataRecordDuplicate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate, Sys.wParam, Sys.lParam))
            {
                if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                {
                    if (this.dfsAssociationNo.Text != Sys.STRING_Null)
                    {
                        Sal.SetFocus(this.dfsAssociationNo);
                        Sal.SendMsg(this.dfsAssociationNo, Sys.SAM_Validate, Sys.wParam, Sys.lParam);
                    }
                }
                e.Return = true;
                return;
            }
            e.Return = false;
            return;
            #endregion
        }

        private void frmOwnerInfo_OnPM_DataRecordPaste(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordPaste, Sys.wParam, Sys.lParam))
            {
                if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                {
                    if (this.dfsAssociationNo.Text != Sys.STRING_Null)
                    {
                        Sal.SetFocus(this.dfsAssociationNo);
                        Sal.SendMsg(this.dfsAssociationNo, Sys.SAM_Validate, Sys.wParam, Sys.lParam);
                    }
                }
                e.Return = true;
                return;
            }
            e.Return = false;
            return;
            #endregion
        }
        

		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void cmbOwnerId_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemNew:
					this.cmbOwnerId_OnPM_DataItemNew(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// PM_DataItemNew event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cmbOwnerId_OnPM_DataItemNew(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemNew, Sys.wParam, Sys.lParam);
			this.cmbOwnerId.EditDataItemSetEdited();
			e.Return = true;
			return;
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dfsAssociationNo_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Validate:
					this.dfsAssociationNo_OnSAM_Validate(sender, e);
					break;
				
				case Sys.SAM_AnyEdit:
					this.dfsAssociationNo_OnSAM_AnyEdit(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Validate event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfsAssociationNo_OnSAM_Validate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (this.bAssociationNoEdited) 
			{
				if (this.CheckAssociationNumber()) 
				{
					this.bAssociationNoEdited = false;
					e.Return = Sys.VALIDATE_Ok;
					return;
				}
				else
				{
					e.Return = Sys.VALIDATE_Cancel;
					return;
				}
			}
			e.Return = Sys.VALIDATE_Ok;
			return;
			#endregion
		}
		
		/// <summary>
		/// SAM_AnyEdit event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfsAssociationNo_OnSAM_AnyEdit(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.bAssociationNoEdited = true;
			e.Return = Sal.SendClassMessage(Sys.SAM_AnyEdit, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
		#endregion
		
		#region Late Bind Methods
		
		/// <summary>
		/// Virtual wrapper replacement for late-bound (..) calls.
		/// </summary>
		public override SalBoolean vrtDataSourceSaveCheck()
		{
			return this.DataSourceSaveCheck();
		}
		
		/// <summary>
		/// Virtual wrapper replacement for late-bound (..) calls.
		/// </summary>
		public override SalBoolean vrtDataSourceSaveCheckOk()
		{
			return this.DataSourceSaveCheckOk();
		}
		
		/// <summary>
		/// Virtual wrapper replacement for late-bound (..) calls.
		/// </summary>
		public override SalBoolean vrtFrameStartupUser()
		{
			return this.FrameStartupUser();
		}
		
		/// <summary>
		/// Virtual wrapper replacement for late-bound (..) calls.
		/// </summary>
		public override SalBoolean vrtTabActivateStart(SalWindowHandle hWnd, SalNumber nTab)
		{
			return this.TabActivateStart(hWnd, nTab);
		}
		#endregion
		
	}
}
