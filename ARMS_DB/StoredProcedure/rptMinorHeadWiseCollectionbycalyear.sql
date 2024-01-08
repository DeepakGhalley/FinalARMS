
Create PROCEDURE [dbo].[rptMinorHeadWiseCollectionbycalyear] 
	@CalendarYearId int
	
AS


begin


	set nocount on;
	
	Select ROW_NUMBER() over(order by(select 1)) as Sl,
	m.minorHeadName as MinorHeadName
	,sum(de.totalAmount) as TotalAmount
	from mstMinorHead m
    inner join mstDetailHead as d on m.minorHeadId = d.minorHeadId
    inner join mstTaxMaster as t on d.detailHeadId = t.detailHeadId
    inner join tblDemand as de on t.taxId = de.taxId
	where de.isPaymentMade = 1  and de.calendarYearId = @CalendarYearId and de.isCancelled = 0
	 group by m.minorHeadId, m.minorHeadName
			
			

end