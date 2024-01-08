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
/*
The column [dbo].[tblLandLeasePeriod].[startDate] on table [dbo].[tblLandLeasePeriod] must be added, but the column has no default value and does not allow NULL values. If the table contains data, the ALTER script will not work. To avoid this issue you must either: add a default value to the column, mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.
*/

IF EXISTS (select top 1 1 from [dbo].[tblLandLeasePeriod])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
PRINT N'Rename refactoring operation with key 3673680b-6883-4a2b-8244-55720952fcbd is skipped, element [dbo].[tblLandLease].[reason] (SqlSimpleColumn) will not be renamed to terminateReason';


GO
PRINT N'Rename refactoring operation with key 04d53c20-2052-4d12-9558-390300918fd4, 47f87ae4-a606-4ad4-9cc4-4721a4898e17 is skipped, element [dbo].[tblLandLeasePeriod].[startEndDate] (SqlSimpleColumn) will not be renamed to startDate';


GO
PRINT N'Rename refactoring operation with key 2fa69af4-b8e2-4962-8a46-49687dff8355 is skipped, element [dbo].[tblLandLeaseDemandDetail].[Id] (SqlSimpleColumn) will not be renamed to landLeaseDemandDetailId';


GO
PRINT N'Rename refactoring operation with key 0a8723c0-af20-47a2-bcf4-21e3eeb7a761 is skipped, element [dbo].[enumDemandGenerateSchedule].[Id] (SqlSimpleColumn) will not be renamed to demandGenerateScheduleId';


GO
PRINT N'Dropping [dbo].[FK_tblLandLeasePeriod_ToTable]...';


GO
ALTER TABLE [dbo].[tblLandLeasePeriod] DROP CONSTRAINT [FK_tblLandLeasePeriod_ToTable];


GO
PRINT N'Dropping [dbo].[FK_tblLandLease_ToTable]...';


GO
ALTER TABLE [dbo].[tblLandLease] DROP CONSTRAINT [FK_tblLandLease_ToTable];


GO
PRINT N'Dropping [dbo].[FK_tblLandLease_ToTable_1]...';


GO
ALTER TABLE [dbo].[tblLandLease] DROP CONSTRAINT [FK_tblLandLease_ToTable_1];


GO
PRINT N'Dropping [dbo].[FK_tblLandLease_ToTable_2]...';


GO
ALTER TABLE [dbo].[tblLandLease] DROP CONSTRAINT [FK_tblLandLease_ToTable_2];


GO
PRINT N'Dropping [dbo].[FK_tblLandLease_ToTable_3]...';


GO
ALTER TABLE [dbo].[tblLandLease] DROP CONSTRAINT [FK_tblLandLease_ToTable_3];


GO
PRINT N'Dropping [dbo].[FK_tblLandLease_ToTable_4]...';


GO
ALTER TABLE [dbo].[tblLandLease] DROP CONSTRAINT [FK_tblLandLease_ToTable_4];


GO
PRINT N'Dropping [dbo].[FK_tblLandOwnershipDetail_ToTable_1]...';


GO
ALTER TABLE [dbo].[tblLandOwnershipDetail] DROP CONSTRAINT [FK_tblLandOwnershipDetail_ToTable_1];


