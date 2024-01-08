using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface IComplainDetail
    {
       
        List<WaterConnectionModel> GetWaterConnection(string ConsumerNo);
        List<ComplainDetail> GetComplainDetail(int ComplainDetailId);
        List<ComplainDetail> GetReviewComplainDetail(int ComplainDetailId);
        int SaveComplainDetail(ComplainDetail obj);
        int SaveReviewComplainDetail(ComplainDetail obj);
        int SaveApprovalComplainDetail(ComplainDetail obj);
        int SaveRejectionComplainDetail(ComplainDetail obj);

    }
}
