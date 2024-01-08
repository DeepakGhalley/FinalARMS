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
The column [dbo].[mstTaxPeriod].[endDate] is being dropped, data loss could occur.

The column [dbo].[mstTaxPeriod].[isActive] is being dropped, data loss could occur.

The column [dbo].[mstTaxPeriod].[taxTypeClassificationId] on table [dbo].[mstTaxPeriod] must be added, but the column has no default value and does not allow NULL values. If the table contains data, the ALTER script will not work. To avoid this issue you must either: add a default value to the column, mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.
*/

IF EXISTS (select top 1 1 from [dbo].[mstTaxPeriod])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
PRINT N'The following operation was generated from a refactoring log file 439ddbb4-c44b-4736-ad1f-532d09d0aa58';

PRINT N'Rename [dbo].[mstTaxPeriod].[transactionTypeId] to calendarYearId';


GO
EXECUTE sp_rename @objname = N'[dbo].[mstTaxPeriod].[transactionTypeId]', @newname = N'calendarYearId', @objtype = N'COLUMN';


GO
PRINT N'The following operation was generated from a refactoring log file 05455bbc-da13-4fc1-b870-b1120532d3a4';

PRINT N'Rename [dbo].[mstTaxPeriod].[startDate] to effectiveDate';


GO
EXECUTE sp_rename @objname = N'[dbo].[mstTaxPeriod].[startDate]', @newname = N'effectiveDate', @objtype = N'COLUMN';


GO
PRINT N'Rename refactoring operation with key 0683bb51-39f5-47ff-86bd-eab3d46de6ee is skipped, element [dbo].[mstTaxPeriod].[typeId] (SqlSimpleColumn) will not be renamed to taxTypeClassificationId';


GO
PRINT N'The following operation was generated from a refactoring log file 1480bf53-971e-4243-b9b6-66c08c4228b5';

PRINT N'Rename [dbo].[mstTaxPeriod].[penalty] to penaltyOrRate';


GO
EXECUTE sp_rename @objname = N'[dbo].[mstTaxPeriod].[penalty]', @newname = N'penaltyOrRate', @objtype = N'COLUMN';


GO
PRINT N'Dropping [dbo].[FK_mstTaxPeriod_ToTable]...';


GO
ALTER TABLE [dbo].[mstTaxPeriod] DROP CONSTRAINT [FK_mstTaxPeriod_ToTable];


GO
PRINT N'Dropping [dbo].[FK_tblLandLease_ToTable_5]...';


GO
ALTER TABLE [dbo].[tblLandLease] DROP CONSTRAINT [FK_tblLandLease_ToTable_5];


GO
PRINT N'Starting rebuilding table [dbo].[mstTaxPeriod]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_mstTaxPeriod] (
    [taxPeriodId]             INT             IDENTITY (1, 1) NOT NULL,
    [taxTypeClassificationId] INT             NOT NULL,
    [calendarYearId]          INT             NOT NULL,
    [penaltyOrRate]           DECIMAL (18, 2) NOT NULL,
    [effectiveDate]           DATE            NOT NULL,
    [createdBy]               INT             NOT NULL,
    [createdOn]               DATETIME        NOT NULL,
    [modifiedBy]              INT             NULL,
    [modifiedOn]              DATETIME        NULL,
    PRIMARY KEY CLUSTERED ([taxPeriodId] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[mstTaxPeriod])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_mstTaxPeriod] ON;
        INSERT INTO [dbo].[tmp_ms_xx_mstTaxPeriod] ([taxPeriodId], [calendarYearId], [effectiveDate], [penaltyOrRate], [createdBy], [createdOn], [modifiedBy], [modifiedOn])
        SELECT   [taxPeriodId],
                 [calendarYearId],
                 [effectiveDate],
                 [penaltyOrRate],
                 [createdBy],
                 [createdOn],
                 [modifiedBy],
                 [modifiedOn]
        FROM     [dbo].[mstTaxPeriod]
        ORDER BY [taxPeriodId] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_mstTaxPeriod] OFF;
    END

DROP TABLE [dbo].[mstTaxPeriod];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_mstTaxPeriod]', N'mstTaxPeriod';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Creating [dbo].[FK_mstTaxPeriod_ToTable]...';


GO
ALTER TABLE [dbo].[mstTaxPeriod] WITH NOCHECK
    ADD CONSTRAINT [FK_mstTaxPeriod_ToTable] FOREIGN KEY ([calendarYearId]) REFERENCES [dbo].[mstCalendarYear] ([calendarYearId]);


GO
PRINT N'Creating [dbo].[FK_tblLandLease_ToTable_5]...';


GO
ALTER TABLE [dbo].[tblLandLease] WITH NOCHECK
    ADD CONSTRAINT [FK_tblLandLease_ToTable_5] FOREIGN KEY ([taxPeriodId]) REFERENCES [dbo].[mstTaxPeriod] ([taxPeriodId]);


GO
PRINT N'Creating [dbo].[FK_mstTaxPeriod_ToTable_1]...';


GO
ALTER TABLE [dbo].[mstTaxPeriod] WITH NOCHECK
    ADD CONSTRAINT [FK_mstTaxPeriod_ToTable_1] FOREIGN KEY ([taxTypeClassificationId]) REFERENCES [dbo].[mstTaxTypeClassification] ([taxTypeClassificationId]);


GO
-- Refactoring step to update target server with deployed transaction logs
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '439ddbb4-c44b-4736-ad1f-532d09d0aa58')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('439ddbb4-c44b-4736-ad1f-532d09d0aa58')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '05455bbc-da13-4fc1-b870-b1120532d3a4')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('05455bbc-da13-4fc1-b870-b1120532d3a4')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '0683bb51-39f5-47ff-86bd-eab3d46de6ee')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('0683bb51-39f5-47ff-86bd-eab3d46de6ee')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '1480bf53-971e-4243-b9b6-66c08c4228b5')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('1480bf53-971e-4243-b9b6-66c08c4228b5')

GO

GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[mstTaxPeriod] WITH CHECK CHECK CONSTRAINT [FK_mstTaxPeriod_ToTable];

ALTER TABLE [dbo].[tblLandLease] WITH CHECK CHECK CONSTRAINT [FK_tblLandLease_ToTable_5];

ALTER TABLE [dbo].[mstTaxPeriod] WITH CHECK CHECK CONSTRAINT [FK_mstTaxPeriod_ToTable_1];


GO
PRINT N'Update complete.';


GO