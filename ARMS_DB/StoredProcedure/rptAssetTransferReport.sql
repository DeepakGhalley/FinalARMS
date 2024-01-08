
--	EXEC [dbo].[rptAssetTransferReport]

create PROCEDURE [dbo].[rptAssetTransferReport] 
	@FromDate  date ,@ToDate  date
	
AS
BEGIN
SET NOCOUNT ON;


select ROW_NUMBER() OVER(
	ORDER BY (select 1)) AS Sl, (pah.PrimaryAccountHeadSymbol + sah.SecondaryaccountHeadSymbol + tah.TertiaryAccountHeadSymbol + 
	'/TT/' + div.DivisionCode + '/' + section.SectionCode + '/' + af.AssetFunctionDescription + '/' + area.AreaCode + '/' + zo.ZoneCode + '/' + Asset.AssetCode) as AssetNumber,
	section.SectionName as transferfrom, sec.SectionName as transferto, Asset.assetCode, Asset.assetName, tblAT.transferDate
	from mstAsset Asset

	inner join tblAssetTransfer tblAT on Asset.assetId = tblAT.assetId
	inner join mstArea area on Asset.areaId = area.areaId
	inner join mstSection section on Asset.sectionId = section.sectionId
	inner join mstDivision div on section.divisionId = div.divisionId
	inner join mstAssetFunction af on Asset.assetFunctionId = af.assetFunctionId
	inner join mstZone zo on Asset.zoneId = zo.zoneId
	inner join mstTertiaryAccountHead tah on Asset.tertiaryAccountHeadId=tah.TertiaryAccountHeadId
	inner join mstSecondaryAccountHead sah on tah.secondaryAccountHeadId=sah.secondaryAccountHeadId
	inner join mstPrimaryAccountHead pah on sah.primaryAccountHeadId=pah.primaryAccountHeadId

	inner join mstSection sec on tblAT.transferToSectionId = sec.SectionId
	
	where tblAT.transferDate >= @FromDate and tblAT.transferDate <= @ToDate
END