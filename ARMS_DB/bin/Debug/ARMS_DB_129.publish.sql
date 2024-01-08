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
PRINT N'Rename refactoring operation with key 8381b46f-5fe7-4929-ae92-01bf5c6ecd13 is skipped, element [dbo].[tblWaterBillChangeHistory].[Id] (SqlSimpleColumn) will not be renamed to waterBillChangeHistoryId';


GO
PRINT N'Rename refactoring operation with key 8f50ebab-94b0-4d1b-8590-a1275db32581 is skipped, element [dbo].[tblWaterBillChangeHistory].[oldPrevReading] (SqlSimpleColumn) will not be renamed to oldPreviousReading';


GO
PRINT N'Rename refactoring operation with key 648814ae-cd7d-430b-aa8c-9dabd46681d5 is skipped, element [dbo].[tblWaterBillChangeHistory].[NewSewerage] (SqlSimpleColumn) will not be renamed to newSewerage';


GO
PRINT N'Rename refactoring operation with key d7d67a6b-fa1e-42de-bb6c-90a4deccb109 is skipped, element [dbo].[tblWaterBillChangeHistory].[[waterMeterReadingId]]] (SqlSimpleColumn) will not be renamed to waterMeterReadingId';


GO
PRINT N'Dropping unnamed constraint on [dbo].[tblWaterMeterReading]...';


GO
ALTER TABLE [dbo].[tblWaterMeterReading] DROP CONSTRAINT [DF__tmp_ms_xx__isRea__59D0414E];


GO
PRINT N'Dropping unnamed constraint on [dbo].[tblWaterMeterReading]...';


GO
ALTER TABLE [dbo].[tblWaterMeterReading] DROP CONSTRAINT [DF__tblWaterM__isAct__5E5FEC41];


GO
PRINT N'Dropping unnamed constraint on [dbo].[tblWaterMeterReading]...';


GO
ALTER TABLE [dbo].[tblWaterMeterReading] DROP CONSTRAINT [DF__tblWaterM__isDis__5F54107A];


GO
PRINT N'Dropping [dbo].[FK_tblWaterMeterReading_ToTable_3]...';


GO
ALTER TABLE [dbo].[tblWaterMeterReading] DROP CONSTRAINT [FK_tblWaterMeterReading_ToTable_3];


GO
PRINT N'Dropping [dbo].[FK_tblWaterMeterReading_ToTable]...';


GO
ALTER TABLE [dbo].[tblWaterMeterReading] DROP CONSTRAINT [FK_tblWaterMeterReading_ToTable];


GO
PRINT N'Dropping [dbo].[FK_tblWaterMeterReading_ToTable_1]...';


GO
ALTER TABLE [dbo].[tblWaterMeterReading] DROP CONSTRAINT [FK_tblWaterMeterReading_ToTable_1];


GO
PRINT N'Dropping [dbo].[FK_tblWaterMeterReading_ToTable_2]...';


GO
ALTER TABLE [dbo].[tblWaterMeterReading] DROP CONSTRAINT [FK_tblWaterMeterReading_ToTable_2];


GO
PRINT N'Dropping [dbo].[FK_tblWaterMeterReading_ToTable_4]...';


GO
ALTER TABLE [dbo].[tblWaterMeterReading] DROP CONSTRAINT [FK_tblWaterMeterReading_ToTable_4];


