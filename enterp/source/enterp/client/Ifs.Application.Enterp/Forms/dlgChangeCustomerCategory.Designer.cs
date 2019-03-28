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
// 150717   Wahelk  BLU-961, Modified Layout to move Transfer Order Address check box below to Overwrite Order Related Data check box
// 150706   Wahelk  BLU-955, Added check bo Transfer Order Address Info from Template
// 150601   JanWse  BLU-675, Find button default not visible
// 150505   JanWse  BLU-152, Added a find button to start dlgFindCustomer
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ifs.Fnd.ApplicationForms;
using PPJ.Runtime;
using PPJ.Runtime.Windows;

namespace Ifs.Application.Enterp
{

    public partial class dlgChangeCustomerCategory
    {

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgChangeCustomerCategory));
            this.cCommandButtonOK = new Ifs.Fnd.ApplicationForms.cCommandButton();
            this.commandOk = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.cCommandButtonCancel = new Ifs.Fnd.ApplicationForms.cCommandButton();
            this.commandCancel = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.labelCustomerCategory = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.labeldfsAssociationNo = new PPJ.Runtime.Windows.SalBackgroundText();
            this.labelCustomerName = new PPJ.Runtime.Windows.SalBackgroundText();
            this.labelCustomerId = new PPJ.Runtime.Windows.SalBackgroundText();
            this.cmbCustomerCategory = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.dfsAssociationNo = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsNewCustomerName = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsNewCustomerId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.gbNew_Customer = new PPJ.Runtime.Windows.SalGroupBox();
            this.dfsTemplateDescription = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsTemplateCustomerName = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsTemplateCustomerId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsTemplateDescription = new PPJ.Runtime.Windows.SalBackgroundText();
            this.labeldfsTemplateCustomerName = new PPJ.Runtime.Windows.SalBackgroundText();
            this.labeldfsTemplateCustomerId = new PPJ.Runtime.Windows.SalBackgroundText();
            this.labeldfsTextDummy1 = new PPJ.Runtime.Windows.SalBackgroundText();
            this.gbTemplate_Customer = new PPJ.Runtime.Windows.SalGroupBox();
            this.cbTransOrdAddrTemp = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.dfDummy = new Ifs.Fnd.ApplicationForms.cDataField();
            this.cbOverwriteData = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.dfsCompany = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelCompany = new PPJ.Runtime.Windows.SalBackgroundText();
            this.commandList = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.cCommandButtonList = new Ifs.Fnd.ApplicationForms.cCommandButton();
            this.commandButtonFind = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.cCommandButtonFind = new Ifs.Fnd.ApplicationForms.cCommandButton();
            this.gbOrder_Related_Info = new PPJ.Runtime.Windows.SalGroupBox();
            this.dfsCustomerGroupDescription = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsCustomerGroup = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsCustomerGroup = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.gbNew_Customer.SuspendLayout();
            this.gbTemplate_Customer.SuspendLayout();
            this.gbOrder_Related_Info.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.commandOk);
            this.commandManager.Commands.Add(this.commandCancel);
            this.commandManager.Commands.Add(this.commandList);
            this.commandManager.Commands.Add(this.commandButtonFind);
            this.commandManager.Components.Add(this.cCommandButtonOK);
            this.commandManager.Components.Add(this.cCommandButtonCancel);
            this.commandManager.Components.Add(this.cCommandButtonList);
            this.commandManager.Components.Add(this.cCommandButtonFind);
            this.commandManager.ImageList = null;
            // 
            // cCommandButtonOK
            // 
            resources.ApplyResources(this.cCommandButtonOK, "cCommandButtonOK");
            this.cCommandButtonOK.Command = this.commandOk;
            this.cCommandButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cCommandButtonOK.Name = "cCommandButtonOK";
            this.cCommandButtonOK.NamedProperties.Put("MethodIdStr", "");
            this.cCommandButtonOK.NamedProperties.Put("MethodParameterType", "String");
            // 
            // commandOk
            // 
            resources.ApplyResources(this.commandOk, "commandOk");
            this.commandOk.Enabled = false;
            this.commandOk.EventCategory = Ifs.Fnd.Windows.Forms.CommandEventCategory.Edit;
            this.commandOk.Name = "commandOk";
            this.commandOk.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.commandOk_Execute);
            this.commandOk.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.commandOk_Inquire);
            // 
            // cCommandButtonCancel
            // 
            resources.ApplyResources(this.cCommandButtonCancel, "cCommandButtonCancel");
            this.cCommandButtonCancel.Command = this.commandCancel;
            this.cCommandButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cCommandButtonCancel.Name = "cCommandButtonCancel";
            this.cCommandButtonCancel.NamedProperties.Put("MethodIdStr", "");
            this.cCommandButtonCancel.NamedProperties.Put("MethodParameterType", "String");
            // 
            // commandCancel
            // 
            resources.ApplyResources(this.commandCancel, "commandCancel");
            this.commandCancel.Name = "commandCancel";
            this.commandCancel.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.commandCancel_Execute);
            // 
            // labelCustomerCategory
            // 
            resources.ApplyResources(this.labelCustomerCategory, "labelCustomerCategory");
            this.labelCustomerCategory.Name = "labelCustomerCategory";
            // 
            // labeldfsAssociationNo
            // 
            resources.ApplyResources(this.labeldfsAssociationNo, "labeldfsAssociationNo");
            this.labeldfsAssociationNo.Name = "labeldfsAssociationNo";
            // 
            // labelCustomerName
            // 
            resources.ApplyResources(this.labelCustomerName, "labelCustomerName");
            this.labelCustomerName.Name = "labelCustomerName";
            // 
            // labelCustomerId
            // 
            resources.ApplyResources(this.labelCustomerId, "labelCustomerId");
            this.labelCustomerId.Name = "labelCustomerId";
            // 
            // cmbCustomerCategory
            // 
            resources.ApplyResources(this.cmbCustomerCategory, "cmbCustomerCategory");
            this.cmbCustomerCategory.Name = "cmbCustomerCategory";
            this.cmbCustomerCategory.NamedProperties.Put("EnumerateMethod", "CUSTOMER_CATEGORY_API.Enumerate");
            this.cmbCustomerCategory.NamedProperties.Put("FieldFlags", "263");
            this.cmbCustomerCategory.NamedProperties.Put("LovReference", "");
            this.cmbCustomerCategory.NamedProperties.Put("ResizeableChildObject", "");
            this.cmbCustomerCategory.NamedProperties.Put("SqlColumn", "CUSTOMER_CATEGORY");
            this.cmbCustomerCategory.NamedProperties.Put("ValidateMethod", "");
            this.cmbCustomerCategory.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cmbCustomerCategory_WindowActions);
            // 
            // dfsAssociationNo
            // 
            resources.ApplyResources(this.dfsAssociationNo, "dfsAssociationNo");
            this.dfsAssociationNo.Name = "dfsAssociationNo";
            this.dfsAssociationNo.NamedProperties.Put("EnumerateMethod", "");
            this.dfsAssociationNo.NamedProperties.Put("FieldFlags", "262");
            this.dfsAssociationNo.NamedProperties.Put("LovReference", "");
            this.dfsAssociationNo.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsAssociationNo.NamedProperties.Put("SqlColumn", "ASSOCIATION_NO");
            this.dfsAssociationNo.NamedProperties.Put("ValidateMethod", "");
            // 
            // dfsNewCustomerName
            // 
            resources.ApplyResources(this.dfsNewCustomerName, "dfsNewCustomerName");
            this.dfsNewCustomerName.Name = "dfsNewCustomerName";
            this.dfsNewCustomerName.NamedProperties.Put("EnumerateMethod", "");
            this.dfsNewCustomerName.NamedProperties.Put("FieldFlags", "263");
            this.dfsNewCustomerName.NamedProperties.Put("LovReference", "");
            this.dfsNewCustomerName.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsNewCustomerName.NamedProperties.Put("SqlColumn", "NEW_CUSTOMER_NAME");
            this.dfsNewCustomerName.NamedProperties.Put("ValidateMethod", "");
            // 
            // dfsNewCustomerId
            // 
            this.dfsNewCustomerId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsNewCustomerId, "dfsNewCustomerId");
            this.dfsNewCustomerId.Name = "dfsNewCustomerId";
            this.dfsNewCustomerId.NamedProperties.Put("EnumerateMethod", "");
            this.dfsNewCustomerId.NamedProperties.Put("LovReference", "");
            this.dfsNewCustomerId.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsNewCustomerId.NamedProperties.Put("SqlColumn", "NEW_CUSTOMER_ID");
            this.dfsNewCustomerId.NamedProperties.Put("ValidateMethod", "");
            // 
            // gbNew_Customer
            // 
            this.gbNew_Customer.Controls.Add(this.labelCustomerCategory);
            this.gbNew_Customer.Controls.Add(this.labeldfsAssociationNo);
            this.gbNew_Customer.Controls.Add(this.labelCustomerName);
            this.gbNew_Customer.Controls.Add(this.labelCustomerId);
            this.gbNew_Customer.Controls.Add(this.cmbCustomerCategory);
            this.gbNew_Customer.Controls.Add(this.dfsAssociationNo);
            this.gbNew_Customer.Controls.Add(this.dfsNewCustomerName);
            this.gbNew_Customer.Controls.Add(this.dfsNewCustomerId);
            resources.ApplyResources(this.gbNew_Customer, "gbNew_Customer");
            this.gbNew_Customer.Name = "gbNew_Customer";
            this.gbNew_Customer.TabStop = false;
            // 
            // dfsTemplateDescription
            // 
            resources.ApplyResources(this.dfsTemplateDescription, "dfsTemplateDescription");
            this.dfsTemplateDescription.Name = "dfsTemplateDescription";
            this.dfsTemplateDescription.NamedProperties.Put("EnumerateMethod", "");
            this.dfsTemplateDescription.NamedProperties.Put("LovReference", "");
            this.dfsTemplateDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsTemplateDescription.NamedProperties.Put("SqlColumn", "");
            this.dfsTemplateDescription.NamedProperties.Put("ValidateMethod", "");
            // 
            // dfsTemplateCustomerName
            // 
            resources.ApplyResources(this.dfsTemplateCustomerName, "dfsTemplateCustomerName");
            this.dfsTemplateCustomerName.Name = "dfsTemplateCustomerName";
            this.dfsTemplateCustomerName.NamedProperties.Put("EnumerateMethod", "");
            this.dfsTemplateCustomerName.NamedProperties.Put("LovReference", "");
            this.dfsTemplateCustomerName.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsTemplateCustomerName.NamedProperties.Put("SqlColumn", "");
            this.dfsTemplateCustomerName.NamedProperties.Put("ValidateMethod", "");
            // 
            // dfsTemplateCustomerId
            // 
            this.dfsTemplateCustomerId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsTemplateCustomerId, "dfsTemplateCustomerId");
            this.dfsTemplateCustomerId.Name = "dfsTemplateCustomerId";
            this.dfsTemplateCustomerId.NamedProperties.Put("EnumerateMethod", "");
            this.dfsTemplateCustomerId.NamedProperties.Put("FieldFlags", "262");
            this.dfsTemplateCustomerId.NamedProperties.Put("LovReference", "CUSTOMER_TEMPLATE_LOV");
            this.dfsTemplateCustomerId.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsTemplateCustomerId.NamedProperties.Put("SqlColumn", "");
            this.dfsTemplateCustomerId.NamedProperties.Put("ValidateMethod", "");
            this.dfsTemplateCustomerId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsTemplateCustomerId_WindowActions);
            // 
            // labeldfsTemplateDescription
            // 
            resources.ApplyResources(this.labeldfsTemplateDescription, "labeldfsTemplateDescription");
            this.labeldfsTemplateDescription.Name = "labeldfsTemplateDescription";
            // 
            // labeldfsTemplateCustomerName
            // 
            resources.ApplyResources(this.labeldfsTemplateCustomerName, "labeldfsTemplateCustomerName");
            this.labeldfsTemplateCustomerName.Name = "labeldfsTemplateCustomerName";
            // 
            // labeldfsTemplateCustomerId
            // 
            resources.ApplyResources(this.labeldfsTemplateCustomerId, "labeldfsTemplateCustomerId");
            this.labeldfsTemplateCustomerId.Name = "labeldfsTemplateCustomerId";
            // 
            // labeldfsTextDummy1
            // 
            resources.ApplyResources(this.labeldfsTextDummy1, "labeldfsTextDummy1");
            this.labeldfsTextDummy1.Name = "labeldfsTextDummy1";
            // 
            // gbTemplate_Customer
            // 
            this.gbTemplate_Customer.Controls.Add(this.cbTransOrdAddrTemp);
            this.gbTemplate_Customer.Controls.Add(this.dfDummy);
            this.gbTemplate_Customer.Controls.Add(this.cbOverwriteData);
            this.gbTemplate_Customer.Controls.Add(this.dfsCompany);
            this.gbTemplate_Customer.Controls.Add(this.labelCompany);
            this.gbTemplate_Customer.Controls.Add(this.dfsTemplateDescription);
            this.gbTemplate_Customer.Controls.Add(this.dfsTemplateCustomerName);
            this.gbTemplate_Customer.Controls.Add(this.dfsTemplateCustomerId);
            this.gbTemplate_Customer.Controls.Add(this.labeldfsTemplateDescription);
            this.gbTemplate_Customer.Controls.Add(this.labeldfsTemplateCustomerName);
            this.gbTemplate_Customer.Controls.Add(this.labeldfsTemplateCustomerId);
            this.gbTemplate_Customer.Controls.Add(this.labeldfsTextDummy1);
            resources.ApplyResources(this.gbTemplate_Customer, "gbTemplate_Customer");
            this.gbTemplate_Customer.Name = "gbTemplate_Customer";
            this.gbTemplate_Customer.TabStop = false;
            // 
            // cbTransOrdAddrTemp
            // 
            resources.ApplyResources(this.cbTransOrdAddrTemp, "cbTransOrdAddrTemp");
            this.cbTransOrdAddrTemp.Name = "cbTransOrdAddrTemp";
            this.cbTransOrdAddrTemp.NamedProperties.Put("FieldFlags", "262");
            // 
            // dfDummy
            // 
            resources.ApplyResources(this.dfDummy, "dfDummy");
            this.dfDummy.Name = "dfDummy";
            // 
            // cbOverwriteData
            // 
            resources.ApplyResources(this.cbOverwriteData, "cbOverwriteData");
            this.cbOverwriteData.Name = "cbOverwriteData";
            this.cbOverwriteData.NamedProperties.Put("FieldFlags", "262");
            this.cbOverwriteData.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbOverwriteData_WindowActions);
            // 
            // dfsCompany
            // 
            resources.ApplyResources(this.dfsCompany, "dfsCompany");
            this.dfsCompany.Name = "dfsCompany";
            this.dfsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCompany.NamedProperties.Put("FieldFlags", "294");
            this.dfsCompany.NamedProperties.Put("LovReference", "COMPANY_FINANCE");
            this.dfsCompany.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsCompany.NamedProperties.Put("SqlColumn", "COMPANY");
            this.dfsCompany.NamedProperties.Put("ValidateMethod", "");
            this.dfsCompany.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsCompany_WindowActions);
            // 
            // labelCompany
            // 
            resources.ApplyResources(this.labelCompany, "labelCompany");
            this.labelCompany.Name = "labelCompany";
            // 
            // commandList
            // 
            resources.ApplyResources(this.commandList, "commandList");
            this.commandList.Enabled = false;
            this.commandList.EventCategory = Ifs.Fnd.Windows.Forms.CommandEventCategory.Focus;
            this.commandList.Name = "commandList";
            this.commandList.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.commandList_Execute);
            this.commandList.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.commandList_Inquire);
            // 
            // cCommandButtonList
            // 
            this.cCommandButtonList.AcceleratorKey = System.Windows.Forms.Keys.F8;
            resources.ApplyResources(this.cCommandButtonList, "cCommandButtonList");
            this.cCommandButtonList.Command = this.commandList;
            this.cCommandButtonList.Name = "cCommandButtonList";
            // 
            // commandButtonFind
            // 
            resources.ApplyResources(this.commandButtonFind, "commandButtonFind");
            this.commandButtonFind.Name = "commandButtonFind";
            this.commandButtonFind.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.commandButtonFind_Execute);
            this.commandButtonFind.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.commandButtonFind_Inquire);
            // 
            // cCommandButtonFind
            // 
            this.cCommandButtonFind.Command = this.commandButtonFind;
            resources.ApplyResources(this.cCommandButtonFind, "cCommandButtonFind");
            this.cCommandButtonFind.Name = "cCommandButtonFind";
            // 
            // gbOrder_Related_Info
            // 
            this.gbOrder_Related_Info.Controls.Add(this.dfsCustomerGroupDescription);
            this.gbOrder_Related_Info.Controls.Add(this.dfsCustomerGroup);
            this.gbOrder_Related_Info.Controls.Add(this.labeldfsCustomerGroup);
            resources.ApplyResources(this.gbOrder_Related_Info, "gbOrder_Related_Info");
            this.gbOrder_Related_Info.Name = "gbOrder_Related_Info";
            this.gbOrder_Related_Info.TabStop = false;
            // 
            // dfsCustomerGroupDescription
            // 
            resources.ApplyResources(this.dfsCustomerGroupDescription, "dfsCustomerGroupDescription");
            this.dfsCustomerGroupDescription.Name = "dfsCustomerGroupDescription";
            this.dfsCustomerGroupDescription.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCustomerGroupDescription.NamedProperties.Put("LovReference", "");
            this.dfsCustomerGroupDescription.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsCustomerGroupDescription.NamedProperties.Put("SqlColumn", "");
            this.dfsCustomerGroupDescription.NamedProperties.Put("ValidateMethod", "");
            // 
            // dfsCustomerGroup
            // 
            this.dfsCustomerGroup.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsCustomerGroup, "dfsCustomerGroup");
            this.dfsCustomerGroup.Name = "dfsCustomerGroup";
            this.dfsCustomerGroup.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCustomerGroup.NamedProperties.Put("FieldFlags", "294");
            this.dfsCustomerGroup.NamedProperties.Put("LovReference", "");
            this.dfsCustomerGroup.NamedProperties.Put("SqlColumn", "CUST_GRP");
            this.dfsCustomerGroup.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsCustomerGroup_WindowActions);
            // 
            // labeldfsCustomerGroup
            // 
            resources.ApplyResources(this.labeldfsCustomerGroup, "labeldfsCustomerGroup");
            this.labeldfsCustomerGroup.BackColor = System.Drawing.Color.Transparent;
            this.labeldfsCustomerGroup.Name = "labeldfsCustomerGroup";
            // 
            // dlgChangeCustomerCategory
            // 
            this.AcceptButton = this.cCommandButtonOK;
            this.CancelButton = this.cCommandButtonCancel;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.gbOrder_Related_Info);
            this.Controls.Add(this.cCommandButtonFind);
            this.Controls.Add(this.cCommandButtonList);
            this.Controls.Add(this.gbNew_Customer);
            this.Controls.Add(this.cCommandButtonOK);
            this.Controls.Add(this.cCommandButtonCancel);
            this.Controls.Add(this.gbTemplate_Customer);
            this.Name = "dlgChangeCustomerCategory";
            this.gbNew_Customer.ResumeLayout(false);
            this.gbNew_Customer.PerformLayout();
            this.gbTemplate_Customer.ResumeLayout(false);
            this.gbTemplate_Customer.PerformLayout();
            this.gbOrder_Related_Info.ResumeLayout(false);
            this.gbOrder_Related_Info.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        #region System Methods/Properties

        /// <summary>
        /// Release global reference.
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion

        protected cCommandButton cCommandButtonOK;
        protected cCommandButton cCommandButtonCancel;
        protected Ifs.Fnd.Windows.Forms.FndCommand commandOk;
        protected Ifs.Fnd.Windows.Forms.FndCommand commandCancel;
        protected cBackgroundText labelCustomerCategory;
        protected SalBackgroundText labeldfsAssociationNo;
        protected SalBackgroundText labelCustomerName;
        protected SalBackgroundText labelCustomerId;
        public cComboBox cmbCustomerCategory;
        public cDataField dfsAssociationNo;
        public cDataField dfsNewCustomerName;
        public cDataField dfsNewCustomerId;
        protected SalGroupBox gbNew_Customer;
        public cDataField dfsTemplateDescription;
        public cDataField dfsTemplateCustomerName;
        public cDataField dfsTemplateCustomerId;
        protected SalBackgroundText labeldfsTemplateDescription;
        protected SalBackgroundText labeldfsTemplateCustomerName;
        protected SalBackgroundText labeldfsTemplateCustomerId;
        protected SalBackgroundText labeldfsTextDummy1;
        protected SalGroupBox gbTemplate_Customer;
        public cDataField dfsCompany;
        protected SalBackgroundText labelCompany;
        protected Fnd.Windows.Forms.FndCommand commandList;
        protected cCommandButton cCommandButtonList;
        protected cCheckBox cbOverwriteData;
        protected cDataField dfDummy;
        protected Fnd.Windows.Forms.FndCommand commandButtonFind;
        protected cCommandButton cCommandButtonFind;
        protected cCheckBox cbTransOrdAddrTemp;
        protected SalGroupBox gbOrder_Related_Info;
        public cDataField dfsCustomerGroupDescription;
        public cDataField dfsCustomerGroup;
        protected cBackgroundText labeldfsCustomerGroup;

    }
}
