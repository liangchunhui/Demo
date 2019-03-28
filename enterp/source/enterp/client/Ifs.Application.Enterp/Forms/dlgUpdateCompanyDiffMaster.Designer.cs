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
	
	public partial class dlgUpdateCompanyDiffMaster
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cResizeSplitter ccDiffMaster;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgUpdateCompanyDiffMaster));
            this.ccDiffMaster = new Ifs.Fnd.ApplicationForms.cResizeSplitter();
            this.ClientArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // ClientArea
            // 
            this.ClientArea.Controls.Add(this.ccDiffMaster);
            resources.ApplyResources(this.ClientArea, "ClientArea");
            // 
            // ccDiffMaster
            // 
            this.ccDiffMaster.Name = "ccDiffMaster";
            this.ccDiffMaster.NamedProperties.Put("First", "frm");
            this.ccDiffMaster.NamedProperties.Put("frmFirst", "frmUpdateCompanyDiffHeader");
            this.ccDiffMaster.NamedProperties.Put("frmSecond", "frmUpdateCompanyDiffDetail");
            this.ccDiffMaster.NamedProperties.Put("objFirst", "");
            this.ccDiffMaster.NamedProperties.Put("objSecond", "");
            this.ccDiffMaster.NamedProperties.Put("Second", "frm");
            resources.ApplyResources(this.ccDiffMaster, "ccDiffMaster");
            this.ccDiffMaster.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.ccDiffMaster_WindowActions);
            // 
            // dlgUpdateCompanyDiffMaster
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "dlgUpdateCompanyDiffMaster";
            this.ShowIcon = false;
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dlgUpdateCompanyDiffMaster_WindowActions);
            this.ClientArea.ResumeLayout(false);
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
