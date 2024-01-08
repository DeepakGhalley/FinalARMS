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
The column [dbo].[tblStallDetail].[billingScheduleId] is being dropped, data loss could occur.

The column [dbo].[tblStallDetail].[houseAddress] is being dropped, data loss could occur.

The column [dbo].[tblStallDetail].[stallDetail] is being dropped, data loss could occur.

The column [dbo].[tblStallDetail].[taxPayerId] is being dropped, data loss could occur.

The column [dbo].[tblStallDetail].[terminateDate] is being dropped, data loss could occur.

The column [dbo].[tblStallDetail].[terminatedBy] is being dropped, data loss could occur.

The column [dbo].[tblStallDetail].[terminateReason] is being dropped, data loss could occur.

The column [dbo].[tblStallDetail].[rateId] on table [dbo].[tblStallDetail] must be added, but the column has no default value and does not allow NULL values. If the table contains data, the ALTER script will not work. To avoid this issue you must either: add a default value to the column, mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.

The column [dbo].[tblStallDetail].[stallArea] on table [dbo].[tblStallDetail] must be added, but the column has no default value and does not allow NULL values. If the table contains data, the ALTER script will not work. To avoid this issue you must either: add a default value to the column, mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.

The column [dbo].[tblStallDetail].[stallName] on table [dbo].[tblStallDetail] must be added, but the column has no default value and does not allow NULL values. If the table contains data, the ALTER script will not work. To avoid this issue you must either: add a default value to the column, mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.

The column [dbo].[tblStallDetail].[stallNo] on table [dbo].[tblStallDetail] must be added, but the column has no default value and does not allow NULL values. If the table contains data, the ALTER script will not work. To avoid this issue you must either: add a default value to the column, mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.

The column rentalAmount on table [dbo].[tblStallDetail] must be changed from NULL to NOT NULL. If the table contains data, the ALTER script may not work. To avoid this issue, you must add values to this column for all rows or mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.

The column securityAmount on table [dbo].[tblStallDetail] must be changed from NULL to NOT NULL. If the table contains data, the ALTER script may not work. To avoid this issue, you must add values to this column for all rows or mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.
*/

IF EXISTS (select top 1 1 from [dbo].[tblStallDetail])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
PRINT N'Rename refactoring operation with key 938bd074-5305-4c4c-a9a2-a658aca81c7e is skipped, element [dbo].[tblStallAllocation].[isActive] (SqlSimpleColumn) will not be renamed to allocationDate';


GO
PRINT N'The following operation was generated from a refactoring log file d21d7a25-af42-43f0-8f16-b33abb568a34';

PRINT N'Rename [dbo].[tblStallPeriod].[stallPeriodDetailId] to stallAllocationId';


GO
EXECUTE sp_rename @objname = N'[dbo].[tblStallPeriod].[stallPeriodDetailId]', @newname = N'stallAllocationId', @objtype = N'COLUMN';


GO
PRINT N'The following operation was generated from a refactoring log file 756ebc03-7cda-4b7c-9646-8b606f3fc4f6';

PRINT N'Rename [dbo].[tblStallDetail].[installmentAmount] to rentalAmount';


GO
EXECUTE sp_rename @objname = N'[dbo].[tblStallDetail].[installmentAmount]', @newname = N'rentalAmount', @objtype = N'COLUMN';


GO
PRINT N'Dropping [dbo].[FK_tblStallDetail_ToTable]...';


GO
ALTER TABLE [dbo].[tblStallDetail] DROP CONSTRAINT [FK_tblStallDetail_ToTable];


GO
PRINT N'Dropping [dbo].[FK_tblStallDetail_ToTable_1]...';


GO
ALTER TABLE [dbo].[tblStallDetail] DROP CONSTRAINT [FK_tblStallDetail_ToTable_1];


GO
PRINT N'Dropping [dbo].[FK_tblStallDetail_ToTable_2]...';


GO
ALTER TABLE [dbo].[tblStallDetail] DROP CONSTRAINT [FK_tblStallDetail_ToTable_2];


GO
PRINT N'Dropping [dbo].[FK_tblStallDetailDemand_ToTable]...';


GO
ALTER TABLE [dbo].[tblStallDetailDemand] DROP CONSTRAINT [FK_tblStallDetailDemand_ToTable];


GO
PRINT N'Starting rebuilding table [dbo].[tblStallDetail]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_tblStallDetail] (
    [stallDetailId]   INT             IDENTITY (1, 1) NOT NULL,
    [stallLocationId] INT             NOT NULL,
    [stallNo]         VARCHAR (250)   NOT NULL,
    [stallName]       VARCHAR (350)   NOT NULL,
    [rateId]          INT             NOT NULL,
    [stallArea]       DECIMAL (18, 2) NOT NULL,
    [rentalAmount]    DECIMAL (18, 2) NOT NULL,
    [securityAmount]  DECIMAL (18, 2) NOT NULL,
    [remarks]         VARCHAR (350)   NULL,
    [isActive]        BIT             NOT NULL,
    [createdBy]       INT             NOT NULL,
    [createdOn]       DATETIME        NOT NULL,
    [modifiedBy]      INT             NULL,
    [modifiedOn]      DATETIME        NULL,
    PRIMARY KEY CLUSTERED ([stallDetailId] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[tblStallDetail])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_tblStallDetail] ON;
        INSERT INTO [dbo].[tmp_ms_xx_tblStallDetail] ([stallDetailId], [stallLocationId], [rentalAmount], [securityAmount], [remarks], [isActive], [createdBy], [createdOn], [modifiedBy], [modifiedOn])
        SELECT   [stallDetailId],
                 [stallLocationId],
                 [rentalAmount],
                 [securityAmount],
                 [remarks],
                 [isActive],
                 [createdBy],
                 [createdOn],
                 [modifiedBy],
                 [modifiedOn]
        FROM     [dbo].[tblStallDetail]
        ORDER BY [stallDetailId] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_tblStallDetail] OFF;
    END

