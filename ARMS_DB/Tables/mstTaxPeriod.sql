CREATE TABLE [dbo].[mstTaxPeriod]
(
	[taxPeriodId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [transactionTypeId] INT NOT NULL, 
    [calendarYearId] INT NOT NULL, 
    [penaltyOrRate] DECIMAL(18, 2) NOT NULL,
    [effectiveDate] DATE NOT NULL, 
    [createdBy] INT NOT NULL, 
    [createdOn] DATETIME NOT NULL, 
    [modifiedBy] INT NULL, 
    [modifiedOn] DATETIME NULL, 
    CONSTRAINT [FK_mstTaxPeriod_ToTable] FOREIGN KEY ([calendarYearId]) REFERENCES [mstCalendarYear]([calendarYearId]), 
    CONSTRAINT [FK_mstTaxPeriod_ToTable_1] FOREIGN KEY ([transactionTypeId]) REFERENCES [mstTransactionType]([transactionTypeId]) 
)
