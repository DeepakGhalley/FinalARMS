CREATE TABLE [dbo].[tblStallDetailDemand]
(
	[stallDemandDetailId] BIGINT NOT NULL PRIMARY KEY IDENTITY,   
    [stallAllocationId] INT NOT NULL,	
    [demandYear] INT NOT NULL, [demandDays] INT NOT NULL,
    [demandGenerateScheduleId] INT NOT NULL,   
    [demandNoId] BIGINT NOT NULL,    
    [amount] DECIMAL(18, 2) NOT NULL, 
    [installmentDate] DATETIME NOT NULL, 
    [createdBy] INT NOT NULL, 
    [createdOn] DATETIME NOT NULL, 
    [modifiedBy] INT NULL, 
    [modifiedOn] DATETIME NULL, 
    [stallTypeId] INT NOT NULL, 
    CONSTRAINT [FK_tblStallDetailDemand_ToTable] FOREIGN KEY ([stallAllocationId]) REFERENCES [tblStallAllocation]([stallAllocationId]), 
    CONSTRAINT [FK_tblStallDetailDemand_ToTable_1] FOREIGN KEY ([demandGenerateScheduleId]) REFERENCES [enumDemandGenerateSchedule]([demandGenerateScheduleId]), 
    CONSTRAINT [FK_tblStallDetailDemand_ToTable_2] FOREIGN KEY ([demandNoId]) REFERENCES [tblDemandNo]([demandNoId]), 
    CONSTRAINT [FK_tblStallDetailDemand_ToTable_3] FOREIGN KEY (stallTypeId) REFERENCES [mstStallType](stallTypeId), 
)