DROP TABLE [dbo].[tblStallDetail];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_tblStallDetail]', N'tblStallDetail';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Creating [dbo].[tblStallAllocation]...';


GO
CREATE TABLE [dbo].[tblStallAllocation] (
    [stallAllocationId] INT           IDENTITY (1, 1) NOT NULL,
    [stallDetailId]     INT           NOT NULL,
    [taxPayerId]        INT           NOT NULL,
    [billingScheduleId] INT           NOT NULL,
    [allocationDate]    DATE          NOT NULL,
    [remarks]           VARCHAR (350) NULL,
    [isTerminated]      BIT           NOT NULL,
    [terminateDate]     DATE          NULL,
    [terminateReason]   VARCHAR (250) NULL,
    [terminatedBy]      INT           NULL,
    [createdBy]         INT           NOT NULL,
    [createdOn]         DATETIME      NOT NULL,
    [modifiedBy]        INT           NULL,
    [modifiedOn]        DATETIME      NULL,
    CONSTRAINT [PK_tblStallAllocation] PRIMARY KEY CLUSTERED ([stallAllocationId] ASC)
);


GO
PRINT N'Creating unnamed constraint on [dbo].[tblStallAllocation]...';


GO
ALTER TABLE [dbo].[tblStallAllocation]
    ADD DEFAULT 0 FOR [isTerminated];


GO
PRINT N'Creating [dbo].[FK_tblStallDetail_ToTable]...';


GO
ALTER TABLE [dbo].[tblStallDetail] WITH NOCHECK
    ADD CONSTRAINT [FK_tblStallDetail_ToTable] FOREIGN KEY ([stallLocationId]) REFERENCES [dbo].[mstStallLocation] ([stallLocationId]);


GO
PRINT N'Creating [dbo].[FK_tblStallDetail_ToTable_2]...';


GO
ALTER TABLE [dbo].[tblStallDetail] WITH NOCHECK
    ADD CONSTRAINT [FK_tblStallDetail_ToTable_2] FOREIGN KEY ([rateId]) REFERENCES [dbo].[mstRate] ([rateId]);


GO
PRINT N'Creating [dbo].[FK_tblStallDetailDemand_ToTable]...';


GO
ALTER TABLE [dbo].[tblStallDetailDemand] WITH NOCHECK
    ADD CONSTRAINT [FK_tblStallDetailDemand_ToTable] FOREIGN KEY ([stallDetailId]) REFERENCES [dbo].[tblStallDetail] ([stallDetailId]);


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
PRINT N'Creating [dbo].[FK_tblStallPeriod_ToTable]...';


GO
ALTER TABLE [dbo].[tblStallPeriod] WITH NOCHECK
    ADD CONSTRAINT [FK_tblStallPeriod_ToTable] FOREIGN KEY ([stallAllocationId]) REFERENCES [dbo].[tblStallAllocation] ([stallAllocationId]);


GO
-- Refactoring step to update target server with deployed transaction logs
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '938bd074-5305-4c4c-a9a2-a658aca81c7e')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('938bd074-5305-4c4c-a9a2-a658aca81c7e')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'd21d7a25-af42-43f0-8f16-b33abb568a34')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('d21d7a25-af42-43f0-8f16-b33abb568a34')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '756ebc03-7cda-4b7c-9646-8b606f3fc4f6')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('756ebc03-7cda-4b7c-9646-8b606f3fc4f6')

GO

GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[tblStallDetail] WITH CHECK CHECK CONSTRAINT [FK_tblStallDetail_ToTable];

ALTER TABLE [dbo].[tblStallDetail] WITH CHECK CHECK CONSTRAINT [FK_tblStallDetail_ToTable_2];

ALTER TABLE [dbo].[tblStallDetailDemand] WITH CHECK CHECK CONSTRAINT [FK_tblStallDetailDemand_ToTable];

ALTER TABLE [dbo].[tblStallAllocation] WITH CHECK CHECK CONSTRAINT [FK_tblStallAllocation_ToTable];

ALTER TABLE [dbo].[tblStallAllocation] WITH CHECK CHECK CONSTRAINT [FK_tblStallAllocation_ToTable_1];

ALTER TABLE [dbo].[tblStallAllocation] WITH CHECK CHECK CONSTRAINT [FK_tblStallAllocation_ToTable_2];

ALTER TABLE [dbo].[tblStallPeriod] WITH CHECK CHECK CONSTRAINT [FK_tblStallPeriod_ToTable];


GO
PRINT N'Update complete.';


GO
