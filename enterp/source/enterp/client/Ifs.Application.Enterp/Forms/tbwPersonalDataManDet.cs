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

namespace Ifs.Application.Enterp
{

    /// <summary>
    /// </summary>
    /// 
    [FndWindowRegistration("PERSONAL_DATA_MAN_DET", "PersonalDataManDet")]
    public partial class tbwPersonalDataManDet : cTableWindow
    {
        #region Member Variables
        protected SalNumber nPersDataManagementId = 0;
        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public tbwPersonalDataManDet()
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
        public new static tbwPersonalDataManDet FromHandle(SalWindowHandle handle)
        {
            return ((tbwPersonalDataManDet)SalWindow.FromHandle(handle, typeof(tbwPersonalDataManDet)));
        }

        #endregion

        #region Properties

        #endregion

        #region Methods

        /// <summary>
        /// The framework calls the DataRecordGetDefaults function to retrive
        /// client default values for new records.
        /// </summary>
        /// <returns>The return value is TRUE if default values were sucessfully retrived, FALSE otherwise.</returns>
        public new SalBoolean DataRecordGetDefaults()
        {
            #region Actions
            using (new SalContext(this))
            {
                this.colnPersDataManagementId.Number = nPersDataManagementId;
                this.colnPersDataManagementId.EditDataItemSetEdited();
            }

            return false;
            #endregion
        }

        /// <summary>
        /// </summary>
        /// <param name="sDataItem"></param>
        /// <returns></returns>
        public virtual SalString FetchTransferredData(SalString sDataItem)
        {
            #region Local Variables
            SalNumber nIndex = 0;
            SalNumber nIndexTotalRows = 0;
            SalNumber nRowNo = 0;
            SalString sTemp = "";
            SalString sSearch = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                sSearch = SalString.Null;
                nIndexTotalRows = Ifs.Fnd.ApplicationForms.Var.DataTransfer.RecCountGet();
                nIndex = Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemIndexGet(sDataItem);
                nRowNo = 0;
                if (nIndex >= 0)
                {
                    while (nRowNo <= nIndexTotalRows - 1)
                    {
                        Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemValueStrGet(nIndex, nRowNo, ref sTemp);
                        sSearch = sTemp;
                        nRowNo = nRowNo + 1;
                    }
                }
                return sSearch;
            }
            #endregion
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Virtual wrapper replacement for late-bound (..) calls.
        /// </summary>
        public override SalBoolean vrtDataRecordGetDefaults()
        {
            return this.DataRecordGetDefaults();
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override SalNumber vrtActivate(fcURL URL)
        {
            #region Local Variables
            SalString sTitle = "";
            SalString sTempCompany = "";
            #endregion

            #region Actions
            using (new SalContext(this))
            {
                if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.RecCountGet() > 0)
                {
                    nPersDataManagementId = FetchTransferredData("PERS_DATA_MANAGEMENT_ID").ToNumber();
                    Sal.WaitCursor(true);
                    InitFromTransferedData();
                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();
                    Sal.WaitCursor(false);
                }
                else
                {
                    return base.Activate(URL);
                }
                return 0;
            }
            #endregion
        }

        #endregion

        #region Window Actions

        #endregion

        #region Event Handlers

        #endregion

        #region Menu Event Handlers

        #endregion

    }
}
