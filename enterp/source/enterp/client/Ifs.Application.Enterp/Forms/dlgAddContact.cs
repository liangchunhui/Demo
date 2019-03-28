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
// -----    ------  ---------------------------------------------------------
// 131121  MaIklk  PRSC-3983, Handled to avoid executing validate for name if edit button is clicked.
// 131114  Pratlk  PBFI-2513, Refactor client windows in component ENTERP
// 131121  MaIklk  Added check for blocked for use and able to use as contact check when populating contacts.
// 131029  MaRalk  PBR-1914, Added Override Constructor and overide method ModalDialog to support additional parameters
// 131029          Personal Interest, Campaign Interest, Decision Power Type, Department, Manager, Manager Cust Address, Manager Guid  
// 131029          and Block for Use in CRM. Added window actions for new fields cbPersonalInterest, cbCampaignInterest, 
// 131029          cbDecisionPowerType, cbDepartment, dfsManager and dfsManagerCustAddress. Added methods FrameStartupUser and HandleCrmColumns.
// 140401  MaRalk  PBSC-6408, Added method TransferCrmValues.
// 140526  MaRalk  PBSC-8831, Added method dfsName_OnPM_DataItemValidate to facilitate full name splitting into first, middle, last names.
// 140526          Added method commandEdit_Execute. Added parameters sFirstName, sMiddleName and sLastName to the  
// 140526          method ModalDialog. Added methods AnalyzeName, ConstructName.
// 140604  MaRalk  PRSC-1212, Modified method ModalDialog which having 17 parameters. Modified method HandleCrmColumns to disable the 
// 140604          'CRM Specific Info' group box once it is open from Supplier/Contact tab.  
// 140829  JanWse  PRSC-2423, Only filter with CUSTOMER_CONTACT_DB='TRUE' when started from customer form.
// 140902  MaIklk  PRSC-2671, Used to check frmCustomerInfoContact is available in order to check crm is installed.
// 140916  JanWse  PRSC-2365, Partly rewritten
// 141126  JanWse  PRSC-4360, Disable OK button when reset button is pressed
// 150123  MaRalk  PRSC-5384, Modified methods ModalDialog, TransferValues in order to retrieve person's initials 
// 150123          entered in the 'Full Name' dialog.
// 150804  SudJlk  ORA-1106, Removed code related to supplier contact as the adding of supplier contact will be handled by dlgAddSupplierContact.
// 150825  Hairlk  AFT-1691, Added STARTED_FROM_SUPPLIER to data transfer when calling dlgFindPerson in order to identify whether the call is made in customer_contact
//                 context or supplier_contact context
// 160114  Hawalk  STRFI-875 (Merged Bug 126340), Expanded the drop down width of cbCampaignInterest from 126 to 170.
// 170829  Chwilk  STRFI-9606, Bug 137301, Modified dfsName_OnSAM_AnyEdit() in order to fix the Person's Name is Parsed Incorrectly.
// 171020  Chwilk  STRFI-10294, Bug 138102, Initialized the window parameters where the access modifier is of protected type.
#endregion

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Ifs.Fnd.ApplicationForms;
using PPJ.Runtime;
using PPJ.Runtime.Windows;
using PPJ.Runtime.Vis;

namespace Ifs.Application.Enterp
{

    /// <summary>
    /// </summary>
    /// <param name="sPersonId"></param>
    /// <param name="sAddressId"></param>
    /// <param name="sName"></param>
    /// <param name="sRole"></param>
    /// <param name="sPhone"></param>
    /// <param name="sFax"></param>
    /// <param name="sMobile"></param>
    /// <param name="sEmail"></param>
    /// <param name="sTitle"></param>
    /// <param name="sInitials"></param>
    /// <param name="sWww"></param>
    /// <param name="sMessenger"></param>
    /// <param name="sIntercom"></param>
    /// <param name="sPager"></param>
    /// <param name="bCopyAddress"></param>    
    /// <param name="sPersonalInterest"></param>
    /// <param name="sCampaignInterest"></param>
    /// <param name="sDecisionPowerType"></param>
    /// <param name="sDepartment"></param>
    /// <param name="sManager"></param>
    /// <param name="sManagerCustAddress"></param>
    /// <param name="ManagerGuid"></param>
    /// <param name="bBlockForUse"></param>
    /// <param name="bCreatePerson"></param>
    /// <param name="sCustomerId"></param>
    [FndWindowRegistration("PERSON_INFO_ALL", "PersonInfo")]
    public partial class dlgAddContact : cDialogBox
    {
        #region Window Parameters
        public SalString sPersonId;
        public SalString sAddressId;
        public SalString sName;
        public SalString sRole;
        public SalString sPhone;
        public SalString sFax;
        public SalString sMobile;
        public SalString sEmail;
        public SalString sTitle;
        public SalString sInitials;
        public SalString sWww;
        public SalString sMessenger;
        public SalString sIntercom;
        public SalString sPager;
        public SalBoolean bCopyAddress;
        protected SalString sPersonalInterest = "";
        protected SalString sCampaignInterest = "";
        protected SalString sDecisionPowerType = "";
        protected SalString sDepartment = "";
        protected SalString sManager = "";
        protected SalString sManagerCustAddress = "";
        protected SalString sManagerGuid = "";
        protected SalBoolean bBlockForUse = false;
        protected SalBoolean bCreatePerson = true;
        public SalString sCustomerId;
        protected SalString sOwner = "";
        #endregion

