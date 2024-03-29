
-- exec [dbo].[rptDifferentSizesMeterNo]

create PROCEDURE [dbo].[rptDifferentSizesMeterNo]

AS

begin

set nocount on;

SELECT  ROW_NUMBER() OVER(
ORDER BY (select 1)) AS Sl,* from(

select wmt.waterMeterType as MeterSizes,count(*) as NumberOfMeter
from mstWaterConnection mstWC
inner join mstWaterMeterType wmt on mstWC.waterMeterTypeId = wmt.waterMeterTypeId
where mstWC.isActive = 1
group by wmt.waterMeterType

)gg
end