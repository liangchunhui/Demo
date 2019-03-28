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
using PPJ.Runtime.Vis;

namespace Ifs.Application.Enterp
{
	
	/// <summary>
	/// </summary>
	[FndWindowRegistration("COMPANY", "Company")]
	public partial class dlgImportTemplateFile : cDialogBox
	{
		#region Window Variables
		public SalString strFile = "";
		public SalArray<SalString> strFilters = new SalArray<SalString>("0:5");
		public SalString sFullName = "";
		public SalString sGlobalTemplateId = "";
		public SalString sModuleVariable = "";
		public SalString sPackageNameVariable = "";
		public SalString sTemplateLogId = "";
		public SalString sExistError = "";
		public SalArray<SalString> strPaths = new SalArray<SalString>();
		public SalArray<SalString> strFiles = new SalArray<SalString>();
		public SalString sTemp = "";
		public SalBoolean bTemplateChecked = false;
		public SalArray<SalString> sParams = new SalArray<SalString>();
		public SalString sAllowed = "";
		public SalBoolean bMultipleTemplates = false;
		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		protected dlgImportTemplateFile()
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
			dlgImportTemplateFile dlg = DialogFactory.CreateInstance<dlgImportTemplateFile>();
			SalNumber ret = dlg.ShowDialog(owner);
			return ret;
		}
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public new static dlgImportTemplateFile FromHandle(SalWindowHandle handle)
		{
			return ((dlgImportTemplateFile)SalWindow.FromHandle(handle, typeof(dlgImportTemplateFile)));
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
					return PressOk(nWhat);
				}
				else if (sMethod == "Cancel") 
				{
					if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
					{
						Sal.EndDialog(this, 0);
					}
					else
					{
						return true;
					}
				}
				else if (sMethod == "Add") 
				{
					return Add(nWhat);
				}
				else if (sMethod == "Remove") 
				{
					return Remove(nWhat);
				}
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nWhat"></param>
		/// <returns></returns>
		public virtual SalBoolean PressOk(SalNumber nWhat)
		{
			#region Local Variables
			SalArray<SalString> sPlaceHolders = new SalArray<SalString>();
			SalArray<SalString> sPlaceHoldersLog = new SalArray<SalString>();
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire) 
				{
					if (!(Sal.ListQueryCount(lbFiles))) 
					{
						return false;
					}
					else
					{
						return true;
					}
					return true;
				}
				if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
				{
					if (ReadTemplateFile()) 
					{
						Sal.WaitCursor(false);
						using(SignatureHints hints = SignatureHints.NewContext())
						{
							hints.Add("Create_Company_Tem_Log_API.Error_Exist__", System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Input);
							DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN\r\n" +
								"				&AO.Create_Company_Tem_Log_API.Error_Exist__(\r\n" +
								"					:i_hWndFrame.dlgImportTemplateFile.sExistError,\r\n" +
								"					:i_hWndFrame.dlgImportTemplateFile.sTemplateLogId);\r\n" +
								"		               END; ");
						}
						if (sExistError == "TRUE") 
						{
							if (bMultipleTemplates) 
							{
								sPlaceHoldersLog[0] = sTemplateLogId;
								Ifs.Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.TEXT_LogImportFile2, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok, sPlaceHoldersLog);
							}
							else
							{
								sPlaceHoldersLog[0] = sGlobalTemplateId;
								sPlaceHoldersLog[1] = sTemplateLogId;
								Ifs.Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.TEXT_LogImportFile, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok, sPlaceHoldersLog);
							}
						}
						else
						{
							if (sGlobalTemplateId != SalString.Null && (!(bMultipleTemplates))) 
							{
								sPlaceHolders[0] = sGlobalTemplateId;
								Ifs.Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.TEXT_ImportFile, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok, sPlaceHolders);
							}
							else
							{
								Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_TemplateFileImport, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
							}
						}
						return Sal.EndDialog(this, 0);
					}
					else
					{
						MethodProgressDone();
					}
				}
			}

			return false;
			#endregion
		}
		
		/// <summary>
		/// Scan through the selected template file for each component and execute the statements written in the file
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean ReadTemplateFile()
		{
			#region Local Variables
            SalString sAppOwner = "&AO";
			SalBoolean bOk = false;
			SalBoolean bMultipleFiles = false;
			SalBoolean bTemplateInfoFound = false;
			SalBoolean bTempTransInfoFound = false;
			SalBoolean bTemplateTranslationFile = false;
			SalFileHandle hSrcHandle = SalFileHandle.Null;
			SalString lsFileLine = "";
			SalString lsFileLineDummy = "";
			SalString lsStmt = "";
			SalNumber i = 0;
			SalNumber n = 0;
			SalNumber nCount = 0;
			SalNumber nFileLength = 0;
			SalNumber nProgress = 0;
			SalNumber nSearchBackslash = 0;
			SalNumber nSize = 0;
			SalNumber nSteps = 0;
			SalNumber nStmtLength = 0;
			SalString sComment = "";
			SalString sCommit = "";
			SalString sDefine = "";
			SalString sFileName = "";
			SalString sPreviousGlobalTemplateId = "";
			SalString sSlash = "";
			SalArray<SalString> sTempArray = new SalArray<SalString>();
			SalString sTemplateComponent = "";
			SalString sTemplateId = "";
			SalString sTemplateVersion = "";
			SalString strText = "";
			SalString sBegin = "";
			SalString sEnd = "";
			SalNumber nBegin = 0;
			SalNumber nEnd = 0;
			SalNumber nMaxStatementLength = 0;
			SalString sUndefine = "";
			SalString sTempdefine = "";
			SalString sMethodEnd = "";
			SalBoolean bMethodEnd = false;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				// Define max length of statement to be passed to the server
				nMaxStatementLength = 28000;
				nCount = Sal.ListQueryCount(lbFiles);
				nCount = nCount + 1;
				if (nCount > 2) 
				{
					bMultipleFiles = true;
				}
				nProgress = 1;
				nBegin = 0;
				nEnd = 0;
				i = 1;
				if (DbTransactionBegin(ref cSessionManager.c_hSql)) 
				{
					using(SignatureHints hints = SignatureHints.NewContext())
					{
						hints.Add("Create_Company_Tem_Log_API.Initiate_Log_Client__", System.Data.ParameterDirection.Output);
						DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN\r\n" +
							"				&AO.Create_Company_Tem_Log_API.Initiate_Log_Client__(:i_hWndFrame.dlgImportTemplateFile.sTemplateLogId);\r\n" +
							"		               END; ");
					}
					while (i < nCount) 
					{
						nProgress = 1;

						bTemplateInfoFound = false;
						bTemplateTranslationFile = false;
						bTempTransInfoFound = false;
						lsStmt = Ifs.Fnd.ApplicationForms.Const.strNULL;
						lsFileLine = Ifs.Fnd.ApplicationForms.Const.strNULL;
						nStmtLength = SalNumber.Null;
						strText = Sal.ListQueryTextX(lbFiles, n);
						nSearchBackslash = Vis.StrScanReverse(strText, -1, "\\");
						nFileLength = strText.Length;
						if (nSearchBackslash > -1) 
						{
							sFileName = strText.Right(nFileLength - nSearchBackslash - 1);
						}
						else
						{
							sFileName = strText;
						}
						nSize = Vis.FileGetSize(strText);
						nSteps = nSize / 100;
						MethodProgressStart(i_hWndSelf, Properties.Resources.TEXT_CompanyTemplateImport, sFileName, "SAVE", true, SalWindowHandle.Null);
						MethodProgressStepAdd(nSteps);
						Vis.FileOpen(ref hSrcHandle, strText, Sys.OF_Read);
						while (Vis.FileReadString(hSrcHandle, ref lsFileLine) > -1) 
						{
							nProgress = nProgress + 1;
							MethodProgressSteps(1);
							if (Vis.StrScanReverse(lsFileLine, -1, "Init_Templ_Trans") > -1) 
							{
								// This is a Template Translation file
								bTempTransInfoFound = true;
								// To be backward compatible if using old Enterp interfaces
								lsFileLine = Vis.StrSubstitute(lsFileLine, "Enterp_Comp_Connect_V151", "Enterp_Comp_Connect_V170");
								lsFileLine = Vis.StrSubstitute(lsFileLine, "Enterp_Comp_Connect_V160", "Enterp_Comp_Connect_V170");
								// Add appowner alias before package name
                                lsFileLine = Vis.StrSubstitute(lsFileLine, "Enterp_Comp_Connect_V", sAppOwner + ".Enterp_Comp_Connect_V");
								lsFileLine = Vis.StrSubstitute(lsFileLine, "&TEMPLATE_ID", sGlobalTemplateId);
								lsStmt = "BEGIN " + lsFileLine;
								// Count number of BEGIN and END; to know if one of them have to be added before sending to DB
								nBegin = nBegin + 1;
							}
							sTempdefine = lsFileLine.Mid(0, 6);
							if (sTempdefine == "DEFINE") 
							{
								lsFileLine = Vis.StrSubstitute(lsFileLine, "DEFINE", ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_GS).ToCharacter());
								lsFileLine = Vis.StrSubstitute(lsFileLine, "=", ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_FS).ToCharacter());
								lsFileLine.Tokenize(((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_GS).ToCharacter(), ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_FS).ToCharacter(), sTempArray);
								if (Vis.StrTrim(sTempArray[0]) == "TEMPLATE_ID") 
								{
									sTemplateId = "'" + Vis.StrTrim(sTempArray[1]) + "'";
									sPreviousGlobalTemplateId = sGlobalTemplateId;
									// sGlobalTemplateId is TemplateId without (') and also used when prompting the user
									sGlobalTemplateId = Vis.StrTrim(sTempArray[1]);
									if (sGlobalTemplateId != sPreviousGlobalTemplateId && sPreviousGlobalTemplateId != Ifs.Fnd.ApplicationForms.Const.strNULL) 
									{
										bTemplateChecked = false;
										bMultipleTemplates = true;
									}
									// If multiple files check if same template is imported or several different templates. Used to display proper error message.
									if (bMultipleFiles) 
									{
										if (sGlobalTemplateId != sPreviousGlobalTemplateId && sPreviousGlobalTemplateId != Ifs.Fnd.ApplicationForms.Const.strNULL) 
										{
											bMultipleTemplates = true;
										}
									}
								}
								if (Vis.StrTrim(sTempArray[0]) == "COMPONENT") 
								{
									sTemplateComponent = "'" + Vis.StrTrim(sTempArray[1]) + "'";
								}
								if (Vis.StrTrim(sTempArray[0]) == "VERSION") 
								{
									sTemplateVersion = "'" + Vis.StrTrim(sTempArray[1]) + "'";
								}
							}
							if (sTemplateComponent != Ifs.Fnd.ApplicationForms.Const.strNULL && sTemplateVersion != Ifs.Fnd.ApplicationForms.Const.strNULL && sGlobalTemplateId != Ifs.Fnd.ApplicationForms.Const.strNULL) 
							{
								bTemplateInfoFound = true;
								lsStmt = Ifs.Fnd.ApplicationForms.Const.strNULL;
								nStmtLength = 0;
							}
							if (sGlobalTemplateId != Ifs.Fnd.ApplicationForms.Const.strNULL && bTempTransInfoFound) 
							{
								bTemplateTranslationFile = true;
							}
							if (bTemplateTranslationFile || bTemplateInfoFound) 
							{
								// Check with user if it is ok to overwrite the template, if same template only one question otherwise one per template that exist (if they are sorted in template order)
								if (!(bTemplateChecked)) 
								{
									using(SignatureHints hints = SignatureHints.NewContext())
									{
										hints.Add("Create_Company_Tem_API.Check_Exist", System.Data.ParameterDirection.Input);
										hints.Add("Create_Company_Tem_API.Change_Template_Allowed", System.Data.ParameterDirection.Input);
										if (DbPLSQLBlock(cSessionManager.c_hSql, "Begin\r\n" +
											"		                 If &AO.Create_Company_Tem_API.Check_Exist(:i_hWndFrame.dlgImportTemplateFile.sGlobalTemplateId) THEN\r\n" +
											"			    :i_hWndFrame.dlgImportTemplateFile.sTemp := 'TRUE';\r\n" +
											"			 Else\r\n" +
											"			    :i_hWndFrame.dlgImportTemplateFile.sTemp := 'FALSE';\r\n" +
											"			 End If;\r\n" +
											"		                 :i_hWndFrame.dlgImportTemplateFile.sAllowed := &AO.Create_Company_Tem_API.Change_Template_Allowed(:i_hWndFrame.dlgImportTemplateFile.sGlobalTemplateId);\r\n" +
											"		            End;")) 
										{
											sParams[0] = sGlobalTemplateId;
											if (sAllowed != "TRUE") 
											{
												Ifs.Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.TEXT_ImportFileNotAllowed, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok, sParams);
												return false;
											}
											if (sTemp == "TRUE") 
											{
												if (Ifs.Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.TEXT_ImportFileExist, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Question, Ifs.Fnd.ApplicationForms.Const.QUESTION_YesNo, sParams) != Sys.IDYES) 
												{
													DbTransactionClear(cSessionManager.c_hSql);
													Vis.FileClose(hSrcHandle);
													MethodProgressDone();
													return false;
												}
											}
										}
										else
										{
											MethodProgressDone();
											return false;
										}
									}
									bTemplateChecked = true;
								}
								while (Vis.FileReadString(hSrcHandle, ref lsFileLine) > -1) 
								{
									nProgress = nProgress + 1;
									MethodProgressSteps(1);
									// To be backward compatible if using old Enterp interfaces
									lsFileLine = Vis.StrSubstitute(lsFileLine, "Enterp_Comp_Connect_V151", "Enterp_Comp_Connect_V170");
									lsFileLine = Vis.StrSubstitute(lsFileLine, "Enterp_Comp_Connect_V160", "Enterp_Comp_Connect_V170");
									// Add appowner alias before package name
									lsFileLine = Vis.StrSubstitute(lsFileLine, "Enterp_Comp_Connect_V", sAppOwner + ".Enterp_Comp_Connect_V");
									lsFileLine = Vis.StrSubstitute(lsFileLine, "Database_SYS", "&AO.Database_SYS");

									sSlash = lsFileLine.Mid(0, 1);
									sDefine = lsFileLine.Mid(0, 6);
									sComment = lsFileLine.Mid(0, 2);
									sCommit = lsFileLine.Mid(0, 7);
									sBegin = lsFileLine.Mid(0, 5).ToUpper();
									sEnd = lsFileLine.Mid(0, 4).ToUpper();
									sUndefine = lsFileLine.Mid(0, 8);
									sMethodEnd = lsFileLine.Right(2).ToUpper();
									if (sMethodEnd == ");") 
									{
										bMethodEnd = true;
									}
									else
									{
										bMethodEnd = false;
									}
									if (bTemplateInfoFound) 
									{
										lsFileLine = Vis.StrSubstitute(lsFileLine, "'&TEMPLATE_ID'", sTemplateId);
										lsFileLine = Vis.StrSubstitute(lsFileLine, "'&COMPONENT'", sTemplateComponent);
										lsFileLine = Vis.StrSubstitute(lsFileLine, "'&VERSION'", sTemplateVersion);
										if (Ifs.Fnd.ApplicationForms.Int.PalStrScanReverse(lsFileLine, -1, "DEFINE ") > -1) 
										{
											lsFileLineDummy = Vis.StrSubstitute(lsFileLine, "DEFINE ", ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_GS).ToCharacter());
											lsFileLineDummy = Vis.StrSubstitute(lsFileLine, "=", ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_FS).ToCharacter());
											lsFileLineDummy.Tokenize(((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_GS).ToCharacter(), ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_FS).ToCharacter(), sTempArray);
											if (Vis.StrTrim(sTempArray[0]) == "COMPONENT") 
											{
												sTemplateComponent = "'" + sTempArray[1] + "'";
											}
											if (Vis.StrTrim(sTempArray[0]) == "VERSION") 
											{
												sTemplateVersion = "'" + sTempArray[1] + "'";
											}
										}
										if (Ifs.Fnd.ApplicationForms.Int.PalStrScanReverse(lsFileLine, -1, "<<END>>") > -1)  // Break when finding <<END>>
										{
											bTemplateInfoFound = false;
											bTempTransInfoFound = false;
											bTemplateTranslationFile = false;
											break;
										}
										// Send statement to server when length is over nMaxStatementLength
										if (Ifs.Fnd.ApplicationForms.Int.PalStrScanReverse(lsFileLine, -1, "END;") > -1 && nStmtLength > nMaxStatementLength) 
										{
											lsStmt = lsStmt + " " + lsFileLine;
											if (lsStmt != SalString.Null) 
											{
												// Count number of BEGIN and END; to know if one of them have to be added before sending to DB
												if (sBegin == "BEGIN") 
												{
													nBegin = nBegin + 1;
												}
												else if (sEnd == "END;") 
												{
													nEnd = nEnd + 1;
												}
												while (nBegin > nEnd) 
												{
													nEnd = nEnd + 1;
													lsStmt = lsStmt + "NULL; END; ";
												}
												while (nEnd > nBegin) 
												{
													nBegin = nBegin + 1;
													lsStmt = "BEGIN NULL; " + lsStmt;
												}
                                                // double begin and end to eliminate a statement like begin xxx end; begin xxx end;
                                                bOk = DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN BEGIN NULL; " + lsStmt + "END; END;");
												nBegin = 0;
												nEnd = 0;
												if (!(bOk)) 
												{
													DbTransactionClear(cSessionManager.c_hSql);
													Vis.FileClose(hSrcHandle);
													MethodProgressDone();
													return false;
												}
											}
											lsStmt = Ifs.Fnd.ApplicationForms.Const.strNULL;
											lsFileLine = Ifs.Fnd.ApplicationForms.Const.strNULL;
											nStmtLength = SalNumber.Null;
										}
										else
										{
											// Count number of BEGIN and END; to know if one of them have to be added before sending to DB
											if (sBegin == "BEGIN") 
											{
												nBegin = nBegin + 1;
											}
											else if (sEnd == "END;") 
											{
												nEnd = nEnd + 1;
											}
											// Accept multiline comments (/* or */) since they will not be executed in server. Ignore comment lines, lines with '/' , lines with 'DEFINE' , lines with 'PROMPT',  lines with 'COMMIT;' AND lines with 'UNDEFINE'
											if ((sSlash != "/" || ((sComment == "/*") || (sComment == "*/"))) && sDefine != "DEFINE" && sDefine != "PROMPT" && sComment != "--" && sCommit != "COMMIT;" && sUndefine != "UNDEFINE") 
											{
												lsStmt = lsStmt + " " + lsFileLine;
												nStmtLength = lsStmt.Length;
											}
										}
									}
									else
									{
										if (Ifs.Fnd.ApplicationForms.Int.PalStrScanReverse(lsFileLine, -1, "<<START>>") > -1)  // Break and start over when finding <<START>>
										{
											bTemplateInfoFound = false;
											bTempTransInfoFound = false;
											bTemplateTranslationFile = false;
											break;
										}
										lsFileLine = Vis.StrSubstitute(lsFileLine, "&TEMPLATE_ID", sGlobalTemplateId);
										nStmtLength = (lsStmt + " " + lsFileLine).Length;
										// Send statement to server wher length is over nMaxStatementLength
										if (nStmtLength > nMaxStatementLength && bMethodEnd) 
										{
											// Ignore comment lines, lines with '/' , lines with 'DEFINE' , lines with 'PROMPT' AND lines with 'COMMIT;' AND lines with 'UNDEFINE'
											if ((sSlash != "/" || ((sComment == "/*") || (sComment == "*/"))) && sDefine != "DEFINE" && sDefine != "PROMPT" && sComment != "--" && sCommit != "COMMIT;" && sUndefine != "UNDEFINE") 
											{
												lsStmt = lsStmt + " " + lsFileLine;
											}
											if (lsStmt != SalString.Null) 
											{
												// Count number of BEGIN and END; to know if one of them have to be added before sending to DB
												if (sBegin == "BEGIN") 
												{
													nBegin = nBegin + 1;
												}
												else if (sEnd == "END;") 
												{
													nEnd = nEnd + 1;
												}
												while (nBegin > nEnd) 
												{
													nEnd = nEnd + 1;
													lsStmt = lsStmt + "NULL; END; ";
												}
												while (nEnd > nBegin) 
												{
													nBegin = nBegin + 1;
													lsStmt = "BEGIN NULL; " + lsStmt;
												}
												nBegin = 0;
												nEnd = 0;
                                                // double begin and end to eliminate a statement like begin xxx end; begin xxx end;
                                                bOk = DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN BEGIN NULL; " + lsStmt + "END; END;");												
												if (!(bOk)) 
												{
													DbTransactionClear(cSessionManager.c_hSql);
													Vis.FileClose(hSrcHandle);
													MethodProgressDone();
													return false;
												}
											}
											lsStmt = Ifs.Fnd.ApplicationForms.Const.strNULL;
											lsFileLine = Ifs.Fnd.ApplicationForms.Const.strNULL;
											nStmtLength = SalNumber.Null;
										}
										else
										{
											// Count number of BEGIN and END; to know if one of them have to be added before sending to DB
											if (sBegin == "BEGIN") 
											{
												nBegin = nBegin + 1;
											}
											else if (sEnd == "END;") 
											{
												nEnd = nEnd + 1;
											}
											// Ignore comment lines and lines with '/' AND lines with 'DEFINE' AND lines with 'PROMPT' AND lines with 'UNDEFINE'
											if ((sSlash != "/" || ((sComment == "/*") || (sComment == "*/"))) && sDefine != "DEFINE" && sDefine != "PROMPT" && sComment != "--" && sCommit != "COMMIT;" && sUndefine != "UNDEFINE") 
											{
												lsStmt = lsStmt + " " + lsFileLine;
											}
										}
									}
								}
								if (nStmtLength > 1) 
								{
									while (nBegin > nEnd) 
									{
										nEnd = nEnd + 1;
										lsStmt = lsStmt + "NULL; END; ";
									}
									while (nEnd > nBegin) 
									{
										nBegin = nBegin + 1;
										lsStmt = "BEGIN NULL; " + lsStmt;
									}
									nBegin = 0;
									nEnd = 0;
                                    // double begin and end to eliminate a statement like begin xxx end; begin xxx end;
                                    bOk = DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN BEGIN NULL; " + lsStmt + "END; END;");
									if (!(bOk)) 
									{
										DbTransactionClear(cSessionManager.c_hSql);
										Vis.FileClose(hSrcHandle);
										MethodProgressDone();
										return false;
									}
								}
								sTemplateComponent = Ifs.Fnd.ApplicationForms.Const.strNULL;
								sTemplateVersion = Ifs.Fnd.ApplicationForms.Const.strNULL;
								sTempArray.SetUpperBound(1, -1);
							}

						}
						MethodProgressSteps(nSteps - nProgress);
						sTemplateComponent = Ifs.Fnd.ApplicationForms.Const.strNULL;
						sTemplateVersion = Ifs.Fnd.ApplicationForms.Const.strNULL;
						Vis.FileClose(hSrcHandle);
						n = n + 1;
						i = i + 1;
					}
				}
				DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN\r\n" +
					"				&AO.Create_Company_Tem_Log_API.Reset_Log_Client__;\r\n" +
					"		               END; ");
				DbTransactionEnd(cSessionManager.c_hSql);
				Vis.FileClose(hSrcHandle);
				MethodProgressDone();
				return true;
			}
			#endregion
		}
		
		/// <summary>
		/// add template for merge
		/// </summary>
		/// <param name="nWhat"></param>
		/// <returns></returns>
		public virtual SalBoolean Add(SalNumber nWhat)
		{
			#region Local Variables
			SalNumber nIndex = 0;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire) 
				{
					return true;
				}
				if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
				{
					if (Sal.IsNull(dfsTemplateSuffix)) 
					{
						strFilters[0] = "Template Files  (*.ins)";
						strFilters[1] = "*.ins";
					}
					else
					{
						strFilters[0] = "Template Files  (*.ins)";
						strFilters[1] = "*" + dfsTemplateSuffix.Text + "*.ins";
					}
					if (Ifs.Fnd.ApplicationForms.Int.PalDlgOpenFiles(this, "Add Input Template", strFilters, 2, ref nIndex, strFiles, strPaths)) 
					{
						AddToListBox();
					}
					pbOk.MethodInvestigateState();
					Sal.SetFocus(lbFiles);
				}
			}

			return false;
			#endregion
		}
		
		/// <summary>
		/// add template for merge
		/// </summary>
		/// <param name="nWhat"></param>
		/// <returns></returns>
		public virtual SalBoolean Remove(SalNumber nWhat)
		{
			#region Local Variables
			SalNumber nSelected = 0;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire) 
				{
					return true;
				}
				if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
				{
					nSelected = Sal.ListQuerySelection(lbFiles);
					Sal.ListDelete(lbFiles, nSelected);
					pbOk.MethodInvestigateState();
					Sal.SetFocus(lbFiles);
				}
			}

			return false;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean AddToListBox()
		{
			#region Local Variables
			SalNumber nCount = 0;
			SalNumber i = 0;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				nCount = strPaths.GetUpperBound(1);
				nCount = nCount + 1;
				i = 0;
				while (i < nCount)  // For each row in strPaths
				{
					Sal.ListAdd(lbFiles, strPaths[i]);
					i = i + 1;
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
		private void dlgImportTemplateFile_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Create:
					this.dlgImportTemplateFile_OnSAM_Create(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Create event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dlgImportTemplateFile_OnSAM_Create(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam);
			this.sFullName = ":i_hWndFrame." + Ifs.Fnd.ApplicationForms.Int.QualifiedItemNameGet(this);
			#endregion
		}
		#endregion
		
		#region Late Bind Methods
		
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
