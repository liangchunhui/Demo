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

using System;
using System.Text;
using System.Drawing;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel;
using Ifs.Application.Appsrv;
using Ifs.Fnd.ApplicationForms;
using PPJ.Runtime;
using PPJ.Runtime.Sql;
using PPJ.Runtime.Vis;
using PPJ.Runtime.Windows;
using PPJ.Runtime.Windows.QO;

namespace Ifs.Application.Enterp
{
	
	/// <summary>
	/// </summary>
	public class cGeneralObjectOnTab : SalGeneralWindow
	{
		#region Fields
		public SalBoolean i__bHidden = false;
		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		public cGeneralObjectOnTab()
		{
			// Attach MessageActions handler
			this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cGeneralObjectOnTab_WindowActions);
		}
		
		/// <summary>
		/// Multiple Inheritance: Constructor.
		/// </summary>
		/// <param name="derived"></param>
		public cGeneralObjectOnTab(ISalWindow derived)
		{
			// Attach derived instance.
			this._derived = derived;
			// Attach MessageActions handler
			this.WindowActions += new PPJ.Runtime.Windows.WindowActionsEventHandler(this.cGeneralObjectOnTab_WindowActions);
			// Attach actions handler to derived instance.
			this._derived.AttachMessageActions(this);
		}
		#endregion
		
		#region Window Actions
		
		/// <summary>
		/// Window Actions
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">An <see ref="PPJ.Runtime.WindowActionsEventArgs"/> that contains the event data.</param>
		private void cGeneralObjectOnTab_WindowActions(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			switch (e.ActionType)
			{
				case Ifs.Fnd.ApplicationForms.Const.PAM_User:
					this.cGeneralObjectOnTab_OnPAM_User(sender, e);
					break;
			}
			#endregion
		}
		
		/// <summary>
		/// PAM_User event handler.
		/// </summary>
		/// <param name="message"></param>
		private void cGeneralObjectOnTab_OnPAM_User(object sender, WindowActionsEventArgs e)
		{
			#region Actions
			e.Handled = true;
			if (Sys.wParam == Const.METHOD_ShowHide) 
			{
				if (Sys.lParam == 0 || this.i__bHidden) 
				{
					Sal.HideWindowAndLabel(Sys.hWndItem);
				}
				else
				{
					Sal.ShowWindowAndLabel(Sys.hWndItem);
				}
			}
			if (Sys.wParam == Const.METHOD_Hide) 
			{
				this.i__bHidden = true;
				Sal.HideWindowAndLabel(Sys.hWndItem);
			}
			#endregion
		}
		#endregion
		
		#region System Methods/Properties
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public static cGeneralObjectOnTab FromHandle(SalWindowHandle handle)
		{
			return ((cGeneralObjectOnTab)SalWindow.FromHandle(handle, typeof(cGeneralObjectOnTab)));
		}
		#endregion
	}
}
