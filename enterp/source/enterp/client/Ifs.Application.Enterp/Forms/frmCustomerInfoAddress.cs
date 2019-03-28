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
// 100611   Samblk  Bug 90626, Added missing Class message
// 101012	Kanslk  Bug 93177,Instead of vrtActivate, vrtFrameActivate is used.
// 111116   Nirplk  SFI-701, Merged bug 99501 
// 120809   RuLiLk  Bug 103569, Added SetAddressSelection. Overwrote PM_DataSourcePopulate, InitFromTransferredData. Modified vrtFrameActivate.
// 120821   Hiralk  EDEL-1413, Added validations to coldValidFrom and coldValidTo.
// 121003   Hiralk  Merged bug 104665.
// 121023   MaRalk  PBR-561, Added End customer Id and Address information. Added methods EnableAddressInfo, ValidateEndCustomerConnection.
// 121023           Modified methods InitValuesForPopulate, frmCustomerInfoAddress_OnPM_DataRecordNew.  
// 121023           Modified method tblAddressType_OnPM_DataRecordRemove to restrict deleting delivery type address when end customer is connected.
// 121108   MaRalk  PBR-566, Added method DataSourcePopulateIt to the child table tblAddressType. Added methods EnableEndCustInfo, CheckEndCustDeliveryTypeConnection. Modified methods  
// 121108           frmCustomerInfoAddress_OnPM_DataRecordNew, tblAddressType_OnPM_DataRecordRemove, colsAddressTypeCode_OnPM_DataItemValidate, frmCustomerInfoAddress_OnPM_DataRecordPaste 
// 121108           and FrameStartupUser.
// 121116   MaRalk  PBR-764, Added method CheckEndCustDeliveryTypeAddress.
// 121221   Nirplk  Merged bug 106346.
// 130205   Kagalk  Merged bug 106801.
// 130515   MaRalk  PBR-1605, Added method tblCustomerInfoContact_colsPersonId_OnPM_DataItemLovUserWhere to filter
// 130515           only the Customer Contact check box selected Persons in tblCustomerInfoContact.
// 130529   MaRalk  PBR-1614, Added colsBlockedForUseDb check box to tblCustomerInfoContact. Added method tblCustomerInfoContact_colsPersonId_OnPM_DataItemValidate method.
// 130530   MaIklk  Added CRM related columns Personal Interest, Campaign Interest, Department, Power of Decision and Manager.
// 131129   PRatlk  PBFI-2525 , Client Refactoring in ChildTables in ENTERP.
// 140210   Maabse  Added check if Customer has been created in Method_Inquire for DataRecordNew
// 130313   MaIklk  PBSC-7573, Changed the behaviour of enabling tabs for prospect and end customer.
// 140317   JanWse  PBSC-7421, Get default address for address type 'Delivery' when adding connecting an end customer (dfsEndCustomerId_OnPM_DataItemValidate(
// 140401   Kagalk	PBFI-4142, Merged Bug 113712, Modified to give a warning when deleting the last address type.
// 140704   MaRalk  PRSC-1620, Modified method PersonZoom in order to populate person when zoom from tblCustomerInfoContact.
// 140902   MaIklk  PRSC-2671, Used to check frmCustomerInfoContact is available in order to check crm is installed.
// 141016   JanWse  PRSC-2936, Handle editing of notes of type CLOB in tblCustomerInfoContact
// 160412   reanpl  STRLOC-75, Added handling of new attributes address3, address4, address5, address6
// 161219   AmThLK  STRFI-4160, Merged Bug 132645, Modified tblCommMethod_DataSourcePrepareKeyTransfer().
// 170113  NaJyLK  STRFI-4023,Merged Bug 132505
// 170627   Bhhilk  STRFI-6919, Merged Bug 136450, Modified tblAddressType_OnPM_DataRecordRemove and introduced tblAddressType_CheckTaxInfoExists.
// 171213   Nirylk  STRFI-9846, Merged LCS Bug 137494, Modified tblCustomerInfoContact_colsPersonId_OnPM_DataItemZoom().
// 180517   Chwtlk  Bug 140764, Modified SetAddressSelection().
#endregion

