CREATE TABLE [dbo].[tblEsakorThramPlotDetail]
(
	[eSakorThramPlotTransactionId] INT NOT NULL PRIMARY KEY IDENTITY , 
    [applicationId] BIGINT NOT NULL, 
    [transactionType] VARCHAR(150) NOT NULL, 
    [thramNo] VARCHAR(100) NOT NULL, 
    [ownerCid] VARCHAR(100) NOT NULL, 
    [ownName] VARCHAR(250) NOT NULL, 
    [ownerType] VARCHAR(250) NOT NULL, 
    [partyType] VARCHAR(150) NULL, 
    [thramStatus] VARCHAR(250) NULL, 
    [plotId] VARCHAR(50) NOT NULL, 
    [netArea] DECIMAL(18, 3) NOT NULL, 
    [precinctName] VARCHAR(250) NOT NULL, 
    [plotStatus] VARCHAR(250) NULL,  
    [createdOn] [datetime] NOT NULL DEFAULT getdate(),   
	[approvalStatus] BIT NULL , 	  
    [approvedOrRejectOn] DATETIME NULL, 
    [approvedRejectedBy] INT NULL, 
    [mobileNo] NCHAR(10) NULL, 
    [email] NCHAR(10) NULL, 
    [transactionFee] NCHAR(10) NULL, 
   
)
