create PROCEDURE [dbo].[rptOnlinePaymentByFromDateToDate]
	@FromDate date
	,@ToDate date
AS
 SELECT  ROW_NUMBER() OVER(
 ORDER BY (select 1)) AS Sl
,FORMAT (pl.createdOn, 'dd/MM/yyyy, hh:mm') as PaymentDate
	,r.receiptNo as ReceiptNo
	,isnull(pl.paymentModeNo,'-') as PaymentModeNo
	,isnull(FORMAT (pl.paymentModeDate, 'dd/MM/yyyy'),'-')  as PaymentModeDate
	,isnull(sum(amount),0) as TotalAmount
	,FORMAT (@FromDate, 'dd/MM/yyyy') as FromDate
	,FORMAT (@ToDate, 'dd/MM/yyyy') as ToDate
	   from tblPaymentLeger pl 	  
	   left join tblReceipt r on pl.receiptId=r.receiptId
	  where pl.paymentModeId not in(1,2) and
	  convert (varchar,pl.createdOn, 112)>=convert (varchar,@FromDate, 112) 
	  and  convert (varchar,pl.createdOn, 112)<=convert (varchar,@ToDate, 112) 
	  
group by r.receiptNo,FORMAT (pl.createdOn, 'dd/MM/yyyy, hh:mm')
,pl.paymentModeNo,FORMAT (pl.paymentModeDate, 'dd/MM/yyyy')
order by r.receiptNo,PaymentDate
RETURN 0

-- exec [dbo].[rptOnlinePaymentByFromDateToDate] 20/02/2021
