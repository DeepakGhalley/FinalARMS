CREATE TABLE [dbo].[mstAttributeUnitMap]
(
	[attributeUnitMapId] INT NOT NULL PRIMARY KEY IDENTITY,
	[assetAttributeId] int NOT NULL,
    [measurementUnitId] int NOT NULL,
	[attributeUnitMapName] VARCHAR(250) NOT NULL, 
    [attributeUnitMapDescription] VARCHAR(350)  NULL, 
    [isActive] BIT NOT NULL, 
    [createdBy] INT NOT NULL, 
    [createdOn] DATETIME NOT NULL, 
    [modifiedBy] INT NULL, 
    [modifiedOn] DATETIME NULL, 
    CONSTRAINT [FK_mstAttributeUnitMap_ToTable] FOREIGN KEY ([measurementUnitId]) REFERENCES [mstMeasurementUnit]([measurementUnitId]), 
    CONSTRAINT [FK_mstAttributeUnitMap_ToTable_1] FOREIGN KEY ([assetAttributeId]) REFERENCES [mstAssetAttribute]([assetAttributeId]), 
)
