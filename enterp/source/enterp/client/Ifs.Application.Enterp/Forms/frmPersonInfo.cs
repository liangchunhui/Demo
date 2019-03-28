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
// 131121   MaIklk  PRSC-3983, Handled to avoid executing validate for name if edit button is clicked.
// 121101   Nudilk  Bug 106333,Corrected in CreatePersonPerCompany.
// 130515   MaRalk  PBR-1602, Made name field link enabled and allow user to edit title, initials, first name, middle name and last name.
// 130522   MaRalk  PBR-1605, Added check boxes cbCustomerContactDb and cbBlockedForCrmObjectsDb.
// 130529   MaRalk  PBR-1604, Added dfsName_OnPM_DataItemValidate to reflect the changes for first, middle and last names in the dialog.
// 130529           Made dfsName edittable only when creating new records. Added methods AnalyzeName, DataRecordFetchEditedUser and
// 130529           dfsName_OnPM_DataItemQueryEnabled. 
// 131114   Pratlk  PBFI-2542, Refactor client windows in component ENTERP
// 131009   MaRalk  PBR-1621, Added methods UpdateContactsBlockForUse, CheckCustomerContactsExist, vrtDataSourcePopulateIt.  
// 131009           Modified methods DataSourceSaveCheck, DataSourceSaveCheckOk to support the blocked for use check box 
// 131009           selecting and unselcting functionality. Added method cbCustomerContactDb_OnSAM_AnyEdit.
// 131010   MaRalk  PBR-1751, Added method HandleCrmColumns to hide columns colsDepartment, colsManager, colsBlockedForCrmObjectsDb in 
// 131010           tblContactCustomer when CRM is not installed.
// 130207   MaRalk  PBSC-5700, Added method ConstructName and modified dfsName_OnPM_DataItemValidate, cmdEnterFullName_Execute.
// 140211   JanWse  PBSC-6380, Refresh connected customers when blocked is checked/unchecked
// 140401   Machlk  PBFI-5564 Merged Bug 115353
// 140401   Kagalk  PBFI-4142, Merged Bug 113712, Modified to give a warning when deleting the last address type.
// 140409   Ajpelk  PBFI-4140, Merged Bug 112894, Added TabActivateFinish()
// 140625   MaRalk  PRSC-1223, Removed Full Name link label and instead added Edit button for allowing 
// 140625           user to edit first name, middle name, last name, title and initials.
// 140818   Kagalk  Bug 118344, Add response to event PAM_RecordNotInitiallySaved.
// 140902   MaIklk  PRSC-2671, Used to check frmCustomerInfoContact is available in order to check crm is installed.
// 140916   MaRalk  PRSC-2393, Removed Full Name link label and instead added Edit button for allowing 
// 140916           user to edit first name, middle name, last name, title and initials.
// 150512   SudJlk  ORA-289, Added cbSupplierContactDb_OnSAM_AnyEdit and cbSupplierContactDb_OnPM_DataItemPopulate to enable cbBlockedForUseSuppDb 
// 150512           according to cbSupplierContactDb value.
// 150514   SudJlk  ORA-290, Added method UpdateSuppContactsBlockForUse and window action cbSupplierContactDb_OnSAM_AnyEdit
// 150514           to handle selection and clearing of cbBlockedForUseSuppDb displaying relevant info messages.
// 160611   SudJlk  ORA-570 Added method HandleSrmColumns and overriden FrameStartUpUser to hide department when SRM is not installed.
#endregion

using System;
using Ifs.Fnd.ApplicationForms;
using PPJ.Runtime;
using PPJ.Runtime.Sql;
using PPJ.Runtime.Windows;
using Ifs.Fnd.Explorer.Interfaces;
using System.Collections.Generic;
using System.Windows.Forms.ComponentModel;
using Ifs.Fnd.Core;
using PPJ.Runtime.Vis;
using Ifs.Fnd.Windows.Forms;


namespace Ifs.Application.Enterp
{

