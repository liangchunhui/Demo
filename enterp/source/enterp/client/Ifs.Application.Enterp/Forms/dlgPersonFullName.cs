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
// 131024   MaRalk  PBR-1748, Added method ValidatePersonFullName and modified commandOk_Execute.
// 130515   MaRalk  PBR-1602, Created.
#endregion

using System.Diagnostics;
using System.Windows.Forms;
using Ifs.Fnd.ApplicationForms;
using PPJ.Runtime;
using PPJ.Runtime.Windows;


namespace Ifs.Application.Enterp
{

    /// <summary>
    /// </summary>
    public partial class dlgPersonFullName : cDialog
    {
        #region Member Variables

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Default Constructor.
        /// </summary>
        protected dlgPersonFullName()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();
        }
        #endregion

        #region System Methods/Properties

        /// <summary>
        /// Shows the modal dialog.
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        public static SalNumber ModalDialog(Control owner)
        {
            dlgPersonFullName dlg = DialogFactory.CreateInstance<dlgPersonFullName>();
            SalNumber ret = dlg.ShowDialog(owner);
            return ret;
        }

        /// <summary>
        /// Returns the object instance associated with the window handle.
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public new static dlgPersonFullName FromHandle(SalWindowHandle handle)
        {
            return ((dlgPersonFullName)SalWindow.FromHandle(handle, typeof(dlgPersonFullName)));
        }
        #endregion

        #region Properties

        #endregion

        #region Methods
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public new SalBoolean FrameStartupUser()
        {
            #region Actions
            using (new SalContext(this))
            {
                if (Ifs.Fnd.ApplicationForms.Var.DataTransfer.RecCountGet() > 0)
                {
                    SalArray<SalString> items = new SalArray<SalString>();

                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("TITLE", items);
                    dfsTitle.Text = items[0];

                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("INITIALS", items);
                    dfsInitials.Text = items[0];

                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("FIRST_NAME", items);
                    dfsFirstName.Text = items[0];

                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("MIDDLE_NAME", items);
                    dfsMiddleName.Text = items[0];

                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.ItemGet("LAST_NAME", items);
                    dfsLastName.Text = items[0];

                    Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();

                }

                return base.vrtFrameStartupUser();

            }
            #endregion
        }

        protected virtual void PrepareDataTransfer()
        {
            Ifs.Fnd.ApplicationForms.Var.DataTransfer.Reset();

            SalArray<SalString> itemNames = new SalArray<SalString>() { "TITLE", "INITIALS", "FIRST_NAME", "MIDDLE_NAME", "LAST_NAME" };
            SalArray<SalWindowHandle> itemHandles = new SalArray<SalWindowHandle>() { dfsTitle, dfsInitials, dfsFirstName, dfsMiddleName, dfsLastName };
            Ifs.Fnd.ApplicationForms.Var.DataTransfer.Init("PersonInfo", this, itemNames, itemHandles);
        }

        /// <summary>
        /// Calculate total length of the name field and raise a error if it exceeds 100.
        /// </summary>
        /// <returns></returns>
        protected virtual SalBoolean ValidatePersonFullName()
        {
            #region Local Variables
            SalString sFullName = "";
            #endregion

            #region Actions
            if (dfsFirstName.Text != Ifs.Fnd.ApplicationForms.Const.strNULL)
            {
                sFullName = dfsFirstName.Text;
            }
            if (dfsMiddleName.Text != Ifs.Fnd.ApplicationForms.Const.strNULL)
            {
                if (sFullName != Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    sFullName = SalString.Concat(sFullName, SalString.Concat(" ", dfsMiddleName.Text));
                }
                else
                {
                    sFullName = dfsMiddleName.Text;
                }
            }
            if (dfsLastName.Text != Ifs.Fnd.ApplicationForms.Const.strNULL)
            {
                if (sFullName != Ifs.Fnd.ApplicationForms.Const.strNULL)
                {
                    sFullName = SalString.Concat(sFullName, SalString.Concat(" ", dfsLastName.Text));
                }
                else
                {
                    sFullName = dfsLastName.Text;
                }
            }
            if (sFullName.Length > 100)
            {
                Ifs.Fnd.ApplicationForms.Int.AlertBox(Properties.Resources.TEXT_NameLengthNotAllowed, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Error, Ifs.Fnd.ApplicationForms.Const.CRITICAL_Ok);
                return false;
            }
            else
            {
                return true;
            }
            #endregion

        }

        #endregion

        #region Overrides
        public override SalBoolean vrtFrameStartupUser()
        {
            return this.FrameStartupUser();
        }
        #endregion

        #region Window Actions

        #endregion

        #region Event Handlers


        private void commandOk_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            // Dialog class have AcceptButton set to run this logic if the user ends the dialog using the Return button.
            // PPJ dialog close trough Sal.EndDialog so we set DialogResult to prevent the dialog from closing premature.
            DialogResult = DialogResult.None;
            if (ValidatePersonFullName())
            {
                PrepareDataTransfer();
                Sal.EndDialog(this, Sys.IDOK);
            }
        }


        private void commandCancel_Execute(object sender, Ifs.Fnd.Windows.Forms.FndCommandExecuteEventArgs e)
        {
            // Dialog class have CancelButton set to run this logic even if the user close the dialog trough the esc button.
            // PPJ dialog close trough Sal.EndDialog so we set DialogResult to prevent the dialog from closing premature.
            DialogResult = DialogResult.None;

            Sal.EndDialog(this, Sys.IDCANCEL);
        }

        #endregion

        #region Menu Event Handlers

        #endregion
    }
}
