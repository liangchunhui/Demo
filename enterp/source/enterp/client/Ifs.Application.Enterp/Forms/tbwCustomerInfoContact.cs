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
// 120913   Maiklk  Implemented to populate the correct record in customer contact tab when opened it from other sources. 
// 121221   Nirplk  Merged Bug 106346.
// 130515   MaRalk  PBR-1605, Added method colsPersonId_OnPM_DataItemLovUserWhere to filter persons who are defined as not blocked customer contacts.
// 130528   MaRalk  PBR-1614, Added colsBlockedForCrmObjectsDb check box and colsPersonId_OnPM_DataItemValidate method.
// 130529   Maiklk  Added CRM related columns colsPersonalInterest, colsCampaignInterest, colsDecisionPowerType, colsDepartment, colsManager, 
// 130529           colsManagerName and colsManagerCustAddress.
// 131010   MaRalk  PBR-1744, Added method colsManager_OnPM_DataItemLovUserWhere to restrict listing the same person in the manager lov. 
// 131029   MaRalk  PBR-1914, Modified method UM_AddContact to support additional values Personal Interest, Campaign Interest, 
// 131029           Decision Power Type, Department, Manager, Manager Cust Address, Manager Guid and Block for Use in CRM 
// 131029           coming from dlgAddContact dialog.
// 140212  Maabse   Changed message response for PAM_SetMainRepresentative and PAM_SetMainRepName
// 140212  Maabse   Added GUID column as a hidden column and removed function GetContactGuid
// 140212  Maabse   Added check if Customer has been created in Method_Inquire for DataRecordNew
// 140305  JanWse   PBSC-7228, Added tableWindow_colsMainRepresentativeId_WindowActions and colsMainRepresentativeId_OnPM_DataItemZoom
// 140324  JanWse   PBSC-7890, Changed from DbPLSQLBlock to DbPLSQLTransaction in Ifs.Fnd.ApplicationForms.Const.METHOD_Execute
// 140331  MaRalk   PBSC-6408, Modified method signature to the call Customer_Info_contact_API.Create_Contact as INOUT in UM_AddContact method.
// 140403  MaRalk   PBSC-8137, Modified UM_AddContact by adding CRM specific information, to support adding an existing person as a customer contact.
// 140411  AjPelk   PBFI-4141 , Merged bug 112761. 
// 140526  MaRalk   PBSC-8831, Modified method UM_AddContact to facilitate name splitting into first, middle, last names in dlgAddContact dialog.
// 140826  Maabse   PESC-1788, Added response to event PAM_RefreshContactOnSave
// 140902  MaIklk   PRSC-2671, Used to check frmCustomerInfoContact is available in order to check crm is installed.
// 140916  JanWse   PRSC-2365, Added parameter bCreatePerson to UM_AddContact
// 141015  JanWse   PRSC-2934, NOTE_TEXT is handled as a CLOB
// 141104  JanWse   PRSC-2930, Keep track of if Manager is entered manually or by LOV
// 150123  MaRalk   PRSC-5384, Modified UM_AddContact in order to facilitate saving person's initials entered in the
// 150123           'Add Contact' dialog.
// 150804  SudJlk   ORA-1106, Modified UM_AddContact to remove value been sent as supplier ID for dlgAddContact.
// 150824  MaRalk   BLU-1182, Modified colsPersonId_OnPM_DataItemValidate in order to fetch the value for www when adding a person.
// 171213  Nirylk   STRFI-9846, Merged LCS Bug 137494, Modified colsPersonId_OnPM_DataItemZoom().
#endregion

