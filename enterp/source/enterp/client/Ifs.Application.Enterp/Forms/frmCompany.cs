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
// Date   By      Notes
// ----   -----   ---------------------------------------------------
// 120419 Chgulk  EASTRTM-6962, Merged LCS patch 101624.
// 120229  Janblk  EDEL-548, Added cbPrintSendersAddress
// 140401 Machlk  PBFI-5564 Merged Bug 115353
// 140401 Kagalk  PBFI-4142, Merged Bug 113712, Modified to give a warning when deleting the last address type.
// 140409 Ajpelk  PBFI-4140, Merged Bug 112894, Added TabActivateFinish()
// 141115 Chhulk  PRFI-3129, Merged Bug 119227, Added cmbCountry_WindowActions()
// 150611 clstlk  Bug 122600, Modified CountryChanged ().
// 150630 Chgulk  ANFIN-264, Added new field for localization attribute.
// 150701 Nudilk  Bug 123378, Corrected in CreateCompany.
#endregion

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
    [FndWindowRegistration("COMPANY, COMPANY_ADDRESS_LOV_PUB, COMPANY_DOC_ADDRESS_LOV_PUB, COMPANY_FINANCE, RESOURCE_CONNECTION_COMPANY", "Company", FndWindowRegistrationFlags.HomePage)]
    [FndWindowRegistration("COMPANY_EMP", "CompanyEmp", FndWindowRegistrationFlags.HomePage)]
    [FndWindowRegistration("COMPANY_ADDRESS_DELIV_INFO", "CompanyAddressDelivInfo", FndWindowRegistrationFlags.HomePage | FndWindowRegistrationFlags.NoSecurity)]
    public partial class frmCompany : cMasterDetailTabFormWindow
    {
        #region Window Variables
        public SalString sFullFormName = "";
        public SalString sCurrencyCode = "";
        public SalDateTime dValidFrom = SalDateTime.Null;
        public SalString sCreationFinished = "";
        public SalString sRMB = "";
        public SalString lsAttr = "";
        public SalString lsAttrUpdate = "";
        public SalString lsStmt = "";
        public SalWindowHandle hWndtabhandle = SalWindowHandle.Null;
        public SalBoolean bRemoved = false;
        public SalBoolean bAssociationNoEdited = false;
        public SalBoolean bCompanyEmpCreated = false;
        public SalString sCommMethodTabActive = "";
        public SalString sAddressTabActive = "";
        public SalBoolean bTabName1Edited = false;
        public SalString sLastChosenCountry = "";
        public SalString sCountryCode = "";
        public SalBoolean bAddressType = false;
        // Company and EmployeeId received from frmLaborClass DataTransfer
        public SalString sDTCompanyId = "";
        public SalString sDTEmployeeId = "";
        public SalString sFixassTabActive = "";
        public SalString sCorporateFormExist = "";
        public SalString sCorporateFormDesc = "";
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public frmCompany()
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
        public new static frmCompany FromHandle(SalWindowHandle handle)
        {
            return ((frmCompany)SalWindow.FromHandle(handle, typeof(frmCompany)));
        }
        #endregion

        #region Methods

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public new SalBoolean FrameStartupUser()
        {
            using (new SalContext(this))
            {
                // Code moved to vrtActivate
                Sal.SetWindowText(i_hWndFrame, Properties.Resources.HEAD_DetailCompany);
                sFixassTabActive = "FALSE";
                if (cmbLocalizationCountryCode.Enumeration.Count <= 1)
                {
                    Sal.DisableWindow(cmbLocalizationCountryCode);
                }
                return true;
            }
        }
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override SalNumber vrtActivate(fcURL URL)
        {
            using (new SalContext(this))
            {
                this.picTab.BringToTop(0, true);

                if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.RecCountGet() > 0)
                {
                    Sal.WaitCursor(true);
                    if (InitFromTransferredData()) //local method called!
                    {
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
                    }
                    Sal.WaitCursor(false);
                    return false;
                }
                return base.Activate(URL);
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
            SalNumber nRows = 0;
            SalNumber nColumns = 0;
            SalString sDelim = "";
            SalString sCompanyId = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                nColumns = Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemNamesGet(sSqlColumn);
                nRows = Ifs.Fnd.ApplicationForms.Var.DataTransfer.RecCountGet();
                if ((nRows == 1) && (nColumns == 2) && (Vis.ArrayFindString(sSqlColumn, "COMPANY") >= 0) && (Vis.ArrayFindString(sSqlColumn, "ADDRESS_ID") >= 0))
                {
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemValueStrGet(Vis.ArrayFindString(sSqlColumn, "COMPANY"), 0, ref sCompanyId);
                    sDelim = "";
                    lsWhereStmt = "COMPANY = ";
                    lsWhereStmt = lsWhereStmt + sDelim + "'" + sCompanyId + "'";
                    Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceUserWhere, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, lsWhereStmt.ToHandle());
                    Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                    picTab.BringToTop(picTab.FindName("Name1"), true);
                    return true;
                }
                else if ((nRows == 1) && (nColumns == 2) && (Vis.ArrayFindString(sSqlColumn, "COMPANY") >= 0) && (Vis.ArrayFindString(sSqlColumn, "EMPLOYEE_ID") >= 0))
                {
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemValueStrGet(Vis.ArrayFindString(sSqlColumn, "COMPANY"), 0, ref sDTCompanyId);
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemValueStrGet(Vis.ArrayFindString(sSqlColumn, "EMPLOYEE_ID"), 0, ref sDTEmployeeId);

                    //Bring 'Employees' tab to top
                    picTab.BringToTop(picTab.FindName("Name4"), true);
                    //Inform the Employees tab to set the employee data to be set for the UserWhereClause
                    Sal.SendMsg(TabAttachedWindowHandleGet(picTab.FindName("Name4")), Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ((SalString)"SetEmployeeData").ToHandle());

                    lsWhereStmt = "COMPANY = '" + sDTCompanyId + "'";
                    //Populate the form with the custom set where clause
                    Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceUserWhere, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, lsWhereStmt.ToHandle());
                    Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);

                    //Clear the Variables
                    sDTCompanyId = SalString.Null;
                    sDTEmployeeId = SalString.Null;

                    return true;
                }
                return ((cMasterDetailTabFormWindow)this).InitFromTransferredData();
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
            #region Local Variables
            SalString sName = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                if (sMethod == "Updated_Company")
                {
                    return UpdatedCompany(nWhat);
                }
                else if (sMethod == "Updated_Company_Translation")
                {
                    return UpdatedCompanyTranslation(nWhat);
                }
                else if (sMethod == "CreateCompany")
                {
                    return CreateCompany(nWhat);
                }
                else
                {
                    Sal.GetItemName(Sys.hWndItem, ref sName);
                    Ifs.Fnd.ApplicationForms.Int.ErrorBox("DESIGN TIME ERROR for item " + sName + "Function UserMethod handling method \"" + sMethod + "\" not written!");
                    switch (nWhat)
                    {
                        case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                            return 0;

                        case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                            return 0;

                        case Ifs.Fnd.ApplicationForms.Const.METHOD_GetType:
                            return Ifs.Fnd.ApplicationForms.Const.CHILDTYPE_AnyMethod;
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
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("Association_Info_API.Association_No_Exist", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                    DbPLSQLBlock(cSessionManager.c_hSql, sFullFormName + ".dfsExist :=\r\n" +
                        "                                 &AO.Association_Info_API.Association_No_Exist( " + sFullFormName + ".dfsAssociationNo, 'COMPANY' )");
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
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalNumber CreateCompany(SalNumber nWhat)
        {
            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        sRMB = "CreateCompany";
                        if (dlgCreateCompany.ModalDialog(Ifs.Fnd.ApplicationForms.Int.Explorer.ExplorerForm, cmbIdentity.i_sMyValue) == Sys.IDOK)
                        {
                            return 1;
                        }
                        return 0;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        if (sCreationFinished == "TRUE" && cmbIdentity.i_sMyValue != Sys.STRING_Null)
                        {
                            return 0;
                        }
                        return Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("dlgCreateCompany"));
                }
            }

            return 0;
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
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalNumber UpdatedCompany(SalNumber nWhat)
        {
            #region Local Variables
            SalString lsStmt = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        lsAttr = Ifs.Fnd.ApplicationForms.Const.strNULL;
                        Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("NEW_COMPANY", cmbIdentity.i_sMyValue, ref lsAttr);
                        Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("PROCESS", "ONLINE", ref lsAttr);
                        lsAttrUpdate = Ifs.Fnd.ApplicationForms.Const.strNULL;
                        Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("NEW_COMPANY", cmbIdentity.i_sMyValue, ref lsAttrUpdate);
                        lsStmt = "BEGIN " + sFullFormName + ".sCurrencyCode :=\r\n" +
                        "	&AO.Company_Finance_API.Get_Currency_Code (\r\n		" + sFullFormName + ".cmbIdentity.i_sMyValue); ";
                        lsStmt = lsStmt + sFullFormName + ".dValidFrom :=\r\n" +
                        "	&AO.Company_Finance_API.Get_Valid_From (\r\n		" + sFullFormName + ".cmbIdentity.i_sMyValue); END;";
                        // Statement parser was suppressed for this database call during porting
                        using (SignatureHints hints = SignatureHints.NewContext())
                        {
                            hints.Add("Company_Finance_API.Get_Currency_Code", System.Data.ParameterDirection.Input);
                            hints.Add("Company_Finance_API.Get_Valid_From", System.Data.ParameterDirection.Input);
                            DbPLSQLBlock(cSessionManager.c_hSql, lsStmt);
                        }
                        Ifs.Fnd.ApplicationForms.Int.PalAttrAddDate("VALID_FROM", dValidFrom, ref lsAttrUpdate);
                        Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("TEMPLATE_ID", dfsFromTemplateId.Text, ref lsAttrUpdate);
                        Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("DUPL_COMPANY", dfsFromCompany.Text, ref lsAttrUpdate);
                        if (dfsFromTemplateId.Text != Ifs.Fnd.ApplicationForms.Const.strNULL)
                        {
                            Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("ACTION", "NEW", ref lsAttrUpdate);
                        }
                        if (dfsFromCompany.Text != Ifs.Fnd.ApplicationForms.Const.strNULL)
                        {
                            Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("ACTION", "DUPLICATE", ref lsAttrUpdate);
                        }
                        Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("MAKE_COMPANY", "IMPORT", ref lsAttrUpdate);
                        if (dlgUpdateCompany.ModalDialog(Ifs.Fnd.ApplicationForms.Int.Explorer.ExplorerForm, cmbIdentity.i_sMyValue, dfName.Text, sCurrencyCode, dValidFrom, lsAttr, lsAttrUpdate) == Sys.IDOK)
                        {
                            return 1;
                        }
                        return 0;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        if (sCreationFinished == "FALSE" || sCreationFinished == Ifs.Fnd.ApplicationForms.Const.strNULL)
                        {
                            return 0;
                        }
                        return !(Sal.IsNull(dfName)) && Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("dlgUpdateCompany"));
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalNumber UpdatedCompanyTranslation(SalNumber nWhat)
        {
            #region Local Variables
            SalString lsStmt = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        lsAttr = Ifs.Fnd.ApplicationForms.Const.strNULL;
                        Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("NEW_COMPANY", cmbIdentity.i_sMyValue, ref lsAttr);
                        Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("PROCESS", "ONLINE", ref lsAttr);
                        lsAttrUpdate = Ifs.Fnd.ApplicationForms.Const.strNULL;
                        Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("NEW_COMPANY", cmbIdentity.i_sMyValue, ref lsAttrUpdate);
                        lsStmt = "BEGIN " + sFullFormName + ".sCurrencyCode :=\r\n" +
                        "	&AO.Company_Finance_API.Get_Currency_Code (\r\n		" + sFullFormName + ".cmbIdentity.i_sMyValue); ";
                        lsStmt = lsStmt + sFullFormName + ".dValidFrom :=\r\n" +
                        "	&AO.Company_Finance_API.Get_Valid_From (\r\n		" + sFullFormName + ".cmbIdentity.i_sMyValue); END;";
                        // Statement parser was suppressed for this database call during porting
                        using (SignatureHints hints = SignatureHints.NewContext())
                        {
                            hints.Add("Company_Finance_API.Get_Currency_Code", System.Data.ParameterDirection.Input);
                            hints.Add("Company_Finance_API.Get_Valid_From", System.Data.ParameterDirection.Input);
                            DbPLSQLBlock(cSessionManager.c_hSql, lsStmt);
                        }
                        Ifs.Fnd.ApplicationForms.Int.PalAttrAddDate("VALID_FROM", dValidFrom, ref lsAttrUpdate);
                        Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("TEMPLATE_ID", dfsFromTemplateId.Text, ref lsAttrUpdate);
                        Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("DUPL_COMPANY", dfsFromCompany.Text, ref lsAttrUpdate);
                        if (dfsFromTemplateId.Text != Ifs.Fnd.ApplicationForms.Const.strNULL)
                        {
                            Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("ACTION", "NEW", ref lsAttrUpdate);
                        }
                        if (dfsFromCompany.Text != Ifs.Fnd.ApplicationForms.Const.strNULL)
                        {
                            Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("ACTION", "DUPLICATE", ref lsAttrUpdate);
                        }
                        Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("MAKE_COMPANY", "IMPORT", ref lsAttrUpdate);
                        if (dlgUpdateCompanyTranslation.ModalDialog(Ifs.Fnd.ApplicationForms.Int.Explorer.ExplorerForm, cmbIdentity.i_sMyValue, sCurrencyCode, dValidFrom, lsAttr, lsAttrUpdate) == Sys.IDOK)
                        {
                            return 1;
                        }
                        return 0;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        return !(Sal.IsNull(dfName)) && Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("dlgUpdateCompanyTranslation"));
                }
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
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                hWndAddress = TabAttachedWindowHandleGet(picTab.FindName("Name1"));
                hWndComMethod = TabAttachedWindowHandleGet(picTab.FindName("Name2"));
                if (sAddressTabActive == "TRUE")
                {
                    if (Sal.SendMsg(frmCompanyAddress.FromHandle(hWndAddress).tblCommMethod, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceIsDirty, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam))
                    {
                        if (!(frmCompanyAddress.FromHandle(hWndAddress).tblCommMethod.CheckDefault()))
                        {
                            return false;
                        }
                    }
                }
                if (sCommMethodTabActive == "TRUE")
                {
                    if (Sal.SendMsg(frmCompany.FromHandle(i_hWndFrame).TabAttachedWindowHandleGet(picTab.FindName("Name2")), Ifs.Fnd.ApplicationForms.Const.PM_DataSourceIsDirty, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam))
                    {
                        if (!(frmCompanyCommMethod.FromHandle(hWndComMethod).tblCommMethod.CheckDefault()))
                        {
                            return false;
                        }
                    }
                }
                return ((cDataSource)this).DataSourceSaveCheckOk();
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual new SalNumber TabActivateFinish(SalWindowHandle hWnd, SalNumber nTab)
        {
            #region Local Variables
            SalWindowHandle hWndInfoCommMethod = SalWindowHandle.Null;
            SalNumber retVal = 0;
            SalString sTabName = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                retVal = base.TabActivateFinish(hWnd, nTab);
                picTab.GetName(nTab, ref sTabName);
                if (sTabName == "Name2")
                {
                    hWndInfoCommMethod = TabAttachedWindowHandleGet(picTab.FindName("Name2"));
                    Sal.SetFocus(frmCompanyCommMethod.FromHandle(hWndInfoCommMethod).tblCommMethod);
                }
            }
            return retVal;
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
                picTab.GetName(nTab, ref sName);
                if (sName == "Name1")
                {
                    sAddressTabActive = "TRUE";
                }
                else if (sName == "Name2")
                {
                    sCommMethodTabActive = "TRUE";
                }
                else if (sName == "DOMAIN-frmCompanyFixassInfo")
                    {
                        sFixassTabActive = "TRUE";
                    }
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
                                                                                                                              :i_hWndSelf.frmCompany.sCountryCode IN,
                                                                                                                              :i_hWndSelf.frmCompany.dfsCorporateForm IN);
                                                           :i_hWndSelf.frmCompany.sCorporateFormExist := CorporateFormExist_ ;
                                                           IF (CorporateFormExist_ = 'TRUE') THEN
                                                              :i_hWndSelf.frmCompany.sCorporateFormDesc:= &AO.Corporate_Form_Api.Get_Corporate_Form_Desc(  
                                                                                                                              :i_hWndSelf.frmCompany.sCountryCode IN,
                                                                                                                              :i_hWndSelf.frmCompany.dfsCorporateForm IN);                                                             
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
            SalWindowHandle hWndFixass = SalWindowHandle.Null;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                hWndAddress = TabAttachedWindowHandleGet(picTab.FindName("Name1"));
                if (sAddressTabActive == "TRUE")
                {
                    if (((bool)Sal.SendMsg(frmCompanyAddress.FromHandle(hWndAddress).tblAddressType, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceIsDirty, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam)) || (Sal.QueryFieldEdit(frmCompanyAddress.FromHandle(hWndAddress).dfdValidFrom) ||
                    Sal.QueryFieldEdit(frmCompanyAddress.FromHandle(hWndAddress).dfdValidTo)))
                    {
                        if (!(frmCompanyAddress.FromHandle(hWndAddress).CheckDefaultAddress()))
                        {
                            return false;
                        }
                        if (!(frmCompanyAddress.FromHandle(hWndAddress).CheckLastAddressType()))
                        {
                            return false;
                        }
                    }
                }
                if (sFixassTabActive == "TRUE")
                {
                    hWndFixass = TabAttachedWindowHandleGet(picTab.FindName("DOMAIN-frmCompanyFixassInfo"));
                    if (!(Sal.SendMsg(hWndFixass, Ifs.Fnd.ApplicationForms.Const.PM_User, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ((SalString)"DataSourceSaveCheckOk").ToHandle())))
                    {
                        return false;
                    }
                }
                return ((cMasterDetailTabFormWindow)this).DataSourceSaveCheck();
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
        private void frmCompany_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_Create:
                    this.frmCompany_OnSAM_Create(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate:
                    this.frmCompany_OnPM_DataSourcePopulate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave:
                    this.frmCompany_OnPM_DataSourceSave(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_Create event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmCompany_OnSAM_Create(object sender, WindowActionsEventArgs e)
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
        private void frmCompany_OnPM_DataSourcePopulate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Sys.wParam, Sys.lParam))
                {
                    this.lsStmt = "BEGIN " + this.sFullFormName + ".sCreationFinished :=\r\n" +
                    "	&AO.Company_Finance_API.Get_Creation_Finished (\r\n		" + this.sFullFormName + ".cmbIdentity.i_sMyValue); END;";
                    using (SignatureHints hints = SignatureHints.NewContext())
                    {
                        hints.Add("Company_Finance_API.Get_Creation_Finished", System.Data.ParameterDirection.Input);
                        this.DbPLSQLBlock(cSessionManager.c_hSql, this.lsStmt);
                    }
                    this.hWndtabhandle = this.TabAttachedWindowHandleGet(this.picTab.FindName("DOMAIN-frmCompanyInvoiceInfo"));
                    Sal.SendMsg(this.hWndtabhandle, Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Sys.wParam, 0);
                    this.sLastChosenCountry = this.cmbCountry.i_sMyValue;
                    this.hWndtabhandle = this.TabAttachedWindowHandleGet(this.picTab.FindName("DOMAIN-frmCreateCompany"));
                    Sal.SendMsg(this.hWndtabhandle, Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Sys.wParam, 0);
                    this.hWndtabhandle = this.TabAttachedWindowHandleGet(this.picTab.FindName("DOMAIN-frmCompanyTaxControl"));
                    Sal.SendMsg(this.hWndtabhandle, Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Sys.wParam, 0);
                    e.Return = Sal.SendMsgToChildren(this.i_hWndFrame, Ifs.Fnd.ApplicationForms.Const.PM_User, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ((SalString)"POPULATE").ToHandle());
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
        /// PM_DataSourceSave event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmCompany_OnPM_DataSourceSave(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if ((Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) && this.bCompanyEmpCreated)
            {
                if (!(tbwCompanyEmp.FromHandle(frmCompany.FromHandle(this.i_hWndFrame).TabAttachedWindowHandleGet(this.picTab.FindName("Name4"))).CheckEmpExpDates()))
                {
                    e.Return = false;
                    return;
                }
            }
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Sys.wParam, Sys.lParam))
            {
                if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                {
                    this.hWndtabhandle = this.TabAttachedWindowHandleGet(this.picTab.FindName("Name1"));
                    if (!(this.bRemoved) && !(this.bAddressType))
                    {
                        Sal.SendMsg(this.hWndtabhandle, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceRefresh, Sys.wParam, Sys.lParam);
                    }
                    this.bRemoved = false;
                    this.bAddressType = false;
                    this.bTabName1Edited = Sal.SendMsgToChildren(this.hWndtabhandle, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceIsDirty, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam);
                    if (this.bTabName1Edited)
                    {
                        this.TabInvalidateData(this.picTab.FindName("Name2"));
                    }
                    this.hWndtabhandle = this.TabAttachedWindowHandleGet(this.picTab.FindName("DOMAIN-frmCompanyInvoiceInfo"));
                    Sal.SendMsg(this.hWndtabhandle, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Sys.wParam, Sys.lParam);
                    this.hWndtabhandle = this.TabAttachedWindowHandleGet(this.picTab.FindName("DOMAIN-frmCreateCompany"));
                    Sal.SendMsg(this.hWndtabhandle, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Sys.wParam, Sys.lParam);
                    this.hWndtabhandle = this.TabAttachedWindowHandleGet(this.picTab.FindName("DOMAIN-frmCompanyTaxControl"));
                    Sal.SendMsg(this.hWndtabhandle, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Sys.wParam, Sys.lParam);
                    Sal.SendMsg(this.TabAttachedWindowHandleGet(this.picTab.FindName("Name1")), Const.PAM_DetailAddress, 0, 0);
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
        private void cmbIdentity_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemNew:
                    this.cmbIdentity_OnPM_DataItemNew(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom:
                    this.cmbIdentity_OnPM_DataItemZoom(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemZoom event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cmbIdentity_OnPM_DataItemZoom(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            e.Return = false;
            return;
            #endregion
        }
        /// <summary>
        /// PM_DataItemNew event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cmbIdentity_OnPM_DataItemNew(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemNew, Sys.wParam, Sys.lParam);
            this.cmbIdentity.EditDataItemSetEdited();
            e.Return = true;
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
        #endregion

        #region Event Handlers

        private void cmdUpdatedCompany_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            // TODO: Rewrite command event handler not to use UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            ((FndCommand)sender).Enabled = Sal.SendMsg(i_hWndFrame, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, ((SalString)"Updated_Company").ToHandle());
        }

        private void cmdUpdatedCompany_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            // TODO: Rewrite command event handler not to make use of UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            Ifs.Fnd.ApplicationForms.Int.PostMessage(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, "Updated_Company");
        }

        private void cmdUpdatedCompanyTranslation_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            // TODO: Rewrite command event handler not to use UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            ((FndCommand)sender).Enabled = Sal.SendMsg(i_hWndFrame, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, ((SalString)"Updated_Company_Translation").ToHandle());
        }

        private void cmdUpdatedCompanyTranslation_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            // TODO: Rewrite command event handler not to make use of UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            Ifs.Fnd.ApplicationForms.Int.PostMessage(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, "Updated_Company_Translation");
        }

        private void cmdCreateCompany_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            // TODO: Rewrite command event handler not to use UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            ((FndCommand)sender).Enabled = Sal.SendMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, ((SalString)"CreateCompany").ToHandle());
        }

        private void cmdCreateCompany_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            // TODO: Rewrite command event handler not to make use of UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            Ifs.Fnd.ApplicationForms.Int.PostMessage(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, "CreateCompany");
        }

        #endregion

    }
}
