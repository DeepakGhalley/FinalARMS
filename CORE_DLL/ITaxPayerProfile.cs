using CORE_BOL;
using System;
using CORE_BOL.Entities;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface ITaxPayerProfile
    {
        IList<TaxPayerProfileModel> GetAll(int? id);
        Task<TaxPayerProfileModel> Details(int? id);
        int Save(TaxPayerProfileModel obj);

        //for Organisation
        int Update(TaxPayerProfileModel obj);
        List<TaxPayerProfileModel> fetchOrganisation(string ttin, string name);
        List<TaxPayerProfileModel> fetchOrganisationAll();

        //for Individual
        int IndividualUpdate(TaxPayerProfileModel obj);
        List<TaxPayerProfileModel> fetchIndividual(string cid, string ttin);
        List<TaxPayerProfileModel> fetchIndividualAll();

        //for Vendor
        int VendorUpdate(TaxPayerProfileModel obj);
        List<TaxPayerProfileModel> fetchVendor(/*string cid, */string ttin, string name);
        List<TaxPayerProfileModel> fetchVendorAll();


        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        bool DuplicateCheckOnSave(string Cid);
        bool DuplicateCheckOnUpdate(string Cid, int Id);
        List<MstVillage> fetchPV(int id);
        List<MstGewog> fetchPG(int id);
        List<MstBankBranch> fetchBB(int id);
        List<MstTaxPayerProfile> fetchCID(string cid, string ttin);
        List<MstTaxPayerProfile> fetchTaxPayer(string cid, string ttin);

    }
}
