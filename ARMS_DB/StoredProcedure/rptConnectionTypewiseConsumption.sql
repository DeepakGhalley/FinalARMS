
-- exec [dbo].[rptConnectionTypewiseConsumption] '20210512', '20210712','3'

create PROCEDURE [dbo].[rptConnectionTypewiseConsumption]
@FromDate  date , @ToDate  date, @WaterConnectionTypeId int
AS
BEGIN
SET NOCOUNT ON;
  
select  ROW_NUMBER() OVER(
       ORDER BY (select 1)) AS Sl, 
	   --FromDate, ToDate, 
	   ConsumerNo,MeterNo,Consumption,TotalAmount,zonename,waterConnectionType
       from
       (
(
select 
--FORMAT (@FromDate, 'dd/MM/yyyy') as FromDate	,FORMAT (@ToDate, 'dd/MM/yyyy') as ToDate,
wc.consumerNo as ConsumerNo, wc.waterMeterNo as MeterNo, z.zoneName as zonename, wct.waterConnectionType,
sum(wmr.consumption) as Consumption, sum(l.totalAmount) as TotalAmount

from tblLedger l 
left join tblDemand d on l.demandId=d.demandId
left join tblTransactionDetail td on l.transactionId = td.transactionId
left join tblWaterMeterReading wmr on td.transactionId = wmr.transactionId
left join mstZone z on wmr.zoneId = z.zoneId
left join mstWaterConnectionType wct on wmr.waterConnectionTypeId = wct.waterConnectionTypeId
left join mstWaterConnection wc on wmr.waterConnectionId = wc.waterConnectionId

where  td.transactionTypeId = 19 and wct.waterConnectionTypeId = @WaterConnectionTypeId and

FORMAT (wmr.readingDate, 'yyyyMMdd') >= FORMAT (@FromDate, 'yyyyMMdd') 
	and FORMAT (wmr.readingDate, 'yyyyMMdd') <= FORMAT (@ToDate, 'yyyyMMdd') 

group by  ConsumerNo, waterMeterNo, zoneName, waterConnectionType


)) f ORDER BY f.ConsumerNo ASC

END