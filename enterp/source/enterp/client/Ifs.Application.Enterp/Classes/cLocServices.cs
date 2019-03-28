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
// DATE        BY        NOTES
// YY-MM-DD
// 15-07-28    Shhelk    Created.

#endregion
using System;
using System.Collections.Generic;
using Ifs.Fnd.ApplicationForms;
using PPJ.Runtime;
using PPJ.Runtime.Windows;
using PPJ.Runtime.Vis;

namespace Ifs.Application.Enterp
{
    /// <summary>
    /// Class used to manage specific services such as geting 'Localization Country'
    /// </summary>
    public class cLocServices 
    {
        
        public SalString sLocCountry = SalString.Null;
        public SalString sAllocateTaxFetch = SalString.Null; 

        public virtual SalString GetLocCountry(SalString sCompany)
        {
            Ifs.Fnd.ApplicationForms.Var.g_Bind.Clear();
            Ifs.Fnd.ApplicationForms.Var.g_Bind.s[0] = sCompany;
            Ifs.Fnd.ApplicationForms.Var.g_Bind.s[1] = sLocCountry;
            Ifs.Fnd.ApplicationForms.Var.g_Bind.DbPLSQLBlock(":g_Bind.s[1] := &AO.Company_API.Get_Localization_Country_Db(:g_Bind.s[0] IN);");
            sLocCountry = Ifs.Fnd.ApplicationForms.Var.g_Bind.s[1];
            return sLocCountry;
        }
    }
}
