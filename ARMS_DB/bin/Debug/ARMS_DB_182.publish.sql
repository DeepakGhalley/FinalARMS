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
PRINT N'Dropping Default Constraint unnamed constraint on [dbo].[tblDemand]...';


GO
ALTER TABLE [dbo].[tblDemand] DROP CONSTRAINT [DF__tmp_ms_xx__isPay__02333863];


GO
PRINT N'Dropping Default Constraint unnamed constraint on [dbo].[tblLedger]...';


GO
ALTER TABLE [dbo].[tblLedger] DROP CONSTRAINT [DF__tmp_ms_xx__payme__050FA50E];


GO
PRINT N'Dropping Foreign Key [dbo].[FK_tblDemand_ToTable]...';


GO
ALTER TABLE [dbo].[tblDemand] DROP CONSTRAINT [FK_tblDemand_ToTable];


GO
PRINT N'Dropping Foreign Key [dbo].[FK_tblDemand_ToTable_1]...';


GO
ALTER TABLE [dbo].[tblDemand] DROP CONSTRAINT [FK_tblDemand_ToTable_1];


GO
PRINT N'Dropping Foreign Key [dbo].[FK_tblDemand_ToTable_10]...';


GO
ALTER TABLE [dbo].[tblDemand] DROP CONSTRAINT [FK_tblDemand_ToTable_10];


GO
PRINT N'Dropping Foreign Key [dbo].[FK_tblDemand_ToTable_11]...';


GO
ALTER TABLE [dbo].[tblDemand] DROP CONSTRAINT [FK_tblDemand_ToTable_11];


GO
PRINT N'Dropping Foreign Key [dbo].[FK_tblDemand_ToTable_12]...';


GO
ALTER TABLE [dbo].[tblDemand] DROP CONSTRAINT [FK_tblDemand_ToTable_12];


GO
PRINT N'Dropping Foreign Key [dbo].[FK_tblDemand_ToTable_2]...';


GO
ALTER TABLE [dbo].[tblDemand] DROP CONSTRAINT [FK_tblDemand_ToTable_2];


GO
PRINT N'Dropping Foreign Key [dbo].[FK_tblDemand_ToTable_3]...';


GO
ALTER TABLE [dbo].[tblDemand] DROP CONSTRAINT [FK_tblDemand_ToTable_3];


GO
PRINT N'Dropping Foreign Key [dbo].[FK_tblDemand_ToTable_4]...';


GO
ALTER TABLE [dbo].[tblDemand] DROP CONSTRAINT [FK_tblDemand_ToTable_4];


GO
PRINT N'Dropping Foreign Key [dbo].[FK_tblDemand_ToTable_6]...';


GO
ALTER TABLE [dbo].[tblDemand] DROP CONSTRAINT [FK_tblDemand_ToTable_6];


GO
PRINT N'Dropping Foreign Key [dbo].[FK_tblDemand_ToTable_7]...';


GO
ALTER TABLE [dbo].[tblDemand] DROP CONSTRAINT [FK_tblDemand_ToTable_7];


GO
PRINT N'Dropping Foreign Key [dbo].[FK_tblDemand_ToTable_8]...';


GO
ALTER TABLE [dbo].[tblDemand] DROP CONSTRAINT [FK_tblDemand_ToTable_8];


GO
PRINT N'Dropping Foreign Key [dbo].[FK_tblDemand_ToTable_9]...';


GO
ALTER TABLE [dbo].[tblDemand] DROP CONSTRAINT [FK_tblDemand_ToTable_9];


GO
PRINT N'Dropping Foreign Key [dbo].[FK_tblDemand_ToTable_13]...';


GO
ALTER TABLE [dbo].[tblDemand] DROP CONSTRAINT [FK_tblDemand_ToTable_13];


GO
PRINT N'Dropping Foreign Key [dbo].[FK_tblDemand_ToTable_5]...';


GO
ALTER TABLE [dbo].[tblDemand] DROP CONSTRAINT [FK_tblDemand_ToTable_5];


GO
PRINT N'Dropping Foreign Key [dbo].[FK_tblLedger_ToTable]...';


