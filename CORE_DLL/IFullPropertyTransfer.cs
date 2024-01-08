using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface IFullPropertyTransfer
    {
        IList<FullPropertyTransferModel> GetAll();
        IList<LocalLandJointOwners> GetLocalLandOwnershipByPlotId(string PlotNo);
        Task<FullPropertyTransferModel> Details(int? id);
        long SaveDemand(DemandVM obj);
        int UpdateActivityType(FullPropertyTransferModel obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        //List<LandTransactionDetail> GetTransactionDetailFromAPIByTransactionId(int? id);
        List<LandDetailModel> GetLandDetailsByPlotNo(string PlotNo, string Cid);  
        List<LandDetailModel> GetPlotDetailsByPlotNo(string PlotNo);  
        List<TaxPayerProfileModel> CheckTaxpayerRegistration(string Cid);

        Task<List<EsakorTaxPayerModel>> CheckTaxPayersAndLandOwnershipAsync(List<EsakorTaxPayerModel> json_data);

    }
}
