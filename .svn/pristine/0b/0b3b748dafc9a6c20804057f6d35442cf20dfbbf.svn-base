CREATE PROCEDURE [dbo].[GetDemandYears]
	@StartDate varchar(20),@EndDate varchar(20)
AS
DECLARE @s SMALLDATETIME, @e SMALLDATETIME;
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
 SELECT  distinct [Year] = CONVERT(VARCHAR(4), DATENAME(year, fd))
	 
  FROM x;
RETURN 0
