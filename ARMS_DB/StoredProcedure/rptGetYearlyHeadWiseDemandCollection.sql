

CREATE PROCEDURE [dbo].[rptGetYearlyHeadWiseDemandCollection] 
	@FinancialYearId int
	
AS


begin

	set nocount on;
	declare @fyr  varchar(20)
	set @fyr=(select FinancialYear from mstFinancialYear where financialYearId=@FinancialYearId);
			select ROW_NUMBER() over(order by(select 1)) as sl,t.taxName as TaxName,sum(l.totalAmount) as TotalAmount, @fyr as FinancialYear
			from tblLedger as l 
			inner join mstTaxMaster as t on l.taxId = t.taxId
			inner join mstFinancialYear as f on l.financialYearId =f.financialYearId
			where l.financialYearId = @FinancialYearId
			group by t.taxName
			 

end