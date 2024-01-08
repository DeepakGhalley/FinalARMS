CREATE TABLE [dbo].[tblUnScheduledParkingRecord]
(
	[UnScheduledParkingRecordId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [cid] VARCHAR(100) NOT NULL,
    [vendorName] VARCHAR(250) NOT NULL, 
    [vendorAddress] VARCHAR(250) NOT NULL, 
    [fromDate] DATE NOT NULL, 
    [toDate] DATE NOT NULL,    
    [amount] DECIMAL(18, 2) NOT NULL, 
    [transactionId] BIGINT NOT NULL, 
    [createdBy] [int] NOT NULL,
	[createdOn] [date] NOT NULL,
	[modifiedBy] [int] NULL,
	[modifiedOn] [date] NULL,
    CONSTRAINT [FK_tblUnScheduledParkingRecord_ToTable] FOREIGN KEY ([transactionId]) REFERENCES [tblTransactionDetail]([transactionId]), 
    
)
