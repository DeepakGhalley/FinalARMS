CREATE TABLE [dbo].[mstTaxMaster]
(
	[taxId] INT NOT NULL PRIMARY KEY IDENTITY,
    [detailHeadId] [int] NOT NULL,
    [taxName] VARCHAR(350) NOT NULL, 
    [isActive] BIT NOT NULL, 
    [createdBy] INT NOT NULL, 
    [createdOn] DATETIME NOT NULL, 
    [modifiedBy] INT NULL, 
    [modifiedOn] DATETIME NULL, 
    CONSTRAINT [FK_mstTaxMaster_ToTable] FOREIGN KEY ([detailHeadId]) REFERENCES [mstDetailHead]([detailHeadId]), 
    --CONSTRAINT [FK_mstTaxMaster_ToTable_1] FOREIGN KEY ([taxTypeClassificationId]) REFERENCES [mstTaxTypeClassification]([taxTypeClassificationId])
)
