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
// Date     By      Notes
// -----    ------  ---------------------------------------------------------------------------------
// 131029   MaRalk  PBR-1914, Added new fields cbPersonalInterest, cbCampaignInterest, cbDecisionPowerType, cbDepartment, dfsManager,
// 131029           dfsManagerName, dfsManagerCustAddress and cbBlockForUseInCrm. Changed data field dfsRole as a combo box cbRole.
// 140526  MaRalk   PBSC-8831, Added command button cCommandButtonEdit to edit the person first, middle, last names.
// 140526           Added hidden field dfsInitials
// 140829  JanWse   PRSC-2423, Removed F8 as AcceleratorKey for cCommandButtonEdit
// 150903  SudJlk   AFT-1682, Set accelerator key Enter for Ok button.
#endregion

using System;
using System.Text;
using System.Drawing;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel;
using Ifs.Application.Appsrv;
using Ifs.Fnd.ApplicationForms;
using PPJ.Runtime;
using PPJ.Runtime.Sql;
using PPJ.Runtime.Vis;
using PPJ.Runtime.Windows;
using PPJ.Runtime.Windows.QO;

namespace Ifs.Application.Enterp
{

    public partial class dlgAddContact
    {

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Window Controls

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgAddContact));
            this.commandEdit = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.cCommandButtonReset = new Ifs.Fnd.ApplicationForms.cCommandButton();
            this.commandReset = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.dfsInitials = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsManagerGuid = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsPersonId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.cCommandButtonEdit = new Ifs.Fnd.ApplicationForms.cCommandButton();
            this.gbCrmSpecificInfo = new Ifs.Fnd.ApplicationForms.cGroupBox();
            this.cbPersonalInterest = new Ifs.Fnd.ApplicationForms.cComboBoxMultiSelection();
            this.cbBlockForUseInCrm = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.dfsManagerName = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsPersonalInterest = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cbDepartment = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.cbCampaignInterest = new Ifs.Fnd.ApplicationForms.cComboBoxMultiSelection();
            this.cbDecisionPowerType = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.labeldfsCampaignInterest = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.labeldfsManagerName = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.labeldfsDecisionPowerType = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.labeldfsDepartment = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsManagerCustAddress = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsManager = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.labeldfsManagerCustAddress = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsManager = new Ifs.Fnd.ApplicationForms.cDataField();
            this.cbRole = new Ifs.Fnd.ApplicationForms.cComboBoxMultiSelection();
            this.pbList = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbFind = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbCancel = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbOk = new Ifs.Fnd.ApplicationForms.cPushButton();
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
            this.labelPersonId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.ClientArea.SuspendLayout();
            this.gbCrmSpecificInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolBar
            // 
            resources.ApplyResources(this.ToolBar, "ToolBar");
            // 
            // ClientArea
            // 
            this.ClientArea.Controls.Add(this.pbOk);
            this.ClientArea.Controls.Add(this.pbCancel);
            this.ClientArea.Controls.Add(this.pbFind);
            this.ClientArea.Controls.Add(this.pbList);
            this.ClientArea.Controls.Add(this.cCommandButtonReset);
            resources.ApplyResources(this.ClientArea, "ClientArea");
            // 
            // StatusBar
            // 
            resources.ApplyResources(this.StatusBar, "StatusBar");
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.commandEdit);
            this.commandManager.Commands.Add(this.commandReset);
            this.commandManager.Components.Add(this.cCommandButtonReset);
            this.commandManager.Components.Add(this.cCommandButtonEdit);
            this.commandManager.Components.Add(this.pbList);
            this.commandManager.Components.Add(this.pbFind);
            this.commandManager.Components.Add(this.pbCancel);
            this.commandManager.Components.Add(this.pbOk);
            // 
            // commandEdit
            // 
            resources.ApplyResources(this.commandEdit, "commandEdit");
            this.commandEdit.Name = "commandEdit";
            this.commandEdit.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.commandEdit_Execute);
            // 
            // cCommandButtonReset
            // 
            resources.ApplyResources(this.cCommandButtonReset, "cCommandButtonReset");
            this.cCommandButtonReset.Command = this.commandReset;
            this.cCommandButtonReset.Name = "cCommandButtonReset";
            // 
            // commandReset
            // 
            resources.ApplyResources(this.commandReset, "commandReset");
            this.commandReset.Name = "commandReset";
            this.commandReset.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.commandReset_Execute);
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
            // cCommandButtonEdit
            // 
            resources.ApplyResources(this.cCommandButtonEdit, "cCommandButtonEdit");
            this.cCommandButtonEdit.Command = this.commandEdit;
            this.cCommandButtonEdit.Name = "cCommandButtonEdit";
            // 
            // gbCrmSpecificInfo
            // 
            this.gbCrmSpecificInfo.Controls.Add(this.cbPersonalInterest);
            this.gbCrmSpecificInfo.Controls.Add(this.cbBlockForUseInCrm);
            this.gbCrmSpecificInfo.Controls.Add(this.dfsManagerName);
            this.gbCrmSpecificInfo.Controls.Add(this.labeldfsPersonalInterest);
            this.gbCrmSpecificInfo.Controls.Add(this.cbDepartment);
            this.gbCrmSpecificInfo.Controls.Add(this.cbCampaignInterest);
            this.gbCrmSpecificInfo.Controls.Add(this.cbDecisionPowerType);
            this.gbCrmSpecificInfo.Controls.Add(this.labeldfsCampaignInterest);
            this.gbCrmSpecificInfo.Controls.Add(this.labeldfsManagerName);
            this.gbCrmSpecificInfo.Controls.Add(this.labeldfsDecisionPowerType);
            this.gbCrmSpecificInfo.Controls.Add(this.labeldfsDepartment);
            this.gbCrmSpecificInfo.Controls.Add(this.dfsManagerCustAddress);
            this.gbCrmSpecificInfo.Controls.Add(this.labeldfsManager);
            this.gbCrmSpecificInfo.Controls.Add(this.labeldfsManagerCustAddress);
            this.gbCrmSpecificInfo.Controls.Add(this.dfsManager);
            resources.ApplyResources(this.gbCrmSpecificInfo, "gbCrmSpecificInfo");
            this.gbCrmSpecificInfo.Name = "gbCrmSpecificInfo";
            this.gbCrmSpecificInfo.TabStop = false;
            // 
            // cbPersonalInterest
            // 
            resources.ApplyResources(this.cbPersonalInterest, "cbPersonalInterest");
            this.cbPersonalInterest.FormattingEnabled = true;
            this.cbPersonalInterest.IsLookup = true;
            this.cbPersonalInterest.Items = null;
            this.cbPersonalInterest.Name = "cbPersonalInterest";
            this.cbPersonalInterest.NamedProperties.Put("EnumerateMethod", "PERSONAL_INTEREST_API.Enumerate");
            this.cbPersonalInterest.NamedProperties.Put("FieldFlags", "262");
            this.cbPersonalInterest.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbCampaignInterest_WindowActions);
            // 
            // cbBlockForUseInCrm
            // 
            resources.ApplyResources(this.cbBlockForUseInCrm, "cbBlockForUseInCrm");
            this.cbBlockForUseInCrm.Name = "cbBlockForUseInCrm";
            this.cbBlockForUseInCrm.NamedProperties.Put("DataType", "5");
            this.cbBlockForUseInCrm.NamedProperties.Put("EnumerateMethod", "");
            this.cbBlockForUseInCrm.NamedProperties.Put("FieldFlags", "262");
            this.cbBlockForUseInCrm.NamedProperties.Put("LovReference", "");
            this.cbBlockForUseInCrm.NamedProperties.Put("ResizeableChildObject", "");
            this.cbBlockForUseInCrm.NamedProperties.Put("SqlColumn", "");
            this.cbBlockForUseInCrm.NamedProperties.Put("ValidateMethod", "");
            this.cbBlockForUseInCrm.NamedProperties.Put("XDataLength", "");
            this.cbBlockForUseInCrm.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbBlockForUseInCrm_WindowActions);
            // 
            // dfsManagerName
            // 
            resources.ApplyResources(this.dfsManagerName, "dfsManagerName");
            this.dfsManagerName.Name = "dfsManagerName";
            this.dfsManagerName.NamedProperties.Put("EnumerateMethod", "");
            this.dfsManagerName.NamedProperties.Put("LovReference", "");
            this.dfsManagerName.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsManagerName.NamedProperties.Put("SqlColumn", "");
            this.dfsManagerName.NamedProperties.Put("ValidateMethod", "");
            // 
            // labeldfsPersonalInterest
            // 
            resources.ApplyResources(this.labeldfsPersonalInterest, "labeldfsPersonalInterest");
            this.labeldfsPersonalInterest.Name = "labeldfsPersonalInterest";
            // 
            // cbDepartment
            // 
            resources.ApplyResources(this.cbDepartment, "cbDepartment");
            this.cbDepartment.FormattingEnabled = true;
            this.cbDepartment.IsLookup = true;
            this.cbDepartment.Name = "cbDepartment";
            this.cbDepartment.NamedProperties.Put("EnumerateMethod", "CONTACT_DEPARTMENT_API.Enumerate");
            this.cbDepartment.NamedProperties.Put("FieldFlags", "262");
            this.cbDepartment.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbDepartment_WindowActions);
            // 
            // cbCampaignInterest
            // 
            this.cbCampaignInterest.DropDownWidth = 170;
            resources.ApplyResources(this.cbCampaignInterest, "cbCampaignInterest");
            this.cbCampaignInterest.FormattingEnabled = true;
            this.cbCampaignInterest.IsLookup = true;
            this.cbCampaignInterest.Items = null;
            this.cbCampaignInterest.Name = "cbCampaignInterest";
            this.cbCampaignInterest.NamedProperties.Put("EnumerateMethod", "BUSINESS_CAMPAIGN_INTEREST_API.Enumerate");
            this.cbCampaignInterest.NamedProperties.Put("FieldFlags", "262");
            this.cbCampaignInterest.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbCampaignInterest_WindowActions);
            // 
            // cbDecisionPowerType
            // 
            resources.ApplyResources(this.cbDecisionPowerType, "cbDecisionPowerType");
            this.cbDecisionPowerType.FormattingEnabled = true;
            this.cbDecisionPowerType.IsLookup = true;
            this.cbDecisionPowerType.Name = "cbDecisionPowerType";
            this.cbDecisionPowerType.NamedProperties.Put("EnumerateMethod", "DECISION_POWER_TYPE_API.Enumerate");
            this.cbDecisionPowerType.NamedProperties.Put("FieldFlags", "262");
            this.cbDecisionPowerType.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbDecisionPowerType_WindowActions);
            // 
            // labeldfsCampaignInterest
            // 
            resources.ApplyResources(this.labeldfsCampaignInterest, "labeldfsCampaignInterest");
            this.labeldfsCampaignInterest.Name = "labeldfsCampaignInterest";
            // 
            // labeldfsManagerName
            // 
            resources.ApplyResources(this.labeldfsManagerName, "labeldfsManagerName");
            this.labeldfsManagerName.Name = "labeldfsManagerName";
            // 
            // labeldfsDecisionPowerType
            // 
            resources.ApplyResources(this.labeldfsDecisionPowerType, "labeldfsDecisionPowerType");
            this.labeldfsDecisionPowerType.Name = "labeldfsDecisionPowerType";
            // 
            // labeldfsDepartment
            // 
            resources.ApplyResources(this.labeldfsDepartment, "labeldfsDepartment");
            this.labeldfsDepartment.Name = "labeldfsDepartment";
            // 
            // dfsManagerCustAddress
            // 
            this.dfsManagerCustAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsManagerCustAddress, "dfsManagerCustAddress");
            this.dfsManagerCustAddress.Name = "dfsManagerCustAddress";
            this.dfsManagerCustAddress.NamedProperties.Put("EnumerateMethod", "");
            this.dfsManagerCustAddress.NamedProperties.Put("FieldFlags", "262");
            this.dfsManagerCustAddress.NamedProperties.Put("LovReference", "CUST_INFO_CONTACT_LOV2_PUB(CUSTOMER_ID)");
            this.dfsManagerCustAddress.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsManagerCustAddress.NamedProperties.Put("SqlColumn", "");
            this.dfsManagerCustAddress.NamedProperties.Put("ValidateMethod", "");
            this.dfsManagerCustAddress.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsManagerCustAddress_WindowActions);
            // 
            // labeldfsManager
            // 
            resources.ApplyResources(this.labeldfsManager, "labeldfsManager");
            this.labeldfsManager.Name = "labeldfsManager";
            // 
            // labeldfsManagerCustAddress
            // 
            resources.ApplyResources(this.labeldfsManagerCustAddress, "labeldfsManagerCustAddress");
            this.labeldfsManagerCustAddress.Name = "labeldfsManagerCustAddress";
            // 
            // dfsManager
            // 
            this.dfsManager.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsManager, "dfsManager");
            this.dfsManager.Name = "dfsManager";
            this.dfsManager.NamedProperties.Put("EnumerateMethod", "");
            this.dfsManager.NamedProperties.Put("FieldFlags", "262");
            this.dfsManager.NamedProperties.Put("LovReference", "CUST_INFO_CONTACT_LOV2_PUB(CUSTOMER_ID)");
            this.dfsManager.NamedProperties.Put("ResizeableChildObject", "");
            this.dfsManager.NamedProperties.Put("SqlColumn", "");
            this.dfsManager.NamedProperties.Put("ValidateMethod", "");
            this.dfsManager.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsManager_WindowActions);
            // 
            // cbRole
            // 
            resources.ApplyResources(this.cbRole, "cbRole");
            this.cbRole.FormattingEnabled = true;
            this.cbRole.Items = null;
            this.cbRole.Name = "cbRole";
            this.cbRole.NamedProperties.Put("EnumerateMethod", "CONTACT_ROLE_API.Enumerate");
            this.cbRole.NamedProperties.Put("FieldFlags", "262");
            this.cbRole.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cbRole_WindowActions);
            // 
            // pbList
            // 
            this.pbList.AcceleratorKey = System.Windows.Forms.Keys.F8;
            resources.ApplyResources(this.pbList, "pbList");
            this.pbList.Name = "pbList";
            this.pbList.NamedProperties.Put("MethodId", "18385");
            this.pbList.NamedProperties.Put("MethodParameter", "List");
            this.pbList.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // pbFind
            // 
            resources.ApplyResources(this.pbFind, "pbFind");
            this.pbFind.Name = "pbFind";
            this.pbFind.NamedProperties.Put("MethodId", "18385");
            this.pbFind.NamedProperties.Put("MethodParameter", "Find");
            this.pbFind.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // pbCancel
            // 
            this.pbCancel.AcceleratorKey = System.Windows.Forms.Keys.Escape;
            resources.ApplyResources(this.pbCancel, "pbCancel");
            this.pbCancel.Name = "pbCancel";
            this.pbCancel.NamedProperties.Put("MethodId", "18385");
            this.pbCancel.NamedProperties.Put("MethodParameter", "Cancel");
            this.pbCancel.NamedProperties.Put("ResizableChildObject", "");
            this.pbCancel.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // pbOk
            // 
            this.pbOk.AcceleratorKey = System.Windows.Forms.Keys.Return;
            resources.ApplyResources(this.pbOk, "pbOk");
            this.pbOk.Name = "pbOk";
            this.pbOk.NamedProperties.Put("MethodId", "18385");
            this.pbOk.NamedProperties.Put("MethodParameter", "Ok");
            this.pbOk.NamedProperties.Put("ResizableChildObject", "");
            this.pbOk.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // dfsAddressId
            // 
            this.dfsAddressId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsAddressId, "dfsAddressId");
            this.dfsAddressId.Name = "dfsAddressId";
            this.dfsAddressId.NamedProperties.Put("EnumerateMethod", "");
            this.dfsAddressId.NamedProperties.Put("FieldFlags", "262");
            this.dfsAddressId.NamedProperties.Put("LovReference", "CUSTOMER_INFO_ADDRESS(CUSTOMER_ID)");
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
            this.dfsIntercom.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsIntercom_WindowActions);
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
            this.dfsPager.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsPager_WindowActions);
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
            this.dfsMessenger.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsMessenger_WindowActions);
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
            this.dfsWww.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsWww_WindowActions);
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
            this.dfsFax.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsFax_WindowActions);
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
            this.dfsEmail.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsEmail_WindowActions);
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
            this.dfsMobile.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsMobile_WindowActions);
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
            this.dfsPhone.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsPhone_WindowActions);
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
            this.dfsTitle.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsTitle_WindowActions);
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
            // labelPersonId
            // 
            resources.ApplyResources(this.labelPersonId, "labelPersonId");
            this.labelPersonId.Name = "labelPersonId";
            // 
            // dlgAddContact
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.labelPersonId);
            this.Controls.Add(this.dfsInitials);
            this.Controls.Add(this.dfsManagerGuid);
            this.Controls.Add(this.dfsPersonId);
            this.Controls.Add(this.cCommandButtonEdit);
            this.Controls.Add(this.gbCrmSpecificInfo);
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
            this.Name = "dlgAddContact";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "NULL");
            this.NamedProperties.Put("PackageName", "");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("ViewName", "");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.ShowIcon = false;
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dlgAddContact_WindowActions);
            this.Controls.SetChildIndex(this.ClientArea, 0);
            this.Controls.SetChildIndex(this.labeldfsName, 0);
            this.Controls.SetChildIndex(this.labeldfsRole, 0);
            this.Controls.SetChildIndex(this.labeldfsTitle, 0);
            this.Controls.SetChildIndex(this.labeldfsPhone, 0);
            this.Controls.SetChildIndex(this.labeldfsMobile, 0);
            this.Controls.SetChildIndex(this.labeldfsEmail, 0);
            this.Controls.SetChildIndex(this.labeldfsFax, 0);
            this.Controls.SetChildIndex(this.labeldfsWww, 0);
            this.Controls.SetChildIndex(this.labeldfsMessenger, 0);
            this.Controls.SetChildIndex(this.labeldfsPager, 0);
            this.Controls.SetChildIndex(this.labeldfsIntercom, 0);
            this.Controls.SetChildIndex(this.labeldfsAddressId, 0);
            this.Controls.SetChildIndex(this.dfsName, 0);
            this.Controls.SetChildIndex(this.dfsTitle, 0);
            this.Controls.SetChildIndex(this.dfsPhone, 0);
            this.Controls.SetChildIndex(this.dfsMobile, 0);
            this.Controls.SetChildIndex(this.dfsEmail, 0);
            this.Controls.SetChildIndex(this.dfsFax, 0);
            this.Controls.SetChildIndex(this.dfsWww, 0);
            this.Controls.SetChildIndex(this.dfsMessenger, 0);
            this.Controls.SetChildIndex(this.dfsPager, 0);
            this.Controls.SetChildIndex(this.dfsIntercom, 0);
            this.Controls.SetChildIndex(this.cbCopyAddress, 0);
            this.Controls.SetChildIndex(this.dfsAddressId, 0);
            this.Controls.SetChildIndex(this.cbRole, 0);
            this.Controls.SetChildIndex(this.gbCrmSpecificInfo, 0);
            this.Controls.SetChildIndex(this.cCommandButtonEdit, 0);
            this.Controls.SetChildIndex(this.dfsPersonId, 0);
            this.Controls.SetChildIndex(this.dfsManagerGuid, 0);
            this.Controls.SetChildIndex(this.dfsInitials, 0);
            this.Controls.SetChildIndex(this.labelPersonId, 0);
            this.Controls.SetChildIndex(this.StatusBar, 0);
            this.Controls.SetChildIndex(this.ToolBar, 0);
            this.ClientArea.ResumeLayout(false);
            this.gbCrmSpecificInfo.ResumeLayout(false);
            this.gbCrmSpecificInfo.PerformLayout();
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

        protected Fnd.Windows.Forms.FndCommand commandEdit;
        protected Fnd.Windows.Forms.FndCommand commandReset;
        protected cCommandButton cCommandButtonReset;
        protected cCommandButton cCommandButtonEdit;
        public cPushButton pbList;
        public cPushButton pbFind;
        public cPushButton pbCancel;
        public cPushButton pbOk;
        public cDataField dfsInitials;
        public cDataField dfsManagerGuid;
        public cDataField dfsPersonId;
        protected cGroupBox gbCrmSpecificInfo;
        protected cComboBoxMultiSelection cbPersonalInterest;
        public cCheckBox cbBlockForUseInCrm;
        public cDataField dfsManagerName;
        protected cBackgroundText labeldfsPersonalInterest;
        protected cComboBox cbDepartment;
        protected cComboBoxMultiSelection cbCampaignInterest;
        protected cComboBox cbDecisionPowerType;
        protected cBackgroundText labeldfsCampaignInterest;
        protected cBackgroundText labeldfsManagerName;
        protected cBackgroundText labeldfsDecisionPowerType;
        protected cBackgroundText labeldfsDepartment;
        public cDataField dfsManagerCustAddress;
        protected cBackgroundText labeldfsManager;
        protected cBackgroundText labeldfsManagerCustAddress;
        public cDataField dfsManager;
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
        protected cBackgroundText labelPersonId;
    }
}
