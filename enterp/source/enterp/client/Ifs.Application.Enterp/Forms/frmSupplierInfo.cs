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
// 101015   Kanslk  Bug 93517, Modified vrtActivate
// 120419   Chgulk  EASTRTM-6962, Merged LCS patch 101624.
// 131114   Pratlk  PBFI-2546, Refactor client windows in component ENTERP
// 140401   Machlk  PBFI-5564 Merged Bug 115353
// 140401   Kagalk  PBFI-4142, Merged Bug 113712, Modified to give a warning when deleting the last address type.
// 140409   Ajpelk  PBFI-4140, Merged Bug 112894, Modified TabActivateFinish()
// 140704   Hawalk  Bug 116673, Changed view of tblOurId from SUPPLIER_INFO_OUR_ID to SUPPLIER_INFO_OUR_ID_FIN_AUTH (user-company authorization rests in
// 140704           ACCRUL, that cannot be directly referenced in the server - hence a new view).
// 140728   Kagalk  PRFI-1290, Merged Bug 117813, Enable to validate association no when using object copy/paste.
// 140818   Kagalk  Bug 118344, Add response to event PAM_RecordNotInitiallySaved.
// 150603   RoJalk  ORA-499, Changed the main WindowRegistration entry to the view SUPPLIER_INFO_GENERAL.
// 150609   RoJalk  ORA-496, Added GetIIDValues, EnableTabsOnCategory to enable/disable tabs based on supplier category.
// 150610   Waudlk  Bug 121697, Registered SUP_INVOICE_ADDRESS_TAX_PUB for zooming.
// 150611   clstlk  Bug 122600, Modified CountryChanged ().
// 150610   RoJalk  ORA-501, Moved the method Validate_One_Time_Supplier__ from Supplier_Info_API to Supplier_Info_General_API
// 150609   SudJlk  ORA-570, Added window action picTab_OnSAM_Create to dynamically load frmSupplierInfoContact when SRM is installed.
// 150612   SudJlk  ORA-571, Modified frmSupplierInfo_OnPM_DataSourceSave to refresh Contact record if Contact tab is in focus when SRM is installed
// 150707   RoJalk  ORA-775, Added the RMB to Change Supplier Category. 
// 150811   RoJalk  ORA-1180, Added the method DummyProcedureCalls. 
// 160516   MAAYLK  STRFI-1726 (Bug 128550), Modified picTab_OnSAM_Create() by removing Pal.GetActiveInstanceName() when calling picTab.TabSetup.Replace().
// 170506   Nirylk  STRFI-6107, Merged LCS Bug 135654.
// 170915   Gawilk  STRFI-9940, Merged Bug 137754. Set correct LU when retrieving History Log.
#endregion

using System.Windows.Forms;
using Ifs.Fnd.ApplicationForms;
using Ifs.Fnd.Windows.Forms;
using PPJ.Runtime;
using PPJ.Runtime.Sql;
using PPJ.Runtime.Windows;
using PPJ.Runtime.Vis;
using System.Collections.Generic;

namespace Ifs.Application.Enterp
{

    /// <summary>
    /// </summary>
    [FndWindowRegistration("SUPPLIER_INFO_GENERAL", "SupplierInfoGeneral", FndWindowRegistrationFlags.HomePage)]
    [FndWindowRegistration("SUPPLIER_INFO,IDENTITY_PAY_INFO_SUPP,MULTI_SUP_DETAILS_QRY", "SupplierInfo", FndWindowRegistrationFlags.HomePage | FndWindowRegistrationFlags.NoSecurity)]
    [FndWindowRegistration("SUPPLIER_INFO", "SupplierInfo")]
    [FndWindowRegistration("EXTERNAL_SUPPLIER_LOV", "SupplierInfo", FndWindowRegistrationFlags.HomePage | FndWindowRegistrationFlags.NoSecurity)]
    [FndWindowRegistration("VALID_SUPPLIER_LOV", "Supplier", FndWindowRegistrationFlags.HomePage | FndWindowRegistrationFlags.NoSecurity)]
    [FndWindowRegistration("SUPPLIER", "Supplier", FndWindowRegistrationFlags.HomePage | FndWindowRegistrationFlags.NoSecurity)]
    [FndWindowRegistration("IDENTITY_INVOICE_INFO_SUPP", "", FndWindowRegistrationFlags.HomePage | FndWindowRegistrationFlags.NoSecurity)]
    [FndWindowRegistration("SUP_INVOICE_ADDRESS_TAX_PUB", "SupplierInfo", FndWindowRegistrationFlags.HomePage | FndWindowRegistrationFlags.NoSecurity)]
    public partial class frmSupplierInfo : cMasterDetailTabFormWindow
    {
        #region Window Variables
        public SalArray<SalString> sItems = new SalArray<SalString>();
        public SalNumber nIndex = 0;
        public SalString sFullFormName = "";
        public SalString sCountryCode = "";
        public SalBoolean bNewItem = false;
        public SalBoolean bTabOk = false;
        public SalBoolean bTabName4 = false;
        public SalBoolean bTabName2 = false;
        public SalBoolean bTabName1 = false;
        public SalBoolean bOk = false;
        public SalWindowHandle hWndtabhandle = SalWindowHandle.Null;
        public SalBoolean bAssociationNoEdited = false;
        public SalString sCommMethodTabActive = "";
        public SalString sAddressTabActive = "";
        public SalString sLastChosenCountry = "";
        public SalString sCountryDb = "";
        public SalString sContactTabActive = "";
        public SalBoolean bOneTime = false;
        public SalString sPaymentTabActive = "";
        public SalString sPurchTabActive = "";
        public SalNumber nActiveTab = 0;
        public SalArray<SalString> sSupplier = new SalArray<SalString>();
        public SalString sProspect = "";
        public SalString sCorporateFormExist = "";
        public SalString sCorporateFormDesc = "";
        public SalString sDataSubjectKeyRef = "";
        public SalString sDataSubjectEnable = "FALSE";
        public static SalString sDataSubjectDb = "SUPPLIER";
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public frmSupplierInfo()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();
        }
        #endregion

