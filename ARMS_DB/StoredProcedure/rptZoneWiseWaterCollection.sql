

create PROCEDURE [dbo].[rptZoneWiseWaterCollection]
@ZoneId int 

AS
begin

set nocount on;
SELECT  ROW_NUMBER() OVER(
ORDER BY (select 1)) AS Sl,* from(

--RESITDENTIAL
select wct.waterConnectionType as WaterConnectionType, count(wc.waterConnectionId) as TotalNo, ms.zoneName as zonename
from mstWaterConnection wc
left join mstWaterConnectionType wct on wc.waterConnectionTypeId = wct.waterConnectionTypeId
left join mstZone ms on wc.zoneId = ms.zoneId
where wc.waterConnectionTypeId = 1 and wc.zoneId = @ZoneId
group by wct.waterConnectionType, ms.zoneName

union all

--COMMERCIAL
select wct.waterConnectionType as WaterConnectionType, count(wc.waterConnectionId) as TotalNo, ms.zoneName as zonename
from mstWaterConnection wc
left join mstWaterConnectionType wct on wc.waterConnectionTypeId = wct.waterConnectionTypeId
left join mstZone ms on wc.zoneId = ms.zoneId
where wc.waterConnectionTypeId = 2 and wc.zoneId = @ZoneId
group by wct.waterConnectionType, ms.zoneName

union all

--INSTITUTIONAL
select wct.waterConnectionType as WaterConnectionType, count(wc.waterConnectionId) as TotalNo, ms.zoneName as zonename 
from mstWaterConnection wc
left join mstWaterConnectionType wct on wc.waterConnectionTypeId = wct.waterConnectionTypeId
left join mstZone ms on wc.zoneId = ms.zoneId
where wc.waterConnectionTypeId = 3 and wc.zoneId = @ZoneId
group by wct.waterConnectionType, ms.zoneName

union all

--INDUSTRIAL
select wct.waterConnectionType as WaterConnectionType, count(wc.waterConnectionId) as TotalNo, ms.zoneName as zonename 
from mstWaterConnection wc
left join mstWaterConnectionType wct on wc.waterConnectionTypeId = wct.waterConnectionTypeId
left join mstZone ms on wc.zoneId = ms.zoneId
where wc.waterConnectionTypeId = 4 and wc.zoneId = @ZoneId
group by wct.waterConnectionType, ms.zoneName
)w
end