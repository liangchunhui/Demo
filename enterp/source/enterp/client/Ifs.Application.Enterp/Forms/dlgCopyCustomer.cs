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
// 120913   MaRalk  PBR-446, Modified methods FrameStartupUser, dfsIdentity_WindowActions-Sys.SAM_FieldEdit to retrieve copying from customer categry.
// 120913           Added parameter category to the Customer_Info_API.Copy_Existing_Customer method call in SaveCustomer function.
// 120928   MaRalk  PBR-508, Added window actions to the cmbNewCustomerCategory field.
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
	public partial class dlgCopyCustomer : cDialogBox
	{
		#region Window Variables
		public SalSqlHandle hSql = SalSqlHandle.Null;
		public SalWindowHandle hWndLovField = SalWindowHandle.Null;
		public SalNumber nNum = 0;
		public SalArray<SalString> sRecords = new SalArray<SalString>();
		public SalArray<SalString> sUnits = new SalArray<SalString>();
		public SalString sCompany = "";
		public SalString sPartyType = "";
		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		protected dlgCopyCustomer()
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
			dlgCopyCustomer dlg = DialogFactory.CreateInstance<dlgCopyCustomer>();
			SalNumber ret = dlg.ShowDialog(owner);
			return ret;
		}
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public new static dlgCopyCustomer FromHandle(SalWindowHandle handle)
		{
			return ((dlgCopyCustomer)SalWindow.FromHandle(handle, typeof(dlgCopyCustomer)));
		}
		#endregion
		
		#region Methods
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
        public virtual SalBoolean SaveCustomer()
        {
            using (new SalContext(this))
            {
                Sal.WaitCursor(true);
                UserGlobalValueGet("COMPANY", ref sCompany);

                if (DbPLSQLBlock(@"&AO.Customer_Info_API.Copy_Existing_Customer({0} IN, {1} IN, {2} IN, {3} IN, {4} IN, {5} IN);",
                    this.dfsIdentity.QualifiedBindName,
                    this.dfsNewIdentity.QualifiedBindName,
                    this.QualifiedVarBindName("sCompany"),
                    this.dfsNewName.QualifiedBindName,
                    this.cmbNewCustomerCategory.QualifiedBindName,
                    this.dfsAssocNo.QualifiedBindName))
                {
                    if (dfsNewIdentity.Text == Ifs.Fnd.ApplicationForms.Const.strNULL)
                    {
                        sPartyType = "CUSTOMER";
                        DbImmediate("SELECT ( &AO.party_type_api.decode(:i_hWndFrame.dlgCopyCustomer.sPartyType))" + " INTO :i_hWndFrame.dlgCopyCustomer.sPartyType FROM dual");
                        using (SignatureHints hints1 = SignatureHints.NewContext())
                        {
                            hints1.Add("PARTY_IDENTITY_SERIES_API.Get_Next_Value", System.Data.ParameterDirection.Input);
                            DbPLSQLBlock(cSessionManager.c_hSql, ":i_hWndFrame.dlgCopyCustomer.dfsNewIdentity := &AO.PARTY_IDENTITY_SERIES_API.Get_Next_Value( :i_hWndFrame.dlgCopyCustomer.sPartyType )");
                        }
                        dfsNewIdentity.Text = (((SalString)dfsNewIdentity.Text).ToNumber() - 1).ToString(0);
                    }
                    SalArray<SalString> sItemNames = new SalArray<SalString>();
                    SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();

                    sItemNames[0] = "CUSTOMER_ID";
                    hWndItems[0] = dfsNewIdentity;
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init(Ifs.Fnd.ApplicationForms.Int.QualifiedItemNameGet(this), this, sItemNames, hWndItems);
                    Sal.WaitCursor(false);
                    return true;
                }
                else
                {
                    Sal.WaitCursor(false);
                    return false;
                }

            }
        }
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber SetWindowTitle()
		{
			#region Actions
			using (new SalContext(this))
			{
				Sal.SetWindowText(i_hWndFrame, Properties.Resources.HEAD_CopyCustomer);
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
				if (sMethod == "ok") 
				{
					switch (nWhat)
					{
						case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
							return 1;
						
						case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
							if (!(CheckAssociationNumber())) 
							{
								return 1;
							}
							if (SaveCustomer()) 
							{
								Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Sys.wParam, Sys.lParam);
								return Sal.EndDialog(this, Sys.IDOK);
							}
							else
							{
								return 1;
							}
							break;
					}
				}
				else if (sMethod == "cancel") 
				{
					switch (nWhat)
					{
						case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
							return 1;
						
						case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
							Sal.EndDialog(this, Sys.IDCANCEL);
							break;
					}
				}
				else if (sMethod == "list") 
				{
					switch (nWhat)
					{
						case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
							return 1;
						
						case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
							if (hWndLovField != SalWindowHandle.Null) 
							{
								if (Sal.SendMsg(hWndLovField, Ifs.Fnd.ApplicationForms.Const.PM_DataItemLov, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0)) 
								{
									Sal.SetFocus(hWndLovField);
									Sal.SendMsg(hWndLovField, Sys.SAM_Validate, 0, 0);
								}
								else
								{
									Sal.SetFocus(hWndLovField);
								}
							}
							break;
					}
				}
			}

			return 0;
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
					DbPLSQLBlock(cSessionManager.c_hSql, ":hWndForm.dlgCopyCustomer.dfsExist :=\r\n" +
						"                                 &AO.Association_Info_API.Association_No_Exist( :hWndForm.dlgCopyCustomer.dfsAssocNo, 'CUSTOMER' )");
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
		public new SalBoolean FrameStartupUser()
		{
			#region Actions
			using (new SalContext(this))
			{
				dfsIdentity.Text = frmCustomerInfo.FromHandle(i_hWndParent).cmbCustomerId.i_sMyValue;
                dfsName.Text = frmCustomerInfo.FromHandle(i_hWndParent).dfsName.Text;
                dfsCategory.Text = frmCustomerInfo.FromHandle(i_hWndParent).cmbCustomerCategory.i_sMyValue;
                Sal.SendMsg(dfsIdentity, Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
			}

			return false;
			#endregion
		}
		#endregion
		
		#region Window Actions
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dlgCopyCustomer_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Create:
					this.dlgCopyCustomer_OnSAM_Create(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Create event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dlgCopyCustomer_OnSAM_Create(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam)) 
			{
				Sal.CenterWindow(this);
				Sal.SetFocus(this.dfsIdentity);
				this.SetWindowTitle();
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
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dfsIdentity_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_SetFocus:
					this.dfsIdentity_OnSAM_SetFocus(sender, e);
					break;
				
				case Sys.SAM_KillFocus:
					this.dfsIdentity_OnSAM_KillFocus(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovDone:
					this.dfsIdentity_OnPM_DataItemLovDone(sender, e);
					break;
				
				case Sys.SAM_FieldEdit:
					e.Handled = true;
                   DbPLSQLBlock(cSessionManager.c_hSql, @":hWndForm.dlgCopyCustomer.dfsName := SUBSTR(&AO.Customer_Info_API.Get_Name(:hWndForm.dlgCopyCustomer.dfsIdentity IN),1,100);
                                                          :hWndForm.dlgCopyCustomer.dfsCategory := &AO.Customer_Info_API.Get_Customer_Category(:hWndForm.dlgCopyCustomer.dfsIdentity IN);");
                   
					break;
				
				case Sys.SAM_AnyEdit:
					e.Handled = true;
					e.Return = true;
					return;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_SetFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfsIdentity_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam)) 
			{
				if (this.dfsIdentity.p_sLovReference != Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					this.hWndLovField = this.dfsIdentity.i_hWndSelf;
					cObjectRelationManager.__bLOV = false;
					Sal.EnableWindow(this.pbList);
				}
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_KillFocus event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfsIdentity_OnSAM_KillFocus(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sys.wParam.ToWindowHandle() != this.pbList.i_hWndSelf) 
			{
				this.hWndLovField = SalWindowHandle.Null;
				Sal.DisableWindow(this.pbList);
			}
			#endregion
		}
		
		/// <summary>
		/// PM_DataItemLovDone event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dfsIdentity_OnPM_DataItemLovDone(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.nNum = SalString.FromHandle(Sys.lParam).Tokenize("", ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_RS).ToCharacter(), this.sRecords);
			this.nNum = this.sRecords[1].Tokenize("", ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_US).ToCharacter(), this.sUnits);
			if (this.sUnits[0] == "NAME") 
			{
				Sal.SendMsg(this.dfsName, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 0, this.sUnits[1].ToHandle());
			}
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dfsNewIdentity_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_AnyEdit:
					e.Handled = true;
					e.Return = true;
					return;
			}
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dfsNewName_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_AnyEdit:
					e.Handled = true;
					e.Return = true;
					return;
			}
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void dfsAssocNo_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				
				case Sys.SAM_AnyEdit:
					e.Handled = true;
					e.Return = true;
					return;
			}
			#endregion
		}

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void cmbNewCustomerCategory_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_AnyEdit:
                    e.Handled = true;
                    e.Return = true;                   
                    return;
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
