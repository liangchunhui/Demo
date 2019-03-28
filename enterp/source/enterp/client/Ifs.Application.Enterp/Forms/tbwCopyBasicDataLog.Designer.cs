#region Copyright (c) IFS Research & Development
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
#endregion
#region History
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ifs.Fnd.ApplicationForms;
using PPJ.Runtime;
using PPJ.Runtime.Windows;

namespace Ifs.Application.Enterp
{

    public partial class tbwCopyBasicDataLog
    {

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwCopyBasicDataLog));
            this.colnLogId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.coldTimestamp = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsSourceCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsCompanyName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsCopyType = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.colsStatus = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsUserId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuTbwMethods_menu_Details___ = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.tsMenuItemmenuTbwMethods_menu_Details___ = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.colsWindowName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuTbwMethods.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.menuTbwMethods_menu_Details___);
            this.commandManager.ContextMenus.Add(this.menuTbwMethods);
            // 
            // colnLogId
            // 
            this.colnLogId.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnLogId.Name = "colnLogId";
            this.colnLogId.NamedProperties.Put("EnumerateMethod", "");
            this.colnLogId.NamedProperties.Put("FieldFlags", "163");
            this.colnLogId.NamedProperties.Put("Format", "");
            this.colnLogId.NamedProperties.Put("LovReference", "");
            this.colnLogId.NamedProperties.Put("SqlColumn", "LOG_ID");
            this.colnLogId.Position = 3;
            this.colnLogId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.colnLogId, "colnLogId");
            // 
            // coldTimestamp
            // 
            this.coldTimestamp.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.coldTimestamp.Format = "G";
            this.coldTimestamp.Name = "coldTimestamp";
            this.coldTimestamp.NamedProperties.Put("EnumerateMethod", "");
            this.coldTimestamp.NamedProperties.Put("FieldFlags", "291");
            this.coldTimestamp.NamedProperties.Put("LovReference", "");
            this.coldTimestamp.NamedProperties.Put("SqlColumn", "TIMESTAMP");
            this.coldTimestamp.Position = 10;
            resources.ApplyResources(this.coldTimestamp, "coldTimestamp");
            // 
            // colsSourceCompany
            // 
            this.colsSourceCompany.MaxLength = 20;
            this.colsSourceCompany.Name = "colsSourceCompany";
            this.colsSourceCompany.NamedProperties.Put("EnumerateMethod", "");
            this.colsSourceCompany.NamedProperties.Put("FieldFlags", "291");
            this.colsSourceCompany.NamedProperties.Put("LovReference", "");
            this.colsSourceCompany.NamedProperties.Put("SqlColumn", "SOURCE_COMPANY");
            this.colsSourceCompany.Position = 4;
            resources.ApplyResources(this.colsSourceCompany, "colsSourceCompany");
            // 
            // colsCompanyName
            // 
            this.colsCompanyName.Name = "colsCompanyName";
            this.colsCompanyName.NamedProperties.Put("EnumerateMethod", "");
            this.colsCompanyName.NamedProperties.Put("FieldFlags", "288");
            this.colsCompanyName.NamedProperties.Put("LovReference", "");
            this.colsCompanyName.NamedProperties.Put("SqlColumn", "COMPANY_NAME");
            this.colsCompanyName.Position = 5;
            resources.ApplyResources(this.colsCompanyName, "colsCompanyName");
            // 
            // colsCopyType
            // 
            this.colsCopyType.CellType = PPJ.Runtime.Windows.CellType.Standard;
            this.colsCopyType.MaxLength = 200;
            this.colsCopyType.Name = "colsCopyType";
            this.colsCopyType.NamedProperties.Put("EnumerateMethod", "SYNCHRONIZATION_TYPE_API.Enumerate");
            this.colsCopyType.NamedProperties.Put("FieldFlags", "291");
            this.colsCopyType.NamedProperties.Put("LovReference", "");
            this.colsCopyType.NamedProperties.Put("SqlColumn", "COPY_TYPE");
            this.colsCopyType.Position = 7;
            resources.ApplyResources(this.colsCopyType, "colsCopyType");
            // 
            // colsStatus
            // 
            this.colsStatus.MaxLength = 20;
            this.colsStatus.Name = "colsStatus";
            this.colsStatus.NamedProperties.Put("EnumerateMethod", "");
            this.colsStatus.NamedProperties.Put("FieldFlags", "295");
            this.colsStatus.NamedProperties.Put("LovReference", "");
            this.colsStatus.NamedProperties.Put("SqlColumn", "STATUS");
            this.colsStatus.Position = 8;
            resources.ApplyResources(this.colsStatus, "colsStatus");
            // 
            // colsUserId
            // 
            this.colsUserId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsUserId.MaxLength = 30;
            this.colsUserId.Name = "colsUserId";
            this.colsUserId.NamedProperties.Put("EnumerateMethod", "");
            this.colsUserId.NamedProperties.Put("FieldFlags", "291");
            this.colsUserId.NamedProperties.Put("LovReference", "");
            this.colsUserId.NamedProperties.Put("SqlColumn", "USER_ID");
            this.colsUserId.Position = 9;
            resources.ApplyResources(this.colsUserId, "colsUserId");
            // 
            // menuTbwMethods_menu_Details___
            // 
            resources.ApplyResources(this.menuTbwMethods_menu_Details___, "menuTbwMethods_menu_Details___");
            this.menuTbwMethods_menu_Details___.Name = "menuTbwMethods_menu_Details___";
            this.menuTbwMethods_menu_Details___.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.menuTbwMethods_menu_Details____Execute);
            this.menuTbwMethods_menu_Details___.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.menuTbwMethods_menu_Details____Inquire);
            // 
            // menuTbwMethods
            // 
            this.menuTbwMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMenuItemmenuTbwMethods_menu_Details___});
            this.menuTbwMethods.Name = "menuTbwMethods";
            resources.ApplyResources(this.menuTbwMethods, "menuTbwMethods");
            // 
            // tsMenuItemmenuTbwMethods_menu_Details___
            // 
            this.tsMenuItemmenuTbwMethods_menu_Details___.Command = this.menuTbwMethods_menu_Details___;
            this.tsMenuItemmenuTbwMethods_menu_Details___.Name = "tsMenuItemmenuTbwMethods_menu_Details___";
            resources.ApplyResources(this.tsMenuItemmenuTbwMethods_menu_Details___, "tsMenuItemmenuTbwMethods_menu_Details___");
            this.tsMenuItemmenuTbwMethods_menu_Details___.Text = "Details...";
            // 
            // colsWindowName
            // 
            this.colsWindowName.MaxLength = 1000;
            this.colsWindowName.Name = "colsWindowName";
            this.colsWindowName.NamedProperties.Put("EnumerateMethod", "");
            this.colsWindowName.NamedProperties.Put("FieldFlags", "288");
            this.colsWindowName.NamedProperties.Put("LovReference", "");
            this.colsWindowName.NamedProperties.Put("SqlColumn", "WINDOW_NAME");
            this.colsWindowName.Position = 6;
            resources.ApplyResources(this.colsWindowName, "colsWindowName");
            // 
            // tbwCopyBasicDataLog
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colnLogId);
            this.Controls.Add(this.colsSourceCompany);
            this.Controls.Add(this.colsCompanyName);
            this.Controls.Add(this.colsWindowName);
            this.Controls.Add(this.colsCopyType);
            this.Controls.Add(this.colsStatus);
            this.Controls.Add(this.colsUserId);
            this.Controls.Add(this.coldTimestamp);
            this.Name = "tbwCopyBasicDataLog";
            this.NamedProperties.Put("DefaultOrderBy", "LOG_ID DESC");
            this.NamedProperties.Put("LogicalUnit", "CopyBasicDataLog");
            this.NamedProperties.Put("Module", "ENTERP");
            this.NamedProperties.Put("PackageName", "COPY_BASIC_DATA_LOG_API");
            this.NamedProperties.Put("SourceFlags", "16641");
            this.NamedProperties.Put("ViewName", "COPY_BASIC_DATA_LOG");
            this.Controls.SetChildIndex(this.coldTimestamp, 0);
            this.Controls.SetChildIndex(this.colsUserId, 0);
            this.Controls.SetChildIndex(this.colsStatus, 0);
            this.Controls.SetChildIndex(this.colsCopyType, 0);
            this.Controls.SetChildIndex(this.colsWindowName, 0);
            this.Controls.SetChildIndex(this.colsCompanyName, 0);
            this.Controls.SetChildIndex(this.colsSourceCompany, 0);
            this.Controls.SetChildIndex(this.colnLogId, 0);
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

        protected cColumn colnLogId;
        protected cColumn coldTimestamp;
        protected cColumn colsSourceCompany;
        protected cColumn colsCompanyName;
        protected cLookupColumn colsCopyType;
        protected cColumn colsStatus;
        protected cColumn colsUserId;
        public Fnd.Windows.Forms.FndCommand menuTbwMethods_menu_Details___;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTbwMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem tsMenuItemmenuTbwMethods_menu_Details___;
        protected cColumn colsWindowName;
    }
}