        #region Window Variables
        public SalWindowHandle hWndLastFieldActive = SalWindowHandle.Null;
        public SalBoolean bUseCustomerAddress = false;
        public SalNumber nNum = 0;
        public SalString sWhereStmt = "";
        public SalArray<SalString> sRecords = new SalArray<SalString>();
        public SalArray<SalString> sUnits = new SalArray<SalString>();
        protected SalNumber nFound = 0;
        protected SalString lsStmt = "";
        protected SalBoolean bManagerLovDone = false;
        protected SalString sFullName = Ifs.Fnd.ApplicationForms.Const.strNULL;
        protected SalString sFirstName = Ifs.Fnd.ApplicationForms.Const.strNULL;
        protected SalString sMiddleName = Ifs.Fnd.ApplicationForms.Const.strNULL;
        protected SalString sLastName = Ifs.Fnd.ApplicationForms.Const.strNULL;
        #endregion

        #region Constructors/Destructors
        /// <summary>
        /// Override Constructor.
        /// </summary>
        public dlgAddContact()
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
        public static SalNumber ModalDialog(
                    Control owner,
                    ref SalString sPersonId,
                    ref SalString sAddressId,
                    ref SalString sFirstName,
                    ref SalString sMiddleName,
                    ref SalString sLastName,
                    ref SalString sName,
                    ref SalString sRole,
                    ref SalString sPhone,
                    ref SalString sFax,
                    ref SalString sMobile,
                    ref SalString sEmail,
                    ref SalString sTitle,
                    ref SalString sInitials,
                    ref SalString sWww,
                    ref SalString sMessenger,
                    ref SalString sIntercom,
                    ref SalString sPager,
                    ref SalBoolean bCopyAddress,
                    ref SalString sPersonalInterest,
                    ref SalString sCampaignInterest,
                    ref SalString sDecisionPowerType,
                    ref SalString sDepartment,
                    ref SalString sManager,
                    ref SalString sManagerCustAddress,
                    ref SalString sManagerGuid,
                    ref SalBoolean bBlockForUse,
                    ref SalBoolean bCreatePerson,
                    SalString sCustomerId)
        {
            dlgAddContact dlg = DialogFactory.CreateInstance<dlgAddContact>();
            dlg.sCustomerId = sCustomerId;
            dlg.sOwner = owner.Name;
            SalNumber ret = dlg.ShowDialog(owner);
            sPersonId = dlg.sPersonId;
            sAddressId = dlg.sAddressId;
            sFirstName = dlg.sFirstName;
            sMiddleName = dlg.sMiddleName;
            sLastName = dlg.sLastName;
            sName = dlg.sName;
            sRole = dlg.sRole;
            sPhone = dlg.sPhone;
            sFax = dlg.sFax;
            sMobile = dlg.sMobile;
            sEmail = dlg.sEmail;
            sTitle = dlg.sTitle;
            sInitials = dlg.sInitials;
            sWww = dlg.sWww;
            sMessenger = dlg.sMessenger;
            sIntercom = dlg.sIntercom;
            sPager = dlg.sPager;
            bCopyAddress = dlg.bCopyAddress;
            sPersonalInterest = dlg.sPersonalInterest;
            sCampaignInterest = dlg.sCampaignInterest;
            sDecisionPowerType = dlg.sDecisionPowerType;
            sDepartment = dlg.sDepartment;
            sManager = dlg.sManager;
            sManagerCustAddress = dlg.sManagerCustAddress;
            sManagerGuid = dlg.sManagerGuid;
            bBlockForUse = dlg.bBlockForUse;
            bCreatePerson = dlg.bCreatePerson;

            return ret;
        }

