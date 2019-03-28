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

    public partial class dlgDetailedTaxOfficeAddress
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgDetailedTaxOfficeAddress));
            this.dfsAddressId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelAddressId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsTaxOfficeId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelTaxOfficeId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsStreet = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelStreet = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsHouseNo = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelHouseNo = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsCommunity = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelCommunity = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsDistrict = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelDistrict = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cmdOK = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.pbOk = new Ifs.Fnd.ApplicationForms.cCommandButton();
            this.pbCancel = new Ifs.Fnd.ApplicationForms.cCommandButton();
            this.cmdCancel = new Ifs.Fnd.Windows.Forms.FndCommand(this.components);
            this.SuspendLayout();
            // 
            // commandManager
            // 
            this.commandManager.Commands.Add(this.cmdOK);
            this.commandManager.Commands.Add(this.cmdCancel);
            this.commandManager.Components.Add(this.pbOk);
            this.commandManager.Components.Add(this.pbCancel);
            // 
            // dfsAddressId
            // 
            this.dfsAddressId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsAddressId, "dfsAddressId");
            this.dfsAddressId.Name = "dfsAddressId";
            this.dfsAddressId.NamedProperties.Put("EnumerateMethod", "");
            this.dfsAddressId.NamedProperties.Put("FieldFlags", "163");
            this.dfsAddressId.NamedProperties.Put("LovReference", "");
            this.dfsAddressId.NamedProperties.Put("SqlColumn", "ADDRESS_ID");
            // 
            // labelAddressId
            // 
            resources.ApplyResources(this.labelAddressId, "labelAddressId");
            this.labelAddressId.Name = "labelAddressId";
            // 
            // dfsTaxOfficeId
            // 
            resources.ApplyResources(this.dfsTaxOfficeId, "dfsTaxOfficeId");
            this.dfsTaxOfficeId.Name = "dfsTaxOfficeId";
            this.dfsTaxOfficeId.NamedProperties.Put("EnumerateMethod", "");
            this.dfsTaxOfficeId.NamedProperties.Put("FieldFlags", "99");
            this.dfsTaxOfficeId.NamedProperties.Put("LovReference", "TAX_OFFICE_INFO");
            this.dfsTaxOfficeId.NamedProperties.Put("SqlColumn", "TAX_OFFICE_ID");
            // 
            // labelTaxOfficeId
            // 
            resources.ApplyResources(this.labelTaxOfficeId, "labelTaxOfficeId");
            this.labelTaxOfficeId.Name = "labelTaxOfficeId";
            // 
            // dfsStreet
            // 
            resources.ApplyResources(this.dfsStreet, "dfsStreet");
            this.dfsStreet.Name = "dfsStreet";
            this.dfsStreet.NamedProperties.Put("EnumerateMethod", "");
            this.dfsStreet.NamedProperties.Put("FieldFlags", "294");
            this.dfsStreet.NamedProperties.Put("LovReference", "");
            this.dfsStreet.NamedProperties.Put("SqlColumn", "STREET");
            this.dfsStreet.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsStreet_WindowActions);
            // 
            // labelStreet
            // 
            resources.ApplyResources(this.labelStreet, "labelStreet");
            this.labelStreet.Name = "labelStreet";
            // 
            // dfsHouseNo
            // 
            resources.ApplyResources(this.dfsHouseNo, "dfsHouseNo");
            this.dfsHouseNo.Name = "dfsHouseNo";
            this.dfsHouseNo.NamedProperties.Put("EnumerateMethod", "");
            this.dfsHouseNo.NamedProperties.Put("FieldFlags", "294");
            this.dfsHouseNo.NamedProperties.Put("LovReference", "");
            this.dfsHouseNo.NamedProperties.Put("SqlColumn", "HOUSE_NO");
            this.dfsHouseNo.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsHouseNo_WindowActions);
            // 
            // labelHouseNo
            // 
            resources.ApplyResources(this.labelHouseNo, "labelHouseNo");
            this.labelHouseNo.Name = "labelHouseNo";
            // 
            // dfsCommunity
            // 
            resources.ApplyResources(this.dfsCommunity, "dfsCommunity");
            this.dfsCommunity.Name = "dfsCommunity";
            this.dfsCommunity.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCommunity.NamedProperties.Put("FieldFlags", "294");
            this.dfsCommunity.NamedProperties.Put("LovReference", "");
            this.dfsCommunity.NamedProperties.Put("SqlColumn", "COMMUNITY");
            this.dfsCommunity.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsCommunity_WindowActions);
            // 
            // labelCommunity
            // 
            resources.ApplyResources(this.labelCommunity, "labelCommunity");
            this.labelCommunity.Name = "labelCommunity";
            // 
            // dfsDistrict
            // 
            resources.ApplyResources(this.dfsDistrict, "dfsDistrict");
            this.dfsDistrict.Name = "dfsDistrict";
            this.dfsDistrict.NamedProperties.Put("EnumerateMethod", "");
            this.dfsDistrict.NamedProperties.Put("FieldFlags", "294");
            this.dfsDistrict.NamedProperties.Put("LovReference", "");
            this.dfsDistrict.NamedProperties.Put("SqlColumn", "DISTRICT");
            this.dfsDistrict.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.dfsDistrict_WindowActions);
            // 
            // labelDistrict
            // 
            resources.ApplyResources(this.labelDistrict, "labelDistrict");
            this.labelDistrict.Name = "labelDistrict";
            // 
            // cmdOK
            // 
            resources.ApplyResources(this.cmdOK, "cmdOK");
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.pbOk_Execute);
            this.cmdOK.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.pbOk_Inquire);
            // 
            // pbOk
            // 
            this.pbOk.Command = this.cmdOK;
            resources.ApplyResources(this.pbOk, "pbOk");
            this.pbOk.Name = "pbOk";
            // 
            // pbCancel
            // 
            this.pbCancel.Command = this.cmdCancel;
            resources.ApplyResources(this.pbCancel, "pbCancel");
            this.pbCancel.Name = "pbCancel";
            // 
            // cmdCancel
            // 
            resources.ApplyResources(this.cmdCancel, "cmdCancel");
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Execute += new Ifs.Fnd.Windows.Forms.FndCommandExecuteHandler(this.pbCancel_Execute);
            this.cmdCancel.Inquire += new Ifs.Fnd.Windows.Forms.FndCommandInquireHandler(this.pbCancel_Inquire);
            // 
            // dlgDetailedTaxOfficeAddress
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pbCancel);
            this.Controls.Add(this.pbOk);
            this.Controls.Add(this.dfsDistrict);
            this.Controls.Add(this.labelDistrict);
            this.Controls.Add(this.dfsCommunity);
            this.Controls.Add(this.labelCommunity);
            this.Controls.Add(this.dfsHouseNo);
            this.Controls.Add(this.labelHouseNo);
            this.Controls.Add(this.dfsStreet);
            this.Controls.Add(this.labelStreet);
            this.Controls.Add(this.dfsTaxOfficeId);
            this.Controls.Add(this.labelTaxOfficeId);
            this.Controls.Add(this.dfsAddressId);
            this.Controls.Add(this.labelAddressId);
            this.Name = "dlgDetailedTaxOfficeAddress";
            this.NamedProperties.Put("DefaultWhere", "TAX_OFFICE_ID= :i_hWndFrame.dlgDetailedTaxOfficeAddress.dfsTaxOfficeId AND\nADDRES" +
                    "S_ID = :i_hWndFrame.dlgDetailedTaxOfficeAddress.dfsAddressId");
            this.NamedProperties.Put("LogicalUnit", "TaxOfficeInfoAddress");
            this.NamedProperties.Put("PackageName", "TAX_OFFICE_INFO_ADDRESS_API");
            this.NamedProperties.Put("SourceFlags", "129");
            this.NamedProperties.Put("ViewName", "TAX_OFFICE_INFO_ADDRESS");
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

        protected Ifs.Fnd.Windows.Forms.FndCommand commandOk;
        protected Ifs.Fnd.Windows.Forms.FndCommand commandCancel;
        public cDataField dfsHouseNo;
        public cDataField dfsAddressId;
        public cDataField dfsCommunity;
        public cDataField dfsDistrict;
        public cDataField dfsStreet;
        public cDataField dfsTaxOfficeId;
        protected cBackgroundText labelAddressId;
        protected cBackgroundText labelCommunity;
        protected cBackgroundText labelDistrict;
        protected cBackgroundText labelHouseNo;
        protected cBackgroundText labelStreet;
        protected cBackgroundText labelTaxOfficeId;
        protected Fnd.Windows.Forms.FndCommand cmdOK;
        public cCommandButton pbCancel;
        public cCommandButton pbOk;
        protected Fnd.Windows.Forms.FndCommand cmdCancel;

    }
}
