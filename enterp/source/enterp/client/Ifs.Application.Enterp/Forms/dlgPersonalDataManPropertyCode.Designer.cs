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

    public partial class dlgPersonalDataManPropertyCode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgPersonalDataManPropertyCode));
            this.cCommandButtonOK = new Ifs.Fnd.ApplicationForms.cCommandButton();
            this.commandOk = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.cCommandButtonCancel = new Ifs.Fnd.ApplicationForms.cCommandButton();
            this.commandCancel = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.dfsPropertyCode = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelPropertyCode = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsDefaultDescription = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelDefaultDescription = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.commandList = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.cCommandButtonList = new Ifs.Fnd.ApplicationForms.cCommandButton();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.commandOk);
            this.commandManager.Commands.Add(this.commandCancel);
            this.commandManager.Commands.Add(this.commandList);
            this.commandManager.Components.Add(this.cCommandButtonOK);
            this.commandManager.Components.Add(this.cCommandButtonCancel);
            this.commandManager.Components.Add(this.cCommandButtonList);
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
            this.commandOk.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.commandOk_Inquire);
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
            // dfsPropertyCode
            // 
            this.dfsPropertyCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsPropertyCode, "dfsPropertyCode");
            this.dfsPropertyCode.Name = "dfsPropertyCode";
            this.dfsPropertyCode.NamedProperties.Put("EnumerateMethod", "");
            this.dfsPropertyCode.NamedProperties.Put("FieldFlags", "259");
            this.dfsPropertyCode.NamedProperties.Put("LovReference", "PROPERTY_RULE_PERSONAL");
            this.dfsPropertyCode.NamedProperties.Put("SqlColumn", "PROPERTY_CODE");
            this.dfsPropertyCode.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsPropertyCode_WindowActions);
            // 
            // labelPropertyCode
            // 
            resources.ApplyResources(this.labelPropertyCode, "labelPropertyCode");
            this.labelPropertyCode.Name = "labelPropertyCode";
            // 
            // dfsDefaultDescription
            // 
            resources.ApplyResources(this.dfsDefaultDescription, "dfsDefaultDescription");
            this.dfsDefaultDescription.Name = "dfsDefaultDescription";
            this.dfsDefaultDescription.NamedProperties.Put("EnumerateMethod", "");
            this.dfsDefaultDescription.NamedProperties.Put("LovReference", "");
            this.dfsDefaultDescription.NamedProperties.Put("SqlColumn", "DEFAULT_DESCRIPTION");
            // 
            // labelDefaultDescription
            // 
            resources.ApplyResources(this.labelDefaultDescription, "labelDefaultDescription");
            this.labelDefaultDescription.Name = "labelDefaultDescription";
            // 
            // commandList
            // 
            resources.ApplyResources(this.commandList, "commandList");
            this.commandList.Name = "commandList";
            this.commandList.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.commandList_Execute);
            this.commandList.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.commandList_Inquire);
            // 
            // cCommandButtonList
            // 
            this.cCommandButtonList.AcceleratorKey = System.Windows.Forms.Keys.F8;
            resources.ApplyResources(this.cCommandButtonList, "cCommandButtonList");
            this.cCommandButtonList.Command = this.commandList;
            this.cCommandButtonList.Name = "cCommandButtonList";
            // 
            // dlgPersonalDataManPropertyCode
            // 
            this.AcceptButton = this.cCommandButtonOK;
            this.CancelButton = this.cCommandButtonCancel;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.cCommandButtonList);
            this.Controls.Add(this.dfsDefaultDescription);
            this.Controls.Add(this.labelDefaultDescription);
            this.Controls.Add(this.dfsPropertyCode);
            this.Controls.Add(this.labelPropertyCode);
            this.Controls.Add(this.cCommandButtonOK);
            this.Controls.Add(this.cCommandButtonCancel);
            this.DataBound = false;
            this.Name = "dlgPersonalDataManPropertyCode";
            this.NamedProperties.Put("LogicalUnit", "");
            this.NamedProperties.Put("Module", "ENTERP");
            this.NamedProperties.Put("PackageName", "");
            this.NamedProperties.Put("ViewName", "");
            this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dlgPersonalDataManPropertyCode_WindowActions);
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
        protected cDataField dfsPropertyCode;
        protected cBackgroundText labelPropertyCode;
        protected cDataField dfsDefaultDescription;
        protected cBackgroundText labelDefaultDescription;
        protected Fnd.Windows.Forms.FndCommand commandList;
        protected cCommandButton cCommandButtonList;

    }
}
