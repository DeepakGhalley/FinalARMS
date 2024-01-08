CREATE PROCEDURE [dbo].[rptDailyPaymentWiseDemandCollectionSum] 
	-- Add the parameters for the stored procedure here
	@StartDate date, @EndDate date
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
SELECT ROW_NUMBER() over(order by(select 1)) as Sl,convert (varchar, @StartDate,103)  as FromDate,convert (varchar, @EndDate,103)  as ToDate,  PaymentMode, ISNULL(sum(SubTotal),0.00)as SubTotal
FROM(
(
SELECT pm.paymentMode as PaymentMode,SUM(pl.amount) as SubTotal
	from  tblPaymentLeger pl 
	inner join enumPaymentMode pm on pl.paymentModeId = pm.paymentModeId
	where 		FORMAT (pl.createdOn, 'yyyyMMdd') >= FORMAT (@StartDate, 'yyyyMMdd') 
	and FORMAT (pl.createdOn, 'yyyyMMdd') <= FORMAT (@EndDate, 'yyyyMMdd') 
	and pl.paymentModeId in(1,2)
	group by pm.paymentMode
	)
	UNION
	(	
SELECT 'Others'  as PaymentMode	,SUM(pl.amount) as SubTotal
	from  tblPaymentLeger pl 
	inner join enumPaymentMode pm on pl.paymentModeId = pm.paymentModeId
	where 		FORMAT (pl.createdOn, 'yyyyMMdd') >= FORMAT (@StartDate, 'yyyyMMdd') 
	and FORMAT (pl.createdOn, 'yyyyMMdd') <= FORMAT (@EndDate, 'yyyyMMdd') 
	and pl.paymentModeId not in(1,2)
	)
	)t group by PaymentMode
END
GO
