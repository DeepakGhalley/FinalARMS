
--	exec [dbo].[rptDefaulterWaterList] '21','13'

create PROCEDURE [dbo].[rptDefaulterWaterList]
@CalendarYearId int, @ZoneId int
AS
BEGIN
	SET NOCOUNT ON;	
	declare @yr varchar(250);declare @mth int=11;declare @dt int=30;

	set @yr=(select CalendarYear from mstCalendarYear where calendarYearId=@CalendarYearId);
	SELECT ROW_NUMBER() over(order by(select 1)) as Sl, ConsumerNo, WaterMeterNo,BillingAddress,contactNo ,zoneName,calendarYear, NoOfPendingBills,sum(WaterTaxAmount) as WaterTaxAmount,sum(SewerageTaxAmount) as SewerageTaxAmount,sum(WaterTaxAmount) +sum(SewerageTaxAmount) as TotalAmount from(

(
SELECT  wc.consumerNo as ConsumerNo,wc.waterMeterNo AS WaterMeterNo,w.billingAddress AS BillingAddress,wc.primaryMobileNo as contactNo
--,DATEDIFF(day,CAST(w.readingDate AS DATE),GETDATE()) as OutstandingDays
,msz.zoneName
	,@yr as calendarYear
	--, FORMAT(w.readingDate, 'MMM') as months
	,sum(d.totalAmount) as WaterTaxAmount,0 as SewerageTaxAmount,count(wc.consumerno) as NoOfPendingBills

	from tblWaterMeterReading w
	inner join tblTransactionDetail td on w.transactionId = td.transactionId
	inner join tblDemand d on td.transactionId = d.transactionId
	inner join mstCalendarYear cy on d.calendarYearId = cy.calendarYearId
	inner join mstWaterConnection wc on w.waterConnectionId = wc.waterConnectionId	
	inner join mstTransactionType ty on td.transactionTypeId = ty.transactionTypeId
	inner join mstzone msz on wc.zoneId = msz.zoneId

	where d.isCancelled=0 and d.taxId=14 and  d.isPaymentMade = 0 and td.transactionTypeId = 19 and msz.zoneId = @ZoneId and cast(convert(varchar,w.readingDate,112)as int)<=cast(convert(varchar,getdate(),112)as int)
	--and cast(convert(varchar,w.readingDate,112)as int)<=cast(convert(varchar,CAST(concat(@yr,'-',@mth,'-',@dt) as datetime),112)as int)
	--and month(w.readingDate)<12	and  year(w.readingDate) >= @yr and DATEDIFF(day,w.readingDate,FORMAT (getdate(), 'yyyy-MM-dd')) >=30 
	
	group by wc.consumerNo, wc.waterMeterNo, w.billingAddress ,wc.primaryMobileNo, msz.zoneName--, cy.calendarYear--, w.readingDate--,d.billingDate
	 having count(wc.consumerno)>3
	)
	union  all
(
SELECT  wc.consumerNo as ConsumerNo,wc.waterMeterNo AS WaterMeterNo,w.billingAddress AS BillingAddress,wc.primaryMobileNo as contactNo
--,DATEDIFF(day,CAST(w.readingDate AS DATE),GETDATE()) as OutstandingDays
,msz.zoneName
	,@yr as calendarYear
	--, FORMAT(w.readingDate, 'MMM') as months
	,0 as WaterTaxAmount,sum(d.totalAmount) as SewerageTaxAmount,count(wc.consumerno) as NoOfPendingBills

	from tblWaterMeterReading w
	inner join tblTransactionDetail td on w.transactionId = td.transactionId
	inner join tblDemand d on td.transactionId = d.transactionId
	inner join mstCalendarYear cy on d.calendarYearId = cy.calendarYearId
	inner join mstWaterConnection wc on w.waterConnectionId = wc.waterConnectionId	
	inner join mstTransactionType ty on td.transactionTypeId = ty.transactionTypeId
	inner join mstzone msz on wc.zoneId = msz.zoneId

	where d.isCancelled=0 and  d.taxId=15 and  d.isPaymentMade = 0 and td.transactionTypeId = 19 and msz.zoneId = @ZoneId and cast(convert(varchar,w.readingDate,112)as int)<=cast(convert(varchar,getdate(),112)as int)
	--cast(convert(varchar,CAST(concat(@yr,'-',@mth,'-',@dt) as datetime),112)as int)
	-- and  year(w.readingDate) >= @yr  and DATEDIFF(day,w.readingDate,FORMAT (getdate(), 'yyyy-MM-dd')) >=30 
	
	group by wc.consumerNo, wc.waterMeterNo, w.billingAddress ,wc.primaryMobileNo, msz.zoneName--, cy.calendarYear--, w.readingDate--,d.billingDate
	 having count(wc.consumerno)>3
	)
	)
	T GROUP BY  ConsumerNo,WaterMeterNo,BillingAddress,contactNo, NoOfPendingBills,zoneName,calendarYear
	
	order by ConsumerNo asc
end