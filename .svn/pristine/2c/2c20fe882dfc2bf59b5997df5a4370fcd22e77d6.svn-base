CREATE TABLE [dbo].[tblECRenewalDetail]
(
	[ecRenewalId] INT NOT NULL PRIMARY KEY IDENTITY,	
	[ecDetailId] [int] NOT NULL,	
	[ecUseTypeId] [int] NOT NULL,
	[validUpTo] [date] NOT NULL,
	[amount] [decimal](18, 2) NOT NULL,
	[ecRefNo] [varchar](250) NULL,
	[ecSl] [int] NOT NULL,
	[calendarYear] [int] NOT NULL,
	[remarks] [varchar](350) NULL,		
	[createdOn] [date] NOT NULL,
	[createdBy] [int] NOT NULL,
	[modifiedOn] [date] NULL,
	[modifiedBy] [int] NULL, 
    CONSTRAINT [FK_tblECRenewalDetail_ToTable_1] FOREIGN KEY ([ecDetailId]) REFERENCES [tblECdetail]([ecDetailId]), 
    CONSTRAINT [FK_tblECRenewalDetail_ToTable] FOREIGN KEY ([ecUseTypeId]) REFERENCES [enumECUseType]([ecUseTypeId]) 
)
