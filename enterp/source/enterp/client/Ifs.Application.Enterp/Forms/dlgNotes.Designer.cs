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
	
	public partial class dlgNotes
	{
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		#region Window Controls
		public cDataField dfnNoteId;
		public cPushButton pbOk;
		public cPushButton pbNew;
		public cPushButton pbSave;
		public cPushButton pbRemove;
		public cPushButton pbClose;
		protected cBackgroundText labeldfsUserId;
		public cDataField dfsUserId;
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgNotes));
            this.dfnNoteId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.pbOk = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbNew = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbSave = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbRemove = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbClose = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.labeldfsUserId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsUserId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.tblNotes = new Ifs.Application.Enterp.cChildTableEntBase();
            this.tblNotes_colnNoteId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblNotes_colnRowNo = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblNotes_coldTimestamp = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblNotes_colText = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblNotes_colsUserId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.ClientArea.SuspendLayout();
            this.tblNotes.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolBar
            // 
            resources.ApplyResources(this.ToolBar, "ToolBar");
            // 
            // ClientArea
            // 
            this.ClientArea.BackColor = System.Drawing.Color.Transparent;
            this.ClientArea.Controls.Add(this.dfsUserId);
            this.ClientArea.Controls.Add(this.pbClose);
            this.ClientArea.Controls.Add(this.pbRemove);
            this.ClientArea.Controls.Add(this.pbSave);
            this.ClientArea.Controls.Add(this.pbNew);
            this.ClientArea.Controls.Add(this.pbOk);
            this.ClientArea.Controls.Add(this.dfnNoteId);
            this.ClientArea.Controls.Add(this.tblNotes);
            this.ClientArea.Controls.Add(this.labeldfsUserId);
            resources.ApplyResources(this.ClientArea, "ClientArea");
            // 
            // StatusBar
            // 
            resources.ApplyResources(this.StatusBar, "StatusBar");
            // 
            // commandManager
            // 
            this.commandManager.Components.Add(this.pbClose);
            this.commandManager.Components.Add(this.pbRemove);
            this.commandManager.Components.Add(this.pbSave);
            this.commandManager.Components.Add(this.pbNew);
            this.commandManager.Components.Add(this.pbOk);
            // 
            // dfnNoteId
            // 
            this.dfnNoteId.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfnNoteId, "dfnNoteId");
            this.dfnNoteId.Name = "dfnNoteId";
            this.dfnNoteId.NamedProperties.Put("EnumerateMethod", "");
            this.dfnNoteId.NamedProperties.Put("FieldFlags", "64");
            this.dfnNoteId.NamedProperties.Put("LovReference", "");
            this.dfnNoteId.NamedProperties.Put("ResizeableChildObject", "");
            this.dfnNoteId.NamedProperties.Put("SqlColumn", "");
            this.dfnNoteId.NamedProperties.Put("ValidateMethod", "");
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
            // pbNew
            // 
            this.pbNew.AcceleratorKey = System.Windows.Forms.Keys.F5;
            resources.ApplyResources(this.pbNew, "pbNew");
            this.pbNew.Name = "pbNew";
            this.pbNew.NamedProperties.Put("MethodId", "18385");
            this.pbNew.NamedProperties.Put("MethodParameter", "New");
            this.pbNew.NamedProperties.Put("ResizableChildObject", "");
            this.pbNew.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // pbSave
            // 
            this.pbSave.AcceleratorKey = System.Windows.Forms.Keys.F12;
            resources.ApplyResources(this.pbSave, "pbSave");
            this.pbSave.Name = "pbSave";
            this.pbSave.NamedProperties.Put("MethodId", "18385");
            this.pbSave.NamedProperties.Put("MethodParameter", "Save");
            this.pbSave.NamedProperties.Put("ResizableChildObject", "");
            this.pbSave.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // pbRemove
            // 
            this.pbRemove.AcceleratorKey = System.Windows.Forms.Keys.F7;
            resources.ApplyResources(this.pbRemove, "pbRemove");
            this.pbRemove.Name = "pbRemove";
            this.pbRemove.NamedProperties.Put("MethodId", "18385");
            this.pbRemove.NamedProperties.Put("MethodParameter", "Remove");
            this.pbRemove.NamedProperties.Put("ResizableChildObject", "");
            this.pbRemove.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // pbClose
            // 
            this.pbClose.AcceleratorKey = System.Windows.Forms.Keys.Escape;
            resources.ApplyResources(this.pbClose, "pbClose");
            this.pbClose.Name = "pbClose";
            this.pbClose.NamedProperties.Put("MethodId", "18385");
            this.pbClose.NamedProperties.Put("MethodParameter", "Close");
            this.pbClose.NamedProperties.Put("ResizableChildObject", "");
            this.pbClose.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // labeldfsUserId
            // 
            resources.ApplyResources(this.labeldfsUserId, "labeldfsUserId");
            this.labeldfsUserId.Name = "labeldfsUserId";
            // 
            // dfsUserId
            // 
            resources.ApplyResources(this.dfsUserId, "dfsUserId");
            this.dfsUserId.Name = "dfsUserId";
            this.dfsUserId.NamedProperties.Put("EnumerateMethod", "");
            this.dfsUserId.NamedProperties.Put("FieldFlags", "295");
            this.dfsUserId.NamedProperties.Put("LovReference", "");
            this.dfsUserId.NamedProperties.Put("SqlColumn", "USER_ID");
            // 
            // tblNotes
            // 
            resources.ApplyResources(this.tblNotes, "tblNotes");
            this.tblNotes.Controls.Add(this.tblNotes_colnNoteId);
            this.tblNotes.Controls.Add(this.tblNotes_colnRowNo);
            this.tblNotes.Controls.Add(this.tblNotes_coldTimestamp);
            this.tblNotes.Controls.Add(this.tblNotes_colText);
            this.tblNotes.Controls.Add(this.tblNotes_colsUserId);
            this.tblNotes.Name = "tblNotes";
            this.tblNotes.NamedProperties.Put("DefaultOrderBy", "TIMESTAMP");
            this.tblNotes.NamedProperties.Put("DefaultWhere", "NOTE_ID = :i_hWndFrame.dlgNotes.nNoteId");
            this.tblNotes.NamedProperties.Put("LogicalUnit", "FinNoteText");
            this.tblNotes.NamedProperties.Put("PackageName", "FIN_NOTE_TEXT_API");
            this.tblNotes.NamedProperties.Put("ResizeableChildObject", "LLRR");
            this.tblNotes.NamedProperties.Put("ViewName", "FIN_NOTE_TEXT");
            this.tblNotes.NamedProperties.Put("Warnings", "FALSE");
            this.tblNotes.DataRecordGetDefaultsEvent += new System.EventHandler<Ifs.Fnd.ApplicationForms.FndReturnEventArgsSalBoolean>(this.tblNotes_DataRecordGetDefaultsEvent);
            this.tblNotes.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblNotes_WindowActions);
            this.tblNotes.Controls.SetChildIndex(this.tblNotes_colsUserId, 0);
            this.tblNotes.Controls.SetChildIndex(this.tblNotes_colText, 0);
            this.tblNotes.Controls.SetChildIndex(this.tblNotes_coldTimestamp, 0);
            this.tblNotes.Controls.SetChildIndex(this.tblNotes_colnRowNo, 0);
            this.tblNotes.Controls.SetChildIndex(this.tblNotes_colnNoteId, 0);
            // 
            // tblNotes_colnNoteId
            // 
            this.tblNotes_colnNoteId.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.tblNotes_colnNoteId, "tblNotes_colnNoteId");
            this.tblNotes_colnNoteId.Name = "tblNotes_colnNoteId";
            this.tblNotes_colnNoteId.NamedProperties.Put("EnumerateMethod", "");
            this.tblNotes_colnNoteId.NamedProperties.Put("FieldFlags", "67");
            this.tblNotes_colnNoteId.NamedProperties.Put("LovReference", "FIN_NOTE");
            this.tblNotes_colnNoteId.NamedProperties.Put("SqlColumn", "NOTE_ID");
            this.tblNotes_colnNoteId.Position = 3;
            // 
            // tblNotes_colnRowNo
            // 
            this.tblNotes_colnRowNo.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.tblNotes_colnRowNo, "tblNotes_colnRowNo");
            this.tblNotes_colnRowNo.Name = "tblNotes_colnRowNo";
            this.tblNotes_colnRowNo.NamedProperties.Put("EnumerateMethod", "");
            this.tblNotes_colnRowNo.NamedProperties.Put("FieldFlags", "131");
            this.tblNotes_colnRowNo.NamedProperties.Put("LovReference", "");
            this.tblNotes_colnRowNo.NamedProperties.Put("SqlColumn", "ROW_NO");
            this.tblNotes_colnRowNo.Position = 4;
            // 
            // tblNotes_coldTimestamp
            // 
            this.tblNotes_coldTimestamp.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            resources.ApplyResources(this.tblNotes_coldTimestamp, "tblNotes_coldTimestamp");
            this.tblNotes_coldTimestamp.Format = "G";
            this.tblNotes_coldTimestamp.Name = "tblNotes_coldTimestamp";
            this.tblNotes_coldTimestamp.NamedProperties.Put("EnumerateMethod", "");
            this.tblNotes_coldTimestamp.NamedProperties.Put("FieldFlags", "289");
            this.tblNotes_coldTimestamp.NamedProperties.Put("LovReference", "");
            this.tblNotes_coldTimestamp.NamedProperties.Put("ResizeableChildObject", "");
            this.tblNotes_coldTimestamp.NamedProperties.Put("SqlColumn", "TIMESTAMP");
            this.tblNotes_coldTimestamp.NamedProperties.Put("ValidateMethod", "");
            this.tblNotes_coldTimestamp.Position = 5;
            // 
            // tblNotes_colText
            // 
            this.tblNotes_colText.MaxLength = 2000;
            this.tblNotes_colText.Name = "tblNotes_colText";
            this.tblNotes_colText.NamedProperties.Put("EnumerateMethod", "");
            this.tblNotes_colText.NamedProperties.Put("FieldFlags", "311");
            this.tblNotes_colText.NamedProperties.Put("LovReference", "");
            this.tblNotes_colText.NamedProperties.Put("SqlColumn", "TEXT");
            this.tblNotes_colText.Position = 6;
            resources.ApplyResources(this.tblNotes_colText, "tblNotes_colText");
            this.tblNotes_colText.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.colText_WindowActions);
            // 
            // tblNotes_colsUserId
            // 
            resources.ApplyResources(this.tblNotes_colsUserId, "tblNotes_colsUserId");
            this.tblNotes_colsUserId.MaxLength = 20;
            this.tblNotes_colsUserId.Name = "tblNotes_colsUserId";
            this.tblNotes_colsUserId.NamedProperties.Put("EnumerateMethod", "");
            this.tblNotes_colsUserId.NamedProperties.Put("FieldFlags", "295");
            this.tblNotes_colsUserId.NamedProperties.Put("LovReference", "");
            this.tblNotes_colsUserId.NamedProperties.Put("SqlColumn", "USER_ID");
            this.tblNotes_colsUserId.Position = 7;
            // 
            // dlgNotes
            // 
            resources.ApplyResources(this, "$this");
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "dlgNotes";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "");
            this.NamedProperties.Put("PackageName", "");
            this.NamedProperties.Put("ParentName", "[NaturalParent]");
            this.NamedProperties.Put("ResizeableChildObject", "");
            this.NamedProperties.Put("ViewName", "");
            this.NamedProperties.Put("Warnings", "FALSE");
            this.ShowIcon = false;
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dlgNotes_WindowActions);
            this.ClientArea.ResumeLayout(false);
            this.ClientArea.PerformLayout();
            this.tblNotes.ResumeLayout(false);
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

        public cChildTableEntBase tblNotes;
        protected cColumn tblNotes_colnNoteId;
        protected cColumn tblNotes_colnRowNo;
        protected cColumn tblNotes_coldTimestamp;
        protected cColumn tblNotes_colText;
        protected cColumn tblNotes_colsUserId;
		
	}
}
