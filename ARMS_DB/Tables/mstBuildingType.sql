CREATE TABLE [dbo].[mstBuildingType]
(
	[buildingTypeId] INT NOT NULL PRIMARY KEY IDENTITY,
	[buildingType]  [varchar](145) NOT NULL,
	[isActive] [bit] NOT NULL,
	[createdOn] [datetime] NOT NULL,
	[createdBy] [int] NOT NULL,
	[modifiedOn] [datetime] NULL,
	[modifiedBy] [int] NULL,
)
