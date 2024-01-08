
--  exec [dbo].[rptShortAndLongTermCollectionReport]  '20210424', '20210930', '3'


create PROCEDURE [dbo].[rptShortAndLongTermCollectionReport]
@StartDate date, @EndDate date, @LeaseType int

AS
BEGIN
SET NOCOUNT ON;

if(@LeaseType = 2)
BEGIN

SELECT ROW_NUMBER() over(order by(select 1)) as Sl,convert (varchar, @StartDate,103) as FromDate,
convert (varchar, @EndDate,103)  as ToDate, ld.plotNo, ld.landAcerage as Acerage, l.totalAmount, l.penaltyAmount, l.penaltyPeriod,
sum(l.totalAmount + l.penaltyAmount) as grandTotal,datename(month,l.createdOn) as periodMonth, datename(year,l.createdOn) as yearPeriod

from  tblLandLease ll
inner join tblLandLeaseDemandDetail lnd on ll.landLeaseId = lnd.landLeaseId
inner join mstLandDetail ld on ll.landDetailId = ld.landDetailId
inner join tblLedger l on lnd.landLeaseDemandDetailId = l.landLeaseDemandDetailId
where FORMAT (ll.createdOn, 'yyyyMMdd') >= FORMAT (@StartDate, 'yyyyMMdd')
and FORMAT (ll.createdOn, 'yyyyMMdd') <= FORMAT (@EndDate, 'yyyyMMdd') and ll.leaseTypeId = 2
group by ld.plotNo, ld.landAcerage, l.totalAmount, l.penaltyAmount,l.penaltyPeriod,ll.landLeaseId,l.createdOn
order by ll.landLeaseId
end

else if(@LeaseType = 3)
BEGIN

SELECT ROW_NUMBER() over(order by(select 1)) as Sl,convert (varchar, @StartDate,103) as FromDate,
convert (varchar, @EndDate,103)  as ToDate, ld.plotNo, ld.landAcerage as Acerage, l.totalAmount, l.penaltyAmount, l.penaltyPeriod,
sum(l.totalAmount + l.penaltyAmount) as grandTotal, datename(month,l.createdOn) as periodMonth, datename(year,l.createdOn) as yearPeriod

from  tblLandLease ll
inner join tblLandLeaseDemandDetail lnd on ll.landLeaseId = lnd.landLeaseId
inner join mstLandDetail ld on ll.landDetailId = ld.landDetailId
inner join tblLedger l on lnd.landLeaseDemandDetailId = l.landLeaseDemandDetailId
where FORMAT (ll.createdOn, 'yyyyMMdd') >= FORMAT (@StartDate, 'yyyyMMdd')
and FORMAT (ll.createdOn, 'yyyyMMdd') <= FORMAT (@EndDate, 'yyyyMMdd') and ll.leaseTypeId = 3
group by ld.plotNo, ld.landAcerage, l.totalAmount, l.penaltyAmount,l.penaltyPeriod,ll.landLeaseId,l.createdOn
order by ll.landLeaseId
end

end
RETURN 0