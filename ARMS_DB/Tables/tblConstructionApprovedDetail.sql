CREATE TABLE [dbo].[tblConstructionApprovedDetail]
(
	[ConstructionApprovedDetailId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [landOwnershipId] INT NOT NULL, 
    [g2cApplicationNo] VARCHAR(250) NOT NULL,
    [scrutinyFee] DECIMAL(18, 2) NOT NULL, 
    [serviceFee] DECIMAL(18, 2) NOT NULL, 
     [workLevelId] INT NOT NULL, 
     [createdBy] INT NOT NULL, 
    [createdOn] DATETIME NOT NULL, 
    [modifiedBy] INT NULL, 
    [modifiedOn] DATETIME NULL, 
    
   
    CONSTRAINT [FK_tblConstructionApprovedDetail_ToTable] FOREIGN KEY ([landOwnershipId]) REFERENCES [tblLandOwnershipDetail]([landOwnershipId]), 
    CONSTRAINT [FK_tblConstructionApprovedDetail_ToTable_1] FOREIGN KEY ([workLevelId]) REFERENCES [enumWorkLevel]([workLevelId]), 
)
