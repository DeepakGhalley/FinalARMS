
Create PROCEDURE [dbo].[spPaymentDepositReport]
	@FromDate int,
	@ToDate int
AS
SELECT  ROW_NUMBER() OVER(
  ORDER BY (select 1)) AS Sl,* from(
select 'Cash' as PaymentMode,'-' as PaymentModeNo,'' as PaymentModeDate, '' as BranchName,sum(d.depositAmount) as Amount,u.firstName + isnull(u.middleName,'') + isnull(u.lastName,'') as UserName
from tblDeposit d 
left join tblPaymentLeger pl on d.paymentLedgerId = pl.paymentLedgerId
left join AspNetUsers u on d.createdBy = u.UserId
where paymentModeId = 1 and
cast(convert(varchar, d.createdOn,112) as int)>=@FromDate and cast(convert(varchar, d.createdOn,112) as int)<=@ToDate
group by paymentModeId,U.FirstName,u.MiddleName,u.LastName
union all

select pm.paymentMode as PaymentMode, pl.paymentModeNo as PaymentModeNo,(convert(varchar, pl.paymentModeDate,103)) as PaymentModeDate, bb.branchName as BranchName, d.depositAmount as Amount,u.UserName as UserName 
from tblDeposit d 
left join tblPaymentLeger pl on d.paymentLedgerId = pl.paymentLedgerId
left join [dbo].[enumPaymentMode] pm on pl.paymentModeId = pm.paymentModeId
left join [dbo].[mstBankBranch] bb on pl.bankBranchId = bb.bankBranchId
left join AspNetUsers u on d.createdBy = u.UserId
where pl.paymentModeId = 2 and 
cast(convert(varchar,d.createdOn,112) as int)>=@FromDate and cast(convert(varchar, d.createdOn,112) as int)<=@ToDate) t    
RETURN 0