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

    public partial class dlgFindPerson
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgFindPerson));
            this.cCommandButtonOK = new Ifs.Fnd.ApplicationForms.cCommandButton();
            this.commandOk = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.cCommandButtonCancel = new Ifs.Fnd.ApplicationForms.cCommandButton();
            this.commandCancel = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.cCommandButtonFind = new Ifs.Fnd.ApplicationForms.cCommandButton();
            this.commandFind = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.labeldfdsFirstName = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsFirstName = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfdsLastName = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsLastName = new Ifs.Fnd.ApplicationForms.cDataField();
            this.tblFindPerson = new Ifs.Application.Enterp.cChildTableEntBase();
            this.tblFindPerson_colsPersonId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblFindPerson_colsName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblFindPerson_colsTitle = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblFindPerson_colsCountry = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.tblFindPerson_colsUserId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblFindPerson_colsContactCustomers = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblFindPerson_colsContactSuppliers = new Ifs.Fnd.ApplicationForms.cColumn();
            this.tblFindPerson.SuspendLayout();
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.commandOk);
            this.commandManager.Commands.Add(this.commandCancel);
            this.commandManager.Commands.Add(this.commandFind);
            this.commandManager.Components.Add(this.cCommandButtonOK);
            this.commandManager.Components.Add(this.cCommandButtonCancel);
            this.commandManager.Components.Add(this.cCommandButtonFind);
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
            // cCommandButtonFind
            // 
            this.cCommandButtonFind.Command = this.commandFind;
            resources.ApplyResources(this.cCommandButtonFind, "cCommandButtonFind");
            this.cCommandButtonFind.Name = "cCommandButtonFind";
            // 
            // commandFind
            // 
            resources.ApplyResources(this.commandFind, "commandFind");
            this.commandFind.Name = "commandFind";
            this.commandFind.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.commandFind_Execute);
            // 
            // labeldfdsFirstName
            // 
            resources.ApplyResources(this.labeldfdsFirstName, "labeldfdsFirstName");
            this.labeldfdsFirstName.Name = "labeldfdsFirstName";
            // 
            // dfsFirstName
            // 
            resources.ApplyResources(this.dfsFirstName, "dfsFirstName");
            this.dfsFirstName.Name = "dfsFirstName";
            this.dfsFirstName.NamedProperties.Put("FieldFlags", "262");
            // 
            // labeldfdsLastName
            // 
            resources.ApplyResources(this.labeldfdsLastName, "labeldfdsLastName");
            this.labeldfdsLastName.Name = "labeldfdsLastName";
            // 
            // dfsLastName
            // 
            resources.ApplyResources(this.dfsLastName, "dfsLastName");
            this.dfsLastName.Name = "dfsLastName";
            this.dfsLastName.NamedProperties.Put("FieldFlags", "262");
            // 
            // tblFindPerson
            // 
            resources.ApplyResources(this.tblFindPerson, "tblFindPerson");
            this.tblFindPerson.Controls.Add(this.tblFindPerson_colsPersonId);
            this.tblFindPerson.Controls.Add(this.tblFindPerson_colsName);
            this.tblFindPerson.Controls.Add(this.tblFindPerson_colsTitle);
            this.tblFindPerson.Controls.Add(this.tblFindPerson_colsCountry);
            this.tblFindPerson.Controls.Add(this.tblFindPerson_colsUserId);
            this.tblFindPerson.Controls.Add(this.tblFindPerson_colsContactCustomers);
            this.tblFindPerson.Controls.Add(this.tblFindPerson_colsContactSuppliers);
            this.tblFindPerson.Name = "tblFindPerson";
            this.tblFindPerson.NamedProperties.Put("DefaultOrderBy", "NAME");
            this.tblFindPerson.NamedProperties.Put("DefaultWhere", "");
            this.tblFindPerson.NamedProperties.Put("LogicalUnit", "PersonInfo");
            this.tblFindPerson.NamedProperties.Put("PackageName", "PERSON_INFO_API");
            this.tblFindPerson.NamedProperties.Put("ResizeableChildObject", "LLRR");
            this.tblFindPerson.NamedProperties.Put("SourceFlags", "0");
            this.tblFindPerson.NamedProperties.Put("ViewName", "PERSON_INFO_ALL");
            this.tblFindPerson.NamedProperties.Put("Warnings", "FALSE");
            this.tblFindPerson.ReadOnly = true;
            this.tblFindPerson.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.tblFindPerson_WindowActions);
            this.tblFindPerson.Controls.SetChildIndex(this.tblFindPerson_colsContactSuppliers, 0);
            this.tblFindPerson.Controls.SetChildIndex(this.tblFindPerson_colsContactCustomers, 0);
            this.tblFindPerson.Controls.SetChildIndex(this.tblFindPerson_colsUserId, 0);
            this.tblFindPerson.Controls.SetChildIndex(this.tblFindPerson_colsCountry, 0);
            this.tblFindPerson.Controls.SetChildIndex(this.tblFindPerson_colsTitle, 0);
            this.tblFindPerson.Controls.SetChildIndex(this.tblFindPerson_colsName, 0);
            this.tblFindPerson.Controls.SetChildIndex(this.tblFindPerson_colsPersonId, 0);
            // 
            // tblFindPerson_colsPersonId
            // 
            this.tblFindPerson_colsPersonId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblFindPerson_colsPersonId.MaxLength = 20;
            this.tblFindPerson_colsPersonId.Name = "tblFindPerson_colsPersonId";
            this.tblFindPerson_colsPersonId.NamedProperties.Put("EnumerateMethod", "");
            this.tblFindPerson_colsPersonId.NamedProperties.Put("FieldFlags", "163");
            this.tblFindPerson_colsPersonId.NamedProperties.Put("LovReference", "");
            this.tblFindPerson_colsPersonId.NamedProperties.Put("SqlColumn", "PERSON_ID");
            this.tblFindPerson_colsPersonId.Position = 3;
            resources.ApplyResources(this.tblFindPerson_colsPersonId, "tblFindPerson_colsPersonId");
            // 
            // tblFindPerson_colsName
            // 
            this.tblFindPerson_colsName.Name = "tblFindPerson_colsName";
            this.tblFindPerson_colsName.NamedProperties.Put("EnumerateMethod", "");
            this.tblFindPerson_colsName.NamedProperties.Put("FieldFlags", "295");
            this.tblFindPerson_colsName.NamedProperties.Put("LovReference", "");
            this.tblFindPerson_colsName.NamedProperties.Put("SqlColumn", "NAME");
            this.tblFindPerson_colsName.Position = 4;
            resources.ApplyResources(this.tblFindPerson_colsName, "tblFindPerson_colsName");
            // 
            // tblFindPerson_colsTitle
            // 
            this.tblFindPerson_colsTitle.Name = "tblFindPerson_colsTitle";
            this.tblFindPerson_colsTitle.NamedProperties.Put("EnumerateMethod", "");
            this.tblFindPerson_colsTitle.NamedProperties.Put("FieldFlags", "294");
            this.tblFindPerson_colsTitle.NamedProperties.Put("LovReference", "");
            this.tblFindPerson_colsTitle.NamedProperties.Put("SqlColumn", "TITLE");
            this.tblFindPerson_colsTitle.Position = 5;
            resources.ApplyResources(this.tblFindPerson_colsTitle, "tblFindPerson_colsTitle");
            // 
            // tblFindPerson_colsCountry
            // 
            this.tblFindPerson_colsCountry.MaxLength = 200;
            this.tblFindPerson_colsCountry.Name = "tblFindPerson_colsCountry";
            this.tblFindPerson_colsCountry.NamedProperties.Put("EnumerateMethod", "ISO_COUNTRY_API.Enumerate");
            this.tblFindPerson_colsCountry.NamedProperties.Put("FieldFlags", "294");
            this.tblFindPerson_colsCountry.NamedProperties.Put("LovReference", "ISO_COUNTRY");
            this.tblFindPerson_colsCountry.NamedProperties.Put("SqlColumn", "COUNTRY");
            this.tblFindPerson_colsCountry.Position = 6;
            resources.ApplyResources(this.tblFindPerson_colsCountry, "tblFindPerson_colsCountry");
            // 
            // tblFindPerson_colsUserId
            // 
            this.tblFindPerson_colsUserId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tblFindPerson_colsUserId.MaxLength = 30;
            this.tblFindPerson_colsUserId.Name = "tblFindPerson_colsUserId";
            this.tblFindPerson_colsUserId.NamedProperties.Put("EnumerateMethod", "");
            this.tblFindPerson_colsUserId.NamedProperties.Put("FieldFlags", "294");
            this.tblFindPerson_colsUserId.NamedProperties.Put("LovReference", "APPLICATION_USER");
            this.tblFindPerson_colsUserId.NamedProperties.Put("SqlColumn", "USER_ID");
            this.tblFindPerson_colsUserId.Position = 7;
            resources.ApplyResources(this.tblFindPerson_colsUserId, "tblFindPerson_colsUserId");
            // 
            // tblFindPerson_colsContactCustomers
            // 
            this.tblFindPerson_colsContactCustomers.MaxLength = 4000;
            this.tblFindPerson_colsContactCustomers.Name = "tblFindPerson_colsContactCustomers";
            this.tblFindPerson_colsContactCustomers.NamedProperties.Put("EnumerateMethod", "");
            this.tblFindPerson_colsContactCustomers.NamedProperties.Put("FieldFlags", "288");
            this.tblFindPerson_colsContactCustomers.NamedProperties.Put("LovReference", "");
            this.tblFindPerson_colsContactCustomers.NamedProperties.Put("SqlColumn", "CONTACT_CUSTOMERS");
            this.tblFindPerson_colsContactCustomers.Position = 8;
            resources.ApplyResources(this.tblFindPerson_colsContactCustomers, "tblFindPerson_colsContactCustomers");
            // 
            // tblFindPerson_colsContactSuppliers
            // 
            this.tblFindPerson_colsContactSuppliers.MaxLength = 4000;
            this.tblFindPerson_colsContactSuppliers.Name = "tblFindPerson_colsContactSuppliers";
            this.tblFindPerson_colsContactSuppliers.NamedProperties.Put("EnumerateMethod", "");
            this.tblFindPerson_colsContactSuppliers.NamedProperties.Put("FieldFlags", "288");
            this.tblFindPerson_colsContactSuppliers.NamedProperties.Put("LovReference", "");
            this.tblFindPerson_colsContactSuppliers.NamedProperties.Put("SqlColumn", "CONTACT_SUPPLIERS");
            this.tblFindPerson_colsContactSuppliers.Position = 9;
            resources.ApplyResources(this.tblFindPerson_colsContactSuppliers, "tblFindPerson_colsContactSuppliers");
            // 
            // dlgFindPerson
            // 
            this.AcceptButton = this.cCommandButtonFind;
            this.CancelButton = this.cCommandButtonCancel;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.dfsLastName);
            this.Controls.Add(this.labeldfdsLastName);
            this.Controls.Add(this.dfsFirstName);
            this.Controls.Add(this.labeldfdsFirstName);
            this.Controls.Add(this.cCommandButtonFind);
            this.Controls.Add(this.tblFindPerson);
            this.Controls.Add(this.cCommandButtonOK);
            this.Controls.Add(this.cCommandButtonCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.Name = "dlgFindPerson";
            this.ShowIcon = false;
            this.tblFindPerson.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        #region System Methods/Properties

        /// <summary>
        /// Release global reference.
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }
        #endregion

        protected cCommandButton cCommandButtonOK;
        protected cCommandButton cCommandButtonCancel;
        protected Ifs.Fnd.Windows.Forms.FndCommand commandOk;
        protected Ifs.Fnd.Windows.Forms.FndCommand commandCancel;
        protected cCommandButton cCommandButtonFind;
        protected cBackgroundText labeldfdsFirstName;
        protected cDataField dfsFirstName;
        protected cBackgroundText labeldfdsLastName;
        protected cDataField dfsLastName;
        protected Fnd.Windows.Forms.FndCommand commandFind;
        protected cColumn tblFindPerson_colsContactSuppliers;
        protected cColumn tblFindPerson_colsContactCustomers;
        protected cColumn tblFindPerson_colsUserId;
        protected cLookupColumn tblFindPerson_colsCountry;
        protected cColumn tblFindPerson_colsTitle;
        protected cColumn tblFindPerson_colsName;
        protected cColumn tblFindPerson_colsPersonId;
        public cChildTableEntBase tblFindPerson;

    }
}
