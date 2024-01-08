
create PROCEDURE [dbo].[rptOnlinepaymentreconciliations]
	@StartDate date, @EndDate date
AS

 --	EXEC  [dbo].[rptOnlinepaymentreconciliations] '07-12-2021','12-12-2021'
begin

SELECT ROW_NUMBER() over(order by(select 1)) as sl, 
	t.bfs_orderNo,ty.transactionType,t.bfs_txnAmount,t.createdOn,tp.FirstName+' '+ISNULL(tp.MiddleName,'')+' '+ISNULL(tp.LastName,'') as Names,
	tp.ttin,tp.cid
	,isnull(l.plotNo ,'-') as PlotNo
	,isnull(l.thramNo  ,'-') as ThramNo
	,isnull(wc.waterMeterNo ,'-') as WaterMeterNo
	,isnull(wc.consumerNo,'-') as ConsumerNo
from tblBfsTransactiondetails t

	inner join tblDemand as d on t.bfsTransactionDetailId = d.bfsTransactionDetailId
	inner join tblTransactionDetail as td on d.transactionId = td.transactionId
	inner join mstTransactionType as ty on td.transactionTypeId = ty.transactionTypeId
	inner join mstTaxPayerProfile as tp on d.taxPayerId = tp.taxPayerId
	inner join tblWaterMeterReading as w on d.waterMeterReadingId = w.waterMeterReadingId
	inner join mstWaterConnection as wc on w.waterConnectionId = wc.waterConnectionId
	inner join mstLandDetail as l on d.landDetailId = l.landDetailId

where d.isPaymentMade = 1  
	and	FORMAT (t.createdOn, 'dd/MM/yyyy') >= FORMAT (@StartDate, 'dd/MM/yyyy') 
	and FORMAT (t.createdOn, 'dd/MM/yyyy') <= FORMAT (@EndDate, 'dd/MM/yyyy') 

group by ty.transactionType,t.bfs_orderNo,t.bfs_txnAmount,t.createdOn,tp.firstName,tp.middleName,tp.lastName,
		tp.ttin,tp.cid,wc.consumerNo,wc.waterMeterNo ,l.thramNo,l.plotNo 

end