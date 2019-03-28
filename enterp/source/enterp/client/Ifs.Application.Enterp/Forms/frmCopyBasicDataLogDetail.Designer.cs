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

    public partial class frmCopyBasicDataLogDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCopyBasicDataLogDetail));
            this.cChildTableDetail = new Ifs.Fnd.ApplicationForms.cChildTable();
            this.cChildTableDetail_colnLogId = new Ifs.Fnd.ApplicationForms.cColumn();
            this.cChildTableDetail_colsTargetCompany = new Ifs.Fnd.ApplicationForms.cColumn();
            this.cChildTableDetail_colsCompanyName = new Ifs.Fnd.ApplicationForms.cColumn();
            this.cChildTableDetail_colsValue = new Ifs.Fnd.ApplicationForms.cColumn();
            this.cChildTableDetail_colsStatus = new Ifs.Fnd.ApplicationForms.cColumn();
            this.cChildTableDetail_colsMessageText = new Ifs.Fnd.ApplicationForms.cColumn();
            this.cChildTableDetail_coldTimestamp = new Ifs.Fnd.ApplicationForms.cColumn();
            this.dfsSourceCompany = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelSourceCompany = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsCompanyName = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelCompanyName = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsUserId = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelUserId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfnLogId = new Ifs.Fnd.ApplicationForms.cRecListDataField();
            this.labelLogId = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.dfsWindowName = new Ifs.Fnd.ApplicationForms.cDataField();
            this.labelWindowName = new Ifs.Fnd.ApplicationForms.cBackgroundText();
            this.cChildTableDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // cChildTableDetail
            // 
            this.cChildTableDetail.Controls.Add(this.cChildTableDetail_colnLogId);
            this.cChildTableDetail.Controls.Add(this.cChildTableDetail_colsTargetCompany);
            this.cChildTableDetail.Controls.Add(this.cChildTableDetail_colsCompanyName);
            this.cChildTableDetail.Controls.Add(this.cChildTableDetail_colsValue);
            this.cChildTableDetail.Controls.Add(this.cChildTableDetail_colsStatus);
            this.cChildTableDetail.Controls.Add(this.cChildTableDetail_colsMessageText);
            this.cChildTableDetail.Controls.Add(this.cChildTableDetail_coldTimestamp);
            resources.ApplyResources(this.cChildTableDetail, "cChildTableDetail");
            this.cChildTableDetail.Name = "cChildTableDetail";
            this.cChildTableDetail.NamedProperties.Put("LogicalUnit", "CopyBasicDataLogDetail");
            this.cChildTableDetail.NamedProperties.Put("Module", "ENTERP");
            this.cChildTableDetail.NamedProperties.Put("PackageName", "COPY_BASIC_DATA_LOG_DETAIL_API");
            this.cChildTableDetail.NamedProperties.Put("ResizeableChildObject", "LLMM");
            this.cChildTableDetail.NamedProperties.Put("SourceFlags", "1");
            this.cChildTableDetail.NamedProperties.Put("ViewName", "COPY_BASIC_DATA_LOG_DETAIL");
            this.cChildTableDetail.Controls.SetChildIndex(this.cChildTableDetail_coldTimestamp, 0);
            this.cChildTableDetail.Controls.SetChildIndex(this.cChildTableDetail_colsMessageText, 0);
            this.cChildTableDetail.Controls.SetChildIndex(this.cChildTableDetail_colsStatus, 0);
            this.cChildTableDetail.Controls.SetChildIndex(this.cChildTableDetail_colsValue, 0);
            this.cChildTableDetail.Controls.SetChildIndex(this.cChildTableDetail_colsCompanyName, 0);
            this.cChildTableDetail.Controls.SetChildIndex(this.cChildTableDetail_colsTargetCompany, 0);
            this.cChildTableDetail.Controls.SetChildIndex(this.cChildTableDetail_colnLogId, 0);
            // 
            // cChildTableDetail_colnLogId
            // 
            this.cChildTableDetail_colnLogId.DataType = PPJ.Runtime.Windows.DataType.Number;
            this.cChildTableDetail_colnLogId.Name = "cChildTableDetail_colnLogId";
            this.cChildTableDetail_colnLogId.NamedProperties.Put("EnumerateMethod", "");
            this.cChildTableDetail_colnLogId.NamedProperties.Put("FieldFlags", "4195");
            this.cChildTableDetail_colnLogId.NamedProperties.Put("Format", "");
            this.cChildTableDetail_colnLogId.NamedProperties.Put("LovReference", "");
            this.cChildTableDetail_colnLogId.NamedProperties.Put("SqlColumn", "LOG_ID");
            this.cChildTableDetail_colnLogId.Position = 3;
            this.cChildTableDetail_colnLogId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            resources.ApplyResources(this.cChildTableDetail_colnLogId, "cChildTableDetail_colnLogId");
            // 
            // cChildTableDetail_colsTargetCompany
            // 
            this.cChildTableDetail_colsTargetCompany.MaxLength = 20;
            this.cChildTableDetail_colsTargetCompany.Name = "cChildTableDetail_colsTargetCompany";
            this.cChildTableDetail_colsTargetCompany.NamedProperties.Put("EnumerateMethod", "");
            this.cChildTableDetail_colsTargetCompany.NamedProperties.Put("FieldFlags", "163");
            this.cChildTableDetail_colsTargetCompany.NamedProperties.Put("LovReference", "");
            this.cChildTableDetail_colsTargetCompany.NamedProperties.Put("SqlColumn", "TARGET_COMPANY");
            this.cChildTableDetail_colsTargetCompany.Position = 4;
            resources.ApplyResources(this.cChildTableDetail_colsTargetCompany, "cChildTableDetail_colsTargetCompany");
            // 
            // cChildTableDetail_colsCompanyName
            // 
            this.cChildTableDetail_colsCompanyName.Name = "cChildTableDetail_colsCompanyName";
            this.cChildTableDetail_colsCompanyName.NamedProperties.Put("EnumerateMethod", "");
            this.cChildTableDetail_colsCompanyName.NamedProperties.Put("FieldFlags", "288");
            this.cChildTableDetail_colsCompanyName.NamedProperties.Put("LovReference", "");
            this.cChildTableDetail_colsCompanyName.NamedProperties.Put("SqlColumn", "COMPANY_NAME");
            this.cChildTableDetail_colsCompanyName.Position = 5;
            resources.ApplyResources(this.cChildTableDetail_colsCompanyName, "cChildTableDetail_colsCompanyName");
            // 
            // cChildTableDetail_colsValue
            // 
            this.cChildTableDetail_colsValue.Name = "cChildTableDetail_colsValue";
            this.cChildTableDetail_colsValue.NamedProperties.Put("EnumerateMethod", "");
            this.cChildTableDetail_colsValue.NamedProperties.Put("FieldFlags", "163");
            this.cChildTableDetail_colsValue.NamedProperties.Put("LovReference", "");
            this.cChildTableDetail_colsValue.NamedProperties.Put("SqlColumn", "VALUE");
            this.cChildTableDetail_colsValue.Position = 6;
            resources.ApplyResources(this.cChildTableDetail_colsValue, "cChildTableDetail_colsValue");
            // 
            // cChildTableDetail_colsStatus
            // 
            this.cChildTableDetail_colsStatus.MaxLength = 20;
            this.cChildTableDetail_colsStatus.Name = "cChildTableDetail_colsStatus";
            this.cChildTableDetail_colsStatus.NamedProperties.Put("EnumerateMethod", "");
            this.cChildTableDetail_colsStatus.NamedProperties.Put("FieldFlags", "291");
            this.cChildTableDetail_colsStatus.NamedProperties.Put("LovReference", "");
            this.cChildTableDetail_colsStatus.NamedProperties.Put("SqlColumn", "STATUS");
            this.cChildTableDetail_colsStatus.Position = 7;
            resources.ApplyResources(this.cChildTableDetail_colsStatus, "cChildTableDetail_colsStatus");
            // 
            // cChildTableDetail_colsMessageText
            // 
            this.cChildTableDetail_colsMessageText.MaxLength = 2000;
            this.cChildTableDetail_colsMessageText.Name = "cChildTableDetail_colsMessageText";
            this.cChildTableDetail_colsMessageText.NamedProperties.Put("EnumerateMethod", "");
            this.cChildTableDetail_colsMessageText.NamedProperties.Put("FieldFlags", "307");
            this.cChildTableDetail_colsMessageText.NamedProperties.Put("LovReference", "");
            this.cChildTableDetail_colsMessageText.NamedProperties.Put("SqlColumn", "MESSAGE_TEXT");
            this.cChildTableDetail_colsMessageText.Position = 8;
            resources.ApplyResources(this.cChildTableDetail_colsMessageText, "cChildTableDetail_colsMessageText");
            // 
            // cChildTableDetail_coldTimestamp
            // 
            this.cChildTableDetail_coldTimestamp.DataType = PPJ.Runtime.Windows.DataType.DateTime;
            this.cChildTableDetail_coldTimestamp.Format = "G";
            this.cChildTableDetail_coldTimestamp.Name = "cChildTableDetail_coldTimestamp";
            this.cChildTableDetail_coldTimestamp.NamedProperties.Put("EnumerateMethod", "");
            this.cChildTableDetail_coldTimestamp.NamedProperties.Put("FieldFlags", "291");
            this.cChildTableDetail_coldTimestamp.NamedProperties.Put("LovReference", "");
            this.cChildTableDetail_coldTimestamp.NamedProperties.Put("SqlColumn", "TIMESTAMP");
            this.cChildTableDetail_coldTimestamp.Position = 9;
            resources.ApplyResources(this.cChildTableDetail_coldTimestamp, "cChildTableDetail_coldTimestamp");
            // 
            // dfsSourceCompany
            // 
            resources.ApplyResources(this.dfsSourceCompany, "dfsSourceCompany");
            this.dfsSourceCompany.Name = "dfsSourceCompany";
            this.dfsSourceCompany.NamedProperties.Put("EnumerateMethod", "");
            this.dfsSourceCompany.NamedProperties.Put("FieldFlags", "291");
            this.dfsSourceCompany.NamedProperties.Put("LovReference", "");
            this.dfsSourceCompany.NamedProperties.Put("SqlColumn", "SOURCE_COMPANY");
            // 
            // labelSourceCompany
            // 
            resources.ApplyResources(this.labelSourceCompany, "labelSourceCompany");
            this.labelSourceCompany.Name = "labelSourceCompany";
            // 
            // dfsCompanyName
            // 
            resources.ApplyResources(this.dfsCompanyName, "dfsCompanyName");
            this.dfsCompanyName.Name = "dfsCompanyName";
            this.dfsCompanyName.NamedProperties.Put("EnumerateMethod", "");
            this.dfsCompanyName.NamedProperties.Put("FieldFlags", "288");
            this.dfsCompanyName.NamedProperties.Put("LovReference", "");
            this.dfsCompanyName.NamedProperties.Put("SqlColumn", "COMPANY_NAME");
            // 
            // labelCompanyName
            // 
            resources.ApplyResources(this.labelCompanyName, "labelCompanyName");
            this.labelCompanyName.Name = "labelCompanyName";
            // 
            // dfsUserId
            // 
            this.dfsUserId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.dfsUserId, "dfsUserId");
            this.dfsUserId.Name = "dfsUserId";
            this.dfsUserId.NamedProperties.Put("EnumerateMethod", "");
            this.dfsUserId.NamedProperties.Put("FieldFlags", "291");
            this.dfsUserId.NamedProperties.Put("LovReference", "");
            this.dfsUserId.NamedProperties.Put("SqlColumn", "USER_ID");
            // 
            // labelUserId
            // 
            resources.ApplyResources(this.labelUserId, "labelUserId");
            this.labelUserId.Name = "labelUserId";
            // 
            // dfnLogId
            // 
            resources.ApplyResources(this.dfnLogId, "dfnLogId");
            this.dfnLogId.Name = "dfnLogId";
            this.dfnLogId.NamedProperties.Put("DataType", "3");
            this.dfnLogId.NamedProperties.Put("EnumerateMethod", "");
            this.dfnLogId.NamedProperties.Put("FieldFlags", "163");
            this.dfnLogId.NamedProperties.Put("Format", "");
            this.dfnLogId.NamedProperties.Put("LovReference", "");
            this.dfnLogId.NamedProperties.Put("SqlColumn", "LOG_ID");
            // 
            // labelLogId
            // 
            resources.ApplyResources(this.labelLogId, "labelLogId");
            this.labelLogId.Name = "labelLogId";
            // 
            // dfsWindowName
            // 
            resources.ApplyResources(this.dfsWindowName, "dfsWindowName");
            this.dfsWindowName.Name = "dfsWindowName";
            this.dfsWindowName.NamedProperties.Put("EnumerateMethod", "");
            this.dfsWindowName.NamedProperties.Put("FieldFlags", "288");
            this.dfsWindowName.NamedProperties.Put("LovReference", "");
            this.dfsWindowName.NamedProperties.Put("SqlColumn", "WINDOW_NAME");
            // 
            // labelWindowName
            // 
            resources.ApplyResources(this.labelWindowName, "labelWindowName");
            this.labelWindowName.Name = "labelWindowName";
            // 
            // frmCopyBasicDataLogDetail
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.dfsWindowName);
            this.Controls.Add(this.labelWindowName);
            this.Controls.Add(this.dfnLogId);
            this.Controls.Add(this.labelLogId);
            this.Controls.Add(this.dfsUserId);
            this.Controls.Add(this.labelUserId);
            this.Controls.Add(this.dfsCompanyName);
            this.Controls.Add(this.labelCompanyName);
            this.Controls.Add(this.dfsSourceCompany);
            this.Controls.Add(this.labelSourceCompany);
            this.Controls.Add(this.cChildTableDetail);
            this.Name = "frmCopyBasicDataLogDetail";
            this.NamedProperties.Put("LogicalUnit", "CopyBasicDataLog");
            this.NamedProperties.Put("Module", "ENTERP");
            this.NamedProperties.Put("PackageName", "COPY_BASIC_DATA_LOG_API");
            this.NamedProperties.Put("SourceFlags", "1");
            this.NamedProperties.Put("ViewName", "COPY_BASIC_DATA_LOG");
            this.cChildTableDetail.ResumeLayout(false);
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

        protected cChildTable cChildTableDetail;
        protected cDataField dfsSourceCompany;
        protected cBackgroundText labelSourceCompany;
        protected cDataField dfsCompanyName;
        protected cBackgroundText labelCompanyName;
        protected cColumn cChildTableDetail_colnLogId;
        protected cColumn cChildTableDetail_colsTargetCompany;
        protected cColumn cChildTableDetail_colsCompanyName;
        protected cColumn cChildTableDetail_colsValue;
        protected cColumn cChildTableDetail_colsStatus;
        protected cColumn cChildTableDetail_colsMessageText;
        protected cColumn cChildTableDetail_coldTimestamp;
        protected cDataField dfsUserId;
        protected cBackgroundText labelUserId;
        protected cRecListDataField dfnLogId;
        protected cBackgroundText labelLogId;
        protected cDataField dfsWindowName;
        protected cBackgroundText labelWindowName;
    }
}