GO
ALTER TABLE [dbo].[tblLedger] DROP CONSTRAINT [FK_tblLedger_ToTable];


GO
PRINT N'Dropping Foreign Key [dbo].[FK_tblLedger_ToTable_7]...';


GO
ALTER TABLE [dbo].[tblLedger] DROP CONSTRAINT [FK_tblLedger_ToTable_7];


GO
PRINT N'Dropping Foreign Key [dbo].[FK_tblLedger_ToTable_8]...';


GO
ALTER TABLE [dbo].[tblLedger] DROP CONSTRAINT [FK_tblLedger_ToTable_8];


GO
PRINT N'Dropping Foreign Key [dbo].[FK_tblLedger_ToTable_9]...';


GO
ALTER TABLE [dbo].[tblLedger] DROP CONSTRAINT [FK_tblLedger_ToTable_9];


GO
PRINT N'Dropping Foreign Key [dbo].[FK_tblLedger_ToTable_0]...';


GO
ALTER TABLE [dbo].[tblLedger] DROP CONSTRAINT [FK_tblLedger_ToTable_0];


GO
PRINT N'Dropping Foreign Key [dbo].[FK_tblLedger_ToTable_1]...';


GO
ALTER TABLE [dbo].[tblLedger] DROP CONSTRAINT [FK_tblLedger_ToTable_1];


GO
PRINT N'Dropping Foreign Key [dbo].[FK_tblLedger_ToTable_10]...';


GO
ALTER TABLE [dbo].[tblLedger] DROP CONSTRAINT [FK_tblLedger_ToTable_10];


GO
PRINT N'Dropping Foreign Key [dbo].[FK_tblLedger_ToTable_11]...';


GO
ALTER TABLE [dbo].[tblLedger] DROP CONSTRAINT [FK_tblLedger_ToTable_11];


GO
PRINT N'Dropping Foreign Key [dbo].[FK_tblLedger_ToTable_2]...';


GO
ALTER TABLE [dbo].[tblLedger] DROP CONSTRAINT [FK_tblLedger_ToTable_2];


GO
PRINT N'Dropping Foreign Key [dbo].[FK_tblLedger_ToTable_3]...';


GO
ALTER TABLE [dbo].[tblLedger] DROP CONSTRAINT [FK_tblLedger_ToTable_3];


GO
PRINT N'Dropping Foreign Key [dbo].[FK_tblLedger_ToTable_4]...';


GO
ALTER TABLE [dbo].[tblLedger] DROP CONSTRAINT [FK_tblLedger_ToTable_4];


GO
PRINT N'Dropping Foreign Key [dbo].[FK_tblLedger_ToTable_5]...';


GO
ALTER TABLE [dbo].[tblLedger] DROP CONSTRAINT [FK_tblLedger_ToTable_5];


GO
PRINT N'Dropping Foreign Key [dbo].[FK_tblLedger_ToTable_6]...';


GO
ALTER TABLE [dbo].[tblLedger] DROP CONSTRAINT [FK_tblLedger_ToTable_6];


GO
PRINT N'Dropping Foreign Key [dbo].[FK_tblLedger_ToTable_13]...';


GO
ALTER TABLE [dbo].[tblLedger] DROP CONSTRAINT [FK_tblLedger_ToTable_13];


GO
PRINT N'Dropping Foreign Key [dbo].[FK_tblLedger_ToTable_14]...';


GO
ALTER TABLE [dbo].[tblLedger] DROP CONSTRAINT [FK_tblLedger_ToTable_14];


GO
PRINT N'Dropping Foreign Key [dbo].[FK_tblLedger_ToTable_12]...';


GO
ALTER TABLE [dbo].[tblLedger] DROP CONSTRAINT [FK_tblLedger_ToTable_12];


