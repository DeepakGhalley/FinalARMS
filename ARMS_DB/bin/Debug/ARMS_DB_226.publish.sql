﻿/*
Deployment script for tt_db

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "tt_db"
:setvar DefaultFilePrefix "tt_db"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL15.REVENUE\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL15.REVENUE\MSSQL\DATA\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
PRINT N'Altering Procedure [dbo].[rptDailyPaymentWiseDemandCollection]...';


GO


--exec [dbo].[rptDailyPaymentWiseDemandCollection] '20210424', '20210430'
ALTER PROCEDURE [dbo].[rptDailyPaymentWiseDemandCollection] 
@StartDate date, @EndDate date
AS
BEGIN
	SET NOCOUNT ON;	
	SELECT ROW_NUMBER() over(order by(select 1)) as Sl, CONVERT(varchar, pl.createdOn,103) as PaymentDate, pm.paymentMode as PaymentMode, SUM(pl.amount) as SubTotal
	from tblLedger l 

	inner join tblPaymentLeger pl on l.receiptId = pl.receiptId
	inner join enumPaymentMode pm on pl.paymentModeId = pm.paymentModeId
	where 		FORMAT (pl.createdOn, 'yyyyMMdd') >= FORMAT (@StartDate, 'yyyyMMdd') 
	and FORMAT (pl.createdOn, 'yyyyMMdd') <= FORMAT (@EndDate, 'yyyyMMdd') 
	group by pm.paymentMode,CONVERT(varchar, pl.createdOn,103)
	select SUM(gt.amount) as GrandTotal from tblPaymentLeger gt

end
GO
PRINT N'Altering Procedure [dbo].[rptGetWaterConsumption]...';


GO


ALTER PROCEDURE [dbo].[rptGetWaterConsumption]
	@zoneId int
AS
--	EXEC [dbo].[rptGetWaterConsumption] '2'

  SELECT ROW_NUMBER() over(order by(select 1)) as sl, w.consumerNo as consumerNo,wc.waterConnectionType as waterConnectionType, 
  w.waterMeterNo as waterMeterNo,  wl.waterLineType as waterLineType,
  CONVERT(varchar, wr.readingDate,103) as readingDate, wr.consumption as consumption
  
   
   from mstWaterConnection w 
   join tblWaterMeterReading wr on w.waterConnectionId = wr.waterConnectionId
   join mstWaterConnectionType wc on w.waterConnectionTypeId = wc.waterConnectionTypeId
   join mstWaterLineType wl on w.waterLineTypeId = wl.waterLineTypeId
   where w.zoneId = @zoneId
RETURN 0
GO
PRINT N'Update complete.';


GO
