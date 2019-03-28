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

    public partial class tbwB2BCustomerUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwB2BCustomerUser));
            this.colsCustomerId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsUserId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsFndUser_GetDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsDefaultCustomer = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.cmdSetDefault = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.menuTbwMethods = new Ifs.Fnd.Windows.Forms.FndContextMenuStrip(this.components);
            this.tsMenuItem = new Ifs.Fnd.Windows.Forms.FndToolStripMenuItem(this.components);
            this.colsCustomerInfo_GetName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.menuTbwMethods.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.cmdSetDefault);
            this.commandManager.ContextMenus.Add(this.menuTbwMethods);
            // 
            // colsCustomerId
            // 
            this.colsCustomerId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsCustomerId.MaxLength = 20;
            this.colsCustomerId.Name = "colsCustomerId";
            this.colsCustomerId.NamedProperties.Put("EnumerateMethod", "");
            this.colsCustomerId.NamedProperties.Put("FieldFlags", "163");
            this.colsCustomerId.NamedProperties.Put("LovReference", "CUSTOMER_INFO");
            this.colsCustomerId.NamedProperties.Put("SqlColumn", "CUSTOMER_ID");
            this.colsCustomerId.Position = 5;
            resources.ApplyResources(this.colsCustomerId, "colsCustomerId");
            this.colsCustomerId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tableWindow_colsCustomerId_WindowActions);
            // 
            // colsUserId
            // 
            this.colsUserId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.colsUserId.MaxLength = 30;
            this.colsUserId.Name = "colsUserId";
            this.colsUserId.NamedProperties.Put("EnumerateMethod", "");
            this.colsUserId.NamedProperties.Put("FieldFlags", "163");
            this.colsUserId.NamedProperties.Put("LovReference", "FND_USER");
            this.colsUserId.NamedProperties.Put("SqlColumn", "USER_ID");
            this.colsUserId.Position = 3;
            resources.ApplyResources(this.colsUserId, "colsUserId");
            // 
            // colsFndUser_GetDescription
            // 
            this.colsFndUser_GetDescription.MaxLength = 2000;
            this.colsFndUser_GetDescription.Name = "colsFndUser_GetDescription";
            this.colsFndUser_GetDescription.NamedProperties.Put("EnumerateMethod", "");
            this.colsFndUser_GetDescription.NamedProperties.Put("FieldFlags", "304");
            this.colsFndUser_GetDescription.NamedProperties.Put("LovReference", "");
            this.colsFndUser_GetDescription.NamedProperties.Put("ParentName", "colsUserId");
            this.colsFndUser_GetDescription.NamedProperties.Put("SqlColumn", "FND_USER_API.Get_Description(USER_ID)");
            this.colsFndUser_GetDescription.Position = 4;
            resources.ApplyResources(this.colsFndUser_GetDescription, "colsFndUser_GetDescription");
            // 
            // colsDefaultCustomer
            // 
            resources.ApplyResources(this.colsDefaultCustomer, "colsDefaultCustomer");
            this.colsDefaultCustomer.MaxLength = 20;
            this.colsDefaultCustomer.Name = "colsDefaultCustomer";
            this.colsDefaultCustomer.NamedProperties.Put("EnumerateMethod", "");
            this.colsDefaultCustomer.NamedProperties.Put("FieldFlags", "288");
            this.colsDefaultCustomer.NamedProperties.Put("Format", "");
            this.colsDefaultCustomer.NamedProperties.Put("LovReference", "");
            this.colsDefaultCustomer.NamedProperties.Put("LovTimeReference", "");
            this.colsDefaultCustomer.NamedProperties.Put("SqlColumn", "DEFAULT_CUSTOMER_DB");
            this.colsDefaultCustomer.Position = 7;
            this.colsDefaultCustomer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cmdSetDefault
            // 
            resources.ApplyResources(this.cmdSetDefault, "cmdSetDefault");
            this.cmdSetDefault.Name = "cmdSetDefault";
            this.cmdSetDefault.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.cmdSetDefault_Execute);
            this.cmdSetDefault.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.cmdSetDefault_Inquire);
            // 
            // menuTbwMethods
            // 
            this.menuTbwMethods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMenuItem});
            this.menuTbwMethods.Name = "menuTbwMethods";
            resources.ApplyResources(this.menuTbwMethods, "menuTbwMethods");
            // 
            // tsMenuItem
            // 
            this.tsMenuItem.Command = this.cmdSetDefault;
            this.tsMenuItem.Name = "tsMenuItem";
            resources.ApplyResources(this.tsMenuItem, "tsMenuItem");
            this.tsMenuItem.Text = "Set Default";
            // 
            // colsCustomerInfo_GetName
            // 
            this.colsCustomerInfo_GetName.MaxLength = 2000;
            this.colsCustomerInfo_GetName.Name = "colsCustomerInfo_GetName";
            this.colsCustomerInfo_GetName.NamedProperties.Put("EnumerateMethod", "");
            this.colsCustomerInfo_GetName.NamedProperties.Put("FieldFlags", "304");
            this.colsCustomerInfo_GetName.NamedProperties.Put("LovReference", "");
            this.colsCustomerInfo_GetName.NamedProperties.Put("ParentName", "colsCustomerId");
            this.colsCustomerInfo_GetName.NamedProperties.Put("SqlColumn", "CUSTOMER_INFO_API.Get_Name(CUSTOMER_ID)");
            this.colsCustomerInfo_GetName.Position = 6;
            resources.ApplyResources(this.colsCustomerInfo_GetName, "colsCustomerInfo_GetName");
            // 
            // tbwB2BCustomerUser
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colsUserId);
            this.Controls.Add(this.colsFndUser_GetDescription);
            this.Controls.Add(this.colsCustomerId);
            this.Controls.Add(this.colsCustomerInfo_GetName);
            this.Controls.Add(this.colsDefaultCustomer);
            this.Name = "tbwB2BCustomerUser";
            this.NamedProperties.Put("DefaultOrderBy", "CUSTOMER_ID, USER_ID");
            this.NamedProperties.Put("DefaultWhere", "");
            this.NamedProperties.Put("LogicalUnit", "B2bCustomerUser");
            this.NamedProperties.Put("Module", "ENTERP");
            this.NamedProperties.Put("PackageName", "B2B_CUSTOMER_USER_API");
            this.NamedProperties.Put("ViewName", "B2B_CUSTOMER_USER");
            this.Controls.SetChildIndex(this.colsDefaultCustomer, 0);
            this.Controls.SetChildIndex(this.colsCustomerInfo_GetName, 0);
            this.Controls.SetChildIndex(this.colsCustomerId, 0);
            this.Controls.SetChildIndex(this.colsFndUser_GetDescription, 0);
            this.Controls.SetChildIndex(this.colsUserId, 0);
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

        protected cColumn colsCustomerId;
        protected cColumn colsUserId;
        protected cColumn colsFndUser_GetDescription;
        protected cCheckBoxColumn colsDefaultCustomer;
        protected Fnd.Windows.Forms.FndCommand cmdSetDefault;
        protected Fnd.Windows.Forms.FndContextMenuStrip menuTbwMethods;
        protected Fnd.Windows.Forms.FndToolStripMenuItem tsMenuItem;
        protected cColumn colsCustomerInfo_GetName;
    }
}
