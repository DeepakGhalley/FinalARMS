-- exec [dbo].[rptMonthlyZoneWiseWaterConsumption] '15','2021','6'

create PROCEDURE [dbo].[rptMonthlyZoneWiseWaterConsumption]
@ZoneId int, @YearId  varchar(200), @MonthId int
AS
BEGIN
SET NOCOUNT ON;
  
select  ROW_NUMBER() OVER(
       ORDER BY (select 1)) AS Sl,ConsumerNo, @YearId as Yr, @MonthId as Mnths, MeterNo,Consumption,TotalAmount,PaymentStatus, zoneName
	   from
	   (
(
select 
wc.consumerNo as ConsumerNo, wc.waterMeterNo as MeterNo, z.zoneName as zoneName,
sum(wmr.consumption) as Consumption, sum(l.totalAmount) as TotalAmount,'Paid' as PaymentStatus
from tblLedger l 
left join tblDemand d on l.demandId=d.demandId
left join tblTransactionDetail td on l.transactionId = td.transactionId
left join tblWaterMeterReading wmr on td.transactionId = wmr.transactionId
left join mstZone z on wmr.zoneId = z.zoneId
left join mstWaterConnection wc on wmr.waterConnectionId = wc.waterConnectionId
left join mstCalendarYear cy on l.calendarYearId = cy.calendarYearId

where  td.transactionTypeId = 19 and z.zoneId = @ZoneId and cy.calendarYear =@YearId  and isPaymentMade = 1
and MONTH(l.paymentDate) = @MonthId
group by  ConsumerNo, waterMeterNo,zoneName

)
union
(
select
wc.consumerNo as ConsumerNo, wc.waterMeterNo as MeterNo,z.zoneName as zoneName,
sum(wmr.consumption) as Consumption, sum(d.demandAmount) as TotalAmount, 'Unpaid' as PaymentStatus
from  tblDemand d 
left join tblTransactionDetail td on d.transactionId = td.transactionId
left join tblWaterMeterReading wmr on td.transactionId = wmr.transactionId
left join mstWaterConnection wc on wmr.waterConnectionId = wc.waterConnectionId
left join mstZone z on wmr.zoneId = z.zoneId
left join mstCalendarYear cy on d.calendarYearId = cy.calendarYearId
where  td.transactionTypeId = 19 and z.zoneId = @ZoneId and cy.calendarYear = @YearId and d.isPaymentMade = 0
and MONTH(d.billingDate) = @MonthId

group by  ConsumerNo, waterMeterNo, zoneName

)) f ORDER BY f.ConsumerNo ASC,PaymentStatus asc

END