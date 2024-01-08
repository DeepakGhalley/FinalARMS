using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface IRevenueReport
    {

        public IEnumerable<ARevenueVM> Revenue(string StartDate, string EndDate);
        public IEnumerable<AwaterVM> Revenuewater(string StartDate, string EndDate);
        public IEnumerable<ApropertyVM> Revenueproperty(string StartDate, string EndDate);
        public IEnumerable<AwaterHeadwiseVM> Revenuewaterheadwise(string StartDate, string EndDate);
        public IEnumerable<AwaterReceiptwiseVM> Revenuewaterrecepitwise(string StartDate, string EndDate);
        public IEnumerable<ApropertyheadwiseVM> Revenuepropertyheadwise(string StartDate, string EndDate);
        public IEnumerable<ApropertyrecepitwiseVM> Revenuepropertyeceiptwise(string StartDate, string EndDate);

        public IEnumerable<wiseCollectionVM> wiseCollection(string StartDate, string EndDate);
        public IEnumerable<wiseCollectionVM> showwiseCollection();
        public IEnumerable<SavewiseCollectionVM> SavewiseCollection(int UserId, int CreatedBy, decimal checkedAmount, string collectionStartDate, string collectionEndDate);
        public IEnumerable<wiseCollectedVM> Collected(string StartDate, string EndDate);
        public IEnumerable<wisedetailVM> detailwise(string StartDate, string EndDate, int UserId);
        public IEnumerable<ModeWiseCollectionVM> ModeWise(string StartDate, string EndDate, int PaymentModeId, int UserId);


    }
}
