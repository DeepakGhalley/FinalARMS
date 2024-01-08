CREATE TABLE [dbo].[trnVacuumTankerService]
(
	[vacuumTankerServiceId] INT NOT NULL PRIMARY KEY IDENTITY,
	[transactionId] BIGINT NOT NULL, 
    [landOwnershipId] INT NULL, 
    [noOfTrips] INT NOT NULL,
    [amount] DECIMAL(18, 2) NOT NULL, 
    [contactName] VARCHAR(250) NOT NULL, 
    [mobileNo] VARCHAR(50) NOT NULL, 
    [emailId] VARCHAR(100) NULL, 
    [contactAddress] VARCHAR(300) NOT NULL, 
    [g2cApplicationNo] VARCHAR(300) NULL,     
    [workLevelId] INT NOT NULL, 
    [createdBy] [int] NOT NULL,
	[createdOn] DATETIME NOT NULL,
	[modifiedBy] [int] NULL,
	[modifiedOn] [datetime] NULL,
    CONSTRAINT [FK_trnVacuumTankerService_ToTable] FOREIGN KEY ([transactionId]) REFERENCES [tblTransactionDetail]([transactionId]), 
    CONSTRAINT [FK_trnVacuumTankerService_ToTable_1] FOREIGN KEY ([landOwnershipId]) REFERENCES [tblLandOwnershipDetail]([landOwnershipId]), 
   
)
