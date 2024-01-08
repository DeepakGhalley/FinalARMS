using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CORE_BOL;
using CORE_BOL.Entities;


namespace CORE_DLL
{
    public interface IAssetTransfer
    {
        List<SecondaryAccountHeadModel> fetchSecondaryHead(int id);
        List<TertiaryAccountHeadModel> fetchTertiaryHead(int id);
        List<SectionModel> fetchDivision(int id);
        List<AssetTransferVM> SearchAsset(int primaryhead, int secondaryhead, int tertiaryhead, int division, int section, string assetname, int assetstatus, int lap, int demkhong);
        List<AssetTransferVM> GetAssetDetails(int id);
        int SaveAssetTransfer(AssetTransferVM obj);




    }
}
