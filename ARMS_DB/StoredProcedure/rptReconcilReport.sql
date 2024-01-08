
-- exec [dbo].[rptReconcilReport] '05/30/2021','06/17/2021'

CREATE PROCEDURE [dbo].[rptReconcilReport]
@StartDate date, @EndDate date

AS


begin

set nocount on;
SELECT  ROW_NUMBER() OVER(
ORDER BY (select 1)) AS Sl,* from(
select 'Cash' as PaymentMode, '-' as PaymentModeNo,'-' as BranchName,'' as PaymentModeDate, sum(amount) as Amount, ps.paymentStatus as PaymentStatus, FORMAT(d.depositDate,'dd/MM/yyyy') as DepositDate, u.FirstName + '' + u.MiddleName + '' + u.LastName as DepositedBy from tblPaymentLeger pl
left join tblDeposit d on pl.paymentLedgerId = d.paymentLedgerId
left join enumPaymentStatus ps on d.paymentStatusId = ps.paymentStatusId
left join AspNetUsers u on d.createdBy = u.userId
where paymentModeId = 1 and
FORMAT (d.paymentFromDate, 'yyyyMMdd') >= FORMAT (@StartDate, 'yyyyMMdd') 
and FORMAT (d.paymentToDate, 'yyyyMMdd') <= FORMAT (@EndDate, 'yyyyMMdd') 

group by paymentModeId, ps.paymentStatus, d.depositDate, u.FirstName + '' + u.MiddleName + '' + LastName
union all
select  pm.paymentMode as PaymentMode,pl.paymentModeNo as PaymentModeNo, bb.branchName as BranchName,
 FORMAT(pl.paymentModeDate,'dd/MM/yyyy') as PaymentModeDate, amount as Amount, ps.paymentStatus as PaymentStatus , FORMAT(d.depositDate,'dd/MM/yyyy') as DepositDate, u.FirstName + '' + u.MiddleName + '' + u.LastName as DepositedBy from tblPaymentLeger pl
left join [dbo].[enumPaymentMode] pm on pl.paymentModeId = pm.paymentModeId
left join [dbo].[mstBankBranch] bb on pl.bankBranchId = bb.bankBranchId
left join tblDeposit d on pl.paymentLedgerId = d.paymentLedgerId
left join AspNetUsers u on d.createdBy = u.userId
left join enumPaymentStatus ps on d.paymentStatusId = ps.paymentStatusId

where pl.paymentModeId = 2 and 
FORMAT (d.paymentFromDate, 'yyyyMMdd') >= FORMAT (@StartDate, 'yyyyMMdd') 
and FORMAT (d.paymentToDate, 'yyyyMMdd') <= FORMAT (@EndDate, 'yyyyMMdd'))t  

end