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
The type for column modifiedOn in table [dbo].[tblComplainDetail] is currently  DATETIME2 (0) NULL but is being changed to  DATETIME NULL. Data loss could occur and deployment may fail if the column contains data that is incompatible with type  DATETIME NULL.
*/

IF EXISTS (select top 1 1 from [dbo].[tblComplainDetail])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
PRINT N'Rename refactoring operation with key 7645a41b-3d11-456b-b458-c2c2313b633b is skipped, element [dbo].[tblInaccessibleWaterMeterReading].[Id] (SqlSimpleColumn) will not be renamed to InaccessibleWaterMeterReadingId';


GO
PRINT N'Rename refactoring operation with key 0cb19f2e-c460-4174-9874-0f93fc65fe3a is skipped, element [dbo].[tblInaccessibleWaterMeterDetail].[Id] (SqlSimpleColumn) will not be renamed to InaccessibleWaterMeterDetailId';


GO
PRINT N'Rename refactoring operation with key b43e2074-fd94-4c23-ada4-7c7a3c39b641 is skipped, element [dbo].[tblComplainReading].[Id] (SqlSimpleColumn) will not be renamed to complainReadingId';


GO
PRINT N'Dropping Default Constraint unnamed constraint on [dbo].[tblComplainDetail]...';


GO
ALTER TABLE [dbo].[tblComplainDetail] DROP CONSTRAINT [DF__tmp_ms_xx__compl__0268428D];


GO
PRINT N'Dropping Foreign Key [dbo].[FK_tblComplainDetail_ToTable]...';


GO
ALTER TABLE [dbo].[tblComplainDetail] DROP CONSTRAINT [FK_tblComplainDetail_ToTable];


GO
PRINT N'Dropping Foreign Key [dbo].[FK_tblComplainDetail_ToTable_2]...';


GO
ALTER TABLE [dbo].[tblComplainDetail] DROP CONSTRAINT [FK_tblComplainDetail_ToTable_2];


GO
PRINT N'Dropping Foreign Key [dbo].[FK_tblComplainDetail_ToTable_1]...';


GO
ALTER TABLE [dbo].[tblComplainDetail] DROP CONSTRAINT [FK_tblComplainDetail_ToTable_1];


GO
PRINT N'Starting rebuilding table [dbo].[tblComplainDetail]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_tblComplainDetail] (
    [complainDetailId]        BIGINT        IDENTITY (1, 1) NOT NULL,
    [waterConnectionId]       INT           NOT NULL,
    [complainTypeId]          INT           NOT NULL,
    [complainStatusId]        INT           DEFAULT 1 NOT NULL,
    [instruction]             VARCHAR (350) NOT NULL,
    [deadLine ]               DATETIME      NOT NULL,
    [createdOn]               DATE          NOT NULL,
    [createdBy]               INT           NOT NULL,
    [modifiedOn]              DATETIME      NULL,
    [modifiedBy]              INT           NULL,
    [complainReviewedBy]      INT           NULL,
    [complainReviewRemarks]   VARCHAR (300) NULL,
    [complainReviewedOn]      DATETIME      NULL,
    [complainRejectedBy]      INT           NULL,
    [complainRejectRemarks]   VARCHAR (300) NULL,
    [complainRejectedOn]      DATETIME      NULL,
    [complainApprovedBy]      INT           NULL,
    [complainApprovalRemarks] VARCHAR (300) NULL,
    [complainApprovedOn]      DATETIME      NULL,
    PRIMARY KEY CLUSTERED ([complainDetailId] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[tblComplainDetail])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_tblComplainDetail] ON;
        INSERT INTO [dbo].[tmp_ms_xx_tblComplainDetail] ([complainDetailId], [waterConnectionId], [complainTypeId], [complainStatusId], [instruction], [deadLine ], [createdOn], [createdBy], [modifiedOn], [modifiedBy], [complainReviewedBy], [complainReviewRemarks], [complainReviewedOn], [complainRejectedBy], [complainRejectRemarks], [complainRejectedOn], [complainApprovedBy], [complainApprovalRemarks], [complainApprovedOn])
        SELECT   [complainDetailId],
                 [waterConnectionId],
                 [complainTypeId],
                 [complainStatusId],
                 [instruction],
                 [deadLine ],
                 [createdOn],
                 [createdBy],
                 [modifiedOn],
                 [modifiedBy],
                 [complainReviewedBy],
                 [complainReviewRemarks],
                 [complainReviewedOn],
                 [complainRejectedBy],
                 [complainRejectRemarks],
                 [complainRejectedOn],
                 [complainApprovedBy],
                 [complainApprovalRemarks],
                 [complainApprovedOn]
        FROM     [dbo].[tblComplainDetail]
        ORDER BY [complainDetailId] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_tblComplainDetail] OFF;
    END

