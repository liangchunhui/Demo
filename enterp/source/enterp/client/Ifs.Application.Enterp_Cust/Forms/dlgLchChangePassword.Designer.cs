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

    public partial class dlgLchChangePassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgLchChangePassword));
            this.sNewPassword = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelLoginPassword = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cBackgroundText1 = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.sID = new Ifs.Fnd.ApplicationForms.cDataField();
            this.pbCancel = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.pbOk = new Ifs.Fnd.ApplicationForms.cPushButton();
            this.sOldPasswordInput = new Ifs.Fnd.ApplicationForms.cDataField();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Components.Add(this.pbCancel);
            this.commandManager.Components.Add(this.pbOk);
            this.commandManager.ImageList = null;
            // 
            // sNewPassword
            // 
            resources.ApplyResources(this.sNewPassword, "sNewPassword");
            this.sNewPassword.Name = "sNewPassword";
            this.sNewPassword.NamedProperties.Put("EnumerateMethod", "");
            this.sNewPassword.NamedProperties.Put("FieldFlags", "295");
            this.sNewPassword.NamedProperties.Put("LovReference", "");
            this.sNewPassword.NamedProperties.Put("SqlColumn", "LOGIN_PASSWORD");
            // 
            // labelLoginPassword
            // 
            resources.ApplyResources(this.labelLoginPassword, "labelLoginPassword");
            this.labelLoginPassword.Name = "labelLoginPassword";
            // 
            // cBackgroundText1
            // 
            resources.ApplyResources(this.cBackgroundText1, "cBackgroundText1");
            this.cBackgroundText1.Name = "cBackgroundText1";
            // 
            // sID
            // 
            resources.ApplyResources(this.sID, "sID");
            this.sID.Name = "sID";
            this.sID.NamedProperties.Put("EnumerateMethod", "");
            this.sID.NamedProperties.Put("FieldFlags", "163");
            this.sID.NamedProperties.Put("LovReference", "");
            this.sID.NamedProperties.Put("LovTimeReference", "");
            this.sID.NamedProperties.Put("SqlColumn", "EMPLOYEE_ID");
            // 
            // pbCancel
            // 
            this.pbCancel.AcceleratorKey = System.Windows.Forms.Keys.Escape;
            resources.ApplyResources(this.pbCancel, "pbCancel");
            this.pbCancel.Name = "pbCancel";
            this.pbCancel.NamedProperties.Put("MethodId", "18385");
            this.pbCancel.NamedProperties.Put("MethodParameter", "cancel");
            this.pbCancel.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // pbOk
            // 
            this.pbOk.AcceleratorKey = System.Windows.Forms.Keys.Return;
            resources.ApplyResources(this.pbOk, "pbOk");
            this.pbOk.Name = "pbOk";
            this.pbOk.NamedProperties.Put("MethodId", "18385");
            this.pbOk.NamedProperties.Put("MethodParameter", "ok");
            this.pbOk.NamedProperties.Put("ResizeableChildObject", "");
            // 
            // sOldPasswordInput
            // 
            resources.ApplyResources(this.sOldPasswordInput, "sOldPasswordInput");
            this.sOldPasswordInput.Name = "sOldPasswordInput";
            this.sOldPasswordInput.NamedProperties.Put("FieldFlags", "263");
            // 
            // dlgLchChangePassword
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.sOldPasswordInput);
            this.Controls.Add(this.pbCancel);
            this.Controls.Add(this.pbOk);
            this.Controls.Add(this.sID);
            this.Controls.Add(this.cBackgroundText1);
            this.Controls.Add(this.sNewPassword);
            this.Controls.Add(this.labelLoginPassword);
            this.DataBound = false;
            this.HelpButton = false;
            this.Name = "dlgLchChangePassword";
            this.NamedProperties.Put("LogicalUnit", "LchEmployee");
            this.NamedProperties.Put("PackageName", "Lch_Employee_API");
            this.NamedProperties.Put("ViewName", "LCH_EMPLOYEE");
            this.NamedProperties.Put("Warnings", "TRUE");
            this.ResumeLayout(false);
            this.PerformLayout();

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

        protected cBackgroundText labelLoginPassword;
        protected cBackgroundText cBackgroundText1;
        private cDataField sID;
        public cPushButton pbCancel;
        public cPushButton pbOk;
        public cDataField sNewPassword;
        private cDataField sOldPasswordInput;

    }
}
