CREATE TABLE [dbo].[tblHouseDetail]
(
	[houseDetailId] INT NOT NULL PRIMARY KEY IDENTITY,
    [houseNo]  VARCHAR(150) NOT NULL,
    [houseAddress]  VARCHAR(350) NOT NULL,
    [remarks] VARCHAR(350) NULL,
	[isActive] BIT NOT NULL, 
    [createdBy] INT NOT NULL, 
    [createdOn] DATETIME NOT NULL, 
    [modifiedBy] INT NULL, 
    [modifiedOn] DATETIME NULL, 
    --CONSTRAINT [FK_tblHouseDetail_ToTable] FOREIGN KEY ([taxPayerId]) REFERENCES [mstTaxPayerProfile]([taxPayerId]), 
    --CONSTRAINT [FK_tblHouseDetail_ToTable_1] FOREIGN KEY ([billingScheduleId]) REFERENCES [enumBillingSchedule]([billingScheduleId]), 
)
