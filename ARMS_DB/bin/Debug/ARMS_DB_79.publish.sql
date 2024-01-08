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
The column flatNo on table [dbo].[mstBuildingUnitDetail] must be changed from NULL to NOT NULL. If the table contains data, the ALTER script may not work. To avoid this issue, you must add values to this column for all rows or mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.

The type for column flatNo in table [dbo].[mstBuildingUnitDetail] is currently  VARCHAR (50) NULL but is being changed to  VARCHAR (45) NOT NULL. Data loss could occur and deployment may fail if the column contains data that is incompatible with type  VARCHAR (45) NOT NULL.
*/

IF EXISTS (select top 1 1 from [dbo].[mstBuildingUnitDetail])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
/*
The column pLR on table [dbo].[tblLandOwnershipDetail] must be changed from NULL to NOT NULL. If the table contains data, the ALTER script may not work. To avoid this issue, you must add values to this column for all rows or mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.
*/

IF EXISTS (select top 1 1 from [dbo].[tblLandOwnershipDetail])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
PRINT N'Dropping unnamed constraint on [dbo].[mstBuildingUnitDetail]...';


GO
ALTER TABLE [dbo].[mstBuildingUnitDetail] DROP CONSTRAINT [DF__tmp_ms_xx__build__1C0818FF];


GO
PRINT N'Dropping unnamed constraint on [dbo].[mstBuildingUnitDetail]...';


GO
ALTER TABLE [dbo].[mstBuildingUnitDetail] DROP CONSTRAINT [DF__tmp_ms_xx__floor__1CFC3D38];


GO
PRINT N'Dropping unnamed constraint on [dbo].[mstBuildingUnitDetail]...';


GO
ALTER TABLE [dbo].[mstBuildingUnitDetail] DROP CONSTRAINT [DF__tmp_ms_xx__build__1DF06171];


GO
PRINT N'Dropping unnamed constraint on [dbo].[mstBuildingUnitDetail]...';


GO
ALTER TABLE [dbo].[mstBuildingUnitDetail] DROP CONSTRAINT [DF__tmp_ms_xx__floor__1EE485AA];


GO
PRINT N'Dropping unnamed constraint on [dbo].[mstBuildingUnitDetail]...';


GO
ALTER TABLE [dbo].[mstBuildingUnitDetail] DROP CONSTRAINT [DF__tmp_ms_xx__noOfU__1FD8A9E3];


GO
PRINT N'Dropping unnamed constraint on [dbo].[mstBuildingUnitDetail]...';


GO
ALTER TABLE [dbo].[mstBuildingUnitDetail] DROP CONSTRAINT [DF__tmp_ms_xx__floor__20CCCE1C];


GO
PRINT N'Dropping unnamed constraint on [dbo].[mstBuildingUnitDetail]...';


GO
ALTER TABLE [dbo].[mstBuildingUnitDetail] DROP CONSTRAINT [DF__tmp_ms_xx__noOfr__21C0F255];


GO
PRINT N'Dropping unnamed constraint on [dbo].[mstBuildingUnitDetail]...';


GO
ALTER TABLE [dbo].[mstBuildingUnitDetail] DROP CONSTRAINT [DF__tmp_ms_xx__taxPa__22B5168E];


GO
PRINT N'Dropping unnamed constraint on [dbo].[mstBuildingUnitDetail]...';


GO
ALTER TABLE [dbo].[mstBuildingUnitDetail] DROP CONSTRAINT [DF__tmp_ms_xx__unitO__23A93AC7];


GO
PRINT N'Dropping unnamed constraint on [dbo].[mstBuildingUnitDetail]...';


GO
ALTER TABLE [dbo].[mstBuildingUnitDetail] DROP CONSTRAINT [DF__tmp_ms_xx__isMai__249D5F00];


GO
PRINT N'Dropping unnamed constraint on [dbo].[mstBuildingUnitDetail]...';


GO
ALTER TABLE [dbo].[mstBuildingUnitDetail] DROP CONSTRAINT [DF__tmp_ms_xx__creat__25918339];


GO
PRINT N'Dropping unnamed constraint on [dbo].[mstBuildingUnitDetail]...';


GO
ALTER TABLE [dbo].[mstBuildingUnitDetail] DROP CONSTRAINT [DF__tmp_ms_xx__creat__2685A772];


