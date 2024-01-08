CREATE TABLE [dbo].[mstSection]
(
	[sectionId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [sectionCode] VARCHAR(50) NOT NULL, 
    [sectionName] VARCHAR(250) NOT NULL, 
    [divisionId] INT NOT NULL,
    [isActive] BIT NOT NULL, 
    [createdBy] INT NOT NULL, 
    [createdOn] DATETIME NOT NULL, 
    [modifiedBy] INT NULL, 
    [modifiedOn] DATETIME NULL, 
    CONSTRAINT [FK_mstSection_ToTable] FOREIGN KEY ([divisionId]) REFERENCES [mstDivision]([divisionId]) 
    )