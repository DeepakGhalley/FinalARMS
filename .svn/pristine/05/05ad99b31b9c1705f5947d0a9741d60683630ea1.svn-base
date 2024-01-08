CREATE TABLE [dbo].[tblMiscellaneousRecord]
(
	[miscellaneousRecordId] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [transactionId] BIGINT NOT NULL, 
    [taxId] INT NOT NULL, 
    [slabId] INT NOT NULL ,
    [name] VARCHAR(250) NOT NULL, 
    [address] VARCHAR(350) NOT NULL, 
    [cid] VARCHAR(50) NULL, 
    [mobileNo] VARCHAR(13) NOT NULL, 
    [quantity] INT NOT NULL, 
    [amount] DECIMAL(18, 2) NOT NULL, 
    [paymentStatus] BIT NOT NULL DEFAULT 0, 
    [createdBy] INT NOT NULL, 
    [createdOn] DATETIME NOT NULL, 
    [modifiedBy] INT NULL, 
    [modifiedOn] DATETIME NULL, 
    CONSTRAINT [FK_tblMiscellaneousRecord_ToTable] FOREIGN KEY (transactionId) REFERENCES [tblTransactionDetail](transactionId), 
    CONSTRAINT [FK_tblMiscellaneousRecord_ToTable_1] FOREIGN KEY ([taxId]) REFERENCES [mstTaxMaster]([taxId]), 
    CONSTRAINT [FK_tblMiscellaneousRecord_ToTable_2] FOREIGN KEY ([slabId]) REFERENCES [mstSlab]([slabId]), 
   
)
