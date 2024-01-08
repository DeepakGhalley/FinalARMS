CREATE TABLE [dbo].[tblDeposit]
(
	[depositId] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [paymentLedgerId] BIGINT NULL, 
    [depositAmount] DECIMAL(18, 2) NOT NULL, 
	[paymentFromDate] DATE NOT NULL, 
    [paymentToDate] DATE NOT NULL,
    [depositDate] DATETIME NOT NULL, 
    [paymentStatusId] INT NULL DEFAULT 1 ,
   	[createdOn] [datetime] NOT NULL,
	[createdBy] [int] NOT NULL,
	[modifiedOn] [datetime] NULL,
	[modifiedBy] [int] NULL, 
    CONSTRAINT [FK_tblDeposit_ToTable] FOREIGN KEY ([paymentLedgerId]) REFERENCES [tblPaymentLeger]([paymentLedgerId]), 
    CONSTRAINT [FK_tblDeposit_ToTable_1] FOREIGN KEY ([paymentStatusId]) REFERENCES [enumPaymentStatus]([paymentStatusId]), 
    
  
)
