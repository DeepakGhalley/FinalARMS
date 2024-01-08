using CORE_BOL;
using System;
using CORE_BOL.Entities;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface IInitialConnections
    {

        List<WaterConnectionModel> SearchConsumerNo(string ConsumerNo);
        List<LandOwnershipDetailsVM> SearchLandDetails(string PlotNo, string ThramNo, string TTIN);
        List<WaterMeterReadingModel> WaterMeterReading(int? id);
        List<WaterConnectionModel> DisplayWaterConnectionDetail(string ConsumerNo);
        int SaveWaterMeterReading(WaterMeterReadingModel obj);
        int SaveWaterConnection(WaterConnectionModel obj);


    }
}
