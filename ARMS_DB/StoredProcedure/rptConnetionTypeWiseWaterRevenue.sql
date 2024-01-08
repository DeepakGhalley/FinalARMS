
-- exec [dbo].[rptConnetionTypeWiseWaterRevenue] '05-12-2021','07-12-2021','3'

create PROCEDURE [dbo].[rptConnetionTypeWiseWaterRevenue]
@FromDate  date , @ToDate  date, @WaterConnectionTypeId int
AS
BEGIN
SET NOCOUNT ON;
  
select  ROW_NUMBER() OVER(
       ORDER BY (select 1)) AS Sl, 
	   --FromDate, ToDate, 
	   ConsumerNo,MeterNo,waterConnectionType,billingAddress,TotalAmount
       from
       (
(
select 
--FORMAT (@FromDate, 'dd/MM/yyyy') as FromDate	,FORMAT (@ToDate, 'dd/MM/yyyy') as ToDate,
wc.consumerNo as ConsumerNo, wc.waterMeterNo as MeterNo, wct.waterConnectionType, wc.billingAddress, 
sum(l.totalAmount) as TotalAmount

from tblLedger l 
left join tblDemand d on l.demandId=d.demandId
left join tblTransactionDetail td on l.transactionId = td.transactionId
left join tblWaterMeterReading wmr on td.transactionId = wmr.transactionId
left join mstWaterConnectionType wct on wmr.waterConnectionTypeId = wct.waterConnectionTypeId
left join mstWaterConnection wc on wmr.waterConnectionId = wc.waterConnectionId

where  td.transactionTypeId = 19 and wct.waterConnectionTypeId = @WaterConnectionTypeId and
FORMAT (wmr.readingDate, 'yyyyMMdd') >= FORMAT (@FromDate, 'yyyyMMdd') 
and FORMAT (wmr.readingDate, 'yyyyMMdd') <= FORMAT (@ToDate, 'yyyyMMdd') 

group by  ConsumerNo, waterMeterNo, waterConnectionType, wc.billingAddress


)) f ORDER BY f.ConsumerNo ASC

END