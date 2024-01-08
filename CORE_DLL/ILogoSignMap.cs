using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CORE_BOL;
using Microsoft.AspNetCore.Http;

namespace CORE_DLL
{
    public interface ILogoSignMap
    {
        IList<LogoSignMapModel> GetAll();
        Task<LogoSignMapModel> Details(int? id);
        int Save(LogoSignMapModel obj);
        int Update(LogoSignMapModel obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
    }
}
