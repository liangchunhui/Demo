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
// Date     By      Notes
// -----    ------  ---------------------------------------------------------------------------------
// 121130   Pratlk  DANU-111, Added Master Company check box
// 121122   Charlk  DANU-137, Parallel currency implementation
#endregion

using System.Windows.Forms;
using Ifs.Fnd.ApplicationForms;
using PPJ.Runtime;
using PPJ.Runtime.Sql;
using PPJ.Runtime.Windows;
using PPJ.Runtime.Vis;

namespace Ifs.Application.Enterp
{
	
	/// <summary>
	/// </summary>
	public partial class frmCompanyInfo : cFormWindow
	{
		#region Window Variables
		public SalArray<SalNumber> nSelectedArray = new SalArray<SalNumber>();
		public SalNumber nSelected = 0;
		public SalNumber nCounter = 0;
		public SalString sText = "";
		#endregion
		
		#region Constructors/Destructors
		
		/// <summary>
		/// Default Constructor.
		/// </summary>
		public frmCompanyInfo()
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
		public new static frmCompanyInfo FromHandle(SalWindowHandle handle)
		{
			return ((frmCompanyInfo)SalWindow.FromHandle(handle, typeof(frmCompanyInfo)));
		}
		#endregion
		
		#region Methods
		
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public new SalNumber FrameActivate()
		{
			#region Actions
			using (new SalContext(this))
			{
				Sal.SetFocus(dfsCompanyId);
				dfsCompanyId.Text = dlgCreateCompany.FromHandle(i_hWndParent).dfsNewCompanyId.Text;
				dfsCompanyName.Text = dlgCreateCompany.FromHandle(i_hWndParent).dfsNewCompanyName.Text;
				if (dlgCreateCompany.FromHandle(i_hWndParent).rbUserDefined.Checked == true) 
				{
					dfsCalendarCreationMethod.Text = Properties.Resources.TEXT_UserDefined;
				}
				else
				{
					dfsCalendarCreationMethod.Text = Properties.Resources.TEXT_SourceCompTempl;
					using(SignatureHints hints = SignatureHints.NewContext())
					{
						hints.Add("Company_API.Get_Cal_Data", System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Output, System.Data.ParameterDirection.Input, System.Data.ParameterDirection.Input);
						DbPLSQLBlock(cSessionManager.c_hSql, "&AO.Company_API.Get_Cal_Data(:i_hWndParent.dlgCreateCompany.dfAccYear,\r\n" +
							"                                                                                                    :i_hWndParent.dlgCreateCompany.dfStartYear,\r\n" +
							"                                                                                                    :i_hWndParent.dlgCreateCompany.dfStartMonth,\r\n" +
							"                                                                                                    :i_hWndParent.dlgCreateCompany.dfNumberOfYears,\r\n" +
							"                                                                                                    :i_hWndParent.dlgCreateCompany.dfsSourceCompanyId,\r\n" +
							"                                                                                                    :i_hWndParent.dlgCreateCompany.dfsTemplateId)");
					}
				}
				dfAccYear.Number = dlgCreateCompany.FromHandle(i_hWndParent).dfAccYear.Number;
				dfStartYear.Number = dlgCreateCompany.FromHandle(i_hWndParent).dfStartYear.Number;
				dfStartMonth.Number = dlgCreateCompany.FromHandle(i_hWndParent).dfStartMonth.Number;
				dfNumberOfYears.Number = dlgCreateCompany.FromHandle(i_hWndParent).dfNumberOfYears.Number;
				dfsAccountingCurrency.Text = dlgCreateCompany.FromHandle(i_hWndParent).dfsAccountingCurrency.Text;
				dfsParallelCurrBase.Text = dlgCreateCompany.FromHandle(i_hWndParent).cmbParallelCurBase.Text;
				dfsParallelAccCurrency.Text = dlgCreateCompany.FromHandle(i_hWndParent).dfsParallelAccCurrency.Text;
				dfdtTimeStamp.DateTime = dlgCreateCompany.FromHandle(i_hWndParent).dfdtTimeStamp.DateTime;
				dfsCountry.Text = dlgCreateCompany.FromHandle(i_hWndParent).cmbCountry.Text;
				dfsDefaultLanguage.Text = dlgCreateCompany.FromHandle(i_hWndParent).cmbDefaultLanguage.Text;
				cbTemplateCompany.EditDataItemValueSet(0, Ifs.Fnd.ApplicationForms.Int.PalBooleanToStr(dlgCreateCompany.FromHandle(i_hWndParent).cbTemplateCompany.Checked).ToHandle());
				cbUsePeriod.EditDataItemValueSet(0, Ifs.Fnd.ApplicationForms.Int.PalBooleanToStr(dlgCreateCompany.FromHandle(i_hWndParent).cbUsePeriod.Checked).ToHandle());
				dfsTemplateId.Text = dlgCreateCompany.FromHandle(i_hWndParent).dfsTemplateId.Text;
				dfsMakeCompany.Text = "IMPORT";
				dfsSourceCompanyId.Text = dlgCreateCompany.FromHandle(i_hWndParent).dfsSourceCompanyId.Text;
                cbMasterCompany.EditDataItemValueSet(0, Ifs.Fnd.ApplicationForms.Int.PalBooleanToStr(dlgCreateCompany.FromHandle(i_hWndParent).cbMasterCompany.Checked).ToHandle());
				nSelected = Sal.ListQueryMultiCount(dlgCreateCompany.FromHandle(i_hWndParent).lbLanguages);
				if (nSelected > 0) 
				{
					Sal.ListGetMultiSelect(dlgCreateCompany.FromHandle(i_hWndParent).lbLanguages, nSelectedArray);
					mlSelectedLanguages.Text = Ifs.Fnd.ApplicationForms.Const.strNULL;
					nCounter = 0;
					while (nCounter < nSelected) 
					{
						sText = Vis.ListGetText(dlgCreateCompany.FromHandle(i_hWndParent).lbLanguages, nSelectedArray[nCounter]);
						mlSelectedLanguages.Text = mlSelectedLanguages.Text + sText + ";";
						nCounter = nCounter + 1;
					}
				}
                if (dlgCreateCompany.FromHandle(i_hWndParent).rbYes.Checked == true)
                {
                    dfsCurrBalCodePart.Text = dlgCreateCompany.FromHandle(i_hWndParent).dfsCodePart.Text;
                    dfsInternalName.Text = dlgCreateCompany.FromHandle(i_hWndParent).dfsInternalName.Text;
                }
                else if (dlgCreateCompany.FromHandle(i_hWndParent).rbNo.Checked == true)
                {
                    Sal.ClearField(dfsCurrBalCodePart);
                    Sal.ClearField(dfsInternalName);

                    Sal.DisableWindow(dfsCurrBalCodePart);
                    Sal.DisableWindow(dfsInternalName);
                }
				if (dlgCreateCompany.FromHandle(i_hWndParent).rbImportTemplate.Checked) 
				{
					dfsAction.Text = "NEW";
					return true;
				}
				if (dlgCreateCompany.FromHandle(i_hWndParent).rbCopyCompany.Checked) 
				{
					dfsAction.Text = "DUPLICATE";
					return true;
				}                
			}

			return 0;
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="lsAttrVar"></param>
		/// <returns></returns>
		public virtual SalString BuildAttr(ref SalString lsAttrVar)
		{
			#region Actions
			using (new SalContext(this))
			{
				lsAttrVar = Ifs.Fnd.ApplicationForms.Const.strNULL;
                		if (dfdtTimeStamp.Text.Equals(Ifs.Fnd.ApplicationForms.Const.strNULL))
                		{
                    		   dfdtTimeStamp.DateTime = dlgCreateCompany.FromHandle(i_hWndParent).dfdtValidFrom.DateTime;
                		}
				Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("COMPANY", dfsCompanyId.Text, ref lsAttrVar);
				Ifs.Fnd.ApplicationForms.Int.PalAttrAddDate("VALID_FROM", dfdtTimeStamp.DateTime, ref lsAttrVar);
				Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("CURRENCY_CODE", dfsAccountingCurrency.Text, ref lsAttrVar);
				Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("PARALLEL_ACC_CURRENCY", dfsParallelAccCurrency.Text, ref lsAttrVar);
				Ifs.Fnd.ApplicationForms.Int.PalAttrAddDate("PAR_ACC_CURR_VALID_FROM", dfdtTimeStamp.DateTime, ref lsAttrVar);
				if (dlgCreateCompany.FromHandle(i_hWndParent).cbUsePeriod.Checked == true) 
				{
					Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("USE_VOU_NO_PERIOD", "TRUE", ref lsAttrVar);
				}
				else
				{
					Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("USE_VOU_NO_PERIOD", Ifs.Fnd.ApplicationForms.Int.PalBooleanToStr(cbUsePeriod.Checked), ref lsAttrVar);
				}
				return lsAttrVar;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="lsAttrVar1"></param>
		/// <returns></returns>
		public virtual SalString BuildAttr1(ref SalString lsAttrVar1)
		{
			#region Actions
			using (new SalContext(this))
			{
				lsAttrVar1 = Ifs.Fnd.ApplicationForms.Const.strNULL;
				Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("NEW_COMPANY", dfsCompanyId.Text, ref lsAttrVar1);
				Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("PROCESS", "ONLINE", ref lsAttrVar1);
				return lsAttrVar1;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="lsAttrVarEnt"></param>
		/// <returns></returns>
		public virtual SalString BuildAttrEnt(ref SalString lsAttrVarEnt)
		{
			#region Actions
			using (new SalContext(this))
			{
				lsAttrVarEnt = Ifs.Fnd.ApplicationForms.Const.strNULL;
				Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("COMPANY", dfsCompanyId.Text, ref lsAttrVarEnt);
				Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("NAME", dfsCompanyName.Text, ref lsAttrVarEnt);
				Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("DEFAULT_LANGUAGE", dfsDefaultLanguage.Text, ref lsAttrVarEnt);
				Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("COUNTRY", dfsCountry.Text, ref lsAttrVarEnt);
				if (cbTemplateCompany.Checked) 
				{
					Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("TEMPLATE_COMPANY", "TRUE", ref lsAttrVarEnt);
				}
				else
				{
					Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("TEMPLATE_COMPANY", "FALSE", ref lsAttrVarEnt);
				}
				Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("FROM_COMPANY", dfsSourceCompanyId.Text, ref lsAttrVarEnt);
				Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("FROM_TEMPLATE_ID", dfsTemplateId.Text, ref lsAttrVarEnt);
				return lsAttrVarEnt;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="lsAttrVarEnt"></param>
		/// <returns></returns>
		public virtual SalString BuildAttrEnt1(ref SalString lsAttrVarEnt)
		{
			#region Actions
			using (new SalContext(this))
			{
				lsAttrVarEnt = Ifs.Fnd.ApplicationForms.Const.strNULL;
				Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("FROM_COMPANY", dfsSourceCompanyId.Text, ref lsAttrVarEnt);
				Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("FROM_TEMPLATE_ID", dfsTemplateId.Text, ref lsAttrVarEnt);
				return lsAttrVarEnt;
			}
			#endregion
		}
		
		/// <summary>
		/// </summary>
		/// <param name="lsAttrVar"></param>
		/// <returns></returns>
		public virtual SalString BuildAttrModule(ref SalString lsAttrVar)
		{
			#region Actions
			using (new SalContext(this))
			{
				lsAttrVar = Ifs.Fnd.ApplicationForms.Const.strNULL;
                		if (dfdtTimeStamp.Text.Equals(Ifs.Fnd.ApplicationForms.Const.strNULL))
                		{
                    		   dfdtTimeStamp.DateTime = dlgCreateCompany.FromHandle(i_hWndParent).dfdtValidFrom.DateTime;
                		}
				Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("NEW_COMPANY", dfsCompanyId.Text, ref lsAttrVar);
				Ifs.Fnd.ApplicationForms.Int.PalAttrAddDate("VALID_FROM", dfdtTimeStamp.DateTime, ref lsAttrVar);
				Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("ACTION", dfsAction.Text, ref lsAttrVar);
				Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("TEMPLATE_ID", dfsTemplateId.Text, ref lsAttrVar);
				Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("DUPL_COMPANY", dfsSourceCompanyId.Text, ref lsAttrVar);
				Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("MAKE_COMPANY", dfsMakeCompany.Text, ref lsAttrVar);
				// complete with all other parameters to create an attribute string with all parameters when creating the company
				// some final attributes are added before calling Company_API.New_Company. See dlgCreateCompany.
				// the creation parameters are used by some LU's, especially LU CompanyFinance and UserFinance
				Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("CURRENCY_CODE", dfsAccountingCurrency.Text, ref lsAttrVar);
				Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("PARALLEL_ACC_CURRENCY", dfsParallelAccCurrency.Text, ref lsAttrVar);
				Ifs.Fnd.ApplicationForms.Int.PalAttrAddDate("PAR_ACC_CURR_VALID_FROM", dfdtTimeStamp.DateTime, ref lsAttrVar);
				if (SalString.FromHandle(cbUsePeriod.EditDataItemValueGet()) == "TRUE") 
				{
					Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("USE_VOU_NO_PERIOD", "TRUE", ref lsAttrVar);
				}
				else
				{
					Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("USE_VOU_NO_PERIOD", "FALSE", ref lsAttrVar);
				}
				Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("NAME", dfsCompanyName.Text, ref lsAttrVar);
				if (cbTemplateCompany.Checked) 
				{
					Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("TEMPLATE_COMPANY", "TRUE", ref lsAttrVar);
				}
				else
				{
					Ifs.Fnd.ApplicationForms.Int.PalAttrAdd("TEMPLATE_COMPANY", "FALSE", ref lsAttrVar);
				}
				return lsAttrVar;
			}
			#endregion
		}
		#endregion
		
		#region Late Bind Methods
		
		/// <summary>
		/// Virtual wrapper replacement for late-bound (..) calls.
		/// </summary>
		public override SalNumber vrtFrameActivate()
		{
			return this.FrameActivate();
		}
		#endregion
	}
}
