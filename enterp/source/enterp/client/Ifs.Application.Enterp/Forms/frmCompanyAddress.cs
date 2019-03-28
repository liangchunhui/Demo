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
// 090902	Hiwilk	Bug 82001, Modified frmCompanyAddress().
// 100611   Samblk  Bug 90626, Added missing Class message
// 111116   Nirplk  SFI-701, Merged bug 99501
// 120208   Janblk  EDEL-522,added tblCommMethod_PM_DataRecordNew() 
// 120406   PRatlk  EASTRTM-4755,refresh added to properly get the company and the address_id values for child windows 
// 121012   PRatlk  Bug 105758, Reverted the changes by Bug 82001 
// 131119   PRatlk  PBFI-2520, Child Table refactoring in ENTERP
// 140401   Kagalk  PBFI-4142, Merged Bug 113712, Modified to give a warning when deleting the last address type.
// 141115   Chhulk  PRFI-3129, Merged Bug 119227, Added cmbCountry_WindowActions()
// 160412   reanpl  STRLOC-53, Added handling of new attributes address3, address4, address5, address6
#endregion

using System.Drawing;
using System.Windows.Forms;
using Ifs.Fnd.ApplicationForms;
using Ifs.Fnd.Windows.Forms;
using PPJ.Runtime;
using PPJ.Runtime.Sql;
using PPJ.Runtime.Windows;
using PPJ.Runtime.Vis;

namespace Ifs.Application.Enterp
{
	
