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

    public partial class tbwAnonymizationSetup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tbwAnonymizationSetup));
            this.colsMethodId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsDefaultMethodDb = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsTextValue = new Ifs.Fnd.ApplicationForms.cColumn();
            this.colsAnonymizationMode = new Ifs.Fnd.ApplicationForms.cLookupColumn();
            this.colnNumberValue = new Ifs.Fnd.ApplicationForms.cColumn();
            this.coldDateValue = new Ifs.Fnd.ApplicationForms.cColumn();
            this.SuspendLayout();
            // 
            // colsMethodId
            // 
            this.colsMethodId.MaxLength = 35;
            this.colsMethodId.Name = "colsMethodId";
            this.colsMethodId.NamedProperties.Put("EnumerateMethod", "");
            this.colsMethodId.NamedProperties.Put("FieldFlags", "163");
            this.colsMethodId.NamedProperties.Put("LovReference", "");
            this.colsMethodId.NamedProperties.Put("SqlColumn", "METHOD_ID");
            this.colsMethodId.Position = 3;
            resources.ApplyResources(this.colsMethodId, "colsMethodId");
            // 
            // colsDefaultMethodDb
            // 
            this.colsDefaultMethodDb.CellType = PPJ.Runtime.Windows.CellType.CheckBox;
            this.colsDefaultMethodDb.CheckBox.CheckedValue = "TRUE";
            this.colsDefaultMethodDb.CheckBox.IgnoreCase = true;
            this.colsDefaultMethodDb.CheckBox.UncheckedValue = "FALSE";
            this.colsDefaultMethodDb.MaxLength = 20;
            this.colsDefaultMethodDb.Name = "colsDefaultMethodDb";
            this.colsDefaultMethodDb.NamedProperties.Put("EnumerateMethod", "");
            this.colsDefaultMethodDb.NamedProperties.Put("FieldFlags", "288");
            this.colsDefaultMethodDb.NamedProperties.Put("LovReference", "");
            this.colsDefaultMethodDb.NamedProperties.Put("SqlColumn", "DEFAULT_METHOD_DB");
            this.colsDefaultMethodDb.Position = 8;
            resources.ApplyResources(this.colsDefaultMethodDb, "colsDefaultMethodDb");
            // 
            // colsTextValue
            // 
            this.colsTextValue.MaxLength = 50;
            this.colsTextValue.Name = "colsTextValue";
            this.colsTextValue.NamedProperties.Put("EnumerateMethod", "");
            this.colsTextValue.NamedProperties.Put("FieldFlags", "294");
            this.colsTextValue.NamedProperties.Put("LovReference", "");
            this.colsTextValue.NamedProperties.Put("SqlColumn", "TEXT_VALUE");
            this.colsTextValue.Position = 4;
            resources.ApplyResources(this.colsTextValue, "colsTextValue");
            // 
            // colsAnonymizationMode
            // 
            this.colsAnonymizationMode.MaxLength = 200;
            this.colsAnonymizationMode.Name = "colsAnonymizationMode";
            this.colsAnonymizationMode.NamedProperties.Put("EnumerateMethod", "ANONYMIZATION_MODE_TYPE_API.Enumerate");
            this.colsAnonymizationMode.NamedProperties.Put("FieldFlags", "294");
            this.colsAnonymizationMode.NamedProperties.Put("LovReference", "");
            this.colsAnonymizationMode.NamedProperties.Put("SqlColumn", "TEXT_ANONYMIZATION_MODE");
            this.colsAnonymizationMode.Position = 5;
            resources.ApplyResources(this.colsAnonymizationMode, "colsAnonymizationMode");
            // 
            // colnNumberValue
            // 
            this.colnNumberValue.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.colnNumberValue.Name = "colnNumberValue";
            this.colnNumberValue.NamedProperties.Put("EnumerateMethod", "");
            this.colnNumberValue.NamedProperties.Put("FieldFlags", "294");
            this.colnNumberValue.NamedProperties.Put("Format", "");
            this.colnNumberValue.NamedProperties.Put("LovReference", "");
            this.colnNumberValue.NamedProperties.Put("SqlColumn", "NUMBER_VALUE");
            this.colnNumberValue.Position = 7;
            this.colnNumberValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.colnNumberValue, "colnNumberValue");
            // 
            // coldDateValue
            // 
            this.coldDateValue.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.coldDateValue.Format = "d";
            this.coldDateValue.Name = "coldDateValue";
            this.coldDateValue.NamedProperties.Put("EnumerateMethod", "");
            this.coldDateValue.NamedProperties.Put("FieldFlags", "294");
            this.coldDateValue.NamedProperties.Put("LovReference", "");
            this.coldDateValue.NamedProperties.Put("SqlColumn", "DATE_VALUE");
            this.coldDateValue.Position = 6;
            resources.ApplyResources(this.coldDateValue, "coldDateValue");
            // 
            // tbwAnonymizationSetup
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.colsMethodId);
            this.Controls.Add(this.colsTextValue);
            this.Controls.Add(this.colsAnonymizationMode);
            this.Controls.Add(this.coldDateValue);
            this.Controls.Add(this.colnNumberValue);
            this.Controls.Add(this.colsDefaultMethodDb);
            this.Name = "tbwAnonymizationSetup";
            this.NamedProperties.Put("LogicalUnit", "AnonymizationSetup");
            this.NamedProperties.Put("Module", "ENTERP");
            this.NamedProperties.Put("PackageName", "ANONYMIZATION_SETUP_API");
            this.NamedProperties.Put("SourceFlags", "449");
            this.NamedProperties.Put("ViewName", "ANONYMIZATION_SETUP");
            this.Controls.SetChildIndex(this.colsDefaultMethodDb, 0);
            this.Controls.SetChildIndex(this.colnNumberValue, 0);
            this.Controls.SetChildIndex(this.coldDateValue, 0);
            this.Controls.SetChildIndex(this.colsAnonymizationMode, 0);
            this.Controls.SetChildIndex(this.colsTextValue, 0);
            this.Controls.SetChildIndex(this.colsMethodId, 0);
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

        protected cColumn colsMethodId;
        protected cColumn colsDefaultMethodDb;
        protected cColumn colsTextValue;
        protected cLookupColumn colsAnonymizationMode;
        protected cColumn colnNumberValue;
        protected cColumn coldDateValue;
    }
}
