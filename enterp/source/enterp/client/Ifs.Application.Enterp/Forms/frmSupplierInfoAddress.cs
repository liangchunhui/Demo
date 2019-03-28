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
// 090902	Hiwilk	Bug 82001, Modified frmSupplierInfoAddress().
// 100611   Samblk  Bug 90626, Added missing Class message
// 100929   Kanslk  Bug 93177, Instead of vrtActivate, vrtFrameActivate is used.
// 111116   Nirplk  SFI-701, Merged bug 99501
// 121003   Hiralk  Merged bug 104665.
// 121012   PRatlk  Bug 105758, Reverted the changes by Bug 82001.
// 121221   Nirplk  Merged 106346.
// 130205   Kagalk  Merged bug 106801.
// 131203   PRatlk  PBFI-2547, Client Refactoring in ENTERP.
// 140401   Kagalk  PBFI-4142, Merged Bug 113712, Modified to give a warning when deleting the last address type.
// 140704   MaRalk  PRSC-1620, Added method tblSupplierInfoContact_colsPersonId_OnPM_DataItemZoom.
// 140818   Kagalk  Bug 118344, Added check if Supplier has been created in Method_Inquire for DataRecordNew
// 150824   MaRalk  BLU-1182, Modified colsPersonId_OnPM_DataItemValidate to add the parameter www for the method call
// 150824           Person_Info_Address_API.Get_Default_Contact_Info. 
// 150831   RoJalk  AFT-2384, Added PM_DataItemLovUserWhere to filter persons allowed as supplier contacts and not blocked. 
// 150902   SudJlk  AFT-3038, Added method tblSupplierInfoContact_HandleSrmColumns and called it in FrameStarupUser to set visibility of SRM columns only when SRM installed.
// 160419	Chgulk	STRLOC-347, Added new fields dfsAddress3,dfsAddress4,dfsAddress5,dfsAddress6.
// 170627   Bhhilk  STRFI-6919, Merged Bug 136450, Modified tblAddressType_OnPM_DataRecordRemove and introduced tblAddressType_CheckTaxInfoExists.
// 171213   Nirylk  STRFI-9846, Merged LCS Bug 137494, Modified tblSupplierInfoContact_colsPersonId_OnPM_DataItemZoom().
#endregion

