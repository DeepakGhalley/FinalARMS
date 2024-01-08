

CREATE PROCEDURE [dbo].[rptGetWaterConsumption]
	@zoneId int
AS
--	EXEC [dbo].[rptGetWaterConsumption] '2'

  SELECT ROW_NUMBER() over(order by(select 1)) as sl, w.consumerNo as consumerNo,wc.waterConnectionType as waterConnectionType, 
  w.waterMeterNo as waterMeterNo,  wl.waterLineType as waterLineType,
  CONVERT(varchar, wr.readingDate,103) as readingDate, wr.consumption as consumption
  
   
   from mstWaterConnection w 
   join tblWaterMeterReading wr on w.waterConnectionId = wr.waterConnectionId
   join mstWaterConnectionType wc on w.waterConnectionTypeId = wc.waterConnectionTypeId
   join mstWaterLineType wl on w.waterLineTypeId = wl.waterLineTypeId
   where w.zoneId = @zoneId
RETURN 0