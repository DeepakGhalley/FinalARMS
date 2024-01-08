CREATE TABLE [dbo].[enumDemandGenerateSchedule]
(
	[demandGenerateScheduleId] INT NOT NULL PRIMARY KEY, 
    [demandGenerateSchedule] VARCHAR(250) NOT NULL, 
    [billingScheduleId] INT NOT NULL, 
    CONSTRAINT [FK_enumDemandGenerateSchedule_ToTable] FOREIGN KEY ([billingScheduleId]) REFERENCES [enumBillingSchedule]([billingScheduleId])
)
