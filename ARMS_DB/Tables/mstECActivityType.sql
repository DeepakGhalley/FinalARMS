CREATE TABLE [dbo].[mstECActivityType]
(	
	[ecActivityTypeId] INT NOT NULL PRIMARY KEY IDENTITY,
	[activityType] [varchar](250) NOT NULL,
	[activityDescription] [varchar](245) NULL,
	[isActive] [bit] NOT NULL,
	[createdOn] [datetime] NOT NULL,
	[createdBy] [int] NOT NULL,
	[modifiedOn] [datetime] NULL,
	[modifiedBy] [int] NULL,
)