GO
PRINT N'Starting rebuilding table [dbo].[tblLandLease]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_tblLandLease] (
    [landLeaseId]         INT             IDENTITY (1, 1) NOT NULL,
    [landDetailId]        INT             NOT NULL,
    [taxPayerId]          INT             NOT NULL,
    [billingScheduleId]   INT             NOT NULL,
    [leaseTypeId]         INT             NOT NULL,
    [leaseActivityTypeId] INT             NOT NULL,
    [hasShed]             BIT             NOT NULL,
    [hassecurityDeposit]  BIT             NOT NULL,
    [startDate]           DATE            NOT NULL,
    [leaseAmount]         DECIMAL (18, 2) NOT NULL,
    [shedAmount]          DECIMAL (18, 2) NOT NULL,
    [remarks]             VARCHAR (350)   NULL,
    [isActive]            BIT             NOT NULL,
    [terminateDate]       DATE            NULL,
    [terminateReason]     VARCHAR (250)   NULL,
    [createdBy]           INT             NOT NULL,
    [createdOn]           DATETIME        NOT NULL,
    [modifiedBy]          INT             NULL,
    [modifiedOn]          DATETIME        NULL,
    PRIMARY KEY CLUSTERED ([landLeaseId] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[tblLandLease])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_tblLandLease] ON;
        INSERT INTO [dbo].[tmp_ms_xx_tblLandLease] ([landLeaseId], [landDetailId], [taxPayerId], [billingScheduleId], [leaseTypeId], [leaseActivityTypeId], [hasShed], [hassecurityDeposit], [startDate], [leaseAmount], [shedAmount], [remarks], [isActive], [createdBy], [createdOn], [modifiedBy], [modifiedOn])
        SELECT   [landLeaseId],
                 [landDetailId],
                 [taxPayerId],
                 [billingScheduleId],
                 [leaseTypeId],
                 [leaseActivityTypeId],
                 [hasShed],
                 [hassecurityDeposit],
                 [startDate],
                 [leaseAmount],
                 [shedAmount],
                 [remarks],
                 [isActive],
                 [createdBy],
                 [createdOn],
                 [modifiedBy],
                 [modifiedOn]
        FROM     [dbo].[tblLandLease]
        ORDER BY [landLeaseId] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_tblLandLease] OFF;
    END

DROP TABLE [dbo].[tblLandLease];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_tblLandLease]', N'tblLandLease';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Starting rebuilding table [dbo].[tblLandLeasePeriod]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_tblLandLeasePeriod] (
    [landLeasePeriodId] INT           IDENTITY (1, 1) NOT NULL,
    [landLeaseId]       INT           NOT NULL,
    [startDate]         DATE          NOT NULL,
    [leaseEndDate]      DATE          NOT NULL,
    [remarks]           VARCHAR (250) NULL,
    [createdBy]         INT           NOT NULL,
    [createdOn]         DATETIME      NOT NULL,
    [modifiedBy]        INT           NULL,
    [modifiedOn]        DATETIME      NULL,
    PRIMARY KEY CLUSTERED ([landLeasePeriodId] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[tblLandLeasePeriod])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_tblLandLeasePeriod] ON;
        INSERT INTO [dbo].[tmp_ms_xx_tblLandLeasePeriod] ([landLeasePeriodId], [landLeaseId], [leaseEndDate], [remarks], [createdBy], [createdOn], [modifiedBy], [modifiedOn])
        SELECT   [landLeasePeriodId],
                 [landLeaseId],
                 [leaseEndDate],
                 [remarks],
                 [createdBy],
                 [createdOn],
                 [modifiedBy],
                 [modifiedOn]
        FROM     [dbo].[tblLandLeasePeriod]
        ORDER BY [landLeasePeriodId] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_tblLandLeasePeriod] OFF;
    END

DROP TABLE [dbo].[tblLandLeasePeriod];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_tblLandLeasePeriod]', N'tblLandLeasePeriod';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Starting rebuilding table [dbo].[enumBillingSchedule]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_enumBillingSchedule] (
    [billingScheduleId] INT           IDENTITY (1, 1) NOT NULL,
    [billingSchedule]   VARCHAR (150) NOT NULL,
    PRIMARY KEY CLUSTERED ([billingScheduleId] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[enumBillingSchedule])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_enumBillingSchedule] ON;
        INSERT INTO [dbo].[tmp_ms_xx_enumBillingSchedule] ([billingScheduleId], [billingSchedule])
        SELECT   [billingScheduleId],
                 [billingSchedule]
        FROM     [dbo].[enumBillingSchedule]
        ORDER BY [billingScheduleId] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_enumBillingSchedule] OFF;
    END

