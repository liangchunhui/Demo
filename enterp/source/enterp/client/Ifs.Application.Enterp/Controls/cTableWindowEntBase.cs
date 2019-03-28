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
	public partial class cTableWindowEntBase : cTableWindow
	{
		#region Fields
		public SalString i_sReportCompany = "";
		public SalString i_sTempReportCompany = "";
		public SalString i_sCompanyName = "";
		public SalString i_sCompanyLogoPath = "";
		public SalString i_sLogoData = "";
		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		public cTableWindowEntBase()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
		}
		
		/// <summary>
		/// Multiple Inheritance: Constructor.
		/// </summary>
		/// <param name="derived"></param>
		public cTableWindowEntBase(ISalWindow derived)
		{
			// Attach derived instance.
			this._derived = derived;
			// This call is required by the Windows Form Designer.
			InitializeComponent();
			// Attach actions handler to derived instance.
			this._derived.AttachMessageActions(this);
		}
		#endregion
		
		#region Multiple Inheritance Operators
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cTableWindowEntBase to type cTableManager.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cTableManager(cTableWindowEntBase self)
		{
			return self._cTableManager;
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cTableWindowEntBase to type cSessionManager.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cSessionManager(cTableWindowEntBase self)
		{
			return ((cSessionManager)self._cTableManager);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cTableWindowEntBase to type cWindowTranslation.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cWindowTranslation(cTableWindowEntBase self)
		{
			return ((cWindowTranslation)self._cTableManager);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cTableWindowEntBase to type SalToolTipManager.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator SalToolTipManager(cTableWindowEntBase self)
		{
			return self._SalToolTipManager;
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cTableManager to type cTableWindowEntBase.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cTableWindowEntBase(cTableManager super)
		{
			return ((cTableWindowEntBase)super._derived);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cSessionManager to type cTableWindowEntBase.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cTableWindowEntBase(cSessionManager super)
		{
			return ((cTableWindowEntBase)((cTableManager)super._derived));
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cWindowTranslation to type cTableWindowEntBase.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cTableWindowEntBase(cWindowTranslation super)
		{
			return ((cTableWindowEntBase)((cTableManager)super._derived));
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type SalToolTipManager to type cTableWindowEntBase.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cTableWindowEntBase(SalToolTipManager super)
		{
			return ((cTableWindowEntBase)((cTableManager)super._derived));
		}
		#endregion
		
		#region System Methods/Properties
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public new static cTableWindowEntBase FromHandle(SalWindowHandle handle)
		{
			return ((cTableWindowEntBase)SalWindow.FromHandle(handle, typeof(cTableWindowEntBase)));
		}
		#endregion
	}
}
