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
// 101015   Kanslk  Bug 93517, Modified vrtActivate
// 120419   Chgulk  EASTRTM-6962, Merged LCS patch 101624.
// 120712   Maiklk  PBR-33, Greyed out tabs according to Customer Category value in the customer form
// 120809   RuLiLk  Bug 103569, Registered CUSTOMER_INFO_ADDR_INV_PUB_LOV and CUSTOMER_INFO_ADDR_DEL_PUB_LOV, CUST_ADDRESS_SHIP_LOV, CUST_BILL_ADDRESS_LOV, CUST_ADDRESS_BILL_LOV.
// 120809           Modified method InitFromTransferredData.
// 120821   MaRalk  PBR-357, Modified method EnableTabs to disable Document Tax Information tab when customer category is END USER.
// 120828   Maiklk  PBR-325, Added CUSTOMER_PROSPECT_PUB to window registration section.
// 120913   Maiklk  PBR-396, Implemented to focus contact tab when opening it from other sources. 
// 121019   MaRalk  PBR-553, Modified method EnableTabs to disable Order tab and last three tabs of Address tab, when customer category is END USER. 
// 121031   MaRalk  PBR-563, Added RMB View End Customer Connections. 
// 121120   MaRalk  PBR-747, Modified methods GetIIDValues and EnableTabs to reflect the IID value change End User to End Customer. 
// 130129   MaRalk  PBR-1203, Added CUSTOMER_INFO_CUSTCATEGORY_PUB to window registration section.
// 130307   MaRalk  PBR-1101, Added CUST_ORD_CUST10 to window registration section.
// 131015   MaIklk  Implemented to load the contact form which include representatives if CRM is installed.
// 140210   Maabse  Add response to event PAM_RecordNotInitiallySaved
// 140221           PBCS-6340, Removed cmbCustomerCategory_OnSAM_AnyEdit, cmbCustomerCategory_OnPM_DataItemValidate, cmbCustomerCategory_OnPM_DataItemPopulate
// 140221           and cmbCustomerCategory_WindowActions. New calles to EnableTabs() in frmCustomerInfo_OnPM_DataSourcePopulate and frmCustomerInfo_OnPM_DataSourceSave
// 140221   JanWse  If cmbCustomerCategory is modified EnableTabs() returns
// 130313   MaIklk  PBSC-7573, Changed the behaviour of enabling tabs for prospect and end customer.
// 140401   Machlk  PBFI-5564 Merged Bug 115353
// 140401   Kagalk	PBFI-4142, Merged Bug 113712, Modified to give a warning when deleting the last address type.
// 140409   Ajpelk  PBFI-4140, Merged Bug 112894, Added more codes to TabActivateFinish()
// 140409   MaIklk  PBSC-8055, Handled to disbale some tabs in order tab for prospect.
// 140704   Hawalk  Bug 116673, Changed view of tblOurId from CUSTOMER_INFO_OUR_ID to CUSTOMER_INFO_OUR_ID_FIN_AUTH (user-company authorization rests in
// 140704           ACCRUL, that cannot be directly referenced in the server - hence a new view).
// 140709   MaIklk  PRSC-1760, Implemented a RMB to change the customer category.
// 140728   Kagalk  PRFI-1290, Merged Bug 117813, Enable to validate association no when using object copy/paste.
// 140826   Maabse  PESC-1788, Added call to event PAM_RefreshContactOnSave
// 140902   MaIklk  PRSC-2671, Used to check frmCustomerInfoContact is available in order to check crm is installed.
// 141107   Kagalk  PRFI-2938, Merged Bug 119066, Removed cmbCustomerId.RecordSelectionListSetSelect(0) from vrtActivate.
// 150706   Wahelk  BLU-955, Modified cmdChangeCategory_Execute
// 150709   Maabse  BLU-984, Added dummy procedure call to Create_Category_Customer__
// 150611   clstlk  Bug 122600, Modified CountryChanged (). 
// 150907   MaRalk  AFT-3103, Added CUST_ORD_CUST1 in window registration.
// 160516   MAAYLk  STRFI-1812 (Bug 128732), Registered CUSTOMER_INFO_ADDRESS.
// 160516   MAAYLK  STRFI-1726 (Bug 128550), Modified picTab_OnSAM_Create() by removing Pal.GetActiveInstanceName() when calling picTab.TabSetup.Replace().
// 160909   JanWse  VAULT-135, Added RMB "Share Customer"
// 160912   Chwilk  STRFI-3299, Bug 130612, Modified OnPM_DataSourceSave() by adding PAM_RefreshContactOnSave, to populate frmCrmCustInfo on save.
// 161026   JanWse  VAULT-1946, Changed from Rm_Acc_Customer_API.Can_Share to Rm_Acc_Usage_API and added some parameters
// 161202   IzShlk  VAULT-2109, Removed RMB to Share Customers.
// 170323   Hairlk  APPUXX-8720, Added windows action for PAM_GetParentValue which will return the customer id.
// 170928   Chwilk  STRFI-9903, Bug 137649, Modified TabActivateFinish().
#endregion

