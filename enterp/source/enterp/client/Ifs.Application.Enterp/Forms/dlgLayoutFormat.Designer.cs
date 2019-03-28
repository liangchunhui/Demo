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
	
	public partial class dlgLayoutFormat
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		protected cBackgroundText labeldfsTaxIdType;
		public cDataField dfsTaxIdType;
		protected cBackgroundText labeldfsLayoutFormat;
		public cDataField dfsLayoutFormat;
		public cPushButton pbOk;
		public cPushButton pbCancel;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgLayoutFormat));
            this.labeldfsTaxIdType = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsTaxIdType = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsLayoutFormat = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsLayoutFormat = new Ifs.Fnd.ApplicationForms.cDataField();
            this.pbOk = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbCancel = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.ClientArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // ClientArea
            // 
            this.ClientArea.Controls.Add(this.pbCancel);
            this.ClientArea.Controls.Add(this.pbOk);
            this.ClientArea.Controls.Add(this.dfsLayoutFormat);
            this.ClientArea.Controls.Add(this.dfsTaxIdType);
            this.ClientArea.Controls.Add(this.labeldfsLayoutFormat);
            this.ClientArea.Controls.Add(this.labeldfsTaxIdType);
            resources.ApplyResources(this.ClientArea, "ClientArea");
            // 
            // commandManager
            // 
            this.commandManager.Components.Add(this.pbCancel);
            this.commandManager.Components.Add(this.pbOk);
            // 
            // labeldfsTaxIdType
            // 
            resources.ApplyResources(this.labeldfsTaxIdType, "labeldfsTaxIdType");
            this.labeldfsTaxIdType.Name = "labeldfsTaxIdType";
            // 
            // dfsTaxIdType
            // 
            this.dfsTaxIdType.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.dfsTaxIdType, "dfsTaxIdType");
            this.dfsTaxIdType.Name = "dfsTaxIdType";
            this.dfsTaxIdType.NamedProperties.Put("EnumerateMethod", "");
            this.dfsTaxIdType.NamedProperties.Put("FieldFlags", "163");
            this.dfsTaxIdType.NamedProperties.Put("LovReference", "");
            this.dfsTaxIdType.NamedProperties.Put("SqlColumn", "TAX_ID_TYPE");
            this.dfsTaxIdType.ReadOnly = true;
            // 
            // labeldfsLayoutFormat
            // 
            resources.ApplyResources(this.labeldfsLayoutFormat, "labeldfsLayoutFormat");
            this.labeldfsLayoutFormat.Name = "labeldfsLayoutFormat";
            // 
            // dfsLayoutFormat
            // 
            resources.ApplyResources(this.dfsLayoutFormat, "dfsLayoutFormat");
            this.dfsLayoutFormat.Name = "dfsLayoutFormat";
            this.dfsLayoutFormat.NamedProperties.Put("EnumerateMethod", "");
            this.dfsLayoutFormat.NamedProperties.Put("FieldFlags", "294");
            this.dfsLayoutFormat.NamedProperties.Put("LovReference", "");
            this.dfsLayoutFormat.NamedProperties.Put("SqlColumn", "LAYOUT_FORMAT");
            // 
            // pbOk
            // 
            this.pbOk.AcceleratorKey = System.Windows.Forms.Keys.Return;
            resources.ApplyResources(this.pbOk, "pbOk");
            this.pbOk.Name = "pbOk";
            this.pbOk.NamedProperties.Put("MethodId", "18385");
            this.pbOk.NamedProperties.Put("MethodParameter", "OK");
            this.pbOk.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // pbCancel
            // 
            this.pbCancel.AcceleratorKey = System.Windows.Forms.Keys.Escape;
            resources.ApplyResources(this.pbCancel, "pbCancel");
            this.pbCancel.Name = "pbCancel";
            this.pbCancel.NamedProperties.Put("MethodId", "18385");
            this.pbCancel.NamedProperties.Put("MethodParameter", "Cancel");
            this.pbCancel.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // dlgLayoutFormat
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "dlgLayoutFormat";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "TAX_ID_TYPE = :i_hWndParent.tbwDefineTaxIdType.colsTaxIdType");
            this.NamedProperties.Put("LogicalUnit", "TaxIdType");
            this.NamedProperties.Put("PackageName", "TAX_ID_TYPE_API");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("ViewName", "TAX_ID_TYPE");
            this.NamedProperties.Put("Warnings", "FALSE");

            this.ShowIcon = false;
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dlgLayoutFormat_WindowActions);
            this.ClientArea.ResumeLayout(false);
            this.ClientArea.PerformLayout();
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
	}
}
