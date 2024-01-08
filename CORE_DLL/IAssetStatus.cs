using CORE_BOL;
using CORE_BOL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface IAssetStatus
    {
        Task<IEnumerable<MstAssetStatus>> GetAll();
        // Task<AssetStatusModel> GetAll();

        Task<AssetStatusModel> Details(int? id);
        int SaveAssetStatus(AssetStatusModel obj);
        int UpdateAssetStatus(AssetStatusModel obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        bool DuplicateCheckOnSave(string AssetStatus);
       bool DuplicateCheckOnUpdate(string AssetStatus,int Id);
    }
}
