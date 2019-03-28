-----------------------------------------------------------------------------
--
--  Logical unit: LchEmployee
--  Component:    ENTERP
--
--  IFS Developer Studio Template Version 3.0
--
--  Date    Sign    History
--  ------  ------  ---------------------------------------------------------
-----------------------------------------------------------------------------

layer Cust;

-------------------- PUBLIC DECLARATIONS ------------------------------------


-------------------- PRIVATE DECLARATIONS -----------------------------------


-------------------- LU SPECIFIC IMPLEMENTATION METHODS ---------------------


-------------------- LU SPECIFIC PRIVATE METHODS ----------------------------


-------------------- LU SPECIFIC PROTECTED METHODS --------------------------


-------------------- LU SPECIFIC PUBLIC METHODS -----------------------------


-------------------- LU CUST NEW METHODS -------------------------------------
PROCEDURE ChangePassword (
   employee_id_       IN VARCHAR2,
   password_          IN VARCHAR2)
IS
   oldrec_       lch_employee_tab%ROWTYPE;
   newrec_       lch_employee_tab%ROWTYPE;
   attr_         VARCHAR2(2000);
   objid_        VARCHAR2(100);
   objversion_   VARCHAR2(200);
   indrec_       Indicator_Rec;
BEGIN
   Get_Id_Version_By_Keys___(objid_, objversion_, employee_id_);
   oldrec_ := Lock_By_Id___(objid_, objversion_);
   Client_SYS.Clear_Attr(attr_);
   Client_SYS.Add_To_Attr('LOGIN_PASSWORD',                 password_,                attr_);
   newrec_ := oldrec_;
   Unpack___(newrec_, indrec_, attr_);
   Check_Update___(oldrec_, newrec_, indrec_, attr_);
   Update___(objid_, oldrec_, newrec_, attr_, objversion_);   
END ChangePassword;