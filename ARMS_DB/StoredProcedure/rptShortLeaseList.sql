--  exec [dbo].[rptShortLeaseList]  '20210424', '20210930'


Create PROCEDURE [dbo].[rptShortLeaseList]
@StartDate date, @EndDate date
AS
BEGIN
SET NOCOUNT ON;
SELECT ROW_NUMBER() over(order by(select 1)) as Sl,convert (varchar, @StartDate,103) as FromDate,
convert (varchar, @EndDate,103)  as ToDate,  tpp.ttin, ld.plotNo, ld.landAcerage as Area, ll.leaseAmount

from  tblLandLease ll
inner join mstLandDetail ld on ll.landDetailId = ld.landDetailId
inner join mstTaxPayerProfile tpp on ll.taxPayerId = tpp.taxPayerId
where FORMAT (ll.createdOn, 'yyyyMMdd') >= FORMAT (@StartDate, 'yyyyMMdd')
and FORMAT (ll.createdOn, 'yyyyMMdd') <= FORMAT (@EndDate, 'yyyyMMdd') and ll.leaseTypeId = 2
order by ll.landLeaseId


end
RETURN 0