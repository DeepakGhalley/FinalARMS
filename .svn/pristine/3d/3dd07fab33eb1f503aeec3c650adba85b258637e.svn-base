CREATE TABLE [dbo].[tblTransactionDetail]
(
	[transactionId] BIGINT NOT NULL PRIMARY KEY IDENTITY,	
	[transactionTypeId] [int] NOT NULL,
	[workLevelId] [int] NULL,
	[transactionValue] [decimal](10, 2) NULL,
	[remarks] [varchar](450) NULL,
	[taxPayerId] [int] NULL, 
	[createdBy] [int] NULL,
	[createdOn] [date] NOT NULL,
	[modifiedBy] [int] NULL,
	[modifiedOn] [date] NULL,
	
    CONSTRAINT [FK_tblTransactionDetail_ToTable] FOREIGN KEY ([transactionTypeId]) REFERENCES [mstTransactionType]([transactionTypeId]),
	
    CONSTRAINT [FK_tblTransactionDetail_ToTable_7] FOREIGN KEY ([workLevelId]) REFERENCES [enumWorkLevel]([workLevelId]), 
)
