-- exec [dbo].[rptWaterTrabsactionReport] 'z600209', '' , ''

create PROCEDURE [dbo].[rptWaterTrabsactionReport]
@consumerNo varchar(50), @waterMeterNo varchar(50), @transactionTypeId int

AS
BEGIN
SET NOCOUNT ON;

if(@consumerNo = '' and @waterMeterNo = '')
BEGIN

SELECT ROW_NUMBER() over(order by(select 1)) as Sl, tc.waterMeterNo, tc.consumerNo, CONVERT(varchar, tc.applicationDate,103) as applicationDate,ld.plotNo, mt.waterMeterType, case when tc.sewerageConnection = 1 then 'Yes' else 'No' end as SewerageConnection, wcs.waterConnectionStatus,
wct.waterConnectionType, wlt.waterLineType, tc.standardCosumption, tc.billingAddress, tc.flatNo,z.zoneName, tc.initialReading, tc.organisationName, case when tc.isActive = 1 then 'Yes' else 'No' end as isActive, tc.remarks,  CONVERT(varchar, tc.disconnectDate,103) as disConnectionDate,
case when tc.reUse = 1 then 'Yes' else '-' end as reUse, tc.noOfUnits, ot.ownerType, CONVERT(varchar, tc.reconnectionDate,103) as reConnectionDate, CONVERT(varchar, tc.sewarageConnectionDate,103) as sewarageConnectionDate, tc.primaryMobileNo, tc.g2cApplicationNo,
case when tc.isPermanentDisconnect = 1 then 'Yes' else '-' end as PermanentDisconnect, ast.approvalStatus, CONVERT(varchar, tc.readingDate,103) as readingDate, CONVERT(varchar, tc.previousReadingDate,103) as previousReadingDate, tc.previousReading,
case when tc.isPermanent = 1 then 'Yes' else 'No' end as isPermanent, mstwc.waterConnectionId as OldWaterConnectionId, td.transactionValue, CONVERT(varchar, td.createdOn,103) as TransactionDate, tt.transactionType

from  trnWaterConnection tc
left join mstLandDetail ld on tc.landDetailId = ld.landDetailId
left join mstWaterMeterType mt on tc.waterMeterTypeId = mt.waterMeterTypeId
left join enumWaterConnectionStatus wcs on tc.waterConnectionStatusId = wcs.waterConnectionStatusId
left join mstWaterConnectionType wct on tc.waterConnectionTypeId = wct.waterConnectionTypeId
left join mstWaterLineType wlt on tc.waterLineTypeId = wlt.waterLineTypeId
left join mstZone z on tc.zoneId = z.zoneId
left join enumOwnerType ot on tc.ownerTypeId = ot.ownerTypeId
left join enumApprovalStatus ast on tc.approvalStatusId = ast.approvalStatusId
left join mstWaterConnection mstwc on tc.oldWaterConnectionId = mstwc.waterConnectionId
left join  tblTransactionDetail td on tc.transactionId = td.transactionId
left join mstTransactionType tt on td.transactionTypeId = tt.transactionTypeId
where td.transactionTypeId = @transactionTypeId
end

else if(@transactionTypeId = '' and @waterMeterNo = '')
BEGIN

SELECT ROW_NUMBER() over(order by(select 1)) as Sl, tc.waterMeterNo, tc.consumerNo, CONVERT(varchar, tc.applicationDate,103) as applicationDate,ld.plotNo, mt.waterMeterType, case when tc.sewerageConnection = 1 then 'Yes' else 'No' end as SewerageConnection, wcs.waterConnectionStatus,
wct.waterConnectionType, wlt.waterLineType, tc.standardCosumption, tc.billingAddress, tc.flatNo,z.zoneName, tc.initialReading, tc.organisationName, case when tc.isActive = 1 then 'Yes' else 'No' end as isActive, tc.remarks,  CONVERT(varchar, tc.disconnectDate,103) as disConnectionDate,
case when tc.reUse = 1 then 'Yes' else '-' end as reUse, tc.noOfUnits, ot.ownerType, CONVERT(varchar, tc.reconnectionDate,103) as reConnectionDate, CONVERT(varchar, tc.sewarageConnectionDate,103) as sewarageConnectionDate, tc.primaryMobileNo, tc.g2cApplicationNo,
case when tc.isPermanentDisconnect = 1 then 'Yes' else '-' end as PermanentDisconnect, ast.approvalStatus, CONVERT(varchar, tc.readingDate,103) as readingDate, CONVERT(varchar, tc.previousReadingDate,103) as previousReadingDate, tc.previousReading,
case when tc.isPermanent = 1 then 'Yes' else 'No' end as isPermanent, mstwc.waterConnectionId as OldWaterConnectionId, td.transactionValue, CONVERT(varchar, td.createdOn,103) as TransactionDate, tt.transactionType

