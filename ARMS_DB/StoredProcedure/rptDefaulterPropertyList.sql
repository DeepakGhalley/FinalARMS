
--	exec [dbo].[rptDefaulterPropertyList] '21','2'

create PROCEDURE [dbo].[rptDefaulterPropertyList]
@CalendarYearId int, @taxPayerTypeId int
AS
BEGIN
	SET NOCOUNT ON;	
	declare @cyr int;declare @tpt varchar(50);
	
set @cyr=(select calendarYear from mstCalendarYear where calendarYearId=@CalendarYearId);
set @tpt=(select taxPayerType from enumTaxPayerType where taxPayerTypeId=@taxPayerTypeId);

SELECT   DISTINCT *, ROW_NUMBER() over(order by(select 1)) as Sl FROM(
	(
	SELECT  tpp.firstName + isnull(tpp.middleName,' ') + isnull(tpp.lastName,' ') as TaxPayerName,tpt.taxPayerType as  TaxPayerType
	,case when tpp.taxPayerTypeId=1 then  tpp.cid else '-' end as CID,tpp.ttin as TTIN,l.plotNo as PlotNo
	,isnull(tpp.mobileNo,'-') as MobileNo 	
	,cy.calendarYear as CalendarYear,o.lastTaxPaidYear as LastTaxPaidYear, sum(d.totalAmount)  as TotalAmount
	from tblDemand d

	inner join mstTaxPayerProfile tpp on d.taxPayerId = tpp.taxPayerId
	inner join enumTaxPayerType tpt on tpp.taxPayerTypeId = tpt.taxPayerTypeId
	inner join mstCalendarYear cy on d.calendarYearId = cy.calendarYearId
	inner join tblTransactionDetail td on d.transactionId = td.transactionId
	inner join mstTransactionType ty on td.transactionTypeId = ty.transactionTypeId
	inner join tblLandOwnershipDetail o on d.landOwnershipId=o.landOwnershipId
		inner join mstLandDetail l on o.landDetailId=l.landDetailId
	where d.isCancelled=0 and d.isPaymentMade = 0 and o.pLR>0 and ty.transactionTypeId = 20 and d.calendarYearId <= @CalendarYearId and tpt.taxPayerTypeId = @taxPayerTypeId

	group by  tpp.firstName , tpp.middleName, tpp.lastName,tpp.mobileNo, tpp.cid, tpp.ttin, d.taxPayerId, tpp.taxPayerTypeId,tpt.taxPayerType,cy.calendarYear,o.lastTaxPaidYear,l.plotNo
	-- order by tpp.cid asc
	)
	UNION ALL
	(
	
select  tp.firstName + isnull(tp.middleName,' ') + isnull(tp.lastName,' ') as TaxPayerName, @tpt as TaxPayerType
,case when tp.taxPayerTypeId=1 then  tp.cid else '-' end as CID,tp.ttin as TTIN,l.plotNo as PlotNo
,isnull(tp.mobileNo,'-') as MobileNo
,@cyr as CalendarYear,ISNULL(ow.lastTaxPaidYear,'-')  as LastTaxPaidYear, 0 as TotalAmount
from
(select distinct o.landOwnershipId from tblLandOwnershipDetail o
	where o.isActive=1 and o.landOwnershipId not in(

						select distinct d.landOwnershipId 
						from tblDemand d						
						inner join tblTransactionDetail td on d.transactionId = td.transactionId
						inner join mstTaxPayerProfile tp on d.taxPayerId=tp.taxPayerId
						where td.transactionTypeId = 20 and tp.taxPayerTypeId = 2  and d.calendarYearId =2021
	)
	)t
	left join tblLandOwnershipDetail ow on t.landOwnershipId=ow.landOwnershipId
	inner join mstTaxPayerProfile tp on ow.taxPayerId=tp.taxPayerId 
	INNER JOIN mstLandDetail l on ow.landDetailId=l.landDetailId
	where   ow.pLR>0 and  tp.taxPayerTypeId=@taxPayerTypeId and (ow.lastTaxPaidYear<2021 or ow.lastTaxPaidYear is null)
	--order by TaxPayerName
	)
	UNION ALL
	(select  tp.firstName + isnull(tp.middleName,' ') + isnull(tp.lastName,' ') as TaxPayerName, @tpt as TaxPayerType
,case when tp.taxPayerTypeId=1 then  tp.cid else '-' end as CID,tp.ttin as TTIN,'-' as PlotNo
,isnull(tp.mobileNo,'-') as MobileNo
,@cyr as CalendarYear,'-' as LastTaxPaidYear, 0 as TotalAmount

from mstTaxPayerProfile tp where tp.isActive=1 and tp.taxPayerTypeId=@taxPayerTypeId and tp.taxPayerId not in(select taxPayerId from tblLandOwnershipDetail )
)
	)U ORDER BY CID asc,TaxPayerName
end