using System.Windows.Forms;
using Ifs.Application.Appsrv;
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
    [FndWindowRegistration("CUSTOMER_INFO_CONTACT", "CustomerInfoContact")]
    [FndDynamicTabPage("frmCustomer360.picTab", "tbCustomerInfoContact", "TAB_NAME_CustomerInfoContact", 20)]    
    public partial class tbwCustomerInfoContact : cTableWindowEntBase
    {
        #region Window Variables
        public SalString lsAttr = "";
        public SalString sCustomerId = "";
        public SalString sPersonId = "";
        public SalString sAddressId = "";
        public fcStartupQuery StartupQuery = new fcStartupQuery();
        public SalString sParentWnd = "";
        public SalString sCustomer = "";
        public SalString sCustomerUserWhere = "";
        public SalString sTempCustomerId = "";
        public SalString sTempAddressId = "";
        public SalArray<SalString> sPersonIdVal = new SalArray<SalString>();
        public SalArray<SalString> sGuid = new SalArray<SalString>();
        public SalString lsStmt = "";
        public SalString sNote_Text = "";
        protected SalNumber nFound = 0;
        protected SalBoolean bManagerDataItemLovDone = false;
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public tbwCustomerInfoContact()
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
        public new static tbwCustomerInfoContact FromHandle(SalWindowHandle handle)
        {
            return ((tbwCustomerInfoContact)SalWindow.FromHandle(handle, typeof(tbwCustomerInfoContact)));
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
                if (sMethod == "mnuCreateContact")
                {
                    return UM_AddContact(nWhat, sMethod);
                }
                else
                {
                    return false;
                }
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <param name="sMethod"></param>
        /// <returns></returns>
        public virtual SalNumber UM_AddContact(SalNumber nWhat, SalString sMethod)
        {
            #region Local Variables
            SalString sName = "";
            SalString sFirstName = "";
            SalString sMiddleName = "";
            SalString sLastName = "";
            SalString sRole = "";
            SalString sPhone = "";
            SalString sFax = "";
            SalString sMobile = "";
            SalString sEmail = "";
            SalString sTitle = "";
            SalString sInitials = "";
            SalString sWww = "";
            SalString sMessenger = "";
            SalString sIntercom = "";
            SalString sPager = "";
            SalBoolean bCopyAddress = false;
            SalString sPersonalInterest = "";
            SalString sCampaignInterest = "";
            SalString sDecisionPowerType = "";
            SalString sDepartment = "";
            SalString sManager = "";
            SalString sManagerCustAddress = "";
            SalString sManagerGuid = "";
            SalBoolean bBlockForUse = false;
            SalBoolean bCreatePerson = false;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Customer_Info_contact_API.New") && Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Customer_Info_contact_API.Create_Contact")))
                            return false;
                        
                        SalWindowHandle hWndParentForm = Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndSelf);
                        if (Ifs.Fnd.ApplicationForms.Int.QualifiedItemNameGet(hWndParentForm) == Pal.GetActiveInstanceName("frmCustomerInfo"))
                        {
                            sCustomerId = frmCustomerInfo.FromHandle(hWndParentForm).cmbCustomerId.i_sMyValue;
                        }
                        else if (Ifs.Fnd.ApplicationForms.Int.QualifiedItemNameGet(hWndParentForm) == Pal.GetActiveInstanceName("frmCustomerInfoContact")) // If CRM is installed
                        {
                            sCustomerId = frmCustomerInfo.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(hWndParentForm)).cmbCustomerId.i_sMyValue;
                        }
                        else if (Ifs.Fnd.ApplicationForms.Int.QualifiedItemNameGet(hWndParentForm) == Pal.GetActiveInstanceName("frmCustomer360"))
                        {
                            this.ParentDataSourceItemValueGet("CUSTOMER_NO", ref sCustomerId);
                        }
                        Ifs.Fnd.ApplicationForms.Var.Console.Add(Ifs.Fnd.ApplicationForms.Int.QualifiedItemNameGet(hWndParentForm));
                        return Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("frmCustomerInfo")) && sCustomerId != SalString.Null;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        if (dlgAddContact.ModalDialog(this, ref sPersonId, ref sAddressId, ref sFirstName, ref sMiddleName, ref sLastName, ref sName, ref sRole,
                            ref sPhone, ref sFax, ref sMobile, ref sEmail, ref sTitle, ref sInitials, ref sWww, ref sMessenger, ref sIntercom, ref sPager, ref bCopyAddress,
                            ref sPersonalInterest, ref sCampaignInterest, ref sDecisionPowerType, ref sDepartment, ref sManager, ref sManagerCustAddress, ref sManagerGuid, 
                            ref bBlockForUse, ref bCreatePerson, sCustomerId) == Sys.IDOK)
                        {
                            lsAttr = "";
                            if (bCopyAddress)
                            {
                                Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("COPY_ADDRESS", "TRUE", ref lsAttr);
                                Ifs.Fnd.ApplicationForms.Var.Console.Add("COPY_ADDRESS: ");
                            }
                            if (sPersonId != SalString.Null && bCreatePerson == false)
                            {
                                Ifs.Fnd.ApplicationForms.Var.Console.Add("Adding Person: " + sPersonId);
                                Ifs.Fnd.ApplicationForms.Var.Console.Add("sAddressId: " + sAddressId);
                                Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("ROLE", sRole, ref lsAttr);
                                if (Ifs.Fnd.ApplicationForms.Var.Component.IsWindowAvailable(Pal.GetActiveInstanceName("frmCustomerInfoContact")) && Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("frmCustomerInfoContact")))
                                {
                                    Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("PERSONAL_INTEREST", sPersonalInterest, ref lsAttr);
                                    Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("CAMPAIGN_INTEREST", sCampaignInterest, ref lsAttr);
                                    Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("DECISION_POWER_TYPE", sDecisionPowerType, ref lsAttr);
                                    Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("DEPARTMENT", sDepartment, ref lsAttr);
                                    Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("MANAGER", sManager, ref lsAttr);
                                    Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("MANAGER_CUST_ADDRESS", sManagerCustAddress, ref lsAttr);
                                    Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("MANAGER_GUID", sManagerGuid, ref lsAttr);
                                    if (bBlockForUse)
                                    {
                                        Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("BLOCKED_FOR_CRM_OBJECTS_DB", "TRUE", ref lsAttr);
                                    }
                                    else
                                    {
                                        Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("BLOCKED_FOR_CRM_OBJECTS_DB", "FALSE", ref lsAttr);
                                    }
                                }
                                Ifs.Fnd.ApplicationForms.Var.Console.Add("lsAttr: " + lsAttr);
                                using (SignatureHints hints = SignatureHints.NewContext())
                                {
                                    sNote_Text = colsNoteText.Text;
                                    hints.Add( "Customer_Info_contact_API.New", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input );
                                    DbPLSQLTransaction( cSessionManager.c_hSql, "\r\n" +
                                        "	BEGIN\r\n" +
                                        "		&AO.Customer_Info_contact_API.New(\r\n" +
                                        "			:i_hWndFrame.tbwCustomerInfoContact.sCustomerId,\r\n" +
                                        "			:i_hWndFrame.tbwCustomerInfoContact.sPersonId,\r\n" +
                                        "			:i_hWndFrame.tbwCustomerInfoContact.sNote_Text,\r\n" +
                                        "			:i_hWndFrame.tbwCustomerInfoContact.sAddressId,\r\n" +
                                        "			:i_hWndFrame.tbwCustomerInfoContact.lsAttr ) ;\r\n	END;");
                                }
                            }
                            else
                            {
                                Ifs.Fnd.ApplicationForms.Var.Console.Add("Creating contact: " + sName);
                                Ifs.Fnd.ApplicationForms.Var.Console.Add("sAddressId: " + sAddressId);
                                Ifs.Fnd.ApplicationForms.Var.Console.Add("sName: " + sName);
                                Ifs.Fnd.ApplicationForms.Var.Console.Add("sPhone: " + sPhone);
                                Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("CUSTOMER_ID", sCustomerId, ref lsAttr);
                                if (sAddressId != SalString.Null)
                                {
                                    Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("CUSTOMER_ADDRESS", sAddressId, ref lsAttr);
                                }
                                if ( sPersonId != SalString.Null )
                                {
                                    Ifs.Fnd.ApplicationForms.Int.PalAttrAdd( "PERSON_ID", sPersonId, ref lsAttr );
                                }
                                Ifs.Fnd.ApplicationForms.Int.PalAttrAdd( "FIRST_NAME", sFirstName, ref lsAttr );
                                Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("MIDDLE_NAME", sMiddleName, ref lsAttr);
                                Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("LAST_NAME", sLastName, ref lsAttr);
                                Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("NAME", sName, ref lsAttr);
                                Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("ROLE", sRole, ref lsAttr);
                                Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("PHONE", sPhone, ref lsAttr);
                                Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("FAX", sFax, ref lsAttr);
                                Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("MOBILE", sMobile, ref lsAttr);
                                Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("E_MAIL", sEmail, ref lsAttr);
                                Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("TITLE", sTitle, ref lsAttr);
                                Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("INITIALS", sInitials, ref lsAttr);
                                Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("WWW", sWww, ref lsAttr);
                                Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("MESSENGER", sMessenger, ref lsAttr);
                                Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("INTERCOM", sIntercom, ref lsAttr);
                                Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("PAGER", sPager, ref lsAttr);
                                if (Ifs.Fnd.ApplicationForms.Var.Component.IsWindowAvailable(Pal.GetActiveInstanceName("frmCustomerInfoContact")) && Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("frmCustomerInfoContact")))
                                {
                                    Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("PERSONAL_INTEREST", sPersonalInterest, ref lsAttr);
                                    Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("CAMPAIGN_INTEREST", sCampaignInterest, ref lsAttr);
                                    Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("DECISION_POWER_TYPE", sDecisionPowerType, ref lsAttr);
                                    Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("DEPARTMENT", sDepartment, ref lsAttr);
                                    Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("MANAGER", sManager, ref lsAttr);
                                    Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("MANAGER_CUST_ADDRESS", sManagerCustAddress, ref lsAttr);
                                    Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("MANAGER_GUID", sManagerGuid, ref lsAttr);
                                    if (bBlockForUse)
                                    {
                                        Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("BLOCKED_FOR_CRM_OBJECTS_DB", "TRUE", ref lsAttr);
                                    }
                                    else
                                    {
                                        Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("BLOCKED_FOR_CRM_OBJECTS_DB", "FALSE", ref lsAttr);
                                    }
                                }
                                
                                Ifs.Fnd.ApplicationForms.Var.Console.Add("lsAttr: " + lsAttr);
                                // Create Contact
                                Sal.WaitCursor(true);
                                sNote_Text = colsNoteText.Text;
                                DbPLSQLTransaction(cSessionManager.c_hSql,
                                                   @"&AO.Customer_Info_contact_API.Create_Contact(:i_hWndFrame.tbwCustomerInfoContact.lsAttr INOUT, :i_hWndFrame.tbwCustomerInfoContact.sNote_Text IN);" );
                                Sal.WaitCursor(false);
                                Ifs.Fnd.ApplicationForms.Var.Console.Add("lsAttr: " + lsAttr);
                            }
                            sAddressId = SalString.Null;
                            Sal.SendMsg(i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceRefresh, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Ifs.Fnd.ApplicationForms.Const.POPULATE_Single);
                            SendMessageToParent(Ifs.Application.Enterp.Const.PAM_RefreshContactOnSave, 1, 0);
                        }
                        break;
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// The DataSourceFormatSqlCount formats the select statement for a data source to count
        /// how many objects match the current where expressions.
        /// </summary>
        /// <param name="sCountBind">
        /// Count bind variable
        /// Fully qualifed bind variable to receive the count result.
        /// </param>
        /// <param name="lsStmt">
        /// Select statement
        /// The complete select statement for a data source to count how many objects match the current where expressions.
        /// </param>
        /// <returns></returns>
        public new SalNumber DataSourceFormatSqlCount(SalString sCountBind, ref SalString lsStmt)
        {
            #region Local Variables
            SalNumber nIndex = 0;
            SalString lsStmt2 = "";
            SalString sStmt = "";
            SalString sCommand = "";
            SalNumber nError = 0;
            SalNumber nErrorPos = 0;
            SalString strReturn = "";
            SalDateTime dtReturn = SalDateTime.Null;
            SalWindowHandle hWndReturn = SalWindowHandle.Null;
            SalNumber nReturn = 0;
            SalNumber nType = 0;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                ((cDataSource)this).DataSourceFormatSqlCount(sCountBind, ref lsStmt);
                // ! If customer where is set, apply it in count query
                if (sCustomerUserWhere != SalString.Null)
                {
                    lsStmt = lsStmt + " AND " + sCustomerUserWhere;
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nParam"></param>
        /// <returns></returns>
        public new SalBoolean DataSourcePopulateIt(SalNumber nParam)
        {
            #region Local Variables
            SalString sUserWhere = "";
            SalString lsOrderByStmt = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                if (StartupQuery.Enabled())
                {
                    StartupQuery.Apply();
                    Ifs.Fnd.ApplicationForms.Var.Console.Add("StartupQuery.ActiveQuery:" + StartupQuery.ActiveQuery());
                }
                // Set where condition when used as tab in frmCustomer360
                if (sParentWnd == Pal.GetActiveInstanceName("frmCustomer360"))
                {
                    sUserWhere = " customer_id = :i_hWndParent.frmCustomer360.ecmbCustomerNo.i_sMyValue";
                    sCustomerUserWhere = sUserWhere;
                    if (i_lsUserWhere != Ifs.Fnd.ApplicationForms.Const.strNULL)
                    {
                        sUserWhere = i_lsUserWhere + " AND " + sUserWhere;
                    }
                    DataSourceUserWhere(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, sUserWhere.ToHandle());
                }
                SalString sSourceName = Ifs.Fnd.ApplicationForms.Var.DataTransfer.SourceNameGet();
                if (sSourceName == Pal.GetActiveInstanceName("tbwCustomerInfoContact"))
                {
                    if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.RecCountGet() > 0)
                    {
                        Sal.WaitCursor(true);
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("PERSON_ID", sPersonIdVal);
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("GUID", sGuid);
                        if (sGuid[0] == SalString.Null)
                        {
                            lsStmt = " PERSON_ID = :i_hWndFrame.tbwCustomerInfoContact.sPersonIdVal[0]";
                        }
                        else
                        {
                            lsStmt = " PERSON_ID = :i_hWndFrame.tbwCustomerInfoContact.sPersonIdVal[0] AND GUID = :i_hWndFrame.tbwCustomerInfoContact.sGuid[0]";
                        }
                        Sal.SendMsg(i_hWndFrame, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceUserWhere, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, lsStmt.ToHandle());                        
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
                        Sal.WaitCursor(false);
                    }
                }

                return ((cTableWindow)this).DataSourcePopulateIt(nParam);
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="PSheetList"></param>
        /// <param name="sTitle"></param>
        /// <returns></returns>
        public new SalNumber PSheetPrepare(cPSheetList PSheetList, ref SalString sTitle)
        {
            #region Actions
            using (new SalContext(this))
            {
                ((cTableWindow)this).PSheetPrepare(PSheetList, ref sTitle);
                // Only add sheet for certain parent(s)
                if (StartupQuery.Enabled())
                {
                    Ifs.Fnd.ApplicationForms.Var.Profile.ValueSet(ProfileSectionGet() + "." + Ifs.Application.Appsrv.Const.DETAIL_STARTUP_QUERY_SECTION, "ViewName", QueryViewGet());
                    PSheetList.Add(Pal.GetActiveInstanceName("dlgPSheetStartupQuery"), Ifs.Application.Appsrv.Const.PSHEET_StartupQuery);
                }
            }

            return 0;
            #endregion
        }
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber CheckDefault()
        {
            SalWindowHandle hWndParent = SalWindowHandle.Null;
            SalWindowHandle hWndAddress = SalWindowHandle.Null;                
            #region Actions
            using (new SalContext(this))
            {
                if ((Ifs.Fnd.ApplicationForms.Int.QualifiedItemNameGet(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndSelf)) == Pal.GetActiveInstanceName("frmCustomerInfo")) ||
                   (Ifs.Fnd.ApplicationForms.Int.QualifiedItemNameGet(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndSelf)) == Pal.GetActiveInstanceName("frmCustomerInfoContact")) || // If CRM is installed
                   (Ifs.Fnd.ApplicationForms.Int.QualifiedItemNameGet(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndSelf)) == Pal.GetActiveInstanceName("frmCustomer360")))
                    
                {
                    sTempCustomerId = this.colsCustomerId.Text;
                    sTempAddressId = Ifs.Fnd.ApplicationForms.Const.strNULL;
                }                
                if (sTempCustomerId != Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    using (SignatureHints hints = SignatureHints.NewContext())
                    {
                        hints.Add("Customer_Info_Contact_API.Check_Default_Values", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                        if (!(DbPLSQLBlock(cSessionManager.c_hSql, "&AO.Customer_Info_Contact_API.Check_Default_Values (	:i_hWndFrame.tbwCustomerInfoContact.sTempCustomerId,\r\n" +
                            "									:i_hWndFrame.tbwCustomerInfoContact.sTempAddressId)")))
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            #endregion
        }

        private SalBoolean FrameStartupUser()
        {
            #region Actions
            using (new SalContext(this))
            {
                if (((cDataSource)this).FrameStartupUser())
                {
                    if (this.i_hWndParent == SalString.Null)
                    {
                        colsCustomerId.Visible = true;
                        colsCustomerName.Visible = true;
                        this.colsCustomerId.EditDataItemFlagSet(Ifs.Fnd.ApplicationForms.Const.FIELD_Query, true);
                        this.colsCustomerName.EditDataItemFlagSet(Ifs.Fnd.ApplicationForms.Const.FIELD_Query, true);  
                    }
                    else
                    {
                        colsCustomerId.Visible = false;
                        colsCustomerName.Visible = false;
                        this.colsCustomerId.EditDataItemFlagSet(Ifs.Fnd.ApplicationForms.Const.FIELD_Query, false);
                        this.colsCustomerName.EditDataItemFlagSet(Ifs.Fnd.ApplicationForms.Const.FIELD_Query, false);  
                    }
                    HandleCrmColumns();
                    return true;
                }
                else
                    return false;
            }
            #endregion
        }

        /// <summary>
        /// colsBlockedForCrmObjectsDb, colsPersonalInterest, colsCampaignInterest, colsDecisionPowerType, colsDepartment, colsManager, colsMainRepresentativeId
        /// colsManagerName and colsManagerCustAddress columns are shown only when CRM is installed.
        /// </summary>
        protected virtual void HandleCrmColumns()
        {
            if (!(Ifs.Fnd.ApplicationForms.Var.Component.IsWindowAvailable(Pal.GetActiveInstanceName("frmCustomerInfoContact")) && Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("frmCustomerInfoContact"))))            
            {
                colsBlockedForCrmObjectsDb.Visible = false;
                colsMainRepresentativeId.Visible = false;
                colsMainRepresentativeName.Visible = false;
                colsPersonalInterest.Visible = false;
                colsCampaignInterest.Visible = false;
                colsDecisionPowerType.Visible = false;
                colsDepartment.Visible = false;
                colsManager.Visible = false;
                colsManagerName.Visible = false;
                colsManagerCustAddress.Visible = false;
            }
        }
        protected virtual bool AddNote( SalNumber nFlagOn, SalNumber nFlagOff )
        {
            SalNumber nRow = Sys.TBL_MinRow;
            while ( Sal.TblFindNextRow( this, ref nRow, nFlagOn, nFlagOff ) )
            {
                Sal.TblSetContext( this, nRow );
                if ( colsNoteText.EditDataItemStateGet() != Ifs.Fnd.ApplicationForms.Const.EDIT_Changed )
                    continue;
                SalString sObjid = DataRecordIdGet();
                SalString sObjversion = DataRecordVersionGet();
                if ( ( (cSessionManager)this ).DbClobWrite( cSessionManager.c_hSql, "CUSTOMER_INFO_CONTACT_API.Write_Note_Text__", sObjid, ref sObjversion, colsNoteText.Text ) )
                    __colObjversion.Text = sObjversion;
                else
                    return false;
            }
            return true;
        }
        #endregion

        #region Window Actions

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tbwCustomerInfoContact_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew:
                    this.tbwCustomerInfoContact_OnPM_DataRecordNew(sender, e);
                    break;
                
                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave:
                    this.tbwCustomerInfoContact_OnPM_DataSourceSave(sender, e);
                    break;

                case Sys.SAM_Create:
                    this.tbwCustomerInfoContact_OnSAM_Create(sender, e);
                    break;

                case Ifs.Application.Appsrv.Const.PAM_StartupQueryResetParent:
                    e.Handled = true;
                    // Parent is going to be populated
                    this.StartupQuery.ResetParent();
                    break;

                case Ifs.Application.Appsrv.Const.PAM_StartupQueryActiveGet:
                    e.Handled = true;
                    // Return the name of the active StartupQuery
                    e.Return = this.StartupQuery.ActiveQuery().ToHandle();
                    return;


                case Ifs.Fnd.ApplicationForms.Const.PM_User:
                    this.tbwCustomerInfoContact_OnPM_User(sender, e);
                    break;


                case Sys.SAM_RowSetContext:
                    this.tbwCustomerInfoContact_OnSAM_RowSetContext(sender, e);
                    break;

                case Ifs.Application.Enterp.Const.PAM_SetMainRepresentative:
                    this.tbwCustomerInfoContact_OnPAM_SetMainRepresentative(sender, e);
                    break;

                case Ifs.Application.Enterp.Const.PAM_SetMainRepName:
                    this.tbwCustomerInfoContact_OnPAM_SetMainRepName(sender, e);
                    break;

                case Ifs.Application.Enterp.Const.PAM_GetParentValue:
                    e.Handled = true;
                    e.Return = ((SalString)this.colsGuid.Text).ToHandle();
                    break;

                case Ifs.Application.Enterp.Const.PAM_GetObjectType:
                    e.Handled = true;
                    e.Return = ((SalString)Const.OBJECT_ContactType).ToHandle();
                    break;

                case Ifs.Application.Enterp.Const.PAM_RecordNotInitiallySaved:
                    e.Handled = true;
                    e.Return = Sal.IsNull(__colObjid);
                    break;

                case Ifs.Application.Enterp.Const.PAM_RefreshContactOnSave:
                    e.Handled = true;
                    this.tbwCustomerInfoContact_OnPAM_RefreshContactOnSave(sender, e);
                    break;
            }
            #endregion
        }

        private void tbwCustomerInfoContact_OnPM_DataRecordNew(object sender, WindowActionsEventArgs e)
        {
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)
            {
                if (SendMessageToParent(Ifs.Application.Enterp.Const.PAM_RecordNotInitiallySaved, 0, 0))
                {
                    e.Return = false;
                    return;
                }
            }
            else if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                SendMessageToParent(Ifs.Application.Enterp.Const.PAM_SetTabToFirst, 0, 0);
            }            
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Sys.wParam, Sys.lParam);
            return;
        }

        /// <summary>
        /// PM_DataSourceSave event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwCustomerInfoContact_OnPM_DataSourceSave(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)
            {
                if (Ifs.Fnd.ApplicationForms.Int.QualifiedItemNameGet(Ifs.Fnd.ApplicationForms.Int.GetParent(this.i_hWndSelf)) != Pal.GetActiveInstanceName("frmCustomerInfo"))
                {
                    e.Return = false;
                    return;
                }
                e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Sys.wParam, Sys.lParam);
                return;
            }
            else
            {
                Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Sys.wParam, Sys.lParam);
                e.Return = Sal.SendMsg(this.i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceRefresh, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Ifs.Fnd.ApplicationForms.Const.POPULATE_Single);
                return;
            }
            #endregion
        }

        /// <summary>
        /// SAM_Create event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwCustomerInfoContact_OnSAM_Create(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam);
            this.sParentWnd = Ifs.Fnd.ApplicationForms.Int.PalGetItemNameX(Ifs.Fnd.ApplicationForms.Int.GetParent(this));
            this.StartupQuery.Init(this.i_hWndSelf, this.ProfileSectionGet());            
            #endregion
        }

        /// <summary>
        /// PM_User event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwCustomerInfoContact_OnPM_User(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                if (SalString.FromHandle(Sys.lParam) == "frmCustomerInfoSaveCheckOk")
                {
                    e.Return = this.CheckDefault();
                    return;
                }
            }
            e.Return = Sal.SendMsgToChildren(this.i_hWndFrame, Ifs.Fnd.ApplicationForms.Const.PM_User, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        private void tbwCustomerInfoContact_OnSAM_RowSetContext(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Sys.SAM_RowSetContext, Sys.wParam, Sys.lParam);
            // Populate representatives table if CRM is installed
            if(Ifs.Fnd.ApplicationForms.Int.QualifiedItemNameGet(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndSelf)) == Pal.GetActiveInstanceName("frmCustomerInfoContact")) // If CRM is installed
                SendMessageToParent(Const.PAM_PopulateRepresentative, 1, 0);            
            e.Return = true;

            #endregion
        }

        private void tbwCustomerInfoContact_OnPAM_SetMainRepresentative(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            SalNumber nRow = Sys.TBL_MinRow;
            SalNumber nOriginalContextRow = this.GetContextRow();
            while (Sal.TblFindNextRow(this, ref nRow, 0, 0))
            {
                this.SetContextRow(nRow);
                if (colsGuid.Text == SalString.FromHandle(Sys.wParam))
                {
                    colsMainRepresentativeId.Text = SalString.FromHandle(Sys.lParam);
                    //colsMainRepresentativeId.EditDataItemSetEdited(); //Cannot be uncommented, Not possible to delete a main rep row.
                }
            }
            this.SetContextRow(nOriginalContextRow);
            #endregion
        }

        private void tbwCustomerInfoContact_OnPAM_SetMainRepName(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            SalNumber nRow = Sys.TBL_MinRow;
            SalNumber nOriginalContextRow = this.GetContextRow();
            while (Sal.TblFindNextRow(this, ref nRow, 0, 0))
            {
                this.SetContextRow(nRow);
                if (colsGuid.Text == SalString.FromHandle(Sys.wParam))
                {
                    colsMainRepresentativeName.Text = SalString.FromHandle(Sys.lParam);
                }
            }
            this.SetContextRow(nOriginalContextRow);
            #endregion
        }

        private void tbwCustomerInfoContact_OnPAM_RefreshContactOnSave(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            SalNumber nRow = Sys.TBL_MinRow;
            SalNumber nOriginalContextRow = this.GetContextRow();
            SalString sPersonId = SalString.FromHandle(Sys.wParam);

            if (sPersonId == "")
            {
                SalNumber nFocusRow = 0;
                SalWindowHandle nFocusCol = null;
                Sal.TblQueryFocus(this, ref nFocusRow, ref nFocusCol);
                this.SetContextRow(nFocusRow);
                sPersonId = colsPersonId.Text;
                this.SetContextRow(nOriginalContextRow);
            }

            while (Sal.TblFindNextRow(this, ref nRow, 0, 0))
            {
                this.SetContextRow(nRow);
                if (colsPersonId.Text == sPersonId)
                {
                    Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataRecordRefresh, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                }
            }
            this.SetContextRow(nOriginalContextRow);
           
            #endregion
        }

        private void colsPersonId_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.colsPersonId_OnPM_DataItemValidate(sender, e);
                    break;
                
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovUserWhere:
                    this.colsPersonId_OnPM_DataItemLovUserWhere(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom:
                    this.colsPersonId_OnPM_DataItemZoom(sender, e);
                    break;
            }
            #endregion
        }

        private void colsPersonId_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam)
            {
                if (DbPLSQLBlock(cSessionManager.c_hSql, @"BEGIN 
														  &AO.Person_Info_Address_API.Get_Default_Contact_Info(:i_hWndFrame.tbwCustomerInfoContact.colPersonInfoAddressPhone OUT,
																											   :i_hWndFrame.tbwCustomerInfoContact.colPersonInfoAddressMobile OUT,
																											   :i_hWndFrame.tbwCustomerInfoContact.colPersonInfoAddressE_Mail OUT,
																											   :i_hWndFrame.tbwCustomerInfoContact.colPersonInfoAddressFax OUT,
																											   :i_hWndFrame.tbwCustomerInfoContact.colPersonInfoAddressPager OUT,
																											   :i_hWndFrame.tbwCustomerInfoContact.colPersonInfoAddressIntercom OUT,
                                                                                                               :i_hWndFrame.tbwCustomerInfoContact.colPersonInfoAddressWww OUT,
																											   :i_hWndFrame.tbwCustomerInfoContact.colsPersonId IN,
																											   :i_hWndFrame.tbwCustomerInfoContact.colsContactAddress IN);
                                                          IF (&AO.Person_Info_API.Get_Blocked_For_Use_Db(:i_hWndFrame.tbwCustomerInfoContact.colsPersonId IN) = 'FALSE') THEN
                                                             :i_hWndFrame.tbwCustomerInfoContact.colsBlockedForCrmObjectsDb := 'FALSE';
                                                          END IF;                                               	                   
                                                       END;"))
                {
                    colsBlockedForCrmObjectsDb.EditDataItemSetEdited();
                    e.Return = Sys.VALIDATE_Ok;
                }
                else
                {
                    e.Return = Sys.VALIDATE_Cancel; 
                }
            }            
            e.Return = Sys.VALIDATE_Ok;
            return;
            #endregion
        }

        private void colsPersonId_OnPM_DataItemLovUserWhere(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            e.Return = ((SalString)"CUSTOMER_CONTACT_DB='TRUE' AND BLOCKED_FOR_USE_DB='FALSE'").ToHandle(); 
            return;     
            #endregion
        }

        private void colsPersonId_OnPM_DataItemZoom(object sender, WindowActionsEventArgs e)
        {
            SalArray<SalString> sItemNames = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();

            #region Actions
            e.Handled = true;

            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                sItemNames[0] = "PERSON_ID";
                hWndItems[0] = colsPersonId;
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("PERSON_ID", this, sItemNames, hWndItems);
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.TypeSet("ZOOM");                
                SessionNavigate(Pal.GetActiveInstanceName("frmPersonInfo"));
                e.Return = true;
                return;
            }
            else if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)
            {
                e.Return = CanDataTransferTo(Pal.GetActiveInstanceName("frmPersonInfo"));
                return;
            }
            else
            {
                e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom, Sys.wParam, Sys.lParam);
                return;
            }
            #endregion
        }

        private void colsManager_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
               
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovDone:
                    this.colsManager_OnPM_DataItemLovDone(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.colsManager_OnPM_DataItemValidate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovUserWhere:
                    this.colsManager_OnPM_DataItemLovUserWhere(sender, e);
                    break;
            }
            #endregion
        }

        private void colsManager_OnPM_DataItemLovDone(object sender, WindowActionsEventArgs e)
        {

            #region Actions
            e.Handled = true;
            bManagerDataItemLovDone = true;
            Sal.SendMsg(this.colsManager, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, Vis.StrSubstitute(Ifs.Fnd.ApplicationForms.Int.PalAttrGet("PERSON_ID", SalString.FromHandle(Sys.lParam)), ((SalNumber)31).ToCharacter(), "").ToHandle());
            Sal.SendMsg(this.colsManagerCustAddress, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, Vis.StrSubstitute(Ifs.Fnd.ApplicationForms.Int.PalAttrGet("CUSTOMER_ADDRESS", SalString.FromHandle(Sys.lParam)), ((SalNumber)31).ToCharacter(), "").ToHandle());
            #endregion
        }

        private void colsManager_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;

            if (Sys.wParam)
            {                
                Sal.WaitCursor(true);
                nFound = 0;
                if (colsManager.Text == Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    colsManagerGuid.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                    colsManagerGuid.EditDataItemSetEdited();
                    colsManagerCustAddress.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                    colsManagerCustAddress.EditDataItemSetEdited();
                    e.Return = Sys.VALIDATE_Ok;
                    return;
                }
                if ( bManagerDataItemLovDone )
                {
                    lsStmt = @"BEGIN 
                                  :i_hWndFrame.tbwCustomerInfoContact.colsManagerGuid :=  &AO.Customer_Info_Contact_API.Get_Guid_By_Cust_Address(:i_hWndFrame.tbwCustomerInfoContact.colsCustomerId IN, :i_hWndFrame.tbwCustomerInfoContact.colsManager IN, :i_hWndFrame.tbwCustomerInfoContact.colsManagerCustAddress IN);
                                  :i_hWndFrame.tbwCustomerInfoContact.colsManagerName :=  &AO.Person_Info_API.Get_Name(:i_hWndFrame.tbwCustomerInfoContact.colsManager IN);                                                                                         
                               END;";
                    bManagerDataItemLovDone = false;
                }
                else
                {
                    lsStmt = @"BEGIN 
                                  IF :i_hWndFrame.tbwCustomerInfoContact.colsManagerCustAddress IS NULL THEN
                                    &AO.Customer_Info_Contact_API.Validate_Customer_Address(:i_hWndFrame.tbwCustomerInfoContact.nFound OUT, :i_hWndFrame.tbwCustomerInfoContact.colsManagerCustAddress OUT, :i_hWndFrame.tbwCustomerInfoContact.colsCustomerId IN, :i_hWndFrame.tbwCustomerInfoContact.colsManager IN); 
                                  END IF;
                                  :i_hWndFrame.tbwCustomerInfoContact.colsManagerGuid :=  &AO.Customer_Info_Contact_API.Get_Guid_By_Cust_Address(:i_hWndFrame.tbwCustomerInfoContact.colsCustomerId IN, :i_hWndFrame.tbwCustomerInfoContact.colsManager IN, :i_hWndFrame.tbwCustomerInfoContact.colsManagerCustAddress IN);
                                  :i_hWndFrame.tbwCustomerInfoContact.colsManagerName :=  &AO.Person_Info_API.Get_Name(:i_hWndFrame.tbwCustomerInfoContact.colsManager IN);                                                                                         
                               END;";
                }
                if (DbPLSQLBlock(cSessionManager.c_hSql, lsStmt))
                {
                    if (nFound > 1)
                    {
                        Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_ManyContactAddress, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                    }
                    colsManagerGuid.EditDataItemSetEdited();
                    colsManagerCustAddress.EditDataItemSetEdited();
                }
                Sal.WaitCursor(false);
            }

            e.Return = Sys.VALIDATE_Ok;
            return;

            #endregion
        }

        private void colsManager_OnPM_DataItemLovUserWhere(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            e.Return = ((SalString)"PERSON_ID !='" + this.colsPersonId.Text + "'").ToHandle();
            return;
            #endregion            
        }

        private void colsManagerCustAddress_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovDone:
                    this.colsManagerCustAddress_OnPM_DataItemLovDone(sender, e);
                    break;              
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovUserWhere:
                    this.colsManagerCustAddress_OnPM_DataItemLovUserWhere(sender, e);
                    break;
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.colsManagerCustAddress_OnPM_DataItemValidate(sender, e);
                    break;  
            }
            #endregion
        }

        private void colsManagerCustAddress_OnPM_DataItemLovDone(object sender, WindowActionsEventArgs e)
        {

            #region Actions
            e.Handled = true;
            Sal.SendMsg(this.colsManagerCustAddress, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 1, Vis.StrSubstitute(Ifs.Fnd.ApplicationForms.Int.PalAttrGet("CUSTOMER_ADDRESS", SalString.FromHandle(Sys.lParam)), ((SalNumber)31).ToCharacter(), "").ToHandle());
            #endregion
        }

        private void colsManagerCustAddress_OnPM_DataItemLovUserWhere(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (colsManager.Text != SalString.Null)
            {
                e.Return = ((SalString)"PERSON_ID= '" + colsManager.Text + "'").ToHandle();
                return;
            }
            e.Return = true;
            return;
            #endregion
        }

        private void colsManagerCustAddress_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;

            if (Sys.wParam)
            {
                Sal.WaitCursor(true);
                lsStmt = @"BEGIN                                  
                               :i_hWndFrame.tbwCustomerInfoContact.colsManagerGuid :=  &AO.Customer_Info_Contact_API.Get_Guid_By_Cust_Address(:i_hWndFrame.tbwCustomerInfoContact.colsCustomerId IN, :i_hWndFrame.tbwCustomerInfoContact.colsManager IN, :i_hWndFrame.tbwCustomerInfoContact.colsManagerCustAddress IN);                                                                                                                 
                           END;";
                if (DbPLSQLBlock(cSessionManager.c_hSql, lsStmt))
                {
                    colsManagerGuid.EditDataItemSetEdited();
                }
                Sal.WaitCursor(false);
            }

            e.Return = Sys.VALIDATE_Ok;
            return;

            #endregion
        }

        private void tableWindow_colsDecisionPowerType_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_DropDown:
                    e.Handled = true;
                    e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_LookupInit, Sys.wParam, Sys.lParam);
                    break;
            }
            #endregion
        }

        private void tableWindow_colsDepartment_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_DropDown:
                    e.Handled = true;
                    e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_LookupInit, Sys.wParam, Sys.lParam);
                    break;
            }
            #endregion
        }

        #endregion

        #region Late Bind Methods

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalNumber vrtDataSourceFormatSqlCount(SalString sCountBind, ref SalString lsStmt)
        {
            return this.DataSourceFormatSqlCount(sCountBind, ref lsStmt);
        }

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalBoolean vrtDataSourcePopulateIt(SalNumber nParam)
        {
			return this.DataSourcePopulateIt(nParam);
        }

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalNumber vrtPSheetPrepare(cPSheetList PSheetList, ref SalString sTitle)
        {
            return this.PSheetPrepare(PSheetList, ref sTitle);
        }

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalNumber vrtUserMethod(SalNumber nWhat, SalString sMethod)
        {
            return this.UserMethod(nWhat, sMethod);
        }

        public override SalBoolean vrtFrameStartupUser()
        {
            return this.FrameStartupUser();
        }

        public override SalBoolean vrtDataSourceSaveNew()
        {
            SalBoolean bOk = base.vrtDataSourceSaveNew();
            if (!this.CheckDefault())
            {
                return false;
            }
            if ( bOk )
                bOk = AddNote( Sys.ROW_New, 0 );
            return bOk;
        }
        public override SalBoolean vrtDataSourceSaveModified()
        {
            SalBoolean bOk = base.vrtDataSourceSaveModified();
            if ( bOk )
                bOk = AddNote( Sys.ROW_Edited, Sys.ROW_New );
            return bOk;
        }

        public override SalNumber vrtDataRecordFetchEditedUser( ref SalString lsAttr )
        {
            Ifs.Fnd.ApplicationForms.Int.PalAttrRemove( "NOTE_TEXT", ref lsAttr );
            return base.vrtDataRecordFetchEditedUser( ref lsAttr );
        }

        #endregion

        #region Event Handlers

        private void menuItem__Add_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            // TODO: Rewrite command event handler not to use UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            ((FndCommand)sender).Enabled = Sal.SendMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, ((SalString)"mnuCreateContact").ToHandle());
        }

        private void menuItem__Add_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            // TODO: Rewrite command event handler not to make use of UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            Ifs.Fnd.ApplicationForms.Int.PostMessage(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, "mnuCreateContact");
        }

        #endregion

        private void tableWindow_colsMainRepresentativeId_WindowActions( object sender, WindowActionsEventArgs e )
        {
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom:
                    this.colsMainRepresentativeId_OnPM_DataItemZoom( sender, e );
                break;
            }
        }

        private void colsMainRepresentativeId_OnPM_DataItemZoom( object sender, WindowActionsEventArgs e )
        {
            SalArray<SalString> sItemNames = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();

            e.Handled = true;

            if ( Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute )
            {
                sItemNames[0] = "REPRESENTATIVE_ID";
                hWndItems[0] = this.colsMainRepresentativeId;
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init( "REPRESENTATIVE_ID", this, sItemNames, hWndItems );
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.TypeSet( "ZOOM" );
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.i_sDestination = "BUSINESS_REPRESENTATIVE";
                SessionNavigate(Pal.GetActiveInstanceName("frmRelMgtBasic"));
                e.Return = true;
                return;
            }
            else
            {
                e.Return = Sal.SendClassMessage( Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom, Sys.wParam, Sys.lParam );
                return;
            }
        }               
    }
}
