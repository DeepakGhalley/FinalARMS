using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface IConditionRating
    {
        IList<ConditionRatingVM> GetAll();
        Task<ConditionRatingVM> Details(int? id);
        int Save(ConditionRatingVM obj);
        int Update(ConditionRatingVM obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        bool DuplicateCheckOnSave(string ConditionRating);
        bool DuplicateCheckOnUpdate(string ConditionRating, int Id);
    }
}
