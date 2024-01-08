
-- exec [dbo].[rptZoneWiseWaterConsumptionFromToDate] '07-12-2021','07-12-2021','15'

create PROCEDURE [dbo].[rptZoneWiseWaterConsumptionFromToDate]
@FromDate  date , @ToDate  date, @ZoneId int
AS
BEGIN
SET NOCOUNT ON;
  
select  ROW_NUMBER() OVER(
       ORDER BY (select 1)) AS Sl, 
	   --FromDate, ToDate, 
	   ConsumerNo,MeterNo,Consumption,TotalAmount,zonename
       from
       (
(
select 
--FORMAT (@FromDate, 'dd/MM/yyyy') as FromDate	,FORMAT (@ToDate, 'dd/MM/yyyy') as ToDate,
wc.consumerNo as ConsumerNo, wc.waterMeterNo as MeterNo, z.zoneName as zonename,
sum(wmr.consumption) as Consumption, sum(l.totalAmount) as TotalAmount

from tblLedger l 
left join tblDemand d on l.demandId=d.demandId
left join tblTransactionDetail td on l.transactionId = td.transactionId
left join tblWaterMeterReading wmr on td.transactionId = wmr.transactionId
left join mstZone z on wmr.zoneId = z.zoneId
left join mstWaterConnection wc on wmr.waterConnectionId = wc.waterConnectionId

where  td.transactionTypeId = 19 and z.zoneId = @ZoneId and
FORMAT (wmr.readingDate, 'yyyyMMdd') >= FORMAT (@FromDate, 'yyyyMMdd') 
and FORMAT (wmr.readingDate, 'yyyyMMdd') <= FORMAT (@ToDate, 'yyyyMMdd')

group by  ConsumerNo, waterMeterNo, zoneName


)) f ORDER BY f.ConsumerNo ASC

END