GO
PRINT N'Dropping unnamed constraint on [dbo].[mstBuildingUnitDetail]...';


GO
ALTER TABLE [dbo].[mstBuildingUnitDetail] DROP CONSTRAINT [DF__tmp_ms_xx__modif__2779CBAB];


GO
PRINT N'Dropping unnamed constraint on [dbo].[mstBuildingUnitDetail]...';


GO
ALTER TABLE [dbo].[mstBuildingUnitDetail] DROP CONSTRAINT [DF__tmp_ms_xx__modif__286DEFE4];


GO
PRINT N'Dropping unnamed constraint on [dbo].[mstBuildingUnitDetail]...';


GO
ALTER TABLE [dbo].[mstBuildingUnitDetail] DROP CONSTRAINT [DF__tmp_ms_xx__trans__2962141D];


GO
PRINT N'Dropping [dbo].[FK_mstBuildingUnitDetail_ToTable]...';


GO
ALTER TABLE [dbo].[mstBuildingUnitDetail] DROP CONSTRAINT [FK_mstBuildingUnitDetail_ToTable];


GO
PRINT N'Dropping [dbo].[FK_mstBuildingUnitDetail_ToTable_1]...';


GO
ALTER TABLE [dbo].[mstBuildingUnitDetail] DROP CONSTRAINT [FK_mstBuildingUnitDetail_ToTable_1];


GO
PRINT N'Dropping [dbo].[FK_mstBuildingUnitDetail_ToTable_2]...';


GO
ALTER TABLE [dbo].[mstBuildingUnitDetail] DROP CONSTRAINT [FK_mstBuildingUnitDetail_ToTable_2];


GO
PRINT N'Dropping [dbo].[FK_mstBuildingUnitDetail_ToTable_3]...';


GO
ALTER TABLE [dbo].[mstBuildingUnitDetail] DROP CONSTRAINT [FK_mstBuildingUnitDetail_ToTable_3];


GO
PRINT N'Dropping [dbo].[FK_mstBuildingUnitDetail_ToTable_4]...';


GO
ALTER TABLE [dbo].[mstBuildingUnitDetail] DROP CONSTRAINT [FK_mstBuildingUnitDetail_ToTable_4];


GO
PRINT N'Starting rebuilding table [dbo].[mstBuildingUnitDetail]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_mstBuildingUnitDetail] (
    [buildingUnitDetailId]  INT             IDENTITY (1, 1) NOT NULL,
    [buildingDetailId]      INT             NOT NULL,
    [buildingUnitClassId]   INT             DEFAULT NULL NOT NULL,
    [floorNameId]           INT             DEFAULT NULL NOT NULL,
    [buildingUnitUseTypeId] INT             DEFAULT NULL NOT NULL,
    [floorNo]               VARCHAR (45)    DEFAULT NULL NOT NULL,
    [flatNo]                VARCHAR (45)    DEFAULT NULL NOT NULL,
    [noOfUnit]              INT             DEFAULT '1' NULL,
    [floorArea]             DECIMAL (10, 2) DEFAULT NULL NOT NULL,
    [noOfrooms]             INT             DEFAULT NULL NOT NULL,
    [taxPayerId]            INT             DEFAULT NULL NULL,
    [unitOwnerTypeId]       INT             DEFAULT NULL NOT NULL,
    [isMainOwner]           BIT             DEFAULT NULL NOT NULL,
    [createdBy]             INT             DEFAULT NULL NULL,
    [createdOn]             DATE            DEFAULT NULL NULL,
    [modifiedBy]            INT             DEFAULT NULL NULL,
    [modifiedOn]            DATE            DEFAULT NULL NULL,
    [transferStatusId]      TINYINT         DEFAULT NULL NULL,
    PRIMARY KEY CLUSTERED ([buildingUnitDetailId] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[mstBuildingUnitDetail])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_mstBuildingUnitDetail] ON;
        INSERT INTO [dbo].[tmp_ms_xx_mstBuildingUnitDetail] ([buildingUnitDetailId], [buildingDetailId], [buildingUnitClassId], [floorNameId], [buildingUnitUseTypeId], [floorNo], [noOfUnit], [floorArea], [noOfrooms], [taxPayerId], [unitOwnerTypeId], [isMainOwner], [createdBy], [createdOn], [modifiedBy], [modifiedOn], [transferStatusId], [flatNo])
        SELECT   [buildingUnitDetailId],
                 [buildingDetailId],
                 [buildingUnitClassId],
                 [floorNameId],
                 [buildingUnitUseTypeId],
                 [floorNo],
                 [noOfUnit],
                 [floorArea],
                 [noOfrooms],
                 [taxPayerId],
                 [unitOwnerTypeId],
                 [isMainOwner],
                 [createdBy],
                 [createdOn],
                 [modifiedBy],
                 [modifiedOn],
                 [transferStatusId],
                 [flatNo]
        FROM     [dbo].[mstBuildingUnitDetail]
        ORDER BY [buildingUnitDetailId] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_mstBuildingUnitDetail] OFF;
    END

