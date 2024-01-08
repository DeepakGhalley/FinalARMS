﻿CREATE TABLE [dbo].[mstBuildingClass]
(
	[buildingClassId] INT NOT NULL PRIMARY KEY IDENTITY,	
	[buildingClassName] [varchar](45) NOT NULL,
	[buildingClassDescription] [varchar](100) NULL,
	[isActive] [bit] NOT NULL,
	[createdOn] [date] NOT NULL DEFAULT getDate(),
	[createdBy] [int] NOT NULL,
	[modifiedOn] [datetime2](0) NULL,
	[modifiedBy] [int] NULL,
)