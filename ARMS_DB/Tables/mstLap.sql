CREATE TABLE [dbo].[mstLap]
(
	[lapId] INT NOT NULL PRIMARY KEY IDENTITY,
	[lapName] VARCHAR(250) NOT NULL, 
    [lapDescription] VARCHAR(300) NOT NULL, 
	[isActive] BIT NOT NULL, 
    [createdBy] INT NOT NULL, 
    [createdOn] DATETIME NOT NULL, 
    [modifiedBy] INT NULL, 
    [modifiedOn] DATETIME NULL, 
)
