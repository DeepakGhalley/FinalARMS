
-- exec [dbo].[rptPaymentModeWiseCollection] '07-12-2021','07-12-2021'

create  PROCEDURE [dbo].[rptPaymentModeWiseCollection]
@FromDate  date ,@ToDate  date
AS
BEGIN
SET NOCOUNT ON;
-- CASH 1

 SELECT  ROW_NUMBER() OVER(
        ORDER BY (select 1)) AS Sl, FromDate,ToDate,ReceiptNo,PaymentModeNo,PaymentModeDate,PaymentDate,UserName,FORMAT (getdate(), 'dd/MM/yyyy')  as ExecutionDate
		,sum(Cash)as Cash,sum(Cheque) as Cheque,sum(ThromdeApp) as ThromdeApp, sum(OnlinePaymentAmount)as OnlinePaymentAmount,sum(PIAmount) as PIAmount,sum(MBOBAmount) as MBOBAmount,
		sum(mPayAmount)as mPayAmount,sum(DkAmount) as DkAmount,sum(TPayAmount) as TPayAmount, sum(DrukPNBAmount)as DrukPNBAmount,sum(ePayAmount) as ePayAmount,sum(eTeeruAmount) as eTeeruAmount,
		sum(ScanPay)as ScanPay,
		(SUM(Cash) + SUM(Cheque) + SUM(ThromdeApp) + SUM(OnlinePaymentAmount) + SUM(PIAmount) + SUM(MBOBAmount) + SUM(mPayAmount) + 
		SUM(DkAmount) + SUM(TPayAmount) + SUM(DrukPNBAmount) + SUM(ePayAmount) +SUM(eTeeruAmount) + SUM(ScanPay)) as grandTotal
	   from (
(
select FORMAT (@FromDate, 'dd/MM/yyyy') as FromDate	,FORMAT (@ToDate, 'dd/MM/yyyy') as ToDate,
r.receiptNo AS ReceiptNo, isnull(pl.paymentModeNo,'-') as PaymentModeNo ,isnull(FORMAT (pl.paymentModeDate, 'dd/MM/yyyy'),'-') as PaymentModeDate,
isnull(FORMAT (pl.createdOn, 'dd/MM/yyyy'),'-') as PaymentDate ,sum(pl.amount) as Cash, 0 as Cheque, 0 as ThromdeApp,0 as OnlinePaymentAmount
,0 as PIAmount,0 as MBOBAmount,0 as mPayAmount,0 as DkAmount,0 as TPayAmount,0 as DrukPNBAmount,0 as ePayAmount,0 as eTeeruAmount, 0 as ScanPay,
(u.FirstName +' '+ ISNULL(u.MiddleName,'')+' '+ ISNULL(u.LastName,'')) as UserName
from [dbo].tblPaymentLeger pl
left join [dbo].[tblReceipt] r on pl.receiptId= r.receiptId
left join AspNetUsers u on pl.createdBy=u.UserId
where pl.paymentModeId=1  and 
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

,isnull(FORMAT (pl.createdOn, 'dd/MM/yyyy'),'-') as PaymentDate ,0 as Cash,sum(pl.amount) as Cheque, 0 as ThromdeApp,0 as OnlinePaymentAmount
,0 as PIAmount,0 as MBOBAmount,0 as mPayAmount,0 as DkAmount,0 as TPayAmount,0 as DrukPNBAmount,0 as ePayAmount,0 as eTeeruAmount, 0 as ScanPay,
(u.FirstName +' '+ ISNULL(u.MiddleName,'') +' '+ isnull(u.LastName,'')) as UserName
from [dbo].tblPaymentLeger pl
left join [dbo].[tblReceipt] r on pl.receiptId= r.receiptId
left join AspNetUsers u on pl.createdBy=u.UserId
where pl.paymentModeId=2  and 
convert (varchar,pl.createdOn, 112)>=convert (varchar,@FromDate, 112) 
and  convert (varchar,pl.createdOn, 112)<=convert (varchar,@ToDate, 112) 

group by FORMAT (pl.createdOn, 'dd/MM/yyyy'),r.receiptNo,pl.paymentModeNo,FORMAT (pl.paymentModeDate, 'dd/MM/yyyy'),u.FirstName, ISNULL(u.MiddleName,''), ISNULL(u.LastName,'')
)
UNION all

-- ThromdeApp 3
(
select
FORMAT (@FromDate, 'dd/MM/yyyy') as FromDate
	,FORMAT (@ToDate, 'dd/MM/yyyy') as ToDate,
r.receiptNo AS ReceiptNo, isnull(pl.paymentModeNo,'-') as PaymentModeNo ,isnull(FORMAT (pl.paymentModeDate, 'dd/MM/yyyy'),'-') as PaymentModeDate

,isnull(FORMAT (pl.createdOn, 'dd/MM/yyyy'),'-') as PaymentDate ,0 as Cash, 0 as Cheque, sum(pl.amount) as ThromdeApp,0 as OnlinePaymentAmount
,0 as PIAmount,0 as MBOBAmount,0 as mPayAmount,0 as DkAmount,0 as TPayAmount,0 as DrukPNBAmount,0 as ePayAmount,0 as eTeeruAmount, 0 as ScanPay,
(u.FirstName +' '+ ISNULL(u.MiddleName,'') +' '+ isnull(u.LastName,'')) as UserName
from [dbo].tblPaymentLeger pl
left join [dbo].[tblReceipt] r on pl.receiptId= r.receiptId
left join AspNetUsers u on pl.createdBy=u.UserId
where pl.paymentModeId=3  and 
convert (varchar,pl.createdOn, 112)>=convert (varchar,@FromDate, 112) 
and  convert (varchar,pl.createdOn, 112)<=convert (varchar,@ToDate, 112) 

group by FORMAT (pl.createdOn, 'dd/MM/yyyy'),r.receiptNo,pl.paymentModeNo,FORMAT (pl.paymentModeDate, 'dd/MM/yyyy'),u.FirstName, ISNULL(u.MiddleName,''), ISNULL(u.LastName,'')
)
UNION all

-- OnlinePaymentAmount 4
(
select
FORMAT (@FromDate, 'dd/MM/yyyy') as FromDate
	,FORMAT (@ToDate, 'dd/MM/yyyy') as ToDate,
r.receiptNo AS ReceiptNo, isnull(pl.paymentModeNo,'-') as PaymentModeNo ,isnull(FORMAT (pl.paymentModeDate, 'dd/MM/yyyy'),'-') as PaymentModeDate

,isnull(FORMAT (pl.createdOn, 'dd/MM/yyyy'),'-') as PaymentDate ,0 as Cash, 0 as Cheque, 0 as ThromdeApp,sum(pl.amount) as OnlinePaymentAmount
,0 as PIAmount,0 as MBOBAmount,0 as mPayAmount,0 as DkAmount,0 as TPayAmount,0 as DrukPNBAmount,0 as ePayAmount,0 as eTeeruAmount, 0 as ScanPay,
(u.FirstName +' '+ ISNULL(u.MiddleName,'') +' '+ isnull(u.LastName,'')) as UserName
from [dbo].tblPaymentLeger pl
left join [dbo].[tblReceipt] r on pl.receiptId= r.receiptId
left join AspNetUsers u on pl.createdBy=u.UserId
where pl.paymentModeId=4  and 
convert (varchar,pl.createdOn, 112)>=convert (varchar,@FromDate, 112) 
and  convert (varchar,pl.createdOn, 112)<=convert (varchar,@ToDate, 112) 

group by FORMAT (pl.createdOn, 'dd/MM/yyyy'),r.receiptNo,pl.paymentModeNo,FORMAT (pl.paymentModeDate, 'dd/MM/yyyy'),u.FirstName, ISNULL(u.MiddleName,''), ISNULL(u.LastName,'')
)
UNION all

-- PIAmount 5
(
select
FORMAT (@FromDate, 'dd/MM/yyyy') as FromDate
	,FORMAT (@ToDate, 'dd/MM/yyyy') as ToDate,
r.receiptNo AS ReceiptNo, isnull(pl.paymentModeNo,'-') as PaymentModeNo ,isnull(FORMAT (pl.paymentModeDate, 'dd/MM/yyyy'),'-') as PaymentModeDate

,isnull(FORMAT (pl.createdOn, 'dd/MM/yyyy'),'-') as PaymentDate ,0 as Cash, 0 as Cheque, 0 as ThromdeApp,0 as OnlinePaymentAmount
,sum(pl.amount) as PIAmount,0 as MBOBAmount,0 as mPayAmount,0 as DkAmount,0 as TPayAmount,0 as DrukPNBAmount,0 as ePayAmount,0 as eTeeruAmount, 0 as ScanPay,
(u.FirstName +' '+ ISNULL(u.MiddleName,'') +' '+ isnull(u.LastName,'')) as UserName
from [dbo].tblPaymentLeger pl
left join [dbo].[tblReceipt] r on pl.receiptId= r.receiptId
left join AspNetUsers u on pl.createdBy=u.UserId
where pl.paymentModeId=5  and 
convert (varchar,pl.createdOn, 112)>=convert (varchar,@FromDate, 112) 
and  convert (varchar,pl.createdOn, 112)<=convert (varchar,@ToDate, 112) 

group by FORMAT (pl.createdOn, 'dd/MM/yyyy'),r.receiptNo,pl.paymentModeNo,FORMAT (pl.paymentModeDate, 'dd/MM/yyyy'),u.FirstName, ISNULL(u.MiddleName,''), ISNULL(u.LastName,'')
)
UNION all

-- MBOBAmount 6
(
select
FORMAT (@FromDate, 'dd/MM/yyyy') as FromDate
	,FORMAT (@ToDate, 'dd/MM/yyyy') as ToDate,
r.receiptNo AS ReceiptNo, isnull(pl.paymentModeNo,'-') as PaymentModeNo ,isnull(FORMAT (pl.paymentModeDate, 'dd/MM/yyyy'),'-') as PaymentModeDate

,isnull(FORMAT (pl.createdOn, 'dd/MM/yyyy'),'-') as PaymentDate ,0 as Cash, 0 as Cheque, 0 as ThromdeApp,0 as OnlinePaymentAmount
,0 as PIAmount,sum(pl.amount) as MBOBAmount,0 as mPayAmount,0 as DkAmount,0 as TPayAmount,0 as DrukPNBAmount,0 as ePayAmount,0 as eTeeruAmount, 0 as ScanPay,
(u.FirstName +' '+ ISNULL(u.MiddleName,'') +' '+ isnull(u.LastName,'')) as UserName
from [dbo].tblPaymentLeger pl
left join [dbo].[tblReceipt] r on pl.receiptId= r.receiptId
left join AspNetUsers u on pl.createdBy=u.UserId
where pl.paymentModeId=6  and 
convert (varchar,pl.createdOn, 112)>=convert (varchar,@FromDate, 112) 
and  convert (varchar,pl.createdOn, 112)<=convert (varchar,@ToDate, 112) 

group by FORMAT (pl.createdOn, 'dd/MM/yyyy'),r.receiptNo,pl.paymentModeNo,FORMAT (pl.paymentModeDate, 'dd/MM/yyyy'),u.FirstName, ISNULL(u.MiddleName,''), ISNULL(u.LastName,'')
)
UNION all

-- mPayAmount 7
(
select
FORMAT (@FromDate, 'dd/MM/yyyy') as FromDate
	,FORMAT (@ToDate, 'dd/MM/yyyy') as ToDate,
r.receiptNo AS ReceiptNo, isnull(pl.paymentModeNo,'-') as PaymentModeNo ,isnull(FORMAT (pl.paymentModeDate, 'dd/MM/yyyy'),'-') as PaymentModeDate

,isnull(FORMAT (pl.createdOn, 'dd/MM/yyyy'),'-') as PaymentDate ,0 as Cash, 0 as Cheque, 0 as ThromdeApp,0 as OnlinePaymentAmount
,0 as PIAmount,0 as MBOBAmount,sum(pl.amount) as mPayAmount,0 as DkAmount,0 as TPayAmount,0 as DrukPNBAmount,0 as ePayAmount,0 as eTeeruAmount, 0 as ScanPay,
(u.FirstName +' '+ ISNULL(u.MiddleName,'') +' '+ isnull(u.LastName,'')) as UserName
from [dbo].tblPaymentLeger pl
left join [dbo].[tblReceipt] r on pl.receiptId= r.receiptId
left join AspNetUsers u on pl.createdBy=u.UserId
where pl.paymentModeId=7  and 
convert (varchar,pl.createdOn, 112)>=convert (varchar,@FromDate, 112) 
and  convert (varchar,pl.createdOn, 112)<=convert (varchar,@ToDate, 112) 

group by FORMAT (pl.createdOn, 'dd/MM/yyyy'),r.receiptNo,pl.paymentModeNo,FORMAT (pl.paymentModeDate, 'dd/MM/yyyy'),u.FirstName, ISNULL(u.MiddleName,''), ISNULL(u.LastName,'')
)
UNION all

-- DkAmount 8
(
select
FORMAT (@FromDate, 'dd/MM/yyyy') as FromDate
	,FORMAT (@ToDate, 'dd/MM/yyyy') as ToDate,
r.receiptNo AS ReceiptNo, isnull(pl.paymentModeNo,'-') as PaymentModeNo ,isnull(FORMAT (pl.paymentModeDate, 'dd/MM/yyyy'),'-') as PaymentModeDate

,isnull(FORMAT (pl.createdOn, 'dd/MM/yyyy'),'-') as PaymentDate ,0 as Cash, 0 as Cheque, 0 as ThromdeApp,0 as OnlinePaymentAmount
,0 as PIAmount,0 as MBOBAmount,0 as mPayAmount,sum(pl.amount) as DkAmount,0 as TPayAmount,0 as DrukPNBAmount,0 as ePayAmount,0 as eTeeruAmount, 0 as ScanPay,
(u.FirstName +' '+ ISNULL(u.MiddleName,'') +' '+ isnull(u.LastName,'')) as UserName
from [dbo].tblPaymentLeger pl
left join [dbo].[tblReceipt] r on pl.receiptId= r.receiptId
left join AspNetUsers u on pl.createdBy=u.UserId
where pl.paymentModeId=8  and 
convert (varchar,pl.createdOn, 112)>=convert (varchar,@FromDate, 112) 
and  convert (varchar,pl.createdOn, 112)<=convert (varchar,@ToDate, 112) 

group by FORMAT (pl.createdOn, 'dd/MM/yyyy'),r.receiptNo,pl.paymentModeNo,FORMAT (pl.paymentModeDate, 'dd/MM/yyyy'),u.FirstName, ISNULL(u.MiddleName,''), ISNULL(u.LastName,'')
)
UNION all

-- TPayAmount 9
(
select
FORMAT (@FromDate, 'dd/MM/yyyy') as FromDate
	,FORMAT (@ToDate, 'dd/MM/yyyy') as ToDate,
r.receiptNo AS ReceiptNo, isnull(pl.paymentModeNo,'-') as PaymentModeNo ,isnull(FORMAT (pl.paymentModeDate, 'dd/MM/yyyy'),'-') as PaymentModeDate

,isnull(FORMAT (pl.createdOn, 'dd/MM/yyyy'),'-') as PaymentDate ,0 as Cash, 0 as Cheque, 0 as ThromdeApp,0 as OnlinePaymentAmount
,0 as PIAmount,0 as MBOBAmount,0 as mPayAmount,0 as DkAmount,sum(pl.amount) as TPayAmount,0 as DrukPNBAmount,0 as ePayAmount,0 as eTeeruAmount, 0 as ScanPay,
(u.FirstName +' '+ ISNULL(u.MiddleName,'') +' '+ isnull(u.LastName,'')) as UserName
from [dbo].tblPaymentLeger pl
left join [dbo].[tblReceipt] r on pl.receiptId= r.receiptId
left join AspNetUsers u on pl.createdBy=u.UserId
where pl.paymentModeId=9  and 
convert (varchar,pl.createdOn, 112)>=convert (varchar,@FromDate, 112) 
and  convert (varchar,pl.createdOn, 112)<=convert (varchar,@ToDate, 112) 

group by FORMAT (pl.createdOn, 'dd/MM/yyyy'),r.receiptNo,pl.paymentModeNo,FORMAT (pl.paymentModeDate, 'dd/MM/yyyy'),u.FirstName, ISNULL(u.MiddleName,''), ISNULL(u.LastName,'')
)
UNION all

-- DrukPNBAmount 10
(
select
FORMAT (@FromDate, 'dd/MM/yyyy') as FromDate
	,FORMAT (@ToDate, 'dd/MM/yyyy') as ToDate,
r.receiptNo AS ReceiptNo, isnull(pl.paymentModeNo,'-') as PaymentModeNo ,isnull(FORMAT (pl.paymentModeDate, 'dd/MM/yyyy'),'-') as PaymentModeDate

,isnull(FORMAT (pl.createdOn, 'dd/MM/yyyy'),'-') as PaymentDate ,0 as Cash, 0 as Cheque, 0 as ThromdeApp,0 as OnlinePaymentAmount
,0 as PIAmount,0 as MBOBAmount,0 as mPayAmount,0 as DkAmount,0 as TPayAmount,sum(pl.amount) as DrukPNBAmount,0 as ePayAmount,0 as eTeeruAmount, 0 as ScanPay,
(u.FirstName +' '+ ISNULL(u.MiddleName,'') +' '+ isnull(u.LastName,'')) as UserName
from [dbo].tblPaymentLeger pl
left join [dbo].[tblReceipt] r on pl.receiptId= r.receiptId
left join AspNetUsers u on pl.createdBy=u.UserId
where pl.paymentModeId=10  and 
convert (varchar,pl.createdOn, 112)>=convert (varchar,@FromDate, 112) 
and  convert (varchar,pl.createdOn, 112)<=convert (varchar,@ToDate, 112) 

group by FORMAT (pl.createdOn, 'dd/MM/yyyy'),r.receiptNo,pl.paymentModeNo,FORMAT (pl.paymentModeDate, 'dd/MM/yyyy'),u.FirstName, ISNULL(u.MiddleName,''), ISNULL(u.LastName,'')
)
UNION all

-- ePayAmount 11
(
select
FORMAT (@FromDate, 'dd/MM/yyyy') as FromDate
	,FORMAT (@ToDate, 'dd/MM/yyyy') as ToDate,
r.receiptNo AS ReceiptNo, isnull(pl.paymentModeNo,'-') as PaymentModeNo ,isnull(FORMAT (pl.paymentModeDate, 'dd/MM/yyyy'),'-') as PaymentModeDate

,isnull(FORMAT (pl.createdOn, 'dd/MM/yyyy'),'-') as PaymentDate ,0 as Cash, 0 as Cheque, 0 as ThromdeApp,0 as OnlinePaymentAmount
,0 as PIAmount,0 as MBOBAmount,0 as mPayAmount,0 as DkAmount,0 as TPayAmount,0 as DrukPNBAmount,sum(pl.amount) as ePayAmount,0 as eTeeruAmount, 0 as ScanPay,
(u.FirstName +' '+ ISNULL(u.MiddleName,'') +' '+ isnull(u.LastName,'')) as UserName
from [dbo].tblPaymentLeger pl
left join [dbo].[tblReceipt] r on pl.receiptId= r.receiptId
left join AspNetUsers u on pl.createdBy=u.UserId
where pl.paymentModeId=11  and 
convert (varchar,pl.createdOn, 112)>=convert (varchar,@FromDate, 112) 
and  convert (varchar,pl.createdOn, 112)<=convert (varchar,@ToDate, 112) 

group by FORMAT (pl.createdOn, 'dd/MM/yyyy'),r.receiptNo,pl.paymentModeNo,FORMAT (pl.paymentModeDate, 'dd/MM/yyyy'),u.FirstName, ISNULL(u.MiddleName,''), ISNULL(u.LastName,'')
)
UNION all

-- eTeeruAmount 12
(
select
FORMAT (@FromDate, 'dd/MM/yyyy') as FromDate
	,FORMAT (@ToDate, 'dd/MM/yyyy') as ToDate,
r.receiptNo AS ReceiptNo, isnull(pl.paymentModeNo,'-') as PaymentModeNo ,isnull(FORMAT (pl.paymentModeDate, 'dd/MM/yyyy'),'-') as PaymentModeDate

,isnull(FORMAT (pl.createdOn, 'dd/MM/yyyy'),'-') as PaymentDate ,0 as Cash, 0 as Cheque, 0 as ThromdeApp,0 as OnlinePaymentAmount
,0 as PIAmount,0 as MBOBAmount,0 as mPayAmount,0 as DkAmount,0 as TPayAmount,0 as DrukPNBAmount,0 as ePayAmount,sum(pl.amount) as eTeeruAmount, 0 as ScanPay,
(u.FirstName +' '+ ISNULL(u.MiddleName,'') +' '+ isnull(u.LastName,'')) as UserName
from [dbo].tblPaymentLeger pl
left join [dbo].[tblReceipt] r on pl.receiptId= r.receiptId
left join AspNetUsers u on pl.createdBy=u.UserId
where pl.paymentModeId=12  and 
convert (varchar,pl.createdOn, 112)>=convert (varchar,@FromDate, 112) 
and  convert (varchar,pl.createdOn, 112)<=convert (varchar,@ToDate, 112) 

group by FORMAT (pl.createdOn, 'dd/MM/yyyy'),r.receiptNo,pl.paymentModeNo,FORMAT (pl.paymentModeDate, 'dd/MM/yyyy'),u.FirstName, ISNULL(u.MiddleName,''), ISNULL(u.LastName,'')
)
UNION all

-- ScanPay 13
(
select
FORMAT (@FromDate, 'dd/MM/yyyy') as FromDate
	,FORMAT (@ToDate, 'dd/MM/yyyy') as ToDate,
r.receiptNo AS ReceiptNo, isnull(pl.paymentModeNo,'-') as PaymentModeNo ,isnull(FORMAT (pl.paymentModeDate, 'dd/MM/yyyy'),'-') as PaymentModeDate

,isnull(FORMAT (pl.createdOn, 'dd/MM/yyyy'),'-') as PaymentDate ,0 as Cash,0 as Cheque, 0 as ThromdeApp,0 as OnlinePaymentAmount
,0 as PIAmount,0 as MBOBAmount,0 as mPayAmount,0 as DkAmount,0 as TPayAmount,0 as DrukPNBAmount,0 as ePayAmount,0 as eTeeruAmount, sum(pl.amount) as ScanPay
,(u.FirstName +' '+ ISNULL(u.MiddleName,'') +' '+ isnull(u.LastName,'')) as UserName
from [dbo].tblPaymentLeger pl
left join [dbo].[tblReceipt] r on pl.receiptId= r.receiptId
left join AspNetUsers u on pl.createdBy=u.UserId
where pl.paymentModeId=13  and 
convert (varchar,pl.createdOn, 112)>=convert (varchar,@FromDate, 112) 
and  convert (varchar,pl.createdOn, 112)<=convert (varchar,@ToDate, 112) 

group by FORMAT (pl.createdOn, 'dd/MM/yyyy'),r.receiptNo,pl.paymentModeNo,FORMAT (pl.paymentModeDate, 'dd/MM/yyyy'),u.FirstName, ISNULL(u.MiddleName,''), ISNULL(u.LastName,'')

))gg group by FromDate,ToDate,ReceiptNo,PaymentModeNo,PaymentModeDate,PaymentDate,UserName
order by ReceiptNo

END