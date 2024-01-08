CREATE TABLE [dbo].[tblDemandLedgerPaymentUpdate]
(
	[paymentUpdateId] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
     [demandId] BIGINT NULL, 
    [ledgerId] BIGINT NULL, 
    [paymentLedgerId] BIGINT NULL, 
    [oldAmount] DECIMAL(18, 2) NULL, 
    [newAmount] DECIMAL(18, 2) NULL,    
    [fileName] VARCHAR(250) NOT NULL,
    [createdBy] INT NOT NULL, 
    [createdOn] DATETIME NOT NULL, 
    CONSTRAINT [FK_tblDemandLedgerPaymentUpdate_ToTable] FOREIGN KEY ([ledgerId]) REFERENCES [tblLedger]([ledgerId]), 
    CONSTRAINT [FK_tblDemandLedgerPaymentUpdate_ToTable_1] FOREIGN KEY ([demandId]) REFERENCES [tblDemand]([demandId]), 
    CONSTRAINT [FK_tblDemandLedgerPaymentUpdate_ToTable_2] FOREIGN KEY ([paymentLedgerId]) REFERENCES [tblPaymentLeger]([paymentLedgerId]), 
    
)
