CREATE TABLE [dbo].[tblFinancialInformation]
(
	[financialInfoId] [int] IDENTITY(1,1) NOT NULL,
	[assetId] [int] NOT NULL,
	[dateofProcurement] [date] NOT NULL,
	[dateofCommissioning] [date] NOT NULL,
	[usefulLife] [decimal](18, 2) NOT NULL,
	[costofProcurement] [decimal](18, 2) NOT NULL,
	[procurementOrderRefNo] [varchar](250) NOT NULL,
	[procurementOrderDate] [date] NOT NULL,
	[createdBy] [int] NOT NULL,
	[createdOn] [datetime] NOT NULL,
	[modifiedBy] [int] NULL,
	[modifiedOn] [datetime] NULL, 
    CONSTRAINT [PK_tblFinancialInformation] PRIMARY KEY ([financialInfoId]),
)
