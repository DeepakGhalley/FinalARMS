CREATE PROCEDURE [dbo].[GetLandLeaseDemandScheduleMonthly]
	@Id int,@yr int,@StartDate varchar(20),@EndDate varchar(20)
AS
BEGIN
--EXEC [dbo].[GetVendorDemandSchedule] 1,'20200101','20200501'

-- SET NOCOUNT ON added to prevent extra result sets from
-- interfering with SELECT statements.
DECLARE @s SMALLDATETIME, @e SMALLDATETIME;
-- SELECT  @s =convert(varchar,@StartDate, 112) ,  @e =convert(varchar,@EndDate, 112);
SELECT  @s = @StartDate,  @e = @EndDate;

;WITH n(n) AS
(
  SELECT TOP (DATEDIFF(MONTH, @s, @e)+1) ROW_NUMBER() OVER
  (ORDER BY [object_id])-1 FROM sys.all_objects
),
x(n,fd,ld) AS
(
  SELECT n.n, DATEADD(MONTH, n.n, m.m), DATEADD(MONTH, n.n+1, m.m)
  FROM n, (SELECT DATEADD(DAY, 1-DAY(@s), @s)) AS m(m)
)
 select * from (
 SELECT  ROW_NUMBER() OVER(
       ORDER BY (select 1)) AS Sl, @Id AS Id,@StartDate as StartDate,@EndDate as EndDate, [Year] = CONVERT(VARCHAR(4), DATENAME(year, fd)), [MonthId] = CONVERT(VARCHAR(4), MONTH(fd)),[Month] = DATENAME(MONTH, fd), [Days] =CONVERT(VARCHAR(55), DATEDIFF(DAY, fd, ld))
	  
  - CASE WHEN @s > fd THEN (DATEDIFF(DAY, fd, @s)+1) ELSE 0 END
  - CASE WHEN @e < ld THEN (DATEDIFF(DAY, @e, ld)-1) ELSE 0 END
  
  ,(select (demandNoId) from tblLandLeaseDemandDetail where landLeaseId=@Id and demandYear=DATENAME(year, fd)and demandGenerateScheduleId= MONTH(fd) and demandYear=@yr) as DemandNoId
   ,TotalDays=day(EOMONTH((fd)))
  FROM x) NARAYAN WHERE Year=@yr ;

RETURN 0
end