GO
PRINT N'Starting rebuilding table [dbo].[tblWaterMeterReading]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_tblWaterMeterReading] (
    [waterMeterReadingId]     BIGINT          IDENTITY (1, 1) NOT NULL,
    [waterConnectionId]       INT             NOT NULL,
    [waterConnectionTypeId]   INT             NOT NULL,
    [waterMeterTypeId]        INT             NOT NULL,
    [waterLineTypeId]         INT             NOT NULL,
    [waterConnectionStatusId] INT             NOT NULL,
    [bucid]                   INT             NULL,
    [zoneId]                  INT             NOT NULL,
    [reading]                 INT             NOT NULL,
    [isRead]                  BIT             DEFAULT 0 NOT NULL,
    [previousReading]         INT             NOT NULL,
    [previousReadingDate]     DATE            NOT NULL,
    [readBy]                  INT             NOT NULL,
    [readingDate]             DATE            NOT NULL,
    [noOfUnit]                INT             NOT NULL,
    [consumption]             INT             NOT NULL,
    [standardConsumption]     DECIMAL (18, 2) NULL,
    [isPermanentConnection]   BIT             NOT NULL,
    [sewerage]                BIT             NOT NULL,
    [solidWaste]              BIT             NOT NULL,
    [remarks]                 VARCHAR (250)   NULL,
    [billingAddress]          VARCHAR (350)   NOT NULL,
    [transactionId]           BIGINT          NULL,
    [primaryMobileNo]         VARCHAR (150)   NOT NULL,
    [secondaryMobileNo]       VARCHAR (150)   NULL,
    [isActive]                BIT             DEFAULT 1 NOT NULL,
    [isDisconnected]          BIT             DEFAULT 0 NOT NULL,
    PRIMARY KEY CLUSTERED ([waterMeterReadingId] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[tblWaterMeterReading])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_tblWaterMeterReading] ON;
        INSERT INTO [dbo].[tmp_ms_xx_tblWaterMeterReading] ([waterMeterReadingId], [waterConnectionId], [waterConnectionTypeId], [waterMeterTypeId], [waterLineTypeId], [waterConnectionStatusId], [bucid], [zoneId], [reading], [isRead], [previousReading], [previousReadingDate], [readBy], [readingDate], [noOfUnit], [consumption], [standardConsumption], [isPermanentConnection], [sewerage], [solidWaste], [remarks], [billingAddress], [transactionId], [primaryMobileNo], [secondaryMobileNo], [isActive], [isDisconnected])
        SELECT   [waterMeterReadingId],
                 [waterConnectionId],
                 [waterConnectionTypeId],
                 [waterMeterTypeId],
                 [waterLineTypeId],
                 [waterConnectionStatusId],
                 [bucid],
                 [zoneId],
                 [reading],
                 [isRead],
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
                 [secondaryMobileNo],
                 [isActive],
                 [isDisconnected]
        FROM     [dbo].[tblWaterMeterReading]
        ORDER BY [waterMeterReadingId] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_tblWaterMeterReading] OFF;
    END

DROP TABLE [dbo].[tblWaterMeterReading];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_tblWaterMeterReading]', N'tblWaterMeterReading';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Creating [dbo].[tblWaterBillChangeHistory]...';


GO
CREATE TABLE [dbo].[tblWaterBillChangeHistory] (
    [waterBillChangeHistoryId] INT             IDENTITY (1, 1) NOT NULL,
    [waterMeterReadingId]      BIGINT          NOT NULL,
    [transactionId]            BIGINT          NOT NULL,
    [currentAmount]            DECIMAL (18, 2) NOT NULL,
    [newAmount]                DECIMAL (18, 2) NOT NULL,
    [oldPreviousReading]       INT             NOT NULL,
    [newPreviousReading]       INT             NOT NULL,
    [oldReading]               INT             NOT NULL,
    [newReading]               INT             NOT NULL,
    [oldUnit]                  INT             NOT NULL,
    [newUnit]                  INT             NOT NULL,
    [oldWaterConnectionTypeId] INT             NOT NULL,
    [newWaterConnectionTypeId] INT             NOT NULL,
    [oldStdConsumption]        INT             NOT NULL,
    [newStdConsumption]        INT             NOT NULL,
    [oldSewerage]              BIT             NOT NULL,
    [newSewerage]              BIT             NOT NULL,
    [oldConsumption]           INT             NOT NULL,
    [newConsumption]           INT             NOT NULL,
    [createdOn]                DATETIME        NOT NULL,
    [createdBy]                INT             NOT NULL,
    PRIMARY KEY CLUSTERED ([waterBillChangeHistoryId] ASC)
);


GO
PRINT N'Creating [dbo].[FK_tblWaterMeterReading_ToTable_3]...';


GO
ALTER TABLE [dbo].[tblWaterMeterReading] WITH NOCHECK
    ADD CONSTRAINT [FK_tblWaterMeterReading_ToTable_3] FOREIGN KEY ([waterLineTypeId]) REFERENCES [dbo].[mstWaterLineType] ([waterLineTypeId]);


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
PRINT N'Creating [dbo].[FK_tblWaterMeterReading_ToTable_4]...';


