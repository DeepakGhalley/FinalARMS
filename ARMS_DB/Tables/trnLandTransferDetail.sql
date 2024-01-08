CREATE TABLE [dbo].[trnLandTransferDetail]
(
	[landTransferDetailId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [fromLandOwnershipId] INT NOT NULL, 
    [toTaxPayerIds] VARCHAR(350) NOT NULL,     
    [landDetailId] INT NOT NULL,
	[transactionId] BIGINT NOT NULL, 
    [createdBy] [int] NOT NULL,
	[createdOn] [date] NOT NULL,
	[modifiedBy] [int] NULL,
	[modifiedOn] [datetime] NULL, 
    
    CONSTRAINT [FK_trnLandTransferDetail_ToTable] FOREIGN KEY ([transactionId]) REFERENCES [tblTransactionDetail]([transactionId]), 
    CONSTRAINT [FK_trnLandTransferDetail_ToTable_1] FOREIGN KEY ([landDetailId]) REFERENCES [mstLandDetail]([landDetailId]), 
    CONSTRAINT [FK_trnLandTransferDetail_ToTable_2] FOREIGN KEY ([fromLandOwnershipId]) REFERENCES [tblLandOwnershipDetail]([landOwnershipId]),
	
)
