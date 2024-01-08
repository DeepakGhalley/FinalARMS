CREATE PROCEDURE [dbo].[rptPrescinctWiseCunt]
	
AS
	SELECT ROW_NUMBER() over(order by(select 1)) as Sl , landUseCategory as LandUseCategory ,landUseSubCategory as LandUseSubCategory,sum(LandCount) as LandCount,sum(landAcerage) AS TotalLandAcerage,SUM(BuildingCount) AS BuildingCount
FROM (
(
select c.landUseCategory,sc.landUseSubCategory,
count(l.landDetailId) as LandCount,sum(l.landAcerage) as landAcerage,0 as BuildingCount
from mstLandDetail l 
inner join mstLandUseSubCategory sc on l.landUseSubCategoryId=sc.landUseSubCategoryId
inner join mstLandUseCategory c on sc.landUseCategoryId=c.landUseCategoryId
where sc.isActive=1
group by c.landUseCategory,sc.landUseSubCategory

)
UNION
(
select c.landUseCategory,sc.landUseSubCategory,0 as LandCount,0 as landAcerage,count(b.buildingDetailId) as BuildingCount
from mstLandDetail l 
inner join mstLandUseSubCategory sc on l.landUseSubCategoryId=sc.landUseSubCategoryId
inner join mstLandUseCategory c on sc.landUseCategoryId=c.landUseCategoryId
inner join mstBuildingDetail b on l.landDetailId=b.landDetailId
where sc.isActive=1
group by c.landUseCategory,sc.landUseSubCategory

)

)
T group by LandUseCategory,landUseSubCategory
ORDER BY landUseCategory,landUseSubCategory
RETURN 0