using System.Collections;
using System.Collections.Generic;
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
    [FndWindowRegistration("SUPPLIER_INFO_ADDRESS", "SupplierInfoAddress")]
    [FndWindowRegistration("SUPP_INFO_CONTACT_LOV_PUB", "SupplierAddress", FndWindowRegistrationFlags.HomePage | FndWindowRegistrationFlags.NoSecurity)]
    public partial class frmSupplierInfoAddress : cMasterDetailTabFormWindow
    {
        #region Window Variables
        public SalString __sAddrTypes = "";
        public SalString sResult = "";
        public SalString lsDisplayLayout = "";
        public SalString lsEditLayout = "";
        public SalString sOldCountry = "";
        public SalString sCountry = "";
        public SalString sCountryCode = "";
        public SalWindowHandle hWndZoomIn = SalWindowHandle.Null;
        public SalArray<SalString> sItemValues = new SalArray<SalString>();
        public SalString sStateLov = "";
        public SalString sCountyLov = "";
        public SalString sCityLov = "";
        public SalString sZipLov = "";
        public SalString sSourceName = "";
        public SalArray<SalString> sAddressId = new SalArray<SalString>();
        public SalBoolean bPopulate = false;
        public SalString lsAddressLayoutsDbStmt = "";
        public SalString lsLovReferenceDbStmt = "";
        public SalArray<SalString> sResultTemp = new SalArray<SalString>();
        public SalBoolean bIsFromClick = false;
        public SalString sExist;
        public SalString sPurchTabActive = "";
        public SalString sPurchTaxTabActive = "";
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public frmSupplierInfoAddress()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();
            this.MinimumSize = new Size(0, 565); 
        }
        #endregion

        #region System Methods/Properties

        /// <summary>
        /// Returns the object instance associated with the window handle.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public new static frmSupplierInfoAddress FromHandle(SalWindowHandle handle)
        {
            return ((frmSupplierInfoAddress)SalWindow.FromHandle(handle, typeof(frmSupplierInfoAddress)));
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
                lsStmt = SalString.Null;
                if (__sAddrTypes != Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    sStartDel = Ifs.Fnd.ApplicationForms.Const.strNULL;
                    sEndDel = ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_US).ToCharacter();
                    nTok = __sAddrTypes.Tokenize(sStartDel, sEndDel, sTokenArray);
                    n = 0;
                    while (n < nTok)
                    {
                        tblAddressType_sSupplierId[n] = dfsSupplierId.Text;
                        tblAddressType_sAddressIdTemp[n] = cmbAddressId.i_sMyValue;
                        tblAddressType_sAddressTypeCode[n] = sTokenArray[n];
                        lsStmt = lsStmt + DefaultExist(n);
                        n = n + 1;
                    }
                    if (Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Enterp_Address_Country_API.Set_Lov_Reverence_All"))
                    {
                        if (!(bPopulate))
                        {
                            lsStmt = lsStmt + lsLovReferenceDbStmt + ";";
                        }
                    }
                    if (lsStmt != SalString.Null)
                    {
                        DbPLSQLBlock(cSessionManager.c_hSql, " BEGIN " + lsStmt + " END;");
                    }
                    n = 0;
                    while (n < nTok)
                    {
                        Sal.SendMsg(tblAddressType, Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                        tblAddressType_colsAddressTypeCode.Text = sTokenArray[n];
                        tblAddressType_colsAddressTypeCode.EditDataItemSetEdited();
                        tblAddressType_colsAddressId.Text = SalString.FromHandle(this.cmbAddressId.EditDataItemValueGet());
                        tblAddressType_colsAddressId.EditDataItemSetEdited();
                        if (sResultTemp[n] == "FALSE")
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
        /// <param name="nCount"></param>
        /// <returns>
        /// </returns>
        public virtual SalString DefaultExist(SalNumber nCount)
        {

            #region Local Variables
            SalString sCount = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                sCount = nCount.ToString(0);
                return ":i_hWndFrame.frmSupplierInfoAddress.sResultTemp[" + sCount + "] := &AO.Supplier_Info_Address_Type_API.Default_Exist(:i_hWndFrame.frmSupplierInfoAddress.tblAddressType_sSupplierId[" + sCount + "] ,:i_hWndFrame.frmSupplierInfoAddress.tblAddressType_sAddressIdTemp[" + sCount + "] ,\r\n" +
                       ":i_hWndFrame.frmSupplierInfoAddress.tblAddressType_sAddressTypeCode[" + sCount + "] );";
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public new SalBoolean FrameStartupUser()
        {
            #region Local Variables
            SalString lsStmt = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                lsAddressLayoutsDbStmt = "&AO.ADDRESS_PRESENTATION_API.Get_All_Layouts(:i_hWndFrame.frmSupplierInfoAddress.sCountry,\r\n" +
                "						:i_hWndFrame.frmSupplierInfoAddress.lsDisplayLayout,\r\n" +
                "						:i_hWndFrame.frmSupplierInfoAddress.lsEditLayout,\r\n" +
                "						:i_hWndFrame.frmSupplierInfoAddress.sCountryCode )";
                lsLovReferenceDbStmt = "&AO.Enterp_Address_Country_API.Set_Lov_Reverence_All(:i_hWndFrame.frmSupplierInfoAddress.sCountryCode,\r\n" +
                "							:i_hWndFrame.frmSupplierInfoAddress.sStateLov,\r\n" +
                "							:i_hWndFrame.frmSupplierInfoAddress.sCountyLov, \r\n" +
                "							:i_hWndFrame.frmSupplierInfoAddress.sCityLov, \r\n" +
                "							:i_hWndFrame.frmSupplierInfoAddress.sZipLov )";
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("Address_Type_Code_API.Enumerate_Type", System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Input);
                    DbPLSQLBlock(cSessionManager.c_hSql, "&AO.Address_Type_Code_API.Enumerate_Type( :i_hWndFrame.frmSupplierInfoAddress.__sAddrTypes, 'SUPPLIER')");
                }
                // Code moved to vrtFrameActivate
                // Hide/Visible according to SRM component is installed.
                tblSupplierInfoContact_HandleSrmColumns();
            }

            return false;
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
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalNumber UM_TaxCode(SalNumber nWhat)
        {
            #region Local Variables
            SalArray<SalString> sItemNames = new SalArray<SalString>();
            SalArray<SalWindowHandle> hItemValues = new SalArray<SalWindowHandle>();
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        if (dfsCountryCode.Text != "AR")
                        {
                            return false;
                        }
                        if (Ifs.Fnd.ApplicationForms.Var.Component.IsWindowAvailable(Pal.GetActiveInstanceName("frmTaxCodeInfo")))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                        goto case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("SupplierInfoAddress", i_hWndSelf, sItemNames, hItemValues);
                        sItemValues[0] = dfsSupplierId.Text;
                        sItemValues[1] = cmbAddressId.i_sMyValue;
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemAdd("SUPPLIER_ID", sItemValues);
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemAdd("ADDRESS_ID", sItemValues);
                        SessionNavigate(Pal.GetActiveInstanceName("frmTaxCodeInfo"));
                        break;
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nWhat">
        /// Standard method parameter
        /// Standard method parameter. Possible values are METHOD_Inquire, METHOD_Execute, METHOD_GetType
        /// </param>
        /// <param name="sMethod">
        /// Method name
        /// Name of the method to be executed.
        /// </param>
        /// <returns>
        /// When nWhat = METHOD_Inquire: the return value should be TRUE if the
        /// method is available (possible to execute), FALSE otherwise.
        /// When nWhat = METHOD_Execute: the return value should be TRUE if the method
        /// is completed sucessfully, FALSE otherwise.
        /// </returns>
        public new SalNumber UserMethod(SalNumber nWhat, SalString sMethod)
        {
            #region Actions
            using (new SalContext(this))
            {
                if (sMethod == "TaxCodeInfo")
                {
                    return UM_TaxCode(nWhat);
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="bExecute">Bug 82148, Begin, Added bExecute check.</param>
        /// <returns></returns>
        public virtual SalNumber SetLovReverence(SalBoolean bExecute)
        {

            #region Actions
            using (new SalContext(this))
            {
                if (Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Enterp_Address_Country_API.Set_Lov_Reverence_All"))
                {
                    if (bExecute)
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
                sCountry = frmSupplierInfoAddress.FromHandle(i_hWndFrame).cmbCountry.Text;
                if (sCountry == Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    sCountry = frmSupplierInfo.FromHandle(i_hWndParent).cmbCountry.Text;
                    frmSupplierInfoAddress.FromHandle(i_hWndFrame).cmbCountry.Text = frmSupplierInfo.FromHandle(i_hWndParent).cmbCountry.Text;
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
                "		country_code_	VARCHAR2(10);\r\n	BEGIN " + Vis.StrSubstitute(lsAddressLayoutsDbStmt, ":i_hWndFrame.frmSupplierInfoAddress.sCountryCode", "country_code_") + ";  " + Vis.StrSubstitute(lsLovReferenceDbStmt, ":i_hWndFrame.frmSupplierInfoAddress.sCountryCode",
                    "country_code_") + "; " + ":i_hWndFrame.frmSupplierInfoAddress.sCountryCode := country_code_;\r\n	END;";
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

        public new SalNumber TabActivateStart(SalWindowHandle hWnd, SalNumber nTab)
        {
            #region Local Variables
            SalString sName = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                picTab.GetName(nTab, ref sName);
                if (sName == Pal.GetActiveInstanceName("frmSupplierAddress"))
                {
                    sPurchTabActive = "TRUE";
                }
                else if (sName == Pal.GetActiveInstanceName("frmSupplierTaxInfo"))
                {
                    sPurchTaxTabActive = "TRUE";
                }
            }
            return 0;
            #endregion
        }

        public virtual void RefreshTabs()
        {
            #region Actions
            if (frmSupplierInfo.FromHandle(i_hWndParent).cbOneTimeDb.IsChecked())
            {
                this.picTab.Enable(this.picTab.FindName("frmSupplierAddress"), false);
                this.picTab.BringToTop(0, true);
            }
            else
            {
                this.picTab.Enable(this.picTab.FindName("frmSupplierAddress"), true);
            }
            #endregion
        }

        public virtual SalBoolean ValidateOneTimeInfo()
        {
            #region Local Variables
            SalArray<SalString> sParam = new SalArray<SalString>(2);
            #endregion

            #region Actions
            if (sPurchTabActive == "TRUE")
            {
                if ((Sal.SendMsg(this.TabAttachedWindowHandleGet(this.picTab.FindName("frmSupplierAddress")), Ifs.Fnd.ApplicationForms.Const.PM_DataSourceIsDirty, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0)))
                {
                    sParam[0] = dfsSupplierId.Text;
                    sParam[1] = Properties.Resources.TAB_NAME_Purch;
                    Ifs.Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.TEXT_InvalidOneTimeSupplier, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok, sParam);
                    return false;
                }
            }
            else if (sPurchTaxTabActive == "TRUE")
            {
                if ((Sal.SendMsg(this.TabAttachedWindowHandleGet(this.picTab.FindName("frmSupplierTaxInfo")), Ifs.Fnd.ApplicationForms.Const.PM_DataSourceIsDirty, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0)))
                {
                    sParam[0] = dfsSupplierId.Text;
                    sParam[1] = Properties.Resources.TAB_NAME_Purch;
                    Ifs.Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.TEXT_InvalidOneTimeSupplier, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok, sParam);
                    return false;
                }
            }
            return true;
            #endregion
        }

        public virtual SalBoolean tblAddressType_CheckTaxInfoExists()
        {
            SalNumber nCurrentRow = Sys.TBL_MinRow;
            tblAddressType.SetRowFlags(tblAddressType.ContextRow, Sys.ROW_Selected, true);
            while (Sal.TblFindNextRow(tblAddressType, ref nCurrentRow, Sys.ROW_Selected, 0))
            {
                Sal.TblSetContext(tblAddressType, nCurrentRow);
                if (this.tblAddressType_colsAddressTypeCodeDb.Text == "INVOICE")
                {
                    if (!DbPLSQLBlock(@"&AO.Supplier_Info_Address_Type_API.Check_Doc_Tax_Info_Exist__({0} IN, {1} IN);", this.tblAddressType_colsSupplierId.QualifiedBindName, this.tblAddressType_colsAddressId.QualifiedBindName))
                    {
                        return true;
                    }
                }
                else if (this.tblAddressType_colsAddressTypeCodeDb.Text == "DELIVERY")
                {
                    if (!DbPLSQLBlock(@"&AO.Supplier_Info_Address_Type_API.Check_Del_Tax_Info_Exist__({0} IN, {1} IN);", this.tblAddressType_colsSupplierId.QualifiedBindName, this.tblAddressType_colsAddressId.QualifiedBindName))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        #endregion

        #region Window Actions

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void frmSupplierInfoAddress_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew:
                    this.frmSupplierInfoAddress_OnPM_DataRecordNew(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate:
                    this.frmSupplierInfoAddress_OnPM_DataRecordDuplicate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_TabAttachedWindowActivate:
                    this.frmSupplierInfoAddress_OnPM_TabAttachedWindowActivate(sender, e);
                    break;

                case Sys.SAM_Create:
                    this.frmSupplierInfoAddress_OnSAM_Create(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove:
                    this.frmSupplierInfoAddress_OnPM_DataRecordRemove(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordPaste:
                    this.frmSupplierInfoAddress_OnPM_DataRecordPaste(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_User:
                    this.frmSupplierInfoAddress_OnPM_User(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataRecordNew event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmSupplierInfoAddress_OnPM_DataRecordNew(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Sys.wParam, Sys.lParam))
            {                
                if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)
                {
                    if (SendMessageToParent(Const.PAM_RecordNotInitiallySaved, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0))
                    {
                        e.Return = false;
                        return;
                    }
                }    
                else if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)                
                {
                    if (frmSupplierInfo.FromHandle(this.i_hWndParent).cmbCountry.Text != Sys.STRING_Null)
                    {
                        Sal.SendMsg(this.cmbCountry, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, ((SalString)frmSupplierInfo.FromHandle(this.i_hWndParent).cmbCountry.Text).ToHandle());
                    }
                    sOldCountry = SalString.Null;
                    this.SetCountry();
                    this.SetAddressLayouts();
                    this.NewAddressTypes();
                    this.SetLovReverence(false);
                    this.RefreshTabs();
                    this.picTab.BringToTop(0, true);
                    Sal.SetFocus(this.cmbAddressId);
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
        private void frmSupplierInfoAddress_OnPM_DataRecordDuplicate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate, Sys.wParam, Sys.lParam))
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
        private void frmSupplierInfoAddress_OnPM_TabAttachedWindowActivate(object sender, WindowActionsEventArgs e)
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
        /// SAM_Create event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmSupplierInfoAddress_OnSAM_Create(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam);
            Sal.SetWindowText(this, Properties.Resources.WH_frmSupplierInfoAddress);
            // Corrected 134612
            #endregion
        }

        /// <summary>
        /// PM_DataRecordRemove event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmSupplierInfoAddress_OnPM_DataRecordRemove(object sender, WindowActionsEventArgs e)
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
        private void frmSupplierInfoAddress_OnPM_DataRecordPaste(object sender, WindowActionsEventArgs e)
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

        private void frmSupplierInfoAddress_OnPM_User(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                if (SalString.FromHandle(Sys.lParam) == "ValidateOneTime")
                {
                    e.Return = this.ValidateOneTimeInfo();
                    return;
                }
            }
            e.Return = Sal.SendMsgToChildren(this.i_hWndFrame, Ifs.Fnd.ApplicationForms.Const.PM_User, Sys.wParam, Sys.lParam);
            return;
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
            this.RefreshTabs();
            this.bPopulate = true;
            this.SetCountry();
            this.InitValuesForPopulate();
            this.SetAddressLayouts();
            this.SetLovReverence(true);
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
            this.SetLovReverence(true);
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

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove:
                    this.tblAddressType_OnPM_DataRecordRemove(sender, e);
                    break;

            }
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
                if (!tblAddressType_CheckTaxInfoExists())
                {
                    if (!(this.tblAddressType_CheckAnyDefaultAddresses("FALSE")))
                    {
                        e.Return = false;
                        return;
                    }
                }
                else
                {
                    e.Return = false;
                    return;
                }
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        private void tblCommMethod_coldValidFrom_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.coldValidFrom_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        private void coldValidFrom_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Local Variables
            SalArray<SalString> sDefMethList = new SalArray<SalString>(1);
            #endregion

            #region Actions
            e.Handled = true;
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
            sDefMethList[0] = Ifs.Fnd.ApplicationForms.Const.strNULL;

            if (Sys.wParam == 1 && this.tblCommMethod.coldValidFrom.DateTime != this.tblCommMethod_coldValidFromOld.DateTime)
            {
                if (Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Comm_Method_API.Comm_Id_Exist"))
                {
                    using (new SalContext(this))
                    {
                        DbPLSQLBlock(cSessionManager.c_hSql, " BEGIN :i_hWndFrame.frmSupplierInfoAddress.sExist := &AO.Comm_Method_API.Comm_Id_Exist(\r\n" +
                                                             "		:i_hWndFrame.frmSupplierInfoAddress.tblCommMethod.colsIdentity IN,\r\n" +
                                                             "		:i_hWndFrame.frmSupplierInfoAddress.tblCommMethod.colsPartyType IN,\r\n" +
                                                             "		:i_hWndFrame.frmSupplierInfoAddress.tblCommMethod.colnCommId IN); END;\r\n");
                        if (sExist == "TRUE")
                        {
                            sDefMethList[0] = this.tblCommMethod.colnCommId.Text;
                            if (Ifs.Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.TEXT_CannotChangeValidFromDateAp, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Warning, Ifs.Fnd.ApplicationForms.Const.WARNING_YesNo, sDefMethList) == Sys.IDNO)
                            {
                                this.tblCommMethod.coldValidFrom.DateTime = this.tblCommMethod_coldValidFromOld.DateTime;
                                e.Return = Sys.VALIDATE_Cancel;
                            }
                        }
                        this.tblCommMethod_coldValidFromOld.DateTime = this.tblCommMethod.coldValidFrom.DateTime;
                    }
                }
            }
            return;
            #endregion
        }

        private void tblCommMethod_coldValidTo_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.coldValidTo_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        private void coldValidTo_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Local Variables
            SalArray<SalString> sDefMethList = new SalArray<SalString>(1);
            #endregion

            #region Actions
            e.Handled = true;
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
            sDefMethList[0] = Ifs.Fnd.ApplicationForms.Const.strNULL;

            if (Sys.wParam == 1 && this.tblCommMethod.coldValidTo.DateTime != this.tblCommMethod_coldValidToOld.DateTime)
            {
                if (Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Comm_Method_API.Comm_Id_Exist"))
                {
                    using (new SalContext(this))
                    {
                        DbPLSQLBlock(cSessionManager.c_hSql, " BEGIN :i_hWndFrame.frmSupplierInfoAddress.sExist := &AO.Comm_Method_API.Comm_Id_Exist(\r\n" +
                                                             "		 :i_hWndFrame.frmSupplierInfoAddress.tblCommMethod.colsIdentity,\r\n" +
                                                             "		 :i_hWndFrame.frmSupplierInfoAddress.tblCommMethod.colsPartyType,\r\n" +
                                                             "		 :i_hWndFrame.frmSupplierInfoAddress.tblCommMethod.colnCommId); END;\r\n");
                        if (sExist == "TRUE")
                        {
                            sDefMethList[0] = this.tblCommMethod.colnCommId.Text;
                            if (Ifs.Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.TEXT_CannotChangeValidToDateAp, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Warning, Ifs.Fnd.ApplicationForms.Const.WARNING_YesNo, sDefMethList) == Sys.IDNO)
                            {
                                this.tblCommMethod.coldValidTo.DateTime = this.tblCommMethod_coldValidToOld.DateTime;
                                e.Return = Sys.VALIDATE_Cancel;
                            }
                        }
                        this.tblCommMethod_coldValidToOld.DateTime = this.tblCommMethod.coldValidTo.DateTime;
                    }
                }
            }
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

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalNumber vrtUserMethod(SalNumber nWhat, SalString sMethod)
        {
            return this.UserMethod(nWhat, sMethod);
        }
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override SalNumber vrtFrameActivate()
        {
            #region Local Variables
            SalString lsStmt = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                sSourceName = Ifs.Fnd.ApplicationForms.Var.DataTransfer.SourceNameGet();
                
                if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.RecCountGet() > 0)
                {
                    Sal.WaitCursor(true);
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("ADDRESS_ID", sAddressId);
                    if (sAddressId[0].Value != Sys.STRING_Null)
                    {
                        lsStmt = " ADDRESS_ID = :i_hWndFrame.frmSupplierInfoAddress.sAddressId[0]";
                        Sal.SendMsg(i_hWndFrame, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceUserWhere, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, lsStmt.ToHandle());
                    }
                    InitFromTransferredData();
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
                    Sal.WaitCursor(false);
                    return false;
                }                
                return base.FrameActivate();
            }

            #endregion
        }

        public override SalBoolean vrtTabActivateStart(SalWindowHandle hWnd, SalNumber nTab)
        {
            return this.TabActivateStart(hWnd, nTab);
        }
        #endregion

        #region ChildTable - tblAddressType

            #region Window Variables
            public SalArray<SalString> tblAddressType_sSupplierId = new SalArray<SalString>();
            public SalArray<SalString> tblAddressType_sAddressIdTemp = new SalArray<SalString>();
            public SalArray<SalString> tblAddressType_sAddressTypeCode = new SalArray<SalString>();
            public SalArray<SalString> tblAddressType_sTempAddressValidation = new SalArray<SalString>();
            public SalArray<SalDateTime> tblAddressType_dTempFromDate = new SalArray<SalDateTime>();
            public SalArray<SalDateTime> tblAddressType_dTempToDate = new SalArray<SalDateTime>();
            public SalArray<SalString> tblAddressType_sAddressId = new SalArray<SalString>();
            public SalArray<SalString> tblAddressType_sAddressTypeCodeArr = new SalArray<SalString>();
            public SalArray<SalString> tblAddressType_sDefAddress = new SalArray<SalString>();
            public SalArray<SalString> tblAddressType_sObjId = new SalArray<SalString>();
            public SalArray<SalString> tblAddressType_sValidFlag = new SalArray<SalString>();
            public SalString tblAddressType_sTempSupplierId = "";
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
                    tblAddressType_sTempSupplierId = SalString.Null;
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
                                lsStmt = lsStmt + "&AO.SUPPLIER_INFO_ADDRESS_TYPE_API.Check_Def_Address_Exist (\r\n" +
                                                                                                               ":i_hWndFrame.frmSupplierInfoAddress.tblAddressType_sTempAddressValidation[" + nIndex.ToString(0) + "] OUT,\r\n" +
                                                                                                               ":i_hWndFrame.frmSupplierInfoAddress.tblAddressType_sValidFlag[" + nIndex.ToString(0) + "] OUT ,\r\n" +
                                                                                                               ":i_hWndFrame.frmSupplierInfoAddress.tblAddressType_sTempSupplierId IN ,\r\n" +
                                                                                                               ":i_hWndFrame.frmSupplierInfoAddress.tblAddressType_sDefAddress[" + nIndex.ToString(0) + "] IN ,\r\n" +
                                                                                                               ":i_hWndFrame.frmSupplierInfoAddress.tblAddressType_sAddressTypeCodeArr[" + nIndex.ToString(0) + "] IN ,\r\n" +
                                                                                                               ":i_hWndFrame.frmSupplierInfoAddress.tblAddressType_sObjId[" + nIndex.ToString(0) + "] IN ,\r\n" +
                                                                                                               ":i_hWndFrame.frmSupplierInfoAddress.tblAddressType_dTempFromDate[" + ((SalNumber)0).ToString(0) + "] IN ,\r\n" +
                                                                                                               ":i_hWndFrame.frmSupplierInfoAddress.tblAddressType_dTempToDate[" + ((SalNumber)0).ToString(0) + "]  IN);";
                                tblAddressType_sAddressId[nIndex] = this.tblAddressType_colsAddressId.Text;
                                tblAddressType_sAddressTypeCodeArr[nIndex] = this.tblAddressType_colsAddressTypeCode.Text;
                                tblAddressType_sDefAddress[nIndex] = this.tblAddressType_colDefAddress.Text;
                                tblAddressType_sObjId[nIndex] = this.tblAddressType.__colObjid.Text;
                                tblAddressType_sTempSupplierId = this.tblAddressType_colsSupplierId.Text;
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
                    sAddressTypeCodeMsg[1] = Sal.ListQueryTextX(this.cmbPartyType, 0);
                    sAddressTypeCodeMsg[2] = this.tblAddressType_colsSupplierId.Text;
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
                        sMessage[2] = this.tblAddressType_colsSupplierId.Text;
                        if (Ifs.Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.TEXT_LastAddressType, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Question, (Ifs.Fnd.ApplicationForms.Const.QUESTION_YesNo | Sys.MB_DefButton2), sMessage) == Sys.IDNO)
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
                    tblAddressType_sTempSupplierId = SalString.Null;
                    sFlag.SetUpperBound(1, -1);
                    tblAddressType_sTempAddressValidation.SetUpperBound(1, -1);
                    tblAddressType_sValidFlag.SetUpperBound(1, -1);
                    tblAddressType_sDefAddress.SetUpperBound(1, -1);
                    tblAddressType_sAddressTypeCodeArr.SetUpperBound(1, -1);
                    tblAddressType_sObjId.SetUpperBound(1, -1);
                    sAddressIdMsg.SetUpperBound(1, -1);
                    sAddressTypeCodeMsg.SetUpperBound(1, -1);
                    while (true)
                    {
                        if (Sal.TblFindNextRow(tblAddressType, ref nCurrentRow, 0, 0))
                        {
                            Sal.TblSetContext(tblAddressType, nCurrentRow);
                            lsStmt = lsStmt + "&AO.SUPPLIER_INFO_ADDRESS_TYPE_API.Check_Def_Address_Exist (\r\n" +
                                                                                                          ":i_hWndFrame.frmSupplierInfoAddress.tblAddressType_sTempAddressValidation[" + nIndex.ToString(0) + "] OUT,\r\n" +
                                                                                                          ":i_hWndFrame.frmSupplierInfoAddress.tblAddressType_sValidFlag[" + nIndex.ToString(0) + "] OUT,\r\n" +
                                                                                                          ":i_hWndFrame.frmSupplierInfoAddress.tblAddressType_sTempSupplierId IN ,\r\n" +
                                                                                                          ":i_hWndFrame.frmSupplierInfoAddress.tblAddressType_sDefAddress[" + nIndex.ToString(0) + "] IN ,\r\n" +
                                                                                                          ":i_hWndFrame.frmSupplierInfoAddress.tblAddressType_sAddressTypeCodeArr[" + nIndex.ToString(0) + "] IN ,\r\n" +
                                                                                                          ":i_hWndFrame.frmSupplierInfoAddress.tblAddressType_sObjId[" + nIndex.ToString(0) + "] IN ,\r\n" +
                                                                                                          ":i_hWndFrame.frmSupplierInfoAddress.tblAddressType_dTempFromDate[" + nIndex.ToString(0) + "] IN ,\r\n" +
                                                                                                          ":i_hWndFrame.frmSupplierInfoAddress.tblAddressType_dTempToDate[" + nIndex.ToString(0) + "] IN );";
                            tblAddressType_sAddressId[nIndex] = this.tblAddressType_colsAddressId.Text;
                            tblAddressType_sAddressTypeCodeArr[nIndex] = this.tblAddressType_colsAddressTypeCode.Text;
                            tblAddressType_sDefAddress[nIndex] = this.tblAddressType_colDefAddress.Text;
                            tblAddressType_sObjId[nIndex] = this.tblAddressType.__colObjid.Text;
                            tblAddressType_sTempSupplierId = this.tblAddressType_colsSupplierId.Text;
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
                    sAddressTypeCodeMsg[1] = Sal.ListQueryTextX(this.cmbPartyType, 0);
                    sAddressTypeCodeMsg[2] = this.tblAddressType_colsSupplierId.Text;
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
                    return bTempValue;
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
                    tblAddressType_sTempSupplierId = SalString.Null;
                    nCount = tblAddressType_sTempAddressValidation.GetUpperBound(1);
                    lsStmt = SalString.Null;
                    while (nIndex <= nCount)
                    {
                        if (tblAddressType_sTempAddressValidation[nIndex] == "FALSE")
                        {
                            lsStmt = lsStmt + "&AO.SUPPLIER_INFO_ADDRESS_TYPE_API.Check_Def_Addr_Temp ( :i_hWndFrame.frmSupplierInfoAddress.tblAddressType_sTempSupplierId IN ,\r\n" +
                                                                                                       ":i_hWndFrame.frmSupplierInfoAddress.tblAddressType_sAddressTypeCodeArr[" + nIndex.ToString(0) + "] IN ,\r\n" +
                                                                                                       ":i_hWndFrame.frmSupplierInfoAddress.tblAddressType_sDefAddress[" + nIndex.ToString(0) + "] IN ,\r\n" +
                                                                                                       ":i_hWndFrame.frmSupplierInfoAddress.tblAddressType_sObjId[" + nIndex.ToString(0) + "] IN ,\r\n" +
                                                                                                       ":i_hWndFrame.frmSupplierInfoAddress.tblAddressType_dTempFromDate[" + nIndex.ToString(0) + "] IN ,\r\n" +
                                                                                                       ":i_hWndFrame.frmSupplierInfoAddress.tblAddressType_dTempToDate[" + nIndex.ToString(0) + "] IN ); ";
                            tblAddressType_dTempFromDate[nIndex] = this.dfdValidFrom.DateTime;
                            tblAddressType_dTempToDate[nIndex] = this.dfdValidTo.DateTime;
                            tblAddressType_sTempSupplierId = this.tblAddressType_colsSupplierId.Text;
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
                        sItemNames[2] = "SUPPLIER_ID";
                        hWndItems[2] = tblAddressType_colsSupplierId;
                    }
                    else
                    {
                        return ((cDataSource)this.tblAddressType).DataSourcePrepareKeyTransfer(sWindowName);
                    }
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("SupplierInfoAddressType", Sys.hWndForm, sItemNames, hWndItems);
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
                        this.tblAddressType_colsAddressTypeCode.TypeCodeLookupInit("SUPPLIER");
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
                    tblCommMethod.colsPartyTypeDb.Text = "SUPPLIER";
                    tblCommMethod.colsIdentity.Text = SalString.FromHandle(this.dfsSupplierId.EditDataItemValueGet());
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
                    tblCommMethod.colsPartyTypeDb.Text = "SUPPLIER";
                    tblCommMethod.colsIdentity.Text = SalString.FromHandle(this.dfsSupplierId.EditDataItemValueGet());
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

        #region ChildTable - tblSupplierInfoContact

            #region Window Variables
            public SalString tblSupplierInfoContact_sTempSupplierId = "";
            public SalString tblSupplierInfoContact_sTempAddressId = "";
            #endregion

            #region Methods

            /// <summary>
            /// Late bound function in cDataSource
            /// </summary>
            /// <param name="hSql"></param>
            /// <returns></returns>
            public virtual SalBoolean tblSupplierInfoContact_DataRecordExecuteNew(SalSqlHandle hSql)
            {
                #region Actions
                using (new SalContext(this))
                {
                    tblSupplierInfoContact_colsSupplierAddress.Text = SalString.FromHandle(this.cmbAddressId.EditDataItemValueGet());
                    tblSupplierInfoContact_colsSupplierAddress.EditDataItemSetEdited();
                    return ((cTableManager)this.tblSupplierInfoContact).DataRecordExecuteNew(hSql);
                }
                #endregion
            }

            public virtual SalNumber tblSupplierInfoContact_CheckDefault(SalString sSupplierId, SalString sAddressId)
            {
                #region Local Variables
                IDictionary<string, string> namedBindVariables = new Dictionary<string, string>();
                #endregion

                #region Actions
                tblSupplierInfoContact_sTempSupplierId = sSupplierId;
                tblSupplierInfoContact_sTempAddressId = sAddressId;

                namedBindVariables.Add("TempSupplierId", this.QualifiedVarBindName("tblSupplierInfoContact_sTempSupplierId"));
                namedBindVariables.Add("TempAddressId", this.QualifiedVarBindName("tblSupplierInfoContact_sTempAddressId"));

                if (!(DbPLSQLBlock("&AO.Supplier_Info_Contact_API.Check_Default_Values ( {TempSupplierId} IN , {TempAddressId} IN );", namedBindVariables)))
                {
                    return false;
                }
                return true;
                #endregion
            }

            public virtual void tblSupplierInfoContact_HandleSrmColumns()
            {
                if ((!(Ifs.Application.Enterp.Int.IsSrmInstalled)) || (!(Ifs.Fnd.ApplicationForms.Var.Component.IsWindowAvailable(Pal.GetActiveInstanceName("frmSupplierInfoContact")))) || (!(Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("frmSupplierInfoContact")))))
                {
                    tblSupplierInfoContact_colsDepartment.Visible = false;
                    tblSupplierInfoContact_colsMainRepresentativeId.Visible = false;
                    tblSupplierInfoContact_colsMainRepresentativeName.Visible = false;
                }
            }

            #endregion

            #region Event Handlers

            private void tblSupplierInfoContact_DataRecordExecuteNewEvent(object sender, cDataSource.DataRecordExecuteNewEventArgs e)
            {
                e.Handled = true;
                e.ReturnValue = tblSupplierInfoContact_DataRecordExecuteNew(e.hSql);
            }

            #endregion
            #region colsPersonId Actions

            /// <summary>
            /// Window Actions for colsPersonId
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void colsPersonId_WindowActions(object sender, WindowActionsEventArgs e)
            {
                #region Actions
                switch (e.ActionType)
                {
                    case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                        this.colsPersonId_OnPM_DataItemValidate(sender, e);
                        break;

                    case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovUserWhere:
                        this.tblSupplierInfoContact_colsPersonId_OnPM_DataItemLovUserWhere(sender, e);
                        break;

                    case Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom:
                        this.tblSupplierInfoContact_colsPersonId_OnPM_DataItemZoom(sender, e);
                        break;
                }
                #endregion
            }

            /// <summary>
            /// PM_ event handler.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void colsPersonId_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
            {
                #region Local Variables
                IDictionary<string, string> namedBindVariables = new Dictionary<string, string>();
                #endregion

                #region Actions
                e.Handled = true;
                namedBindVariables.Add("Phone", tblSupplierInfoContact_colPersonInfoAddressPhone.QualifiedBindName);
                namedBindVariables.Add("Mobile", tblSupplierInfoContact_colPersonInfoAddressMobile.QualifiedBindName);
                namedBindVariables.Add("E_Mail", tblSupplierInfoContact_colPersonInfoAddressE_Mail.QualifiedBindName);
                namedBindVariables.Add("Fax", tblSupplierInfoContact_colPersonInfoAddressFax.QualifiedBindName);
                namedBindVariables.Add("Pager", tblSupplierInfoContact_colPersonInfoAddressPager.QualifiedBindName);
                namedBindVariables.Add("Intercom", tblSupplierInfoContact_colPersonInfoAddressIntercom.QualifiedBindName);
                namedBindVariables.Add("Www", tblSupplierInfoContact_colPersonInfoAddressWww.QualifiedBindName);
                namedBindVariables.Add("PersonId", tblSupplierInfoContact_colsPersonId.QualifiedBindName);
                namedBindVariables.Add("ContactAddress", tblSupplierInfoContact_colsContactAddress.QualifiedBindName);

                if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam))
                {
                    if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                    {
                        DbPLSQLBlock("&AO.Person_Info_Address_API.Get_Default_Contact_Info({Phone} OUT,{Mobile} OUT,{E_Mail} OUT,{Fax} OUT,{Pager} OUT,{Intercom} OUT , {Www} OUT, {PersonId} IN ,{ContactAddress} IN);", namedBindVariables);
                    }
                }
                e.Return = true;
                return;
                #endregion
            }

            private void tblSupplierInfoContact_colsPersonId_OnPM_DataItemLovUserWhere(object sender, WindowActionsEventArgs e)
            {
                #region Actions
                e.Handled = true;
                e.Return = ((SalString)"SUPPLIER_CONTACT_DB ='TRUE' AND BLOCKED_FOR_USE_SUPPLIER_DB ='FALSE'").ToHandle();
                return;
                #endregion
            }

            private void tblSupplierInfoContact_colsPersonId_OnPM_DataItemZoom(object sender, WindowActionsEventArgs e)
            {
                #region Local Variables
                SalArray<SalString> sItemNames = new SalArray<SalString>();
                SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
                #endregion

                #region Actions
                e.Handled = true;  
                if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                {
                    sItemNames[0] = "PERSON_ID";
                    hWndItems[0] = tblSupplierInfoContact_colsPersonId;
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("PERSON_ID", tblSupplierInfoContact, sItemNames, hWndItems);
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.TypeSet("ZOOM");
                    SessionNavigate(Pal.GetActiveInstanceName("frmPersonInfo"));
                    e.Return = true;
                    return;
                }
                else if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)
                {
                    e.Return = tblSupplierInfoContact.CanDataTransferTo(Pal.GetActiveInstanceName("frmPersonInfo"));
                    return;
                }
                else
                {
                    e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom, Sys.wParam, Sys.lParam);
                    return;
                }
                #endregion
            }
            #endregion

        #endregion

        #region Event Handlers

        private void menuItem__Tax_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            // TODO: Rewrite command event handler not to use UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            ((FndCommand)sender).Enabled = Sal.SendMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, ((SalString)"TaxCodeInfo").ToHandle());
        }

        private void menuItem__Tax_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            // TODO: Rewrite command event handler not to make use of UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            Ifs.Fnd.ApplicationForms.Int.PostMessage(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, "TaxCodeInfo");
        }

        #endregion

    }
}