    /// <summary>
    /// </summary>
    [FndDataValidity(FndDataValidityMode.ActiveHiddenBlocked)]
    [FndWindowRegistration("PERSON_INFO,PERSON_INFO_LOV,PERSON_INFO_PUBLIC_LOV,RESOURCE_PERSON_LOV", "PersonInfo", FndWindowRegistrationFlags.HomePage)]
    public partial class frmPersonInfo : cMasterDetailTabFormWindow
    {
        #region Window Variables
        public SalString sCommMethodTabActive = "";
        public SalString sAddressTabActive = "";
        public SalString sCompany = "";
        protected SalBoolean bNew = false;
        protected SalBoolean bOk = false;
        protected SalString sFullName = Ifs.Fnd.ApplicationForms.Const.strNULL;
        protected SalString sFirstName = Ifs.Fnd.ApplicationForms.Const.strNULL;
        protected SalString sMiddleName = Ifs.Fnd.ApplicationForms.Const.strNULL;
        protected SalString sLastName = Ifs.Fnd.ApplicationForms.Const.strNULL;
        protected SalBoolean bOldBlockedForUse = false;
        protected SalBoolean bUpdateContactBlockForUse = false;
        protected SalString lsStmt = "";        
        protected SalString sCustomerContactsExist = "FALSE";
        /*protected SalString sExist = "";
        protected SalString sPerson = "";*/
        protected SalBoolean bBlockedUseSuppChanged = false;
        protected SalString sDataSubjectKeyRef = "";
        protected SalString sDataSubjectEnable = "FALSE";
        protected static SalString sDataSubjectDb = "PERSON";
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public frmPersonInfo()
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
        public new static frmPersonInfo FromHandle(SalWindowHandle handle)
        {
            return ((frmPersonInfo)SalWindow.FromHandle(handle, typeof(frmPersonInfo)));
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
                this.HandleCrmColumns();
                this.HandleSrmColumns();
                return true;
            }
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
                    if (Sal.SendMsg(frmPersonInfoAddress.FromHandle(hWndAddress).tblCommMethod, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceIsDirty, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam))
                    {
                        if (!(frmPersonInfoAddress.FromHandle(hWndAddress).tblCommMethod.CheckDefault()))
                        {
                            return false;
                        }
                    }
                }
                if (sCommMethodTabActive == "TRUE")
                {
                    if (Sal.SendMsg(frmPersonInfo.FromHandle(i_hWndFrame).TabAttachedWindowHandleGet(picTab.FindName("Name2")), Ifs.Fnd.ApplicationForms.Const.PM_DataSourceIsDirty, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam))
                    {
                        if (!(frmPersonInfoCommMethod.FromHandle(hWndComMethod).tblCommMethod.CheckDefault()))
                        {
                            return false;
                        }
                    }
                }
                this.bOldBlockedForUse = cbBlockedForUseDb.Checked;
                return ((cDataSource)this).DataSourceSaveCheckOk();
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
                picTab.GetName(nTab, ref sName);
                if (sName == "Name1")
                {
                    sAddressTabActive = "TRUE";
                }
                else if (sName == "Name2")
                {
                    sCommMethodTabActive = "TRUE";
                }
            }

            return 0;
            #endregion
        }
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber CreatePersonPerCompany()
        {
            #region Actions
            using (new SalContext(this))
            {
                UserGlobalValueGet("COMPANY", ref sCompany);
                if (sCompany != Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    using (SignatureHints hints = SignatureHints.NewContext())
                    {
                        cmbPerson.EditDataItemSetEdited();
                        hints.Add("Person_Company_Access_API.New", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);                        
                        DbPLSQLBlock(cSessionManager.c_hSql, " &AO.Person_Company_Access_API.New(:i_hWndFrame.frmPersonInfo.sCompany,\r\n" +
                            "                                                                                                                  :i_hWndFrame.frmPersonInfo.cmbPerson.i_sMyValue)");
                    }
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// The DataRecordExecuteNew function performs server creation of
        /// new records.
        /// COMMENTS:
        /// DataRecordExecuteNew is called once for each new record by the
        /// DataSourceExecuteSqlInsert function during the save process.
        /// </summary>
        /// <param name="hSql">
        /// Sql handle
        /// Database connection sql handle to use for this server function call. Typically c_hSql is used.
        /// </param>
        /// <returns>The return value is TRUE if the record is created successfully, FALSE otherwise.</returns>
        public new SalBoolean DataRecordExecuteNew(SalSqlHandle hSql)
        {
            #region Actions
            using (new SalContext(this))
            {
                if (Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Person_Company_Access_API.New"))
                {
                    if (((cMasterDetailTabFormWindow)this).DataRecordExecuteNew(hSql))
                    {
                        CreatePersonPerCompany();
                        return true;
                    }
                }
                else
                {
                    Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_NoPriviledge, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Warning, Ifs.Fnd.ApplicationForms.Const.WARNING_Ok);
                }
                return false;
            }
            #endregion
        }
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber InvalidateTabs()
        {
            #region Local Variables
            SalNumber nMax = 0;
            SalNumber n = 0;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                nMax = picTab.GetCount();
                while (n < nMax)
                {
                    if ((i_hWndTab[n] != SalWindowHandle.Null) && (i_hWndTab[n] != i_hWndActive))
                    {
                        TabInvalidateData(n);
                    }
                    n = n + 1;
                }
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
                    if (((bool)Sal.SendMsg(frmPersonInfoAddress.FromHandle(hWndAddress).tblAddressType, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceIsDirty, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, Sys.lParam)) || (Sal.QueryFieldEdit(frmPersonInfoAddress.FromHandle(hWndAddress).dfdValidFrom) ||
                    Sal.QueryFieldEdit(frmPersonInfoAddress.FromHandle(hWndAddress).dfdValidTo)))
                    {
                        if (!(frmPersonInfoAddress.FromHandle(hWndAddress).tblAddressType_CheckDefaultAddress()))
                        {
                            return false;
                        }
                        if (!(frmPersonInfoAddress.FromHandle(hWndAddress).tblAddressType_CheckLastAddressType()))
                        {
                            return false;
                        }
                    }
                }
                // Check whether Block for use check box modified for existing records.
                if (!bNew)
                {
                    UpdateCustContactsBlockForUse(); // This function sets the variable bUpdateContactBlockForUse.
                    UpdateSuppContactsBlockForUse();
                }

                return ((cMasterDetailTabFormWindow)this).DataSourceSaveCheck();
            }
            #endregion
        }

        /// <summary>
        /// AnalyzeName.
        /// </summary>
        /// This method takes the person name value as input parameter and
        /// set sFirstName, sMiddleName, sLastName variables by extracting from it.
        /// First name will be the first most element in the name and the last name will be 
        /// the last most one. The whole texts in between will be suggested as the middle name.
        public virtual void AnalyzeName(SalString sName)
        {
            #region Local Variables
            SalNumber nCurrentNameItemsCount = Sys.NUMBER_Null;
            SalNumber nCounter = 0;
            sFirstName = Ifs.Fnd.ApplicationForms.Const.strNULL;
            sMiddleName = Ifs.Fnd.ApplicationForms.Const.strNULL;
            sLastName = Ifs.Fnd.ApplicationForms.Const.strNULL;
            #endregion

            #region Actions
             String[] sFullNameItems = sName.ToString().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
             nCurrentNameItemsCount = sFullNameItems.Length;

            if (nCurrentNameItemsCount == 1)
            {
                sFirstName = sFullNameItems[0];
            }

            if (nCurrentNameItemsCount == 2)
            {
                sFirstName = sFullNameItems[0];
                sLastName = sFullNameItems[1];
            }
            if (nCurrentNameItemsCount > 2)
            {
                sFirstName = sFullNameItems[0];

                nCounter = 1;
                while (nCounter < (nCurrentNameItemsCount - 1))
                {
                    if (nCounter == (nCurrentNameItemsCount - 2))
                        sMiddleName = SalString.Concat(sMiddleName, sFullNameItems[nCounter]);
                    else
                        sMiddleName = SalString.Concat(sMiddleName, SalString.Concat(sFullNameItems[nCounter], " "));
                    nCounter = nCounter + 1;
                }

                sLastName = sFullNameItems[nCurrentNameItemsCount - 1];
            }
            #endregion
        }

        /// <summary>
        /// ConstructName.
        /// </summary>
        /// This method takes sFirstName, sMiddleName, sLastName as parameters
        /// and construct the full name by concatenating them.
        public virtual SalString ConstructName(SalString sFirstName, SalString sMiddleName, SalString sLastName)
        {
            #region Local Variables
            SalString sTemp = Ifs.Fnd.ApplicationForms.Const.strNULL;
            #endregion

            #region Actions
            sTemp = sFirstName;
            if (sTemp != Ifs.Fnd.ApplicationForms.Const.strNULL)
            {
                if (sMiddleName != Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    sTemp = SalString.Concat(sTemp, SalString.Concat(" ", sMiddleName));
                }
                if (sLastName != Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    sTemp = SalString.Concat(sTemp, SalString.Concat(" ", sLastName));
                }

            }
            else
            {
                if (sMiddleName != Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    sTemp = sMiddleName;
                    if (sLastName != Ifs.Fnd.ApplicationForms.Const.strNULL)
                    {
                        sTemp = SalString.Concat(sTemp, SalString.Concat(" ", sLastName));
                    }
                }
                else
                {
                    if (sLastName != Ifs.Fnd.ApplicationForms.Const.strNULL)
                    {
                        sTemp = sLastName;
                    }
                }
            }
            return sTemp;
            #endregion
        }

        public new SalNumber DataRecordFetchEditedUser(ref SalString lsAttr)
        {
            // When other fields modified sFullName is null. For existing records, when name fields are editted sFullName is having a value.                 
            if (!bNew && sFullName != Ifs.Fnd.ApplicationForms.Const.strNULL)
            {
                Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("NAME", sFullName, ref lsAttr);
            }

            // Updating Block for use in CRM value in customr contacts.
            if (!bNew && bUpdateContactBlockForUse)
            {
                Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("UPDATE_CON_BLOCK_FOR_CRM_OBJS", "TRUE", ref lsAttr);
                tblContactCustomer.DataSourcePopulate( Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0 );
            }
            return base.vrtDataRecordFetchEditedUser(ref lsAttr);
        }

        /// <summary>
        /// UpdateCustContactsBlockForUse.
        /// This method takes the user input whether to select/unselect Blocked for use in CRM check box in customer contacts,
        /// when person blocked for use check box is select/unselect. (bUpdateContactBlockForUse is set accordingly.)
        /// Popping up messages are different based on CRM installed or not and whether person is connected as customer contact or not.
        /// </summary>
        protected virtual void UpdateCustContactsBlockForUse()
        {
            #region Actions
            if (bOldBlockedForUse != cbBlockedForUseDb.Checked)
            {
                CheckCustomerContactsExist();

                // Changing Unblock to Block
                if (cbBlockedForUseDb.Checked && cbCustomerContactDb.Checked)
                {
                    // When CRM installed
                    if (Ifs.Fnd.ApplicationForms.Var.Component.IsWindowAvailable(Pal.GetActiveInstanceName("frmCustomerInfoContact")) && Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("frmCustomerInfoContact")))
                    {
                        // Person has connected as customer contacts
                        if (sCustomerContactsExist == "TRUE")
                        {
                            if (Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_BlockForUse1, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Question, Ifs.Fnd.ApplicationForms.Const.QUESTION_YesNo) == Sys.IDYES)
                            {
                                bUpdateContactBlockForUse = true;
                            }
                            else
                            {
                                bUpdateContactBlockForUse = false;
                            }
                        }
                        // Person hasn't connected as customer contacts
                        else
                        {
                            Ifs.Fnd.ApplicationForms.Int.InfoBox(Properties.Resources.TEXT_BlockForUse2);
                            bUpdateContactBlockForUse = false;
                        }
                    }
                    // When CRM NOT installed
                    else
                    {
                        Ifs.Fnd.ApplicationForms.Int.InfoBox(Properties.Resources.TEXT_BlockForUse2);
                        if (sCustomerContactsExist == "TRUE")
                        {
                            bUpdateContactBlockForUse = true;
                        }
                        else
                        {
                            bUpdateContactBlockForUse = false;
                        }
                    }
                }
                // Changing Block to Unblock 
                else if ((!cbBlockedForUseDb.Checked) && cbCustomerContactDb.Checked)
                {
                    // When CRM installed
                    if (Ifs.Fnd.ApplicationForms.Var.Component.IsWindowAvailable(Pal.GetActiveInstanceName("frmCustomerInfoContact")) && Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("frmCustomerInfoContact")))
                    {
                        // Person has connected as customer contacts
                        if (sCustomerContactsExist == "TRUE")
                        {
                            if (Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_UnBlockForUse1, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Question, Ifs.Fnd.ApplicationForms.Const.QUESTION_YesNo) == Sys.IDYES)
                            {
                                bUpdateContactBlockForUse = true;
                            }
                            else
                            {
                                bUpdateContactBlockForUse = false;
                            }
                        }
                        // Person hasn't connected as customer contacts
                        else
                        {
                            Ifs.Fnd.ApplicationForms.Int.InfoBox(Properties.Resources.TEXT_UnBlockForUse2);
                            bUpdateContactBlockForUse = false;
                        }

                    }
                    // When CRM NOT installed
                    else
                    {
                        Ifs.Fnd.ApplicationForms.Int.InfoBox(Properties.Resources.TEXT_UnBlockForUse2);
                        if (sCustomerContactsExist == "TRUE")
                        {
                            bUpdateContactBlockForUse = true;
                        }
                        else
                        {
                            bUpdateContactBlockForUse = false;
                        }
                    }
                }
            }
            #endregion
        }

        public virtual SalNumber CheckCustomerContactsExist()
        {
            return DbPLSQLBlock(@"{0} := &AO.Customer_Info_Contact_API.Is_Customer_Contact({1} IN);", this.QualifiedVarBindName("sCustomerContactsExist"), this.cmbPerson.QualifiedBindName);
        }

        /// <summary>
        /// colsDepartment, colsManager, colsBlockedForCrmObjectsDb columns are shown only when CRM is installed.
        /// </summary>
        public virtual void HandleCrmColumns()
        {
            if (!(Ifs.Fnd.ApplicationForms.Var.Component.IsWindowAvailable(Pal.GetActiveInstanceName("frmCustomerInfoContact")) && Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("frmCustomerInfoContact"))))
            {
                tblContactCustomer_colsDepartment.Visible = false;
                tblContactCustomer_colsManager.Visible = false;
                tblContactCustomer_colsBlockedForCrmObjectsDb.Visible = false;
            }
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

        /// <summary>
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="nTab"></param>
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
                    Sal.SetFocus(frmPersonInfoCommMethod.FromHandle(hWndInfoCommMethod).tblCommMethod);
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
        public virtual new SalNumber TabActivateFinished(SalWindowHandle hWnd, SalNumber nTab)
        {
            #region Local Variables            
            SalNumber retVal = 0;            
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                retVal = base.TabActivateFinish(hWnd, nTab);
                HandleDataSubjectConsentColumns(SalBoolean.False);
            }
            return retVal;
            #endregion
        }
        
        /// <summary>
        /// UpdateSuppContactsBlockForUse.
        /// This method takes the user input whether to select/unselect Blocked for use in CRM check box in customer contacts,
        /// when person blocked for use check box is select/unselect. (bUpdateContactBlockForUse is set accordingly.)
        /// Popping up messages are different based on CRM installed or not and whether person is connected as customer contact or not.
        /// </summary>
        protected virtual void UpdateSuppContactsBlockForUse()
        {
            #region Local Variables
			SalArray<SalString> sParam = new SalArray<SalString>();
			#endregion

            #region Actions
            //if (bOldBlockedUseSupp != cbBlockedForUseSuppDb.Checked)

            if (bBlockedUseSuppChanged)
            {
                // Changing Unblock to Block
                if (cbBlockedForUseSuppDb.Checked && cbSupplierContactDb.Checked)
                {
                    Ifs.Fnd.ApplicationForms.Int.InfoBox(Properties.Resources.TEXT_BlockSuppContact);
                }
                // Changing Block to Unblock
                else if (!cbBlockedForUseSuppDb.Checked && cbSupplierContactDb.Checked)
                {
                    Ifs.Fnd.ApplicationForms.Int.InfoBox(Properties.Resources.TEXT_UnblockSuppContact);
                }
            }
            bBlockedUseSuppChanged = false;
            #endregion

        }

        public virtual void HandleSrmColumns()
        {
            if (!(Ifs.Fnd.ApplicationForms.Var.Component.IsWindowAvailable(Pal.GetActiveInstanceName("frmSupplierInfoContact")) && Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("frmSupplierInfoContact"))))
            {
                tblContactSupplier_colsDepartment.Visible = false;
            }
        }

        #endregion

        #region Window Actions

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void frmPersonInfo_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate:
                    this.frmPersonInfo_OnPM_DataRecordDuplicate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate:
                    this.frmPersonInfo_OnPM_DataSourcePopulate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave:
                    this.frmPersonInfo_OnPM_DataSourceSave(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew:
                    this.frmPersonInfo_OnPM_DataRecordNew(sender, e);
                    break;
                case Const.PAM_RecordNotInitiallySaved:
                    e.Handled = true;
                    if (this.cmbPerson.EditDataItemStateGet() == Ifs.Fnd.ApplicationForms.Const.EDIT_Changed)
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
        /// PM_DataRecordDuplicate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmPersonInfo_OnPM_DataRecordDuplicate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordDuplicate, Sys.wParam, Sys.lParam))
            {
                if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                {
                    Sal.SendMsg(this.picPicture, Ifs.Fnd.ApplicationForms.Const.PM_DataItemClear, 0, 0);
                    Sal.SendMsg(this.picPicture, Ifs.Fnd.ApplicationForms.Const.PM_DataItemNew, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                    bNew = true;
                }
                e.Return = true;
                return;
            }
            e.Return = false;
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataSourcePopulate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void frmPersonInfo_OnPM_DataSourcePopulate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                if (Sys.lParam == Ifs.Fnd.ApplicationForms.Const.POPULATE_UseQueryDialog)
                {
                    this.dfsUserId.p_sLovReference = "PERSON_INFO_NON_FREE_USER";
                }
                if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Sys.wParam, Sys.lParam))
                {
                    this.dfsUserId.p_sLovReference = "PERSON_INFO_FREE_USER";
                    e.Return = Sal.SendMsgToChildren(this.i_hWndFrame, Ifs.Fnd.ApplicationForms.Const.PM_User, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ((SalString)"POPULATE").ToHandle());
                    return;
                }
                else
                {
                    this.dfsUserId.p_sLovReference = "PERSON_INFO_FREE_USER";
                    e.Return = false;
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
        private void frmPersonInfo_OnPM_DataSourceSave(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Sys.wParam, Sys.lParam))
            {
                if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                {
                    Sal.SendMsg(this.TabAttachedWindowHandleGet(this.picTab.FindName("Name1")), Const.PAM_DetailAddress, 0, 0);
                    this.InvalidateTabs();
                    bNew = false;
                }
                e.Return = true;
                return;
            }
            e.Return = false;
            return;
            #endregion
        }

        private void frmPersonInfo_OnPM_DataRecordNew(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.bOk = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Sys.wParam, Sys.lParam);
            if ((Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) && this.bOk)
            {
                bNew = true;
            }
            e.Return = this.bOk;
            return;
            #endregion
        }
    
        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void cmbPerson_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemNew:
                    this.cmbPerson_OnPM_DataItemNew(sender, e);
                    break;

            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemNew event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cmbPerson_OnPM_DataItemNew(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemNew, Sys.wParam, Sys.lParam);
            this.cmbPerson.EditDataItemSetEdited();
            e.Return = true;
            return;
            #endregion
        }

        private void dfsName_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.dfsName_OnPM_DataItemQueryEnabled(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.dfsName_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        private void dfsName_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (!(bNew))
            {
                e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
                return;
            }
            else
            {
                e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled, Sys.wParam, Sys.lParam);
                return;
            }
            #endregion
        }

        private void dfsName_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Local Variable
            SalArray<SalString> items = new SalArray<SalString>();
            SalString sCurrTitle;
            SalString sCurrInitials;
            SalString sCurrFirstName;
            SalString sCurrMiddleName;
            SalString sCurrLastName;
            SalBoolean bFirstNameChanged = false;
            SalBoolean bMiddleNameChanged = false;
            SalBoolean bLastNameChanged = false;
            #endregion

            #region Actions
            e.Handled = true;
            if (Sys.wParam)
            {
                // If edit button is clicked then no need to execute validate.
                if (cCommandButtonEdit.Focused)
                {
                    e.Return = Sys.VALIDATE_Ok;
                    return;
                }
                sFullName = Ifs.Fnd.ApplicationForms.Const.strNULL;
                AnalyzeName(dfsName.Text);                

                //Full name having only one name value
                if ((sFirstName != Ifs.Fnd.ApplicationForms.Const.strNULL) && (sMiddleName == Ifs.Fnd.ApplicationForms.Const.strNULL) && (sLastName == Ifs.Fnd.ApplicationForms.Const.strNULL)) 
                {
                    // Having only one element suggesting to save it as the first name.
                    dfsFirstName.Text = sFirstName;
                    dfsFirstName.EditDataItemSetEdited();

                    vrtDataSourcePrepareKeyTransfer(Pal.GetActiveInstanceName("dlgPersonFullName"));

                    sCurrTitle = dfsTitle.Text;
                    sCurrInitials = dfsInitials.Text;
                    sCurrFirstName = dfsName.Text;
                    sCurrMiddleName = dfsMiddleName.Text;
                    sCurrLastName = dfsLastName.Text;

                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemAdd("TITLE", new SalArray<SalString>() { dfsTitle });
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemAdd("INITIALS", new SalArray<SalString>() { dfsInitials });
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemAdd("FIRST_NAME", new SalArray<SalString>() { dfsFirstName });
                    // Sending NULL values for Middle and Last Name fields
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemAdd("MIDDLE_NAME", new SalArray<SalString>() { Ifs.Fnd.ApplicationForms.Const.strNULL });
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemAdd("LAST_NAME", new SalArray<SalString>() { Ifs.Fnd.ApplicationForms.Const.strNULL });

                    if (Sys.IDOK == dlgPersonFullName.ModalDialog(Sys.hWndMDI))
                    {
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("TITLE", items);
                        dfsTitle.Text = items[0];

                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("INITIALS", items);
                        dfsInitials.Text = items[0];

                        // Make editted the fields only if they have changed
                        if (!(SalString.Equals(sCurrTitle, dfsTitle.Text)))
                        {
                            dfsTitle.EditDataItemSetEdited();
                        }
                        if (!(SalString.Equals(sCurrInitials, dfsInitials.Text)))
                        {
                            dfsInitials.EditDataItemSetEdited();
                        }

                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("FIRST_NAME", items);
                        if (!(SalString.Equals(sCurrFirstName, items[0])))
                        {
                            dfsFirstName.Text = items[0];
                            dfsFirstName.EditDataItemSetEdited();
                            bFirstNameChanged = true;
                        }

                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("MIDDLE_NAME", items);
                        if (!(SalString.Equals(sCurrMiddleName, items[0])))
                        {
                            dfsMiddleName.Text = items[0];
                            dfsMiddleName.EditDataItemSetEdited();
                            bMiddleNameChanged = true;
                        }

                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("LAST_NAME", items);
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
                        if (!(SalString.Equals(sCurrLastName, items[0])))
                        {
                            dfsLastName.Text = items[0];
                            dfsLastName.EditDataItemSetEdited();
                            bLastNameChanged = true;
                        }

                        if (bFirstNameChanged || bMiddleNameChanged || bLastNameChanged)
                        {
                            // Concatenating First Name, Middle Name and the Last Name to save in the NAME column.
                            sFullName = ConstructName(dfsFirstName.Text, dfsMiddleName.Text, dfsLastName.Text);

                            dfsName.EditDataItemValueSet(1, sFullName.ToHandle());
                        }
                    }
                }
                //Full name having more than one name value 
                else
                {
                    dfsFirstName.Text = sFirstName;
                    dfsFirstName.EditDataItemSetEdited();

                    dfsMiddleName.Text = sMiddleName;
                    dfsMiddleName.EditDataItemSetEdited();

                    dfsLastName.Text = sLastName;
                    dfsLastName.EditDataItemSetEdited();

                    // Constructing full name.(As AnalyzeName remove extra spaces full name need to be constructed again)
                    sFullName = ConstructName(sFirstName, sMiddleName, sLastName);
                    dfsName.EditDataItemValueSet(1, sFullName.ToHandle());
                }
            }            
            e.Return = Sys.VALIDATE_Ok;
            #endregion
        }

        private void cbCustomerContactDb_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_AnyEdit:
                    this.cbCustomerContactDb_OnSAM_AnyEdit(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemPopulate:
                    this.cbCustomerContactDb_OnPM_DataItemPopulate(sender, e);
                    break;
            }
            #endregion
        }

        private void cbCustomerContactDb_OnSAM_AnyEdit(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Sys.SAM_AnyEdit, Sys.wParam, Sys.lParam);
            if (cbCustomerContactDb.Checked)
            {
                Sal.EnableWindow(cbBlockedForUseDb);
            }
            else
            {
                if (cbBlockedForUseDb.Checked)
                {
                    cbBlockedForUseDb.Checked = false;
                    cbBlockedForUseDb.__sValue = "FALSE";
                    cbBlockedForUseDb.EditDataItemSetEdited();
                }
                Sal.DisableWindow(cbBlockedForUseDb);
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemPopulate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cbCustomerContactDb_OnPM_DataItemPopulate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemPopulate, Sys.wParam, Sys.lParam);
            if (cbCustomerContactDb.Checked)
            {
                Sal.EnableWindow(cbBlockedForUseDb);
            }
            else
            {
                Sal.DisableWindow(cbBlockedForUseDb);
            }
            #endregion
        }

        private void cbSupplierContactDb_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_AnyEdit:
                    this.cbSupplierContactDb_OnSAM_AnyEdit(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemPopulate:
                    this.cbSupplierContactDb_OnPM_DataItemPopulate(sender, e);
                    break;
            }
            #endregion
        }

        private void cbSupplierContactDb_OnSAM_AnyEdit(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Sys.SAM_AnyEdit, Sys.wParam, Sys.lParam);
            if (cbSupplierContactDb.Checked)
            {
                Sal.EnableWindow(cbBlockedForUseSuppDb);
            }
            else
            {
                if (cbBlockedForUseSuppDb.Checked)
                {
                    cbBlockedForUseSuppDb.Checked = false;
                    cbBlockedForUseSuppDb.__sValue = "FALSE";
                    cbBlockedForUseSuppDb.EditDataItemSetEdited();
                }
                Sal.DisableWindow(cbBlockedForUseSuppDb);
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemPopulate event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cbSupplierContactDb_OnPM_DataItemPopulate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemPopulate, Sys.wParam, Sys.lParam);
            if (cbSupplierContactDb.Checked)
            {
                Sal.EnableWindow(cbBlockedForUseSuppDb);
            }
            else
            {
                Sal.DisableWindow(cbBlockedForUseSuppDb);
            }
            #endregion
        }

        private void cbBlockedForUseSuppDb_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_AnyEdit:
                    this.cbBlockedForUseSuppDb_OnSAM_AnyEdit(sender, e);
                    break;
            }
            #endregion
        }

        private void cbBlockedForUseSuppDb_OnSAM_AnyEdit(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            bBlockedUseSuppChanged = true;
            #endregion
        }
        #endregion

        #region Late Bind Methods

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalBoolean vrtDataRecordExecuteNew(SalSqlHandle hSql)
        {
            return this.DataRecordExecuteNew(hSql);
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

        public override SalNumber vrtActivate(fcURL URL)
        {
            #region Actions
            using (new SalContext(this))
            {
                this.HandleDataSubjectConsentColumns(SalBoolean.True);
            }
            return base.Activate(URL);
            #endregion
        }

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalBoolean vrtTabActivateFinish(SalWindowHandle hWnd, SalNumber nTab)
        {
            return this.TabActivateFinished(hWnd, nTab);
        }
        #endregion

        #region Event Handlers

        private void commandEdit_Execute(object sender, Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            #region Local Variable
            SalArray<SalString> items = new SalArray<SalString>();
            SalString sCurrTitle;
            SalString sCurrInitials;
            SalString sCurrName;
            SalString sCurrFirstName;
            SalString sCurrMiddleName;
            SalString sCurrLastName;
            SalBoolean bFirstNameChanged = false;
            SalBoolean bMiddleNameChanged = false;
            SalBoolean bLastNameChanged = false;
            SalBoolean bNameAnalyzed = false;
            SalString  sTitle = "";
            #endregion


            #region Action
            vrtDataSourcePrepareKeyTransfer(Pal.GetActiveInstanceName("dlgPersonFullName"));

            sCurrTitle = dfsTitle.Text;
            sCurrInitials = dfsInitials.Text;
            sCurrName = dfsName.Text;
            sCurrFirstName = dfsFirstName.Text;
            sCurrMiddleName = dfsMiddleName.Text;
            sCurrLastName = dfsLastName.Text;
            sFullName = Ifs.Fnd.ApplicationForms.Const.strNULL;
            sFirstName = Ifs.Fnd.ApplicationForms.Const.strNULL;
            sMiddleName = Ifs.Fnd.ApplicationForms.Const.strNULL;
            sLastName = Ifs.Fnd.ApplicationForms.Const.strNULL;

            // Setting sFirstName, sMiddleName and sLastName variables by analyzing name value. 
            // This is done only if concatenation of first, middle, last names differs to full name value.
            if (dfsName.Text != ConstructName(dfsFirstName.Text, dfsMiddleName.Text, dfsLastName.Text))
            {
                AnalyzeName(dfsName.Text);
                bNameAnalyzed = true;
                if (bNew)
                {                  
                    dfsFirstName.Text = sFirstName;
                    dfsMiddleName.Text = sMiddleName;
                    dfsLastName.Text = sLastName;
                }
            }

            Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemAdd("TITLE", new SalArray<SalString>() { dfsTitle });
            Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemAdd("INITIALS", new SalArray<SalString>() { dfsInitials });
            Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemAdd("FIRST_NAME", new SalArray<SalString>() { dfsFirstName });
            Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemAdd("MIDDLE_NAME", new SalArray<SalString>() { dfsMiddleName });
            Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemAdd("LAST_NAME", new SalArray<SalString>() { dfsLastName });

            if (Sys.IDOK == dlgPersonFullName.ModalDialog(Sys.hWndMDI))
            {
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("TITLE", items);
                sTitle = items[0];

                Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("INITIALS", items);
                dfsInitials.Text = items[0];

                // Make editted the fields only if they have changed
                if (!(SalString.Equals(sCurrTitle, sTitle)))
                {
                    dfsTitle.Text = sTitle;
                    dfsTitle.EditDataItemSetEdited();
                }
                if (!(SalString.Equals(sCurrInitials, dfsInitials.Text)))
                {
                    dfsInitials.EditDataItemSetEdited();
                }

                Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("FIRST_NAME", items);
                // If user has changed the saved first name in the dialog new value need to be updated.
                if (!(SalString.Equals(sCurrFirstName, items[0])))
                {
                    dfsFirstName.Text = items[0];
                    dfsFirstName.EditDataItemSetEdited();
                    bFirstNameChanged = true;
                }
                // If the first name saved already differs with the first name extracting from name field.
                // bNameAnalyzed is checked to avoid enabling save button unnecessarily for existing records.
                else if ((!(SalString.Equals(sCurrFirstName, sFirstName))) && bNameAnalyzed)
                {
                    dfsFirstName.Text = sCurrFirstName.Trim();
                    dfsFirstName.EditDataItemSetEdited();
                    bFirstNameChanged = true;
                }

                Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("MIDDLE_NAME", items);
                // If user has changed the saved middle name in the dialog new value need to be updated.                
                if (!(SalString.Equals(sCurrMiddleName, items[0])))
                {
                    dfsMiddleName.Text = items[0];
                    dfsMiddleName.EditDataItemSetEdited();
                    bMiddleNameChanged = true;
                }
                // If the middle name saved already differs with the middle name extracting from name field.
                // bNameAnalyzed is checked to avoid enabling save button unnecessarily for existing records.
                else if ((!(SalString.Equals(sCurrMiddleName, sMiddleName))) && bNameAnalyzed)
                {
                    dfsMiddleName.Text = sCurrMiddleName.Trim();
                    dfsMiddleName.EditDataItemSetEdited();
                    bMiddleNameChanged = true;
                }

                Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("LAST_NAME", items);
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
                // If user has changed the saved last name in the dialog new value need to be updated.                
                if (!(SalString.Equals(sCurrLastName, items[0])))
                {
                    dfsLastName.Text = items[0];
                    dfsLastName.EditDataItemSetEdited();
                    bLastNameChanged = true;
                }
                // If the last name saved already differs with the last name extracting from name field.
                // bNameAnalyzed is checked to avoid enabling save button unnecessarily for existing records.
                else if ((!(SalString.Equals(sCurrLastName, sLastName))) && bNameAnalyzed)
                {
                    dfsLastName.Text = sCurrLastName.Trim();
                    dfsLastName.EditDataItemSetEdited();
                    bLastNameChanged = true;
                }

                // Concatenating First Name, Middle Name and the Last Name to save in the Name column.
                sFullName = ConstructName(dfsFirstName.Text, dfsMiddleName.Text, dfsLastName.Text);

                if ((bFirstNameChanged || bMiddleNameChanged || bLastNameChanged) || (sFullName != sCurrName))
                {  
                    dfsName.EditDataItemValueSet(0, sFullName.ToHandle());
                    dfsName.EditDataItemSetEdited();
                }

            }


            #endregion
        }

        private void commandViewUser_Execute(object sender, Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            IFndExplorerNavigationService navigationService = IFndApplication.FndApplication.ActiveExplorer.Services.GetServiceProvider<IFndExplorerNavigationService>();
            FndUrlAddress tempUrl = new FndUrlAddress("ifswin:Ifs.Application.UserAdministration.User?");

            tempUrl.SetParameter("action", "get");
            tempUrl.SetParameter("key1", dfsUserId.Text);

            navigationService.Navigate(tempUrl);
        }

        private void commandViewUser_Inquire(object sender, Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            commandViewUser.Enabled = false;

            if (dfsUserId.Text != "")
            {
                commandViewUser.Enabled = true;
            }
        }

        private void cmdManageDataProcessingPurposes_Inquire(object sender, Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            #region Action
            if (Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("DATA_SUBJECT_CONSENT_OPER_API.Consent_Action") && !(Sal.IsNull(cmbPerson)) && sDataSubjectEnable == "TRUE")
                ((FndCommand)sender).Enabled = true;
            else
                ((FndCommand)sender).Enabled = false;
            #endregion
        }

        private void cmdManageDataProcessingPurposes_Execute(object sender, Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            #region Action
            DbPLSQLBlock(@"{0} := &AO.Data_Subject_Consent_API.Get_Subject_Key_Ref({1} IN,{2} IN, NULL);", this.QualifiedVarBindName("sDataSubjectKeyRef"), this.QualifiedVarBindName("sDataSubjectDb"), this.cmbPerson.QualifiedBindName);
            if (dlgPersonalDataConsent.ModalDialog(this, this.sDataSubjectKeyRef, sDataSubjectDb, dfsName.Text) == Sys.IDOK)
            {
                Sal.SendMsg(i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceRefresh, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                return;
            }
            #endregion

        }

        #endregion

        #region Overrides

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalNumber vrtDataRecordFetchEditedUser(ref SalString lsAttr)
        {
            return this.DataRecordFetchEditedUser(ref lsAttr);
        }

        public override SalBoolean vrtDataSourcePopulateIt(SalNumber nParam)
        {
            this.bOldBlockedForUse = cbBlockedForUseDb.Checked;
            return base.vrtDataSourcePopulateIt(nParam); 
        }
        #endregion

        


        

    }
}
