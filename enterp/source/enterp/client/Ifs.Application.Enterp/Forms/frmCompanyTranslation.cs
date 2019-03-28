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
//  130918  Hecolk  Bug 112509, Modified in vrtActivate
//  131120  PRatlk  PBFI-2523 , ChildTable Refactoring in ENTERP.
#endregion

using System.Windows.Forms;
using Ifs.Fnd.ApplicationForms;
using Ifs.Fnd.Windows.Forms;
using PPJ.Runtime;
using PPJ.Runtime.Sql;
using PPJ.Runtime.Windows;
using Ifs.Application.Enterp.Classes;

namespace Ifs.Application.Enterp
{
	
	/// <summary>
	/// </summary>
    [FndWindowRegistration("COMPANY_KEY_LU", "CompanyKeyLu", FndWindowRegistrationFlags.HomePage)]
    public partial class frmCompanyTranslation : cFormWindow
    {
        #region Window Variables
        public SalString sLanguageCode = "";
        public SalString sAttribute = "";
        public SalString sTransCompany = "";
        public SalString sTransModule = "";
        public SalString sTransLu = "";
        public SalString lsTransAttribute = "";

        protected SalString sLu = "CompanyKeyLuTranslation";
        protected SalString sState = "";
        protected SalString sAllInfo = "";
        protected SalString sType = "";
        protected SalNumber nLogId = 0;
        protected SalString sWindow = "";
        protected SalArray<SalString> lsAttr = new SalArray<SalString>();
        protected SalArray<SalString> sParams = new SalArray<SalString>();
        protected SalArray<SalWindowHandle> cControls = new SalArray<SalWindowHandle>();        
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public frmCompanyTranslation()
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
        public new static frmCompanyTranslation FromHandle(SalWindowHandle handle)
        {
            return ((frmCompanyTranslation)SalWindow.FromHandle(handle, typeof(frmCompanyTranslation)));
        }
        #endregion

