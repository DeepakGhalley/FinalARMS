using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
   public interface IParentAttribute
    {
        IList<ParentAttributeModel> GetAll();
        //Task<IEnumerable<TblMstUser>> Details(int? id);
        Task<ParentAttributeModel> Details(int? id);
        int SaveParentArribute(ParentAttributeModel obj);
        int UpdateParentArribute(ParentAttributeModel obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        bool DuplicateCheckOnSave(string ParentAttribute);
        bool DuplicateCheckOnUpdate(string ParentAttribute, int TertiaryAccountHeadId, int Id);
    }
}