	/// <summary>
	/// </summary>
    public partial class frmCompanyAddress : cMasterDetailTabFormWindow
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
        public SalNumber nMsgReturn = 0;
        public SalString sStateLov = "";
        public SalString sCountyLov = "";
        public SalString sCityLov = "";
        public SalString sZipLov = "";
        public SalString sAddressSelection = "";
        public SalString sDetailAddress = "";
        public SalBoolean bModifiedAddress = false;
        public SalBoolean bPopulate = false;
        public SalString lsAddressLayoutsDbStmt = "";
        public SalString lsLovReferenceDbStmt = "";
        public SalString lsDetailedAddressDbStmt = "";
        public SalBoolean bIsFromClick = false;
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public frmCompanyAddress()
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
        public new static frmCompanyAddress FromHandle(SalWindowHandle handle)
        {
            return ((frmCompanyAddress)SalWindow.FromHandle(handle, typeof(frmCompanyAddress)));
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
                lsStmt = "&AO.Address_Type_Code_API.Enumerate_Type( :i_hWndFrame.frmCompanyAddress.__sAddrTypes, 'COMPANY' )";
                using (SignatureHints hints = SignatureHints.NewContext())
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
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("Company_Address_Type_API.Default_Exist", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                    DbPLSQLBlock(cSessionManager.c_hSql, ":i_hWndFrame.frmCompanyAddress.sResult := &AO.Company_Address_Type_API.Default_Exist (\r\n" + sFullNameTbl + ".tblAddressType_colsCompany,\r\n" + sFullNameTbl + ".tblAddressType_colsAddressId,\r\n" + sFullNameTbl + ".tblAddressType_colsAddressTypeCode )");
                }
                return sResult;
            }
            #endregion
        }
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override SalNumber vrtActivate(fcURL URL)
        {
            using (new SalContext(this))
            {
                lsAddressLayoutsDbStmt = "&AO.ADDRESS_PRESENTATION_API.Get_All_Layouts(:i_hWndFrame.frmCompanyAddress.sCountry,\r\n" +
                "						:i_hWndFrame.frmCompanyAddress.lsDisplayLayout,\r\n" +
                "						:i_hWndFrame.frmCompanyAddress.lsEditLayout,\r\n" +
                "						:i_hWndFrame.frmCompanyAddress.sCountryCode)";
                lsLovReferenceDbStmt = "&AO.Enterp_Address_Country_API.Set_Lov_Reverence_All(:i_hWndFrame.frmCompanyAddress.sCountryCode,\r\n" +
                "							:i_hWndFrame.frmCompanyAddress.sStateLov,\r\n" +
                "							:i_hWndFrame.frmCompanyAddress.sCountyLov, \r\n" +
                "                           :i_hWndFrame.frmCompanyAddress.sCityLov, \r\n" +
                "							:i_hWndFrame.frmCompanyAddress.sZipLov)";
                lsDetailedAddressDbStmt = ":i_hWndFrame.frmCompanyAddress.sDetailAddress := \r\n" +
                "                                               		&AO.Enterp_Address_Country_API.Get_Detailed_Address(\r\n" +
                "                                               		&AO.ISO_Country_Api.Encode(\r\n" +
                "				:i_hWndFrame.frmCompanyAddress.cmbCountry))";
                if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.RecCountGet() > 0)
                {
                    Sal.WaitCursor(true);
                    InitFromTransferredData(); //call local definition!
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
                    Sal.WaitCursor(false);
                    return false;
                }
                return base.Activate(URL);
            }
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override SalNumber vrtFrameActivate()
        {
            using (new SalContext(this))
            {
                lsAddressLayoutsDbStmt = "&AO.ADDRESS_PRESENTATION_API.Get_All_Layouts(:i_hWndFrame.frmCompanyAddress.sCountry,\r\n" +
                "						:i_hWndFrame.frmCompanyAddress.lsDisplayLayout,\r\n" +
                "						:i_hWndFrame.frmCompanyAddress.lsEditLayout,\r\n" +
                "						:i_hWndFrame.frmCompanyAddress.sCountryCode)";
                lsLovReferenceDbStmt = "&AO.Enterp_Address_Country_API.Set_Lov_Reverence_All(:i_hWndFrame.frmCompanyAddress.sCountryCode,\r\n" +
                "							:i_hWndFrame.frmCompanyAddress.sStateLov,\r\n" +
                "							:i_hWndFrame.frmCompanyAddress.sCountyLov, \r\n" +
                "							:i_hWndFrame.frmCompanyAddress.sCityLov, \r\n" +
                "							:i_hWndFrame.frmCompanyAddress.sZipLov)";
                lsDetailedAddressDbStmt = ":i_hWndFrame.frmCompanyAddress.sDetailAddress := \r\n" +
                "                                               		&AO.Enterp_Address_Country_API.Get_Detailed_Address(\r\n" +
                "                                               		&AO.ISO_Country_Api.Encode(\r\n" +
                "				:i_hWndFrame.frmCompanyAddress.cmbCountry))";
                if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.RecCountGet() > 0)
                {
                    Sal.WaitCursor(true);
                    InitFromTransferredData(); //call local definition!
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
                    Sal.WaitCursor(false);
                    return false;
                }
                return base.FrameActivate();
            }
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual new SalBoolean InitFromTransferredData()
        {
            #region Local Variables
            SalArray<SalString> sSqlColumn = new SalArray<SalString>();
            SalString lsWhereStmt = "";
            SalNumber n = 0;
            SalNumber nIndex = 0;
            SalNumber nRows = 0;
            SalNumber nColumns = 0;
            SalString sDelim = "";
            SalString sDelim2 = "";
            SalString sTmp = "";
            SalWindowHandle hAttachedWnd = SalWindowHandle.Null;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                nColumns = Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemNamesGet(sSqlColumn);
                nRows = Ifs.Fnd.ApplicationForms.Var.DataTransfer.RecCountGet();
                if ((nRows == 1) && (nColumns == 2) && (Vis.ArrayFindString(sSqlColumn, "COMPANY") >= 0) && (Vis.ArrayFindString(sSqlColumn, "ADDRESS_ID") >= 0))
                {
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemValueStrGet(Vis.ArrayFindString(sSqlColumn, "ADDRESS_ID"), 0, ref sAddressSelection);
                    return true;
                }
                return ((cMasterDetailTabFormWindow)this).InitFromTransferredData();
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
                    if (!(bPopulate))
                    {
                        GetDetailedAddress();
                    }
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
        public virtual SalNumber SetAddressSelection()
        {
            #region Local Variables
            SalString sDelim = "";
            SalString lsWhereStmt = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                sDelim = "";
                lsWhereStmt = "ADDRESS_ID = " + sDelim + "'" + sAddressSelection + "'";
                Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceUserWhere, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, lsWhereStmt.ToHandle());
                sAddressSelection = Ifs.Fnd.ApplicationForms.Const.strNULL;
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalNumber UM_DetailedAddress(SalNumber nWhat)
        {
            #region Actions
            using (new SalContext(this))
            {
                if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)
                {
                    if (DataSourceIsDirty(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire))
                    {
                        return false;
                    }
                    if (cmbAddressId.i_sMyValue == SalString.Null)
                    {
                        return false;
                    }
                    if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("dlgDetailedCompanyAddress"))))
                    {
                        return false;
                    }
                    if (sDetailAddress == "TRUE")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    return true;
                }
                else if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                {
                    ShowDetailedAddress();
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
                if (sMethod == "DetailedAddress")
                {
                    return UM_DetailedAddress(nWhat);
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
        public virtual SalNumber ShowDetailedAddress()
        {
            #region Local Variables
            SalArray<SalString> sItemNames = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                if (Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("dlgDetailedCompanyAddress")))
                {
                    if (sDetailAddress == "TRUE")
                    {
                        sItemNames[0] = "COMPANY";
                        hWndItems[0] = dfsCompany;
                        sItemNames[1] = "ADDRESS_ID";
                        hWndItems[1] = cmbAddressId;
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("EditableAddress", this, sItemNames, hWndItems);
                        dlgDetailedCompanyAddress.ModalDialog(i_hWndFrame);
                        Sal.SendMsg(i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceRefresh, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Ifs.Fnd.ApplicationForms.Const.POPULATE_Single);
                    }
                    bModifiedAddress = false;
                }
                return true;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber GetDetailedAddress()
        {
            #region Actions
            using (new SalContext(this))
            {
                sDetailAddress = SalString.Null;
                if (Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Enterp_Address_Country_API.Get_Detailed_Address"))
                {
                    // Statement parser was suppressed for this database call during porting
                    using (SignatureHints hints = SignatureHints.NewContext())
                    {
                        hints.Add("ISO_Country_Api.Encode", System.Data.ParameterDirection.Input);
                        hints.Add("Enterp_Address_Country_API.Get_Detailed_Address", System.Data.ParameterDirection.Input);
                        DbPLSQLBlock(cSessionManager.c_hSql, lsDetailedAddressDbStmt);
                    }
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
                sCountry = frmCompanyAddress.FromHandle(i_hWndFrame).cmbCountry.Text;
                if (sCountry == Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    sCountry = frmCompany.FromHandle(i_hWndParent).cmbCountry.Text;
                    frmCompanyAddress.FromHandle(i_hWndFrame).cmbCountry.Text = frmCompany.FromHandle(i_hWndParent).cmbCountry.Text;
                }
            }

            return 0;
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
                "		country_code_	VARCHAR2(10);\r\n	BEGIN " + lsDetailedAddressDbStmt + ";  " + Vis.StrSubstitute(lsAddressLayoutsDbStmt, ":i_hWndFrame.frmCompanyAddress.sCountryCode", "country_code_") + ";  " + Vis.StrSubstitute(lsLovReferenceDbStmt, ":i_hWndFrame.frmCompanyAddress.sCountryCode",
                    "country_code_") + "; " + ":i_hWndFrame.frmCompanyAddress.sCountryCode := country_code_;\r\n	END;";
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
            public SalArray<SalString> tblAddressType_sTempAddressValidation = new SalArray<SalString>();
            public SalArray<SalDateTime> tblAddressType_dTempFromDate = new SalArray<SalDateTime>();
            public SalArray<SalDateTime> tblAddressType_dTempToDate = new SalArray<SalDateTime>();
            public SalArray<SalString> tblAddressType_sAddressId = new SalArray<SalString>();
            public SalArray<SalString> tblAddressType_sAddressTypeCodeArr = new SalArray<SalString>();
            public SalArray<SalString> tblAddressType_sDefAddress = new SalArray<SalString>();
            public SalArray<SalString> tblAddressType_sObjId = new SalArray<SalString>();
            public SalArray<SalString> tblAddressType_sValidFlag = new SalArray<SalString>();
            public SalString tblAddressType_sTempCompany = "";
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
            public virtual SalBoolean CheckDefaultAddress()
            {
                #region Local Variables
                SalBoolean bTempValue = false;
                SalNumber nCurrentRow = 0;
                SalNumber nTempCount = 0;
                SalArray<SalString> sFlag = new SalArray<SalString>();
                SalArray<SalString> sMsgArr = new SalArray<SalString>();
                SalString sMsgTemp = "";
                SalArray<SalString> tblAddressType_sAddressIdMsg = new SalArray<SalString>();
                SalArray<SalString> sAddressTypeCodeMsg = new SalArray<SalString>();
                SalNumber nIndex = 0;
                SalNumber nCount = 0;
                SalString lsStmt = "";
                SalNumber nDefaultUncheckCount = 0;
                SalString tempAddressTypeCode = "";
                SalNumber tempCheckMsgCount = 0;
                SalNumber tempUnCheckMsgCount = 0;
                SalNumber nPrevCurrentRow = 0;
                SalNumber tempMsgCount = 0;
                #endregion

                #region Actions
                using (new SalContext(this))
                {
                    nPrevCurrentRow = Sal.TblQueryContext(tblAddressType);
                    nCurrentRow = Sys.TBL_MinRow;
                    bTempValue = true;
                    nTempCount = 0;
                    nIndex = 0;
                    nDefaultUncheckCount = 0;
                    tblAddressType_sTempCompany = SalString.Null;
                    sFlag.SetUpperBound(1, -1);
                    tblAddressType_sTempAddressValidation.SetUpperBound(1, -1);
                    tblAddressType_sValidFlag.SetUpperBound(1, -1);
                    tblAddressType_sDefAddress.SetUpperBound(1, -1);
                    tblAddressType_sAddressTypeCodeArr.SetUpperBound(1, -1);
                    tblAddressType_sObjId.SetUpperBound(1, -1);
                    tblAddressType_sAddressIdMsg.SetUpperBound(1, -1);
                    sAddressTypeCodeMsg.SetUpperBound(1, -1);
                    tblAddressType_dTempFromDate.SetUpperBound(1, -1);
                    tblAddressType_dTempToDate.SetUpperBound(1, -1);
                    while (true)
                    {
                        if (Sal.TblFindNextRow(tblAddressType, ref nCurrentRow, 0, 0))
                        {
                            Sal.TblSetContext(tblAddressType, nCurrentRow);
                            lsStmt = lsStmt + "&AO.COMPANY_ADDRESS_TYPE_API.Check_Def_Address_Exist (\r\n" +
                            "                                                                                                                        :i_hWndFrame.frmCompanyAddress.tblAddressType_sTempAddressValidation[" + nIndex.ToString(0) + "] OUT,\r\n" +
                            "                                                                                                                        :i_hWndFrame.frmCompanyAddress.tblAddressType_sValidFlag[" + nIndex.ToString(0) + "] OUT,\r\n" +
                            "                                                                                                                        :i_hWndFrame.frmCompanyAddress.tblAddressType_sTempCompany IN ,\r\n" +
                            "                                                                                                                        :i_hWndFrame.frmCompanyAddress.tblAddressType_sDefAddress[" + nIndex.ToString(0) + "] IN ,\r\n" +
                            "                                                                                                                        :i_hWndFrame.frmCompanyAddress.tblAddressType_sAddressTypeCodeArr[" + nIndex.ToString(0) + "] IN ,\r\n" +
                            "                                                                                                                        :i_hWndFrame.frmCompanyAddress.tblAddressType_sObjId[" + nIndex.ToString(0) + "] IN ,\r\n" +
                            "                                                                                                                        :i_hWndFrame.frmCompanyAddress.tblAddressType_dTempFromDate[" + nIndex.ToString(0) + "] IN ,\r\n" +
                            "                                                                                                                        :i_hWndFrame.frmCompanyAddress.tblAddressType_dTempToDate[" + nIndex.ToString(0) + "] IN );";
                            tblAddressType_sAddressId[nIndex] = this.tblAddressType_colsAddressId.Text;
                            tblAddressType_sAddressTypeCodeArr[nIndex] = this.tblAddressType_colsAddressTypeCode.Text;
                            tblAddressType_sDefAddress[nIndex] = this.tblAddressType_colDefAddress.Text;
                            tblAddressType_sObjId[nIndex] = this.tblAddressType.__colObjid.Text;
                            tblAddressType_sTempCompany = this.tblAddressType_colsCompany.Text;
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
                    frmCompany.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).bAddressType = true;
                    if (lsStmt != SalString.Null)
                    {
                        // Statement parser was suppressed for this database call during porting
                            if (DbPLSQLBlock(cSessionManager.c_hSql, " BEGIN " + lsStmt + " END; "))
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
                    sAddressTypeCodeMsg[1] = this.dfsPartyType.Text;
                    sAddressTypeCodeMsg[2] = this.tblAddressType_colsCompany.Text;
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
                    Sal.TblSetContext(tblAddressType, nPrevCurrentRow);
                    frmCompany.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndFrame)).bAddressType = true;
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
                using (new SalContext(this))
                {
                    nPrevCurrentRow = Sal.TblQueryContext(tblAddressType);
                    nCurrentRow = Sys.TBL_MinRow;
                    bTempValue = true;
                    nTempCount = 0;
                    nIndex = 0;
                    tblAddressType_sTempCompany = SalString.Null;
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
                            Sal.TblSetContext(tblAddressType, nCurrentRow);
                            if (this.tblAddressType_colDefAddress.Text == "TRUE")
                            {
                                lsStmt = lsStmt + "&AO.COMPANY_ADDRESS_TYPE_API.Check_Def_Address_Exist (\r\n" +
                                "                                                                                                                        :i_hWndFrame.frmCompanyAddress.tblAddressType_sTempAddressValidation[" + nIndex.ToString(0) + "] OUT,\r\n" +
                                "                                                                                                                        :i_hWndFrame.frmCompanyAddress.tblAddressType_sValidFlag[" + nIndex.ToString(0) + "] OUT ,\r\n" +
                                "                                                                                                                        :i_hWndFrame.frmCompanyAddress.tblAddressType_sTempCompany IN ,\r\n" +
                                "                                                                                                                        :i_hWndFrame.frmCompanyAddress.tblAddressType_sDefAddress[" + nIndex.ToString(0) + "] IN ,\r\n" +
                                "                                                                                                                        :i_hWndFrame.frmCompanyAddress.tblAddressType_sAddressTypeCodeArr[" + nIndex.ToString(0) + "] IN ,\r\n" +
                                "                                                                                                                        :i_hWndFrame.frmCompanyAddress.tblAddressType_sObjId[" + nIndex.ToString(0) + "] IN ,\r\n" +
                                "                                                                                                                        :i_hWndFrame.frmCompanyAddress.tblAddressType_dTempFromDate[" + ((SalNumber)0).ToString(0) + "] IN,\r\n" +
                                "                                                                                                                        :i_hWndFrame.frmCompanyAddress.tblAddressType_dTempToDate[" + ((SalNumber)0).ToString(0) + "] IN );";
                                tblAddressType_sAddressId[nIndex] = this.tblAddressType_colsAddressId.Text;
                                tblAddressType_sAddressTypeCodeArr[nIndex] = this.tblAddressType_colsAddressTypeCode.Text;
                                tblAddressType_sDefAddress[nIndex] = this.tblAddressType_colDefAddress.Text;
                                tblAddressType_sObjId[nIndex] = this.tblAddressType.__colObjid.Text;
                                tblAddressType_sTempCompany = this.tblAddressType_colsCompany.Text;
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
                    sAddressTypeCodeMsg[1] = this.dfsPartyType.Text;
                    sAddressTypeCodeMsg[2] = this.tblAddressType_colsCompany.Text;
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
                        sMessage[1] = this.dfsPartyType.Text.ToLower();
                        sMessage[2] = this.tblAddressType_colsCompany.Text;
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
                    tblAddressType_sTempCompany = SalString.Null;
                    nCount = tblAddressType_sTempAddressValidation.GetUpperBound(1);
                    lsStmt = SalString.Null;
                    while (nIndex <= nCount)
                    {
                        if (tblAddressType_sTempAddressValidation[nIndex] == "FALSE")
                        {
                            lsStmt = lsStmt + "&AO.COMPANY_ADDRESS_TYPE_API.Check_Def_Addr_Temp (:i_hWndFrame.frmCompanyAddress.tblAddressType_sTempCompany IN,\r\n" +
                            "                                                                                                                        :i_hWndFrame.frmCompanyAddress.tblAddressType_sAddressTypeCodeArr[" + nIndex.ToString(0) + "] IN,\r\n" +
                            "                                                                                                                        :i_hWndFrame.frmCompanyAddress.tblAddressType_sDefAddress[" + nIndex.ToString(0) + "] IN,\r\n" +
                            "                                                                                                                        :i_hWndFrame.frmCompanyAddress.tblAddressType_sObjId[" + nIndex.ToString(0) + "] IN,\r\n" +
                            "                                                                                                                        :i_hWndFrame.frmCompanyAddress.tblAddressType_dTempFromDate[" + nIndex.ToString(0) + "] IN,\r\n" +
                            "                                                                                                                        :i_hWndFrame.frmCompanyAddress.tblAddressType_dTempToDate[" + nIndex.ToString(0) + "] IN ); ";
                            tblAddressType_dTempFromDate[nIndex] = this.dfdValidFrom.DateTime;
                            tblAddressType_dTempToDate[nIndex] = this.dfdValidTo.DateTime;
                            tblAddressType_sTempCompany = this.tblAddressType_colsCompany.Text;
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
                using (new SalContext(this))
                {
                    if (sWindowName == Pal.GetActiveInstanceName("frmHistoryLog"))
                    {
                        sItemNames[0] = "ADDRESS_ID";
                        hWndItems[0] = tblAddressType_colsAddressId;
                        sItemNames[1] = "ADDRESS_TYPE_CODE";
                        hWndItems[1] = tblAddressType_colsAddressTypeCodeDb;
                        sItemNames[2] = "COMPANY";
                        hWndItems[2] = tblAddressType_colsCompany;
                    }
                    else
                    {
                        return ((cDataSource)this).DataSourcePrepareKeyTransfer(sWindowName);
                    }
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("CompanyAddressType", tblAddressType, sItemNames, hWndItems);
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
                #region Actions
                
                DbPLSQLBlock(cSessionManager.c_hSql, this.sFullNameTbl + ".tblAddressType_colsAddressTypeCodeDb  :=\r\n" +
                            "                        &AO.ADDRESS_TYPE_CODE_API.Encode( " + this.sFullNameTbl + ".tblAddressType_colsAddressTypeCode IN)");
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
                        this.tblAddressType_colsAddressTypeCode.TypeCodeLookupInit("COMPANY");
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
                using (new SalContext(tblCommMethod))
                {
                    tblCommMethod.colsPartyTypeDb.Text = "COMPANY";
                    tblCommMethod.colsIdentity.Text = SalString.FromHandle(this.dfsCompany.EditDataItemValueGet());
                    tblCommMethod.colsAddressId.Text = SalString.FromHandle(this.cmbAddressId.EditDataItemValueGet());
                    tblCommMethod.colsPartyTypeDb.EditDataItemSetEdited();
                    tblCommMethod.colsIdentity.EditDataItemSetEdited();
                    tblCommMethod.colsAddressId.EditDataItemSetEdited();
                    return ((cTableManager)this.tblCommMethod).DataRecordExecuteNew(hSql);
                }
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
                using (new SalContext(tblCommMethod))
                {
                    tblCommMethod.colsPartyTypeDb.Text = "COMPANY";
                    tblCommMethod.colsIdentity.Text = SalString.FromHandle(this.dfsCompany.EditDataItemValueGet());
                    tblCommMethod.colsAddressId.Text = SalString.FromHandle(this.cmbAddressId.EditDataItemValueGet());
                    tblCommMethod.colsPartyTypeDb.EditDataItemSetEdited();
                    tblCommMethod.colsIdentity.EditDataItemSetEdited();
                    tblCommMethod.colsAddressId.EditDataItemSetEdited();
                    return ((cTableManager)this.tblCommMethod).DataRecordExecuteModify(hSql);
                }
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

            #region Window Actions

            private void tblCommMethod_WindowActions(object sender, WindowActionsEventArgs e)
            {
                #region Actions
                switch (e.ActionType)
                {
                    case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew:
                        e.Handled = true;
                        this.tblCommMethod_PM_DataRecordNew(sender, e);
                        break;
                }
                #endregion
            }

            private void tblCommMethod_PM_DataRecordNew(object sender, WindowActionsEventArgs e)
            {
                #region Actions
                e.Handled = true;
                if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Sys.wParam, Sys.lParam))
                {
                    if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                    {
                        this.tblCommMethod.colsPartyTypeDb.Text = "COMPANY";
                        this.tblCommMethod.colsPartyTypeDb.EditDataItemSetEdited();
                    }
                    e.Return = true;
                    return;
                }
                e.Return = false;
                return;
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
        private void frmCompanyAddress_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew:
                    this.frmCompanyAddress_OnPM_DataRecordNew(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate:
                    this.frmCompanyAddress_OnPM_DataRecordDuplicate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_TabAttachedWindowActivate:
                    this.frmCompanyAddress_OnPM_TabAttachedWindowActivate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate:
                    this.frmCompanyAddress_OnPM_DataSourcePopulate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove:
                    this.frmCompanyAddress_OnPM_DataRecordRemove(sender, e);
                    break;

                case Const.PAM_DetailAddress:
                    this.frmCompanyAddress_OnPAM_DetailAddress(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordPaste:
                    this.frmCompanyAddress_OnPM_DataRecordPaste(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataRecordNew event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmCompanyAddress_OnPM_DataRecordNew(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Sys.wParam, Sys.lParam))
            {
                if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                {
                    this.picTab.BringToTop(this.picTab.FindName("Name0"), true);
                    Sal.SendMsg(this.cmbCountry, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, ((SalString)frmCompany.FromHandle(this.i_hWndParent).cmbCountry.Text).ToHandle());
                    this.picTab.Enable(this.picTab.FindName("DOMAIN-frmCompDeliveryFeeCode"), false);
                    this.picTab.Enable(this.picTab.FindName("DOMAIN-frmCompanyInvoiceInfo"), false);                    
                    this.NewAddressTypes();
                    sOldCountry = SalString.Null;
                    this.SetCountry();
                    this.SetAddressLayouts();
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
        private void frmCompanyAddress_OnPM_DataRecordDuplicate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate, Sys.wParam, Sys.lParam))
            {
                if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                {
                    this.picTab.Enable(this.picTab.FindName("DOMAIN-frmCompDeliveryFeeCode"), false);
                    this.picTab.Enable(this.picTab.FindName("DOMAIN-frmCompanyInvoiceInfo"), false);                    
                    Sal.SendMsg(this.cmbCountry, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, ((SalString)frmCompany.FromHandle(this.i_hWndParent).cmbCountry.Text).ToHandle());
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
        /// PM_DataRecordPaste event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmCompanyAddress_OnPM_DataRecordPaste(object sender, WindowActionsEventArgs e)
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
        /// PM_TabAttachedWindowActivate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmCompanyAddress_OnPM_TabAttachedWindowActivate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.HideWindowAndLabel(this.dfsAddress1);
            Sal.HideWindowAndLabel(this.dfsAddress2);
            Sal.HideWindowAndLabel(this.dfsAddress3);
            Sal.HideWindowAndLabel(this.dfsAddress4);
            Sal.HideWindowAndLabel(this.dfsAddress5);
            Sal.HideWindowAndLabel(this.dfsAddress6);
            Sal.HideWindowAndLabel(this.dfsZipCode);
            Sal.HideWindowAndLabel(this.dfsCity);
            Sal.HideWindowAndLabel(this.dfsCounty);
            Sal.HideWindowAndLabel(this.dfsState);
            Sal.HideWindowAndLabel(this.dfsState);
            e.Return = true;
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataSourcePopulate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmCompanyAddress_OnPM_DataSourcePopulate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.sAddressSelection != Ifs.Fnd.ApplicationForms.Const.strNULL && Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                this.SetAddressSelection();
            }
            this.nMsgReturn = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Sys.wParam, Sys.lParam);
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute && this.nMsgReturn == 1)
            {
                this.picTab.Enable(this.picTab.FindName("DOMAIN-frmCompDeliveryFeeCode"), true);
                this.picTab.Enable(this.picTab.FindName("DOMAIN-frmCompanyInvoiceInfo"), true);                
            }
            e.Return = this.nMsgReturn;
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataRecordRemove event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmCompanyAddress_OnPM_DataRecordRemove(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                frmCompany.FromHandle(this.i_hWndParent).bRemoved = true;
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
        /// PAM_DetailAddress event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmCompanyAddress_OnPAM_DetailAddress(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.bModifiedAddress)
            {
                this.GetDetailedAddress();
                this.ShowDetailedAddress();
            }
            this.bModifiedAddress = false;
            e.Return = true;
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void cmbAddressId_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemSave:
                    this.cmbAddressId_OnPM_DataItemSave(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemSave event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cmbAddressId_OnPM_DataItemSave(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.picTab.Enable(this.picTab.FindName("DOMAIN-frmCompDeliveryFeeCode"), true);
            this.picTab.Enable(this.picTab.FindName("DOMAIN-frmCompanyInvoiceInfo"), true);            
            Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemSave, Sys.wParam, Sys.lParam);
            this.bModifiedAddress = true;
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

                case Sys.SAM_DropDown:
                    e.Handled = true;
                    this.cmbCountry.LookupInit();
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
            this.GetDetailedAddress();
            this.bModifiedAddress = true;
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
            this.sFullNameTbl = ":i_hWndFrame." + Ifs.Fnd.ApplicationForms.Int.QualifiedItemNameGet(this);
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

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void dfsAddress1_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet:
                    this.dfsAddress1_OnPM_DataItemValueSet(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValueSet event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsAddress1_OnPM_DataItemValueSet(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == 1)
            {
                this.bModifiedAddress = true;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void dfsAddress2_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet:
                    this.dfsAddress2_OnPM_DataItemValueSet(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValueSet event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsAddress2_OnPM_DataItemValueSet(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == 1)
            {
                this.bModifiedAddress = true;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        private void dfsAddress3_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet:
                    this.dfsAddress3_OnPM_DataItemValueSet(sender, e);
                    break;
            }
            #endregion
        }

        private void dfsAddress3_OnPM_DataItemValueSet(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == 1)
            {
                this.bModifiedAddress = true;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        private void dfsAddress4_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet:
                    this.dfsAddress4_OnPM_DataItemValueSet(sender, e);
                    break;
            }
            #endregion
        }

        private void dfsAddress4_OnPM_DataItemValueSet(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == 1)
            {
                this.bModifiedAddress = true;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        private void dfsAddress5_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet:
                    this.dfsAddress5_OnPM_DataItemValueSet(sender, e);
                    break;
            }
            #endregion
        }

        private void dfsAddress5_OnPM_DataItemValueSet(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == 1)
            {
                this.bModifiedAddress = true;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        private void dfsAddress6_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet:
                    this.dfsAddress6_OnPM_DataItemValueSet(sender, e);
                    break;
            }
            #endregion
        }

        private void dfsAddress6_OnPM_DataItemValueSet(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == 1)
            {
                this.bModifiedAddress = true;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void dfsZipCode_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet:
                    this.dfsZipCode_OnPM_DataItemValueSet(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValueSet event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsZipCode_OnPM_DataItemValueSet(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == 1)
            {
                this.bModifiedAddress = true;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void dfsCity_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet:
                    this.dfsCity_OnPM_DataItemValueSet(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValueSet event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsCity_OnPM_DataItemValueSet(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == 1)
            {
                this.bModifiedAddress = true;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void dfsCounty_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet:
                    this.dfsCounty_OnPM_DataItemValueSet(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValueSet event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsCounty_OnPM_DataItemValueSet(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == 1)
            {
                this.bModifiedAddress = true;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void dfsState_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet:
                    this.dfsState_OnPM_DataItemValueSet(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValueSet event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsState_OnPM_DataItemValueSet(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == 1)
            {
                this.bModifiedAddress = true;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, Sys.wParam, Sys.lParam);
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

        public override SalNumber vrtDataSourceSaveMarkCommitted()
        {
            #region Local Variables
            SalNumber nReturn;
            #endregion

            #region Actions
            nReturn = base.vrtDataSourceSaveMarkCommitted();
            // This make sures that company and address_id of the child windows get updates properly when a new address_id is saved.
            Sal.SendMsgToChildren(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceRefresh, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
            return nReturn;
            #endregion
        }
        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalNumber vrtUserMethod(SalNumber nWhat, SalString sMethod)
        {
            return this.UserMethod(nWhat, sMethod);
        }
        #endregion

        #region Event Handlers

        private void menuItem_View_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            // TODO: Rewrite command event handler not to use UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            ((FndCommand)sender).Enabled = Sal.SendMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, ((SalString)"DetailedAddress").ToHandle());
        }

        private void menuItem_View_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            // TODO: Rewrite command event handler not to make use of UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            Ifs.Fnd.ApplicationForms.Int.PostMessage(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, "DetailedAddress");
        }

        #endregion

    }
}
