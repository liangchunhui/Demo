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
// 120403   Hiralk  EASTRTM-3059, Merged bug 101459
// 140401   Machlk  PBFI-5564 Merged Bug 115353
// 140401   Kagalk  PBFI-4142, Merged Bug 113712, Modified to give a warning when deleting the last address type.
// 140409   Ajpelk  PBFI-4140, Merged Bug 112894, Added TabActivateFinish()
#endregion

using System.Windows.Forms;
using Ifs.Fnd.ApplicationForms;
using PPJ.Runtime;
using PPJ.Runtime.Windows;

namespace Ifs.Application.Enterp
{
	
	/// <summary>
	/// </summary>
	[FndWindowRegistration("TAX_OFFICE_INFO", "TaxOfficeInfo", FndWindowRegistrationFlags.HomePage)]
	public partial class frmTaxOfficeInfo : cMasterDetailTabFormWindow
	{
		#region Window Variables
		public SalString sFullFormName = "";
		public SalString sCommMethodTabActive = "";
		public SalString sAddressTabActive = "";
		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		public frmTaxOfficeInfo()
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
		public new static frmTaxOfficeInfo FromHandle(SalWindowHandle handle)
		{
			return ((frmTaxOfficeInfo)SalWindow.FromHandle(handle, typeof(frmTaxOfficeInfo)));
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public new SalBoolean DataSourceSaveCheckOk()
		{
			#region Local Variables
			SalWindowHandle hWndAddress = SalWindowHandle.Null;
			SalWindowHandle hWndCommMethod = SalWindowHandle.Null;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				hWndAddress = TabAttachedWindowHandleGet(picTab.FindName("Name1"));
				hWndCommMethod = TabAttachedWindowHandleGet(picTab.FindName("Name2"));
				if (sAddressTabActive == "TRUE") 
				{
					if (Sal.SendMsg(frmTaxOfficeInfoAddress.FromHandle(hWndAddress).tblCommMethod, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceIsDirty, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam)) 
					{
						if (!(frmTaxOfficeInfoAddress.FromHandle(hWndAddress).tblCommMethod.CheckDefault())) 
						{
							return false;
						}
					}
				}
				if (sCommMethodTabActive == "TRUE") 
				{
					if (Sal.SendMsg(frmTaxOfficeInfoCommMethod.FromHandle(hWndCommMethod).tblCommMethod, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceIsDirty, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam)) 
					{
						if (!(frmTaxOfficeInfoCommMethod.FromHandle(hWndCommMethod).tblCommMethod.CheckDefault())) 
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
                if (sName == "Name1")
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
				hWndAddress = TabAttachedWindowHandleGet(picTab.FindName("Name1"));
				if (sAddressTabActive == "TRUE") 
				{
					if (((bool)Sal.SendMsg(frmTaxOfficeInfoAddress.FromHandle(hWndAddress).tblAddressType, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceIsDirty, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam)) || (Sal.QueryFieldEdit(frmTaxOfficeInfoAddress.FromHandle(hWndAddress).dfdValidFrom) || 
					Sal.QueryFieldEdit(frmTaxOfficeInfoAddress.FromHandle(hWndAddress).dfdValidTo))) 
					{
                        if (!(frmTaxOfficeInfoAddress.FromHandle(hWndAddress).CheckDefaultAddress())) 
						{
							return false;
						}
                        if (!(frmTaxOfficeInfoAddress.FromHandle(hWndAddress).CheckLastAddressType()))
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
                    Sal.SetFocus(frmTaxOfficeInfoCommMethod.FromHandle(hWndInfoCommMethod).tblCommMethod);
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
		private void frmTaxOfficeInfo_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Create:
					this.frmTaxOfficeInfo_OnSAM_Create(sender, e);
					break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave:
                    this.frmTaxOfficeInfo_OnPM_DataSourceSave(sender, e);
                    break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Create event handler.
		/// </summary>
		/// <param name="message"></param>
		private void frmTaxOfficeInfo_OnSAM_Create(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam);
			this.sFullFormName = ":i_hWndFrame." + Ifs.Fnd.ApplicationForms.Int.QualifiedItemNameGet(this);
			#endregion
		}

        /// <summary>
        /// PM_DataSourceSave event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmTaxOfficeInfo_OnPM_DataSourceSave(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Sys.wParam, Sys.lParam))
            {
                if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                {
                    Sal.SendMsg(this.TabAttachedWindowHandleGet(this.picTab.FindName("Name1")), Const.PAM_DetailAddress, 0, 0);
                }
                e.Return = true;
                return;
            }
            e.Return = false;
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
		public override SalBoolean vrtTabActivateStart(SalWindowHandle hWnd, SalNumber nTab)
		{
			return this.TabActivateStart(hWnd, nTab);
		}
		#endregion
	}
}
