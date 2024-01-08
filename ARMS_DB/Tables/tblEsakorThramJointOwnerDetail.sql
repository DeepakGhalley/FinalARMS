CREATE TABLE [dbo].[tblEsakorThramJointOwnerDetail]
(
	[eSakorThramOwnerDetailId] INT NOT NULL PRIMARY KEY, 
    [applicationId] BIGINT NOT NULL, 
    [transactionType] VARCHAR(150) NOT NULL,
    [thramNo] VARCHAR(100) NOT NULL, 
    [ownerCid] VARCHAR(100) NOT NULL, 
    [ownName] VARCHAR(250) NOT NULL, 
    [ownerStatus] VARCHAR(250) NULL, 
    [createdOn] [datetime] NOT NULL DEFAULT getdate(),   
	[approvalStatus] BIT NULL , 	  
    [approvedOrRejectOn] DATETIME NULL, 
    [approvedRejectedBy] INT NULL, 
    [mobileNo] NCHAR(10) NULL, 
    [email] NCHAR(10) NULL, 
    [transactionFee] NCHAR(10) NULL, 
)
