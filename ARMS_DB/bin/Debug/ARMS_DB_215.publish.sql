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
The column stallTypeId on table [dbo].[tblStallDetailDemand] must be changed from NULL to NOT NULL. If the table contains data, the ALTER script may not work. To avoid this issue, you must add values to this column for all rows or mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.
*/

IF EXISTS (select top 1 1 from [dbo].[tblStallDetailDemand])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
/*
The column [dbo].[trnWaterConnection].[completionStatus] is being dropped, data loss could occur.
*/

IF EXISTS (select top 1 1 from [dbo].[trnWaterConnection])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
PRINT N'Rename refactoring operation with key 9398d4c4-002c-4774-b842-9c7168922eaf is skipped, element [dbo].[trnLandFeeDetail].[Id] (SqlSimpleColumn) will not be renamed to landFeeDetailId';


GO
PRINT N'Rename refactoring operation with key 7222f21d-9518-470e-be38-2469a92cc7ac is skipped, element [dbo].[mstLandServiceType].[Id] (SqlSimpleColumn) will not be renamed to landServiceTypeId';


GO
PRINT N'Dropping Default Constraint unnamed constraint on [dbo].[trnWaterConnection]...';


GO
ALTER TABLE [dbo].[trnWaterConnection] DROP CONSTRAINT [DF__trnWaterC__compl__03B16C81];


GO
PRINT N'Dropping Foreign Key [dbo].[FK_tblStallDetailDemand_ToTable_3]...';


GO
ALTER TABLE [dbo].[tblStallDetailDemand] DROP CONSTRAINT [FK_tblStallDetailDemand_ToTable_3];


GO
PRINT N'Altering Table [dbo].[tblStallDetailDemand]...';


GO
ALTER TABLE [dbo].[tblStallDetailDemand] ALTER COLUMN [stallTypeId] INT NOT NULL;


GO
PRINT N'Altering Table [dbo].[trnWaterConnection]...';


GO
ALTER TABLE [dbo].[trnWaterConnection] DROP COLUMN [completionStatus];


GO
PRINT N'Creating Table [dbo].[mstLandServiceType]...';


GO
CREATE TABLE [dbo].[mstLandServiceType] (
    [landServiceTypeId] INT           IDENTITY (1, 1) NOT NULL,
    [landServiceType]   VARCHAR (150) NOT NULL,
    [isActive]          BIT           NOT NULL,
    [createdBy]         INT           NOT NULL,
    [createdOn]         DATETIME      NOT NULL,
    [modifiedBy]        INT           NULL,
    [modifiedOn]        DATETIME      NULL,
    PRIMARY KEY CLUSTERED ([landServiceTypeId] ASC)
);


GO
PRINT N'Creating Table [dbo].[trnLandFeeDetail]...';


GO
CREATE TABLE [dbo].[trnLandFeeDetail] (
    [landFeeDetailId]   INT      IDENTITY (1, 1) NOT NULL,
    [landOwnershipId]   INT      NOT NULL,
    [landServiceTypeId] INT      NOT NULL,
    [transactionId]     BIGINT   NOT NULL,
    [createdBy]         INT      NOT NULL,
    [createdOn]         DATETIME NOT NULL,
    [modifiedBy]        INT      NULL,
    [modifiedOn]        DATETIME NULL,
    PRIMARY KEY CLUSTERED ([landFeeDetailId] ASC)
);


GO
PRINT N'Creating Foreign Key [dbo].[FK_tblStallDetailDemand_ToTable_3]...';


GO
ALTER TABLE [dbo].[tblStallDetailDemand] WITH NOCHECK
    ADD CONSTRAINT [FK_tblStallDetailDemand_ToTable_3] FOREIGN KEY ([stallTypeId]) REFERENCES [dbo].[mstStallType] ([stallTypeId]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_trnLandFeeDetail_ToTable]...';


GO
ALTER TABLE [dbo].[trnLandFeeDetail] WITH NOCHECK
    ADD CONSTRAINT [FK_trnLandFeeDetail_ToTable] FOREIGN KEY ([landOwnershipId]) REFERENCES [dbo].[tblLandOwnershipDetail] ([landOwnershipId]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_trnLandFeeDetail_ToTable_1]...';


GO
ALTER TABLE [dbo].[trnLandFeeDetail] WITH NOCHECK
    ADD CONSTRAINT [FK_trnLandFeeDetail_ToTable_1] FOREIGN KEY ([landServiceTypeId]) REFERENCES [dbo].[mstLandServiceType] ([landServiceTypeId]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_trnLandFeeDetail_ToTable_2]...';


GO
ALTER TABLE [dbo].[trnLandFeeDetail] WITH NOCHECK
    ADD CONSTRAINT [FK_trnLandFeeDetail_ToTable_2] FOREIGN KEY ([transactionId]) REFERENCES [dbo].[tblTransactionDetail] ([transactionId]);


GO
PRINT N'Refreshing Procedure [dbo].[GetStallDemandScheduleMonthly]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[GetStallDemandScheduleMonthly]';


GO
-- Refactoring step to update target server with deployed transaction logs
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '9398d4c4-002c-4774-b842-9c7168922eaf')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('9398d4c4-002c-4774-b842-9c7168922eaf')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '7222f21d-9518-470e-be38-2469a92cc7ac')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('7222f21d-9518-470e-be38-2469a92cc7ac')

GO

GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[tblStallDetailDemand] WITH CHECK CHECK CONSTRAINT [FK_tblStallDetailDemand_ToTable_3];

ALTER TABLE [dbo].[trnLandFeeDetail] WITH CHECK CHECK CONSTRAINT [FK_trnLandFeeDetail_ToTable];

ALTER TABLE [dbo].[trnLandFeeDetail] WITH CHECK CHECK CONSTRAINT [FK_trnLandFeeDetail_ToTable_1];

ALTER TABLE [dbo].[trnLandFeeDetail] WITH CHECK CHECK CONSTRAINT [FK_trnLandFeeDetail_ToTable_2];


GO
PRINT N'Update complete.';


GO