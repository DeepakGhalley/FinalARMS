CREATE PROCEDURE [dbo].[GetUnitDetailsByBuildingId]
	@buildingDetailId INT, @ttin VARCHAR(200)
AS
	
select 
b.LandDetailId ,
                                 x.BuildingUnitDetailId,
                                   x.BuildingDetailId,
                                    c.BuildingUnitClassId,
                              c.BuildingUnitClassName,
                                  ut.BuildingUnitUseType,
                               x.BuildingUnitUseTypeId,
                                  ot.UnitOwnerType,
                                x.UnitOwnerTypeId,
                               x.FlatNo,
                                x.FloorNo,
                                  f.FloorName,
                              x.FloorNameId,
                                 x.NoOfrooms,
                                 x.IsMainOwner,
                                  x.FloorArea,
                                  b.BuildingNo,
                                  b.BuildupArea,
                                 x.NoOfUnit,
                                x.IsRegularized,
                              x.TaxPayerId,
                               t.Cid,
                                  t.Ttin,
								  case when o.IssueDate is not null then o.IssueDate else '1900-01-01' end as OccupancyCertificateIssueDate
								  ,isnull(o.OcReferenceNo,'')as OccupancyCertificateNo,
                                (t.FirstName+isnull(t.MiddleName,'')+isnull(t.lastName,'')) as FullName
							
from mstBuildingUnitDetail x
inner join mstBuildingDetail b on x.buildingDetailId=b.buildingDetailId
inner join mstBuildingUnitClass c on x.buildingUnitClassId=c.buildingUnitClassId
inner join mstFloorName f on x.floorNameId=f.floorNameId
inner join mstBuildingUnitUseType ut on x.buildingUnitUseTypeId=ut.buildingUnitUseTypeId
inner join enumUnitOwnerType ot on x.unitOwnerTypeId=ot.unitOwnerTypeId
inner join mstTaxPayerProfile t on x.taxPayerId=t.taxPayerId
left join ViewLatestOcDetail o on x.taxPayerId=o.taxPayerId and b.buildingDetailId=o.buildingDetailId

where b.buildingDetailId=@buildingDetailId and t.ttin=@ttin 

RETURN 0
