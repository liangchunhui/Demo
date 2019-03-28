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

    public partial class dlgCopyToCompanies
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgCopyToCompanies));
            this.cCommandButtonOK = new Ifs.Fnd.ApplicationForms.cCommandButton();
            this.commandOk = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.cCommandButtonCancel = new Ifs.Fnd.ApplicationForms.cCommandButton();
            this.commandCancel = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.tblSelectCompany = new Ifs.Fnd.ApplicationForms.cChildTable();
            this.tblSelectCompany_colsSourceCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblSelectCompany_colsCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblSelectCompany_colsName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblSelectCompany_colsCountry = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblSelectCompany_colInclude = new Ifs.Fnd.ApplicationForms.cCheckBoxColumn();
            this.tblSelectCompany_colUpdateExist = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.lblManual = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.lblAuto = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.commandSchedule = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.cbSelect = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.cbReplace = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.cbRunInBackground = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.ClientArea.SuspendLayout();
            this.tblSelectCompany.SuspendLayout();
            this.SuspendLayout();
            // 
            // ClientArea
            // 
            this.ClientArea.BackColor = System.Drawing.Color.Transparent;
            this.ClientArea.Controls.Add(this.cbRunInBackground);
            this.ClientArea.Controls.Add(this.cbReplace);
            this.ClientArea.Controls.Add(this.cbSelect);
            this.ClientArea.Controls.Add(this.lblAuto);
            this.ClientArea.Controls.Add(this.lblManual);
            this.ClientArea.Controls.Add(this.tblSelectCompany);
            this.ClientArea.Controls.Add(this.cCommandButtonOK);
            this.ClientArea.Controls.Add(this.cCommandButtonCancel);
            resources.ApplyResources(this.ClientArea, "ClientArea");
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.commandOk);
            this.commandManager.Commands.Add(this.commandCancel);
            this.commandManager.Commands.Add(this.commandSchedule);
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
            // 
            // tblSelectCompany
            // 
            resources.ApplyResources(this.tblSelectCompany, "tblSelectCompany");
            this.tblSelectCompany.Controls.Add(this.tblSelectCompany_colsSourceCompany);
            this.tblSelectCompany.Controls.Add(this.tblSelectCompany_colsCompany);
            this.tblSelectCompany.Controls.Add(this.tblSelectCompany_colsName);
            this.tblSelectCompany.Controls.Add(this.tblSelectCompany_colsCountry);
            this.tblSelectCompany.Controls.Add(this.tblSelectCompany_colInclude);
            this.tblSelectCompany.Controls.Add(this.tblSelectCompany_colUpdateExist);
            this.tblSelectCompany.Name = "tblSelectCompany";
            this.tblSelectCompany.NamedProperties.Put("DefaultWhere", @"(SOURCE_COMPANY =  :i_hWndFrame.dlgCopyToCompanies.sCompany OR  
                         (SOURCE_COMPANY IS NULL AND TARGET_COMPANY NOT IN (SELECT TARGET_COMPANY FROM &AO.TARGET_COMPANY WHERE SOURCE_COMPANY = :i_hWndFrame.dlgCopyToCompanies.sCompany)) )AND EXISTS (SELECT 1 FROM  &AO.user_finance_auth_pub WHERE  company = &AO.TARGET_COMPANY_UNION.target_company ) AND (TARGET_COMPANY != :i_hWndFrame.dlgCopyToCompanies.sCompany)");
            this.tblSelectCompany.NamedProperties.Put("LogicalUnit", "TargetCompany");
            this.tblSelectCompany.NamedProperties.Put("Module", "ENTERP");
            this.tblSelectCompany.NamedProperties.Put("PackageName", "");
            this.tblSelectCompany.NamedProperties.Put("SourceFlags", "129");
            this.tblSelectCompany.NamedProperties.Put("ViewName", "TARGET_COMPANY_UNION");
            this.tblSelectCompany.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblSelectCompany_WindowActions);
            this.tblSelectCompany.Controls.SetChildIndex(this.tblSelectCompany_colUpdateExist, 0);
            this.tblSelectCompany.Controls.SetChildIndex(this.tblSelectCompany_colInclude, 0);
            this.tblSelectCompany.Controls.SetChildIndex(this.tblSelectCompany_colsCountry, 0);
            this.tblSelectCompany.Controls.SetChildIndex(this.tblSelectCompany_colsName, 0);
            this.tblSelectCompany.Controls.SetChildIndex(this.tblSelectCompany_colsCompany, 0);
            this.tblSelectCompany.Controls.SetChildIndex(this.tblSelectCompany_colsSourceCompany, 0);
            // 
            // tblSelectCompany_colsSourceCompany
            // 
            this.tblSelectCompany_colsSourceCompany.MaxLength = 20;
            this.tblSelectCompany_colsSourceCompany.Name = "tblSelectCompany_colsSourceCompany";
            this.tblSelectCompany_colsSourceCompany.NamedProperties.Put("EnumerateMethod", "");
            this.tblSelectCompany_colsSourceCompany.NamedProperties.Put("FieldFlags", "66");
            this.tblSelectCompany_colsSourceCompany.NamedProperties.Put("LovReference", "SOURCE_COMPANY");
            this.tblSelectCompany_colsSourceCompany.NamedProperties.Put("SqlColumn", "SOURCE_COMPANY");
            this.tblSelectCompany_colsSourceCompany.Position = 3;
            resources.ApplyResources(this.tblSelectCompany_colsSourceCompany, "tblSelectCompany_colsSourceCompany");
            // 
            // tblSelectCompany_colsCompany
            // 
            this.tblSelectCompany_colsCompany.MaxLength = 20;
            this.tblSelectCompany_colsCompany.Name = "tblSelectCompany_colsCompany";
            this.tblSelectCompany_colsCompany.NamedProperties.Put("EnumerateMethod", "");
            this.tblSelectCompany_colsCompany.NamedProperties.Put("FieldFlags", "163");
            this.tblSelectCompany_colsCompany.NamedProperties.Put("LovReference", "COMPANY_PUBLIC");
            this.tblSelectCompany_colsCompany.NamedProperties.Put("LovTimeReference", "");
            this.tblSelectCompany_colsCompany.NamedProperties.Put("SqlColumn", "TARGET_COMPANY");
            this.tblSelectCompany_colsCompany.Position = 4;
            resources.ApplyResources(this.tblSelectCompany_colsCompany, "tblSelectCompany_colsCompany");
            // 
            // tblSelectCompany_colsName
            // 
            this.tblSelectCompany_colsName.MaxLength = 2000;
            this.tblSelectCompany_colsName.Name = "tblSelectCompany_colsName";
            this.tblSelectCompany_colsName.NamedProperties.Put("EnumerateMethod", "");
            this.tblSelectCompany_colsName.NamedProperties.Put("FieldFlags", "288");
            this.tblSelectCompany_colsName.NamedProperties.Put("LovReference", "");
            this.tblSelectCompany_colsName.NamedProperties.Put("LovTimeReference", "");
            this.tblSelectCompany_colsName.NamedProperties.Put("SqlColumn", "Company_API.Get_Name(TARGET_COMPANY)");
            this.tblSelectCompany_colsName.Position = 5;
            resources.ApplyResources(this.tblSelectCompany_colsName, "tblSelectCompany_colsName");
            // 
            // tblSelectCompany_colsCountry
            // 
            this.tblSelectCompany_colsCountry.MaxLength = 2000;
            this.tblSelectCompany_colsCountry.Name = "tblSelectCompany_colsCountry";
            this.tblSelectCompany_colsCountry.NamedProperties.Put("EnumerateMethod", "");
            this.tblSelectCompany_colsCountry.NamedProperties.Put("FieldFlags", "288");
            this.tblSelectCompany_colsCountry.NamedProperties.Put("LovReference", "");
            this.tblSelectCompany_colsCountry.NamedProperties.Put("LovTimeReference", "");
            this.tblSelectCompany_colsCountry.NamedProperties.Put("SqlColumn", "Company_API.Get_Country(TARGET_COMPANY)");
            this.tblSelectCompany_colsCountry.Position = 6;
            resources.ApplyResources(this.tblSelectCompany_colsCountry, "tblSelectCompany_colsCountry");
            // 
            // tblSelectCompany_colInclude
            // 
            this.tblSelectCompany_colInclude.MaxLength = 2000;
            this.tblSelectCompany_colInclude.Name = "tblSelectCompany_colInclude";
            this.tblSelectCompany_colInclude.NamedProperties.Put("EnumerateMethod", "");
            this.tblSelectCompany_colInclude.NamedProperties.Put("FieldFlags", "294");
            this.tblSelectCompany_colInclude.NamedProperties.Put("LovReference", "");
            this.tblSelectCompany_colInclude.NamedProperties.Put("LovTimeReference", "");
            this.tblSelectCompany_colInclude.NamedProperties.Put("SqlColumn", "Company_Basic_Data_Window_API.Get_Include(SOURCE_COMPANY,TARGET_COMPANY,:i_hWndFr" +
        "ame.dlgCopyToCompanies.sLu)");
            this.tblSelectCompany_colInclude.Position = 7;
            resources.ApplyResources(this.tblSelectCompany_colInclude, "tblSelectCompany_colInclude");
            this.tblSelectCompany_colInclude.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblSelectCompany_colInclude_WindowActions);
            // 
            // tblSelectCompany_colUpdateExist
            // 
            this.tblSelectCompany_colUpdateExist.EnumerationFilter = new string[] {
        ""};
            this.tblSelectCompany_colUpdateExist.MaxLength = 2000;
            this.tblSelectCompany_colUpdateExist.Name = "tblSelectCompany_colUpdateExist";
            this.tblSelectCompany_colUpdateExist.NamedProperties.Put("EnumerateMethod", "Sync_Update_Method_Type_API.Enumerate");
            this.tblSelectCompany_colUpdateExist.NamedProperties.Put("FieldFlags", "295");
            this.tblSelectCompany_colUpdateExist.NamedProperties.Put("LovReference", "");
            this.tblSelectCompany_colUpdateExist.NamedProperties.Put("LovTimeReference", "");
            this.tblSelectCompany_colUpdateExist.NamedProperties.Put("SqlColumn", "Company_Basic_Data_Window_API.Get_Update_Method_Type(SOURCE_COMPANY,TARGET_COMPAN" +
        "Y,:i_hWndFrame.dlgCopyToCompanies.sLu)");
            this.tblSelectCompany_colUpdateExist.Position = 8;
            resources.ApplyResources(this.tblSelectCompany_colUpdateExist, "tblSelectCompany_colUpdateExist");
            this.tblSelectCompany_colUpdateExist.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblSelectCompany_colUpdateExist_WindowActions);
            // 
            // lblManual
            // 
            resources.ApplyResources(this.lblManual, "lblManual");
            this.lblManual.Name = "lblManual";
            // 
            // lblAuto
            // 
            resources.ApplyResources(this.lblAuto, "lblAuto");
            this.lblAuto.Name = "lblAuto";
            // 
            // commandSchedule
            // 
            resources.ApplyResources(this.commandSchedule, "commandSchedule");
            this.commandSchedule.Name = "commandSchedule";
            // 
            // cbSelect
            // 
            resources.ApplyResources(this.cbSelect, "cbSelect");
            this.cbSelect.CheckedValue = "TRUE";
            this.cbSelect.Name = "cbSelect";
            this.cbSelect.NamedProperties.Put("FieldFlags", "260");
            this.cbSelect.UncheckedValue = "FALSE";
            this.cbSelect.CheckedChanged += new System.EventHandler(this.cbSelect_CheckedChanged);
            // 
            // cbReplace
            // 
            resources.ApplyResources(this.cbReplace, "cbReplace");
            this.cbReplace.CheckedValue = "TRUE";
            this.cbReplace.Name = "cbReplace";
            this.cbReplace.UncheckedValue = "FALSE";
            this.cbReplace.CheckedChanged += new System.EventHandler(this.cbReplace_CheckedChanged);
            // 
            // cbRunInBackground
            // 
            resources.ApplyResources(this.cbRunInBackground, "cbRunInBackground");
            this.cbRunInBackground.CheckedValue = "TRUE";
            this.cbRunInBackground.Name = "cbRunInBackground";
            this.cbRunInBackground.NamedProperties.Put("FieldFlags", "260");
            this.cbRunInBackground.UncheckedValue = "FALSE";
            // 
            // dlgCopyToCompanies
            // 
            this.AcceptButton = this.cCommandButtonOK;
            this.CancelButton = this.cCommandButtonCancel;
            resources.ApplyResources(this, "$this");
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "dlgCopyToCompanies";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.ClientArea.ResumeLayout(false);
            this.ClientArea.PerformLayout();
            this.tblSelectCompany.ResumeLayout(false);
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

        protected cCommandButton cCommandButtonOK;
        protected cCommandButton cCommandButtonCancel;
        protected Ifs.Fnd.Windows.Forms.FndCommand commandOk;
        protected Ifs.Fnd.Windows.Forms.FndCommand commandCancel;
        protected cChildTable tblSelectCompany;
        protected cColumn tblSelectCompany_colsCompany;
        protected cColumn tblSelectCompany_colsName;
        protected cColumn tblSelectCompany_colsCountry;
        protected cColumn tblSelectCompany_colsSourceCompany;
        protected cCheckBoxColumn tblSelectCompany_colInclude;
        protected cLookupColumn tblSelectCompany_colUpdateExist;
        protected cBackgroundText lblManual;
        protected cBackgroundText lblAuto;
        protected Fnd.Windows.Forms.FndCommand commandSchedule;
        protected cCheckBox cbSelect;
        protected cCheckBox cbReplace;
        protected cCheckBox cbRunInBackground;

    }
}
