CREATE TABLE [dbo].[tblLandLeaseDemandDetail]
(
	[landLeaseDemandDetailId] BIGINT NOT NULL PRIMARY KEY IDENTITY,   
    [landLeaseId] INT NOT NULL,	
    [demandYear] INT NOT NULL, 
    [demandDays] INT NOT NULL,
    [demandGenerateScheduleId] INT NOT NULL, 
    [installmentAmount] DECIMAL(18, 2) NOT NULL, 
    [demandNoId] BIGINT NOT NULL, 
     [createdBy] INT NOT NULL, 
    [createdOn] DATETIME NOT NULL, 
    [modifiedBy] INT NULL, 
    [modifiedOn] DATETIME NULL, 
    [installmentDate] DATE NOT NULL, 
    CONSTRAINT [FK_tblLandLeaseDemandDetail_ToTable] FOREIGN KEY ([landLeaseId]) REFERENCES [tblLandLease]([landLeaseId]), 
    CONSTRAINT [FK_tblLandLeaseDemandDetail_ToTable_1] FOREIGN KEY ([demandGenerateScheduleId]) REFERENCES [enumDemandGenerateSchedule]([demandGenerateScheduleId]), 
    CONSTRAINT [FK_tblLandLeaseDemandDetail_ToTable_2] FOREIGN KEY ([demandNoId]) REFERENCES [tblDemandNo]([demandNoId]), 
)