DROP TABLE [dbo].[enumBillingSchedule];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_enumBillingSchedule]', N'enumBillingSchedule';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Starting rebuilding table [dbo].[enumLandOwnershipType]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_enumLandOwnershipType] (
    [landOwnershipTypeId] INT          IDENTITY (1, 1) NOT NULL,
    [landOwnershipType]   VARCHAR (45) NOT NULL,
    PRIMARY KEY CLUSTERED ([landOwnershipTypeId] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[enumLandOwnershipType])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_enumLandOwnershipType] ON;
        INSERT INTO [dbo].[tmp_ms_xx_enumLandOwnershipType] ([landOwnershipTypeId], [landOwnershipType])
        SELECT   [landOwnershipTypeId],
                 [landOwnershipType]
        FROM     [dbo].[enumLandOwnershipType]
        ORDER BY [landOwnershipTypeId] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_enumLandOwnershipType] OFF;
    END

DROP TABLE [dbo].[enumLandOwnershipType];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_enumLandOwnershipType]', N'enumLandOwnershipType';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Creating [dbo].[enumDemandGenerateSchedule]...';


GO
CREATE TABLE [dbo].[enumDemandGenerateSchedule] (
    [demandGenerateScheduleId] INT           NOT NULL,
    [demandGenerateSchedule]   VARCHAR (250) NOT NULL,
    PRIMARY KEY CLUSTERED ([demandGenerateScheduleId] ASC)
);


GO
PRINT N'Creating [dbo].[mstParkingZone]...';


GO
CREATE TABLE [dbo].[mstParkingZone] (
    [parkingZoneId]   INT           IDENTITY (1, 1) NOT NULL,
    [parkingzoneName] VARCHAR (250) NOT NULL,
    [parkingzoneDesc] VARCHAR (250) NOT NULL,
    [isActive]        BIT           NOT NULL,
    [createdBy]       INT           NOT NULL,
    [createdOn]       DATETIME      NOT NULL,
    [modifiedBy]      INT           NULL,
    [modifiedOn]      DATETIME      NULL,
    PRIMARY KEY CLUSTERED ([parkingZoneId] ASC)
);


GO
PRINT N'Creating [dbo].[tblLandLeaseDemandDetail]...';


GO
CREATE TABLE [dbo].[tblLandLeaseDemandDetail] (
    [landLeaseDemandDetailId] INT        IDENTITY (1, 1) NOT NULL,
    [landLeaseId]             INT        NULL,
    [financialYearId]         NCHAR (10) NOT NULL,
    [demandYearId]            NCHAR (10) NULL,
    [demandMonthId]           NCHAR (10) NULL,
    PRIMARY KEY CLUSTERED ([landLeaseDemandDetailId] ASC)
);


GO
PRINT N'Creating [dbo].[FK_tblLandLeasePeriod_ToTable]...';


GO
ALTER TABLE [dbo].[tblLandLeasePeriod] WITH NOCHECK
    ADD CONSTRAINT [FK_tblLandLeasePeriod_ToTable] FOREIGN KEY ([landLeaseId]) REFERENCES [dbo].[tblLandLease] ([landLeaseId]);


GO
PRINT N'Creating [dbo].[FK_tblLandLease_ToTable]...';


GO
ALTER TABLE [dbo].[tblLandLease] WITH NOCHECK
    ADD CONSTRAINT [FK_tblLandLease_ToTable] FOREIGN KEY ([billingScheduleId]) REFERENCES [dbo].[enumBillingSchedule] ([billingScheduleId]);


GO
PRINT N'Creating [dbo].[FK_tblLandLease_ToTable_1]...';


GO
ALTER TABLE [dbo].[tblLandLease] WITH NOCHECK
    ADD CONSTRAINT [FK_tblLandLease_ToTable_1] FOREIGN KEY ([landDetailId]) REFERENCES [dbo].[mstLandDetail] ([landDetailId]);


GO
PRINT N'Creating [dbo].[FK_tblLandLease_ToTable_2]...';


