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
// 170113   NaJyLK  STRFI-4023,Merged Bug 132505 
// 140409   MaIklk  PBSC-8055, Added PAM_EnableTabs in order to enable/disable tabs in customer/order tab.
// 140210   Maabse  Added PAM_RecordNotInitiallySaved to be used if CustomerInfo form (+ other) has been intially saved.
// 131014   MaIklk  Added some constants which will use related to CRM representaives.
// 120419   Chgulk  EASTRTM-6962, Merged LCS patch 101624.
#endregion


namespace Ifs.Application.Enterp
{
	
	public sealed class Const
	{
        ///// <summary>
        ///// -----------------------------------------------------------------------------------
        ///// </summary>
        public const int METHOD_User = 44;
        public const int METHOD_ShowHide = METHOD_User + 1;
        public const int METHOD_Hide = METHOD_User + 5;
        
        ///// <summary>
        ///// Messages
        ///// </summary>
        public const int PAM_UpdateLuModControl = Ifs.Fnd.ApplicationForms.Const.PAM_User + 1001;
        public const int PAM_DetailAddress = Ifs.Fnd.ApplicationForms.Const.PAM_User + 1003;		
        public const int PAM_SetDiffSplitterPosition = Ifs.Fnd.ApplicationForms.Const.PAM_User + 1004;
		public const int PAM_NewForCustomer = Ifs.Fnd.ApplicationForms.Const.PAM_User + 2004;
        public const int PAM_SetMainRepresentative = Ifs.Fnd.ApplicationForms.Const.PAM_User + 2020;
        public const int PAM_SetMainRepName = Ifs.Fnd.ApplicationForms.Const.PAM_User + 2021;
        public const int PAM_RefreshHeaderOnSave = Ifs.Fnd.ApplicationForms.Const.PAM_User + 2022;
        public const int PAM_GetParentValue = Ifs.Fnd.ApplicationForms.Const.PAM_User + 2023;
        public const int PAM_GetObjectType = Ifs.Fnd.ApplicationForms.Const.PAM_User + 2024;
        public const int PAM_StateDoesNotAllowChanges = Ifs.Fnd.ApplicationForms.Const.PAM_User + 2025;
        public const int PAM_PopulateRepresentative = Ifs.Fnd.ApplicationForms.Const.PAM_User + 2026;
        public const int PAM_RecordNotInitiallySaved = Ifs.Fnd.ApplicationForms.Const.PAM_User + 2027;
        public const int PAM_EnableTabs = Ifs.Fnd.ApplicationForms.Const.PAM_User + 2028;
        public const int PAM_GetDefaultCountry = Ifs.Fnd.ApplicationForms.Const.PAM_User + 2029;
        public const int PAM_RefreshContactOnSave = Ifs.Fnd.ApplicationForms.Const.PAM_User + 2030;
        public const int PAM_GetParentIdentity = Ifs.Fnd.ApplicationForms.Const.PAM_User + 2031;
        public const int PAM_SetTabToFirst = Ifs.Fnd.ApplicationForms.Const.PAM_User + 2032;
        public const int PAM_GetAccessObjectId = Ifs.Fnd.ApplicationForms.Const.PAM_User + 2033;
        public const int PAM_SetOrderAddressInfoOnSave = Ifs.Fnd.ApplicationForms.Const.PAM_User + 2034;
        public const int PAM_ValidateValue = Ifs.Fnd.ApplicationForms.Const.PAM_User + 5222;
        public const string OBJECT_ContactType = "CUSTOMER_CONTACT";
        public const string OBJECT_SupContactType = "SUPPLIER_CONTACT";
		
	}
}
