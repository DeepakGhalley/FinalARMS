CREATE TABLE [dbo].[tblBuildingOwnership]
(
	[buildingOwnershipId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [landOwnershipId] INT NOT NULL, 
    [buildingDetailId] INT NOT NULL, 
    [createdBy] [int] NOT NULL,
	[createdOn] DATETIME NOT NULL,
	[modifiedBy] [int] NULL,
	[modifiedOn] [datetime] NULL,
    
    [deletedOn] DATETIME NULL, 
    [deletedBy] INT NULL, 
    CONSTRAINT [FK_tblBuildingOwnership_ToTable] FOREIGN KEY ([landOwnershipId]) REFERENCES [tblLandOwnershipDetail]([landOwnershipId]), 
    CONSTRAINT [FK_tblBuildingOwnership_ToTable_1] FOREIGN KEY ([buildingDetailId]) REFERENCES [mstBuildingDetail]([buildingDetailId])
)
