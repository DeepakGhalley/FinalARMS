CREATE TABLE [dbo].[tblStallDetail]
(
    [stallDetailId] INT NOT NULL PRIMARY KEY IDENTITY,
    [stallLocationId] INT NOT NULL,
    [stallNo] VARCHAR(250) NOT NULL, 
    [stallName]  VARCHAR(350) NOT NULL,
    [stallArea] DECIMAL(18, 2) NOT NULL, 
    [remarks] VARCHAR(350) NULL,
	[isActive] BIT NOT NULL, 
    [createdBy] INT NOT NULL, 
    [createdOn] DATETIME NOT NULL, 
    [modifiedBy] INT NULL, 
    [modifiedOn] DATETIME NULL, 
    [stallTypeId] INT NULL, 
    CONSTRAINT [FK_tblStallDetail_ToTable] FOREIGN KEY ([stallLocationId]) REFERENCES [mstStallLocation]([stallLocationId]), 
    CONSTRAINT [FK_tblStallDetail_ToTable_1] FOREIGN KEY ([stallTypeId]) REFERENCES [mstStallType]([stallTypeId]),  
    -- CONSTRAINT [FK_tblStallDetail_ToTable_2] FOREIGN KEY ([rateId]) REFERENCES [mstRate]([rateId]), 
)
