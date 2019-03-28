#region Copyright (c) IFS Research & Development
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
#endregion
#region History
/// Date    By      Notes
/// -----   ------  ---------------------------------------------------------
/// 170829  Chwilk  STRFI-9606, Bug 137301, Modified dfsName_OnSAM_AnyEdit() and commandOk_Execute()  in order to fix the Person's Name is Parsed Incorrectly.
/// 150820  RoJalk  AFT-2185, Modified commandOk_Execute added code to fetch the value of generated person id.
/// 150828  SudJlk  AFT-1698, Modified dfsName_OnSAM_AnyEdit to handle CommandOk Inquire event.
/// 150825  Hairlk  AFT-1691, Added STARTED_FROM_SUPPLIER to data transfer when calling dlgFindPerson in order to identify whether the call is made in customer_contact
///                context or supplier_contact context
/// 150820  RoJalk  ORA-1216, Modified commandOk_Execute to add the department to attr.
/// 150818  SudJlk  ORA-1221, Removed parameter SrmInstalled. Used Ifs.Application.Enterp.Int.IsSrmInstalled to check if SRM is installed.
/// 150804  RoJalk  ORA-1094, Added code to methods commandOk_Execute, EditExecute, ConstructName.  
/// 150730  SudJlk  ORA-1094, Added logic for command buttons Cancel and Reset. Added dfsAddressId_WindowActions.
/// 150730  SudJlk  ORA-1107, Overriden vrtFrameStartupUser and added window parameter sSrmInstalled and HandleSrmColumns() to enable cbDepartment only if SRM is installed.
/// 150729  SudJlk  Created.
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Ifs.Fnd.ApplicationForms;
using PPJ.Runtime;
using PPJ.Runtime.Windows;
using Ifs.Fnd.Windows.Forms;

namespace Ifs.Application.Enterp
{

    /// <summary>
    /// </summary>
    /// <param name="sSupplierId"></param>
    public partial class dlgAddSupplierContact : cDialog
    {

        #region Window Parameters
        public SalString sContact;
        public SalString sAddressId;
        public SalString sSupplierId;
        #endregion

        #region Member Variables
        protected SalBoolean bCreatePerson = false;
        protected SalString sFullName = Ifs.Fnd.ApplicationForms.Const.strNULL;
        protected SalString sFirstName = Ifs.Fnd.ApplicationForms.Const.strNULL;
        protected SalString sMiddleName = Ifs.Fnd.ApplicationForms.Const.strNULL;
        protected SalString sLastName = Ifs.Fnd.ApplicationForms.Const.strNULL;
        public SalWindowHandle hWndLastFieldActive = SalWindowHandle.Null;
        protected SalString lsStmt = "";
        public SalString lsAttr = "";
        protected SalWindowHandle hWndFocus;
        protected SalNumber nFound = 0;
        protected SalString sPersonId = Ifs.Fnd.ApplicationForms.Const.strNULL;
        #endregion
        
        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        protected dlgAddSupplierContact()
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
        public static SalNumber ModalDialog(Control owner, ref SalString sContact, ref SalString sAddressId, SalString sSupplierId)
        {
            dlgAddSupplierContact dlg = DialogFactory.CreateInstance<dlgAddSupplierContact>();
            dlg.sContact = sContact;
            dlg.sAddressId = sAddressId;
            dlg.sSupplierId = sSupplierId;
            SalNumber ret = dlg.ShowDialog(owner);
            sContact = dlg.sContact;
            sAddressId = dlg.sAddressId;
            return ret;
        }

        /// <summary>
        /// Returns the object instance associated with the window handle.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public new static dlgAddSupplierContact FromHandle(SalWindowHandle handle)
        {
            return ((dlgAddSupplierContact)SalWindow.FromHandle(handle, typeof(dlgAddSupplierContact)));
        }

        #endregion

        #region Properties

        #endregion

        #region Methods

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalNumber SetWindowTitle()
        {
            #region Actions
            using (new SalContext(this))
            {
                Sal.SetWindowText(i_hWndFrame, Properties.Resources.WH_dlgAddSuppContact);
            }

            return 0;
            #endregion
        }

