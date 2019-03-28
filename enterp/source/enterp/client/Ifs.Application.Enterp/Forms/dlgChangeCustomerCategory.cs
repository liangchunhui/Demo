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
// 170104   ChJalk  STRSC-15394, Added both Ok and Cancel buttons to the warning message TEXT_CustGroupNullNotAllowed and handled it.
// 160921   JeeJlk  Bug 130939, Added dfsCustomerGroup and dfsCustomerGroupDescription to transfer Customer Order related data.
// 150722   Wahelk  BLU-961, Added dfsCompany_WindowActions to get check box deafult values when company is changed
// 150706   Wahelk  BLU-955, Modified dfsTemplateCustomerId_OnPM_DataItemValidate and cmbCustomerCategory_OnSAM_Click and FrameStartupUser
// 150603   JanWse  BLU-765, Start dlgFindCustomer from URL, handle LEAD_ID in data transfer
// 150601   JanWse  BLU-765, Find button only visible if started from Business Lead
// 150521   Wahelk  BLU-764, Removed GetPresetCustomerId from dlg and Modified FrameStartupUser
// 150520   Wahelk  BLU-714, Added method GetPresetCustomerId and used it in FrameStartupUser to get customer id value based on preset customer Id
// 150505   JanWse  BLU-152, Added a find button to start dlgFindCustomer
// 141113   MaIklk  PRSC-3536, Implemented to popup a question if association no is already exist when convering lead to customer.
// 140709   MaIklk  PRSC-1760, Created.
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
    public partial class dlgChangeCustomerCategory : cDialog
    {
        #region Member Variables
        protected SalWindowHandle hWndFocus;
        protected SalArray<SalString> sUnits = new SalArray<SalString>();
        protected SalNumber nNum = 0;
        protected SalArray<SalString> sRecords = new SalArray<SalString>();
        protected SalArray<SalString> sIIDValues = new SalArray<SalString>();
        protected cMessage IIDValues = new cMessage();
        protected SalString sFromCategory = "";
        protected SalBoolean bOrderInstalled = false;
        protected SalBoolean bOverwrite = false;
        protected SalString sChangeCustomerCategory = "TRUE";
        protected SalString sTempCustomerCategory = "";
        protected SalString sCustomerExist = "TRUE";
        protected SalString sCustomerCategory = "";
        protected SalString sAssociationNoExist = "FALSE";
        protected SalString sPresetCustomerId = "FALSE";
        protected SalString sLeadId = SalString.Empty;
        protected SalBoolean bTranferAddr = false;
        protected SalString sOverwriteOrdData = "FALSE";
        protected SalString sTransOrdAddr = "FALSE";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        protected dlgChangeCustomerCategory()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();
            cCommandButtonFind.Visible = Ifs.Fnd.ApplicationForms.Var.DataTransfer.SourceNameGet() == "BusinessLead";
        }
        #endregion

        #region System Methods/Properties

        /// <summary>
        /// Shows the modal dialog.
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        public static SalNumber ModalDialog(Control owner, ref SalBoolean bOverwrite, ref SalBoolean bTranferAddr)
        {
            dlgChangeCustomerCategory dlg = DialogFactory.CreateInstance<dlgChangeCustomerCategory>();
            SalNumber ret = dlg.ShowDialog(owner);
            bOverwrite = dlg.bOverwrite;
            bTranferAddr = dlg.bTranferAddr;
            return ret;
        }

        /// <summary>
        /// Returns the object instance associated with the window handle.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public new static dlgChangeCustomerCategory FromHandle(SalWindowHandle handle)
        {
            return ((dlgChangeCustomerCategory)SalWindow.FromHandle(handle, typeof(dlgChangeCustomerCategory)));
        }
        #endregion

        #region Properties

        #endregion

        #region Methods

        protected new SalBoolean FrameStartupUser()
        {
            #region Actions           
            GetIIDValues();
            if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.RecCountGet() > 0)
            {
                SalArray<SalString> items = new SalArray<SalString>();
                SalArray<SalString> sItemNames = new SalArray<SalString>();

                Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("CHANGE_CUSTOMER_CATEGORY", items);
                sChangeCustomerCategory = items[0];

                Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemNamesGet(sItemNames);
                if (sItemNames.Find("LEAD_ID") != -1)
                {
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("LEAD_ID", items);
                    sLeadId = items[0];
                }

                if (sChangeCustomerCategory == "FALSE")
                {
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("PRESET_CUSTOMER_ID", items);
                    sPresetCustomerId = items[0];
                    if (sPresetCustomerId == "TRUE")
                    {
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("CUSTOMER_ID", items);
                        dfsNewCustomerId.Text = items[0];
                    }
                }
                else
                {
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("CUSTOMER_ID", items);
                    dfsNewCustomerId.Text = items[0];
                    gbOrder_Related_Info.DisableWindow();
                }

                Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("CUSTOMER_NAME", items);
                dfsNewCustomerName.Text = items[0];

                Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("ASSOCIATION_NO", items);
                dfsAssociationNo.Text = items[0];

                Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("CATEGORY", items);
                sFromCategory = items[0];

                //if(Ifs.Fnd.ApplicationForms.Var.DataTransfer.

                if (sChangeCustomerCategory == "FALSE")
                {
                    dfsNewCustomerId.EditDataItemFlagSet(Ifs.Fnd.ApplicationForms.Const.FIELD_Update, true);
                    sChangeCustomerCategory = "FALSE";
                }

                Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("TITLE", items);
                if (items[0] != Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    this.Text = items[0];
                }
                cmbCustomerCategory.SetFocus();

                Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();

               
            }

            //Fetch the user default company
            DbPLSQLBlock(@"{0}:= &AO.User_Finance_API.Get_Default_Company_Func;", dfsCompany.QualifiedBindName);

            gbTemplate_Customer.DisableWindow();
            bOrderInstalled = Ifs.Fnd.ApplicationForms.Var.Security.IsViewAvailable("CUST_ORD_CUSTOMER");

            if (bOrderInstalled)
            {
                DbPLSQLBlock(@"{0}:= &AO.Company_Order_Info_API.Get_Overwrite_Ord_Rel_Data_Db({1} IN);", QualifiedVarBindName("sOverwriteOrdData"), dfsCompany.QualifiedBindName);
                DbPLSQLBlock(@"{0}:= &AO.Company_Order_Info_API.Get_Trans_Ord_Addr_Info_Tem_Db({1} IN);", QualifiedVarBindName("sTransOrdAddr"), dfsCompany.QualifiedBindName);

                this.dfsCustomerGroup.p_sLovReference = "CUSTOMER_GROUP";
                this.dfsTemplateCustomerId.p_sLovReference = "CUSTOMER_TEMPLATE_LOV";
            }

            return true;
            #endregion
        }

        protected virtual void GetIIDValues()
        {
            #region Local Variables
            SalArray<SalString> sIIDNames = new SalArray<SalString>();
            SalNumber nCurrent = 0;
            SalNumber nMax = 0;
            SalString lsStmt = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                // Write all IID values you want to get here.
                sIIDNames[0] = "Customer_Category_API.Decode('CUSTOMER')";
                sIIDNames[1] = "Customer_Category_API.Decode('PROSPECT')";
                sIIDNames[2] = "Customer_Category_API.Decode('END_CUSTOMER')";

                // Create string
                nMax = sIIDNames.GetUpperBound(1);
                nCurrent = 0;
                while (nMax > (nCurrent - 1))
                {
                    lsStmt = string.Format("{0}{1}[" + nCurrent.ToString(0) + "] := &AO.{2};", lsStmt, QualifiedVarBindName("sIIDValues"), sIIDNames[nCurrent]);
                   // lsStmt = lsStmt + sFullName + ".sIIDValues[" + nCurrent.ToString(0) + "] := &AO." + sIIDNames[nCurrent] + "; ";
                    nCurrent = nCurrent + 1;
                }

                if (DbPLSQLBlock(@"{0}", lsStmt))
                {
                    IIDValues.Construct();
                    IIDValues.AddAttribute("CUSTOMER_CATEGORY.CUSTOMER", sIIDValues[0]);
                    IIDValues.AddAttribute("CUSTOMER_CATEGORY.PROSPECT", sIIDValues[1]);
                    IIDValues.AddAttribute("CUSTOMER_CATEGORY.ENDCUSTOMER", sIIDValues[2]);
                }
            }
            #endregion
        }

        protected virtual void PrepareDataTransfer()
        {
            Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();

            SalArray<SalString> itemNames = new SalArray<SalString>() { 
                "CUSTOMER_ID", "CUSTOMER_NAME", "ASSOCIATION_NO", "CATEGORY", "TEMPLATE_CUSTOMER_ID" , "TEMPLATE_COMPANY", "CUST_GRP"};
            SalArray<SalWindowHandle> itemHandles = new SalArray<SalWindowHandle>() { 
                dfsNewCustomerId, dfsNewCustomerName, dfsAssociationNo, cmbCustomerCategory, dfsTemplateCustomerId, dfsCompany, dfsCustomerGroup};
            Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("BusinessActivity", this, itemNames, itemHandles);
        }

        protected virtual SalBoolean ValidateFields()
        {
            SalArray<SalString> sParam = new SalArray<SalString>();
            
            #region Actions  
            sCustomerExist = "FALSE";
            if (this.dfsTemplateCustomerId.Text == Ifs.Fnd.ApplicationForms.Const.strNULL && this.dfsCustomerGroup.Text == Ifs.Fnd.ApplicationForms.Const.strNULL
                && cmbCustomerCategory.Text != IIDValues.GetAttribute("CUSTOMER_CATEGORY.ENDCUSTOMER") && sChangeCustomerCategory == "FALSE")
            {
                if (Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_CustGroupNullNotAllowed, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Warning, Ifs.Fnd.ApplicationForms.Const.WARNING_OkCancel) == Sys.IDCANCEL)
                {
                    return false;
                }
                return true;
            }
            if (DbPLSQLBlock(@"IF ({0} = 'FALSE') THEN
                                  IF(&AO.Customer_Info_API.Exists({1} IN)) THEN
                                     {2} := 'TRUE';
                                  END IF; 
                                  {3} := &AO.Association_Info_API.Association_No_Exist({4} IN, 'CUSTOMER' );                                 
                               END IF;
                               IF ({5} IS NOT NULL) THEN
                                  {6} := &AO.Customer_Info_API.Get_Customer_Category_Db({5} IN); 
                                  &AO.Customer_Info_API.Exist({5} IN, {6} IN);  
                               END IF;
                               IF ({7} IS NOT NULL) THEN
                                  &AO.Company_Finance_API.Exist({7} IN);  
                               END IF;", QualifiedVarBindName("sChangeCustomerCategory"), dfsNewCustomerId.QualifiedBindName,                                         
                                         QualifiedVarBindName("sCustomerExist"), QualifiedVarBindName("sAssociationNoExist"), 
                                         dfsAssociationNo.QualifiedBindName, dfsTemplateCustomerId.QualifiedBindName, 
                                         QualifiedVarBindName("sTempCustomerCategory"), dfsCompany.QualifiedBindName))
                                
            {
                if (sChangeCustomerCategory == "FALSE")
                {
                    if (sCustomerExist == "TRUE")
                    {
                        sParam[0] = dfsNewCustomerId.Text;
                        Ifs.Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.TEXT_CustomerExist, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok, sParam);
                        return false;
                    }
                    if (sAssociationNoExist == "TRUE")
                    {
                        if (Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_WarnSameAssocNo, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Warning, Ifs.Fnd.ApplicationForms.Const.WARNING_OkCancel) == Sys.IDCANCEL)
                        {
                            return false;
                        }
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

        protected virtual void EnableCustStatGroup()
        {

            #region Local Variables
            #endregion

            #region Actions
            if (sChangeCustomerCategory == "TRUE")
            {
                gbOrder_Related_Info.DisableWindow();
            }
            else if (dfsTemplateCustomerId.Text != Ifs.Fnd.ApplicationForms.Const.strNULL && cbOverwriteData.Checked == true)
            {
                gbOrder_Related_Info.DisableWindow();
                dfsCustomerGroup.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                dfsCustomerGroupDescription.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;

            }
            else
            {
                gbOrder_Related_Info.EnableWindow();
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

        private void dfsTemplateCustomerId_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovDone:
                    this.dfsTemplateCustomerId_OnPM_DataItemLovDone(sender, e);
                    break;
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.dfsTemplateCustomerId_OnPM_DataItemValidate(sender, e);
                    break; 
            }
            #endregion
        }

        private void dfsTemplateCustomerId_OnPM_DataItemLovDone(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.nNum = SalString.FromHandle(Sys.lParam).Tokenize("", ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_RS).ToCharacter(), this.sRecords);
            this.nNum = this.sRecords[1].Tokenize("", ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_US).ToCharacter(), this.sUnits);
            if (this.sUnits[0] == "NAME")
            {
                Sal.SendMsg(this.dfsTemplateCustomerName, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 0, this.sUnits[1].ToHandle());
            }
            this.nNum = this.sRecords[2].Tokenize("", ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_US).ToCharacter(), this.sUnits);
            if (this.sUnits[0] == "TEMPLATE_CUSTOMER_DESC")
            {
                Sal.SendMsg(this.dfsTemplateDescription, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 0, this.sUnits[1].ToHandle());
            }
            #endregion
        }

        private void dfsTemplateCustomerId_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam)
            {
                DbPLSQLBlock(@"{0}:= &AO.Cust_Ord_Customer_API.Get_Name({1} IN);
                           {2}:= &AO.Cust_Ord_Customer_API.Get_Template_Customer_Desc({1} IN);", dfsTemplateCustomerName.QualifiedBindName, dfsTemplateCustomerId.QualifiedBindName, dfsTemplateDescription.QualifiedBindName);

                if (sFromCategory == IIDValues.GetAttribute("CUSTOMER_CATEGORY.ENDCUSTOMER") || (dfsTemplateCustomerId.Text == Ifs.Fnd.ApplicationForms.Const.strNULL))
                {
                    cbOverwriteData.DisableWindow();
                    cbOverwriteData.Checked = false;
                    cbTransOrdAddrTemp.DisableWindow();
                    cbTransOrdAddrTemp.Checked = false;
                }
                else
                {
                    cbOverwriteData.EnableWindow();
                    cbTransOrdAddrTemp.EnableWindow();
                    if(sOverwriteOrdData == "TRUE")
                         cbOverwriteData.Checked = true;
                    if (sTransOrdAddr == "TRUE")
                        cbTransOrdAddrTemp.Checked = true;

                }
                this.EnableCustStatGroup();
            }
            
            e.Return = Sys.VALIDATE_Ok;
            return;
            #endregion
        }

        private void cmbCustomerCategory_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_LookupInit:
                    this.cmbCustomerCategory_OnPM_LookupInit(sender, e);
                    break;
                case Sys.SAM_Click:
                    this.cmbCustomerCategory_OnSAM_Click(sender, e);
                    break;

            }
            #endregion
        }

        private void cmbCustomerCategory_OnPM_LookupInit(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            SalNumber index = 0;
            e.Handled = true;

            Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_LookupInit, Sys.wParam, Sys.lParam);
          
            for (int i = 0; i < cmbCustomerCategory.GetListItemsCount(); i++)
            {                
                if (cmbCustomerCategory.GetListItemText(i) == sFromCategory)
                {
                    Sal.ListDelete(this.cmbCustomerCategory, i);
                    break;
                }
            }          
            
            #endregion
        }

        private void cmbCustomerCategory_OnSAM_Click(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.cmbCustomerCategory.EditDataItemSetEdited();
            //Sal.SendMsg(this.cmbCustomerCategory.i_hWndParent, Ifs.Fnd.ApplicationForms.Const.PM_DataItemEntered, Sys.wParam, Sys.lParam);

            if (cmbCustomerCategory.Text == IIDValues.GetAttribute("CUSTOMER_CATEGORY.ENDCUSTOMER"))
            {
                dfsTemplateCustomerId.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                dfsTemplateCustomerName.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                dfsTemplateDescription.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                dfsCustomerGroup.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                dfsCustomerGroupDescription.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                dfsCompany.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                cbOverwriteData.Checked = false;
                cbTransOrdAddrTemp.Checked = false;
                gbTemplate_Customer.DisableWindow();
                gbOrder_Related_Info.DisableWindow();
            }
            else if(bOrderInstalled)
            {
                gbTemplate_Customer.EnableWindow();
                if (sChangeCustomerCategory == "FALSE")
                {
                    gbOrder_Related_Info.EnableWindow();
                }
                if (cmbCustomerCategory.Text == IIDValues.GetAttribute("CUSTOMER_CATEGORY.CUSTOMER"))
                {
                    dfsTemplateCustomerId.p_sLovReference = "CUSTOMER_TEMPLATE_LOV";
                }
                else if (cmbCustomerCategory.Text == IIDValues.GetAttribute("CUSTOMER_CATEGORY.PROSPECT"))
                {
                    dfsTemplateCustomerId.p_sLovReference = "CUST_PROSPECT_TEMPLATE_LOV";
                }
                if (sFromCategory == IIDValues.GetAttribute("CUSTOMER_CATEGORY.ENDCUSTOMER") || (dfsTemplateCustomerId.Text == Ifs.Fnd.ApplicationForms.Const.strNULL))
                {
                    cbOverwriteData.DisableWindow();
                    cbOverwriteData.Checked = false;
                    cbTransOrdAddrTemp.DisableWindow();
                    cbTransOrdAddrTemp.Checked = false;
                }
                else
                {                   
                    cbOverwriteData.EnableWindow();
                    cbTransOrdAddrTemp.EnableWindow();
                    if (sOverwriteOrdData == "TRUE")
                        cbOverwriteData.Checked = true;
                    if (sTransOrdAddr == "TRUE")
                        cbTransOrdAddrTemp.Checked = true;
                }
            }         

            #endregion
        }

        private void dfsCompany_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    this.dfsCompany_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        private void dfsCompany_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam)
            {
                if (bOrderInstalled)
                {
                    if (dfsCompany.Text != Ifs.Fnd.ApplicationForms.Const.strNULL)
                    {
                        DbPLSQLBlock(@"{0}:= &AO.Company_Order_Info_API.Get_Overwrite_Ord_Rel_Data_Db({1} IN);", QualifiedVarBindName("sOverwriteOrdData"), dfsCompany.QualifiedBindName);
                        DbPLSQLBlock(@"{0}:= &AO.Company_Order_Info_API.Get_Trans_Ord_Addr_Info_Tem_Db({1} IN);", QualifiedVarBindName("sTransOrdAddr"), dfsCompany.QualifiedBindName);
                    }
                }
                if (sOverwriteOrdData == "TRUE")
                   cbOverwriteData.Checked = true;
                else
                   cbOverwriteData.Checked = false;
                if (sTransOrdAddr == "TRUE")
                   cbTransOrdAddrTemp.Checked = true;
                else
                   cbTransOrdAddrTemp.Checked = false;
            }
            e.Return = Sys.VALIDATE_Ok;
            return;
            #endregion
        }

        private void dfsCustomerGroup_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemLovDone:
                    this.dfsCustomerGroup_OnPM_DataItemLovDone(sender, e);
                    break;
                case Ifs.Fnd.ApplicationForms.Const.PM_DataItemValidate:
                    dfsCustomerGroup_OnPM_DataItemValidate(sender, e);
                    break;
            }
            #endregion
        }

        private void dfsCustomerGroup_OnPM_DataItemLovDone(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            this.nNum = SalString.FromHandle(Sys.lParam).Tokenize("", ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_RS).ToCharacter(), this.sRecords);
            this.nNum = this.sRecords[1].Tokenize("", ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_US).ToCharacter(), this.sUnits);
            if (this.sUnits[0] == "DESCRIPTION")
            {
                Sal.SendMsg(this.dfsCustomerGroupDescription, Ifs.Fnd.ApplicationForms.Const.PM_DataItemValueSet, 0, this.sUnits[1].ToHandle());
            }
            #endregion
        }

        private void dfsCustomerGroup_OnPM_DataItemValidate(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sys.wParam)
            {
                if (this.dfsCustomerGroup.Text == Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    this.dfsCustomerGroupDescription.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
                }
                if (bOrderInstalled)
                {
                    DbPLSQLBlock(@"{0}:= &AO.Customer_Group_API.Get_Description({1} IN);", dfsCustomerGroupDescription.QualifiedBindName, dfsCustomerGroup.QualifiedBindName);
                }
            }
            e.Return = Sys.VALIDATE_Ok;
            return;
            #endregion
        }

        private void cbOverwriteData_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Sys.SAM_Click:
                    this.EnableCustStatGroup();
                    break;
            }
            #endregion
        }

        #endregion

        #region Event Handlers

        private void commandOk_Inquire(object sender, FndCommandInquireEventArgs e)
        {
            ((FndCommand)sender).Enabled = dfsNewCustomerName.Text != Ifs.Fnd.ApplicationForms.Const.strNULL &&
                                           cmbCustomerCategory.Text != Ifs.Fnd.ApplicationForms.Const.strNULL;
        }

        private void commandOk_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            // Dialog class have AcceptButton set to run this logic if the user ends the dialog using the Return button.
            // PPJ dialog close trough Sal.EndDialog so we set DialogResult to prevent the dialog from closing premature.
            DialogResult = DialogResult.None;

            if (ValidateFields())
            {
                PrepareDataTransfer();
                bOverwrite = cbOverwriteData.Checked;
                bTranferAddr = cbTransOrdAddrTemp.Checked;
                Sal.EndDialog(this, Sys.IDOK);
            }
        }

        private void commandCancel_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            // Dialog class have CancelButton set to run this logic even if the user close the dialog trough the esc button.
            // PPJ dialog close trough Sal.EndDialog so we set DialogResult to prevent the dialog from closing premature.
            DialogResult = DialogResult.None;

            Sal.EndDialog(this, Sys.IDCANCEL);
        }

        private void commandList_Inquire(object sender, Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            e.Handled = true;
            hWndFocus = Ifs.Fnd.ApplicationForms.Int.PalGetFocus();
            ((FndCommand)sender).Enabled = Sal.SendMsg(hWndFocus, Ifs.Fnd.ApplicationForms.Const.PM_DataItemLov, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0);
        }

        private void commandList_Execute(object sender, Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            e.Handled = true;
            Sal.SendMsg(hWndFocus, Ifs.Fnd.ApplicationForms.Const.PM_DataItemLov, Ifs.Fnd.ApplicationForms.Const.METHOD_Execute, 0);
        }

        private void commandButtonFind_Execute(object sender, FndCommandExecuteEventArgs e)
        {
            fcURL URL = new fcURL();
            URL.SetProgId(Pal.GetActiveInstanceName("dlgFindCustomer"));
            URL.iParameters.SetAttribute("LEAD_ID", sLeadId);
            URL.iParameters.SetAttribute("CUSTOMER_NAME", dfsNewCustomerName.Text);
            URL.iParameters.SetAttribute("ASSOCIATION_NO", dfsAssociationNo.Text);
            URL.iParameters.SetAttribute("STARTED_FROM", Pal.GetActiveInstanceName("dlgChangeCustomerCategory"));
            URL.Go();

            SalString sReturn = Ifs.Fnd.ApplicationForms.Var.g_DlgReturnValues.FindValue("RETURN");
            if (sReturn == "IDOK")
            {
                DialogResult = DialogResult.None;
                Sal.EndDialog(this, Sys.IDCANCEL);
            }
            this.BringWindowToTop();
        }

        private void commandButtonFind_Inquire(object sender, FndCommandInquireEventArgs e)
        {
            e.Handled = true;

            SalBoolean a = Ifs.Fnd.ApplicationForms.Var.Component.IsWindowAvailable(Pal.GetActiveInstanceName("dlgFindCustomer"));
            SalBoolean b = Ifs.Fnd.ApplicationForms.Var.Security.IsDataSourceAvailable(Pal.GetActiveInstanceName("dlgFindCustomer"));
            SalBoolean c = Ifs.Fnd.ApplicationForms.Var.Security.IsPresObjectAvailable(Pal.GetActiveInstanceName("dlgFindCustomer"));

            ((FndCommand)sender).Enabled = a && b && c;
        }

        #endregion

        #region Menu Event Handlers

        #endregion
    }
}
