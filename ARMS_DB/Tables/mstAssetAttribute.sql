CREATE TABLE [dbo].[mstAssetAttribute]
(
    [assetAttributeId] INT NOT NULL PRIMARY KEY IDENTITY,
    [parentAttributeId] int NOT NULL,
	[attributeName] VARCHAR(250) NOT NULL, 
    [attributeDescription] VARCHAR(350)  NULL, 
    ValueRequired BIT NOT NULL, 
    [isActive] BIT NOT NULL, 
    [createdBy] INT NOT NULL, 
    [createdOn] DATETIME NOT NULL, 
    [modifiedBy] INT NULL, 
    [modifiedOn] DATETIME NULL, 
    CONSTRAINT [FK_mstAttribute_ToTable] FOREIGN KEY ([parentAttributeId]) REFERENCES [mstParentAttribute]([parentAttributeId]), 
)
