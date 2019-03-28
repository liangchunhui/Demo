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
#endregion

using System.Windows.Forms;
using Ifs.Fnd.ApplicationForms;
using Ifs.Fnd.Windows.Forms;
using PPJ.Runtime;
using PPJ.Runtime.Sql;
using PPJ.Runtime.Windows;
using System.Collections.Generic;
using System;

namespace Ifs.Application.Enterp
{
	
	/// <summary>
	/// </summary>
    [FndWindowRegistration("COMPANY_EMP", "CompanyEmp")]
    public partial class tbwCompanyEmp : cTableWindowEntBase
    {
        #region Window Variables
        public SalBoolean bCheckedValidToday = false;
        public SalString lsWarning = "";
        public SalString lsEmpMsg = "";
        public SalString lsTimeReportWarning = "";
        protected SalString sDataSubjectKeyRef = "";
        protected SalString sDataSubjectEnable = "FALSE";
        protected static SalString sDataSubjectDb = "EMPLOYEE";

        #region Data Transfer for Labor Class Employee
        protected SalBoolean bPopulateEmployee = false;
        protected SalString sDTCompanyId = "";
        protected SalString sDTEmployeeId = "";
        #endregion

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public tbwCompanyEmp()
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
        public new static tbwCompanyEmp FromHandle(SalWindowHandle handle)
        {
            return ((tbwCompanyEmp)SalWindow.FromHandle(handle, typeof(tbwCompanyEmp)));
        }
        #endregion

