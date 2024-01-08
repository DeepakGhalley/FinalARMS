CREATE TABLE [dbo].[tblParkingfeeDetail]
(
	[parkingFeeDetailId] INT NOT NULL PRIMARY KEY IDENTITY,
    [parkingZoneId] INT NOT NULL, 
	[taxPayerId] INT NOT NULL, 
    [billingScheduleId] INT NOT NULL,  
    [installmentAmount] DECIMAL(18, 2) NULL, 
    [remarks] VARCHAR(350) NULL,
	[isActive] [bit] NOT NULL DEFAULT 0,
    [terminateDate] DATE NULL, 
    [terminateReason] VARCHAR(250) NULL, 
    [terminatedBy] INT NULL, 
    [createdBy] INT NOT NULL, 
    [createdOn] DATETIME NOT NULL, 
    [modifiedBy] INT NULL, 
    [modifiedOn] DATETIME NULL, 
    CONSTRAINT [FK_tblParkingfeeDetail_ToTable] FOREIGN KEY ([parkingZoneId]) REFERENCES [mstParkingZone]([parkingZoneId]), 
    CONSTRAINT [FK_tblParkingfeeDetail_ToTable_1] FOREIGN KEY ([billingScheduleId]) REFERENCES [enumBillingSchedule]([billingScheduleId]), 
    CONSTRAINT [FK_tblParkingfeeDetail_ToTable_2] FOREIGN KEY ([taxPayerId]) REFERENCES [mstTaxPayerProfile]([taxPayerId]), 
    
)
