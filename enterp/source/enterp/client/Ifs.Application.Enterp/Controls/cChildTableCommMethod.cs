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
//2012-01-04  Janblk EDEL-214,Removed items from enumeration depending on party type
//2013-09-02  Machlk Bug 111816, Filter the warnings only for new/modified records.
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
	public partial class cChildTableCommMethod : cChildTable
	{
		#region Fields
        public SalString sAttr = "";
		public SalString sNoDefMethodList = "";
		public SalString sNoDefAddList = "";
		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		public cChildTableCommMethod()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
		}
		
		/// <summary>
		/// Multiple Inheritance: Constructor.
		/// </summary>
		/// <param name="derived"></param>
		public cChildTableCommMethod(ISalWindow derived)
		{
			// Attach derived instance.
			this._derived = derived;
			// This call is required by the Windows Form Designer.
			InitializeComponent();
			// Attach actions handler to derived instance.
			this._derived.AttachMessageActions(this);
		}
		#endregion
		
		#region Methods
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public virtual SalNumber CheckDefault()
		{
			#region Local Variables
            SalNumber nOldRow = 0;
            SalNumber nCurrentRow = 0;
			SalArray<SalString> sDefMethList = new SalArray<SalString>(1);
			SalArray<SalString> sDefAddList = new SalArray<SalString>(2);
			SalString sMethId = "";
			SalString sAddId = "";
			#endregion
			
			#region Actions
			using (new SalContext(this))
			{
                nOldRow = Sal.TblQueryContext(this);
                nCurrentRow = Sys.TBL_MinRow;
                sAttr = SalString.Null;
                while (Sal.TblFindNextRow(this, ref nCurrentRow, Sys.ROW_Edited, 0))
                {
                    Sal.TblSetContext(this, nCurrentRow);
                    Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("ROW_ID", __colObjid.Text, ref sAttr);
                    Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("METHOD_ID", colsMethodId.Text, ref sAttr);
                    Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("ADDRESS_ID", colsAddressId.Text, ref sAttr);
                    if (colsPrevAddrId.Text == SalString.Null && colsAddressId.Text != SalString.Null)
                    {
                        colsPrevAddrId.Text = colsAddressId.Text;
                    }
                    Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("PREV_ADDRESS_ID", colsPrevAddrId.Text, ref sAttr);
                    Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("METHOD_DEFAULT", colMethodDefault.Text, ref sAttr);
                    Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("ADDRESS_DEFAULT", colAddressDefault.Text, ref sAttr);
                    if (coldValidFrom.DateTime != Sys.DATETIME_Null)
                    {
                        Ifs.Fnd.ApplicationForms.Int.PalAttrAddDate("VALID_FROM", coldValidFrom.DateTime, ref sAttr);
                    }
                    if (coldValidTo.DateTime != Sys.DATETIME_Null)
                    {
                        Ifs.Fnd.ApplicationForms.Int.PalAttrAddDate("VALID_TO", coldValidTo.DateTime, ref sAttr);
                    }
                    Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("END_MODIFY", SalString.Null, ref sAttr);
                }
                while (Sal.TblFindNextRow(this, ref nCurrentRow, Sys.ROW_MarkDeleted, 0))
                {
                    Sal.TblSetContext(this, nCurrentRow);
                    Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("ROW_ID", __colObjid.Text, ref sAttr);
                    Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("METHOD_ID", colsMethodId.Text, ref sAttr);
                    Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("ADDRESS_ID", colsAddressId.Text, ref sAttr);
                    Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("METHOD_DEFAULT", colMethodDefault.Text, ref sAttr);
                    Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("ADDRESS_DEFAULT", colAddressDefault.Text, ref sAttr);
                    if (coldValidFrom.DateTime != Sys.DATETIME_Null)
                    {
                        Ifs.Fnd.ApplicationForms.Int.PalAttrAddDate("VALID_FROM", coldValidFrom.DateTime, ref sAttr);
                    }
                    if (coldValidTo.DateTime != Sys.DATETIME_Null)
                    {
                        Ifs.Fnd.ApplicationForms.Int.PalAttrAddDate("VALID_TO", coldValidTo.DateTime, ref sAttr);
                    }
                    Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("END_DELETE", SalString.Null, ref sAttr);
                }
                Sal.TblSetContext(this, nOldRow);
                if (sAttr != SalString.Null)
                {
                    sNoDefMethodList = Ifs.Fnd.ApplicationForms.Const.strNULL;
                    sNoDefAddList = Ifs.Fnd.ApplicationForms.Const.strNULL;
                    sDefMethList[0] = Ifs.Fnd.ApplicationForms.Const.strNULL;
                    sDefAddList[0] = Ifs.Fnd.ApplicationForms.Const.strNULL;
                    using (SignatureHints hints = SignatureHints.NewContext())
                    {
                        hints.Add("Comm_Method_API.Check_Default", System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
                        if (!(DbPLSQLBlock(cSessionManager.c_hSql, "&AO.Comm_Method_API.Check_Default (:i_hWndSelf.cChildTableCommMethod.sNoDefMethodList,\r\n" +
                            "                                                                          :i_hWndSelf.cChildTableCommMethod.sNoDefAddList,\r\n" +
                            "                                                                          :i_hWndSelf.cChildTableCommMethod.sAttr,\r\n" +
                            "                                                                          :i_hWndSelf.cChildTableCommMethod.colsPartyTypeDb,\r\n" +
                            "                                                                          :i_hWndSelf.cChildTableCommMethod.colsIdentity  )")))
                        {
                            return false;
                        }
                    }
                }
				while (sNoDefMethodList != Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					sMethId = Ifs.Fnd.ApplicationForms.Int.PalStrSplitLeft(sNoDefMethodList, ((SalNumber)31).ToCharacter());
					sNoDefMethodList = Ifs.Fnd.ApplicationForms.Int.PalStrSplitRight(sNoDefMethodList, ((SalNumber)31).ToCharacter());
					sDefMethList[0] = sMethId;
					if (Ifs.Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.QUESTION_NotMethDefaultSet, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Question, (Ifs.Fnd.ApplicationForms.Const.QUESTION_YesNo | Sys.MB_DefButton2), sDefMethList) != 
					Sys.IDYES) 
					{
						return false;
					}
				}
				while (sNoDefAddList != Ifs.Fnd.ApplicationForms.Const.strNULL) 
				{
					sMethId = Ifs.Fnd.ApplicationForms.Int.PalStrSplitLeft(sNoDefAddList, ((SalNumber)31).ToCharacter());
					sNoDefAddList = Ifs.Fnd.ApplicationForms.Int.PalStrSplitRight(sNoDefAddList, ((SalNumber)31).ToCharacter());
					sAddId = Ifs.Fnd.ApplicationForms.Int.PalStrSplitLeft(sNoDefAddList, ((SalNumber)30).ToCharacter());
					sNoDefAddList = Ifs.Fnd.ApplicationForms.Int.PalStrSplitRight(sNoDefAddList, ((SalNumber)30).ToCharacter());
					sDefAddList[0] = sMethId;
					sDefAddList[1] = sAddId;
					if (Ifs.Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.QUESTION_NotAddDefaultSet, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Question, (Ifs.Fnd.ApplicationForms.Const.QUESTION_YesNo | Sys.MB_DefButton2), sDefAddList) != 
					Sys.IDYES) 
					{
						return false;
					}
				}
				return true;
			}
			#endregion
		}
		// Description:
		// Returns
		// Parameters
		// : PSheetList
		// Receive String: sTitle
		// Static Variables
		// Local variables
		// Actions
		// Add Window sheet
		// Call PSheetList.Add( 'dlgPSheetDataSource', PSHEET_DataSource, strNULL )
		// Add standard sheets for ChildTable
		// Call cChildTable.PSheetPrepare( PSheetList, sTitle )
		/// <summary>
		/// </summary>
		/// <param name="PSheetList"></param>
		/// <param name="sTitle"></param>
		/// <returns></returns>
		public new SalNumber PSheetPrepare(cPSheetList PSheetList, ref SalString sTitle)
		{
			#region Actions
			using (new SalContext(this))
			{
				// Add Window sheet
				PSheetList.Add(Pal.GetActiveInstanceName("dlgPSheetDataSource"), Ifs.Fnd.ApplicationForms.Properties.Resources.PSHEET_DataSource);
				// Add standard sheets for ChildTable
				((cChildTable)this).PSheetPrepare(PSheetList, ref sTitle);
			}

			return 0;
			#endregion
		}
		#endregion
		
		#region Multiple Inheritance Operators
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cChildTableCommMethod to type cTableManager.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cTableManager(cChildTableCommMethod self)
		{
			return self._cTableManager;
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cChildTableCommMethod to type cSessionManager.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cSessionManager(cChildTableCommMethod self)
		{
			return ((cSessionManager)self._cTableManager);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cChildTableCommMethod to type cWindowTranslation.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cWindowTranslation(cChildTableCommMethod self)
		{
			return ((cWindowTranslation)self._cTableManager);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cChildTableCommMethod to type cResize.
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		public static implicit operator cResize(cChildTableCommMethod self)
		{
			return self._cResize;
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cTableManager to type cChildTableCommMethod.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cChildTableCommMethod(cTableManager super)
		{
			return ((cChildTableCommMethod)super._derived);
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cSessionManager to type cChildTableCommMethod.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cChildTableCommMethod(cSessionManager super)
		{
			return ((cChildTableCommMethod)((cTableManager)super._derived));
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cWindowTranslation to type cChildTableCommMethod.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cChildTableCommMethod(cWindowTranslation super)
		{
			return ((cChildTableCommMethod)((cTableManager)super._derived));
		}
		
		/// <summary>
		/// Multiple Inheritance: Cast operator from type cResize to type cChildTableCommMethod.
		/// </summary>
		/// <param name="super"></param>
		/// <returns></returns>
		public static implicit operator cChildTableCommMethod(cResize super)
		{
			return ((cChildTableCommMethod)((cTableManager)super._derived));
		}
		#endregion
		
		#region System Methods/Properties
		
		/// <summary>
		/// Returns the object instance associated with the window handle.
		/// </summary>
		/// <param name="handle"></param>
		/// <returns></returns>
		public new static cChildTableCommMethod FromHandle(SalWindowHandle handle)
		{
			return ((cChildTableCommMethod)SalWindow.FromHandle(handle, typeof(cChildTableCommMethod)));
		}
		#endregion
		
		#region Late Bind Methods
		
		/// <summary>
		/// Virtual wrapper replacement for late-bound (..) calls.
		/// </summary>
		public override SalNumber vrtPSheetPrepare(cPSheetList PSheetList, ref SalString sTitle)
		{
			LateBind lateBind = (LateBind)this._derived;
			if (lateBind == null) 
			{
				return this.PSheetPrepare(PSheetList, ref sTitle);
			}
			else
			{
				return lateBind.vrtPSheetPrepare(PSheetList, ref sTitle);
			}
		}
		#endregion
		
		#region Multiple Inheritance Late Bind Interface
		
		public interface LateBind
		{
			SalNumber vrtPSheetPrepare(cPSheetList PSheetList, ref SalString sTitle);
		}
		#endregion

        #region Windows Events
        private void colsMethodId_WindowActions(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            switch (e.ActionType)
            {
                case Ifs.Fnd.ApplicationForms.Const.PM_LookupInit:
                    e.Handled = true;
                    this.colsMethodId_OnPM_LookupInit(sender, e);
                    break;
            }
            #endregion
        }

        private void colsMethodId_OnPM_LookupInit(object sender, WindowActionsEventArgs e)
        {
            #region Actions
            e.Handled = true;
            if (Sal.SendClassMessage(Ifs.Fnd.ApplicationForms.Const.PM_LookupInit, Sys.wParam, Sys.lParam))
            {
                if (this.colsPartyTypeDb.Text != "COMPANY")
                {
                    Sal.ListDelete(this.colsMethodId, 3);
                }
                e.Return = true;
                return;
            }
            e.Return = false;
            return;
            #endregion
        }

        #endregion




    }
}
