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
PRINT N'Starting rebuilding table [dbo].[tbl_menu]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_tbl_menu] (
    [menu_id]         INT           NOT NULL,
    [menu_name]       VARCHAR (150) NOT NULL,
    [menu_parent_id]  INT           NOT NULL,
    [orderFor]        INT           DEFAULT 1 NULL,
    [menuFor]         INT           NULL,
    [menuSequence]    INT           NULL,
    [isactive]        INT           NOT NULL,
    [area_name]       VARCHAR (150) NULL,
    [controller_name] VARCHAR (150) NULL,
    [action_name]     VARCHAR (150) NULL,
    [menuIconName]    VARCHAR (150) NULL,
    CONSTRAINT [tmp_ms_xx_constraint_PK_tbl_menu1] PRIMARY KEY CLUSTERED ([menu_id] ASC) ON [PRIMARY]
) ON [PRIMARY];

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[tbl_menu])
    BEGIN
        INSERT INTO [dbo].[tmp_ms_xx_tbl_menu] ([menu_id], [menu_name], [menu_parent_id], [menuFor], [menuSequence], [isactive], [area_name], [controller_name], [action_name], [menuIconName])
        SELECT   [menu_id],
                 [menu_name],
                 [menu_parent_id],
                 [menuFor],
                 [menuSequence],
                 [isactive],
                 [area_name],
                 [controller_name],
                 [action_name],
                 [menuIconName]
        FROM     [dbo].[tbl_menu]
        ORDER BY [menu_id] ASC;
    END

DROP TABLE [dbo].[tbl_menu];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_tbl_menu]', N'tbl_menu';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_PK_tbl_menu1]', N'PK_tbl_menu', N'OBJECT';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Refreshing [dbo].[sp_populatemenu]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[sp_populatemenu]';


GO
PRINT N'Refreshing [dbo].[sp_populatemenusByRoleID]...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[sp_populatemenusByRoleID]';


GO
PRINT N'Update complete.';


GO
