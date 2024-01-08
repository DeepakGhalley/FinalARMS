-- exec [dbo].[rptDailyReceiptWiseCollectionByFromDateToDate] '20210423','20211104'

create PROCEDURE [dbo].[rptDailyReceiptWiseCollectionByFromDateToDate]
	-- Add the parameters for the stored procedure here
		 @FromDate  date ,@ToDate  date
AS
BEGIN
SET NOCOUNT ON;


 SELECT  ROW_NUMBER() OVER(
       ORDER BY (select 1)) AS Sl, *,(CashAmount+ChecqueAmount+ThromdeApp+OnlinePaymentAmount+PIAmount+MBOBAmount+mPayAmount+DkAmount+TPayAmount+DrukPNBAmount+ePayAmount+eTeeruAmount+ScanPay)AS GrandTotal from (
(
-- CASH 1
select r.receiptId,
r.receiptNo AS ReceiptNo, isnull(pl.paymentModeNo,'-') as PaymentModeNo ,isnull(convert(varchar ,pl.paymentModeDate,103),'') as PaymentModeDate,
convert(varchar ,pl.createdOn,103) as PaymentDate ,sum(pl.amount) as CashAmount,0 as ChecqueAmount,0 as ThromdeApp,0 as OnlinePaymentAmount
,0 as PIAmount,0 as MBOBAmount,0 as mPayAmount,0 as DkAmount,0 as TPayAmount,0 as DrukPNBAmount,0 as ePayAmount,0 as eTeeruAmount, 0 as ScanPay
,convert(varchar ,@FromDate,103) as FromDate,convert(varchar ,@ToDate,103) as ToDate
from [dbo].tblPaymentLeger pl
left join [dbo].[tblReceipt] r on pl.receiptId= r.receiptId
where pl.paymentModeId=1 and convert(varchar ,pl.createdOn,112)>=@FromDate and convert(varchar ,pl.createdOn,112)<=@ToDate
group by convert(varchar ,pl.createdOn,103),r.receiptNo, r.receiptId,pl.paymentModeNo,pl.paymentModeDate
)
UNION all
-- CHEQUE 2
(
select  r.receiptId,
--convert(varchar ,@FromDate,103) as FromDate,convert(varchar ,@ToDate,103) as ToDate,
r.receiptNo AS ReceiptNo, isnull(pl.paymentModeNo,'-') as PaymentModeNo ,isnull(convert(varchar ,pl.paymentModeDate,103),'') as PaymentModeDate,
convert(varchar ,pl.createdOn,103) as PaymentDate, 0 as CashAmount,sum(pl.amount) as ChecqueAmount,0 as ThromdeApp,0 as OnlinePaymentAmount
,0 as PIAmount,0 as MBOBAmount,0 as mPayAmount,0 as DkAmount,0 as TPayAmount,0 as DrukPNBAmount,0 as ePayAmount,0 as eTeeruAmount, 0 as ScanPay
,convert(varchar ,@FromDate,103) as FromDate,convert(varchar ,@ToDate,103) as ToDate
from [dbo].tblPaymentLeger pl

left join [dbo].[tblReceipt] r on pl.receiptId= r.receiptId
where pl.paymentModeId=2 and convert(varchar ,pl.createdOn,112)>=@FromDate and convert(varchar ,pl.createdOn,112)<=@ToDate
group by convert(varchar ,pl.createdOn,103),r.receiptNo, r.receiptId,pl.paymentModeNo,pl.paymentModeDate
)
UNION all
-- Thromde App 3
(
select  r.receiptId,
--convert(varchar ,@FromDate,103) as FromDate,convert(varchar ,@ToDate,103) as ToDate,
r.receiptNo AS ReceiptNo, isnull(pl.paymentModeNo,'-') as PaymentModeNo ,isnull(convert(varchar ,pl.paymentModeDate,103),'') as PaymentModeDate,
convert(varchar ,pl.createdOn,103) as PaymentDate, 0 as CashAmount,0 as ChecqueAmount,sum(pl.amount) as ThromdeApp,0 as OnlinePaymentAmount
,0 as PIAmount,0 as MBOBAmount,0 as mPayAmount,0 as DkAmount,0 as TPayAmount,0 as DrukPNBAmount,0 as ePayAmount,0 as eTeeruAmount, 0 as ScanPay
,convert(varchar ,@FromDate,103) as FromDate,convert(varchar ,@ToDate,103) as ToDate
from [dbo].tblPaymentLeger pl

left join [dbo].[tblReceipt] r on pl.receiptId= r.receiptId
where pl.paymentModeId=3 and convert(varchar ,pl.createdOn,112)>=@FromDate and convert(varchar ,pl.createdOn,112)<=@ToDate
group by convert(varchar ,pl.createdOn,103),r.receiptNo, r.receiptId,pl.paymentModeNo,pl.paymentModeDate
)
UNION all
-- OnlinePaymentAmount 4
(
select  r.receiptId,
--convert(varchar ,@FromDate,103) as FromDate,convert(varchar ,@ToDate,103) as ToDate,
r.receiptNo AS ReceiptNo, isnull(pl.paymentModeNo,'-') as PaymentModeNo ,isnull(convert(varchar ,pl.paymentModeDate,103),'') as PaymentModeDate,
convert(varchar ,pl.createdOn,103) as PaymentDate, 0 as CashAmount,0 as ChecqueAmount,0 as ThromdeApp,sum(pl.amount) as OnlinePaymentAmount
,0 as PIAmount,0 as MBOBAmount,0 as mPayAmount,0 as DkAmount,0 as TPayAmount,0 as DrukPNBAmount,0 as ePayAmount,0 as eTeeruAmount, 0 as ScanPay
,convert(varchar ,@FromDate,103) as FromDate,convert(varchar ,@ToDate,103) as ToDate
from [dbo].tblPaymentLeger pl

left join [dbo].[tblReceipt] r on pl.receiptId= r.receiptId
where pl.paymentModeId=4 and convert(varchar ,pl.createdOn,112)>=@FromDate and convert(varchar ,pl.createdOn,112)<=@ToDate
group by convert(varchar ,pl.createdOn,103),r.receiptNo, r.receiptId,pl.paymentModeNo,pl.paymentModeDate
)

UNION all
-- PIAmount 5
(
select  r.receiptId,
--convert(varchar ,@FromDate,103) as FromDate,convert(varchar ,@ToDate,103) as ToDate,
r.receiptNo AS ReceiptNo, isnull(pl.paymentModeNo,'-') as PaymentModeNo ,isnull(convert(varchar ,pl.paymentModeDate,103),'') as PaymentModeDate,
convert(varchar ,pl.createdOn,103) as PaymentDate, 0 as CashAmount,0 as ChecqueAmount,0 as ThromdeApp,0 as OnlinePaymentAmount
,sum(pl.amount) as PIAmount,0 as MBOBAmount,0 as mPayAmount,0 as DkAmount,0 as TPayAmount,0 as DrukPNBAmount,0 as ePayAmount,0 as eTeeruAmount,0 as ScanPay
,convert(varchar ,@FromDate,103) as FromDate,convert(varchar ,@ToDate,103) as ToDate
from [dbo].tblPaymentLeger pl

left join [dbo].[tblReceipt] r on pl.receiptId= r.receiptId
where pl.paymentModeId=5 and convert(varchar ,pl.createdOn,112)>=@FromDate and convert(varchar ,pl.createdOn,112)<=@ToDate
group by convert(varchar ,pl.createdOn,103),r.receiptNo, r.receiptId,pl.paymentModeNo,pl.paymentModeDate
)
UNION all
-- MBOB 6
(
select  r.receiptId,
--convert(varchar ,@FromDate,103) as FromDate,convert(varchar ,@ToDate,103) as ToDate,
r.receiptNo AS ReceiptNo, isnull(pl.paymentModeNo,'-') as PaymentModeNo ,isnull(convert(varchar ,pl.paymentModeDate,103),'') as PaymentModeDate,
convert(varchar ,pl.createdOn,103) as PaymentDate, 0 as CashAmount,0 as ChecqueAmount,0 as ThromdeApp,0 as OnlinePaymentAmount
,0 as PIAmount,sum(pl.amount) as MBOBAmount,0 as mPayAmount,0 as DkAmount,0 as TPayAmount,0 as DrukPNBAmount,0 as ePayAmount,0 as eTeeruAmount,0 as ScanPay
,convert(varchar ,@FromDate,103) as FromDate,convert(varchar ,@ToDate,103) as ToDate
from [dbo].tblPaymentLeger pl

left join [dbo].[tblReceipt] r on pl.receiptId= r.receiptId
where pl.paymentModeId=6 and convert(varchar ,pl.createdOn,112)>=@FromDate and convert(varchar ,pl.createdOn,112)<=@ToDate
group by convert(varchar ,pl.createdOn,103),r.receiptNo, r.receiptId,pl.paymentModeNo,pl.paymentModeDate
)
UNION all
-- mPayAmount 7
(
select  r.receiptId,
--convert(varchar ,@FromDate,103) as FromDate,convert(varchar ,@ToDate,103) as ToDate,
r.receiptNo AS ReceiptNo, isnull(pl.paymentModeNo,'-') as PaymentModeNo ,isnull(convert(varchar ,pl.paymentModeDate,103),'') as PaymentModeDate,
convert(varchar ,pl.createdOn,103) as PaymentDate, 0 as CashAmount,0 as ChecqueAmount,0 as ThromdeApp,0 as OnlinePaymentAmount
,0 as PIAmount,0 as MBOBAmount,sum(pl.amount) as mPayAmount,0 as DkAmount,0 as TPayAmount,0 as DrukPNBAmount,0 as ePayAmount,0 as eTeeruAmount, 0 as ScanPay
,convert(varchar ,@FromDate,103) as FromDate,convert(varchar ,@ToDate,103) as ToDate
from [dbo].tblPaymentLeger pl

left join [dbo].[tblReceipt] r on pl.receiptId= r.receiptId
where pl.paymentModeId=7 and convert(varchar ,pl.createdOn,112)>=@FromDate and convert(varchar ,pl.createdOn,112)<=@ToDate
group by convert(varchar ,pl.createdOn,103),r.receiptNo, r.receiptId,pl.paymentModeNo,pl.paymentModeDate
)
UNION all
-- DkAmount 8
( 
select  r.receiptId,
--convert(varchar ,@FromDate,103) as FromDate,convert(varchar ,@ToDate,103) as ToDate,
r.receiptNo AS ReceiptNo, isnull(pl.paymentModeNo,'-') as PaymentModeNo ,isnull(convert(varchar ,pl.paymentModeDate,103),'') as PaymentModeDate,
convert(varchar ,pl.createdOn,103) as PaymentDate, 0 as CashAmount,0 as ChecqueAmount,0 as ThromdeApp,0 as OnlinePaymentAmount
,0 as PIAmount,0 as MBOBAmount,0 as mPayAmount,sum(pl.amount) as DkAmount,0 as TPayAmount,0 as DrukPNBAmount,0 as ePayAmount,0 as eTeeruAmount, 0 as ScanPay
,convert(varchar ,@FromDate,103) as FromDate,convert(varchar ,@ToDate,103) as ToDate
from [dbo].tblPaymentLeger pl

left join [dbo].[tblReceipt] r on pl.receiptId= r.receiptId
where pl.paymentModeId=8 and convert(varchar ,pl.createdOn,112)>=@FromDate and convert(varchar ,pl.createdOn,112)<=@ToDate
group by convert(varchar ,pl.createdOn,103),r.receiptNo, r.receiptId,pl.paymentModeNo,pl.paymentModeDate
)
UNION all
-- TPayAmount 9
(
select  r.receiptId,
--convert(varchar ,@FromDate,103) as FromDate,convert(varchar ,@ToDate,103) as ToDate,
r.receiptNo AS ReceiptNo, isnull(pl.paymentModeNo,'-') as PaymentModeNo ,isnull(convert(varchar ,pl.paymentModeDate,103),'') as PaymentModeDate,
convert(varchar ,pl.createdOn,103) as PaymentDate, 0 as CashAmount,0 as ChecqueAmount,0 as ThromdeApp,0 as OnlinePaymentAmount
,0 as PIAmount,0 as MBOBAmount,0 as mPayAmount,0 as DkAmount,sum(pl.amount) as TPayAmount,0 as DrukPNBAmount,0 as ePayAmount,0 as eTeeruAmount, 0 as ScanPay
,convert(varchar ,@FromDate,103) as FromDate,convert(varchar ,@ToDate,103) as ToDate
from [dbo].tblPaymentLeger pl

left join [dbo].[tblReceipt] r on pl.receiptId= r.receiptId
where pl.paymentModeId=9 and convert(varchar ,pl.createdOn,112)>=convert(varchar ,@FromDate,112)  and convert(varchar ,pl.createdOn,112)<=convert(varchar ,@ToDate,112)
group by convert(varchar ,pl.createdOn,103),r.receiptNo, r.receiptId,pl.paymentModeNo,pl.paymentModeDate
)

UNION all
-- DrukPNBAmount 10
(
select  r.receiptId,
--convert(varchar ,@FromDate,103) as FromDate,convert(varchar ,@ToDate,103) as ToDate,
r.receiptNo AS ReceiptNo, isnull(pl.paymentModeNo,'-') as PaymentModeNo ,isnull(convert(varchar ,pl.paymentModeDate,103),'') as PaymentModeDate,
convert(varchar ,pl.createdOn,103) as PaymentDate, 0 as CashAmount,0 as ChecqueAmount,0 as ThromdeApp,0 as OnlinePaymentAmount
,0 as PIAmount,0 as MBOBAmount,0 as mPayAmount,0 as DkAmount,0 as TPayAmount,sum(pl.amount) as DrukPNBAmount,0 as ePayAmount,0 as eTeeruAmount, 0 as ScanPay
,convert(varchar ,@FromDate,103) as FromDate,convert(varchar ,@ToDate,103) as ToDate
from [dbo].tblPaymentLeger pl

left join [dbo].[tblReceipt] r on pl.receiptId= r.receiptId
where pl.paymentModeId=10 and convert(varchar ,pl.createdOn,112)>=convert(varchar ,@FromDate,112)  and convert(varchar ,pl.createdOn,112)<=convert(varchar ,@ToDate,112)
group by convert(varchar ,pl.createdOn,103),r.receiptNo, r.receiptId,pl.paymentModeNo,pl.paymentModeDate
)
UNION all
-- ePayAmount 11
(
select  r.receiptId,
--convert(varchar ,@FromDate,103) as FromDate,convert(varchar ,@ToDate,103) as ToDate,
r.receiptNo AS ReceiptNo, isnull(pl.paymentModeNo,'-') as PaymentModeNo ,isnull(convert(varchar ,pl.paymentModeDate,103),'') as PaymentModeDate,
convert(varchar ,pl.createdOn,103) as PaymentDate, 0 as CashAmount,0 as ChecqueAmount,0 as ThromdeApp,0 as OnlinePaymentAmount
,0 as PIAmount,0 as MBOBAmount,0 as mPayAmount,0 as DkAmount,0 as TPayAmount,0 as DrukPNBAmount,sum(pl.amount) as ePayAmount,0 as eTeeruAmount, 0 as ScanPay
,convert(varchar ,@FromDate,103) as FromDate,convert(varchar ,@ToDate,103) as ToDate
from [dbo].tblPaymentLeger pl

left join [dbo].[tblReceipt] r on pl.receiptId= r.receiptId
where pl.paymentModeId=11 and convert(varchar ,pl.createdOn,112)>=convert(varchar ,@FromDate,112)  and convert(varchar ,pl.createdOn,112)<=convert(varchar ,@ToDate,112)
group by convert(varchar ,pl.createdOn,103),r.receiptNo, r.receiptId,pl.paymentModeNo,pl.paymentModeDate
)
UNION all
-- eTeeruAmount 12
(
select  r.receiptId,
--convert(varchar ,@FromDate,103) as FromDate,convert(varchar ,@ToDate,103) as ToDate,
r.receiptNo AS ReceiptNo, isnull(pl.paymentModeNo,'-') as PaymentModeNo ,isnull(convert(varchar ,pl.paymentModeDate,103),'') as PaymentModeDate,
convert(varchar ,pl.createdOn,103) as PaymentDate, 0 as CashAmount,0 as ChecqueAmount,0 as ThromdeApp,0 as OnlinePaymentAmount
,0 as PIAmount,0 as MBOBAmount,0 as mPayAmount,0 as DkAmount,0 as TPayAmount,0 as DrukPNBAmount,0 as ePayAmount,sum(pl.amount) as eTeeruAmount,0 as ScanPay
,convert(varchar ,@FromDate,103) as FromDate,convert(varchar ,@ToDate,103) as ToDate
from [dbo].tblPaymentLeger pl

left join [dbo].[tblReceipt] r on pl.receiptId= r.receiptId
where pl.paymentModeId=12 and convert(varchar ,pl.createdOn,112)>=convert(varchar ,@FromDate,112)  and convert(varchar ,pl.createdOn,112)<=convert(varchar ,@ToDate,112)
group by convert(varchar ,pl.createdOn,103),r.receiptNo, r.receiptId,pl.paymentModeNo,pl.paymentModeDate
)
UNION all
-- ScanPay 13
(
select  r.receiptId,
--convert(varchar ,@FromDate,103) as FromDate,convert(varchar ,@ToDate,103) as ToDate,
r.receiptNo AS ReceiptNo, isnull(pl.paymentModeNo,'-') as PaymentModeNo ,isnull(convert(varchar ,pl.paymentModeDate,103),'') as PaymentModeDate,
convert(varchar ,pl.createdOn,103) as PaymentDate, 0 as CashAmount,0 as ChecqueAmount,0 as ThromdeApp,0 as OnlinePaymentAmount
,0 as PIAmount,0 as MBOBAmount,0 as mPayAmount,0 as DkAmount,0 as TPayAmount,0 as DrukPNBAmount,0 as ePayAmount,0 as eTeeruAmount, sum(pl.amount) as ScanPay
,convert(varchar ,@FromDate,103) as FromDate,convert(varchar ,@ToDate,103) as ToDate
from [dbo].tblPaymentLeger pl

left join [dbo].[tblReceipt] r on pl.receiptId= r.receiptId
where pl.paymentModeId=13 and convert(varchar ,pl.createdOn,112)>=convert(varchar ,@FromDate,112)  and convert(varchar ,pl.createdOn,112)<=convert(varchar ,@ToDate,112)
group by convert(varchar ,pl.createdOn,103),r.receiptNo , r.receiptId,pl.paymentModeNo,pl.paymentModeDate
)) gg
order by receiptId
END