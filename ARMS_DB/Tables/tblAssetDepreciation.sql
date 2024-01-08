CREATE TABLE [dbo].[tblAssetDepreciation]
(
	[depreciationId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [assetId] INT NOT NULL, 
    [financialYearId] INT NOT NULL, 
    [depreciationTypeId] INT NOT NULL, 
    [depreciationValue] DECIMAL(18, 2) NOT NULL,
     [createdBy] INT NOT NULL, 
    [createdOn] DATETIME NOT NULL, 
    [modifiedBy] INT NULL, 
    [modifiedOn] DATETIME NULL, 
    CONSTRAINT [FK_tblAssetDepreciation_ToTable] FOREIGN KEY ([assetId]) REFERENCES [mstAsset]([assetId]), 
    CONSTRAINT [FK_tblAssetDepreciation_ToTable_1] FOREIGN KEY (depreciationTypeId) REFERENCES [enumDepreciationType](depreciationTypeId), 
    CONSTRAINT [FK_tblAssetDepreciation_ToTable_2] FOREIGN KEY ([financialYearId]) REFERENCES [mstFinancialYear]([financialYearId]),
)
