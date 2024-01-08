

-- exec [dbo].[rptZoneWiseWaterConsumption] '15','2021'

create PROCEDURE [dbo].[rptZoneWiseWaterConsumption]
@ZoneId int, @YearId  varchar(200)
AS
BEGIN
SET NOCOUNT ON;
  
select  ROW_NUMBER() OVER(
       ORDER BY (select 1)) AS Sl,@YearId as Yr,ConsumerNo,MeterNo,Consumption,TotalAmount,PaymentStatus,zonename
       from
       (
(
select 
wc.consumerNo as ConsumerNo, wc.waterMeterNo as MeterNo, z.zoneName as zonename,
sum(wmr.consumption) as Consumption, sum(l.totalAmount) as TotalAmount,'Paid' as PaymentStatus

from tblLedger l 
left join tblDemand d on l.demandId=d.demandId
left join tblTransactionDetail td on l.transactionId = td.transactionId
left join tblWaterMeterReading wmr on td.transactionId = wmr.transactionId
left join mstZone z on wmr.zoneId = z.zoneId
left join mstWaterConnection wc on wmr.waterConnectionId = wc.waterConnectionId
left join mstCalendarYear cy on l.calendarYearId = cy.calendarYearId

where  td.transactionTypeId = 19 and z.zoneId = @ZoneId and isPaymentMade = 1 

group by  ConsumerNo, waterMeterNo, zoneName

)
union
(
select
wc.consumerNo as ConsumerNo, wc.waterMeterNo as MeterNo, z.zoneName as zonename,
sum(wmr.consumption) as Consumption, sum(d.demandAmount) as TotalAmount, 'Unpaid' as PaymentStatus

from  tblDemand d 
left join tblTransactionDetail td on d.transactionId = td.transactionId
left join tblWaterMeterReading wmr on td.transactionId = wmr.transactionId
left join mstWaterConnection wc on wmr.waterConnectionId = wc.waterConnectionId
left join mstZone z on wmr.zoneId = z.zoneId
left join mstCalendarYear cy on d.calendarYearId = cy.calendarYearId
where  td.transactionTypeId = 19 and z.zoneId = @ZoneId and d.isPaymentMade = 0

group by  ConsumerNo, waterMeterNo, zoneName

)) f ORDER BY f.ConsumerNo ASC,PaymentStatus asc

END