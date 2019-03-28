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
// 130115   MaRalk  PBR-1203, Removed LOV reference CUSTOMER_INFO from colsCustomerId column.
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
	
	public partial class tbwCustomerInfoMsgSetup
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cColumn colMessageClass;
		public cColumn colMediaCode;
		public cColumn colAddress;
		public cColumn colnSequenceNo;
		public cCheckBoxColumn colMethodDefault;
		public cColumn colsCustomerId;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwCustomerInfoMsgSetup));
            this.colMessageClass = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colMediaCode = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colAddress = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colnSequenceNo = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colMethodDefault = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.colsCustomerId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsLocale = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.SuspendLayout();
            // 
            // colMessageClass
            // 
            this.colMessageClass.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colMessageClass.MaxLength = 30;
            this.colMessageClass.Name = "colMessageClass";
            this.colMessageClass.NamedProperties.Put("EnumerateMethod", "");
            this.colMessageClass.NamedProperties.Put("FieldFlags", "167");
            this.colMessageClass.NamedProperties.Put("LovReference", "MESSAGE_CLASS");
            this.colMessageClass.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colMessageClass.NamedProperties.Put("ResizeableChildObject", "");
            this.colMessageClass.NamedProperties.Put("SqlColumn", "MESSAGE_CLASS");
            this.colMessageClass.NamedProperties.Put("ValidateMethod", "");
            this.colMessageClass.Position = 3;
            resources.ApplyResources(this.colMessageClass, "colMessageClass");
            // 
            // colMediaCode
            // 
            this.colMediaCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colMediaCode.MaxLength = 30;
            this.colMediaCode.Name = "colMediaCode";
            this.colMediaCode.NamedProperties.Put("EnumerateMethod", "");
            this.colMediaCode.NamedProperties.Put("FieldFlags", "167");
            this.colMediaCode.NamedProperties.Put("LovReference", "MESSAGE_MEDIA");
            this.colMediaCode.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colMediaCode.NamedProperties.Put("ResizeableChildObject", "");
            this.colMediaCode.NamedProperties.Put("SqlColumn", "MEDIA_CODE");
            this.colMediaCode.NamedProperties.Put("ValidateMethod", "");
            this.colMediaCode.Position = 4;
            resources.ApplyResources(this.colMediaCode, "colMediaCode");
            // 
            // colAddress
            // 
            this.colAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colAddress.MaxLength = 200;
            this.colAddress.Name = "colAddress";
            this.colAddress.NamedProperties.Put("EnumerateMethod", "");
            this.colAddress.NamedProperties.Put("FieldFlags", "167");
            this.colAddress.NamedProperties.Put("LovReference", "MESSAGE_RECEIVER");
            this.colAddress.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colAddress.NamedProperties.Put("ResizeableChildObject", "");
            this.colAddress.NamedProperties.Put("SqlColumn", "ADDRESS");
            this.colAddress.NamedProperties.Put("ValidateMethod", "");
            this.colAddress.Position = 5;
            resources.ApplyResources(this.colAddress, "colAddress");
            // 
            // colnSequenceNo
            // 
            this.colnSequenceNo.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnSequenceNo.Name = "colnSequenceNo";
            this.colnSequenceNo.NamedProperties.Put("EnumerateMethod", "");
            this.colnSequenceNo.NamedProperties.Put("FieldFlags", "294");
            this.colnSequenceNo.NamedProperties.Put("LovReference", "");
            this.colnSequenceNo.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colnSequenceNo.NamedProperties.Put("ResizeableChildObject", "");
            this.colnSequenceNo.NamedProperties.Put("SqlColumn", "SEQUENCE_NO");
            this.colnSequenceNo.NamedProperties.Put("ValidateMethod", "");
            this.colnSequenceNo.Position = 6;
            resources.ApplyResources(this.colnSequenceNo, "colnSequenceNo");
            // 
            // colMethodDefault
            // 
            this.colMethodDefault.Name = "colMethodDefault";
            this.colMethodDefault.NamedProperties.Put("EnumerateMethod", "");
            this.colMethodDefault.NamedProperties.Put("FieldFlags", "295");
            this.colMethodDefault.NamedProperties.Put("LovReference", "");
            this.colMethodDefault.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colMethodDefault.NamedProperties.Put("ResizeableChildObject", "");
            this.colMethodDefault.NamedProperties.Put("SqlColumn", "METHOD_DEFAULT");
            this.colMethodDefault.NamedProperties.Put("ValidateMethod", "");
            this.colMethodDefault.Position = 7;
            resources.ApplyResources(this.colMethodDefault, "colMethodDefault");
            // 
            // colsCustomerId
            // 
            this.colsCustomerId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.colsCustomerId, "colsCustomerId");
            this.colsCustomerId.MaxLength = 20;
            this.colsCustomerId.Name = "colsCustomerId";
            this.colsCustomerId.NamedProperties.Put("EnumerateMethod", "");
            this.colsCustomerId.NamedProperties.Put("FieldFlags", "67");
            this.colsCustomerId.NamedProperties.Put("LovReference", "");
            this.colsCustomerId.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsCustomerId.NamedProperties.Put("ResizeableChildObject", "");
            this.colsCustomerId.NamedProperties.Put("SqlColumn", "CUSTOMER_ID");
            this.colsCustomerId.NamedProperties.Put("ValidateMethod", "");
            this.colsCustomerId.Position = 8;
            // 
            // colsLocale
            // 
            this.colsLocale.MaxLength = 8;
            this.colsLocale.Name = "colsLocale";
            this.colsLocale.NamedProperties.Put("EnumerateMethod", "Language_Code_API.Enum_Lang_Code_Rfc3066");
            this.colsLocale.NamedProperties.Put("FieldFlags", "294");
            this.colsLocale.NamedProperties.Put("LovReference", "");
            this.colsLocale.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.colsLocale.NamedProperties.Put("SqlColumn", "LOCALE");
            this.colsLocale.Position = 9;
            resources.ApplyResources(this.colsLocale, "colsLocale");
            this.colsLocale.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colsLocale_WindowActions);
            // 
            // tbwCustomerInfoMsgSetup
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colMessageClass);
            this.Controls.Add(this.colMediaCode);
            this.Controls.Add(this.colAddress);
            this.Controls.Add(this.colnSequenceNo);
            this.Controls.Add(this.colMethodDefault);
            this.Controls.Add(this.colsCustomerId);
            this.Controls.Add(this.colsLocale);
            this.Name = "tbwCustomerInfoMsgSetup";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "CustomerInfoMsgSetup");
            this.NamedProperties.Put("PackageName", "CUSTOMER_INFO_MSG_SETUP_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizableChildObject", "");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("SourceFlags", "449");
            this.NamedProperties.Put("ViewName", "CUSTOMER_INFO_MSG_SETUP");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.Controls.SetChildIndex(this.colsLocale, 0);
            this.Controls.SetChildIndex(this.colsCustomerId, 0);
            this.Controls.SetChildIndex(this.colMethodDefault, 0);
            this.Controls.SetChildIndex(this.colnSequenceNo, 0);
            this.Controls.SetChildIndex(this.colAddress, 0);
            this.Controls.SetChildIndex(this.colMediaCode, 0);
            this.Controls.SetChildIndex(this.colMessageClass, 0);
            this.Controls.SetChildIndex(this.@__colObjversion, 0);
            this.Controls.SetChildIndex(this.@__colObjid, 0);
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

        protected cLookupColumn colsLocale;
	}
}