CREATE TABLE [dbo].[mstECApplicantdetail]
(
	[applicantId] INT NOT NULL PRIMARY KEY IDENTITY,
	[cid] [varchar](100) NULL,
	[licenceNo] [varchar](150) NOT NULL,
	[applicantName] [varchar](450) NOT NULL,
	[address] [varchar](450) NOT NULL,
	[postBoxNo] [varchar](145) NULL,
	[contactNo] [varchar](145) NOT NULL,
	[faxNo] [varchar](145) NULL,
	[isActive] BIT NOT NULL,
	[createdOn] [date] NOT NULL,
	[createdBy] [int] NOT NULL,
	[modifiedOn] [date] NULL,
	[modifiedBy] [int] NULL,
	[remarks] [varchar](300) NULL,
)
