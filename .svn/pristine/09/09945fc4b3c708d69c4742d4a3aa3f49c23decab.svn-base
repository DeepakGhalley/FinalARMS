CREATE VIEW [dbo].[View_ReadingSeet]
	AS 


select t1.[waterMeterReadingId]
      ,t1.[waterConnectionId]
      ,t1.[transactionId]
      ,t1.[waterConnectionTypeId]
      ,t1.[waterMeterTypeId]
      ,t1.[waterLineTypeId]
      ,t1.[waterConnectionStatusId]
      ,t1.[bucid]
      ,t1.[zoneId]
      ,t1.[reading]
      ,t1.[isRead]
      ,t1.[readingDate]
      ,t1.[previousReading]
      ,t1.[previousReadingDate]
      ,t1.[readBy]
      ,t1.[noOfUnit]
      ,t1.[consumption]
      ,t1.[standardConsumption]
      ,t1.[isPermanentConnection]
      ,t1.[sewerage]
      ,t1.[solidWaste]
      ,t1.[remarks]
      ,t1.[flatNo]
      ,t1.[billingAddress]
      ,t1.[primaryMobileNo]
      ,t1.[secondaryMobileNo]
      ,t1.[isActive]
      ,t1.[isDisconnected]
      ,t1.[createdOn]
      ,t1.[createdBy]
      ,t1.[modifiedOn]
      ,t1.[modifiedBy]
      ,format(t1.readingDate,'yyyyMM') ReadingYM
      ,c.consumerNo
      ,c.waterMeterNo
from tblWaterMeterReading t1
left join mstWaterConnection c on t1.waterConnectionId=c.waterConnectionId
where c.isActive=1 and t1.isRead =0 and t1.readingDate in (
select max(t2.readingDate) from tblWaterMeterReading t2
where t2.waterConnectionId=t1.waterConnectionId)

-- and t1.zoneId = 1
--order by c.consumerNo


