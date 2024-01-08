--	EXEC [dbo].[rptAssetMaintenanceReport]

create PROCEDURE [dbo].[rptAssetMaintenanceReport] 
	@FromDate  date, @ToDate  date
	
AS
BEGIN
SET NOCOUNT ON;


select ROW_NUMBER() OVER(
	ORDER BY (select 1)) AS Sl, (pah.PrimaryAccountHeadSymbol + sah.SecondaryaccountHeadSymbol + tah.TertiaryAccountHeadSymbol + 
	'/TT/' + div.DivisionCode + '/' + section.SectionCode + '/' + af.AssetFunctionDescription + '/' + area.AreaCode + '/' + zo.ZoneCode + '/' + Asset.AssetCode) as AssetNumber,
	tblAM.maintenanceDate, Asset.assetCode, Asset.assetName
	from mstAsset Asset

	inner join tblAssetMaintenance tblAM on Asset.assetId = tblAM.assetId
	inner join mstArea area on Asset.areaId = area.areaId
	inner join mstSection section on Asset.sectionId = section.sectionId
	inner join mstDivision div on section.divisionId = div.divisionId
	inner join mstAssetFunction af on Asset.assetFunctionId = af.assetFunctionId
	inner join mstZone zo on Asset.zoneId = zo.zoneId
	inner join mstTertiaryAccountHead tah on Asset.tertiaryAccountHeadId=tah.TertiaryAccountHeadId
	inner join mstSecondaryAccountHead sah on tah.secondaryAccountHeadId=sah.secondaryAccountHeadId
	inner join mstPrimaryAccountHead pah on sah.primaryAccountHeadId=pah.primaryAccountHeadId

	where tblAM.maintenanceDate >= @FromDate and tblAM.maintenanceDate <= @ToDate
END