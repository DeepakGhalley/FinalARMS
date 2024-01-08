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
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\"

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
PRINT N'Creating Procedure [dbo].[rptDailyPaymentWiseDemandCollection]...';


GO


--exec [dbo].[rptDailyPaymentWiseDemandCollection] '20210424', '20210430'
create PROCEDURE [dbo].[rptDailyPaymentWiseDemandCollection] 
@StartDate int, @EndDate int
AS
BEGIN
	SET NOCOUNT ON;	
	SELECT ROW_NUMBER() over(order by(select 1)) as Sl, CONVERT(varchar, pl.createdOn,103) as PaymentDate, pm.paymentMode as PaymentMode, SUM(pl.amount) as SubTotal
	from tblLedger l 

	inner join tblPaymentLeger pl on l.receiptId = pl.receiptId
	inner join enumPaymentMode pm on pl.paymentModeId = pm.paymentModeId
	where cast(convert(varchar,pl.createdOn,112) as int) >= @StartDate
and cast(convert(varchar,pl.createdOn,112) as int) <=  @EndDate
	group by pm.paymentMode,CONVERT(varchar, pl.createdOn,103)
	select SUM(gt.amount) as GrandTotal from tblPaymentLeger gt

end
GO
PRINT N'Creating Procedure [dbo].[rptGetDailyHeadWiseDemandCollection]...';


GO

create PROCEDURE [dbo].[rptGetDailyHeadWiseDemandCollection] 
	@FinancialYearId int
	
AS
DECLARE @s SMALLDATETIME;


begin

	set nocount on;
	declare @fyr  varchar(20)
	set @fyr=(select FinancialYear from mstFinancialYear where financialYearId=@FinancialYearId);
			select ROW_NUMBER() over(order by(select 1)) as sl,t.taxName as TaxName,sum(l.totalAmount) as TotalAmount, @fyr as FinancialYear
			from tblLedger as l 
			inner join mstTaxMaster as t on l.taxId = t.taxId
			inner join mstFinancialYear as f on l.financialYearId =f.financialYearId
			where l.financialYearId = @FinancialYearId
			group by t.taxName
			 

end
GO
PRINT N'Creating Procedure [dbo].[rptGetYearlyHeadWiseDemandCollection]...';


GO

Create PROCEDURE [dbo].[rptGetYearlyHeadWiseDemandCollection] 
	@StartDate varchar(20), @EndDate varchar(20)
	
AS
DECLARE @s SMALLDATETIME, @e SMALLDATETIME;
set @s=@StartDate

set @e=@EndDate

begin

	set nocount on;

	select ROW_NUMBER() over(order by(select 1)) as sl,CONVERT(varchar,l.paymentDate,103) as PaymentDate, t.taxName as TaxName, l.totalAmount as TotalAmount, l.penaltyAmount as PenaltyAmount, CONVERT(varchar,@s,103) as StartDate, CONVERT(varchar,@e,103)  as EndDate
	
	from tblLedger as l
	inner join tblDemand as d on l.demandId = d.demandId
	inner join mstTaxMaster as t on l.taxId = t.taxId
	where d.isPaymentMade = 1 and l.paymentDate >= @StartDate and l.paymentDate <= @EndDate

end
GO
PRINT N'Update complete.';


GO