DROP TABLE [dbo].[mstBuildingUnitDetail];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_mstBuildingUnitDetail]', N'mstBuildingUnitDetail';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Altering [dbo].[tblLandOwnershipDetail]...';


GO
ALTER TABLE [dbo].[tblLandOwnershipDetail] ALTER COLUMN [pLR] DECIMAL (10, 2) NOT NULL;


GO
PRINT N'Creating [dbo].[FK_mstBuildingUnitDetail_ToTable]...';


GO
ALTER TABLE [dbo].[mstBuildingUnitDetail] WITH NOCHECK
    ADD CONSTRAINT [FK_mstBuildingUnitDetail_ToTable] FOREIGN KEY ([buildingDetailId]) REFERENCES [dbo].[mstBuildingDetail] ([buildingDetailId]);


GO
PRINT N'Creating [dbo].[FK_mstBuildingUnitDetail_ToTable_1]...';


GO
ALTER TABLE [dbo].[mstBuildingUnitDetail] WITH NOCHECK
    ADD CONSTRAINT [FK_mstBuildingUnitDetail_ToTable_1] FOREIGN KEY ([buildingUnitUseTypeId]) REFERENCES [dbo].[mstBuildingUnitUseType] ([buildingUnitUseTypeId]);


GO
PRINT N'Creating [dbo].[FK_mstBuildingUnitDetail_ToTable_2]...';


GO
ALTER TABLE [dbo].[mstBuildingUnitDetail] WITH NOCHECK
    ADD CONSTRAINT [FK_mstBuildingUnitDetail_ToTable_2] FOREIGN KEY ([floorNameId]) REFERENCES [dbo].[mstFloorName] ([floorNameId]);


GO
PRINT N'Creating [dbo].[FK_mstBuildingUnitDetail_ToTable_3]...';


GO
ALTER TABLE [dbo].[mstBuildingUnitDetail] WITH NOCHECK
    ADD CONSTRAINT [FK_mstBuildingUnitDetail_ToTable_3] FOREIGN KEY ([buildingUnitClassId]) REFERENCES [dbo].[mstBuildingUnitClass] ([buildingUnitClassId]);


GO
PRINT N'Creating [dbo].[FK_mstBuildingUnitDetail_ToTable_4]...';


GO
ALTER TABLE [dbo].[mstBuildingUnitDetail] WITH NOCHECK
    ADD CONSTRAINT [FK_mstBuildingUnitDetail_ToTable_4] FOREIGN KEY ([unitOwnerTypeId]) REFERENCES [dbo].[enumUnitOwnerType] ([unitOwnerTypeId]);


GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[mstBuildingUnitDetail] WITH CHECK CHECK CONSTRAINT [FK_mstBuildingUnitDetail_ToTable];

ALTER TABLE [dbo].[mstBuildingUnitDetail] WITH CHECK CHECK CONSTRAINT [FK_mstBuildingUnitDetail_ToTable_1];

ALTER TABLE [dbo].[mstBuildingUnitDetail] WITH CHECK CHECK CONSTRAINT [FK_mstBuildingUnitDetail_ToTable_2];

ALTER TABLE [dbo].[mstBuildingUnitDetail] WITH CHECK CHECK CONSTRAINT [FK_mstBuildingUnitDetail_ToTable_3];

ALTER TABLE [dbo].[mstBuildingUnitDetail] WITH CHECK CHECK CONSTRAINT [FK_mstBuildingUnitDetail_ToTable_4];


GO
PRINT N'Update complete.';


GO