        /// <summary>
        /// cbDepartment is enabled only when SRM is installed.        
        /// </summary>
        protected virtual void HandleSrmColumns()
        {
            #region Actions
            if (!(Ifs.Application.Enterp.Int.IsSrmInstalled))
            {
                cbDepartment.DisableWindowAndLabel();
            }
            #endregion
        }

        protected virtual void EditExecute()
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
            vrtDataSourcePrepareKeyTransfer(Pal.GetActiveInstanceName("dlgPersonFullName"));

            sCurrTitle = dfsTitle.Text;
            sCurrInitials = dfsInitials.Text;
            sCurrName = dfsName.Text;
            sFullName = Ifs.Fnd.ApplicationForms.Const.strNULL;

            sCurrFirstName = (sFirstName != Ifs.Fnd.ApplicationForms.Const.strNULL) ? sFirstName.ToString() : Ifs.Fnd.ApplicationForms.Const.strNULL;
            sCurrMiddleName = (sMiddleName != Ifs.Fnd.ApplicationForms.Const.strNULL) ? sMiddleName.ToString() : Ifs.Fnd.ApplicationForms.Const.strNULL;
            sCurrLastName = (sFirstName != Ifs.Fnd.ApplicationForms.Const.strNULL) ? sLastName.ToString() : Ifs.Fnd.ApplicationForms.Const.strNULL;

            if (dfsName.Text != ConstructName(sFirstName, sMiddleName, sLastName))
            {
                AnalyzeName(dfsName.Text);
            }

            Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemAdd("TITLE", new SalArray<SalString>() { dfsTitle });
            Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemAdd("INITIALS", new SalArray<SalString>() { dfsInitials });
            Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemAdd("FIRST_NAME", new SalArray<SalString>() { sFirstName });
            Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemAdd("MIDDLE_NAME", new SalArray<SalString>() { sMiddleName });
            Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemAdd("LAST_NAME", new SalArray<SalString>() { sLastName });

            if (Sys.IDOK == dlgPersonFullName.ModalDialog(Sys.hWndMDI))
            {
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("TITLE", items);
                sTitle = items[0];

                Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("INITIALS", items);
                sInitials = items[0];

                // Assigning values to fields only if they have changed
                if (!(SalString.Equals(sCurrTitle, sTitle)))
                {
                    dfsTitle.Text = sTitle;
                }
                if (!(SalString.Equals(sCurrInitials, sInitials)))
                {
                    dfsInitials.Text = sInitials;
                }

                Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("FIRST_NAME", items);
                // If user has changed the first name in the dialog new value need to be updated.
                if (!(SalString.Equals(sCurrFirstName, items[0])))
                {
                    sFirstName = items[0];
                    bFirstNameChanged = true;
                }

                Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("MIDDLE_NAME", items);
                // If user has changed the middle name in the dialog new value need to be updated.  
                if (!(SalString.Equals(sCurrMiddleName, items[0])))
                {
                    sMiddleName = items[0];
                    bMiddleNameChanged = true;
                }

                Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("LAST_NAME", items);
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
                // If user has changed the last name in the dialog new value need to be updated.  
                if (!(SalString.Equals(sCurrLastName, items[0])))
                {
                    sLastName = items[0];
                    bLastNameChanged = true;
                }

                // Concatenating First Name, Middle Name and the Last Name to take as the person full name.
                sFullName = ConstructName(sFirstName, sMiddleName, sLastName);

                if ((bFirstNameChanged || bMiddleNameChanged || bLastNameChanged) || (sFullName != sCurrName))
                {
                    dfsName.EditDataItemValueSet(0, sFullName.ToHandle());
                    dfsName.Text = sFullName;
                    dfsName.EditDataItemSetEdited();
                }
            }

            #endregion
        }

