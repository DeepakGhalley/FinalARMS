CREATE TABLE [dbo].[tblDemandCancel]
(
	[demandCancelId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [demandNoId] BIGINT NOT NULL, 
    [totalCancelAmount] DECIMAL(18, 2) NOT NULL,
    [remarks] VARCHAR(300) NOT NULL, 
    [createdBy] INT NOT NULL, 
    [createdOn] DATETIME NOT NULL, 
    [modifiedBy] INT NULL, 
    [modifiedOn] DATETIME NULL, 
    CONSTRAINT [FK_tblDemandCancel_ToTable] FOREIGN KEY ([demandNoId]) REFERENCES [tblDemandNo]([demandNoId]), 
)
