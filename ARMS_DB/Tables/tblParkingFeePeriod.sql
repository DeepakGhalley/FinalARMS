CREATE TABLE [dbo].[tblParkingFeePeriod]
(
	[parkingFeePeriodId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [parkingFeeDetailId] INT NOT NULL,
    [startDate] DATE NOT NULL,
    [EndDate] DATE NOT NULL,
    [remarks] VARCHAR(250) NULL, 
    [createdBy] INT NOT NULL, 
    [createdOn] DATETIME NOT NULL, 
    [modifiedBy] INT NULL, 
    [modifiedOn] DATETIME NULL, 
    CONSTRAINT [FK_tblParkingFeePeriod_ToTable] FOREIGN KEY ([parkingFeeDetailId]) REFERENCES [tblParkingfeeDetail]([parkingFeeDetailId]), 
)