GO
PRINT N'Starting rebuilding table [dbo].[tblDemand]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_tblDemand] (
    [demandId]                BIGINT          IDENTITY (1, 1) NOT NULL,
    [transactionId]           BIGINT          NOT NULL,
    [demandNoId]              BIGINT          NOT NULL,
    [taxId]                   INT             NOT NULL,
    [financialYearId]         INT             NOT NULL,
    [calendarYearId]          INT             NOT NULL,
    [demandAmount]            DECIMAL (18, 2) NOT NULL,
    [exemptionAmount]         DECIMAL (18, 2) NULL,
    [exemptionLetter]         VARCHAR (150)   NULL,
    [totalAmount]             DECIMAL (18, 2) NOT NULL,
    [landDetailId]            INT             NULL,
    [taxPayerId]              INT             NULL,
    [landOwnershipId]         INT             NULL,
    [buildingUnitDetailId]    INT             NULL,
    [createdBy]               INT             NOT NULL,
    [createdOn]               DATETIME        NOT NULL,
    [modifiedBy]              INT             NULL,
    [modifiedOn]              DATETIME        NULL,
    [waterMeterReadingId]     BIGINT          NULL,
    [applicantId]             INT             NULL,
    [ecRenewalId]             INT             NULL,
    [landLeaseDemandDetailId] BIGINT          NULL,
    [parkingDemandDetailId]   BIGINT          NULL,
    [stallDemandDetailId]     BIGINT          NULL,
    [houseRentDemandDetailId] BIGINT          NULL,
    [miscellaneousRecordId]   BIGINT          NULL,
    [isPaymentMade]           BIT             DEFAULT 0 NOT NULL,
    [billingDate]             DATETIME        NOT NULL,
    [paymentDate]             DATETIME        NULL,
    [g2cApplicationNo]        VARCHAR (300)   NULL,
    PRIMARY KEY CLUSTERED ([demandId] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[tblDemand])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_tblDemand] ON;
        INSERT INTO [dbo].[tmp_ms_xx_tblDemand] ([demandId], [transactionId], [demandNoId], [taxId], [financialYearId], [calendarYearId], [demandAmount], [exemptionAmount], [exemptionLetter], [totalAmount], [landDetailId], [taxPayerId], [landOwnershipId], [buildingUnitDetailId], [createdBy], [createdOn], [modifiedBy], [modifiedOn], [applicantId], [ecRenewalId], [landLeaseDemandDetailId], [parkingDemandDetailId], [stallDemandDetailId], [houseRentDemandDetailId], [miscellaneousRecordId], [isPaymentMade], [billingDate], [paymentDate], [g2cApplicationNo])
        SELECT   [demandId],
                 [transactionId],
                 [demandNoId],
                 [taxId],
                 [financialYearId],
                 [calendarYearId],
                 [demandAmount],
                 [exemptionAmount],
                 [exemptionLetter],
                 [totalAmount],
                 [landDetailId],
                 [taxPayerId],
                 [landOwnershipId],
                 [buildingUnitDetailId],
                 [createdBy],
                 [createdOn],
                 [modifiedBy],
                 [modifiedOn],
                 [applicantId],
                 [ecRenewalId],
                 [landLeaseDemandDetailId],
                 [parkingDemandDetailId],
                 [stallDemandDetailId],
                 [houseRentDemandDetailId],
                 [miscellaneousRecordId],
                 [isPaymentMade],
                 [billingDate],
                 [paymentDate],
                 [g2cApplicationNo]
        FROM     [dbo].[tblDemand]
        ORDER BY [demandId] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_tblDemand] OFF;
    END

