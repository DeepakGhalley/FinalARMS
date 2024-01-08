CREATE TABLE [dbo].[tblManualReceipt]
(
	[manualReceiptId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [manualTaxName] VARCHAR(350) NOT NULL, 
    [manualReceiptNo] VARCHAR(250) NOT NULL, 
    [receiptDate] DATE NOT NULL,
    [amount] DECIMAL(18, 2) NOT NULL, 
    [collectedBy] VARCHAR(250) NOT NULL, 
    [remarks] VARCHAR(350) NULL, 
    [createdOn] DATETIME NOT NULL  DEFAULT GETDATE(), 
    [createdBy] INT NOT NULL, 
    [modifiedOn] DATETIME NULL, 
    [modifiedBy] INT NULL, 
   

  
)
