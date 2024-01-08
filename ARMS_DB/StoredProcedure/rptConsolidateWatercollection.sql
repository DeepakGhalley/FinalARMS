
--  exec [dbo].[rptConsolidateWatercollection]  '20210801', '20210925'


CREATE PROCEDURE [dbo].[rptConsolidateWatercollection]
@StartDate date, @EndDate date
AS
BEGIN
SET NOCOUNT ON;
SELECT ROW_NUMBER() over(order by(select 1)) as Sl,convert (varchar, @StartDate,103)  as FromDate,convert (varchar, @EndDate,103)  as ToDate,
CAST(pl.createdOn as date) as PaymentDate,sum(pl.amount) as Amount

from  tblPaymentLeger pl
inner join AspNetUsers ap on pl.createdBy = ap.UserId
inner join tbl_role r on ap.RoleId = r.roleId
where FORMAT (pl.createdOn, 'yyyyMMdd') >= FORMAT (@StartDate, 'yyyyMMdd')
and FORMAT (pl.createdOn, 'yyyyMMdd') <= FORMAT (@EndDate, 'yyyyMMdd') and r.roleId = 45

group by  CAST(pl.createdOn as date)  
order by   CAST(pl.createdOn as date)   asc

end
RETURN 0