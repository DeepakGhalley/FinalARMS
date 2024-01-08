CREATE TABLE [dbo].[mstBankBranch]
(
	[bankBranchId] INT NOT NULL PRIMARY KEY IDENTITY,
	[bankId] [int] NOT NULL,
	[branchName] [varchar](145) NOT NULL,
	[branchOfficeAddress] [varchar](245) NULL,
	[phoneNo] [varchar](145) NULL,
	[faxNo] [varchar](145) NULL,
	[contactPerson] [varchar](245) NULL,
	[contactEmail] [varchar](245) NULL,
	[isActive] [bit] NOT NULL,
	[createdOn] [datetime] NOT NULL,
	[createdBy] [int] NOT NULL,
	[modifiedOn] [datetime] NULL,
	[modifiedBy] [int] NULL, 
    CONSTRAINT [FK_mstBankBranch_ToTable] FOREIGN KEY ([bankId]) REFERENCES [mstBank]([bankId]),
)
