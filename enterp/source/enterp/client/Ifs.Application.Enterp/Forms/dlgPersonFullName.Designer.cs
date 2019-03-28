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

    public partial class dlgPersonFullName
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgPersonFullName));
            this.cCommandButtonOK = new Ifs.Fnd.ApplicationForms.cCommandButton();
            this.commandOk = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.cCommandButtonCancel = new Ifs.Fnd.ApplicationForms.cCommandButton();
            this.commandCancel = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.dfsTitle = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsTitle = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsInitials = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelInitials = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsLastName = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelLastName = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsMiddleName = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelMiddleName = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsFirstName = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelFirstName = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsPersonId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.commandOk);
            this.commandManager.Commands.Add(this.commandCancel);
            this.commandManager.Components.Add(this.cCommandButtonOK);
            this.commandManager.Components.Add(this.cCommandButtonCancel);
            // 
            // cCommandButtonOK
            // 
            resources.ApplyResources(this.cCommandButtonOK, "cCommandButtonOK");
            this.cCommandButtonOK.Command = this.commandOk;
            this.cCommandButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cCommandButtonOK.Name = "cCommandButtonOK";
            this.cCommandButtonOK.NamedProperties.Put("MethodIdStr", "");
            this.cCommandButtonOK.NamedProperties.Put("MethodParameterType", "String");
            // 
            // commandOk
            // 
            resources.ApplyResources(this.commandOk, "commandOk");
            this.commandOk.Name = "commandOk";
            this.commandOk.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.commandOk_Execute);
            // 
            // cCommandButtonCancel
            // 
            resources.ApplyResources(this.cCommandButtonCancel, "cCommandButtonCancel");
            this.cCommandButtonCancel.Command = this.commandCancel;
            this.cCommandButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cCommandButtonCancel.Name = "cCommandButtonCancel";
            this.cCommandButtonCancel.NamedProperties.Put("MethodIdStr", "");
            this.cCommandButtonCancel.NamedProperties.Put("MethodParameterType", "String");
            // 
            // commandCancel
            // 
            resources.ApplyResources(this.commandCancel, "commandCancel");
            this.commandCancel.Name = "commandCancel";
            this.commandCancel.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.commandCancel_Execute);
            // 
            // dfsTitle
            // 
            resources.ApplyResources(this.dfsTitle, "dfsTitle");
            this.dfsTitle.Name = "dfsTitle";
            this.dfsTitle.NamedProperties.Put("EnumerateMethod", "");
            this.dfsTitle.NamedProperties.Put("FieldFlags", "294");
            this.dfsTitle.NamedProperties.Put("LovReference", "");
            this.dfsTitle.NamedProperties.Put("SqlColumn", "TITLE");
            // 
            // labeldfsTitle
            // 
            resources.ApplyResources(this.labeldfsTitle, "labeldfsTitle");
            this.labeldfsTitle.Name = "labeldfsTitle";
            // 
            // dfsInitials
            // 
            resources.ApplyResources(this.dfsInitials, "dfsInitials");
            this.dfsInitials.Name = "dfsInitials";
            this.dfsInitials.NamedProperties.Put("EnumerateMethod", "");
            this.dfsInitials.NamedProperties.Put("FieldFlags", "294");
            this.dfsInitials.NamedProperties.Put("LovReference", "");
            this.dfsInitials.NamedProperties.Put("SqlColumn", "INITIALS");
            // 
            // labelInitials
            // 
            resources.ApplyResources(this.labelInitials, "labelInitials");
            this.labelInitials.Name = "labelInitials";
            // 
            // dfsLastName
            // 
            resources.ApplyResources(this.dfsLastName, "dfsLastName");
            this.dfsLastName.Name = "dfsLastName";
            this.dfsLastName.NamedProperties.Put("EnumerateMethod", "");
            this.dfsLastName.NamedProperties.Put("FieldFlags", "294");
            this.dfsLastName.NamedProperties.Put("LovReference", "");
            this.dfsLastName.NamedProperties.Put("SqlColumn", "LAST_NAME");
            // 
            // labelLastName
            // 
            resources.ApplyResources(this.labelLastName, "labelLastName");
            this.labelLastName.Name = "labelLastName";
            // 
            // dfsMiddleName
            // 
            resources.ApplyResources(this.dfsMiddleName, "dfsMiddleName");
            this.dfsMiddleName.Name = "dfsMiddleName";
            this.dfsMiddleName.NamedProperties.Put("EnumerateMethod", "");
            this.dfsMiddleName.NamedProperties.Put("FieldFlags", "294");
            this.dfsMiddleName.NamedProperties.Put("LovReference", "");
            this.dfsMiddleName.NamedProperties.Put("SqlColumn", "MIDDLE_NAME");
            // 
            // labelMiddleName
            // 
            resources.ApplyResources(this.labelMiddleName, "labelMiddleName");
            this.labelMiddleName.Name = "labelMiddleName";
            // 
            // dfsFirstName
            // 
            resources.ApplyResources(this.dfsFirstName, "dfsFirstName");
            this.dfsFirstName.Name = "dfsFirstName";
            this.dfsFirstName.NamedProperties.Put("EnumerateMethod", "");
            this.dfsFirstName.NamedProperties.Put("FieldFlags", "294");
            this.dfsFirstName.NamedProperties.Put("LovReference", "");
            this.dfsFirstName.NamedProperties.Put("SqlColumn", "FIRST_NAME");
            // 
            // labelFirstName
            // 
            resources.ApplyResources(this.labelFirstName, "labelFirstName");
            this.labelFirstName.Name = "labelFirstName";
            // 
            // dfsPersonId
            // 
            resources.ApplyResources(this.dfsPersonId, "dfsPersonId");
            this.dfsPersonId.Name = "dfsPersonId";
            // 
            // dlgPersonFullName
            // 
            this.AcceptButton = this.cCommandButtonOK;
            this.CancelButton = this.cCommandButtonCancel;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.dfsPersonId);
            this.Controls.Add(this.dfsLastName);
            this.Controls.Add(this.labelLastName);
            this.Controls.Add(this.dfsMiddleName);
            this.Controls.Add(this.labelMiddleName);
            this.Controls.Add(this.dfsFirstName);
            this.Controls.Add(this.labelFirstName);
            this.Controls.Add(this.dfsInitials);
            this.Controls.Add(this.labelInitials);
            this.Controls.Add(this.dfsTitle);
            this.Controls.Add(this.labeldfsTitle);
            this.Controls.Add(this.cCommandButtonOK);
            this.Controls.Add(this.cCommandButtonCancel);
            this.Name = "dlgPersonFullName";
            this.ShowIcon = false;
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

        protected cCommandButton cCommandButtonOK;
        protected cCommandButton cCommandButtonCancel;
        protected Ifs.Fnd.Windows.Forms.FndCommand commandOk;
        protected Ifs.Fnd.Windows.Forms.FndCommand commandCancel;
        public cDataField dfsTitle;
        protected cBackgroundText labeldfsTitle;
        protected cDataField dfsInitials;
        protected cBackgroundText labelInitials;
        protected cDataField dfsLastName;
        protected cBackgroundText labelLastName;
        protected cDataField dfsMiddleName;
        protected cBackgroundText labelMiddleName;
        protected cDataField dfsFirstName;
        protected cBackgroundText labelFirstName;
        protected cDataField dfsPersonId;

    }
}
