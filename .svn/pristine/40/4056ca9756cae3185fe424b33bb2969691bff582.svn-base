CREATE TABLE [dbo].[trnConstructionApprovalApplicationFeeDetail]
(
	[constructionApprovalApplicationFeeId] INT NOT NULL PRIMARY KEY IDENTITY,     
    [landOwnershipId] INT NOT NULL, 
	[transactionId] BIGINT NOT NULL,
	[amount] DECIMAL(18, 2) NOT NULL, 	
    [mobileNo] VARCHAR(50) NOT NULL, 
    [email] VARCHAR(300) NULL, 
    [g2cApplicationNo] VARCHAR(150) NOT NULL,    		
	[createdOn] [date] NOT NULL,
	[createdBy] [int] NOT NULL,
	[modifiedOn] [date] NULL,
	[modifiedBy] [int] NULL, 
    
    CONSTRAINT [FK_trnConstructionApprovalApplicationFeeDetail_ToTable] FOREIGN KEY ([landOwnershipId]) REFERENCES [tblLandOwnershipDetail]([landOwnershipId]), 
    CONSTRAINT [FK_trnConstructionApprovalApplicationFeeDetail_ToTable_1] FOREIGN KEY ([transactionId]) REFERENCES [tblTransactionDetail]([transactionId]), 
    
)
