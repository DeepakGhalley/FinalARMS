using CORE_BOL;
using CORE_BOL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace CORE_DLL
{
    public interface IOccupancyCertificate
    {

        List<OccupancyCertificateVM> FetchOccupanyCertificate(string Cid, string Ttin);
        public List<OccupancyCertificateVM> FetchLanddetails(int OccupancyCertificateApplicationId);
        public List<OccupancyCertificateVM> FetchTaxpayerdetails(int OccupancyCertificateApplicationId);

        public List<OccupancyCertificateVM> Fetchbuildingdetails(int OccupancyCertificateApplicationId);
        public List<OccupancyCertificateVM> FetchUnitdetails(int OccupancyCertificateApplicationId);

    }
}
