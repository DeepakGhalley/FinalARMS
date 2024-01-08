CREATE TABLE [dbo].[mstLandServiceType]
(
	[landServiceTypeId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [landServiceType] VARCHAR(150) NOT NULL,
	[isActive] BIT NOT NULL, 
    [createdBy] INT NOT NULL, 
    [createdOn] DATETIME NOT NULL, 
    [modifiedBy] INT NULL, 
    [modifiedOn] DATETIME NULL, 
)
