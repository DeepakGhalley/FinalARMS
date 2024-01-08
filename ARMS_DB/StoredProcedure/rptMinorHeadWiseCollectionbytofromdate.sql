
--  exec [dbo].[rptMinorHeadWiseCollectionbytofromdate]  '20210801', '20210830'

CREATE PROCEDURE [dbo].[rptMinorHeadWiseCollectionbytofromdate] 
	@StartDate date, @EndDate date
	
AS


begin

	set nocount on;
	 
	Select ROW_NUMBER() over(order by(select 1)) as Sl,convert (varchar, @StartDate,103)  as FromDate,convert (varchar, @EndDate,103)  as ToDate,
	m.minorHeadName as MinorHeadName
	,(sum(de.totalAmount) + SUM(de.penaltyAmount)) as TotalAmount
	from mstMinorHead m
    inner join mstDetailHead as d on m.minorHeadId = d.minorHeadId
    inner join mstTaxMaster as t on d.detailHeadId = t.detailHeadId
    inner join tblLedger as de on t.taxId = de.taxId
	where
FORMAT (de.createdOn, 'yyyyMMdd') >= FORMAT (@StartDate, 'yyyyMMdd')
and FORMAT (de.createdOn, 'yyyyMMdd') <= FORMAT (@EndDate, 'yyyyMMdd')	
group by m.minorHeadId, m.minorHeadName
	 
	
end