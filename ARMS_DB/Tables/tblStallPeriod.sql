CREATE TABLE [dbo].[tblStallPeriod]
(
	[stallPeriodId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [stallAllocationId] INT NOT NULL,
    [startDate] DATE NOT NULL,
    [EndDate] DATE NOT NULL,
    [remarks] VARCHAR(250) NULL, 
    [createdBy] INT NOT NULL, 
    [createdOn] DATETIME NOT NULL, 
    [modifiedBy] INT NULL, 
    [modifiedOn] DATETIME NULL, 
    CONSTRAINT [FK_tblStallPeriod_ToTable] FOREIGN KEY ([stallAllocationId]) REFERENCES [tblStallAllocation]([stallAllocationId]), 
)
