
--	EXEC [dbo].[rptAssetListing] 1 ,1,84

create PROCEDURE [dbo].[rptAssetListing]
	@PrimaryAccountHeadId int, @SecondaryAccountHeadId int, @TertiaryAccountHeadId int
	
AS
BEGIN
SET NOCOUNT ON;

if(@SecondaryAccountHeadId = '' and @TertiaryAccountHeadId = '' )
BEGIN
	

    select ROW_NUMBER() OVER(
	ORDER BY (select 1)) AS Sl,Asset.remarks, Asset.assetName, Asset.responsiblePerson, area.areaName, lap.lapName, section.sectionName, af.assetFunctionName
	from mstAsset Asset
	left join mstTertiaryAccountHead tah on Asset.tertiaryAccountHeadId=tah.TertiaryAccountHeadId
	left join mstSecondaryAccountHead sah on tah.secondaryAccountHeadId=sah.secondaryAccountHeadId
	left join mstPrimaryAccountHead pah on sah.primaryAccountHeadId=pah.primaryAccountHeadId

	left join mstArea area on Asset.areaId = area.areaId
	left join mstLap lap on Asset.lapId = lap.lapId
	left join mstSection section on Asset.sectionId = section.sectionId
	left join mstAssetFunction af on Asset.assetFunctionId = af.assetFunctionId

	where pah.primaryAccountHeadId = @PrimaryAccountHeadId 
	--or sah.secondaryAccountHeadId = @SecondaryAccountHeadId 
	--or tah.TertiaryAccountHeadId = @TertiaryAccountHeadId
END

ELSE IF(@TertiaryAccountHeadId = '' )
BEGIN
	

    select ROW_NUMBER() OVER(
	ORDER BY (select 1)) AS Sl,Asset.remarks, Asset.assetName, Asset.responsiblePerson, area.areaName, lap.lapName, section.sectionName, af.assetFunctionName
	from mstAsset Asset
	left join mstTertiaryAccountHead tah on Asset.tertiaryAccountHeadId=tah.TertiaryAccountHeadId
	left join mstSecondaryAccountHead sah on tah.secondaryAccountHeadId=sah.secondaryAccountHeadId
	left join mstPrimaryAccountHead pah on sah.primaryAccountHeadId=pah.primaryAccountHeadId

	left join mstArea area on Asset.areaId = area.areaId
	left join mstLap lap on Asset.lapId = lap.lapId
	left join mstSection section on Asset.sectionId = section.sectionId
	left join mstAssetFunction af on Asset.assetFunctionId = af.assetFunctionId

	where pah.primaryAccountHeadId = @PrimaryAccountHeadId and sah.secondaryAccountHeadId = @SecondaryAccountHeadId 
	--or tah.TertiaryAccountHeadId = @TertiaryAccountHeadId
END

else
BEGIN
	

    select ROW_NUMBER() OVER(
	ORDER BY (select 1)) AS Sl,Asset.remarks, Asset.assetName, Asset.responsiblePerson, area.areaName, lap.lapName, section.sectionName, af.assetFunctionName
	from mstAsset Asset
	left join mstTertiaryAccountHead tah on Asset.tertiaryAccountHeadId=tah.TertiaryAccountHeadId
	left join mstSecondaryAccountHead sah on tah.secondaryAccountHeadId=sah.secondaryAccountHeadId
	left join mstPrimaryAccountHead pah on sah.primaryAccountHeadId=pah.primaryAccountHeadId

	left join mstArea area on Asset.areaId = area.areaId
	left join mstLap lap on Asset.lapId = lap.lapId
	left join mstSection section on Asset.sectionId = section.sectionId
	left join mstAssetFunction af on Asset.assetFunctionId = af.assetFunctionId

	where pah.primaryAccountHeadId = @PrimaryAccountHeadId and sah.secondaryAccountHeadId = @SecondaryAccountHeadId 
	and tah.TertiaryAccountHeadId = @TertiaryAccountHeadId
END
end