
-- exec [dbo].[rptMissedOutReadingReport] 

CREATE PROCEDURE [dbo].[rptMissedOutReadingReport]

AS
begin
set nocount on;

SELECT  ROW_NUMBER() OVER(
ORDER BY (select 1)) AS Sl,* from(
select 
wc.consumerNo as ConsumerNo,wc.waterMeterNo as MeterNo,  FORMAT (wc.connectionDate, 'dd/MM/yyyy') as connectionDate,wmr.isActive as ActiveStatus,wl.waterLineType as LineType,
wct.waterConnectionType as ConnectionType,wcs.waterConnectionStatus as ConnectionStatus,wmr.flatNo as FlatNo,wmr.billingAddress as BillingAddress
from tblWaterMeterReading wmr
inner join mstWaterConnection wc on wmr.waterConnectionId = wc.waterConnectionId
inner join mstWaterLineType wl on wmr.waterLineTypeId = wl.waterLineTypeId
inner join mstWaterConnectionType wct on wmr.waterConnectionTypeId = wct.waterConnectionTypeId 
inner join enumWaterConnectionStatus wcs on wmr.waterConnectionStatusId = wcs.waterConnectionStatusId
where wmr.isRead = 0 
--and 
--wmr.transactionId is null and Format(wmr.readingDate,'yyyyMM')+'01' = Format(DATEADD(month, -1, @ReadingMonth),'yyyyMM')+'01' 
) gg
end