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
The column [dbo].[trnWaterMeterReading].[waterConnectionId] is being dropped, data loss could occur.

The column [dbo].[trnWaterMeterReading].[waterMeterReadingId] is being dropped, data loss could occur.

The column [dbo].[trnWaterMeterReading].[trnWaterConnectionId] on table [dbo].[trnWaterMeterReading] must be added, but the column has no default value and does not allow NULL values. If the table contains data, the ALTER script will not work. To avoid this issue you must either: add a default value to the column, mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.
*/

IF EXISTS (select top 1 1 from [dbo].[trnWaterMeterReading])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
PRINT N'Rename refactoring operation with key bf1fea50-67c8-4457-a713-ccfd1e999a79 is skipped, element [dbo].[trnWaterMeterReading].[trnwaterConnectionId] (SqlSimpleColumn) will not be renamed to trnWaterConnectionId';


GO
PRINT N'Dropping [dbo].[FK_trnWaterMeterReading_ToTable]...';


GO
ALTER TABLE [dbo].[trnWaterMeterReading] DROP CONSTRAINT [FK_trnWaterMeterReading_ToTable];


GO
PRINT N'Dropping [dbo].[FK_trnWaterMeterReading_ToTable_1]...';


GO
ALTER TABLE [dbo].[trnWaterMeterReading] DROP CONSTRAINT [FK_trnWaterMeterReading_ToTable_1];


GO
PRINT N'Dropping [dbo].[FK_trnWaterMeterReading_ToTable_2]...';


GO
ALTER TABLE [dbo].[trnWaterMeterReading] DROP CONSTRAINT [FK_trnWaterMeterReading_ToTable_2];


GO
PRINT N'Dropping [dbo].[FK_trnWaterMeterReading_ToTable_3]...';


GO
ALTER TABLE [dbo].[trnWaterMeterReading] DROP CONSTRAINT [FK_trnWaterMeterReading_ToTable_3];


GO
PRINT N'Dropping [dbo].[FK_trnWaterMeterReading_ToTable_4]...';


GO
ALTER TABLE [dbo].[trnWaterMeterReading] DROP CONSTRAINT [FK_trnWaterMeterReading_ToTable_4];


GO
PRINT N'Dropping [dbo].[FK_tblLandOwnershipDetail_ToTable_1]...';


GO
ALTER TABLE [dbo].[tblLandOwnershipDetail] DROP CONSTRAINT [FK_tblLandOwnershipDetail_ToTable_1];


GO
PRINT N'Starting rebuilding table [dbo].[trnWaterMeterReading]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_trnWaterMeterReading] (
    [trnWaterMeterReadingId]  INT           IDENTITY (1, 1) NOT NULL,
    [trnWaterConnectionId]    BIGINT        NOT NULL,
    [waterConnectionTypeId]   INT           NOT NULL,
    [waterMeterTypeId]        INT           NOT NULL,
    [waterLineTypeId]         INT           NOT NULL,
    [waterConnectionStatusId] INT           NOT NULL,
    [bucid]                   INT           NULL,
    [reading]                 INT           NOT NULL,
    [previousReading]         INT           NOT NULL,
    [previousReadingDate]     DATE          NOT NULL,
    [readBy]                  INT           NOT NULL,
    [readingDate]             DATE          NOT NULL,
    [noOfUnit]                INT           NOT NULL,
    [consumption]             INT           NOT NULL,
    [standardConsumption]     INT           NULL,
    [isPermanentConnection]   BIT           NOT NULL,
    [sewerage]                BIT           NOT NULL,
    [solidWaste]              BIT           NOT NULL,
    [remarks]                 VARCHAR (250) NULL,
    [billingAddress]          VARCHAR (350) NOT NULL,
    [transactionId]           BIGINT        NULL,
    [primaryMobileNo]         VARCHAR (150) NOT NULL,
    [secondaryMobileNo]       VARCHAR (150) NULL,
    PRIMARY KEY CLUSTERED ([trnWaterMeterReadingId] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[trnWaterMeterReading])
    BEGIN
        INSERT INTO [dbo].[tmp_ms_xx_trnWaterMeterReading] ([waterConnectionTypeId], [waterMeterTypeId], [waterLineTypeId], [waterConnectionStatusId], [bucid], [reading], [previousReading], [previousReadingDate], [readBy], [readingDate], [noOfUnit], [consumption], [standardConsumption], [isPermanentConnection], [sewerage], [solidWaste], [remarks], [billingAddress], [transactionId], [primaryMobileNo], [secondaryMobileNo])
        SELECT [waterConnectionTypeId],
               [waterMeterTypeId],
               [waterLineTypeId],
               [waterConnectionStatusId],
               [bucid],
               [reading],
               [previousReading],
               [previousReadingDate],
               [readBy],
               [readingDate],
               [noOfUnit],
               [consumption],
               [standardConsumption],
               [isPermanentConnection],
               [sewerage],
               [solidWaste],
               [remarks],
               [billingAddress],
               [transactionId],
               [primaryMobileNo],
               [secondaryMobileNo]
        FROM   [dbo].[trnWaterMeterReading];
    END

