
-- exec [dbo].[rptNoOfConnectionZoneWise]

create PROCEDURE [dbo].[rptNoOfConnectionZoneWise]

AS

begin

set nocount on;

SELECT  ROW_NUMBER() OVER(
ORDER BY (select 1)) AS Sl,* from(

select zo.zoneName, wct.waterConnectionType as ConnectionType,count(*) as NumberOfConnection
from mstWaterConnection mstWC
inner join mstWaterConnectionType wct on mstWC.waterConnectionTypeId = wct.waterConnectionTypeId
inner join mstZone zo on mstWC.zoneId = zo.zoneId
group by zo.zoneName, wct.waterConnectionType

)gg
end