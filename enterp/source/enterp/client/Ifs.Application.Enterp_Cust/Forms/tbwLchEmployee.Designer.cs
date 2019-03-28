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

namespace Ifs.Application.Enterp_Cust
{

    public partial class tbwLchEmployee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwLchEmployee));
            this.colsEmployeeId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsEmployeeName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsLoginName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsLoginPassword = new Ifs.Fnd.ApplicationForms.cColumn();
            this.coldBirthday = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colnAge = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuTbwMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.tsMenuItemChangePassword = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.cmdChangePassword = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.colsSex = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.menuTbwMethods.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.cmdChangePassword);
            this.commandManager.ContextMenus.Add(this.menuTbwMethods);
            this.commandManager.ImageList = null;
            // 
            // colsEmployeeId
            // 
            this.colsEmployeeId.MaxLength = 20;
            this.colsEmployeeId.Name = "colsEmployeeId";
            this.colsEmployeeId.NamedProperties.Put("EnumerateMethod", "");
            this.colsEmployeeId.NamedProperties.Put("FieldFlags", "163");
            this.colsEmployeeId.NamedProperties.Put("LovReference", "");
            this.colsEmployeeId.NamedProperties.Put("SqlColumn", "EMPLOYEE_ID");
            this.colsEmployeeId.Position = 3;
            resources.ApplyResources(this.colsEmployeeId, "colsEmployeeId");
            // 
            // colsEmployeeName
            // 
            this.colsEmployeeName.MaxLength = 20;
            this.colsEmployeeName.Name = "colsEmployeeName";
            this.colsEmployeeName.NamedProperties.Put("EnumerateMethod", "");
            this.colsEmployeeName.NamedProperties.Put("FieldFlags", "294");
            this.colsEmployeeName.NamedProperties.Put("LovReference", "");
            this.colsEmployeeName.NamedProperties.Put("SqlColumn", "EMPLOYEE_NAME");
            this.colsEmployeeName.Position = 4;
            resources.ApplyResources(this.colsEmployeeName, "colsEmployeeName");
            // 
            // colsLoginName
            // 
            this.colsLoginName.MaxLength = 20;
            this.colsLoginName.Name = "colsLoginName";
            this.colsLoginName.NamedProperties.Put("EnumerateMethod", "");
            this.colsLoginName.NamedProperties.Put("FieldFlags", "294");
            this.colsLoginName.NamedProperties.Put("LovReference", "");
            this.colsLoginName.NamedProperties.Put("SqlColumn", "LOGIN_NAME");
            this.colsLoginName.Position = 5;
            resources.ApplyResources(this.colsLoginName, "colsLoginName");
            // 
            // colsLoginPassword
            // 
            this.colsLoginPassword.MaxLength = 20;
            this.colsLoginPassword.Name = "colsLoginPassword";
            this.colsLoginPassword.NamedProperties.Put("EnumerateMethod", "");
            this.colsLoginPassword.NamedProperties.Put("FieldFlags", "290");
            this.colsLoginPassword.NamedProperties.Put("LovReference", "");
            this.colsLoginPassword.NamedProperties.Put("SqlColumn", "LOGIN_PASSWORD");
            this.colsLoginPassword.Position = 6;
            resources.ApplyResources(this.colsLoginPassword, "colsLoginPassword");
            // 
            // coldBirthday
            // 
            this.coldBirthday.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.coldBirthday.Format = "d";
            this.coldBirthday.Name = "coldBirthday";
            this.coldBirthday.NamedProperties.Put("EnumerateMethod", "");
            this.coldBirthday.NamedProperties.Put("FieldFlags", "294");
            this.coldBirthday.NamedProperties.Put("LovReference", "");
            this.coldBirthday.NamedProperties.Put("SqlColumn", "BIRTHDAY");
            this.coldBirthday.Position = 7;
            resources.ApplyResources(this.coldBirthday, "coldBirthday");
            this.coldBirthday.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tableWindow_coldBirthday_WindowActions);
            // 
            // colnAge
            // 
            this.colnAge.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.colnAge, "colnAge");
            this.colnAge.Name = "colnAge";
            this.colnAge.NamedProperties.Put("EnumerateMethod", "");
            this.colnAge.NamedProperties.Put("FieldFlags", "290");
            this.colnAge.NamedProperties.Put("Format", "");
            this.colnAge.NamedProperties.Put("LovReference", "");
            this.colnAge.NamedProperties.Put("SqlColumn", "AGE");
            this.colnAge.Position = 8;
            this.colnAge.ReadOnly = true;
            this.colnAge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // menuTbwMethods
            // 
            this.menuTbwMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMenuItemChangePassword});
            this.menuTbwMethods.Name = "menuTbwMethods";
            resources.ApplyResources(this.menuTbwMethods, "menuTbwMethods");
            // 
            // tsMenuItemChangePassword
            // 
            this.tsMenuItemChangePassword.Command = this.cmdChangePassword;
            this.tsMenuItemChangePassword.Name = "tsMenuItemChangePassword";
            resources.ApplyResources(this.tsMenuItemChangePassword, "tsMenuItemChangePassword");
            this.tsMenuItemChangePassword.Text = "&ChangePassword...";
            // 
            // cmdChangePassword
            // 
            resources.ApplyResources(this.cmdChangePassword, "cmdChangePassword");
            this.cmdChangePassword.Name = "cmdChangePassword";
            this.cmdChangePassword.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.cmdChangePassword_Execute);
            this.cmdChangePassword.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.cmdChangePassword_Inquire);
            // 
            // colsSex
            // 
            this.colsSex.MaxLength = 200;
            this.colsSex.Name = "colsSex";
            this.colsSex.NamedProperties.Put("EnumerateMethod", "SEX_ENUMERATION_API.Enumerate");
            this.colsSex.NamedProperties.Put("FieldFlags", "294");
            this.colsSex.NamedProperties.Put("LovReference", "");
            this.colsSex.NamedProperties.Put("SqlColumn", "SEX");
            this.colsSex.Position = 9;
            resources.ApplyResources(this.colsSex, "colsSex");
            // 
            // tbwLchEmployee
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colsEmployeeId);
            this.Controls.Add(this.colsEmployeeName);
            this.Controls.Add(this.colsLoginName);
            this.Controls.Add(this.colsLoginPassword);
            this.Controls.Add(this.coldBirthday);
            this.Controls.Add(this.colsSex);
            this.Controls.Add(this.colnAge);
            this.Name = "tbwLchEmployee";
            this.NamedProperties.Put("LogicalUnit", "LchEmployee");
            this.NamedProperties.Put("Module", "ENTERP");
            this.NamedProperties.Put("PackageName", "Lch_Employee_API");
            this.NamedProperties.Put("SourceFlags", "449");
            this.NamedProperties.Put("ViewName", "LCH_EMPLOYEE");
            this.Controls.SetChildIndex(this.colnAge, 0);
            this.Controls.SetChildIndex(this.colsSex, 0);
            this.Controls.SetChildIndex(this.coldBirthday, 0);
            this.Controls.SetChildIndex(this.colsLoginPassword, 0);
            this.Controls.SetChildIndex(this.colsLoginName, 0);
            this.Controls.SetChildIndex(this.colsEmployeeName, 0);
            this.Controls.SetChildIndex(this.colsEmployeeId, 0);
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

        protected cColumn colsEmployeeId;
        protected cColumn colsEmployeeName;
        protected cColumn colsLoginName;
        protected cColumn colsLoginPassword;
        protected cColumn coldBirthday;
        protected cColumn colnAge;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTbwMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem tsMenuItemChangePassword;
        public Fnd.Windows.Forms.FndCommand cmdChangePassword;
        protected cLookupColumn colsSex;
    }
}
