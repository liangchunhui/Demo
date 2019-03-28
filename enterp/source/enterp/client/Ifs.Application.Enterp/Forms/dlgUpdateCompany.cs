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
	/// <param name="sCompany"></param>
	/// <param name="sDescription"></param>
	/// <param name="sAccCurr"></param>
	/// <param name="dValidFrom"></param>
	/// <param name="lsAttr"></param>
	/// <param name="lsAttrUpdate"></param>
	[FndWindowRegistration("COMPANY", "Company")]
	public partial class dlgUpdateCompany : cDialogBox
	{
		#region Window Parameters
		public SalString sCompany;
		public SalString sDescription;
		public SalString sAccCurr;
		public SalDateTime dValidFrom;
		public SalString lsAttr;
		public SalString lsAttrUpdate;
		#endregion
		
		#region Window Variables
		public SalString sErrorCreated = "";
		public SalNumber nSteps = 0;
		public SalString sFullName = "";
		public SalString sModuleVariable = "";
		public SalString sPackageNameVariable = "";
		public SalString sCompName = "";
		public SalNumber nExecId = 0;
		public SalWindowHandle hLastWithFocus = SalWindowHandle.Null;
		public SalArray<SalString> sExistingLngs = new SalArray<SalString>();
		public SalString sLanguages = "";
		public SalString sTemplateLng = "";
		public SalString sUpdateId = "";
		public SalString lsAttrSend = "";
		public SalString sSourceCompany = "";
		public SalString sSourceTemplate = "";
		public SalString sOldSourceTemplate = "";
		public SalString sTempSourceTemplate = "";
		public SalString sTempTargetTemplate = "";
		public SalString sDiffTemplate = "";
		public SalString lsDeleteAttr = "";
		public SalArray<SalString> sDiffTemplateForRemove = new SalArray<SalString>();
		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		protected dlgUpdateCompany()
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
		public static SalNumber ModalDialog(Control owner, SalString sCompany, SalString sDescription, SalString sAccCurr, SalDateTime dValidFrom, SalString lsAttr, SalString lsAttrUpdate)
		{
			dlgUpdateCompany dlg = DialogFactory.CreateInstance<dlgUpdateCompany>();
			dlg.sCompany = sCompany;
			dlg.sDescription = sDescription;
			dlg.sAccCurr = sAccCurr;
			dlg.dValidFrom = dValidFrom;
			dlg.lsAttr = lsAttr;
			dlg.lsAttrUpdate = lsAttrUpdate;
			SalNumber ret = dlg.ShowDialog(owner);
			return ret;
		}
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public new static dlgUpdateCompany FromHandle(SalWindowHandle handle)
		{
			return ((dlgUpdateCompany)SalWindow.FromHandle(handle, typeof(dlgUpdateCompany)));
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
				Sal.SendMsg(i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
				dfCompany.Text = sCompany;
				dfCurrencyCode.Text = sAccCurr;
				dfValidFrom.DateTime = dValidFrom;
				dfFromCompany.Text = Ifs.Fnd.ApplicationForms.Int.PalAttrGet("DUPL_COMPANY", lsAttrUpdate);
				dfFromTemplateId.Text = Ifs.Fnd.ApplicationForms.Int.PalAttrGet("TEMPLATE_ID", lsAttrUpdate);
				if (dfFromCompany.Text == Ifs.Fnd.ApplicationForms.Const.strNULL && dfFromTemplateId.Text == Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					cbTemplateAsSource.Checked = true;
					Sal.EnableWindow(dfUpdateTemplateId);
					Sal.EnableWindow(cbDifferenceTemplate);
					Sal.SetFocus(dfUpdateTemplateId);
					Sal.DisableWindow(pbOk);
				}
				else
				{
					Sal.DisableWindow(dfUpdateTemplateId);
					Sal.DisableWindow(cbDifferenceTemplate);
					Sal.SetFocus(pbOk);
				}
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
				if (sAction == "OKButton") 
				{
					switch (nWhat)
					{
						case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
							if (dfFromCompany.Text == Ifs.Fnd.ApplicationForms.Const.strNULL && dfFromTemplateId.Text == Ifs.Fnd.ApplicationForms.Const.strNULL && dfUpdateTemplateId.Text == Ifs.Fnd.ApplicationForms.Const.strNULL) 
							{
								return false;
							}
							return true;
						
						case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
							if (UpdatedCompany()) 
							{
								Sal.EndDialog(i_hWndFrame, Sys.IDOK);
							}
							goto case Ifs.Fnd.ApplicationForms.Const.METHOD_GetType;
						
						case Ifs.Fnd.ApplicationForms.Const.METHOD_GetType:
							return Ifs.Fnd.ApplicationForms.Const.CHILDTYPE_Any;
					}
				}
				if (sAction == "CancelButton") 
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
				if (sAction == "ListButton") 
				{
					switch (nWhat)
					{
						case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
							return Sal.SendMsg(Ifs.Fnd.ApplicationForms.Int.PalGetFocus(), Ifs.Fnd.ApplicationForms.Const.PM_DataItemLov, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0);
						
						case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
							Sal.SendMsg(hLastWithFocus, Ifs.Fnd.ApplicationForms.Const.PM_DataItemLov, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
							Sal.SetFocus(hLastWithFocus);
							return true;
					}
				}
				if (sAction == "SpecifyLu") 
				{
					return UM_SpecifyLu(nWhat);
				}
				if (sAction == "GenerateDiff") 
				{
					return UM_GenerateDiff(nWhat);
				}
			}

			return false;
			#endregion
		}
		
		/// <summary>
		/// Displays a dialog with progress bar
		/// </summary>
		/// <returns></returns>
		public virtual SalString DisplayProgresBar()
		{
			#region Local Variables
			SalString sTitle = "";
			SalString sUpdateIn = "";
			SalArray<SalString> sAttrs = new SalArray<SalString>();
			SalArray<SalString> sFields = new SalArray<SalString>();
			SalNumber n = 0;
			SalSqlHandle hSql = SalSqlHandle.Null;
			SalBoolean bOk = false;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				sTitle = Properties.Resources.TEXT_UpdatingCompany + " " + sCompany;
				MethodProgressStart(i_hWndSelf, sTitle, Properties.Resources.TEXT_UpdatingCompany, "SAVE", true, SalWindowHandle.Null);
				n = 1;
				nSteps = lsAttr.Tokenize(Ifs.Fnd.ApplicationForms.Const.strNULL, ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_RS).ToCharacter(), sAttrs);
				MethodProgressStepAdd(nSteps);
				if (!(DbConnect(ref hSql))) 
				{
					return "FALSE";
				}
				while (sAttrs[n - 1] != Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					sAttrs[n - 1].Tokenize(Ifs.Fnd.ApplicationForms.Const.strNULL, ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_US).ToCharacter(), sFields);
					if (sFields[0] == "MODULE") 
					{
						sModuleVariable = sFields[1];
					}
					if (sFields[0] == "PACKAGE") 
					{
						sPackageNameVariable = sFields[1];
					}
					if (sModuleVariable != Ifs.Fnd.ApplicationForms.Const.strNULL && sPackageNameVariable != Ifs.Fnd.ApplicationForms.Const.strNULL) 
					{
						sUpdateIn = Properties.Resources.TEXT_UpdateIn + " " + sModuleVariable;
						MethodProgressMessage(sUpdateIn);
						if (DbTransactionBegin(ref cSessionManager.c_hSql)) 
						{
							using(SignatureHints hints = SignatureHints.NewContext())
							{
								hints.Add("Create_Company_API.Create_New_Company__", System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
								bOk = DbPLSQLBlock(hSql, "&AO.Create_Company_API.Create_New_Company__( :i_hWndFrame.dlgUpdateCompany.sErrorCreated,\r\n" +
									"                                                                                                                                :i_hWndFrame.dlgUpdateCompany.dfCompany,\r\n" +
									"								:i_hWndFrame.dlgUpdateCompany.sModuleVariable,\r\n" +
									"								:i_hWndFrame.dlgUpdateCompany.sPackageNameVariable,\r\n" +
									"								:i_hWndFrame.dlgUpdateCompany.lsAttrUpdate,\r\n" +
									"								:i_hWndFrame.dlgUpdateCompany.sLanguages )");
							}
							if (!(bOk)) 
							{
								DbTransactionClear(cSessionManager.c_hSql);
								return "FALSE";
							}
							if (sModuleVariable == "ACCRUL") 
							{
								using(SignatureHints hints = SignatureHints.NewContext())
								{
									hints.Add("Company_Finance_API.Set_Creation_Finished", System.Data.ParameterDirection.Input);
									bOk = DbPLSQLBlock(hSql, "&AO.Company_Finance_API.Set_Creation_Finished( :i_hWndFrame.dlgUpdateCompany.dfCompany )");
								}
								if (!(bOk)) 
								{
									DbTransactionClear(cSessionManager.c_hSql);
									return "FALSE";
								}
							}
						}
						DbTransactionEnd(cSessionManager.c_hSql);
						sModuleVariable = Ifs.Fnd.ApplicationForms.Const.strNULL;
						sPackageNameVariable = Ifs.Fnd.ApplicationForms.Const.strNULL;
					}
					n = n + 1;
					MethodProgressStep();
				}
				MethodProgressDone();
				// Update info to implementation table create_company_log_imp_tab
				using(SignatureHints hints = SignatureHints.NewContext())
				{
					hints.Add("Create_Company_Log_API.Add_To_Imp_Table__", System.Data.ParameterDirection.Input);
					hints.Add("Create_Company_Log_API.Update_Log_Tab_To_Comments__", System.Data.ParameterDirection.Input);
					DbPLSQLTransaction(cSessionManager.c_hSql, " &AO.Create_Company_Log_API.Add_To_Imp_Table__( :i_hWndFrame.dlgUpdateCompany.dfCompany);\r\n" +
						"			          &AO.Create_Company_Log_API.Update_Log_Tab_To_Comments__( :i_hWndFrame.dlgUpdateCompany.dfCompany) ");
				}
				if (sErrorCreated == "TRUE") 
				{
					if (Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_NoSuccessUpdateOpenLog, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.QUESTION_YesNo) == Sys.IDYES) 
					{
						return "OPEN_LOG";
					}
					else
					{
						return "TRUE";
					}
				}
				else if (sErrorCreated == "FALSE") 
				{
					Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_SuccessUpdate, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
				}
				else if (sErrorCreated == "COMMENTS") 
				{
					Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_SuccessUpdateComments, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
				}
				DbDisconnect(hSql);
				return "TRUE";
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nWhat"></param>
		/// <returns></returns>
		public virtual SalBoolean UM_SpecifyLu(SalNumber nWhat)
		{
			#region Actions
			using (new SalContext(this))
			{
				switch (nWhat)
				{
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
						if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Update_Company_Select_Lu_API.Initiate_Values__"))) 
						{
							return false;
						}
						return true;
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
						if (sUpdateId == Ifs.Fnd.ApplicationForms.Const.strNULL) 
						{
							using(SignatureHints hints = SignatureHints.NewContext())
							{
								hints.Add("Update_Company_Select_Lu_API.Initiate_Values__", System.Data.ParameterDirection.InputOutput);
								DbPLSQLTransaction(cSessionManager.c_hSql, "&AO.Update_Company_Select_Lu_API.Initiate_Values__(" + sFullName + ".sUpdateId)");
							}
						}
						if (!(dlgUpdateCompanySelectLu.ModalDialog(Ifs.Fnd.ApplicationForms.Int.Explorer.ExplorerForm, dfCompany.Text, sDescription, sUpdateId) == Sys.IDOK)) 
						{
							return false;
						}
						return true;
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_GetType:
						return Ifs.Fnd.ApplicationForms.Const.CHILDTYPE_Any;
				}
			}

			return false;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nWhat"></param>
		/// <returns></returns>
		public virtual SalBoolean UM_GenerateDiff(SalNumber nWhat)
		{
			#region Local Variables
			SalNumber nEndDialog = 0;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				switch (nWhat)
				{
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
						sSourceCompany = dfFromCompany.Text;
						if (cbTemplateAsSource.Checked) 
						{
							if (sDiffTemplate == dfUpdateTemplateId.Text) 
							{
								sSourceTemplate = dfOldSourceTemplate.Text;
							}
							else
							{
								sSourceTemplate = dfUpdateTemplateId.Text;
							}
							if (dfOldSourceTemplate.Text != sSourceTemplate) 
							{
								if (dfOldSourceTemplate.Text != sOldSourceTemplate) 
								{
									if (sDiffTemplate != SalString.Null) 
									{
										AddToDiffTemplateToRemove(sDiffTemplate);
									}
									sDiffTemplate = SalString.Null;
								}
								else if (sSourceTemplate != sOldSourceTemplate) 
								{
									if (sDiffTemplate != SalString.Null) 
									{
										AddToDiffTemplateToRemove(sDiffTemplate);
									}
									sDiffTemplate = SalString.Null;
								}
							}
						}
						else
						{
							if (sDiffTemplate == SalString.Null) 
							{
								sSourceTemplate = dfFromTemplateId.Text;
							}
							if (sSourceCompany == SalString.Null) 
							{
								if (sOldSourceTemplate != sSourceTemplate) 
								{
									if (sDiffTemplate != SalString.Null) 
									{
										AddToDiffTemplateToRemove(sDiffTemplate);
									}
									sDiffTemplate = SalString.Null;
								}
							}
							else
							{
								if (sTempSourceTemplate != sSourceCompany) 
								{
									if (sDiffTemplate != SalString.Null) 
									{
										AddToDiffTemplateToRemove(sDiffTemplate);
									}
									sDiffTemplate = SalString.Null;
								}
							}
						}
						nEndDialog = dlgUpdateCompanyDiffMaster.ModalDialog(Ifs.Fnd.ApplicationForms.Int.Explorer.ExplorerForm, dfCompany.Text, sDescription, ref sSourceCompany, ref sSourceTemplate, dfValidFrom.DateTime, ref sUpdateId, ref sOldSourceTemplate, ref sTempSourceTemplate, ref sTempTargetTemplate, ref 
							sDiffTemplate);
						// If nEndDialog is 0 or 2 then dlgUpdateCompanyDiffMaster have been cancelled or closed.
						if (sDiffTemplate != SalString.Null && nEndDialog != 0 && nEndDialog != 2) 
						{
							dfOldSourceTemplate.Text = sOldSourceTemplate;
							dfUpdateTemplateId.Text = sDiffTemplate;
							cbDifferenceTemplate.Checked = true;
							cbTemplateAsSource.Checked = true;
							Sal.EnableWindow(dfUpdateTemplateId);
							RefreshButtonsState();
						}
						return true;
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
						if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("dlgUpdateCompanyDiffMaster")))) 
						{
							return false;
						}
						if (dfFromCompany.Text == Ifs.Fnd.ApplicationForms.Const.strNULL && dfFromTemplateId.Text == Ifs.Fnd.ApplicationForms.Const.strNULL && dfUpdateTemplateId.Text == Ifs.Fnd.ApplicationForms.Const.strNULL) 
						{
							return false;
						}
						if (cbTemplateAsSource.Checked && dfUpdateTemplateId.Text == Ifs.Fnd.ApplicationForms.Const.strNULL) 
						{
							return false;
						}
						return true;
				}
			}

			return false;
			#endregion
		}

		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber GetExistingLanguages()
		{
			#region Local Variables
			SalString lsStmt = "";
			SalNumber i = 0;
			SalNumber nDummy = 0;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				sExistingLngs.SetUpperBound(1, -1);
				if (Ifs.Fnd.ApplicationForms.Var.Security.IsViewAvailable("Company_Translation_Lng")) 
				{
					lsStmt = "SELECT language_code into\r\n	" + sFullName + ".sTemplateLng\r\n" +
					"	FROM &AO.Company_Translation_Lng\r\n" +
					"	WHERE key_name = 'CompanyKeyLu'\r\n" +
					"	AND key_value =  " + sFullName + ".dfCompany\r\n" +
					"	group by language_code";
					DbPrepareAndExecute(cSessionManager.c_hSql, lsStmt);
					while (DbFetchNext(cSessionManager.c_hSql, ref nDummy)) 
					{
						sExistingLngs[i] = sTemplateLng;
						i = i + 1;
					}
				}
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber PackExistingLangauges()
		{
			#region Local Variables
			SalNumber nBound = 0;
			SalNumber nCounter = 0;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				sLanguages = Ifs.Fnd.ApplicationForms.Const.strNULL;
				nBound = sExistingLngs.GetUpperBound(1);
				nCounter = -1;
				while (nCounter < nBound) 
				{
					nCounter = nCounter + 1;
					sLanguages = sLanguages + sExistingLngs[nCounter] + ((SalNumber)31).ToCharacter();
				}
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber RefreshButtonsState()
		{
			#region Actions
			using (new SalContext(this))
			{
				pbList.MethodInvestigateState();
				pbGenerateDiff.MethodInvestigateState();
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean UpdatedCompany()
		{
			#region Local Variables
			SalString sReturn = "";
			SalArray<SalString> sItemNames = new SalArray<SalString>();
			SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				Sal.WaitCursor(true);
				if (cbTemplateAsSource.Checked && (dfUpdateTemplateId.Text != Ifs.Fnd.ApplicationForms.Const.strNULL)) 
				{
					using(SignatureHints hints = SignatureHints.NewContext())
					{
						hints.Add("Create_Company_Tem_API.Exist", System.Data.ParameterDirection.Input);
						if (!(DbPLSQLBlock(cSessionManager.c_hSql, "&AO.Create_Company_Tem_API.Exist( " + sFullName + ".dfUpdateTemplateId )"))) 
						{
							return false;
						}
					}
				}
				using(SignatureHints hints = SignatureHints.NewContext())
				{
					hints.Add("Create_Company_API.New_Company__", System.Data.ParameterDirection.InputOutput);
					if (!(DbPLSQLBlock(cSessionManager.c_hSql, "&AO.Create_Company_API.New_Company__( " + sFullName + ".lsAttr )"))) 
					{
						return false;
					}
				}
				if (cbAccRelData.Checked) 
				{
					Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("UPDATE_ACC_REL_DATA", "TRUE", ref lsAttrUpdate);
				}
				else
				{
					Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("UPDATE_ACC_REL_DATA", "FALSE", ref lsAttrUpdate);
				}
				if (cbNonAccRelData.Checked) 
				{
					Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("UPDATE_NON_ACC_DATA", "TRUE", ref lsAttrUpdate);
				}
				else
				{
					Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("UPDATE_NON_ACC_DATA", "FALSE", ref lsAttrUpdate);
				}
				if (cbTemplateAsSource.Checked) 
				{
					Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("UPDATE_FROM_TEMPLATE", dfUpdateTemplateId.Text, ref lsAttrUpdate);
				}
				Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("FROM_WINDOW", "UPDATE_COMPANY", ref lsAttrUpdate);
				Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("MAIN_PROCESS", "UPDATE COMPANY", ref lsAttrUpdate);
				// Add Update_Id
				Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("UPDATE_ID", sUpdateId, ref lsAttrUpdate);
				GetExistingLanguages();
				PackExistingLangauges();
				sReturn = DisplayProgresBar();
				Sal.WaitCursor(false);
				if (sReturn == "OPEN_LOG") 
				{
					Sal.WaitCursor(true);
					sItemNames[0] = "COMPANY";
					hWndItems[0] = dfCompany;
					Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init(Pal.GetActiveInstanceName("dlgUpdateCompany"), i_hWndFrame, sItemNames, hWndItems);
					SessionCreateWindow(Pal.GetActiveInstanceName("tbwCompanyComponentLog"), Sys.hWndMDI);
					Sal.WaitCursor(false);
				}
				return true;
			}
			#endregion
		}
		
		/// <summary>
		/// Pack attr for Delete of Temporary Diff Templates
		/// </summary>
		/// <returns></returns>
		public virtual SalString PackDeleteAttr()
		{
			#region Actions
			using (new SalContext(this))
			{
				lsDeleteAttr = Ifs.Fnd.ApplicationForms.Const.strNULL;
				Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("TEMP_SOURCE_TEMPLATE", sTempSourceTemplate, ref lsDeleteAttr);
				Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("TEMP_TARGET_TEMPLATE", sTempTargetTemplate, ref lsDeleteAttr);
				Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("DIFF_TEMPLATE", sDiffTemplate, ref lsDeleteAttr);
				return lsDeleteAttr;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber RemoveTempDiffTemplates()
		{
			#region Actions
			using (new SalContext(this))
			{
				lsDeleteAttr = PackDeleteAttr();
				// Notify user that delete of temporary diff template will take place and it will take some time
				Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_DeleteTempDiffTemplates, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
				Sal.WaitCursor(true);
				using(SignatureHints hints = SignatureHints.NewContext())
				{
					hints.Add("Company_Template_Diff_Util_API.Remove_Temorary_Templats__", System.Data.ParameterDirection.Input);
					DbPLSQLTransaction(cSessionManager.c_hSql, "&AO.Company_Template_Diff_Util_API.Remove_Temorary_Templats__(" + sFullName + ".lsDeleteAttr)");
				}
				Sal.WaitCursor(false);
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="sTemplate"></param>
		/// <returns></returns>
		public virtual SalNumber AddToDiffTemplateToRemove(SalString sTemplate)
		{
			#region Local Variables
			SalNumber nIndex = 0;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				if (sDiffTemplateForRemove.IsEmpty) 
				{
					sDiffTemplateForRemove[0] = sTemplate;
				}
				else
				{
					nIndex = sDiffTemplateForRemove.GetUpperBound(1);
					sDiffTemplateForRemove[nIndex + 1] = sTemplate;
				}
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber RemoveOldDiffTemplates()
		{
			#region Local Variables
			SalString sTemplateId = "";
			SalNumber i = 0;
			SalNumber nIndex = 0;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				nIndex = sDiffTemplateForRemove.GetUpperBound(1);
				i = 0;
				while (i < (nIndex + 1)) 
				{
					sTemplateId = sDiffTemplateForRemove[i];
					i = i + 1;
					lsDeleteAttr = Ifs.Fnd.ApplicationForms.Const.strNULL;
					Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("DIFF_TEMPLATE", sTemplateId, ref lsDeleteAttr);
					Sal.WaitCursor(true);
					using(SignatureHints hints = SignatureHints.NewContext())
					{
						hints.Add("Company_Template_Diff_Util_API.Remove_Temorary_Templats__", System.Data.ParameterDirection.Input);
						DbPLSQLTransaction(cSessionManager.c_hSql, "&AO.Company_Template_Diff_Util_API.Remove_Temorary_Templats__(" + sFullName + ".lsDeleteAttr)");
					}
					Sal.WaitCursor(false);
				}
				sDiffTemplateForRemove.SetUpperBound(1, -1);
				lsDeleteAttr = Ifs.Fnd.ApplicationForms.Const.strNULL;
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
		private void dlgUpdateCompany_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Create:
					this.dlgUpdateCompany_OnSAM_Create(sender, e);
					break;
				
				case Sys.SAM_Destroy:
					this.dlgUpdateCompany_OnSAM_Destroy(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Create event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dlgUpdateCompany_OnSAM_Create(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam);
			this.sFullName = ":i_hWndFrame." + Ifs.Fnd.ApplicationForms.Int.QualifiedItemNameGet(this);
			Sal.CenterWindow(this.i_hWndFrame);
			#endregion
		}
		
		/// <summary>
		/// SAM_Destroy event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dlgUpdateCompany_OnSAM_Destroy(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			Sal.SendClassMessage(Sys.SAM_Destroy, Sys.wParam, Sys.lParam);
			if (this.sUpdateId != Ifs.Fnd.ApplicationForms.Const.strNULL) 
			{
				using(SignatureHints hints = SignatureHints.NewContext())
				{
					hints.Add("Update_Company_Select_Lu_API.Remove_For_Id__", System.Data.ParameterDirection.Input);
					this.DbPLSQLTransaction(cSessionManager.c_hSql, "&AO.Update_Company_Select_Lu_API.Remove_For_Id__(" + this.sFullName + ".sUpdateId)");
				}
			}
			// Check delete of temporary diff template should take place
			if (this.sDiffTemplate != Ifs.Fnd.ApplicationForms.Const.strNULL || this.sTempSourceTemplate != Ifs.Fnd.ApplicationForms.Const.strNULL || this.sTempTargetTemplate != Ifs.Fnd.ApplicationForms.Const.strNULL) 
			{
				this.RemoveTempDiffTemplates();
			}
			if (!(this.sDiffTemplateForRemove.IsEmpty)) 
			{
				this.RemoveOldDiffTemplates();
			}
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void cbNonAccRelData_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_SetFocus:
					this.cbNonAccRelData_OnSAM_SetFocus(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cbNonAccRelData_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.hLastWithFocus = this.cbNonAccRelData;
			this.RefreshButtonsState();
			e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void cbAccRelData_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_SetFocus:
					this.cbAccRelData_OnSAM_SetFocus(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cbAccRelData_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.hLastWithFocus = this.cbAccRelData;
			this.RefreshButtonsState();
			e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void cbTemplateAsSource_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Click:
					this.cbTemplateAsSource_OnSAM_Click(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Click event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cbTemplateAsSource_OnSAM_Click(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (this.cbTemplateAsSource.Checked) 
			{
				Sal.EnableWindow(this.dfUpdateTemplateId);
				Sal.EnableWindow(this.cbDifferenceTemplate);
				Sal.SetFocus(this.dfUpdateTemplateId);
				this.RefreshButtonsState();
			}
			else
			{
				Sal.DisableWindow(this.dfUpdateTemplateId);
				Sal.DisableWindow(this.cbDifferenceTemplate);
				this.RefreshButtonsState();
			}
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dfUpdateTemplateId_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_SetFocus:
					this.dfUpdateTemplateId_OnSAM_SetFocus(sender, e);
					break;
				
				case Sys.SAM_AnyEdit:
					this.dfUpdateTemplateId_OnSAM_AnyEdit(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfUpdateTemplateId_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.hLastWithFocus = this.dfUpdateTemplateId;
			this.RefreshButtonsState();
			e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
		
		/// <summary>
		/// SAM_AnyEdit event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfUpdateTemplateId_OnSAM_AnyEdit(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (this.dfFromCompany.Text == Ifs.Fnd.ApplicationForms.Const.strNULL && this.dfFromTemplateId.Text == Ifs.Fnd.ApplicationForms.Const.strNULL && this.dfUpdateTemplateId.Text == Ifs.Fnd.ApplicationForms.Const.strNULL) 
			{
				Sal.DisableWindow(this.pbOk);
			}
			else
			{
				Sal.EnableWindow(this.pbOk);
			}
			if (this.sDiffTemplate == this.dfUpdateTemplateId.Text && this.sDiffTemplate != SalString.Null) 
			{
				this.cbDifferenceTemplate.Checked = true;
			}
			else
			{
				this.cbDifferenceTemplate.Checked = false;
			}
			this.RefreshButtonsState();
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
