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
// 090902	Hiwilk	Bug 82001, Modified frmForwarderInfoAddress().
// 100611   Samblk  Bug 90626, Added missing Class message
// 111116   Nirplk  SFI-701, Merged bug 99501
// 121012   PRatlk  Bug 105758, Reverted the changes by Bug 82001
// 121213   PRatlk  PBFI-2530, Client Refactor in INVOIC.
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
	public partial class frmForwarderInfoAddress : cMasterDetailTabFormWindow
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
		public frmForwarderInfoAddress()
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
		public new static frmForwarderInfoAddress FromHandle(SalWindowHandle handle)
		{
			return ((frmForwarderInfoAddress)SalWindow.FromHandle(handle, typeof(frmForwarderInfoAddress)));
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
				lsStmt = "&AO.Address_Type_Code_API.Enumerate_Type( :i_hWndFrame.frmForwarderInfoAddress.__sAddrTypes, 'FORWARDER' )";
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
			#region Actions
			using (new SalContext(this))
			{
				using(SignatureHints hints = SignatureHints.NewContext())
				{
					hints.Add("Forw_Info_Addr_Type_API.Default_Exist", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                    DbPLSQLBlock(cSessionManager.c_hSql, ":i_hWndFrame.frmForwarderInfoAddress.sResult := &AO.Forw_Info_Addr_Type_API.Default_Exist (:i_hWndFrame.frmForwarderInfoAddress.tblAddressType_colsForwarderId ,:i_hWndFrame.frmForwarderInfoAddress.tblAddressType_colsAddressId ,:i_hWndFrame.frmForwarderInfoAddress.tblAddressType_colsAddressTypeCode ); ");
				}
				return sResult;
			}
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
                   // dfsZipCode.p_sLovReference = "Zip_Code2(COUNTRY_DB,STATE,COUNTY,CITY)";
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
				sCountry = frmForwarderInfoAddress.FromHandle(i_hWndFrame).cmbCountry.Text;
				if (sCountry == Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					sCountry = frmForwarderInfo.FromHandle(i_hWndParent).cmbCountry.Text;
					frmForwarderInfoAddress.FromHandle(i_hWndFrame).cmbCountry.Text = frmForwarderInfo.FromHandle(i_hWndParent).cmbCountry.Text;
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
				lsAddressLayoutsDbStmt = "&AO.ADDRESS_PRESENTATION_API.Get_All_Layouts(:i_hWndFrame.frmForwarderInfoAddress.sCountry,\r\n" +
				"						:i_hWndFrame.frmForwarderInfoAddress.lsDisplayLayout,\r\n" +
				"						:i_hWndFrame.frmForwarderInfoAddress.lsEditLayout,\r\n" +
				"						:i_hWndFrame.frmForwarderInfoAddress.sCountryCode )";
				lsLovReferenceDbStmt = "&AO.Enterp_Address_Country_API.Set_Lov_Reverence_All(:i_hWndFrame.frmForwarderInfoAddress.sCountryCode,\r\n" +
				"							:i_hWndFrame.frmForwarderInfoAddress.sStateLov,\r\n" +
				"							:i_hWndFrame.frmForwarderInfoAddress.sCountyLov, \r\n" +
                "							:i_hWndFrame.frmForwarderInfoAddress.sCityLov, \r\n" +
				"							:i_hWndFrame.frmForwarderInfoAddress.sZipLov )";
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
				"		country_code_	VARCHAR2(10);\r\n	BEGIN " + Vis.StrSubstitute(lsAddressLayoutsDbStmt, ":i_hWndFrame.frmForwarderInfoAddress.sCountryCode", "country_code_") + ";  " + Vis.StrSubstitute(lsLovReferenceDbStmt, ":i_hWndFrame.frmForwarderInfoAddress.sCountryCode", 
					"country_code_") + "; " + ":i_hWndFrame.frmForwarderInfoAddress.sCountryCode := country_code_;\r\n	END;";
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
                    if (!(CheckDefaultAddress()))
                    {
                        return false;
                    }
                }
                return ((cDataSource)this).DataSourceSaveCheckOk();
            }
            #endregion
        }
        
		#endregion

        #region ChildTable - tblAddressType

            #region Window Variables
            public SalArray<SalString> sTempAddressValidation = new SalArray<SalString>();
            public SalArray<SalDateTime> dTempFromDate = new SalArray<SalDateTime>();
            public SalArray<SalDateTime> dTempToDate = new SalArray<SalDateTime>();
            public SalArray<SalString> sAddressId = new SalArray<SalString>();
            public SalArray<SalString> sAddressTypeCodeArr = new SalArray<SalString>();
            public SalArray<SalString> sDefAddress = new SalArray<SalString>();
            public SalArray<SalString> sObjId = new SalArray<SalString>();
            public SalArray<SalString> sValidFlag = new SalArray<SalString>();
            public SalString sTempForwarderId = "";
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
                using (new SalContext(tblAddressType))
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
            public virtual SalBoolean CheckDefaultAddress()
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
                    sTempForwarderId = SalString.Null;
                    sFlag.SetUpperBound(1, -1);
                    sTempAddressValidation.SetUpperBound(1, -1);
                    sValidFlag.SetUpperBound(1, -1);
                    sDefAddress.SetUpperBound(1, -1);
                    sAddressTypeCodeArr.SetUpperBound(1, -1);
                    sObjId.SetUpperBound(1, -1);
                    sAddressIdMsg.SetUpperBound(1, -1);
                    sAddressTypeCodeMsg.SetUpperBound(1, -1);
                    dTempFromDate.SetUpperBound(1, -1);
                    dTempToDate.SetUpperBound(1, -1);
                    while (true)
                    {
                        if (Sal.TblFindNextRow(tblAddressType, ref nCurrentRow, 0, 0))
                        {
                            Sal.TblSetContext(tblAddressType, nCurrentRow);
                            lsStmt = lsStmt + "&AO.FORW_INFO_ADDR_TYPE_API.Check_Def_Address_Exist (\r\n" +
                            "                                                                       :i_hWndFrame.frmForwarderInfoAddress.sTempAddressValidation[" + nIndex.ToString(0) + "] OUT ,\r\n" +
                            "                                                                       :i_hWndFrame.frmForwarderInfoAddress.sValidFlag[" + nIndex.ToString(0) + "] OUT ,\r\n" +
                            "                                                                       :i_hWndFrame.frmForwarderInfoAddress.sTempForwarderId IN ,\r\n" +
                            "                                                                       :i_hWndFrame.frmForwarderInfoAddress.sDefAddress[" + nIndex.ToString(0) + "] IN ,\r\n" +
                            "                                                                       :i_hWndFrame.frmForwarderInfoAddress.sAddressTypeCodeArr[" + nIndex.ToString(0) + "] IN ,\r\n" +
                            "                                                                       :i_hWndFrame.frmForwarderInfoAddress.sObjId[" + nIndex.ToString(0) + "] IN ,\r\n" +
                            "                                                                       :i_hWndFrame.frmForwarderInfoAddress.dTempFromDate[" + nIndex.ToString(0) + "] IN ,\r\n" +
                            "                                                                       :i_hWndFrame.frmForwarderInfoAddress.dTempToDate[" + nIndex.ToString(0) + "]  IN );";
                            sAddressId[nIndex] = this.tblAddressType_colsAddressId.Text;
                            sAddressTypeCodeArr[nIndex] = this.tblAddressType_colsAddressTypeCode.Text;
                            sDefAddress[nIndex] = this.tblAddressType_colDefAddress.Text;
                            sObjId[nIndex] = this.tblAddressType.__colObjid.Text;
                            sTempForwarderId = this.tblAddressType_colsForwarderId.Text;
                            if (this.tblAddressType_colDefAddress.Text == "FALSE")
                            {
                                dTempFromDate[nIndex] = SalDateTime.Null;
                                dTempToDate[nIndex] = SalDateTime.Null;
                                sFlag[nIndex] = "FALSE";
                            }
                            else
                            {
                                dTempFromDate[nIndex] = this.dfdValidFrom.DateTime;
                                dTempToDate[nIndex] = this.dfdValidTo.DateTime;
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
                            if (DbPLSQLBlock(cSessionManager.c_hSql, lsStmt ))
                            {
                                nCount = 0;
                                tempMsgCount = 0;
                                tempCheckMsgCount = 0;
                                tempUnCheckMsgCount = 0;
                                while (tempMsgCount < nIndex)
                                {
                                    if (sTempAddressValidation[tempMsgCount] == "FALSE")
                                    {
                                        tempCheckMsgCount = tempMsgCount;
                                    }
                                    else if (sValidFlag[tempMsgCount] == "TRUE" && sFlag[tempMsgCount] == "FALSE")
                                    {
                                        tempUnCheckMsgCount = tempMsgCount;
                                    }
                                    tempMsgCount = tempMsgCount + 1;
                                }
                                while (nCount < nIndex)
                                {
                                    if (sTempAddressValidation[nCount] == "FALSE")
                                    {
                                        if (nCount == tempCheckMsgCount)
                                        {
                                            sMsgTemp = sMsgTemp + sAddressTypeCodeArr[nCount] + " ";
                                        }
                                        else
                                        {
                                            sMsgTemp = sMsgTemp + sAddressTypeCodeArr[nCount] + "," + " ";
                                        }
                                        bTempValue = true;
                                        nTempCount = nTempCount + 1;
                                    }
                                    else if (sValidFlag[nCount] == "TRUE" && sFlag[nCount] == "FALSE")
                                    {
                                        if (nCount == tempUnCheckMsgCount)
                                        {
                                            tempAddressTypeCode = tempAddressTypeCode + sAddressTypeCodeArr[nCount] + " ";
                                        }
                                        else
                                        {
                                            tempAddressTypeCode = tempAddressTypeCode + sAddressTypeCodeArr[nCount] + "," + " ";
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
                    sAddressTypeCodeMsg[2] = this.tblAddressType_colsForwarderId.Text;
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
                            bTempValue = RemoveDefaultAddress();
                        }
                        else
                        {
                            bTempValue = false;
                        }
                    }
                    frmForwarderInfo.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).bAddressType = true;
                    return bTempValue;
                }
                #endregion
            }

            /// <summary>
            /// </summary>
            /// <param name="sMethodFlag"></param>
            /// <returns></returns>
            public virtual SalBoolean CheckAnyDefaultAddresses(SalString sMethodFlag)
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
                    sTempForwarderId = SalString.Null;
                    sTempAddressValidation.SetUpperBound(1, -1);
                    sDefAddress.SetUpperBound(1, -1);
                    sAddressTypeCodeArr.SetUpperBound(1, -1);
                    sObjId.SetUpperBound(1, -1);
                    sAddressTypeCodeMsg.SetUpperBound(1, -1);
                    dTempFromDate.SetUpperBound(1, -1);
                    dTempToDate.SetUpperBound(1, -1);
                    sMsgArr.SetUpperBound(1, -1);
                    dTempFromDate[0] = SalDateTime.Null;
                    dTempToDate[0] = SalDateTime.Null;
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
                            Sal.TblSetContext(tblAddressType, nCurrentRow);
                            if (this.tblAddressType_colDefAddress.Text == "TRUE")
                            {
                                lsStmt = lsStmt + "&AO.FORW_INFO_ADDR_TYPE_API.Check_Def_Address_Exist (\r\n" +
                                "                                                                       :i_hWndFrame.frmForwarderInfoAddress.sTempAddressValidation[" + nIndex.ToString(0) + "] OUT ,\r\n" +
                                "                                                                       :i_hWndFrame.frmForwarderInfoAddress.sValidFlag[" + nIndex.ToString(0) + "] OUT ,\r\n" +
                                "                                                                       :i_hWndFrame.frmForwarderInfoAddress.sTempForwarderId IN ,\r\n" +
                                "                                                                       :i_hWndFrame.frmForwarderInfoAddress.sDefAddress[" + nIndex.ToString(0) + "] IN ,\r\n" +
                                "                                                                       :i_hWndFrame.frmForwarderInfoAddress.sAddressTypeCodeArr[" + nIndex.ToString(0) + "] IN ,\r\n" +
                                "                                                                       :i_hWndFrame.frmForwarderInfoAddress.sObjId[" + nIndex.ToString(0) + "] IN ,\r\n" +
                                "                                                                       :i_hWndFrame.frmForwarderInfoAddress.dTempFromDate[" + ((SalNumber)0).ToString(0) + "] IN ,\r\n" +
                                "                                                                       :i_hWndFrame.frmForwarderInfoAddress.dTempToDate[" + ((SalNumber)0).ToString(0) + "] IN );";
                                sAddressId[nIndex] = this.tblAddressType_colsAddressId.Text;
                                sAddressTypeCodeArr[nIndex] = this.tblAddressType_colsAddressTypeCode.Text;
                                sDefAddress[nIndex] = this.tblAddressType_colDefAddress.Text;
                                sObjId[nIndex] = this.tblAddressType.__colObjid.Text;
                                sTempForwarderId = this.tblAddressType_colsForwarderId.Text;
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
                            if (DbPLSQLBlock(cSessionManager.c_hSql, lsStmt ))
                            {
                                nCount = 0;
                                tempUnCheckMsgCount = 0;
                                tempMsgCount = 0;
                                while (tempMsgCount < nIndex)
                                {
                                    if (sTempAddressValidation[tempMsgCount] == "TRUE")
                                    {
                                        tempUnCheckMsgCount = tempMsgCount;
                                    }
                                    tempMsgCount = tempMsgCount + 1;
                                }
                                while (nCount < nIndex)
                                {
                                    if (sTempAddressValidation[nCount] == "TRUE")
                                    {
                                        if (nCount == tempUnCheckMsgCount)
                                        {
                                            sMsgTemp = sMsgTemp + sAddressTypeCodeArr[nCount] + " ";
                                        }
                                        else
                                        {
                                            sMsgTemp = sMsgTemp + sAddressTypeCodeArr[nCount] + "," + " ";
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
                    sAddressTypeCodeMsg[2] = this.tblAddressType_colsForwarderId.Text;
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

            public virtual SalBoolean CheckLastAddressType()
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
                        sMessage[2] = this.tblAddressType_colsForwarderId.Text;
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
            public virtual SalBoolean RemoveDefaultAddress()
            {
                #region Local Variables
                SalNumber nCurrentRowRemove = 0;
                SalBoolean bTempResult = false;
                SalNumber nIndex = 0;
                SalNumber nCount = 0;
                SalString lsStmt = "";
                #endregion

                #region Actions
                using (new SalContext(this))
                {
                    nIndex = 0;
                    sTempForwarderId = SalString.Null;
                    nCount = sTempAddressValidation.GetUpperBound(1);
                    lsStmt = SalString.Null;
                    while (nIndex <= nCount)
                    {
                        if (sTempAddressValidation[nIndex] == "FALSE")
                        {
                            lsStmt = lsStmt + "&AO.FORW_INFO_ADDR_TYPE_API.Check_Def_Addr_Temp (:i_hWndFrame.frmForwarderInfoAddress.sTempForwarderId IN ,\r\n" +
                            "                                                                   :i_hWndFrame.frmForwarderInfoAddress.sAddressTypeCodeArr[" + nIndex.ToString(0) + "] IN ,\r\n" +
                            "                                                                   :i_hWndFrame.frmForwarderInfoAddress.sDefAddress[" + nIndex.ToString(0) + "] IN ,\r\n" +
                            "                                                                   :i_hWndFrame.frmForwarderInfoAddress.sObjId[" + nIndex.ToString(0) + "] IN ,\r\n" +
                            "                                                                   :i_hWndFrame.frmForwarderInfoAddress.dTempFromDate[" + nIndex.ToString(0) + "] IN ,\r\n" +
                            "                                                                   :i_hWndFrame.frmForwarderInfoAddress.dTempToDate[" + nIndex.ToString(0) + "] IN ); ";
                            dTempFromDate[nIndex] = this.dfdValidFrom.DateTime;
                            dTempToDate[nIndex] = this.dfdValidTo.DateTime;
                            sTempForwarderId = this.tblAddressType_colsForwarderId.Text;
                        }
                        nIndex = nIndex + 1;
                    }
                    if (lsStmt != SalString.Null)
                    {
                        // Statement parser was suppressed for this database call during porting
                        if (DbPLSQLBlock(cSessionManager.c_hSql, lsStmt ))
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
                        sItemNames[2] = "FORWARDER_ID";
                        hWndItems[2] = tblAddressType_colsForwarderId;
                    }
                    else
                    {
                        return ((cDataSource)this.tblAddressType).DataSourcePrepareKeyTransfer(sWindowName);
                    }
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("ForwInfoAddrType", tblAddressType, sItemNames, hWndItems);
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.TypeSet("CREATE_WINDOW");
                }

                return 0;
                #endregion
            }

            /// <summary>
            /// </summary>
            /// <returns></returns>
            public virtual SalBoolean ValidateAddressType()
            {
                #region Local Variables
                IDictionary<string, string> namedBindVariables = new Dictionary<string, string>();
                #endregion

                #region Actions
                namedBindVariables.Add("colsAddressTypeCodeDb", tblAddressType_colsAddressTypeCodeDb.QualifiedBindName);
                namedBindVariables.Add("colsAddressTypeCode", tblAddressType_colsAddressTypeCode.QualifiedBindName);
                DbPLSQLBlock("{colsAddressTypeCodeDb}  := &AO.ADDRESS_TYPE_CODE_API.Encode( {colsAddressTypeCode} IN ); ", namedBindVariables );
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
                        this.tblAddressType_colsAddressTypeCode.TypeCodeLookupInit("FORWARDER");
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
                        e.Return = this.ValidateAddressType();
                        return;
                    }
                }
                e.Return = true;
                return;
                #endregion
            }
            #endregion

            #region Event Handlers

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
                tblCommMethod.colsPartyTypeDb.Text = "FORWARDER";
                tblCommMethod.colsIdentity.Text = SalString.FromHandle(this.dfsForwarderId.EditDataItemValueGet());
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
                tblCommMethod.colsPartyTypeDb.Text = "FORWARDER";
                tblCommMethod.colsIdentity.Text = SalString.FromHandle(this.dfsForwarderId.EditDataItemValueGet());
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
                using (new SalContext(tblCommMethod))
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
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init(sSourceName, tblCommMethod, sItemNames, hWndItems);
                        return Ifs.Fnd.ApplicationForms.Var.DataTransfer.TypeSet("CREATE_WINDOW");
                    }
                    return ((cChildTableCommMethod)this.tblCommMethod).DataSourcePrepareKeyTransfer(sWindowName);
                }
                #endregion
            }
            #endregion

            #region Event Handlers

            private void tblCommMethod_DataRecordExecuteModifyEvent(object sender, cDataSource.DataRecordExecuteModifyEventArgs e)
            {
                e.Handled = true;
                e.ReturnValue = tblCommMethod_DataRecordExecuteModify(e.hSql);
            }

            private void tblCommMethod_DataRecordExecuteNewEvent(object sender, cDataSource.DataRecordExecuteNewEventArgs e)
            {
                e.Handled = true;
                e.ReturnValue = tblCommMethod_DataRecordExecuteNew(e.hSql);
            }

            private void tblCommMethod_DataSourcePrepareKeyTransferEvent(object sender, cDataSource.DataSourcePrepareKeyTransferEventArgs e)
            {
                e.Handled = true;
                e.ReturnValue = tblCommMethod_DataSourcePrepareKeyTransfer(e.sWindowName);
            }

            #endregion

        #endregion

        #region Window Actions

            /// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void frmForwarderInfoAddress_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew:
					this.frmForwarderInfoAddress_OnPM_DataRecordNew(sender, e);
					break;
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate:
					this.frmForwarderInfoAddress_OnPM_DataRecordDuplicate(sender, e);
					break;
				
				// IID 10990 - Start
				
				// On PM_TabAttachedWindowActivate
				
				// Call SetAddressLayouts()
				
				// Return TRUE
				
				// IID 10990 - End
				
				
				case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove:
					this.frmForwarderInfoAddress_OnPM_DataRecordRemove(sender, e);
					break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordPaste:
                    this.frmForwarderInfoAddres_OnPM_DataRecordPaste(sender, e);
                    break;
				
			}
			#endregion
		}
		
		/// <summary>
		/// PM_DataRecordNew event handler.
		/// </summary>
		/// <param name="message"></param>
		private void frmForwarderInfoAddress_OnPM_DataRecordNew(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Sys.wParam, Sys.lParam)) 
			{
				if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
				{
					Sal.SendMsg(this.cmbCountry, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, ((SalString)frmForwarderInfo.FromHandle(this.i_hWndParent).cmbCountry.Text).ToHandle());
                    sOldCountry = SalString.Null;
					this.SetCountry();
					// IID 10990 - Start
					this.SetAddressLayouts();
					// IID 10990 - End
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
		private void frmForwarderInfoAddress_OnPM_DataRecordDuplicate(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate, Sys.wParam, Sys.lParam)) 
			{
				if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
				{
					Sal.SendMsg(this.cmbCountry, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, ((SalString)frmForwarderInfo.FromHandle(this.i_hWndParent).cmbCountry.Text).ToHandle());
					this.SetCountry();
					// IID 10990 - Start
					this.SetAddressLayouts();
					// IID 10990 - End
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
		private void frmForwarderInfoAddress_OnPM_DataRecordRemove(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
			{
				if (!(this.CheckAnyDefaultAddresses("TRUE"))) 
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
        private void frmForwarderInfoAddres_OnPM_DataRecordPaste(object sender, WindowActionsEventArgs e)
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
				if (!(this.CheckAnyDefaultAddresses("FALSE"))) 
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

	}
}
