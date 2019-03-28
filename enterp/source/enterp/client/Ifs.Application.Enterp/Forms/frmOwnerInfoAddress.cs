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
// 090902	Hiwilk	Bug 82001, Modified frmOwnerInfoAddress().
// 100611   Samblk  Bug 90626, Added missing Class message
// 111116   Nirplk  SFI-701, Merged bug 99501
// 121012   PRatlk  Bug 105758, Reverted the changes by Bug 82001
// 131127   PRatlk  PBFI-2538, Client Refactoring in ENTERP.
// 140401   Kagalk  PBFI-4142, Merged Bug 113712, Modified to give a warning when deleting the last address type.
#endregion

using System.Collections;
using System.Collections.Generic;
using System.Drawing;
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
	public partial class frmOwnerInfoAddress : cMasterDetailTabFormWindow
	{
		#region Window Variables
		public SalString __sAddrTypes = "";
		public SalString sFullNameTbl = "";
		public SalString sResult = "";
		public SalString lsDisplayLayout = "";
		public SalString lsEditLayout = "";
		public SalString sOldCountry = "";
		public SalString sCountry = "";
		public SalString sCountryCode = "";
		public SalString sStateLov = "";
		public SalString sCountyLov = "";
		public SalString sCityLov = "";
        public SalString sZipLov = "";
		public SalBoolean bPopulate = false;
		public SalString lsAddressLayoutsDbStmt = "";
		public SalString lsLovReferenceDbStmt = "";
        public SalBoolean bIsFromClick = false;
		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		public frmOwnerInfoAddress()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
            this.MinimumSize = new Size(0, 457);
		}
		#endregion
		
		#region System Methods/Properties
		
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public new static frmOwnerInfoAddress FromHandle(SalWindowHandle handle)
		{
			return ((frmOwnerInfoAddress)SalWindow.FromHandle(handle, typeof(frmOwnerInfoAddress)));
		}
		#endregion
		
		#region Methods
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber NewAddressTypes()
		{
			#region Local Variables
			SalNumber nTok = 0;
			SalNumber n = 0;
			SalString sStartDel = "";
			SalString sEndDel = "";
			SalArray<SalString> sTokenArray = new SalArray<SalString>();
			SalString lsStmt = "";
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				lsStmt = "&AO.Address_Type_Code_API.Enumerate_Type( :i_hWndFrame.frmOwnerInfoAddress.__sAddrTypes, 'OWNER' )";
				using(SignatureHints hints = SignatureHints.NewContext())
				{
					hints.Add("Address_Type_Code_API.Enumerate_Type", System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Input);
					DbPLSQLBlock(cSessionManager.c_hSql, lsStmt);
				}
				if (__sAddrTypes != Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					sStartDel = Ifs.Fnd.ApplicationForms.Const.strNULL;
					sEndDel = ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_US).ToCharacter();
					nTok = __sAddrTypes.Tokenize(sStartDel, sEndDel, sTokenArray);
					n = 0;
					while (n < nTok) 
					{
						Sal.SendMsg(tblAddressType, Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
						tblAddressType_colsAddressTypeCode.Text = sTokenArray[n];
						tblAddressType_colsAddressTypeCode.EditDataItemSetEdited();
						if (DefaultExist() == "FALSE") 
						{
							tblAddressType_colDefAddress.Text = "TRUE";
						}
						else
						{
							tblAddressType_colDefAddress.Text = "FALSE";
						}
						tblAddressType_colDefAddress.EditDataItemSetEdited();
						n = n + 1;
					}
				}
				Sal.SetFocus(cmbAddressId);
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalString DefaultExist()
        {
            #region Local Variable
            IDictionary<string, string> namedBindVariables = new Dictionary<string, string>();
            #endregion

            #region Actions
            namedBindVariables.Add("Result", this.QualifiedVarBindName("sResult"));
            namedBindVariables.Add("OwnerId",  tblAddressType_colsOwnerId.QualifiedBindName);
            namedBindVariables.Add("AddressId", tblAddressType_colsAddressId.QualifiedBindName);
            namedBindVariables.Add("AddressTypeCode", tblAddressType_colsAddressTypeCode.QualifiedBindName);

            DbPLSQLBlock(" {Result} := &AO.Owner_Info_Address_Type_API.Default_Exist ( {OwnerId} IN , {AddressId} IN , {AddressTypeCode} IN); ", namedBindVariables);
		    return sResult;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber SetAddressLayouts()
		{
			#region Actions
			using (new SalContext(this))
			{
				if (sOldCountry != sCountry) 
				{
					if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Address_Presentation_API.Get_All_Layouts"))) 
					{
						return false;
					}
					if (!(bPopulate)) 
					{
						// Statement parser was suppressed for this database call during porting
                        using (SignatureHints hints = SignatureHints.NewContext())
                        {
                            hints.Add("ADDRESS_PRESENTATION_API.Get_All_Layouts", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output);
						DbPLSQLBlock(cSessionManager.c_hSql, lsAddressLayoutsDbStmt);
                        }
					}
					amlAddress.AddressItemDisplayLayoutSet(lsDisplayLayout);
					amlAddress.AddressItemEditLayoutSet(lsEditLayout);
				}
				sOldCountry = sCountry;
				dfsCountryCode.Text = sCountryCode;
				return true;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber SetLovReverence()
		{
			#region Actions
			using (new SalContext(this))
			{
				if (Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Enterp_Address_Country_API.Set_Lov_Reverence_All")) 
				{
					if (!(bPopulate)) 
					{
						// Statement parser was suppressed for this database call during porting
                        using (SignatureHints hints = SignatureHints.NewContext())
                        {
                            hints.Add("Enterp_Address_Country_API.Set_Lov_Reverence_All", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.InputOutput, System.Data.ParameterDirection.InputOutput);
						DbPLSQLBlock(cSessionManager.c_hSql, lsLovReferenceDbStmt);
                        }
					}
					dfsState.p_sLovReference = sStateLov;
					dfsCounty.p_sLovReference = sCountyLov;
					dfsCity.p_sLovReference = sCityLov;
                    //dfsZipCode.p_sLovReference = "Zip_Code2(COUNTRY_DB,STATE,COUNTY,CITY)";
                    dfsZipCode.p_sLovReference = sZipLov;
				}
			}

			return 0;
			#endregion
		}
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber SetCountry()
		{
			#region Actions
			using (new SalContext(this))
			{
				sCountry = frmOwnerInfoAddress.FromHandle(i_hWndFrame).cmbCountry.Text;
				if (sCountry == Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					sCountry = frmOwnerInfo.FromHandle(i_hWndParent).cmbCountry.Text;
					frmOwnerInfoAddress.FromHandle(i_hWndFrame).cmbCountry.Text = frmOwnerInfo.FromHandle(i_hWndParent).cmbCountry.Text;
				}
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
				lsAddressLayoutsDbStmt = "&AO.ADDRESS_PRESENTATION_API.Get_All_Layouts(:i_hWndFrame.frmOwnerInfoAddress.sCountry,\r\n" +
				"						:i_hWndFrame.frmOwnerInfoAddress.lsDisplayLayout,\r\n" +
				"						:i_hWndFrame.frmOwnerInfoAddress.lsEditLayout,\r\n" +
				"						:i_hWndFrame.frmOwnerInfoAddress.sCountryCode)";
				lsLovReferenceDbStmt = "&AO.Enterp_Address_Country_API.Set_Lov_Reverence_All(:i_hWndFrame.frmOwnerInfoAddress.sCountryCode,\r\n" +
				"							:i_hWndFrame.frmOwnerInfoAddress.sStateLov,\r\n" +
				"							:i_hWndFrame.frmOwnerInfoAddress.sCountyLov, \r\n" +
                "							:i_hWndFrame.frmOwnerInfoAddress.sCityLov, \r\n" +
				"							:i_hWndFrame.frmOwnerInfoAddress.sZipLov)";
				return ((cMasterDetailTabFormWindow)this).FrameStartupUser();
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber InitValuesForPopulate()
		{
			#region Local Variables
			SalString lsStmt = "";
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
				lsStmt = "DECLARE\r\n" +
				"		country_code_	VARCHAR2(10);\r\n	BEGIN " + Vis.StrSubstitute(lsAddressLayoutsDbStmt, ":i_hWndFrame.frmOwnerInfoAddress.sCountryCode", "country_code_") + ";  " + Vis.StrSubstitute(lsLovReferenceDbStmt, ":i_hWndFrame.frmOwnerInfoAddress.sCountryCode", 
					"country_code_") + "; " + ":i_hWndFrame.frmOwnerInfoAddress.sCountryCode := country_code_;\r\n	END;";
				DbPLSQLBlock(cSessionManager.c_hSql, lsStmt);
			}

			return 0;
			#endregion
		}

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public new SalBoolean DataSourceSaveCheckOk()
        {
            #region Actions
            using (new SalContext(this))
            {
                if (Sal.SendMsg(tblCommMethod, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceIsDirty, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam))
                {
                    if (!(tblCommMethod.CheckDefault()))
                    {
                        return false;
                    }
                }

                if (((bool)Sal.SendMsg(tblAddressType, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceIsDirty, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam)) || (Sal.QueryFieldEdit(dfdValidFrom) || Sal.QueryFieldEdit(dfdValidTo)))
                {
                    if (!(tblAddressType_CheckDefaultAddress()))
                    {
                        return false;
                    }
                }
                return ((cDataSource)this).DataSourceSaveCheckOk();
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
		private void frmOwnerInfoAddress_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew:
					this.frmOwnerInfoAddress_OnPM_DataRecordNew(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate:
					this.frmOwnerInfoAddress_OnPM_DataRecordDuplicate(sender, e);
					break;
				
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove:
					this.frmOwnerInfoAddress_OnPM_DataRecordRemove(sender, e);
					break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordPaste:
                    this.frmOwnerInfoAddress_OnPM_DataRecordPaste(sender, e);
                    break;
				
			}
			#endregion
		}
		
		/// <summary>
		/// PM_DataRecordNew event handler.
		/// </summary>
		/// <param name="message"></param>
		private void frmOwnerInfoAddress_OnPM_DataRecordNew(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Sys.wParam, Sys.lParam)) 
			{
				if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
				{
					Sal.SendMsg(this.cmbCountry, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, ((SalString)frmOwnerInfo.FromHandle(this.i_hWndParent).cmbCountry.Text).ToHandle());
                    sOldCountry = SalString.Null;
					this.SetCountry();
					this.SetAddressLayouts();
					this.NewAddressTypes();
					this.SetLovReverence();
				}
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
		/// PM_DataRecordDuplicate event handler.
		/// </summary>
		/// <param name="message"></param>
		private void frmOwnerInfoAddress_OnPM_DataRecordDuplicate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate, Sys.wParam, Sys.lParam)) 
			{
				if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
				{
					Sal.SendMsg(this.cmbCountry, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, ((SalString)frmOwnerInfo.FromHandle(this.i_hWndParent).cmbCountry.Text).ToHandle());
					this.SetCountry();
					this.SetAddressLayouts();
					this.NewAddressTypes();
				}
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
		/// PM_DataRecordRemove event handler.
		/// </summary>
		/// <param name="message"></param>
		private void frmOwnerInfoAddress_OnPM_DataRecordRemove(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
			{
				if (!(this.tblAddressType_CheckAnyDefaultAddresses("TRUE"))) 
				{
					e.Return = false;
					return;
				}
			}
			e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}

        /// <summary>
        /// PM_DataRecordPaste event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmOwnerInfoAddress_OnPM_DataRecordPaste(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordPaste, Sys.wParam, Sys.lParam))
            {
                if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                {
                    this.SetCountry();
                    this.SetAddressLayouts();
                    this.NewAddressTypes();
                }
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
		private void cmbCountry_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Click:
					this.cmbCountry_OnSAM_Click(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataItemPopulate:
					this.cmbCountry_OnPM_DataItemPopulate(sender, e);
					break;
				
				case Sys.SAM_Validate:
					this.cmbCountry_OnSAM_Validate(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Click event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cmbCountry_OnSAM_Click(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
            if (Sal.SendClassMessage(Sys.SAM_Click, Sys.wParam, Sys.lParam))
            {
			this.SetCountry();
			this.SetAddressLayouts();
            this.bIsFromClick = true;
            }
			#endregion
		}
		
		/// <summary>
		/// PM_DataItemPopulate event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cmbCountry_OnPM_DataItemPopulate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemPopulate, Sys.wParam, Sys.lParam);
			this.bPopulate = true;
			this.SetCountry();
			this.InitValuesForPopulate();
			this.SetAddressLayouts();
			this.SetLovReverence();
			this.bPopulate = false;
			e.Return = true;
			return;
			#endregion
		}
		
		/// <summary>
		/// SAM_Validate event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cmbCountry_OnSAM_Validate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			this.SetLovReverence();
            if (!(bIsFromClick))
            {
                this.SetCountry();
                this.SetAddressLayouts();
            }
            this.bIsFromClick = false;
			e.Return = Sys.VALIDATE_Ok;
			return;
			#endregion
		}
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void tblAddressType_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Sys.SAM_Create:
					this.tblAddressType_OnSAM_Create(sender, e);
					break;
				
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove:
					this.tblAddressType_OnPM_DataRecordRemove(sender, e);
					break;
				
			}
			#endregion
		}
		
		/// <summary>
		/// SAM_Create event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblAddressType_OnSAM_Create(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam);
			this.sFullNameTbl = ":i_hWndFrame." + Ifs.Fnd.ApplicationForms.Int.QualifiedItemNameGet(this.tblAddressType);
			#endregion
		}
		
		/// <summary>
		/// PM_DataRecordRemove event handler.
		/// </summary>
		/// <param name="message"></param>
		private void tblAddressType_OnPM_DataRecordRemove(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
			{
				if (!(this.tblAddressType_CheckAnyDefaultAddresses("FALSE"))) 
				{
					e.Return = false;
					return;
				}
            }
			e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove, Sys.wParam, Sys.lParam);
			return;
			#endregion
		}
		#endregion
		
		#region Late Bind Methods
       
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
		public override SalBoolean vrtFrameStartupUser()
		{
			return this.FrameStartupUser();
		}
		#endregion

        #region ChildTable - tblAddressType

            #region Window Variables
            public SalArray<SalString> tblAddressType_sTempAddressValidation = new SalArray<SalString>();
            public SalArray<SalDateTime> tblAddressType_dTempFromDate = new SalArray<SalDateTime>();
            public SalArray<SalDateTime> tblAddressType_dTempToDate = new SalArray<SalDateTime>();
            public SalArray<SalString> tblAddressType_sAddressId = new SalArray<SalString>();
            public SalArray<SalString> tblAddressType_sAddressTypeCodeArr = new SalArray<SalString>();
            public SalArray<SalString> tblAddressType_sDefAddress = new SalArray<SalString>();
            public SalArray<SalString> tblAddressType_sObjId = new SalArray<SalString>();
            public SalArray<SalString> tblAddressType_sValidFlag = new SalArray<SalString>();
            public SalString tblAddressType_sTempOwnerId = "";
            #endregion

            #region Methods

            /// <summary>
            /// Late bound function in cDataSource
            /// </summary>
            /// <param name="hSql"></param>
            /// <returns></returns>
            public virtual SalBoolean tblAddressType_DataRecordExecuteNew(SalSqlHandle hSql)
            {
                #region Actions
                using (new SalContext(this))
                {
                    tblAddressType_colsAddressId.Text = SalString.FromHandle(this.cmbAddressId.EditDataItemValueGet());
                    tblAddressType_colsAddressId.EditDataItemSetEdited();
                    return ((cTableManager)this.tblAddressType).DataRecordExecuteNew(hSql);
                }
                #endregion
            }
            /// <summary>
            /// </summary>
            /// <returns></returns>
            public virtual SalBoolean tblAddressType_CheckDefaultAddress()
            {
                #region Local Variables
                SalBoolean bTempValue = false;
                SalNumber nCurrentRow = 0;
                SalNumber nTempCount = 0;
                SalArray<SalString> sFlag = new SalArray<SalString>();
                SalArray<SalString> sMsgArr = new SalArray<SalString>();
                SalString sMsgTemp = "";
                SalArray<SalString> sAddressIdMsg = new SalArray<SalString>();
                SalArray<SalString> sAddressTypeCodeMsg = new SalArray<SalString>();
                SalNumber nIndex = 0;
                SalNumber nCount = 0;
                SalString lsStmt = "";
                SalNumber nDefaultUncheckCount = 0;
                SalString tempAddressTypeCode = "";
                SalNumber tempCheckMsgCount = 0;
                SalNumber tempUnCheckMsgCount = 0;
                SalNumber tempMsgCount = 0;
                SalNumber nPrevCurrentRow = 0;
                #endregion

                #region Actions
                using (new SalContext(tblAddressType))
                {
                    nPrevCurrentRow = Sal.TblQueryContext(tblAddressType);
                    nCurrentRow = Sys.TBL_MinRow;
                    bTempValue = true;
                    nTempCount = 0;
                    nIndex = 0;
                    nDefaultUncheckCount = 0;
                    tblAddressType_sTempOwnerId = SalString.Null;
                    sFlag.SetUpperBound(1, -1);
                    tblAddressType_sTempAddressValidation.SetUpperBound(1, -1);
                    tblAddressType_sValidFlag.SetUpperBound(1, -1);
                    tblAddressType_sDefAddress.SetUpperBound(1, -1);
                    tblAddressType_sAddressTypeCodeArr.SetUpperBound(1, -1);
                    tblAddressType_sObjId.SetUpperBound(1, -1);
                    sAddressIdMsg.SetUpperBound(1, -1);
                    sAddressTypeCodeMsg.SetUpperBound(1, -1);
                    tblAddressType_dTempFromDate.SetUpperBound(1, -1);
                    tblAddressType_dTempToDate.SetUpperBound(1, -1);
                    while (true)
                    {
                        if (Sal.TblFindNextRow(tblAddressType, ref nCurrentRow, 0, 0))
                        {
                            Sal.TblSetContext(tblAddressType, nCurrentRow);

                            lsStmt = lsStmt + "&AO.OWNER_INFO_ADDRESS_TYPE_API.Check_Def_Address_Exist (\r\n" +
                                                                                                        ":i_hWndFrame.frmOwnerInfoAddress.tblAddressType_sTempAddressValidation[" + nIndex.ToString(0) + "] OUT,\r\n" +
                                                                                                        ":i_hWndFrame.frmOwnerInfoAddress.tblAddressType_sValidFlag[" + nIndex.ToString(0) + "] OUT ,\r\n" +
                                                                                                        ":i_hWndFrame.frmOwnerInfoAddress.tblAddressType_sTempOwnerId IN ,\r\n" +
                                                                                                        ":i_hWndFrame.frmOwnerInfoAddress.tblAddressType_sDefAddress[" + nIndex.ToString(0) + "] IN,\r\n" +
                                                                                                        ":i_hWndFrame.frmOwnerInfoAddress.tblAddressType_sAddressTypeCodeArr[" + nIndex.ToString(0) + "] IN,\r\n" +
                                                                                                        ":i_hWndFrame.frmOwnerInfoAddress.tblAddressType_sObjId[" + nIndex.ToString(0) + "] IN,\r\n" +
                                                                                                        ":i_hWndFrame.frmOwnerInfoAddress.tblAddressType_dTempFromDate[" + nIndex.ToString(0) + "] IN ,\r\n" +
                                                                                                        ":i_hWndFrame.frmOwnerInfoAddress.tblAddressType_dTempToDate[" + nIndex.ToString(0) + "]  IN );";
                                                                                           
                            tblAddressType_sAddressId[nIndex] = this.tblAddressType_colsAddressId.Text;
                            tblAddressType_sAddressTypeCodeArr[nIndex] = this.tblAddressType_colsAddressTypeCode.Text;
                            tblAddressType_sDefAddress[nIndex] = this.tblAddressType_colDefAddress.Text;
                            tblAddressType_sObjId[nIndex] = this.tblAddressType.__colObjid.Text;
                            tblAddressType_sTempOwnerId = this.tblAddressType_colsOwnerId.Text;
                            if (this.tblAddressType_colDefAddress.Text == "FALSE")
                            {
                                tblAddressType_dTempFromDate[nIndex] = SalDateTime.Null;
                                tblAddressType_dTempToDate[nIndex] = SalDateTime.Null;
                                sFlag[nIndex] = "FALSE";
                            }
                            else
                            {
                                tblAddressType_dTempFromDate[nIndex] = this.dfdValidFrom.DateTime;
                                tblAddressType_dTempToDate[nIndex] = this.dfdValidTo.DateTime;
                                sFlag[nIndex] = "TRUE";
                            }
                            nIndex = nIndex + 1;
                        }
                        else
                        {
                            break;
                        }
                    }
                    Sal.TblSetContext(tblAddressType, nPrevCurrentRow);
                    if (lsStmt != SalString.Null)
                    {
                        // Statement parser was suppressed for this database call during porting
                        if (DbPLSQLBlock(lsStmt))
                        {
                            nCount = 0;
                            tempMsgCount = 0;
                            tempCheckMsgCount = 0;
                            tempUnCheckMsgCount = 0;
                            while (tempMsgCount < nIndex)
                            {
                                if (tblAddressType_sTempAddressValidation[tempMsgCount] == "FALSE")
                                {
                                    tempCheckMsgCount = tempMsgCount;
                                }
                                else if (tblAddressType_sValidFlag[tempMsgCount] == "TRUE" && sFlag[tempMsgCount] == "FALSE")
                                {
                                    tempUnCheckMsgCount = tempMsgCount;
                                }
                                tempMsgCount = tempMsgCount + 1;
                            }
                            while (nCount < nIndex)
                            {
                                if (tblAddressType_sTempAddressValidation[nCount] == "FALSE")
                                {
                                    if (nCount == tempCheckMsgCount)
                                    {
                                        sMsgTemp = sMsgTemp + tblAddressType_sAddressTypeCodeArr[nCount] + " ";
                                    }
                                    else
                                    {
                                        sMsgTemp = sMsgTemp + tblAddressType_sAddressTypeCodeArr[nCount] + "," + " ";
                                    }
                                    bTempValue = true;
                                    nTempCount = nTempCount + 1;
                                }
                                else if (tblAddressType_sValidFlag[nCount] == "TRUE" && sFlag[nCount] == "FALSE")
                                {
                                    if (nCount == tempUnCheckMsgCount)
                                    {
                                        tempAddressTypeCode = tempAddressTypeCode + tblAddressType_sAddressTypeCodeArr[nCount] + " ";
                                    }
                                    else
                                    {
                                        tempAddressTypeCode = tempAddressTypeCode + tblAddressType_sAddressTypeCodeArr[nCount] + "," + " ";
                                    }
                                    nDefaultUncheckCount = nDefaultUncheckCount + 1;
                                }
                                nCount = nCount + 1;
                            }
                        }
                        else
                        {
                            bTempValue = false;
                        }
                    }
                    else
                    {
                        bTempValue = false;
                    }
                    sMsgArr[0] = sMsgTemp;
                    sAddressTypeCodeMsg[0] = tempAddressTypeCode;
                    sAddressTypeCodeMsg[1] = Sal.ListQueryTextX(this.cmbPartyType, 0);
                    sAddressTypeCodeMsg[2] = this.tblAddressType_colsOwnerId.Text;
                    if (nDefaultUncheckCount > 0)
                    {
                        if (Ifs.Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.TEXT_DefautExists, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Question, (Ifs.Fnd.ApplicationForms.Const.QUESTION_YesNo | Sys.MB_DefButton2), sAddressTypeCodeMsg) ==
                        Sys.IDNO)
                        {
                            return false;
                        }
                    }
                    if (nTempCount > 0 && bTempValue)
                    {
                        if (Ifs.Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.TEXT_DefAddressExt, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Question, (Ifs.Fnd.ApplicationForms.Const.QUESTION_YesNo | Sys.MB_DefButton2), sMsgArr) ==
                        Sys.IDYES)
                        {
                            bTempValue = tblAddressType_RemoveDefaultAddress();
                        }
                        else
                        {
                            bTempValue = false;
                        }
                    }
                    frmOwnerInfo.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).bAddressType = true;
                    return bTempValue;
                }
                #endregion
            }

            /// <summary>
            /// </summary>
            /// <param name="sMethodFlag"></param>
            /// <returns></returns>
            public virtual SalBoolean tblAddressType_CheckAnyDefaultAddresses(SalString sMethodFlag)
            {
                #region Local Variables
                SalBoolean bTempValue = false;
                SalNumber nCurrentRow = 0;
                SalNumber nTempCount = 0;
                SalArray<SalString> sMsgArr = new SalArray<SalString>();
                SalString sMsgTemp = "";
                SalArray<SalString> sAddressTypeCodeMsg = new SalArray<SalString>();
                SalNumber nIndex = 0;
                SalNumber nCount = 0;
                SalString lsStmt = "";
                SalNumber nRowCondition = 0;
                SalNumber tempUnCheckMsgCount = 0;
                SalNumber tempMsgCount = 0;
                SalNumber nPrevCurrentRow = 0;
                #endregion

                #region Actions
                using (new SalContext(tblAddressType))
                {
                    nPrevCurrentRow = Sal.TblQueryContext(tblAddressType);
                    nCurrentRow = Sys.TBL_MinRow;
                    bTempValue = true;
                    nTempCount = 0;
                    nIndex = 0;
                    tblAddressType_sTempOwnerId = SalString.Null;
                    tblAddressType_sTempAddressValidation.SetUpperBound(1, -1);
                    tblAddressType_sDefAddress.SetUpperBound(1, -1);
                    tblAddressType_sAddressTypeCodeArr.SetUpperBound(1, -1);
                    tblAddressType_sObjId.SetUpperBound(1, -1);
                    sAddressTypeCodeMsg.SetUpperBound(1, -1);
                    tblAddressType_dTempFromDate.SetUpperBound(1, -1);
                    tblAddressType_dTempToDate.SetUpperBound(1, -1);
                    sMsgArr.SetUpperBound(1, -1);
                    tblAddressType_dTempFromDate[0] = SalDateTime.Null;
                    tblAddressType_dTempToDate[0] = SalDateTime.Null;
                    if (sMethodFlag == "FALSE")
                    {
                        nRowCondition = Sys.ROW_Selected;
                    }
                    else
                    {
                        nRowCondition = 0;
                    }
                    while (true)
                    {
                        if (Sal.TblFindNextRow(tblAddressType, ref nCurrentRow, nRowCondition, 0))
                        {
                            Sal.TblSetContext(this, nCurrentRow);
                            if (this.tblAddressType_colDefAddress.Text == "TRUE")
                            {
                                lsStmt = lsStmt + "&AO.OWNER_INFO_ADDRESS_TYPE_API.Check_Def_Address_Exist (\r\n" +
                                                                                                                ":i_hWndFrame.frmOwnerInfoAddress.tblAddressType_sTempAddressValidation[" + nIndex.ToString(0) + "] OUT,\r\n" +
                                                                                                                ":i_hWndFrame.frmOwnerInfoAddress.tblAddressType_sValidFlag[" + nIndex.ToString(0) + "] OUT ,\r\n" +
                                                                                                                ":i_hWndFrame.frmOwnerInfoAddress.tblAddressType_sTempOwnerId IN ,\r\n" +
                                                                                                                ":i_hWndFrame.frmOwnerInfoAddress.tblAddressType_sDefAddress[" + nIndex.ToString(0) + "] IN ,\r\n" +
                                                                                                                ":i_hWndFrame.frmOwnerInfoAddress.tblAddressType_sAddressTypeCodeArr[" + nIndex.ToString(0) + "] IN ,\r\n" +
                                                                                                                ":i_hWndFrame.frmOwnerInfoAddress.tblAddressType_sObjId[" + nIndex.ToString(0) + "] IN ,\r\n" +
                                                                                                                ":i_hWndFrame.frmOwnerInfoAddress.tblAddressType_dTempFromDate[" + ((SalNumber)0).ToString(0) + "] IN,\r\n" +
                                                                                                                ":i_hWndFrame.frmOwnerInfoAddress.tblAddressType_dTempToDate[" + ((SalNumber)0).ToString(0) + "]  IN );";
                                tblAddressType_sAddressId[nIndex] = this.tblAddressType_colsAddressId.Text;
                                tblAddressType_sAddressTypeCodeArr[nIndex] = this.tblAddressType_colsAddressTypeCode.Text;
                                tblAddressType_sDefAddress[nIndex] = this.tblAddressType_colDefAddress.Text;
                                tblAddressType_sObjId[nIndex] = this.tblAddressType.__colObjid.Text;
                                tblAddressType_sTempOwnerId = this.tblAddressType_colsOwnerId.Text;
                            }
                            nIndex = nIndex + 1;
                        }
                        else
                        {
                            break;
                        }
                    }
                    Sal.TblSetContext(this, nPrevCurrentRow);
                    if (lsStmt != SalString.Null)
                    {
                        // Statement parser was suppressed for this database call during porting
                        if (DbPLSQLBlock(cSessionManager.c_hSql, " BEGIN " + lsStmt + " END; "))
                        {
                            nCount = 0;
                            tempUnCheckMsgCount = 0;
                            tempMsgCount = 0;
                            while (tempMsgCount < nIndex)
                            {
                                if (tblAddressType_sTempAddressValidation[tempMsgCount] == "TRUE")
                                {
                                    tempUnCheckMsgCount = tempMsgCount;
                                }
                                tempMsgCount = tempMsgCount + 1;
                            }
                            while (nCount < nIndex)
                            {
                                if (tblAddressType_sTempAddressValidation[nCount] == "TRUE")
                                {
                                    if (nCount == tempUnCheckMsgCount)
                                    {
                                        sMsgTemp = sMsgTemp + tblAddressType_sAddressTypeCodeArr[nCount] + " ";
                                    }
                                    else
                                    {
                                        sMsgTemp = sMsgTemp + tblAddressType_sAddressTypeCodeArr[nCount] + "," + " ";
                                    }
                                    bTempValue = true;
                                    nTempCount = nTempCount + 1;
                                }
                                nCount = nCount + 1;
                            }
                        }
                        else
                        {
                            bTempValue = false;
                        }
                    }
                    else
                    {
                        bTempValue = false;
                    }
                    sMsgArr[0] = sMsgTemp;
                    sAddressTypeCodeMsg[0] = sMsgTemp;
                    sAddressTypeCodeMsg[1] = Sal.ListQueryTextX(this.cmbPartyType, 0);
                    sAddressTypeCodeMsg[2] = this.tblAddressType_colsOwnerId.Text;
                    if (nTempCount > 0 && bTempValue)
                    {
                        if (Ifs.Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.TEXT_DefautExists, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Question, (Ifs.Fnd.ApplicationForms.Const.QUESTION_YesNo | Sys.MB_DefButton2), sAddressTypeCodeMsg) ==
                        Sys.IDNO)
                        {
                            return false;
                        }
                    }
                    return true;
                }
                #endregion
            }

            public virtual SalBoolean tblAddressType_CheckLastAddressType()
            {
                #region Local Variables
                SalNumber nCountRows = 0;
                SalArray<SalString> sMessage = new SalArray<SalString>();
                #endregion

                #region Actions
                using (new SalContext(this))
                {
                    nCountRows = Sal.TblAnyRows(this.tblAddressType, 0, Sys.ROW_MarkDeleted);
                    if (nCountRows == 0)
                    {
                        sMessage[0] = this.tblAddressType_colsAddressId.Text;
                        sMessage[1] = Sal.ListQueryTextX(this.cmbPartyType, 0).ToLower();
                        sMessage[2] = this.tblAddressType_colsOwnerId.Text;
                        if (Ifs.Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.TEXT_LastAddressType, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Question, (Ifs.Fnd.ApplicationForms.Const.QUESTION_YesNo | Sys.MB_DefButton2), sMessage) == Sys.IDNO)
                        {
                            return false;
                        }
                    }
                    return true;
                }
                #endregion
            }

            // Configure default address
            /// <summary>
            /// </summary>
            /// <returns></returns>
            public virtual SalBoolean tblAddressType_RemoveDefaultAddress()
            {
                #region Local Variables
                SalNumber nCurrentRowRemove = 0;
                SalBoolean bTempResult = false;
                SalNumber nIndex = 0;
                SalNumber nCount = 0;
                SalString lsStmt = "";
                #endregion

                #region Actions
                using (new SalContext(tblAddressType))
                {
                    nIndex = 0;
                    tblAddressType_sTempOwnerId = SalString.Null;
                    nCount = tblAddressType_sTempAddressValidation.GetUpperBound(1);
                    lsStmt = SalString.Null;
                    while (nIndex <= nCount)
                    {
                        if (tblAddressType_sTempAddressValidation[nIndex] == "FALSE")
                        {
                            lsStmt = lsStmt + "&AO.OWNER_INFO_ADDRESS_TYPE_API.Check_Def_Addr_Temp (:i_hWndFrame.frmOwnerInfoAddress.tblAddressType_sTempOwnerId IN ,\r\n" +
                            "                                                                       :i_hWndFrame.frmOwnerInfoAddress.tblAddressType_sAddressTypeCodeArr[" + nIndex.ToString(0) + "] IN ,\r\n" +
                            "                                                                       :i_hWndFrame.frmOwnerInfoAddress.tblAddressType_sDefAddress[" + nIndex.ToString(0) + "] IN ,\r\n" +
                            "                                                                       :i_hWndFrame.frmOwnerInfoAddress.tblAddressType_sObjId[" + nIndex.ToString(0) + "] IN ,\r\n" +
                            "                                                                       :i_hWndFrame.frmOwnerInfoAddress.tblAddressType_dTempFromDate[" + nIndex.ToString(0) + "] IN ,\r\n" +
                            "                                                                       :i_hWndFrame.frmOwnerInfoAddress.tblAddressType_dTempToDate[" + nIndex.ToString(0) + "] IN ); ";
                            tblAddressType_dTempFromDate[nIndex] = this.dfdValidFrom.DateTime;
                            tblAddressType_dTempToDate[nIndex] = this.dfdValidTo.DateTime;
                            tblAddressType_sTempOwnerId = this.tblAddressType_colsOwnerId.Text;
                        }
                        nIndex = nIndex + 1;
                    }
                    if (lsStmt != SalString.Null)
                    {
                        // Statement parser was suppressed for this database call during porting
                        if (DbPLSQLBlock(cSessionManager.c_hSql, " BEGIN " + lsStmt + " END; "))
                        {
                            bTempResult = true;
                        }
                        else
                        {
                            bTempResult = false;
                        }
                    }
                    return bTempResult;
                }
                #endregion
            }
            /// <summary>
            /// </summary>
            /// <param name="sWindowName"></param>
            /// <returns></returns>
            public virtual SalNumber tblAddressType_DataSourcePrepareKeyTransfer(SalString sWindowName)
            {
                #region Local Variables
                SalArray<SalString> sItemNames = new SalArray<SalString>();
                SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
                #endregion

                #region Actions
                using (new SalContext(tblAddressType))
                {
                    if (sWindowName == Pal.GetActiveInstanceName("frmHistoryLog"))
                    {
                        sItemNames[0] = "ADDRESS_ID";
                        hWndItems[0] = tblAddressType_colsAddressId;
                        sItemNames[1] = "ADDRESS_TYPE_CODE";
                        hWndItems[1] = tblAddressType_colsAddressTypeCodeDb;
                        sItemNames[2] = "OWNER_ID";
                        hWndItems[2] = tblAddressType_colsOwnerId;
                    }
                    else
                    {
                        return ((cDataSource)this.tblAddressType).DataSourcePrepareKeyTransfer(sWindowName);
                    }
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("OwnerInfoAddressType", Sys.hWndForm, sItemNames, hWndItems);
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.TypeSet("CREATE_WINDOW");
                }

                return 0;
                #endregion
            }

            /// <summary>
            /// </summary>
            /// <returns></returns>
            public virtual SalBoolean tblAddressType_ValidateAddressType()
            {
                #region Local Variables
                IDictionary<string, string> namedBindVariables = new Dictionary<string, string>();
                #endregion

                #region Actions
                namedBindVariables.Add("AddressTypeCodeDb", tblAddressType_colsAddressTypeCodeDb.QualifiedBindName);
                namedBindVariables.Add("AddressTypeCode", tblAddressType_colsAddressTypeCode.QualifiedBindName);

                DbPLSQLBlock("{AddressTypeCodeDb}:= &AO.ADDRESS_TYPE_CODE_API.Encode( {AddressTypeCode} IN );", namedBindVariables);
                return true;
                #endregion
            }
            #endregion

            #region Window Actions

            /// <summary>
            /// Window Actions
            /// </summary>
            /// <param name="sender">The source of the event.</param>
            /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
            private void colsAddressTypeCode_WindowActions(object sender, WindowActionsEventArgs e)
            {
                #region Actions
                switch (e.ActionType)
                {
                    case Ifs.Fnd.ApplicationForms.Const.PM_LookupInit:
                        e.Handled = true;
                        this.tblAddressType_colsAddressTypeCode.TypeCodeLookupInit("OWNER");
                        break;


                    case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                        this.colsAddressTypeCode_OnPM_DataItemValidate(sender, e);
                        break;

                }
                #endregion
            }

            /// <summary>
            /// PM_DataItemValidate event handler.
            /// </summary>
            /// <param name="message"></param>
            private void colsAddressTypeCode_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
            {
                #region Actions
                e.Handled = true;
                if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam))
                {
                    if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                    {
                        e.Return = this.tblAddressType_ValidateAddressType();
                        return;
                    }
                }
                e.Return = true;
                return;
                #endregion
            }
            #endregion

            #region Late Bind Methods

            private void tblAddressType_DataRecordExecuteNewEvent(object sender, cDataSource.DataRecordExecuteNewEventArgs e)
            {
                e.Handled = true;
                e.ReturnValue = tblAddressType_DataRecordExecuteNew(e.hSql);
            }

            private void tblAddressType_DataSourcePrepareKeyTransferEvent(object sender, cDataSource.DataSourcePrepareKeyTransferEventArgs e)
            {
                e.Handled = true;
                e.ReturnValue = tblAddressType_DataSourcePrepareKeyTransfer(e.sWindowName);
            }

            #endregion

        #endregion

        #region ChildTable - tblCommMethod

            #region Methods

            /// <summary>
            /// Late bound function in cDataSource
            /// </summary>
            /// <param name="hSql"></param>
            /// <returns></returns>
            public virtual SalBoolean tblCommMethod_DataRecordExecuteNew(SalSqlHandle hSql)
            {
                #region Actions
                tblCommMethod.colsPartyTypeDb.Text = "OWNER";
                tblCommMethod.colsIdentity.Text = SalString.FromHandle(this.dfsOwnerId.EditDataItemValueGet());
                tblCommMethod.colsAddressId.Text = SalString.FromHandle(this.cmbAddressId.EditDataItemValueGet());
                tblCommMethod.colsPartyTypeDb.EditDataItemSetEdited();
                tblCommMethod.colsIdentity.EditDataItemSetEdited();
                tblCommMethod.colsAddressId.EditDataItemSetEdited();
                return ((cTableManager)this.tblCommMethod).DataRecordExecuteNew(hSql);
                #endregion
            }

            /// <summary>
            /// Late bound function in cDataSource
            /// </summary>
            /// <param name="hSql"></param>
            /// <returns></returns>
            public virtual SalBoolean tblCommMethod_DataRecordExecuteModify(SalSqlHandle hSql)
            {
                #region Actions
                tblCommMethod.colsPartyTypeDb.Text = "OWNER";
                tblCommMethod.colsIdentity.Text = SalString.FromHandle(this.dfsOwnerId.EditDataItemValueGet());
                tblCommMethod.colsAddressId.Text = SalString.FromHandle(this.cmbAddressId.EditDataItemValueGet());
                tblCommMethod.colsPartyTypeDb.EditDataItemSetEdited();
                tblCommMethod.colsIdentity.EditDataItemSetEdited();
                tblCommMethod.colsAddressId.EditDataItemSetEdited();
                return ((cTableManager)this.tblCommMethod).DataRecordExecuteModify(hSql);
                #endregion
            }
            /// <summary>
            /// </summary>
            /// <param name="sWindowName">
            /// Window name
            /// Intendend receiver window of the data transfer. When overriding DataSourcePrepareKeyTransfer,
            /// applications can use this parameter to initialize data transfer in different ways for
            /// different receiver windows.
            /// </param>
            /// <returns></returns>
            public virtual SalNumber tblCommMethod_DataSourcePrepareKeyTransfer(SalString sWindowName)
            {
                #region Local Variables
                SalString sSourceName = "";
                SalWindowHandle hWndSource = SalWindowHandle.Null;
                SalArray<SalString> sItemNames = new SalArray<SalString>();
                SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
                #endregion

                #region Actions
                using (new SalContext(this))
                {
                    if (sWindowName == Pal.GetActiveInstanceName("frmHistoryLog"))
                    {
                        sSourceName = p_sLogicalUnit;
                        hWndSource = i_hWndSelf;
                        sItemNames[0] = "COMM_ID";
                        sItemNames[1] = "IDENTITY";
                        sItemNames[2] = "PARTY_TYPE";
                        hWndItems[0] = tblCommMethod.colnCommId;
                        hWndItems[1] = tblCommMethod.colsIdentity;
                        hWndItems[2] = tblCommMethod.colsPartyTypeDb;
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init(sSourceName, hWndSource, sItemNames, hWndItems);
                        return Ifs.Fnd.ApplicationForms.Var.DataTransfer.TypeSet("CREATE_WINDOW");
                    }
                    return ((cChildTableCommMethod)this.tblCommMethod).DataSourcePrepareKeyTransfer(sWindowName);
                }
                #endregion
            }
            #endregion

            #region Event Handlers

            private void tblCommMethod_DataRecordExecuteNewEvent(object sender, cDataSource.DataRecordExecuteNewEventArgs e)
            {
                e.Handled = true;
                e.ReturnValue = tblCommMethod_DataRecordExecuteNew(e.hSql);
            }

            private void tblCommMethod_DataRecordExecuteModifyEvent(object sender, cDataSource.DataRecordExecuteModifyEventArgs e)
            {
                e.Handled = true;
                e.ReturnValue = tblCommMethod_DataRecordExecuteModify(e.hSql);
            }

            private void tblCommMethod_DataSourcePrepareKeyTransferEvent(object sender, cDataSource.DataSourcePrepareKeyTransferEventArgs e)
            {
                e.Handled = true;
                e.ReturnValue = tblCommMethod_DataSourcePrepareKeyTransfer(e.sWindowName);
            }

            #endregion

        #endregion

	}
}
