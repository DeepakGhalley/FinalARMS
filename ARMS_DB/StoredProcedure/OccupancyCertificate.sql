
Create PROCEDURE [dbo].[OccupancyCertificate]
	@occupancyCertificateApplicationId int
AS
--	EXEC  [dbo].[OccupancyCertificate] 1

 declare @IsUnitOc bit
 set @IsUnitOc=(select isBuildingOC from [dbo].[trnOccupancyCertificateApplication] where [occupancyCertificateApplicationId]=@occupancyCertificateApplicationId)
if @IsUnitOc = 1
begin
			 SELECT ROW_NUMBER() over(order by(select 1)) as sl,  occupancyCertificateApplicationId as OccupancyCertificateApplicationId,ttin as Ttin,cid as Cid, t.firstName + isnull(t.middleName,'') + isnull(t.lastName,'') as TaxPayerName,convert(varchar,convert(decimal(11,3),landAcerage)) as LandAcerage,plotNo as PlotNo,landUseCategory as LandUseCategory,
			 landUseSubCategory as LandUseSubCategory,buildingNo as BuildingNo,constructionType as ConstructionType,convert(varchar,convert(decimal(11,3),buildupArea))   as BuildupArea,convert(varchar,convert(int,numberOfFloors))  as NumberOfFloors,buildingUnitUseType as BuildingUnitUseType,buildingUnitClassName as BuildingUnitClassName,
			 noOfUnit as NoOfUnit,floorArea as FloorArea,location as Location,yearOfConstruction as YearOfConstruction,convert (varchar, oc.dateOfFinalInspection,103) as DateOfFinalInspection,ocReferenceNo as OcReferenceNo, convert(varchar,convert(decimal(11,3),lo.pLR))   as Plr,l.thramNo as ThramNo,lo.ownershipPercentage as OwnershipPercentage,eo.occupancyType as OccupancyType
		,lp.lapName,ot.landOwnershipType, fn.floorName as FloorName, oc.isBuildingOC as isBuildingOC,oc.validTillDate as validTillDate
		from mstBuildingDetail b 
			 left join mstLandDetail l on b.landDetailId = l.landDetailId
			
			  left join trnOccupancyCertificateApplication oc  on b.buildingDetailId=oc.buildingDetailId 
				left join mstBuildingUnitDetail bu on b.buildingDetailId =bu.buildingDetailId and  bu.taxPayerId=oc.taxPayerId
			  left join tblLandOwnershipDetail lo on  oc.landOwnershipId=lo.landOwnershipId
			  LEFT JOIN enumLandOwnershipType		ot on lo.landOwnershipTypeId=ot.landOwnershipTypeId			
			 left join mstTaxPayerProfile t on lo.taxPayerId = t.taxPayerId
			left join mstLandUseSubCategory lsc on l.landUseSubCategoryId = lsc.landUseSubCategoryId
			left join mstLandUseCategory lc on lsc.landUseCategoryId = lc.landUseCategoryId
			left join mstConstructionType ct on b.constructionTypeId = ct.constructionTypeId
			 left join mstBuildingUnitClass buc on bu.buildingUnitClassId = buc.buildingUnitClassId
			 left join mstBuildingUnitUseType but on bu.buildingUnitUseTypeId = but.buildingUnitUseTypeId
			 left join enumOccupancyType eo on oc.occupancyTypeId = eo.occupancyTypeId
			 left join mstFloorName fn on bu.floorNameId = fn.floorNameId
			 left join mstLap lp on l.lapId=lp.lapId
			 where oc.occupancyCertificateApplicationId= @occupancyCertificateApplicationId
 end
 else
 begin
			 SELECT ROW_NUMBER() over(order by(select 1)) as sl,
			
			 occupancyCertificateApplicationId as OccupancyCertificateApplicationId,t.ttin as Ttin,t.cid as Cid, t.firstName + isnull(t.middleName,'') + isnull(t.lastName,'') as TaxPayerName,convert(varchar,convert(decimal(11,3),landAcerage))  as LandAcerage,plotNo as PlotNo,landUseCategory as LandUseCategory,
			 landUseSubCategory as LandUseSubCategory,buildingNo as BuildingNo,constructionType as ConstructionType,convert(varchar,convert(decimal(11,3),buildupArea))   as BuildupArea,convert(varchar,convert(int,numberOfFloors))  as NumberOfFloors,buildingUnitUseType as BuildingUnitUseType,buildingUnitClassName as BuildingUnitClassName,
			 noOfUnit as NoOfUnit,floorArea as floorArea,location as Location,yearOfConstruction as YearOfConstruction,convert (varchar, o.dateOfFinalInspection,103) as DateOfFinalInspection,ocReferenceNo as OcReferenceNo, convert(varchar,convert(decimal(11,3),lo.pLR)) as Plr,l.thramNo as ThramNo,lo.ownershipPercentage as OwnershipPercentage,eo.occupancyType as OccupancyType
			,lp.lapName,ot.landOwnershipType, fn.floorName as FloorName,o.isBuildingOC as isBuildingOC,o.validTillDate as validTillDate
			from trnOccupancyCertificateApplication o
			
			-- left join mstTaxPayerProfile t on o.taxPayerId = t.taxPayerId
			 left join mstLandDetail l on o.landDetailId = l.landDetailId
			 left join tblLandOwnershipDetail lo on o.landDetailId = lo.landDetailId AND o.taxPayerId=lo.taxPayerId
			  LEFT JOIN enumLandOwnershipType	ot on lo.landOwnershipTypeId=ot.landOwnershipTypeId

			 left join mstTaxPayerProfile t on o.taxPayerId = t.taxPayerId
			 left join mstLandUseSubCategory lsc on l.landUseSubCategoryId = lsc.landUseSubCategoryId
			 left join mstLandUseCategory lc on lsc.landUseCategoryId = lc.landUseCategoryId
			 left join mstBuildingDetail b on o.buildingDetailId = b.buildingDetailId
			 left join mstConstructionType ct on b.constructionTypeId = ct.constructionTypeId
			 left join mstBuildingUnitDetail bu on o.buildingUnitDetailId = bu.buildingUnitDetailId
			 left join mstFloorName fn on bu.floorNameId = fn.floorNameId
			 left join mstBuildingUnitClass buc on bu.buildingUnitClassId = buc.buildingUnitClassId
			 left join mstBuildingUnitUseType but on bu.buildingUnitUseTypeId = but.buildingUnitUseTypeId
			  left join mstTaxPayerProfile tu on o.taxPayerId = tu.taxPayerId
			   left join enumOccupancyType eo on o.occupancyTypeId = eo.occupancyTypeId
			   	 left join mstLap lp on l.lapId=lp.lapId
			 where o.occupancyCertificateApplicationId = @occupancyCertificateApplicationId
 end

 RETURN 0