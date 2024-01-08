using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;


namespace CORE_DLL
{
    public interface IDeposit
    {
        IEnumerable<DepositVM> GetDepositDetails(int StartDate, int EndDate);
       
        int SaveDeposit(DepositSaveVM obj);
        long Update(DepositSaveVM obj);
        List<DepositSaveVM> GetDepositupdatedisplay(string ChequeNo);
        bool DuplicateCheck(DateTime PaymentToDate, DateTime PaymentFromDate);
        IList<IndividualDetails> GetAll();
        IList<DepositSaveVM> GetDate();
        IEnumerable<PaymentDepositReportVM> GetPaymentDepositReport(int StartDate, int EndDate);
        //int UpdateDeposit(DepositSaveVM obj);
    }
}

