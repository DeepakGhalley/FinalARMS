using CORE_BOL;
using System;
using CORE_BOL.Entities;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
namespace CORE_DLL
{
    public interface ItrnWaterConnection
    {
        IList<TrnWaterConnectionVM> GetAll();
        Task<TrnWaterConnectionVM> Details(int? id);
      

    }
}
