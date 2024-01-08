CREATE TABLE [dbo].[tblHouseRentPeriod]
(
	[houseRentPeriodId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [houseAllocationId] INT NOT NULL,
    [startDate] DATE NOT NULL,
    [EndDate] DATE NOT NULL,
    [remarks] VARCHAR(250) NULL, 
    [createdBy] INT NOT NULL, 
    [createdOn] DATETIME NOT NULL, 
    [modifiedBy] INT NULL, 
    [modifiedOn] DATETIME NULL, 
    CONSTRAINT [FK_tblHouseRentPeriod_ToTable] FOREIGN KEY ([houseAllocationId]) REFERENCES [tblHouseAllocation]([houseAllocationId]), 
)
