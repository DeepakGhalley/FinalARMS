CREATE TABLE [dbo].[tblOpeningBalance]
(
	[openingBalanceId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [particular] VARCHAR(300) NULL, 
    [amount] DECIMAL(18, 2) NULL, 
    [remarks] VARCHAR(300) NULL, 
    [openingBalanceCarriedOn] DATETIME NULL,
    [createdOn] DATETIME NOT NULL DEFAULT GETDATE(), 
    [createdBy] INT NOT NULL, 
    [modifiedOn] DATETIME NULL, 
    [modifiedBy] INT NULL, 
)
