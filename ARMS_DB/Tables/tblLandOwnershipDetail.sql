CREATE TABLE [dbo].[tblLandOwnershipDetail]
(
	[landOwnershipId] INT NOT NULL PRIMARY KEY IDENTITY,	
	[landDetailId] [int] NOT NULL,
	[landOwnershipTypeId] [int] NOT NULL,
	[taxPayerId] [int] NOT NULL,
	[thramNo] [varchar](150) NOT NULL,
	[ownershipPercentage] [decimal](10, 2) NULL,
	[pLR] [decimal](10, 2) NOT NULL,
	[previousTaxPayerId] [int] NULL,
	[createdBy] [int] NOT NULL,
	[createdOn] DATETIME NOT NULL,
	[modifiedBy] [int] NULL,
	[modifiedOn] [datetime] NULL,
	[transactionId] BIGINT NULL, 
    [isActive] BIT NOT NULL DEFAULT 1, 
    [remarks] VARCHAR(MAX) NULL, 
    [lastTaxPaidYear] INT NULL, 
    CONSTRAINT [FK_tblLandOwnershipDetail_ToTable] FOREIGN KEY ([landDetailId]) REFERENCES [mstLandDetail]([landDetailId]), 
    CONSTRAINT [FK_tblLandOwnershipDetail_ToTable_1] FOREIGN KEY ([landOwnershipTypeId]) REFERENCES [enumLandOwnershipType]([landOwnershipTypeId]), 
    CONSTRAINT [FK_tblLandOwnershipDetail_ToTable_2] FOREIGN KEY ([taxPayerId]) REFERENCES [mstTaxPayerProfile]([taxPayerId]), 
    CONSTRAINT [FK_tblLandOwnershipDetail_ToTable_3] FOREIGN KEY ([transactionId]) REFERENCES [tblTransactionDetail]([transactionId]),
	
	
)
