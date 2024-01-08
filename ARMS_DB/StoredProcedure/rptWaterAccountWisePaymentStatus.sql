--exec [dbo].[rptWaterAccountWisePaymentStatus] '20210701','20210712'

create PROCEDURE [dbo].[rptWaterAccountWisePaymentStatus]
    @FromDate  date ,@ToDate  date

AS
BEGIN

    SET NOCOUNT ON;

    SELECT  ROW_NUMBER() OVER(
    ORDER BY (select 1)) AS Sl, convert (varchar, @FromDate,103)  as FromDate,convert (varchar, @ToDate,103) as ToDate,
    r.receiptNo, l.totalAmount as paymentAount, tm.taxName, w.previousReading, w.reading, w.consumption, w.waterConnectionStatusId,
    l.paymentStatusId   
    from tblWaterMeterReading w
    inner join tblLedger l on w.transactionId = l.transactionId
    inner join mstTaxMaster tm on l.taxId = tm.taxId
    inner join tblReceipt r on l.receiptId = r.receiptId
    
    where convert (varchar,w.createdOn,103) >= convert (varchar, @FromDate,103)
    and convert (varchar,w.createdOn, 103) <= convert (varchar,@ToDate, 103)

    group by  r.receiptNo, l.totalAmount, tm.taxName, w.previousReading, w.reading, w.consumption, w.waterConnectionStatusId,
    l.paymentStatusId
    
END