CREATE TABLE [dbo].[mstLogoUpload]
(
	[logoId] INT NOT NULL PRIMARY KEY IDENTITY,
	[logoName] [varchar](245) NOT NULL,
	[logoPath] [varchar](345) NOT NULL,
	    [isActive] BIT NOT NULL, 
    [createdBy] INT NOT NULL, 
    [createdOn] DATETIME NOT NULL, 
    [modifiedBy] INT NULL, 
    [modifiedOn] DATETIME NULL
)