DROP TABLE [dbo].[trnWaterMeterReading];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_trnWaterMeterReading]', N'trnWaterMeterReading';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Starting rebuilding table [dbo].[enumLandOwnershipType]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_enumLandOwnershipType] (
    [landOwnershipTypeId]          INT           IDENTITY (1, 1) NOT NULL,
    [landOwnershipType]            VARCHAR (45)  NOT NULL,
    [landOwnershipTypeDescription] VARCHAR (250) NOT NULL,
    PRIMARY KEY CLUSTERED ([landOwnershipTypeId] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[enumLandOwnershipType])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_enumLandOwnershipType] ON;
        INSERT INTO [dbo].[tmp_ms_xx_enumLandOwnershipType] ([landOwnershipTypeId], [landOwnershipType], [landOwnershipTypeDescription])
        SELECT   [landOwnershipTypeId],
                 [landOwnershipType],
                 [landOwnershipTypeDescription]
        FROM     [dbo].[enumLandOwnershipType]
        ORDER BY [landOwnershipTypeId] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_enumLandOwnershipType] OFF;
    END

DROP TABLE [dbo].[enumLandOwnershipType];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_enumLandOwnershipType]', N'enumLandOwnershipType';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Creating [dbo].[tblWaterMeterReading]...';


GO
CREATE TABLE [dbo].[tblWaterMeterReading] (
    [waterMeterReadingId]     INT           IDENTITY (1, 1) NOT NULL,
    [waterConnectionId]       INT           NOT NULL,
    [waterConnectionTypeId]   INT           NOT NULL,
    [waterMeterTypeId]        INT           NOT NULL,
    [waterLineTypeId]         INT           NOT NULL,
    [waterConnectionStatusId] INT           NOT NULL,
    [bucid]                   INT           NULL,
    [reading]                 INT           NOT NULL,
    [previousReading]         INT           NOT NULL,
    [previousReadingDate]     DATE          NOT NULL,
    [readBy]                  INT           NOT NULL,
    [readingDate]             DATE          NOT NULL,
    [noOfUnit]                INT           NOT NULL,
    [consumption]             INT           NOT NULL,
    [standardConsumption]     INT           NULL,
    [isPermanentConnection]   BIT           NOT NULL,
    [sewerage]                BIT           NOT NULL,
    [solidWaste]              BIT           NOT NULL,
    [remarks]                 VARCHAR (250) NULL,
    [billingAddress]          VARCHAR (350) NOT NULL,
    [transactionId]           BIGINT        NULL,
    [primaryMobileNo]         VARCHAR (150) NOT NULL,
    [secondaryMobileNo]       VARCHAR (150) NULL,
    PRIMARY KEY CLUSTERED ([waterMeterReadingId] ASC)
);


GO
PRINT N'Creating [dbo].[FK_trnWaterMeterReading_ToTable]...';


GO
ALTER TABLE [dbo].[trnWaterMeterReading] WITH NOCHECK
    ADD CONSTRAINT [FK_trnWaterMeterReading_ToTable] FOREIGN KEY ([trnWaterConnectionId]) REFERENCES [dbo].[trnWaterConnection] ([trnWaterConnectionId]);


GO
PRINT N'Creating [dbo].[FK_trnWaterMeterReading_ToTable_1]...';


GO
ALTER TABLE [dbo].[trnWaterMeterReading] WITH NOCHECK
    ADD CONSTRAINT [FK_trnWaterMeterReading_ToTable_1] FOREIGN KEY ([waterConnectionTypeId]) REFERENCES [dbo].[mstWaterConnectionType] ([waterConnectionTypeId]);


GO
PRINT N'Creating [dbo].[FK_trnWaterMeterReading_ToTable_2]...';


GO
ALTER TABLE [dbo].[trnWaterMeterReading] WITH NOCHECK
    ADD CONSTRAINT [FK_trnWaterMeterReading_ToTable_2] FOREIGN KEY ([waterMeterTypeId]) REFERENCES [dbo].[mstWaterMeterType] ([waterMeterTypeId]);


GO
PRINT N'Creating [dbo].[FK_trnWaterMeterReading_ToTable_3]...';


GO
ALTER TABLE [dbo].[trnWaterMeterReading] WITH NOCHECK
    ADD CONSTRAINT [FK_trnWaterMeterReading_ToTable_3] FOREIGN KEY ([waterLineTypeId]) REFERENCES [dbo].[mstWaterLineType] ([waterLineTypeId]);


GO
PRINT N'Creating [dbo].[FK_trnWaterMeterReading_ToTable_4]...';