DROP TABLE [dbo].[tblComplainDetail];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_tblComplainDetail]', N'tblComplainDetail';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Creating Table [dbo].[tblComplainReading]...';


GO
CREATE TABLE [dbo].[tblComplainReading] (
    [complainReadingId] BIGINT   IDENTITY (1, 1) NOT NULL,
    [complainReading]   INT      NOT NULL,
    [complainDetailId]  BIGINT   NOT NULL,
    [createdOn]         DATE     NOT NULL,
    [createdBy]         INT      NOT NULL,
    [modifiedOn]        DATETIME NULL,
    [modifiedBy]        INT      NULL,
    PRIMARY KEY CLUSTERED ([complainReadingId] ASC)
);


GO
PRINT N'Creating Table [dbo].[tblInaccessibleWaterMeterDetail]...';


GO
CREATE TABLE [dbo].[tblInaccessibleWaterMeterDetail] (
    [InaccessibleWaterMeterDetailId] INT           IDENTITY (1, 1) NOT NULL,
    [waterConnectionId]              INT           NOT NULL,
    [readingDate]                    DATE          NOT NULL,
    [remarks]                        VARCHAR (250) NOT NULL,
    [photoUrl]                       VARCHAR (250) NOT NULL,
    [createdOn]                      DATETIME      NOT NULL,
    [createdBy]                      INT           NOT NULL,
    [modifiedOn]                     DATETIME      NULL,
    [modifiedBy]                     INT           NULL,
    PRIMARY KEY CLUSTERED ([InaccessibleWaterMeterDetailId] ASC)
);


GO
PRINT N'Creating Foreign Key [dbo].[FK_tblComplainDetail_ToTable]...';


GO
ALTER TABLE [dbo].[tblComplainDetail] WITH NOCHECK
    ADD CONSTRAINT [FK_tblComplainDetail_ToTable] FOREIGN KEY ([complainTypeId]) REFERENCES [dbo].[enumComplainType] ([complainTypeId]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_tblComplainDetail_ToTable_2]...';


GO
ALTER TABLE [dbo].[tblComplainDetail] WITH NOCHECK
    ADD CONSTRAINT [FK_tblComplainDetail_ToTable_2] FOREIGN KEY ([waterConnectionId]) REFERENCES [dbo].[mstWaterConnection] ([waterConnectionId]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_tblComplainDetail_ToTable_1]...';


GO
ALTER TABLE [dbo].[tblComplainDetail] WITH NOCHECK
    ADD CONSTRAINT [FK_tblComplainDetail_ToTable_1] FOREIGN KEY ([complainStatusId]) REFERENCES [dbo].[enumComplainStatus] ([complainStatusId]);


GO
PRINT N'Creating Foreign Key [dbo].[FK_tblInaccessibleWaterMeterDetail_ToTable]...';


GO
ALTER TABLE [dbo].[tblInaccessibleWaterMeterDetail] WITH NOCHECK
    ADD CONSTRAINT [FK_tblInaccessibleWaterMeterDetail_ToTable] FOREIGN KEY ([waterConnectionId]) REFERENCES [dbo].[mstWaterConnection] ([waterConnectionId]);


GO
-- Refactoring step to update target server with deployed transaction logs
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '7645a41b-3d11-456b-b458-c2c2313b633b')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('7645a41b-3d11-456b-b458-c2c2313b633b')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '0cb19f2e-c460-4174-9874-0f93fc65fe3a')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('0cb19f2e-c460-4174-9874-0f93fc65fe3a')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'b43e2074-fd94-4c23-ada4-7c7a3c39b641')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('b43e2074-fd94-4c23-ada4-7c7a3c39b641')

GO

GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[tblComplainDetail] WITH CHECK CHECK CONSTRAINT [FK_tblComplainDetail_ToTable];

ALTER TABLE [dbo].[tblComplainDetail] WITH CHECK CHECK CONSTRAINT [FK_tblComplainDetail_ToTable_2];

ALTER TABLE [dbo].[tblComplainDetail] WITH CHECK CHECK CONSTRAINT [FK_tblComplainDetail_ToTable_1];

ALTER TABLE [dbo].[tblInaccessibleWaterMeterDetail] WITH CHECK CHECK CONSTRAINT [FK_tblInaccessibleWaterMeterDetail_ToTable];


GO
PRINT N'Update complete.';


GO