DROP TABLE [dbo].[tblDemand];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_tblDemand]', N'tblDemand';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Starting rebuilding table [dbo].[tblLedger]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_tblLedger] (
    [ledgerId]                BIGINT          IDENTITY (1, 1) NOT NULL,
    [demandId]                BIGINT          NOT NULL,
    [transactionId]           BIGINT          NOT NULL,
    [taxId]                   INT             NOT NULL,
    [financialYearId]         INT             NOT NULL,
    [calendarYearId]          INT             NOT NULL,
    [landDetailId]            INT             NULL,
    [landOwnershipId]         INT             NULL,
    [buildingUnitDetailId]    INT             NULL,
    [taxPayerId]              INT             NULL,
    [totalAmount]             DECIMAL (18, 2) NOT NULL,
    [paymentDate]             DATETIME        NOT NULL,
    [receiptId]               BIGINT          NOT NULL,
    [reconciledOn]            DATETIME        NULL,
    [createdBy]               INT             NOT NULL,
    [createdOn]               DATETIME        NOT NULL,
    [modifiedBy]              INT             NULL,
    [modifiedOn]              DATETIME        NULL,
    [waterMeterReadingId]     BIGINT          NULL,
    [applicantId]             INT             NULL,
    [ecRenewalId]             INT             NULL,
    [landLeaseDemandDetailId] BIGINT          NULL,
    [parkingDemandDetailId]   BIGINT          NULL,
    [stallDemandDetailId]     BIGINT          NULL,
    [houseRentDemandDetailId] BIGINT          NULL,
    [miscellaneousRecordId]   BIGINT          NULL,
    [penaltyAmount]           DECIMAL (18, 2) NOT NULL,
    [penaltyPeriod]           INT             NOT NULL,
    [paymentStatusId]         INT             DEFAULT 1 NULL,
    PRIMARY KEY CLUSTERED ([ledgerId] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[tblLedger])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_tblLedger] ON;
        INSERT INTO [dbo].[tmp_ms_xx_tblLedger] ([ledgerId], [demandId], [transactionId], [taxId], [financialYearId], [calendarYearId], [landDetailId], [landOwnershipId], [buildingUnitDetailId], [taxPayerId], [totalAmount], [paymentDate], [receiptId], [reconciledOn], [createdBy], [createdOn], [modifiedBy], [modifiedOn], [applicantId], [ecRenewalId], [landLeaseDemandDetailId], [parkingDemandDetailId], [stallDemandDetailId], [houseRentDemandDetailId], [miscellaneousRecordId], [penaltyAmount], [penaltyPeriod], [paymentStatusId])
        SELECT   [ledgerId],
                 [demandId],
                 [transactionId],
                 [taxId],
                 [financialYearId],
                 [calendarYearId],
                 [landDetailId],
                 [landOwnershipId],
                 [buildingUnitDetailId],
                 [taxPayerId],
                 [totalAmount],
                 [paymentDate],
                 [receiptId],
                 [reconciledOn],
                 [createdBy],
                 [createdOn],
                 [modifiedBy],
                 [modifiedOn],
                 [applicantId],
                 [ecRenewalId],
                 [landLeaseDemandDetailId],
                 [parkingDemandDetailId],
                 [stallDemandDetailId],
                 [houseRentDemandDetailId],
                 [miscellaneousRecordId],
                 [penaltyAmount],
                 [penaltyPeriod],
                 [paymentStatusId]
        FROM     [dbo].[tblLedger]
        ORDER BY [ledgerId] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_tblLedger] OFF;
    END

DROP TABLE [dbo].[tblLedger];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_tblLedger]', N'tblLedger';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Creating Foreign Key [dbo].[FK_tblDemand_ToTable]...';


GO
ALTER TABLE [dbo].[tblDemand] WITH NOCHECK
    ADD CONSTRAINT [FK_tblDemand_ToTable] FOREIGN KEY ([demandNoId]) REFERENCES [dbo].[tblDemandNo] ([demandNoId]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_tblDemand_ToTable_1]...';


GO
ALTER TABLE [dbo].[tblDemand] WITH NOCHECK
    ADD CONSTRAINT [FK_tblDemand_ToTable_1] FOREIGN KEY ([calendarYearId]) REFERENCES [dbo].[mstCalendarYear] ([calendarYearId]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_tblDemand_ToTable_10]...';


GO
ALTER TABLE [dbo].[tblDemand] WITH NOCHECK
    ADD CONSTRAINT [FK_tblDemand_ToTable_10] FOREIGN KEY ([stallDemandDetailId]) REFERENCES [dbo].[tblStallDetailDemand] ([stallDemandDetailId]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_tblDemand_ToTable_11]...';


GO
ALTER TABLE [dbo].[tblDemand] WITH NOCHECK
    ADD CONSTRAINT [FK_tblDemand_ToTable_11] FOREIGN KEY ([houseRentDemandDetailId]) REFERENCES [dbo].[tblHouseRentDemandDetail] ([houseRentDemandDetailId]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_tblDemand_ToTable_12]...';