        protected virtual void Find_Execute()
        {
            SalArray<SalString> items = new SalArray<SalString>();

            #region Actions
            Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("PERSON_ID", items);
            sPersonId = items[0];
            dfsPersonId.Text = sPersonId;
            Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
            
            lsStmt = @"BEGIN 
                            :i_hWndFrame.dlgAddSupplierContact.dfsName      :=  &AO.Person_Info_API.Get_Name(:i_hWndFrame.dlgAddSupplierContact.dfsPersonId IN);  
                            :i_hWndFrame.dlgAddSupplierContact.dfsTitle     :=  &AO.Person_Info_API.Get_Title(:i_hWndFrame.dlgAddSupplierContact.dfsPersonId IN);  

                            :i_hWndFrame.dlgAddSupplierContact.dfsPhone     :=  &AO.Comm_Method_API.Get_Default_Value('PERSON', :i_hWndFrame.dlgAddSupplierContact.dfsPersonId IN, 'PHONE');  
                            :i_hWndFrame.dlgAddSupplierContact.dfsMobile    :=  &AO.Comm_Method_API.Get_Default_Value('PERSON', :i_hWndFrame.dlgAddSupplierContact.dfsPersonId IN, 'MOBILE');  
                            :i_hWndFrame.dlgAddSupplierContact.dfsEmail     :=  &AO.Comm_Method_API.Get_Default_Value('PERSON', :i_hWndFrame.dlgAddSupplierContact.dfsPersonId IN, 'E_MAIL');  
                            :i_hWndFrame.dlgAddSupplierContact.dfsFax       :=  &AO.Comm_Method_API.Get_Default_Value('PERSON', :i_hWndFrame.dlgAddSupplierContact.dfsPersonId IN, 'FAX');  
                            :i_hWndFrame.dlgAddSupplierContact.dfsPager     :=  &AO.Comm_Method_API.Get_Default_Value('PERSON', :i_hWndFrame.dlgAddSupplierContact.dfsPersonId IN, 'PAGER');  
                            :i_hWndFrame.dlgAddSupplierContact.dfsIntercom  :=  &AO.Comm_Method_API.Get_Default_Value('PERSON', :i_hWndFrame.dlgAddSupplierContact.dfsPersonId IN, 'INTERCOM');  
                            :i_hWndFrame.dlgAddSupplierContact.dfsWww       :=  &AO.Comm_Method_API.Get_Default_Value('PERSON', :i_hWndFrame.dlgAddSupplierContact.dfsPersonId IN, 'WWW');  
                            :i_hWndFrame.dlgAddSupplierContact.dfsMessenger :=  &AO.Comm_Method_API.Get_Default_Value('PERSON', :i_hWndFrame.dlgAddSupplierContact.dfsPersonId IN, 'MESSENGER');  
                       END;";
            DbPLSQLBlock(cSessionManager.c_hSql, lsStmt);
            AnalyzeName(dfsName.Text);
            dfsName.EditDataItemSetEdited();
            Sal.SetFocus(cbRole);
            EnableDisableContactInfo(false);
            #endregion
        }

