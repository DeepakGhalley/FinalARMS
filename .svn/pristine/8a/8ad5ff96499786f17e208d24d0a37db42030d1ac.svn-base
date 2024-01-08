using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface IAssetFunction
    {
        IList<AssetFunctionModel> GetAll();
        Task<AssetFunctionModel> Details(int? id);
        int SaveAssetFunction(AssetFunctionModel obj);
        int UpdateAssetFunction(AssetFunctionModel obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        bool DuplicateCheckOnSave(string FunctionName);
        bool DuplicateCheckOnUpdate(string FunctionName, int Id);
    }
}
