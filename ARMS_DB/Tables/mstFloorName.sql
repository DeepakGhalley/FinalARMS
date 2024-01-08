CREATE TABLE [dbo].[mstFloorName]
(
	[floorNameId] INT NOT NULL PRIMARY KEY IDENTITY,
	[floorName] [varchar](150) NOT NULL,
	[floorNameDescription] [varchar](245) NULL,
	[isActive] [bit] NOT NULL,
	[createdOn] [datetime] NOT NULL,
	[createdBy] [int] NOT NULL,
	[modifiedOn] [datetime] NULL,
	[modifiedBy] [int] NULL,
)
