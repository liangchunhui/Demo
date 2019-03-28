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
// DATE        BY        NOTES
// YY-MM-DD
// 09-08-19    GADALK    Bug 84163, Modified UM_Ok, get the global value of the invoker.
// 10-07-01    NIFELK    Bug 91107, Corrected in UM_Ok.
// 13-11-18    Pratlk    PBFI-2514, Refactor client windows in component ENTERP.
// 14-02-27    Shedlk    PBFI-5565, Merged LCS bug 115389

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
	/// <param name="p_hWndInvoker"></param>
	[FndWindowRegistration("COMPANY_FINANCE", "CompanyFinance")]
	public partial class dlgChangeCompanyFin : cDialogBox
	{
		#region Window Parameters
		public SalWindowHandle p_hWndInvoker;
		#endregion
		
		#region Window Variables
		public SalString sGlobalCompany = "";
		public SalString sDefaultCompany = "";
		public SalString sPreviousCompany = "";
		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
        public dlgChangeCompanyFin()
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
		public static SalNumber ModalDialog(Control owner, SalWindowHandle p_hWndInvoker)
		{
            dlgChangeCompanyFin dlg = DialogFactory.CreateInstance<dlgChangeCompanyFin>();
            dlg.p_hWndInvoker = p_hWndInvoker;
			SalNumber ret = dlg.ShowDialog(owner);
			return ret;
		}
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public new static dlgChangeCompanyFin FromHandle(SalWindowHandle handle)
		{
			return ((dlgChangeCompanyFin)SalWindow.FromHandle(handle, typeof(dlgChangeCompanyFin)));
		}
		#endregion
		
		#region Methods
		
		/// <summary>
		/// </summary>
		/// <param name="nWhat"></param>
		/// <param name="sMethod"></param>
		/// <returns></returns>
		public new SalNumber UserMethod(SalNumber nWhat, SalString sMethod)
		{
			#region Actions
			using (new SalContext(this))
			{
				if (sMethod == "Ok") 
				{
					return UM_Ok(nWhat);
				}
				else if (sMethod == "Default") 
				{
					return UM_Default(nWhat);
				}
				else if (sMethod == "Cancel") 
				{
					return UM_Cancel(nWhat);
				}
				else
				{
					return 0;
				}
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber GetGlobalCompany()
		{
			#region Actions
			using (new SalContext(this))
			{
                if (p_hWndInvoker != SalWindowHandle.Null)
                {
                    cSessionManager.FromHandle(p_hWndInvoker).UserGlobalValueGet("COMPANY", ref sGlobalCompany);
                }
                else
                {
                    UserGlobalValueGet("COMPANY", ref sGlobalCompany);
                }
				Sal.SetWindowText(dfsCompany, sGlobalCompany);
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public new SalBoolean FrameStartupUser()
		{
			#region Actions
			using (new SalContext(this))
			{
				GetGlobalCompany();
				GetDefaultCompany();
				if (Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0)) 
				{
					tblChangeCompany_MarkDefaultCompany(sGlobalCompany);
					return true;
				}
				return false;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber GetDefaultCompany()
		{
			#region Actions
			using (new SalContext(this))
			{
				using(SignatureHints hints = SignatureHints.NewContext())
				{
					hints.Add("User_Finance_API.Get_Default_Company", System.Data.ParameterDirection.Output);
					if (!(DbPLSQLBlock(cSessionManager.c_hSql, "&AO.User_Finance_API.Get_Default_Company(:i_hWndFrame.dlgChangeCompanyFin.sDefaultCompany )"))) 
					{
						return false;
					}
				}
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber SetWindowTitle()
		{
			#region Actions
			using (new SalContext(this))
			{
				if (p_hWndInvoker == SalWindowHandle.Null) 
				{
					Sal.SetWindowText(i_hWndSelf, Properties.Resources.WH_dlgChangeGlobalCompany);
				}
				else
				{
					Sal.SetWindowText(i_hWndSelf, Properties.Resources.WH_dlgChangeCompany);
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
			#region Local Variables
			SalString sNewValue = "";
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				switch (nWhat)
				{
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
						return true;
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
						if (p_hWndInvoker == SalWindowHandle.Null) 
						{
							_UserProfileCurrentSet("COMPANY", sGlobalCompany);
						}
						else
						{
                            // We should get the global value of the invoker.
                            cSessionManager.FromHandle(p_hWndInvoker).UserGlobalValueGet("COMPANY", ref sPreviousCompany);
							if (sPreviousCompany != sGlobalCompany) 
							{
                                if (Sal.WindowIsDerivedFromClass(p_hWndInvoker, typeof(cTabDialog)) || Sal.WindowIsDerivedFromClass(p_hWndInvoker, typeof(cDialogBox)))
							    {
								    Sal.SendMsg(p_hWndInvoker, Ifs.Fnd.ApplicationForms.Const.AM_UserProfileValueSet, 0, ("COMPANY^" + sGlobalCompany).ToHandle());
								    Sal.SendMsg(p_hWndInvoker, Ifs.Fnd.ApplicationForms.Const.PM_UserProfileChanged, 0, ("COMPANY" + ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_US).ToCharacter() + sGlobalCompany + ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_RS).ToCharacter()).ToHandle());
							    }                            
                                // The Change Company functionality has been implemented in such a way that the top level window gets cleared. However since tbwCreditCollectionInfo is used within a tab and called from the navigator as well
                                // the following code has been added to solve the top level window getting cleared only for tbwCreditCollectionInfo window.
                                else if ((p_hWndInvoker.GetName() == Pal.GetActiveInstanceName("tbwCreditCollectionInfo")) && (cDataSource.FromHandle(p_hWndInvoker).i_hWndTopFrame != p_hWndInvoker))
                                {
                                    Sal.SendMsg(p_hWndInvoker, Ifs.Fnd.ApplicationForms.Const.AM_UserProfileValueSet, 0, ("COMPANY^" + sGlobalCompany).ToHandle());
                                    Sal.SendMsg(p_hWndInvoker, Ifs.Fnd.ApplicationForms.Const.PM_UserProfileChanged, 0, ("COMPANY" + ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_US).ToCharacter() + sGlobalCompany + ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_RS).ToCharacter()).ToHandle());
                                }
							    else
							    {
								    // Leave the invoker window as it is and navigate to a "clean" version of the window with the new company
								    SalString sURL = Sal.NumberToHString(p_hWndInvoker.SendMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceConstructBaseURL, 0, 0));
								    if (sURL != Ifs.Fnd.ApplicationForms.Const.strNULL)
								    {
									    fcURL URL = new fcURL(sURL);
									    URL.iParameters.SetAttribute("COMPANY", sGlobalCompany);
									    URL.Go();
								    }
							    }
							}
						}
						Sal.EndDialog(this, Sys.IDOK);
						break;
				}
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nWhat"></param>
		/// <returns></returns>
		public virtual SalNumber UM_Default(SalNumber nWhat)
		{
			#region Actions
			using (new SalContext(this))
			{
				switch (nWhat)
				{
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
						if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("USER_FINANCE_API.Get_Default_Company"))) 
						{
							return false;
						}
						return true;
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
						tblChangeCompany_MarkDefaultCompany(sDefaultCompany);
						return true;
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
						return true;
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
						Sal.EndDialog(this, Sys.IDCANCEL);
						break;
				}
			}

			return 0;
			#endregion
		}
		#endregion

        #region ChildTable - tblChangeCompany

            #region Methods

            /// <summary>
            /// </summary>
            /// <param name="sColCompany"></param>
            /// <returns></returns>
            public virtual SalNumber tblChangeCompany_MarkDefaultCompany(SalString sColCompany)
            {
                #region Local Variables
                SalNumber nRow = 0;
                SalNumber nCurrent = 0;
                SalNumber nStart = 0;
                SalBoolean bTemp = false;
                #endregion

                #region Actions
                using (new SalContext(this))
                {
                    Sal.TblClearSelection(tblChangeCompany);
                    bTemp = true;
                    nStart = 0;
                    while (bTemp)
                    {
                        nRow = Vis.TblFindString(tblChangeCompany, nStart, tblChangeCompany_colsCompany, sColCompany);
                        if (nRow < 0)
                        {
                            Ifs.Fnd.ApplicationForms.Var.Console.Add("Default company: " + sColCompany + " not found in current list, re-populate source");
                            tblChangeCompany.DataSourcePopulateIt(Ifs.Fnd.ApplicationForms.Const.POPULATE_KeepFocus);
                            nRow = Vis.TblFindString(tblChangeCompany, nStart, tblChangeCompany_colsCompany, sColCompany);
                            if (nRow < 0)
                            {
                                // If the default company is not found after re-populate then quit the method. This should not happen (unless the user has been removed from the company)
                                bTemp = false;
                            }
                        }
                        Sal.TblSetContext(tblChangeCompany, nRow);
                        if (tblChangeCompany_colsCompany.Text == sColCompany)
                        {
                            Sal.TblSetFocusRow(tblChangeCompany, nRow);
                            tblChangeCompany_colsSelectGlobal.Text = "TRUE";
                            this.sGlobalCompany = tblChangeCompany_colsCompany.Text;
                            this.dfsCompany.Text = tblChangeCompany_colsCompany.Text + " - " + tblChangeCompany_colsDescription.Text;
                            ClearChecked();
                            bTemp = false;
                        }
                        else
                        {
                            nStart = nRow + 1;
                        }
                    }
                }

                return 0;
                #endregion
            }

            /// <summary>
            /// Clear all Select checkbox
            /// </summary>
            /// <returns></returns>
            public virtual SalNumber ClearChecked()
            {
                #region Local Variables
                SalNumber nRow = 0;
                SalNumber nCurrentRow = 0;
                #endregion

                #region Actions
                using (new SalContext(this))
                {
                    nCurrentRow = Sal.TblQueryContext(tblChangeCompany);
                    nRow = Sys.TBL_MinRow;
                    while (true)
                    {
                        if (Sal.TblFindNextRow(tblChangeCompany, ref nRow, 0, 0))
                        {
                            Sal.TblSetContext(tblChangeCompany, nRow);
                            if (nCurrentRow != nRow)
                            {
                                if (tblChangeCompany_colsSelectGlobal.Text == "TRUE")
                                {
                                    tblChangeCompany_colsSelectGlobal.Text = "FALSE";
                                    Sal.TblSetRowFlags(tblChangeCompany, nRow, Sys.ROW_Edited, 0);
                                }
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    Sal.TblSetContext(tblChangeCompany, nCurrentRow);
                }

                return 0;
                #endregion
            }

            #endregion

            #region Window Actions

            /// <summary>
            /// Window Actions
            /// </summary>
            /// <param name="sender">The source of the event.</param>
            /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
            private void colsSelectGlobal_WindowActions(object sender, WindowActionsEventArgs e)
            {
                #region Actions
                switch (e.ActionType)
                {
                    case Sys.SAM_AnyEdit:
                        this.colsSelectGlobal_OnSAM_AnyEdit(sender, e);
                        break;
                }
                #endregion
            }

            /// <summary>
            /// SAM_AnyEdit event handler.
            /// </summary>
            /// <param name="message"></param>
            private void colsSelectGlobal_OnSAM_AnyEdit(object sender, WindowActionsEventArgs e)
            {
                #region Actions
                e.Handled = true;
                if (this.tblChangeCompany_colsSelectGlobal.Text == "FALSE")
                {
                    this.tblChangeCompany_colsSelectGlobal.Text = "TRUE";
                }
                else
                {
                    this.sGlobalCompany = this.tblChangeCompany_colsCompany.Text;
                    this.ClearChecked();
                }
                // Class message is not returned to avoid the state of the datasource from getting dirty.
                #endregion
            }
            #endregion

        #endregion

        #region Window Actions

        /// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dlgChangeCompanyFin_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Create:
					this.dlgChangeCompanyFin_OnSAM_Create(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Create event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dlgChangeCompanyFin_OnSAM_Create(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam);
			Sal.CenterWindow(this);
			Sal.TblSetTableFlags(this.tblChangeCompany, Sys.TBL_Flag_SingleSelection, true);
			Sal.TblSetTableFlags(this.tblChangeCompany, Sys.TBL_Flag_MovableCols, false);
			this.SetWindowTitle();
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