GO
ALTER TABLE [dbo].[tblDemand] WITH NOCHECK
    ADD CONSTRAINT [FK_tblDemand_ToTable_12] FOREIGN KEY ([miscellaneousRecordId]) REFERENCES [dbo].[tblMiscellaneousRecord] ([miscellaneousRecordId]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_tblDemand_ToTable_2]...';


GO
ALTER TABLE [dbo].[tblDemand] WITH NOCHECK
    ADD CONSTRAINT [FK_tblDemand_ToTable_2] FOREIGN KEY ([financialYearId]) REFERENCES [dbo].[mstFinancialYear] ([financialYearId]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_tblDemand_ToTable_3]...';


GO
ALTER TABLE [dbo].[tblDemand] WITH NOCHECK
    ADD CONSTRAINT [FK_tblDemand_ToTable_3] FOREIGN KEY ([taxId]) REFERENCES [dbo].[mstTaxMaster] ([taxId]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_tblDemand_ToTable_4]...';


GO
ALTER TABLE [dbo].[tblDemand] WITH NOCHECK
    ADD CONSTRAINT [FK_tblDemand_ToTable_4] FOREIGN KEY ([transactionId]) REFERENCES [dbo].[tblTransactionDetail] ([transactionId]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_tblDemand_ToTable_6]...';


GO
ALTER TABLE [dbo].[tblDemand] WITH NOCHECK
    ADD CONSTRAINT [FK_tblDemand_ToTable_6] FOREIGN KEY ([applicantId]) REFERENCES [dbo].[mstECApplicantdetail] ([applicantId]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_tblDemand_ToTable_7]...';


GO
ALTER TABLE [dbo].[tblDemand] WITH NOCHECK
    ADD CONSTRAINT [FK_tblDemand_ToTable_7] FOREIGN KEY ([ecRenewalId]) REFERENCES [dbo].[tblECRenewalDetail] ([ecRenewalId]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_tblDemand_ToTable_8]...';


GO
ALTER TABLE [dbo].[tblDemand] WITH NOCHECK
    ADD CONSTRAINT [FK_tblDemand_ToTable_8] FOREIGN KEY ([landLeaseDemandDetailId]) REFERENCES [dbo].[tblLandLeaseDemandDetail] ([landLeaseDemandDetailId]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_tblDemand_ToTable_9]...';


GO
ALTER TABLE [dbo].[tblDemand] WITH NOCHECK
    ADD CONSTRAINT [FK_tblDemand_ToTable_9] FOREIGN KEY ([parkingDemandDetailId]) REFERENCES [dbo].[tblParkingFeeDemandDetail] ([parkingDemandDetailId]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_tblDemand_ToTable_13]...';


GO
ALTER TABLE [dbo].[tblDemand] WITH NOCHECK
    ADD CONSTRAINT [FK_tblDemand_ToTable_13] FOREIGN KEY ([buildingUnitDetailId]) REFERENCES [dbo].[mstBuildingUnitDetail] ([buildingUnitDetailId]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_tblDemand_ToTable_5]...';


GO
ALTER TABLE [dbo].[tblDemand] WITH NOCHECK
    ADD CONSTRAINT [FK_tblDemand_ToTable_5] FOREIGN KEY ([landOwnershipId]) REFERENCES [dbo].[tblLandOwnershipDetail] ([landOwnershipId]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_tblLedger_ToTable]...';


GO
ALTER TABLE [dbo].[tblLedger] WITH NOCHECK
    ADD CONSTRAINT [FK_tblLedger_ToTable] FOREIGN KEY ([demandId]) REFERENCES [dbo].[tblDemand] ([demandId]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_tblDemand_ToTable_14]...';


GO
ALTER TABLE [dbo].[tblDemand] WITH NOCHECK
    ADD CONSTRAINT [FK_tblDemand_ToTable_14] FOREIGN KEY ([waterMeterReadingId]) REFERENCES [dbo].[tblWaterMeterReading] ([waterMeterReadingId]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_tblLedger_ToTable_7]...';


GO
ALTER TABLE [dbo].[tblLedger] WITH NOCHECK
    ADD CONSTRAINT [FK_tblLedger_ToTable_7] FOREIGN KEY ([financialYearId]) REFERENCES [dbo].[mstFinancialYear] ([financialYearId]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_tblLedger_ToTable_8]...';


