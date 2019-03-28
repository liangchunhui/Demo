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
// 130115    MaRalk  PBR-1203, Removed LOV reference CUSTOMER_INFO from colsCustomerId column.
// 150813    MaRalk  BLU-1182, Added new column colPersonInfoAddressWww.
// 150813            Modified colPersonInfoAddressE_Mail column as hyperlink enabled.
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
	
	public partial class tbwCustomerInfoContact
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cColumn colsCustomerId;
		public cColumn colsPersonId;
		public cColumn colPersonInfoName;
		public cColumn colPersonInfoTitle;
		public cColumn colsCustomerAddress;
		public cColumn colsContactAddress;
		public cCheckBoxColumn colAddressPrimary;
		public cCheckBoxColumn colAddressSecondary;
		public cCheckBoxColumn colCustomerPrimary;
		public cCheckBoxColumn colCustomerSecondary;
		public cColumn colPersonInfoAddressPhone;
		public cColumn colPersonInfoAddressMobile;
		public cColumn colPersonInfoAddressE_Mail;
		public cColumn colPersonInfoAddressFax;
		public cColumn colPersonInfoAddressPager;
		public cColumn colPersonInfoAddressIntercom;
		public cColumn colsNoteText;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwCustomerInfoContact));
            this.menuTbwMethods_menu_Add_Contact___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.colsCustomerId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsPersonId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colPersonInfoName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colPersonInfoTitle = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsCustomerAddress = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsContactAddress = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colAddressPrimary = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.colAddressSecondary = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.colCustomerPrimary = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.colCustomerSecondary = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.colPersonInfoAddressPhone = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colPersonInfoAddressMobile = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colPersonInfoAddressE_Mail = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colPersonInfoAddressFax = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colPersonInfoAddressPager = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colPersonInfoAddressIntercom = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsNoteText = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuTbwMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem__Add = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.colsBlockedForCrmObjectsDb = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.colsPersonalInterest = new Ifs.Fnd.ApplicationForms.cMultiSelectionColumn();
            this.colsCampaignInterest = new Ifs.Fnd.ApplicationForms.cMultiSelectionColumn();
            this.colsDecisionPowerType = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.colsDepartment = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.colsManager = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsManagerName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsManagerCustAddress = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsManagerGuid = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsRole = new Ifs.Fnd.ApplicationForms.cMultiSelectionColumn();
            this.colsMainRepresentativeId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsMainRepresentativeName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsGuid = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsCustomerName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colPersonInfoAddressWww = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsConnectAllCustAddrDb = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.menuTbwMethods.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuTbwMethods_menu_Add_Contact___);
            this.commandManager.ContextMenus.Add(this.menuTbwMethods);
            // 
            // menuTbwMethods_menu_Add_Contact___
            // 
            resources.ApplyResources(this.menuTbwMethods_menu_Add_Contact___, "menuTbwMethods_menu_Add_Contact___");
            this.menuTbwMethods_menu_Add_Contact___.Name = "menuTbwMethods_menu_Add_Contact___";
            this.menuTbwMethods_menu_Add_Contact___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Add_Execute);
            this.menuTbwMethods_menu_Add_Contact___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Add_Inquire);
            // 
            // colsCustomerId
            // 
            this.colsCustomerId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.colsCustomerId, "colsCustomerId");
            this.colsCustomerId.MaxLength = 20;
            this.colsCustomerId.Name = "colsCustomerId";
            this.colsCustomerId.NamedProperties.Put("EnumerateMethod", "");
            this.colsCustomerId.NamedProperties.Put("FieldFlags", "4163");
            this.colsCustomerId.NamedProperties.Put("LovReference", "");
            this.colsCustomerId.NamedProperties.Put("SqlColumn", "CUSTOMER_ID");
            this.colsCustomerId.NamedProperties.Put("ValidateMethod", "");
            this.colsCustomerId.Position = 7;
            // 
            // colsPersonId
            // 
            this.colsPersonId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsPersonId.MaxLength = 20;
            this.colsPersonId.Name = "colsPersonId";
            this.colsPersonId.NamedProperties.Put("EnumerateMethod", "");
            this.colsPersonId.NamedProperties.Put("FieldFlags", "99");
            this.colsPersonId.NamedProperties.Put("LovReference", "PERSON_INFO_ALL");
            this.colsPersonId.NamedProperties.Put("SqlColumn", "PERSON_ID");
            this.colsPersonId.Position = 3;
            resources.ApplyResources(this.colsPersonId, "colsPersonId");
            this.colsPersonId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsPersonId_WindowActions);
            // 
            // colPersonInfoName
            // 
            this.colPersonInfoName.MaxLength = 2000;
            this.colPersonInfoName.Name = "colPersonInfoName";
            this.colPersonInfoName.NamedProperties.Put("EnumerateMethod", "");
            this.colPersonInfoName.NamedProperties.Put("FieldFlags", "304");
            this.colPersonInfoName.NamedProperties.Put("LovReference", "");
            this.colPersonInfoName.NamedProperties.Put("ParentName", "colsPersonId");
            this.colPersonInfoName.NamedProperties.Put("ResizeableChildObject", "");
            this.colPersonInfoName.NamedProperties.Put("SqlColumn", "PERSON_INFO_API.Get_Name(PERSON_ID)");
            this.colPersonInfoName.NamedProperties.Put("ValidateMethod", "");
            this.colPersonInfoName.Position = 4;
            resources.ApplyResources(this.colPersonInfoName, "colPersonInfoName");
            // 
            // colPersonInfoTitle
            // 
            this.colPersonInfoTitle.MaxLength = 2000;
            this.colPersonInfoTitle.Name = "colPersonInfoTitle";
            this.colPersonInfoTitle.NamedProperties.Put("EnumerateMethod", "");
            this.colPersonInfoTitle.NamedProperties.Put("FieldFlags", "304");
            this.colPersonInfoTitle.NamedProperties.Put("LovReference", "");
            this.colPersonInfoTitle.NamedProperties.Put("ParentName", "colsPersonId");
            this.colPersonInfoTitle.NamedProperties.Put("ResizeableChildObject", "");
            this.colPersonInfoTitle.NamedProperties.Put("SqlColumn", "PERSON_INFO_API.Get_Title(PERSON_ID)");
            this.colPersonInfoTitle.NamedProperties.Put("ValidateMethod", "");
            this.colPersonInfoTitle.Position = 6;
            resources.ApplyResources(this.colPersonInfoTitle, "colPersonInfoTitle");
            // 
            // colsCustomerAddress
            // 
            this.colsCustomerAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsCustomerAddress.MaxLength = 50;
            this.colsCustomerAddress.Name = "colsCustomerAddress";
            this.colsCustomerAddress.NamedProperties.Put("EnumerateMethod", "");
            this.colsCustomerAddress.NamedProperties.Put("FieldFlags", "294");
            this.colsCustomerAddress.NamedProperties.Put("LovReference", "CUSTOMER_INFO_ADDRESS(CUSTOMER_ID)");
            this.colsCustomerAddress.NamedProperties.Put("ResizeableChildObject", "");
            this.colsCustomerAddress.NamedProperties.Put("SqlColumn", "CUSTOMER_ADDRESS");
            this.colsCustomerAddress.NamedProperties.Put("ValidateMethod", "");
            this.colsCustomerAddress.Position = 9;
            resources.ApplyResources(this.colsCustomerAddress, "colsCustomerAddress");
            // 
            // colsContactAddress
            // 
            this.colsContactAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsContactAddress.MaxLength = 50;
            this.colsContactAddress.Name = "colsContactAddress";
            this.colsContactAddress.NamedProperties.Put("EnumerateMethod", "");
            this.colsContactAddress.NamedProperties.Put("FieldFlags", "294");
            this.colsContactAddress.NamedProperties.Put("LovReference", "PERSON_INFO_ADDRESS1(PERSON_ID)");
            this.colsContactAddress.NamedProperties.Put("SqlColumn", "CONTACT_ADDRESS");
            this.colsContactAddress.Position = 11;
            resources.ApplyResources(this.colsContactAddress, "colsContactAddress");
            // 
            // colAddressPrimary
            // 
            this.colAddressPrimary.Name = "colAddressPrimary";
            this.colAddressPrimary.NamedProperties.Put("EnumerateMethod", "");
            this.colAddressPrimary.NamedProperties.Put("FieldFlags", "295");
            this.colAddressPrimary.NamedProperties.Put("LovReference", "");
            this.colAddressPrimary.NamedProperties.Put("SqlColumn", "ADDRESS_PRIMARY");
            this.colAddressPrimary.Position = 23;
            resources.ApplyResources(this.colAddressPrimary, "colAddressPrimary");
            // 
            // colAddressSecondary
            // 
            this.colAddressSecondary.Name = "colAddressSecondary";
            this.colAddressSecondary.NamedProperties.Put("EnumerateMethod", "");
            this.colAddressSecondary.NamedProperties.Put("FieldFlags", "295");
            this.colAddressSecondary.NamedProperties.Put("LovReference", "");
            this.colAddressSecondary.NamedProperties.Put("SqlColumn", "ADDRESS_SECONDARY");
            this.colAddressSecondary.Position = 24;
            resources.ApplyResources(this.colAddressSecondary, "colAddressSecondary");
            // 
            // colCustomerPrimary
            // 
            this.colCustomerPrimary.Name = "colCustomerPrimary";
            this.colCustomerPrimary.NamedProperties.Put("EnumerateMethod", "");
            this.colCustomerPrimary.NamedProperties.Put("FieldFlags", "295");
            this.colCustomerPrimary.NamedProperties.Put("LovReference", "");
            this.colCustomerPrimary.NamedProperties.Put("SqlColumn", "CUSTOMER_PRIMARY");
            this.colCustomerPrimary.Position = 25;
            resources.ApplyResources(this.colCustomerPrimary, "colCustomerPrimary");
            // 
            // colCustomerSecondary
            // 
            this.colCustomerSecondary.Name = "colCustomerSecondary";
            this.colCustomerSecondary.NamedProperties.Put("EnumerateMethod", "");
            this.colCustomerSecondary.NamedProperties.Put("FieldFlags", "295");
            this.colCustomerSecondary.NamedProperties.Put("LovReference", "");
            this.colCustomerSecondary.NamedProperties.Put("SqlColumn", "CUSTOMER_SECONDARY");
            this.colCustomerSecondary.Position = 26;
            resources.ApplyResources(this.colCustomerSecondary, "colCustomerSecondary");
            // 
            // colPersonInfoAddressPhone
            // 
            this.colPersonInfoAddressPhone.MaxLength = 2000;
            this.colPersonInfoAddressPhone.Name = "colPersonInfoAddressPhone";
            this.colPersonInfoAddressPhone.NamedProperties.Put("EnumerateMethod", "");
            this.colPersonInfoAddressPhone.NamedProperties.Put("FieldFlags", "304");
            this.colPersonInfoAddressPhone.NamedProperties.Put("LovReference", "");
            this.colPersonInfoAddressPhone.NamedProperties.Put("ParentName", "colsContactAddress");
            this.colPersonInfoAddressPhone.NamedProperties.Put("ResizeableChildObject", "");
            this.colPersonInfoAddressPhone.NamedProperties.Put("SqlColumn", "Comm_Method_API.Get_Value(\'PERSON\', person_id, &AO.Comm_Method_Code_API.Decode(\'P" +
        "HONE\'), 1, CONTACT_ADDRESS)");
            this.colPersonInfoAddressPhone.NamedProperties.Put("ValidateMethod", "");
            this.colPersonInfoAddressPhone.Position = 27;
            resources.ApplyResources(this.colPersonInfoAddressPhone, "colPersonInfoAddressPhone");
            // 
            // colPersonInfoAddressMobile
            // 
            this.colPersonInfoAddressMobile.MaxLength = 2000;
            this.colPersonInfoAddressMobile.Name = "colPersonInfoAddressMobile";
            this.colPersonInfoAddressMobile.NamedProperties.Put("EnumerateMethod", "");
            this.colPersonInfoAddressMobile.NamedProperties.Put("FieldFlags", "304");
            this.colPersonInfoAddressMobile.NamedProperties.Put("LovReference", "");
            this.colPersonInfoAddressMobile.NamedProperties.Put("ParentName", "colsContactAddress");
            this.colPersonInfoAddressMobile.NamedProperties.Put("ResizeableChildObject", "");
            this.colPersonInfoAddressMobile.NamedProperties.Put("SqlColumn", "Comm_Method_API.Get_Value(\'PERSON\', person_id, &AO.Comm_Method_Code_API.Decode(\'M" +
        "OBILE\'), 1, CONTACT_ADDRESS)");
            this.colPersonInfoAddressMobile.NamedProperties.Put("ValidateMethod", "");
            this.colPersonInfoAddressMobile.Position = 28;
            resources.ApplyResources(this.colPersonInfoAddressMobile, "colPersonInfoAddressMobile");
            // 
            // colPersonInfoAddressE_Mail
            // 
            this.colPersonInfoAddressE_Mail.DetectHyperLinks = true;
            this.colPersonInfoAddressE_Mail.MaxLength = 2000;
            this.colPersonInfoAddressE_Mail.Name = "colPersonInfoAddressE_Mail";
            this.colPersonInfoAddressE_Mail.NamedProperties.Put("EnumerateMethod", "");
            this.colPersonInfoAddressE_Mail.NamedProperties.Put("FieldFlags", "304");
            this.colPersonInfoAddressE_Mail.NamedProperties.Put("LovReference", "");
            this.colPersonInfoAddressE_Mail.NamedProperties.Put("ParentName", "colsContactAddress");
            this.colPersonInfoAddressE_Mail.NamedProperties.Put("ResizeableChildObject", "");
            this.colPersonInfoAddressE_Mail.NamedProperties.Put("SqlColumn", "Comm_Method_API.Get_Value(\'PERSON\', person_id, &AO.Comm_Method_Code_API.Decode(\'E" +
        "_MAIL\'), 1, CONTACT_ADDRESS)");
            this.colPersonInfoAddressE_Mail.NamedProperties.Put("ValidateMethod", "");
            this.colPersonInfoAddressE_Mail.Position = 29;
            resources.ApplyResources(this.colPersonInfoAddressE_Mail, "colPersonInfoAddressE_Mail");
            // 
            // colPersonInfoAddressFax
            // 
            this.colPersonInfoAddressFax.MaxLength = 2000;
            this.colPersonInfoAddressFax.Name = "colPersonInfoAddressFax";
            this.colPersonInfoAddressFax.NamedProperties.Put("EnumerateMethod", "");
            this.colPersonInfoAddressFax.NamedProperties.Put("FieldFlags", "304");
            this.colPersonInfoAddressFax.NamedProperties.Put("LovReference", "");
            this.colPersonInfoAddressFax.NamedProperties.Put("ParentName", "colsContactAddress");
            this.colPersonInfoAddressFax.NamedProperties.Put("ResizeableChildObject", "");
            this.colPersonInfoAddressFax.NamedProperties.Put("SqlColumn", "Comm_Method_API.Get_Value(\'PERSON\', person_id, Comm_Method_Code_API.Decode(\'FAX\')" +
        ", 1, CONTACT_ADDRESS)");
            this.colPersonInfoAddressFax.NamedProperties.Put("ValidateMethod", "");
            this.colPersonInfoAddressFax.Position = 30;
            resources.ApplyResources(this.colPersonInfoAddressFax, "colPersonInfoAddressFax");
            // 
            // colPersonInfoAddressPager
            // 
            this.colPersonInfoAddressPager.MaxLength = 2000;
            this.colPersonInfoAddressPager.Name = "colPersonInfoAddressPager";
            this.colPersonInfoAddressPager.NamedProperties.Put("EnumerateMethod", "");
            this.colPersonInfoAddressPager.NamedProperties.Put("FieldFlags", "304");
            this.colPersonInfoAddressPager.NamedProperties.Put("LovReference", "");
            this.colPersonInfoAddressPager.NamedProperties.Put("ParentName", "colsContactAddress");
            this.colPersonInfoAddressPager.NamedProperties.Put("ResizeableChildObject", "");
            this.colPersonInfoAddressPager.NamedProperties.Put("SqlColumn", "Comm_Method_API.Get_Value(\'PERSON\', person_id, &AO.Comm_Method_Code_API.Decode(\'P" +
        "AGER\'), 1, CONTACT_ADDRESS)");
            this.colPersonInfoAddressPager.NamedProperties.Put("ValidateMethod", "");
            this.colPersonInfoAddressPager.Position = 31;
            resources.ApplyResources(this.colPersonInfoAddressPager, "colPersonInfoAddressPager");
            // 
            // colPersonInfoAddressIntercom
            // 
            this.colPersonInfoAddressIntercom.MaxLength = 2000;
            this.colPersonInfoAddressIntercom.Name = "colPersonInfoAddressIntercom";
            this.colPersonInfoAddressIntercom.NamedProperties.Put("EnumerateMethod", "");
            this.colPersonInfoAddressIntercom.NamedProperties.Put("FieldFlags", "304");
            this.colPersonInfoAddressIntercom.NamedProperties.Put("LovReference", "");
            this.colPersonInfoAddressIntercom.NamedProperties.Put("ParentName", "colsContactAddress");
            this.colPersonInfoAddressIntercom.NamedProperties.Put("ResizeableChildObject", "");
            this.colPersonInfoAddressIntercom.NamedProperties.Put("SqlColumn", "Comm_Method_API.Get_Value(\'PERSON\', person_id, &AO.Comm_Method_Code_API.Decode(\'I" +
        "NTERCOM\'), 1, CONTACT_ADDRESS)");
            this.colPersonInfoAddressIntercom.NamedProperties.Put("ValidateMethod", "");
            this.colPersonInfoAddressIntercom.Position = 32;
            resources.ApplyResources(this.colPersonInfoAddressIntercom, "colPersonInfoAddressIntercom");
            // 
            // colsNoteText
            // 
            this.colsNoteText.MaxLength = 50000;
            this.colsNoteText.Name = "colsNoteText";
            this.colsNoteText.NamedProperties.Put("EnumerateMethod", "");
            this.colsNoteText.NamedProperties.Put("FieldFlags", "310");
            this.colsNoteText.NamedProperties.Put("LovReference", "");
            this.colsNoteText.NamedProperties.Put("ResizeableChildObject", "");
            this.colsNoteText.NamedProperties.Put("SqlColumn", "NOTE_TEXT");
            this.colsNoteText.NamedProperties.Put("ValidateMethod", "");
            this.colsNoteText.Position = 34;
            resources.ApplyResources(this.colsNoteText, "colsNoteText");
            // 
            // menuTbwMethods
            // 
            this.menuTbwMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem__Add});
            this.menuTbwMethods.Name = "menuTbwMethods";
            resources.ApplyResources(this.menuTbwMethods, "menuTbwMethods");
            // 
            // menuItem__Add
            // 
            this.menuItem__Add.Command = this.menuTbwMethods_menu_Add_Contact___;
            this.menuItem__Add.Name = "menuItem__Add";
            resources.ApplyResources(this.menuItem__Add, "menuItem__Add");
            this.menuItem__Add.Text = "&Add Contact...";
            // 
            // colsBlockedForCrmObjectsDb
            // 
            this.colsBlockedForCrmObjectsDb.Name = "colsBlockedForCrmObjectsDb";
            this.colsBlockedForCrmObjectsDb.NamedProperties.Put("EnumerateMethod", "");
            this.colsBlockedForCrmObjectsDb.NamedProperties.Put("FieldFlags", "294");
            this.colsBlockedForCrmObjectsDb.NamedProperties.Put("LovReference", "");
            this.colsBlockedForCrmObjectsDb.NamedProperties.Put("SqlColumn", "BLOCKED_FOR_CRM_OBJECTS_DB");
            this.colsBlockedForCrmObjectsDb.Position = 12;
            resources.ApplyResources(this.colsBlockedForCrmObjectsDb, "colsBlockedForCrmObjectsDb");
            // 
            // colsPersonalInterest
            // 
            this.colsPersonalInterest.IsLookup = true;
            this.colsPersonalInterest.MaxLength = 4000;
            this.colsPersonalInterest.Name = "colsPersonalInterest";
            this.colsPersonalInterest.NamedProperties.Put("EnumerateMethod", "PERSONAL_INTEREST_API.Enumerate");
            this.colsPersonalInterest.NamedProperties.Put("FieldFlags", "294");
            this.colsPersonalInterest.NamedProperties.Put("LovReference", "");
            this.colsPersonalInterest.NamedProperties.Put("SqlColumn", "PERSONAL_INTEREST");
            this.colsPersonalInterest.Position = 15;
            resources.ApplyResources(this.colsPersonalInterest, "colsPersonalInterest");
            // 
            // colsCampaignInterest
            // 
            this.colsCampaignInterest.IsLookup = true;
            this.colsCampaignInterest.MaxLength = 4000;
            this.colsCampaignInterest.Name = "colsCampaignInterest";
            this.colsCampaignInterest.NamedProperties.Put("EnumerateMethod", "BUSINESS_CAMPAIGN_INTEREST_API.Enumerate");
            this.colsCampaignInterest.NamedProperties.Put("FieldFlags", "294");
            this.colsCampaignInterest.NamedProperties.Put("LovReference", "");
            this.colsCampaignInterest.NamedProperties.Put("SqlColumn", "CAMPAIGN_INTEREST");
            this.colsCampaignInterest.Position = 16;
            resources.ApplyResources(this.colsCampaignInterest, "colsCampaignInterest");
            // 
            // colsDecisionPowerType
            // 
            this.colsDecisionPowerType.IsLookup = true;
            this.colsDecisionPowerType.MaxLength = 200;
            this.colsDecisionPowerType.Name = "colsDecisionPowerType";
            this.colsDecisionPowerType.NamedProperties.Put("EnumerateMethod", "DECISION_POWER_TYPE_API.Enumerate");
            this.colsDecisionPowerType.NamedProperties.Put("FieldFlags", "294");
            this.colsDecisionPowerType.NamedProperties.Put("LovReference", "");
            this.colsDecisionPowerType.NamedProperties.Put("SqlColumn", "DECISION_POWER_TYPE");
            this.colsDecisionPowerType.Position = 17;
            resources.ApplyResources(this.colsDecisionPowerType, "colsDecisionPowerType");
            this.colsDecisionPowerType.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tableWindow_colsDecisionPowerType_WindowActions);
            // 
            // colsDepartment
            // 
            this.colsDepartment.IsLookup = true;
            this.colsDepartment.MaxLength = 200;
            this.colsDepartment.Name = "colsDepartment";
            this.colsDepartment.NamedProperties.Put("EnumerateMethod", "CONTACT_DEPARTMENT_API.Enumerate");
            this.colsDepartment.NamedProperties.Put("FieldFlags", "294");
            this.colsDepartment.NamedProperties.Put("LovReference", "");
            this.colsDepartment.NamedProperties.Put("SqlColumn", "DEPARTMENT");
            this.colsDepartment.Position = 18;
            resources.ApplyResources(this.colsDepartment, "colsDepartment");
            this.colsDepartment.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tableWindow_colsDepartment_WindowActions);
            // 
            // colsManager
            // 
            this.colsManager.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsManager.MaxLength = 20;
            this.colsManager.Name = "colsManager";
            this.colsManager.NamedProperties.Put("EnumerateMethod", "");
            this.colsManager.NamedProperties.Put("FieldFlags", "294");
            this.colsManager.NamedProperties.Put("LovReference", "CUST_INFO_CONTACT_LOV2_PUB(CUSTOMER_ID)");
            this.colsManager.NamedProperties.Put("SqlColumn", "MANAGER");
            this.colsManager.Position = 19;
            resources.ApplyResources(this.colsManager, "colsManager");
            this.colsManager.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsManager_WindowActions);
            // 
            // colsManagerName
            // 
            this.colsManagerName.MaxLength = 2000;
            this.colsManagerName.Name = "colsManagerName";
            this.colsManagerName.NamedProperties.Put("EnumerateMethod", "");
            this.colsManagerName.NamedProperties.Put("FieldFlags", "288");
            this.colsManagerName.NamedProperties.Put("LovReference", "");
            this.colsManagerName.NamedProperties.Put("ParentName", "colsManager");
            this.colsManagerName.NamedProperties.Put("SqlColumn", "PERSON_INFO_API.Get_Name(MANAGER)");
            this.colsManagerName.Position = 20;
            resources.ApplyResources(this.colsManagerName, "colsManagerName");
            // 
            // colsManagerCustAddress
            // 
            this.colsManagerCustAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsManagerCustAddress.MaxLength = 50;
            this.colsManagerCustAddress.Name = "colsManagerCustAddress";
            this.colsManagerCustAddress.NamedProperties.Put("EnumerateMethod", "");
            this.colsManagerCustAddress.NamedProperties.Put("FieldFlags", "294");
            this.colsManagerCustAddress.NamedProperties.Put("LovReference", "CUST_INFO_CONTACT_LOV2_PUB(CUSTOMER_ID)");
            this.colsManagerCustAddress.NamedProperties.Put("SqlColumn", "MANAGER_CUST_ADDRESS");
            this.colsManagerCustAddress.Position = 22;
            resources.ApplyResources(this.colsManagerCustAddress, "colsManagerCustAddress");
            this.colsManagerCustAddress.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsManagerCustAddress_WindowActions);
            // 
            // colsManagerGuid
            // 
            this.colsManagerGuid.MaxLength = 50;
            this.colsManagerGuid.Name = "colsManagerGuid";
            this.colsManagerGuid.NamedProperties.Put("EnumerateMethod", "");
            this.colsManagerGuid.NamedProperties.Put("FieldFlags", "294");
            this.colsManagerGuid.NamedProperties.Put("LovReference", "");
            this.colsManagerGuid.NamedProperties.Put("SqlColumn", "MANAGER_GUID");
            this.colsManagerGuid.Position = 21;
            resources.ApplyResources(this.colsManagerGuid, "colsManagerGuid");
            // 
            // colsRole
            // 
            this.colsRole.MaxLength = 4000;
            this.colsRole.Name = "colsRole";
            this.colsRole.NamedProperties.Put("EnumerateMethod", "CONTACT_ROLE_API.Enumerate");
            this.colsRole.NamedProperties.Put("FieldFlags", "294");
            this.colsRole.NamedProperties.Put("LovReference", "");
            this.colsRole.NamedProperties.Put("SqlColumn", "ROLE");
            this.colsRole.Position = 5;
            resources.ApplyResources(this.colsRole, "colsRole");
            // 
            // colsMainRepresentativeId
            // 
            this.colsMainRepresentativeId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsMainRepresentativeId.MaxLength = 20;
            this.colsMainRepresentativeId.Name = "colsMainRepresentativeId";
            this.colsMainRepresentativeId.NamedProperties.Put("EnumerateMethod", "");
            this.colsMainRepresentativeId.NamedProperties.Put("FieldFlags", "290");
            this.colsMainRepresentativeId.NamedProperties.Put("LovReference", "BUSINESS_REPRESENTATIVE_LOV");
            this.colsMainRepresentativeId.NamedProperties.Put("SqlColumn", "MAIN_REPRESENTATIVE_ID");
            this.colsMainRepresentativeId.Position = 13;
            resources.ApplyResources(this.colsMainRepresentativeId, "colsMainRepresentativeId");
            this.colsMainRepresentativeId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tableWindow_colsMainRepresentativeId_WindowActions);
            // 
            // colsMainRepresentativeName
            // 
            this.colsMainRepresentativeName.MaxLength = 2000;
            this.colsMainRepresentativeName.Name = "colsMainRepresentativeName";
            this.colsMainRepresentativeName.NamedProperties.Put("EnumerateMethod", "");
            this.colsMainRepresentativeName.NamedProperties.Put("FieldFlags", "288");
            this.colsMainRepresentativeName.NamedProperties.Put("LovReference", "");
            this.colsMainRepresentativeName.NamedProperties.Put("ParentName", "colsMainRepresentativeId");
            this.colsMainRepresentativeName.NamedProperties.Put("SqlColumn", "Person_Info_API.Get_Name(MAIN_REPRESENTATIVE_ID)");
            this.colsMainRepresentativeName.Position = 14;
            resources.ApplyResources(this.colsMainRepresentativeName, "colsMainRepresentativeName");
            // 
            // colsGuid
            // 
            this.colsGuid.MaxLength = 50;
            this.colsGuid.Name = "colsGuid";
            this.colsGuid.NamedProperties.Put("EnumerateMethod", "");
            this.colsGuid.NamedProperties.Put("FieldFlags", "128");
            this.colsGuid.NamedProperties.Put("LovReference", "");
            this.colsGuid.NamedProperties.Put("SqlColumn", "GUID");
            this.colsGuid.Position = 35;
            resources.ApplyResources(this.colsGuid, "colsGuid");
            // 
            // colsCustomerName
            // 
            this.colsCustomerName.MaxLength = 2000;
            this.colsCustomerName.Name = "colsCustomerName";
            this.colsCustomerName.NamedProperties.Put("EnumerateMethod", "");
            this.colsCustomerName.NamedProperties.Put("FieldFlags", "288");
            this.colsCustomerName.NamedProperties.Put("LovReference", "");
            this.colsCustomerName.NamedProperties.Put("SqlColumn", "Customer_Info_API.Get_Name(CUSTOMER_ID)");
            this.colsCustomerName.Position = 8;
            resources.ApplyResources(this.colsCustomerName, "colsCustomerName");
            // 
            // colPersonInfoAddressWww
            // 
            this.colPersonInfoAddressWww.DetectHyperLinks = true;
            this.colPersonInfoAddressWww.MaxLength = 2000;
            this.colPersonInfoAddressWww.Name = "colPersonInfoAddressWww";
            this.colPersonInfoAddressWww.NamedProperties.Put("EnumerateMethod", "");
            this.colPersonInfoAddressWww.NamedProperties.Put("FieldFlags", "304");
            this.colPersonInfoAddressWww.NamedProperties.Put("LovReference", "");
            this.colPersonInfoAddressWww.NamedProperties.Put("ParentName", "colsContactAddress");
            this.colPersonInfoAddressWww.NamedProperties.Put("ResizeableChildObject", "");
            this.colPersonInfoAddressWww.NamedProperties.Put("SqlColumn", "Comm_Method_API.Get_Value(\'PERSON\', person_id, &AO.Comm_Method_Code_API.Decode(\'W" +
        "WW\'), 1, CONTACT_ADDRESS)");
            this.colPersonInfoAddressWww.NamedProperties.Put("ValidateMethod", "");
            this.colPersonInfoAddressWww.Position = 33;
            resources.ApplyResources(this.colPersonInfoAddressWww, "colPersonInfoAddressWww");
            // 
            // colsConnectAllCustAddrDb
            // 
            this.colsConnectAllCustAddrDb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsConnectAllCustAddrDb.MaxLength = 20;
            this.colsConnectAllCustAddrDb.Name = "colsConnectAllCustAddrDb";
            this.colsConnectAllCustAddrDb.NamedProperties.Put("EnumerateMethod", "");
            this.colsConnectAllCustAddrDb.NamedProperties.Put("FieldFlags", "294");
            this.colsConnectAllCustAddrDb.NamedProperties.Put("LovReference", "");
            this.colsConnectAllCustAddrDb.NamedProperties.Put("LovTimeReference", "");
            this.colsConnectAllCustAddrDb.NamedProperties.Put("SqlColumn", "CONNECT_ALL_CUST_ADDR_DB");
            this.colsConnectAllCustAddrDb.Position = 10;
            resources.ApplyResources(this.colsConnectAllCustAddrDb, "colsConnectAllCustAddrDb");
            // 
            // tbwCustomerInfoContact
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colsPersonId);
            this.Controls.Add(this.colPersonInfoName);
            this.Controls.Add(this.colsRole);
            this.Controls.Add(this.colPersonInfoTitle);
            this.Controls.Add(this.colsCustomerId);
            this.Controls.Add(this.colsCustomerName);
            this.Controls.Add(this.colsCustomerAddress);
            this.Controls.Add(this.colsConnectAllCustAddrDb);
            this.Controls.Add(this.colsContactAddress);
            this.Controls.Add(this.colsBlockedForCrmObjectsDb);
            this.Controls.Add(this.colsMainRepresentativeId);
            this.Controls.Add(this.colsMainRepresentativeName);
            this.Controls.Add(this.colsPersonalInterest);
            this.Controls.Add(this.colsCampaignInterest);
            this.Controls.Add(this.colsDecisionPowerType);
            this.Controls.Add(this.colsDepartment);
            this.Controls.Add(this.colsManager);
            this.Controls.Add(this.colsManagerName);
            this.Controls.Add(this.colsManagerGuid);
            this.Controls.Add(this.colsManagerCustAddress);
            this.Controls.Add(this.colAddressPrimary);
            this.Controls.Add(this.colAddressSecondary);
            this.Controls.Add(this.colCustomerPrimary);
            this.Controls.Add(this.colCustomerSecondary);
            this.Controls.Add(this.colPersonInfoAddressPhone);
            this.Controls.Add(this.colPersonInfoAddressMobile);
            this.Controls.Add(this.colPersonInfoAddressE_Mail);
            this.Controls.Add(this.colPersonInfoAddressFax);
            this.Controls.Add(this.colPersonInfoAddressPager);
            this.Controls.Add(this.colPersonInfoAddressIntercom);
            this.Controls.Add(this.colPersonInfoAddressWww);
            this.Controls.Add(this.colsNoteText);
            this.Controls.Add(this.colsGuid);
            this.Name = "tbwCustomerInfoContact";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "CustomerInfoContact");
            this.NamedProperties.Put("PackageName", "CUSTOMER_INFO_CONTACT_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "449");
            this.NamedProperties.Put("ViewName", "CUSTOMER_INFO_CONTACT");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tbwCustomerInfoContact_WindowActions);
            this.Controls.SetChildIndex(this.colsGuid, 0);
            this.Controls.SetChildIndex(this.colsNoteText, 0);
            this.Controls.SetChildIndex(this.colPersonInfoAddressWww, 0);
            this.Controls.SetChildIndex(this.colPersonInfoAddressIntercom, 0);
            this.Controls.SetChildIndex(this.colPersonInfoAddressPager, 0);
            this.Controls.SetChildIndex(this.colPersonInfoAddressFax, 0);
            this.Controls.SetChildIndex(this.colPersonInfoAddressE_Mail, 0);
            this.Controls.SetChildIndex(this.colPersonInfoAddressMobile, 0);
            this.Controls.SetChildIndex(this.colPersonInfoAddressPhone, 0);
            this.Controls.SetChildIndex(this.colCustomerSecondary, 0);
            this.Controls.SetChildIndex(this.colCustomerPrimary, 0);
            this.Controls.SetChildIndex(this.colAddressSecondary, 0);
            this.Controls.SetChildIndex(this.colAddressPrimary, 0);
            this.Controls.SetChildIndex(this.colsManagerCustAddress, 0);
            this.Controls.SetChildIndex(this.colsManagerGuid, 0);
            this.Controls.SetChildIndex(this.colsManagerName, 0);
            this.Controls.SetChildIndex(this.colsManager, 0);
            this.Controls.SetChildIndex(this.colsDepartment, 0);
            this.Controls.SetChildIndex(this.colsDecisionPowerType, 0);
            this.Controls.SetChildIndex(this.colsCampaignInterest, 0);
            this.Controls.SetChildIndex(this.colsPersonalInterest, 0);
            this.Controls.SetChildIndex(this.colsMainRepresentativeName, 0);
            this.Controls.SetChildIndex(this.colsMainRepresentativeId, 0);
            this.Controls.SetChildIndex(this.colsBlockedForCrmObjectsDb, 0);
            this.Controls.SetChildIndex(this.colsContactAddress, 0);
            this.Controls.SetChildIndex(this.colsConnectAllCustAddrDb, 0);
            this.Controls.SetChildIndex(this.colsCustomerAddress, 0);
            this.Controls.SetChildIndex(this.colsCustomerName, 0);
            this.Controls.SetChildIndex(this.colsCustomerId, 0);
            this.Controls.SetChildIndex(this.colPersonInfoTitle, 0);
            this.Controls.SetChildIndex(this.colsRole, 0);
            this.Controls.SetChildIndex(this.colPersonInfoName, 0);
            this.Controls.SetChildIndex(this.colsPersonId, 0);
            this.Controls.SetChildIndex(this.@__colObjversion, 0);
            this.Controls.SetChildIndex(this.@__colObjid, 0);
            this.menuTbwMethods.ResumeLayout(false);
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

        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menu_Add_Contact___;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTbwMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem menuItem__Add;
        protected cCheckBoxColumn colsBlockedForCrmObjectsDb;
        protected cMultiSelectionColumn colsPersonalInterest;
		protected cMultiSelectionColumn colsCampaignInterest;
        protected cLookupColumn colsDecisionPowerType;
        protected cLookupColumn colsDepartment;
        protected cColumn colsManager;
        protected cColumn colsManagerName;
        protected cColumn colsManagerCustAddress;
        protected cColumn colsManagerGuid;
		protected cMultiSelectionColumn colsRole;
        protected cColumn colsMainRepresentativeId;
        protected cColumn colsMainRepresentativeName;
        protected cColumn colsGuid;
        protected cColumn colsCustomerName;
        public cColumn colPersonInfoAddressWww;
        protected cCheckBoxColumn colsConnectAllCustAddrDb;
	}
}
