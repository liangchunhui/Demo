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

namespace Ifs.Application.Enterp
{

    /// <summary>
    /// </summary>
    public partial class dlgCopyToCompanies : cDialogBox
    {
        #region Member Variables
        public SalString sCompany = "";
        public SalString sLu = "";
        public SalString sType = "";
        public SalString sRunInBackground = "";
        public SalString i_sOperatorDbList = "";
        public SalString i_sOperatorClientList = "";
        protected SalArray<SalString> sCompanyList = new SalArray<SalString>();
        protected SalArray<SalString> sReplaceExistList = new SalArray<SalString>();
        protected SalArray<SalString> i_sOperatorDbValues = new SalArray<SalString>();
        protected SalArray<SalString> i_sOperatorClientValues = new SalArray<SalString>();
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        protected dlgCopyToCompanies()
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
        public static SalNumber ModalDialog(Control owner)
        {
            dlgCopyToCompanies dlg = DialogFactory.CreateInstance<dlgCopyToCompanies>();
            SalNumber ret = dlg.ShowDialog(owner);
            return ret;
        }

        public static SalNumber ModalDialog(Control owner, SalString sCompany, SalString sType, SalString sLu, ref SalArray<SalString> sCompanyList, ref SalArray<SalString> sReplaceExistList, ref SalString sRunInBackground)
        {
            dlgCopyToCompanies dlg = DialogFactory.CreateInstance<dlgCopyToCompanies>();
            dlg.sCompanyList = sCompanyList;
            dlg.sReplaceExistList = sReplaceExistList;
            dlg.sCompany = sCompany;
            dlg.sType = sType;
            dlg.sLu = sLu;
            dlg.sRunInBackground = sRunInBackground;
            SalNumber ret = dlg.ShowDialog(owner);
            sCompanyList = dlg.sCompanyList;
            sReplaceExistList = dlg.sReplaceExistList;
            sRunInBackground = dlg.sRunInBackground;
            return ret;
        }
        /// <summary>
        /// Returns the object instance associated with the window handle.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public new static dlgCopyToCompanies FromHandle(SalWindowHandle handle)
        {
            return ((dlgCopyToCompanies)SalWindow.FromHandle(handle, typeof(dlgCopyToCompanies)));
        }

        #endregion

        #region Properties

        #endregion

        #region Methods

        private void tblSelectCompany_OnSAM_CreateComplete(object sender, WindowActionsEventArgs e)
        {
            #region Local Variables
            SalNumber nRow = Sys.TBL_MinRow;
            #endregion

            #region Action
            e.Handled = true;
            if(Sal.SendClassMessage(Sys.SAM_CreateComplete, Sys.wParam, Sys.lParam))
            {
                if (sType == "MANUAL")
                {
                    //while (Sal.TblFindNextRow(this.tblSelectCompany, ref nRow, 0, 0))
                    //{
                    //    Sal.TblSetContext(this.tblSelectCompany, nRow);
                    //    tblSelectCompany_colInclude.Text = "FALSE";
                    //}
                    lblManual.Visible = true;
                    lblAuto.Visible = false;
                }
                else
                {
                    lblManual.Visible = false;
                    lblAuto.Visible = true;
                }
            }
            e.Return = true;
            #endregion
        }

        private void tblSelectCompany_OnPM_DataRecordNew(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam == Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire)
            {
                e.Return = false;
            }
            #endregion
        }

