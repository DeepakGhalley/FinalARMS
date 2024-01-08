CREATE TABLE [dbo].[mstTransactionTypeTaxMap]
(
	[transactionTypeTaxMapId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [transactionTypeId] INT NOT NULL, 
    [taxId] INT NOT NULL,
    [isActive] BIT NOT NULL, 
    [createdBy] INT NOT NULL, 
    [createdOn] DATETIME NOT NULL, 
    [modifiedBy] INT NULL, 
    [modifiedOn] DATETIME NULL, 
    CONSTRAINT [FK_mstTransactionTypeTaxMap_ToTable] FOREIGN KEY ([transactionTypeId]) REFERENCES [mstTransactionType]([transactionTypeId]), 
    CONSTRAINT [FK_mstTransactionTypeTaxMap_ToTable_1] FOREIGN KEY ([taxId]) REFERENCES [mstTaxMaster]([taxId]),

)
