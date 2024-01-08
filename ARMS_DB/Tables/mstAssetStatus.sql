create TABLE [dbo].[mstAssetStatus]
(
	[assetStatusId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [assetStatus] VARCHAR(100) NOT NULL, 
    [statusDescription] VARCHAR(250) NOT NULL, 
    [isActive] BIT NOT NULL, 
    [createdBy] INT NOT NULL, 
    [createdOn] DATETIME NOT NULL, 
    [modifiedBy] INT NULL, 
    [modifiedOn] DATETIME NULL
)
