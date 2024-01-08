CREATE TABLE [dbo].[mstBuildingUnitClass]
(
	[buildingUnitClassId] INT NOT NULL PRIMARY KEY IDENTITY,	
	[buildingUnitClassName] [varchar](45) NOT NULL,
	[buildingUnitClassDescription] [varchar](100) NULL,
	[isActive] [bit] NOT NULL,
	[createdOn] [date] NOT NULL,
	[createdBy] [int] NOT NULL,
	[modifiedOn] [datetime2](0) NULL,
	[modifiedBy] [int] NULL,
)
