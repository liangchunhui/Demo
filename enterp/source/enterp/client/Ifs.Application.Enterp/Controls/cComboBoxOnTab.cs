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
	public class cComboBoxOnTab : cComboBox
	{
		// Multiple Inheritance: Base class instance.
		protected cGeneralObjectOnTab _cGeneralObjectOnTab;
		
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		public cComboBoxOnTab()
		{
			// Initialize second-base instances.
			InitializeMultipleInheritance();
			// This call is required by the Windows Form Designer.
			InitializeComponent();
		}
		
		/// <summary>
		/// Multiple Inheritance: Constructor.
		/// </summary>
		/// <param name="derived"></param>
		public cComboBoxOnTab(ISalWindow derived)
		{
			// Attach derived instance.
			this._derived = derived;
			// Initialize second-base instances.
			InitializeMultipleInheritance();
			// This call is required by the Windows Form Designer.
			InitializeComponent();
			// Attach actions handler to derived instance.
			this._derived.AttachMessageActions(this);
		}
		#endregion
		
		#region Multiple Inheritance Fields
		[Browsable(false)]
		[DesignerSerializationVisibility(0)]
		public SalBoolean i__bHidden
		{
			get { return _cGeneralObjectOnTab.i__bHidden; }
			set { _cGeneralObjectOnTab.i__bHidden = value; }
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
			// cComboBoxOnTab
			// 
			this.Name = "cComboBoxOnTab";
		}
		#endregion
		
		#region Multiple Inheritance Methods
		#endregion
		
		#region Multiple Inheritance Operators
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cComboBoxOnTab to type cEditControlsManager.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cEditControlsManager(cComboBoxOnTab self)
		{
			return self._cEditControlsManager;
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cComboBoxOnTab to type cSessionManager.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cSessionManager(cComboBoxOnTab self)
		{
			return ((cSessionManager)self._cEditControlsManager);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cComboBoxOnTab to type cResize.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cResize(cComboBoxOnTab self)
		{
			return self._cResize;
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cComboBoxOnTab to type cGeneralObjectOnTab.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cGeneralObjectOnTab(cComboBoxOnTab self)
		{
			return self._cGeneralObjectOnTab;
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cEditControlsManager to type cComboBoxOnTab.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cComboBoxOnTab(cEditControlsManager super)
		{
			return ((cComboBoxOnTab)super._derived);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cSessionManager to type cComboBoxOnTab.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cComboBoxOnTab(cSessionManager super)
		{
			return ((cComboBoxOnTab)((cEditControlsManager)super._derived));
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cResize to type cComboBoxOnTab.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cComboBoxOnTab(cResize super)
		{
			return ((cComboBoxOnTab)((cEditControlsManager)super._derived));
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cGeneralObjectOnTab to type cComboBoxOnTab.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cComboBoxOnTab(cGeneralObjectOnTab super)
		{
			return ((cComboBoxOnTab)super._derived);
		}
		#endregion
		
		#region System Methods/Properties
		
		/// <summary>
		/// Multiple Inheritance: Initialize delegate instances.
		/// </summary>
		private void InitializeMultipleInheritance()
		{
			this._cGeneralObjectOnTab = new cGeneralObjectOnTab(this);
		}
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public new static cComboBoxOnTab FromHandle(SalWindowHandle handle)
		{
			return ((cComboBoxOnTab)SalWindow.FromHandle(handle, typeof(cComboBoxOnTab)));
		}
		#endregion
	}
}
