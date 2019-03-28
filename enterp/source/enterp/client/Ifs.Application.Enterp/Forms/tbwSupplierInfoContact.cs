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
// Date      By      Notes
// ------    -----   ---------------------------------------------------
// 121221    Nirplk  Merged Bug 106346.
// 140411    AjPelk  PBFI-4141 , Merged bug 112761. 
// 140704    MaRalk  PRSC-1620, Added method colsPersonId_OnPM_DataItemZoom.
// 140916    JanWse  PRSC-2365, Added parameter bCreatePerson to UM_AddContact
// 150126    MaRalk  PRSC-5384, Modified UM_AddContact in order to facilitate saving person's initials entered in the
// 150126            'Add Contact' dialog.
// 150513    SudJlk   ORA-292, Added colsPersonId_OnPM_DataItemLovUserWhere to filter persons who are defined as not blocked supplier contacts.
// 150610    SudJlk  ORA-691, Added method HandleSrmColumns, window actions tbwCustomerInfoContact_OnPAM_SetMainRepresentative,tbwCustomerInfoContact_OnPAM_SetMainRepName
// 150610            colsMainRepresentativeId_OnPM_DataItemZoom, tableWindow_colsDepartment_OnPM_LookupInit and Overriden FrameStartupUser.
// 150612    SudJlk  ORA-571, Modified methods CheckDefault, DataSourcePopulateIt and window actions PAM_SetMainRepresentative, PAM_SetMainRepName.
// 150612            Added window actions SAM_RowSetContext, PAM_GetParentValue, PAM_GetObjectType, PAM_RecordNotInitiallySaved and PAM_RefreshContactOnSave.
// 150629    SudJlk  ORA-761, Modified method UM_AddContact to enable RMB Add Contact when loaded from frmSupplierInfoContact. Added window action PM_DataRecordNew.
// 150804    SudJlk  ORA-1095, Modified UM_AddContact to call dlgAddSupplierContact replacing dlgAddContact.
// 150818    SudJlk  ORA-1221, Modified UM_AddContact as parameters to dlgAddSupplierContact have changed.
// 150824    MaRalk  BLU-1182, Modified tblPersonId_OnPM_DataItemValidate in order to fetch the value for www when adding a person.
// 160512    SudJlk  STRSC-2113, Modified CheckDefault to correct the case for frmSupplierInfoContact so that the code will be executed properly to validate attraibutes.
// 171213    Nirylk  STRFI-9846, Merged LCS Bug 137494, Modified colsPersonId_OnPM_DataItemZoom().
#endregion

using System.Windows.Forms;
using Ifs.Application.Appsrv;
using Ifs.Fnd.ApplicationForms;
using Ifs.Fnd.Windows.Forms;
using PPJ.Runtime;
using PPJ.Runtime.Sql;
using PPJ.Runtime.Windows;

namespace Ifs.Application.Enterp
{
	