        #region System Methods/Properties

        /// <summary>
        /// Returns the object instance associated with the window handle.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public new static frmSupplierInfo FromHandle(SalWindowHandle handle)
        {
            return ((frmSupplierInfo)SalWindow.FromHandle(handle, typeof(frmSupplierInfo)));
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
                if (sMethod == Pal.GetActiveInstanceName("dlgCopySupplier"))
                {
                    switch (nWhat)
                    {
                        case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                            if (bNewItem)
                            {
                                bNewItem = false;
                                return false;
                            }
                            if (DataSourceIsDirty(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire))
                            {
                                return false;
                            }
                            return Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("dlgCopySupplier"));

                        case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                            bOk = true;
                            if (cbOneTimeDb.IsChecked())
                            {
                                bOk = (Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_CopyOneTimeIdentity, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Question, (Ifs.Fnd.ApplicationForms.Const.QUESTION_YesNo | Sys.MB_DefButton2)) == Sys.IDYES);
                            }
                            if (bOk)
                            {
                                if (dlgCopySupplier.ModalDialog(this))
                                {
                                    if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.RecCountGet() > 0)
                                    {
                                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemNamesGet(sItems);
                                        nIndex = Vis.ArrayFindString(sItems, "SUPPLIER_ID");
                                        if (nIndex != -1)
                                        {
                                            Ifs.Fnd.ApplicationForms.Var.DataTransfer.i_sItemNames[nIndex] = "SUPPLIER_ID";
                                        }
                                        Sal.WaitCursor(true);
                                        InitFromTransferedData();
                                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
                                        
                                        Sal.PostMsg(i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceRefresh, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                                        Sal.WaitCursor(false);
                                        return false;
                                    }
                                }
                            }
                            return true;
                    }
                }
                else if (sMethod == "GetVendorNo")
                {
                    return cmbSupplierId.i_sMyValue.ToHandle();
                }
                // changed 4 Supplier360
                else if (sMethod == "GetIdentity")
                {
                    switch (nWhat)
                    {
                        case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                            return false;

                        case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                            return cmbSupplierId.i_sMyValue.ToHandle();
                    }
                }
                else
                {
                    return false;
                }
            }

            return 0;
            #endregion
        }

        public virtual new SalBoolean InitFromTransferredData()
        {
            #region Local Variables
            SalArray<SalString> sSqlColumn = new SalArray<SalString>();
            SalString lsWhereStmt = "";
            SalNumber nRows = 0;
            SalNumber nColumns = 0;
            SalString sDelim = "";
            SalString sSupplierId = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                nColumns = Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemNamesGet(sSqlColumn);
                nRows = Ifs.Fnd.ApplicationForms.Var.DataTransfer.RecCountGet();
                if ((nRows == 1) && (nColumns == 2) && (Vis.ArrayFindString(sSqlColumn, "ADDRESS_ID") >= 0 ||
                                                        Vis.ArrayFindString(sSqlColumn, "DELIVERY_ADDRESS_ID") >= 0 ||
                                                        Vis.ArrayFindString(sSqlColumn, "INVOICE_ADDRESS_ID") >= 0))
                {
                    if (Vis.ArrayFindString(sSqlColumn, "SUPPLIER_ID") >= 0)
                    {
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemValueStrGet(Vis.ArrayFindString(sSqlColumn, "SUPPLIER_ID"), 0, ref sSupplierId);
                    }

                    sDelim = "";
                    lsWhereStmt = "SUPPLIER_ID = ";
                    lsWhereStmt = lsWhereStmt + sDelim + "'" + sSupplierId + "'";
                    Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceUserWhere, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, lsWhereStmt.ToHandle());
                    Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                    picTab.BringToTop(picTab.FindName("Name1"), true);
                    return true;
                }
                return ((cMasterDetailTabFormWindow)this).InitFromTransferredData();
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public new SalBoolean FrameStartupUser()
        {
            #region Local Variables
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                Sal.SetWindowText(i_hWndFrame, Properties.Resources.HEAD_DetailSupplierInfo);
                return true;
            }

            return false;
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
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("Association_Info_API.Association_No_Exist", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                    DbPLSQLBlock(cSessionManager.c_hSql, sFullFormName + ".dfsExist :=\r\n" +
                        "                                 &AO.Association_Info_API.Association_No_Exist( " + sFullFormName + ".dfsAssociationNo, 'SUPPLIER' )");
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
        /// <param name="sWindowName"></param>
        /// <returns></returns>
        public new SalNumber DataSourcePrepareKeyTransfer(SalString sWindowName)
        {
            #region Local Variables
            SalString sSourceName = "";
            SalArray<SalString> sItemNames = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                if (sWindowName == Pal.GetActiveInstanceName("tbwCorporateForms"))
                {
                    sSourceName = p_sLogicalUnit;
                    sItemNames[0] = "COUNTRY_CODE";
                    hWndItems[0] = dfsCountryDb;
                }
                else if (sWindowName == Pal.GetActiveInstanceName("frmHistoryLog"))
                {
                    sSourceName = "SupplierInfo";
                    sItemNames[0] = "SUPPLIER_ID";
                    hWndItems[0] = cmbSupplierId;
                }
                else
                {
                    return ((cDataSource)this).DataSourcePrepareKeyTransfer(sWindowName);
                }
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init(sSourceName, this, sItemNames, hWndItems);
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.TypeSet("CREATE_WINDOW");
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber GetLovValues()
        {
            #region Actions
            using (new SalContext(this))
            {
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("Iso_Country_API.Encode", System.Data.ParameterDirection.Input);
                    DbPLSQLBlock(cSessionManager.c_hSql, sFullFormName + ".sCountryCode :=\r\n" +
                        "                                 &AO.Iso_Country_API.Encode( " + sFullFormName + ".cmbCountry.i_sMyValue)");
                }
                dfsCountryDb.Text = sCountryCode;
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public new SalBoolean DataSourceSaveCheckOk()
        {
            #region Local Variables
            SalWindowHandle hWndAddress = SalWindowHandle.Null;
            SalWindowHandle hWndComMethod = SalWindowHandle.Null;
            SalWindowHandle hWndContact = SalWindowHandle.Null;
            SalBoolean bOk = true;
            SalBoolean bIsOneTimeChecked = false;
             SalBoolean errorMsg = false;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                hWndAddress = TabAttachedWindowHandleGet(picTab.FindName("Name1"));
                hWndComMethod = TabAttachedWindowHandleGet(picTab.FindName("Name2"));
                hWndContact = TabAttachedWindowHandleGet(picTab.FindName("Name4"));
                if (sAddressTabActive == "TRUE")
                {
                    if (Sal.SendMsg(frmSupplierInfoAddress.FromHandle(hWndAddress).tblCommMethod, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceIsDirty, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam))
                    {
                        if (!(frmSupplierInfoAddress.FromHandle(hWndAddress).tblCommMethod.CheckDefault()))
                        {
                            return false;
                        }
                    }
                    if (Sal.SendMsg(frmSupplierInfoAddress.FromHandle(hWndAddress).tblSupplierInfoContact, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceIsDirty, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam))
                    {
                        if (!(frmSupplierInfoAddress.FromHandle(hWndAddress).tblSupplierInfoContact_CheckDefault(cmbSupplierId.i_sMyValue, frmSupplierInfoAddress.FromHandle(hWndAddress).cmbAddressId.i_sMyValue)))
                        {
                            return false;
                        }
                    }
                }

                if (sContactTabActive == "TRUE")
                {
                    if (Ifs.Fnd.ApplicationForms.Var.Component.IsWindowAvailable(Pal.GetActiveInstanceName("frmSupplierInfoContact")) && Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("frmSupplierInfoContact")))
                    {
                        using (new SalContext(this))
                        {
                            SalNumber nTab = picTab.FindName("Name4");
                            if (nTab == picTab.GetTop())
                            {
                                this.hWndtabhandle = this.TabAttachedWindowHandleGet(this.picTab.FindName("Name4"));
                                if (this.hWndtabhandle != null)
                                {
                                    errorMsg = Sal.SendMsg(this.hWndtabhandle, Ifs.Application.Enterp.Const.PAM_ValidateValue, 0, 0);
                                }

                                return errorMsg;
                            }

                        }
                    }
                }


                if (((cDataSource)this).DataSourceSaveCheckOk())
                {
                    bOk = true;
                    bIsOneTimeChecked = cbOneTimeDb.IsChecked();
                    if (bOneTime != bIsOneTimeChecked)
                    {
                        bOk = DbPLSQLBlock(cSessionManager.c_hSql, "Supplier_Info_API.Validate_One_Time_Supplier__(:i_hWndFrame.frmSupplierInfo.cmbSupplierId.i_sMyValue)");
                    }
                    if (bOk)
                    {
                        bOneTime = bIsOneTimeChecked;
                    }
                    return bOk;
                }
                return false;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="nTab"></param>
        /// <returns></returns>
        public new SalNumber TabActivateStart(SalWindowHandle hWnd, SalNumber nTab)
        {
            #region Local Variables
            SalString sName = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                nActiveTab = nTab;
                picTab.GetName(nTab, ref sName);
                if (sName == "Name1")
                {
                    sAddressTabActive = "TRUE";
                }
                else if (sName == "Name2")
                {
                    sCommMethodTabActive = "TRUE";
                }
                else if (sName == "Name4")
                {
                    sContactTabActive = "TRUE";
                }

                else if (sName == "DOMAIN-frmCustOrSupPayLed")
                {
                    sPaymentTabActive = "TRUE";
                }
                else if (sName == Pal.GetActiveInstanceName("frmSupplier"))
                {
                    sPurchTabActive = "TRUE";
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="nTab"></param>
        /// <returns></returns>
        public new SalNumber TabActivateFinish(SalWindowHandle hWnd, SalNumber nTab)
        {
            #region Local Variables
            SalWindowHandle hWndAddress = SalWindowHandle.Null;
            SalWindowHandle hWndInfoCommMethod = SalWindowHandle.Null;
            SalNumber retVal = 0;
            SalString sTabName = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                retVal = base.TabActivateFinish(hWnd, nTab);
                picTab.GetName(nTab, ref sTabName);
                if (sTabName == "Name1")
                {
                    hWndAddress = TabAttachedWindowHandleGet(picTab.FindName("Name1"));
                    frmSupplierInfoAddress.FromHandle(hWndAddress).RefreshTabs();
                }
                else
                {
                    if (sTabName == "Name2")
                    {
                        hWndInfoCommMethod = TabAttachedWindowHandleGet(picTab.FindName("Name2"));
                        Sal.SetFocus(frmSupplierInfoCommMethod.FromHandle(hWndInfoCommMethod).tblCommMethod);
                    }
                }
                HandleDataSubjectConsentColumns(SalBoolean.False);
            }

            return retVal;

            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber CountryChanged()
        {
            #region Local Variables
            SalArray<SalString> sParam = new SalArray<SalString>(2);
            #endregion

            #region Actions
            using (new SalContext(this))
            {               
                GetLovValues();
                DbPLSQLBlock(cSessionManager.c_hSql, @" DECLARE
                                                           CorporateFormExist_  VARCHAR2(10);
                                                        BEGIN 
                                                           CorporateFormExist_ := &AO.Corporate_Form_API.Validate_Corporate_Form(
                                                                                                                              :i_hWndSelf.frmSupplierInfo.sCountryCode IN,
                                                                                                                              :i_hWndSelf.frmSupplierInfo.dfsCorporateForm IN);
                                                           :i_hWndSelf.frmSupplierInfo.sCorporateFormExist := CorporateFormExist_ ;
                                                           IF (CorporateFormExist_ = 'TRUE') THEN
                                                              :i_hWndSelf.frmSupplierInfo.sCorporateFormDesc:= &AO.Corporate_Form_API.Get_Corporate_Form_Desc(  
                                                                                                                              :i_hWndSelf.frmSupplierInfo.sCountryCode IN,
                                                                                                                              :i_hWndSelf.frmSupplierInfo.dfsCorporateForm IN);                                                              
                                                           END IF;                                                      
                                                        END; ");
                if (dfsCorporateForm.Text != Sys.STRING_Null && sCorporateFormExist == "FALSE")
                {
                    sParam[0] = dfsCorporateForm.Text;
                    sParam[1] = sCountryCode;
                    Ifs.Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.TEXT_FormOfBusiness, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Warning, Ifs.Fnd.ApplicationForms.Const.WARNING_Ok, sParam);
                    dfsCorporateForm.Text = Sys.STRING_Null;
                    dfsCorporateFormDesc.Text = Sys.STRING_Null;
                    dfsCorporateForm.EditDataItemSetEdited();
                }
                else if (sCorporateFormExist == "TRUE" || sCorporateFormExist == Sys.STRING_Null)
                {
                    dfsCorporateFormDesc.Text = sCorporateFormDesc;
                }
                sLastChosenCountry = cmbCountry.i_sMyValue;
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// The DataSourceSaveCheck function performs server validation of the complete
        /// master-detail chain of data sources.
        /// COMMENTS:
        /// DataSourceSaveCheck is called by the DataSourceSave function during the save
        /// process. To perform validation, DataSourceSaveCheck first calls DataSourceCheck
        /// to validate the current data source, and then calls DataSourceSaveCheck in all
        /// child data sources.
        /// </summary>
        /// <returns>The return value is TRUE if validation is successful, FALSE otherwise.</returns>
        public new SalBoolean DataSourceSaveCheck()
        {
            #region Local Variables
            SalWindowHandle hWndAddress = SalWindowHandle.Null;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                hWndAddress = TabAttachedWindowHandleGet(picTab.FindName("Name1"));
                if (sAddressTabActive == "TRUE")
                {
                    if (((bool)Sal.SendMsg(frmSupplierInfoAddress.FromHandle(hWndAddress).tblAddressType, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceIsDirty, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam)) || (Sal.QueryFieldEdit(frmSupplierInfoAddress.FromHandle(hWndAddress).dfdValidFrom) ||
                    Sal.QueryFieldEdit(frmSupplierInfoAddress.FromHandle(hWndAddress).dfdValidTo)))
                    {
                        if (!(frmSupplierInfoAddress.FromHandle(hWndAddress).tblAddressType_CheckDefaultAddress()))
                        {
                            return false;
                        }
                        if (!(frmSupplierInfoAddress.FromHandle(hWndAddress).tblAddressType_CheckLastAddressType()))
                        {
                            return false;
                        }
                    }
                }
                return ((cMasterDetailTabFormWindow)this).DataSourceSaveCheck();
            }
            #endregion
        }

        public virtual void RefreshTabs()
        {
            #region Local Variables
            SalNumber nTab = 0;
            #endregion

            #region Actions
            nTab = this.picTab.FindName("frmSupplier");
            if (this.cbOneTimeDb.IsChecked())
            {
                this.picTab.Enable(nTab, false);
                if (nActiveTab == nTab)
                    this.picTab.BringToTop(0, true);
            }
            else
            {
                this.picTab.Enable(nTab, true);
            }
            #endregion
        }

        public virtual SalBoolean IsOneTimeAllowed()
        {
            #region Local Variables
            SalArray<SalString> sParam = new SalArray<SalString>(2);
            SalBoolean bAllowed = true;
            #endregion

            #region Actions
            if (sAddressTabActive == "TRUE")
            {
                if (!(Sal.SendMsg(this.TabAttachedWindowHandleGet(this.picTab.FindName("Name1")), Ifs.Fnd.ApplicationForms.Const.PM_User, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ((SalString)"ValidateOneTime").ToHandle())))
                {
                    return false;
                }
            }
            if (sPaymentTabActive == "TRUE")
            {
                if (!(Sal.SendMsg(this.TabAttachedWindowHandleGet(this.picTab.FindName("DOMAIN-frmCustOrSupPayLed")), Ifs.Fnd.ApplicationForms.Const.PM_User, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ((SalString)"ValidateOneTime").ToHandle())))
                {
                    sParam[1] = Properties.Resources.TAB_NAME_Payment;
                    bAllowed = false;
                }
            }
            if (sPurchTabActive == "TRUE")
            {
                if ((Sal.SendMsg(this.TabAttachedWindowHandleGet(this.picTab.FindName("frmSupplier")), Ifs.Fnd.ApplicationForms.Const.PM_DataSourceIsDirty, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0)))
                {
                    sParam[1] = Properties.Resources.TAB_NAME_Purch;
                    bAllowed = false;
                }
            }
            if (!bAllowed)
            {
                sParam[0] = this.cmbSupplierId.Text;
                Ifs.Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.TEXT_InvalidOneTimeSupplier, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok, sParam);
                return false;
            }
            //hWndPayment = TabAttachedWindowHandleGet(nTab);
            //Sal.SendMsg(hWndPayment, Ifs.Fnd.ApplicationForms.Const.PM_User, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ((SalString)"OneTimeActivateTab").ToHandle());
            this.RefreshTabs();
            return true;
            #endregion
        }

        public virtual SalString GetGlobalCompany()
        {
            SalString sCompany = "";
            UserGlobalValueGet("COMPANY", ref sCompany);
            return sCompany;
        }

        public virtual SalNumber GetIIDValues()
        {
            #region Actions
            IDictionary<string, string> vars = new Dictionary<string, string>();
            vars.Add("Prospect", QualifiedVarBindName("sProspect"));
            DbPLSQLBlock(@"{Prospect} := &AO.Supplier_Info_Category_API.Decode('PROSPECT')", vars);
            return 0;
            #endregion
        }

        public virtual void EnableTabsOnCategory()
        {
            #region Actions
            using (new SalContext(this))
            {
                if (sProspect == SalString.Null)
                {
                    GetIIDValues();
                }

                if (cmbSupplierCategory.i_sMyValue == sProspect)
                {
                    // Enable/disable tabs depending on customer category settings
                    picTab.Enable(picTab.FindName("Name3"), false);
                    picTab.Enable(picTab.FindName("DOMAIN-frmPartyInvoiceInfo"), false);
                    picTab.Enable(picTab.FindName("DOMAIN-frmCustOrSupPayLed"), false);
                }
                else
                {
                    picTab.Enable(picTab.FindName("Name3"), true);
                    picTab.Enable(picTab.FindName("DOMAIN-frmPartyInvoiceInfo"), true);
                    picTab.Enable(picTab.FindName("DOMAIN-frmCustOrSupPayLed"), true);
                }
            }
            #endregion
        }

        protected virtual void DummyProcedureCalls()
        {
            //Added this dummy call to make the method granted by default when granting this form
            DbPLSQLBlock(@"&AO.SUPPLIER_INFO_API.Create_Supplier__();");
        }

        public virtual void HandleDataSubjectConsentColumns(SalBoolean bFromVrtActivate)        
        {
            #region Actions
            if (bFromVrtActivate)
            {
                DbPLSQLBlock(@"{0} := &AO.Data_Subject_API.Get_Personal_Data_Managemen_Db({1});", this.QualifiedVarBindName("sDataSubjectEnable"), this.QualifiedVarBindName("sDataSubjectDb"));
            }
            if (sDataSubjectEnable == "FALSE")
            {
                cbValidDataProcessingPurpose.Visible = false;
                cmdManageDataProcessingPurposes.Visible = false;
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
        private void frmSupplierInfo_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_Create:
                    this.frmSupplierInfo_OnSAM_Create(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate:
                    this.frmSupplierInfo_OnPM_DataSourcePopulate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew:
                    this.frmSupplierInfo_OnPM_DataRecordNew(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove:
                    this.frmSupplierInfo_OnPM_DataRecordRemove(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave:
                    this.frmSupplierInfo_OnPM_DataSourceSave(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PAM_User:
                    this.frmSupplierInfo_OnPAM_User(sender, e);
                    break;


                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate:
                    this.frmSupplierInfo_OnPM_DataRecordDuplicate(sender, e);
                    break;


                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordPaste:
                    this.frmSupplierInfo_OnPM_DataRecordPaste(sender, e);
                    break;

                case Const.PAM_RecordNotInitiallySaved:
                    e.Handled = true;
                    if (this.cmbSupplierId.EditDataItemStateGet() == Ifs.Fnd.ApplicationForms.Const.EDIT_Changed)
                    {
                        e.Return = true;
                    }
                    else
                    {
                        e.Return = false;
                    }
                    break;

            }
            #endregion
        }

        /// <summary>
        /// SAM_Create event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmSupplierInfo_OnSAM_Create(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam);
            this.sFullFormName = ":i_hWndFrame." + Ifs.Fnd.ApplicationForms.Int.QualifiedItemNameGet(this);
            #endregion
        }

        /// <summary>
        /// PM_DataSourcePopulate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmSupplierInfo_OnPM_DataSourcePopulate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Sys.wParam, Sys.lParam))
                {
                    bOneTime = this.cbOneTimeDb.IsChecked();
                    this.RefreshTabs();
                    this.sLastChosenCountry = this.cmbCountry.i_sMyValue;
                    e.Return = Sal.SendMsgToChildren(this.i_hWndFrame, Ifs.Fnd.ApplicationForms.Const.PM_User, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ((SalString)"POPULATE").ToHandle());
                    EnableTabsOnCategory();
                    return;
                }
            }
            else
            {
                e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Sys.wParam, Sys.lParam);
                return;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataRecordNew event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmSupplierInfo_OnPM_DataRecordNew(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                if (!(Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Sys.wParam, Sys.lParam)))
                {
                    e.Return = false;
                    return;
                }
                this.EnableTabsOnCategory();
                this.RefreshTabs();
                this.picTab.BringToTop(0, true);
                Sal.SetFocus(this.cmbSupplierId);
                this.bNewItem = true;
                e.Return = true;
                return;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataRecordRemove event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmSupplierInfo_OnPM_DataRecordRemove(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove, Sys.wParam, Sys.lParam))
                {
                    this.bNewItem = false;
                    e.Return = true;
                    return;
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

        /// <summary>
        /// PM_DataSourceSave event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmSupplierInfo_OnPM_DataSourceSave(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Sys.wParam, Sys.lParam))
            {
                if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                {
                    this.RefreshTabs();
                    this.bTabOk = Sal.SendMsgToChildren(this.TabAttachedWindowHandleGet(frmSupplierInfo.FromHandle(this.i_hWndFrame).picTab.FindName("frmSupplier")), Ifs.Fnd.ApplicationForms.Const.PM_DataSourceIsDirty, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire,
                        Sys.lParam);
                    if (this.bTabOk)
                    {
                        this.TabInvalidateData(frmSupplierInfo.FromHandle(this.i_hWndFrame).picTab.FindName("Name1"));
                    }
                    this.bTabName4 = Sal.SendMsgToChildren(this.TabAttachedWindowHandleGet(frmSupplierInfo.FromHandle(this.i_hWndFrame).picTab.FindName("Name4")), Ifs.Fnd.ApplicationForms.Const.PM_DataSourceIsDirty, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire,
                        Sys.lParam);
                    if (this.bTabName4)
                    {
                        this.TabInvalidateData(frmSupplierInfo.FromHandle(this.i_hWndFrame).picTab.FindName("Name1"));
                    }
                    this.bTabName2 = Sal.SendMsgToChildren(this.TabAttachedWindowHandleGet(frmSupplierInfo.FromHandle(this.i_hWndFrame).picTab.FindName("Name2")), Ifs.Fnd.ApplicationForms.Const.PM_DataSourceIsDirty, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire,
                        Sys.lParam);
                    if (this.bTabName2)
                    {
                        this.TabInvalidateData(frmSupplierInfo.FromHandle(this.i_hWndFrame).picTab.FindName("Name1"));
                    }
                    this.bTabName1 = Sal.SendMsgToChildren(this.TabAttachedWindowHandleGet(frmSupplierInfo.FromHandle(this.i_hWndFrame).picTab.FindName("Name1")), Ifs.Fnd.ApplicationForms.Const.PM_DataSourceIsDirty, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire,
                        Sys.lParam);
                    if (this.bTabName1)
                    {
                        this.TabInvalidateData(frmSupplierInfo.FromHandle(this.i_hWndFrame).picTab.FindName("Name2"));
                        this.TabInvalidateData(frmSupplierInfo.FromHandle(this.i_hWndFrame).picTab.FindName("Name4"));
                    }
                    this.hWndtabhandle = this.TabAttachedWindowHandleGet(this.picTab.FindName("DOMAIN-frmPartyInvoiceInfo"));
                    Sal.SendMsg(this.hWndtabhandle, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Sys.wParam, Sys.lParam);
                    // Refresh Contact record if Contact tab is in focus when SRM is installed
                    if (Ifs.Fnd.ApplicationForms.Var.Component.IsWindowAvailable(Pal.GetActiveInstanceName("frmSupplierInfoContact")) && Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("frmSupplierInfoContact")))
                    {
                        using (new SalContext(this))
                        {
                            SalNumber nTab = picTab.FindName("Name4");
                            if (nTab == picTab.GetTop())
                            {
                                this.hWndtabhandle = this.TabAttachedWindowHandleGet(this.picTab.FindName("Name4"));
                                Sal.SendMsg(this.hWndtabhandle, Ifs.Application.Enterp.Const.PAM_RefreshContactOnSave, 0, 0);
                            }

                        }
                    }
                    EnableTabsOnCategory();
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
        /// PAM_User event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmSupplierInfo_OnPAM_User(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.bOk = Sal.SendMsg(this.TabAttachedWindowHandleGet(frmSupplierInfo.FromHandle(this.i_hWndFrame).picTab.FindName("DOMAIN-frmPartyInvoiceInfo")), Ifs.Fnd.ApplicationForms.Const.PM_DataSourceIsDirty, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire,
                Sys.lParam);
            if (this.bOk)
            {
                if (Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_NotSaved, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok) == Sys.IDOK)
                {
                    this.picTab.BringToTop(this.picTab.Prev(), true);
                    Sal.SendMsg(this.TabAttachedWindowHandleGet(frmSupplierInfo.FromHandle(this.i_hWndFrame).picTab.FindName("DOMAIN-frmCustOrSupPayLed")), Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Sys.lParam);
                    e.Return = true;
                    return;
                }
            }
            else
            {
                e.Return = true;
                return;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataRecordDuplicate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmSupplierInfo_OnPM_DataRecordDuplicate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)
            {
                e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate, Sys.wParam, Sys.lParam);
                return;
            }
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate, Sys.wParam, Sys.lParam);
                if (this.dfsAssociationNo.Text != Sys.STRING_Null)
                {
                    Sal.SetFocus(this.dfsAssociationNo);
                    Sal.SendMsg(this.dfsAssociationNo, Sys.SAM_Validate, Sys.wParam, Sys.lParam);
                }
                e.Return = true;
                return;
            }
            #endregion
        }

        private void frmSupplierInfo_OnPM_DataRecordPaste(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordPaste, Sys.wParam, Sys.lParam))
            {
                if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                {
                    if (this.dfsAssociationNo.Text != Sys.STRING_Null)
                    {
                        Sal.SetFocus(this.dfsAssociationNo);
                        Sal.SendMsg(this.dfsAssociationNo, Sys.SAM_Validate, Sys.wParam, Sys.lParam);
                    }
                }
                e.Return = true;
                return;
            }
            e.Return = false;
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void cmbSupplierId_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemNew:
                    this.cmbSupplierId_OnPM_DataItemNew(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemSave:
                    this.cmbSupplierId_OnPM_DataItemSave(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom:
                    this.cmbSupplierId_OnPM_DataItemZoom(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemNew event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cmbSupplierId_OnPM_DataItemNew(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemNew, Sys.wParam, Sys.lParam);
            this.cmbSupplierId.EditDataItemSetEdited();
            e.Return = true;
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemSave event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cmbSupplierId_OnPM_DataItemSave(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemSave, Sys.wParam, Sys.lParam))
            {
                this.bNewItem = false;
                e.Return = true;
                return;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemSave, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemZoom event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cmbSupplierId_OnPM_DataItemZoom(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            e.Return = false;
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void dfsAssociationNo_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_Validate:
                    this.dfsAssociationNo_OnSAM_Validate(sender, e);
                    break;

                case Sys.SAM_AnyEdit:
                    this.dfsAssociationNo_OnSAM_AnyEdit(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_Validate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsAssociationNo_OnSAM_Validate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.bAssociationNoEdited)
            {
                if (this.CheckAssociationNumber())
                {
                    this.bAssociationNoEdited = false;
                    e.Return = Sys.VALIDATE_Ok;
                    return;
                }
                else
                {
                    e.Return = Sys.VALIDATE_Cancel;
                    return;
                }
            }
            e.Return = Sys.VALIDATE_Ok;
            return;
            #endregion
        }

        /// <summary>
        /// SAM_AnyEdit event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsAssociationNo_OnSAM_AnyEdit(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.bAssociationNoEdited = true;
            e.Return = Sal.SendClassMessage(Sys.SAM_AnyEdit, Sys.wParam, Sys.lParam);
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
            Sal.SendClassMessage(Sys.SAM_Click, Sys.wParam, Sys.lParam);
            if (this.sLastChosenCountry != this.cmbCountry.i_sMyValue)
            {
                this.CountryChanged();
            }
            this.GetLovValues();
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
            this.GetLovValues();
            e.Return = true;
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void dfsCorporateForm_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom:
                    this.dfsCorporateForm_OnPM_DataItemZoom(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovUserWhere:
                    this.dfsCorporateForm_OnPM_DataItemLovUserWhere(sender, e);
                    break;

                case Sys.SAM_Validate:
                    this.dfsCorporateForm_OnSAM_Validate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemZoom event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsCorporateForm_OnPM_DataItemZoom(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)
            {
                e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom, Sys.wParam, Sys.lParam);
                return;
            }
            else if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                Sal.SendMsg(this.dfsCorporateForm.i_hWndFrame, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceCreateWindow, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ((SalString)Pal.GetActiveInstanceName("tbwCorporateForms")).ToHandle());
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemLovUserWhere event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsCorporateForm_OnPM_DataItemLovUserWhere(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            using (SignatureHints hints = SignatureHints.NewContext())
            {
                hints.Add("Iso_Country_API.Encode", System.Data.ParameterDirection.Input);
                this.dfsCorporateForm.DbPLSQLBlock(cSessionManager.c_hSql, this.sFullFormName + ".sCountryDb :=\r\n" +
                    "                                 SUBSTR(&AO.Iso_Country_API.Encode( " + this.sFullFormName + ".cmbCountry.i_sMyValue),1,20)");
            }
            e.Return = (" COUNTRY_CODE = '" + this.sCountryDb + "' ").ToHandle();
            return;
            #endregion
        }

        /// <summary>
        /// SAM_Validate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsCorporateForm_OnSAM_Validate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            using (SignatureHints hints = SignatureHints.NewContext())
            {
                hints.Add("CORPORATE_FORM_API.Get_Corporate_Form_Desc", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                this.dfsCorporateForm.DbPLSQLBlock(cSessionManager.c_hSql, this.sFullFormName + ".dfsCorporateFormDesc  :=\r\n" +
                    "                                 SUBSTR(&AO.CORPORATE_FORM_API.Get_Corporate_Form_Desc( " + this.sFullFormName + ".sCountryCode, " + this.sFullFormName + ".dfsCorporateForm),1,50)");
            }
            e.Return = true;
            return;
            #endregion
        }

        private void cbOneTimeDb_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_Click:
                    this.cbOneTimeDb_OnSAM_Click(sender, e);
                    break;
            }
            #endregion
        }

        private void cbOneTimeDb_OnSAM_Click(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.IsOneTimeAllowed())
            {
                Sal.SendClassMessage(Sys.SAM_Click, Sys.wParam, Sys.lParam);
                e.Return = true;
                return;
            }
            this.cbOneTimeDb.Checked = !(this.cbOneTimeDb.Checked);
            Sal.SetFieldEdit(this, false);
            this.RefreshTabs();
            e.Return = true;
            return;
            #endregion
        }

        private void picTab_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_Create:
                    this.picTab_OnSAM_Create(sender, e);
                    break;
            }
            #endregion
        }


        private void picTab_OnSAM_Create(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Ifs.Fnd.ApplicationForms.Var.Component.IsWindowAvailable(Pal.GetActiveInstanceName("frmSupplierInfoContact")) && Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("frmSrmContactInfo")))
            {
                // Removed Pal.GetActiveInstanceName because if there is a customisation in tbwSupplierInfoContact, Pal.GetActiveInstanceName() will return "tbwSupplierInfoContact_Cust" which will not be identified to be replaced.
                //APFRefactoringTool.IgnoreNavigationScan
                picTab.TabSetup = picTab.TabSetup.Replace("tbwSupplierInfoContact", "frmSupplierInfoContact");
            }
            e.Return = Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam);

            #endregion
        }

        #endregion

        #region Late Bind Methods

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalNumber vrtDataSourcePrepareKeyTransfer(SalString sWindowName)
        {
            return this.DataSourcePrepareKeyTransfer(sWindowName);
        }

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalBoolean vrtDataSourceSaveCheck()
        {
            return this.DataSourceSaveCheck();
        }

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
        public override SalBoolean vrtTabActivateStart(SalWindowHandle hWnd, SalNumber nTab)
        {
            return this.TabActivateStart(hWnd, nTab);
        }

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalBoolean vrtTabActivateFinish(SalWindowHandle hWnd, SalNumber nTab)
        {
            return this.TabActivateFinish(hWnd, nTab);
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
        public override SalNumber vrtActivate(fcURL URL)
        {
            #region Local Variables
            SalArray<SalString> sItems = new SalArray<SalString>();
            SalNumber nIndex = 0;
            SalArray<SalString> sAddressId = new SalArray<SalString>();
            SalArray<SalString> sSupplierId = new SalArray<SalString>();
            SalString sTarget = "";

            SalArray<SalString> sPersonId = new SalArray<SalString>();
            SalArray<SalString> sGuid = new SalArray<SalString>();
            #endregion

            #region Actions
            using (new SalContext(this))
            {

                this.picTab.BringToTop(0, true);
                HandleDataSubjectConsentColumns(SalBoolean.True);

                if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.RecCountGet() > 0)
                {
                    if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.SourceNameGet() == Pal.GetActiveInstanceName("frmSupplierInfoAddress"))
                    {
                        Sal.WaitCursor(true);
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("SUPPLIER_ID", sSupplierId);
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("ADDRESS_ID", sAddressId);
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.SourceNameSet(Pal.GetActiveInstanceName("frmSupplierInfoAddress"));
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemAdd("SUPPLIER_ID", sSupplierId);
                        InitFromTransferredData();
                        cmbSupplierId.RecordSelectionListSetSelect(0);
                        Sal.WaitCursor(false);
                        frmSupplierInfo.FromHandle(i_hWndFrame).TabSetActive(picTab.FindName("Name1"), true);
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemAdd("ADDRESS_ID", sAddressId);
                        Ifs.Fnd.ApplicationForms.Var.Cache.SessionRetrieve("TargetTab", ref sTarget);
                        if (sTarget == "SupplierGeneralAddressInfo")
                        {
                            if (((this.TabAttachedWindowHandleGet(picTab.FindName("Name1")))) != Sys.hWndNULL)
                            {
                                (frmSupplierInfoAddress.FromHandle(this.TabAttachedWindowHandleGet(picTab.FindName("Name1")))).picTab.BringToTop(0, true);
                            }
                        }
                        Ifs.Fnd.ApplicationForms.Var.Cache.SessionStore("TargetTab", "");
                        return false;
                    }
                    else if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.SourceNameGet() == Pal.GetActiveInstanceName("tbwSupplierInfoContact"))
                    {
                        Sal.WaitCursor(true);

                        //Get Data from DataTransfer object and Reset it
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("SUPPLIER_ID", sSupplier);
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("PERSON_ID", sPersonId);
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("GUID", sGuid);
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();

                        //Set the SourceName as frmSupplierInfo. this will be used to check in tbwSupplierInfoContact.
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.SourceNameSet(Pal.GetActiveInstanceName("frmSupplierInfo"));
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemAdd("SUPPLIER_ID", sSupplier);
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemAdd("PERSON_ID", sPersonId);
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemAdd("GUID", sGuid);

                        //Construct the custom where clause and populate the datasource
                        Sal.SendMsg(i_hWndFrame, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceUserWhere, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ((SalString)"SUPPLIER_ID = :i_hWndFrame.frmSupplierInfo.sSupplier[0] ").ToHandle());
                        Sal.SendMsg(i_hWndFrame, Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);

                        cmbSupplierId.RecordSelectionListSetSelect(0);
                        Sal.WaitCursor(false);

                        //Set Contact tab as active tab
                        frmSupplierInfo.FromHandle(i_hWndFrame).TabSetActive(picTab.FindName("Name4"), true);
                        return false;
                    }
                    else
                    {
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemNamesGet(sItems);
                        nIndex = Vis.ArrayFindString(sItems, "VENDOR_NO");
                        if (nIndex != -1)
                        {
                            Ifs.Fnd.ApplicationForms.Var.DataTransfer.i_sItemNames[nIndex] = "SUPPLIER_ID";
                        }
                        Sal.SetWindowText(i_hWndFrame, Properties.Resources.HEAD_DetailSupplierInfo);
                        Sal.WaitCursor(true);
                        InitFromTransferredData();
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();                        
                        Sal.WaitCursor(false);
                        return false;
                    }
                }

                return base.Activate(URL);
            }
            #endregion
        }
        #endregion

        #region Event Handlers

        private void menuItem__Copy_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            // TODO: Rewrite command event handler not to use UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            ((FndCommand)sender).Enabled = Sal.SendMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, ((SalString)Pal.GetActiveInstanceName("dlgCopySupplier")).ToHandle());
        }

        private void menuItem__Copy_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            // TODO: Rewrite command event handler not to make use of UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            Ifs.Fnd.ApplicationForms.Int.PostMessage(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Pal.GetActiveInstanceName("dlgCopySupplier"));
        }

        private void menuItem__Chg_Supp_Category_Inquire(object sender, FndCommandInquireEventArgs e)
        {
            if (Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0))
            {
                ((FndCommand)sender).Enabled = false;
                return;
            }
            ((FndCommand)sender).Enabled = (!(Sal.IsNull(cmbSupplierCategory))) && (cmbSupplierCategory.i_sMyValue == sProspect);
        }

        private void menuItem__Chg_Supp_Category_Execute(object sender, FndCommandExecuteEventArgs e)
        {
            if (dlgChangeSupplierCategory.ModalDialog(Ifs.Fnd.ApplicationForms.Int.Explorer.ExplorerForm, cmbSupplierId.i_sMyValue, dfsName.Text, dfsAssociationNo.Text) == Sys.IDOK)
            {
                cmbSupplierId.RecordSelectionListSetSelect(cmbSupplierId.GetSelectedItem());
                return;
            }
        }

        private void cmdManageDataProcessingPurposes_Inquire(object sender, FndCommandInquireEventArgs e)
        {
            #region Action
            if (Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("DATA_SUBJECT_CONSENT_OPER_API.Consent_Action") && !(Sal.IsNull(cmbSupplierId)) && sDataSubjectEnable == "TRUE")
                ((FndCommand)sender).Enabled = true;
            else
                ((FndCommand)sender).Enabled = false;
            #endregion
        }

        private void cmdManageDataProcessingPurposes_Execute(object sender, FndCommandExecuteEventArgs e)
        {
            #region Action
            DbPLSQLBlock(@"{0} := &AO.Data_Subject_Consent_API.Get_Subject_Key_Ref({1} IN,{2} IN, NULL);", this.QualifiedVarBindName("sDataSubjectKeyRef"), this.QualifiedVarBindName("sDataSubjectDb"), this.cmbSupplierId.QualifiedBindName);
            if (dlgPersonalDataConsent.ModalDialog(this, this.sDataSubjectKeyRef, sDataSubjectDb, dfsName.Text) == Sys.IDOK)
            {
                Sal.SendMsg(i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceRefresh, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                return;
            }
            #endregion
        }

        #endregion

        private void cmdViewB2BUsers_Execute(object sender, FndCommandExecuteEventArgs e)
        {
            #region Local Variables
            SalArray<SalString> sArray = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndArray = new SalArray<SalWindowHandle>();
            #endregion

            #region Actions
            sArray[0] = "SUPPLIER_ID";
            hWndArray[0] = cmbSupplierId;
            Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init(Pal.GetActiveInstanceName("frmSupplierInfo"), this, sArray, hWndArray);
            SessionNavigate(Pal.GetActiveInstanceName("tbwB2BSupplierUser"));
            #endregion
        }

        private void cmdViewB2BUsers_Inquire(object sender, FndCommandInquireEventArgs e)
        {
            if (Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0))
            {
                ((FndCommand)sender).Enabled = false;
                return;
            }
            if (!(DataSourceCreateWindow(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Pal.GetActiveInstanceName("tbwB2BSupplierUser")) == 0))
            {
                if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsPresObjectAvailable(Pal.GetActiveInstanceName("tbwB2BSupplierUser"))))
                {
                    ((FndCommand)sender).Enabled = false;
                    return;
                }
            }
            else
            {
                ((FndCommand)sender).Enabled = false;
                return;
            }
            ((FndCommand)sender).Enabled = (!(Sal.IsNull(cmbSupplierId))) && cbB2bSupplier.Checked;
        }

        

    }
}
