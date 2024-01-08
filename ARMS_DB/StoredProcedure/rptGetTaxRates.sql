
CREATE PROCEDURE [dbo].[rptGetTaxRates]
	@TransactionTypeId int
AS
--	EXEC [dbo].[rptGetTaxRates] 19

  SELECT ROW_NUMBER() over(order by(select 1)) as sl, t.taxName as taxName, s.slabName as slabName, s.slabStart as slabStart, FORMAT (s.effectiveDate, 'dd/MM/yyyy') as effectiveDate, s.slabEnd as slabEnd,
  r.rate as rate
   
   from mstRate r 
   join mstTaxMaster t on r.taxId=t.taxId
   join mstSlab s on r.slabId=s.slabId
   left join mstTransactionTypeTaxMap ty on t.taxId=ty.taxId
--   left join mstLandUseSubCategory sc on s.landUseSubCategoryId=sc.landUseSubCategoryId
   where ty.transactionTypeId=@TransactionTypeId
RETURN 0