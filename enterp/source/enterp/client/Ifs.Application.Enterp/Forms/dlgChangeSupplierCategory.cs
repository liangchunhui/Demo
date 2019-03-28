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
// Date     By      Notes
// -----    ------  ---------------------------------------------------------------------------------
// 150821   RoJalk  ORA-1227, Modified dfsTemplateSupplierId_OnPM_DataItemLovDone and assigned a value to dfsTemplateSupplierName.
// 150702   RoJalk  ORA-782, Created.
// 170404   Dakplk  STRFI-5232, Merged Bug  134737, Modified ValidateFields().
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
    public partial class dlgChangeSupplierCategory : cDialog
    {
        
        #region Window Parameters
        public SalString sNewSupplierId;
        public SalString sNewSupplierName;
        public SalString sAssociationNo;
        protected SalWindowHandle hWndFocus;
        protected SalNumber nNum = 0;
        protected SalArray<SalString> sRecords = new SalArray<SalString>();
        protected SalArray<SalString> sUnits = new SalArray<SalString>();
        protected SalString sAssociationNoExist = "FALSE";
        #endregion

        #region Member Variables
        protected SalString sOverwritePurchData = "FALSE";
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        protected dlgChangeSupplierCategory()
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
        public static SalNumber ModalDialog(Control owner, SalString sNewSupplierId, SalString sNewSupplierName, SalString sAssociationNo)
        {
            dlgChangeSupplierCategory dlg = DialogFactory.CreateInstance<dlgChangeSupplierCategory>();
            dlg.sNewSupplierId   = sNewSupplierId;
            dlg.sNewSupplierName = sNewSupplierName;
            dlg.sAssociationNo   = sAssociationNo;
            SalNumber ret = dlg.ShowDialog(owner);
            return ret;
        }

        /// <summary>
        /// Returns the object instance associated with the window handle.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public new static dlgChangeSupplierCategory FromHandle(SalWindowHandle handle)
        {
            return ((dlgChangeSupplierCategory)SalWindow.FromHandle(handle, typeof(dlgChangeSupplierCategory)));
        }

        #endregion

        #region Properties

        #endregion

        #region Methods

        public new SalBoolean FrameStartupUser()
        {
            #region Actions
            dfsNewSupplierId.Text   = sNewSupplierId;
            dfsNewSupplierName.Text = sNewSupplierName;
            dfsAssociationNo.Text   = sAssociationNo;
            SetCategory();
            if (!(Ifs.Fnd.ApplicationForms.Var.Security.IsViewAvailable("SUPPLIER")))
            {
                gbTemplateSupplier.DisableWindow();
            }
            else
            {
                //Fetch the user default company
                DbPLSQLBlock(@"{0}:= &AO.User_Finance_API.Get_Default_Company_Func;", dfsCompany.QualifiedBindName);
            }
            return true;
            #endregion
        }

        public virtual SalNumber SetCategory()
        {
            #region Actions
            IDictionary<string, string> namedBindVariables = new Dictionary<string, string>();
            namedBindVariables.Add("Category", dfsCategory.QualifiedBindName);
            DbPLSQLBlock(@"{Category} := &AO.Supplier_Info_Category_API.Decode('SUPPLIER');", namedBindVariables);
            return 0;
            #endregion
        }

        public virtual SalBoolean ValidateFields()
        {
            #region Actions
            sAssociationNoExist = "FALSE";
            IDictionary<string, string> namedBindVariables = new Dictionary<string, string>();
            namedBindVariables.Add("AssociationNoExist", QualifiedVarBindName("sAssociationNoExist"));
            namedBindVariables.Add("AssociationNo",      dfsAssociationNo.QualifiedBindName);
            if (DbPLSQLBlock(@"{AssociationNoExist} := &AO.Association_Info_API.Association_No_Exist({AssociationNo}, 'SUPPLIER');", namedBindVariables))
            {
                if (sAssociationNoExist == "TRUE" && dfsAssociationNo.Text != sAssociationNo)
                {
                    if (Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_WarnSameAssocNo, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Warning, Ifs.Fnd.ApplicationForms.Const.WARNING_OkCancel) == Sys.IDCANCEL)
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
            #endregion
        }
        #endregion

        #region Overrides

        public override SalBoolean vrtFrameStartupUser()
        {
            return this.FrameStartupUser();
        }

        #endregion

        #region Window Actions

        #endregion

        #region Event Handlers

        private void commandList_Inquire(object sender, FndCommandInquireEventArgs e)
        {
            e.Handled = true;
            hWndFocus = Ifs.Fnd.ApplicationForms.Int.PalGetFocus();
            ((FndCommand)sender).Enabled = Sal.SendMsg(hWndFocus, Ifs.Fnd.ApplicationForms.Const.PM_DataItemLov, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0);
        }

        private void commandList_Execute(object sender, FndCommandExecuteEventArgs e)
        {
            e.Handled = true;
            Sal.SendMsg(hWndFocus, Ifs.Fnd.ApplicationForms.Const.PM_DataItemLov, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
        }

        private void commandOk_Inquire(object sender, Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = (dfsNewSupplierName.Text != Ifs.Fnd.ApplicationForms.Const.strNULL);
        }

        private void commandOk_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            // Dialog class have AcceptButton set to run this logic if the user ends the dialog using the Return button.
            // PPJ dialog close trough Sal.EndDialog so we set DialogResult to prevent the dialog from closing premature.
            DialogResult = DialogResult.None;

            if (!(ValidateFields()))
            {
                return;
            }
            if (cbOverwriteData.Checked)
            {
                sOverwritePurchData = "TRUE";
            }
            else
            {
                sOverwritePurchData = "FALSE";
            }
            Sal.WaitCursor(true);
            IDictionary<string, string> namedBindVariables = new Dictionary<string, string>();
            namedBindVariables.Add("NewSupplierId",      dfsNewSupplierId.QualifiedBindName);
            namedBindVariables.Add("NewSupplierName",    dfsNewSupplierName.QualifiedBindName);
            namedBindVariables.Add("AssociationNo",      dfsAssociationNo.QualifiedBindName);
            namedBindVariables.Add("TemplateSupplierId", dfsTemplateSupplierId.QualifiedBindName);
            namedBindVariables.Add("Company",            dfsCompany.QualifiedBindName);
            namedBindVariables.Add("OverwritePurchData", QualifiedVarBindName("sOverwritePurchData"));
            if (DbPLSQLTransaction(@"&AO.Supplier_Info_General_API.Change_Supplier_Category__({NewSupplierId}       IN,
                                                                                              {NewSupplierName}     IN,
                                                                                              {AssociationNo}       IN,
                                                                                              {TemplateSupplierId}  IN,
                                                                                              {Company}             IN,
                                                                                              {OverwritePurchData}  IN );", namedBindVariables))
            {
                Sal.WaitCursor(false);
                Sal.EndDialog(this, Sys.IDOK);
            }
            else
            {
                Sal.WaitCursor(false);
            }

            
        }

        private void commandCancel_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            // Dialog class have CancelButton set to run this logic even if the user close the dialog trough the esc button.
            // PPJ dialog close trough Sal.EndDialog so we set DialogResult to prevent the dialog from closing premature.
            DialogResult = DialogResult.None;

            Sal.EndDialog(this, Sys.IDCANCEL);
        }

        private void dfsTemplateSupplierId_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovDone:
                    this.dfsTemplateSupplierId_OnPM_DataItemLovDone(sender, e);
                    break;
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.dfsTemplateSupplierId_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        private void dfsTemplateSupplierId_OnPM_DataItemLovDone(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.nNum = SalString.FromHandle(Sys.lParam).Tokenize("", ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_RS).ToCharacter(), this.sRecords);
            this.nNum = this.sRecords[1].Tokenize("", ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_US).ToCharacter(), this.sUnits);
            if (this.sUnits[0] == "NAME")
            {
				Sal.SendMsg(this.dfsTemplateSupplierName, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 0, this.sUnits[1].ToHandle());
            }
            this.nNum = this.sRecords[2].Tokenize("", ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_US).ToCharacter(), this.sUnits);
            if (this.sUnits[0] == "SUPPLIER_TEMPLATE_DESC")
            {
                Sal.SendMsg(this.dfsTemplateDescription, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 0, this.sUnits[1].ToHandle());
            }
            #endregion
        }

        private void dfsTemplateSupplierId_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam)
            {
                DbPLSQLBlock(@"{0}:= &AO.Supplier_API.Get_Vendor_Name({1} IN);
                               {2}:= &AO.Supplier_API.Get_Supplier_Template_Desc({1} IN);",
                               dfsTemplateSupplierName.QualifiedBindName, dfsTemplateSupplierId.QualifiedBindName, dfsTemplateDescription.QualifiedBindName);

                if (dfsTemplateSupplierId.Text == Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    cbOverwriteData.DisableWindow();
                    cbOverwriteData.Checked = false;
                }
                else
                {
                    cbOverwriteData.EnableWindow();
                }
            }

            e.Return = Sys.VALIDATE_Ok;
            return;
            #endregion
        }

        #endregion

        #region Menu Event Handlers

        #endregion
    }
}
