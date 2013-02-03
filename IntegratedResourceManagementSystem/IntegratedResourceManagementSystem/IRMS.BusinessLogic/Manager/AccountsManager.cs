using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRMS.BusinessLogic.DataAccess;
using IRMS.ObjectModel;
using BLToolkit.Data;

namespace IRMS.BusinessLogic.Manager
{
    public enum TransactionState
    {
        Default=0, Add=1, Update=2, Delete=3
    }

    public class AccountsManager
    {
        #region Accessor
        AccountsAccessor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return AccountsAccessor.CreateInstance(); }
        }
        #endregion

        private AccountClass OldAccount = new AccountClass();
        private TransactionState TransState = TransactionState.Default;


        public AccountClass PreviousAccount
        {
            get { return OldAccount; }
            set { OldAccount = value; }
        }

        public AccountClass GetAccountByKey(long id)
        {
            return Accessor.Query.SelectByKey<AccountClass>(id) ?? new AccountClass();
        }

        public AccountClass GetAccountByAccountCode(string AccountCode)
        {
            string[] paramkey = new string[1];
            paramkey[0] = AccountCode;
            string[] paramcolumn = new string[1];
            paramcolumn[0] = "ACCT_CODE";

            return Accessor.Query.SelectByKeyWords<AccountClass>(paramkey, paramcolumn)[0] ?? new AccountClass();
        }

        public List<AccountClass> Accounts()
        {
            return Accessor.Accounts();
        }

        public AccountClass GetAccountByCode(string accountCode)
        {
            var result = (from account in Accounts()
                          where account.AccountCode == accountCode
                          select account).FirstOrDefault();
            return result ?? new AccountClass();
        }

        public bool ValidateAccount(AccountClass account, ref string Message)
        {
            bool bResult = false;
            bool bChange = true;
            int iResultCount = 0;

            iResultCount = Accessor.AccountsByAccountCode(account.AccountCode).Count;
            if (TransState == TransactionState.Update)
            {
                if (OldAccount.AccountCode == account.AccountCode)
                    bChange = false;
            }

            if (iResultCount > 0 && bChange == true)
            {
                Message = "Account code already been used!";
                return bResult;
            }


            iResultCount = Accessor.AccountsByAccountName(account.AccountCode, account.AccountName).Count;
            bChange = true;

            if (TransState == TransactionState.Update)
            {
                if (OldAccount.AccountName == account.AccountName)
                    bChange = false;
            }

            if (iResultCount > 1 && bChange == true)
            {
                Message = "Account name already exist!";
                return bResult;
            }


            bResult = true;
            return bResult;
        }

        public void Add()
        {
            TransState = TransactionState.Add;
        }
        public void Update()
        {
            TransState = TransactionState.Update;
        }


        private string GenerateAccountCode()
        {
            string sResult = string.Empty;
            using (DbManager db = new DbManager())
            {

                db.SetSpCommand("Get_AccountSequence", db.Parameter("@GUID_NUMBER", "TEST")).ExecuteNonQuery();
                long lData = Convert.ToInt32(db.Parameter("@RETURN_VALUE").Value);

                sResult = string.Format("ACCT-{0:00000}", lData);
            }
            return sResult;
        }

        public bool Save(AccountClass account)
        {
            bool bResult = false;
            using (DbManager db = new DbManager())
            {
                try
                {
                    if (account.RecordNo != 0)
                    {
                        Accessor.Query.Update(db, account);
                    }
                    else
                    {
                        account.AccountCode = GenerateAccountCode();
                        Accessor.Query.Insert(db, account);
                    }
                    bResult = true;
                }
                catch (Exception except)
                {
                    throw new System.ArgumentException(except.Message);
                }
                
            }
            TransState = TransactionState.Default;
            return bResult;
        }

        public bool Delete(AccountClass account)
        {
            bool bResult = false;
            try
            {           
                using (DbManager db = new DbManager())
                {
                    Accessor.Query.Delete(db, account);
                }
                bResult = true;
            }
            catch (Exception except)
            {
                throw new System.ArgumentException(except.Message);
            }
            TransState = TransactionState.Default;
            return bResult;
        }

        public List<AccountClass> SearchAccounts(string[] search_parameter)
        {
            string[] columns = new string[1];
            columns[0] = "ACCT_NAME";
            return Accessor.Query.SelectByKeyWords<AccountClass>(search_parameter, columns);
        }

    }
}
