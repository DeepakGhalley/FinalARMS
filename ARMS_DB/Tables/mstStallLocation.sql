CREATE TABLE [dbo].[mstStallLocation]
(
	[stallLocationId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [stallLocation] VARCHAR(300) NOT NULL,
    [stallLocationDetail] VARCHAR(300) NOT NULL,
	[isActive] [bit] NOT NULL,
	[createdOn] [datetime] NOT NULL,
	[createdBy] [int] NOT NULL,
	[modifiedOn] [datetime] NULL,
	[modifiedBy] [int] NULL,
)
