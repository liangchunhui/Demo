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
	
	public partial class cChildTableCommMethod
	{
		#region Window Controls
		public cColumn colsPartyType;
		public cColumn colsPartyTypeDb;
		public cColumn colsIdentity;
		public cColumn colnCommId;
		public cColumn colsName;
		public cColumn colsDescription;
		public cLookupColumn colsMethodId;
		public cColumn colsValue;
		public cCheckBoxColumn colMethodDefault;
		public cColumn colsAddressId;
		public cCheckBoxColumn colAddressDefault;
		public cColumn coldValidFrom;
		public cColumn coldValidTo;
        public cColumn colsPrevAddrId;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(cChildTableCommMethod));
            this.colsPartyType = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsPartyTypeDb = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsIdentity = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colnCommId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsMethodId = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.colsValue = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colMethodDefault = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.colsAddressId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colAddressDefault = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.coldValidFrom = new Ifs.Fnd.ApplicationForms.cColumn();
            this.coldValidTo = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsPrevAddrId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.SuspendLayout();
            // 
            // __colObjid
            // 
            this.@__colObjid.CheckBox.CheckedValue = "";
            this.@__colObjid.CheckBox.IgnoreCase = true;
            this.@__colObjid.CheckBox.UncheckedValue = "";
            this.@__colObjid.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.@__colObjid.ComboBox.Sorted = true;
            this.@__colObjid.PopupBox.Lines = 5;
            // 
            // __colObjversion
            // 
            this.@__colObjversion.CheckBox.CheckedValue = "";
            this.@__colObjversion.CheckBox.IgnoreCase = true;
            this.@__colObjversion.CheckBox.UncheckedValue = "";
            this.@__colObjversion.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.@__colObjversion.ComboBox.Sorted = true;
            this.@__colObjversion.PopupBox.Lines = 5;
            // 
            // colsPartyType
            // 
            this.colsPartyType.CheckBox.CheckedValue = "";
            this.colsPartyType.CheckBox.IgnoreCase = true;
            this.colsPartyType.CheckBox.UncheckedValue = "";
            this.colsPartyType.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.colsPartyType.ComboBox.Sorted = true;
            resources.ApplyResources(this.colsPartyType, "colsPartyType");
            this.colsPartyType.MaxLength = 20;
            this.colsPartyType.Name = "colsPartyType";
            this.colsPartyType.NamedProperties.Put("EnumerateMethod", "");
            this.colsPartyType.NamedProperties.Put("FieldFlags", "262");
            this.colsPartyType.NamedProperties.Put("LovReference", "");
            this.colsPartyType.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsPartyType.NamedProperties.Put("ResizeableChildObject", "");
            this.colsPartyType.NamedProperties.Put("SqlColumn", "PARTY_TYPE");
            this.colsPartyType.NamedProperties.Put("ValidateMethod", "");
            this.colsPartyType.PopupBox.Lines = 5;
            this.colsPartyType.Position = 3;
            // 
            // colsPartyTypeDb
            // 
            this.colsPartyTypeDb.CheckBox.CheckedValue = "";
            this.colsPartyTypeDb.CheckBox.IgnoreCase = true;
            this.colsPartyTypeDb.CheckBox.UncheckedValue = "";
            this.colsPartyTypeDb.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.colsPartyTypeDb.ComboBox.Sorted = true;
            resources.ApplyResources(this.colsPartyTypeDb, "colsPartyTypeDb");
            this.colsPartyTypeDb.MaxLength = 20;
            this.colsPartyTypeDb.Name = "colsPartyTypeDb";
            this.colsPartyTypeDb.NamedProperties.Put("EnumerateMethod", "");
            this.colsPartyTypeDb.NamedProperties.Put("FieldFlags", "262");
            this.colsPartyTypeDb.NamedProperties.Put("LovReference", "");
            this.colsPartyTypeDb.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsPartyTypeDb.NamedProperties.Put("ResizeableChildObject", "");
            this.colsPartyTypeDb.NamedProperties.Put("SqlColumn", "PARTY_TYPE_DB");
            this.colsPartyTypeDb.NamedProperties.Put("ValidateMethod", "");
            this.colsPartyTypeDb.PopupBox.Lines = 5;
            this.colsPartyTypeDb.Position = 4;
            // 
            // colsIdentity
            // 
            this.colsIdentity.CheckBox.CheckedValue = "";
            this.colsIdentity.CheckBox.IgnoreCase = true;
            this.colsIdentity.CheckBox.UncheckedValue = "";
            this.colsIdentity.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.colsIdentity.ComboBox.Sorted = true;
            resources.ApplyResources(this.colsIdentity, "colsIdentity");
            this.colsIdentity.MaxLength = 20;
            this.colsIdentity.Name = "colsIdentity";
            this.colsIdentity.NamedProperties.Put("EnumerateMethod", "");
            this.colsIdentity.NamedProperties.Put("FieldFlags", "262");
            this.colsIdentity.NamedProperties.Put("LovReference", "");
            this.colsIdentity.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsIdentity.NamedProperties.Put("ResizeableChildObject", "");
            this.colsIdentity.NamedProperties.Put("SqlColumn", "IDENTITY");
            this.colsIdentity.NamedProperties.Put("ValidateMethod", "");
            this.colsIdentity.PopupBox.Lines = 5;
            this.colsIdentity.Position = 5;
            // 
            // colnCommId
            // 
            this.colnCommId.CheckBox.CheckedValue = "";
            this.colnCommId.CheckBox.IgnoreCase = true;
            this.colnCommId.CheckBox.UncheckedValue = "";
            this.colnCommId.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.colnCommId.ComboBox.Sorted = true;
            this.colnCommId.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.colnCommId, "colnCommId");
            this.colnCommId.MaxLength = 20;
            this.colnCommId.Name = "colnCommId";
            this.colnCommId.NamedProperties.Put("EnumerateMethod", "");
            this.colnCommId.NamedProperties.Put("FieldFlags", "130");
            this.colnCommId.NamedProperties.Put("LovReference", "");
            this.colnCommId.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colnCommId.NamedProperties.Put("ResizeableChildObject", "");
            this.colnCommId.NamedProperties.Put("SqlColumn", "COMM_ID");
            this.colnCommId.NamedProperties.Put("ValidateMethod", "");
            this.colnCommId.PopupBox.Lines = 5;
            this.colnCommId.Position = 6;
            // 
            // colsName
            // 
            this.colsName.CheckBox.CheckedValue = "";
            this.colsName.CheckBox.IgnoreCase = true;
            this.colsName.CheckBox.UncheckedValue = "";
            this.colsName.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.colsName.ComboBox.Sorted = true;
            this.colsName.Name = "colsName";
            this.colsName.NamedProperties.Put("EnumerateMethod", "");
            this.colsName.NamedProperties.Put("FieldFlags", "294");
            this.colsName.NamedProperties.Put("LovReference", "");
            this.colsName.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsName.NamedProperties.Put("SqlColumn", "NAME");
            this.colsName.PopupBox.Lines = 5;
            this.colsName.Position = 7;
            resources.ApplyResources(this.colsName, "colsName");
            // 
            // colsDescription
            // 
            this.colsDescription.CheckBox.CheckedValue = "";
            this.colsDescription.CheckBox.IgnoreCase = true;
            this.colsDescription.CheckBox.UncheckedValue = "";
            this.colsDescription.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.colsDescription.ComboBox.Sorted = true;
            this.colsDescription.MaxLength = 200;
            this.colsDescription.Name = "colsDescription";
            this.colsDescription.NamedProperties.Put("EnumerateMethod", "");
            this.colsDescription.NamedProperties.Put("FieldFlags", "294");
            this.colsDescription.NamedProperties.Put("LovReference", "");
            this.colsDescription.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.colsDescription.PopupBox.Lines = 5;
            this.colsDescription.Position = 8;
            resources.ApplyResources(this.colsDescription, "colsDescription");
            // 
            // colsMethodId
            // 
            this.colsMethodId.CellType = PPJ.Runtime.Windows.CellType.ComboBox;
            this.colsMethodId.CheckBox.CheckedValue = "";
            this.colsMethodId.CheckBox.IgnoreCase = true;
            this.colsMethodId.CheckBox.UncheckedValue = "";
            this.colsMethodId.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colsMethodId.ComboBox.Sorted = false;
            this.colsMethodId.MaxLength = 20;
            this.colsMethodId.Name = "colsMethodId";
            this.colsMethodId.NamedProperties.Put("EnumerateMethod", "COMM_METHOD_CODE_API.Enumerate");
            this.colsMethodId.NamedProperties.Put("FieldFlags", "295");
            this.colsMethodId.NamedProperties.Put("LovReference", "");
            this.colsMethodId.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsMethodId.NamedProperties.Put("ResizeableChildObject", "");
            this.colsMethodId.NamedProperties.Put("SqlColumn", "METHOD_ID");
            this.colsMethodId.NamedProperties.Put("ValidateMethod", "");
            this.colsMethodId.PopupBox.Lines = 5;
            this.colsMethodId.Position = 9;
            resources.ApplyResources(this.colsMethodId, "colsMethodId");
            this.colsMethodId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsMethodId_WindowActions);
            // 
            // colsValue
            // 
            this.colsValue.CheckBox.CheckedValue = "";
            this.colsValue.CheckBox.IgnoreCase = true;
            this.colsValue.CheckBox.UncheckedValue = "";
            this.colsValue.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.colsValue.ComboBox.Sorted = true;
            this.colsValue.MaxLength = 200;
            this.colsValue.Name = "colsValue";
            this.colsValue.NamedProperties.Put("EnumerateMethod", "");
            this.colsValue.NamedProperties.Put("FieldFlags", "311");
            this.colsValue.NamedProperties.Put("LovReference", "");
            this.colsValue.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsValue.NamedProperties.Put("ResizeableChildObject", "");
            this.colsValue.NamedProperties.Put("SqlColumn", "VALUE");
            this.colsValue.NamedProperties.Put("ValidateMethod", "");
            this.colsValue.PopupBox.Lines = 5;
            this.colsValue.Position = 10;
            resources.ApplyResources(this.colsValue, "colsValue");
            // 
            // colMethodDefault
            // 
            this.colMethodDefault.CellType = PPJ.Runtime.Windows.CellType.CheckBox;
            this.colMethodDefault.CheckBox.CheckedValue = "TRUE";
            this.colMethodDefault.CheckBox.IgnoreCase = true;
            this.colMethodDefault.CheckBox.UncheckedValue = "FALSE";
            this.colMethodDefault.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.colMethodDefault.ComboBox.Sorted = true;
            this.colMethodDefault.Name = "colMethodDefault";
            this.colMethodDefault.NamedProperties.Put("EnumerateMethod", "");
            this.colMethodDefault.NamedProperties.Put("FieldFlags", "294");
            this.colMethodDefault.NamedProperties.Put("LovReference", "");
            this.colMethodDefault.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colMethodDefault.NamedProperties.Put("ResizeableChildObject", "");
            this.colMethodDefault.NamedProperties.Put("SqlColumn", "METHOD_DEFAULT");
            this.colMethodDefault.NamedProperties.Put("ValidateMethod", "");
            this.colMethodDefault.PopupBox.Lines = 5;
            this.colMethodDefault.Position = 11;
            resources.ApplyResources(this.colMethodDefault, "colMethodDefault");
            // 
            // colsAddressId
            // 
            this.colsAddressId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsAddressId.CheckBox.CheckedValue = "";
            this.colsAddressId.CheckBox.IgnoreCase = true;
            this.colsAddressId.CheckBox.UncheckedValue = "";
            this.colsAddressId.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.colsAddressId.ComboBox.Sorted = true;
            this.colsAddressId.MaxLength = 50;
            this.colsAddressId.Name = "colsAddressId";
            this.colsAddressId.NamedProperties.Put("EnumerateMethod", "");
            this.colsAddressId.NamedProperties.Put("FieldFlags", "294");
            this.colsAddressId.NamedProperties.Put("LovReference", "PARTY_TYPE_ADDRESS(PARTY_TYPE_DB,IDENTITY)");
            this.colsAddressId.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsAddressId.NamedProperties.Put("ResizeableChildObject", "");
            this.colsAddressId.NamedProperties.Put("SqlColumn", "ADDRESS_ID");
            this.colsAddressId.NamedProperties.Put("ValidateMethod", "");
            this.colsAddressId.PopupBox.Lines = 5;
            this.colsAddressId.Position = 12;
            resources.ApplyResources(this.colsAddressId, "colsAddressId");
            // 
            // colAddressDefault
            // 
            this.colAddressDefault.CellType = PPJ.Runtime.Windows.CellType.CheckBox;
            this.colAddressDefault.CheckBox.CheckedValue = "TRUE";
            this.colAddressDefault.CheckBox.IgnoreCase = true;
            this.colAddressDefault.CheckBox.UncheckedValue = "FALSE";
            this.colAddressDefault.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.colAddressDefault.ComboBox.Sorted = true;
            this.colAddressDefault.Name = "colAddressDefault";
            this.colAddressDefault.NamedProperties.Put("EnumerateMethod", "");
            this.colAddressDefault.NamedProperties.Put("FieldFlags", "294");
            this.colAddressDefault.NamedProperties.Put("LovReference", "");
            this.colAddressDefault.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colAddressDefault.NamedProperties.Put("ResizeableChildObject", "");
            this.colAddressDefault.NamedProperties.Put("SqlColumn", "ADDRESS_DEFAULT");
            this.colAddressDefault.NamedProperties.Put("ValidateMethod", "");
            this.colAddressDefault.PopupBox.Lines = 5;
            this.colAddressDefault.Position = 13;
            resources.ApplyResources(this.colAddressDefault, "colAddressDefault");
            // 
            // coldValidFrom
            // 
            this.coldValidFrom.CheckBox.CheckedValue = "";
            this.coldValidFrom.CheckBox.IgnoreCase = true;
            this.coldValidFrom.CheckBox.UncheckedValue = "";
            this.coldValidFrom.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.coldValidFrom.ComboBox.Sorted = true;
            this.coldValidFrom.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.coldValidFrom.Format = "d";
            this.coldValidFrom.Name = "coldValidFrom";
            this.coldValidFrom.NamedProperties.Put("EnumerateMethod", "");
            this.coldValidFrom.NamedProperties.Put("FieldFlags", "294");
            this.coldValidFrom.NamedProperties.Put("LovReference", "");
            this.coldValidFrom.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.coldValidFrom.NamedProperties.Put("ResizeableChildObject", "");
            this.coldValidFrom.NamedProperties.Put("SqlColumn", "VALID_FROM");
            this.coldValidFrom.NamedProperties.Put("ValidateMethod", "");
            this.coldValidFrom.PopupBox.Lines = 5;
            this.coldValidFrom.Position = 14;
            resources.ApplyResources(this.coldValidFrom, "coldValidFrom");
            // 
            // coldValidTo
            // 
            this.coldValidTo.CheckBox.CheckedValue = "";
            this.coldValidTo.CheckBox.IgnoreCase = true;
            this.coldValidTo.CheckBox.UncheckedValue = "";
            this.coldValidTo.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.coldValidTo.ComboBox.Sorted = true;
            this.coldValidTo.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.coldValidTo.Format = "d";
            this.coldValidTo.Name = "coldValidTo";
            this.coldValidTo.NamedProperties.Put("EnumerateMethod", "");
            this.coldValidTo.NamedProperties.Put("FieldFlags", "294");
            this.coldValidTo.NamedProperties.Put("LovReference", "");
            this.coldValidTo.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.coldValidTo.NamedProperties.Put("ResizeableChildObject", "");
            this.coldValidTo.NamedProperties.Put("SqlColumn", "VALID_TO");
            this.coldValidTo.NamedProperties.Put("ValidateMethod", "");
            this.coldValidTo.PopupBox.Lines = 5;
            this.coldValidTo.Position = 15;
            resources.ApplyResources(this.coldValidTo, "coldValidTo");
            // 
            // colsPrevAddrId
            // 
            this.colsPrevAddrId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsPrevAddrId.CheckBox.CheckedValue = "";
            this.colsPrevAddrId.CheckBox.IgnoreCase = true;
            this.colsPrevAddrId.CheckBox.UncheckedValue = "";
            this.colsPrevAddrId.ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.colsPrevAddrId.ComboBox.Sorted = true;
            this.colsPrevAddrId.EditorSize = new System.Drawing.Size(0, 0);
            this.colsPrevAddrId.MaxLength = 50;
            this.colsPrevAddrId.Name = "colsPrevAddrId";
            this.colsPrevAddrId.NamedProperties.Put("EnumerateMethod", "");
            this.colsPrevAddrId.NamedProperties.Put("FieldFlags", "256");
            this.colsPrevAddrId.NamedProperties.Put("LovReference", "");
            this.colsPrevAddrId.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsPrevAddrId.NamedProperties.Put("ResizeableChildObject", "");
            this.colsPrevAddrId.NamedProperties.Put("SqlColumn", "ADDRESS_ID");
            this.colsPrevAddrId.PopupBox.Lines = 5;
            this.colsPrevAddrId.Position = 16;
            this.colsPrevAddrId.ReadOnly = true;
            resources.ApplyResources(this.colsPrevAddrId, "colsPrevAddrId");
            // 
            // cChildTableCommMethod
            // 
            this.Controls.Add(this.colsPartyType);
            this.Controls.Add(this.colsPartyTypeDb);
            this.Controls.Add(this.colsIdentity);
            this.Controls.Add(this.colnCommId);
            this.Controls.Add(this.colsName);
            this.Controls.Add(this.colsDescription);
            this.Controls.Add(this.colsMethodId);
            this.Controls.Add(this.colsValue);
            this.Controls.Add(this.colMethodDefault);
            this.Controls.Add(this.colsAddressId);
            this.Controls.Add(this.colAddressDefault);
            this.Controls.Add(this.coldValidFrom);
            this.Controls.Add(this.coldValidTo);
            this.Controls.Add(this.colsPrevAddrId);
            this.Name = "cChildTableCommMethod";
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("SourceFlags", "449");
            resources.ApplyResources(this, "$this");
            this.Controls.SetChildIndex(this.colsPrevAddrId, 0);
            this.Controls.SetChildIndex(this.coldValidTo, 0);
            this.Controls.SetChildIndex(this.coldValidFrom, 0);
            this.Controls.SetChildIndex(this.colAddressDefault, 0);
            this.Controls.SetChildIndex(this.colsAddressId, 0);
            this.Controls.SetChildIndex(this.colMethodDefault, 0);
            this.Controls.SetChildIndex(this.colsValue, 0);
            this.Controls.SetChildIndex(this.colsMethodId, 0);
            this.Controls.SetChildIndex(this.colsDescription, 0);
            this.Controls.SetChildIndex(this.colsName, 0);
            this.Controls.SetChildIndex(this.colnCommId, 0);
            this.Controls.SetChildIndex(this.colsIdentity, 0);
            this.Controls.SetChildIndex(this.colsPartyTypeDb, 0);
            this.Controls.SetChildIndex(this.colsPartyType, 0);
            this.Controls.SetChildIndex(this.@__colObjversion, 0);
            this.Controls.SetChildIndex(this.@__colObjid, 0);
            this.ResumeLayout(false);

		}
		#endregion
	}
}