GO
ALTER TABLE [dbo].[tblWaterMeterReading] WITH NOCHECK
    ADD CONSTRAINT [FK_tblWaterMeterReading_ToTable_4] FOREIGN KEY ([waterConnectionStatusId]) REFERENCES [dbo].[enumWaterConnectionStatus] ([waterConnectionStatusId]);


GO
PRINT N'Creating [dbo].[FK_tblWaterBillChangeHistory_ToTable]...';


GO
ALTER TABLE [dbo].[tblWaterBillChangeHistory] WITH NOCHECK
    ADD CONSTRAINT [FK_tblWaterBillChangeHistory_ToTable] FOREIGN KEY ([waterMeterReadingId]) REFERENCES [dbo].[tblWaterMeterReading] ([waterMeterReadingId]);


GO
PRINT N'Creating [dbo].[FK_tblWaterBillChangeHistory_ToTable_1]...';


GO
ALTER TABLE [dbo].[tblWaterBillChangeHistory] WITH NOCHECK
    ADD CONSTRAINT [FK_tblWaterBillChangeHistory_ToTable_1] FOREIGN KEY ([transactionId]) REFERENCES [dbo].[tblTransactionDetail] ([transactionId]);


GO
PRINT N'Creating [dbo].[FK_tblWaterBillChangeHistory_ToTable_2]...';


GO
ALTER TABLE [dbo].[tblWaterBillChangeHistory] WITH NOCHECK
    ADD CONSTRAINT [FK_tblWaterBillChangeHistory_ToTable_2] FOREIGN KEY ([oldWaterConnectionTypeId]) REFERENCES [dbo].[mstWaterConnectionType] ([waterConnectionTypeId]);


GO
PRINT N'Creating [dbo].[FK_tblWaterBillChangeHistory_ToTable_3]...';


GO
ALTER TABLE [dbo].[tblWaterBillChangeHistory] WITH NOCHECK
    ADD CONSTRAINT [FK_tblWaterBillChangeHistory_ToTable_3] FOREIGN KEY ([newWaterConnectionTypeId]) REFERENCES [dbo].[mstWaterConnectionType] ([waterConnectionTypeId]);


GO
-- Refactoring step to update target server with deployed transaction logs
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '8381b46f-5fe7-4929-ae92-01bf5c6ecd13')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('8381b46f-5fe7-4929-ae92-01bf5c6ecd13')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '8f50ebab-94b0-4d1b-8590-a1275db32581')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('8f50ebab-94b0-4d1b-8590-a1275db32581')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '648814ae-cd7d-430b-aa8c-9dabd46681d5')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('648814ae-cd7d-430b-aa8c-9dabd46681d5')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'd7d67a6b-fa1e-42de-bb6c-90a4deccb109')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('d7d67a6b-fa1e-42de-bb6c-90a4deccb109')

GO

GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[tblWaterMeterReading] WITH CHECK CHECK CONSTRAINT [FK_tblWaterMeterReading_ToTable_3];

ALTER TABLE [dbo].[tblWaterMeterReading] WITH CHECK CHECK CONSTRAINT [FK_tblWaterMeterReading_ToTable];

ALTER TABLE [dbo].[tblWaterMeterReading] WITH CHECK CHECK CONSTRAINT [FK_tblWaterMeterReading_ToTable_1];

ALTER TABLE [dbo].[tblWaterMeterReading] WITH CHECK CHECK CONSTRAINT [FK_tblWaterMeterReading_ToTable_2];

ALTER TABLE [dbo].[tblWaterMeterReading] WITH CHECK CHECK CONSTRAINT [FK_tblWaterMeterReading_ToTable_4];

ALTER TABLE [dbo].[tblWaterBillChangeHistory] WITH CHECK CHECK CONSTRAINT [FK_tblWaterBillChangeHistory_ToTable];

ALTER TABLE [dbo].[tblWaterBillChangeHistory] WITH CHECK CHECK CONSTRAINT [FK_tblWaterBillChangeHistory_ToTable_1];

ALTER TABLE [dbo].[tblWaterBillChangeHistory] WITH CHECK CHECK CONSTRAINT [FK_tblWaterBillChangeHistory_ToTable_2];

ALTER TABLE [dbo].[tblWaterBillChangeHistory] WITH CHECK CHECK CONSTRAINT [FK_tblWaterBillChangeHistory_ToTable_3];


GO
PRINT N'Update complete.';


GO