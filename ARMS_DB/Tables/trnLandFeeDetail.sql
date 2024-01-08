CREATE TABLE [dbo].[trnLandFeeDetail]
(
	[landFeeDetailId] INT NOT NULL PRIMARY KEY IDENTITY,     
    [landOwnershipId] INT NOT NULL,
    [landServiceTypeId] INT NOT NULL, 
    [transactionId] BIGINT NOT NULL,
    [createdBy] INT NOT NULL, 
    [createdOn] DATETIME NOT NULL, 
    [modifiedBy] INT NULL, 
    [modifiedOn] DATETIME NULL, 
    [amount] NCHAR(10) NULL, 
    CONSTRAINT [FK_trnLandFeeDetail_ToTable] FOREIGN KEY ([landOwnershipId]) REFERENCES [tblLandOwnershipDetail]([landOwnershipId]), 
    CONSTRAINT [FK_trnLandFeeDetail_ToTable_1] FOREIGN KEY ([landServiceTypeId]) REFERENCES [mstLandServiceType]([landServiceTypeId]), 
    CONSTRAINT [FK_trnLandFeeDetail_ToTable_2] FOREIGN KEY ([transactionId]) REFERENCES [tblTransactionDetail]([transactionId]), 
)