        private void tblSelectCompany_OnPM_DataSourcePopulate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;

            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Sys.wParam, Sys.lParam))
            {
                SalNumber nRow = Sys.TBL_MinRow;
                if (sType == "MANUAL")
                {
                    nRow = Sys.TBL_MinRow;
                    while (Sal.TblFindNextRow(this.tblSelectCompany, ref nRow, 0, 0))
                    {
                        Sal.TblSetContext(this.tblSelectCompany, nRow);
                        if (this.tblSelectCompany_colUpdateExist.Text == i_sOperatorClientValues[i_sOperatorDbValues.Find("MODIFICATION_ONLY")]||this.tblSelectCompany_colUpdateExist.Text =="")
                        {
                            this.tblSelectCompany_colUpdateExist.Text = i_sOperatorClientValues[i_sOperatorDbValues.Find("NO_UPDATE")];
                        }
                    }
                    
                }
                else
                {
                    nRow = Sys.TBL_MinRow;
                    while (Sal.TblFindNextRow(this.tblSelectCompany, ref nRow, 0, 0))
                    {
                        Sal.TblSetContext(this.tblSelectCompany, nRow);
                        if (this.tblSelectCompany_colUpdateExist.Text == "")
                        {
                            this.tblSelectCompany_colUpdateExist.Text = i_sOperatorClientValues[i_sOperatorDbValues.Find("NO_UPDATE")];
                        }
                    }
                }
                e.Return = true;
            }
            e.Return = false;
            #endregion
        }

        //private void tblSelectCompany_colUpdateExist_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        //{
        //    e.Handled = true;
        //    if (tblSelectCompany_colInclude.Text == "TRUE")
        //    {
        //        e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldEnabled;
        //    }
        //    else
        //    {
        //        e.Return = Ifs.Fnd.ApplicationForms.Const.EDITSTATEFieldNotEnabled;
        //    }
        //}

        private void tblSelectCompany_colInclude_OnPM_DataItemQueryEnabled(object sender, WindowActionsEventArgs e)
        {
            if (tblSelectCompany_colInclude.Text == "FALSE")
            {
                //tblSelectCompany_colUpdateExist.Text = "FALSE";
            }
        }

        #endregion

        #region Overrides
        public override SalBoolean vrtFrameStartupUser()
        {
            return this.FrameStartupUser();
        }

        public new SalBoolean FrameStartupUser()
        {
            #region Local Variables
            SalString sOut = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                ((cDialogBox)this).FrameStartupUser();

                DbPLSQLBlock(@"	&AO.Sync_Update_Method_Type_API.Enumerate_Db({0} OUT); " +
                        "		&AO.Sync_Update_Method_Type_API.Enumerate({1} OUT );",
                                this.QualifiedVarBindName("i_sOperatorDbList"),
                                this.QualifiedVarBindName("i_sOperatorClientList"));
                if (i_sOperatorDbList != Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    i_sOperatorClientValues.SetUpperBound(0, -1);
                    i_sOperatorDbValues.SetUpperBound(0, -1);
                    i_sOperatorClientList.Tokenize(Ifs.Fnd.ApplicationForms.Const.strNULL, Ifs.Fnd.ApplicationForms.Var.g_sCHAR_US, i_sOperatorClientValues);
                    i_sOperatorDbList.Tokenize(Ifs.Fnd.ApplicationForms.Const.strNULL, Ifs.Fnd.ApplicationForms.Var.g_sCHAR_US, i_sOperatorDbValues);
                }
            }
            Sal.SendMsg(this.tblSelectCompany, Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
            return false;
            #endregion
        }

        #endregion

        #region Window Actions

        private void tblSelectCompany_WindowActions(object sender, WindowActionsEventArgs e)
        {
            switch (e.ActionType)
            {
                case Sys.SAM_CreateComplete:
                    this.tblSelectCompany_OnSAM_CreateComplete(sender, e);
                    break;
                case Ifs.Fnd.ApplicationForms.Const.PM_DataRecordNew:
                    this.tblSelectCompany_OnPM_DataRecordNew(sender, e);
                    break;
                case Ifs.Fnd.ApplicationForms.Const.PM_DataSourcePopulate:
                    this.tblSelectCompany_OnPM_DataSourcePopulate(sender, e);
                    break;
            }
        }

        private void tblSelectCompany_colUpdateExist_WindowActions(object sender, WindowActionsEventArgs e)
        {
            switch (e.ActionType)
            {
                //case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                //    this.tblSelectCompany_colUpdateExist_OnPM_DataItemQueryEnabled(sender, e);
                //    break;

                case Sys.SAM_DropDown:
                    this.tblSelectCompany_colUpdateExist_OnSAM_DropDown(sender, e);
                    break;

            }
        }

        private void tblSelectCompany_colUpdateExist_OnSAM_DropDown(object sender, WindowActionsEventArgs e)
        {
            e.Handled = true;
            tblSelectCompany_colUpdateExist.LookupInit();
            if (sType == "MANUAL")
            {
                Sal.ListDelete(this.tblSelectCompany_colUpdateExist.i_hWndSelf, 1);
            }
            e.Return = true;
            return;
        }

        #endregion

        private void cbSelect_CheckedChanged(object sender, EventArgs e)
        {
            Sal.WaitCursor(true);
            SalNumber nRow = Sys.TBL_MinRow;
            if (cbSelect.Value == "TRUE")
            {
                while (Sal.TblFindNextRow(tblSelectCompany, ref nRow, Sys.ROW_Selected, 0))
                {
                    Sal.TblSetContext(tblSelectCompany, nRow);
                    tblSelectCompany_colInclude.Text = "TRUE";
                }
            }
            else
            {
                while (Sal.TblFindNextRow(tblSelectCompany, ref nRow, Sys.ROW_Selected, 0))
                {
                    Sal.TblSetContext(tblSelectCompany, nRow);
                    tblSelectCompany_colInclude.Text = "FLASE";
                }
            }
            Sal.WaitCursor(false);
        }

        private void cbReplace_CheckedChanged(object sender, EventArgs e)
        {
            Sal.WaitCursor(true);
            SalNumber nRow = Sys.TBL_MinRow;
            if (cbReplace.Value == "TRUE")
            {
                while (Sal.TblFindNextRow(tblSelectCompany, ref nRow, Sys.ROW_Selected, 0))
                {
                    Sal.TblSetContext(tblSelectCompany, nRow);
                    if (tblSelectCompany_colInclude.Text == "TRUE")
                    {
                        tblSelectCompany_colUpdateExist.Text = "TRUE";
                    }
                }
            }
            else
            {
                while (Sal.TblFindNextRow(tblSelectCompany, ref nRow, Sys.ROW_Selected, 0))
                {
                    Sal.TblSetContext(tblSelectCompany, nRow);
                    tblSelectCompany_colUpdateExist.Text = "FLASE";
                }
            }
            Sal.WaitCursor(false);
        }


        #region Event Handlers

        private void commandOk_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            // Dialog class have AcceptButton set to run this logic if the user ends the dialog using the Return button.
            // PPJ dialog close trough Sal.EndDialog so we set DialogResult to prevent the dialog from closing premature.

            #region Local Variables
            SalNumber nRow = Sys.TBL_MinRow;
            SalString sFieldChar = ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_US).ToCharacter();
            SalNumber nCount = 0;
            #endregion
            
            #region Actions
            DialogResult = DialogResult.None;
            Sal.WaitCursor(true);

            sRunInBackground = cbRunInBackground.Value;
            while (Sal.TblFindNextRow(this.tblSelectCompany, ref nRow, 0, 0))
            {
                Sal.TblSetContext(this.tblSelectCompany, nRow);
                if (tblSelectCompany_colInclude.Text == "TRUE")
                {
                    sCompanyList[nCount] = this.tblSelectCompany_colsCompany.Text;
                    sReplaceExistList[nCount] = i_sOperatorDbValues[i_sOperatorClientValues.Find(this.tblSelectCompany_colUpdateExist.Text)];                 
                    nCount++;
                }
            }

            Sal.WaitCursor(false);
            Sal.EndDialog(this, Sys.IDOK);
            #endregion
        }

        #endregion

        private void tblSelectCompany_colInclude_WindowActions(object sender, WindowActionsEventArgs e)
        {
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemQueryEnabled:
                    this.tblSelectCompany_colInclude_OnPM_DataItemQueryEnabled(sender, e);
                    break;
                //case Sys.SAM_Click:
                //    e.Handled = true;
                //    //Sal.SetFieldEdit(this.tblSelectCompany_colInclude, false);
                //    Sal.TblSetTableFlags(this.tblSelectCompany_colInclude,)
                //    e.Return = false;
                //    break;

            }
        }

        #region Menu Event Handlers

        #endregion
    }
}
