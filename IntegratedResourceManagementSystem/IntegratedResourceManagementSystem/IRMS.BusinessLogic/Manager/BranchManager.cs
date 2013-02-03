using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRMS.BusinessLogic.DataAccess;
using IRMS.ObjectModel;
using BLToolkit.Data;

namespace IRMS.BusinessLogic.Manager
{
    public class BranchManager
    {
        private TransactionState TransState = TransactionState.Default;
        private BranchClass OldBranch = new BranchClass();

        #region Accessor
        BranchAccessor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return BranchAccessor.CreateInstance(); }
        }
        #endregion

        public BranchClass PreviousBranch
        {
            get { return OldBranch; }
            set { OldBranch = value; }
        }
        public BranchClass GetBranchByKey(long id)
        {
            return Accessor.Query.SelectByKey<BranchClass>(id) ?? new BranchClass();
        }

        public BranchClass GetBranchByBranchCode(string BranchCode)
        {
            string[] paramkey = new string[1];
            paramkey[0] = BranchCode;
            string[] paramcolumn = new string[1];
            paramcolumn[0] = "BRANCH_CODE";

            return Accessor.Query.SelectByKeyWords<BranchClass>(paramkey, paramcolumn)[0] ?? new BranchClass();
        }

        public List<BranchClass> Branch()
        {        
            return Accessor.Branch();
        }

        public List<BranchClass> Branches()
        {
            using (DbManager dbm = new DbManager())
            {
              return  Accessor.Query.SelectAll<BranchClass>() ?? new List<BranchClass>();
            }
        }

        public BranchClass GetBranchByCode(string branchCode)
        {
            var result = (from branch in Branches()
                          where branch.BranchCode == branchCode
                          select branch).FirstOrDefault();
            return result ?? new BranchClass();
        }

        public void Add()
        {
            TransState = TransactionState.Add;
        }
        public void Update()
        {
            TransState = TransactionState.Update;
        }

        public bool ValidateData(BranchClass branch, ref string Message)
        {
            bool bResult = false;

            if (string.IsNullOrEmpty(branch.AccountCode) == true)
            {
                Message = "Account name required!";
                return bResult;
            }

            if (string.IsNullOrEmpty(branch.BranchName) == true)
            {
                Message = "Branch name required!";
                return bResult;
            }

            int iResultCount = 0;
            bool bChange = true;


            if (OldBranch.AccountCode == branch.AccountCode || TransState == TransactionState.Add)
            {
                iResultCount = Accessor.BranchByBranchName(branch.AccountCode, branch.BranchName).Count;
                if (TransState == TransactionState.Update)
                {
                    if (OldBranch.BranchName == branch.BranchName)
                            bChange = false;
                }
            }

            if (iResultCount > 0 && bChange == true)
            {
                Message = "Branch name already been used!";
                return bResult;
            }






            /*
            string[] paramKey = new string[2];
            string[] paramColumn = new string[2];

            paramKey[0] = branch.BranchName;
            paramKey[1] = branch.BranchCode;
            paramColumn[0] = "BRANCH_NAME";
            paramColumn[1] = "BRANCH_CODE";
            int iResultCount = 0;
            bool bChange = true;

            iResultCount = Accessor.Query.SelectByKeyWords<BranchClass>(paramKey,paramColumn).Count;
            
            if (TransState == TransactionState.Update)
            {
                if (OldBranch.BranchName == branch.BranchName)
                    bChange = false;
            }

            if (iResultCount > 0 && bChange == true)
            {
                Message = "Branch name already been used!";
                return bResult;
            }



            paramKey = new string[1];
            paramColumn = new string[1];
            paramKey[0] = branch.BranchCode;
            paramColumn[0] = "BRANCH_CODE";
            iResultCount = 0;
            bChange = true;

            iResultCount = Accessor.Query.SelectByKeyWords<BranchClass>(paramKey, paramColumn).Count;

            if (TransState == TransactionState.Update)
            {
                if (OldBranch.BranchCode == branch.BranchCode)
                    bChange = false;
            }

            if (iResultCount > 0 && bChange == true)
            {
                Message = "Branch code already been used!";
                return bResult;
            }*/


            bResult = true;
            return bResult;
        }

        public bool Save(BranchClass branch)
        {
            bool bResult = false;
            branch.BranchCode = GenerateBranchCode();
            using (DbManager db = new DbManager())
            {
                try
                {
                    if (branch.RecordNo != 0)
                    {
                        Accessor.Query.Update(db, branch);
                    }
                    else
                    {
                        Accessor.Query.Insert(db, branch);
                    }
                    bResult = true;
                }
                catch (Exception except)
                {
                    throw new System.ArgumentException(except.Message);
                }
            }
            return bResult;
        }

        public bool Delete(BranchClass branch)
        {
            bool bResult = false;

            try
            {
                using (DbManager db = new DbManager())
                {
                    Accessor.Query.Delete(db, branch); 
                    bResult = true;
                }             
            }
            catch(Exception except)
            {
                throw new System.ArgumentException(except.Message);
            }

            return bResult;
        }

        private string GenerateBranchCode()
        {
            string sResult = string.Empty;
            using (DbManager db = new DbManager())
            {

                db.SetSpCommand("Get_BranchSequence", db.Parameter("@GUID_NUMBER", "TEST")).ExecuteNonQuery();
                long lData = Convert.ToInt32(db.Parameter("@RETURN_VALUE").Value);

                sResult = string.Format("BR-{0:00000}", lData);
            }
            return sResult;
        }

        public List<BranchClass> SearchBranch(string[] search_parameter)
        {
            string[] columns = new string[1];
            columns[0] = "BRANCH_NAME";
            return Accessor.Query.SelectByKeyWords<BranchClass>(search_parameter, columns);
        }

        public List<BranchClass> SearchBranchByAccountCode(string[] search_parameter)
        {
            string[] columns = new string[1];
            columns[0] = "ACCT_CODE";
            return Accessor.Query.SelectByKeyWords<BranchClass>(search_parameter, columns);
        }

        public List<BranchClass> GetAllBranch()
        {
            return Accessor.Branch();
        }
    }
}