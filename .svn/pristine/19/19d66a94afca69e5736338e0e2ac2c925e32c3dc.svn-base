

Create PROCEDURE [dbo].[GetLongTermLandLease]
	 @lli int,	@StartDate varchar(50),@EndDate varchar(50)
AS
DECLARE @s date, @e date;
SELECT  @s = @StartDate,  @e = @EndDate;
WITH DateRange(DateData) AS 
(
    SELECT @s as Date
    UNION ALL
    SELECT DATEADD(YEAR,1,DateData)
    FROM DateRange 
    WHERE DateData < @e
)
 SELECT  ROW_NUMBER() OVER(
       ORDER BY (select 1)) as Sl, DateData,year(DateData) as DemandYear,DATEADD(year, 1, DateData) as EDate,
(DATEDIFF(DAY,DateData,DATEADD(year, 1, DateData) ) ) as Days,@lli as landLeaseId,@StartDate as StartDate ,@EndDate as Enddate,
(select (demandNoId) from tblLandLeaseDemandDetail where landLeaseId=@lli and demandYear=year(DateData)) as DemandNoId
   
FROM DateRange  where DateData!=@e
OPTION (MAXRECURSION 0)
GO


