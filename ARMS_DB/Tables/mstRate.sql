CREATE TABLE [dbo].[mstRate]
(
	[rateId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [taxId] INT NOT NULL, 
    [slabId] INT NOT NULL, 
    [rate] DECIMAL(18, 3) NOT NULL, 
    [minimumRate] DECIMAL(18, 3) NULL, 
    [effectiveDate] DATE NOT NULL,
    [isActive] BIT NOT NULL, 
    [createdBy] INT NOT NULL, 
    [createdOn] DATETIME NOT NULL, 
    [modifiedBy] INT NULL, 
    [modifiedOn] DATETIME NULL, 
   
    CONSTRAINT [FK_mstRate_ToTable] FOREIGN KEY ([taxId]) REFERENCES [mstTaxMaster]([taxId]), 
    CONSTRAINT [FK_mstRate_ToTable_1] FOREIGN KEY ([slabId]) REFERENCES [mstSlab]([slabId]) 
)
