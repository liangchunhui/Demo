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
// Date    By      Notes
/// -----   ------  ---------------------------------------------------------
/// 150903  SudJlk  AFT-1682, Set accelerator key Enter for Ok button.
/// 150729  SudJlk  Created.
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

    public partial class dlgAddSupplierContact
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgAddSupplierContact));
            this.commandReset = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.commandEdit = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.labelPersonId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsInitials = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsManagerGuid = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsPersonId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.cbRole = new Ifs.Fnd.ApplicationForms.cComboBoxMultiSelection();
            this.dfsAddressId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.cbCopyAddress = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.dfsIntercom = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsPager = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsMessenger = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsWww = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsFax = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsEmail = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsMobile = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsPhone = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsTitle = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsName = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsAddressId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.labeldfsIntercom = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.labeldfsPager = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.labeldfsMessenger = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.labeldfsWww = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.labeldfsFax = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.labeldfsEmail = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.labeldfsMobile = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.labeldfsPhone = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.labeldfsTitle = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.labeldfsRole = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.labeldfsName = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cCommandButtonReset = new Ifs.Fnd.ApplicationForms.cCommandButton();
            this.cbDepartment = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.labeldfsDepartment = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cCommandButtonEdit = new Ifs.Fnd.ApplicationForms.cCommandButton();
            this.cCommandButtonOk = new Ifs.Fnd.ApplicationForms.cCommandButton();
            this.commandOk = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.cCommandButtonCancel = new Ifs.Fnd.ApplicationForms.cCommandButton();
            this.commandCancel = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.cCommandButtonList = new Ifs.Fnd.ApplicationForms.cCommandButton();
            this.commandList = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.cCommandButtonFind = new Ifs.Fnd.ApplicationForms.cCommandButton();
            this.commandFind = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.commandReset);
            this.commandManager.Commands.Add(this.commandEdit);
            this.commandManager.Commands.Add(this.commandOk);
            this.commandManager.Commands.Add(this.commandCancel);
            this.commandManager.Commands.Add(this.commandFind);
            this.commandManager.Commands.Add(this.commandList);
            this.commandManager.Components.Add(this.cCommandButtonReset);
            this.commandManager.Components.Add(this.cCommandButtonEdit);
            this.commandManager.Components.Add(this.cCommandButtonOk);
            this.commandManager.Components.Add(this.cCommandButtonCancel);
            this.commandManager.Components.Add(this.cCommandButtonList);
            this.commandManager.Components.Add(this.cCommandButtonFind);
            this.commandManager.ImageList = null;
            // 
            // commandReset
            // 
            resources.ApplyResources(this.commandReset, "commandReset");
            this.commandReset.Name = "commandReset";
            this.commandReset.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.commandReset_Execute);
            // 
            // commandEdit
            // 
            resources.ApplyResources(this.commandEdit, "commandEdit");
            this.commandEdit.Name = "commandEdit";
            this.commandEdit.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.commandEdit_Execute);
            // 
            // labelPersonId
            // 
            resources.ApplyResources(this.labelPersonId, "labelPersonId");
            this.labelPersonId.Name = "labelPersonId";
            // 
            // dfsInitials
            // 
            resources.ApplyResources(this.dfsInitials, "dfsInitials");
            this.dfsInitials.Name = "dfsInitials";
            this.dfsInitials.NamedProperties.Put("EnumerateMethod", "");
            this.dfsInitials.NamedProperties.Put("LovReference", "");
            this.dfsInitials.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsInitials.NamedProperties.Put("SqlColumn", "");
            this.dfsInitials.NamedProperties.Put("ValidateMethod", "");
            // 
            // dfsManagerGuid
            // 
            resources.ApplyResources(this.dfsManagerGuid, "dfsManagerGuid");
            this.dfsManagerGuid.Name = "dfsManagerGuid";
            this.dfsManagerGuid.NamedProperties.Put("EnumerateMethod", "");
            this.dfsManagerGuid.NamedProperties.Put("LovReference", "");
            this.dfsManagerGuid.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsManagerGuid.NamedProperties.Put("SqlColumn", "");
            this.dfsManagerGuid.NamedProperties.Put("ValidateMethod", "");
            // 
            // dfsPersonId
            // 
            this.dfsPersonId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsPersonId, "dfsPersonId");
            this.dfsPersonId.Name = "dfsPersonId";
            this.dfsPersonId.NamedProperties.Put("EnumerateMethod", "");
            this.dfsPersonId.NamedProperties.Put("FieldFlags", "262");
            this.dfsPersonId.NamedProperties.Put("LovReference", "");
            this.dfsPersonId.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsPersonId.NamedProperties.Put("SqlColumn", "");
            this.dfsPersonId.NamedProperties.Put("ValidateMethod", "");
            this.dfsPersonId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsPersonId_WindowActions);
            // 
            // cbRole
            // 
            resources.ApplyResources(this.cbRole, "cbRole");
            this.cbRole.FormattingEnabled = true;
            this.cbRole.Items = null;
            this.cbRole.Name = "cbRole";
            this.cbRole.NamedProperties.Put("EnumerateMethod", "CONTACT_ROLE_API.Enumerate");
            this.cbRole.NamedProperties.Put("FieldFlags", "262");
            // 
            // dfsAddressId
            // 
            this.dfsAddressId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsAddressId, "dfsAddressId");
            this.dfsAddressId.Name = "dfsAddressId";
            this.dfsAddressId.NamedProperties.Put("EnumerateMethod", "");
            this.dfsAddressId.NamedProperties.Put("FieldFlags", "262");
            this.dfsAddressId.NamedProperties.Put("LovReference", "SUPPLIER_INFO_ADDRESS(SUPPLIER_ID)");
            this.dfsAddressId.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsAddressId.NamedProperties.Put("SqlColumn", "ADDRESS_ID");
            this.dfsAddressId.NamedProperties.Put("ValidateMethod", "");
            this.dfsAddressId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsAddressId_WindowActions);
            // 
            // cbCopyAddress
            // 
            resources.ApplyResources(this.cbCopyAddress, "cbCopyAddress");
            this.cbCopyAddress.Name = "cbCopyAddress";
            this.cbCopyAddress.NamedProperties.Put("DataType", "5");
            this.cbCopyAddress.NamedProperties.Put("EnumerateMethod", "");
            this.cbCopyAddress.NamedProperties.Put("FieldFlags", "262");
            this.cbCopyAddress.NamedProperties.Put("LovReference", "");
            this.cbCopyAddress.NamedProperties.Put("ResizeableChildObject", "");
            this.cbCopyAddress.NamedProperties.Put("SqlColumn", "");
            this.cbCopyAddress.NamedProperties.Put("ValidateMethod", "");
            this.cbCopyAddress.NamedProperties.Put("XDataLength", "");
            this.cbCopyAddress.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsAddressId_WindowActions);
            // 
            // dfsIntercom
            // 
            resources.ApplyResources(this.dfsIntercom, "dfsIntercom");
            this.dfsIntercom.Name = "dfsIntercom";
            this.dfsIntercom.NamedProperties.Put("EnumerateMethod", "");
            this.dfsIntercom.NamedProperties.Put("FieldFlags", "262");
            this.dfsIntercom.NamedProperties.Put("LovReference", "");
            this.dfsIntercom.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsIntercom.NamedProperties.Put("SqlColumn", "");
            this.dfsIntercom.NamedProperties.Put("ValidateMethod", "");
            // 
            // dfsPager
            // 
            resources.ApplyResources(this.dfsPager, "dfsPager");
            this.dfsPager.Name = "dfsPager";
            this.dfsPager.NamedProperties.Put("EnumerateMethod", "");
            this.dfsPager.NamedProperties.Put("FieldFlags", "262");
            this.dfsPager.NamedProperties.Put("LovReference", "");
            this.dfsPager.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsPager.NamedProperties.Put("SqlColumn", "");
            this.dfsPager.NamedProperties.Put("ValidateMethod", "");
            // 
            // dfsMessenger
            // 
            resources.ApplyResources(this.dfsMessenger, "dfsMessenger");
            this.dfsMessenger.Name = "dfsMessenger";
            this.dfsMessenger.NamedProperties.Put("EnumerateMethod", "");
            this.dfsMessenger.NamedProperties.Put("FieldFlags", "262");
            this.dfsMessenger.NamedProperties.Put("LovReference", "");
            this.dfsMessenger.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsMessenger.NamedProperties.Put("SqlColumn", "");
            this.dfsMessenger.NamedProperties.Put("ValidateMethod", "");
            // 
            // dfsWww
            // 
            resources.ApplyResources(this.dfsWww, "dfsWww");
            this.dfsWww.Name = "dfsWww";
            this.dfsWww.NamedProperties.Put("EnumerateMethod", "");
            this.dfsWww.NamedProperties.Put("FieldFlags", "262");
            this.dfsWww.NamedProperties.Put("LovReference", "");
            this.dfsWww.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsWww.NamedProperties.Put("SqlColumn", "");
            this.dfsWww.NamedProperties.Put("ValidateMethod", "");
            // 
            // dfsFax
            // 
            resources.ApplyResources(this.dfsFax, "dfsFax");
            this.dfsFax.Name = "dfsFax";
            this.dfsFax.NamedProperties.Put("EnumerateMethod", "");
            this.dfsFax.NamedProperties.Put("FieldFlags", "262");
            this.dfsFax.NamedProperties.Put("LovReference", "");
            this.dfsFax.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsFax.NamedProperties.Put("SqlColumn", "");
            this.dfsFax.NamedProperties.Put("ValidateMethod", "");
            // 
            // dfsEmail
            // 
            resources.ApplyResources(this.dfsEmail, "dfsEmail");
            this.dfsEmail.Name = "dfsEmail";
            this.dfsEmail.NamedProperties.Put("EnumerateMethod", "");
            this.dfsEmail.NamedProperties.Put("FieldFlags", "262");
            this.dfsEmail.NamedProperties.Put("LovReference", "");
            this.dfsEmail.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsEmail.NamedProperties.Put("SqlColumn", "");
            this.dfsEmail.NamedProperties.Put("ValidateMethod", "");
            // 
            // dfsMobile
            // 
            resources.ApplyResources(this.dfsMobile, "dfsMobile");
            this.dfsMobile.Name = "dfsMobile";
            this.dfsMobile.NamedProperties.Put("EnumerateMethod", "");
            this.dfsMobile.NamedProperties.Put("FieldFlags", "262");
            this.dfsMobile.NamedProperties.Put("LovReference", "");
            this.dfsMobile.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsMobile.NamedProperties.Put("SqlColumn", "");
            this.dfsMobile.NamedProperties.Put("ValidateMethod", "");
            // 
            // dfsPhone
            // 
            resources.ApplyResources(this.dfsPhone, "dfsPhone");
            this.dfsPhone.Name = "dfsPhone";
            this.dfsPhone.NamedProperties.Put("EnumerateMethod", "");
            this.dfsPhone.NamedProperties.Put("FieldFlags", "262");
            this.dfsPhone.NamedProperties.Put("LovReference", "");
            this.dfsPhone.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsPhone.NamedProperties.Put("SqlColumn", "");
            this.dfsPhone.NamedProperties.Put("ValidateMethod", "");
            // 
            // dfsTitle
            // 
            resources.ApplyResources(this.dfsTitle, "dfsTitle");
            this.dfsTitle.Name = "dfsTitle";
            this.dfsTitle.NamedProperties.Put("EnumerateMethod", "");
            this.dfsTitle.NamedProperties.Put("FieldFlags", "262");
            this.dfsTitle.NamedProperties.Put("LovReference", "");
            this.dfsTitle.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsTitle.NamedProperties.Put("SqlColumn", "");
            this.dfsTitle.NamedProperties.Put("ValidateMethod", "");
            // 
            // dfsName
            // 
            resources.ApplyResources(this.dfsName, "dfsName");
            this.dfsName.Name = "dfsName";
            this.dfsName.NamedProperties.Put("EnumerateMethod", "");
            this.dfsName.NamedProperties.Put("FieldFlags", "263");
            this.dfsName.NamedProperties.Put("LovReference", "");
            this.dfsName.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsName.NamedProperties.Put("SqlColumn", "");
            this.dfsName.NamedProperties.Put("ValidateMethod", "");
            this.dfsName.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsName_WindowActions);
            // 
            // labeldfsAddressId
            // 
            resources.ApplyResources(this.labeldfsAddressId, "labeldfsAddressId");
            this.labeldfsAddressId.Name = "labeldfsAddressId";
            // 
            // labeldfsIntercom
            // 
            resources.ApplyResources(this.labeldfsIntercom, "labeldfsIntercom");
            this.labeldfsIntercom.Name = "labeldfsIntercom";
            // 
            // labeldfsPager
            // 
            resources.ApplyResources(this.labeldfsPager, "labeldfsPager");
            this.labeldfsPager.Name = "labeldfsPager";
            // 
            // labeldfsMessenger
            // 
            resources.ApplyResources(this.labeldfsMessenger, "labeldfsMessenger");
            this.labeldfsMessenger.Name = "labeldfsMessenger";
            // 
            // labeldfsWww
            // 
            resources.ApplyResources(this.labeldfsWww, "labeldfsWww");
            this.labeldfsWww.Name = "labeldfsWww";
            // 
            // labeldfsFax
            // 
            resources.ApplyResources(this.labeldfsFax, "labeldfsFax");
            this.labeldfsFax.Name = "labeldfsFax";
            // 
            // labeldfsEmail
            // 
            resources.ApplyResources(this.labeldfsEmail, "labeldfsEmail");
            this.labeldfsEmail.Name = "labeldfsEmail";
            // 
            // labeldfsMobile
            // 
            resources.ApplyResources(this.labeldfsMobile, "labeldfsMobile");
            this.labeldfsMobile.Name = "labeldfsMobile";
            // 
            // labeldfsPhone
            // 
            resources.ApplyResources(this.labeldfsPhone, "labeldfsPhone");
            this.labeldfsPhone.Name = "labeldfsPhone";
            // 
            // labeldfsTitle
            // 
            resources.ApplyResources(this.labeldfsTitle, "labeldfsTitle");
            this.labeldfsTitle.Name = "labeldfsTitle";
            // 
            // labeldfsRole
            // 
            resources.ApplyResources(this.labeldfsRole, "labeldfsRole");
            this.labeldfsRole.Name = "labeldfsRole";
            // 
            // labeldfsName
            // 
            resources.ApplyResources(this.labeldfsName, "labeldfsName");
            this.labeldfsName.Name = "labeldfsName";
            // 
            // cCommandButtonReset
            // 
            resources.ApplyResources(this.cCommandButtonReset, "cCommandButtonReset");
            this.cCommandButtonReset.Command = this.commandReset;
            this.cCommandButtonReset.Name = "cCommandButtonReset";
            // 
            // cbDepartment
            // 
            resources.ApplyResources(this.cbDepartment, "cbDepartment");
            this.cbDepartment.FormattingEnabled = true;
            this.cbDepartment.IsLookup = true;
            this.cbDepartment.Name = "cbDepartment";
            this.cbDepartment.NamedProperties.Put("EnumerateMethod", "CONTACT_DEPARTMENT_API.Enumerate");
            this.cbDepartment.NamedProperties.Put("FieldFlags", "262");
            // 
            // labeldfsDepartment
            // 
            resources.ApplyResources(this.labeldfsDepartment, "labeldfsDepartment");
            this.labeldfsDepartment.Name = "labeldfsDepartment";
            // 
            // cCommandButtonEdit
            // 
            resources.ApplyResources(this.cCommandButtonEdit, "cCommandButtonEdit");
            this.cCommandButtonEdit.Command = this.commandEdit;
            this.cCommandButtonEdit.Name = "cCommandButtonEdit";
            // 
            // cCommandButtonOk
            // 
            this.cCommandButtonOk.AcceleratorKey = System.Windows.Forms.Keys.Return;
            resources.ApplyResources(this.cCommandButtonOk, "cCommandButtonOk");
            this.cCommandButtonOk.Command = this.commandOk;
            this.cCommandButtonOk.Name = "cCommandButtonOk";
            // 
            // commandOk
            // 
            resources.ApplyResources(this.commandOk, "commandOk");
            this.commandOk.EventCategory = Ifs.Fnd.Windows.Forms.CommandEventCategory.Edit;
            this.commandOk.Name = "commandOk";
            this.commandOk.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.commandOk_Execute);
            this.commandOk.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.commandOk_Inquire);
            // 
            // cCommandButtonCancel
            // 
            this.cCommandButtonCancel.AcceleratorKey = System.Windows.Forms.Keys.Escape;
            resources.ApplyResources(this.cCommandButtonCancel, "cCommandButtonCancel");
            this.cCommandButtonCancel.Command = this.commandCancel;
            this.cCommandButtonCancel.Name = "cCommandButtonCancel";
            // 
            // commandCancel
            // 
            resources.ApplyResources(this.commandCancel, "commandCancel");
            this.commandCancel.Name = "commandCancel";
            this.commandCancel.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.commandCancel_Execute);
            // 
            // cCommandButtonList
            // 
            this.cCommandButtonList.AcceleratorKey = System.Windows.Forms.Keys.F8;
            resources.ApplyResources(this.cCommandButtonList, "cCommandButtonList");
            this.cCommandButtonList.Command = this.commandList;
            this.cCommandButtonList.Name = "cCommandButtonList";
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
            // cCommandButtonFind
            // 
            resources.ApplyResources(this.cCommandButtonFind, "cCommandButtonFind");
            this.cCommandButtonFind.Command = this.commandFind;
            this.cCommandButtonFind.Name = "cCommandButtonFind";
            // 
            // commandFind
            // 
            resources.ApplyResources(this.commandFind, "commandFind");
            this.commandFind.Name = "commandFind";
            this.commandFind.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.commandFind_Execute);
            this.commandFind.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.commandFind_Inquire);
            // 
            // dlgAddSupplierContact
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.cCommandButtonFind);
            this.Controls.Add(this.cCommandButtonList);
            this.Controls.Add(this.cCommandButtonCancel);
            this.Controls.Add(this.cCommandButtonOk);
            this.Controls.Add(this.cbDepartment);
            this.Controls.Add(this.cCommandButtonEdit);
            this.Controls.Add(this.labeldfsDepartment);
            this.Controls.Add(this.cCommandButtonReset);
            this.Controls.Add(this.labelPersonId);
            this.Controls.Add(this.dfsInitials);
            this.Controls.Add(this.dfsManagerGuid);
            this.Controls.Add(this.dfsPersonId);
            this.Controls.Add(this.cbRole);
            this.Controls.Add(this.dfsAddressId);
            this.Controls.Add(this.cbCopyAddress);
            this.Controls.Add(this.dfsIntercom);
            this.Controls.Add(this.dfsPager);
            this.Controls.Add(this.dfsMessenger);
            this.Controls.Add(this.dfsWww);
            this.Controls.Add(this.dfsFax);
            this.Controls.Add(this.dfsEmail);
            this.Controls.Add(this.dfsMobile);
            this.Controls.Add(this.dfsPhone);
            this.Controls.Add(this.dfsTitle);
            this.Controls.Add(this.dfsName);
            this.Controls.Add(this.labeldfsAddressId);
            this.Controls.Add(this.labeldfsIntercom);
            this.Controls.Add(this.labeldfsPager);
            this.Controls.Add(this.labeldfsMessenger);
            this.Controls.Add(this.labeldfsWww);
            this.Controls.Add(this.labeldfsFax);
            this.Controls.Add(this.labeldfsEmail);
            this.Controls.Add(this.labeldfsMobile);
            this.Controls.Add(this.labeldfsPhone);
            this.Controls.Add(this.labeldfsTitle);
            this.Controls.Add(this.labeldfsRole);
            this.Controls.Add(this.labeldfsName);
            this.Name = "dlgAddSupplierContact";
            this.NamedProperties.Put("LogicalUnit", "NULL");
            this.ShowIcon = false;
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dlgAddSupplierContact_WindowActions);
            this.ResumeLayout(false);
            this.PerformLayout();

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

        protected Ifs.Fnd.Windows.Forms.FndCommand commandReset;
        protected Ifs.Fnd.Windows.Forms.FndCommand commandEdit;
        protected cBackgroundText labelPersonId;
        public cDataField dfsInitials;
        public cDataField dfsManagerGuid;
        public cDataField dfsPersonId;
        protected cComboBoxMultiSelection cbRole;
        public cDataField dfsAddressId;
        public cCheckBox cbCopyAddress;
        public cDataField dfsIntercom;
        public cDataField dfsPager;
        public cDataField dfsMessenger;
        public cDataField dfsWww;
        public cDataField dfsFax;
        public cDataField dfsEmail;
        public cDataField dfsMobile;
        public cDataField dfsPhone;
        public cDataField dfsTitle;
        public cDataField dfsName;
        protected cBackgroundText labeldfsAddressId;
        protected cBackgroundText labeldfsIntercom;
        protected cBackgroundText labeldfsPager;
        protected cBackgroundText labeldfsMessenger;
        protected cBackgroundText labeldfsWww;
        protected cBackgroundText labeldfsFax;
        protected cBackgroundText labeldfsEmail;
        protected cBackgroundText labeldfsMobile;
        protected cBackgroundText labeldfsPhone;
        protected cBackgroundText labeldfsTitle;
        protected cBackgroundText labeldfsRole;
        protected cBackgroundText labeldfsName;
        protected cCommandButton cCommandButtonReset;
        protected cComboBox cbDepartment;
        protected cBackgroundText labeldfsDepartment;
        protected cCommandButton cCommandButtonEdit;
        protected cCommandButton cCommandButtonOk;
        protected cCommandButton cCommandButtonCancel;
        protected cCommandButton cCommandButtonList;
        protected cCommandButton cCommandButtonFind;
        protected Fnd.Windows.Forms.FndCommand commandOk;
        protected Fnd.Windows.Forms.FndCommand commandCancel;
        protected Fnd.Windows.Forms.FndCommand commandFind;
        protected Fnd.Windows.Forms.FndCommand commandList;

    }
}
