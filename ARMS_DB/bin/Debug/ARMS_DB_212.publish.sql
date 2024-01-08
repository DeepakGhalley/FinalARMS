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
PRINT N'Rename refactoring operation with key ac8d4239-b782-44b0-bcae-34fcb5d7e74e is skipped, element [dbo].[tblStallDetail].[stallType] (SqlSimpleColumn) will not be renamed to stallTypeId';


GO
PRINT N'Rename refactoring operation with key 65a94339-85d6-414a-b05a-1f2247c32db2 is skipped, element [dbo].[mstStallType].[Id] (SqlSimpleColumn) will not be renamed to stallTypeId';


GO
PRINT N'Altering Table [dbo].[tblStallDetail]...';


GO
ALTER TABLE [dbo].[tblStallDetail]
    ADD [stallTypeId] INT NULL;


GO
PRINT N'Creating Table [dbo].[mstStallType]...';


GO
CREATE TABLE [dbo].[mstStallType] (
    [stallTypeId] INT           IDENTITY (1, 1) NOT NULL,
    [stallType]   VARCHAR (250) NOT NULL,
    PRIMARY KEY CLUSTERED ([stallTypeId] ASC)
);


GO
PRINT N'Creating Foreign Key [dbo].[FK_tblStallDetail_ToTable_1]...';


GO
ALTER TABLE [dbo].[tblStallDetail] WITH NOCHECK
    ADD CONSTRAINT [FK_tblStallDetail_ToTable_1] FOREIGN KEY ([stallTypeId]) REFERENCES [dbo].[mstStallType] ([stallTypeId]);


GO
-- Refactoring step to update target server with deployed transaction logs
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'ac8d4239-b782-44b0-bcae-34fcb5d7e74e')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('ac8d4239-b782-44b0-bcae-34fcb5d7e74e')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '65a94339-85d6-414a-b05a-1f2247c32db2')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('65a94339-85d6-414a-b05a-1f2247c32db2')

GO

GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[tblStallDetail] WITH CHECK CHECK CONSTRAINT [FK_tblStallDetail_ToTable_1];


GO
PRINT N'Update complete.';


GO