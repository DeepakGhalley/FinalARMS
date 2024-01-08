using CORE_BOL;
using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface IAssetRegister
    {
        IList<AssetRegisterVM> GetAll(int SecondaryAccountHeadId);
        List<AssetRegisterVM> GetTechnical(int? id);
        List<TechicalInformationVM> GetTechnicalDetail(int? id);
        List<FinancialDetailVM> GetFinancialDetail(int? id);
        List<TechicalInformationVM> CheckDuplicateInformation(int id);
        List<FinancialInformationVM> CheckDuplicateFinancial(int id);
        Task<AssetRegisterVM> Details(int? id);
        int Save(AssetRegisterVM obj);
        int SaveFinancial(FinancialInformationVM obj);
        int SaveTechnical(TechicalInformationVM obj);
        int UpdateFinancial(FinancialInformationVM obj);
        int Update(AssetRegisterVM obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        bool DuplicateCheckOnSave(string AssetCode);
        bool DuplicateCheckOnUpdate(string AssetCode, int TertiaryAccountHeadId, int SectionId, int AssetStatusId, int AssetFunctionId, int Id);
        IEnumerable<AssetManagementVM> FetchAssetRegiser(int PrimaryHeadId);
        
        List<MstSection> fetchSEC(int id);
        List<MstTertiaryAccountHead> fetchTER(int id);
        List<MstSecondaryAccountHead> fetchSED(int id);
        List<AssetRegisterVM> GetAssetsNumber(int AssetId);
        List<UsersModel> Fetchuser(int uid);
        //List<MstArea> FetchArea(int aid);
        //List<MstZone> FetchZone(int zid);

    }
}