using System;
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
    [FndWindowRegistration("CUSTOMER_INFO_ADDRESS", "CustomerInfoAddress", FndWindowRegistrationFlags.NoSecurity)]
    [FndWindowRegistration("CUST_INFO_CONTACT_LOV_PUB", "frmCustomerInfoAddress", FndWindowRegistrationFlags.HomePage | FndWindowRegistrationFlags.NoSecurity)]
    public partial class frmCustomerInfoAddress : cMasterDetailTabFormWindow
    {
        #region Window Variables
        public SalString __sAddrTypes = "";
        public SalString sFullFormName = "";
        public SalString lsStmt = "";
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
        public SalString sSourceName = "";
        public SalArray<SalString> sAddressId = new SalArray<SalString>();
        public SalString lsAttr = "";
        public SalString sCustomerId = "";
        public SalString sCustomerAddressId = "";
        public SalString sPersonId = "";
        public SalBoolean bPopulate = false;
        public SalString lsAddressLayoutsDbStmt = "";
        public SalString lsLovReferenceDbStmt = "";
        public SalArray<SalString> sResultTemp = new SalArray<SalString>();
        public SalBoolean bIsFromClick = false;
        public SalString sAddressSelection = "";
        public SalNumber nMsgReturn = 0;
        public SalString sExist;
        public SalString sOrderTabActive = "";
        protected SalString sCustomerCategory = "";
        protected SalString sEndCustomerCategory = "";
        public SalString sCustomerCategoryValue = "";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public frmCustomerInfoAddress()
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
        public new static frmCustomerInfoAddress FromHandle(SalWindowHandle handle)
        {
            return ((frmCustomerInfoAddress)SalWindow.FromHandle(handle, typeof(frmCustomerInfoAddress)));
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
                        tblAddressType_sCustomerId[n] = dfsCustomerId.Text;
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
        /// Enable/Disable End Customer Information in the Header.
        /// </summary>
        public virtual void EnableEndCustInfo(SalBoolean bEnable)
        {
            #region Local Variables
            SalBoolean bShowEndCustInfo = (((frmCustomerInfo.FromHandle(i_hWndParent)).cmbCustomerCategory.i_sMyValue) == (this.sCustomerCategory));
            #endregion

            #region Actions
            //Enable the End Customer Information only if the customer category is Customer.
            if (bShowEndCustInfo)
            {
                if (bEnable)
                {
                    Sal.EnableWindowAndLabel(gbEnd_Customer);
                    Sal.EnableWindowAndLabel(dfsEndCustomerId);
                    Sal.EnableWindowAndLabel(dfsEndCustomerName);
                    Sal.EnableWindowAndLabel(dfsEndCustAddrId);
                }
                else
                {
                    Sal.DisableWindowAndLabel(gbEnd_Customer);
                    Sal.DisableWindowAndLabel(dfsEndCustomerId);
                    Sal.DisableWindowAndLabel(dfsEndCustomerName);
                    Sal.DisableWindowAndLabel(dfsEndCustAddrId);
                }
            }
            else
            {
                Sal.DisableWindowAndLabel(gbEnd_Customer);
                Sal.DisableWindowAndLabel(dfsEndCustomerId);
                Sal.DisableWindowAndLabel(dfsEndCustomerName);
                Sal.DisableWindowAndLabel(dfsEndCustAddrId);
            }
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
                return " :i_hWndFrame.frmCustomerInfoAddress.sResultTemp[" + sCount + "] := &AO.Customer_Info_Address_Type_API.Default_Exist (\r\n" + sFullNameTbl + ".tblAddressType_sCustomerId[" + sCount + "] ,\r\n" + sFullNameTbl + ".tblAddressType_sAddressIdTemp[" + sCount + "] ,\r\n" +
                sFullNameTbl + ".tblAddressType_sAddressTypeCode[" + sCount + "]  ); ";
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
                lsAddressLayoutsDbStmt = "&AO.ADDRESS_PRESENTATION_API.Get_All_Layouts(:i_hWndFrame.frmCustomerInfoAddress.sCountry,\r\n" +
                "							:i_hWndFrame.frmCustomerInfoAddress.lsDisplayLayout,\r\n" +
                "							:i_hWndFrame.frmCustomerInfoAddress.lsEditLayout, \r\n" +
                "							:i_hWndFrame.frmCustomerInfoAddress.sCountryCode )";
                lsLovReferenceDbStmt = "&AO.Enterp_Address_Country_API.Set_Lov_Reverence_All(:i_hWndFrame.frmCustomerInfoAddress.sCountryCode,\r\n" +
                "							:i_hWndFrame.frmCustomerInfoAddress.sStateLov,\r\n" +
                "							:i_hWndFrame.frmCustomerInfoAddress.sCountyLov, \r\n" +
                "							:i_hWndFrame.frmCustomerInfoAddress.sCityLov, \r\n" +
                "							:i_hWndFrame.frmCustomerInfoAddress.sZipLov )";
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("Address_Type_Code_API.Enumerate_Type", System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Input);
                    DbPLSQLBlock(cSessionManager.c_hSql, @"&AO.Address_Type_Code_API.Enumerate_Type( :i_hWndFrame.frmCustomerInfoAddress.__sAddrTypes, 'CUSTOMER' ); 
                                                          :i_hWndFrame.frmCustomerInfoAddress.sCustomerCategory := &AO.Customer_Category_API.Decode('CUSTOMER');
                                                          :i_hWndFrame.frmCustomerInfoAddress.sEndCustomerCategory := &AO.Customer_Category_API.Decode('END_CUSTOMER');");
                }
                // Code moved to vrtFrameActivate
            }
            // Hide/Visible according to CRM component is installed.
            tblCustomerInfoContact_HandleCrmColumns();
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
        /// <param name="bExecute">Bug 82153, Begin.</param>
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
                sCountry = frmCustomerInfoAddress.FromHandle(i_hWndFrame).cmbCountry.Text;
                if (sCountry == Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    frmCustomerInfoAddress.FromHandle(i_hWndFrame).cmbCountry.Text = frmCustomerInfo.FromHandle(i_hWndParent).cmbCountry.Text;
                    sCountry = frmCustomerInfo.FromHandle(i_hWndParent).cmbCountry.Text;
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
                "		country_code_	VARCHAR2(10);\r\n	BEGIN " + Vis.StrSubstitute(lsAddressLayoutsDbStmt, ":i_hWndFrame.frmCustomerInfoAddress.sCountryCode", "country_code_") + ";  " + Vis.StrSubstitute(lsLovReferenceDbStmt, ":i_hWndFrame.frmCustomerInfoAddress.sCountryCode",
                    "country_code_") + "; " + ":i_hWndFrame.frmCustomerInfoAddress.sCountryCode := country_code_;\r\n	END;";
                DbPLSQLBlock(cSessionManager.c_hSql, lsStmt);
                EnableAddressInfo();
            }
            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean ValidateEndCustomerConnection()
        {
            #region Local Variables
            SalString lsStmt = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                if (!(Sal.IsNull(dfsEndCustAddrId)))
                {
                    lsStmt = @"BEGIN 
                                   &AO.Customer_Info_Address_API.Exist(:i_hWndFrame.frmCustomerInfoAddress.dfsEndCustomerId IN, :i_hWndFrame.frmCustomerInfoAddress.dfsEndCustAddrId IN);
                                      :i_hWndFrame.frmCustomerInfoAddress.dfsName        := &AO.Customer_Info_Address_API.Get_Name( :i_hWndFrame.frmCustomerInfoAddress.dfsEndCustomerId IN, :i_hWndFrame.frmCustomerInfoAddress.dfsEndCustAddrId IN);
                                      :i_hWndFrame.frmCustomerInfoAddress.dfsAddress1    := &AO.Customer_Info_Address_API.Get_Address1(:i_hWndFrame.frmCustomerInfoAddress.dfsEndCustomerId IN, :i_hWndFrame.frmCustomerInfoAddress.dfsEndCustAddrId IN);
                                      :i_hWndFrame.frmCustomerInfoAddress.dfsAddress2    := &AO.Customer_Info_Address_API.Get_Address2(:i_hWndFrame.frmCustomerInfoAddress.dfsEndCustomerId IN, :i_hWndFrame.frmCustomerInfoAddress.dfsEndCustAddrId IN);
                                      :i_hWndFrame.frmCustomerInfoAddress.dfsAddress3    := &AO.Customer_Info_Address_API.Get_Address3(:i_hWndFrame.frmCustomerInfoAddress.dfsEndCustomerId IN, :i_hWndFrame.frmCustomerInfoAddress.dfsEndCustAddrId IN);
                                      :i_hWndFrame.frmCustomerInfoAddress.dfsAddress4    := &AO.Customer_Info_Address_API.Get_Address4(:i_hWndFrame.frmCustomerInfoAddress.dfsEndCustomerId IN, :i_hWndFrame.frmCustomerInfoAddress.dfsEndCustAddrId IN);
                                      :i_hWndFrame.frmCustomerInfoAddress.dfsAddress5    := &AO.Customer_Info_Address_API.Get_Address5(:i_hWndFrame.frmCustomerInfoAddress.dfsEndCustomerId IN, :i_hWndFrame.frmCustomerInfoAddress.dfsEndCustAddrId IN);
                                      :i_hWndFrame.frmCustomerInfoAddress.dfsAddress6    := &AO.Customer_Info_Address_API.Get_Address6(:i_hWndFrame.frmCustomerInfoAddress.dfsEndCustomerId IN, :i_hWndFrame.frmCustomerInfoAddress.dfsEndCustAddrId IN);
                                      :i_hWndFrame.frmCustomerInfoAddress.dfsZipCode     := &AO.Customer_Info_Address_API.Get_Zip_Code(:i_hWndFrame.frmCustomerInfoAddress.dfsEndCustomerId IN, :i_hWndFrame.frmCustomerInfoAddress.dfsEndCustAddrId IN);
                                      :i_hWndFrame.frmCustomerInfoAddress.dfsCity        := &AO.Customer_Info_Address_API.Get_City(:i_hWndFrame.frmCustomerInfoAddress.dfsEndCustomerId IN, :i_hWndFrame.frmCustomerInfoAddress.dfsEndCustAddrId IN);
                                      :i_hWndFrame.frmCustomerInfoAddress.dfsState       := &AO.Customer_Info_Address_API.Get_State(:i_hWndFrame.frmCustomerInfoAddress.dfsEndCustomerId IN, :i_hWndFrame.frmCustomerInfoAddress.dfsEndCustAddrId IN);
                                      :i_hWndFrame.frmCustomerInfoAddress.dfsCounty      := &AO.Customer_Info_Address_API.Get_County(:i_hWndFrame.frmCustomerInfoAddress.dfsEndCustomerId IN, :i_hWndFrame.frmCustomerInfoAddress.dfsEndCustAddrId IN);
                                      :i_hWndFrame.frmCustomerInfoAddress.dfsCountryCode := &AO.Customer_Info_Address_API.Get_Country_Code(:i_hWndFrame.frmCustomerInfoAddress.dfsEndCustomerId IN, :i_hWndFrame.frmCustomerInfoAddress.dfsEndCustAddrId IN);
                                      :i_hWndFrame.frmCustomerInfoAddress.cmbCountry     := &AO.Customer_Info_Address_API.Get_Country(:i_hWndFrame.frmCustomerInfoAddress.dfsEndCustomerId IN, :i_hWndFrame.frmCustomerInfoAddress.dfsEndCustAddrId IN); 
                                      :i_hWndFrame.frmCustomerInfoAddress.sCustomerCategoryValue := &AO.Customer_Info_API.Get_Customer_Category(:i_hWndFrame.frmCustomerInfoAddress.dfsEndCustomerId IN);  
                               END;";

                    if (!DbPLSQLBlock(cSessionManager.c_hSql, lsStmt))
                    {
                        return false;
                    }
                    if (string.IsNullOrEmpty(dfsName.Text))
                    {
                        dfsName.Text = dfsEndCustomerName.Text;
                    }
                    dfsName.EditDataItemSetEdited();
                    dfsAddress1.EditDataItemSetEdited();
                    dfsAddress2.EditDataItemSetEdited();
                    dfsAddress3.EditDataItemSetEdited();
                    dfsAddress4.EditDataItemSetEdited();
                    dfsAddress5.EditDataItemSetEdited();
                    dfsAddress6.EditDataItemSetEdited();
                    dfsZipCode.EditDataItemSetEdited();
                    dfsCity.EditDataItemSetEdited();
                    dfsState.EditDataItemSetEdited();
                    dfsCounty.EditDataItemSetEdited();
                    dfsCountryCode.EditDataItemSetEdited();
                    cmbCountry.EditDataItemSetEdited();
                    sCountry = cmbCountry.Text;
                    this.SetAddressLayouts();
                    EnableAddressInfo();

                    return true;
                }
                else
                {
                    if (!string.IsNullOrEmpty(dfsEndCustomerName.Text))
                    {
                        dfsName.Text = dfsEndCustomerName.Text;
                    }
                    EnableAddressInfo();
                    return true;
                }
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual void EnableAddressInfo()
        {
            #region Actions
            if (!(Sal.IsNull(dfsEndCustAddrId)))
            {
                Sal.DisableWindow(this.cmbCountry);
                dfsAddress1.EditDataItemFlagSet(Ifs.Fnd.ApplicationForms.Const.FIELD_Update, false);
                dfsAddress2.EditDataItemFlagSet(Ifs.Fnd.ApplicationForms.Const.FIELD_Update, false);
                dfsAddress3.EditDataItemFlagSet(Ifs.Fnd.ApplicationForms.Const.FIELD_Update, false);
                dfsAddress4.EditDataItemFlagSet(Ifs.Fnd.ApplicationForms.Const.FIELD_Update, false);
                dfsAddress5.EditDataItemFlagSet(Ifs.Fnd.ApplicationForms.Const.FIELD_Update, false);
                dfsAddress6.EditDataItemFlagSet(Ifs.Fnd.ApplicationForms.Const.FIELD_Update, false);
                dfsZipCode.EditDataItemFlagSet(Ifs.Fnd.ApplicationForms.Const.FIELD_Update, false);
                dfsCity.EditDataItemFlagSet(Ifs.Fnd.ApplicationForms.Const.FIELD_Update, false);
                dfsState.EditDataItemFlagSet(Ifs.Fnd.ApplicationForms.Const.FIELD_Update, false);
                dfsCounty.EditDataItemFlagSet(Ifs.Fnd.ApplicationForms.Const.FIELD_Update, false);
                dfsCountryCode.EditDataItemFlagSet(Ifs.Fnd.ApplicationForms.Const.FIELD_Update, false);
            }
            else
            {
                Sal.EnableWindow(this.cmbCountry);
                dfsAddress1.EditDataItemFlagSet(Ifs.Fnd.ApplicationForms.Const.FIELD_Update, true);
                dfsAddress2.EditDataItemFlagSet(Ifs.Fnd.ApplicationForms.Const.FIELD_Update, true);
                dfsAddress3.EditDataItemFlagSet(Ifs.Fnd.ApplicationForms.Const.FIELD_Update, true);
                dfsAddress4.EditDataItemFlagSet(Ifs.Fnd.ApplicationForms.Const.FIELD_Update, true);
                dfsAddress5.EditDataItemFlagSet(Ifs.Fnd.ApplicationForms.Const.FIELD_Update, true);
                dfsAddress6.EditDataItemFlagSet(Ifs.Fnd.ApplicationForms.Const.FIELD_Update, true);
                dfsZipCode.EditDataItemFlagSet(Ifs.Fnd.ApplicationForms.Const.FIELD_Update, true);
                dfsCity.EditDataItemFlagSet(Ifs.Fnd.ApplicationForms.Const.FIELD_Update, true);
                dfsState.EditDataItemFlagSet(Ifs.Fnd.ApplicationForms.Const.FIELD_Update, true);
                dfsCounty.EditDataItemFlagSet(Ifs.Fnd.ApplicationForms.Const.FIELD_Update, true);
                dfsCountryCode.EditDataItemFlagSet(Ifs.Fnd.ApplicationForms.Const.FIELD_Update, true);
            }
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
                if (sName == Pal.GetActiveInstanceName("frmCustOrdCustomerAddress"))
                {
                    sOrderTabActive = "TRUE";
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
                // Bug 140764, Begin, Set the sAddressSelection as a bind variable. This will ensure characters like apostrophe to set correctly in the where statement
                lsWhereStmt = "ADDRESS_ID = :i_hWndFrame.frmCustomerInfoAddress.sAddressSelection";
                // Bug 140764, End.
                Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceUserWhere, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, lsWhereStmt.ToHandle());
                // Bug 140764, Removed moved to frmCustomerInfoAddress_OnPM_DataSourcePopulate. Since sAddressSelection is set as a bind variable, setting it to null should takes place after the populate code.
            }

            return 0;
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
            SalNumber nRows = 0;
            SalNumber nColumns = 0;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                nColumns = Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemNamesGet(sSqlColumn);
                nRows = Ifs.Fnd.ApplicationForms.Var.DataTransfer.RecCountGet();
                if ((nRows == 1) && (nColumns == 2) && (Vis.ArrayFindString(sSqlColumn, "ADDRESS_ID") >= 0 || Vis.ArrayFindString(sSqlColumn, "DELIVERY_ADDRESS_ID") >= 0))
                {
                    if (Vis.ArrayFindString(sSqlColumn, "ADDRESS_ID") >= 0)
                    {
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemValueStrGet(Vis.ArrayFindString(sSqlColumn, "ADDRESS_ID"), 0, ref sAddressSelection);
                    }
                    else
                    {
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemValueStrGet(Vis.ArrayFindString(sSqlColumn, "DELIVERY_ADDRESS_ID"), 0, ref sAddressSelection);
                    }
                    return true;
                }
                return ((cMasterDetailTabFormWindow)this).InitFromTransferredData();
            }
            #endregion
        }

        public virtual void RefreshTabs()
        {
            #region Actions
            if (frmCustomerInfo.FromHandle(i_hWndParent).cbOneTimeDb.IsChecked())
            {
                this.picTab.Enable(this.picTab.FindName("frmCustOrdCustomerAddress"), false);
                this.picTab.BringToTop(0, true);
            }
            else if((frmCustomerInfo.FromHandle(i_hWndParent)).cmbCustomerCategory.i_sMyValue != (this.sEndCustomerCategory))
            {
                this.picTab.Enable(this.picTab.FindName("frmCustOrdCustomerAddress"), true);
            }
            #endregion
        }

        public virtual SalBoolean ValidateOneTimeInfo()
        {
            #region Local Variables
            SalArray<SalString> sParam = new SalArray<SalString>(2);
            #endregion

            if (sOrderTabActive == "TRUE")
            {
                if ((Sal.SendMsg(this.TabAttachedWindowHandleGet(this.picTab.FindName("frmCustOrdCustomerAddress")), Ifs.Fnd.ApplicationForms.Const.PM_DataSourceIsDirty, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0)))
                {
                    sParam[0] = dfsCustomerId.Text;
                    sParam[1] = Properties.Resources.TAB_NAME_Order;
                    Ifs.Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.TEXT_InvalidOneTimeCustomer, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok, sParam);
                    return false;
                }
            }
            return true;
        }

        public virtual SalBoolean tblAddressType_CheckTaxInfoExists()
        {
            SalNumber nCurrentRow = Sys.TBL_MinRow;
            tblAddressType.SetRowFlags(tblAddressType.ContextRow, Sys.ROW_Selected, 1);
            while (Sal.TblFindNextRow(tblAddressType, ref nCurrentRow, Sys.ROW_Selected, 0))
            {
                Sal.TblSetContext(tblAddressType, nCurrentRow);
                if (this.tblAddressType_colsAddressTypeCodeDb.Text == "DELIVERY")
                {
                    if (!DbPLSQLBlock(@"&AO.Customer_Info_Address_Type_API.Check_Del_Tax_Info_Exist__({0} IN, {1} IN);", this.tblAddressType_colsCustomerId.QualifiedBindName, this.tblAddressType_colsAddressId.QualifiedBindName))
                    {
                        return true;
                    }
                }
                else if (this.tblAddressType_colsAddressTypeCodeDb.Text == "INVOICE")
                {
                    if (!DbPLSQLBlock(@"&AO.Customer_Info_Address_Type_API.Check_Doc_Tax_Info_Exist__({0} IN, {1} IN);", this.tblAddressType_colsCustomerId.QualifiedBindName, this.tblAddressType_colsAddressId.QualifiedBindName))
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
        private void frmCustomerInfoAddress_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew:
                    this.frmCustomerInfoAddress_OnPM_DataRecordNew(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate:
                    this.frmCustomerInfoAddress_OnPM_DataRecordDuplicate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordPaste:
                    this.frmCustomerInfoAddress_OnPM_DataRecordPaste(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_TabAttachedWindowActivate:
                    e.Handled = true;
                    this.lsStmt = "&AO.Address_Type_Code_API.Enumerate_Type( i_hWndFrame.frmCustomerInfoAddress.__sAddrTypes, \"CUSTOMER\" )";
                    break;

                case Sys.SAM_Create:
                    this.frmCustomerInfoAddress_OnSAM_Create(sender, e);
                    break;


                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRemove:
                    this.frmCustomerInfoAddress_OnPM_DataRecordRemove(sender, e);
                    break;




                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate:
                    this.frmCustomerInfoAddress_OnPM_DataSourcePopulate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_User:
                    this.frmCustomerInfoAddress_OnPM_User(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataRecordNew event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmCustomerInfoAddress_OnPM_DataRecordNew(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;

            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Sys.wParam, Sys.lParam))
            {
                if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)
                {
                    if (SendMessageToParent(Const.PAM_RecordNotInitiallySaved, 0, 0))
                    {
                        e.Return = false;
                        return;
                    }
                }
                else if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                {
                    Sal.SendMsg(this.cmbCountry, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, ((SalString)frmCustomerInfo.FromHandle(this.i_hWndParent).cmbCountry.Text).ToHandle());
                    sOldCountry = SalString.Null;
                    this.SetCountry();
                    this.EnableAddressInfo();
                    this.EnableEndCustInfo(true);
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
        private void frmCustomerInfoAddress_OnPM_DataRecordDuplicate(object sender, WindowActionsEventArgs e)
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
        /// PM_DataRecordPaste event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmCustomerInfoAddress_OnPM_DataRecordPaste(object sender, WindowActionsEventArgs e)
        {
            #region Local Variables
            SalString lsStmt = "";
            #endregion

            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordPaste, Sys.wParam, Sys.lParam))
            {
                if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                {
                    EnableAddressInfo();
                    if (!(Sal.IsNull(dfsEndCustomerId)))
                    {
                        lsStmt = @"BEGIN 
                                  :i_hWndFrame.frmCustomerInfoAddress.cmbCountry  := &AO.Customer_Info_Address_API.Get_Country(:i_hWndFrame.frmCustomerInfoAddress.dfsEndCustomerId IN, :i_hWndFrame.frmCustomerInfoAddress.dfsEndCustAddrId IN); 
                               END;";

                        DbPLSQLBlock(cSessionManager.c_hSql, lsStmt);
                        cmbCountry.EditDataItemSetEdited();
                        sCountry = cmbCountry.Text;
                    }
                    else
                    {
                        this.SetCountry();
                    }
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
        /// SAM_Create event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmCustomerInfoAddress_OnSAM_Create(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam);
            // The variables are not updated after creation. No need to move to vrtActivate
            this.sFullFormName = ":i_hWndFrame." + Ifs.Fnd.ApplicationForms.Int.QualifiedItemNameGet(this);
            this.sCustomerId = frmCustomerInfo.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(this.i_hWndSelf)).cmbCustomerId.i_sMyValue;
            #endregion
        }

        /// <summary>
        /// PM_DataRecordRemove event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmCustomerInfoAddress_OnPM_DataRecordRemove(object sender, WindowActionsEventArgs e)
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
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void dfsEndCustomerId_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.dfsEndCustomerId_OnPM_DataItemValidate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovUserWhere:
                    this.dfsEndCustomerId_OnPM_DataItemLovUserWhere(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.dfsEndCustomerId_OnPM_DataItemQueryEnabled(sender, e);
                    break;

            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsEndCustomerId_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Local Variables
            SalArray<SalString> sMessage = new SalArray<SalString>();
            #endregion

            #region Actions
            e.Handled = true;
            
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam) == Sys.VALIDATE_Cancel)
            {
                e.Return = Sys.VALIDATE_Cancel;
                return;
            }

            if (Sys.wParam)
            {
                if ( this.dfsEndCustomerId.Text == Sys.STRING_Null )
                {
                    dfsEndCustAddrId.Text = Sys.STRING_Null;
                    dfsEndCustAddrId.EditDataItemSetEdited();
                }
                else
                {
                    DbPLSQLBlock(@"DECLARE
                                    addr_type_  VARCHAR2(50);
                                BEGIN
                                    addr_type_ := &AO.Address_Type_Code_API.Decode('DELIVERY');
                                    {0} := &AO.Customer_Info_Address_API.Get_Default_Address({1} IN, addr_type_);                                
                                END;",
                                this.dfsEndCustAddrId.QualifiedBindName,
                                this.dfsEndCustomerId.QualifiedBindName); 

                    this.ValidateEndCustomerConnection();
                    dfsEndCustAddrId.EditDataItemSetEdited();
                    if ((this.dfsEndCustAddrId.Text != Sys.STRING_Null) && (this.sCustomerCategoryValue != (this.sEndCustomerCategory)))
                    {
                        sMessage[0] = this.dfsEndCustAddrId.Text;
                        Ifs.Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.TEXT_EndCustChanged, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok, sMessage);
                    }
                }                
            }
            Sal.SetFocus(this.dfsEndCustAddrId);
            e.Return = Sys.VALIDATE_Ok;
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemLovUserWhere event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsEndCustomerId_OnPM_DataItemLovUserWhere(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            e.Return = ((SalString)("(CUSTOMER_ID != '" + this.dfsCustomerId.Text) + "' AND ONE_TIME_DB = 'FALSE')").ToHandle();
            return;
            #endregion
        }

        private void dfsEndCustomerId_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (frmCustomerInfo.FromHandle(i_hWndParent).cbOneTimeDb.IsChecked())
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                return;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void dfsEndCustAddrId_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.dfsEndCustAddrId_OnPM_DataItemValidate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom:
                    this.dfsEndCustAddrId_OnPM_DataItemZoom(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.dfsEndCustAddrId_OnPM_DataItemQueryEnabled(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsEndCustAddrId_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Local Variables
            SalString lsStmt = "";
            SalArray<SalString> sMessage = new SalArray<SalString>();
            #endregion

            #region Actions
            if (Sys.wParam)
            {
                if (this.ValidateEndCustomerConnection())
                {
                    e.Return = Sys.VALIDATE_Ok;
                    if ((this.dfsEndCustAddrId.Text != Sys.STRING_Null) && (this.sCustomerCategoryValue != (this.sEndCustomerCategory)))
                    {
                        sMessage[0] = this.dfsEndCustAddrId.Text;
                        Ifs.Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.TEXT_EndCustChanged, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok, sMessage);
                    }
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
        /// PM_DataItemZoom event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsEndCustAddrId_OnPM_DataItemZoom(object sender, WindowActionsEventArgs e)
        {
            #region Local Variables
            SalArray<SalString> sItemNames = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
            #endregion

            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)
            {
                e.Return = true;
                return;
            }
            else if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                sItemNames[0] = "CUSTOMER_ID";
                hWndItems[0] = dfsEndCustomerId;
                sItemNames[1] = "ADDRESS_ID";
                hWndItems[1] = dfsEndCustAddrId;
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init(Pal.GetActiveInstanceName("frmCustomerInfoAddress"), this, sItemNames, hWndItems);
                SessionNavigate(Pal.GetActiveInstanceName("frmCustomerInfo"));
                e.Return = true;
                return;
            }
            #endregion
        }

        private void dfsEndCustAddrId_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (frmCustomerInfo.FromHandle(i_hWndParent).cbOneTimeDb.IsChecked() || (this.dfsEndCustomerId.Text == Sys.STRING_Null))
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                return;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataSourcePopulate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmCustomerInfoAddress_OnPM_DataSourcePopulate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.sAddressSelection != Ifs.Fnd.ApplicationForms.Const.strNULL && Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                this.SetAddressSelection();
            }
            this.nMsgReturn = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Sys.wParam, Sys.lParam);
            // Bug 140764, Begin.
            sAddressSelection = Ifs.Fnd.ApplicationForms.Const.strNULL;
            // Bug 140764, End.
            e.Return = this.nMsgReturn;
            return;
            #endregion
        }

        private void frmCustomerInfoAddress_OnPM_User(object sender, WindowActionsEventArgs e)
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
            // not updated after creation. No need to move to vrtActivate
            this.sFullNameTbl = ":i_hWndFrame." + Ifs.Fnd.ApplicationForms.Int.QualifiedItemNameGet(this);
            #endregion
        }

        /// <summary>
        /// PM_DataRecordRemove event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblAddressType_OnPM_DataRecordRemove(object sender, WindowActionsEventArgs e)
        {
            #region Local Variables
            SalNumber nRow = Sys.TBL_MinRow;
            SalBoolean bFound = false;
            #endregion

            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                if (!tblAddressType_CheckTaxInfoExists() && this.tblAddressType_CheckEndCustDeliveryTypeConnection())
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
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                while (Sal.TblFindNextRow(this.tblAddressType, ref nRow, 0, 0))
                {
                    Sal.TblSetContext(Sys.hWndForm, nRow);

                    if (this.tblAddressType_colsAddressTypeCodeDb.Text == "DELIVERY")
                    {
                        bFound = true;
                        if (Sal.TblQueryRowFlags(Sys.hWndForm, nRow, Sys.ROW_MarkDeleted))
                        {
                            this.EnableEndCustInfo(false);
                        }
                        else
                        {
                            this.EnableEndCustInfo(true);
                        }
                    }
                }
                if (!bFound)
                {
                    this.EnableEndCustInfo(false);
                }
            }

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
                        DbPLSQLBlock(cSessionManager.c_hSql, " BEGIN :i_hWndFrame.frmCustomerInfoAddress.sExist := &AO.Comm_Method_API.Comm_Id_Exist(\r\n" +
                                                             "		:i_hWndFrame.frmCustomerInfoAddress.tblCommMethod.colsIdentity IN,\r\n" +
                                                             "		:i_hWndFrame.frmCustomerInfoAddress.tblCommMethod.colsPartyType IN,\r\n" +
                                                             "		:i_hWndFrame.frmCustomerInfoAddress.tblCommMethod.colnCommId IN); END;\r\n");
                        if (sExist == "TRUE")
                        {
                            sDefMethList[0] = this.tblCommMethod.colnCommId.Text;
                            if (Ifs.Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.TEXT_CannotChangeValidFromDate, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Warning, Ifs.Fnd.ApplicationForms.Const.WARNING_YesNo, sDefMethList) == Sys.IDNO)
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
                        DbPLSQLBlock(cSessionManager.c_hSql, " BEGIN :i_hWndFrame.frmCustomerInfoAddress.sExist := &AO.Comm_Method_API.Comm_Id_Exist(\r\n" +
                                                             "		 :i_hWndFrame.frmCustomerInfoAddress.tblCommMethod.colsIdentity,\r\n" +
                                                             "		 :i_hWndFrame.frmCustomerInfoAddress.tblCommMethod.colsPartyType,\r\n" +
                                                             "		 :i_hWndFrame.frmCustomerInfoAddress.tblCommMethod.colnCommId); END;\r\n");
                        if (sExist == "TRUE")
                        {
                            sDefMethList[0] = this.tblCommMethod.colnCommId.Text;
                            if (Ifs.Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.TEXT_CannotChangeValidToDate, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Warning, Ifs.Fnd.ApplicationForms.Const.WARNING_YesNo, sDefMethList) == Sys.IDNO)
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

        private void tblCustomerInfoContact_colsPersonId_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblCustomerInfoContact_colsPersonId_OnPM_DataItemValidate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovUserWhere:
                    this.tblCustomerInfoContact_colsPersonId_OnPM_DataItemLovUserWhere(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom:
                    this.tblCustomerInfoContact_colsPersonId_OnPM_DataItemZoom(sender, e);
                    break;
            }
            #endregion
        }

        private void tblCustomerInfoContact_colsPersonId_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {

        }

        private void tblCustomerInfoContact_colsPersonId_OnPM_DataItemLovUserWhere(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            e.Return = ((SalString)"CUSTOMER_CONTACT_DB='TRUE' AND BLOCKED_FOR_USE_DB='FALSE'").ToHandle();
            return;
            #endregion
        }

        private void tblCustomerInfoContact_colsPersonId_OnPM_DataItemZoom(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;

            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                this.PersonZoom();
                e.Return = true;
                return;
            }
            else if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)
            {
                e.Return = tblCustomerInfoContact.CanDataTransferTo(Pal.GetActiveInstanceName("frmPersonInfo"));
                return;
            }
            else
            {
                e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom, Sys.wParam, Sys.lParam);
                return;
            }
            #endregion
        }

        private void tblCustomerInfoContact_colsManager_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovDone:
                    this.tblCustomerInfoContact_colsManager_OnPM_DataItemLovDone(sender, e);
                    break;
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblCustomerInfoContact_colsManager_OnPM_DataItemValidate(sender, e);
                    break;

            }
            #endregion
        }

        private void tblCustomerInfoContact_colsManager_OnPM_DataItemLovDone(object sender, WindowActionsEventArgs e)
        {

            #region Actions
            e.Handled = true;
            Sal.SendMsg(this.tblCustomerInfoContact_colsManager, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, Vis.StrSubstitute(Ifs.Fnd.ApplicationForms.Int.PalAttrGet("PERSON_ID", SalString.FromHandle(Sys.lParam)), ((SalNumber)31).ToCharacter(), "").ToHandle());
            Sal.SendMsg(this.tblCustomerInfoContact_colsManagerCustAddress, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, Vis.StrSubstitute(Ifs.Fnd.ApplicationForms.Int.PalAttrGet("CUSTOMER_ADDRESS", SalString.FromHandle(Sys.lParam)), ((SalNumber)31).ToCharacter(), "").ToHandle());
            #endregion
        }

        private void tblCustomerInfoContact_colsManager_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Local Variables
            IDictionary<string, string> namedBindVariables = new Dictionary<string, string>();
            #endregion

            #region Actions
            e.Handled = true;

            if (Sys.wParam)
            {
                Sal.WaitCursor(true);
                tblCustomerInfoContact_nFound = 0;
                if (tblCustomerInfoContact_colsManager.Text == Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    tblCustomerInfoContact_colsManagerGuid.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                    tblCustomerInfoContact_colsManagerGuid.EditDataItemSetEdited();
                    tblCustomerInfoContact_colsManagerCustAddress.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                    tblCustomerInfoContact_colsManagerCustAddress.EditDataItemSetEdited();
                    e.Return = Sys.VALIDATE_Ok;
                    return;
                }

                namedBindVariables.Add("ManagerCustAddress", tblCustomerInfoContact_colsManagerCustAddress.QualifiedBindName);
                namedBindVariables.Add("Found", this.QualifiedVarBindName("tblCustomerInfoContact_nFound"));
                namedBindVariables.Add("CustomerId", tblCustomerInfoContact_colsCustomerId.QualifiedBindName);
                namedBindVariables.Add("Manager", tblCustomerInfoContact_colsManager.QualifiedBindName);
                namedBindVariables.Add("ManagerGuid", tblCustomerInfoContact_colsManagerGuid.QualifiedBindName);
                namedBindVariables.Add("ManagerName", tblCustomerInfoContact_colsManagerName.QualifiedBindName);

                lsStmt = @"BEGIN 
                                IF {ManagerCustAddress} IS NULL THEN
                                &AO.Customer_Info_Contact_API.Validate_Customer_Address( {Found} OUT, {ManagerCustAddress} OUT, {CustomerId} IN, {Manager} IN); 
                                END IF;
                                {ManagerGuid} :=  &AO.Customer_Info_Contact_API.Get_Guid_By_Cust_Address( {CustomerId} IN, {Manager} IN, {ManagerCustAddress} IN);
                                {ManagerName} :=  &AO.Person_Info_API.Get_Name( {Manager} IN );                                                                                         
                           END;";
                if (DbPLSQLBlock(lsStmt, namedBindVariables))
                {
                    if (this.tblCustomerInfoContact_nFound > 1)
                    {
                        Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_ManyContactAddress, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                    }
                    else
                    {
                        tblCustomerInfoContact_colsManagerGuid.EditDataItemSetEdited();
                        tblCustomerInfoContact_colsManagerCustAddress.EditDataItemSetEdited();
                    }
                }
                Sal.WaitCursor(false);
            }

            e.Return = Sys.VALIDATE_Ok;
            return;

            #endregion
        }

        private void tblCustomerInfoContact_colsManagerCustAddress_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovDone:
                    this.tblCustomerInfoContact_colsManagerCustAddress_OnPM_DataItemLovDone(sender, e);
                    break;
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovUserWhere:
                    this.tblCustomerInfoContact_colsManagerCustAddress_OnPM_DataItemLovUserWhere(sender, e);
                    break;
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblCustomerInfoContact_colsManagerCustAddress_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        private void tblCustomerInfoContact_colsManagerCustAddress_OnPM_DataItemLovDone(object sender, WindowActionsEventArgs e)
        {

            #region Actions
            e.Handled = true;
            Sal.SendMsg(this.tblCustomerInfoContact_colsManagerCustAddress, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, Vis.StrSubstitute(Ifs.Fnd.ApplicationForms.Int.PalAttrGet("CUSTOMER_ADDRESS", SalString.FromHandle(Sys.lParam)), ((SalNumber)31).ToCharacter(), "").ToHandle());
            #endregion
        }

        private void tblCustomerInfoContact_colsManagerCustAddress_OnPM_DataItemLovUserWhere(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (tblCustomerInfoContact_colsManager.Text != SalString.Null)
            {
                e.Return = ((SalString)"PERSON_ID= '" + tblCustomerInfoContact_colsManager.Text + "'").ToHandle();
                return;
            }
            e.Return = true;
            return;
            #endregion
        }

        private void tblCustomerInfoContact_colsManagerCustAddress_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Local Variables
            IDictionary<string, string> namedBindVariables = new Dictionary<string, string>();
            #endregion

            #region Actions
            e.Handled = true;

            if (Sys.wParam)
            {                
                Sal.WaitCursor(true);
                namedBindVariables.Add("ManagerCustAddress", tblCustomerInfoContact_colsManagerCustAddress.QualifiedBindName);                
                namedBindVariables.Add("CustomerId", tblCustomerInfoContact_colsCustomerId.QualifiedBindName);
                namedBindVariables.Add("Manager", tblCustomerInfoContact_colsManager.QualifiedBindName);
                namedBindVariables.Add("ManagerGuid", tblCustomerInfoContact_colsManagerGuid.QualifiedBindName);
                
                lsStmt = @"BEGIN                                  
                               {ManagerGuid} :=  &AO.Customer_Info_Contact_API.Get_Guid_By_Cust_Address({CustomerId} IN, {Manager} IN, {ManagerCustAddress} IN);
                           END;";
                if (DbPLSQLBlock(lsStmt, namedBindVariables))
                {
                    tblCustomerInfoContact_colsManagerGuid.EditDataItemSetEdited();
                }
                Sal.WaitCursor(false);
            }

            e.Return = Sys.VALIDATE_Ok;
            return;

            #endregion
        }

        private void tblCustomerInfoContact_colsMainRepresentativeId_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom:
                    this.tblCustomerInfoContact_colsMainRepresentativeId_OnPM_DataItemZoom(sender, e);
                    break;
            }
            #endregion
        }

        private void tblCustomerInfoContact_colsMainRepresentativeId_OnPM_DataItemZoom(object sender, WindowActionsEventArgs e)
        {
            #region Local Variables
            SalArray<SalString> sItemNames = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
            #endregion

            #region Actions
            e.Handled = true;

            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                sItemNames[0] = "REPRESENTATIVE_ID";
                hWndItems[0] = tblCustomerInfoContact_colsMainRepresentativeId;
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("REPRESENTATIVE_ID", tblCustomerInfoContact, sItemNames, hWndItems);
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.TypeSet("ZOOM");
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.i_sDestination = "BUSINESS_REPRESENTATIVE";
                SessionNavigate(Pal.GetActiveInstanceName("frmRelMgtBasic"));
                e.Return = true;
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
        /// </summary>
        /// <returns></returns>
        public override SalNumber vrtFrameActivate()
        {
            using (new SalContext(this))
            {
                sSourceName = Ifs.Fnd.ApplicationForms.Var.DataTransfer.SourceNameGet();
                
                if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.RecCountGet() > 0)
                {
                    Sal.WaitCursor(true);
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("ADDRESS_ID", sAddressId);
                    if (sAddressId[0].Value != Sys.STRING_Null)
                    {
                        lsStmt = " ADDRESS_ID = :i_hWndFrame.frmCustomerInfoAddress.sAddressId[0]";
                        Sal.SendMsg(i_hWndFrame, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceUserWhere, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, lsStmt.ToHandle());
                    }
                    InitFromTransferredData();
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
                    Sal.WaitCursor(false);
                    return false;
                }                
                
                else
                {
                    Sal.WaitCursor(false);
                    return true;
                }
                
                return base.FrameActivate();
            }
        }
        public override SalBoolean vrtTabActivateStart(SalWindowHandle hWnd, SalNumber nTab)
        {
            return this.TabActivateStart(hWnd, nTab);
        }
        public override SalBoolean vrtDataSourceSaveNew()
        {
            SalBoolean bOk = base.vrtDataSourceSaveNew();
            if (bOk)
            {
                bOk = AddNote(Sys.ROW_New, 0);
                if (!(Sal.IsNull(dfsEndCustomerId)) && ((this.dfsEndCustomerId.IsModified() || this.dfsEndCustAddrId.IsModified())))
                {
                    Sal.SendMsgToChildren(this, Ifs.Application.Enterp.Const.PAM_SetOrderAddressInfoOnSave, 0, 0);
                }
            }
            return bOk;
        }
        public override SalBoolean vrtDataSourceSaveModified()
        {
            SalBoolean bOk = base.vrtDataSourceSaveModified();
            if (bOk)
            {
                bOk = AddNote(Sys.ROW_Edited, Sys.ROW_New);
                if (!(Sal.IsNull(dfsEndCustomerId)) && ((this.dfsEndCustomerId.IsModified() || this.dfsEndCustAddrId.IsModified())))
                {
                    Sal.SendMsgToChildren(this, Ifs.Application.Enterp.Const.PAM_SetOrderAddressInfoOnSave, 0, 0);
                }
            }
            return bOk;
        }
        #endregion

        #region ChildTable - tblAddressType

        #region Window Variables
        public SalArray<SalString> tblAddressType_sCustomerId = new SalArray<SalString>();
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
        public SalString tblAddressType_sTempCustomer = "";
        protected Boolean tblAddressType_bDeliveryExist = true;
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
        /// Late bound function for DataSourcePopulateIt
        /// </summary>
        /// <param name="hSql"></param>
        /// <returns></returns>            
        public virtual SalBoolean tblAddressType_DataSourcePopulateIt(SalNumber nParam)
        {
            #region Local Variables
            SalNumber nCurrentRow = 0;
            SalBoolean bHavingDeliveryAddr = false;
            SalBoolean bRet = false;
            #endregion

            #region Actions
            bRet = ((cChildTable)this.tblAddressType).DataSourcePopulateIt(nParam);
            nCurrentRow = Sys.TBL_MinRow;
            while (Sal.TblFindNextRow(tblAddressType, ref nCurrentRow, 0, 0))
            {

                Sal.TblSetContext(tblAddressType, nCurrentRow);
                if (this.tblAddressType_colsAddressTypeCodeDb.Text == "DELIVERY")
                {
                    bHavingDeliveryAddr = true;
                    break;
                }

            }
            // if 'Delievry' address type exists, enable the end customer information in the header. if not disable.
            EnableEndCustInfo(bHavingDeliveryAddr);
            return bRet;
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
                tblAddressType_sTempCustomer = SalString.Null;
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
                        lsStmt = lsStmt + "&AO.CUSTOMER_INFO_ADDRESS_TYPE_API.Check_Def_Address_Exist (\r\n" +
                        "                                                                                                                        :i_hWndFrame.frmCustomerInfoAddress.tblAddressType_sTempAddressValidation[" + nIndex.ToString(0) + "] OUT ,\r\n" +
                        "                                                                                                                        :i_hWndFrame.frmCustomerInfoAddress.tblAddressType_sValidFlag[" + nIndex.ToString(0) + "] OUT ,\r\n" +
                        "                                                                                                                        :i_hWndFrame.frmCustomerInfoAddress.tblAddressType_sTempCustomer IN ,\r\n" +
                        "                                                                                                                        :i_hWndFrame.frmCustomerInfoAddress.tblAddressType_sDefAddress[" + nIndex.ToString(0) + "] IN ,\r\n" +
                        "                                                                                                                        :i_hWndFrame.frmCustomerInfoAddress.tblAddressType_sAddressTypeCodeArr[" + nIndex.ToString(0) + "] IN ,\r\n" +
                        "                                                                                                                        :i_hWndFrame.frmCustomerInfoAddress.tblAddressType_sObjId[" + nIndex.ToString(0) + "] IN ,\r\n" +
                        "                                                                                                                        :i_hWndFrame.frmCustomerInfoAddress.tblAddressType_dTempFromDate[" + nIndex.ToString(0) + "] IN,\r\n" +
                        "                                                                                                                        :i_hWndFrame.frmCustomerInfoAddress.tblAddressType_dTempToDate[" + nIndex.ToString(0) + "] IN );";
                        tblAddressType_sAddressId[nIndex] = this.tblAddressType_colsAddressId.Text;
                        tblAddressType_sAddressTypeCodeArr[nIndex] = this.tblAddressType_colsAddressTypeCode.Text;
                        tblAddressType_sDefAddress[nIndex] = this.tblAddressType_colDefAddress.Text;
                        tblAddressType_sObjId[nIndex] = this.tblAddressType.__colObjid.Text;
                        tblAddressType_sTempCustomer = this.tblAddressType_colsCustomerId.Text;
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
                sAddressTypeCodeMsg[2] = this.tblAddressType_colsCustomerId.Text;
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
                tblAddressType_sTempCustomer = SalString.Null;
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
                            lsStmt = lsStmt + "&AO.CUSTOMER_INFO_ADDRESS_TYPE_API.Check_Def_Address_Exist (\r\n" +
                                                                                                           ":i_hWndFrame.frmCustomerInfoAddress.tblAddressType_sTempAddressValidation[" + nIndex.ToString(0) + "] OUT,\r\n" +
                                                                                                           ":i_hWndFrame.frmCustomerInfoAddress.tblAddressType_sValidFlag[" + nIndex.ToString(0) + "] OUT ,\r\n" +
                                                                                                           ":i_hWndFrame.frmCustomerInfoAddress.tblAddressType_sTempCustomer IN ,\r\n" +
                                                                                                           ":i_hWndFrame.frmCustomerInfoAddress.tblAddressType_sDefAddress[" + nIndex.ToString(0) + "] IN ,\r\n" +
                                                                                                           ":i_hWndFrame.frmCustomerInfoAddress.tblAddressType_sAddressTypeCodeArr[" + nIndex.ToString(0) + "] IN ,\r\n" +
                                                                                                           ":i_hWndFrame.frmCustomerInfoAddress.tblAddressType_sObjId[" + nIndex.ToString(0) + "] IN ,\r\n" +
                                                                                                           ":i_hWndFrame.frmCustomerInfoAddress.tblAddressType_dTempFromDate[" + ((SalNumber)0).ToString(0) + "] IN ,\r\n" +
                                                                                                           ":i_hWndFrame.frmCustomerInfoAddress.tblAddressType_dTempToDate[" + ((SalNumber)0).ToString(0) + "]  IN );";
                            tblAddressType_sAddressId[nIndex] = this.tblAddressType_colsAddressId.Text;
                            tblAddressType_sAddressTypeCodeArr[nIndex] = this.tblAddressType_colsAddressTypeCode.Text;
                            tblAddressType_sDefAddress[nIndex] = this.tblAddressType_colDefAddress.Text;
                            tblAddressType_sObjId[nIndex] = this.tblAddressType.__colObjid.Text;
                            tblAddressType_sTempCustomer = this.tblAddressType_colsCustomerId.Text;
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
                sAddressTypeCodeMsg[2] = this.tblAddressType_colsCustomerId.Text;
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
                    sMessage[2] = this.tblAddressType_colsCustomerId.Text;
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
                tblAddressType_sTempCustomer = SalString.Null;
                nCount = tblAddressType_sTempAddressValidation.GetUpperBound(1);
                lsStmt = SalString.Null;
                while (nIndex <= nCount)
                {
                    if (tblAddressType_sTempAddressValidation[nIndex] == "FALSE")
                    {
                        lsStmt = lsStmt + "&AO.CUSTOMER_INFO_ADDRESS_TYPE_API.Check_Def_Addr_Temp (:i_hWndFrame.frmCustomerInfoAddress.tblAddressType_sTempCustomer IN ,\r\n" +
                                                                                                  ":i_hWndFrame.frmCustomerInfoAddress.tblAddressType_sAddressTypeCodeArr[" + nIndex.ToString(0) + "] IN ,\r\n" +
                                                                                                  ":i_hWndFrame.frmCustomerInfoAddress.tblAddressType_sDefAddress[" + nIndex.ToString(0) + "] IN ,\r\n" +
                                                                                                  ":i_hWndFrame.frmCustomerInfoAddress.tblAddressType_sObjId[" + nIndex.ToString(0) + "] IN ,\r\n" +
                                                                                                  ":i_hWndFrame.frmCustomerInfoAddress.tblAddressType_dTempFromDate[" + nIndex.ToString(0) + "] IN ,\r\n" +
                                                                                                  ":i_hWndFrame.frmCustomerInfoAddress.tblAddressType_dTempToDate[" + nIndex.ToString(0) + "] IN ); ";
                        tblAddressType_dTempFromDate[nIndex] = this.dfdValidFrom.DateTime;
                        tblAddressType_dTempToDate[nIndex] = this.dfdValidTo.DateTime;
                        tblAddressType_sTempCustomer = this.tblAddressType_colsCustomerId.Text;
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
                    sItemNames[2] = "CUSTOMER_ID";
                    hWndItems[2] = tblAddressType_colsCustomerId;
                }
                else
                {
                    return ((cDataSource)this.tblAddressType).DataSourcePrepareKeyTransfer(sWindowName);
                }
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("CustomerInfoAddressType", Sys.hWndForm, sItemNames, hWndItems);
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.TypeSet("CREATE_WINDOW");
            }

            return 0;
            #endregion
        }


        public virtual SalBoolean tblAddressType_ValidateAddressType()
        {
            #region Local Variables
            IDictionary<string, string> namedBindVariables = new Dictionary<string, string>();
            #endregion

            #region Actions
            namedBindVariables.Add("AddressTypeCodeDb", tblAddressType_colsAddressTypeCodeDb.QualifiedBindName);
            namedBindVariables.Add("AddressTypeCode", tblAddressType_colsAddressTypeCode.QualifiedBindName);

            DbPLSQLBlock("{AddressTypeCodeDb}:= &AO.ADDRESS_TYPE_CODE_API.Encode( {AddressTypeCode} IN );", namedBindVariables);

            if (this.tblAddressType_colsAddressTypeCodeDb.Text == "DELIVERY")
            {
                EnableEndCustInfo(false);
            }

            return true;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>            
        public virtual SalBoolean tblAddressType_CheckEndCustDeliveryTypeConnection()
        {
            #region Local Variables
            SalNumber nCurrentRow = 0;
            #endregion

            #region Actions
            nCurrentRow = Sys.TBL_MinRow;
            while (Sal.TblFindNextRow(tblAddressType, ref nCurrentRow, Sys.ROW_Selected, 0))
            {
                Sal.TblSetContext(tblAddressType, nCurrentRow);
                if ((!(Sal.IsNull(this.dfsEndCustAddrId))) && (this.tblAddressType_colsAddressTypeCodeDb.Text == "DELIVERY"))
                {
                    Ifs.Fnd.ApplicationForms.Int.PalMessageBox(Properties.Resources.TEXT_CannotDelDelivAddr, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
                    return false;
                }
            }
            return true;
            #endregion

        }

        /// <summary>
        /// </summary>
        /// <returns></returns>            
        public virtual SalBoolean tblAddressType_CheckEndCustDeliveryTypeAddress()
        {
            #region Local Variables
            SalNumber nSelectedRow = Sys.TBL_MinRow;
            SalNumber nRow = Sys.TBL_MinRow;
            SalBoolean bDelAddrFound = false;
            #endregion

            #region Actions
            nSelectedRow = Sal.TblQueryContext(tblAddressType);
            while (Sal.TblFindNextRow(tblAddressType, ref nRow, 0, 0))
            {
                Sal.TblSetContext(tblAddressType, nRow);
                if (this.tblAddressType_colsAddressTypeCodeDb.Text == "DELIVERY")
                {
                    bDelAddrFound = true;
                    break;
                }
            }
            Sal.TblSetContext(tblAddressType, nSelectedRow);
            if ((!(Sal.IsNull(this.dfsEndCustAddrId))) && (!bDelAddrFound))
            {
                Ifs.Fnd.ApplicationForms.Int.PalMessageBox(Properties.Resources.TEXT_DelivAddrMustExist, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
                return false;
            }
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
                    this.tblAddressType_colsAddressTypeCode.TypeCodeLookupInit("CUSTOMER");
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


                    if (this.tblAddressType_colsAddressTypeCodeDb.Text == "DELIVERY")
                    {
                        EnableEndCustInfo(true);
                        tblAddressType_bDeliveryExist = true;
                    }
                    else
                    {
                        if (!(tblAddressType_CheckEndCustDeliveryTypeAddress()))
                        {
                            tblAddressType_bDeliveryExist = false;
                            e.Return = false;
                            return;
                        }
                        else
                            tblAddressType_bDeliveryExist = true;
                    }
                    return;
                }
                if (!tblAddressType_bDeliveryExist)
                {
                    if (!(tblAddressType_CheckEndCustDeliveryTypeAddress()))
                    {
                        e.Return = false;
                        return;
                    }
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

        private void tblAddressType_DataSourcePopulateItEvent(object sender, cDataSource.DataSourcePopulateItEventArgs e)
        {
            e.Handled = true;
            e.ReturnValue = tblAddressType_DataSourcePopulateIt(e.nParam);
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
                tblCommMethod.colsPartyTypeDb.Text = "CUSTOMER";
                tblCommMethod.colsIdentity.Text = SalString.FromHandle(this.dfsCustomerId.EditDataItemValueGet());
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
                tblCommMethod.colsPartyTypeDb.Text = "CUSTOMER";
                tblCommMethod.colsIdentity.Text = SalString.FromHandle(this.dfsCustomerId.EditDataItemValueGet());
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

                    sSourceName = tblCommMethod.p_sLogicalUnit;
                    hWndSource = tblCommMethod;
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

        #region Late Bind Methods

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

        #region ChildTable - tblCustomerInfoContact

        #region Window Variables
        public SalString tblCustomerInfoContact_sTempCustomerId = "";
        public SalString tblCustomerInfoContact_sTempAddressId = "";
        public SalNumber tblCustomerInfoContact_nFound = 0;
        #endregion

        #region Methods

        /// <summary>
        /// Late bound function in cDataSource
        /// </summary>
        /// <param name="hSql"></param>
        /// <returns></returns>
        public virtual SalBoolean tblCustomerInfoContact_DataRecordExecuteNew(SalSqlHandle hSql)
        {
            #region Actions
            using (new SalContext(tblCustomerInfoContact))
            {
                tblCustomerInfoContact_colsCustomerAddress.Text = SalString.FromHandle(this.cmbAddressId.EditDataItemValueGet());
                tblCustomerInfoContact_colsCustomerAddress.EditDataItemSetEdited();
                return ((cTableManager)this.tblCustomerInfoContact).DataRecordExecuteNew(hSql);
            }
            #endregion
        }
        /// <summary>
        /// </summary>
        /// <param name="sCustomerId"></param>
        /// <param name="sAddressId"></param>
        /// <returns></returns>
        public virtual SalNumber tblCustomerInfoContact_CheckDefault(SalString sCustomerId, SalString sAddressId)
        {
            #region Local Variables
            IDictionary<string, string> namedBindVariables = new Dictionary<string, string>();
            #endregion

            #region Actions
            tblCustomerInfoContact_sTempCustomerId = sCustomerId;
            tblCustomerInfoContact_sTempAddressId = sAddressId;

            namedBindVariables.Add("TempCustomerId", this.QualifiedVarBindName("tblCustomerInfoContact_sTempCustomerId"));
            namedBindVariables.Add("TempAddressId", this.QualifiedVarBindName("tblCustomerInfoContact_sTempAddressId"));

            if (!(DbPLSQLBlock("&AO.Customer_Info_Contact_API.Check_Default_Values ( {TempCustomerId} IN , {TempAddressId} IN );", namedBindVariables)))
            {
                return false;
            }
            return true;
            #endregion
        }

        public virtual void tblCustomerInfoContact_HandleCrmColumns()
        {
            if (!(Ifs.Fnd.ApplicationForms.Var.Component.IsWindowAvailable(Pal.GetActiveInstanceName("frmCustomerInfoContact")) && Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("frmCustomerInfoContact"))))
            {
                tblCustomerInfoContact_colsBlockedForCrmObjectsDb.Visible = false;
                tblCustomerInfoContact_colsPersonalInterest.Visible = false;
                tblCustomerInfoContact_colsCampaignInterest.Visible = false;
                tblCustomerInfoContact_colsDecisionPowerType.Visible = false;
                tblCustomerInfoContact_colsDepartment.Visible = false;
                tblCustomerInfoContact_colsManager.Visible = false;
                tblCustomerInfoContact_colsManagerName.Visible = false;
                tblCustomerInfoContact_colsManagerCustAddress.Visible = false;
                tblCustomerInfoContact_colsMainRepresentativeId.Visible = false;
                tblCustomerInfoContact_colsMainRepresentativeName.Visible = false;
            }
        }

        public virtual void PersonZoom()
        {
            SalArray<SalString> sItemNames = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();

            sItemNames[0] = "PERSON_ID";
            hWndItems[0] = tblCustomerInfoContact_colsPersonId;
            Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("PERSON_ID", tblCustomerInfoContact, sItemNames, hWndItems);
            Ifs.Fnd.ApplicationForms.Var.DataTransfer.TypeSet("ZOOM");
            SessionNavigate(Pal.GetActiveInstanceName("frmPersonInfo"));
        }

        protected virtual bool AddNote( SalNumber nFlagOn, SalNumber nFlagOff )
        {
            SalNumber nRow = Sys.TBL_MinRow;
            while ( Sal.TblFindNextRow( tblCustomerInfoContact, ref nRow, nFlagOn, nFlagOff ) )
            {
                Sal.TblSetContext( tblCustomerInfoContact, nRow );
                if ( tblCustomerInfoContact_colNoteText.EditDataItemStateGet() != Ifs.Fnd.ApplicationForms.Const.EDIT_Changed )
                    continue;
                SalString sObjid = tblCustomerInfoContact.DataRecordIdGet();
                SalString sObjversion = tblCustomerInfoContact.DataRecordVersionGet();
                if ( ( (cSessionManager)this ).DbClobWrite( cSessionManager.c_hSql, "CUSTOMER_INFO_CONTACT_API.Write_Note_Text__", sObjid, ref sObjversion, tblCustomerInfoContact_colNoteText.Text ) )
                    tblCustomerInfoContact.__colObjversion.Text = sObjversion;
                else
                    return false;
            }
            return true;
        }
        private void tblCustomerInfoContact_DataRecordFetchEditedUserEvent( object sender, cDataSource.DataRecordFetchEditedUserEventArgs e )
        {
            SalString lsAttr = e.lsAttr;
            Ifs.Fnd.ApplicationForms.Int.PalAttrRemove( "NOTE_TEXT", ref lsAttr );
            e.lsAttr = lsAttr;
            e.Handled = true;

        }
        #endregion

        #region Event Handlers

        private void tblCustomerInfoContact_DataRecordExecuteNewEvent(object sender, cDataSource.DataRecordExecuteNewEventArgs e)
        {
            e.Handled = true;
            e.ReturnValue = tblCustomerInfoContact_DataRecordExecuteNew(e.hSql);
        }

        #endregion

        private void tblAddressType_Load(object sender, EventArgs e)
        {

        }
        #endregion


    }
}
