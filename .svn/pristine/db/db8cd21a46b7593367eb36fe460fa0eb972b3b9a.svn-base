CREATE TABLE [dbo].[trnSewerageConnection]
(
	[sewerageConnectionId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [transactionId] BIGINT NOT NULL, 
    [amount] DECIMAL(18, 2) NOT NULL, 
    [mobileNo] VARCHAR(50) NOT NULL, 
    [contactAddress] VARCHAR(300) NOT NULL, 
    [landOwnershipId] INT NOT NULL, 
    [g2cApplicationNo] VARCHAR(300) NULL, 
    [createdBy] INT NOT NULL, 
    [createdOn] DATETIME NOT NULL, 
    [modifiedBy] INT NULL, 
    [modifiedOn] DATETIME NULL, 
    [workLevelId] INT NULL DEFAULT 1, 
    CONSTRAINT [FK_trnSewerageConnection_ToTable] FOREIGN KEY ([transactionId]) REFERENCES [tblTransactionDetail]([transactionId]), 
    CONSTRAINT [FK_trnSewerageConnection_ToTable_1] FOREIGN KEY ([landOwnershipId]) REFERENCES [tblLandOwnershipDetail]([landOwnershipId]), 
    CONSTRAINT [FK_trnSewerageConnection_ToTable_2] FOREIGN KEY ([workLevelId]) REFERENCES [enumWorkLevel]([workLevelId]),
    
)
