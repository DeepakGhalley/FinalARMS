

--  exec [dbo].[AAAAATRY]  '20220901', '20220930', 1,0 

create PROCEDURE [dbo].[Modewisecollection] 
	@StartDate date, @EndDate date, @PaymentModeId int, @UserId int = Null
	
AS




	if(@UserId = 0)
	begin
Select ROW_NUMBER() over(order by(select 1)) as Sl,pl.receiptId,r.receiptNo,isnull(pl.paymentModeNo,'-') as PaymentModeNo ,
isnull(FORMAT (pl.paymentModeDate, 'dd/MM/yyyy'),'-') as PaymentModeDate,(FORMAT (pl.createdOn, 'dd/MM/yyyy')) as PaymentModeDate
	,pl.amount as TotalAmount
	from tblPaymentLeger pl
    inner join tblReceipt r on pl.receiptId = r.receiptId
	where
FORMAT (pl.createdOn, 'yyyyMMdd') >= FORMAT (@StartDate, 'yyyyMMdd')
and FORMAT (pl.createdOn, 'yyyyMMdd') <= FORMAT (@EndDate, 'yyyyMMdd')	and pl.paymentModeId = @PaymentModeId
end
else
begin 

	Select ROW_NUMBER() over(order by(select 1)) as Sl,pl.receiptId,r.receiptNo,isnull(pl.paymentModeNo,'-') as PaymentModeNo ,
isnull(FORMAT (pl.paymentModeDate, 'dd/MM/yyyy'),'-') as PaymentModeDate,(FORMAT (pl.createdOn, 'dd/MM/yyyy')) as PaymentModeDate
	,pl.amount as TotalAmount
	from tblPaymentLeger pl
    inner join tblReceipt r on pl.receiptId = r.receiptId
	where
FORMAT (pl.createdOn, 'yyyyMMdd') >= FORMAT (@StartDate, 'yyyyMMdd')
and FORMAT (pl.createdOn, 'yyyyMMdd') <= FORMAT (@EndDate, 'yyyyMMdd')	and pl.paymentModeId = @PaymentModeId
and pl.createdBy = @UserId

end