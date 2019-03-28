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
// 130619 Mawelk  Bug id 110526 corrected.
//  121129 Pratlk  DANU-111, Added Master Company check box.
//  130129 NILILK  Added some validation to Parallel Currency Basic Data..
//  130510 NILILK  Modified the logic to enable disable next button based on parallel currency values.
//  130510 NILILK  Modified Validation of Parallel Currency Amount to use same valid from date as accounting currency.
//  131204 LaMaLK  PBFI-3613, Disabled the 'Parallel Currency Base' label and combo box when creating Master Companies
#endregion

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
    /// <param name="pCompany"></param>
    [FndWindowRegistration("COMPANY", "Company")]
    public partial class dlgCreateCompany : cWizardDialogBox
    {
        #region Window Parameters
        public SalString pCompany;
        #endregion

        #region Window Variables
        public SalString sCompanyExist = "";
        public SalString sCreationFinished = "";
        public SalString sErrorCreated = "";
        public SalString sFullName = "";
        public SalString sModuleVariable = "";
        public SalString sPackageNameVariable = "";
        public SalString lsAccrulAttr = "";
        public SalString lsAttrEnt = "";
        public SalString lsComp = "";
        public SalString lsCountry = "";
        public SalString lsCreateAttrOut = "";
        public SalString lsCreateAttrModule = "";
        public SalString lsDefaultLanguage = "";
        public SalString lsNewCompanyName = "";
        public SalString lsOutAttr = "";
        public SalString lsOutAttr1 = "";
        public SalString lsTemplateName = "";
        public SalNumber nSteps = 0;
        public SalNumber nTemp1 = 0;
        public SalNumber nTemp2 = 0;
        public SalNumber nTemp3 = 0;
        public SalString sFromCompany = "";
        public SalString lsStmt = "";
        public SalString sTemplateCompany = "";
        public SalString sFromTemplateId = "";
        public SalString sCurrencyCode = "";
        public SalString sParallellCurrency = "";
        public SalString sCorrectionType = "";
        public SalDateTime dValidFrom = SalDateTime.Null;
        public SalString sTimeStamp = "";
        public SalString sUseMakeCompany = "";
        public SalString lsComponentList = "";
        public SalString sCompName = "";
        public SalNumber nExecId = 0;
        public SalString sDefaultTemplateId = "";
        public SalString lsDefaultTemplateName = "";
        public SalNumber nAccCurrCheck = 0;
        public SalNumber nParallelCurrCheck = 0;
        public SalString sAccCurrCheck = "";
        public SalString sParallelCurrCheck = "";
        public SalString sOldStep = "";
        public SalArray<SalString> sTemplateLngs = new SalArray<SalString>();
        public SalString sTemplateLng = "";
        public SalArray<SalString> sTemplateLngDescs = new SalArray<SalString>();
        public SalString sTemplateLngDesc = "";
        public SalString sLanguages = "";
        public SalBoolean bOptionChanged = false;
        public SalString sOldCreateFrom = "";
        public SalString sOldCreateFromType = "";
        public SalNumber nNum = 0;
        public SalArray<SalString> sRecords = new SalArray<SalString>();
        public SalArray<SalString> sUnits = new SalArray<SalString>();
        public SalString lsPeriodUsed = "";
        public SalDateTime dtUserDefinedCalendarStart = SalDateTime.Null;
        public SalDateTime dtUserDefinedCalendarEnd = SalDateTime.Null;
        public SalString sLogicalAccTypes = "";
        public SalString sCodePartAvaialable = "";
        public SalString sCodePartIdVal = "";
        public SalString sCodePartNameVal = "";
        public SalBoolean bUseCurrBalCodePart = false;
        public SalBoolean bDefaultCodePartExist = false;

        public SalString sParallelCurrBaseDb = "";
        public SalString sCurrBalFunction = "CURR";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public dlgCreateCompany()
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
        public static SalNumber ModalDialog(Control owner, SalString pCompany)
        {
            dlgCreateCompany dlg = DialogFactory.CreateInstance<dlgCreateCompany>();
            dlg.pCompany = pCompany;
            dlg.AutoResizeButtons = true;
            SalNumber ret = dlg.ShowDialog(owner);
            return ret;
        }

        /// <summary>
        /// Returns the object instance associated with the window handle.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public new static dlgCreateCompany FromHandle(SalWindowHandle handle)
        {
            return ((dlgCreateCompany)SalWindow.FromHandle(handle, typeof(dlgCreateCompany)));
        }
        #endregion

        #region Properties

        protected frmCompanyInfo CompanyInfo
        {
            get
            {
                return frmCompanyInfo.FromHandle(this.WizardExternalWindowHandleGet(this.StepSix.StepDescription));
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public new SalBoolean FrameStartupUser()
        {
            #region Actions
            using (new SalContext(this))
            {
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("Crecomp_Component_API.Check_If_All_Use_Make_Company", System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output);
                    DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN\r\n" +
                        "		   :i_hWndFrame.dlgCreateCompany.dfsDomainId :=  &AO.Application_Domain_API.Get_Default;\r\n" +
                        "		   &AO.Crecomp_Component_API.Check_If_All_Use_Make_Company( :i_hWndFrame.dlgCreateCompany.sUseMakeCompany,\r\n" +
                        "									:i_hWndFrame.dlgCreateCompany.lsComponentList);\r\n		 END;");
                }
                Sal.EnableWindow(dfsTemplateId);
                Sal.EnableWindow(dfsTemplateName);
                Sal.DisableWindow(dfsSourceCompanyId);
                Sal.DisableWindow(dfsSourceCompanyName);
                dfsDomainId.EditDataItemSetEdited();
                Sal.EnableWindowAndLabel(cmbDefaultLanguage);
                Sal.EnableWindowAndLabel(cmbCountry);
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
                if (sMethod == "SetFocusNewCompanyId")
                {
                    switch (nWhat)
                    {
                        case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                            return true;

                        case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                            Sal.SetFocus(dfsNewCompanyId);
                            return true;
                    }
                }
                else if (sMethod == "select")
                {
                    switch (nWhat)
                    {
                        case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                            return ValidateLanguageButtonState("select");

                        case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                            if (FetchToLngListBox())
                            {
                                return true;
                            }
                            break;
                    }
                }
                else if (sMethod == "unselect")
                {
                    switch (nWhat)
                    {
                        case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                            return ValidateLanguageButtonState("unselect");

                        case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                            if (UnCheckLngListBox())
                            {
                                return true;
                            }
                            break;
                    }
                }
                else
                {
                    return ((cWizardDialogBox)this).UserMethod(nWhat, sMethod);
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="sStep"></param>
        /// <returns></returns>
        public virtual SalBoolean AllFieldsValidate(SalString sStep)
        {
            #region Local Variables
            SalString sDate = "";
            SalString sDate1 = "";
            SalArray<SalString> sPlaceHolders = new SalArray<SalString>();
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                if (sStep == "StepThree")
                {
                    if (dfsTemplateId.Text == Ifs.Fnd.ApplicationForms.Const.strNULL)
                    {
                        if (dfsSourceCompanyId.Text == Ifs.Fnd.ApplicationForms.Const.strNULL)
                        {
                            Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_Validate, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                            return false;
                        }
                        else if (dfsSourceCompanyId.Text != Ifs.Fnd.ApplicationForms.Const.strNULL)
                        {
                            if (Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Company_API.Exist"))
                            {
                                using (SignatureHints hints = SignatureHints.NewContext())
                                {
                                    hints.Add("Company_API.Exist", System.Data.ParameterDirection.Input);
                                    if (!(DbPLSQLBlock(cSessionManager.c_hSql, "&AO.Company_API.Exist(:i_hWndFrame.dlgCreateCompany.dfsSourceCompanyId)")))
                                    {
                                        return false;
                                    }
                                }
                            }
                        }
                    }
                    else if (dfsTemplateId.Text != Ifs.Fnd.ApplicationForms.Const.strNULL)
                    {
                        if (Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Create_Company_Tem_API.Exist"))
                        {
                            using (SignatureHints hints = SignatureHints.NewContext())
                            {
                                hints.Add("Create_Company_Tem_API.Exist", System.Data.ParameterDirection.Input);
                                if (!(DbPLSQLBlock(cSessionManager.c_hSql, "&AO.Create_Company_Tem_API.Exist(:i_hWndFrame.dlgCreateCompany.dfsTemplateId)")))
                                {
                                    return false;
                                }
                            }
                        }
                    }
                    if (dfsSourceCompanyId.Text == Ifs.Fnd.ApplicationForms.Const.strNULL)
                    {
                        if ((dfsTemplateId.Text == Ifs.Fnd.ApplicationForms.Const.strNULL) || (dfsTemplateName.Text == Ifs.Fnd.ApplicationForms.Const.strNULL))
                        {
                            Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_Validate, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                            return false;
                        }
                    }
                    if (sUseMakeCompany == "FALSE")
                    {
                        sPlaceHolders[0] = lsComponentList;
                        Ifs.Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.TEXT_Info, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok, sPlaceHolders);
                        return true;
                    }
                }
                else if (sStep == "StepFive")
                {                    
                    sDate = dfdtValidFrom.DateTime.ToString();
                    if ((dfsAccountingCurrency.Text == Ifs.Fnd.ApplicationForms.Const.strNULL) || (sDate == Ifs.Fnd.ApplicationForms.Const.strNULL) || (cmbDefaultLanguage.Text == Ifs.Fnd.ApplicationForms.Const.strNULL) || (cmbCountry.Text == Ifs.Fnd.ApplicationForms.Const.strNULL))
                    {
                        Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_Validate, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                        return false;
                    }
                    if (dfsParallelAccCurrency.Text != Ifs.Fnd.ApplicationForms.Const.strNULL)
                    {
                        sDate1 = dfdtTimeStamp.DateTime.ToString();
                        if (sDate1 == Ifs.Fnd.ApplicationForms.Const.strNULL)
                        {
                            Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_Parallel, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                            return false;
                        }
                    }
                    if (!(ValidateCurrency()))
                    {
                        return false;
                    }
                    if (dfsTemplateId.Text != Ifs.Fnd.ApplicationForms.Const.strNULL)
                    {
                        if (!(ValidateTemplateInfo()))
                        {
                            return false;
                        }
                    }
                    else if (dfsSourceCompanyId.Text != Ifs.Fnd.ApplicationForms.Const.strNULL)
                    {
                        if (!(ValidateCurrency()))
                        {
                            return false;
                        }
                        if (!(ValidateCompanyInfo()))
                        {
                            return false;
                        }
                    }
                    if (rbUserDefined.Checked == true)
                    {
                        if (!(ValidateUserDefinedCalendar()))
                        {
                            return false;
                        }
                    } 

                }
                else if (sStep == "StepSix")
                {
                                                         
                }
                return true;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean CheckIfOptionChanged()
        {
            #region Actions
            using (new SalContext(this))
            {
                if (rbCopyCompany.Checked)
                {
                    if (sOldCreateFromType == "Company")
                    {
                        if (sOldCreateFrom == dfsSourceCompanyId.Text)
                        {
                            return false;
                        }
                        else
                        {
                            sOldCreateFromType = "Company";
                            sOldCreateFrom = dfsSourceCompanyId.Text;
                            return true;
                        }
                    }
                    else
                    {
                        sOldCreateFromType = "Company";
                        sOldCreateFrom = dfsSourceCompanyId.Text;
                        return true;
                    }
                }
                else
                {
                    if (sOldCreateFromType == "Template")
                    {
                        if (sOldCreateFrom == dfsTemplateId.Text)
                        {
                            return false;
                        }
                        else
                        {
                            sOldCreateFromType = "Template";
                            sOldCreateFrom = dfsTemplateId.Text;
                            return true;
                        }
                    }
                    else
                    {
                        sOldCreateFromType = "Template";
                        sOldCreateFrom = dfsTemplateId.Text;
                        return true;
                    }
                }
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="sAttr"></param>
        /// <returns></returns>
        public virtual SalString ConvertAttrToMessage(SalString sAttr)
        {
            #region Local Variables
            cMessage sTempMessage = new cMessage();
            SalNumber nTo = 0;
            SalNumber nIndex = 0;
            SalString sName = "";
            SalString sValue = "";
            SalNumber nAttributeId = 0;
            SalString sTempAttr = "";
            SalNumber nLength = 0;
            SalString sEmpty = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                sTempAttr = sAttr;
                nTo = sTempAttr.Scan(Ifs.Fnd.ApplicationForms.Var.g_sCHAR_RS);
                if (nTo > 0)
                {
                    sTempMessage.Construct();
                    while (nTo > 0)
                    {
                        nLength = sTempAttr.Length;
                        nIndex = sTempAttr.Scan(Ifs.Fnd.ApplicationForms.Var.g_sCHAR_US);
                        sName = sTempAttr.Mid(0, nIndex);
                        sValue = sTempAttr.Mid(nIndex + 1, nTo - nIndex - 1);
                        // Add the name and value to the message variable
                        nAttributeId = sTempMessage.AddAttribute(sName, sValue);
                        sTempAttr = sTempAttr.Mid(nTo + 1, nLength - (nTo + 1));
                        nTo = sTempAttr.Scan(Ifs.Fnd.ApplicationForms.Var.g_sCHAR_RS);
                    }
                    return sTempMessage.Pack();
                }
                return sEmpty;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public new SalNumber DataSourceInquireSave()
        {
            #region Actions
            using (new SalContext(this))
            {
                return Sys.IDNO;
            }
            #endregion
        }

        /// <summary>
        /// Displays a dialog with progress bar
        /// </summary>
        /// <returns></returns>
        public virtual SalString DisplayProgresBar()
        {
            #region Local Variables
            SalString sTitle = "";
            SalString sCreate = "";
            SalArray<SalString> sAttrs = new SalArray<SalString>();
            SalArray<SalString> sFields = new SalArray<SalString>();
            SalNumber n = 0;
            SalSqlHandle hSql = SalSqlHandle.Null;
            SalBoolean bOk = false;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                sTitle = Properties.Resources.TEXT_CreatingCompany + " " + CompanyInfo.dfsCompanyId.Text;
                MethodProgressStart(i_hWndSelf, sTitle, Properties.Resources.TEXT_CreatingCompany, "SAVE", true, SalWindowHandle.Null);
                n = 1;
                nSteps = lsCreateAttrOut.Tokenize(Ifs.Fnd.ApplicationForms.Const.strNULL, ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_RS).ToCharacter(), sAttrs);
                MethodProgressStepAdd(nSteps);
                if (!(DbConnect(ref hSql)))
                {
                    return "FALSE";
                }
                while (sAttrs[n - 1] != Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    sAttrs[n - 1].Tokenize(Ifs.Fnd.ApplicationForms.Const.strNULL, ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_US).ToCharacter(), sFields);
                    if (sFields[0] == "MODULE")
                    {
                        sModuleVariable = sFields[1];
                    }
                    if (sFields[0] == "PACKAGE")
                    {
                        sPackageNameVariable = sFields[1];
                    }
                    if (sModuleVariable != Ifs.Fnd.ApplicationForms.Const.strNULL && sPackageNameVariable != Ifs.Fnd.ApplicationForms.Const.strNULL)
                    {
                        sCreate = Properties.Resources.TEXT_CreatingIn + " " + sModuleVariable;
                        MethodProgressMessage(sCreate);
                        if (DbTransactionBegin(ref cSessionManager.c_hSql))
                        {
                            using (SignatureHints hints = SignatureHints.NewContext())
                            {
                                hints.Add("Create_Company_API.Create_New_Company__", System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                                bOk = DbPLSQLBlock(hSql, "&AO.Create_Company_API.Create_New_Company__( :i_hWndFrame.dlgCreateCompany.sErrorCreated,\r\n" +
                                    "                                                                                                                                :i_hWndFrame.dlgCreateCompany.dfsNewCompanyId,\r\n" +
                                    "								:i_hWndFrame.dlgCreateCompany.sModuleVariable,\r\n" +
                                    "								:i_hWndFrame.dlgCreateCompany.sPackageNameVariable,\r\n" +
                                    "								:i_hWndFrame.dlgCreateCompany.lsCreateAttrModule,\r\n" +
                                    "								:i_hWndFrame.dlgCreateCompany.sLanguages )");
                            }
                            if (!(bOk))
                            {
                                DbTransactionClear(cSessionManager.c_hSql);
                                return "FALSE";
                            }
                            if (sModuleVariable == "ACCRUL")
                            {
                                using (SignatureHints hints = SignatureHints.NewContext())
                                {
                                    hints.Add("Company_Finance_API.Set_Creation_Finished", System.Data.ParameterDirection.Input);
                                    bOk = DbPLSQLBlock(hSql, "&AO.Company_Finance_API.Set_Creation_Finished( :i_hWndFrame.dlgCreateCompany.dfsNewCompanyId )");
                                }
                                if (!(bOk))
                                {
                                    DbTransactionClear(cSessionManager.c_hSql);
                                    return "FALSE";
                                }
                            }
                        }
                        DbTransactionEnd(cSessionManager.c_hSql);
                        sModuleVariable = Ifs.Fnd.ApplicationForms.Const.strNULL;
                        sPackageNameVariable = Ifs.Fnd.ApplicationForms.Const.strNULL;
                    }
                    n = n + 1;
                    MethodProgressStep();
                }
                MethodProgressDone();
                DbDisconnect(hSql);
                return "TRUE";
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public new SalNumber FrameActivate()
        {
            #region Actions
            using (new SalContext(this))
            {
                Sal.EnableWindowAndLabel(cmbDefaultLanguage);
                Sal.EnableWindowAndLabel(cmbCountry);
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// Insert components to lbLngList
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean FetchToLngListBox()
        {
            #region Local Variables
            SalNumber nCount = 0;
            SalNumber i = 0;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                Sal.ListClear(lbLanguages);
                nCount = sTemplateLngDescs.GetUpperBound(1);
                Sal.DisableWindow(pbSelectAll);
                Sal.EnableWindow(pbUnSelectAll);
                Sal.EnableWindow(pbNext);
                nCount = nCount + 1;
                i = 0;
                while (i < nCount)
                {
                    if (sTemplateLngDescs[i] != Ifs.Fnd.ApplicationForms.Const.strNULL)
                    {
                        lbLanguages.AddValue(sTemplateLngDescs[i], true, i);
                    }
                    i = i + 1;
                }
                if (nCount >= 0)
                {
                    Sal.ListSetMultiSelect(lbLanguages, 0, true);
                }
                return true;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean GetCompanyName()
        {
            #region Local Variables
            SalString lsStmt = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("Company_API.Get_Name", System.Data.ParameterDirection.Input);
                    hints.Add("Company_API.Get_Default_Language", System.Data.ParameterDirection.Input);
                    hints.Add("Company_API.Get_Country", System.Data.ParameterDirection.Input);
                    hints.Add("Company_API.Get_Template_Company", System.Data.ParameterDirection.Input);
                    if (!(DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN\r\n" +
                        "		        :i_hWndFrame.dlgCreateCompany.lsNewCompanyName := &AO.Company_API.Get_Name(:i_hWndFrame.dlgCreateCompany.dfsNewCompanyId);\r\n" +
                        "		        :i_hWndFrame.dlgCreateCompany.lsDefaultLanguage := &AO.Company_API.Get_Default_Language(:i_hWndFrame.dlgCreateCompany.dfsNewCompanyId);\r\n" +
                        "		        :i_hWndFrame.dlgCreateCompany.lsCountry := &AO.Company_API.Get_Country(:i_hWndFrame.dlgCreateCompany.dfsNewCompanyId);\r\n" +
                        "		        :i_hWndFrame.dlgCreateCompany.sTemplateCompany := &AO.Company_API.Get_Template_Company (" + sFullName + ".dfsNewCompanyId);\r\n" +
                        "		      END;")))
                    {
                        return false;
                    }
                }
                if (lsNewCompanyName != Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    dfsNewCompanyName.Text = lsNewCompanyName;
                    if (sTemplateCompany == "TRUE")
                    {
                        cbTemplateCompany.EditDataItemValueSet(1, sTemplateCompany.ToHandle());
                    }
                    if (sTemplateCompany == "FALSE")
                    {
                        cbTemplateCompany.EditDataItemValueSet(0, ((SalString)"FALSE").ToHandle());
                    }
                    Sal.DisableWindow(cbTemplateCompany);
                    dfsNewCompanyName.EditDataItemStateSet(Ifs.Fnd.ApplicationForms.Const.EDIT_Query);
                    return true;
                }
                else
                {
                    Sal.EnableWindow(cbTemplateCompany);
                    Sal.EnableWindow(cmbCountry);
                    Sal.EnableWindow(cmbDefaultLanguage);
                    Sal.ClearField(cmbCountry);
                    Sal.ClearField(cmbDefaultLanguage);
                }
                dfsNewCompanyName.EditDataItemStateSet(Ifs.Fnd.ApplicationForms.Const.EDIT_Changed);
                return true;
            }

            return false;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber GetAccountingInfo()
        {
            #region Local Variables
            SalString lsStmt = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                lsStmt = "BEGIN " + sFullName + ".lsDefaultLanguage :=\r\n" +
                "	&AO.Company_API.Get_Default_Language (\r\n		" + sFullName + ".dfsNewCompanyId); ";
                lsStmt = lsStmt + sFullName + ".lsCountry :=\r\n" +
                "	&AO.Company_API.Get_Country (\r\n		" + sFullName + ".dfsNewCompanyId); ";
                lsStmt = lsStmt + sFullName + ".sCurrencyCode :=\r\n" +
                "	&AO.Company_Finance_API.Get_Currency_Code (\r\n		" + sFullName + ".dfsNewCompanyId); ";
                lsStmt = lsStmt + sFullName + ".dValidFrom :=\r\n" +
                "	&AO.Company_Finance_API.Get_Valid_From (\r\n		" + sFullName + ".dfsNewCompanyId); ";
                lsStmt = lsStmt + sFullName + ".sCorrectionType :=\r\n" +
                "	&AO.Company_Finance_API.Get_Correction_Type (\r\n		" + sFullName + ".dfsNewCompanyId); ";
                lsStmt = lsStmt + sFullName + ".sTimeStamp :=\r\n" +
                "	&AO.Company_Finance_API.Get_Time_Stamp (\r\n		" + sFullName + ".dfsNewCompanyId); END; ";
                // Statement parser was suppressed for this database call during porting
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("Company_API.Get_Default_Language", System.Data.ParameterDirection.Input);
                    hints.Add("Company_API.Get_Country", System.Data.ParameterDirection.Input);
                    hints.Add("Company_Finance_API.Get_Currency_Code", System.Data.ParameterDirection.Input);
                    hints.Add("Company_Finance_API.Get_Valid_From", System.Data.ParameterDirection.Input);
                    hints.Add("Company_Finance_API.Get_Correction_Type", System.Data.ParameterDirection.Input);
                    hints.Add("Company_Finance_API.Get_Time_Stamp", System.Data.ParameterDirection.Input);
                    DbPLSQLBlock(cSessionManager.c_hSql, lsStmt);
                }
                lsStmt = "BEGIN " + sFullName + ".sParallellCurrency :=\r\n" +
                "	&AO.Company_Finance_API.Get_Parallel_Acc_Currency (\r\n		" + sFullName + ".dfsNewCompanyId,\r\n" +
                "                                " + sFullName + ".sTimeStamp); END; ";
                // Statement parser was suppressed for this database call during porting
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("Company_Finance_API.Get_Parallel_Acc_Currency",
                        System.Data.ParameterDirection.Input,
                        System.Data.ParameterDirection.Input);
                    DbPLSQLBlock(cSessionManager.c_hSql, lsStmt);
                }
                Sal.SendMsg(cmbDefaultLanguage, Sys.SAM_DropDown, 0, 0);
                cmbDefaultLanguage.EditDataItemValueSet(0, lsDefaultLanguage.ToHandle());
                Sal.SendMsg(cmbCountry, Sys.SAM_DropDown, 0, 0);
                cmbCountry.EditDataItemValueSet(0, lsCountry.ToHandle());
                dfsAccountingCurrency.Text = sCurrencyCode;
                dfdtValidFrom.DateTime = dValidFrom;
                dfdtTimeStamp.DateTime = sTimeStamp.ToDate();
                dfsParallelAccCurrency.Text = sParallellCurrency;
                if (dfsNewCompanyId.Text != Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    Sal.DisableWindow(cmbDefaultLanguage);
                    Sal.DisableWindow(cmbCountry);
                }
                if (sCurrencyCode != Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    Sal.DisableWindow(cmbDefaultLanguage);
                    Sal.DisableWindow(cmbCountry);
                    Sal.DisableWindow(dfsAccountingCurrency);
                    Sal.DisableWindow(dfdtValidFrom);
                    Sal.DisableWindow(dfsParallelAccCurrency);
                    Sal.DisableWindow(dfdtTimeStamp);
                }
            }

            return 0;
            #endregion
        }


        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber GetLanguages()
        {
            #region Local Variables
            SalString lsStmt = "";
            SalNumber i = 0;
            SalNumber nDummy = 0;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                sTemplateLngs.SetUpperBound(1, -1);
                sTemplateLngDescs.SetUpperBound(1, -1);
                if (rbCopyCompany.Checked)
                {
                    if (Ifs.Fnd.ApplicationForms.Var.Security.IsViewAvailable("Company_Translation_Lng"))
                    {
                        lsStmt = "SELECT language_code, &AO.Iso_Language_API.Decode(language_code) description into\r\n	" + sFullName + ".sTemplateLng, " + sFullName + ".sTemplateLngDesc\r\n" +
                        "	FROM &AO.Company_Translation_Lng\r\n" +
                        "	WHERE key_name = 'CompanyKeyLu'\r\n" +
                        "	AND key_value =  " + sFullName + ".dfsSourceCompanyId\r\n" +
                        "                order by 2";
                        DbPrepareAndExecute(cSessionManager.c_hSql, lsStmt);
                        while (DbFetchNext(cSessionManager.c_hSql, ref nDummy))
                        {
                            sTemplateLngs[i] = sTemplateLng;
                            sTemplateLngDescs[i] = sTemplateLngDesc;
                            i = i + 1;
                        }
                    }
                }
                else if (rbImportTemplate.Checked)
                {
                    if (Ifs.Fnd.ApplicationForms.Var.Security.IsViewAvailable("Templ_Translation_Lng"))
                    {
                        lsStmt = "SELECT language_code, &AO.Iso_Language_API.Decode(language_code) description into\r\n	" + sFullName + ".sTemplateLng, " + sFullName + ".sTemplateLngDesc\r\n" +
                        "	FROM &AO.Templ_Translation_Lng\r\n" +
                        "	WHERE key_name = 'TemplKeyLu'\r\n" +
                        "	AND key_value =  " + sFullName + ".dfsTemplateId\r\n" +
                        "                order by 2";
                        DbPrepareAndExecute(cSessionManager.c_hSql, lsStmt);
                        while (DbFetchNext(cSessionManager.c_hSql, ref nDummy))
                        {
                            sTemplateLngs[i] = sTemplateLng;
                            sTemplateLngDescs[i] = sTemplateLngDesc;
                            i = i + 1;
                        }
                    }
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber PackSelectedLangauges()
        {
            #region Local Variables
            SalNumber nSelected = 0;
            SalNumber nCounter = 0;
            SalNumber nIndex = 0;
            SalString strText = "";
            SalString sSelectedLanguage = "";
            SalArray<SalNumber> nSelectedArray = new SalArray<SalNumber>();
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                if (Sal.ListQueryMultiCount(lbLanguages) > 0)
                {
                    nSelected = Sal.ListQueryMultiCount(lbLanguages);
                    Sal.ListGetMultiSelect(lbLanguages, nSelectedArray);
                    sLanguages = Ifs.Fnd.ApplicationForms.Const.strNULL;
                    nCounter = 0;
                    while (nCounter < nSelected)
                    {
                        strText = Vis.ListGetText(lbLanguages, nSelectedArray[nCounter]);
                        nIndex = Vis.ArrayFindString(sTemplateLngDescs, strText);
                        sSelectedLanguage = sTemplateLngs[nIndex];
                        sLanguages = sLanguages + sSelectedLanguage + ((SalNumber)31).ToCharacter();
                        nCounter = nCounter + 1;
                    }
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber RefreshButtonsState()
        {
            #region Actions
            using (new SalContext(this))
            {
                pbNext.MethodInvestigateState();
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean ValidateAndGetSourceCompanyName()
        {
            #region Actions
            using (new SalContext(this))
            {
                lsNewCompanyName = Ifs.Fnd.ApplicationForms.Const.strNULL;
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("Company_API.Exist", System.Data.ParameterDirection.Input);
                    hints.Add("Company_API.Get_Name", System.Data.ParameterDirection.Input);
                    if (!(DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN\r\n" +
                        "		        &AO.Company_API.Exist(:i_hWndFrame.dlgCreateCompany.dfsSourceCompanyId);\r\n" +
                        "		        :i_hWndFrame.dlgCreateCompany.lsNewCompanyName :=\r\n" +
                        "		         &AO.Company_API.Get_Name(:i_hWndFrame.dlgCreateCompany.dfsSourceCompanyId);\r\n" +
                        "		      END;")))
                    {
                        return false;
                    }
                }
                if (lsNewCompanyName != Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    dfsSourceCompanyName.Text = lsNewCompanyName;
                }
                else
                {
                    dfsSourceCompanyName.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                }
                return true;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean ValidateAndGetTemplateName()
        {
            #region Actions
            using (new SalContext(this))
            {
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("Create_Company_Tem_API.Exist", System.Data.ParameterDirection.Input);
                    hints.Add("Create_Company_Tem_API.Get_Description", System.Data.ParameterDirection.Input);
                    if (!(DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN\r\n" +
                        "		        &AO.Create_Company_Tem_API.Exist(:i_hWndFrame.dlgCreateCompany.dfsTemplateId);\r\n" +
                        "		         :i_hWndFrame.dlgCreateCompany.lsTemplateName :=\r\n" +
                        "		         &AO.Create_Company_Tem_API.Get_Description(:i_hWndFrame.dlgCreateCompany.dfsTemplateId);\r\n" +
                        "		      END;")))
                    {
                        return false;
                    }
                }
                if (lsTemplateName != Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    dfsTemplateName.Text = lsTemplateName;
                }
                else
                {
                    dfsTemplateName.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                }
                return true;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber ValidateCompanyInfo()
        {
            #region Local Variables
            SalArray<SalString> sParam = new SalArray<SalString>();
            SalArray<SalString> sParam2 = new SalArray<SalString>();
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                if (Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Currency_Code_API.Get_Currency_Code_Attributes"))
                {
                    lsStmt = "Declare\r\n" +
                    "                     conv_factor_           NUMBER;\r\n" +
                    "                     currency_rounding_ NUMBER;\r\n" +
                    "                     decimals_in_rate_    NUMBER;\r\n" +
                    "                BEGIN\r\n" +
                    "	      &AO.Currency_Code_API.Get_Currency_Code_Attributes( conv_factor_,\r\n" +
                    "							  currency_rounding_,\r\n" +
                    "							  decimals_in_rate_,\r\n" +
                    "							  :i_hWndFrame.dlgCreateCompany.dfsSourceCompanyId,\r\n" +
                    "                      				  		  :i_hWndFrame.dlgCreateCompany.dfsAccountingCurrency);\r\n" +
                    "                      :i_hWndFrame.dlgCreateCompany.nAccCurrCheck := conv_factor_;\r\n" +
                    "	      &AO.Currency_Code_API.Get_Currency_Code_Attributes( conv_factor_,\r\n" +
                    "							  currency_rounding_,\r\n" +
                    "							  decimals_in_rate_,\r\n" +
                    "							  :i_hWndFrame.dlgCreateCompany.dfsSourceCompanyId,\r\n" +
                    "                      				  		  :i_hWndFrame.dlgCreateCompany.dfsParallelAccCurrency);\r\n" +
                    "                      :i_hWndFrame.dlgCreateCompany.nParallelCurrCheck := conv_factor_;\r\n" +
                    "                END;";
                    using (SignatureHints hints = SignatureHints.NewContext())
                    {
                        hints.Add("Currency_Code_API.Get_Currency_Code_Attributes", System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                        if (!(DbPLSQLBlock(cSessionManager.c_hSql, lsStmt)))
                        {
                            return false;
                        }
                    }
                    if (nAccCurrCheck == SalNumber.Null)
                    {
                        sParam[0] = dfsAccountingCurrency.Text;
                        sParam[1] = dfsSourceCompanyId.Text;
                        Ifs.Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.TEXT_AccCurrInfoMissing, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok, sParam);
                        return false;
                    }
                    if (dfsParallelAccCurrency.Text != Ifs.Fnd.ApplicationForms.Const.strNULL && nParallelCurrCheck == SalNumber.Null)
                    {
                        sParam2[0] = dfsParallelAccCurrency.Text;
                        sParam2[1] = dfsSourceCompanyId.Text;
                        Ifs.Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.TEXT_ParallelCurrInfoMissing, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok, sParam2);
                        return false;
                    }
                    return true;
                }
                return true;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber ValidateCurrency()
        {
            #region Actions
            using (new SalContext(this))
            {
                if (dfsParallelAccCurrency.Text != Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    lsStmt = "BEGIN \r\n" +
                    "	&AO.Iso_Currency_API.Exist (:i_hWndFrame.dlgCreateCompany.dfsAccountingCurrency);\r\n" +
                    "	&AO.Iso_Currency_API.Exist (:i_hWndFrame.dlgCreateCompany.dfsParallelAccCurrency);\r\n" +
                    "                END;";
                }
                else
                {
                    lsStmt = "BEGIN \r\n" +
                    "	&AO.Iso_Currency_API.Exist (:i_hWndFrame.dlgCreateCompany.dfsAccountingCurrency);\r\n" +
                    "                END;";
                }
                // Statement parser was suppressed for this database call during porting
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("Iso_Currency_API.Exist", System.Data.ParameterDirection.Input);
                    if (!(DbPLSQLBlock(cSessionManager.c_hSql, lsStmt)))
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
        public virtual SalNumber ValidateTemplateInfo()
        {
            #region Local Variables
            SalArray<SalString> sParam = new SalArray<SalString>();
            SalArray<SalString> sParam2 = new SalArray<SalString>();
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                if (Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Create_Company_Tem_API.Exist_Curr_Code_In_Template__"))
                {
                    lsStmt = "BEGIN\r\n" +
                    "	:i_hWndFrame.dlgCreateCompany.sAccCurrCheck := &AO.Create_Company_Tem_API.Exist_Curr_Code_In_Template__ ( :i_hWndFrame.dlgCreateCompany.dfsTemplateId,\r\n" +
                    "                        :i_hWndFrame.dlgCreateCompany.dfsAccountingCurrency);\r\n" +
                    "	:i_hWndFrame.dlgCreateCompany.sParallelCurrCheck := &AO.Create_Company_Tem_API.Exist_Curr_Code_In_Template__( :i_hWndFrame.dlgCreateCompany.dfsTemplateId,\r\n" +
                    "                        :i_hWndFrame.dlgCreateCompany.dfsParallelAccCurrency);\r\n" +
                    "                END;";
                    using (SignatureHints hints = SignatureHints.NewContext())
                    {
                        hints.Add("Create_Company_Tem_API.Exist_Curr_Code_In_Template__", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                        if (!(DbPLSQLBlock(cSessionManager.c_hSql, lsStmt)))
                        {
                            return false;
                        }
                    }
                    if (sAccCurrCheck != "TRUE")
                    {
                        sParam[0] = dfsAccountingCurrency.Text;
                        sParam[1] = dfsTemplateId.Text;
                        Ifs.Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.TEXT_TemAccCurrInfoMissing, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok, sParam);
                        return false;
                    }
                    if ((dfsParallelAccCurrency.Text != Ifs.Fnd.ApplicationForms.Const.strNULL) && (sParallelCurrCheck != "TRUE"))
                    {
                        sParam2[0] = dfsParallelAccCurrency.Text;
                        sParam2[1] = dfsTemplateId.Text;
                        Ifs.Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.TEXT_TemParallelCurrInfoMissing, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok, sParam2);
                        return false;
                    }
                    return true;
                }
                return true;
            }
            #endregion
        }

        public virtual void FetchCodePartInfo()
        {
            #region Actions
            using (new SalContext(this))
            {
                if (dfsTemplateId.Text != Fnd.ApplicationForms.Const.strNULL)
                {
                    DbPLSQLBlock(@"{0}:= &AO.Create_Company_Tem_Detail_API.Get_Curr_Bal_Code_Part__({1} IN);
                                        {2} := &AO.Create_Company_Tem_Detail_API.Get_Internal_Name__({1} IN,{0} IN);", dfsCodePart.QualifiedBindName, dfsTemplateId.QualifiedBindName, dfsInternalName.QualifiedBindName);
                }
                else if (dfsSourceCompanyId.Text != Fnd.ApplicationForms.Const.strNULL)
                {
                    if (Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Accounting_Code_Parts_API.Get_Codepart_Function_Db"))
                    {
                        DbPLSQLBlock(@"{0} := &AO.Accounting_Code_Parts_API.Get_Codepart_Function_Db({1} IN,{2} IN);", dfsCodePart.QualifiedBindName, dfsSourceCompanyId.QualifiedBindName, QualifiedVarBindName("sCurrBalFunction"));
                    }
                    if (Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Accounting_Code_Parts_API.Get_Code_Name"))
                    {
                        DbPLSQLBlock(@"{0} := &AO.Accounting_Code_Parts_API.Get_Code_Name({1} IN,{2} IN);", dfsInternalName.QualifiedBindName, dfsSourceCompanyId.QualifiedBindName, dfsCodePart.QualifiedBindName);
                    }
                }
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber ValidateUserDefinedCalendar()
        {
            #region Local Variables
            SalBoolean bIsOk = false;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                if (rbUserDefined.Checked == true)
                {
                    if (dfStartYear.Number == Sys.NUMBER_Null)
                    {
                        Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_StartYearNotNull, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                        return false;
                    }
                    else if (dfStartYear.Number < 1)
                    {
                        Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_NotAValidYear, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                        return false;
                    }
                    else if (dfStartYear.Number < dfAccYear.Number - 1)
                    {
                        Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_InvalidStartYear, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                        return false;
                    }
                    else if (dfStartYear.Number > dfAccYear.Number)
                    {
                        Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_InvalidStartYear, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                        return false;
                    }
                    if (dfAccYear.Number == Sys.NUMBER_Null)
                    {
                        Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_AccYearNotNull, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                        return false;
                    }
                    else if (dfAccYear.Number < 1)
                    {
                        Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_NotAValidAccYear, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                        return false;
                    }
                    if (dfStartMonth.Number == Sys.NUMBER_Null)
                    {
                        Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_StartMonthNotNull, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                        return false;
                    }
                    else if ((dfStartMonth.Number < 1) || (dfStartMonth.Number > 12))
                    {
                        Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_NotWithinMonthRange, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                        return false;
                    }
                    if (dfNumberOfYears.Number == Sys.NUMBER_Null)
                    {
                        Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_NumberOfYearsNotNull, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                        return false;
                    }
                    else if (dfNumberOfYears.Number < 1)
                    {
                        Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_NotPositiveYears, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                        return false;
                    }
                    if ((dfStartYear.Number != Sys.NUMBER_Null) && (dfStartMonth.Number != Sys.NUMBER_Null) && (dfNumberOfYears.Number != Sys.NUMBER_Null))
                    {
                        if (dfdtValidFrom.DateTime != Sys.DATETIME_Null)
                        {
                            bIsOk = true;
                            
                            if ((dfdtValidFrom.DateTime < dtUserDefinedCalendarStart) || (dfdtValidFrom.DateTime >= dtUserDefinedCalendarEnd))
                            {
                                Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_ValidFromNotInCalendar, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                                bIsOk = false;
                            }
                            if (!(bIsOk))
                            {
                                return false;
                            }
                        }
                    }
                }
                return true;
            }
            #endregion
        }

        /// <summary>
        /// This is called when the 'Finish' option is selected.
        /// To check the possibility of terminating the application
        /// a METHOD_Inquire is passed.
        /// To terminate the application a METHOD_Execute is passed.
        /// </summary>
        /// <param name="nWhat"></param>
        /// <param name="sStep"></param>
        /// <returns></returns>
        public new SalBoolean WizardFinish(SalNumber nWhat, SalString sStep)
        {
            #region Local Variables
            SalString lsAttr = "";
            SalString lsAttr1 = "";
            SalNumber nIndex = 0;
            SalString sReturn = "";
            SalArray<SalString> sItemNames = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
            SalString sCreationParams = "";
            SalString sCountryDb = "";
            SalString sDefaultLanguageDb = "";

            #endregion

            #region Actions
            using (new SalContext(this))
            {
                if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)
                {
                    return WizardIsLastStep();
                }
                if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                {
                    Sal.WaitCursor(true);
                    Ifs.Fnd.ApplicationForms.Var.g_Bind.Clear();
                    if (!DbPLSQLBlock(@"BEGIN
							               {0} :=&AO.Company_API.Check_Exist( {1} IN);
							               :g_Bind.s[0] := &AO.Iso_Language_API.Encode( {2} IN);
							               :g_Bind.s[1] := &AO.Iso_Country_API.Encode({3} IN);
                                           {4} := &AO.Parallel_Base_API.Encode( {5} IN);
     						            END;",
                                QualifiedVarBindName("sCompanyExist"),
                                dfsNewCompanyId.QualifiedBindName,
                                cmbDefaultLanguage.QualifiedBindName,
                                cmbCountry.QualifiedBindName,
                                QualifiedVarBindName("sParallelCurrBaseDb"),
                                cmbParallelCurBase.QualifiedBindName))
                    {
                        return false;
                    }
                    sDefaultLanguageDb = Ifs.Fnd.ApplicationForms.Var.g_Bind.s[0];
                    sCountryDb = Ifs.Fnd.ApplicationForms.Var.g_Bind.s[1];
                    Ifs.Fnd.ApplicationForms.Var.g_Bind.Clear();
                    // Adding all parameters set when creating the company. Will be stored in company LU
                    // Not correct way of calling a form like this, should be done by sending message

                    lsAttrEnt = CompanyInfo.BuildAttrEnt(ref lsAttr1);
                    lsCreateAttrModule = CompanyInfo.BuildAttrModule(ref lsCreateAttrModule);
                    Ifs.Fnd.ApplicationForms.Int.PalAttrAddNumber("START_YEAR", dfStartYear.Number, ref lsCreateAttrModule);
                    Ifs.Fnd.ApplicationForms.Int.PalAttrAddNumber("START_MONTH", dfStartMonth.Number, ref lsCreateAttrModule);
                    Ifs.Fnd.ApplicationForms.Int.PalAttrAddNumber("NUMBER_OF_YEARS", dfNumberOfYears.Number, ref lsCreateAttrModule);
                    Ifs.Fnd.ApplicationForms.Int.PalAttrAddNumber("ACC_YEAR", dfAccYear.Number, ref lsCreateAttrModule);

                    sLogicalAccTypes = "";
                    if (cbAssets.Value == "TRUE")
                    {
                        sLogicalAccTypes = sLogicalAccTypes == "" ? "A" : (string)sLogicalAccTypes + "^A";
                    }
                    if (cbCost.Value == "TRUE")
                    {
                        sLogicalAccTypes = sLogicalAccTypes == "" ? "C" : (string)sLogicalAccTypes + "^C";
                    }
                    if (cbLiabilities.Value == "TRUE")
                    {
                        sLogicalAccTypes = sLogicalAccTypes == "" ? "L" : (string)sLogicalAccTypes + "^L";
                    }                    
                    if (cbRevenues.Value == "TRUE")
                    {
                        sLogicalAccTypes = sLogicalAccTypes == "" ? "R" : (string)sLogicalAccTypes + "^R";
                    }
                    if (cbStatistics.Value == "TRUE")
                    {
                        sLogicalAccTypes = sLogicalAccTypes == "" ? "S" : (string)sLogicalAccTypes + "^S";
                    }
                    if (cbStatOpenBal.Value == "TRUE")
                    {
                        sLogicalAccTypes = sLogicalAccTypes == "" ? "O" : (string)sLogicalAccTypes + "^O";
                    }

                    Fnd.ApplicationForms.Int.PalAttrAdd("LOGICAL_ACC_TYPES", sLogicalAccTypes, ref lsCreateAttrModule);
                    Fnd.ApplicationForms.Int.PalAttrAdd("CURR_BAL_CODE_PART", dfsCodePart.Text, ref lsCreateAttrModule);
                    Fnd.ApplicationForms.Int.PalAttrAdd("CURR_BAL_CODE_PART_DESC", dfsInternalName.Text, ref lsCreateAttrModule);
                    if (rbUserDefined.Checked == true)
                    {
                        Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("USER_DEFINED", "TRUE", ref lsCreateAttrModule);
                    }
                    else
                    {
                        Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("USER_DEFINED", "FALSE", ref lsCreateAttrModule);
                    }
                    if (cbMasterCompany.Checked == true)
                    {
                        Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("MASTER_COMPANY_DB", "TRUE", ref lsCreateAttrModule);
                    }
                    else
                    {
                        Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("MASTER_COMPANY_DB", "FALSE", ref lsCreateAttrModule);
                    }
                    Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("LANGUAGES", Vis.StrSubstitute(sLanguages, ((SalNumber)31).ToCharacter(), "^"), ref lsCreateAttrModule);
                    Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("DEFAULT_LANGUAGE_DB", sDefaultLanguageDb, ref lsCreateAttrModule);
                    Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("COUNTRY_DB", sCountryDb, ref lsCreateAttrModule);
                    Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("MAIN_PROCESS", "CREATE COMPANY", ref lsCreateAttrModule);
                    // The creation parameters are used by some LU's, especially LU CompanyFinance and UserFinance
                    sCreationParams = ConvertAttrToMessage(lsCreateAttrModule);
                    Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("CREATION_PARAMETERS", sCreationParams, ref lsAttrEnt);
                    if (cbMasterCompany.Checked == true)
                    {
                        Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("MASTER_COMPANY_DB", "TRUE", ref lsAttrEnt);
                    }
                    else
                    {
                        Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("MASTER_COMPANY_DB", "FALSE", ref lsAttrEnt);
                    }
                    if (sCompanyExist != "TRUE")
                    {
                        using (SignatureHints hints = SignatureHints.NewContext())
                        {
                            hints.Add("Company_API.New_Company", System.Data.ParameterDirection.Input);
                            if (!(DbPLSQLBlock(cSessionManager.c_hSql, "&AO.Company_API.New_Company( :i_hWndFrame.dlgCreateCompany.lsAttrEnt )")))
                            {
                                return false;
                            }
                        }
                    }
                    else
                    {
                        lsAttrEnt = CompanyInfo.BuildAttrEnt1(ref lsAttr1);
                        using (SignatureHints hints = SignatureHints.NewContext())
                        {
                            hints.Add("Company_API.Update_Company", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                            if (!(DbPLSQLBlock(cSessionManager.c_hSql, "&AO.Company_API.Update_Company( :i_hWndFrame.dlgCreateCompany.dfsNewCompanyId, \r\n" +
                                "                                                                                                                                :i_hWndFrame.dlgCreateCompany.lsAttrEnt )")))
                            {
                                return false;
                            }
                        }
                    }
                    lsAccrulAttr = CompanyInfo.BuildAttr(ref lsAttr);
                    lsCreateAttrOut = CompanyInfo.BuildAttr1(ref lsCreateAttrOut);
                    using (SignatureHints hints = SignatureHints.NewContext())
                    {
                        hints.Add("Create_Company_API.New_Company__", System.Data.ParameterDirection.InputOutput);
                        if (!(DbPLSQLBlock(cSessionManager.c_hSql, "&AO.Create_Company_API.New_Company__( " + sFullName + ".lsCreateAttrOut )")))
                        {
                            return false;
                        }
                    }
                    Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("FROM_WINDOW", "CREATE_COMPANY", ref lsCreateAttrModule);

                    Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("PARALLEL_CURR_BASE", sParallelCurrBaseDb, ref lsCreateAttrModule);

                    sReturn = DisplayProgresBar();
                    // Update info to implementation table create_company_log_imp_tab
                    using (SignatureHints hints = SignatureHints.NewContext())
                    {
                        hints.Add("Create_Company_Log_API.Add_To_Imp_Table__", System.Data.ParameterDirection.Input);
                        hints.Add("Create_Company_Log_API.Update_Log_Tab_To_Comments__", System.Data.ParameterDirection.Input);
                        DbPLSQLTransaction(cSessionManager.c_hSql, " &AO.Create_Company_Log_API.Add_To_Imp_Table__( :i_hWndFrame.dlgCreateCompany.dfsNewCompanyId);\r\n" +
                            "			      &AO.Create_Company_Log_API.Update_Log_Tab_To_Comments__( :i_hWndFrame.dlgCreateCompany.dfsNewCompanyId) ");
                    }
                    if (sErrorCreated == "TRUE")
                    {
                        if (Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_NoSuccessOpenLog, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.QUESTION_YesNo) == Sys.IDYES)
                        {
                            sReturn = "OPEN_LOG";
                        }
                    }
                    else if (sErrorCreated == "FALSE")
                    {
                        Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_Success, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                    }
                    else if (sErrorCreated == "COMMENTS")
                    {
                        Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_Success, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                    }

                    Sal.WaitCursor(false);
                    if (sReturn == "OPEN_LOG")
                    {
                        Sal.WaitCursor(true);
                        sItemNames[0] = "COMPANY";
                        hWndItems[0] = dfsNewCompanyId;
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init(Pal.GetActiveInstanceName("dlgCreateCompany"), i_hWndFrame, sItemNames, hWndItems);
                        SessionCreateWindow(Pal.GetActiveInstanceName("tbwCompanyComponentLog"), Sys.hWndMDI);
                        Sal.WaitCursor(false);
                    }
                    return ((cWizardDialogBox)this).WizardFinish(nWhat, sStep);
                }
            }

            return false;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <param name="sStep"></param>
        /// <returns></returns>
        public new SalBoolean WizardNext(SalNumber nWhat, SalString sStep)
        {
            #region Local Variables
            SalBoolean sAbort = false;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                if (nWhat == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)
                {
                    if (sStep == "StepTwo")
                    {
                        if ((dfsNewCompanyId.Text == Ifs.Fnd.ApplicationForms.Const.strNULL) || (dfsNewCompanyName.Text == Ifs.Fnd.ApplicationForms.Const.strNULL))
                        {
                            return false;
                        }
                        return m_nCurrentPage + 1 < m_nTotalPages;
                    }
                    else if (sStep == "StepThree")
                    {
                        if (rbCopyCompany.Checked)
                        {
                            this.dfsTemplateName.EditDataItemFlagSet(Ifs.Fnd.ApplicationForms.Const.FIELD_Required, false);
                            if (dfsSourceCompanyId.Text == Ifs.Fnd.ApplicationForms.Const.strNULL)
                            {
                                return false;
                            }
                            else
                            {
                                return m_nCurrentPage + 1 < m_nTotalPages;
                            }
                        }
                        else
                        {
                            this.dfsTemplateName.EditDataItemFlagSet(Ifs.Fnd.ApplicationForms.Const.FIELD_Required, true);
                            if (dfsTemplateId.Text == Ifs.Fnd.ApplicationForms.Const.strNULL)
                            {
                                return false;
                            }
                            else
                            {
                                return m_nCurrentPage + 1 < m_nTotalPages;
                            }
                        }
                    }
                    else if (sStep == "StepFour")
                    {
                        return m_nCurrentPage + 1 < m_nTotalPages;
                    }
                    else if (sStep == "StepFive")
                    {
                        if (rbUserDefined.Checked == true && (dfStartYear.Number == Sys.NUMBER_Null || dfStartMonth.Number == Sys.NUMBER_Null || dfNumberOfYears.Number == Sys.NUMBER_Null))
                        {
                            return false;
                        }
                        // (+/-) 130129 NILILK C_G1219089-1 DANU - 271, Modified IF Condition.
                        if ((dfsAccountingCurrency.Text == Ifs.Fnd.ApplicationForms.Const.strNULL) || (dfdtValidFrom.DateTime == Sys.DATETIME_Null) || (cmbDefaultLanguage.Text == Ifs.Fnd.ApplicationForms.Const.strNULL) || (cmbCountry.Text == Ifs.Fnd.ApplicationForms.Const.strNULL) || (cmbParallelCurBase.Text != Ifs.Fnd.ApplicationForms.Const.strNULL && dfsParallelAccCurrency.Text == Ifs.Fnd.ApplicationForms.Const.strNULL) || (dfsParallelAccCurrency.Text != Ifs.Fnd.ApplicationForms.Const.strNULL && cmbParallelCurBase.Text == Ifs.Fnd.ApplicationForms.Const.strNULL))
                        {
                            return false;
                        }
                        else
                        {
                            return m_nCurrentPage + 1 < m_nTotalPages;
                        }
                    }
                    else if (sStep == "StepSix")
                    {     
                        if (rbYes.Checked && dfsCodePart.Text == Fnd.ApplicationForms.Const.strNULL)
                        {
                            dfsCodePart.EditDataItemFlagSet(Fnd.ApplicationForms.Const.FIELD_Required, true);
                            dfsInternalName.EditDataItemFlagSet(Fnd.ApplicationForms.Const.FIELD_Required, true);
                            return false;
                        }                                                       
                        return m_nCurrentPage + 1 < m_nTotalPages;                                                
                    }
                    return m_nCurrentPage + 1 < m_nTotalPages;
                }
                else
                {
                    if (sStep == "StepTwo")
                    {
                        if (AllFieldsValidate(sStep))
                        {
                            return true;
                        }
                    }
                    else if (sStep == "StepThree")
                    {
                        if (CheckIfOptionChanged())
                        {
                            GetLanguages();
                            FetchToLngListBox();
                        }
                        if (AllFieldsValidate(sStep))
                        {
                            return true;
                        }
                    }
                    else if (sStep == "StepFour")
                    {
                        if (cbMasterCompany.Checked)
                        {
                            dfsParallelAccCurrency.Clear();
                            dfdtTimeStamp.Clear();
                            Sal.DisableWindowAndLabel(dfsParallelAccCurrency);
                            Sal.DisableWindowAndLabel(cmbParallelCurBase);
                            Sal.DisableWindowAndLabel(dfdtTimeStamp);
                        }
                        else
                        {
                            Sal.EnableWindowAndLabel(dfsParallelAccCurrency);
                            Sal.EnableWindowAndLabel(cmbParallelCurBase);
                            Sal.EnableWindowAndLabel(dfdtTimeStamp);
                        }

                        //Sal.DisableWindow(this.cmbParallelCurBase);

                        if (AllFieldsValidate(sStep))
                        {
                            return true;
                        }
                    }
                    else if (sStep == "StepFive")
                    {
                        bDefaultCodePartExist = false;                        

                        if (dfsCodePart.Text == Fnd.ApplicationForms.Const.strNULL )
                        {
                            FetchCodePartInfo();
                            if (dfsCodePart.Text != Fnd.ApplicationForms.Const.strNULL)
                            {
                                bDefaultCodePartExist = true;
                                Sal.DisableWindowAndLabel(rbYes);
                                Sal.DisableWindowAndLabel(rbNo);
                            }
                            else
                            {
                                dfsCodePart.Text = sCodePartIdVal != "" ? sCodePartIdVal.ToString() : "";
                                dfsInternalName.Text = sCodePartNameVal != "" ? sCodePartNameVal.ToString() : "";
                            }
                        }                                                 

                        if (dfdtTimeStamp.DateTime == Sys.DATETIME_Null)
                        {
                            dfdtTimeStamp.DateTime = dfdtValidFrom.DateTime;
                        }
                        if (this.dfsAccountingCurrency.Text == this.dfsParallelAccCurrency.Text)
                        {
                            if (Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_ParallelAccNext, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Question, (Ifs.Fnd.ApplicationForms.Const.QUESTION_YesNo | Sys.MB_DefButton2)) != Sys.IDYES)
                            {
                                return false;
                            }
                        }
                        if ((this.cmbParallelCurBase.Text == Sys.STRING_Null) && (this.dfsParallelAccCurrency.Text != Sys.STRING_Null))
                        {
                            Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_ParallelCurrBase, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                            return false;
                        }

                        PackSelectedLangauges();
                        if (AllFieldsValidate(sStep))
                        {
                            return true;
                        }
                    }
                    else if (sStep == "StepSix")
                    {
                        sCodePartIdVal = dfsCodePart.Text;
                        sCodePartNameVal = dfsInternalName.Text;
                        bUseCurrBalCodePart = rbYes.Checked ? true : false;
                        return rbNo.Checked ? true : dfsCodePart.Text != Fnd.ApplicationForms.Const.strNULL;
                    }
                    return false;
                }
            }
            #endregion
        }

        /// <summary>
        /// The WizardStepActivated hook function is called by the framework when just
        /// after a step has been activated. Application should override this function
        /// to perform task upon activation of a step.
        /// COMMENTS:
        /// A typical task to perform on activation of a step would be to display any
        /// values previously entered for this step (for example if the user has
        /// activated this step before, moved on to another step, and now reactivated
        /// this step)
        /// 
        /// For steps that use external windows it is usually better to override the
        /// FramActivate function in the external window to perform activation tasks.
        /// EXAMPLE:
        /// Function: WizarStepActivated
        /// 	Actions
        /// 		! Display laster enetered values
        /// 		Set rbLocalPrinter = PalStrToBoolean( MsgData.FindAttribute( 'LOCAL_PRINTER', 'TRUE' ) )
        /// 		Set rbNetworkPrinter = Not PalStrToBoolean( MsgData.FindAttribute( 'LOCAL_PRINTER', 'TRUE' ) )
        /// 		Set dfPrinterName = MsgData.FindAttribute( 'PRINTER_NAME', STRING_Null )
        /// </summary>
        /// <param name="sStep">
        /// Step name
        /// Name of the step just activated.
        /// </param>
        /// <returns></returns>
        public new SalNumber WizardStepActivated(SalString sStep)
        {
            #region Local Variables
            SalString lsStmt = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                if (sStep == "StepOne")
                {
                    sOldStep = sStep;
                    Ifs.Fnd.ApplicationForms.Int.PostMessage(this, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, "SetFocusNewCompanyId");
                }
                else if (sStep == "StepTwo")
                {
                    if (sOldStep != "StepThree")
                    {
                        sOldStep = sStep;
                        Sal.DisableWindow(dfsSourceCompanyId);
                        Sal.DisableWindow(dfsSourceCompanyName);
                        Sal.ClearField(dfsSourceCompanyId);
                        Sal.ClearField(dfsSourceCompanyName);
                        rbImportTemplate.Checked = true;
                        Sal.EnableWindow(dfsTemplateId);
                        Sal.EnableWindow(dfsTemplateName);
                        if (dfsTemplateId.Text == Sys.STRING_Null)
                        {
                            lsStmt = "Declare\r\n" +
                            "                     template_id_ varchar2(30);\r\n" +
                            "                BEGIN\r\n" +
                            "	&AO.Create_Company_Tem_API.Get_Default_Template__ ( template_id_);\r\n" +
                            "                :i_hWndFrame.dlgCreateCompany.lsDefaultTemplateName := &AO.Create_Company_Tem_API.Get_Description(template_id_);\r\n" +
                            "                :i_hWndFrame.dlgCreateCompany.sDefaultTemplateId := template_id_;\r\n" +
                            "                END;";
                            using (SignatureHints hints = SignatureHints.NewContext())
                            {
                                hints.Add("Create_Company_Tem_API.Get_Default_Template__", System.Data.ParameterDirection.InputOutput);
                                hints.Add("Create_Company_Tem_API.Get_Description", System.Data.ParameterDirection.Input);
                                DbPLSQLBlock(cSessionManager.c_hSql, lsStmt);
                            }
                            dfsTemplateId.Text = sDefaultTemplateId;
                            dfsTemplateName.Text = lsDefaultTemplateName;
                            dfsTemplateId.EditDataItemSetEdited();
                            dfsTemplateName.EditDataItemSetEdited();
                        }
                        Sal.SetFocus(dfsTemplateId);
                    }
                    Sal.SetFocus(dfsTemplateId);
                }
                else if (sStep == "StepThree")
                {
                    sOldStep = sStep;
                    Sal.SetFocus(lbLanguages);
                }
                else if (sStep == "StepFour")
                {
                    if ((rbSourceTemplateCompany.Checked == false && rbUserDefined.Checked == false) || rbSourceTemplateCompany.Checked == true)
                    {
                        rbSourceTemplateCompany.Checked = true;
                        rbUserDefined.Checked = false;
                        Sal.ClearField(dfStartYear);
                        Sal.ClearField(dfStartMonth);
                        Sal.ClearField(dfNumberOfYears);
                        Sal.DisableWindow(dfStartYear);
                        Sal.DisableWindow(dfStartMonth);
                        Sal.DisableWindow(dfNumberOfYears);
                        if (dfsParallelAccCurrency.Text == Sys.STRING_Null)
                        {
                            Sal.DisableWindow(cmbParallelCurBase);
                        }
                        Sal.SetFocus(rbSourceTemplateCompany);
                    }
                    sOldStep = sStep;
                    Sal.SendMsg(this.cmbDefaultLanguage, Sys.SAM_DropDown, 0, 0);
                    Sal.SendMsg(cmbCountry, Sys.SAM_DropDown, 0, 0);
                    if (sCreationFinished != Ifs.Fnd.ApplicationForms.Const.strNULL)
                    {
                        GetAccountingInfo();
                    }
                    dfsCodePart.Text = "";
                    dfsInternalName.Text = "";
                }
                else if (sStep == "StepFive")
                {
                    if (cbMasterCompany.Checked)
                    {
                        rbNo.Checked = true;
                        Sal.DisableWindowAndLabel(rbYes);
                        Sal.SendMsg(rbNo, Sys.SAM_Click, Sys.wParam, Sys.lParam);
                    }
                    else
                    {
                        Sal.EnableWindowAndLabel(rbYes);
                        Sal.SendMsg(rbYes, Sys.SAM_Click, Sys.wParam, Sys.lParam);
                        rbYes.Checked = true;
                        if (sOldStep != "StepSix" && !cbMasterCompany.Checked)
                        {
                            Sal.EnableWindow(dfsCodePart);
                        }
                        else
                        {
                            dfsCodePart.Text = sCodePartIdVal;
                            dfsInternalName.Text = sCodePartNameVal;
                            if (bUseCurrBalCodePart)
                            {
                                rbYes.Checked = true;
                            }
                            else
                            {
                                rbNo.Checked = true;
                            }
                        }

                        dfsCodePart.EditDataItemSetEdited();
                        dfsInternalName.EditDataItemSetEdited();

                        if (dfsCodePart.Text != Fnd.ApplicationForms.Const.strNULL && bDefaultCodePartExist)
                        {
                            Sal.DisableWindow(dfsCodePart);
                        }
                        else
                        {
                            if (dfsSourceCompanyId.Text == "" && dfsTemplateId.Text != "")
                            {
                                dfsCodePart.p_sLovReference = "CURR_BAL_CODE_PART_LOV(TEMPLATE_ID)";
                            }
                            else if (dfsSourceCompanyId.Text != "" && dfsTemplateId.Text == "")
                            {
                                dfsCodePart.p_sLovReference = "CREATE_COM_CURR_BAL_LOV(COMPANY)";
                            }
                        }
                    }             
                    
                    sOldStep = sStep;                    
                }
                else if (sStep == "StepSix")
                {
                    sOldStep = sStep;
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber EnableDisablePeriod()
        {
            #region Actions
            using (new SalContext(this))
            {
                lsPeriodUsed = SalString.Null;
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("COMPANY_FINANCE_API.Get_Use_Vou_No_Period", System.Data.ParameterDirection.Input);
                    DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN\r\n" +
                        "		:i_hWndFrame.dlgCreateCompany.lsPeriodUsed := &AO.COMPANY_FINANCE_API.Get_Use_Vou_No_Period(:i_hWndFrame.dlgCreateCompany.dfsSourceCompanyId);\r\n		 END;");
                }
                if (dlgCreateCompany.FromHandle(i_hWndFrame).lsPeriodUsed == "TRUE" && rbSourceTemplateCompany.Checked)
                {
                    cbUsePeriod.Checked = true;
                    Sal.DisableWindow(dlgCreateCompany.FromHandle(i_hWndFrame).cbUsePeriod);
                }
                else
                {
                    cbUsePeriod.Checked = Sys.STRING_Null;
                    Sal.EnableWindow(dlgCreateCompany.FromHandle(i_hWndFrame).cbUsePeriod);
                }
            }

            return 0;
            #endregion
        }
        


        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber ValidateValidFrom()
        {
            #region Actions
            using (new SalContext(this))
            {
                if (dfdtValidFrom.DateTime != Sys.DATETIME_Null)
                {
                    dfdtTimeStamp.DateTime = dfdtValidFrom.DateTime;
                }
                if (dfdtValidFrom.DateTime != Sys.DATETIME_Null)
                {
                    if ((dfStartYear.Number != Sys.NUMBER_Null) && (dfStartMonth.Number != Sys.NUMBER_Null) && (dfNumberOfYears.Number != Sys.NUMBER_Null))
                    {
                        if ((dfdtValidFrom.DateTime < dtUserDefinedCalendarStart) || (dfdtValidFrom.DateTime >= dtUserDefinedCalendarEnd))
                        {
                            return Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_ValidFromNotInCalendar, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                        }
                    }
                    if (dfdtTimeStamp.DateTime == Sys.DATETIME_Null)
                    {
                        if ((dfdtValidFrom.DateTime != Sys.DATETIME_Null) && (dfsParallelAccCurrency.Text != Ifs.Fnd.ApplicationForms.Const.strNULL))
                        {
                            dfdtTimeStamp.DateTime = dfdtValidFrom.DateTime;
                        }
                    }                    
                }
                return true;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber ValidateStartYear()
        {
            #region Actions
            using (new SalContext(this))
            {
                if (dfStartYear.Number != Sys.NUMBER_Null)
                {
                    if (dfStartYear.Number < 1)
                    {
                        Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_NotAValidYear, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                        return Sys.VALIDATE_Cancel;
                    }
                    else if (dfStartYear.Number < dfAccYear.Number - 1)
                    {
                        Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_InvalidStartYear, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                        return Sys.VALIDATE_Cancel;
                    }
                    else if (dfStartYear.Number > dfAccYear.Number)
                    {
                        Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_InvalidStartYear, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                        return Sys.VALIDATE_Cancel;
                    }
                    else
                    {
                        dfStartMonth.Number = Sys.NUMBER_Null;
                        Sal.DisableWindow(pbNext);
                    }
                    ValidateCalendarDataFields();
                }
                else
                {
                    Sal.DisableWindow(pbNext);
                }
                return true;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber ValidateStartMonth()
        {
            #region Actions
            using (new SalContext(this))
            {
                if (dfStartMonth.Number != Sys.NUMBER_Null)
                {
                    if ((dfStartMonth.Number < 1) || (dfStartMonth.Number > 12))
                    {
                        Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_NotWithinMonthRange, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                        return Sys.VALIDATE_Cancel;
                    }
                    if ((dfStartMonth.Number == 1) && (dfStartYear.Number < dfAccYear.Number))
                    {
                        Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_MonthTooSmallForAccYear, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                        return Sys.VALIDATE_Cancel;
                    }
                    ValidateCalendarDataFields();
                }
                else
                {
                    Sal.DisableWindow(pbNext);
                }
                return true;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber ValidateNumberOfYears()
        {
            #region Actions
            using (new SalContext(this))
            {
                if (dfNumberOfYears.Number != Sys.NUMBER_Null)
                {
                    if (dfNumberOfYears.Number < 1)
                    {
                        Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_NotPositiveYears, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                        return Sys.VALIDATE_Cancel;
                    }
                    else if (dfNumberOfYears.Number > 99)
                    {
                        Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_NotThreeDigitsYears, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                        return Sys.VALIDATE_Cancel;
                    }
                    ValidateCalendarDataFields();
                }
                else
                {
                    Sal.DisableWindow(pbNext);
                }
                return true;
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber ValidateCalendarDataFields()
        {
            #region Actions
            using (new SalContext(this))
            {
                if ((dfAccYear.Number != Sys.NUMBER_Null) && (dfStartYear.Number != Sys.NUMBER_Null) && (dfStartMonth.Number != Sys.NUMBER_Null) && (dfNumberOfYears.Number != Sys.NUMBER_Null))
                {
                    dtUserDefinedCalendarStart = new SalDateTime(dfStartYear.Number, dfStartMonth.Number, 1, 0, 0, 0);
                    dtUserDefinedCalendarEnd = new SalDateTime(dfStartYear.Number + dfNumberOfYears.Number, dfStartMonth.Number, 1, 0, 0, 0);
                    if ((dfdtValidFrom.DateTime == Sys.DATETIME_Null) && (dfsAccountingCurrency.Text != Ifs.Fnd.ApplicationForms.Const.strNULL))
                    {
                        dfdtValidFrom.DateTime = dtUserDefinedCalendarStart;
                    }
                    if ((dfdtTimeStamp.DateTime == Sys.DATETIME_Null) && (dfsParallelAccCurrency.Text != Ifs.Fnd.ApplicationForms.Const.strNULL))
                    {
                        dfdtTimeStamp.DateTime = dfdtValidFrom.DateTime;
                    }
                    if ((dfdtValidFrom.DateTime != Sys.DATETIME_Null) && ((dfdtValidFrom.DateTime < dtUserDefinedCalendarStart) || (dfdtValidFrom.DateTime >= dtUserDefinedCalendarEnd)))
                    {
                        Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_ValidFromNotInCalendar, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                    }
                    Sal.EnableWindow(pbNext);
                    RefreshButtonsState();
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber ValidateAccYear()
        {
            #region Actions
            using (new SalContext(this))
            {
                if (dfAccYear.Number != Sys.NUMBER_Null)
                {
                    if (dfAccYear.Number < 1)
                    {
                        Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_NotAValidAccYear, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                        return Sys.VALIDATE_Cancel;
                    }
                    dfStartYear.Number = dfAccYear.Number;
                    dfStartMonth.Number = 1;
                    ValidateCalendarDataFields();
                }
                else
                {
                    Sal.DisableWindow(pbNext);
                }
                return true;
            }
            #endregion
        }
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber EnableDisableLanuageButtons()
        {
            #region Local Variables
            SalArray<SalNumber> nIndexArr = new SalArray<SalNumber>();
            SalNumber nItemCount = 0;
            SalNumber nItemArrCount = 0;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                nItemCount = 0;
                nItemArrCount = 0;
                nIndexArr.SetUpperBound(1, -1);
                Sal.ListGetMultiSelect(lbLanguages, nIndexArr);
                if (nIndexArr.IsEmpty)
                {
                    Sal.DisableWindow(pbUnSelectAll);
                    Sal.EnableWindow(pbSelectAll);
                    Sal.DisableWindow(pbNext);
                }
                else
                {
                    nItemCount = Sal.ListQueryCount(lbLanguages);
                    nItemArrCount = nIndexArr.GetUpperBound(1);
                    if (nItemCount == nItemArrCount + 1)
                    {
                        Sal.DisableWindow(pbSelectAll);
                        Sal.EnableWindow(pbUnSelectAll);
                        Sal.EnableWindow(pbNext);
                    }
                    else
                    {
                        Sal.EnableWindow(pbUnSelectAll);
                        Sal.EnableWindow(pbSelectAll);
                        Sal.EnableWindow(pbNext);
                    }
                }
            }

            return 0;
            #endregion
        }
        // Uncheck Language List box
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean UnCheckLngListBox()
        {
            #region Local Variables
            SalNumber nListBoxCount = 0;
            SalNumber nListBoxCountTemp = 0;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                nListBoxCount = Sal.ListQueryCount(lbLanguages);
                nListBoxCountTemp = 0;
                Sal.ListClear(lbLanguages);
                while (nListBoxCountTemp < nListBoxCount)
                {
                    lbLanguages.AddValue(sTemplateLngDescs[nListBoxCountTemp], false, nListBoxCountTemp);
                    nListBoxCountTemp = nListBoxCountTemp + 1;
                }
                Sal.EnableWindow(pbSelectAll);
                Sal.DisableWindow(pbUnSelectAll);
                Sal.DisableWindow(pbNext);
                return true;
            }
            #endregion
        }
        // Validate the push button state
        /// <summary>
        /// </summary>
        /// <param name="sEvent"></param>
        /// <returns></returns>
        public virtual SalBoolean ValidateLanguageButtonState(SalString sEvent)
        {
            #region Local Variables
            SalArray<SalNumber> nIndexArr = new SalArray<SalNumber>();
            SalNumber nItemCount = 0;
            SalNumber nItemArrCount = 0;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                nIndexArr.SetUpperBound(1, -1);
                nItemCount = 0;
                nItemArrCount = 0;
                Sal.ListGetMultiSelect(lbLanguages, nIndexArr);
                if (sEvent == "unselect")
                {
                    if (nIndexArr.IsEmpty)
                    {
                        return false;
                    }
                    else
                    {
                        nItemCount = Sal.ListQueryCount(lbLanguages);
                        nItemArrCount = nIndexArr.GetUpperBound(1);
                        if (nItemCount == nItemArrCount + 1)
                        {
                            return true;
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    if (nIndexArr.IsEmpty)
                    {
                        return true;
                    }
                    else
                    {
                        nItemCount = Sal.ListQueryCount(lbLanguages);
                        nItemArrCount = nIndexArr.GetUpperBound(1);
                        if (nItemCount == nItemArrCount + 1)
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
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
        private void dlgCreateCompany_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_Create:
                    this.dlgCreateCompany_OnSAM_Create(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceQueryFieldName:
                    this.dlgCreateCompany_OnPM_DataSourceQueryFieldName(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_User:
                    this.dlgCreateCompany_OnPM_User(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_Create event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dlgCreateCompany_OnSAM_Create(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam);
            this.sFullName = ":i_hWndFrame." + Ifs.Fnd.ApplicationForms.Int.QualifiedItemNameGet(this);
            #endregion
        }

        /// <summary>
        /// PM_DataSourceQueryFieldName event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dlgCreateCompany_OnPM_DataSourceQueryFieldName(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (SalString.FromHandle(Sys.lParam) == "DOMAIN_ID")
            {
                e.Return = (this.i_hWndFrame.ToNumber().ToString(0) + "." + Ifs.Fnd.ApplicationForms.Int.QualifiedItemNameGet(this.i_hWndFrame) + ".dfsDomainId").ToHandle();
                return;
            }
            #endregion
        }

        /// <summary>
        /// PM_User event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dlgCreateCompany_OnPM_User(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                if (SalString.FromHandle(Sys.lParam) == "Focus")
                {
                    Sal.SetFocus(this.pbNext);
                }
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void dfsNewCompanyId_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.dfsNewCompanyId_OnPM_DataItemValidate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovDone:
                    this.dfsNewCompanyId_OnPM_DataItemLovDone(sender, e);
                    break;

                case Sys.SAM_AnyEdit:
                    e.Handled = true;
                    this.RefreshButtonsState();
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsNewCompanyId_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam))
            {
                if (this.dfsNewCompanyId.Text != Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    this.dfsNewCompanyId.Text = ((SalString)this.dfsNewCompanyId.Text).Trim();
                    this.nTemp1 = ((SalString)this.dfsNewCompanyId.Text).Scan("\\%");
                    this.nTemp2 = ((SalString)this.dfsNewCompanyId.Text).Scan("\\_");
                    this.nTemp3 = ((SalString)this.dfsNewCompanyId.Text).Scan("&");
                    if (this.nTemp1 > -1 || this.nTemp2 > -1 || this.nTemp3 > -1)
                    {
                        Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_Wildcard, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
                        e.Return = Sys.VALIDATE_Cancel;
                        return;
                    }
                    this.lsStmt = "BEGIN\r\n		" + this.sFullName + ".sCreationFinished :=&AO.Company_Finance_API.Get_Creation_Finished (" + this.sFullName + ".dfsNewCompanyId);\r\n" +
                    "		:i_hWndFrame.dlgCreateCompany.lsNewCompanyName := &AO.Company_API.Get_Name(:i_hWndFrame.dlgCreateCompany.dfsNewCompanyId);\r\n" +
                    "	     END;";
                    using (SignatureHints hints = SignatureHints.NewContext())
                    {
                        hints.Add("Company_Finance_API.Get_Creation_Finished", System.Data.ParameterDirection.Input);
                        hints.Add("Company_API.Get_Name", System.Data.ParameterDirection.Input);
                        this.dfsNewCompanyId.DbPLSQLBlock(cSessionManager.c_hSql, this.lsStmt);
                    }
                    if (this.lsNewCompanyName != Ifs.Fnd.ApplicationForms.Const.strNULL)
                    {
                        this.dfsNewCompanyName.Text = this.lsNewCompanyName;
                    }
                    this.RefreshButtonsState();
                    if (this.sCreationFinished != "TRUE" && this.lsNewCompanyName != Ifs.Fnd.ApplicationForms.Const.strNULL)
                    {
                        this.GetCompanyName();
                        if (this.lsDefaultLanguage != Ifs.Fnd.ApplicationForms.Const.strNULL)
                        {
                            Sal.SendMsg(this.cmbDefaultLanguage, Sys.SAM_DropDown, 0, 0);
                            this.cmbDefaultLanguage.EditDataItemValueSet(1, this.lsDefaultLanguage.ToHandle());
                        }
                        if (this.lsCountry != Ifs.Fnd.ApplicationForms.Const.strNULL)
                        {
                            Sal.SendMsg(this.cmbCountry, Sys.SAM_DropDown, 0, 0);
                            this.cmbCountry.EditDataItemValueSet(1, this.lsCountry.ToHandle());
                        }
                        if (this.lsCountry != Ifs.Fnd.ApplicationForms.Const.strNULL && this.lsDefaultLanguage != Ifs.Fnd.ApplicationForms.Const.strNULL)
                        {
                            Sal.EnableWindowAndLabel(this.cmbCountry);
                            Sal.EnableWindowAndLabel(this.cmbDefaultLanguage);
                            Sal.DisableWindow(this.cmbCountry);
                            Sal.DisableWindow(this.cmbDefaultLanguage);
                            e.Return = Sys.VALIDATE_Ok;
                            return;
                        }
                    }
                    else
                    {
                        this.dfsNewCompanyName.EditDataItemStateSet(Ifs.Fnd.ApplicationForms.Const.EDIT_Changed);
                        e.Return = Sys.VALIDATE_Ok;
                        return;
                    }
                }
                else
                {
                    Sal.ClearField(this.dfsNewCompanyName);
                }
                e.Return = Sys.VALIDATE_Ok;
                return;
            }
            e.Return = Sys.VALIDATE_Cancel;
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemLovDone event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsNewCompanyId_OnPM_DataItemLovDone(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (!(Sal.IsNull(this.dfsNewCompanyId)))
            {
                this.nNum = SalString.FromHandle(Sys.lParam).Tokenize("", ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_RS).ToCharacter(), this.sRecords);
                this.nNum = this.sRecords[1].Tokenize("", ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_US).ToCharacter(), this.sUnits);
                if (this.sUnits[0] == "NAME")
                {
                    this.dfsSourceCompanyName.Text = this.sUnits[1];
                }
            }
            e.Return = true;
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void dfsNewCompanyName_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_AnyEdit:
                    e.Handled = true;
                    this.RefreshButtonsState();
                    break;
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void rbCopyCompany_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_Click:
                    this.rbCopyCompany_OnSAM_Click(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_Click event handler.
        /// </summary>
        /// <param name="message"></param>
        private void rbCopyCompany_OnSAM_Click(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.DisableWindow(this.dfsTemplateId);
            Sal.DisableWindow(this.dfsTemplateName);
            Sal.ClearField(this.dfsTemplateId);
            Sal.ClearField(this.dfsTemplateName);
            Sal.EnableWindow(this.dfsSourceCompanyId);
            Sal.EnableWindow(this.dfsSourceCompanyName);
            this.RefreshButtonsState();
            Sal.SetFocus(this.dfsSourceCompanyId);
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void rbImportTemplate_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_Click:
                    this.rbImportTemplate_OnSAM_Click(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_Click event handler.
        /// </summary>
        /// <param name="message"></param>
        private void rbImportTemplate_OnSAM_Click(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.DisableWindow(this.dfsSourceCompanyId);
            Sal.DisableWindow(this.dfsSourceCompanyName);
            Sal.ClearField(this.dfsSourceCompanyId);
            Sal.ClearField(this.dfsSourceCompanyName);
            Sal.EnableWindow(this.dfsTemplateId);
            Sal.EnableWindow(this.dfsTemplateName);
            this.dfsTemplateId.Text = this.sDefaultTemplateId;
            this.dfsTemplateName.Text = this.lsDefaultTemplateName;
            this.RefreshButtonsState();
            Sal.SetFocus(this.dfsTemplateId);
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void dfsSourceCompanyId_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.dfsSourceCompanyId_OnPM_DataItemValidate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovDone:
                    this.dfsSourceCompanyId_OnPM_DataItemLovDone(sender, e);
                    break;

                case Sys.SAM_AnyEdit:
                    e.Handled = true;
                    this.RefreshButtonsState();
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsSourceCompanyId_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam))
            {
                if (this.dfsSourceCompanyId.Text != Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    if (this.ValidateAndGetSourceCompanyName())
                    {
                        this.EnableDisablePeriod();
                        e.Return = Sys.VALIDATE_Ok;
                        return;
                    }
                    else
                    {
                        e.Return = Sys.VALIDATE_Cancel;
                        return;
                    }
                }
                else
                {
                    Sal.ClearField(this.dfsSourceCompanyName);
                    e.Return = Sys.VALIDATE_Ok;
                    return;
                }
            }
            e.Return = Sys.VALIDATE_Cancel;
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemLovDone event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsSourceCompanyId_OnPM_DataItemLovDone(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (!(Sal.IsNull(this.dfsSourceCompanyId)))
            {
                this.nNum = SalString.FromHandle(Sys.lParam).Tokenize("", ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_RS).ToCharacter(), this.sRecords);
                this.nNum = this.sRecords[1].Tokenize("", ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_US).ToCharacter(), this.sUnits);
                if (this.sUnits[0] == "NAME")
                {
                    this.dfsSourceCompanyName.Text = this.sUnits[1];
                }
            }
            this.RefreshButtonsState();
            e.Return = true;
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void dfsTemplateId_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.dfsTemplateId_OnPM_DataItemValidate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovDone:
                    this.dfsTemplateId_OnPM_DataItemLovDone(sender, e);
                    break;

                case Sys.SAM_AnyEdit:
                    e.Handled = true;
                    this.RefreshButtonsState();
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsTemplateId_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam))
            {
                if (this.dfsTemplateId.Text != Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    if (this.ValidateAndGetTemplateName())
                    {
                        this.cbUsePeriod.Checked = Sys.STRING_Null;
                        Sal.EnableWindow(dlgCreateCompany.FromHandle(this.dfsTemplateId.i_hWndFrame).cbUsePeriod);
                        e.Return = Sys.VALIDATE_Ok;
                        return;
                    }
                    else
                    {
                        e.Return = Sys.VALIDATE_Cancel;
                        return;
                    }
                }
                else
                {
                    Sal.ClearField(this.dfsTemplateName);
                    e.Return = Sys.VALIDATE_Ok;
                    return;
                }
            }
            e.Return = Sys.VALIDATE_Cancel;
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataItemLovDone event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsTemplateId_OnPM_DataItemLovDone(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (!(Sal.IsNull(this.dfsTemplateId)))
            {
                this.nNum = SalString.FromHandle(Sys.lParam).Tokenize("", ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_RS).ToCharacter(), this.sRecords);
                this.nNum = this.sRecords[1].Tokenize("", ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_US).ToCharacter(), this.sUnits);
                if (this.sUnits[0] == "DESCRIPTION")
                {
                    this.dfsTemplateName.Text = this.sUnits[1];
                }
            }
            this.RefreshButtonsState();
            e.Return = true;
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void lbLanguages_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {

                case Sys.SAM_Click:
                    e.Handled = true;
                    this.EnableDisableLanuageButtons();
                    break;

            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void dfsAccountingCurrency_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_AnyEdit:
                    e.Handled = true;
                    this.RefreshButtonsState();
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.dfsAccountingCurrency_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsAccountingCurrency_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if ((this.dfStartYear.Number != Sys.NUMBER_Null) && (this.dfStartMonth.Number != Sys.NUMBER_Null))
            {
                if (this.dfdtValidFrom.DateTime == Sys.DATETIME_Null)
                {
                    this.dfdtValidFrom.DateTime = new SalDateTime(this.dfStartYear.Number, this.dfStartMonth.Number, 1, 0, 0, 0);
                }
            }
            this.RefreshButtonsState();
            e.Return = true;
            return;
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void dfdtValidFrom_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_AnyEdit:
                    e.Handled = true;
                    this.RefreshButtonsState();
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    e.Handled = true;
                    e.Return = this.ValidateValidFrom();
                    return;
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void dfsParallelAccCurrency_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.dfsParallelAccCurrency_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsParallelAccCurrency_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;

            Sal.EnableWindow(this.cmbParallelCurBase);

            if (this.dfdtTimeStamp.DateTime == Sys.DATETIME_Null)
            {
                if ((this.dfdtValidFrom.DateTime != Sys.DATETIME_Null) && (this.dfsParallelAccCurrency.Text != Sys.STRING_Null))
                {
                    this.dfdtTimeStamp.DateTime = this.dfdtValidFrom.DateTime;
                }
                else
                {
                    if ((this.dfStartYear.Number != Sys.NUMBER_Null) && (this.dfStartMonth.Number != Sys.NUMBER_Null))
                    {
                        this.dfdtTimeStamp.DateTime = new SalDateTime(this.dfStartYear.Number, this.dfStartMonth.Number, 1, 0, 0, 0);
                    }
                }
            }


            if (this.dfsParallelAccCurrency.Text != Sys.STRING_Null)
            {
                Sal.EnableWindow(this.cmbParallelCurBase);
                Sal.SetFocus(this.cmbParallelCurBase);
            }
            else
            {
                this.cmbParallelCurBase.Text = Sys.STRING_Null;
                Sal.DisableWindow(this.cmbParallelCurBase);
            }
            this.RefreshButtonsState();

            e.Return = true;
            return;
            #endregion
        }


        private void cmbParallelCurBase_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.cmbParallelCurBase_OnPM_DataItemQueryEnabled(sender, e);
                    break;
                case Ifs.Fnd.ApplicationForms.Const.PM_LookupInit:
                    this.cmbParallelCurBase_OnPM_LookupInit(sender, e);
                    break;

                case Sys.SAM_AnyEdit:
                    e.Handled = true;
                    this.RefreshButtonsState();
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_LookupInit event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cmbParallelCurBase_OnPM_LookupInit(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.cmbParallelCurBase.EditDataItemFlagSet(Ifs.Fnd.ApplicationForms.Const.FIELD_Required, true);
            Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_LookupInit, Sys.wParam, Sys.lParam);
            this.cmbParallelCurBase.EditDataItemFlagSet(Ifs.Fnd.ApplicationForms.Const.FIELD_Required, false);
            #endregion
        }

        /// <summary>
        /// PM_DataItemQueryEnabled event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cmbParallelCurBase_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.dfsParallelAccCurrency.Text != Sys.STRING_Null)
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldEnabled;
                return;
            }
            else
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                return;
            }
            #endregion
        }
                

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void cmbDefaultLanguage_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_AnyEdit:
                    e.Handled = true;
                    this.RefreshButtonsState();
                    break;
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
                case Sys.SAM_AnyEdit:
                    e.Handled = true;
                    this.RefreshButtonsState();
                    break;
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void rbSourceTemplateCompany_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_Click:
                    this.rbSourceTemplateCompany_OnSAM_Click(sender, e);
                    break;

                case Sys.SAM_Create:
                    this.rbSourceTemplateCompany_OnSAM_Create(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_Click event handler.
        /// </summary>
        /// <param name="message"></param>
        private void rbSourceTemplateCompany_OnSAM_Click(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.ClearField(this.dfStartYear);
            Sal.ClearField(this.dfStartMonth);
            Sal.ClearField(this.dfNumberOfYears);
            Sal.ClearField(this.dfAccYear);
            Sal.DisableWindowAndLabel(this.dfStartYear);
            Sal.DisableWindowAndLabel(this.dfStartMonth);
            Sal.DisableWindowAndLabel(this.dfNumberOfYears);
            Sal.DisableWindowAndLabel(this.dfAccYear);
            this.EnableDisablePeriod();
            this.RefreshButtonsState();
            #endregion
        }

        /// <summary>
        /// SAM_Create event handler.
        /// </summary>
        /// <param name="message"></param>
        private void rbSourceTemplateCompany_OnSAM_Create(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.DisableWindowAndLabel(this.dfStartYear);
            Sal.DisableWindowAndLabel(this.dfStartMonth);
            Sal.DisableWindowAndLabel(this.dfNumberOfYears);
            Sal.DisableWindowAndLabel(this.dfAccYear);
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void rbUserDefined_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_Click:
                    this.rbUserDefined_OnSAM_Click(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_Click event handler.
        /// </summary>
        /// <param name="message"></param>
        private void rbUserDefined_OnSAM_Click(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.EnableWindowAndLabel(this.dfStartYear);
            Sal.EnableWindowAndLabel(this.dfStartMonth);
            Sal.EnableWindowAndLabel(this.dfNumberOfYears);
            Sal.EnableWindowAndLabel(this.dfAccYear);
            this.EnableDisablePeriod();
            Sal.SetFocus(this.dfAccYear);
            if ((this.dfStartYear.Number != Sys.NUMBER_Null) && (this.dfStartMonth.Number != Sys.NUMBER_Null) && (this.dfNumberOfYears.Number != Sys.NUMBER_Null))
            {
                Sal.EnableWindow(this.pbNext);
                this.RefreshButtonsState();
            }
            else
            {
                Sal.DisableWindow(this.pbNext);
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void dfAccYear_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_AnyEdit:
                    e.Handled = true;
                    this.RefreshButtonsState();
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    e.Handled = true;
                    e.Return = this.ValidateAccYear();
                    return;
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void dfStartYear_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_AnyEdit:
                    e.Handled = true;
                    this.RefreshButtonsState();
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    e.Handled = true;
                    e.Return = this.ValidateStartYear();
                    return;
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void dfStartMonth_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_AnyEdit:
                    e.Handled = true;
                    this.RefreshButtonsState();
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    e.Handled = true;
                    e.Return = this.ValidateStartMonth();
                    return;
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void dfNumberOfYears_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_AnyEdit:
                    e.Handled = true;
                    this.RefreshButtonsState();
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    e.Handled = true;
                    e.Return = this.ValidateNumberOfYears();
                    return;
            }
            #endregion
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbNo_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_Click:
                    this.rbNo_OnSAM_Click(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbNo_OnSAM_Click(object sender, WindowActionsEventArgs e)
        {
            #region Actins
            e.Handled = true;
            Sal.ClearField(dfsCodePart);
            Sal.ClearField(dfsInternalName);
            Sal.ClearField(cbAssets);
            Sal.ClearField(cbLiabilities);
            Sal.ClearField(cbRevenues);
            Sal.ClearField(cbCost);
            Sal.ClearField(cbStatistics);
            Sal.ClearField(cbStatOpenBal);
            Sal.DisableWindow(dfsCodePart);
            Sal.DisableWindow(dfsInternalName);
            Sal.DisableWindow(gbCurrBalAccountsEnable);
            Sal.EnableWindow(this.pbNext);
            e.Return = Sal.SendClassMessage(Sys.SAM_Click, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbYes_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_Click:
                    this.rbYes_OnSAM_Click(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbYes_OnSAM_Click(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (bDefaultCodePartExist)
            {
                FetchCodePartInfo();
            }

            if (dfsCodePart.Text != Fnd.ApplicationForms.Const.strNULL && bDefaultCodePartExist)
            {
                Sal.DisableWindow(dfsCodePart);
                Sal.DisableWindow(dfsInternalName);
            }
            else
            {
                Sal.EnableWindow(dfsCodePart);
                Sal.EnableWindow(dfsInternalName);                
            }
            Sal.EnableWindow(gbCurrBalAccountsEnable);
            e.Return = Sal.SendClassMessage(Sys.SAM_Click, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dfsCodePart_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.dfsCodePart_OnPM_DataItemValidate(sender, e);
                    break;

                case Fnd.ApplicationForms.Const.PM_DataItemLovUserWhere:
                    this.dfsCodePart_OnPM_DataItemLovUserWhere(sender, e);
                    break;
            }
            #endregion
        }        

        private void dfsCodePart_OnPM_DataItemLovUserWhere(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (dfsSourceCompanyId.Text == "" && dfsTemplateId.Text != "")
            {
                e.Return = ((SalString)" TEMPLATE_ID = '" + dfsTemplateId.Text + "'").ToHandle();
            }
            else if (dfsSourceCompanyId.Text != "" && dfsTemplateId.Text == "")
            {
                e.Return = ((SalString)" COMPANY = '" + dfsSourceCompanyId.Text+"'").ToHandle();
            }
            
            return;
            #endregion
        }

        private void dfsCodePart_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Local Variables
            SalArray<SalString> sParam = new SalArray<SalString>();  
            SalString sSourceType = "";
            SalString sSource = "";
            #endregion

            #region Actions
            e.Handled = true;  
            if (dfsCodePart.Text != Fnd.ApplicationForms.Const.strNULL && dfsTemplateId.Text != Fnd.ApplicationForms.Const.strNULL)
            {
                DbPLSQLBlock(@"{0} := Create_Company_Tem_Detail_API.Is_Valid_Code_Part__({1} IN,{2} IN);", QualifiedVarBindName("sCodePartAvaialable"), dfsTemplateId.QualifiedBindName, dfsCodePart.QualifiedBindName);
                if (sCodePartAvaialable != "TRUE")
                {
                    sParam[0] = dfsCodePart.Text;
                    sParam[1] = dfsTemplateId.Text;
                    Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.ERROR_TempCodePartNotAvailable, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok, sParam);
                    e.Return = Sys.VALIDATE_Cancel;
                    return;
                }
                DbPLSQLBlock(@"{0}:= &AO.Create_Company_Tem_Detail_API.Get_Internal_Name__({1} IN, {2} IN);", dfsInternalName.QualifiedBindName, dfsTemplateId.QualifiedBindName, dfsCodePart.QualifiedBindName);                    
            }
            else if (dfsCodePart.Text != Fnd.ApplicationForms.Const.strNULL && dfsSourceCompanyId.Text != Fnd.ApplicationForms.Const.strNULL)
            {
                if (Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Accounting_Code_Parts_API.Is_Codepart_Function"))
                {                    
                    DbPLSQLBlock(@"{0} := &AO.Accounting_Code_Parts_API.Is_Codepart_Function({1} IN,{2} IN,{3} IN)",    QualifiedVarBindName("sCodePartAvaialable"), 
                                                                                                                        dfsSourceCompanyId.QualifiedBindName, 
                                                                                                                        dfsCodePart.QualifiedBindName,
                                                                                                                        QualifiedVarBindName("sCurrBalFunction"));

                    if (sCodePartAvaialable == "TRUE")
                    {
                        sParam[0] = dfsCodePart.Text;
                        sParam[1] = dfsSourceCompanyId.Text;
                        Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.ERROR_CompCodePartNotAvailable, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.INFO_Ok, sParam);
                        e.Return = Sys.VALIDATE_Cancel;
                        return;
                    }
                }
                if (Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Accounting_Code_Parts_API.Get_Code_Name"))
                {
                    DbPLSQLBlock(@"{0}:= &AO.Accounting_Code_Parts_API.Get_Code_Name({1} IN, {2} IN);", dfsInternalName.QualifiedBindName, dfsSourceCompanyId.QualifiedBindName, dfsCodePart.QualifiedBindName);
                }                  
            }                           
            RefreshButtonsState();
            e.Return = Sal.SendClassMessage(Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        
        #endregion

        #region Late Bind Methods

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalNumber vrtDataSourceInquireSave()
        {
            return this.DataSourceInquireSave();
        }

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalNumber vrtFrameActivate()
        {
            return this.FrameActivate();
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
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalBoolean vrtWizardFinish(SalNumber nWhat, SalString sStep)
        {
            return this.WizardFinish(nWhat, sStep);
        }

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalBoolean vrtWizardNext(SalNumber nWhat, SalString sStep)
        {
            return this.WizardNext(nWhat, sStep);
        }

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalNumber vrtWizardStepActivated(SalString sStep)
        {
            return this.WizardStepActivated(sStep);
        }
        #endregion        
    }
}