GO
ALTER TABLE [dbo].[tblLedger] WITH NOCHECK
    ADD CONSTRAINT [FK_tblLedger_ToTable_8] FOREIGN KEY ([calendarYearId]) REFERENCES [dbo].[mstCalendarYear] ([calendarYearId]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_tblLedger_ToTable_9]...';


GO
ALTER TABLE [dbo].[tblLedger] WITH NOCHECK
    ADD CONSTRAINT [FK_tblLedger_ToTable_9] FOREIGN KEY ([miscellaneousRecordId]) REFERENCES [dbo].[tblMiscellaneousRecord] ([miscellaneousRecordId]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_tblLedger_ToTable_0]...';


GO
ALTER TABLE [dbo].[tblLedger] WITH NOCHECK
    ADD CONSTRAINT [FK_tblLedger_ToTable_0] FOREIGN KEY ([taxId]) REFERENCES [dbo].[mstTaxMaster] ([taxId]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_tblLedger_ToTable_1]...';


GO
ALTER TABLE [dbo].[tblLedger] WITH NOCHECK
    ADD CONSTRAINT [FK_tblLedger_ToTable_1] FOREIGN KEY ([applicantId]) REFERENCES [dbo].[mstECApplicantdetail] ([applicantId]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_tblLedger_ToTable_10]...';


GO
ALTER TABLE [dbo].[tblLedger] WITH NOCHECK
    ADD CONSTRAINT [FK_tblLedger_ToTable_10] FOREIGN KEY ([transactionId]) REFERENCES [dbo].[tblTransactionDetail] ([transactionId]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_tblLedger_ToTable_11]...';


GO
ALTER TABLE [dbo].[tblLedger] WITH NOCHECK
    ADD CONSTRAINT [FK_tblLedger_ToTable_11] FOREIGN KEY ([receiptId]) REFERENCES [dbo].[tblReceipt] ([receiptId]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_tblLedger_ToTable_2]...';


GO
ALTER TABLE [dbo].[tblLedger] WITH NOCHECK
    ADD CONSTRAINT [FK_tblLedger_ToTable_2] FOREIGN KEY ([ecRenewalId]) REFERENCES [dbo].[tblECRenewalDetail] ([ecRenewalId]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_tblLedger_ToTable_3]...';


GO
ALTER TABLE [dbo].[tblLedger] WITH NOCHECK
    ADD CONSTRAINT [FK_tblLedger_ToTable_3] FOREIGN KEY ([landLeaseDemandDetailId]) REFERENCES [dbo].[tblLandLeaseDemandDetail] ([landLeaseDemandDetailId]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_tblLedger_ToTable_4]...';


GO
ALTER TABLE [dbo].[tblLedger] WITH NOCHECK
    ADD CONSTRAINT [FK_tblLedger_ToTable_4] FOREIGN KEY ([parkingDemandDetailId]) REFERENCES [dbo].[tblParkingFeeDemandDetail] ([parkingDemandDetailId]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_tblLedger_ToTable_5]...';


GO
ALTER TABLE [dbo].[tblLedger] WITH NOCHECK
    ADD CONSTRAINT [FK_tblLedger_ToTable_5] FOREIGN KEY ([stallDemandDetailId]) REFERENCES [dbo].[tblStallDetailDemand] ([stallDemandDetailId]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_tblLedger_ToTable_6]...';


GO
ALTER TABLE [dbo].[tblLedger] WITH NOCHECK
    ADD CONSTRAINT [FK_tblLedger_ToTable_6] FOREIGN KEY ([houseRentDemandDetailId]) REFERENCES [dbo].[tblHouseRentDemandDetail] ([houseRentDemandDetailId]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_tblLedger_ToTable_13]...';


GO
ALTER TABLE [dbo].[tblLedger] WITH NOCHECK
    ADD CONSTRAINT [FK_tblLedger_ToTable_13] FOREIGN KEY ([paymentStatusId]) REFERENCES [dbo].[enumPaymentStatus] ([paymentStatusId]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_tblLedger_ToTable_14]...';


