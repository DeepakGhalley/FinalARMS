using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;

namespace CORE_DLL
{
    public interface IBfsTranaction
    {
        int SavePaymentCancel(BfsModel objBfs);
        long SavePaymentSuccess(BfsModel objBfs);
        int SavePaymentFailure(BfsModel objBfs);
        long SaveBFS(BfsModel objBfs);
        IList<OnlinePaymentCheckModel> FetOnlinePaymentStatus(string DemandNoIds);

    }
}
