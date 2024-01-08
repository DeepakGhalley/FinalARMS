CREATE TABLE [dbo].[tblOccupancyCertificateUnitMap]
(
	[occupancyCertificateUnitMapId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [occupancyCertificateApplicationId] INT NULL,
	[buildingUnitDetailId] INT NULL
)
