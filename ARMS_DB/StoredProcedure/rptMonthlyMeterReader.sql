

--exec [dbo].[rptMonthlyMeterReader] '13','3','2021'
CREATE  PROCEDURE [dbo].[rptMonthlyMeterReader]
@ZoneId int, @MonthId int, @YearId int
AS
BEGIN
	SET NOCOUNT ON;	
	SELECT ROW_NUMBER() over(order by(select 1)) as Sl, wc.consumerNo as ConsumerNo, mr.billingAddress as BillingAddress, wc.waterMeterNo as MeterNo,
	mr.previousReading as PrevReading, convert(varchar,mr.previousReadingDate,3) as PrevReadingDate, '' as CurrentReading, '' as Remarks
	,z.zoneReader,z.zoneName	,FORMAT (mr.readingDate, 'dd/MM/yyyy')  as ReadingYearMonth
	from tblWaterMeterReading mr 
	inner join mstWaterConnection wc on mr.waterConnectionId = wc.waterConnectionId
    inner join mstzone z on mr.zoneId = z.ZoneId	
	where  mr.zoneId = @ZoneId and year(mr.readingDate) = @YearId and month(mr.readingDate) = @MonthId
	
	group by wc.consumerNo, mr.billingAddress, wc.waterMeterNo, mr.previousReading, mr.previousReadingDate, mr.readingDate,z.zoneReader,z.zoneName
end

