using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface IAssetAttribute
    {
        IList<AssetAttributeVM> GetAll();
        Task<AssetAttributeVM> Details(int? id);
        int Save(AssetAttributeVM obj);
        int Update(AssetAttributeVM obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        bool DuplicateCheckOnSave(string AttributeName);
        bool DuplicateCheckOnUpdate(string AttributeName, int ParentAttributeId, int AssetAttributeId);
    }
}
