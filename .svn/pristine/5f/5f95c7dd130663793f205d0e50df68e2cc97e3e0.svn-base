CREATE TABLE [dbo].[tblLandLeasePeriod]
(
	[landLeasePeriodId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [landLeaseId] INT NOT NULL,
    [startDate] DATE NOT NULL,
    [EndDate] DATE NOT NULL,
    [remarks] VARCHAR(250) NULL, 
    [createdBy] INT NOT NULL, 
    [createdOn] DATETIME NOT NULL, 
    [modifiedBy] INT NULL, 
    [modifiedOn] DATETIME NULL, 
   
    CONSTRAINT [FK_tblLandLeasePeriod_ToTable] FOREIGN KEY ([landLeaseId]) REFERENCES [tblLandLease]([landLeaseId]), 
)
