CREATE VIEW [dbo].[view_TaxCalculationAPI]
	AS 
	
	SELECT dbo.mstCalendarYear.calendarYearId, dbo.mstCalendarYear.calendarYear, dbo.mstCalendarYear.startDate, dbo.mstCalendarYear.endDate,
    dbo.mstCalendarYear.isActive AS isActiveCalendarYear, dbo.mstLandDetail.plotNo, dbo.mstLandDetail.landAcerage, dbo.mstLandDetail.landUseSubCategoryId, dbo.mstLandDetail.propertyTypeId, 
             dbo.mstLandDetail.landTypeId, dbo.mstLandDetail.streetNameId, dbo.mstLandDetail.demkhongId, dbo.mstLandDetail.lapId, dbo.tblLandOwnershipDetail.landOwnershipId, dbo.tblLandOwnershipDetail.landOwnershipTypeId, dbo.tblLandOwnershipDetail.taxPayerId, 
             dbo.mstLandDetail.thramNo, dbo.tblLandOwnershipDetail.pLR, dbo.tblLandOwnershipDetail.isActive AS IsActiveOwnership, dbo.tblLandOwnershipDetail.lastTaxPaidYear, dbo.mstLandUseCategory.landUseCategory, 
             dbo.mstLandUseSubCategory.landUseSubCategory, dbo.tblLandOwnershipDetail.landDetailId, dbo.mstLandDetail.isApportioned, DATEDIFF(day, dbo.mstCalendarYear.startDate,  dbo.mstCalendarYear.endDate) + 1 AS TotalDays, CASE WHEN DATEDIFF(day, EndDate, GETDATE()) 
             < 0 THEN 0 ELSE DATEDIFF(day, EndDate, GETDATE()) END AS PenaltyDays
FROM   dbo.tblLandOwnershipDetail INNER JOIN
             dbo.mstLandDetail ON dbo.tblLandOwnershipDetail.landDetailId = dbo.mstLandDetail.landDetailId INNER JOIN
             dbo.mstLandUseSubCategory ON dbo.mstLandDetail.landUseSubCategoryId = dbo.mstLandUseSubCategory.landUseSubCategoryId INNER JOIN
             dbo.mstLandUseCategory ON dbo.mstLandUseSubCategory.landUseCategoryId = dbo.mstLandUseCategory.landUseCategoryId CROSS JOIN
             dbo.mstCalendarYear
              
  WHERE dbo.tblLandOwnershipDetail.lastTaxPaidYear is not null and dbo.tblLandOwnershipDetail.pLR>0 
  --and dbo.tblLandOwnershipDetail.landOwnershipId NOT IN
		--	 (SELECT landOwnershipId FROM tblDemand l inner join tblTransactionDetail t on l.transactionId=t.transactionId where
		-- t.transactionTypeId=20 and l.calendarYearId= dbo.mstCalendarYear.calendarYearId and l.landOwnershipId=dbo.tblLandOwnershipDetail.landOwnershipId)

