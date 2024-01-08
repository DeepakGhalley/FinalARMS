CREATE TABLE [dbo].[mstParkingZone]
(
	[parkingZoneId] INT NOT NULL PRIMARY KEY IDENTITY,
    parkingzoneName VARCHAR(250) NOT NULL,
    parkingzoneDesc VARCHAR(250) NOT NULL,
    [isActive] BIT NOT NULL, 
    [createdBy] INT NOT NULL, 
    [createdOn] DATETIME NOT NULL, 
    [modifiedBy] INT NULL, 
    [modifiedOn] DATETIME NULL, 
)