        public virtual void AnalyzeName(SalString sName)
        {
            #region Local Variables
            SalNumber nCurrentNameItemsCount = Sys.NUMBER_Null;
            SalNumber nCounter = 0;
            sFirstName  = Ifs.Fnd.ApplicationForms.Const.strNULL;
            sMiddleName = Ifs.Fnd.ApplicationForms.Const.strNULL;
            sLastName   = Ifs.Fnd.ApplicationForms.Const.strNULL;
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

        protected virtual void EnableDisableContactInfo(bool fEnable)
        {
            #region Actions
            bCreatePerson              = fEnable;
            cCommandButtonEdit.Enabled = fEnable;
            dfsPersonId.Enabled        = fEnable;
            dfsName.Enabled            = fEnable;
            dfsTitle.Enabled           = fEnable;
            dfsPhone.Enabled           = fEnable;
            dfsMobile.Enabled          = fEnable;
            dfsEmail.Enabled           = fEnable;
            dfsFax.Enabled             = fEnable;
            dfsPager.Enabled           = fEnable;
            dfsIntercom.Enabled        = fEnable;
            dfsWww.Enabled             = fEnable;
            dfsMessenger.Enabled       = fEnable;
            #endregion
        }

        public new SalBoolean FrameStartupUser()
        {
            #region Actions
            this.HandleSrmColumns();
            dfsAddressId.Text = sAddressId;
            return base.vrtFrameStartupUser();
            #endregion
        }

        #endregion

        #region Overrides

        public override SalBoolean vrtFrameStartupUser()
        {
            return this.FrameStartupUser();
        }

        
        private IEnumerable<Control> GetControls(Control parent)
        {
            #region Actions
            List<Control> controls = new List<Control>();
            foreach (Control child in parent.Controls)
            {
                controls.AddRange(GetControls(child));
            }
            controls.Add(parent);
            return controls;
            #endregion
        }

        private SalArray<SalString> RequiredFieldsNotEntered(Control parent)
        {
            #region Actions
            SalArray<SalString> requiredFields = new SalArray<SalString>();
            var controls = GetControls(this);
            foreach (Control con in controls)
            {
                if (con is cDataField && ((cDataField)con).EditDataItemRequired() && con.Text == "")
                    requiredFields.Add(con.Name);
                else if (con is cComboBox && ((cComboBox)con).EditDataItemRequired() && con.Text == "")
                    requiredFields.Add(con.Name);
                else if (con is cComboBoxMultiSelection && ((cComboBoxMultiSelection)con).EditDataItemRequired() && con.Text == "")
                    requiredFields.Add(con.Name);
            }
            return requiredFields;
            #endregion
        }

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

        private void dlgAddSupplierContact_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_Create:
                    this.dlgAddSupplierContact_OnSAM_Create(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_Create event handler.
        /// </summary>
        /// <param name="message"></param>
        private void dlgAddSupplierContact_OnSAM_Create(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam))
            {
                Sal.CenterWindow(this);
                Sal.SetFocus(this.dfsName);
                this.SetWindowTitle();
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

       

        private void dfsAddressId_WindowActions(object sender, WindowActionsEventArgs e)
        {
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    e.Handled = true;
                    e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldEnabled;
                    return;

                case Sys.SAM_AnyEdit:
                    this.dfsAddressId_OnSAM_AnyEdit(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovUserWhere:
                    this.dfsAddressId_OnPM_DataItemLovUserWhere(sender, e);
                    break;

               
            }
        }

        private void dfsAddressId_OnPM_DataItemLovUserWhere(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            e.Return = ("SUPPLIER_ID = '" + this.sSupplierId + "'").ToHandle();
            return;
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

        private void dfsPersonId_WindowActions(object sender, WindowActionsEventArgs e)
        {
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.dfsPersonId_OnPM_DataItemValidate(sender, e);
                    break;
            }
        }

        private void dfsPersonId_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            lsStmt = @"BEGIN
                          :i_hWndFrame.dlgAddSupplierContact.nFound := 0;
                          IF &AO.Person_Info_API.Exists(:i_hWndFrame.dlgAddSupplierContact.dfsPersonId.Text IN) THEN
                             :i_hWndFrame.dlgAddSupplierContact.nFound := 1;
                          END IF;
                       END;";
            DbPLSQLBlock(cSessionManager.c_hSql, lsStmt);
            if (nFound == 1)
            {
                sPersonId = dfsPersonId.Text;
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.SourceNameSet(Pal.GetActiveInstanceName("dlgAddSupplierContact"));
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemAdd("PERSON_ID", new SalArray<SalString>() { sPersonId });
                Find_Execute();
            }
            else
            {
                dfsPersonId.EditDataItemSetEdited();
            }
            e.Return = Sys.VALIDATE_Ok;
            #endregion
        }

        private void dfsName_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_AnyEdit:
                    this.dfsName_OnSAM_AnyEdit(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.dfsName_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        private void dfsName_OnSAM_AnyEdit(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            commandOk.OnInquireEventFired(sender, e);
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
            AnalyzeName(dfsName.Text);

            //Full name having only one name value
            if (sFirstName != Ifs.Fnd.ApplicationForms.Const.strNULL && sMiddleName == Ifs.Fnd.ApplicationForms.Const.strNULL && sLastName == Ifs.Fnd.ApplicationForms.Const.strNULL)
            {
                EditExecute();
            }
            e.Handled = true;
            e.Return = Sys.VALIDATE_Ok;
        }

        #endregion

        #region Event Handlers

        private void commandEdit_Inquire(object sender, Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            #region Action
            e.Handled = true;
            #endregion
        }

        private void commandEdit_Execute(object sender, Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            #region Action
            EditExecute();
            e.Handled = true;
            #endregion
        }

        private void commandOk_Inquire(object sender, Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            #region Action
            var requiredFields = RequiredFieldsNotEntered(this);
            ((FndCommand)sender).Enabled = (requiredFields.Count == 0);
            #endregion
        }

        private void commandOk_Execute(object sender, Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            #region Action
            {
                lsAttr = "";
                if (cbCopyAddress.Checked)
                {
                    Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("COPY_ADDRESS", "TRUE", ref lsAttr);
                    Ifs.Fnd.ApplicationForms.Var.Console.Add("COPY_ADDRESS: ");
                }
				Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("ROLE", cbRole.Text, ref lsAttr);
				if (Ifs.Application.Enterp.Int.IsSrmInstalled)
				{
					Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("DEPARTMENT", cbDepartment.Text, ref lsAttr);
				}
                if (sPersonId != SalString.Null && bCreatePerson == false)
                {
                    Ifs.Fnd.ApplicationForms.Var.Console.Add("Adding Person: " + dfsPersonId.Text);
                    Ifs.Fnd.ApplicationForms.Var.Console.Add("sSupplierId: " + sSupplierId);
                    Ifs.Fnd.ApplicationForms.Var.Console.Add("sAddressId: " + dfsAddressId.Text);
                    Ifs.Fnd.ApplicationForms.Var.Console.Add("lsAttr: " + lsAttr);
                                        
                    IDictionary<string, string> namedBindVariables = new Dictionary<string, string>();
                    namedBindVariables.Add("SupplierId", QualifiedVarBindName("sSupplierId"));
                    namedBindVariables.Add("PersonId",   dfsPersonId.QualifiedBindName);
                    namedBindVariables.Add("AddressId",  dfsAddressId.QualifiedBindName);
                    namedBindVariables.Add("Attr",       QualifiedVarBindName("lsAttr"));
                    if (DbPLSQLTransaction(@"&AO.Supplier_Info_Contact_API.New({SupplierId} IN, {PersonId} IN, {AddressId} IN, {Attr} IN );", namedBindVariables))
                    {
                        sContact = dfsPersonId.Text;
                        sAddressId = dfsAddressId.Text;
                    }
                    else
                    {
                        sContact = Ifs.Fnd.ApplicationForms.Const.strNULL;
                        sAddressId = Ifs.Fnd.ApplicationForms.Const.strNULL;
                    }
                }
                else
                {
                    Ifs.Fnd.ApplicationForms.Var.Console.Add("Creating contact: " + dfsName.Text);
                    Ifs.Fnd.ApplicationForms.Var.Console.Add("sAddressId: " + dfsAddressId.Text);
                    Ifs.Fnd.ApplicationForms.Var.Console.Add("sName: " + dfsName.Text);
                    Ifs.Fnd.ApplicationForms.Var.Console.Add("sPhone: " + dfsPhone.Text);
                    Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("SUPPLIER_ID", sSupplierId, ref lsAttr);
                    if (dfsAddressId.Text != SalString.Null)
                    {
                        Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("SUPPLIER_ADDRESS", dfsAddressId.Text, ref lsAttr);
                    }
                    if (dfsPersonId.Text != SalString.Null)
                    {
                        Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("PERSON_ID", dfsPersonId.Text, ref lsAttr);
                    }
                    Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("FIRST_NAME",  sFirstName,        ref lsAttr);
                    Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("MIDDLE_NAME", sMiddleName,       ref lsAttr);
                    Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("LAST_NAME",   sLastName,         ref lsAttr);
                    Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("NAME",        dfsName.Text,      ref lsAttr);
                    Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("PHONE",       dfsPhone.Text,     ref lsAttr);
                    Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("FAX",         dfsFax.Text,       ref lsAttr);
                    Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("MOBILE",      dfsMobile.Text,    ref lsAttr);
                    Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("E_MAIL",      dfsEmail.Text,     ref lsAttr);
                    Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("TITLE",       dfsTitle.Text,     ref lsAttr);
                    Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("INITIALS",    dfsInitials.Text,  ref lsAttr);
                    Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("WWW",         dfsWww.Text,       ref lsAttr);
                    Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("MESSENGER",   dfsMessenger.Text, ref lsAttr);
                    Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("INTERCOM",    dfsIntercom.Text,  ref lsAttr);
                    Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("PAGER",       dfsPager.Text,     ref lsAttr);
                    Ifs.Fnd.ApplicationForms.Var.Console.Add("lsAttr: " + lsAttr);

                    Sal.WaitCursor(true);
                    IDictionary<string, string> namedBindVariables = new Dictionary<string, string>();
                    namedBindVariables.Add("Attr", QualifiedVarBindName("lsAttr"));
                    if (DbPLSQLTransaction(@"&AO.Supplier_Info_Contact_API.Create_Contact({Attr});", namedBindVariables))
                    {
                        if (dfsPersonId.Text == SalString.Null)
                        {
                            dfsPersonId.Text = Ifs.Fnd.ApplicationForms.Int.PalAttrGet("PERSON_ID", lsAttr);
                        }
                        sContact = dfsPersonId.Text;
                        sAddressId = dfsAddressId.Text;
                    }
                    else
                    {
                        sContact = Ifs.Fnd.ApplicationForms.Const.strNULL;
                        sAddressId = Ifs.Fnd.ApplicationForms.Const.strNULL;
                    }
                    Sal.WaitCursor(false);
                    Ifs.Fnd.ApplicationForms.Var.Console.Add("lsAttr: " + lsAttr);
                }
                Sal.EndDialog(this, Sys.IDOK);
                
            }
            #endregion
        }

        private void commandCancel_Execute(object sender, Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            #region Action
            DialogResult = DialogResult.None;
            Sal.EndDialog(this, Sys.IDCANCEL);
            #endregion
        }

        private void commandFind_Inquire(object sender, FndCommandInquireEventArgs e)
        {
            #region Action
            ((FndCommand)sender).Enabled = true;
            #endregion
        }

        private void commandFind_Execute(object sender, Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            #region Action
            SalString sStartedFromCustomer = "FALSE";
            Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
            vrtDataSourcePrepareKeyTransfer(Pal.GetActiveInstanceName("dlgFindPerson"));
            Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemAdd("STARTED_FROM_CUSTOMER", new SalArray<SalString>() { sStartedFromCustomer });
			Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemAdd("STARTED_FROM_SUPPLIER", new SalArray<SalString>() { "TRUE" });
            Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemAdd("FIRST_NAME", new SalArray<SalString>() { sFirstName });
            Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemAdd("MIDDLE_NAME", new SalArray<SalString>() { sMiddleName });
            Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemAdd("LAST_NAME", new SalArray<SalString>() { sLastName });

            if (Sys.IDOK != dlgFindPerson.ModalDialog(Sys.hWndMDI))
            {
                return;
            }
            Find_Execute();
            #endregion
        }

        private void commandList_Inquire(object sender, Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            #region Action
            e.Handled = true;
            hWndFocus = Ifs.Fnd.ApplicationForms.Int.PalGetFocus();
            ((FndCommand)sender).Enabled = Sal.SendMsg(hWndFocus, Ifs.Fnd.ApplicationForms.Const.PM_DataItemLov, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0);
            #endregion
        }

        private void commandList_Execute(object sender, Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            #region Action
            e.Handled = true;
            Sal.SendMsg(hWndFocus, Ifs.Fnd.ApplicationForms.Const.PM_DataItemLov, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
            #endregion
        }

        private void commandReset_Execute(object sender, Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            #region Action
            var controls = GetControls(this);
            foreach (Control con in controls)
            {
                if (con is cDataField)
                    con.ResetText();
                else if (con is cComboBox)
                    con.ResetText();
                else if (con is cComboBoxMultiSelection)
                    con.ResetText();
            }
            cbCopyAddress.Checked = false;
            EnableDisableContactInfo(true);
            sFirstName = Ifs.Fnd.ApplicationForms.Const.strNULL;
            sMiddleName = Ifs.Fnd.ApplicationForms.Const.strNULL;
            sLastName = Ifs.Fnd.ApplicationForms.Const.strNULL;
            this.cCommandButtonOk.Enabled = false;
            #endregion
        }

        #endregion     


        #region Menu Event Handlers

        #endregion
    }
}
