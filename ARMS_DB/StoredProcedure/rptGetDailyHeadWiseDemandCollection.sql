

--	exec [dbo].[rptGetDailyHeadWiseDemandCollection] '06/05/2021', '06/05/2021'

CREATE PROCEDURE [dbo].[rptGetDailyHeadWiseDemandCollection] 
	@StartDate date, @EndDate date
	
AS

begin

	set nocount on;

	select ROW_NUMBER() over(order by(select 1)) as sl, CONVERT(varchar, l.paymentDate,103) as PaymentDate, t.taxName as TaxName,
	l.totalAmount as TotalAmount, l.penaltyAmount as PenaltyAmount,
	CONVERT(varchar, @StartDate ,103) as StartDate, CONVERT(varchar, @EndDate ,103)  as EndDate
	
	from tblLedger as l
	inner join tblDemand as d on l.demandId = d.demandId
	inner join mstTaxMaster as t on l.taxId = t.taxId
	where d.isPaymentMade = 1 and 
		FORMAT (l.paymentDate, 'yyyyMMdd') >= FORMAT (@StartDate, 'yyyyMMdd') 
	and FORMAT (l.paymentDate, 'yyyyMMdd') <= FORMAT (@EndDate, 'yyyyMMdd') 

end