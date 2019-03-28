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
// 150610    SudJlk  ORA-691, Added columns colsMainRepresentativeId, colsMainRepresentativeName and colsDepartment.
// 150612    SudJlk  ORA-571, Added invisible column colsGuid.
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
	
	public partial class tbwSupplierInfoContact
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cColumn colsSupplierId;
		public cColumn colsPersonId;
		public cColumn colPersonInfoName;
        public cColumn colPersonInfoTitle;
		public cColumn colsSupplierAddress;
		public cColumn colsContactAddress;
		public cCheckBoxColumn colAddressPrimary;
		public cCheckBoxColumn colAddressSecondary;
		public cCheckBoxColumn colSupplierPrimary;
		public cCheckBoxColumn colSupplierSecondary;
		public cColumn colPersonInfoAddressPhone;
		public cColumn colPersonInfoAddressMobile;
		public cColumn colPersonInfoAddressE_Mail;
		public cColumn colPersonInfoAddressFax;
		public cColumn colPersonInfoAddressPager;
		public cColumn colPersonInfoAddressIntercom;
		public cColumn colNoteText;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwSupplierInfoContact));
            this.menuTbwMethods_menu_Add_Contact___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.colsSupplierId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsPersonId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colPersonInfoName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colPersonInfoTitle = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsSupplierAddress = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsContactAddress = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colAddressPrimary = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.colAddressSecondary = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.colSupplierPrimary = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.colSupplierSecondary = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.colPersonInfoAddressPhone = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colPersonInfoAddressMobile = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colPersonInfoAddressE_Mail = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colPersonInfoAddressFax = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colPersonInfoAddressPager = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colPersonInfoAddressIntercom = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colNoteText = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuTbwMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.menuItem__Add = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.colsRole = new Ifs.Fnd.ApplicationForms.cMultiSelectionColumn();
            this.colsMainRepresentativeId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsMainRepresentativeName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsDepartment = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.colsGuid = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colPersonInfoAddressWww = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsConnectAllSuppAddrDb = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.menuTbwMethods.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuTbwMethods_menu_Add_Contact___);
            this.commandManager.ContextMenus.Add(this.menuTbwMethods);
            this.commandManager.ImageList = null;
            // 
            // menuTbwMethods_menu_Add_Contact___
            // 
            resources.ApplyResources(this.menuTbwMethods_menu_Add_Contact___, "menuTbwMethods_menu_Add_Contact___");
            this.menuTbwMethods_menu_Add_Contact___.Name = "menuTbwMethods_menu_Add_Contact___";
            this.menuTbwMethods_menu_Add_Contact___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuItem__Add_Execute);
            this.menuTbwMethods_menu_Add_Contact___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuItem__Add_Inquire);
            // 
            // colsSupplierId
            // 
            this.colsSupplierId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.colsSupplierId, "colsSupplierId");
            this.colsSupplierId.MaxLength = 20;
            this.colsSupplierId.Name = "colsSupplierId";
            this.colsSupplierId.NamedProperties.Put("EnumerateMethod", "");
            this.colsSupplierId.NamedProperties.Put("FieldFlags", "67");
            this.colsSupplierId.NamedProperties.Put("LovReference", "SUPPLIER_INFO");
            this.colsSupplierId.NamedProperties.Put("SqlColumn", "SUPPLIER_ID");
            this.colsSupplierId.Position = 3;
            // 
            // colsPersonId
            // 
            this.colsPersonId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsPersonId.MaxLength = 20;
            this.colsPersonId.Name = "colsPersonId";
            this.colsPersonId.NamedProperties.Put("EnumerateMethod", "");
            this.colsPersonId.NamedProperties.Put("FieldFlags", "67");
            this.colsPersonId.NamedProperties.Put("LovReference", "PERSON_INFO_ALL");
            this.colsPersonId.NamedProperties.Put("SqlColumn", "PERSON_ID");
            this.colsPersonId.Position = 4;
            resources.ApplyResources(this.colsPersonId, "colsPersonId");
            this.colsPersonId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblPersonId_WindowActions);
            // 
            // colPersonInfoName
            // 
            this.colPersonInfoName.MaxLength = 2000;
            this.colPersonInfoName.Name = "colPersonInfoName";
            this.colPersonInfoName.NamedProperties.Put("EnumerateMethod", "");
            this.colPersonInfoName.NamedProperties.Put("FieldFlags", "304");
            this.colPersonInfoName.NamedProperties.Put("LovReference", "");
            this.colPersonInfoName.NamedProperties.Put("ParentName", "colsPersonId");
            this.colPersonInfoName.NamedProperties.Put("SqlColumn", "PERSON_INFO_API.Get_Name(PERSON_ID)");
            this.colPersonInfoName.NamedProperties.Put("ValidateMethod", "");
            this.colPersonInfoName.Position = 5;
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
            this.colPersonInfoTitle.NamedProperties.Put("SqlColumn", "PERSON_INFO_API.Get_Title(PERSON_ID)");
            this.colPersonInfoTitle.NamedProperties.Put("ValidateMethod", "");
            this.colPersonInfoTitle.Position = 6;
            resources.ApplyResources(this.colPersonInfoTitle, "colPersonInfoTitle");
            // 
            // colsSupplierAddress
            // 
            this.colsSupplierAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsSupplierAddress.MaxLength = 50;
            this.colsSupplierAddress.Name = "colsSupplierAddress";
            this.colsSupplierAddress.NamedProperties.Put("EnumerateMethod", "");
            this.colsSupplierAddress.NamedProperties.Put("FieldFlags", "294");
            this.colsSupplierAddress.NamedProperties.Put("LovReference", "SUPPLIER_INFO_ADDRESS(SUPPLIER_ID)");
            this.colsSupplierAddress.NamedProperties.Put("SqlColumn", "SUPPLIER_ADDRESS");
            this.colsSupplierAddress.Position = 8;
            resources.ApplyResources(this.colsSupplierAddress, "colsSupplierAddress");
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
            this.colsContactAddress.Position = 10;
            resources.ApplyResources(this.colsContactAddress, "colsContactAddress");
            // 
            // colAddressPrimary
            // 
            this.colAddressPrimary.Name = "colAddressPrimary";
            this.colAddressPrimary.NamedProperties.Put("EnumerateMethod", "");
            this.colAddressPrimary.NamedProperties.Put("FieldFlags", "295");
            this.colAddressPrimary.NamedProperties.Put("LovReference", "");
            this.colAddressPrimary.NamedProperties.Put("SqlColumn", "ADDRESS_PRIMARY");
            this.colAddressPrimary.Position = 14;
            resources.ApplyResources(this.colAddressPrimary, "colAddressPrimary");
            // 
            // colAddressSecondary
            // 
            this.colAddressSecondary.Name = "colAddressSecondary";
            this.colAddressSecondary.NamedProperties.Put("EnumerateMethod", "");
            this.colAddressSecondary.NamedProperties.Put("FieldFlags", "295");
            this.colAddressSecondary.NamedProperties.Put("LovReference", "");
            this.colAddressSecondary.NamedProperties.Put("SqlColumn", "ADDRESS_SECONDARY");
            this.colAddressSecondary.Position = 15;
            resources.ApplyResources(this.colAddressSecondary, "colAddressSecondary");
            // 
            // colSupplierPrimary
            // 
            this.colSupplierPrimary.Name = "colSupplierPrimary";
            this.colSupplierPrimary.NamedProperties.Put("EnumerateMethod", "");
            this.colSupplierPrimary.NamedProperties.Put("FieldFlags", "295");
            this.colSupplierPrimary.NamedProperties.Put("LovReference", "");
            this.colSupplierPrimary.NamedProperties.Put("SqlColumn", "SUPPLIER_PRIMARY");
            this.colSupplierPrimary.Position = 16;
            resources.ApplyResources(this.colSupplierPrimary, "colSupplierPrimary");
            // 
            // colSupplierSecondary
            // 
            this.colSupplierSecondary.Name = "colSupplierSecondary";
            this.colSupplierSecondary.NamedProperties.Put("EnumerateMethod", "");
            this.colSupplierSecondary.NamedProperties.Put("FieldFlags", "295");
            this.colSupplierSecondary.NamedProperties.Put("LovReference", "");
            this.colSupplierSecondary.NamedProperties.Put("SqlColumn", "SUPPLIER_SECONDARY");
            this.colSupplierSecondary.Position = 17;
            resources.ApplyResources(this.colSupplierSecondary, "colSupplierSecondary");
            // 
            // colPersonInfoAddressPhone
            // 
            this.colPersonInfoAddressPhone.MaxLength = 2000;
            this.colPersonInfoAddressPhone.Name = "colPersonInfoAddressPhone";
            this.colPersonInfoAddressPhone.NamedProperties.Put("EnumerateMethod", "");
            this.colPersonInfoAddressPhone.NamedProperties.Put("FieldFlags", "304");
            this.colPersonInfoAddressPhone.NamedProperties.Put("LovReference", "");
            this.colPersonInfoAddressPhone.NamedProperties.Put("ParentName", "colsContactAddress");
            this.colPersonInfoAddressPhone.NamedProperties.Put("SqlColumn", "Comm_Method_API.Get_Value(\'PERSON\', person_id, &AO.Comm_Method_Code_API.Decode(\'P" +
        "HONE\'), 1, CONTACT_ADDRESS)");
            this.colPersonInfoAddressPhone.NamedProperties.Put("ValidateMethod", "");
            this.colPersonInfoAddressPhone.Position = 18;
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
            this.colPersonInfoAddressMobile.NamedProperties.Put("SqlColumn", "Comm_Method_API.Get_Value(\'PERSON\', person_id, &AO.Comm_Method_Code_API.Decode(\'M" +
        "OBILE\'), 1, CONTACT_ADDRESS)");
            this.colPersonInfoAddressMobile.NamedProperties.Put("ValidateMethod", "");
            this.colPersonInfoAddressMobile.Position = 19;
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
            this.colPersonInfoAddressE_Mail.NamedProperties.Put("SqlColumn", "Comm_Method_API.Get_Value(\'PERSON\', person_id, &AO.Comm_Method_Code_API.Decode(\'E" +
        "_MAIL\'), 1, CONTACT_ADDRESS)");
            this.colPersonInfoAddressE_Mail.NamedProperties.Put("ValidateMethod", "");
            this.colPersonInfoAddressE_Mail.Position = 20;
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
            this.colPersonInfoAddressFax.NamedProperties.Put("SqlColumn", "Comm_Method_API.Get_Value(\'PERSON\', person_id, Comm_Method_Code_API.Decode(\'FAX\')" +
        ", 1, CONTACT_ADDRESS)");
            this.colPersonInfoAddressFax.NamedProperties.Put("ValidateMethod", "");
            this.colPersonInfoAddressFax.Position = 21;
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
            this.colPersonInfoAddressPager.NamedProperties.Put("SqlColumn", "Comm_Method_API.Get_Value(\'PERSON\', person_id, &AO.Comm_Method_Code_API.Decode(\'P" +
        "AGER\'), 1, CONTACT_ADDRESS)");
            this.colPersonInfoAddressPager.NamedProperties.Put("ValidateMethod", "");
            this.colPersonInfoAddressPager.Position = 22;
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
            this.colPersonInfoAddressIntercom.NamedProperties.Put("SqlColumn", "Comm_Method_API.Get_Value(\'PERSON\', person_id, &AO.Comm_Method_Code_API.Decode(\'I" +
        "NTERCOM\'), 1, CONTACT_ADDRESS)");
            this.colPersonInfoAddressIntercom.NamedProperties.Put("ValidateMethod", "");
            this.colPersonInfoAddressIntercom.Position = 23;
            resources.ApplyResources(this.colPersonInfoAddressIntercom, "colPersonInfoAddressIntercom");
            // 
            // colNoteText
            // 
            this.colNoteText.MaxLength = 2000;
            this.colNoteText.Name = "colNoteText";
            this.colNoteText.NamedProperties.Put("EnumerateMethod", "");
            this.colNoteText.NamedProperties.Put("FieldFlags", "310");
            this.colNoteText.NamedProperties.Put("LovReference", "");
            this.colNoteText.NamedProperties.Put("SqlColumn", "NOTE_TEXT");
            this.colNoteText.Position = 25;
            resources.ApplyResources(this.colNoteText, "colNoteText");
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
            // colsRole
            // 
            this.colsRole.MaxLength = 4000;
            this.colsRole.Name = "colsRole";
            this.colsRole.NamedProperties.Put("EnumerateMethod", "Contact_Role_API.Enumerate");
            this.colsRole.NamedProperties.Put("FieldFlags", "294");
            this.colsRole.NamedProperties.Put("SqlColumn", "ROLE");
            this.colsRole.Position = 7;
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
            this.colsMainRepresentativeId.Position = 11;
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
            this.colsMainRepresentativeName.Position = 12;
            resources.ApplyResources(this.colsMainRepresentativeName, "colsMainRepresentativeName");
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
            this.colsDepartment.Position = 13;
            resources.ApplyResources(this.colsDepartment, "colsDepartment");
            // 
            // colsGuid
            // 
            this.colsGuid.MaxLength = 50;
            this.colsGuid.Name = "colsGuid";
            this.colsGuid.NamedProperties.Put("EnumerateMethod", "");
            this.colsGuid.NamedProperties.Put("FieldFlags", "128");
            this.colsGuid.NamedProperties.Put("LovReference", "");
            this.colsGuid.NamedProperties.Put("SqlColumn", "GUID");
            this.colsGuid.Position = 26;
            resources.ApplyResources(this.colsGuid, "colsGuid");
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
            this.colPersonInfoAddressWww.NamedProperties.Put("SqlColumn", "Comm_Method_API.Get_Value(\'PERSON\', person_id, &AO.Comm_Method_Code_API.Decode(\'W" +
        "WW\'), 1, CONTACT_ADDRESS)");
            this.colPersonInfoAddressWww.NamedProperties.Put("ValidateMethod", "");
            this.colPersonInfoAddressWww.Position = 24;
            resources.ApplyResources(this.colPersonInfoAddressWww, "colPersonInfoAddressWww");
            // 
            // colsConnectAllSuppAddrDb
            // 
            this.colsConnectAllSuppAddrDb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsConnectAllSuppAddrDb.MaxLength = 20;
            this.colsConnectAllSuppAddrDb.Name = "colsConnectAllSuppAddrDb";
            this.colsConnectAllSuppAddrDb.NamedProperties.Put("EnumerateMethod", "");
            this.colsConnectAllSuppAddrDb.NamedProperties.Put("FieldFlags", "294");
            this.colsConnectAllSuppAddrDb.NamedProperties.Put("LovReference", "");
            this.colsConnectAllSuppAddrDb.NamedProperties.Put("LovTimeReference", "");
            this.colsConnectAllSuppAddrDb.NamedProperties.Put("SqlColumn", "CONNECT_ALL_SUPP_ADDR_DB");
            this.colsConnectAllSuppAddrDb.Position = 9;
            resources.ApplyResources(this.colsConnectAllSuppAddrDb, "colsConnectAllSuppAddrDb");
            // 
            // tbwSupplierInfoContact
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colsSupplierId);
            this.Controls.Add(this.colsPersonId);
            this.Controls.Add(this.colPersonInfoName);
            this.Controls.Add(this.colPersonInfoTitle);
            this.Controls.Add(this.colsRole);
            this.Controls.Add(this.colsSupplierAddress);
            this.Controls.Add(this.colsConnectAllSuppAddrDb);
            this.Controls.Add(this.colsContactAddress);
            this.Controls.Add(this.colsMainRepresentativeId);
            this.Controls.Add(this.colsMainRepresentativeName);
            this.Controls.Add(this.colsDepartment);
            this.Controls.Add(this.colAddressPrimary);
            this.Controls.Add(this.colAddressSecondary);
            this.Controls.Add(this.colSupplierPrimary);
            this.Controls.Add(this.colSupplierSecondary);
            this.Controls.Add(this.colPersonInfoAddressPhone);
            this.Controls.Add(this.colPersonInfoAddressMobile);
            this.Controls.Add(this.colPersonInfoAddressE_Mail);
            this.Controls.Add(this.colPersonInfoAddressFax);
            this.Controls.Add(this.colPersonInfoAddressPager);
            this.Controls.Add(this.colPersonInfoAddressIntercom);
            this.Controls.Add(this.colPersonInfoAddressWww);
            this.Controls.Add(this.colNoteText);
            this.Controls.Add(this.colsGuid);
            this.Name = "tbwSupplierInfoContact";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "SupplierInfoContact");
            this.NamedProperties.Put("PackageName", "SUPPLIER_INFO_CONTACT_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "449");
            this.NamedProperties.Put("ViewName", "SUPPLIER_INFO_CONTACT");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tbwSupplierInfoContact_WindowActions);
            this.Controls.SetChildIndex(this.colsGuid, 0);
            this.Controls.SetChildIndex(this.colNoteText, 0);
            this.Controls.SetChildIndex(this.colPersonInfoAddressWww, 0);
            this.Controls.SetChildIndex(this.colPersonInfoAddressIntercom, 0);
            this.Controls.SetChildIndex(this.colPersonInfoAddressPager, 0);
            this.Controls.SetChildIndex(this.colPersonInfoAddressFax, 0);
            this.Controls.SetChildIndex(this.colPersonInfoAddressE_Mail, 0);
            this.Controls.SetChildIndex(this.colPersonInfoAddressMobile, 0);
            this.Controls.SetChildIndex(this.colPersonInfoAddressPhone, 0);
            this.Controls.SetChildIndex(this.colSupplierSecondary, 0);
            this.Controls.SetChildIndex(this.colSupplierPrimary, 0);
            this.Controls.SetChildIndex(this.colAddressSecondary, 0);
            this.Controls.SetChildIndex(this.colAddressPrimary, 0);
            this.Controls.SetChildIndex(this.colsDepartment, 0);
            this.Controls.SetChildIndex(this.colsMainRepresentativeName, 0);
            this.Controls.SetChildIndex(this.colsMainRepresentativeId, 0);
            this.Controls.SetChildIndex(this.colsContactAddress, 0);
            this.Controls.SetChildIndex(this.colsConnectAllSuppAddrDb, 0);
            this.Controls.SetChildIndex(this.colsSupplierAddress, 0);
            this.Controls.SetChildIndex(this.colsRole, 0);
            this.Controls.SetChildIndex(this.colPersonInfoTitle, 0);
            this.Controls.SetChildIndex(this.colPersonInfoName, 0);
            this.Controls.SetChildIndex(this.colsPersonId, 0);
            this.Controls.SetChildIndex(this.colsSupplierId, 0);
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
        protected cMultiSelectionColumn colsRole;
        protected cColumn colsMainRepresentativeId;
        protected cColumn colsMainRepresentativeName;
        protected cLookupColumn colsDepartment;
        protected cColumn colsGuid;
        public cColumn colPersonInfoAddressWww;
        protected cCheckBoxColumn colsConnectAllSuppAddrDb;
	}
}
