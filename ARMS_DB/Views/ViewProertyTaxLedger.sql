CREATE VIEW [dbo].[ViewProertyTaxLedger]
	AS 
select taxId,CalendarYear,TaxName,receiptId,CreatedOn,taxPayerId,MobileNo,FullName,CAddress,Cid,Ttin, PlotNo,PenaltyPeriod,sum(PenaltyAmount) as PenaltyAmount,sum(totalAmount) as totalAmount,
(sum(PenaltyAmount)+ sum(totalAmount)) as lastColumnTotal,landDetailId,isApportioned
from (
select tm.taxId, tm.TaxName,l.totalAmount,format(l.CreatedOn,'yyyy-MM-dd') as CreatedOn,l.receiptId,tp.taxPayerId,tp.MobileNo,(tp.firstName + ' ' + isnull(tp.MiddleName,'')+ isnull(tp.lastName,'')) as FullName
,tp.CAddress,tp.Cid,tp.Ttin, ld.PlotNo, c.CalendarYear,l.PenaltyAmount,l.PenaltyPeriod,ld.landDetailId,ld.isApportioned
from tblLedger l  
inner join mstTaxPayerProfile tp on l.taxPayerId=tp.taxPayerId
inner join mstLandDetail ld on l.landDetailId=ld.landDetailId
inner join MstTaxMaster tm on l.taxId=tm.taxId
inner join mstCalendarYear c on l.calendarYearId=c.calendarYearId
) tt group by taxId, TaxName,CreatedOn,receiptId,taxPayerId,MobileNo,FullName,CAddress,Cid,Ttin, PlotNo,CalendarYear,PenaltyPeriod,landDetailId,isApportioned
--order by taxId, calendarYear


