using CORE_BOL;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
   public interface IPaymentAmountModification
    {
        List<PaymentAmountModification> GetDemandDetails(string DemandNo);
        List<PaymentAmountModification> GetReceiptDetails(string ReceiptNo);
        List<PaymentAmountModification> GetPaymentModeDetails(int PaymentLedgerId);
        int SaveDemand(PaymentAmountModification obj);
        int SavePayment(PaymentAmountModification obj);
        int SavePaymentModeAmount(PaymentAmountModification obj);


    }
}