        /// <summary>
        /// Returns the object instance associated with the window handle.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        public new static dlgAddContact FromHandle(SalWindowHandle handle)
        {
            return ((dlgAddContact)SalWindow.FromHandle(handle, typeof(dlgAddContact)));
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
                if (sMethod == "Ok")
                {
                    return UM_Ok(nWhat);
                }
                else if (sMethod == "Cancel")
                {
                    return UM_Cancel(nWhat);
                }
                else if (sMethod == "Find")
                {
                    return UM_Find(nWhat);
                }
                else if ( sMethod == "List" )
                {
                    return UM_List( nWhat );
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
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalNumber UM_Ok(SalNumber nWhat)
        {
            #region Local Variables
            SalNumber nRow = 0;
            SalString sMessage = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        var requiredFields = RequiredFieldsNotEntered( this );
                        return requiredFields.Count == 0;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        TransferValues();
                        return Sal.EndDialog(this, Sys.IDOK);
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// Returns TRUE if there are any rows in tblFindPerson
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean MatchesFound()
        {
            #region Local Variables
            SalNumber nRow = 0;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                nRow = -1;
                //Sal.TblFindNextRow(tblFindPerson, ref nRow, 0, 0);
                return nRow > -1;
            }
            #endregion
        }
		
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber TransferValues()
        {
            #region Actions
            using (new SalContext(this))
            {
                sPersonId = dfsPersonId.Text;
                sAddressId = dfsAddressId.Text;
                sName = dfsName.Text;
				sRole = cbRole.Text;
                sPhone = dfsPhone.Text;
                sFax = dfsFax.Text;
                sMobile = dfsMobile.Text;
                sEmail = dfsEmail.Text;
                sTitle = dfsTitle.Text;                
                sInitials = dfsInitials.Text;
                sWww = dfsWww.Text;
                sMessenger = dfsMessenger.Text;
                sIntercom = dfsIntercom.Text;
                sPager = dfsPager.Text;
                bCopyAddress = cbCopyAddress.Checked;
                if (Ifs.Fnd.ApplicationForms.Var.Component.IsWindowAvailable(Pal.GetActiveInstanceName("frmCustomerInfoContact")) && Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("frmCustomerInfoContact")))
                {
                    TransferCrmValues();
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber TransferCrmValues()
        {
            #region Actions
            using (new SalContext(this))
            {
                sPersonalInterest = cbPersonalInterest.Text;
                sCampaignInterest = cbCampaignInterest.Text;
                sDecisionPowerType = cbDecisionPowerType.Text;
                sDepartment = cbDepartment.Text;
                sManager = dfsManager.Text;
                sManagerCustAddress = dfsManagerCustAddress.Text;
                sManagerGuid = dfsManagerGuid.Text;
                bBlockForUse = cbBlockForUseInCrm.Checked;
            }
            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalNumber UM_List(SalNumber nWhat)
        {
            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        return Sal.SendMsg(hWndLastFieldActive, Ifs.Fnd.ApplicationForms.Const.PM_DataItemLov, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0);

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        return Sal.SendMsg(hWndLastFieldActive, Ifs.Fnd.ApplicationForms.Const.PM_DataItemLov, nWhat, 0);
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber SetWindowTitle()
        {
            #region Actions
            using (new SalContext(this))
            {
                Sal.SetWindowText(i_hWndFrame, Properties.Resources.WH_dlgAddCustContact);
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalNumber UM_Find(SalNumber nWhat)
        {
            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        return true;
                        //return dfsName.Text != Sys.STRING_Null;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        UM_Find_Execute();
                        break;
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalNumber UM_Cancel(SalNumber nWhat)
        {
            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        return true;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        Sal.EndDialog(this, Sys.IDCANCEL);
                        break;
                }
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// cbPersonalInterest, cbCampaignInterest, cbDecisionPowerType, cbDepartment, dfsManager, dfsManagerNamem 
        /// dfsManagerCustAddress and cbBlockForUseInCrm fields are enabled only when CRM is installed.        
        /// </summary>
        protected virtual void HandleCrmColumns()
        {
            #region Actions
            if (!(Ifs.Fnd.ApplicationForms.Var.Component.IsWindowAvailable(Pal.GetActiveInstanceName("frmCustomerInfoContact")) && Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("frmCustomerInfoContact"))))
            {
                gbCrmSpecificInfo.DisableWindow();
            }
            else
            {
                gbCrmSpecificInfo.EnableWindow();
                if (sOwner == Pal.GetActiveInstanceName("tbwObjectContact"))
                {
                    cbBlockForUseInCrm.DisableWindow();
                }
            } 
            #endregion            
        }

        /// <summary>
        /// AnalyzeName.
        /// </summary>
        /// This method takes the contact person name value as input parameter and
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
        #endregion

        #region Window Actions

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void dlgAddContact_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_Create:
                    this.dlgAddContact_OnSAM_Create(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_Create event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dlgAddContact_OnSAM_Create(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam))
            {
                Sal.CenterWindow(this);
                Sal.SetFocus(this.dfsName);
                this.SetWindowTitle();
                if (!string.IsNullOrEmpty(this.sCustomerId))
                {
                    this.bUseCustomerAddress = true;
                }
                if (!string.IsNullOrEmpty(this.sAddressId))
                {
                    this.dfsAddressId.Text = this.sAddressId;
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
        private void dfsName_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_AnyEdit:
                    this.dfsName_OnSAM_AnyEdit(sender, e);
                    break;

                case Sys.SAM_SetFocus:
                    this.dfsName_OnSAM_SetFocus(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.dfsName_OnPM_DataItemValidate(sender, e);
                    break;                
            }
            #endregion
        }

        /// <summary>
        /// SAM_AnyEdit event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsName_OnSAM_AnyEdit(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.pbOk.MethodInvestigateState();
            this.pbList.MethodInvestigateState();
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsName_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
            this.hWndLastFieldActive = this.dfsName.i_hWndSelf;
            this.pbList.MethodInvestigateState();
            #endregion
        }

        private void dfsName_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            // If edit button is clicked then no need to execute validate.
            if (cCommandButtonEdit.Focused)
            {
                e.Return = Sys.VALIDATE_Ok;
                return;
            }
            AnalyzeName( dfsName.Text );

            //Full name having only one name value
            if ( sFirstName != Ifs.Fnd.ApplicationForms.Const.strNULL && sMiddleName == Ifs.Fnd.ApplicationForms.Const.strNULL && sLastName == Ifs.Fnd.ApplicationForms.Const.strNULL )
            {
                Edit_Execute();
            }
            e.Handled = true;
            e.Return = Sys.VALIDATE_Ok;
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void dfsPhone_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.dfsPhone_OnSAM_SetFocus(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsPhone_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
            this.hWndLastFieldActive = this.dfsPhone.i_hWndSelf;
            this.pbList.MethodInvestigateState();
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void dfsMobile_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.dfsMobile_OnSAM_SetFocus(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsMobile_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
            this.hWndLastFieldActive = this.dfsMobile.i_hWndSelf;
            this.pbList.MethodInvestigateState();
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void dfsEmail_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.dfsEmail_OnSAM_SetFocus(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsEmail_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
            this.hWndLastFieldActive = this.dfsEmail.i_hWndSelf;
            this.pbList.MethodInvestigateState();
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void dfsFax_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.dfsFax_OnSAM_SetFocus(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsFax_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
            this.hWndLastFieldActive = this.dfsFax.i_hWndSelf;
            this.pbList.MethodInvestigateState();
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void dfsWww_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.dfsWww_OnSAM_SetFocus(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsWww_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
            this.hWndLastFieldActive = this.dfsWww.i_hWndSelf;
            this.pbList.MethodInvestigateState();
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void dfsMessenger_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.dfsMessenger_OnSAM_SetFocus(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsMessenger_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
            this.hWndLastFieldActive = this.dfsMessenger.i_hWndSelf;
            this.pbList.MethodInvestigateState();
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void dfsPager_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.dfsPager_OnSAM_SetFocus(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsPager_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
            this.hWndLastFieldActive = this.dfsPager.i_hWndSelf;
            this.pbList.MethodInvestigateState();
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void dfsIntercom_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.dfsIntercom_OnSAM_SetFocus(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsIntercom_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
            this.hWndLastFieldActive = this.dfsIntercom.i_hWndSelf;
            this.pbList.MethodInvestigateState();
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void cbCopyAddress_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_Click:
                    this.cbCopyAddress_OnSAM_Click(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_Click event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cbCopyAddress_OnSAM_Click(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.dfsAddressId.Text == Sys.STRING_Null)
            {
                this.cbCopyAddress.Checked = false;
            }
            #endregion
        }

        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void dfsAddressId_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    e.Handled = true;
                    e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldEnabled;
                    return;

                case Sys.SAM_SetFocus:
                    this.dfsAddressId_OnSAM_SetFocus(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovUserWhere:
                    this.dfsAddressId_OnPM_DataItemLovUserWhere(sender, e);
                    break;

                case Sys.SAM_AnyEdit:
                    this.dfsAddressId_OnSAM_AnyEdit(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsAddressId_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
            this.hWndLastFieldActive = this.dfsAddressId.i_hWndSelf;
            if (this.bUseCustomerAddress)
            {
                this.dfsAddressId.p_sLovReference = "CUSTOMER_INFO_ADDRESS(CUSTOMER_ID)";
            }
            this.pbList.MethodInvestigateState();
            #endregion
        }

        /// <summary>
        /// PM_DataItemLovUserWhere event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsAddressId_OnPM_DataItemLovUserWhere(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.bUseCustomerAddress)
            {
                e.Return = ("CUSTOMER_ID = '" + this.sCustomerId + "'").ToHandle();
                return;
            }
            #endregion
        }

        /// <summary>
        /// SAM_AnyEdit event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsAddressId_OnSAM_AnyEdit(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (this.dfsAddressId.Text == Sys.STRING_Null)
            {
                this.cbCopyAddress.Checked = false;
            }
            #endregion
        }

        private void cbPersonalInterest_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.cbPersonalInterest_OnSAM_SetFocus(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cbPersonalInterest_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
            this.hWndLastFieldActive = this.cbPersonalInterest.i_hWndSelf;
            this.pbList.MethodInvestigateState();
            #endregion
        }

        private void cbCampaignInterest_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.cbCampaignInterest_OnSAM_SetFocus(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cbCampaignInterest_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
            this.hWndLastFieldActive = this.cbCampaignInterest.i_hWndSelf;
            this.pbList.MethodInvestigateState();
            #endregion
        }

        private void cbDecisionPowerType_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.cbDecisionPowerType_OnSAM_SetFocus(sender, e);
                    break;
            }
            #endregion
        }

        // <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cbDecisionPowerType_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
            this.hWndLastFieldActive = this.cbDecisionPowerType.i_hWndSelf;
            this.pbList.MethodInvestigateState();
            #endregion
        }

        private void cbDepartment_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.cbDepartment_OnSAM_SetFocus(sender, e);
                    break;
            }
            #endregion
        }

        // <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void cbDepartment_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
            this.hWndLastFieldActive = this.cbDepartment.i_hWndSelf;
            this.pbList.MethodInvestigateState();
            #endregion
        }


        private void dfsManager_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.dfsManager_OnSAM_SetFocus(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovUserWhere:
                    this.dfsManager_OnPM_DataItemLovUserWhere(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovDone:
                    e.Handled = true;
                    bManagerLovDone = true;
                    dfsManagerName.Text = Vis.StrSubstitute(Ifs.Fnd.ApplicationForms.Int.PalAttrGet("CONTACT_NAME", SalString.FromHandle(Sys.lParam)), ((SalNumber)31).ToCharacter(), "");
                    dfsManagerCustAddress.Text = Vis.StrSubstitute(Ifs.Fnd.ApplicationForms.Int.PalAttrGet("CUSTOMER_ADDRESS", SalString.FromHandle(Sys.lParam)), ((SalNumber)31).ToCharacter(), "");
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.dfsManager_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsManager_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
            this.hWndLastFieldActive = this.dfsManager.i_hWndSelf;
            this.pbList.MethodInvestigateState();
            #endregion
        }

        /// <summary>
        /// PM_DataItemLovUserWhere event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsManager_OnPM_DataItemLovUserWhere(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            e.Return = ("CUSTOMER_ID = '" + this.sCustomerId + "'").ToHandle();
            return;
            #endregion
        }

        private void dfsManager_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;

            if (bManagerLovDone)
            {
                bManagerLovDone = false;
                lsStmt = @"BEGIN 
                                  :i_hWndFrame.dlgAddContact.dfsManagerGuid :=  &AO.Customer_Info_Contact_API.Get_Guid_By_Cust_Address(:i_hWndFrame.dlgAddContact.sCustomerId IN, :i_hWndFrame.dlgAddContact.dfsManager IN, :i_hWndFrame.dlgAddContact.dfsManagerCustAddress IN);
                           END;";
                if (DbPLSQLBlock(cSessionManager.c_hSql, lsStmt))
                {
                    dfsManagerGuid.EditDataItemSetEdited();
                }
            }
            else
            {
                if ( Sys.wParam )
                {
                    nFound = 0;
                    if (dfsManager.Text == Ifs.Fnd.ApplicationForms.Const.strNULL)
                    {
                        dfsManagerGuid.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                        dfsManagerGuid.EditDataItemSetEdited();
                        dfsManagerCustAddress.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                        dfsManagerCustAddress.EditDataItemSetEdited();
                        dfsManagerName.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                        dfsManagerName.EditDataItemSetEdited();
                        e.Return = Sys.VALIDATE_Ok;
                        return;
                    }

                    lsStmt = @"BEGIN 
                                        IF :i_hWndFrame.dlgAddContact.dfsManagerCustAddress IS NULL THEN
                                            &AO.Customer_Info_Contact_API.Validate_Customer_Address(:i_hWndFrame.dlgAddContact.nFound OUT, :i_hWndFrame.dlgAddContact.dfsManagerCustAddress OUT, :i_hWndFrame.dlgAddContact.sCustomerId IN, :i_hWndFrame.dlgAddContact.dfsManager IN); 
                                        END IF;
                                        :i_hWndFrame.dlgAddContact.dfsManagerName :=  &AO.Person_Info_API.Get_Name(:i_hWndFrame.dlgAddContact.dfsManager IN);  
                                        :i_hWndFrame.dlgAddContact.dfsManagerGuid :=  &AO.Customer_Info_Contact_API.Get_Guid_By_Cust_Address(:i_hWndFrame.dlgAddContact.sCustomerId IN, :i_hWndFrame.dlgAddContact.dfsManager IN, :i_hWndFrame.dlgAddContact.dfsManagerCustAddress IN);
                               END;";
                    if (DbPLSQLBlock(cSessionManager.c_hSql, lsStmt))
                    {
                        if (nFound > 1)
                        {
                            Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_ManyContactAddress, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Information, Ifs.Fnd.ApplicationForms.Const.INFO_Ok);
                            e.Return = Sys.VALIDATE_Cancel;
                            return;
                        }
                        else
                        {
                            dfsManagerGuid.EditDataItemSetEdited();
                            dfsManagerCustAddress.EditDataItemSetEdited();
                        }
                    }
                }
            }
            e.Return = Sys.VALIDATE_Ok;
            return;

            #endregion
        }



        private void dfsManagerCustAddress_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_SetFocus:
                    this.dfsManagerCustAddress_OnSAM_SetFocus(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovUserWhere:
                    this.dfsManagerCustAddress_OnPM_DataItemLovUserWhere(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovDone:
                    e.Handled = true;
                    dfsManagerCustAddress.Text = Vis.StrSubstitute(Ifs.Fnd.ApplicationForms.Int.PalAttrGet("CUSTOMER_ADDRESS", SalString.FromHandle(Sys.lParam)), ((SalNumber)31).ToCharacter(), "");
                    break;

            }
            #endregion
        }

        /// <summary>
        /// SAM_SetFocus event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dfsManagerCustAddress_OnSAM_SetFocus(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Sys.SAM_SetFocus, Sys.wParam, Sys.lParam);
            this.hWndLastFieldActive = this.dfsManagerCustAddress.i_hWndSelf;
            this.pbList.MethodInvestigateState();
            #endregion
        }

        private void dfsManagerCustAddress_OnPM_DataItemLovUserWhere(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (dfsManager.Text != SalString.Null)
            {
                e.Return = ((SalString)"CUSTOMER_ID='" + sCustomerId + "' AND PERSON_ID= '" + dfsManager.Text + "'").ToHandle();
                return;
            }
            else
            {
                e.Return = ("CUSTOMER_ID = '" + this.sCustomerId + "'").ToHandle();
                return;
            }

            e.Return = true;
            return;
            #endregion
        }

        private void cbRole_WindowActions( object sender, WindowActionsEventArgs e )
        {
            switch ( e.ActionType )
            {
                case Sys.SAM_SetFocus:
                    this.cbRole_OnSAM_SetFocus( sender, e );
                    break;
            }
        }

        private void cbRole_OnSAM_SetFocus( object sender, WindowActionsEventArgs e )
        {
            e.Handled = true;
            Sal.SendClassMessage( Sys.SAM_SetFocus, Sys.wParam, Sys.lParam );
            this.hWndLastFieldActive = this.cbRole.i_hWndSelf;
            this.pbList.MethodInvestigateState();
        }

        private void dfsTitle_WindowActions( object sender, WindowActionsEventArgs e )
        {
            switch ( e.ActionType )
            {
                case Sys.SAM_SetFocus:
                    this.dfsTitle_OnSAM_SetFocus( sender, e );
                    break;
            }
        }

        private void dfsTitle_OnSAM_SetFocus( object sender, WindowActionsEventArgs e )
        {
            e.Handled = true;
            Sal.SendClassMessage( Sys.SAM_SetFocus, Sys.wParam, Sys.lParam );
            this.hWndLastFieldActive = this.dfsTitle.i_hWndSelf;
            this.pbList.MethodInvestigateState();
        }

        private void cbBlockForUseInCrm_WindowActions( object sender, WindowActionsEventArgs e )
        {
            switch ( e.ActionType )
            {
                case Sys.SAM_SetFocus:
                    this.bBlockForUseInCrm_OnSAM_SetFocus( sender, e );
                    break;
            }
        }

        private void bBlockForUseInCrm_OnSAM_SetFocus( object sender, WindowActionsEventArgs e )
        {
            e.Handled = true;
            Sal.SendClassMessage( Sys.SAM_SetFocus, Sys.wParam, Sys.lParam );
            this.hWndLastFieldActive = this.cbBlockForUseInCrm.i_hWndSelf;
            this.pbList.MethodInvestigateState();
        }

        #endregion

        #region Event Handlers

        private void commandEdit_Execute(object sender, Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            Edit_Execute();
            e.Handled = true;
        }

        protected virtual void Edit_Execute()
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
            SalString sTitle = "";
            SalString sInitials = "";
            #endregion

            #region Action
            vrtDataSourcePrepareKeyTransfer( Pal.GetActiveInstanceName( "dlgPersonFullName" ) );

            sCurrTitle = dfsTitle.Text;
            sCurrInitials = dfsInitials.Text;
            sCurrName = dfsName.Text;
            sFullName = Ifs.Fnd.ApplicationForms.Const.strNULL;

            sCurrFirstName = ( sFirstName != Ifs.Fnd.ApplicationForms.Const.strNULL ) ? sFirstName.ToString() : Ifs.Fnd.ApplicationForms.Const.strNULL;
            sCurrMiddleName = ( sMiddleName != Ifs.Fnd.ApplicationForms.Const.strNULL ) ? sMiddleName.ToString() : Ifs.Fnd.ApplicationForms.Const.strNULL;
            sCurrLastName = ( sFirstName != Ifs.Fnd.ApplicationForms.Const.strNULL ) ? sLastName.ToString() : Ifs.Fnd.ApplicationForms.Const.strNULL;

            if ( dfsName.Text != ConstructName( sFirstName, sMiddleName, sLastName ) )
            {
                AnalyzeName( dfsName.Text );
            }

            Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemAdd( "TITLE", new SalArray<SalString>() { dfsTitle } );
            Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemAdd( "INITIALS", new SalArray<SalString>() { dfsInitials } );
            Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemAdd( "FIRST_NAME", new SalArray<SalString>() { sFirstName } );
            Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemAdd( "MIDDLE_NAME", new SalArray<SalString>() { sMiddleName } );
            Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemAdd( "LAST_NAME", new SalArray<SalString>() { sLastName } );

            if ( Sys.IDOK == dlgPersonFullName.ModalDialog( Sys.hWndMDI ) )
            {
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet( "TITLE", items );
                sTitle = items[0];

                Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet( "INITIALS", items );
                sInitials = items[0];

                // Assigning values to fields only if they have changed
                if ( !( SalString.Equals( sCurrTitle, sTitle ) ) )
                {
                    dfsTitle.Text = sTitle;
                }
                if ( !( SalString.Equals( sCurrInitials, sInitials ) ) )
                {
                    dfsInitials.Text = sInitials;
                }

                Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet( "FIRST_NAME", items );
                // If user has changed the first name in the dialog new value need to be updated.
                if ( !( SalString.Equals( sCurrFirstName, items[0] ) ) )
                {
                    sFirstName = items[0];
                    bFirstNameChanged = true;
                }

                Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet( "MIDDLE_NAME", items );
                // If user has changed the middle name in the dialog new value need to be updated.  
                if ( !( SalString.Equals( sCurrMiddleName, items[0] ) ) )
                {
                    sMiddleName = items[0];
                    bMiddleNameChanged = true;
                }

                Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet( "LAST_NAME", items );
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
                // If user has changed the last name in the dialog new value need to be updated.  
                if ( !( SalString.Equals( sCurrLastName, items[0] ) ) )
                {
                    sLastName = items[0];
                    bLastNameChanged = true;
                }

                // Concatenating First Name, Middle Name and the Last Name to take as the person full name.
                sFullName = ConstructName( sFirstName, sMiddleName, sLastName );

                if ( ( bFirstNameChanged || bMiddleNameChanged || bLastNameChanged ) || ( sFullName != sCurrName ) )
                {
                    dfsName.EditDataItemValueSet( 0, sFullName.ToHandle() );
                    dfsName.Text = sFullName;
                    dfsName.EditDataItemSetEdited();
                }
            }

            #endregion
        }

        protected virtual void UM_Find_Execute()
        {
            SalString sStartedFromCustomer = this.bUseCustomerAddress ? "TRUE" : "FALSE";
            Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
            vrtDataSourcePrepareKeyTransfer( Pal.GetActiveInstanceName( "dlgFindPerson" ) );
            Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemAdd( "STARTED_FROM_CUSTOMER", new SalArray<SalString>() { sStartedFromCustomer } );
			Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemAdd("STARTED_FROM_SUPPLIER", new SalArray<SalString>() { "FALSE" });
            Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemAdd( "FIRST_NAME", new SalArray<SalString>() { sFirstName } );
            Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemAdd( "MIDDLE_NAME", new SalArray<SalString>() { sMiddleName } );
            Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemAdd( "LAST_NAME", new SalArray<SalString>() { sLastName } );

            if ( Sys.IDOK != dlgFindPerson.ModalDialog( Sys.hWndMDI ) )
            {
                return;
            }
            Find_Execute();
        }

        protected virtual void Find_Execute()
        {
            SalArray<SalString> items = new SalArray<SalString>();
            Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet( "PERSON_ID", items );
            sPersonId = items[0];
            dfsPersonId.Text = sPersonId;
            Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();

            lsStmt = @"BEGIN 
                            :i_hWndFrame.dlgAddContact.dfsName      :=  &AO.Person_Info_API.Get_Name(:i_hWndFrame.dlgAddContact.dfsPersonId IN);  
                            :i_hWndFrame.dlgAddContact.dfsTitle     :=  &AO.Person_Info_API.Get_Title(:i_hWndFrame.dlgAddContact.dfsPersonId IN);  

                            :i_hWndFrame.dlgAddContact.dfsPhone     :=  &AO.Comm_Method_API.Get_Default_Value('PERSON', :i_hWndFrame.dlgAddContact.dfsPersonId IN, 'PHONE');  
                            :i_hWndFrame.dlgAddContact.dfsMobile    :=  &AO.Comm_Method_API.Get_Default_Value('PERSON', :i_hWndFrame.dlgAddContact.dfsPersonId IN, 'MOBILE');  
                            :i_hWndFrame.dlgAddContact.dfsEmail     :=  &AO.Comm_Method_API.Get_Default_Value('PERSON', :i_hWndFrame.dlgAddContact.dfsPersonId IN, 'E_MAIL');  
                            :i_hWndFrame.dlgAddContact.dfsFax       :=  &AO.Comm_Method_API.Get_Default_Value('PERSON', :i_hWndFrame.dlgAddContact.dfsPersonId IN, 'FAX');  
                            :i_hWndFrame.dlgAddContact.dfsPager     :=  &AO.Comm_Method_API.Get_Default_Value('PERSON', :i_hWndFrame.dlgAddContact.dfsPersonId IN, 'PAGER');  
                            :i_hWndFrame.dlgAddContact.dfsIntercom  :=  &AO.Comm_Method_API.Get_Default_Value('PERSON', :i_hWndFrame.dlgAddContact.dfsPersonId IN, 'INTERCOM');  
                            :i_hWndFrame.dlgAddContact.dfsWww       :=  &AO.Comm_Method_API.Get_Default_Value('PERSON', :i_hWndFrame.dlgAddContact.dfsPersonId IN, 'WWW');  
                            :i_hWndFrame.dlgAddContact.dfsMessenger :=  &AO.Comm_Method_API.Get_Default_Value('PERSON', :i_hWndFrame.dlgAddContact.dfsPersonId IN, 'MESSENGER');  
                       END;";
            DbPLSQLBlock( cSessionManager.c_hSql, lsStmt );
            AnalyzeName( dfsName.Text );
            dfsName.EditDataItemSetEdited();
            Sal.SetFocus( cbRole );

            EnableDisableContactInfo( false );
        }

        private void commandReset_Execute( object sender, Fnd.Windows.Forms.FndCommandExecuteEventArgs e )
        {
            var controls = GetControls( this );
            foreach ( Control con in controls )
            {
                if ( con is cDataField )
                    con.ResetText();
                else if ( con is cComboBox )
                    con.ResetText();
                else if ( con is cComboBoxMultiSelection )
                    con.ResetText();
            }
            cbCopyAddress.Checked = false;
            cbBlockForUseInCrm.Checked = false;
            EnableDisableContactInfo( true );
            sFirstName = Ifs.Fnd.ApplicationForms.Const.strNULL;
            sMiddleName = Ifs.Fnd.ApplicationForms.Const.strNULL;
            sLastName = Ifs.Fnd.ApplicationForms.Const.strNULL;
            this.pbOk.Enabled = false;
        }
        #endregion

        #region Late Bind Methods

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalNumber vrtUserMethod(SalNumber nWhat, SalString sMethod)
        {
            return this.UserMethod(nWhat, sMethod);
        }

        public override SalBoolean vrtFrameStartupUser()
        {
            #region Actions
            this.HandleCrmColumns();
            return base.vrtFrameStartupUser();
            #endregion
        }
        #endregion

        private IEnumerable<Control> GetControls( Control parent )
        {
            List<Control> controls = new List<Control>();
            foreach ( Control child in parent.Controls )
            {
                controls.AddRange( GetControls( child ) );
            }
            controls.Add( parent );
            return controls;
        }

        private SalArray<SalString> RequiredFieldsNotEntered( Control parent )
        {
            SalArray<SalString> requiredFields = new SalArray<SalString>();
            var controls = GetControls( this );
            foreach ( Control con in controls )
            {
                if ( con is cDataField && ( (cDataField)con ).EditDataItemRequired() && con.Text == "" )
                    requiredFields.Add( con.Name );
                else if ( con is cComboBox && ( (cComboBox)con ).EditDataItemRequired() && con.Text == "" )
                    requiredFields.Add( con.Name );
                else if ( con is cComboBoxMultiSelection && ( (cComboBoxMultiSelection)con ).EditDataItemRequired() && con.Text == "" )
                    requiredFields.Add( con.Name );
            }
            return requiredFields;
        }

        protected virtual void EnableDisableContactInfo( bool fEnable )
        {
            bCreatePerson = fEnable;
            cCommandButtonEdit.Enabled = fEnable;
            dfsPersonId.Enabled = fEnable;
            dfsName.Enabled = fEnable;
            dfsTitle.Enabled = fEnable;
            dfsPhone.Enabled = fEnable;
            dfsMobile.Enabled = fEnable;
            dfsEmail.Enabled = fEnable;
            dfsFax.Enabled = fEnable;
            dfsPager.Enabled = fEnable;
            dfsIntercom.Enabled = fEnable;
            dfsWww.Enabled = fEnable;
            dfsMessenger.Enabled = fEnable;
        }

        private void dfsPersonId_WindowActions( object sender, WindowActionsEventArgs e )
        {
            switch ( e.ActionType )
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.dfsPersonId_OnPM_DataItemValidate( sender, e );
                    break;
            }
        }

        private void dfsPersonId_OnPM_DataItemValidate( object sender, WindowActionsEventArgs e )
        {
            e.Handled = true;
            lsStmt = @"BEGIN
                          :i_hWndFrame.dlgAddContact.nFound := 0;
                          IF &AO.Person_Info_API.Exists(:i_hWndFrame.dlgAddContact.dfsPersonId.Text IN) THEN
                             :i_hWndFrame.dlgAddContact.nFound := 1;
                          END IF;
                       END;";
            DbPLSQLBlock( cSessionManager.c_hSql, lsStmt );
            if ( nFound == 1 )
            {
                sPersonId = dfsPersonId.Text;
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.SourceNameSet( Pal.GetActiveInstanceName( "dlgAddContact" ) );
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemAdd( "PERSON_ID", new SalArray<SalString>() { sPersonId } );
                Find_Execute();
            }
            else
            {
                dfsPersonId.EditDataItemSetEdited();
            }
            e.Return = Sys.VALIDATE_Ok;
        }

    }
}
