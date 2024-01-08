using CORE_BOL;
using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface IRevenueTransfer
    {
        IList<RevenueTransferVM> GetAll();
        Task<RevenueTransferVM> Details(int? id);
        int Save(RevenueTransferVM obj);
         int Update(RevenueTransferVM obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExistsAsync(int id);
        public IList<RevenueIOVM> ROnline(string StartDate, string EndDate);
        public IEnumerable<RevenueIOVM> Rtransfer(string StartDate, string EndDate);
        public IEnumerable<RevenueIOVM> Ropeniingbalance(string StartDate, string EndDate);
        public IEnumerable<RevenueIOVM> Rmannual(string StartDate,string EndDate);


    }
}
