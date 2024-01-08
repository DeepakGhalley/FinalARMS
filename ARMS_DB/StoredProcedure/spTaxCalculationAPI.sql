﻿create PROCEDURE [dbo].[spTaxCalculationAPI]
	@calendarYearId int,
	@taxpayerid int
AS
/****** Script for SelectTopNRows command from SSMS  ******/

-- [startDate],[endDate],isActiveCalendarYear,[landUseSubCategoryId],[propertyTypeId],[landTypeId] ,[streetNameId] ,[demkhongId] ,[lapId] ,[landOwnershipTypeId]  ,[IsActiveOwnership]
--,[landUseCategory] ,[landUseSubCategory], TotalDays , PenaltyDays

 -- EXEC [dbo].[spTaxCalculationAPI] 21,4014

-- EXEC [dbo].[spTaxCalculationAPI] 21,101884

select ROW_NUMBER() OVER(  ORDER BY (select 1)) AS Sl
,pType, [calendarYearId],[calendarYear],[plotNo],[landAcerage],[landOwnershipId] ,[taxPayerId] ,[thramNo] ,[pLR] ,[lastTaxPaidYear] ,[landDetailId] ,[isApportioned] 
      ,LandTaxId, LandTaxRate, LandTaxAmount,round(LandTaxPenalty,2) as LandTaxPenalty,UDTaxId,UDTaxApplicable,penaltyOrRate
      , UDTaxRate,round(UDTaxAmount,2)as UDTaxAmount,round(UDTaxPenaltyAmount,2)as UDTaxPenaltyAmount ,
	 UnitTaxId,  GarbageTaxId,  StreetLightTaxId, noOfUnit , UnitTax,GarbageTax, isnull(StreetLightTax,0.00) as StreetLightTax, UnitTaxRate, GarbageTaxRate, isnull(StreetLightRate,0.00) as StreetLightRate
	 , round(UnitTaxPenalty,2) as UnitTaxPenalty,round(GarbageTaxPenalty,2) as GarbageTaxPenalty,round(isnull(StreetLightTaxPenalty,0.00),2) as StreetLightTaxPenalty,
	 TotalDays , PenaltyDays,flatNo
 from(

(SELECT  1 as pType, [calendarYearId],[calendarYear],[plotNo],[landAcerage],[landOwnershipId] ,[taxPayerId] ,[thramNo] ,[pLR] ,[lastTaxPaidYear] ,[landDetailId] ,[isApportioned] 
      ,LandTaxId, LandTaxRate, LandTaxAmount, LandTaxPenalty,UDTaxId,UDTaxApplicable,penaltyOrRate
      , UDTaxRate,case when UDTaxApplicable='Yes' then ((LandTaxAmount*UDTaxRate)) else 0.00 end  as UDTaxAmount,case when UDTaxApplicable='Yes' then (((penaltyOrRate/(TotalDays*100))*LandTaxAmount*UDTaxRate*PenaltyDays)) else 0.00 end as UDTaxPenaltyAmount,
	  0 as UnitTaxId, 0 as GarbageTaxId, 0 as StreetLightTaxId,0 as noOfUnit ,0 as UnitTax,0 as GarbageTax,0 as StreetLightTax,0 as UnitTaxRate,0 as GarbageTaxRate,0 as StreetLightRate 
      ,0 as UnitTaxPenalty,0 as GarbageTaxPenalty,0 as StreetLightTaxPenalty, TotalDays , PenaltyDays,'' as flatNo
      FROM(
SELECT 
[calendarYearId],[calendarYear],[startDate],[endDate],isActiveCalendarYear,[plotNo],[landAcerage],[landUseSubCategoryId],[propertyTypeId]
      ,[landTypeId] ,[streetNameId] ,[demkhongId] ,[lapId] ,[landOwnershipId] ,[landOwnershipTypeId] ,[taxPayerId] ,[thramNo] ,[pLR]      
      ,[IsActiveOwnership] ,[lastTaxPaidYear] ,[landUseCategory] ,[landUseSubCategory] ,[landDetailId] ,[isApportioned] , TotalDays , PenaltyDays
      ,LandTaxId, LandTaxRate, LandTaxAmount,(((penaltyOrRate/(TotalDays*100))*PenaltyDays*LandTaxAmount)) as LandTaxPenalty,UDTaxId
	  ,case when (BuildingAvailable>0 OR [landUseSubCategoryId]=21  OR  [landUseSubCategoryId]=26 )   then 'No' else 'Yes' end as  UDTaxApplicable,penaltyOrRate
      ,case when BuildingAvailable>0  then 0 ELSE (select TOP 1 sqr.rate from mstSlab sqs inner join mstRate sqr on sqs.slabId=sqr.slabId where sqs.isActive=1  and sqs.taxId=UDTaxId )  end as UDTaxRate
-- FOR UD RATE
FROM (
                SELECT [calendarYearId]
                      ,[calendarYear]
                      ,[startDate]
                      ,[endDate]
                      ,isActiveCalendarYear
                      ,[plotNo]
                      ,[landAcerage]
                      ,[landUseSubCategoryId]
                      ,[propertyTypeId]
                      ,[landTypeId]
                      ,[streetNameId]
                      ,[demkhongId]
                      ,[lapId]
                      ,[landOwnershipId]
                      ,[landOwnershipTypeId]
                      ,[taxPayerId]
                      ,[thramNo]
                      ,[pLR]      
                      ,[IsActiveOwnership]
                      ,[lastTaxPaidYear]
                      ,[landUseCategory]
                      ,[landUseSubCategory]
                      ,[landDetailId]
                      ,[isApportioned]
                      ,TotalDays
	                  ,PenaltyDays
                  ,(select top 1 sqs.taxId from mstSlab sqs  where sqs.isActive=1  and sqs.landUseSubCategoryId=v.landUseSubCategoryId ) LandTaxId
	                ,(select  top 1  sqr.rate from mstSlab sqs inner join mstRate sqr on sqs.slabId=sqr.slabId where sqs.isActive=1  and sqs.landUseSubCategoryId=v.landUseSubCategoryId ) as LandTaxRate
	                ,(v.pLR *(select  top 1  sqr.rate from mstSlab sqs inner join mstRate sqr on sqs.slabId=sqr.slabId where sqs.isActive=1  and sqs.landUseSubCategoryId=v.landUseSubCategoryId ) ) as LandTaxAmount
	                -- ud
	                 ,(case when  (select top 1 sqs.taxId from mstSlab sqs  where sqs.isActive=1  and sqs.landUseSubCategoryId=v.landUseSubCategoryId )=1 then 8 
			                when  (select top 1 sqs.taxId from mstSlab sqs  where sqs.isActive=1  and sqs.landUseSubCategoryId=v.landUseSubCategoryId )=2 then 9
			                when  (select top 1 sqs.taxId from mstSlab sqs  where sqs.isActive=1  and sqs.landUseSubCategoryId=v.landUseSubCategoryId )=3 then 71
			                when  (select top 1 sqs.taxId from mstSlab sqs  where sqs.isActive=1  and sqs.landUseSubCategoryId=v.landUseSubCategoryId )=50 then 72
			                when  (select top 1 sqs.taxId from mstSlab sqs  where sqs.isActive=1  and sqs.landUseSubCategoryId=v.landUseSubCategoryId )=51 then 73
			                end
	                  ) as UDTaxId
					,(select count(bd.buildingDetailId)  from mstBuildingDetail bd  where isnull(bd.createdOn,concat(v.[calendarYear],'-12-31'))<concat(v.[calendarYear],'-06-01') and bd.landDetailId =v.landDetailId)as BuildingAvailable


				  ,(SELECT  penaltyOrRate FROM mstTaxPeriod tp WHERE tp.transactionTypeId=20 AND tp.calendarYearId=v.[calendarYearId]) as penaltyOrRate
                 FROM [tt_db].[dbo].[view_TaxCalculationAPI] v

  
                WHERE 	v.isActiveCalendarYear=1 AND  v.[IsActiveOwnership]=1 AND  v.[lastTaxPaidYear] IS NOT NULL AND

              v.[calendarYear]>lastTaxPaidYear  AND 
				  v.calendarYearId<=@calendarYearId and  v.taxpayerid=@taxpayerid
) N) O
)

UNION ALL

(

SELECT 2 as pType, calendarYearId,calendarYear,plotNo,0 as [landAcerage],[landOwnershipId] ,[taxPayerId],thramNo, pLR,lastTaxPaidYear,[landDetailId],isApportioned,0 as LandTaxId,
0 as LandTaxRate,0 as LandTaxAmount,0 as LandTaxPenalty,0 as UDTaxId,'-' as UDTaxApplicable
, penaltyOrRate,0 as UDTaxRate,0 as UDTaxAmount,0 as UDTaxPenaltyAmount,UnitTaxId, GarbageTaxId, StreetLightTaxId,noOfUnit ,UnitTax,
GarbageTax,StreetLightTax,UnitTaxRate,GarbageTaxRate,StreetLightRate
,(((penaltyOrRate/(TotalDays*100))*UnitTax*PenaltyDays)) as UnitTaxPenalty,(((penaltyOrRate/(TotalDays*100))*GarbageTax*PenaltyDays)) as GarbageTaxPenalty,(((penaltyOrRate/(TotalDays*100))*StreetLightTax*PenaltyDays)) as StreetLightTaxPenalty
, TotalDays , PenaltyDays,flatNo
--  constructionTypeId,buildingUnitClassId,buildingUnitUseTypeId,UnitTaxSlabId,GarbageTaxSlabId,StreetLightSlabId,startDate,endDate,[landOwnershipTypeId]
FROM( 

SELECT calendarYearId,calendarYear,plotNo,[landOwnershipId],[landDetailId],isApportioned, [taxPayerId],thramNo,lastTaxPaidYear
,(SELECT penaltyOrRate FROM mstTaxPeriod tp WHERE tp.transactionTypeId=20 AND tp.calendarYearId=C.[calendarYearId])as penaltyOrRate
,UnitTaxId, GarbageTaxId, StreetLightTaxId,noOfUnit ,UnitTax,GarbageTax,StreetLightTax,UnitTaxRate,GarbageTaxRate,StreetLightRate,C.TotalDays,C.PenaltyDays,floorNameId,pLR
,flatNo

--  constructionTypeId,buildingUnitClassId,buildingUnitUseTypeId,UnitTaxSlabId,GarbageTaxSlabId,StreetLightSlabId,startDate,endDate,[landOwnershipTypeId]
FROM( 
SELECT  UnitTaxId, GarbageTaxId, StreetLightTaxId,noOfUnit ,UnitTax,
GarbageTax,StreetLightTax,UnitTaxRate,GarbageTaxRate,StreetLightRate
,constructionTypeId,buildingUnitClassId,buildingUnitUseTypeId,UnitTaxSlabId,GarbageTaxSlabId,StreetLightSlabId
,[landDetailId],[landOwnershipId] ,[landOwnershipTypeId] ,[taxPayerId] ,plotNo,thramNo,landUseSubCategory,lastTaxPaidYear,isApportioned,floorNameId,pLR
,flatNo FROM(
select *,(UnitTaxRate* noOfUnit) AS UnitTax,(GarbageTaxRate* noOfUnit*NoOfMonths) GarbageTax,(StreetLightRate* noOfUnit*NoOfMonths) AS StreetLightTax   from (
select *,
(select top 1 rate from mstRate r  where r.isActive=1 and r.slabId=l.UnitTaxSlabId order by r.rateId desc) as UnitTaxRate
,(select top 1 rate from mstRate r where r.isActive=1 and r.slabId=l.GarbageTaxSlabId order by r.rateId desc) as GarbageTaxRate
,(select top 1 rate from mstRate r where r.isActive=1 and r.slabId=l.StreetLightSlabId order by r.rateId desc) as StreetLightRate
,12 as NoOfMonths
from
(
select k.*,
(select top 1 slabid from mstSlab s  where s.isActive=1  and s.taxId=k.UnitTaxId and s.buildingUnitUseTypeId=k.buildingUnitUseTypeId and s.buildingUnitClassId=k.buildingUnitClassId and s.constructionTypeId=k.constructionTypeId order by slabId desc) as UnitTaxSlabId
,(select top 1 slabid from mstSlab s where s.isActive=1 and s.taxId=k.GarbageTaxId and s.buildingUnitUseTypeId=k.buildingUnitUseTypeId and s.buildingUnitClassId=k.buildingUnitClassId and s.constructionTypeId=k.constructionTypeId order by slabId desc) as GarbageTaxSlabId
,(select top 1 slabid from mstSlab s where s.isActive=1 and s.taxId=k.StreetLightTaxId  and s.buildingUnitUseTypeId=k.buildingUnitUseTypeId and s.buildingUnitClassId=k.buildingUnitClassId and s.constructionTypeId=k.constructionTypeId order by slabId desc) as StreetLightSlabId
FROM(
			
			select  b.constructionTypeId,u.buildingUnitClassId,u.buildingUnitUseTypeId,o.landDetailId,o.taxPayerId,[landOwnershipId],o.[landOwnershipTypeId],plotNo,l.thramNo,landUseSubCategory,o.lastTaxPaidYear,isApportioned
			,(case when u.buildingUnitUseTypeId=1 then 4 when u.buildingUnitUseTypeId=2 then 5 when u.buildingUnitUseTypeId=3 then 6 when u.buildingUnitUseTypeId=4 then 7 when u.buildingUnitUseTypeId=5 then 55 when u.buildingUnitUseTypeId=6 then 58 else 0 end ) as UnitTaxId
			,(case when u.buildingUnitUseTypeId=1 then 10 when u.buildingUnitUseTypeId=2 then 11 when u.buildingUnitUseTypeId=3 then 63 when u.buildingUnitUseTypeId=4 then 64 when u.buildingUnitUseTypeId=5 then 65 when u.buildingUnitUseTypeId=6 then 66 else 0 end ) as GarbageTaxId
			,(case when u.buildingUnitUseTypeId=1 then 12 when u.buildingUnitUseTypeId=2 then 13 when u.buildingUnitUseTypeId=3 then 67 when u.buildingUnitUseTypeId=4 then 68 when u.buildingUnitUseTypeId=5 then 69 when u.buildingUnitUseTypeId=6 then 67 else 0 end ) as StreetLightTaxId
			,u.noOfUnit,u.floorNameId,o.pLR,u.flatNo

			from
			tblLandOwnershipDetail o
			inner join mstTaxPayerProfile p on o.taxPayerId=p.taxPayerId
			inner join mstLandDetail l on o.landDetailId=l.landDetailId
				inner join mstLandUseSubCategory sc on l.landUseSubCategoryId=sc.landUseSubCategoryId
			inner join mstBuildingDetail b on l.landDetailId=b.landDetailId
			inner join mstBuildingUnitDetail u on b.buildingDetailId=u.buildingDetailId and u.taxPayerId=@taxpayerid and u.landDetailId=b.landDetailId and u.landDetailId=o.landDetailId
	
			inner join mstConstructionType  c on b.constructionTypeId=c.constructionTypeId
			inner join mstBuildingUnitUseType ut on u.buildingUnitUseTypeId=ut.buildingUnitUseTypeId
			inner join mstBuildingUnitClass uc on u.buildingUnitClassId=uc.buildingUnitClassId
			inner join enumLandOwnershipType ot on o.landOwnershipTypeId=ot.landOwnershipTypeId

			where  o.isActive=1 AND o.lastTaxPaidYear IS NOT NULL AND o.pLR > 0 and  o.taxPayerId=@taxpayerid		--u.noOfUnit>0 and 	


	)k
	)l
 )m
 )n
) B 
CROSS JOIN 
( SELECT  [calendarYearId],[calendarYear],startDate,endDate, DATEDIFF(day, v.startDate, v.endDate) + 1 AS TotalDays, 
             CASE WHEN DATEDIFF(day, EndDate, GETDATE()) < 0 THEN 0 ELSE DATEDIFF(day, EndDate, GETDATE()) END AS PenaltyDays


FROM [tt_db].[dbo].[mstCalendarYear] v

  
                 WHERE  v.isActive=1 --and v.calendarYearId>=@calendarYearId 
				 and v.calendarYearId<=@calendarYearId
)  C

)L WHERE  calendarYear>lastTaxPaidYear


			--and L.landOwnershipId NOT IN
			-- (SELECT landOwnershipId FROM tblDemand d inner join tblTransactionDetail t on d.transactionId=t.transactionId where
		 --t.transactionTypeId=20 and d.calendarYearId= L.calendarYearId and d.landOwnershipId=L.landOwnershipId)


) 

)FINAL --where plotNo='DJ1-024' --AND lastTaxPaidYear>=2021
WHERE  calendarYear>lastTaxPaidYear 

order by calendarYearId desc ,pType


  
RETURN 0

--  EXEC [dbo].[spTaxCalculationAPI] 21,8600