from  trnWaterConnection tc
left join mstLandDetail ld on tc.landDetailId = ld.landDetailId
left join mstWaterMeterType mt on tc.waterMeterTypeId = mt.waterMeterTypeId
left join enumWaterConnectionStatus wcs on tc.waterConnectionStatusId = wcs.waterConnectionStatusId
left join mstWaterConnectionType wct on tc.waterConnectionTypeId = wct.waterConnectionTypeId
left join mstWaterLineType wlt on tc.waterLineTypeId = wlt.waterLineTypeId
left join mstZone z on tc.zoneId = z.zoneId
left join enumOwnerType ot on tc.ownerTypeId = ot.ownerTypeId
left join enumApprovalStatus ast on tc.approvalStatusId = ast.approvalStatusId
left join mstWaterConnection mstwc on tc.oldWaterConnectionId = mstwc.waterConnectionId
left join  tblTransactionDetail td on tc.transactionId = td.transactionId
left join mstTransactionType tt on td.transactionTypeId = tt.transactionTypeId
where tc.consumerNo = @consumerNo
end

else
BEGIN

SELECT ROW_NUMBER() over(order by(select 1)) as Sl, tc.waterMeterNo, tc.consumerNo, CONVERT(varchar, tc.applicationDate,103) as applicationDate,ld.plotNo, mt.waterMeterType, case when tc.sewerageConnection = 1 then 'Yes' else 'No' end as SewerageConnection, wcs.waterConnectionStatus,
wct.waterConnectionType, wlt.waterLineType, tc.standardCosumption, tc.billingAddress, tc.flatNo,z.zoneName, tc.initialReading, tc.organisationName, case when tc.isActive = 1 then 'Yes' else 'No' end as isActive, tc.remarks,  CONVERT(varchar, tc.disconnectDate,103) as disConnectionDate,
case when tc.reUse = 1 then 'Yes' else '-' end as reUse, tc.noOfUnits, ot.ownerType, CONVERT(varchar, tc.reconnectionDate,103) as reConnectionDate, CONVERT(varchar, tc.sewarageConnectionDate,103) as sewarageConnectionDate, tc.primaryMobileNo, tc.g2cApplicationNo,
case when tc.isPermanentDisconnect = 1 then 'Yes' else '-' end as PermanentDisconnect, ast.approvalStatus, CONVERT(varchar, tc.readingDate,103) as readingDate, CONVERT(varchar, tc.previousReadingDate,103) as previousReadingDate, tc.previousReading,
case when tc.isPermanent = 1 then 'Yes' else 'No' end as isPermanent, mstwc.waterConnectionId as OldWaterConnectionId, td.transactionValue, CONVERT(varchar, td.createdOn,103) as TransactionDate, tt.transactionType

from  trnWaterConnection tc
left join mstLandDetail ld on tc.landDetailId = ld.landDetailId
left join mstWaterMeterType mt on tc.waterMeterTypeId = mt.waterMeterTypeId
left join enumWaterConnectionStatus wcs on tc.waterConnectionStatusId = wcs.waterConnectionStatusId
left join mstWaterConnectionType wct on tc.waterConnectionTypeId = wct.waterConnectionTypeId
left join mstWaterLineType wlt on tc.waterLineTypeId = wlt.waterLineTypeId
left join mstZone z on tc.zoneId = z.zoneId
left join enumOwnerType ot on tc.ownerTypeId = ot.ownerTypeId
left join enumApprovalStatus ast on tc.approvalStatusId = ast.approvalStatusId
left join mstWaterConnection mstwc on tc.oldWaterConnectionId = mstwc.waterConnectionId
left join  tblTransactionDetail td on tc.transactionId = td.transactionId
left join mstTransactionType tt on td.transactionTypeId = tt.transactionTypeId
where tc.waterMeterNo = @waterMeterNo
end
end

RETURN 0
