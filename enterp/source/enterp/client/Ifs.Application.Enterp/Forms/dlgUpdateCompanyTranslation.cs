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
	/// <param name="sCompany"></param>
	/// <param name="sAccCurr"></param>
	/// <param name="dValidFrom"></param>
	/// <param name="lsAttr"></param>
	/// <param name="lsAttrUpdate"></param>
	[FndWindowRegistration("COMPANY_KEY_LU_TRANSLATION,TEMPL_KEY_LU_TRANSLATION", "Company")]
	public partial class dlgUpdateCompanyTranslation : cDialogBox
	{
		#region Window Parameters
		public SalString sCompany;
		public SalString sAccCurr;
		public SalDateTime dValidFrom;
		public SalString lsAttr;
		public SalString lsAttrUpdate;
		#endregion
		
		#region Window Variables
		public SalString sErrorCreated = "";
		public SalNumber nSteps = 0;
		public SalString sFullName = "";
		public SalString sMessage = "";
		public SalString sModuleVariable = "";
		public SalString sPackageNameVariable = "";
		public SalString sTitle = "";
		public SalString sCompName = "";
		public SalNumber nExecId = 0;
		public SalWindowHandle hLastWithFocus = SalWindowHandle.Null;
		public SalArray<SalString> sTemplateLngs = new SalArray<SalString>();
		public SalString sTemplateLng = "";
		public SalArray<SalString> sTemplateLngDescs = new SalArray<SalString>();
		public SalString sTemplateLngDesc = "";
		public SalArray<SalString> sExistingLngs = new SalArray<SalString>();
		public SalArray<SalString> sExistingLngDescs = new SalArray<SalString>();
		public SalString sLanguages = "";
		public SalString lsTemplateName = "";
		public SalNumber nNum = 0;
		public SalArray<SalString> sRecords = new SalArray<SalString>();
		public SalArray<SalString> sUnits = new SalArray<SalString>();
		public SalString sSource = "";
		public SalString sSourceValue = "";
		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		protected dlgUpdateCompanyTranslation()
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
		public static SalNumber ModalDialog(Control owner, SalString sCompany, SalString sAccCurr, SalDateTime dValidFrom, SalString lsAttr, SalString lsAttrUpdate)
		{
			dlgUpdateCompanyTranslation dlg = DialogFactory.CreateInstance<dlgUpdateCompanyTranslation>();
			dlg.sCompany = sCompany;
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
		public new static dlgUpdateCompanyTranslation FromHandle(SalWindowHandle handle)
		{
			return ((dlgUpdateCompanyTranslation)SalWindow.FromHandle(handle, typeof(dlgUpdateCompanyTranslation)));
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
				Sal.DisableWindow(lbExistingLanguage);
				Sal.WaitCursor(true);
				if (dfFromCompany.Text == Ifs.Fnd.ApplicationForms.Const.strNULL && dfFromTemplateId.Text == Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					Sal.DisableWindow(pbOk);
					GetDefaultTemplate();
					GetExistingLanguages();
					FetchToExistingLngListBox();
					GetAvailableLanguages("NewTemplate");
					FetchToAvailableLngListBox();
					Sal.SetFocus(lbAvailableLanguage);
				}
				else
				{
					if (dfFromCompany.Text != Ifs.Fnd.ApplicationForms.Const.strNULL) 
					{
						GetExistingLanguages();
						FetchToExistingLngListBox();
						GetAvailableLanguages("Company");
						FetchToAvailableLngListBox();
					}
					else
					{
						GetExistingLanguages();
						FetchToExistingLngListBox();
						GetAvailableLanguages("Template");
						FetchToAvailableLngListBox();
					}
					Sal.SetFocus(pbOk);
				}
				Sal.WaitCursor(false);
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
					return UM_Ok(nWhat);
				}
				else if (sAction == "CancelButton") 
				{
					// Select Case nWhat
					// Case METHOD_Inquire
					// Return TRUE
					// Case METHOD_Execute
					// Call SalEndDialog ( i_hWndFrame, IDCANCEL)
					// Case METHOD_GetType
					// Return CHILDTYPE_Any
					return UM_Cancel(nWhat);
				}
				else if (sAction == "ListButton") 
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
				else if (sAction == "Populate") 
				{
					return UM_Populate(nWhat);
				}
			}

			return false;
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
						if (dfFromCompany.Text == Ifs.Fnd.ApplicationForms.Const.strNULL && dfFromTemplateId.Text == Ifs.Fnd.ApplicationForms.Const.strNULL && dfsTemplateId.Text == Ifs.Fnd.ApplicationForms.Const.strNULL) 
						{
							return false;
						}
						return true;
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
						if (UpdateCompanyTranslation()) 
						{
							Sal.EndDialog(i_hWndFrame, Sys.IDOK);
						}
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
		public virtual SalNumber UM_Populate(SalNumber nWhat)
		{
			#region Actions
			using (new SalContext(this))
			{
				switch (nWhat)
				{
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
						return !(Sal.IsNull(dfsTemplateId)) && Ifs.Fnd.ApplicationForms.Var.Security.IsViewAvailable("Templ_Translation_Lng");
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
						GetAvailableLanguages("NewTemplate");
						FetchToAvailableLngListBox();
						return true;
				}
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// Displays a dialog with progress bar
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber DisplayProgresBar()
		{
			#region Local Variables
			SalString sHeading = "";
			SalString sCreate = "";
			SalArray<SalString> sAttrs = new SalArray<SalString>();
			SalArray<SalString> sFields = new SalArray<SalString>();
			SalNumber n = 0;
			SalSqlHandle hSql = SalSqlHandle.Null;
			SalBoolean bOk = false;
			SalArray<SalString> sParams = new SalArray<SalString>();
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				sParams[0] = dfCompany.Text;
				MethodProgressStart(i_hWndSelf, Ifs.Fnd.ApplicationForms.Int.TranslateConstantWithParams(Properties.Resources.TEXT_UpdateCompanyTranslation, sParams), "Update", "SAVE", true, SalWindowHandle.Null);
				n = 1;
				nSteps = lsAttr.Tokenize(Ifs.Fnd.ApplicationForms.Const.strNULL, ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_RS).ToCharacter(), sAttrs);
				MethodProgressStepAdd(nSteps);
				if (!(DbConnect(ref hSql))) 
				{
					return false;
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
						sParams[0] = sModuleVariable;
						MethodProgressMessage(Ifs.Fnd.ApplicationForms.Int.TranslateConstantWithParams(Properties.Resources.TEXT_UpdateCompanyTranslationIn, sParams));
						if (DbTransactionBegin(ref cSessionManager.c_hSql)) 
						{
							using(SignatureHints hints = SignatureHints.NewContext())
							{
								hints.Add("Create_Company_API.Create_New_Company__", System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
								bOk = DbPLSQLBlock(hSql, "&AO.Create_Company_API.Create_New_Company__( :i_hWndFrame.dlgUpdateCompanyTranslation.sErrorCreated,\r\n" +
									"                                                                                                                                            :i_hWndFrame.dlgUpdateCompanyTranslation.dfCompany,\r\n" +
									"								            :i_hWndFrame.dlgUpdateCompanyTranslation.sModuleVariable,\r\n" +
									"								            :i_hWndFrame.dlgUpdateCompanyTranslation.sPackageNameVariable,\r\n" +
									"								            :i_hWndFrame.dlgUpdateCompanyTranslation.lsAttrUpdate,\r\n" +
									"								            :i_hWndFrame.dlgUpdateCompanyTranslation.sLanguages )");
							}
							if (!(bOk)) 
							{
								DbTransactionClear(cSessionManager.c_hSql);
								return false;
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
				DbDisconnect(hSql);
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// Insert components to lbLngList
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean FetchToExistingLngListBox()
		{
			#region Local Variables
			SalNumber nCount = 0;
			SalNumber i = 0;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				Sal.ListClear(lbExistingLanguage);
				nCount = sExistingLngDescs.GetUpperBound(1);
				nCount = nCount + 1;
				i = 0;
				while (i < nCount) 
				{
					if (sExistingLngDescs[i] != Ifs.Fnd.ApplicationForms.Const.strNULL) 
					{
						lbExistingLanguage.AddValue(sExistingLngDescs[i], true, i);
					}
					i = i + 1;
				}
				return true;
			}
			#endregion
		}
		
		/// <summary>
		/// Insert components to lbLngList
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean FetchToAvailableLngListBox()
		{
			#region Local Variables
			SalNumber nCount = 0;
			SalNumber i = 0;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				Sal.ListClear(lbAvailableLanguage);
				nCount = sTemplateLngDescs.GetUpperBound(1);
				nCount = nCount + 1;
				i = 0;
				while (i < nCount) 
				{
					if (sTemplateLngDescs[i] != Ifs.Fnd.ApplicationForms.Const.strNULL) 
					{
						lbAvailableLanguage.AddValue(sTemplateLngDescs[i], false, i);
					}
					i = i + 1;
				}
				return true;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber GetDefaultTemplate()
		{
			#region Local Variables
			SalString lsStmt = "";
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				if (Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Create_Company_Tem_API.Get_Default_Template__")) 
				{
					lsStmt = "Declare\r\n" +
					"                     template_id_ varchar2(30);\r\n" +
					"                BEGIN\r\n" +
					"	&AO.Create_Company_Tem_API.Get_Default_Template__ ( template_id_);\r\n" +
					"                :i_hWndFrame.dlgUpdateCompanyTranslation.dfsTemplateName := &AO.Create_Company_Tem_API.Get_Description(template_id_);\r\n" +
					"                :i_hWndFrame.dlgUpdateCompanyTranslation.dfsTemplateId := template_id_;\r\n" +
					"                END;";
					using(SignatureHints hints = SignatureHints.NewContext())
					{
						hints.Add("Create_Company_Tem_API.Get_Default_Template__", System.Data.ParameterDirection.InputOutput);
						hints.Add("Create_Company_Tem_API.Get_Description", System.Data.ParameterDirection.Input);
						DbPLSQLBlock(cSessionManager.c_hSql, lsStmt);
					}
				}
			}

			return 0;
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
				sExistingLngDescs.SetUpperBound(1, -1);
				if (Ifs.Fnd.ApplicationForms.Var.Security.IsViewAvailable("Company_Translation_Lng")) 
				{
					lsStmt = "SELECT language_code, &AO.Iso_Language_API.Decode(language_code) description into\r\n	" + sFullName + ".sTemplateLng, " + sFullName + ".sTemplateLngDesc\r\n" +
					"	FROM &AO.Company_Translation_Lng\r\n" +
					"	WHERE key_name = 'CompanyKeyLu'\r\n" +
					"	AND key_value =  " + sFullName + ".dfCompany\r\n" +
					"	group by language_code\r\n" +
					"                order by 2";
					DbPrepareAndExecute(cSessionManager.c_hSql, lsStmt);
					while (DbFetchNext(cSessionManager.c_hSql, ref nDummy)) 
					{
						sExistingLngs[i] = sTemplateLng;
						sExistingLngDescs[i] = sTemplateLngDesc;
						i = i + 1;
					}
				}
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="sSource"></param>
		/// <returns></returns>
		public virtual SalNumber GetAvailableLanguages(SalString sSource)
		{
			#region Local Variables
			SalString lsStmt = "";
			SalNumber i = 0;
			SalNumber nDummy = 0;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				sTemplateLngs.SetUpperBound(1, -1);
				sTemplateLngDescs.SetUpperBound(1, -1);
				if (sSource == "Company") 
				{
					if (Ifs.Fnd.ApplicationForms.Var.Security.IsViewAvailable("Company_Translation_Lng")) 
					{
						lsStmt = "SELECT language_code, &AO.Iso_Language_API.Decode(language_code) description into\r\n	" + sFullName + ".sTemplateLng, " + sFullName + ".sTemplateLngDesc\r\n" +
						"	FROM &AO.Company_Translation_Lng\r\n" +
						"	WHERE key_name = 'CompanyKeyLu'\r\n" +
						"	AND key_value =  " + sFullName + ".dfFromCompany\r\n" +
						"	group by language_code\r\n" +
						"                order by 2";
						DbPrepareAndExecute(cSessionManager.c_hSql, lsStmt);
						while (DbFetchNext(cSessionManager.c_hSql, ref nDummy)) 
						{
							sTemplateLngs[i] = sTemplateLng;
							sTemplateLngDescs[i] = sTemplateLngDesc;
							i = i + 1;
						}
					}
				}
				else if (sSource == "Template") 
				{
					if (Ifs.Fnd.ApplicationForms.Var.Security.IsViewAvailable("Templ_Translation_Lng")) 
					{
						lsStmt = "SELECT language_code, &AO.Iso_Language_API.Decode(language_code) description into\r\n	" + sFullName + ".sTemplateLng, " + sFullName + ".sTemplateLngDesc\r\n" +
						"	FROM &AO.Templ_Translation_Lng\r\n" +
						"	WHERE key_name = 'TemplKeyLu'\r\n" +
						"	AND key_value =  " + sFullName + ".dfFromTemplateId\r\n" +
						"	group by language_code\r\n" +
						"                order by 2";
						DbPrepareAndExecute(cSessionManager.c_hSql, lsStmt);
						while (DbFetchNext(cSessionManager.c_hSql, ref nDummy)) 
						{
							sTemplateLngs[i] = sTemplateLng;
							sTemplateLngDescs[i] = sTemplateLngDesc;
							i = i + 1;
						}
					}
				}
				else if (sSource == "NewTemplate") 
				{
					if (Ifs.Fnd.ApplicationForms.Var.Security.IsViewAvailable("Templ_Translation_Lng")) 
					{
						lsStmt = "SELECT language_code, &AO.Iso_Language_API.Decode(language_code) description into\r\n	" + sFullName + ".sTemplateLng, " + sFullName + ".sTemplateLngDesc\r\n" +
						"	FROM &AO.Templ_Translation_Lng\r\n" +
						"	WHERE key_name = 'TemplKeyLu'\r\n" +
						"	AND key_value =  " + sFullName + ".dfsTemplateId\r\n" +
						"	group by language_code\r\n" +
						"                order by 2";
						DbPrepareAndExecute(cSessionManager.c_hSql, lsStmt);
						while (DbFetchNext(cSessionManager.c_hSql, ref nDummy)) 
						{
							sTemplateLngs[i] = sTemplateLng;
							sTemplateLngDescs[i] = sTemplateLngDesc;
							i = i + 1;
						}
					}
				}
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber PackSelectedLangauges()
		{
			#region Local Variables
			SalNumber nSelected = 0;
			SalNumber nCounter = 0;
			SalNumber nIndex = 0;
			SalString strText = "";
			SalString sSelectedLanguage = "";
			SalArray<SalNumber> nSelectedArray = new SalArray<SalNumber>();
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				sLanguages = Ifs.Fnd.ApplicationForms.Const.strNULL;
				if (Sal.ListQueryMultiCount(lbAvailableLanguage) > 0) 
				{
					nSelected = Sal.ListQueryMultiCount(lbAvailableLanguage);
					Sal.ListGetMultiSelect(lbAvailableLanguage, nSelectedArray);
					sLanguages = Ifs.Fnd.ApplicationForms.Const.strNULL;
					nCounter = 0;
					while (nCounter < nSelected) 
					{
						strText = Vis.ListGetText(lbAvailableLanguage, nSelectedArray[nCounter]);
						nIndex = Vis.ArrayFindString(sTemplateLngDescs, strText);
						sSelectedLanguage = sTemplateLngs[nIndex];
						sLanguages = sLanguages + sSelectedLanguage + ((SalNumber)31).ToCharacter();
						nCounter = nCounter + 1;
					}
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
				pbPopulate.MethodInvestigateState();
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber UpdateCompanyTranslation()
		{
			#region Actions
			using (new SalContext(this))
			{
				PackSelectedLangauges();
				if (sLanguages == Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					return true;
				}
				Sal.WaitCursor(true);
				using(SignatureHints hints = SignatureHints.NewContext())
				{
					hints.Add("Create_Company_API.New_Company__", System.Data.ParameterDirection.InputOutput);
					if (!(DbPLSQLBlock(cSessionManager.c_hSql, "&AO.Create_Company_API.New_Company__( " + sFullName + ".lsAttr )"))) 
					{
						return false;
					}
				}
				if (!(Sal.IsNull(dfsTemplateId))) 
				{
					Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("UPDATE_FROM_TEMPLATE", dfsTemplateId.Text, ref lsAttrUpdate);
				}
				Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("FROM_WINDOW", "UPDATE_TRANSLATION", ref lsAttrUpdate);
				Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("MAIN_PROCESS", "UPDATE TRANSLATION", ref lsAttrUpdate);
				DisplayProgresBar();
				Sal.WaitCursor(false);
				return true;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalBoolean ValidateAndGetTemplateName()
		{
			#region Actions
			using (new SalContext(this))
			{
				using(SignatureHints hints = SignatureHints.NewContext())
				{
					hints.Add("Create_Company_Tem_API.Exist", System.Data.ParameterDirection.Input);
					hints.Add("Create_Company_Tem_API.Get_Description", System.Data.ParameterDirection.Input);
					if (!(DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN\r\n" +
						"		        &AO.Create_Company_Tem_API.Exist(:i_hWndFrame.dlgUpdateCompanyTranslation.dfsTemplateId);\r\n" +
						"		         :i_hWndFrame.dlgUpdateCompanyTranslation.lsTemplateName :=\r\n" +
						"		         &AO.Create_Company_Tem_API.Get_Description(:i_hWndFrame.dlgUpdateCompanyTranslation.dfsTemplateId);\r\n" +
						"		      END;"))) 
					{
						return false;
					}
				}
				if (lsTemplateName != Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					dfsTemplateName.Text = lsTemplateName;
				}
				else
				{
					dfsTemplateName.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
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
		private void dlgUpdateCompanyTranslation_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Create:
					this.dlgUpdateCompanyTranslation_OnSAM_Create(sender, e);
					break;
				
				case Sys.SAM_Close:
					e.Handled = true;
					Sal.EndDialog(this.i_hWndFrame, Sys.IDCANCEL);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Create event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dlgUpdateCompanyTranslation_OnSAM_Create(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam);
			this.sFullName = ":i_hWndFrame." + Ifs.Fnd.ApplicationForms.Int.QualifiedItemNameGet(this);
			Sal.CenterWindow(this.i_hWndFrame);
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void pbOk_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_SetFocus:
					this.pbOk_OnSAM_SetFocus(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void pbOk_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.hLastWithFocus = this.pbOk;
			this.RefreshButtonsState();
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void pbCancel_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_SetFocus:
					this.pbCancel_OnSAM_SetFocus(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void pbCancel_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.hLastWithFocus = this.pbCancel;
			this.RefreshButtonsState();
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void pbPopulate_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_SetFocus:
					this.pbPopulate_OnSAM_SetFocus(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void pbPopulate_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.hLastWithFocus = this.pbPopulate;
			this.RefreshButtonsState();
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void lbAvailableLanguage_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_SetFocus:
					this.lbAvailableLanguage_OnSAM_SetFocus(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void lbAvailableLanguage_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.hLastWithFocus = this.lbAvailableLanguage;
			this.RefreshButtonsState();
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dfsTemplateId_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_SetFocus:
					this.dfsTemplateId_OnSAM_SetFocus(sender, e);
					break;
				
				case Sys.SAM_AnyEdit:
					this.dfsTemplateId_OnSAM_AnyEdit(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
					this.dfsTemplateId_OnPM_DataItemValidate(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovDone:
					this.dfsTemplateId_OnPM_DataItemLovDone(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfsTemplateId_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.hLastWithFocus = this.dfsTemplateId;
			this.RefreshButtonsState();
			e.Return = Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
		
		/// <summary>
		/// SAM_AnyEdit event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfsTemplateId_OnSAM_AnyEdit(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (this.dfFromCompany.Text == Ifs.Fnd.ApplicationForms.Const.strNULL && this.dfFromTemplateId.Text == Ifs.Fnd.ApplicationForms.Const.strNULL && this.dfsTemplateId.Text == Ifs.Fnd.ApplicationForms.Const.strNULL) 
			{
				Sal.DisableWindow(this.pbOk);
			}
			else
			{
				Sal.EnableWindow(this.pbOk);
			}
			this.RefreshButtonsState();
			#endregion
		}
		
		/// <summary>
		/// PM_DataItemValidate event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfsTemplateId_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam)) 
			{
				if (this.dfsTemplateId.Text != Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					this.ValidateAndGetTemplateName();
					this.GetAvailableLanguages("NewTemplate");
					this.FetchToAvailableLngListBox();
				}
				else
				{
					Sal.ClearField(this.dfsTemplateName);
				}
				e.Return = Sys.VALIDATE_Ok;
				return;
			}
			e.Return = Sys.VALIDATE_Cancel;
			return;
			#endregion
		}
		
		/// <summary>
		/// PM_DataItemLovDone event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfsTemplateId_OnPM_DataItemLovDone(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (!(Sal.IsNull(this.dfsTemplateId))) 
			{
				this.nNum = SalString.FromHandle(Sys.lParam).Tokenize("", ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_RS).ToCharacter(), this.sRecords);
				this.nNum = this.sRecords[1].Tokenize("", ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_US).ToCharacter(), this.sUnits);
				if (this.sUnits[0] == "DESCRIPTION") 
				{
					this.dfsTemplateName.Text = this.sUnits[1];
				}
				this.GetAvailableLanguages("NewTemplate");
				this.FetchToAvailableLngListBox();
			}
			e.Return = true;
			return;
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
