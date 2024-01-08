CREATE TABLE [dbo].[tblRevenueTransfer]
(
	[revenueTransferId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [revenueTransferAmount] DECIMAL(18, 2) NOT NULL, 
    [revenueTransferDate] DATE NOT NULL, 
    [revenueTakenBy] VARCHAR(250) NOT NULL,
     [remarks] VARCHAR(350) NULL, 
    [createdOn] DATETIME NOT NULL DEFAULT GETDATE(), 
    [createdBy] INT NOT NULL, 
    [modifiedOn] DATETIME NULL, 
    [modifiedBy] INT NULL, 
)
