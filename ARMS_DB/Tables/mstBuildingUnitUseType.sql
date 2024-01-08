CREATE TABLE [dbo].[mstBuildingUnitUseType]
(
	[buildingUnitUseTypeId] INT NOT NULL PRIMARY KEY IDENTITY,
	[buildingUnitUseType] [varchar](150) NOT NULL,
	[buildingUnitUseTypeDescription] [varchar](245) NULL,
	[isActive] [bit] NOT NULL,
	[createdOn] [datetime] NOT NULL,
	[createdBy] [int] NOT NULL,
	[modifiedOn] [datetime] NULL,
	[modifiedBy] [int] NULL,
)
