
Create PROCEDURE [dbo].[spCollectionByFromDateToDate]
	@FromDate int,
	@ToDate int
AS
	  SELECT  ROW_NUMBER() OVER(
       ORDER BY (select 1)) AS Sl,* from(
select 'Cash' as PaymentMode,'-' as PaymentModeNo,'' as PaymentModeDate, '' as BranchName, sum(amount) as Amount from tblPaymentLeger where paymentModeId = 1 and cast(convert(varchar, createdOn,112) as int)>=@FromDate and cast(convert(varchar, createdOn,112) as int)<=@ToDate
group by paymentModeId
union all
select pm.paymentMode as PaymentMode, pl.paymentModeNo as PaymentModeNo,(convert(varchar, pl.paymentModeDate,103)) as PaymentModeDate, bb.branchName as BranchName, amount as Amount from tblPaymentLeger pl
left join [dbo].[enumPaymentMode] pm on pl.paymentModeId = pm.paymentModeId
left join [dbo].[mstBankBranch] bb on pl.bankBranchId = bb.bankBranchId

where pl.paymentModeId = 2 and cast(convert(varchar, pl.createdOn,112) as int)>=@FromDate and cast(convert(varchar, pl.createdOn,112) as int)<=@ToDate) t    
RETURN 0