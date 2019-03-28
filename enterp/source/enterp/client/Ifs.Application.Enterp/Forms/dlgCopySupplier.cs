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
// 150617   RoJalk  ORA-656, Replaced Supplier_Info_API.Get_Name with Supplier_Info_General_API.Get_Name.
// 150617   RoJalk  ORA-656, Replaced Supplier_Info_API.Copy_Existing_Supplier_Inv with Supplier_Info_General_API.Copy_Existing_Supplier_Inv.
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
	public partial class dlgCopySupplier : cDialogBox
	{
		#region Window Variables
		public SalSqlHandle hSql = SalSqlHandle.Null;
		public SalWindowHandle hWndLovField = SalWindowHandle.Null;
		public SalNumber nNum = 0;
		public SalArray<SalString> sRecords = new SalArray<SalString>();
		public SalArray<SalString> sUnits = new SalArray<SalString>();
		public SalString sCompany = "";
		public SalString sPartyType = "";
        public SalString sLanguage = null;
        public SalString sCountry = null;
		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		protected dlgCopySupplier()
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
			dlgCopySupplier dlg = DialogFactory.CreateInstance<dlgCopySupplier>();
			SalNumber ret = dlg.ShowDialog(owner);
			return ret;
		}
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public new static dlgCopySupplier FromHandle(SalWindowHandle handle)
		{
			return ((dlgCopySupplier)SalWindow.FromHandle(handle, typeof(dlgCopySupplier)));
		}
		#endregion
		
		#region Methods
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
        public virtual SalBoolean SaveSupplier()
        {
            using (new SalContext(this))
            {
                Sal.WaitCursor(true);
                UserGlobalValueGet("COMPANY", ref sCompany);
                if (DbPLSQLBlock("&AO.Supplier_Info_General_API.Copy_Existing_Supplier_Inv( {0} IN, {1} IN, {2} IN, {3} IN, {4} IN, {5} IN, {6} IN );",
                    this.dfsIdentity.QualifiedBindName,
                    this.dfsNewIdentity.QualifiedBindName,
                    this.QualifiedVarBindName("sCompany"),
                    this.dfsNewName.QualifiedBindName,
                    this.QualifiedVarBindName("sLanguage"),
                    this.QualifiedVarBindName("sCountry"),
                    this.dfsAssocNo.QualifiedBindName))
                {
                    if (dfsNewIdentity.Text == Ifs.Fnd.ApplicationForms.Const.strNULL)
                    {
                        sPartyType = "SUPPLIER";
                        DbImmediate("SELECT ( &AO.party_type_api.decode(:i_hWndFrame.dlgCopySupplier.sPartyType)) INTO :i_hWndFrame.dlgCopySupplier.sPartyType FROM dual");
                        DbPLSQLBlock("{0} := &AO.PARTY_IDENTITY_SERIES_API.Get_Next_Value( {1} IN )", this.dfsNewIdentity.QualifiedBindName, this.QualifiedVarBindName("sPartyType"));
                        dfsNewIdentity.Text = (((SalString)dfsNewIdentity.Text).ToNumber() - 1).ToString(0);
                    }
                    SalArray<SalString> sItemNames = new SalArray<SalString>();
                    SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
                    sItemNames[0] = "SUPPLIER_ID";
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
				Sal.SetWindowText(i_hWndFrame, Properties.Resources.HEAD_CopySupplier);
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
							if (SaveSupplier()) 
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
					DbPLSQLBlock(cSessionManager.c_hSql, ":hWndForm.dlgCopySupplier.dfsExist :=\r\n" +
						"                                 &AO.Association_Info_API.Association_No_Exist( :hWndForm.dlgCopySupplier.dfsAssocNo, 'SUPPLIER' )");
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
				Sal.SendMsg(dfsIdentity, Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
				dfsIdentity.Text = frmSupplierInfo.FromHandle(i_hWndParent).cmbSupplierId.i_sMyValue;
				using(SignatureHints hints = SignatureHints.NewContext())
				{
                    hints.Add("Supplier_Info_General_API.Get_Name", System.Data.ParameterDirection.Input);
                    DbPLSQLBlock(cSessionManager.c_hSql, ":hWndForm.dlgCopySupplier.dfsName := &AO.Supplier_Info_General_API.Get_Name( :hWndForm.dlgCopySupplier.dfsIdentity )");
				}
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
		private void dlgCopySupplier_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Create:
					this.dlgCopySupplier_OnSAM_Create(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Create event handler.
		/// </summary>
		/// <param name="message"></param>
		private void dlgCopySupplier_OnSAM_Create(object sender, WindowActionsEventArgs e)
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
					using(SignatureHints hints = SignatureHints.NewContext())
					{
                        hints.Add("Supplier_Info_General_API.Get_Name", System.Data.ParameterDirection.Input);
                        this.dfsIdentity.DbPLSQLBlock(cSessionManager.c_hSql, ":hWndForm.dlgCopySupplier.dfsName := SUBSTR(&AO.Supplier_Info_General_API.Get_Name( :hWndForm.dlgCopySupplier.dfsIdentity ),1,100)");
					}
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
