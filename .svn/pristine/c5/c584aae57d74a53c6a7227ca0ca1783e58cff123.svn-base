CREATE TABLE [dbo].[tblEsakorTransaction]
(
	[esakorTransactionId] [bigint] NOT NULL IDENTITY,	
	[transactionNo] [varchar](150) NOT NULL,
	[transactionApproveDate] DATE NOT NULL, 
	[transactorType] VARCHAR(50) NOT NULL,
	[transactionType] [varchar](150) NOT NULL,
	[previousPlotId] [varchar](50) NOT NULL,
	[previousThramNo] [varchar](50) NOT NULL,
	[precinct] [varchar](300) NOT NULL,
	[totalArea] [decimal](18, 2) NOT NULL,
	[transferorCid] [varchar](11) NOT NULL,
	[transferorName] [varchar](250) NOT NULL,
	[tranferorOwnershipType] VARCHAR(150) NOT NULL, 
	[tranferorNetArea] [decimal](18, 2) NOT NULL,
	[tranferorPLR] [decimal](18, 2) NOT NULL,
	[transfereeCid] [varchar](11) NULL,
	[transfereeName] [varchar](250) NULL,
	[tranfereeOwnershipType] VARCHAR(150) NULL, 
	[transfererorPlotId] VARCHAR(50) NULL, 
	[transferorThramNo] VARCHAR(50) NULL, 
	[transferereePlotId] VARCHAR(50) NULL, 
    [transferereeThramNo] VARCHAR(50) NULL, 
	[transfereeNetArea] [decimal](18, 2) NULL,
	[transfereePLR] [decimal](18, 2) NULL,
	[createdOn] [datetime] NOT NULL DEFAULT getdate(),   
	[approvalStatus] BIT NULL , 	  
    [approvedOrRejectOn] DATETIME NULL, 
    [approvedRejectedBy] INT NULL, 
  
    
    CONSTRAINT [PK_tblEsakorTransaction] PRIMARY KEY ([esakorTransactionId]),
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Transferor/Transferee',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'tblEsakorTransaction',
    @level2type = N'COLUMN',
    @level2name = N'transactorType'