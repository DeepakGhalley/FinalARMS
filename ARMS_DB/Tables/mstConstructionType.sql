CREATE TABLE [dbo].[mstConstructionType]
(
	[constructionTypeId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [constructionType] VARCHAR(150) NOT NULL,
    [constructionTypeDescription] VARCHAR(150)  NULL,
	[isActive] BIT NOT NULL, 
    [createdBy] INT NOT NULL, 
    [createdOn] DATETIME NOT NULL, 
    [modifiedBy] INT NULL, 
    [modifiedOn] DATETIME NULL, 

)