using System.Windows.Forms;
using System.Collections.Generic;
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
    [FndWindowRegistration("CUSTOMER_INFO_CUSTCATEGORY_PUB", "CustomerInfo", FndWindowRegistrationFlags.HomePage)]
    [FndWindowRegistration("CUST_BILL_ADDRESS_LOV", "CustomerInfo", FndWindowRegistrationFlags.HomePage | FndWindowRegistrationFlags.NoSecurity)]
    [FndWindowRegistration("CUST_ADDRESS_SHIP_LOV", "CustomerInfo", FndWindowRegistrationFlags.HomePage | FndWindowRegistrationFlags.NoSecurity)]
    [FndWindowRegistration("CUST_ADDRESS_BILL_LOV", "CustomerInfo", FndWindowRegistrationFlags.HomePage | FndWindowRegistrationFlags.NoSecurity)]
    [FndWindowRegistration("CUSTOMER_INFO_ADDR_DEL_PUB_LOV", "CustomerInfo", FndWindowRegistrationFlags.HomePage)]
    [FndWindowRegistration("CUSTOMER_INFO_ADDR_INV_PUB_LOV", "CustomerInfo", FndWindowRegistrationFlags.HomePage)]
    [FndWindowRegistration("IDENTITY_INVOICE_INFO_CUST", "", FndWindowRegistrationFlags.HomePage | FndWindowRegistrationFlags.NoSecurity)]
    [FndWindowRegistration("CUST_ORD_CUSTOMER, CUST_ORD_CUST1, CUST_ORD_CUST10", "CustOrdCustomer", FndWindowRegistrationFlags.HomePage | FndWindowRegistrationFlags.NoSecurity)]
    [FndWindowRegistration("EXTERNAL_CUSTOMER_LOV", "CustomerInfo", FndWindowRegistrationFlags.HomePage | FndWindowRegistrationFlags.NoSecurity)]
    [FndWindowRegistration("CUST_ORD_CUST2", "CustOrdCustomer", FndWindowRegistrationFlags.HomePage | FndWindowRegistrationFlags.NoSecurity)]
    [FndWindowRegistration("CUST_ORD_CUST5", "CustOrdCustomer", FndWindowRegistrationFlags.HomePage | FndWindowRegistrationFlags.NoSecurity)]
    [FndWindowRegistration("CUST_ORD_CUST6", "CustOrdCustomer", FndWindowRegistrationFlags.HomePage | FndWindowRegistrationFlags.NoSecurity)]
    [FndWindowRegistration("CUST_ORD_CUST7", "CustOrdCustomer", FndWindowRegistrationFlags.HomePage | FndWindowRegistrationFlags.NoSecurity)]
    [FndWindowRegistration("CUSTOMER_INFO,IDENTITY_PAY_INFO_CUST,MULTI_CUS_DETAILS_QRY,IDENTITY_PAY_INFO_CUST_NETTING", "CustomerInfo", FndWindowRegistrationFlags.HomePage | FndWindowRegistrationFlags.NoSecurity)]
    [FndWindowRegistration("CUSTOMER_PROSPECT_PUB", "CustomerInfo", FndWindowRegistrationFlags.HomePage)]
    [FndWindowRegistration("CUSTOMER_INFO", "CustomerInfo", FndWindowRegistrationFlags.HomePage)]
    [FndWindowRegistration("CUSTOMER_INFO_ADDRESS", "CustomerInfo", FndWindowRegistrationFlags.HomePage | FndWindowRegistrationFlags.NoSecurity)]
    public partial class frmCustomerInfo : cMasterDetailTabFormWindow
    {
        #region Window Variables
        public SalNumber nIndex = 0;
        public SalArray<SalString> sItems = new SalArray<SalString>();
        public SalString sFullFormName = "";
        public SalString sCountryDb = "";
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
        public SalString sCountryCode = "";
        public SalString sContactTabActive = "";
        public SalString sPaymentTabActive = "";
        public SalString sProjRepTabActive = "";
        public SalArray<SalString> sIIDValues = new SalArray<SalString>();
        public cMessage IIDValues = new cMessage();
        public SalString sProjTabActive = "";
        public SalString sOrderTabActive = "";
        public SalWindowHandle hWndAddress = SalWindowHandle.Null;
        public SalWindowHandle hWndPayment = SalWindowHandle.Null;
        public SalWindowHandle hWndDelivaryTaxInfo = SalWindowHandle.Null;
        public SalBoolean bOneTime = false;
        public SalNumber nActiveTab = 0;
        public SalString sCustomerName = "";
        public SalString sAssociationNo = "";
        public SalString sCustomerCategory = "";
        public SalString sTemplateCustomerId = "";
        public SalString sTemplateCompany = "";
        public SalString sOverwriteOrderData = "";
        public SalString sTranferAddr = "";
        public SalString sCorporateFormExist = "";
        public SalString sCorporateFormDesc = "";
        public SalString sDataSubjectKeyRef = "";
        public SalString sDataSubjectEnable = "FALSE";
        public static SalString sDataSubjectDb = "CUSTOMER";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public frmCustomerInfo()
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
        public new static frmCustomerInfo FromHandle(SalWindowHandle handle)
        {
            return ((frmCustomerInfo)SalWindow.FromHandle(handle, typeof(frmCustomerInfo)));
        }
        #endregion

        #region Methods

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <param name="sMethod"></param>
        /// <returns>
        /// </returns>
        public new SalNumber UserMethod(SalNumber nWhat, SalString sMethod)
        {
            #region Actions
            using (new SalContext(this))
            {
                if (sMethod == Pal.GetActiveInstanceName("dlgCopyCustomer"))
                {
                    switch (nWhat)
                    {
                        case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                            {
                                if (bNewItem)
                                {
                                    bNewItem = false;
                                    return 0;
                                }
                                if (DataSourceIsDirty(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire))
                                {
                                    return 0;
                                }
                                return Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("dlgCopyCustomer"));
                            }

                        case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                            {
                                bOk = true;
                                if (cbOneTimeDb.IsChecked())
                                {
                                    bOk = (Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_CopyOneTimeIdentity, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Question, (Ifs.Fnd.ApplicationForms.Const.QUESTION_YesNo | Sys.MB_DefButton2)) == Sys.IDYES);
                                }
                                if (bOk)
                                {
                                    if (dlgCopyCustomer.ModalDialog(this))
                                    {
                                        if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.RecCountGet() > 0)
                                        {
                                            Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemNamesGet(sItems);
                                            nIndex = Vis.ArrayFindString(sItems, "CUSTOMER_ID");
                                            if (nIndex != -1)
                                            {
                                                Ifs.Fnd.ApplicationForms.Var.DataTransfer.i_sItemNames[nIndex] = "CUSTOMER_ID";
                                            }
                                            Sal.WaitCursor(true);
                                            InitFromTransferedData();
                                            Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
                                            cmbCustomerId.RecordSelectionListSetSelect(0);
                                            Sal.PostMsg(i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceRefresh, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                                            Sal.WaitCursor(false);
                                            return 0;
                                        }
                                    }
                                }
                                break;
                            }
                    }
                }
                else if (sMethod == "GetIdentity")
                {
                    switch (nWhat)
                    {
                        case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                            return 0;

                        case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                            return cmbCustomerId.i_sMyValue.ToHandle();
                    }
                }
                else
                {
                    return 0;
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
            #region Local Variables
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                Sal.SetWindowText(i_hWndFrame, Properties.Resources.HEAD_DetailCustomerInfo);
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
                        "                                 &AO.Association_Info_API.Association_No_Exist( " + sFullFormName + ".dfsAssociationNo, 'CUSTOMER' )");
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
            SalArray<SalString> sItemNames = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                if (sWindowName == Pal.GetActiveInstanceName("tbwCorporateForms"))
                {
                    sItemNames[0] = "COUNTRY_CODE";
                    hWndItems[0] = dfsCountryDb;
                }
                else
                {
                    return ((cDataSource)this).DataSourcePrepareKeyTransfer(sWindowName);
                }
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init(sWindowName, this, sItemNames, hWndItems);
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.TypeSet("CREATE_WINDOW");
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
                    if (Sal.SendMsg(frmCustomerInfoAddress.FromHandle(hWndAddress).tblCommMethod, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceIsDirty, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam))
                    {
                        if (!(frmCustomerInfoAddress.FromHandle(hWndAddress).tblCommMethod.CheckDefault()))
                        {
                            return false;
                        }
                    }
                    if (Sal.SendMsg(frmCustomerInfoAddress.FromHandle(hWndAddress).tblCustomerInfoContact, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceIsDirty, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam))
                    {
                        if (!(frmCustomerInfoAddress.FromHandle(hWndAddress).tblCustomerInfoContact_CheckDefault(cmbCustomerId.i_sMyValue, frmCustomerInfoAddress.FromHandle(hWndAddress).cmbAddressId.i_sMyValue)))
                        {
                            return false;
                        }
                    }
                }
                if (sCommMethodTabActive == "TRUE")
                {
                    if (Sal.SendMsg(frmCustomerInfo.FromHandle(i_hWndFrame).TabAttachedWindowHandleGet(picTab.FindName("Name2")), Ifs.Fnd.ApplicationForms.Const.PM_DataSourceIsDirty, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam))
                    {
                        if (!(frmCustomerInfoCommMethod.FromHandle(hWndComMethod).tblCommMethod.CheckDefault()))
                        {
                            return false;
                        }
                    }
                }

                if (sContactTabActive == "TRUE")
                {
                    if (Ifs.Fnd.ApplicationForms.Var.Component.IsWindowAvailable(Pal.GetActiveInstanceName("frmCustomerInfoContact")) && Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("frmCustomerInfoContact")))
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
                    bIsOneTimeChecked = this.cbOneTimeDb.IsChecked();
                    if (bOneTime != bIsOneTimeChecked)
                    {
                        bOk = DbPLSQLBlock(cSessionManager.c_hSql, "Customer_Info_API.Validate_One_Time_Customer__(:i_hWndFrame.frmCustomerInfo.cmbCustomerId.i_sMyValue)");
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
                else if (sName == Pal.GetActiveInstanceName("frmCustomerProjRep"))
                {
                    sProjRepTabActive = "TRUE";
                }
                else if (sName == Pal.GetActiveInstanceName("tbwProject"))
                {
                    sProjTabActive = "TRUE";
                }
                else if (sName == Pal.GetActiveInstanceName("frmCustOrdCustomer"))
                {
                    sOrderTabActive = "TRUE";
                }
            }
            return 0;
            #endregion
        }

        public new SalNumber TabActivateFinish(SalWindowHandle hWnd, SalNumber nTab)
        {
            #region Local Variables
            SalString sName = "";
            SalWindowHandle hWndInfoCommMethod = SalWindowHandle.Null;
            SalNumber retVal = 0;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                retVal = base.TabActivateFinish(hWnd, nTab);
                picTab.GetName(nTab, ref sName);
                if (sName == "Name1")
                {
                    hWndAddress = TabAttachedWindowHandleGet(picTab.FindName("Name1"));
                    frmCustomerInfoAddress.FromHandle(hWndAddress).RefreshTabs();
                }
                else
                {                    
                    if (sName == "DOMAIN-frmCustOrSupPayLed")
                    {
                        hWndPayment = TabAttachedWindowHandleGet(nTab);
                        Sal.SendMsg(hWndPayment, Ifs.Fnd.ApplicationForms.Const.PM_User, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ((SalString)"OneTimeActivateTab").ToHandle());
                    }
                    else
                    {
                        if (sName == "Name2")
                        {
                            hWndInfoCommMethod = TabAttachedWindowHandleGet(picTab.FindName(sName));
                            Sal.SetFocus(frmCustomerInfoCommMethod.FromHandle(hWndInfoCommMethod).tblCommMethod);
                        }
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
                                                           CorporateFormExist_ := &AO.Corporate_Form_Api.Validate_Corporate_Form(
                                                                                                                              :i_hWndSelf.frmCustomerInfo.sCountryCode IN,
                                                                                                                              :i_hWndSelf.frmCustomerInfo.dfsCorporateForm IN);
                                                           :i_hWndSelf.frmCustomerInfo.sCorporateFormExist := CorporateFormExist_ ;
                                                           IF (CorporateFormExist_ = 'TRUE') THEN
                                                              :i_hWndSelf.frmCustomerInfo.sCorporateFormDesc:= &AO.Corporate_Form_Api.Get_Corporate_Form_Desc(  
                                                                                                                              :i_hWndSelf.frmCustomerInfo.sCountryCode IN,
                                                                                                                              :i_hWndSelf.frmCustomerInfo.dfsCorporateForm IN);                                                            
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
                    if (((bool)Sal.SendMsg(frmCustomerInfoAddress.FromHandle(hWndAddress).tblAddressType, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceIsDirty, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam)) || (Sal.QueryFieldEdit(frmCustomerInfoAddress.FromHandle(hWndAddress).dfdValidFrom) ||
                    Sal.QueryFieldEdit(frmCustomerInfoAddress.FromHandle(hWndAddress).dfdValidTo)))
                    {
                        if (!(frmCustomerInfoAddress.FromHandle(hWndAddress).tblAddressType_CheckDefaultAddress()))
                        {
                            return false;
                        }
                        if (!(frmCustomerInfoAddress.FromHandle(hWndAddress).tblAddressType_CheckLastAddressType()))
                        {
                            return false;
                        }
                    }
                }
                return ((cMasterDetailTabFormWindow)this).DataSourceSaveCheck();
            }
            #endregion
        }

        /// <summary>
        /// Applications call the InitFromTransferredData function to initialize
        /// (populate) the data source based on information in data transfer.
        /// COMMENTS:
        /// NOTE! That this function is replacing the obsolete function
        /// InitFromTransferedData. All types of datasources will automatically
        /// be populated.
        /// </summary>
        /// <returns></returns>
        public virtual new SalBoolean InitFromTransferredData()
        {
            #region Local Variables
            SalArray<SalString> sSqlColumn = new SalArray<SalString>();
            SalString lsWhereStmt = "";
            SalNumber nRows = 0;
            SalNumber nColumns = 0;
            SalString sDelim = "";
            SalString sCustomerId = "";
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
                    if (Vis.ArrayFindString(sSqlColumn, "CUSTOMER_ID") >= 0)
                    {
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemValueStrGet(Vis.ArrayFindString(sSqlColumn, "CUSTOMER_ID"), 0, ref sCustomerId);
                    }
                    else if (Vis.ArrayFindString(sSqlColumn, "IDENTITY") >= 0)
                    {
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemValueStrGet(Vis.ArrayFindString(sSqlColumn, "IDENTITY"), 0, ref sCustomerId);
                    }
                    sDelim = "";
                    lsWhereStmt = "CUSTOMER_ID = ";
                    lsWhereStmt = lsWhereStmt + sDelim + "'" + sCustomerId + "'";
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
        public virtual SalNumber GetIIDValues()
        {
            #region Local Variables
            SalArray<SalString> sIIDNames = new SalArray<SalString>();
            SalNumber nCurrent = 0;
            SalNumber nMax = 0;
            SalString lsStmt = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                // Write all IID values you want to get here.
                sIIDNames[0] = "Customer_Category_API.Decode('CUSTOMER')";
                sIIDNames[1] = "Customer_Category_API.Decode('PROSPECT')";
                sIIDNames[2] = "Customer_Category_API.Decode('END_CUSTOMER')";

                // Create string
                nMax = sIIDNames.GetUpperBound(1);
                nCurrent = 0;
                while (nMax > (nCurrent - 1))
                {
                    lsStmt = lsStmt + sFullFormName + ".sIIDValues[" + nCurrent.ToString(0) + "] := &AO." + sIIDNames[nCurrent] + "; ";
                    nCurrent = nCurrent + 1;
                }
                if (DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN " + lsStmt + "END;"))
                {
                    IIDValues.Construct();
                    IIDValues.AddAttribute("CUSTOMER_CATEGORY.CUSTOMER", sIIDValues[0]);
                    IIDValues.AddAttribute("CUSTOMER_CATEGORY.PROSPECT", sIIDValues[1]);
                    IIDValues.AddAttribute("CUSTOMER_CATEGORY.END_CUSTOMER", sIIDValues[2]);

                }
            }

            return 0;
            #endregion
        }

        public virtual void RefreshTabs()
        {
            #region Local Variables
            SalNumber nPrjrepTab = 0;
            SalNumber nProjTab = 0;
            SalNumber nOrderTab = 0;
            #endregion

            #region Actions
            nPrjrepTab = this.picTab.FindName("frmCustomerProjRep");
            nProjTab = this.picTab.FindName("tbwProject");
            nOrderTab = this.picTab.FindName("frmCustOrdCustomer");
            if (this.cbOneTimeDb.IsChecked())
            {
                this.picTab.Enable(nPrjrepTab, false);
                this.picTab.Enable(nProjTab, false);
                this.picTab.Enable(nOrderTab, false);
                if (nActiveTab == nPrjrepTab || nActiveTab == nProjTab || nActiveTab == nOrderTab)
                    this.picTab.BringToTop(0, true);
            }
            else if (cmbCustomerCategory.i_sMyValue != IIDValues.GetAttribute("CUSTOMER_CATEGORY.END_CUSTOMER"))
            {
                if (cmbCustomerCategory.i_sMyValue != IIDValues.GetAttribute("CUSTOMER_CATEGORY.PROSPECT"))
                {
                    this.picTab.Enable(nPrjrepTab, true);
                    this.picTab.Enable(nProjTab, true);
                }
                this.picTab.Enable(nOrderTab, true);
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
            if (sProjRepTabActive == "TRUE")
            {
                if ((Sal.SendMsg(this.TabAttachedWindowHandleGet(this.picTab.FindName("frmCustomerProjRep")), Ifs.Fnd.ApplicationForms.Const.PM_DataSourceIsDirty, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0)))
                {
                    sParam[1] = Properties.Resources.TAB_NAME_ProjRepParam;
                    bAllowed = false;
                }
            }
            if (sProjTabActive == "TRUE")
            {
                if ((Sal.SendMsg(this.TabAttachedWindowHandleGet(this.picTab.FindName("tbwProject")), Ifs.Fnd.ApplicationForms.Const.PM_DataSourceIsDirty, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0)))
                {
                    sParam[1] = Properties.Resources.TAB_NAME_ProjRepParam;
                    bAllowed = false;
                }
            }
            if (sOrderTabActive == "TRUE")
            {
                if ((Sal.SendMsg(this.TabAttachedWindowHandleGet(this.picTab.FindName("frmCustOrdCustomer")), Ifs.Fnd.ApplicationForms.Const.PM_DataSourceIsDirty, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0)))
                {
                    sParam[1] = Properties.Resources.TAB_NAME_Order;
                    bAllowed = false;
                }
            }
            if (sPaymentTabActive == "TRUE")
            {
                if (!(Sal.SendMsg(hWndPayment, Ifs.Fnd.ApplicationForms.Const.PM_User, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ((SalString)"ValidateOneTime").ToHandle())))
                {
                    sParam[1] = Properties.Resources.TAB_NAME_Payment;
                    bAllowed = false;
                }
            }
            if (!bAllowed)
            {
                sParam[0] = this.cmbCustomerId.Text;
                Ifs.Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.TEXT_InvalidOneTimeCustomer, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok, sParam);
                return false;
            }
            //hWndPayment = TabAttachedWindowHandleGet(nTab);
            //Sal.SendMsg(hWndPayment, Ifs.Fnd.ApplicationForms.Const.PM_User, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ((SalString)"OneTimeActivateTab").ToHandle());
            this.RefreshTabs();
            return true;
            #endregion
        }

        /// <summary>
        /// Enable/Disable tabs according to the value selected in Customer Catgeroy
        /// </summary>
        public virtual void EnableTabs()
        {
            #region Local Variables
            SalWindowHandle hWndAddress = SalWindowHandle.Null;
            SalWindowHandle hWndCustOrdCustomer = SalWindowHandle.Null;
            SalBoolean bIsProspect;
            SalBoolean bIsEndCustomer;
            SalBoolean bIsCustomer;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                if (cmbCustomerCategory.Modified || cbOneTimeDb.IsChecked())
                    return;

                bIsProspect = cmbCustomerCategory.i_sMyValue == IIDValues.GetAttribute("CUSTOMER_CATEGORY.PROSPECT");
                bIsEndCustomer = cmbCustomerCategory.i_sMyValue == IIDValues.GetAttribute("CUSTOMER_CATEGORY.END_CUSTOMER");
                bIsCustomer = cmbCustomerCategory.i_sMyValue == IIDValues.GetAttribute("CUSTOMER_CATEGORY.CUSTOMER");

                // If no category selected then enable all tabs.
                if (cmbCustomerCategory.i_sMyValue == Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    EnableTabs(true, false);
                    return;
                }

                // Enable/disable tabs depending on customer category settings
                picTab.Enable(picTab.FindName("Name3"), bIsCustomer);
                picTab.Enable(picTab.FindName("DOMAIN-frmPartyInvoiceInfo"), bIsCustomer);
                picTab.Enable(picTab.FindName("DOMAIN-frmCustOrSupPayLed"), bIsCustomer);
                picTab.Enable(picTab.FindName("DOMAIN-frmCustomerCreditInfo"), bIsCustomer);
                picTab.Enable(picTab.FindName("frmCustOrdCustomer"), bIsCustomer || bIsProspect);
                picTab.Enable(picTab.FindName("frmCrmCustInfo"), true);
                picTab.Enable(picTab.FindName("frmCustomerProjRep"), bIsCustomer);
                picTab.Enable(picTab.FindName("tbwProject"), bIsCustomer);

                // Enable some tabs in order tab for prospect/customer
                hWndCustOrdCustomer = TabAttachedWindowHandleGet(picTab.FindName("frmCustOrdCustomer"));
                if (hWndCustOrdCustomer != Sys.hWndNULL)
                {
                    if (bIsProspect)
                    {
                        Sal.SendMsg(hWndCustOrdCustomer, Const.PAM_EnableTabs, 0, ((SalString)"PROSPECT").ToHandle());
                    }
                    else if (bIsCustomer)
                    {
                        Sal.SendMsg(hWndCustOrdCustomer, Const.PAM_EnableTabs, 0, ((SalString)"CUSTOMER").ToHandle());
                    }
                }

                hWndAddress = TabAttachedWindowHandleGet(picTab.FindName("Name1"));
                if (hWndAddress != Sys.hWndNULL)
                {
                    // Although Address tab is enabled from the above code sub tabs must be handled separately for enabling.                        
                    frmCustomerInfoAddress.FromHandle(hWndAddress).picTab.Enable(frmCustomerInfoAddress.FromHandle(hWndAddress).picTab.FindName("Name0"), true);

                    frmCustomerInfoAddress.FromHandle(hWndAddress).picTab.Enable(frmCustomerInfoAddress.FromHandle(hWndAddress).picTab.FindName("DOMAIN-frmDeliveryFeeCode"), bIsCustomer || bIsProspect);
                    frmCustomerInfoAddress.FromHandle(hWndAddress).picTab.Enable(frmCustomerInfoAddress.FromHandle(hWndAddress).picTab.FindName("DOMAIN-tbwDocumentFeeCode"), bIsCustomer || bIsProspect);
                    frmCustomerInfoAddress.FromHandle(hWndAddress).picTab.Enable(frmCustomerInfoAddress.FromHandle(hWndAddress).picTab.FindName("frmCustOrdCustomerAddress"), bIsCustomer || bIsProspect);

                    // only enable General tab for Address and make it as activated tab when End customer is selected
                    if (bIsEndCustomer)
                        frmCustomerInfoAddress.FromHandle(hWndAddress).picTab.BringToTop(frmCustomerInfoAddress.FromHandle(hWndAddress).picTab.FindName("Name0"), true);
                }

                // if selected tab is a disable one then activate the General tab
                if (!picTab.IsEnabled(picTab.GetTop()))
                {
                    picTab.BringToTop(picTab.FindName("Name0"), true);
                }
            }
            #endregion
        }

        public virtual SalString GetGlobalCompany()
        {
            SalString sCompany = "";
            UserGlobalValueGet("COMPANY", ref sCompany);
            return sCompany;
        }

        /// <summary>
        /// Common method to enable/disable all tabs
        /// </summary>
        /// <param name="bEnable"></param>
        /// <param name="bOnlyAddress"></param>
        public virtual void EnableTabs(SalBoolean bEnable, SalBoolean bOnlyAddress)
        {
            #region Local Variables
            SalNumber nMaxTabs = 0;
            SalNumber nTabIndex = 0;
            SalWindowHandle hWndAddress = SalWindowHandle.Null;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                // bOnlyAddress must be set to true only when the Customer/Address tab data are considered.
                // In generally when bOnlyAddress is false, all the main tabs in the customer form will be enabled or disabled depending on bEnable value. 
                if (!bOnlyAddress)
                {
                    nMaxTabs = picTab.GetCount() - 1;
                    nTabIndex = 0;
                    while (nTabIndex <= nMaxTabs)
                    {
                        picTab.Enable(nTabIndex, bEnable);
                        nTabIndex = nTabIndex + 1;
                    }
                }

                // when bEnable is true all the sub tabs of Customer/Address will be enabled.
                // According to customer category disabling specific sub tabs(in Customer/Address) must be handled separately.
                hWndAddress = TabAttachedWindowHandleGet(picTab.FindName("Name1"));
                if (hWndAddress != Sys.hWndNULL)
                {
                    nMaxTabs = frmCustomerInfoAddress.FromHandle(hWndAddress).picTab.GetCount() - 1;
                    nTabIndex = 0;
                    while (nTabIndex <= nMaxTabs)
                    {
                        frmCustomerInfoAddress.FromHandle(hWndAddress).picTab.Enable(nTabIndex, bEnable);
                        nTabIndex = nTabIndex + 1;
                    }
                }

            }

            #endregion
        }

        protected virtual void DummyProcedureCalls()
        {
            //Added this dummy call to make the method granted by default when granting this form
            DbPLSQLBlock(@"&AO.Customer_Info_API.Create_Category_Customer__();");
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
        private void frmCustomerInfo_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_Create:
                    this.frmCustomerInfo_OnSAM_Create(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate:
                    this.frmCustomerInfo_OnPM_DataSourcePopulate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew:
                    this.frmCustomerInfo_OnPM_DataRecordNew(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove:
                    this.frmCustomerInfo_OnPM_DataRecordRemove(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave:
                    this.frmCustomerInfo_OnPM_DataSourceSave(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PAM_User:
                    this.frmCustomerInfo_OnPAM_User(sender, e);
                    break;


                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate:
                    this.frmCustomerInfo_OnPM_DataRecordDuplicate(sender, e);
                    break;


                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordPaste:
                    this.frmCustomerInfo_OnPM_DataRecordPaste(sender, e);
                    break;


                case Const.PAM_RecordNotInitiallySaved:
                    e.Handled = true;
                    e.Return = (__sObjid == SalString.Null);
                    break;

                case Ifs.Application.Enterp.Const.PAM_GetParentValue:
                    e.Handled = true;
                    e.Return = ((SalString)this.cmbCustomerId.Text).ToHandle();
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_Create event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmCustomerInfo_OnSAM_Create(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam);
            this.sFullFormName = ":i_hWndFrame." + Ifs.Fnd.ApplicationForms.Int.QualifiedItemNameGet(this);
            this.GetIIDValues();
            #endregion
        }

        /// <summary>
        /// PM_DataSourcePopulate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmCustomerInfo_OnPM_DataSourcePopulate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Sys.wParam, Sys.lParam))
                {
                    this.bOneTime = this.cbOneTimeDb.IsChecked();
                    this.RefreshTabs();
                    this.sLastChosenCountry = this.cmbCountry.i_sMyValue;
                    e.Return = Sal.SendMsgToChildren(this.i_hWndFrame, Ifs.Fnd.ApplicationForms.Const.PM_User, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ((SalString)"POPULATE").ToHandle());
                    EnableTabs();
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
        private void frmCustomerInfo_OnPM_DataRecordNew(object sender, WindowActionsEventArgs e)
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
                this.RefreshTabs();
                this.picTab.BringToTop(0, true);
                Sal.SetFocus(this.cmbCustomerId);
                this.bNewItem = true;
                //If new record then enable all tabs since customer catagory is not selected.
                EnableTabs(true, false);
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
        private void frmCustomerInfo_OnPM_DataRecordRemove(object sender, WindowActionsEventArgs e)
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
        private void frmCustomerInfo_OnPM_DataSourceSave(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Sys.wParam, Sys.lParam))
            {
                if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                {
                    this.RefreshTabs();
                    this.bTabOk = Sal.SendMsgToChildren(this.TabAttachedWindowHandleGet(frmCustomerInfo.FromHandle(this.i_hWndFrame).picTab.FindName("frmCustOrdCustomer")), Ifs.Fnd.ApplicationForms.Const.PM_DataSourceIsDirty, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire,
                        Sys.lParam);
                    if (this.bTabOk)
                    {
                        this.TabInvalidateData(frmCustomerInfo.FromHandle(this.i_hWndFrame).picTab.FindName("Name1"));
                        Sal.PostMsg(this.TabAttachedWindowHandleGet(frmCustomerInfo.FromHandle(this.i_hWndFrame).picTab.FindName("frmCustOrdCustomer")), Ifs.Fnd.ApplicationForms.Const.PM_DataSourceRefresh, Sys.wParam, Sys.lParam);
                    }
                    this.bTabName4 = Sal.SendMsgToChildren(this.TabAttachedWindowHandleGet(frmCustomerInfo.FromHandle(this.i_hWndFrame).picTab.FindName("Name4")), Ifs.Fnd.ApplicationForms.Const.PM_DataSourceIsDirty, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire,
                        Sys.lParam);
                    if (this.bTabName4)
                    {
                        this.TabInvalidateData(frmCustomerInfo.FromHandle(this.i_hWndFrame).picTab.FindName("Name1"));
                    }
                    this.bTabName2 = Sal.SendMsgToChildren(this.TabAttachedWindowHandleGet(frmCustomerInfo.FromHandle(this.i_hWndFrame).picTab.FindName("Name2")), Ifs.Fnd.ApplicationForms.Const.PM_DataSourceIsDirty, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire,
                        Sys.lParam);
                    if (this.bTabName2)
                    {
                        this.TabInvalidateData(frmCustomerInfo.FromHandle(this.i_hWndFrame).picTab.FindName("Name1"));
                    }
                    this.bTabName1 = Sal.SendMsgToChildren(this.TabAttachedWindowHandleGet(frmCustomerInfo.FromHandle(this.i_hWndFrame).picTab.FindName("Name1")), Ifs.Fnd.ApplicationForms.Const.PM_DataSourceIsDirty, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire,
                        Sys.lParam);
                    if (this.bTabName1)
                    {
                        this.TabInvalidateData(frmCustomerInfo.FromHandle(this.i_hWndFrame).picTab.FindName("Name2"));
                        this.TabInvalidateData(frmCustomerInfo.FromHandle(this.i_hWndFrame).picTab.FindName("Name4"));
                    }
                    this.hWndtabhandle = this.TabAttachedWindowHandleGet(this.picTab.FindName("DOMAIN-frmPartyInvoiceInfo"));
                    Sal.SendMsg(this.hWndtabhandle, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Sys.wParam, Sys.lParam);
                    // Refresh Contact record if Contact tab is in focus when CRM is installed
                    if (Ifs.Fnd.ApplicationForms.Var.Component.IsWindowAvailable(Pal.GetActiveInstanceName("frmCustomerInfoContact")) && Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("frmCustomerInfoContact")))
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

                    this.EnableTabs();
                    if (hWndAddress != Sys.hWndNULL)
                    {
                        hWndDelivaryTaxInfo = frmCustomerInfoAddress.FromHandle(hWndAddress).TabAttachedWindowHandleGet(frmCustomerInfoAddress.FromHandle(hWndAddress).picTab.FindName("DOMAIN-frmDeliveryFeeCode"));
                        Sal.SendMsg(hWndDelivaryTaxInfo, Ifs.Fnd.ApplicationForms.Const.PM_User, 1, 0);
                    }
                    if (Ifs.Fnd.ApplicationForms.Var.Component.IsWindowAvailable(Pal.GetActiveInstanceName("frmCrmCustInfo")) && Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("frmCrmCustInfo")))
                    {
                        this.hWndtabhandle = this.TabAttachedWindowHandleGet(frmCustomerInfo.FromHandle(this.i_hWndFrame).picTab.FindName("frmCrmCustInfo"));
                        Sal.SendMsg(this.hWndtabhandle, Ifs.Application.Enterp.Const.PAM_RefreshContactOnSave, 0, 0);
                    }
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
        private void frmCustomerInfo_OnPAM_User(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.bOk = Sal.SendMsg(this.TabAttachedWindowHandleGet(frmCustomerInfo.FromHandle(this.i_hWndFrame).picTab.FindName("DOMAIN-frmPartyInvoiceInfo")), Ifs.Fnd.ApplicationForms.Const.PM_DataSourceIsDirty, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire,
                Sys.lParam);
            if (this.bOk)
            {
                if (Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_NotSaved, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok) == Sys.IDOK)
                {
                    this.picTab.BringToTop(this.picTab.Prev(), true);
                    Sal.SendMsg(this.TabAttachedWindowHandleGet(frmCustomerInfo.FromHandle(this.i_hWndFrame).picTab.FindName("DOMAIN-frmCustOrSupPayLed")), Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Sys.lParam);
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
        private void frmCustomerInfo_OnPM_DataRecordDuplicate(object sender, WindowActionsEventArgs e)
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


        private void frmCustomerInfo_OnPM_DataRecordPaste(object sender, WindowActionsEventArgs e)
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
        private void cmbCustomerId_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemNew:
                    this.cmbCustomerId_OnPM_DataItemNew(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemSave:
                    this.cmbCustomerId_OnPM_DataItemSave(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom:
                    this.cmbCustomerId_OnPM_DataItemZoom(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemNew event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cmbCustomerId_OnPM_DataItemNew(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemNew, Sys.wParam, Sys.lParam);
            this.cmbCustomerId.EditDataItemSetEdited();
            e.Return = true;
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemSave event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cmbCustomerId_OnPM_DataItemSave(object sender, WindowActionsEventArgs e)
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
        private void cmbCustomerId_OnPM_DataItemZoom(object sender, WindowActionsEventArgs e)
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
                if (this.sLastChosenCountry != this.cmbCountry.i_sMyValue)
                {
                    this.CountryChanged();
                }
            }
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
                    "                                 SUBSTR(&AO.CORPORATE_FORM_API.Get_Corporate_Form_Desc( " + this.sFullFormName + ".sCountryDb, " + this.sFullFormName + ".dfsCorporateForm),1,50)");
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
            e.Return = false;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void picTab_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_TabActivateFinish:
                    this.picTab_OnPM_TabActivateFinish(sender, e);
                    break;

                case Sys.SAM_Create:
                    this.picTab_OnSAM_Create(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_TabActivateFinish event handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picTab_OnPM_TabActivateFinish(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_TabActivateFinish, Sys.wParam, Sys.lParam);
            this.EnableTabs();
            #endregion
        }

        private void picTab_OnSAM_Create(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Ifs.Fnd.ApplicationForms.Var.Component.IsWindowAvailable(Pal.GetActiveInstanceName("frmCustomerInfoContact")) && Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("frmCustomerInfoContact")))
            {
                //Removed Pal.GetActiveInstanceName() because if there is a customisation in tbwCustomerInfoContact, Pal.GetActiveInstanceName() will return "tbwCustomerInfoContact_Cust" which will not be identified to be replaced.
                //APFRefactoringTool.IgnoreNavigationScan
                picTab.TabSetup = picTab.TabSetup.Replace("tbwCustomerInfoContact", "frmCustomerInfoContact");
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
            SalArray<SalString> sCustomerId = new SalArray<SalString>();
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
                    if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.SourceNameGet() == Pal.GetActiveInstanceName("frmCustomerInfoAddress"))
                    {
                        Sal.WaitCursor(true);
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("CUSTOMER_ID", sCustomerId);
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("ADDRESS_ID", sAddressId);
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.SourceNameSet(Pal.GetActiveInstanceName("frmCustomerInfoAddress"));
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemAdd("CUSTOMER_ID", sCustomerId);
                        InitFromTransferredData();
                        cmbCustomerId.RecordSelectionListSetSelect(0);
                        Sal.WaitCursor(false);
                        frmCustomerInfo.FromHandle(i_hWndFrame).TabSetActive(picTab.FindName("Name1"), true);
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemAdd("ADDRESS_ID", sAddressId);
                        Ifs.Fnd.ApplicationForms.Var.Cache.SessionRetrieve("TargetTab", ref sTarget);
                        if (sTarget == "CustomerGeneralAddressInfo")
                        {
                            if (((this.TabAttachedWindowHandleGet(picTab.FindName("Name1")))) != Sys.hWndNULL)
                            {
                                (frmCustomerInfoAddress.FromHandle(this.TabAttachedWindowHandleGet(picTab.FindName("Name1")))).picTab.BringToTop(0, true);
                            }
                        }
                        Ifs.Fnd.ApplicationForms.Var.Cache.SessionStore("TargetTab", "");
                        return false;
                    }
                    else if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.SourceNameGet() == Pal.GetActiveInstanceName("tbwCustomerInfoContact"))
                    {
                        Sal.WaitCursor(true);
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("CUSTOMER_ID", sCustomerId);
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("PERSON_ID", sPersonId);
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("GUID", sGuid);
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.SourceNameSet(Pal.GetActiveInstanceName("tbwCustomerInfoContact"));
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemAdd("CUSTOMER_ID", sCustomerId);
                        InitFromTransferredData();
                        cmbCustomerId.RecordSelectionListSetSelect(0);
                        Sal.WaitCursor(false);
                        frmCustomerInfo.FromHandle(i_hWndFrame).TabSetActive(picTab.FindName("Name4"), true);
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemAdd("PERSON_ID", sPersonId);
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemAdd("GUID", sGuid);
                        return false;
                    }
                    else
                    {
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemNamesGet(sItems);
                        nIndex = Vis.ArrayFindString(sItems, "CUSTOMER_NO");
                        if (nIndex != -1)
                        {
                            Ifs.Fnd.ApplicationForms.Var.DataTransfer.i_sItemNames[nIndex] = "CUSTOMER_ID";
                        }
                        Sal.SetWindowText(i_hWndFrame, Properties.Resources.HEAD_DetailCustomerInfo);
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

        public override SalBoolean vrtTabActivateFinish(SalWindowHandle hWnd, SalNumber nTab)
        {
            return this.TabActivateFinish(hWnd, nTab);
        }
        #endregion

        #region Event Handlers

        private void menuItem__Copy_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            // TODO: Rewrite command event handler not to use UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            ((FndCommand)sender).Enabled = Sal.SendMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, ((SalString)Pal.GetActiveInstanceName("dlgCopyCustomer")).ToHandle());
        }

        private void menuItem__Copy_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            // TODO: Rewrite command event handler not to make use of UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            Ifs.Fnd.ApplicationForms.Int.PostMessage(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Pal.GetActiveInstanceName("dlgCopyCustomer"));
        }

        /// <summary>
        /// RMB Operation "View End Customer Connections..."
        /// </summary>
        private void cmdEndCustConns_Inquire(object sender, FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = (!(Sal.IsNull(cmbCustomerId))) && (cmbCustomerCategory.i_sMyValue == IIDValues.GetAttribute("CUSTOMER_CATEGORY.CUSTOMER"));
        }

        private void cmdEndCustConns_Execute(object sender, FndCommandExecuteEventArgs e)
        {
            Ifs.Fnd.ApplicationForms.Int.PostMessage(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceCreateWindow, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Pal.GetActiveInstanceName("frmEndCustomerConnection"));

        }

        #endregion

        #region Menu Event Handlers
        private void cmdChangeCategory_Inquire(object sender, FndCommandInquireEventArgs e)
        {
            if (Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0))
            {
                ((FndCommand)sender).Enabled = false;
                return;
            }
            if (!(DataSourceCreateWindow(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Pal.GetActiveInstanceName("dlgChangeCustomerCategory")) == 0))
            {
                if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsPresObjectAvailable(Pal.GetActiveInstanceName("dlgChangeCustomerCategory"))))
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
            ((FndCommand)sender).Enabled = (!(Sal.IsNull(cmbCustomerId))) && (cmbCustomerCategory.i_sMyValue != IIDValues.GetAttribute("CUSTOMER_CATEGORY.CUSTOMER"));
        }

        private void cmdChangeCategory_Execute(object sender, FndCommandExecuteEventArgs e)
        {
            #region Local Variable
            SalWindowHandle hWndFocus = SalWindowHandle.Null;
            SalBoolean bOverwrite = false;
            SalBoolean bTranferAddr = false;
            #endregion

            #region Action
            vrtDataSourcePrepareKeyTransfer(Pal.GetActiveInstanceName("dlgChangeCustomerCategory"));

            Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemAdd("CUSTOMER_ID", new SalArray<SalString>() { cmbCustomerId.Text });
            Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemAdd("CUSTOMER_NAME", new SalArray<SalString>() { dfsName.Text });
            Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemAdd("ASSOCIATION_NO", new SalArray<SalString>() { dfsAssociationNo.Text });
            Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemAdd("CATEGORY", new SalArray<SalString>() { cmbCustomerCategory.Text });
            Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemAdd("CHANGE_CUSTOMER_CATEGORY", new SalArray<SalString>() { "TRUE" });
            Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemAdd("TITLE", new SalArray<SalString>() { Properties.Resources.TITLE_ChangeCustomerCategory });




            if (Sys.IDOK == dlgChangeCustomerCategory.ModalDialog(Sys.hWndMDI, ref bOverwrite, ref bTranferAddr))
            {
                if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.RecCountGet() > 0)
                {
                    SalArray<SalString> items = new SalArray<SalString>();

                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("CUSTOMER_NAME", items);
                    sCustomerName = items[0];

                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("ASSOCIATION_NO", items);
                    sAssociationNo = items[0];

                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("CATEGORY", items);
                    sCustomerCategory = items[0];

                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("TEMPLATE_CUSTOMER_ID", items);
                    sTemplateCustomerId = items[0];

                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("TEMPLATE_COMPANY", items);
                    sTemplateCompany = items[0];

                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();

                    sOverwriteOrderData = Ifs.Fnd.ApplicationForms.Int.PalBooleanToStr(bOverwrite);
                    sTranferAddr = Ifs.Fnd.ApplicationForms.Int.PalBooleanToStr(bTranferAddr);
                    Sal.WaitCursor(true);
                    if (DbPLSQLTransaction(@"&AO.Customer_Info_API.Change_Customer_Category({0} IN, {1} IN, {2} IN, {3} IN, {4} IN, {5} IN, {6} IN, {7} IN);"
                                             , cmbCustomerId.QualifiedBindName, QualifiedVarBindName("sCustomerName"), QualifiedVarBindName("sAssociationNo"), QualifiedVarBindName("sCustomerCategory"), QualifiedVarBindName("sTemplateCustomerId"), QualifiedVarBindName("sTemplateCompany"), QualifiedVarBindName("sOverwriteOrderData"), QualifiedVarBindName("sTranferAddr")))
                    {
                        Sal.WaitCursor(false);
                        hWndFocus = Sal.GetFocus();
                        cmbCustomerId.RecordSelectionListSetSelect(cmbCustomerId.GetSelectedItem());
                        Sal.SetFocus(hWndFocus);
                    }
                    else
                    {
                        Sal.WaitCursor(false);
                    }
                }

            }

            #endregion
        }

        private void cmdManageDataProcessingPurposes_Inquire(object sender, FndCommandInquireEventArgs e)
        {
            #region Action
            if (Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("DATA_SUBJECT_CONSENT_OPER_API.Consent_Action") && !(Sal.IsNull(cmbCustomerId)) && sDataSubjectEnable == "TRUE")
                ((FndCommand)sender).Enabled = true;
            else
                ((FndCommand)sender).Enabled = false;
            #endregion
        }

        private void cmdManageDataProcessingPurposes_Execute(object sender, FndCommandExecuteEventArgs e)
        {
            #region Action
            DbPLSQLBlock(@"{0} := &AO.Data_Subject_Consent_API.Get_Subject_Key_Ref({1} IN,{2} IN, NULL);", this.QualifiedVarBindName("sDataSubjectKeyRef"), this.QualifiedVarBindName("sDataSubjectDb"), this.cmbCustomerId.QualifiedBindName);
            if (dlgPersonalDataConsent.ModalDialog(this, this.sDataSubjectKeyRef, sDataSubjectDb, dfsName.Text) == Sys.IDOK)
            {
                Sal.SendMsg(i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceRefresh, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                return;
            }
            #endregion
        }

        #endregion

        private void cmdViewB2BUsers_Inquire(object sender, FndCommandInquireEventArgs e)
        {
            if (Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0))
            {
                ((FndCommand)sender).Enabled = false;
                return;
            }
            if (!(DataSourceCreateWindow(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Pal.GetActiveInstanceName("tbwB2BCustomerUser")) == 0))
            {
                if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsPresObjectAvailable(Pal.GetActiveInstanceName("tbwB2BCustomerUser"))))
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
            ((FndCommand)sender).Enabled = (!(Sal.IsNull(cmbCustomerId))) && cbB2bCustomer.Checked;
        }

        private void cmdViewB2BUsers_Execute(object sender, FndCommandExecuteEventArgs e)
        {
            #region Local Variables
            SalArray<SalString> sArray = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndArray = new SalArray<SalWindowHandle>();
            #endregion

            #region Actions
            sArray[0] = "CUSTOMER_ID";
            hWndArray[0] = cmbCustomerId;
            Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init(Pal.GetActiveInstanceName("frmCustomerInfo"), this, sArray, hWndArray);
            SessionNavigate(Pal.GetActiveInstanceName("tbwB2BCustomerUser"));
            #endregion
        }

        
    }
}
