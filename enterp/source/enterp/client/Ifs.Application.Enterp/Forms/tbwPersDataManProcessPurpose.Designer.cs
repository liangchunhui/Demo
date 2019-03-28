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

    public partial class tbwPersDataManProcessPurpose
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwPersDataManProcessPurpose));
            this.colsPersonalData = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsPurposeName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsDescription = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsDataSubject = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.SuspendLayout();
            // 
            // colsPersonalData
            // 
            this.colsPersonalData.MaxLength = 30;
            this.colsPersonalData.Name = "colsPersonalData";
            this.colsPersonalData.NamedProperties.Put("EnumerateMethod", "");
            this.colsPersonalData.NamedProperties.Put("FieldFlags", "290");
            this.colsPersonalData.NamedProperties.Put("LovReference", "PERSONAL_DATA_MANAGEMENT_LOV");
            this.colsPersonalData.NamedProperties.Put("SqlColumn", "PERSONAL_DATA");
            this.colsPersonalData.Position = 3;
            resources.ApplyResources(this.colsPersonalData, "colsPersonalData");
            // 
            // colsPurposeName
            // 
            this.colsPurposeName.Name = "colsPurposeName";
            this.colsPurposeName.NamedProperties.Put("EnumerateMethod", "");
            this.colsPurposeName.NamedProperties.Put("FieldFlags", "290");
            this.colsPurposeName.NamedProperties.Put("LovReference", "PERS_DATA_PROC_PURPOSE_LOV");
            this.colsPurposeName.NamedProperties.Put("SqlColumn", "PURPOSE_NAME");
            this.colsPurposeName.Position = 4;
            resources.ApplyResources(this.colsPurposeName, "colsPurposeName");
            // 
            // colsDescription
            // 
            this.colsDescription.MaxLength = 1000;
            this.colsDescription.Name = "colsDescription";
            this.colsDescription.NamedProperties.Put("EnumerateMethod", "");
            this.colsDescription.NamedProperties.Put("FieldFlags", "288");
            this.colsDescription.NamedProperties.Put("LovReference", "");
            this.colsDescription.NamedProperties.Put("SqlColumn", "DESCRIPTION");
            this.colsDescription.Position = 5;
            resources.ApplyResources(this.colsDescription, "colsDescription");
            // 
            // colsDataSubject
            // 
            this.colsDataSubject.MaxLength = 200;
            this.colsDataSubject.Name = "colsDataSubject";
            this.colsDataSubject.NamedProperties.Put("EnumerateMethod", "DATA_SUBJECT_API.Enumerate_Active");
            this.colsDataSubject.NamedProperties.Put("FieldFlags", "167");
            this.colsDataSubject.NamedProperties.Put("LovReference", "");
            this.colsDataSubject.NamedProperties.Put("SqlColumn", "DATA_SUBJECT");
            this.colsDataSubject.Position = 6;
            resources.ApplyResources(this.colsDataSubject, "colsDataSubject");
            // 
            // tbwPersDataManProcessPurpose
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colsPersonalData);
            this.Controls.Add(this.colsPurposeName);
            this.Controls.Add(this.colsDescription);
            this.Controls.Add(this.colsDataSubject);
            this.Name = "tbwPersDataManProcessPurpose";
            this.NamedProperties.Put("DefaultOrderBy", "");
            this.NamedProperties.Put("LogicalUnit", "PersDataManProcessPurpose");
            this.NamedProperties.Put("Module", "ENTERP");
            this.NamedProperties.Put("PackageName", "PERS_DATA_MAN_PROC_PURPOSE_API");
            this.NamedProperties.Put("SourceFlags", "1");
            this.NamedProperties.Put("ViewName", "PERS_DATA_MAN_PROC_PURPOSE");
            this.ReadOnly = true;
            this.Controls.SetChildIndex(this.colsDataSubject, 0);
            this.Controls.SetChildIndex(this.colsDescription, 0);
            this.Controls.SetChildIndex(this.colsPurposeName, 0);
            this.Controls.SetChildIndex(this.colsPersonalData, 0);
            this.Controls.SetChildIndex(this.@__colObjversion, 0);
            this.Controls.SetChildIndex(this.@__colObjid, 0);
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

        protected cColumn colsPersonalData;
        protected cColumn colsPurposeName;
        protected cColumn colsDescription;
        protected cLookupColumn colsDataSubject;
    }
}