GO
ALTER TABLE [dbo].[trnWaterMeterReading] WITH NOCHECK
    ADD CONSTRAINT [FK_trnWaterMeterReading_ToTable_4] FOREIGN KEY ([waterConnectionStatusId]) REFERENCES [dbo].[enumWaterConnectionStatus] ([waterConnectionStatusId]);


GO
PRINT N'Creating [dbo].[FK_tblLandOwnershipDetail_ToTable_1]...';


GO
ALTER TABLE [dbo].[tblLandOwnershipDetail] WITH NOCHECK
    ADD CONSTRAINT [FK_tblLandOwnershipDetail_ToTable_1] FOREIGN KEY ([landOwnershipTypeId]) REFERENCES [dbo].[enumLandOwnershipType] ([landOwnershipTypeId]);


GO
PRINT N'Creating [dbo].[FK_tblWaterMeterReading_ToTable]...';


GO
ALTER TABLE [dbo].[tblWaterMeterReading] WITH NOCHECK
    ADD CONSTRAINT [FK_tblWaterMeterReading_ToTable] FOREIGN KEY ([waterConnectionId]) REFERENCES [dbo].[mstWaterConnection] ([waterConnectionId]);


GO
PRINT N'Creating [dbo].[FK_tblWaterMeterReading_ToTable_1]...';


GO
ALTER TABLE [dbo].[tblWaterMeterReading] WITH NOCHECK
    ADD CONSTRAINT [FK_tblWaterMeterReading_ToTable_1] FOREIGN KEY ([waterConnectionTypeId]) REFERENCES [dbo].[mstWaterConnectionType] ([waterConnectionTypeId]);


GO
PRINT N'Creating [dbo].[FK_tblWaterMeterReading_ToTable_2]...';


GO
ALTER TABLE [dbo].[tblWaterMeterReading] WITH NOCHECK
    ADD CONSTRAINT [FK_tblWaterMeterReading_ToTable_2] FOREIGN KEY ([waterMeterTypeId]) REFERENCES [dbo].[mstWaterMeterType] ([waterMeterTypeId]);


GO
PRINT N'Creating [dbo].[FK_tblWaterMeterReading_ToTable_3]...';


GO
ALTER TABLE [dbo].[tblWaterMeterReading] WITH NOCHECK
    ADD CONSTRAINT [FK_tblWaterMeterReading_ToTable_3] FOREIGN KEY ([waterLineTypeId]) REFERENCES [dbo].[mstWaterLineType] ([waterLineTypeId]);


GO
PRINT N'Creating [dbo].[FK_tblWaterMeterReading_ToTable_4]...';


GO
ALTER TABLE [dbo].[tblWaterMeterReading] WITH NOCHECK
    ADD CONSTRAINT [FK_tblWaterMeterReading_ToTable_4] FOREIGN KEY ([waterConnectionStatusId]) REFERENCES [dbo].[enumWaterConnectionStatus] ([waterConnectionStatusId]);


GO
-- Refactoring step to update target server with deployed transaction logs
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'bf1fea50-67c8-4457-a713-ccfd1e999a79')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('bf1fea50-67c8-4457-a713-ccfd1e999a79')

GO

GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[trnWaterMeterReading] WITH CHECK CHECK CONSTRAINT [FK_trnWaterMeterReading_ToTable];

ALTER TABLE [dbo].[trnWaterMeterReading] WITH CHECK CHECK CONSTRAINT [FK_trnWaterMeterReading_ToTable_1];

ALTER TABLE [dbo].[trnWaterMeterReading] WITH CHECK CHECK CONSTRAINT [FK_trnWaterMeterReading_ToTable_2];

ALTER TABLE [dbo].[trnWaterMeterReading] WITH CHECK CHECK CONSTRAINT [FK_trnWaterMeterReading_ToTable_3];

ALTER TABLE [dbo].[trnWaterMeterReading] WITH CHECK CHECK CONSTRAINT [FK_trnWaterMeterReading_ToTable_4];

ALTER TABLE [dbo].[tblLandOwnershipDetail] WITH CHECK CHECK CONSTRAINT [FK_tblLandOwnershipDetail_ToTable_1];

ALTER TABLE [dbo].[tblWaterMeterReading] WITH CHECK CHECK CONSTRAINT [FK_tblWaterMeterReading_ToTable];

ALTER TABLE [dbo].[tblWaterMeterReading] WITH CHECK CHECK CONSTRAINT [FK_tblWaterMeterReading_ToTable_1];

ALTER TABLE [dbo].[tblWaterMeterReading] WITH CHECK CHECK CONSTRAINT [FK_tblWaterMeterReading_ToTable_2];

ALTER TABLE [dbo].[tblWaterMeterReading] WITH CHECK CHECK CONSTRAINT [FK_tblWaterMeterReading_ToTable_3];

ALTER TABLE [dbo].[tblWaterMeterReading] WITH CHECK CHECK CONSTRAINT [FK_tblWaterMeterReading_ToTable_4];


GO
PRINT N'Update complete.';


GO