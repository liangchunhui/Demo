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
	/// Dialog to create and visualize diff templates
	/// </summary>
	/// <param name="p_sCompany"></param>
	/// <param name="p_sDescription"></param>
	/// <param name="p_sSourceCompany"></param>
	/// <param name="p_sSourceTemplate"></param>
	/// <param name="p_dValidFrom"></param>
	/// <param name="p_sUpdateId"></param>
	/// <param name="p_sOldSourceTemplate"></param>
	/// <param name="p_sTempSourceTemplate"></param>
	/// <param name="p_sTempTargetTemplate"></param>
	/// <param name="p_sDiffTemplate"></param>
	public partial class dlgUpdateCompanyDiffMaster : cDialogBox
	{
		#region Window Parameters
		public SalString p_sCompany;
		public SalString p_sDescription;
		public SalString p_sSourceCompany;
		public SalString p_sSourceTemplate;
		public SalDateTime p_dValidFrom;
		public SalString p_sUpdateId;
		public SalString p_sOldSourceTemplate;
		public SalString p_sTempSourceTemplate;
		public SalString p_sTempTargetTemplate;
		public SalString p_sDiffTemplate;
		#endregion
		
		#region Window Variables
		public SalString sComponent = "";
		public SalString sLu = "";
		public SalString sDate = "";
		public SalBoolean bChildUpdated = false;
		public SalString sInStepMsg = "";
		public SalString sAttr = "";
		public cMessage msgStepMsg = new cMessage();
		public cMessage msgStepMsg2 = new cMessage();
		public SalString sStep = "";
		public SalString sStepText = "";
		public SalString lsAttribute = "";
		public SalString sColumnTranslationMsg = "";
		public cMessage cColumnTranslationMsg = new cMessage();
		public cMessage cColumnTranslationMsg2 = new cMessage();
		public cMessage cColumnTranslationMsg3 = new cMessage();
		public cMessage cColumnTranslationMsg4 = new cMessage();
		public cMessage msgDiffHeader = new cMessage();
		public cMessage msgDiffDetail = new cMessage();
		public cMessage msgInMessage = new cMessage();
		public SalString lsHeaderMessage = "";
		public SalString lsDetailMessage = "";
		public SalWindowHandle hWndDetail = SalWindowHandle.Null;
		public SalWindowHandle hWndHeader = SalWindowHandle.Null;
		public SalString sDiffTemplate = "";
		public SalNumber nWidth = 0;
		public SalNumber nHeight = 0;
		public SalNumber nY = 0;
		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		protected dlgUpdateCompanyDiffMaster()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
            this.ccDiffMaster.Orientation = PPJ.Runtime.Vis.Orientation.Horizontal;
		}
		#endregion
		
		#region System Methods/Properties
		
		/// <summary>
		/// Shows the modal dialog.
		/// </summary>
		/// <param name="owner"></param>
		/// <returns></returns>
		public static SalNumber ModalDialog(Control owner, SalString p_sCompany, SalString p_sDescription, ref SalString p_sSourceCompany, ref SalString p_sSourceTemplate, SalDateTime p_dValidFrom, ref SalString p_sUpdateId, ref SalString p_sOldSourceTemplate, ref SalString p_sTempSourceTemplate, ref SalString p_sTempTargetTemplate, ref SalString p_sDiffTemplate)
		{
			dlgUpdateCompanyDiffMaster dlg = DialogFactory.CreateInstance<dlgUpdateCompanyDiffMaster>();
			dlg.p_sCompany = p_sCompany;
			dlg.p_sDescription = p_sDescription;
			dlg.p_sSourceCompany = p_sSourceCompany;
			dlg.p_sSourceTemplate = p_sSourceTemplate;
			dlg.p_dValidFrom = p_dValidFrom;
			dlg.p_sUpdateId = p_sUpdateId;
			dlg.p_sOldSourceTemplate = p_sOldSourceTemplate;
			dlg.p_sTempSourceTemplate = p_sTempSourceTemplate;
			dlg.p_sTempTargetTemplate = p_sTempTargetTemplate;
			dlg.p_sDiffTemplate = p_sDiffTemplate;
			SalNumber ret = dlg.ShowDialog(owner);
			p_sSourceCompany = dlg.p_sSourceCompany;
			p_sSourceTemplate = dlg.p_sSourceTemplate;
			p_sUpdateId = dlg.p_sUpdateId;
			p_sOldSourceTemplate = dlg.p_sOldSourceTemplate;
			p_sTempSourceTemplate = dlg.p_sTempSourceTemplate;
			p_sTempTargetTemplate = dlg.p_sTempTargetTemplate;
			p_sDiffTemplate = dlg.p_sDiffTemplate;
			return ret;
		}
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public new static dlgUpdateCompanyDiffMaster FromHandle(SalWindowHandle handle)
		{
			return ((dlgUpdateCompanyDiffMaster)SalWindow.FromHandle(handle, typeof(dlgUpdateCompanyDiffMaster)));
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
				Sal.WaitCursor(false);
				hWndHeader = ccDiffMaster.SplitterGetFirst();
				hWndDetail = ccDiffMaster.SplitterGetSecond();
				// Header
				msgDiffHeader.Construct();
				msgDiffHeader.SetName("FRAME_STARTUP");
				msgDiffHeader.AddAttribute("COMPANY", p_sCompany);
				msgDiffHeader.AddAttribute("COMPANY_NAME", p_sDescription);
				if (p_sSourceTemplate != SalString.Null) 
				{
					msgDiffHeader.AddAttribute("UPDATE_SOURCE", p_sSourceTemplate);
					msgDiffHeader.AddAttribute("TEMPLATE", "TRUE");
				}
				else
				{
					msgDiffHeader.AddAttribute("UPDATE_SOURCE", p_sSourceCompany);
					msgDiffHeader.AddAttribute("TEMPLATE", "FALSE");
				}
				sDate = p_dValidFrom.ToString();
				msgDiffHeader.AddAttribute("VALID_FROM", sDate);
				msgDiffHeader.AddAttribute("OLD_SOURCE_TEMPLATE", p_sOldSourceTemplate);
				msgDiffHeader.AddAttribute("UPDATE_ID", p_sUpdateId);
				msgDiffHeader.AddAttribute("TEMP_SOURCE_TEMPLATE", p_sOldSourceTemplate);
				msgDiffHeader.AddAttribute("TEMP_TARGET_TEMPLATE", p_sTempTargetTemplate);
				msgDiffHeader.AddAttribute("DIFF_TEMPLATE", p_sDiffTemplate);
				lsHeaderMessage = msgDiffHeader.Pack();
				Sal.SendMsg(hWndHeader, Ifs.Fnd.ApplicationForms.Const.PAM_User, 9, lsHeaderMessage.ToHandle());
				// to details
				if (p_sDiffTemplate != SalString.Null && p_sUpdateId != SalString.Null) 
				{
					msgDiffDetail.Construct();
					msgDiffDetail.SetName("FRAME_STARTUP");
					msgDiffDetail.AddAttribute("DIFF_TEMPLATE", p_sDiffTemplate);
					msgDiffDetail.AddAttribute("COMPANY", p_sCompany);
					msgDiffDetail.AddAttribute("UPDATE_ID", p_sUpdateId);
					lsDetailMessage = msgDiffDetail.Pack();
					Sal.SendMsg(hWndDetail, Ifs.Fnd.ApplicationForms.Const.PAM_User, 10, lsDetailMessage.ToHandle());
				}
				return true;
			}
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
				if (sMethod == "GetFirst") 
				{
					return ccDiffMaster.SplitterGetFirst().ToNumber();
				}
				else if (sMethod == "GetSecond") 
				{
					return ccDiffMaster.SplitterGetSecond().ToNumber();
				}
				else if (sMethod == "GetMaster") 
				{
					return i_hWndSelf.ToNumber();
				}
				return 0;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="lsDetailMessage"></param>
		/// <returns></returns>
		public virtual SalNumber CallDetail(SalString lsDetailMessage)
		{
			#region Actions
			using (new SalContext(this))
			{
				if (hWndDetail == SalWindowHandle.Null) 
				{
					hWndDetail = ccDiffMaster.SplitterGetSecond();
				}
				Sal.SendMsg(hWndDetail, Ifs.Fnd.ApplicationForms.Const.PAM_User, 10, lsDetailMessage.ToHandle());
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="lsHeaderMessage"></param>
		/// <returns></returns>
		public virtual SalNumber CallHeader(SalString lsHeaderMessage)
		{
			#region Actions
			using (new SalContext(this))
			{
				if (hWndHeader == SalWindowHandle.Null) 
				{
					hWndHeader = ccDiffMaster.SplitterGetFirst();
				}
				Sal.SendMsg(hWndHeader, Ifs.Fnd.ApplicationForms.Const.PAM_User, 9, lsHeaderMessage.ToHandle());
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nWhat"></param>
		/// <returns></returns>
		public virtual SalNumber Cancel(SalNumber nWhat)
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
		public virtual SalNumber GenerateDiff(SalNumber nWhat)
		{
			#region Local Variables
			SalNumber nRows = 0;
			SalNumber n = 0;
			SalNumber nRows2 = 0;
			SalNumber n2 = 0;
			SalArray<SalString> sNames = new SalArray<SalString>();
			SalArray<SalString> sValues = new SalArray<SalString>();
			SalArray<SalString> sNames2 = new SalArray<SalString>();
			SalArray<SalString> sValues2 = new SalArray<SalString>();
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				switch (nWhat)
				{
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
						if (Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Company_Template_Diff_Util_API.Return_Diff_Steps__")) 
						{
							return true;
						}
						return false;
					
					case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
						sAttr = PackAttr();
						if (p_sSourceTemplate != SalString.Null) 
						{
							using(SignatureHints hints = SignatureHints.NewContext())
							{
								hints.Add("Company_Template_Diff_Util_API.Return_Diff_Steps__", System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Input);
								hints.Add("Create_Company_Tem_API.Exist", System.Data.ParameterDirection.Input);
								if (!(DbPLSQLBlock(cSessionManager.c_hSql, "Begin &AO.Company_Template_Diff_Util_API.Return_Diff_Steps__(:i_hWndFrame.dlgUpdateCompanyDiffMaster.sInStepMsg,\r\n" +
									"									:i_hWndFrame.dlgUpdateCompanyDiffMaster.sAttr);\r\n" +
									"				&AO.Create_Company_Tem_API.Exist( :i_hWndFrame.dlgUpdateCompanyDiffMaster.p_sSourceTemplate );\r\n" +
									"			     End;"))) 
								{
									return false;
								}
							}
						}
						else
						{
							using(SignatureHints hints = SignatureHints.NewContext())
							{
								hints.Add("Company_Template_Diff_Util_API.Return_Diff_Steps__", System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Input);
								DbPLSQLBlock(cSessionManager.c_hSql, "&AO.Company_Template_Diff_Util_API.Return_Diff_Steps__(:i_hWndFrame.dlgUpdateCompanyDiffMaster.sInStepMsg,\r\n" +
									"									:i_hWndFrame.dlgUpdateCompanyDiffMaster.sAttr)");
							}
						}
						msgStepMsg.Unpack(sInStepMsg);
						nRows = msgStepMsg.EnumAttributes(sNames, sValues);
						n = 0;
						MethodProgressStart(i_hWndSelf, Properties.Resources.TEXT_CreateDiffTemplate, SalString.Null, "SAVE", true, SalWindowHandle.Null);
						while (n < nRows) 
						{
							msgStepMsg2.Unpack(sValues[n]);
                            if (msgStepMsg2.Name == "SUB_MSG") 
							{
								nRows2 = msgStepMsg2.EnumAttributes(sNames2, sValues2);
								n2 = 0;
								while (n2 < nRows2) 
								{
									if (sNames2[n2] == "STEP") 
									{
										sStep = sValues2[n2];
									}
									if (sNames2[n2] == "STEP_TXT") 
									{
										sStepText = sValues2[n2];
									}
									n2 = n2 + 1;
								}
								if (sStep != SalString.Null && sStepText != SalString.Null) 
								{
									MethodProgressMessage(sStepText);
									using(SignatureHints hints = SignatureHints.NewContext())
									{
										hints.Add("Company_Template_Diff_Util_API.Generate_Diff_Template__", System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.Input);
										if (!(DbPLSQLTransaction(cSessionManager.c_hSql, "&AO.Company_Template_Diff_Util_API.Generate_Diff_Template__(:i_hWndFrame.dlgUpdateCompanyDiffMaster.sAttr,\r\n" +
											"									          :i_hWndFrame.dlgUpdateCompanyDiffMaster.sStep)"))) 
										{
											MethodProgressDone();
											return false;
										}
									}
								}
								// Clear variables after every step
								sStep = SalString.Null;
								sStepText = SalString.Null;
							}
							n = n + 1;
							MethodProgressStep();
						}
						MethodProgressDone();
						UnpackAttr(sAttr);
						// If no Diff Template Created then no diff, notify user
						if (p_sDiffTemplate == Ifs.Fnd.ApplicationForms.Const.strNULL) 
						{
							Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_NoDiffTemplateCreated, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
						}
						else
						{
							UpdateChilds();
						}
						RefreshButtonState(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
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
		/// <returns></returns>
		public new SalNumber MethodProgressCount()
		{
			#region Actions
			using (new SalContext(this))
			{
				MethodProgressStepAdd(3);
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber Ok()
		{
			#region Actions
			using (new SalContext(this))
			{
				Sal.EndDialog(i_hWndFrame, Sys.IDOK);
				return false;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="wParam"></param>
		/// <param name="lParam"></param>
		/// <returns></returns>
		public virtual SalNumber OnPamUser(SalNumber wParam, SalNumber lParam)
		{
			#region Local Variables
			SalString sName = "";
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				msgInMessage.Unpack(SalString.FromHandle(lParam));
                sName = msgInMessage.Name;
				if (sName == "CANCEL") 
				{
					Cancel(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
				}
				else if (sName == "OK") 
				{
					Ok();
				}
				else if (sName == "GENERATE") 
				{
					GenerateDiff(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute);
				}
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalString PackAttr()
		{
			#region Local Variables
			SalString sAttr = "";
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("COMPANY", p_sCompany, ref sAttr);
				Ifs.Fnd.ApplicationForms.Int.PalAttrAddDate("VALID_FROM", p_dValidFrom, ref sAttr);
				if (p_sSourceTemplate != SalString.Null) 
				{
					Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("SOURCE_TEMPLATE", p_sSourceTemplate, ref sAttr);
				}
				else
				{
					Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("SOURCE_COMPANY", p_sSourceCompany, ref sAttr);
				}
				Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("UPDATE_ID", p_sUpdateId, ref sAttr);
				// Receive Strings
				Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("OLD_SOURCE_TEMPLATE", p_sOldSourceTemplate, ref sAttr);
				Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("TEMP_SOURCE_TEMPLATE", p_sTempSourceTemplate, ref sAttr);
				Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("TEMP_TARGET_TEMPLATE", p_sTempTargetTemplate, ref sAttr);
				Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("DIFF_TEMPLATE", p_sDiffTemplate, ref sAttr);
				return sAttr;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="nWhat"></param>
		/// <returns></returns>
		public virtual SalNumber RefreshButtonState(SalNumber nWhat)
		{
			#region Actions
			using (new SalContext(this))
			{
				msgDiffHeader.Construct();
				msgDiffHeader.SetName("REFRESH");
				msgDiffHeader.AddAttribute("DUMMY", "TRUE");
				lsHeaderMessage = msgDiffHeader.Pack();
				CallHeader(lsHeaderMessage);
				return true;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="sAttr"></param>
		/// <returns></returns>
		public virtual SalNumber UnpackAttr(SalString sAttr)
		{
			#region Local Variables
			SalArray<SalString> sAttrs = new SalArray<SalString>();
			SalArray<SalString> sFields = new SalArray<SalString>();
			SalNumber n = 0;
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				sAttr.Tokenize(Ifs.Fnd.ApplicationForms.Const.strNULL, ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_RS).ToCharacter(), sAttrs);
				while (sAttrs[n] != Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					sFields[1] = Ifs.Fnd.ApplicationForms.Const.strNULL;
					sAttrs[n].Tokenize(Ifs.Fnd.ApplicationForms.Const.strNULL, ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_US).ToCharacter(), sFields);
					if (sFields[0] == "DIFF_TEMPLATE") 
					{
						p_sDiffTemplate = sFields[1];
					}
					if (sFields[0] == "UPDATE_ID") 
					{
						p_sUpdateId = sFields[1];
					}
					if (sFields[0] == "OLD_SOURCE_TEMPLATE") 
					{
						p_sOldSourceTemplate = sFields[1];
					}
					if (sFields[0] == "TEMP_SOURCE_TEMPLATE") 
					{
						p_sTempSourceTemplate = sFields[1];
					}
					if (sFields[0] == "TEMP_TARGET_TEMPLATE") 
					{
						p_sTempTargetTemplate = sFields[1];
					}
					n = n + 1;
				}
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber UpdateChilds()
		{
			#region Actions
			using (new SalContext(this))
			{
				// to header
				msgDiffHeader.Construct();
				msgDiffHeader.SetName("REGENERATED");
				msgDiffHeader.AddAttribute("COMPANY", p_sCompany);
				msgDiffHeader.AddAttribute("COMPANY_NAME", p_sDescription);
				if (p_sSourceTemplate != SalString.Null) 
				{
					msgDiffHeader.AddAttribute("UPDATE_SOURCE", p_sSourceTemplate);
					msgDiffHeader.AddAttribute("TEMPLATE", "TRUE");
				}
				else
				{
					msgDiffHeader.AddAttribute("UPDATE_SOURCE", p_sSourceCompany);
					msgDiffHeader.AddAttribute("TEMPLATE", "FALSE");
				}
				sDate = p_dValidFrom.ToString();
				msgDiffHeader.AddAttribute("VALID_FROM", sDate);
				msgDiffHeader.AddAttribute("OLD_SOURCE_TEMPLATE", p_sOldSourceTemplate);
				msgDiffHeader.AddAttribute("UPDATE_ID", p_sUpdateId);
				msgDiffHeader.AddAttribute("TEMP_SOURCE_TEMPLATE", p_sOldSourceTemplate);
				msgDiffHeader.AddAttribute("TEMP_TARGET_TEMPLATE", p_sTempTargetTemplate);
				msgDiffHeader.AddAttribute("DIFF_TEMPLATE", p_sDiffTemplate);
				lsHeaderMessage = msgDiffHeader.Pack();
				CallHeader(lsHeaderMessage);
				// to details
				msgDiffDetail.Construct();
				msgDiffDetail.SetName("REGENERATED");
				msgDiffDetail.AddAttribute("DIFF_TEMPLATE", p_sDiffTemplate);
				msgDiffDetail.AddAttribute("UPDATE_ID", p_sUpdateId);
				msgDiffDetail.AddAttribute("COMPANY", p_sCompany);
				lsDetailMessage = msgDiffDetail.Pack();
				// send 10 to populate
				CallDetail(lsDetailMessage);
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
		private void dlgUpdateCompanyDiffMaster_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PAM_User:
					this.dlgUpdateCompanyDiffMaster_OnPAM_User(sender, e);
					break;
				
				
				case Sys.SAM_CreateComplete:
					this.dlgUpdateCompanyDiffMaster_OnSAM_CreateComplete(sender, e);
					break;
				
			}
			#endregion
		}
		
		/// <summary>
		/// PAM_User event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dlgUpdateCompanyDiffMaster_OnPAM_User(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sys.wParam == 10) 
			{
				e.Return = this.OnPamUser(Sys.wParam, Sys.lParam);
				return;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_CreateComplete event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dlgUpdateCompanyDiffMaster_OnSAM_CreateComplete(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			Sal.SendClassMessage(Sys.SAM_CreateComplete, Sys.wParam, Sys.lParam);
			Sal.SendMsg(dlgUpdateCompanyDiffMaster.FromHandle(this.i_hWndFrame).ccDiffMaster, Const.PAM_SetDiffSplitterPosition, 0, 0);
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void ccDiffMaster_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				
				case Const.PAM_SetDiffSplitterPosition:
					this.ccDiffMaster_OnPAM_SetDiffSplitterPosition(sender, e);
					break;
				
			}
			#endregion
		}
		
		/// <summary>
		/// PAM_SetDiffSplitterPosition event handler.
		/// </summary>
		/// <param name="message"></param>
		private void ccDiffMaster_OnPAM_SetDiffSplitterPosition(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.ccDiffMaster.nY = 1.5m;
			this.ccDiffMaster.nY = Ifs.Fnd.ApplicationForms.Var.Profile.ValueNumberGet(Ifs.Fnd.ApplicationForms.Int.QualifiedItemNameGet(this.ccDiffMaster), "Y_Pos", this.ccDiffMaster.nY);
			Sal.GetWindowSize(this, ref this.nWidth, ref this.nHeight);
			this.ccDiffMaster.nY = Vis.NumberChoose(this.nHeight > this.ccDiffMaster.nY, this.ccDiffMaster.nY, this.nHeight - 0.5m);
			this.ccDiffMaster.nY = Vis.NumberChoose(this.ccDiffMaster.nY <= 0, 2, this.ccDiffMaster.nY);
			Sal.SetWindowLoc(this.ccDiffMaster, 0, this.ccDiffMaster.nY);
			this.ccDiffMaster.ResizeObjects();
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
		public override SalNumber vrtMethodProgressCount()
		{
			return this.MethodProgressCount();
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
