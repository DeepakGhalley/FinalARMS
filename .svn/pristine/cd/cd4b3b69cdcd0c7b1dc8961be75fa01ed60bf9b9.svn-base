CREATE TABLE [dbo].[mstTransactionType]
(	[transactionTypeId] INT NOT NULL PRIMARY KEY IDENTITY,	
	[transactionType] [varchar](250) NOT NULL,
	[transactionTypeDescription] VARCHAR(300) NULL,
	[sectionId] INT NOT NULL, 
    [node] VARCHAR(250) NOT NULL, 
	[isActive] BIT NOT NULL, 	
	[createdOn] [date] NOT NULL,
	[createdBy] [int] NOT NULL,
	[modifiedBy] [int] NULL,
	[modifiedOn] [date] NULL, 
   
    [hasApprovalProcess] BIT NOT NULL, 
    CONSTRAINT [FK_mstTransactionType_ToTable] FOREIGN KEY ([sectionId]) REFERENCES [mstSection]([sectionId]), 
    
   
	
)
