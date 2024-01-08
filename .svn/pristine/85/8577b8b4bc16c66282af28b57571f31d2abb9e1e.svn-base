CREATE PROCEDURE [dbo].[rptGetPropertyTaxDefaulter]
	@pcalendarYearId int,@plandOwnershipTypeId int
AS
	
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	--	EXEC [dbo].[rptGetPropertyTaxDefaulter] 22,1

	SET NOCOUNT ON;
	IF(@plandOwnershipTypeId!=1)--FOR JOINT
	BEGIN
	SELECT *,(TotalLandTaxAmount+TotalUDTaxAmount+TotalUnitTaxAmount+ TotalGarbageTax+TotalStreetLightTax) as TotalPropertyTax FROM(

	select a.*,b.noOfUnit, (a.NoOfYears* b.UnitTaxAmount) as TotalUnitTaxAmount
			, (a.NoOfYears* b.GarbageTaxAmount) as TotalGarbageTax
			,(a.NoOfYears* b.StreetLightTaxAmount) as TotalStreetLightTax  from (

				SELECT *,case when structureAvailable=1 then 0.25*TotalLandTaxAmount else 0 end as TotalUDTaxAmount
				FROM (
						SELECT *,(PLR*NoOfYears*LandTaxRate)as TotalLandTaxAmount FROM(
		
									SELECT
									TS.*,(CurrentYear-lastTaxPaidYear)NoOfYears-- MAKE SURE TO ADD THE VIEW IN CLASS FILE			
									FROM(
											select T.*,ow.landDetailId, ld.plotNo,ld.thramNo,ow.taxPayerId,tp.ttin,tp.cid,concat( tp.firstName +' ' +isnull(tp.middleName,''),' ',isnull(tp.lastName,'')) as TaxPayerName,ow.landOwnershipTypeId,ld.isApportioned,ld.landAcerage,ow.pLR,ld.landUseSubCategoryId,ld.structureAvailable,isnull(ow.lastTaxPaidYear,0) as lastTaxPaidYear ,year(getdate()) as CurrentYear,ld.slabId,ld.rateId,ld.rate as LandTaxRate
											from (
											select distinct o.landOwnershipId from tblLandOwnershipDetail o
											where o.isActive=1 and o.landDetailId not in (select distinct d.landDetailId from tblDemand d
											inner join tblTransactionDetail t on d.transactionId=t.transactionId
											where d.isCancelled=0 and d.isPaymentMade=1 and t.transactionTypeId=20 and d.calendarYearId=@pcalendarYearId
											)) T
											inner join tblLandOwnershipDetail ow on T.landOwnershipId = ow.landOwnershipId
											inner join ViewSlabAndRatesForLandTax ld on ow.landDetailId = ld.landDetailId
											inner join mstTaxPayerProfile tp on ow.taxPayerId=tp.taxPayerId
											where ow.isActive=1 and ld.landAcerage<>0 --and ow.lastTaxPaidYear = 2021
											and ow.landOwnershipTypeId!=1-- FOR non JOINT OWNERS ONLY
									) TS		
							)TC 
				) TUD  )a

	inner join  ViewUnitTax b on a.landDetailId = b.landDetailId and a.taxPayerId= b.taxPayerId	

	)LUT order by plotNo

	END
	ELSE -- EXCEPT JOINT FOR OTHERS
	BEGIN
		SELECT *,(TotalLandTaxAmount+TotalUDTaxAmount+TotalUnitTaxAmount+ TotalGarbageTax+TotalStreetLightTax) as TotalPropertyTax FROM(

	select a.* ,b.noOfUnit, (a.NoOfYears* b.UnitTaxAmount) as TotalUnitTaxAmount
			, (a.NoOfYears* b.GarbageTaxAmount) as TotalGarbageTax
			,(a.NoOfYears* b.StreetLightTaxAmount) as TotalStreetLightTax  from (

				SELECT *,case when structureAvailable=1 then 0.25*TotalLandTaxAmount else 0 end as TotalUDTaxAmount
				FROM (
						SELECT *,(PLR*NoOfYears*LandTaxRate)as TotalLandTaxAmount FROM(
		
									SELECT
									TS.*,(CurrentYear-lastTaxPaidYear)NoOfYears-- MAKE SURE TO ADD THE VIEW IN CLASS FILE			
									FROM(
											select T.*,ow.landDetailId, ld.plotNo,ld.thramNo,tp.ttin,tp.cid,concat( tp.firstName +' ' +isnull(tp.middleName,''),' ',isnull(tp.lastName,'')) as TaxPayerName,ow.landOwnershipTypeId,ld.isApportioned,ld.landAcerage,ow.pLR,ld.landUseSubCategoryId,ow.taxPayerId,ld.structureAvailable,isnull(ow.lastTaxPaidYear,0) as lastTaxPaidYear ,year(getdate()) as CurrentYear,ld.slabId,ld.rateId,ld.rate as LandTaxRate
											from (
											select distinct o.landOwnershipId from tblLandOwnershipDetail o
											where o.isActive=1 and o.landDetailId not in (select distinct d.landDetailId from tblDemand d
											inner join tblTransactionDetail t on d.transactionId=t.transactionId
											where d.isCancelled=0 and d.isPaymentMade=1 and t.transactionTypeId=20 and d.calendarYearId=@pcalendarYearId
											)) T
											inner join tblLandOwnershipDetail ow on T.landOwnershipId = ow.landOwnershipId
											inner join ViewSlabAndRatesForLandTax ld on ow.landDetailId = ld.landDetailId
											inner join mstTaxPayerProfile tp on ow.taxPayerId=tp.taxPayerId
											where ow.isActive=1 and ld.landAcerage<>0 --and ow.lastTaxPaidYear = 2021
											and ow.landOwnershipTypeId=1-- FOR non JOINT OWNERS ONLY
									) TS		
							)TC 
				) TUD  WHERE TUD.landDetailId IN(
								--IN START
								SELECT landDetailId FROM(
										SELECT landDetailId,landAcerage,SUM(pLR)AS TotalpLR
											FROM (
				
															select T.*,ld.landDetailId,ow.landOwnershipTypeId,ld.isApportioned,ld.landAcerage,ow.pLR
															from (
															select distinct o.landOwnershipId from tblLandOwnershipDetail o
															where o.isActive=1 and o.landDetailId not in (select distinct d.landDetailId from tblDemand d
															inner join tblTransactionDetail t on d.transactionId=t.transactionId
															where d.isCancelled=0 and d.isPaymentMade=1 and t.transactionTypeId=20 and d.calendarYearId=22
															)) T
															inner join tblLandOwnershipDetail ow on T.landOwnershipId = ow.landOwnershipId
															inner join ViewSlabAndRatesForLandTax ld on ow.landDetailId = ld.landDetailId
															where ow.isActive=1 and ld.landAcerage<>0 --and ow.lastTaxPaidYear = 2021
															AND ow.landOwnershipTypeId=1-- FOR JOINT OWNERS ONLY
												)O  
												GROUP BY landDetailId,landAcerage
											)DEF WHERE DEF.landAcerage<>DEF.TotalpLR
											-- IN INSIDE
								)
				
				)a

	inner join  ViewUnitTax b on a.landDetailId = b.landDetailId and a.taxPayerId= b.taxPayerId	

	)LUT order by plotNo

	END


END
GO

--RETURN 0
