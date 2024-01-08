CREATE TABLE [dbo].[tblParkingFeeDemandDetail]
(
	[parkingDemandDetailId] BIGINT NOT NULL PRIMARY KEY IDENTITY,   
    [parkingFeeDetailId] INT NOT NULL,	
    [demandYear] INT NOT NULL, 
    [demandGenerateScheduleId] INT NOT NULL,   
    [demandNoId] BIGINT NOT NULL,    
    [installmentAmount] DECIMAL(18, 2) NOT NULL, 
    [installmentDate] DATETIME NOT NULL, 
    [demandDays] INT NOT NULL, 
    [createdBy] INT NOT NULL, 
    [createdOn] DATETIME NOT NULL, 
    [modifiedBy] INT NULL, 
    [modifiedOn] DATETIME NULL, 

    CONSTRAINT [FK_tblParkingFeeDemandDetail_ToTable] FOREIGN KEY ([parkingFeeDetailId]) REFERENCES [tblParkingfeeDetail]([parkingFeeDetailId]), 
    CONSTRAINT [FK_tblParkingFeeDemandDetail_ToTable_1] FOREIGN KEY ([demandGenerateScheduleId]) REFERENCES [enumDemandGenerateSchedule]([demandGenerateScheduleId]), 
    CONSTRAINT [FK_tblParkingFeeDemandDetail_ToTable_2] FOREIGN KEY ([demandNoId]) REFERENCES [tblDemandNo](demandNoId), 
)
