
-- exec [dbo].[rptNoOfConnectionCategoryWise]

create PROCEDURE [dbo].[rptNoOfConnectionCategoryWise]

AS

begin

set nocount on;

SELECT  ROW_NUMBER() OVER(
ORDER BY (select 1)) AS Sl,* from(

select wct.waterConnectionType as ConnectionType,count(*) as NumberOfConnection
from mstWaterConnection mstWC
inner join mstWaterConnectionType wct on mstWC.waterConnectionTypeId = wct.waterConnectionTypeId
where mstWC.isActive = 1
group by wct.waterConnectionType

)gg
end