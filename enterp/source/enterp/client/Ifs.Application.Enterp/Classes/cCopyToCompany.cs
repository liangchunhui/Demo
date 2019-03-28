using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ifs.Fnd.ApplicationForms;
using PPJ.Runtime;
using PPJ.Runtime.Windows;
using PPJ.Runtime.Vis;
using System.Windows.Forms;

namespace Ifs.Application.Enterp.Classes
{
    public class cCopyToCompany
    {
        #region Member Variables
        private static SalString _sRunInBackground          = "";
        private static SalArray<SalString> _sCompanyList    = new SalArray<SalString>();
        private static SalArray<SalString> _sUpdateMethod   = new SalArray<SalString>();

        #endregion

        public static SalNumber CopyToCompanies(SalNumber nWhat, Control hWndTBLWindow, SalString sLu, SalString sPackage, SalArray<SalWindowHandle> nCols, SalString sSourceCompany, SalString sType, ref SalArray<SalString> sAttr, ref SalString sInfo, ref SalString sWindow, ref SalNumber nLogId, Control hWndTBLWindow2, SalString sLu2, SalString sPackage2, SalArray<SalWindowHandle> nCols2, ref SalArray<SalString> sAttr2, ref SalString sInfo2, ref SalString sWindow2, ref SalNumber nLogId2)
        {
            _sCompanyList.Clear();
            _sUpdateMethod.Clear();
            if (CopyToCompanies(nWhat, hWndTBLWindow, sLu, sPackage, nCols, sSourceCompany, sType, ref sAttr, ref sInfo, ref sWindow, ref nLogId) == 1)
            {
                return CopyToCompanies(nWhat, hWndTBLWindow2, sLu2, sPackage2, nCols2, sSourceCompany, sType, ref sAttr2, ref sInfo2, ref sWindow2, ref nLogId2, "TRUE");
            }
            return 0;
        }
        public static SalNumber CopyToCompanies(SalNumber nWhat, Control hWndTBLWindow, SalString sLu, SalString sPackage, SalArray<SalWindowHandle> nCols, SalString sSourceCompany, SalString sType, ref SalArray<SalString> sAttr, ref SalString sInfo, ref SalString sWindow, ref SalNumber nLogId, string sDlgOpen = null, SalArray<SalWindowHandle> nColsComp = null)
        {
            #region Local Variables
            SalNumber nIteration    = 0;
            SalNumber nCount        = 2;
            SalNumber nTotalCount   = 1;
            SalString sRunInBackground  = "";
            SalString stmt              = "";
            SalString sBlock            = "";
            SalString sFieldChar        = ((SalNumber)Ifs.Fnd.ApplicationForms.Const.CHAR_FS).ToCharacter();
            SalString sParameterString  = "";
            SalBoolean bOpen            = false;
            SalWindowHandle hWndCol;
            SalArray<SalString> sItemNames      = new SalArray<SalString>();
            SalArray<SalString> sCompanyList    = new SalArray<SalString>();
            SalArray<SalString> sUpdateMethod   = new SalArray<SalString>();
            SalArray<SalString> sParameterList  = new SalArray<SalString>();


            #endregion

            #region Actions
            switch (nWhat)
            {
                case Ifs.Fnd.ApplicationForms.Const.METHOD_Execute:
                    sCompanyList = new SalArray<SalString>();
                    if (sDlgOpen == null)
                    {
                        if (dlgCopyToCompanies.ModalDialog(Sys.hWndMDI, sSourceCompany, sType, sLu, ref sCompanyList, ref sUpdateMethod, ref sRunInBackground) == Sys.IDOK )
                        {
                            _sCompanyList       = sCompanyList;
                            _sUpdateMethod      = sUpdateMethod;
                            _sRunInBackground   = sRunInBackground;
                            bOpen = true;
                        }
                    }
                    else
                    {
                        sCompanyList     = _sCompanyList;
                        sUpdateMethod    = _sUpdateMethod;
                        sRunInBackground = _sRunInBackground;
                        bOpen = false;
                    }

                    if (!sCompanyList.IsEmpty)
                    {
                        if (bOpen || (sDlgOpen == "TRUE"))
                        {
                            Sal.WaitCursor(true);
                            SalNumber nRow = Sys.TBL_MinRow;
                            Ifs.Fnd.ApplicationForms.Var.g_Bind.Clear();
                            Ifs.Fnd.ApplicationForms.Var.g_Bind.s[0] = sSourceCompany;
                        
                            while ((Sal.TblFindNextRow(hWndTBLWindow, ref nRow, Sys.ROW_Selected | Sys.ROW_New | Sys.ROW_Edited | Sys.ROW_MarkDeleted, 0)) || (hWndTBLWindow.GetType().BaseType.Name.Contains("FormWindow")))
                            {
                                Sal.TblSetContext(hWndTBLWindow, nRow);
                                if ((nColsComp == null) || nColsComp[0].GetText(100) == sSourceCompany)
                                { 
                                    for (int i = 0; i < sCompanyList.Length; i++)
                                    {
                                        sParameterString = "";
                                        if (sRunInBackground == "TRUE" && nIteration == 0)
                                        {
                                            Ifs.Fnd.ApplicationForms.Var.g_Bind.s[2] = Ifs.Fnd.ApplicationForms.Var.g_Bind.s[2] + sCompanyList[i] + sFieldChar;
                                            Ifs.Fnd.ApplicationForms.Var.g_Bind.s[3] = Ifs.Fnd.ApplicationForms.Var.g_Bind.s[3] + sUpdateMethod[i] + sFieldChar;
                                        }
                                        else if (sRunInBackground != "TRUE")
                                        {
                                            for (int k = 0; k < nCols.Length; k++)
                                            {
                                                if (nCols[k].GetDataType() == 2)
                                                {
                                                    Ifs.Fnd.ApplicationForms.Var.g_Bind.dt[nCount] = nCols[k].GetText(100).ToDate();
                                                    sParameterString += ",:g_Bind.dt[" + nCount + "] IN ";
                                                }
                                                else if (nCols[k].GetDataType() == 3)
                                                {
                                                    Ifs.Fnd.ApplicationForms.Var.g_Bind.n[nCount] = nCols[k].GetText(100).ToNumber();
                                                    sParameterString += ",:g_Bind.n[" + nCount + "] IN ";
                                                }
                                                else
                                                {
                                                    Ifs.Fnd.ApplicationForms.Var.g_Bind.s[nCount] = nCols[k].GetText(100);
                                                    sParameterString += ",:g_Bind.s[" + nCount + "] IN ";
                                                }
                                                nCount++;
                                            }
                                            nTotalCount = nCount;
                                            stmt += "&AO." + sPackage + ".Copy_To_Companies__(:g_Bind.s[0] IN,'" + sCompanyList[i] + "'" + sParameterString + ", '" + sUpdateMethod[i] + "', nLogId,'" + sAttr[nIteration] + "' );\n";
                                        }

                                    }
                                    if (sRunInBackground == "TRUE")
                                    {
                                        for (int l = 0; l < nCols.Length; l++)
                                        {
                                            if (nCols[l].GetDataType() == 2)
                                            {
                                                Ifs.Fnd.ApplicationForms.Var.g_Bind.s[l + 4] = Ifs.Fnd.ApplicationForms.Var.g_Bind.s[l + 4] + nCols[l].GetText(100).ToDate().ToString("yyyy-MM-dd") + sFieldChar;
                                            }
                                            else
                                            {
                                                Ifs.Fnd.ApplicationForms.Var.g_Bind.s[l + 4] = Ifs.Fnd.ApplicationForms.Var.g_Bind.s[l + 4] + nCols[l].GetText(100) + sFieldChar;
                                            }
                                            nTotalCount = l;
                                        }
                                        nTotalCount = nTotalCount + 5;
                                    }
                                    nIteration++;
                                    if (hWndTBLWindow.GetType().BaseType.Name.Contains("FormWindow"))
                                    {
                                        break;
                                    }

                                }
                            }
                            if (sRunInBackground == "TRUE")
                            {
                                for (int m = 0; m < sAttr.Length; m++)
                                {
                                    Ifs.Fnd.ApplicationForms.Var.g_Bind.s[1] = Ifs.Fnd.ApplicationForms.Var.g_Bind.s[1] + sAttr[m] + sFieldChar; ;
                                }
                            }
                            Ifs.Fnd.ApplicationForms.Var.g_Bind.s[nTotalCount]     = sType;
                            Ifs.Fnd.ApplicationForms.Var.g_Bind.s[nTotalCount + 1] = sLu;
                            if (sRunInBackground == "TRUE")
                            {
                                stmt = "&AO." + sPackage + ".Copy_To_Companies(:g_Bind.s[0] IN,:g_Bind.s[2] IN, ";
                                for (int n = 0; n < nCols.Length; n++)
                                {
                                    sBlock = sBlock + ":g_Bind.s[" + (n + 4) + "] IN,";
                                }

                                stmt = stmt + sBlock + ":g_Bind.s[3] IN,:g_Bind.s[" + nTotalCount + "] IN, :g_Bind.s[1] IN );";
                            }
                            else
                            {
                                sBlock = "DECLARE\n" +
                                           "     nLogId NUMBER;\n" +
                                           "  BEGIN \n" +
                                           "    &AO.Copy_Basic_Data_Log_API.Create_New_Record(nLogId, :g_Bind.s[0] IN , :g_Bind.s[" + nTotalCount + "] IN, :g_Bind.s[" + (nTotalCount + 1) + "] IN);\n";
                                stmt = sBlock + "    " + stmt + "\n" +
                                       "     &AO.Copy_Basic_Data_Log_API.Update_Status(nLogId);\n" +
                                       "     :g_Bind.s[" + (nTotalCount + 2) + "]   := &AO.Copy_Basic_Data_Log_API.Get_Status_Db(nLogId);\n" +
                                       "     :g_Bind.s[" + (nTotalCount + 3) + "]   := &AO.Basic_Data_Window_API.Get_Window(:g_Bind.s[" + (nTotalCount + 1) + "] IN);\n" +
                                       "     :g_Bind.s[" + (nTotalCount + 4) + "]   := nLogId;\n" +
                                       " END;";
                            }
                            Ifs.Fnd.ApplicationForms.Var.g_Bind.DbPLSQLTransaction(stmt);
                            sInfo = Ifs.Fnd.ApplicationForms.Var.g_Bind.s[(nTotalCount + 2)];
                            sWindow = Ifs.Fnd.ApplicationForms.Var.g_Bind.s[(nTotalCount + 3)];
                            nLogId = Ifs.Fnd.ApplicationForms.Var.g_Bind.s[(nTotalCount + 4)].ToNumber();
                            sAttr.Clear();
                            Sal.WaitCursor(false);
                            return 1;
                        }
                    }
                    sAttr.Clear();
                    return 1;
                case Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire:
                    if (hWndTBLWindow.GetType().BaseType.Name.Contains("FormWindow"))
                    {
                        return (!Sal.SendMsg(hWndTBLWindow, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0));
                    }
                    return (!Sal.SendMsg(hWndTBLWindow, Ifs.Fnd.ApplicationForms.Const.PM_DataSourceSave, Ifs.Fnd.ApplicationForms.Const.METHOD_Inquire, 0)) && (Sal.TblAnyRows(hWndTBLWindow, 0, 0) == true);
            }
            return 0;
            #endregion
        }

        public static SalBoolean NavigateToCopyBasicDataLog(ref SalString sAllInfo, SalArray<SalString> sParams)
        {
            #region Actions
            if (sAllInfo == "SUCCESSFUL")
            {
                sAllInfo = "";
                Ifs.Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.TEXT_SuccessfullyCopied, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Question, Ifs.Fnd.ApplicationForms.Const.INFO_Ok, sParams);
                return false;
            }
            if (sAllInfo == "PARTIALLY_SUCCESSFUL")
            {
                sAllInfo = "";
                if (Ifs.Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.TEXT_PartiallyCopied, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Question, Ifs.Fnd.ApplicationForms.Const.INFO_YesNo, sParams) == Sys.IDYES)
                {
                   return true;
                }
            }
            if (sAllInfo == "ERROR")
            {
                sAllInfo = "";
                if (Ifs.Fnd.ApplicationForms.Int.AlertBoxWithParams(Properties.Resources.TEXT_CopiedError, Ifs.Fnd.ApplicationForms.Properties.Resources.CAPTION_Question, Ifs.Fnd.ApplicationForms.Const.INFO_YesNo, sParams) == Sys.IDYES)
                {
                    return true;
                }
            }
            return false;
            #endregion
        }

    }
}
