
--	EXEC [dbo].[rptStatusReportAsset] 1


create PROCEDURE [dbo].[rptStatusReportAsset] 
	@isActiveId int 

AS

if @isActiveId>0
begin

set nocount on;


--isActive true
select ROW_NUMBER() OVER(
ORDER BY (select 1)) AS Sl, Asset.assetName, Asset.responsiblePerson, area.areaName, 
lap.lapName, section.sectionName, af.assetFunctionName, tah.TertiaryAccountHeadName, sah.secondaryAccountHeadName, pah.primaryAccountHeadName
from mstAsset Asset
left join mstArea area on Asset.areaId = area.areaId
left join mstLap lap on Asset.lapId = lap.lapId
left join mstSection section on Asset.sectionId = section.sectionId
left join mstAssetFunction af on Asset.assetFunctionId = af.assetFunctionId

left join mstTertiaryAccountHead tah on Asset.tertiaryAccountHeadId=tah.TertiaryAccountHeadId
left join mstSecondaryAccountHead sah on tah.secondaryAccountHeadId=sah.secondaryAccountHeadId
left join mstPrimaryAccountHead pah on sah.primaryAccountHeadId=pah.primaryAccountHeadId
where Asset.isActive = 1
--group by Asset.assetId, Asset.assetName, Asset.responsiblePerson

end
else
begin

--isActive false
select ROW_NUMBER() OVER(
ORDER BY (select 1)) AS Sl, Asset.assetName, Asset.responsiblePerson, area.areaName,
lap.lapName, section.sectionName, af.assetFunctionName, tah.TertiaryAccountHeadName, sah.secondaryAccountHeadName, pah.primaryAccountHeadName
from mstAsset Asset
left join mstArea area on Asset.areaId = area.areaId
left join mstLap lap on Asset.lapId = lap.lapId
left join mstSection section on Asset.sectionId = section.sectionId
left join mstAssetFunction af on Asset.assetFunctionId = af.assetFunctionId

left join mstTertiaryAccountHead tah on Asset.tertiaryAccountHeadId=tah.TertiaryAccountHeadId
left join mstSecondaryAccountHead sah on tah.secondaryAccountHeadId=sah.secondaryAccountHeadId
left join mstPrimaryAccountHead pah on sah.primaryAccountHeadId=pah.primaryAccountHeadId
where Asset.isActive = 0
--group by Asset.assetId, Asset.assetName, Asset.responsiblePerson

end