GO
ALTER TABLE [dbo].[tblLedger] WITH NOCHECK
    ADD CONSTRAINT [FK_tblLedger_ToTable_14] FOREIGN KEY ([buildingUnitDetailId]) REFERENCES [dbo].[mstBuildingUnitDetail] ([buildingUnitDetailId]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_tblLedger_ToTable_12]...';


GO
ALTER TABLE [dbo].[tblLedger] WITH NOCHECK
    ADD CONSTRAINT [FK_tblLedger_ToTable_12] FOREIGN KEY ([landOwnershipId]) REFERENCES [dbo].[tblLandOwnershipDetail] ([landOwnershipId]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_tblLedger_ToTable_15]...';


GO
ALTER TABLE [dbo].[tblLedger] WITH NOCHECK
    ADD CONSTRAINT [FK_tblLedger_ToTable_15] FOREIGN KEY ([waterMeterReadingId]) REFERENCES [dbo].[tblWaterMeterReading] ([waterMeterReadingId]);


GO
PRINT N'Altering Procedure [dbo].[rptOnlinePaymentByFromDateToDate]...';


GO
ALTER PROCEDURE [dbo].[rptOnlinePaymentByFromDateToDate]
	@FromDate date
	,@ToDate date
AS
 SELECT  ROW_NUMBER() OVER(
 ORDER BY (select 1)) AS Sl
,FORMAT (pl.createdOn, 'dd/MM/yyyy, hh:mm') as PaymentDate
	,r.receiptNo as ReceiptNo
	,isnull(pl.paymentModeNo,'-') as PaymentModeNo
	,isnull(FORMAT (pl.paymentModeDate, 'dd/MM/yyyy'),'-')  as PaymentModeDate
	,isnull(sum(amount),0) as TotalAmount
	,FORMAT (@FromDate, 'dd/MM/yyyy') as FromDate
	,FORMAT (@ToDate, 'dd/MM/yyyy') as ToDate
	   from tblPaymentLeger pl 	  
	   left join tblReceipt r on pl.receiptId=r.receiptId
	  where pl.paymentModeId not in(1,2) and
	  convert (varchar,pl.createdOn, 112)>=convert (varchar,@FromDate, 112) 
	  and  convert (varchar,pl.createdOn, 112)<=convert (varchar,@ToDate, 112) 
	  
group by r.receiptNo,FORMAT (pl.createdOn, 'dd/MM/yyyy, hh:mm')
,pl.paymentModeNo,FORMAT (pl.paymentModeDate, 'dd/MM/yyyy')
order by r.receiptNo,PaymentDate
RETURN 0

-- exec [dbo].[rptOnlinePaymentByFromDateToDate] 20/02/2021
GO
PRINT N'Refreshing Procedure [dbo].[rptDefaulterPropertyList]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[rptDefaulterPropertyList]';


GO
PRINT N'Refreshing Procedure [dbo].[rptDefaulterWaterList]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[rptDefaulterWaterList]';


GO
PRINT N'Refreshing Procedure [dbo].[rptGetDailyHeadWiseDemandCollection]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[rptGetDailyHeadWiseDemandCollection]';


GO
PRINT N'Refreshing Procedure [dbo].[rptMinorHeadWiseCollectionbycalyear]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[rptMinorHeadWiseCollectionbycalyear]';


GO
PRINT N'Refreshing Procedure [dbo].[rptMinorHeadWiseCollectionbytofromdate]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[rptMinorHeadWiseCollectionbytofromdate]';


GO
PRINT N'Refreshing Procedure [dbo].[rptDailyPaymentWiseDemandCollection]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[rptDailyPaymentWiseDemandCollection]';


GO
PRINT N'Refreshing Procedure [dbo].[rptGetYearlyHeadWiseDemandCollection]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[rptGetYearlyHeadWiseDemandCollection]';


GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[tblDemand] WITH CHECK CHECK CONSTRAINT [FK_tblDemand_ToTable];

ALTER TABLE [dbo].[tblDemand] WITH CHECK CHECK CONSTRAINT [FK_tblDemand_ToTable_1];

ALTER TABLE [dbo].[tblDemand] WITH CHECK CHECK CONSTRAINT [FK_tblDemand_ToTable_10];

