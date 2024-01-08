
--	EXEC [dbo].[rptAssetListByResponsiblePerson] @responsiblePerson = 'Jigme'

--	EXEC [dbo].[rptAssetListByResponsiblePerson] 'Jigme'

create PROCEDURE [dbo].[rptAssetListByResponsiblePerson] 
	@responsiblePerson varchar(60)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    select ROW_NUMBER() OVER(
	ORDER BY (select 1)) AS Sl, Asset.assetName, Asset.responsiblePerson,area.areaName, 
	lap.lapName, section.sectionName, af.assetFunctionName, tah.TertiaryAccountHeadName, sah.secondaryAccountHeadName, pah.primaryAccountHeadName
	from mstAsset Asset
	left join mstArea area on Asset.areaId = area.areaId
	left join mstLap lap on Asset.lapId = lap.lapId
	left join mstSection section on Asset.sectionId = section.sectionId
	left join mstAssetFunction af on Asset.assetFunctionId = af.assetFunctionId

	left join mstTertiaryAccountHead tah on Asset.tertiaryAccountHeadId=tah.TertiaryAccountHeadId
	left join mstSecondaryAccountHead sah on tah.secondaryAccountHeadId=sah.secondaryAccountHeadId
	left join mstPrimaryAccountHead pah on sah.primaryAccountHeadId=pah.primaryAccountHeadId
	where Asset.responsiblePerson = @responsiblePerson
	--group by Asset.assetId, Asset.assetName, Asset.responsiblePerson
	
END