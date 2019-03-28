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
using System.Diagnostics;
using Ifs.Fnd.ApplicationForms;
using PPJ.Runtime;
using PPJ.Runtime.Windows;
using Ifs.Fnd.Windows.Forms;

namespace Ifs.Application.Enterp
{

    /// <summary>
    /// </summary>
    [FndWindowRegistration("DATA_SUBJECT_CONSENT_OV", "DataSubjectConsent")]
    public partial class tbwDataSubjectConsentAnalysis : cTableWindow
    {
        #region Member Variables
        protected SalString sDataSubjectKeyRef = "";
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public tbwDataSubjectConsentAnalysis()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();
        }

        #endregion

        #region System Methods/Properties

        /// <summary>
        /// Returns the object instance associated with the window handle.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public new static tbwDataSubjectConsentAnalysis FromHandle(SalWindowHandle handle)
        {
            return ((tbwDataSubjectConsentAnalysis)SalWindow.FromHandle(handle, typeof(tbwDataSubjectConsentAnalysis)));
        }

        #endregion        

        #region Properties

        #endregion

        #region Methods

        #endregion

        #region Overrides

        #endregion

        #region Window Actions

        #endregion

        #region Event Handlers

        private void cmdManageDataProcessingPurposes_Inquire(object sender, Fnd.Windows.Forms.FndCommandInquireEventArgs e)
        {
            #region Action
            if (Ifs.Fnd.ApplicationForms.Var.Security.IsMethodAvailable("DATA_SUBJECT_CONSENT_OPER_API.Consent_Action"))
                ((FndCommand)sender).Enabled = true;
            else
                ((FndCommand)sender).Enabled = false;
            #endregion
        }

        private void cmdManageDataProcessingPurposes_Execute(object sender, Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            #region Action
            DbPLSQLBlock(@"{0} := &AO.Data_Subject_Consent_API.Get_Subject_Key_Ref({1} IN,{2} IN, {3} IN);",
                this.QualifiedVarBindName("sDataSubjectKeyRef"), this.colsDataSubjectDb.QualifiedBindName, this.colsDataSubjectPart1.QualifiedBindName, this.colsDataSubjectPart2.QualifiedBindName);

            if (dlgPersonalDataConsent.ModalDialog(this, this.sDataSubjectKeyRef, this.colsDataSubjectDb.Text, this.colsDataSubjectName.Text) == Sys.IDOK)
            {
                DbPLSQLBlock(@"&AO.Data_Subject_Consent_Api.Get_Data_Subject_Analysis_Data({0}, {1}, {2}, {3}, {4}, {5});",
                                this.colsDataSubjectName.QualifiedBindName,
                                this.colPersonalDataConsentHistory.QualifiedBindName, 
                                this.colValidDataProcessingPurpose.QualifiedBindName,
                                this.colsDataSubjectDb.QualifiedBindName,
                                this.colsDataSubjectPart1.QualifiedBindName,
                                this.colsDataSubjectPart2.QualifiedBindName);
                return;
            }
            #endregion
        }
        #endregion

        #region Menu Event Handlers

        #endregion
    }
}
