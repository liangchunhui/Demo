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
	
	public partial class frmCustomerInfoCommMethod
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomerInfoCommMethod));
            this.tblCommMethod = new Ifs.Application.Enterp.cChildTableCommMethod();
            this.tblCommMethod_coldValidFromOld = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblCommMethod_coldValidToOld = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblCommMethod.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblCommMethod
            // 
            // 
            // tblCommMethod.colAddressDefault
            // 
            resources.ApplyResources(this.tblCommMethod.colAddressDefault, "tblCommMethod.colAddressDefault");
            // 
            // tblCommMethod.coldValidFrom
            // 
            this.tblCommMethod.coldValidFrom.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblCommMethod_coldValidFrom_WindowActions);
            // 
            // tblCommMethod.coldValidTo
            // 
            this.tblCommMethod.coldValidTo.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblCommMethod_coldValidTo_WindowActions);
            // 
            // tblCommMethod.colMethodDefault
            // 
            resources.ApplyResources(this.tblCommMethod.colMethodDefault, "tblCommMethod.colMethodDefault");
            // 
            // tblCommMethod.colnCommId
            // 
            resources.ApplyResources(this.tblCommMethod.colnCommId, "tblCommMethod.colnCommId");
            // 
            // tblCommMethod.colsAddressId
            // 
            resources.ApplyResources(this.tblCommMethod.colsAddressId, "tblCommMethod.colsAddressId");
            // 
            // tblCommMethod.colsDescription
            // 
            resources.ApplyResources(this.tblCommMethod.colsDescription, "tblCommMethod.colsDescription");
            // 
            // tblCommMethod.colsMethodId
            // 
            resources.ApplyResources(this.tblCommMethod.colsMethodId, "tblCommMethod.colsMethodId");
            this.tblCommMethod.colsMethodId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblCommMethod_colsMethodId_WindowActions);
            // 
            // tblCommMethod.colsName
            // 
            resources.ApplyResources(this.tblCommMethod.colsName, "tblCommMethod.colsName");
            // 
            // tblCommMethod.colsPrevAddrId
            // 
            this.tblCommMethod.colsPrevAddrId.Position = 18;
            this.tblCommMethod.Controls.Add(this.tblCommMethod_coldValidFromOld);
            this.tblCommMethod.Controls.Add(this.tblCommMethod_coldValidToOld);
            resources.ApplyResources(this.tblCommMethod, "tblCommMethod");
            this.tblCommMethod.Name = "tblCommMethod";
            this.tblCommMethod.NamedProperties.Put("DefaultOrderBy", "");
            this.tblCommMethod.NamedProperties.Put("DefaultWhere", "");
            this.tblCommMethod.NamedProperties.Put("LogicalUnit", "CommMethod");
            this.tblCommMethod.NamedProperties.Put("PackageName", "COMM_METHOD_API");
            this.tblCommMethod.NamedProperties.Put("ResizeableChildObject", "LLMM");
            this.tblCommMethod.NamedProperties.Put("ViewName", "COMM_METHOD");
            this.tblCommMethod.NamedProperties.Put("Warnings", "FALSE");
            this.tblCommMethod.DataRecordExecuteModifyEvent += new Ifs.Fnd.ApplicationForms.cDataSource.DataRecordExecuteModifyEventHandler(this.tblCommMethod_DataRecordExecuteModifyEvent);
            this.tblCommMethod.DataRecordExecuteNewEvent += new Ifs.Fnd.ApplicationForms.cDataSource.DataRecordExecuteNewEventHandler(this.tblCommMethod_DataRecordExecuteNewEvent);
            this.tblCommMethod.DataSourcePrepareKeyTransferEvent += new Ifs.Fnd.ApplicationForms.cDataSource.DataSourcePrepareKeyTransferEventHandler(this.tblCommMethod_DataSourcePrepareKeyTransferEvent);
            this.tblCommMethod.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblCommMethod_WindowActions);
            this.tblCommMethod.Controls.SetChildIndex(this.tblCommMethod_coldValidToOld, 0);
            this.tblCommMethod.Controls.SetChildIndex(this.tblCommMethod_coldValidFromOld, 0);
            // 
            // tblCommMethod_coldValidFromOld
            // 
            this.tblCommMethod_coldValidFromOld.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.tblCommMethod_coldValidFromOld.Format = "d";
            this.tblCommMethod_coldValidFromOld.Name = "tblCommMethod_coldValidFromOld";
            this.tblCommMethod_coldValidFromOld.NamedProperties.Put("EnumerateMethod", "");
            this.tblCommMethod_coldValidFromOld.NamedProperties.Put("FieldFlags", "290");
            this.tblCommMethod_coldValidFromOld.NamedProperties.Put("LovReference", "");
            this.tblCommMethod_coldValidFromOld.NamedProperties.Put("SqlColumn", "");
            this.tblCommMethod_coldValidFromOld.Position = 16;
            resources.ApplyResources(this.tblCommMethod_coldValidFromOld, "tblCommMethod_coldValidFromOld");
            // 
            // tblCommMethod_coldValidToOld
            // 
            this.tblCommMethod_coldValidToOld.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.tblCommMethod_coldValidToOld.Format = "d";
            this.tblCommMethod_coldValidToOld.Name = "tblCommMethod_coldValidToOld";
            this.tblCommMethod_coldValidToOld.NamedProperties.Put("EnumerateMethod", "");
            this.tblCommMethod_coldValidToOld.NamedProperties.Put("FieldFlags", "290");
            this.tblCommMethod_coldValidToOld.NamedProperties.Put("LovReference", "");
            this.tblCommMethod_coldValidToOld.NamedProperties.Put("SqlColumn", "");
            this.tblCommMethod_coldValidToOld.Position = 17;
            resources.ApplyResources(this.tblCommMethod_coldValidToOld, "tblCommMethod_coldValidToOld");
            this.tblCommMethod_coldValidToOld.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblCommMethod_coldValidTo_WindowActions);
            // 
            // frmCustomerInfoCommMethod
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.tblCommMethod);
            this.Name = "frmCustomerInfoCommMethod";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "");
            this.NamedProperties.Put("PackageName", "");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("ViewName", "");
            this.NamedProperties.Put("Warnings", "TRUE");
            this.tblCommMethod.ResumeLayout(false);
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

        public cChildTableCommMethod tblCommMethod;
        protected cColumn tblCommMethod_coldValidFromOld;
        protected cColumn tblCommMethod_coldValidToOld;
		
	}
}