GO
ALTER TABLE [dbo].[tblLandLease] WITH NOCHECK
    ADD CONSTRAINT [FK_tblLandLease_ToTable_2] FOREIGN KEY ([taxPayerId]) REFERENCES [dbo].[mstTaxPayerProfile] ([taxPayerId]);


GO
PRINT N'Creating [dbo].[FK_tblLandLease_ToTable_3]...';


GO
ALTER TABLE [dbo].[tblLandLease] WITH NOCHECK
    ADD CONSTRAINT [FK_tblLandLease_ToTable_3] FOREIGN KEY ([leaseTypeId]) REFERENCES [dbo].[enumLeaseType] ([leaseTypeId]);


GO
PRINT N'Creating [dbo].[FK_tblLandLease_ToTable_4]...';


GO
ALTER TABLE [dbo].[tblLandLease] WITH NOCHECK
    ADD CONSTRAINT [FK_tblLandLease_ToTable_4] FOREIGN KEY ([leaseActivityTypeId]) REFERENCES [dbo].[enumLeaseActivityType] ([leaseActivityTypeId]);


GO
PRINT N'Creating [dbo].[FK_tblLandOwnershipDetail_ToTable_1]...';


GO
ALTER TABLE [dbo].[tblLandOwnershipDetail] WITH NOCHECK
    ADD CONSTRAINT [FK_tblLandOwnershipDetail_ToTable_1] FOREIGN KEY ([landOwnershipTypeId]) REFERENCES [dbo].[enumLandOwnershipType] ([landOwnershipTypeId]);


GO
PRINT N'Creating [dbo].[FK_tblLandLeaseDemandDetail_ToTable]...';


GO
ALTER TABLE [dbo].[tblLandLeaseDemandDetail] WITH NOCHECK
    ADD CONSTRAINT [FK_tblLandLeaseDemandDetail_ToTable] FOREIGN KEY ([landLeaseId]) REFERENCES [dbo].[tblLandLease] ([landLeaseId]);


GO
-- Refactoring step to update target server with deployed transaction logs
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '3673680b-6883-4a2b-8244-55720952fcbd')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('3673680b-6883-4a2b-8244-55720952fcbd')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '04d53c20-2052-4d12-9558-390300918fd4')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('04d53c20-2052-4d12-9558-390300918fd4')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '47f87ae4-a606-4ad4-9cc4-4721a4898e17')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('47f87ae4-a606-4ad4-9cc4-4721a4898e17')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '2fa69af4-b8e2-4962-8a46-49687dff8355')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('2fa69af4-b8e2-4962-8a46-49687dff8355')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '0a8723c0-af20-47a2-bcf4-21e3eeb7a761')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('0a8723c0-af20-47a2-bcf4-21e3eeb7a761')

GO

GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[tblLandLeasePeriod] WITH CHECK CHECK CONSTRAINT [FK_tblLandLeasePeriod_ToTable];

ALTER TABLE [dbo].[tblLandLease] WITH CHECK CHECK CONSTRAINT [FK_tblLandLease_ToTable];

ALTER TABLE [dbo].[tblLandLease] WITH CHECK CHECK CONSTRAINT [FK_tblLandLease_ToTable_1];

ALTER TABLE [dbo].[tblLandLease] WITH CHECK CHECK CONSTRAINT [FK_tblLandLease_ToTable_2];

ALTER TABLE [dbo].[tblLandLease] WITH CHECK CHECK CONSTRAINT [FK_tblLandLease_ToTable_3];

ALTER TABLE [dbo].[tblLandLease] WITH CHECK CHECK CONSTRAINT [FK_tblLandLease_ToTable_4];

ALTER TABLE [dbo].[tblLandOwnershipDetail] WITH CHECK CHECK CONSTRAINT [FK_tblLandOwnershipDetail_ToTable_1];

ALTER TABLE [dbo].[tblLandLeaseDemandDetail] WITH CHECK CHECK CONSTRAINT [FK_tblLandLeaseDemandDetail_ToTable];


GO
PRINT N'Update complete.';


GO
