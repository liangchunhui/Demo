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
// -----    ------  ---------------------------------------------------------
// 131120   Pratlk  PBFI-2517, Refactor client windows in component ENTERP
#endregion

using System.Windows.Forms;
using Ifs.Fnd.ApplicationForms;
using PPJ.Runtime;
using PPJ.Runtime.Windows;

namespace Ifs.Application.Enterp
{
	
	/// <summary>
	/// </summary>
	/// <param name="sCompany"></param>
	/// <param name="sDescription"></param>
	/// <param name="sUpdateId"></param>
	public partial class dlgUpdateCompanySelectLu : cDialogBox
	{
		#region Window Parameters
		public SalString sCompany;
		public SalString sDescription;
		public SalString sUpdateId;
		#endregion
		
		#region Window Variables
		public SalString sCurrentUpdateId = "";
		public SalBoolean bChildUpdated = false;
		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		protected dlgUpdateCompanySelectLu()
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
		public static SalNumber ModalDialog(Control owner, SalString sCompany, SalString sDescription, SalString sUpdateId)
		{
			dlgUpdateCompanySelectLu dlg = DialogFactory.CreateInstance<dlgUpdateCompanySelectLu>();
			dlg.sCompany = sCompany;
			dlg.sDescription = sDescription;
			dlg.sUpdateId = sUpdateId;
			SalNumber ret = dlg.ShowDialog(owner);
			return ret;
		}
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public new static dlgUpdateCompanySelectLu FromHandle(SalWindowHandle handle)
		{
			return ((dlgUpdateCompanySelectLu)SalWindow.FromHandle(handle, typeof(dlgUpdateCompanySelectLu)));
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
				dfCompany.Text = sCompany;
				dfDescription.Text = sDescription;
				sCurrentUpdateId = sUpdateId;
				bChildUpdated = false;
				Sal.SendMsgToChildren(i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
				RefreshButtonState();
				return true;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nWhat"></param>
		/// <param name="sAction"></param>
		/// <returns></returns>
		public new SalNumber UserMethod(SalNumber nWhat, SalString sAction)
		{
			#region Actions
			using (new SalContext(this))
			{
				if (sAction == "OkButton") 
				{
					return UM_Ok(nWhat);
				}
				else if (sAction == "CancelButton") 
				{
					return UM_Cancel(nWhat);
				}
				else if (sAction == "SaveButton") 
				{
					return UM_Save(nWhat);
				}
				else if (sAction == "SelectAll") 
				{
					return UM_SelectAll(nWhat);
				}
				else if (sAction == "UnSelectAll") 
				{
					return UM_UnselectAll(nWhat);
				}
				else
				{
					return false;
				}
			}
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
						return true;
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
						Sal.EndDialog(i_hWndFrame, Sys.IDCANCEL);
						goto case Ifs.Fnd.ApplicationForms.Const.METHOD_GetType;
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_GetType:
						return Ifs.Fnd.ApplicationForms.Const.CHILDTYPE_Any;
				}
			}

			return 0;
			#endregion
		}
		
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
						return bChildUpdated;
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
						if (!(Sal.SendMsg(tblUpdateCompanySelectLu, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0))) 
						{
							return false;
						}
						Sal.EndDialog(i_hWndFrame, Sys.IDOK);
						goto case Ifs.Fnd.ApplicationForms.Const.METHOD_GetType;
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_GetType:
						return Ifs.Fnd.ApplicationForms.Const.CHILDTYPE_Any;
				}
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nWhat"></param>
		/// <returns></returns>
		public virtual SalNumber UM_Save(SalNumber nWhat)
		{
			#region Actions
			using (new SalContext(this))
			{
				switch (nWhat)
				{
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
						return bChildUpdated;
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
						if (!(Sal.SendMsg(tblUpdateCompanySelectLu, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0))) 
						{
							return false;
						}
						return true;
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_GetType:
						return Ifs.Fnd.ApplicationForms.Const.CHILDTYPE_Any;
				}
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nWhat"></param>
		/// <returns></returns>
		public virtual SalNumber UM_SelectAll(SalNumber nWhat)
		{
			#region Local Variables
			SalNumber nRow = 0;
			SalBoolean bUpdated = false;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				switch (nWhat)
				{
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
						bUpdated = false;
						nRow = Sys.TBL_MinRow;
						while (true)
						{
							if (Sal.TblFindNextRow(tblUpdateCompanySelectLu, ref nRow, 0, 0)) 
							{
								Sal.TblSetContext(tblUpdateCompanySelectLu, nRow);
								if (tblUpdateCompanySelectLu_colSelected.Text == "FALSE") 
								{
									tblUpdateCompanySelectLu_colSelected.Text = "TRUE";
									Sal.SetFieldEdit(tblUpdateCompanySelectLu_colSelected, true);
									bUpdated = true;
								}
							}
							else
							{
								break;
							}
						}
						if (bUpdated) 
						{
							bChildUpdated = true;
							RefreshButtonState();
						}
						goto case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire;
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
						nRow = Sys.TBL_MinRow;
						while (true)
						{
							if (Sal.TblFindNextRow(tblUpdateCompanySelectLu, ref nRow, 0, 0)) 
							{
								Sal.TblSetContext(tblUpdateCompanySelectLu, nRow);
								if (tblUpdateCompanySelectLu_colSelected.Text == "FALSE") 
								{
									return true;
								}
							}
							else
							{
								break;
							}
						}
						return false;
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_GetType:
						return Ifs.Fnd.ApplicationForms.Const.CHILDTYPE_Any;
				}
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nWhat"></param>
		/// <returns></returns>
		public virtual SalNumber UM_UnselectAll(SalNumber nWhat)
		{
			#region Local Variables
			SalNumber nRow = 0;
			SalBoolean bUpdated = false;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				switch (nWhat)
				{
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
						bUpdated = false;
						nRow = Sys.TBL_MinRow;
						while (true)
						{
							if (Sal.TblFindNextRow(tblUpdateCompanySelectLu, ref nRow, 0, 0)) 
							{
								Sal.TblSetContext(tblUpdateCompanySelectLu, nRow);
								if (tblUpdateCompanySelectLu_colSelected.Text == "TRUE") 
								{
									tblUpdateCompanySelectLu_colSelected.Text = "FALSE";
									Sal.SetFieldEdit(tblUpdateCompanySelectLu_colSelected, true);
									bUpdated = true;
								}
							}
							else
							{
								break;
							}
						}
						if (bUpdated) 
						{
							bChildUpdated = true;
							RefreshButtonState();
						}
						goto case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire;
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
						nRow = Sys.TBL_MinRow;
						while (true)
						{
							if (Sal.TblFindNextRow(tblUpdateCompanySelectLu, ref nRow, 0, 0)) 
							{
								Sal.TblSetContext(tblUpdateCompanySelectLu, nRow);
								if (tblUpdateCompanySelectLu_colSelected.Text == "TRUE") 
								{
									return true;
								}
							}
							else
							{
								break;
							}
						}
						return false;
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_GetType:
						return Ifs.Fnd.ApplicationForms.Const.CHILDTYPE_Any;
				}
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber RefreshButtonState()
		{
			#region Actions
			using (new SalContext(this))
			{
				pbOk.MethodInvestigateState();
				pbSave.MethodInvestigateState();
				pbSelectAll.MethodInvestigateState();
				pbUnselectAll.MethodInvestigateState();
			}

			return 0;
			#endregion
		}
		#endregion

        #region ChildTable - tblUpdateCompanySelectLu

            #region Window Variables
            public SalBoolean tblUpdateCompanySelectLu_bUpdated = false;
            #endregion

            #region Window Actions

            /// <summary>
            /// Window Actions
            /// </summary>
            /// <param name="sender">The source of the event.</param>
            /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
            private void colSelected_WindowActions(object sender, WindowActionsEventArgs e)
            {
                #region Actions
                switch (e.ActionType)
                {
                    case Sys.SAM_AnyEdit:
                        this.colSelected_OnSAM_AnyEdit(sender, e);
                        break;
                }
                #endregion
            }

            /// <summary>
            /// SAM_AnyEdit event handler.
            /// </summary>
            /// <param name="message"></param>
            private void colSelected_OnSAM_AnyEdit(object sender, WindowActionsEventArgs e)
            {
                #region Actions
                e.Handled = true;
                if (!(Sal.SendClassMessage(Sys.SAM_AnyEdit, Sys.wParam, Sys.lParam)))
                {
                    e.Return = false;
                    return;
                }
                this.tblUpdateCompanySelectLu_bUpdated = true;
                Sal.SendMsg(this.tblUpdateCompanySelectLu_colSelected.i_hWndFrame, Const.PAM_UpdateLuModControl, 0, 0);
                e.Return = true;
                return;
                #endregion
            }
            #endregion

            #region Event Handlers

            private void tblUpdateCompanySelectLu_FrameStartupUserEvent(object sender, FndReturnEventArgsSalBoolean e)
            {
                e.Handled = true;
                tblUpdateCompanySelectLu_bUpdated = false;
                e.ReturnValue = true;
            }

            #endregion

        #endregion
		
		#region Window Actions
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dlgUpdateCompanySelectLu_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Const.PAM_UpdateLuModControl:
					this.dlgUpdateCompanySelectLu_OnPAM_UpdateLuModControl(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// PAM_UpdateLuModControl event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dlgUpdateCompanySelectLu_OnPAM_UpdateLuModControl(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.bChildUpdated = true;
			this.RefreshButtonState();
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void tblUpdateCompanySelectLu_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PAM_User:
					e.Handled = true;
					Sal.SendMsg(this.tblUpdateCompanySelectLu.i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
					break;
			}
			#endregion
		}
		#endregion
		
		#region Late Bind Methods
		
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
		public override SalNumber vrtUserMethod(SalNumber nWhat, SalString sMethod)
		{
			return this.UserMethod(nWhat, sMethod);
		}
		#endregion

	}
}