        #region Methods
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override SalNumber vrtActivate(fcURL URL)
        {

            #region Local Variables
            SalString sLuString = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                Ifs.Fnd.ApplicationForms.Var.Cache.SessionRetrieve("TRANSLATE_COMPANY", ref sTransCompany);
                Ifs.Fnd.ApplicationForms.Var.Cache.SessionRetrieve("TRANSLATE_MODULE", ref sTransModule);
                Ifs.Fnd.ApplicationForms.Var.Cache.SessionRetrieve("TRANSLATE_LU", ref sTransLu);
                Ifs.Fnd.ApplicationForms.Var.Cache.SessionRetrieve("TRANSLATE_ATTRIBUTE", ref lsTransAttribute);
                if (sTransCompany != Ifs.Fnd.ApplicationForms.Const.strNULL && sTransModule != Ifs.Fnd.ApplicationForms.Const.strNULL && sTransLu != Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    Sal.WaitCursor(true);
                    Sal.SetWindowText(i_hWndFrame, Properties.Resources.WH_CompanyTranslation);
                    cmbCompany.EditDataItemValueSet(0, sTransCompany.ToHandle());
                    Sal.SetWindowText(cmbCompany, sTransCompany);
                    dfsModule.Text = sTransModule;
                    dfsLu.Text = sTransLu;
                    sLuString = "^Account^CodeB^CodeC^CodeD^CodeE^CodeF^CodeG^CodeH^CodeI^CodeJ^AccountingProject^";
                    if (sLuString.Scan("^" + sTransLu + "^") != -1)
                    {
                        Sal.SetMaxDataLength(tblCompanyTranslationDetail_colsCurrentTranslation, 100);
                    }
                    if (sTransModule != Ifs.Fnd.ApplicationForms.Const.strNULL)
                    {
                        Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceUserWhere, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ("KEY_VALUE= '" + sTransCompany + "' AND MODULE= '" + sTransModule + "' AND LU= '" + sTransLu + "'").ToHandle());
                    }
                    else
                    {
                        Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceUserWhere, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ("KEY_VALUE= '" + sTransCompany + "' AND LU= '" + sTransLu + "'").ToHandle());
                    }
                    if (lsTransAttribute != Ifs.Fnd.ApplicationForms.Const.strNULL)
                    {
                        Sal.SendMsg(tblCompanyTranslationDetail, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceUserWhere, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ("ATTRIBUTE_KEY IN (" + lsTransAttribute + ")").ToHandle());
                        Sal.SendMsg(tblCompanyTranslationDetail, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceUserOrderBy, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, ((SalString)"ATTRIBUTE_KEY").ToHandle());
                    }
                    Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
                    Sal.WaitCursor(false);
                    // Set cache variables to null
                    Ifs.Fnd.ApplicationForms.Var.Cache.SessionStore("TRANSLATE_COMPANY", Ifs.Fnd.ApplicationForms.Const.strNULL);
                    Ifs.Fnd.ApplicationForms.Var.Cache.SessionStore("TRANSLATE_MODULE", Ifs.Fnd.ApplicationForms.Const.strNULL);
                    Ifs.Fnd.ApplicationForms.Var.Cache.SessionStore("TRANSLATE_LU", Ifs.Fnd.ApplicationForms.Const.strNULL);
                    Ifs.Fnd.ApplicationForms.Var.Cache.SessionStore("TRANSLATE_ATTRIBUTE", Ifs.Fnd.ApplicationForms.Const.strNULL);
                    return false;
                }
                else
                {
                    Sal.SetWindowText(i_hWndFrame, Properties.Resources.WH_CompanyTranslation);
                }
            }
            return base.Activate(URL);
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
                if (sMethod == "CopyInstallationText")
                {
                    switch (nWhat)
                    {
                        case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                            if ((cmbCompany.i_sMyValue == SalString.Null) || (dfsLu.Text == Sys.STRING_Null))
                            {
                                return 0;
                            }
                            return Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Key_Lu_Translation_API.Copy_Installation_Text__");

                        case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                            return CopyInstallationText(nWhat);
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
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalNumber CopyInstallationText(SalNumber nWhat)
        {
            #region Actions
            using (new SalContext(this))
            {
                sLanguageCode = SalString.Null;
                sAttribute = SalString.Null;
                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("Key_Lu_Translation_API.Copy_Installation_Text__", System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                    DbPLSQLTransaction(cSessionManager.c_hSql, "&AO.Key_Lu_Translation_API.Copy_Installation_Text__(  :i_hWndFrame.frmCompanyTranslation.dfsKeyName,\r\n" +
                        "                                                                                                                                          :i_hWndFrame.frmCompanyTranslation.cmbCompany.i_sMyValue,\r\n" +
                        "                                                                                                                                          :i_hWndFrame.frmCompanyTranslation.dfsModule,\r\n" +
                        "                                                                                                                                          :i_hWndFrame.frmCompanyTranslation.dfsLu,\r\n" +
                        "                                                                                                                                          :i_hWndFrame.frmCompanyTranslation.sAttribute,\r\n" +
                        "                                                                                                                                          :i_hWndFrame.frmCompanyTranslation.sLanguageCode )");
                }
                Sal.SendMsg(i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceRefresh, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                return 1;
            }
            #endregion
        }

        public new SalBoolean DataSourceSaveCheckOk()
        {
            #region Actions
            DbPLSQLBlock(@" {0} := &AO.Company_Basic_Data_Window_API.Is_Active_Lu_Exist( {1} IN,{2} IN) ;",
                                                  this.QualifiedVarBindName("sState"),
                                                 this.QualifiedVarBindName("cmbCompany.i_sMyValue"),
                                                  this.QualifiedVarBindName("sLu"));
            if (sState == "TRUE")
            {
                sType = "AUTOMATIC";
                cControls[0] = tblCompanyTranslationDetail_colsModule;
                cControls[1] = tblCompanyTranslationDetail_colsLu;
                cControls[2] = tblCompanyTranslationDetail_colsAttributeKey;
                cControls[3] = tblCompanyTranslationDetail_colsLanguageCodeDb;
                cCopyToCompany.CopyToCompanies(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, this.tblCompanyTranslationDetail, sLu, "Company_Key_Lu_Translation_API", cControls, this.cmbCompany.i_sMyValue, sType, ref this.lsAttr, ref sAllInfo, ref sWindow, ref nLogId);
                sParams[0] = sWindow;
            }
            return true;
            #endregion
        }

        public virtual new void NavigateToCopyBasicDataLog()
        {
            #region Local Variables
            SalArray<SalString> sItemNames = new SalArray<SalString>();
            #endregion

            #region Actions
            sItemNames[0] = nLogId.ToString();
            Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
            Ifs.Fnd.ApplicationForms.Var.DataTransfer.SourceNameSet("LOG_DETAIL");
            Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemAdd("LOG_ID", sItemNames);
            SessionNavigate(Pal.GetActiveInstanceName("tbwCopyBasicDataLog"));
            #endregion
        }

        #endregion

        #region tblCompanyTranslationDetail

            #region Window Variables
            public SalNumber tblCompanyTranslationDetail_nNum = 0;
            public SalArray<SalString> tblCompanyTranslationDetail_sRecords = new SalArray<SalString>();
            public SalArray<SalString> tblCompanyTranslationDetail_sUnits = new SalArray<SalString>();
            public SalBoolean tblCompanyTranslationDetail_bNewRecord = false;
            public SalNumber tblCompanyTranslationDetail_nCurrentRow = 0;
            #endregion

            #region Methods

            /// <summary>
            /// </summary>
            /// <param name="nWhat"></param>
            /// <param name="sMethod"></param>
            /// <returns></returns>
            public virtual SalNumber tblCompanyTranslationDetail_UserMethod(SalNumber nWhat, SalString sMethod)
            {
                #region Actions
                using (new SalContext(this))
                {
                    if (sMethod == "CopyInstallationText")
                    {
                        switch (nWhat)
                        {
                            case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                                return tblCompanyTranslationDetail_CopyInstallationText(nWhat);

                            case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                                return tblCompanyTranslationDetail_CopyInstallationText(nWhat);
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
            /// <param name="nWhat"></param>
            /// <returns></returns>
            public virtual SalNumber tblCompanyTranslationDetail_CopyInstallationText(SalNumber nWhat)
            {
                #region Local Variables
                SalBoolean bOk = false;
                SalNumber nCurrentRow = 0;
                #endregion

                #region Actions
                using (new SalContext(this))
                {
                    switch (nWhat)
                    {
                        case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                            nCurrentRow = Sys.TBL_MinRow;
                            bOk = true;
                            if (!(Sal.TblAnyRows(tblCompanyTranslationDetail, Sys.ROW_Selected, 0)))
                            {
                                bOk = false;
                            }
                            while (Sal.TblFindNextRow(tblCompanyTranslationDetail, ref nCurrentRow, Sys.ROW_Selected, 0))
                            {
                                Sal.TblSetFocusRow(tblCompanyTranslationDetail, nCurrentRow);
                                if ((tblCompanyTranslationDetail_colsInstallationTranslation.Text == Sys.STRING_Null) || (tblCompanyTranslationDetail_colsInstallationTranslation.Text == tblCompanyTranslationDetail_colsCurrentTranslation.Text))
                                {
                                    bOk = false;
                                }
                            }
                            return bOk && Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Key_Lu_Translation_API.Copy_Installation_Text__");

                        case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                            nCurrentRow = Sys.TBL_MinRow;
                            while (Sal.TblFindNextRow(tblCompanyTranslationDetail, ref nCurrentRow, Sys.ROW_Selected, 0))
                            {
                                Sal.TblSetFocusRow(tblCompanyTranslationDetail, nCurrentRow);
                                DbPLSQLTransaction(cSessionManager.c_hSql, "&AO.Key_Lu_Translation_API.Copy_Installation_Text__( :i_hWndFrame.frmCompanyTranslation.tblCompanyTranslationDetail_colsKeyName IN,\r\n" +
                                        "                                                                                        :i_hWndFrame.frmCompanyTranslation.tblCompanyTranslationDetail_colsKeyValue IN ,\r\n" +
                                        "                                                                                        :i_hWndFrame.frmCompanyTranslation.tblCompanyTranslationDetail_colsModule IN ,\r\n" +
                                        "                                                                                        :i_hWndFrame.frmCompanyTranslation.tblCompanyTranslationDetail_colsLu IN ,\r\n" +
                                        "                                                                                        :i_hWndFrame.frmCompanyTranslation.tblCompanyTranslationDetail_colsAttributeKey IN ,\r\n" +
                                        "                                                                                        :i_hWndFrame.frmCompanyTranslation.tblCompanyTranslationDetail_colsLanguageCodeDb IN )");
                            }
                            Sal.SendMsg(tblCompanyTranslationDetail, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceRefresh, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                            return 1;
                    }
                }

                return 0;
                #endregion
            }

            /// <summary>
            /// </summary>
            /// <returns></returns>
            public virtual SalBoolean GetProgCurrTrans()
            {
                #region Actions
                using (new SalContext(this))
                {
                    if (!(DbPLSQLBlock(cSessionManager.c_hSql, "\r\n" +
                            "  BEGIN\r\n" +
                            "			:i_hWndFrame.frmCompanyTranslation.tblCompanyTranslationDetail_colsCurrentTranslation :=\r\n" +
                            "			&AO.Key_Lu_Translation_API.Get_Prog_Current_Translation__(\r\n" +
                            "		    :i_hWndFrame.frmCompanyTranslation.tblCompanyTranslationDetail_colsKeyName IN ,\r\n" +
                            "			:i_hWndFrame.frmCompanyTranslation.tblCompanyTranslationDetail_colsKeyValue IN,\r\n" +
                            "		    :i_hWndFrame.frmCompanyTranslation.tblCompanyTranslationDetail_colsModule IN,\r\n" +
                            "			:i_hWndFrame.frmCompanyTranslation.tblCompanyTranslationDetail_colsLu IN,\r\n" +
                            "			:i_hWndFrame.frmCompanyTranslation.tblCompanyTranslationDetail_colsAttributeKey IN );\r\n END;")))
                    {
                            return false;
                    }
                    Sal.SetFieldEdit(tblCompanyTranslationDetail_colsCurrentTranslation, true);
                    return true;
                }
                #endregion
            }

            /// <summary>
            /// </summary>
            /// <returns></returns>
            public virtual SalBoolean GetLanguageDesc()
            {
                #region Actions
                if (!(DbPLSQLBlock(cSessionManager.c_hSql, "\r\n" +
                            "		BEGIN\r\n" +
                            "	    :i_hWndFrame.frmCompanyTranslation.tblCompanyTranslationDetail_colsLanguageCodeDesc :=\r\n" +
                            "	    &AO.Iso_Language_API.Decode(:i_hWndFrame.frmCompanyTranslation.tblCompanyTranslationDetail_colsLanguageCodeDb IN );\r\n END;")))
                {
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
            private void colsAttributeKey_WindowActions(object sender, WindowActionsEventArgs e)
            {
                #region Actions
                switch (e.ActionType)
                {
                    case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                        this.colsAttributeKey_OnPM_DataItemValidate(sender, e);
                        break;

                    case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovDone:
                        this.colsAttributeKey_OnPM_DataItemLovDone(sender, e);
                        break;
                }
                #endregion
            }

            /// <summary>
            /// PM_DataItemValidate event handler.
            /// </summary>
            /// <param name="message"></param>
            private void colsAttributeKey_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
            {
                #region Actions
                e.Handled = true;
                if (Sal.IsNull(this.tblCompanyTranslationDetail_colsAttributeKey))
                {
                    this.tblCompanyTranslationDetail_colsCurrentTranslation.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                    e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
                    return;
                }
                // ! Bug 89816, Begin, Validation done only for new records. Omitted for Duplicated and Pasted records
                if (this.tblCompanyTranslationDetail_bNewRecord)
                {
                    if (!(this.GetProgCurrTrans()))
                    {
                        e.Return = Sys.VALIDATE_Cancel;
                        return;
                    }
                    this.tblCompanyTranslationDetail_bNewRecord = false;
                }
                // ! Bug 89816, End
                e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
                return;
                #endregion
            }

            /// <summary>
            /// PM_DataItemLovDone event handler.
            /// </summary>
            /// <param name="message"></param>
            private void colsAttributeKey_OnPM_DataItemLovDone(object sender, WindowActionsEventArgs e)
            {
                #region Actions
                e.Handled = true;
                this.tblCompanyTranslationDetail_nNum = SalString.FromHandle(Sys.lParam).Tokenize("", ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_RS).ToCharacter(), this.tblCompanyTranslationDetail_sRecords);
                this.tblCompanyTranslationDetail_nNum = this.tblCompanyTranslationDetail_sRecords[1].Tokenize("", ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_US).ToCharacter(), this.tblCompanyTranslationDetail_sUnits);
                if (this.tblCompanyTranslationDetail_sUnits[0] == "CURRENT_TRANSLATION")
                {
                    this.tblCompanyTranslationDetail_colsCurrentTranslation.Text = this.tblCompanyTranslationDetail_sUnits[1];
                    Sal.SetFieldEdit(this.tblCompanyTranslationDetail_colsCurrentTranslation, true);
                }
                #endregion
            }

            /// <summary>
            /// Window Actions
            /// </summary>
            /// <param name="sender">The source of the event.</param>
            /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
            private void colsLanguageCodeDb_WindowActions(object sender, WindowActionsEventArgs e)
            {
                #region Actions
                switch (e.ActionType)
                {
                    case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                        this.colsLanguageCodeDb_OnPM_DataItemValidate(sender, e);
                        break;

                    // On PM_DataItemLovDone

                    // Set tblCompanyTranslationDetail_nNum = SalStrTokenize( SalNumberToHString( lParam ), '', SalNumberToChar( CHAR_RS ), sRecords )

                    // Set tblCompanyTranslationDetail_nNum = SalStrTokenize( sRecords[1], '', SalNumberToChar( CHAR_US ), sUnits )

                    // If sUnits[0] = 'DESCRIPTION'

                    // Call SalSendMsg( colsLanguageCodeDesc, PM_DataItemValueSet, FALSE, SalHStringToNumber( sUnits[1] ) )
                }
                #endregion
            }

            /// <summary>
            /// PM_DataItemValidate event handler.
            /// </summary>
            /// <param name="message"></param>
            private void colsLanguageCodeDb_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
            {
                #region Actions
                e.Handled = true;
                if (Sal.IsNull(this.tblCompanyTranslationDetail_colsLanguageCodeDb))
                {
                    this.tblCompanyTranslationDetail_colsLanguageCodeDesc.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                    e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
                    return;
                }
                if (!(this.GetLanguageDesc()))
                {
                    e.Return = Sys.VALIDATE_Cancel;
                    return;
                }
                e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, Sys.wParam, Sys.lParam);
                return;
                #endregion
            }
            #endregion

            #region Event Handlers

            private void tblCompanyTranslationDetail_UserMethodEvent(object sender, cMethodManager.UserMethodEventArgs e)
            {
                e.Handled = true;
                e.ReturnValue = tblCompanyTranslationDetail_UserMethod(e.nWhat, e.sMethod);
            }

            private void tblCompanyTranslationDetail_DataRecordFetchEditedUserEvent(object sender, cDataSource.DataRecordFetchEditedUserEventArgs e)
            {
                #region Actions
                e.Handled = true;
                lsAttr[lsAttr.Length] = e.lsAttr;
                #endregion
            }
            #endregion

        #endregion

        #region Window Actions

            private void frmCompanyTranslation_WindowActions(object sender, WindowActionsEventArgs e)
            {
                #region Actions
                switch (e.ActionType)
                {
                    case Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave:
                        this.frmCompanyTranslation_OnPM_DataSourceSave(sender, e);
                        break;
                }
                #endregion
            }

            private void frmCompanyTranslation_OnPM_DataSourceSave(object sender, WindowActionsEventArgs e)
            {
                #region Actions
                e.Handled = true;
                if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Sys.wParam, Sys.lParam))
                {
                    e.Return = true;
                    if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                    {
                        if (cCopyToCompany.NavigateToCopyBasicDataLog(ref sAllInfo, sParams))
                        {
                            NavigateToCopyBasicDataLog();
                        }
                    }
                    return;
                }
                else
                {
                    lsAttr.Clear();
                    e.Return = false;
                    return;
                }

                #endregion
            }

            
            private void cmbCompany_WindowActions(object sender, WindowActionsEventArgs e)
            {
                #region Actions
                switch (e.ActionType)
                {
                    case Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom:
                        this.frmCompanyTranslation_cmbCompany_OnPM_DataItemZoom(sender, e);
                        break;                    
                }
                #endregion
            }


            /// <summary>
            /// PM_DataItemZoom event handler.
            /// </summary>
            /// <param name="message"></param>
            private void frmCompanyTranslation_cmbCompany_OnPM_DataItemZoom(object sender, WindowActionsEventArgs e)
            {
                #region Local Variable
                SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
                SalArray<SalString> sItemNames = new SalArray<SalString>();
                #endregion
                #region Actions
                e.Handled = true;
                switch (Sys.wParam)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        sItemNames[0] = "COMPANY";
                        hWndItems[0] = this.cmbCompany;
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init(Pal.GetActiveInstanceName("frmCompanyTranslation"), this, sItemNames, hWndItems);
                        SessionNavigate(Pal.GetActiveInstanceName("frmCompany"));
                        e.Return = true;
                        return;
                }
                e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataItemZoom, Sys.wParam, Sys.lParam);
                return;
                #endregion
            }
        /// <summary>
        /// Window Actions
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
        private void tblCompanyTranslationDetail_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                // ! Bug 89816, Begin

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew:
                    this.tblCompanyTranslationDetail_OnPM_DataRecordNew(sender, e);
                    break;

                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordPaste:
                    this.tblCompanyTranslationDetail_OnPM_DataRecordPaste(sender, e);
                    break;

                // ! Bug 89816, End
            }
            #endregion
        }

        /// <summary>
        /// PM_DataRecordNew event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblCompanyTranslationDetail_OnPM_DataRecordNew(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
            {
                this.tblCompanyTranslationDetail_bNewRecord = true;
            }
            e.Return = Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew, Sys.wParam, Sys.lParam);
            return;
            #endregion
        }

        /// <summary>
        /// PM_DataRecordPaste event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tblCompanyTranslationDetail_OnPM_DataRecordPaste(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataRecordPaste, Sys.wParam, Sys.lParam))
            {
                if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Execute)
                {
                    this.tblCompanyTranslationDetail_nCurrentRow = Sys.TBL_MinRow;
                    while (true)
                    {
                        if (Sal.TblFindNextRow(this.tblCompanyTranslationDetail.i_hWndSelf, ref this.tblCompanyTranslationDetail_nCurrentRow, Sys.ROW_Edited, 0))
                        {
                            Sal.TblSetContext(this.tblCompanyTranslationDetail.i_hWndSelf, this.tblCompanyTranslationDetail_nCurrentRow);
                            Sal.SendMsg(this.tblCompanyTranslationDetail_colsLanguageCodeDb, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate, 0, 0);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                e.Return = true;
                return;
            }
            #endregion
        }
        #endregion

        #region Late Bind Methods
        // Insert new code here...

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalNumber vrtUserMethod(SalNumber nWhat, SalString sMethod)
        {
            return this.UserMethod(nWhat, sMethod);
        }

        public override SalBoolean vrtDataSourceSaveCheckOk()
        {
            return DataSourceSaveCheckOk();
        }

        #endregion

        #region Event Handlers

        private void menuItem__Copy_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            // TODO: Rewrite command event handler not to use UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            ((FndCommand)sender).Enabled = Sal.SendMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, ((SalString)"CopyInstallationText").ToHandle());
        }

        private void menuItem__Copy_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            // TODO: Rewrite command event handler not to make use of UserMethod.
            // Place the logic in UserMethod directly in this event handler.i_sCompany
            Ifs.Fnd.ApplicationForms.Int.PostMessage(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, "CopyInstallationText");
        }

        private void menuItem__Copy_1_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            // TODO: Rewrite command event handler not to use UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            ((FndCommand)sender).Enabled = Sal.SendMsg(tblCompanyTranslationDetail, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, ((SalString)"CopyInstallationText").ToHandle());
        }

        private void menuItem__Copy_1_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            // TODO: Rewrite command event handler not to make use of UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            Ifs.Fnd.ApplicationForms.Int.PostMessage(tblCompanyTranslationDetail, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, "CopyInstallationText");
        }

        private void menuTbwMethods_menuCopy_To_Companies____Execute(object sender, FndCommandExecuteEventArgs e)
        {
            sType = "MANUAL";
            cControls[0] = tblCompanyTranslationDetail_colsModule;
            cControls[1] = tblCompanyTranslationDetail_colsLu;
            cControls[2] = tblCompanyTranslationDetail_colsAttributeKey;
            cControls[3] = tblCompanyTranslationDetail_colsLanguageCodeDb;
            cCopyToCompany.CopyToCompanies(Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, this.tblCompanyTranslationDetail, sLu, "Company_Key_Lu_Translation_API", cControls, this.cmbCompany.i_sMyValue, sType, ref this.lsAttr, ref sAllInfo, ref sWindow, ref nLogId);
            sParams[0] = sWindow;
            if (cCopyToCompany.NavigateToCopyBasicDataLog(ref sAllInfo, sParams))
            {
                NavigateToCopyBasicDataLog();
            }
        }

        private void menuTbwMethods_menuCopy_To_Companies____Inquire(object sender, FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = cCopyToCompany.CopyToCompanies(Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, this.tblCompanyTranslationDetail, sLu, "Company_Key_Lu_Translation_API", cControls, this.cmbCompany.i_sMyValue, sType, ref this.lsAttr, ref sAllInfo, ref sWindow, ref nLogId);
        }
        #endregion
              
        

    }
}
