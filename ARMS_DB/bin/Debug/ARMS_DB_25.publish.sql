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
PRINT N'Dropping [dbo].[FK_mstTaxPeriod_ToTable]...';


GO
ALTER TABLE [dbo].[mstTaxPeriod] DROP CONSTRAINT [FK_mstTaxPeriod_ToTable];


GO
PRINT N'Dropping [dbo].[FK_mstTaxPeriod_ToTable_1]...';


GO
ALTER TABLE [dbo].[mstTaxPeriod] DROP CONSTRAINT [FK_mstTaxPeriod_ToTable_1];


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
        INSERT INTO [dbo].[tmp_ms_xx_mstTaxPeriod] ([taxPeriodId], [taxTypeClassificationId], [calendarYearId], [penaltyOrRate], [effectiveDate], [createdBy], [createdOn], [modifiedBy], [modifiedOn])
        SELECT   [taxPeriodId],
                 [taxTypeClassificationId],
                 [calendarYearId],
                 [penaltyOrRate],
                 [effectiveDate],
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
PRINT N'Creating [dbo].[FK_mstTaxPeriod_ToTable_1]...';


GO
ALTER TABLE [dbo].[mstTaxPeriod] WITH NOCHECK
    ADD CONSTRAINT [FK_mstTaxPeriod_ToTable_1] FOREIGN KEY ([taxTypeClassificationId]) REFERENCES [dbo].[mstTaxTypeClassification] ([taxTypeClassificationId]);


GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[mstTaxPeriod] WITH CHECK CHECK CONSTRAINT [FK_mstTaxPeriod_ToTable];

ALTER TABLE [dbo].[mstTaxPeriod] WITH CHECK CHECK CONSTRAINT [FK_mstTaxPeriod_ToTable_1];


GO
PRINT N'Update complete.';


GO
