CREATE TABLE [dbo].[mstProcessLevel]
(
	[processLevelId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [transactionTypeId] INT NULL, 
    [process2Approval] BIT NULL, 
   [process3Approval] BIT NULL, 
	[createdOn] [date] NOT NULL,
	[createdBy] [int] NOT NULL,
	[modifiedBy] [int] NULL,
	[modifiedOn] [date] NULL, 
   
    CONSTRAINT [FK_mstProcessLevel_ToTable] FOREIGN KEY ([transactionTypeId]) REFERENCES [mstTransactionType]([transactionTypeId]), 

)
