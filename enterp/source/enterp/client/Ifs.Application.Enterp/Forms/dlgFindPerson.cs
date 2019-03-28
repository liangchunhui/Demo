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
/// DATE      SIGN    HISTORY
/// --------  ------  --------------------------------------------------------------------------------------------------------------------------------------
/// 150825    Hairlk  AFT-1691, Modified ConstructWhereStmt to only supplier contacts when calling from dlgAddSupplierContact dialog box
/// 150819    Wahelk  BLU-1114, Modified ConstructWhereStmt to filter first name and last name based on exact given query
/// 14/09/16  JanWse  PRSC-2365, Created
/// --------------------------------------------------------------------------------------------------------------------------------------------------

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
    public partial class dlgFindPerson : cDialog
    {
        #region Member Variables
        protected SalString sFirstName = Ifs.Fnd.ApplicationForms.Const.strNULL;
        protected SalString sLastName = Ifs.Fnd.ApplicationForms.Const.strNULL;
        protected SalString sPersonId = Ifs.Fnd.ApplicationForms.Const.strNULL;
        protected SalString sStartedFromCustomer = Ifs.Fnd.ApplicationForms.Const.strNULL;
		protected SalString sStartedFromSupplier = Ifs.Fnd.ApplicationForms.Const.strNULL;
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        protected dlgFindPerson()
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
        public static SalNumber ModalDialog( Control owner )
        {
            dlgFindPerson dlg = DialogFactory.CreateInstance<dlgFindPerson>();
            SalNumber ret = dlg.ShowDialog( owner );
            return ret;
        }

        /// <summary>
        /// Returns the object instance associated with the window handle.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public new static dlgFindPerson FromHandle( SalWindowHandle handle )
        {
            return ( (dlgFindPerson)SalWindow.FromHandle( handle, typeof( dlgFindPerson ) ) );
        }

        #endregion

        #region Properties

        #endregion

        #region Methods
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public new SalBoolean FrameStartupUser()
        {
            #region Actions
            using ( new SalContext( this ) )
            {
                if ( Ifs.Fnd.ApplicationForms.Var.DataTransfer.RecCountGet() > 0 )
                {
                    SalArray<SalString> items = new SalArray<SalString>();
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet( "FIRST_NAME", items );
                    sFirstName = items[0];

                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet( "LAST_NAME", items );
                    sLastName = items[0];

                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet( "STARTED_FROM_CUSTOMER", items );
                    sStartedFromCustomer = items[0];

					Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("STARTED_FROM_SUPPLIER", items);
					sStartedFromSupplier = items[0];

                    if ( sFirstName.Length == 0 && sLastName.Length == 0 )
                    {
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
                        return true;
                    }

                    dfsFirstName.Text = sFirstName;
                    dfsLastName.Text = sLastName;
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();

                    SalString sWhereStmt = ConstructWhereStmt( sFirstName, sLastName );

                    tblFindPerson.DataSourceUserWhere( Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, sWhereStmt.ToHandle() );
                    tblFindPerson.DataSourcePopulateIt( Ifs.Fnd.ApplicationForms.Const.POPULATE_Single );
                    return base.vrtFrameStartupUser();
                }

                return true;

            }
            #endregion
        }

        protected virtual void SelectResult()
        {
            DialogResult = DialogResult.None;
            SalNumber nRow = -1;
            Sal.TblFindNextRow(tblFindPerson, ref nRow, Sys.ROW_Selected, 0);
            Sal.TblGetColumnText(tblFindPerson, Sal.TblQueryColumnID(tblFindPerson_colsPersonId), ref sPersonId);
            Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
            Ifs.Fnd.ApplicationForms.Var.DataTransfer.SourceNameSet(Pal.GetActiveInstanceName("dlgAddContact"));
            Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemAdd("PERSON_ID", new SalArray<SalString>() { sPersonId });
            Sal.EndDialog(this, Sys.IDOK);
        }

        SalString ConstructWhereStmt(SalString sFirstName, SalString sLastName)
        {
            SalString sWhereStmt = Ifs.Fnd.ApplicationForms.Const.strNULL;

            sFirstName = sFirstName.ToUpper();
            sLastName = sLastName.ToUpper();

            if (sFirstName.Length > 0 && sWhereStmt.Length == 0)
                sWhereStmt = "UPPER(first_name) like '" + sFirstName + "'";
            else if (sFirstName.Length > 0 && sWhereStmt.Length > 0)
                sWhereStmt += " AND UPPER(first_name) like '" + sFirstName + "'";

            if (sLastName.Length > 0 && sWhereStmt.Length == 0)
                sWhereStmt = "UPPER(last_name) like '" + sLastName + "'";
            else if (sLastName.Length > 0 && sWhereStmt.Length > 0)
                sWhereStmt += " AND UPPER(last_name) like '" + sLastName + "'";

            // Check blocked for use and able to use as contact if opened from customer form
            if (sStartedFromCustomer == "TRUE" && sWhereStmt.Length == 0)
                sWhereStmt = "CUSTOMER_CONTACT_DB ='TRUE' AND BLOCKED_FOR_USE_DB ='FALSE'";
            else if (sStartedFromCustomer == "TRUE" && sWhereStmt.Length > 0)
                sWhereStmt += " AND CUSTOMER_CONTACT_DB ='TRUE' AND BLOCKED_FOR_USE_DB ='FALSE'";

			if (sStartedFromSupplier == "TRUE" && sWhereStmt.Length == 0)
				sWhereStmt = "SUPPLIER_CONTACT_DB ='TRUE' AND BLOCKED_FOR_USE_SUPPLIER_DB ='FALSE'";
			else if (sStartedFromSupplier == "TRUE" && sWhereStmt.Length > 0)
				sWhereStmt += " AND SUPPLIER_CONTACT_DB ='TRUE' AND BLOCKED_FOR_USE_SUPPLIER_DB ='FALSE'";

            return sWhereStmt;
        }
        #endregion

        #region Overrides
        public override SalBoolean vrtFrameStartupUser()
        {
            return this.FrameStartupUser();
        }
        #endregion

        #region Window Actions
        private void tblFindPerson_WindowActions( object sender, WindowActionsEventArgs e )
        {
            SalNumber nRow = -1;
            switch ( e.ActionType )
            {
                case Sys.SAM_DoubleClick:
                case Sys.SAM_RowHeaderDoubleClick:
                    SelectResult();
                    break;
            }
        }
        #endregion

        #region Event Handlers

        private void commandOk_Inquire( object sender, Ifs.Fnd.Windows.Forms.FndCommandInquireEventArgs e )
        {
            SalNumber nRow = Sys.TBL_MinRow;
            ( (Ifs.Fnd.Windows.Forms.FndCommand)sender ).Enabled = tblFindPerson.FindNextRow( ref nRow, Sys.ROW_Selected, 0 );
        }

        private void commandOk_Execute( object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e )
        {
            SelectResult();
        }

        private void commandCancel_Execute( object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e )
        {
            // Dialog class have CancelButton set to run this logic even if the user close the dialog trough the esc button.
            // PPJ dialog close trough Sal.EndDialog so we set DialogResult to prevent the dialog from closing premature.
            DialogResult = DialogResult.None;
            Sal.EndDialog( this, Sys.IDCANCEL );
        }

        private void commandFind_Execute( object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e )
        {
            if ( Sal.GetFocus() == tblFindPerson )
            {
                SelectResult();
                return;
            }

            SalString sWhereStmt = ConstructWhereStmt( dfsFirstName.Text, dfsLastName.Text );

            tblFindPerson.DataSourceUserWhere( Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, sWhereStmt.ToHandle() );
            tblFindPerson.DataSourcePopulateIt( Ifs.Fnd.ApplicationForms.Const.POPULATE_Single );
        }
        #endregion

        #region Menu Event Handlers

        #endregion

 

    }
}
