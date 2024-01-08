﻿CREATE TABLE [dbo].[tblPaymentLeger]
(
	[paymentLedgerId] BIGINT NOT NULL PRIMARY KEY IDENTITY,
    [receiptId] BIGINT NOT NULL, 
    [paymentModeId] INT NOT NULL,  
    [amount] DECIMAL(18, 2) NOT NULL,
    [bankBranchId] INT NULL, 
    [paymentModeNo] VARCHAR(250) NULL, 
    [paymentModeDate] DATE NULL,
    [createdBy] INT NOT NULL, 
    [createdOn] DATETIME NOT NULL, 
    [modifiedBy] INT NULL, 
    [modifiedOn] DATETIME NULL,  
    [paymentStatusId] INT NULL DEFAULT 1, 
    [bfsTransactionDetailId] BIGINT NULL, 
    [recordedOn] DATETIME NULL DEFAULT GETDATE()
    --CONSTRAINT [FK_tblPaymentLeger_ToTable] FOREIGN KEY ([transactionId]) REFERENCES [tblTransactionDetail]([transactionId]), 
    CONSTRAINT [FK_tblPaymentLeger_ToTable_1] FOREIGN KEY ([paymentModeId]) REFERENCES [enumPaymentMode]([paymentModeId]), 
    [remarks] VARCHAR(300) NULL, 
    CONSTRAINT [FK_tblPaymentLeger_ToTable_2] FOREIGN KEY ([receiptId]) REFERENCES [tblReceipt]([receiptId]), 
    CONSTRAINT [FK_tblPaymentLeger_ToTable_3] FOREIGN KEY ([bankBranchId]) REFERENCES [mstBankBranch]([bankBranchId]) ,
    --CONSTRAINT [FK_tblPaymentLeger_ToTable_2] FOREIGN KEY ([Column]) REFERENCES [ToTable]([ToTableColumn]),  
    CONSTRAINT [FK_tblPaymentLeger_ToTable] FOREIGN KEY (paymentStatusId) REFERENCES [enumPaymentStatus](paymentStatusId), 
    CONSTRAINT [FK_tblPaymentLeger_ToTable_4] FOREIGN KEY ([bfsTransactionDetailId]) REFERENCES [tblBfsTransactiondetails]([bfsTransactionDetailId]))