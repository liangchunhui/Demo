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
// Date     By      Comment
// -------  ------- -------------------------------------------------------------------------------------
// 120803  Umdolk  EDEL-1259, when launching the notes dialog from Latest note column in payled, written logic to select the latest notes.
// 131118  Pratlk  PBFI-2516, Refactor client windows in component ENTERP
// 141120  Chgulk  PRFI-3644, Merged LCS patch 119778.
// 150609  Kagalk  Bug 122748, Modified to restrict creating notes by different users at the same time.
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
	public partial class dlgNotes : cDialogBox
	{
		#region Window Variables
		public SalString sCompany = "";
		public SalString sFndUser = "";
		public SalString sFullName = "";
		public SalString sPackage = "";
		public SalString sKeyAttr = "";
		public SalString sPackageName = "";
		public SalString sWindowTitle = "";
		public SalNumber nPayledInstalled = 0;
		public SalNumber nNoteId = 0;
		public SalNumber nNoteIdTemp = 0;
		public SalNumber nNewNoteId = 0;
		public SalNumber nRowCount = 0;
		public SalNumber nNumRowsRemoved = 0;
		public SalWindowHandle hWndFocusCell = SalWindowHandle.Null;
        public SalString sOpenedFromLastNote = "";
        public SalNumber nExistingNoteId = 0;
		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		protected dlgNotes()
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
			dlgNotes dlg = DialogFactory.CreateInstance<dlgNotes>();
			SalNumber ret = dlg.ShowDialog(owner);
			return ret;
		}
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public new static dlgNotes FromHandle(SalWindowHandle handle)
		{
			return ((dlgNotes)SalWindow.FromHandle(handle, typeof(dlgNotes)));
		}
		#endregion
		
		#region Methods
		
		/// <summary>
		/// Receive data at window startup
		/// </summary>
		/// <returns></returns>
		public new SalBoolean FrameStartupUser()
		{
			#region Actions
			using (new SalContext(this))
			{
				Populate();
				SetWindowTitle();
                if (sOpenedFromLastNote == "TRUE")
                {                     
                    Sal.TblClearSelection(tblNotes);
                    Sal.TblSetContext(tblNotes,nRowCount - 1);
                    Sal.TblSetFocusRow(tblNotes, nRowCount - 1);
                    this.tblNotes.SetFocusCell(nRowCount - 1, this.tblNotes_colText, 0, 0);                                        
                }           
                
				return true;
			}
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
				sCompany = Ifs.Fnd.ApplicationForms.Int.PalAttrGet("COMPANY", sKeyAttr);
				Sal.SetWindowText(this, sCompany + " - " + sWindowTitle);
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber InvestigateButtons()
		{
			#region Actions
			using (new SalContext(this))
			{
				pbNew.MethodInvestigateState();
				pbSave.MethodInvestigateState();
				pbRemove.MethodInvestigateState();
				pbOk.MethodInvestigateState();
			}

			return 0;
			#endregion
		}
		
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
				else if (sMethod == "Close") 
				{
					return UM_Cancel(nWhat);
				}
				else if (sMethod == "New") 
				{
					return UM_New(nWhat);
				}
				else if (sMethod == "Remove") 
				{
					return UM_Remove(nWhat);
				}
				else if (sMethod == "Save") 
				{
					return UM_Save(nWhat);
				}
				return false;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nWhat"></param>
		/// <returns></returns>
		public virtual SalBoolean UM_Ok(SalNumber nWhat)
        {
            #region Local Variables
            SalBoolean bRemove = false;
            #endregion

            #region Actions
            using (new SalContext(this))
			{
				switch (nWhat)
				{
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
						return true;
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
						if (Sal.SendMsg(tblNotes, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0)) 
						{
							switch (DataSourceInquireSave())
							{
								case Sys.IDCANCEL:
									return false;
								
								case Sys.IDYES:
									if (CheckNoteText()) 
									{
										if (nNoteIdTemp == SalNumber.Null) 
										{
                                            if (!CreateNote())
                                            {
                                                return false;
                                            }
											nNoteIdTemp = nNoteId;
										}
                                        bRemove = true;
									}
									if (Sal.SendMsg(tblNotes, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0)) 
									{
                                        if (bRemove)
                                            RemoveNote();
										return Sal.EndDialog(this, 1);
									}
									return false;
								
								case Sys.IDNO:
									return Sal.EndDialog(this, 0);
							}
						}
						else
						{
							return Sal.EndDialog(this, Ifs.Fnd.ApplicationForms.Var.bReturn);
						}
						break;
				}
			}

			return false;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nWhat"></param>
		/// <returns></returns>
		public virtual SalBoolean UM_Cancel(SalNumber nWhat)
		{
			#region Actions
			using (new SalContext(this))
			{
				switch (nWhat)
				{
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
						return true;
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
						return Sal.EndDialog(this, Ifs.Fnd.ApplicationForms.Var.bReturn);
				}
			}

			return false;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nWhat"></param>
		/// <returns></returns>
		public virtual SalBoolean UM_New(SalNumber nWhat)
		{
			#region Local Variables
			SalBoolean bOk = false;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				switch (nWhat)
				{
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
						return Sal.SendMsg(tblNotes, Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, nWhat, 0);
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
						bOk = Sal.SendMsg(tblNotes, Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, nWhat, 0);
						InvestigateButtons();
						return bOk;
				}
			}

			return false;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nWhat"></param>
		/// <returns></returns>
		public virtual SalBoolean UM_Remove(SalNumber nWhat)
		{
			#region Local Variables
			SalBoolean bOk = false;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				switch (nWhat)
				{
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
						return Sal.SendMsg(tblNotes, Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove, nWhat, 0);
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
						bOk = Sal.SendMsg(tblNotes, Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove, nWhat, 0);
						GetMarkDeletedCount();
						GetRowCount();
						InvestigateButtons();
						return bOk;
				}
			}

			return false;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nWhat"></param>
		/// <returns></returns>
		public virtual SalBoolean UM_Save(SalNumber nWhat)
		{
			#region Local Variables
            SalBoolean bOk = false;
            SalBoolean bRemove = false;
            #endregion
			
			#region Actions
			using (new SalContext(this))
			{
				switch (nWhat)
				{
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
						return Sal.SendMsg(tblNotes, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, nWhat, 0);
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
						if (CheckNoteText()) 
						{
							if (nNoteIdTemp == SalNumber.Null) 
							{								
                                if (!CreateNote())
                                {
                                    return false;
                                }
								nNoteIdTemp = nNoteId;
							}
                            bRemove = true;
						}
						bOk = Sal.SendMsg(tblNotes, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, nWhat, 0);
                        if (bOk && bRemove)
							RemoveNote();
						InvestigateButtons();
						return bOk;
				}
			}

			return false;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean Populate()
		{
			#region Actions
			using (new SalContext(this))
			{
				GetNoteId();
				nNoteIdTemp = nNoteId;
				DataSourcePopulateIt(Ifs.Fnd.ApplicationForms.Const.POPULATE_Single);
				GetRowCount();
                
				return true;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean ReceiveData()
		{
			#region Local Variables
			SalString sRS = "";
			SalString sParameters = "";
			SalArray<SalString> sArray = new SalArray<SalString>();
			SalNumber nPos = 0;
			SalNumber nLength = 0;
			SalNumber nIndex = 0;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.RecCountGet() > 0) 
				{
					sRS = ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_RS).ToCharacter();
					Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemValueStrGet(Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemIndexGet("NotesData"), 0, ref sParameters);
					nIndex = 0;
					while (sParameters != Ifs.Fnd.ApplicationForms.Const.strNULL) 
					{
						nLength = sParameters.Length;
						if (nIndex != 2) 
						{
							nPos = sParameters.Scan(sRS);
							sArray[nIndex] = sParameters.Left(nPos);
							sParameters = sParameters.Mid(nPos + 1, nLength - nPos - 1);
						}
						else
						{
							sArray[nIndex] = sParameters.Left(nLength);
							sParameters = Ifs.Fnd.ApplicationForms.Const.strNULL;
						}
						nIndex = nIndex + 1;
					}
					sPackageName = sArray[0];
					sWindowTitle = sArray[1];
					sKeyAttr = sArray[2];
                    sOpenedFromLastNote = Ifs.Fnd.ApplicationForms.Int.PalAttrGet("OPENNED_FROM_LAST_NOTE", sKeyAttr);
				}
				Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
				return true;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean GetNoteId()
		{
			#region Actions
			using (new SalContext(this))
			{
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add(sPackageName + ".Get_Note_Id", System.Data.ParameterDirection.Input);
				return DbPLSQLBlock(cSessionManager.c_hSql, ":i_hWndFrame.dlgNotes.nNoteId := &AO." + sPackageName + ".Get_Note_Id(\r\n" +
					"								:i_hWndFrame.dlgNotes.sKeyAttr)");
                } 
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean GetNewNoteId()
		{
			#region Actions
			using (new SalContext(this))
			{
				return DbPLSQLBlock(cSessionManager.c_hSql, ":i_hWndFrame.dlgNotes.nNewNoteId := &AO.Fin_Note_API.Get_New_Note_Id");
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean CreateNote()
		{
			#region Actions
			using (new SalContext(this))
			{
                this.nExistingNoteId = SalNumber.Null;
                if (DbPLSQLTransaction(cSessionManager.c_hSql, @"BEGIN                                                                  
                                                                    :i_hWndFrame.dlgNotes.nExistingNoteId := &AO." + sPackageName + @".Get_Note_Id(:i_hWndFrame.dlgNotes.sKeyAttr IN);
                                                                    IF (:i_hWndFrame.dlgNotes.nExistingNoteId IS NULL) THEN                                                                   
                                                                       &AO.Fin_Note_API.Create_Note(:i_hWndFrame.dlgNotes.nNoteId IN); 
                    					                               &AO." + sPackageName + @".Create_Note(:i_hWndFrame.dlgNotes.nNoteId IN,
                    					                                                                     :i_hWndFrame.dlgNotes.sKeyAttr IN);                                                                 
                                                                    END IF;                                                                
                    			                                 END;"))
                {
                    if (nExistingNoteId != SalNumber.Null && nNoteId != nExistingNoteId)
                    {
                        Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.ERROR_NotesExist, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Warning, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                        return false;
                    }
                    return true;
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
		/// <returns></returns>
		public virtual SalBoolean RemoveNote()
		{
			#region Local Variables
			SalBoolean bOk = false;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				if (nNumRowsRemoved > 0) 
				{
					if (nNumRowsRemoved == nRowCount) 
					{
						using(SignatureHints hints = SignatureHints.NewContext())
						{
							hints.Add("Fin_Note_API.Remove_Note", System.Data.ParameterDirection.Input);
							bOk = DbPLSQLTransaction(cSessionManager.c_hSql, "BEGIN\r\n" +
								"\r\n					&AO." + sPackageName + ".Remove_Note(\r\n" +
								"					:i_hWndFrame.dlgNotes.nNoteId,\r\n" +
								"					:i_hWndFrame.dlgNotes.sKeyAttr);\r\n" +
                                "					&AO.Fin_Note_API.Remove_Note(\r\n" +
                                "					:i_hWndFrame.dlgNotes.nNoteId);\r\n" +
                                "				   END;");
						}
						nRowCount = 0;
						nNumRowsRemoved = 0;
						nNoteId = SalNumber.Null;
						nNoteIdTemp = SalNumber.Null;
						return bOk;
					}
				}
				return false;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber GetRowCount()
		{
			#region Local Variables
			SalNumber nRow = 0;
			SalBoolean bFlag = false;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				nRow = Sys.TBL_MinRow;
				nRowCount = 0;
				while (Sal.TblFindNextRow(tblNotes, ref nRow, 0, 0)) 
				{
					Sal.TblSetContext(tblNotes, nRow);
					nRowCount = nRowCount + 1;
				}
				bFlag = Sal.TblSetRow(tblNotes, Sys.TBL_SetFirstRow);
			}
            

			return 0;
			#endregion
		}
		
		/// <summary>
		/// Get the current logging user info
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean GetFndUser()
		{
			#region Actions
			using (new SalContext(this))
			{
				sFndUser = Ifs.Fnd.ApplicationForms.Int.FndUser();
				return true;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber GetMarkDeletedCount()
		{
			#region Local Variables
			SalNumber nRow = 0;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				nRow = Sys.TBL_MinRow;
				nNumRowsRemoved = 0;
				while (Sal.TblFindNextRow(tblNotes, ref nRow, Sys.ROW_MarkDeleted, 0)) 
				{
					Sal.TblSetContext(tblNotes, nRow);
					nNumRowsRemoved = nNumRowsRemoved + 1;
				}
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean CheckDelete()
		{
			#region Local Variables
			SalNumber nRow = 0;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				nRow = Sys.TBL_MinRow;
				while (Sal.TblFindNextRow(tblNotes, ref nRow, Sys.ROW_Selected, 0)) 
				{
					Sal.TblSetContext(tblNotes, nRow);
					if (tblNotes_colsUserId.Text != sFndUser) 
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
		public virtual SalBoolean CheckNoteText()
		{
			#region Actions
			using (new SalContext(this))
			{
				if (tblNotes_colText.Text == Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					return false;
				}
				return true;
			}
			#endregion
		}
		#endregion

        #region ChildTable - tblNotes

            #region Methods

            /// <summary>
            /// The framework calls the DataRecordGetDefaults function to retrive
            /// client default values for new records.
            /// </summary>
            /// <returns></returns>
            public virtual SalBoolean DataRecordGetDefaults()
            {
                #region Actions
                using (new SalContext(tblNotes))
                {
                    if (this.nNoteId == SalNumber.Null)
                    {
                        this.GetNewNoteId();
                        tblNotes_colnNoteId.Number = this.nNewNoteId;
                        tblNotes_colnNoteId.EditDataItemSetEdited();
                        this.nNoteId = this.nNewNoteId;
                    }
                    else
                    {
                        tblNotes_colnNoteId.Number = this.nNoteId;
                        tblNotes_colnNoteId.EditDataItemSetEdited();
                    }
                    return true;
                }
                #endregion
            }
            #endregion

            #region Window Actions

            /// <summary>
            /// Window Actions
            /// </summary>
            /// <param name="sender">The source of the event.</param>
            /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
            private void colText_WindowActions(object sender, WindowActionsEventArgs e)
            {
                #region Actions
                switch (e.ActionType)
                {
                    case Sys.SAM_SetFocus:
                        this.colText_OnSAM_SetFocus(sender, e);
                        break;

                    case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                        this.colText_OnPM_DataItemQueryEnabled(sender, e);
                        break;
                }
                #endregion
            }

            /// <summary>
            /// SAM_SetFocus event handler.
            /// </summary>
            /// <param name="message"></param>
            private void colText_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
            {
                #region Actions
                e.Handled = true;
                if (Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam))
                {
                    if (Sal.SendMsg(i_hWndFrame, Ifs.Fnd.ApplicationForms.Const.PM_User, 1, 0))
                    {
                        Sal.EnableWindow(this.pbRemove);
                    }
                    else
                    {
                        Sal.DisableWindow(this.pbRemove);
                    }
                }
                e.Return = true;
                return;
                #endregion
            }

            /// <summary>
            /// PM_DataItemQueryEnabled event handler.
            /// </summary>
            /// <param name="message"></param>
            private void colText_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
            {
                #region Actions
                e.Handled = true;
                if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled, Sys.wParam, Sys.lParam))
                {
                    if (Sal.SendMsg(i_hWndFrame, Ifs.Fnd.ApplicationForms.Const.PM_User, 1, 0))
                    {
                        e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldEnabled;
                        return;
                    }
                    else
                    {
                        e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                        return;
                    }
                }
                e.Return = true;
                return;
                #endregion
            }
            #endregion

            #region Event Handlers

            private void tblNotes_DataRecordGetDefaultsEvent(object sender, FndReturnEventArgsSalBoolean e)
            {
                e.Handled = true;
                e.ReturnValue = this.DataRecordGetDefaults();
            }

            #endregion

        #endregion

        #region Window Actions

        /// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dlgNotes_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Create:
					this.dlgNotes_OnSAM_Create(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_User:
					this.dlgNotes_OnPM_User(sender, e);
					break;

                case Sys.SAM_Close:
                    this.dlgNotes_OnSAM_Close(sender, e);
                    break; 
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Create event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dlgNotes_OnSAM_Create(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam);
			Sal.CenterWindow(this.i_hWndFrame);
			this.ReceiveData();
			this.GetFndUser();
			#endregion
		}
		
		/// <summary>
		/// PM_User event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dlgNotes_OnPM_User(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sys.wParam == 1) 
			{
				if (this.sFndUser == this.tblNotes_colsUserId.Text) 
				{
					e.Return = true;
					return;
				}
			}
			e.Return = false;
			return;
			#endregion
		}

        /// <summary>
        /// SAM_Create event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dlgNotes_OnSAM_Close(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            e.Return = UM_Ok(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
            return;
            #endregion
        }
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void tblNotes_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemEntered:
					this.tblNotes_OnPM_DataItemEntered(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew:
					this.tblNotes_OnPM_DataRecordNew(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove:
					this.tblNotes_OnPM_DataRecordRemove(sender, e);
					break;
				
				case Sys.SAM_RowSetContext:
					this.tblNotes_OnSAM_RowSetContext(sender, e);
					break;                
			}
			#endregion
		}

        
		
		/// <summary>
		/// PM_DataItemEntered event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblNotes_OnPM_DataItemEntered(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.hWndFocusCell = Sys.wParam.ToWindowHandle();
			Sal.PostMsg(this.tblNotes, Ifs.Fnd.ApplicationForms.Const.PM_User, 1, 0); // Store focus
			#endregion
		}
		
		/// <summary>
		/// PM_DataRecordNew event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblNotes_OnPM_DataRecordNew(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
			{
				this.nRowCount = this.nRowCount + 1;
			}
			e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
		
		/// <summary>
		/// PM_DataRecordRemove event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblNotes_OnPM_DataRecordRemove(object sender, WindowActionsEventArgs e)
        {
            #region Local Variables
            SalBoolean bOk;
            #endregion

            #region Actions
            e.Handled = true;
			if (!(this.CheckDelete())) 
			{
				e.Return = false;
				return;
			}
			bOk = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove, Sys.wParam, Sys.lParam);
			if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
			{
				this.GetMarkDeletedCount();
			}
			e.Return = bOk;
			return;
			#endregion
		}
		
		/// <summary>
		/// SAM_RowSetContext event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblNotes_OnSAM_RowSetContext(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
            if (Sal.SendMsg(i_hWndFrame, Ifs.Fnd.ApplicationForms.Const.PM_User, 1, 0)) 
			{
				Sal.EnableWindow(this.pbRemove);
			}
			else
			{
				Sal.DisableWindow(this.pbRemove);
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
