#region Copyright (c) IFS Research & Development
// ======================================================================================================
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
// ======================================================================================================
#endregion
#region History
#endregion

using Ifs.Fnd.ApplicationForms;
using PPJ.Runtime;
using PPJ.Runtime.Windows;

namespace Ifs.Application.Enterp
{
	
	/// <summary>
	/// </summary>
	public class cLookupColumnTypeCode : cLookupColumn
	{
		#region Fields
		public SalBoolean __bDoLookUpInit = false;
		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		public cLookupColumnTypeCode()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
		}
		
		/// <summary>
		/// Multiple Inheritance: Constructor.
		/// </summary>
		/// <param name="derived"></param>
		public cLookupColumnTypeCode(ISalWindow derived)
		{
			// Attach derived instance.
			this._derived = derived;
			// This call is required by the Windows Form Designer.
			InitializeComponent();
			// Attach actions handler to derived instance.
			this._derived.AttachMessageActions(this);
		}
		#endregion
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// cLookupColumnTypeCode
			// 
			this.Name = "cLookupColumnTypeCode";
			this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cLookupColumnTypeCode_WindowActions);
		}
		#endregion
		
		#region Methods
		
		/// <summary>
		/// The LookupInit function populates the lookup column with
		/// the list possible values.
		/// COMMENTS:
		/// The framework implementation of LookupInit calls the
		/// Enumerate method specified in Foundation1 Properties.
		/// Applications may override LookupInit to initialize
		/// the lookup column in a different way.
		/// </summary>
        /// <param name="partyType"></param>
        public virtual void TypeCodeLookupInit(string partyType)
        {
            Ifs.Fnd.ApplicationForms.Var.g_Bind.Clear();
            Ifs.Fnd.ApplicationForms.Var.g_Bind.s[0] = partyType;
            if (!Ifs.Fnd.ApplicationForms.Var.g_Bind.DbPLSQLBlock("&AO.Address_Type_Code_API.Enumerate_Type( :g_Bind.s[1] OUT, :g_Bind.s[0] IN)"))
                return;

            // Save edit flag
            bool editFlag = this.Modified;
            // Populate list
            this.ClearList();
            foreach (SalString sValue in Ifs.Fnd.ApplicationForms.Var.g_Bind.s[1].Tokenize(Ifs.Fnd.ApplicationForms.Var.g_sCHAR_US, Ifs.Fnd.ApplicationForms.Var.g_sCHAR_US))
                this.AddListItem(sValue);

            // Restore edit flag
            this.SetModified(editFlag);
        }

		#endregion
		
		#region Window Actions
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void cLookupColumnTypeCode_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PM_LookupInit:
					e.Handled = true;
					this.__bDoLookUpInit = false;
					break;
			}
			#endregion
		}
		#endregion
		
		#region Multiple Inheritance Operators
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cLookupColumnTypeCode to type cEditControlsManager.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cEditControlsManager(cLookupColumnTypeCode self)
		{
			return self._cEditControlsManager;
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cLookupColumnTypeCode to type cSessionManager.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cSessionManager(cLookupColumnTypeCode self)
		{
			return ((cSessionManager)self._cEditControlsManager);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cEditControlsManager to type cLookupColumnTypeCode.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cLookupColumnTypeCode(cEditControlsManager super)
		{
			return ((cLookupColumnTypeCode)super._derived);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cSessionManager to type cLookupColumnTypeCode.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cLookupColumnTypeCode(cSessionManager super)
		{
			return ((cLookupColumnTypeCode)((cEditControlsManager)super._derived));
		}
		#endregion
		
		#region System Methods/Properties
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public new static cLookupColumnTypeCode FromHandle(SalWindowHandle handle)
		{
			return ((cLookupColumnTypeCode)SalWindow.FromHandle(handle, typeof(cLookupColumnTypeCode)));
		}
		#endregion
	}
}
