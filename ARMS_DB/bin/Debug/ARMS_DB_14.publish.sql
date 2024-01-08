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
The column [dbo].[tblStallAllocation].[rentalAmount] on table [dbo].[tblStallAllocation] must be added, but the column has no default value and does not allow NULL values. If the table contains data, the ALTER script will not work. To avoid this issue you must either: add a default value to the column, mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.

The column [dbo].[tblStallAllocation].[securityAmount] on table [dbo].[tblStallAllocation] must be added, but the column has no default value and does not allow NULL values. If the table contains data, the ALTER script will not work. To avoid this issue you must either: add a default value to the column, mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.
*/

IF EXISTS (select top 1 1 from [dbo].[tblStallAllocation])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
PRINT N'The following operation was generated from a refactoring log file dafe8718-2a65-41e2-9ed9-e32134e15a62';

PRINT N'Rename [dbo].[tblStallDetailDemand].[installmentAmount] to amount';


GO
EXECUTE sp_rename @objname = N'[dbo].[tblStallDetailDemand].[installmentAmount]', @newname = N'amount', @objtype = N'COLUMN';


GO
PRINT N'Dropping unnamed constraint on [dbo].[tblStallAllocation]...';


GO
ALTER TABLE [dbo].[tblStallAllocation] DROP CONSTRAINT [DF__tblStallA__isTer__75E27017];


GO
PRINT N'Dropping [dbo].[FK_tblStallPeriod_ToTable]...';


GO
ALTER TABLE [dbo].[tblStallPeriod] DROP CONSTRAINT [FK_tblStallPeriod_ToTable];


GO
PRINT N'Dropping [dbo].[FK_tblStallAllocation_ToTable]...';


GO
ALTER TABLE [dbo].[tblStallAllocation] DROP CONSTRAINT [FK_tblStallAllocation_ToTable];


GO
PRINT N'Dropping [dbo].[FK_tblStallAllocation_ToTable_1]...';


GO
ALTER TABLE [dbo].[tblStallAllocation] DROP CONSTRAINT [FK_tblStallAllocation_ToTable_1];


GO
PRINT N'Dropping [dbo].[FK_tblStallAllocation_ToTable_2]...';


GO
ALTER TABLE [dbo].[tblStallAllocation] DROP CONSTRAINT [FK_tblStallAllocation_ToTable_2];


GO
PRINT N'Starting rebuilding table [dbo].[tblStallAllocation]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_tblStallAllocation] (
    [stallAllocationId] INT             IDENTITY (1, 1) NOT NULL,
    [stallDetailId]     INT             NOT NULL,
    [taxPayerId]        INT             NOT NULL,
    [billingScheduleId] INT             NOT NULL,
    [allocationDate]    DATE            NOT NULL,
    [rentalAmount]      DECIMAL (18, 2) NOT NULL,
    [securityAmount]    DECIMAL (18, 2) NOT NULL,
    [remarks]           VARCHAR (350)   NULL,
    [isTerminated]      BIT             DEFAULT 0 NOT NULL,
    [terminateDate]     DATE            NULL,
    [terminateReason]   VARCHAR (250)   NULL,
    [terminatedBy]      INT             NULL,
    [createdBy]         INT             NOT NULL,
    [createdOn]         DATETIME        NOT NULL,
    [modifiedBy]        INT             NULL,
    [modifiedOn]        DATETIME        NULL,
    CONSTRAINT [tmp_ms_xx_constraint_PK_tblStallAllocation1] PRIMARY KEY CLUSTERED ([stallAllocationId] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[tblStallAllocation])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_tblStallAllocation] ON;
        INSERT INTO [dbo].[tmp_ms_xx_tblStallAllocation] ([stallAllocationId], [stallDetailId], [taxPayerId], [billingScheduleId], [allocationDate], [remarks], [isTerminated], [terminateDate], [terminateReason], [terminatedBy], [createdBy], [createdOn], [modifiedBy], [modifiedOn])
        SELECT   [stallAllocationId],
                 [stallDetailId],
                 [taxPayerId],
                 [billingScheduleId],
                 [allocationDate],
                 [remarks],
                 [isTerminated],
                 [terminateDate],
                 [terminateReason],
                 [terminatedBy],
                 [createdBy],
                 [createdOn],
                 [modifiedBy],
                 [modifiedOn]
        FROM     [dbo].[tblStallAllocation]
        ORDER BY [stallAllocationId] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_tblStallAllocation] OFF;
    END

DROP TABLE [dbo].[tblStallAllocation];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_tblStallAllocation]', N'tblStallAllocation';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_PK_tblStallAllocation1]', N'PK_tblStallAllocation', N'OBJECT';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Creating [dbo].[FK_tblStallPeriod_ToTable]...';


GO
ALTER TABLE [dbo].[tblStallPeriod] WITH NOCHECK
    ADD CONSTRAINT [FK_tblStallPeriod_ToTable] FOREIGN KEY ([stallAllocationId]) REFERENCES [dbo].[tblStallAllocation] ([stallAllocationId]);


GO
PRINT N'Creating [dbo].[FK_tblStallAllocation_ToTable]...';


GO
ALTER TABLE [dbo].[tblStallAllocation] WITH NOCHECK
    ADD CONSTRAINT [FK_tblStallAllocation_ToTable] FOREIGN KEY ([stallDetailId]) REFERENCES [dbo].[tblStallDetail] ([stallDetailId]);


GO
PRINT N'Creating [dbo].[FK_tblStallAllocation_ToTable_1]...';


GO
ALTER TABLE [dbo].[tblStallAllocation] WITH NOCHECK
    ADD CONSTRAINT [FK_tblStallAllocation_ToTable_1] FOREIGN KEY ([taxPayerId]) REFERENCES [dbo].[mstTaxPayerProfile] ([taxPayerId]);


GO
PRINT N'Creating [dbo].[FK_tblStallAllocation_ToTable_2]...';


GO
ALTER TABLE [dbo].[tblStallAllocation] WITH NOCHECK
    ADD CONSTRAINT [FK_tblStallAllocation_ToTable_2] FOREIGN KEY ([billingScheduleId]) REFERENCES [dbo].[enumBillingSchedule] ([billingScheduleId]);


GO
-- Refactoring step to update target server with deployed transaction logs
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'dafe8718-2a65-41e2-9ed9-e32134e15a62')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('dafe8718-2a65-41e2-9ed9-e32134e15a62')

GO

GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[tblStallPeriod] WITH CHECK CHECK CONSTRAINT [FK_tblStallPeriod_ToTable];

ALTER TABLE [dbo].[tblStallAllocation] WITH CHECK CHECK CONSTRAINT [FK_tblStallAllocation_ToTable];

ALTER TABLE [dbo].[tblStallAllocation] WITH CHECK CHECK CONSTRAINT [FK_tblStallAllocation_ToTable_1];

ALTER TABLE [dbo].[tblStallAllocation] WITH CHECK CHECK CONSTRAINT [FK_tblStallAllocation_ToTable_2];


GO
PRINT N'Update complete.';


GO
