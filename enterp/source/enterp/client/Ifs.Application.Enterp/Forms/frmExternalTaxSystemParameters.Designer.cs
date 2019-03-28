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

    public partial class frmExternalTaxSystemParameters
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExternalTaxSystemParameters));
            this.dfnSequenceNumber = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelSequenceNumber = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsUserNameVertex = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelUserNameVertex = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsPasswordVertex = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelPasswordVertex = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsTrustedIdVertex = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelTrustedIdVertex = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.gbVertexO = new Ifs.Fnd.ApplicationForms.cGroupBox();
            this.cmbVersionVertex = new Ifs.Fnd.ApplicationForms.cComboBox();
            this.labelVersionVertex = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.gbVertexO.SuspendLayout();
            this.SuspendLayout();
            // 
            // dfnSequenceNumber
            // 
            this.dfnSequenceNumber.DataType = PPJ.Runtime.Windows.DataType.Number;
            resources.ApplyResources(this.dfnSequenceNumber, "dfnSequenceNumber");
            this.dfnSequenceNumber.Name = "dfnSequenceNumber";
            this.dfnSequenceNumber.NamedProperties.Put("EnumerateMethod", "");
            this.dfnSequenceNumber.NamedProperties.Put("FieldFlags", "130");
            this.dfnSequenceNumber.NamedProperties.Put("Format", "");
            this.dfnSequenceNumber.NamedProperties.Put("LovReference", "");
            this.dfnSequenceNumber.NamedProperties.Put("SqlColumn", "SEQUENCE_NUMBER");
            // 
            // labelSequenceNumber
            // 
            resources.ApplyResources(this.labelSequenceNumber, "labelSequenceNumber");
            this.labelSequenceNumber.Name = "labelSequenceNumber";
            // 
            // dfsUserNameVertex
            // 
            resources.ApplyResources(this.dfsUserNameVertex, "dfsUserNameVertex");
            this.dfsUserNameVertex.Name = "dfsUserNameVertex";
            this.dfsUserNameVertex.NamedProperties.Put("EnumerateMethod", "");
            this.dfsUserNameVertex.NamedProperties.Put("FieldFlags", "294");
            this.dfsUserNameVertex.NamedProperties.Put("LovReference", "");
            this.dfsUserNameVertex.NamedProperties.Put("SqlColumn", "USER_NAME_VERTEX");
            // 
            // labelUserNameVertex
            // 
            resources.ApplyResources(this.labelUserNameVertex, "labelUserNameVertex");
            this.labelUserNameVertex.Name = "labelUserNameVertex";
            // 
            // dfsPasswordVertex
            // 
            resources.ApplyResources(this.dfsPasswordVertex, "dfsPasswordVertex");
            this.dfsPasswordVertex.Name = "dfsPasswordVertex";
            this.dfsPasswordVertex.NamedProperties.Put("EnumerateMethod", "");
            this.dfsPasswordVertex.NamedProperties.Put("FieldFlags", "294");
            this.dfsPasswordVertex.NamedProperties.Put("LovReference", "");
            this.dfsPasswordVertex.NamedProperties.Put("SqlColumn", "PASSWORD_VERTEX");
            // 
            // labelPasswordVertex
            // 
            resources.ApplyResources(this.labelPasswordVertex, "labelPasswordVertex");
            this.labelPasswordVertex.Name = "labelPasswordVertex";
            // 
            // dfsTrustedIdVertex
            // 
            resources.ApplyResources(this.dfsTrustedIdVertex, "dfsTrustedIdVertex");
            this.dfsTrustedIdVertex.Name = "dfsTrustedIdVertex";
            this.dfsTrustedIdVertex.NamedProperties.Put("EnumerateMethod", "");
            this.dfsTrustedIdVertex.NamedProperties.Put("FieldFlags", "294");
            this.dfsTrustedIdVertex.NamedProperties.Put("LovReference", "");
            this.dfsTrustedIdVertex.NamedProperties.Put("SqlColumn", "TRUSTED_ID_VERTEX");
            // 
            // labelTrustedIdVertex
            // 
            resources.ApplyResources(this.labelTrustedIdVertex, "labelTrustedIdVertex");
            this.labelTrustedIdVertex.Name = "labelTrustedIdVertex";
            // 
            // gbVertexO
            // 
            this.gbVertexO.Controls.Add(this.cmbVersionVertex);
            this.gbVertexO.Controls.Add(this.labelVersionVertex);
            this.gbVertexO.Controls.Add(this.dfsTrustedIdVertex);
            this.gbVertexO.Controls.Add(this.labelTrustedIdVertex);
            this.gbVertexO.Controls.Add(this.dfnSequenceNumber);
            this.gbVertexO.Controls.Add(this.dfsPasswordVertex);
            this.gbVertexO.Controls.Add(this.labelSequenceNumber);
            this.gbVertexO.Controls.Add(this.labelPasswordVertex);
            this.gbVertexO.Controls.Add(this.dfsUserNameVertex);
            this.gbVertexO.Controls.Add(this.labelUserNameVertex);
            resources.ApplyResources(this.gbVertexO, "gbVertexO");
            this.gbVertexO.Name = "gbVertexO";
            this.gbVertexO.TabStop = false;
            // 
            // cmbVersionVertex
            // 
            this.cmbVersionVertex.FormattingEnabled = true;
            resources.ApplyResources(this.cmbVersionVertex, "cmbVersionVertex");
            this.cmbVersionVertex.Name = "cmbVersionVertex";
            this.cmbVersionVertex.NamedProperties.Put("EnumerateMethod", "EXT_TAX_SYSTEM_VERSION_API.Enumerate");
            this.cmbVersionVertex.NamedProperties.Put("FieldFlags", "295");
            this.cmbVersionVertex.NamedProperties.Put("LovReference", "");
            this.cmbVersionVertex.NamedProperties.Put("SqlColumn", "VERSION_VERTEX");
            // 
            // labelVersionVertex
            // 
            resources.ApplyResources(this.labelVersionVertex, "labelVersionVertex");
            this.labelVersionVertex.Name = "labelVersionVertex";
            // 
            // frmExternalTaxSystemParameters
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.gbVertexO);
            this.Name = "frmExternalTaxSystemParameters";
            this.NamedProperties.Put("LogicalUnit", "ExtTaxSystemParameters");
            this.NamedProperties.Put("Module", "ENTERP");
            this.NamedProperties.Put("PackageName", "EXT_TAX_SYSTEM_PARAMETERS_API");
            this.NamedProperties.Put("SourceFlags", "129");
            this.NamedProperties.Put("ViewName", "EXT_TAX_SYSTEM_PARAMETERS");
            this.gbVertexO.ResumeLayout(false);
            this.gbVertexO.PerformLayout();
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

        protected cDataField dfnSequenceNumber;
        protected cBackgroundText labelSequenceNumber;
        protected cDataField dfsUserNameVertex;
        protected cBackgroundText labelUserNameVertex;
        protected cDataField dfsPasswordVertex;
        protected cBackgroundText labelPasswordVertex;
        protected cDataField dfsTrustedIdVertex;
        protected cBackgroundText labelTrustedIdVertex;
        protected cGroupBox gbVertexO;
        protected cComboBox cmbVersionVertex;
        protected cBackgroundText labelVersionVertex;
    }
}