        #region Methods

        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalBoolean __RunForm(SalNumber nWhat)
        {
            #region Local Variables
            SalString sSourceName = "";
            SalArray<SalString> sItemNames = new SalArray<SalString>();
            SalWindowHandle hWndSource = SalWindowHandle.Null;
            SalArray<SalWindowHandle> hWndItems = new SalArray<SalWindowHandle>();
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        // Check if datasource is dirty
                        if (Sal.SendMsg(this, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceIsDirty, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0))
                        {
                            // Datasource is dirty, operation is not allowed
                            return false;
                        }
                        if (!(Sal.TblAnyRows(this, Sys.ROW_Selected, 0)))
                        {
                            return false;
                        }
                        return Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("frmPersonInfo"));

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        Sal.WaitCursor(true);
                        sSourceName = "COMPANY_EMP";
                        hWndSource = this;
                        sItemNames[0] = "PERSON_ID";
                        hWndItems[0] = colsPersonId;
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init(sSourceName, hWndSource, sItemNames, hWndItems);
                        SessionNavigate(Pal.GetActiveInstanceName("frmPersonInfo"));
                        Sal.WaitCursor(false);
                        return true;
                }
                return false;
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
            #region Actions
            using (new SalContext(this))
            {
                if (sMethod == "mnuRunDetailForm")
                {
                    switch (nWhat)
                    {
                        case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                            return Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("frmPersonInfo"));

                        case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                            return __RunForm(nWhat);
                    }
                }
                else if (sMethod == "PopulateData")
                {
                    return PopulateData(nWhat);
                }
                else if (sMethod == "SetEmployeeData")
                {
                    return SetEmployeeData();
                }
                else
                {
                    return false;
                }
            }

            return 0;
            #endregion
        }

        protected virtual SalNumber SetEmployeeData()
        {
            #region Actions
            //Where clause will be set in DataSourcePopulateIt according to these set values
            bPopulateEmployee = true;
            sDTCompanyId = frmCompany.FromHandle(i_hWndParent).sDTCompanyId;
            sDTEmployeeId = frmCompany.FromHandle(i_hWndParent).sDTEmployeeId;
            return true;
            #endregion
        }


        /// <summary>
        /// </summary>
        /// <param name="nWhat"></param>
        /// <returns></returns>
        public virtual SalNumber PopulateData(SalNumber nWhat)
        {
            #region Actions
            using (new SalContext(this))
            {
                switch (nWhat)
                {
                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                        return (i_nDataSourceState == Ifs.Fnd.ApplicationForms.Const.DATASOURCE_Query) || (i_nDataSourceState == Ifs.Fnd.ApplicationForms.Const.DATASOURCE_Empty);

                    case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                        return DataSourcePopulateIt(0);
                }
                return false;
            }
            #endregion
        }

        /// <summary>
        /// Applications and the framework call the DataSourcePopulate function.
        /// </summary>
        /// <param name="nParam"></param>
        /// <returns></returns>
        public new SalBoolean DataSourcePopulateIt(SalNumber nParam)
        {
            #region Local Variables
            SalString lsUserWhere = "";
            SalString CurrentIntervalSelection = "";
            SalString CurrentIntervalSelectionHangOn = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                // If Data has been Transferred from Labor Class Employee then populate the Employees window
                // with the correct company employee only
                if (bPopulateEmployee && sDTCompanyId != SalString.Null && sDTEmployeeId != SalString.Null)
                {
                    i_lsUserWhere = "COMPANY = '" + sDTCompanyId + "' AND EMPLOYEE_ID = '" + sDTEmployeeId + "'";
                    bPopulateEmployee = false;
                }
                else
                {
                    CurrentIntervalSelection = " EXPIRE_DATE > SYSDATE OR EXPIRE_DATE IS NULL";
                    CurrentIntervalSelectionHangOn = " and (EXPIRE_DATE > SYSDATE OR EXPIRE_DATE IS NULL)";
                    if (bCheckedValidToday)
                    {
                        lsUserWhere = CurrentIntervalSelection;
                    }
                    if (lsUserWhere != Ifs.Fnd.ApplicationForms.Const.strNULL)
                    {
                        if (i_lsUserWhere == Ifs.Fnd.ApplicationForms.Const.strNULL)
                        {
                            i_lsUserWhere = lsUserWhere;
                        }
                        else
                        {
                            i_lsUserWhere = i_lsUserWhere + CurrentIntervalSelectionHangOn;
                        }
                    }
                }

                return ((cTableManager)this).DataSourcePopulateIt(nParam);
            }
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual SalBoolean CheckEmpExpDates()
        {
            #region Local Variables
            SalNumber nOldRow = 0;
            SalNumber nRow = 0;
            cMessage EmpMsg = new cMessage();
            SalBoolean bRes = false;
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                nOldRow = Sal.TblQueryContext(i_hWndSelf);
                nRow = Sys.TBL_MinRow;
                bRes = true;
                EmpMsg.Construct();
                while (true)
                {
                    if (Sal.TblFindNextRow(i_hWndSelf, ref nRow, (Sys.ROW_Edited | Sys.ROW_New), (Sys.ROW_MarkDeleted | Sys.ROW_UnusedFlag2)))
                    {
                        Sal.TblSetContext(i_hWndSelf, nRow);
                        EmpMsg.AddAttribute("EMP_ID", colsEmployeeId.Text);
                        EmpMsg.AddAttribute("EXP_DATE", SalString.FromHandle(Sal.SendMsg(coldExpireDate, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueGet, 0, 0)));
                    }
                    else
                    {
                        break;
                    }
                }
                Sal.TblSetContext(i_hWndSelf, nOldRow);
                lsEmpMsg = EmpMsg.Pack();

                using (SignatureHints hints = SignatureHints.NewContext())
                {
                    hints.Add("Company_Emp_API.Check_Expire_Date_All__", System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                    hints.Add("Company_Emp_API.Check_Expire_Date_Time_Rep__", System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                    bRes = DbPLSQLBlock(cSessionManager.c_hSql, "BEGIN &AO.Company_Emp_API.Check_Expire_Date_All__(:i_hWndFrame.tbwCompanyEmp.lsWarning,\r\n" +
                        "					   			           	           :i_hWndFrame.tbwCompanyEmp.lsEmpMsg,\r\n" +
                        "					   			                           :i_hWndFrame.tbwCompanyEmp.colsCompany);\r\n" +
                        "				        &AO.Company_Emp_API.Check_Expire_Date_Time_Rep__(:i_hWndFrame.tbwCompanyEmp.lsTimeReportWarning,\r\n" +
                        "					   			           	                       :i_hWndFrame.tbwCompanyEmp.lsEmpMsg,\r\n" +
                        "					   			                                       :i_hWndFrame.tbwCompanyEmp.colsCompany);\r\n" +
                        "			            END;");
                }
                if (bRes)
                {
                    if (lsWarning != SalString.Null)
                    {
                        if (Ifs.Fnd.ApplicationForms.Int.AlertBox(lsWarning, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Warning, Ifs.Fnd.ApplicationForms.Const.WARNING_YesNo) == Sys.IDNO)
                        {
                            return false;
                        }
                    }
                    if (lsTimeReportWarning != SalString.Null)
                    {
                        if (Ifs.Fnd.ApplicationForms.Int.AlertBox(lsTimeReportWarning, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Warning, Ifs.Fnd.ApplicationForms.Const.WARNING_YesNo) == Sys.IDNO)
                        {
                            return false;
                        }
                    }
                    return true;
                }
                return false;
            }
            #endregion
        }

        public virtual void HandleDataSubjectConsentColumns()
        {
            #region Actions
            DbPLSQLBlock(@"{0} := &AO.Data_Subject_API.Get_Personal_Data_Managemen_Db({1});", this.QualifiedVarBindName("sDataSubjectEnable"), this.QualifiedVarBindName("sDataSubjectDb"));
            if (sDataSubjectEnable == "TRUE")
            {
                colValidDataProcessingPurpose.Visible = true;
                cmdManageDataProcessingPurposes.Visible = true;
            }
            else
            {
                colValidDataProcessingPurpose.Visible = false;
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
        private void tbwCompanyEmp_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_Create:
                    this.tbwCompanyEmp_OnSAM_Create(sender, e);
                    break;
            }
            #endregion
        }

        /// <summary>
        /// SAM_Create event handler.
        /// </summary>
        /// <param name="message"></param>
        private void tbwCompanyEmp_OnSAM_Create(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            Sal.SendClassMessage(Sys.SAM_Create, Sys.wParam, Sys.lParam);
            if (Ifs.Fnd.ApplicationForms.Int.QualifiedItemNameGet(Ifs.Fnd.ApplicationForms.Int.GetParent(this.i_hWndSelf)) == Pal.GetActiveInstanceName("frmCompany"))
            {
                frmCompany.FromHandle(Ifs.Fnd.ApplicationForms.Int.GetParent(this.i_hWndSelf)).bCompanyEmpCreated = true;
            }
            #endregion
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
        public override SalNumber vrtUserMethod(SalNumber nWhat, SalString sMethod)
        {
            return this.UserMethod(nWhat, sMethod);
        }

        public override SalNumber vrtFrameActivate()
        {
            #region Actions
            HandleDataSubjectConsentColumns();
            return base.vrtFrameActivate();
            #endregion
        }
        #endregion

        #region Event Handlers

        private void menuItem__Details_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            // TODO: Rewrite command event handler not to use UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            ((FndCommand)sender).Enabled = Sal.SendMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, ((SalString)"mnuRunDetailForm").ToHandle());
        }

        private void menuItem__Details_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            // TODO: Rewrite command event handler not to make use of UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            Ifs.Fnd.ApplicationForms.Int.PostMessage(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, "mnuRunDetailForm");
        }

        private void menuItem__Only_Inquire(object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            // TODO: Rewrite command event handler not to use UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            ((FndCommand)sender).Checked = bCheckedValidToday;
            ((FndCommand)sender).Enabled = Sal.SendMsg(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, ((SalString)"PopulateData").ToHandle());
        }

        private void menuItem__Only_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            // TODO: Rewrite command event handler not to make use of UserMethod.
            // Place the logic in UserMethod directly in this event handler.
            if (bCheckedValidToday)
            {
                bCheckedValidToday = false;
            }
            else
            {
                bCheckedValidToday = true;
            }
            Ifs.Fnd.ApplicationForms.Int.PostMessage(Sys.hWndForm, Ifs.Fnd.ApplicationForms.Const.PM_UserMethod, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, "PopulateData");
        }
        private void cmdManageDataProcessingPurposes_Inquire(object sender, FndCommandInquireEventArgs e)
        {
            #region Local Variable
            SalNumber nRow = Sys.TBL_MinRow;
            #endregion

            #region Action
            if (!(Sal.TblAnyRows(this, Sys.ROW_Selected, 0)))
            {
                ((FndCommand)sender).Enabled = false;
                return;
            }
            nRow = Sys.TBL_MinRow;
            if (Sal.TblFindNextRow(this, ref nRow, Sys.ROW_Selected, 0))
            {
                if (Sal.TblFindNextRow(this, ref nRow, Sys.ROW_Selected, 0))
                {
                    ((FndCommand)sender).Enabled = false;
                    return;
                }
            }
            if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("Data_Subject_Consent_Oper_API.Consent_Action")) || sDataSubjectEnable == "FALSE")
            {
                ((FndCommand)sender).Enabled = false;
                return;
            }
            ((FndCommand)sender).Enabled = true;
            #endregion
        }

        private void cmdManageDataProcessingPurposes_Execute(object sender, FndCommandExecuteEventArgs e)
        {
            #region Action
            DbPLSQLBlock(@"{0} := &AO.Data_Subject_Consent_API.Get_Subject_Key_Ref({1} IN,{2} IN,{3} IN);", this.QualifiedVarBindName("sDataSubjectKeyRef"), this.QualifiedVarBindName("sDataSubjectDb"), this.colsCompany.QualifiedBindName, this.colsEmployeeId.QualifiedBindName);
            if (dlgPersonalDataConsent.ModalDialog(this, this.sDataSubjectKeyRef, sDataSubjectDb, colsName.Text) == Sys.IDOK)
            {
                Sal.SendMsg(i_hWndSelf, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceRefresh, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
                return;
            }
            #endregion
        }
        #endregion

    }
}
