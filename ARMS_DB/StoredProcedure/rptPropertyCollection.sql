CREATE PROCEDURE [dbo].[rptPropertyCollection]
@StartDate date, @EndDate date
AS
BEGIN
SET NOCOUNT ON;
SELECT ROW_NUMBER() over(order by(select 1)) as Sl,convert (varchar, @StartDate,103)  as FromDate,convert (varchar, @EndDate,103)  as ToDate,
rec.receiptNo,
CONVERT(varchar, l.createdOn,103) as PaymentDate, 
sum(l.totalAmount) as Amount, sum(l.penaltyAmount) as Penalty

from  tblLedger l
inner join tblReceipt rec on l.receiptId = rec.receiptId
inner join mstTaxMaster tm on l.taxId = tm.taxId
inner join mstDetailHead d on tm.detailHeadId = d.detailHeadId
inner join mstMinorHead m on d.minorHeadId = m.minorHeadId
where FORMAT (l.createdOn, 'yyyyMMdd') >= FORMAT (@StartDate, 'yyyyMMdd')
and FORMAT (l.createdOn, 'yyyyMMdd') <= FORMAT (@EndDate, 'yyyyMMdd') and m.minorHeadId in (1,2,3,4,5,10) 
group by rec.receiptNo, l.createdOn, l.penaltyAmount,m.minorHeadId, m.minorHeadName

end
RETURN 0