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
	
	public partial class dlgImportTemplateFile
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		protected cBackgroundText labeldfHeading1;
		public cDataField dfHeading;
		protected SalGroupBox gbFile_Details;
		protected cBackgroundText labeldfsTemplateSuffix;
		public SalDataField dfsTemplateSuffix;
		public cPushButton pbOk;
		public cPushButton pbCancel;
		protected cBackgroundText labellbFiles;
		public _cListBox lbFiles;
		public cPushButton pbAdd;
		public cPushButton pbRemove;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgImportTemplateFile));
            this.labeldfHeading1 = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfHeading = new Ifs.Fnd.ApplicationForms.cDataField();
            this.gbFile_Details = new PPJ.Runtime.Windows.SalGroupBox();
            this.labeldfsTemplateSuffix = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsTemplateSuffix = new PPJ.Runtime.Windows.SalDataField();
            this.pbOk = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbCancel = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.labellbFiles = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.lbFiles = new Ifs.Fnd.ApplicationForms._cListBox();
            this.pbAdd = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbRemove = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.labeldfHeading2 = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.labeldfHeading3 = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.labeldfHeading4 = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.labeldfHeading5 = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.ClientArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // ClientArea
            // 
            this.ClientArea.Controls.Add(this.labeldfHeading5);
            this.ClientArea.Controls.Add(this.labeldfHeading4);
            this.ClientArea.Controls.Add(this.labeldfHeading3);
            this.ClientArea.Controls.Add(this.labeldfHeading2);
            this.ClientArea.Controls.Add(this.pbRemove);
            this.ClientArea.Controls.Add(this.pbAdd);
            this.ClientArea.Controls.Add(this.lbFiles);
            this.ClientArea.Controls.Add(this.pbCancel);
            this.ClientArea.Controls.Add(this.pbOk);
            this.ClientArea.Controls.Add(this.dfsTemplateSuffix);
            this.ClientArea.Controls.Add(this.dfHeading);
            this.ClientArea.Controls.Add(this.labellbFiles);
            this.ClientArea.Controls.Add(this.labeldfsTemplateSuffix);
            this.ClientArea.Controls.Add(this.labeldfHeading1);
            this.ClientArea.Controls.Add(this.gbFile_Details);
            resources.ApplyResources(this.ClientArea, "ClientArea");
            // 
            // commandManager
            // 
            this.commandManager.Components.Add(this.pbRemove);
            this.commandManager.Components.Add(this.pbAdd);
            this.commandManager.Components.Add(this.pbCancel);
            this.commandManager.Components.Add(this.pbOk);
            // 
            // labeldfHeading1
            // 
            resources.ApplyResources(this.labeldfHeading1, "labeldfHeading1");
            this.labeldfHeading1.Name = "labeldfHeading1";
            // 
            // dfHeading
            // 
            this.dfHeading.Name = "dfHeading";
            resources.ApplyResources(this.dfHeading, "dfHeading");
            // 
            // gbFile_Details
            // 
            resources.ApplyResources(this.gbFile_Details, "gbFile_Details");
            this.gbFile_Details.Name = "gbFile_Details";
            this.gbFile_Details.TabStop = false;
            // 
            // labeldfsTemplateSuffix
            // 
            resources.ApplyResources(this.labeldfsTemplateSuffix, "labeldfsTemplateSuffix");
            this.labeldfsTemplateSuffix.Name = "labeldfsTemplateSuffix";
            // 
            // dfsTemplateSuffix
            // 
            this.dfsTemplateSuffix.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsTemplateSuffix, "dfsTemplateSuffix");
            this.dfsTemplateSuffix.Name = "dfsTemplateSuffix";
            // 
            // pbOk
            // 
            this.pbOk.AcceleratorKey = System.Windows.Forms.Keys.Return;
            resources.ApplyResources(this.pbOk, "pbOk");
            this.pbOk.Name = "pbOk";
            this.pbOk.NamedProperties.Put("MethodId", "18385");
            this.pbOk.NamedProperties.Put("MethodParameter", "Ok");
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
            // labellbFiles
            // 
            resources.ApplyResources(this.labellbFiles, "labellbFiles");
            this.labellbFiles.Name = "labellbFiles";
            // 
            // lbFiles
            // 
            resources.ApplyResources(this.lbFiles, "lbFiles");
            this.lbFiles.Name = "lbFiles";
            this.lbFiles.UseCustomTabOffsets = true;
            // 
            // pbAdd
            // 
            resources.ApplyResources(this.pbAdd, "pbAdd");
            this.pbAdd.Name = "pbAdd";
            this.pbAdd.NamedProperties.Put("MethodId", "18385");
            this.pbAdd.NamedProperties.Put("MethodParameter", "Add");
            this.pbAdd.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // pbRemove
            // 
            resources.ApplyResources(this.pbRemove, "pbRemove");
            this.pbRemove.Name = "pbRemove";
            this.pbRemove.NamedProperties.Put("MethodId", "18385");
            this.pbRemove.NamedProperties.Put("MethodParameter", "Remove");
            this.pbRemove.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // labeldfHeading2
            // 
            resources.ApplyResources(this.labeldfHeading2, "labeldfHeading2");
            this.labeldfHeading2.Name = "labeldfHeading2";
            // 
            // labeldfHeading3
            // 
            resources.ApplyResources(this.labeldfHeading3, "labeldfHeading3");
            this.labeldfHeading3.Name = "labeldfHeading3";
            // 
            // labeldfHeading4
            // 
            resources.ApplyResources(this.labeldfHeading4, "labeldfHeading4");
            this.labeldfHeading4.Name = "labeldfHeading4";
            // 
            // labeldfHeading5
            // 
            resources.ApplyResources(this.labeldfHeading5, "labeldfHeading5");
            this.labeldfHeading5.Name = "labeldfHeading5";
            // 
            // dlgImportTemplateFile
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "dlgImportTemplateFile";
            this.ShowIcon = false;
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dlgImportTemplateFile_WindowActions);
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

        protected cBackgroundText labeldfHeading5;
        protected cBackgroundText labeldfHeading4;
        protected cBackgroundText labeldfHeading3;
        protected cBackgroundText labeldfHeading2;
	}
}
