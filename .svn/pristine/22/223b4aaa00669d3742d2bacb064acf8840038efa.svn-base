CREATE TABLE [dbo].[tblTechnicalInformation]
(
	[techicalInformationId] INT NOT NULL PRIMARY KEY IDENTITY,
      [assetId] INT NOT NULL, 
	[assetAttributeId] INT NOT NULL,   
    [measurementUnitId] INT NOT NULL, 
    [value] VARCHAR(100) NOT NULL, 
    [createdBy] INT NOT NULL, 
    [createdOn] DATETIME NOT NULL, 
    [modifiedBy] INT NULL, 
    [modifiedOn] DATETIME NULL
    CONSTRAINT [FK_tblTechnicalInformation_ToTable] FOREIGN KEY ([assetAttributeId]) REFERENCES [mstAssetAttribute]([assetAttributeId]), 
    CONSTRAINT [FK_tblTechnicalInformation_ToTable_1] FOREIGN KEY ([assetId]) REFERENCES [mstAsset]([assetId]), 
    CONSTRAINT [FK_tblTechnicalInformation_ToTable_2] FOREIGN KEY ([measurementUnitId]) REFERENCES [mstMeasurementUnit]([measurementUnitId]),
)