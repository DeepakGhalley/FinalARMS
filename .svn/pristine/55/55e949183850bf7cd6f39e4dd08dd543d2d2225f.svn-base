CREATE TABLE [dbo].[trnTaxDetail]
(
	[trnTaxDetailId] INT NOT NULL PRIMARY KEY IDENTITY,	
	[taxId] INT NOT NULL, 
    [amount] NCHAR(10) NOT NULL,
	[eSakorTransactionId] VARCHAR(250) NOT NULL, 
	[landTransferTypeId] INT NOT NULL ,
	[createdOn] [date] NOT NULL,
	[createdBy] [int] NOT NULL,
	[modifiedDate] [date] NULL,
	[modifiedBy] [int] NULL, 
    CONSTRAINT [FK_trnTaxDetail_ToTable] FOREIGN KEY ([taxId]) REFERENCES [mstTaxMaster]([taxId]),  
     CONSTRAINT[FK_trnTaxDetail_ToTable_1] FOREIGN KEY ([landTransferTypeId]) REFERENCES [enumLandTransferType]([landTransferTypeId]), 


)
