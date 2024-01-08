CREATE TABLE [dbo].[tblReceipt]
(
	[receiptId] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [receiptNo] VARCHAR(250) NOT NULL, 
    [sl] INT NOT NULL, 
    [receiptYear] INT NOT NULL, 
    [createdOn] DATETIME NOT NULL, 
    [createdBy] INT NOT NULL, 
    [recordedOn] DATETIME NULL DEFAULT GETDATE()
)
