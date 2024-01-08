CREATE PROCEDURE [dbo].[GetOwnershipDetailByLandOwnershipId]
	
	-- Add the parameters for the stored procedure here
	@LandOwnershipIds varchar(500)
	,@CalendarYearId int
AS
BEGIN
	--	exec [dbo].[GetOwnershipDetailByLandOwnershipId] '103281,5', 20

	SET NOCOUNT ON;
	
--declare @CalendarYearId int ;
declare  @CalendarYear int;declare  @TotalDays int;declare @StartDate date;declare @EndDate date;
--set @CalendarYearId=20;
set @CalendarYear=(select CalendarYear from mstCalendarYear where calendarYearId=@CalendarYearId);
set @StartDate=(select startDate from mstCalendarYear where calendarYearId=@CalendarYearId);
set @EndDate=(select EndDate from mstCalendarYear where calendarYearId=@CalendarYearId);
SET @TotalDays=DATEDIFF(day,@StartDate,@EndDate)+1;
SELECT ROW_NUMBER() over(order by(select 1)) as Sl
,Tax, firstName + isnull(middleName,'') + isnull(lastName,'') as TaxPayerName, landOwnershipId,landDetailId,landOwnershipTypeId,taxPayerId,constructionTypeId
,buildingUnitClassId,buildingUnitUseTypeId,pLR,ttin,cid
,plotNo,thramNo,lastTaxPaidYear,LandTaxId, LandTaxRate, LandTaxAmount,Penaltydays, LandTaxPenalty ,UDTaxId,UDTaxApplicable, UDTaxRate,UDTax, penaltyOrRate,UDTaxPenalty
,buildingNo,isnull(occupancyCertificateNo,'') as occupancyCertificateNo,isnull(occupancyCertificateDate,'') as occupancyCertificateDate,constructionType,buildingUnitUseType,buildingUnitClassName,noOfUnit,UnitTaxId,GarbageTaxId,StreetLightTaxId
, UHTRate, UHTAmount,GarbageRate, GarbageAmount, StreetLightRate, StreetLightAmount
,UHTPenalty, GarbagePenalty,StreetLightPenalty
from
(
 select Tax, landOwnershipId,landDetailId,landOwnershipTypeId,taxPayerId, constructionTypeId, buildingUnitClassId, buildingUnitUseTypeId
,PLR,ttin,cid,firstName,middleName,lastName,plotNo,thramNo,lastTaxPaidYear
,LandTaxId,LandTaxRate,LandTaxAmount
,case when (DATEDIFF(day,@EndDate,GETDATE())) >0 then (DATEDIFF(day,@EndDate,GETDATE())) ELSE 0 END as Penaltydays
,case when (DATEDIFF(day,@EndDate,GETDATE())) >0 then ((penaltyOrRate/(@TotalDays*100))*LandTaxAmount* (DATEDIFF(day,@EndDate,GETDATE()))) else 0.00 end as LandTaxPenalty
,UDTaxId,UDTaxApplicable, UDTaxRate,UDTax,penaltyOrRate
,CASE WHEN (DATEDIFF(day,@EndDate,GETDATE())) >0 then 
case when UDTaxApplicable='Yes'  then ((penaltyOrRate/(@TotalDays*100))*UDTax* (DATEDIFF(day,@EndDate,GETDATE()))) else 0 end else 0.00 END as UDTaxPenalty
,buildingNo, occupancyCertificateNo, occupancyCertificateDate, constructionType, buildingUnitUseType, buildingUnitClassName
,noOfUnit, UnitTaxId, GarbageTaxId, StreetLightTaxId,UHTRate, UHTAmount, GarbageRate, GarbageAmount, StreetLightRate, StreetLightAmount
,0 as UHTPenalty,0 as GarbagePenalty,0 as StreetLightPenalty
FROM(

select Tax, landOwnershipId,landDetailId,landOwnershipTypeId,taxPayerId,0 as constructionTypeId,0 as buildingUnitClassId,0as buildingUnitUseTypeId
,PLR,ttin,cid,firstName,middleName,lastName,plotNo,thramNo,lastTaxPaidYear,LandTaxId,LandTaxRate,LandTaxAmount,UDTaxId,UDTaxApplicable
,(select sqr.rate from mstSlab sqs inner join mstRate sqr on sqs.slabId=sqr.slabId where sqs.isActive=1  and sqs.taxId=UDTaxId ) as UDTaxRate
,case when UDTaxApplicable='Yes' then (select sqr.rate from mstSlab sqs inner join mstRate sqr on sqs.slabId=sqr.slabId where sqs.isActive=1  and sqs.taxId=UDTaxId )* LandTaxAmount else 0.00 end  as UDTax
,'' as buildingNo,'' as occupancyCertificateNo,'' as occupancyCertificateDate,'' as constructionType,'' as buildingUnitUseType,'' as buildingUnitClassName,0 as noOfUnit,0 as UnitTaxId,0 as GarbageTaxId,0 as StreetLightTaxId,0 as UHTRate,0 as UHTAmount,0 as GarbageRate,0 as GarbageAmount,0 as StreetLightRate,0 as StreetLightAmount
,(SELECT penaltyOrRate FROM mstTaxPeriod WHERE transactionTypeId=20 AND calendarYearId=@CalendarYearId) as penaltyOrRate
 from(
select 1 AS Tax, o.landOwnershipId,o.landDetailId,o.landOwnershipTypeId,o.taxPayerId,0 as constructionTypeId,0 as buildingUnitClassId,0as buildingUnitUseTypeId
,o.PLR,p.ttin,p.cid,p.firstName,p.middleName,p.lastName,l.plotNo,o.thramNo,o.lastTaxPaidYear
,(select sqs.taxId from mstSlab sqs  where sqs.isActive=1  and sqs.landUseSubCategoryId=l.landUseSubCategoryId ) LandTaxId
,(select sqr.rate from mstSlab sqs inner join mstRate sqr on sqs.slabId=sqr.slabId where sqs.isActive=1  and sqs.landUseSubCategoryId=l.landUseSubCategoryId ) as LandTaxRate
,(pLR *(select sqr.rate from mstSlab sqs inner join mstRate sqr on sqs.slabId=sqr.slabId where sqs.isActive=1  and sqs.landUseSubCategoryId=l.landUseSubCategoryId ) ) as LandTaxAmount
-- ud
	 ,(case when  (select sqs.taxId from mstSlab sqs  where sqs.isActive=1  and sqs.landUseSubCategoryId=l.landUseSubCategoryId )=1 then 8 
			when  (select sqs.taxId from mstSlab sqs  where sqs.isActive=1  and sqs.landUseSubCategoryId=l.landUseSubCategoryId )=2 then 9
			when  (select sqs.taxId from mstSlab sqs  where sqs.isActive=1  and sqs.landUseSubCategoryId=l.landUseSubCategoryId )=3 then 71
			when  (select sqs.taxId from mstSlab sqs  where sqs.isActive=1  and sqs.landUseSubCategoryId=l.landUseSubCategoryId )=50 then 72
			when  (select sqs.taxId from mstSlab sqs  where sqs.isActive=1  and sqs.landUseSubCategoryId=l.landUseSubCategoryId )=51 then 73
			end
	  ) as UDTaxId
,case when (select count(bd.buildingDetailId)  from mstBuildingDetail bd  where createdOn>=concat(@CalendarYear,'-06-01') and landDetailId =o.landDetailId)>0 then 'Yes' else 'No' end as UDTaxApplicable
,'' as buildingNo,'' as occupancyCertificateNo,'' as occupancyCertificateDate,'' as constructionType,'' as buildingUnitUseType,'' as buildingUnitClassName,0 as noOfUnit,0 as UnitTaxId,0 as GarbageTaxId
,0 as StreetLightTaxId,0 as UHTRate,0 as UHTAmount,0 as GarbageRate,0 as GarbageAmount,0 as StreetLightRate,0 as StreetLightAmount

from tblLandOwnershipDetail o
inner join mstTaxPayerProfile p on o.taxPayerId=p.taxPayerId
inner join mstLandDetail l on o.landDetailId=l.landDetailId
inner join mstLandUseSubCategory sc on l.landUseSubCategoryId=sc.landUseSubCategoryId

where o.isActive=1 and o.landOwnershipId in(SELECT value FROM STRING_SPLIT(@LandOwnershipIds, ','))
) a
) B


 UNION  ALL
 SELECT Tax, landOwnershipId,landDetailId,landOwnershipTypeId,taxPayerId,constructionTypeId,buildingUnitClassId,buildingUnitUseTypeId,pLR,ttin,cid,firstName,middleName,lastName
,plotNo,thramNo,lastTaxPaidYear,0 as LandTaxId,0 as LandTaxRate,0 as LandTaxAmount,Penaltydays,0.00 as LandTaxPenalty ,0 as UDTaxId,UDTaxApplicable,0.00 as UDTaxRate, 0.00 as UDTax, penaltyOrRate,0 as UDTaxPenalty
,buildingNo,occupancyCertificateNo,occupancyCertificateIssueDate,constructionType,buildingUnitUseType,buildingUnitClassName,noOfUnit,UnitTaxId,GarbageTaxId,StreetLightTaxId
, UHTRate, UHTAmount,GarbageRate, GarbageAmount, StreetLightRate, StreetLightAmount
,(((penaltyOrRate)/(100*@TotalDays))*UHTAmount*Penaltydays ) AS UHTPenalty
,(((penaltyOrRate)/(100*@TotalDays))*Penaltydays *GarbageAmount) AS GarbagePenalty
,((penaltyOrRate/(100*@TotalDays))*(Penaltydays *StreetLightAmount)) AS StreetLightPenalty

 FROM (
select 2 AS Tax, landOwnershipId,landDetailId,landOwnershipTypeId,taxPayerId,constructionTypeId,buildingUnitClassId,buildingUnitUseTypeId,pLR,ttin,cid,firstName,middleName,lastName
,plotNo,thramNo,lastTaxPaidYear,0 as LandTaxId,0 as LandTaxRate,0 as LandTaxAmount,Penaltydays,0.00 as LandTaxPenalty ,0 as UDTaxId,UDTaxApplicable,0.00 as UDTaxRate, 0.00 as UDTax, penaltyOrRate,0.00 as UDTaxPenalty
,buildingNo,occupancyCertificateNo,occupancyCertificateIssueDate,constructionType,buildingUnitUseType,buildingUnitClassName,noOfUnit,UnitTaxId,GarbageTaxId,StreetLightTaxId
,(select sqr.rate from mstSlab sqs inner join mstRate sqr on sqs.slabId=sqr.slabId where sqs.isActive=1 and sqr.taxId=a.UnitTaxId and sqs.constructionTypeId=a.constructionTypeId and sqs.buildingUnitClassId=a.buildingUnitClassId and sqs.buildingUnitUseTypeId=a.buildingUnitUseTypeId )  as UHTRate
,(select sqr.rate from mstSlab sqs inner join mstRate sqr on sqs.slabId=sqr.slabId where sqs.isActive=1 and sqr.taxId=a.UnitTaxId and sqs.constructionTypeId=a.constructionTypeId and sqs.buildingUnitClassId=a.buildingUnitClassId and sqs.buildingUnitUseTypeId=a.buildingUnitUseTypeId ) *noOfUnit as UHTAmount
,(select sqr.rate from mstSlab sqs inner join mstRate sqr on sqs.slabId=sqr.slabId where sqs.isActive=1 and sqr.taxId=a.GarbageTaxId and sqs.constructionTypeId=a.constructionTypeId and sqs.buildingUnitClassId=a.buildingUnitClassId and sqs.buildingUnitUseTypeId=a.buildingUnitUseTypeId )  as GarbageRate
,(select sqr.rate from mstSlab sqs inner join mstRate sqr on sqs.slabId=sqr.slabId where sqs.isActive=1 and sqr.taxId=a.GarbageTaxId and sqs.constructionTypeId=a.constructionTypeId and sqs.buildingUnitClassId=a.buildingUnitClassId and sqs.buildingUnitUseTypeId=a.buildingUnitUseTypeId ) *noOfUnit as GarbageAmount
,(select sqr.rate from mstSlab sqs inner join mstRate sqr on sqs.slabId=sqr.slabId where sqs.isActive=1 and sqr.taxId=a.StreetLightTaxId and sqs.constructionTypeId=a.constructionTypeId and sqs.buildingUnitClassId=a.buildingUnitClassId and sqs.buildingUnitUseTypeId=a.buildingUnitUseTypeId )  as StreetLightRate
,(select sqr.rate from mstSlab sqs inner join mstRate sqr on sqs.slabId=sqr.slabId where sqs.isActive=1 and sqr.taxId=a.StreetLightTaxId and sqs.constructionTypeId=a.constructionTypeId and sqs.buildingUnitClassId=a.buildingUnitClassId and sqs.buildingUnitUseTypeId=a.buildingUnitUseTypeId ) *noOfUnit as StreetLightAmount

from(
select
o.landOwnershipId,o.landDetailId,o.landOwnershipTypeId,o.taxPayerId,b.constructionTypeId,u.buildingUnitClassId,u.buildingUnitUseTypeId,o.pLR,p.ttin,p.cid,p.firstName,p.middleName,p.lastName
,l.plotNo,o.thramNo,o.lastTaxPaidYear,0 as LandTaxId,0 as LandTaxRate,0 as LandTaxAmount,0 as TotalTax,'-' as UDTaxApplicable
,b.buildingNo,b.occupancyCertificateNo,b.occupancyCertificateIssueDate,c.constructionType,ut.buildingUnitUseType,uc.buildingUnitClassName,u.noOfUnit
,(case when u.buildingUnitUseTypeId=1 then 4 when u.buildingUnitUseTypeId=2 then 5 when u.buildingUnitUseTypeId=3 then 6 when u.buildingUnitUseTypeId=4 then 7 when u.buildingUnitUseTypeId=5 then 55 when u.buildingUnitUseTypeId=6 then 58 else 0 end ) as UnitTaxId
,(case when u.buildingUnitUseTypeId=1 then 10 when u.buildingUnitUseTypeId=2 then 11 when u.buildingUnitUseTypeId=3 then 63 when u.buildingUnitUseTypeId=4 then 64 when u.buildingUnitUseTypeId=5 then 65 when u.buildingUnitUseTypeId=6 then 66 else 0 end ) as GarbageTaxId
,(case when u.buildingUnitUseTypeId=1 then 12 when u.buildingUnitUseTypeId=2 then 13 when u.buildingUnitUseTypeId=3 then 67 when u.buildingUnitUseTypeId=4 then 68 when u.buildingUnitUseTypeId=5 then 69 when u.buildingUnitUseTypeId=6 then 670 else 0 end ) as StreetLightTaxId
,case when (DATEDIFF(day,@EndDate,GETDATE())) >0 then (DATEDIFF(day,@EndDate,GETDATE())) ELSE 0 END as Penaltydays
,(SELECT penaltyOrRate FROM mstTaxPeriod WHERE transactionTypeId=20 AND calendarYearId=@CalendarYearId) as penaltyOrRate

from tblLandOwnershipDetail o
inner join mstTaxPayerProfile p on o.taxPayerId=p.taxPayerId
inner join mstLandDetail l on o.landDetailId=l.landDetailId
inner join mstBuildingDetail b on l.landDetailId=b.landDetailId
inner join mstBuildingUnitDetail u on b.buildingDetailId=u.buildingDetailId --and u.taxPayerId=5
inner join mstConstructionType  c on b.constructionTypeId=c.constructionTypeId
inner join mstBuildingUnitUseType ut on u.buildingUnitUseTypeId=ut.buildingUnitUseTypeId
inner join mstBuildingUnitClass uc on u.buildingUnitClassId=uc.buildingUnitClassId
inner join enumLandOwnershipType ot on o.landOwnershipTypeId=ot.landOwnershipTypeId
where o.isActive=1 and u.isRegularized=1  and  o.landOwnershipId in(SELECT value FROM STRING_SPLIT(@LandOwnershipIds, ','))

) a
) B
)c
end