	/// <summary>
	/// </summary>
    [FndWindowRegistration("SUPPLIER_INFO_CONTACT", "SupplierInfoContact")]
    [FndDynamicTabPage("frmSupplier360.picTab", "tbSupplierInfoContact", "TAB_NAME_SupplierInfoContact", 26)]
    public partial class tbwSupplierInfoContact : cTableWindowEntBase
    {
        #region Window Variables
        public SalString lsAttr = "";
        public SalString sSupplierId = "";
        public SalString sPersonId = "";
        public SalString sAddressId = "";
        public SalString sTempSupplierId = "";
        public SalString sTempAddressId = "";
        public fcStartupQuery StartupQuery = new fcStartupQuery();
        public SalString sSupplierUserWhere = "";
        public SalString sParentWnd = "";
        public SalString lsStmt = "";
		public SalArray<SalString> sPersonIdVal = new SalArray<SalString>();
		public SalArray<SalString> sGuidVal = new SalArray<SalString>();
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public tbwSupplierInfoContact()
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
        public new static tbwSupplierInfoContact FromHandle(SalWindowHandle handle)
        {
            return ((tbwSupplierInfoContact)SalWindow.FromHandle(handle, typeof(tbwSupplierInfoContact)));
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
            SalBoolean bCreatePerson = false;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Supplier_Info_contact_API.New") && Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Supplier_Info_contact_API.Create_Contact")))
                            return false;
                        
                        if (Ifs.Fnd.ApplicationForms.Int.QualifiedItemNameGet(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndSelf)) == Pal.GetActiveInstanceName("frmSupplierInfo"))
                        {
                            sSupplierId = frmSupplierInfo.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndSelf)).cmbSupplierId.i_sMyValue;
                        }
                        else if (Ifs.Fnd.ApplicationForms.Int.QualifiedItemNameGet(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndSelf)) == Pal.GetActiveInstanceName("frmSupplier360"))
                        {
                            this.ParentDataSourceItemValueGet("SUPPLIER_ID", ref sSupplierId);
                        }
                        else if (Ifs.Fnd.ApplicationForms.Int.QualifiedItemNameGet(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndSelf)) == Pal.GetActiveInstanceName("frmSupplierInfoContact")) // If SRM is installed
                        {
                            sSupplierId = frmSupplierInfo.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndSelf))).cmbSupplierId.i_sMyValue;
                        }

                        Ifs.Fnd.ApplicationForms.Var.Console.Add(Ifs.Fnd.ApplicationForms.Int.QualifiedItemNameGet(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndSelf)));
                        return Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("frmSupplierInfo")) && sSupplierId != SalString.Null;

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        if (dlgAddSupplierContact.ModalDialog(this, ref sPersonId, ref sAddressId, sSupplierId) == Sys.IDOK)
                        {
                            sAddressId = SalString.Null;
                            Sal.SendMsg(i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceRefresh, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, Ifs.Fnd.ApplicationForms.Const.POPULATE_Single);
                        }
                        break;
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
            #region Actions
            using (new SalContext(this))
            {
                if (Ifs.Fnd.ApplicationForms.Int.QualifiedItemNameGet(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndSelf)) == Pal.GetActiveInstanceName("frmSupplierInfo") ||
                    Ifs.Fnd.ApplicationForms.Int.QualifiedItemNameGet(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndSelf)) == Pal.GetActiveInstanceName("frmSupplier360") ||
                    Ifs.Fnd.ApplicationForms.Int.QualifiedItemNameGet(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndSelf)) == Pal.GetActiveInstanceName("frmSupplierInfoContact"))
                {
                    sTempSupplierId = colsSupplierId.Text;
                    sTempAddressId = Ifs.Fnd.ApplicationForms.Const.strNULL;
                    using (SignatureHints hints = SignatureHints.NewContext())
                    {
                        hints.Add("Supplier_Info_Contact_API.Check_Default_Values", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                        if (!(DbPLSQLBlock(cSessionManager.c_hSql, "&AO.Supplier_Info_Contact_API.Check_Default_Values (	:i_hWndFrame.tbwSupplierInfoContact.sTempSupplierId,\r\n" +
                            "									:i_hWndFrame.tbwSupplierInfoContact.sTempAddressId)")))
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            #endregion
        }
        // supplier360
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
                if (sParentWnd == Pal.GetActiveInstanceName("frmSupplier360"))
                {
                    sUserWhere = " supplier_id = :i_hWndParent.frmSupplier360.ecmbSupplierNo.i_sMyValue";
                    sSupplierUserWhere = sUserWhere;
                    if (i_lsUserWhere != Ifs.Fnd.ApplicationForms.Const.strNULL)
                    {
                        sUserWhere = i_lsUserWhere + " AND " + sUserWhere;
                    }
                    DataSourceUserWhere(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, sUserWhere.ToHandle());
                }
                //SalString sSourceName = Ifs.Fnd.ApplicationForms.Var.DataTransfer.SourceNameGet();
                //if (sSourceName == Pal.GetActiveInstanceName("tbwSupplierInfoContact"))
                if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.SourceNameGet() == Pal.GetActiveInstanceName("frmSupplierInfo"))
                {
                    if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.RecCountGet() > 0)
                    {
                        Sal.WaitCursor(true);
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("PERSON_ID", sPersonIdVal);
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("GUID", sGuidVal);

                        if (sGuidVal[0] == SalString.Null)
                            lsStmt = " PERSON_ID = :i_hWndFrame.tbwSupplierInfoContact.sPersonIdVal[0]";
                        else
							lsStmt = " PERSON_ID = :i_hWndFrame.tbwSupplierInfoContact.sPersonIdVal[0] AND GUID = :i_hWndFrame.tbwSupplierInfoContact.sGuidVal[0]";

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

        protected virtual void HandleSrmColumns()
        {
            if (!(Ifs.Fnd.ApplicationForms.Var.Component.IsWindowAvailable(Pal.GetActiveInstanceName("frmSupplierInfoContact")) && Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("frmSupplierInfoContact"))))
            {
                colsMainRepresentativeId.Visible = false;
                colsMainRepresentativeName.Visible = false;
                colsDepartment.Visible = false;
            }
        }

        private SalBoolean FrameStartupUser()
        {
            #region Actions
            using (new SalContext(this))
            {
                if (((cDataSource)this).FrameStartupUser())
                {
                    HandleSrmColumns();
                    return true;
                }
                else
                    return false;
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
        private void tbwSupplierInfoContact_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew:
                    this.tbwSupplierInfoContact_OnPM_DataRecordNew(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave:
                    this.tbwSupplierInfoContact_OnPM_DataSourceSave(sender, e);
                    break;


                case Ifs.Fnd.ApplicationForms.Const.PM_User:
                    this.tbwSupplierInfoContact_OnPM_User(sender, e);
                    break;


                // supplier360

                case Sys.SAM_Create:
                    this.tbwSupplierInfoContact_OnSAM_Create(sender, e);
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
                case Ifs.Application.Enterp.Const.PAM_SetMainRepresentative:
                    this.tbwSupplierInfoContact_OnPAM_SetMainRepresentative(sender, e);
                    break;

                case Ifs.Application.Enterp.Const.PAM_SetMainRepName:
                    this.tbwSupplierInfoContact_OnPAM_SetMainRepName(sender, e);
                    break;

                case Sys.SAM_RowSetContext:
                    this.tbwSupplierInfoContact_OnSAM_RowSetContext(sender, e);
                    break;

                case Ifs.Application.Enterp.Const.PAM_GetParentValue:
                    e.Handled = true;
                    e.Return = ((SalString)this.colsGuid.Text).ToHandle();
                    break;
                case Ifs.Application.Enterp.Const.PAM_GetObjectType:
                    e.Handled = true;
                    e.Return = ((SalString)Const.OBJECT_SupContactType).ToHandle();
                    break;

                case Ifs.Application.Enterp.Const.PAM_RecordNotInitiallySaved:
                    e.Handled = true;
                    e.Return = Sal.IsNull(__colObjid);
                    break;

                case Ifs.Application.Enterp.Const.PAM_RefreshContactOnSave:
                    e.Handled = true;
                    this.tbwSupplierInfoContact_OnPAM_RefreshContactOnSave(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataSourceSave event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwSupplierInfoContact_OnPM_DataSourceSave(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)
            {
                if (Ifs.Fnd.ApplicationForms.Int.QualifiedItemNameGet(Ifs.Fnd.ApplicationForms.Int.GetParent(this.i_hWndSelf)) != Pal.GetActiveInstanceName("frmSupplierInfo"))
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
        /// PM_User event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwSupplierInfoContact_OnPM_User(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                if (SalString.FromHandle(Sys.lParam) == "frmSupplierInfoSaveCheckOk")
                {
                    e.Return = this.CheckDefault();
                    return;
                }
            }
            e.Return = Sal.SendMsgToChildren(this.i_hWndFrame, Ifs.Fnd.ApplicationForms.Const.PM_User, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// SAM_Create event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwSupplierInfoContact_OnSAM_Create(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam);
            this.sParentWnd = Ifs.Fnd.ApplicationForms.Int.PalGetItemNameX(Ifs.Fnd.ApplicationForms.Int.GetParent(this));
            this.StartupQuery.Init(this.i_hWndSelf, this.ProfileSectionGet());
            #endregion
        }

        #region tblPersonId Actions

        /// <summary>
        /// Window Actions for tblPersonId
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tblPersonId_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.tblPersonId_OnPM_DataItemValidate(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom:
                    this.colsPersonId_OnPM_DataItemZoom(sender, e);
                    break;
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovUserWhere:
                    this.colsPersonId_OnPM_DataItemLovUserWhere(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// PM_DataItemValidate event handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tblPersonId_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
			if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam)) 
			{
				if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute) 
				{
                    if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                    {
                        using (SignatureHints hints = SignatureHints.NewContext())
                        {
                            hints.Add("Person_Info_Address_API.Get_Default_Contact_Info", System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                            this.colsPersonId.DbPLSQLBlock(cSessionManager.c_hSql, "\r\n" +
                                "	BEGIN\r\n" +
                                "		&AO.Person_Info_Address_API.Get_Default_Contact_Info(\r\n" +
                                "			:i_hWndFrame.tbwSupplierInfoContact.colPersonInfoAddressPhone,\r\n" +
                                "			:i_hWndFrame.tbwSupplierInfoContact.colPersonInfoAddressMobile,\r\n" +
                                "			:i_hWndFrame.tbwSupplierInfoContact.colPersonInfoAddressE_Mail,\r\n" +
                                "			:i_hWndFrame.tbwSupplierInfoContact.colPersonInfoAddressFax,\r\n" +
                                "			:i_hWndFrame.tbwSupplierInfoContact.colPersonInfoAddressPager,\r\n" +
                                "			:i_hWndFrame.tbwSupplierInfoContact.colPersonInfoAddressIntercom,\r\n" +
                                "			:i_hWndFrame.tbwSupplierInfoContact.colPersonInfoAddressWww,\r\n" +
                                "			:i_hWndFrame.tbwSupplierInfoContact.colsPersonId,\r\n" +
                                "			:i_hWndFrame.tbwSupplierInfoContact.colsContactAddress) ;\r\n	END;");
                        }
                    }



				
		
		    	}
			
           }
           e.Return = true;
		   return;
           #endregion
        }

        private void colsPersonId_OnPM_DataItemZoom(object sender, WindowActionsEventArgs e)
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

        #endregion

        private void colsPersonId_OnPM_DataItemLovUserWhere(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            e.Return = ((SalString)"SUPPLIER_CONTACT_DB='TRUE' AND BLOCKED_FOR_USE_SUPPLIER_DB='FALSE'").ToHandle();
            return;
            #endregion
        }

        private void tbwSupplierInfoContact_OnPAM_SetMainRepresentative(object sender, WindowActionsEventArgs e)
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
                }
            }
            this.SetContextRow(nOriginalContextRow);
            #endregion
        }

        private void tbwSupplierInfoContact_OnPAM_SetMainRepName(object sender, WindowActionsEventArgs e)
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

        private void tableWindow_colsMainRepresentativeId_WindowActions(object sender, WindowActionsEventArgs e)
        {
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom:
                    this.colsMainRepresentativeId_OnPM_DataItemZoom(sender, e);
                    break;
            }
        }

        private void colsMainRepresentativeId_OnPM_DataItemZoom(object sender, WindowActionsEventArgs e)
        {
            SalArray<SalString> sItemNames = new SalArray<SalString>();
            SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();

            e.Handled = true;

            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                sItemNames[0] = "REPRESENTATIVE_ID";
                hWndItems[0] = this.colsMainRepresentativeId;
                Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("REPRESENTATIVE_ID", this, sItemNames, hWndItems);
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

        private void tbwSupplierInfoContact_OnSAM_RowSetContext(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Sys.SAM_RowSetContext, Sys.wParam, Sys.lParam);
            // Populate representatives table if SRM is installed
            if (Ifs.Fnd.ApplicationForms.Int.QualifiedItemNameGet(Ifs.Fnd.ApplicationForms.Int.GetParent(i_hWndSelf)) == Pal.GetActiveInstanceName("frmSupplierInfoContact")) 
                SendMessageToParent(Const.PAM_PopulateRepresentative, 1, 0);
            e.Return = true;

            #endregion
        }

        private void tbwSupplierInfoContact_OnPAM_RefreshContactOnSave(object sender, WindowActionsEventArgs e)
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

        private void tbwSupplierInfoContact_OnPM_DataRecordNew(object sender, WindowActionsEventArgs e)
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

        #endregion

        #region Late Bind Methods

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

        public override SalBoolean vrtDataSourceSaveNew()
        {
            SalBoolean bOk = base.vrtDataSourceSaveNew();
            if (!this.CheckDefault())
            {
                return false;
            }
            return bOk;
        }

        public override SalBoolean vrtFrameStartupUser()
        {
            return this.FrameStartupUser();
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

    }
}