ALTER TABLE [dbo].[tblDemand] WITH CHECK CHECK CONSTRAINT [FK_tblDemand_ToTable_11];

ALTER TABLE [dbo].[tblDemand] WITH CHECK CHECK CONSTRAINT [FK_tblDemand_ToTable_12];

ALTER TABLE [dbo].[tblDemand] WITH CHECK CHECK CONSTRAINT [FK_tblDemand_ToTable_2];

ALTER TABLE [dbo].[tblDemand] WITH CHECK CHECK CONSTRAINT [FK_tblDemand_ToTable_3];

ALTER TABLE [dbo].[tblDemand] WITH CHECK CHECK CONSTRAINT [FK_tblDemand_ToTable_4];

ALTER TABLE [dbo].[tblDemand] WITH CHECK CHECK CONSTRAINT [FK_tblDemand_ToTable_6];

ALTER TABLE [dbo].[tblDemand] WITH CHECK CHECK CONSTRAINT [FK_tblDemand_ToTable_7];

ALTER TABLE [dbo].[tblDemand] WITH CHECK CHECK CONSTRAINT [FK_tblDemand_ToTable_8];

ALTER TABLE [dbo].[tblDemand] WITH CHECK CHECK CONSTRAINT [FK_tblDemand_ToTable_9];

ALTER TABLE [dbo].[tblDemand] WITH CHECK CHECK CONSTRAINT [FK_tblDemand_ToTable_13];

ALTER TABLE [dbo].[tblDemand] WITH CHECK CHECK CONSTRAINT [FK_tblDemand_ToTable_5];

ALTER TABLE [dbo].[tblLedger] WITH CHECK CHECK CONSTRAINT [FK_tblLedger_ToTable];

ALTER TABLE [dbo].[tblDemand] WITH CHECK CHECK CONSTRAINT [FK_tblDemand_ToTable_14];

ALTER TABLE [dbo].[tblLedger] WITH CHECK CHECK CONSTRAINT [FK_tblLedger_ToTable_7];

ALTER TABLE [dbo].[tblLedger] WITH CHECK CHECK CONSTRAINT [FK_tblLedger_ToTable_8];

ALTER TABLE [dbo].[tblLedger] WITH CHECK CHECK CONSTRAINT [FK_tblLedger_ToTable_9];

ALTER TABLE [dbo].[tblLedger] WITH CHECK CHECK CONSTRAINT [FK_tblLedger_ToTable_0];

ALTER TABLE [dbo].[tblLedger] WITH CHECK CHECK CONSTRAINT [FK_tblLedger_ToTable_1];

ALTER TABLE [dbo].[tblLedger] WITH CHECK CHECK CONSTRAINT [FK_tblLedger_ToTable_10];

ALTER TABLE [dbo].[tblLedger] WITH CHECK CHECK CONSTRAINT [FK_tblLedger_ToTable_11];

ALTER TABLE [dbo].[tblLedger] WITH CHECK CHECK CONSTRAINT [FK_tblLedger_ToTable_2];

ALTER TABLE [dbo].[tblLedger] WITH CHECK CHECK CONSTRAINT [FK_tblLedger_ToTable_3];

ALTER TABLE [dbo].[tblLedger] WITH CHECK CHECK CONSTRAINT [FK_tblLedger_ToTable_4];

ALTER TABLE [dbo].[tblLedger] WITH CHECK CHECK CONSTRAINT [FK_tblLedger_ToTable_5];

ALTER TABLE [dbo].[tblLedger] WITH CHECK CHECK CONSTRAINT [FK_tblLedger_ToTable_6];

ALTER TABLE [dbo].[tblLedger] WITH CHECK CHECK CONSTRAINT [FK_tblLedger_ToTable_13];

ALTER TABLE [dbo].[tblLedger] WITH CHECK CHECK CONSTRAINT [FK_tblLedger_ToTable_14];

ALTER TABLE [dbo].[tblLedger] WITH CHECK CHECK CONSTRAINT [FK_tblLedger_ToTable_12];

ALTER TABLE [dbo].[tblLedger] WITH CHECK CHECK CONSTRAINT [FK_tblLedger_ToTable_15];


GO
PRINT N'Update complete.';


GO