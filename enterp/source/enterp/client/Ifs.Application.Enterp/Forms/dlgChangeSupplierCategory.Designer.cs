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
// Date     By      Notes
// -----    ------  ---------------------------------------------------------------------------------
// 150702   RoJalk  ORA-782, Created.
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

    public partial class dlgChangeSupplierCategory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgChangeSupplierCategory));
            this.cCommandButtonOK = new Ifs.Fnd.ApplicationForms.cCommandButton();
            this.commandOk = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.cCommandButtonCancel = new Ifs.Fnd.ApplicationForms.cCommandButton();
            this.commandCancel = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.dfsNewSupplierId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsNewSupplierName = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsAssociationNo = new Ifs.Fnd.ApplicationForms.cDataField();
            this.gbNewSupplier = new Ifs.Fnd.ApplicationForms.cGroupBox();
            this.dfsCategory = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labeldfsCategory = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.labeldfsNewSuppId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.labeldfsNewSuppName = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.labeldfsAssociationNo = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.gbTemplateSupplier = new Ifs.Fnd.ApplicationForms.cGroupBox();
            this.cbOverwriteData = new Ifs.Fnd.ApplicationForms.cCheckBox();
            this.labeldfsTemplateSuppId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.labeldfsTextDummy1 = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.labeldfsCompany = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.labeldfsTemplateDescription = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.labeldfsTemplateSuppName = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsCompany = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsTemplateDescription = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsTemplateSupplierName = new Ifs.Fnd.ApplicationForms.cDataField();
            this.dfsTemplateSupplierId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.cCommandButtonList = new Ifs.Fnd.ApplicationForms.cCommandButton();
            this.commandList = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.gbNewSupplier.SuspendLayout();
            this.gbTemplateSupplier.SuspendLayout();
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
            this.commandManager.ImageList = null;
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
            // dfsNewSupplierId
            // 
            this.dfsNewSupplierId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsNewSupplierId, "dfsNewSupplierId");
            this.dfsNewSupplierId.Name = "dfsNewSupplierId";
            // 
            // dfsNewSupplierName
            // 
            resources.ApplyResources(this.dfsNewSupplierName, "dfsNewSupplierName");
            this.dfsNewSupplierName.Name = "dfsNewSupplierName";
            this.dfsNewSupplierName.NamedProperties.Put("FieldFlags", "263");
            // 
            // dfsAssociationNo
            // 
            resources.ApplyResources(this.dfsAssociationNo, "dfsAssociationNo");
            this.dfsAssociationNo.Name = "dfsAssociationNo";
            this.dfsAssociationNo.NamedProperties.Put("FieldFlags", "262");
            // 
            // gbNewSupplier
            // 
            this.gbNewSupplier.Controls.Add(this.dfsCategory);
            this.gbNewSupplier.Controls.Add(this.labeldfsCategory);
            this.gbNewSupplier.Controls.Add(this.labeldfsNewSuppId);
            this.gbNewSupplier.Controls.Add(this.labeldfsNewSuppName);
            this.gbNewSupplier.Controls.Add(this.labeldfsAssociationNo);
            this.gbNewSupplier.Controls.Add(this.dfsNewSupplierId);
            this.gbNewSupplier.Controls.Add(this.dfsNewSupplierName);
            this.gbNewSupplier.Controls.Add(this.dfsAssociationNo);
            resources.ApplyResources(this.gbNewSupplier, "gbNewSupplier");
            this.gbNewSupplier.Name = "gbNewSupplier";
            this.gbNewSupplier.TabStop = false;
            // 
            // dfsCategory
            // 
            resources.ApplyResources(this.dfsCategory, "dfsCategory");
            this.dfsCategory.Name = "dfsCategory";
            // 
            // labeldfsCategory
            // 
            resources.ApplyResources(this.labeldfsCategory, "labeldfsCategory");
            this.labeldfsCategory.Name = "labeldfsCategory";
            // 
            // labeldfsNewSuppId
            // 
            resources.ApplyResources(this.labeldfsNewSuppId, "labeldfsNewSuppId");
            this.labeldfsNewSuppId.Name = "labeldfsNewSuppId";
            // 
            // labeldfsNewSuppName
            // 
            resources.ApplyResources(this.labeldfsNewSuppName, "labeldfsNewSuppName");
            this.labeldfsNewSuppName.Name = "labeldfsNewSuppName";
            // 
            // labeldfsAssociationNo
            // 
            resources.ApplyResources(this.labeldfsAssociationNo, "labeldfsAssociationNo");
            this.labeldfsAssociationNo.Name = "labeldfsAssociationNo";
            // 
            // gbTemplateSupplier
            // 
            this.gbTemplateSupplier.Controls.Add(this.cbOverwriteData);
            this.gbTemplateSupplier.Controls.Add(this.labeldfsTemplateSuppId);
            this.gbTemplateSupplier.Controls.Add(this.labeldfsTextDummy1);
            this.gbTemplateSupplier.Controls.Add(this.labeldfsCompany);
            this.gbTemplateSupplier.Controls.Add(this.labeldfsTemplateDescription);
            this.gbTemplateSupplier.Controls.Add(this.labeldfsTemplateSuppName);
            this.gbTemplateSupplier.Controls.Add(this.dfsCompany);
            this.gbTemplateSupplier.Controls.Add(this.dfsTemplateDescription);
            this.gbTemplateSupplier.Controls.Add(this.dfsTemplateSupplierName);
            this.gbTemplateSupplier.Controls.Add(this.dfsTemplateSupplierId);
            resources.ApplyResources(this.gbTemplateSupplier, "gbTemplateSupplier");
            this.gbTemplateSupplier.Name = "gbTemplateSupplier";
            this.gbTemplateSupplier.TabStop = false;
            // 
            // cbOverwriteData
            // 
            resources.ApplyResources(this.cbOverwriteData, "cbOverwriteData");
            this.cbOverwriteData.Name = "cbOverwriteData";
            this.cbOverwriteData.NamedProperties.Put("FieldFlags", "262");
            this.cbOverwriteData.NamedProperties.Put("LovReference", "");
            // 
            // labeldfsTemplateSuppId
            // 
            resources.ApplyResources(this.labeldfsTemplateSuppId, "labeldfsTemplateSuppId");
            this.labeldfsTemplateSuppId.Name = "labeldfsTemplateSuppId";
            // 
            // labeldfsTextDummy1
            // 
            resources.ApplyResources(this.labeldfsTextDummy1, "labeldfsTextDummy1");
            this.labeldfsTextDummy1.Name = "labeldfsTextDummy1";
            // 
            // labeldfsCompany
            // 
            resources.ApplyResources(this.labeldfsCompany, "labeldfsCompany");
            this.labeldfsCompany.Name = "labeldfsCompany";
            // 
            // labeldfsTemplateDescription
            // 
            resources.ApplyResources(this.labeldfsTemplateDescription, "labeldfsTemplateDescription");
            this.labeldfsTemplateDescription.Name = "labeldfsTemplateDescription";
            // 
            // labeldfsTemplateSuppName
            // 
            resources.ApplyResources(this.labeldfsTemplateSuppName, "labeldfsTemplateSuppName");
            this.labeldfsTemplateSuppName.Name = "labeldfsTemplateSuppName";
            // 
            // dfsCompany
            // 
            resources.ApplyResources(this.dfsCompany, "dfsCompany");
            this.dfsCompany.Name = "dfsCompany";
            this.dfsCompany.NamedProperties.Put("FieldFlags", "262");
            this.dfsCompany.NamedProperties.Put("LovReference", "COMPANY_FINANCE");
            // 
            // dfsTemplateDescription
            // 
            resources.ApplyResources(this.dfsTemplateDescription, "dfsTemplateDescription");
            this.dfsTemplateDescription.Name = "dfsTemplateDescription";
            // 
            // dfsTemplateSupplierName
            // 
            resources.ApplyResources(this.dfsTemplateSupplierName, "dfsTemplateSupplierName");
            this.dfsTemplateSupplierName.Name = "dfsTemplateSupplierName";
            // 
            // dfsTemplateSupplierId
            // 
            this.dfsTemplateSupplierId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsTemplateSupplierId, "dfsTemplateSupplierId");
            this.dfsTemplateSupplierId.Name = "dfsTemplateSupplierId";
            this.dfsTemplateSupplierId.NamedProperties.Put("FieldFlags", "262");
            this.dfsTemplateSupplierId.NamedProperties.Put("LovReference", "SUPPLIER_TEMPLATE_LOV");
            this.dfsTemplateSupplierId.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsTemplateSupplierId_WindowActions);
            // 
            // cCommandButtonList
            // 
            this.cCommandButtonList.AcceleratorKey = System.Windows.Forms.Keys.F8;
            resources.ApplyResources(this.cCommandButtonList, "cCommandButtonList");
            this.cCommandButtonList.Command = this.commandList;
            this.cCommandButtonList.Name = "cCommandButtonList";
            // 
            // commandList
            // 
            resources.ApplyResources(this.commandList, "commandList");
            this.commandList.Enabled = false;
            this.commandList.EventCategory = Ifs.Fnd.Windows.Forms.CommandEventCategory.Focus;
            this.commandList.Name = "commandList";
            this.commandList.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.commandList_Execute);
            this.commandList.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.commandList_Inquire);
            // 
            // dlgChangeSupplierCategory
            // 
            this.AcceptButton = this.cCommandButtonOK;
            this.CancelButton = this.cCommandButtonCancel;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.cCommandButtonList);
            this.Controls.Add(this.gbTemplateSupplier);
            this.Controls.Add(this.gbNewSupplier);
            this.Controls.Add(this.cCommandButtonOK);
            this.Controls.Add(this.cCommandButtonCancel);
            this.Name = "dlgChangeSupplierCategory";
            this.gbNewSupplier.ResumeLayout(false);
            this.gbNewSupplier.PerformLayout();
            this.gbTemplateSupplier.ResumeLayout(false);
            this.gbTemplateSupplier.PerformLayout();
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

        protected cCommandButton cCommandButtonCancel;
        protected Ifs.Fnd.Windows.Forms.FndCommand commandOk;
        protected Ifs.Fnd.Windows.Forms.FndCommand commandCancel;
        protected cDataField dfsNewSupplierId;
        protected cDataField dfsNewSupplierName;
        protected cDataField dfsAssociationNo;
        protected cGroupBox gbNewSupplier;
        protected cBackgroundText labeldfsNewSuppId;
        protected cBackgroundText labeldfsNewSuppName;
        protected cBackgroundText labeldfsAssociationNo;
        protected cGroupBox gbTemplateSupplier;
        protected cDataField dfsCompany;
        protected cDataField dfsTemplateDescription;
        protected cDataField dfsTemplateSupplierName;
        protected cDataField dfsTemplateSupplierId;
        protected cBackgroundText labeldfsCompany;
        protected cBackgroundText labeldfsTemplateDescription;
        protected cBackgroundText labeldfsTemplateSuppName;
        protected cBackgroundText labeldfsTextDummy1;
        protected cBackgroundText labeldfsTemplateSuppId;
        protected cCheckBox cbOverwriteData;
        protected cBackgroundText labeldfsCategory;
        protected cDataField dfsCategory;
        protected Fnd.Windows.Forms.FndCommand commandList;
        protected cCommandButton cCommandButtonOK;
        protected cCommandButton cCommandButtonList;

    }
}
