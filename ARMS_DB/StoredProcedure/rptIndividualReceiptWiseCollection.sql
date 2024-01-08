
create  PROCEDURE [dbo].[rptIndividualReceiptWiseCollection]
@FromDate  date ,@ToDate  date,@UserId int
AS
BEGIN
SET NOCOUNT ON;
-- CASH 1

 SELECT  ROW_NUMBER() OVER(
        ORDER BY (select 1)) AS Sl, FromDate,ToDate,ReceiptNo,PaymentModeNo,PaymentModeDate,PaymentDate,UserName,FORMAT (getdate(), 'dd/MM/yyyy')  as ExecutionDate
		,sum(Cash)as Cash,sum(Cheque) as Cheque,sum(ScanPay) as ScanPay, (SUM(Cash) + SUM(Cheque) + SUM(ScanPay)) as grandTotal
	   from (
(
select FORMAT (@FromDate, 'dd/MM/yyyy') as FromDate	,FORMAT (@ToDate, 'dd/MM/yyyy') as ToDate,
r.receiptNo AS ReceiptNo, isnull(pl.paymentModeNo,'-') as PaymentModeNo ,isnull(FORMAT (pl.paymentModeDate, 'dd/MM/yyyy'),'-') as PaymentModeDate,
isnull(FORMAT (pl.createdOn, 'dd/MM/yyyy'),'-') as PaymentDate ,sum(pl.amount) as Cash,0 as Cheque, 0 as ScanPay
,(u.FirstName +' '+ ISNULL(u.MiddleName,'')+' '+ ISNULL(u.LastName,'')) as UserName
from [dbo].tblPaymentLeger pl
left join [dbo].[tblReceipt] r on pl.receiptId= r.receiptId
left join AspNetUsers u on pl.createdBy=u.UserId
where pl.paymentModeId=1 and  pl.createdBy=@UserId  and 
 convert (varchar,pl.createdOn, 112)>=convert (varchar,@FromDate, 112) 
and  convert (varchar,pl.createdOn, 112)<=convert (varchar,@ToDate, 112) 

group by FORMAT (pl.createdOn, 'dd/MM/yyyy'),r.receiptNo,pl.paymentModeNo,FORMAT (pl.paymentModeDate, 'dd/MM/yyyy'),u.FirstName,  ISNULL(u.MiddleName,''), ISNULL(u.LastName,'')
)
UNION all
-- CHEQUE 2
(
select
FORMAT (@FromDate, 'dd/MM/yyyy') as FromDate
	,FORMAT (@ToDate, 'dd/MM/yyyy') as ToDate,
r.receiptNo AS ReceiptNo, isnull(pl.paymentModeNo,'-') as PaymentModeNo ,isnull(FORMAT (pl.paymentModeDate, 'dd/MM/yyyy'),'-') as PaymentModeDate

,isnull(FORMAT (pl.createdOn, 'dd/MM/yyyy'),'-') as PaymentDate ,0 as Cash,sum(pl.amount) as Cheque, 0 as ScanPay
,(u.FirstName +' '+ ISNULL(u.MiddleName,'') +' '+ isnull(u.LastName,'')) as UserName
from [dbo].tblPaymentLeger pl
left join [dbo].[tblReceipt] r on pl.receiptId= r.receiptId
left join AspNetUsers u on pl.createdBy=u.UserId
where pl.paymentModeId=2 and  pl.createdBy=@UserId  and 
convert (varchar,pl.createdOn, 112)>=convert (varchar,@FromDate, 112) 
and  convert (varchar,pl.createdOn, 112)<=convert (varchar,@ToDate, 112) 

group by FORMAT (pl.createdOn, 'dd/MM/yyyy'),r.receiptNo,pl.paymentModeNo,FORMAT (pl.paymentModeDate, 'dd/MM/yyyy'),u.FirstName, ISNULL(u.MiddleName,''), ISNULL(u.LastName,'')
)
UNION all
-- ScanPay 3
(
select
FORMAT (@FromDate, 'dd/MM/yyyy') as FromDate
	,FORMAT (@ToDate, 'dd/MM/yyyy') as ToDate,
r.receiptNo AS ReceiptNo, isnull(pl.paymentModeNo,'-') as PaymentModeNo ,isnull(FORMAT (pl.paymentModeDate, 'dd/MM/yyyy'),'-') as PaymentModeDate

,isnull(FORMAT (pl.createdOn, 'dd/MM/yyyy'),'-') as PaymentDate ,0 as Cash,0 as Cheque, sum(pl.amount) as ScanPay
,(u.FirstName +' '+ ISNULL(u.MiddleName,'') +' '+ isnull(u.LastName,'')) as UserName
from [dbo].tblPaymentLeger pl
left join [dbo].[tblReceipt] r on pl.receiptId= r.receiptId
left join AspNetUsers u on pl.createdBy=u.UserId
where pl.paymentModeId=13 and  pl.createdBy=@UserId  and 
convert (varchar,pl.createdOn, 112)>=convert (varchar,@FromDate, 112) 
and  convert (varchar,pl.createdOn, 112)<=convert (varchar,@ToDate, 112) 

group by FORMAT (pl.createdOn, 'dd/MM/yyyy'),r.receiptNo,pl.paymentModeNo,FORMAT (pl.paymentModeDate, 'dd/MM/yyyy'),u.FirstName, ISNULL(u.MiddleName,''), ISNULL(u.LastName,'')
))gg group by FromDate,ToDate,ReceiptNo,PaymentModeNo,PaymentModeDate,PaymentDate,UserName
order by ReceiptNo


-- exec [dbo].[rptIndividualReceiptWiseCollection] '07-12-2021','07-12-2021',125
END