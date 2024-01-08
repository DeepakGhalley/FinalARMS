CREATE TABLE [dbo].[mstDesignation]
(
	[designationId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [designation] VARCHAR(250) NOT NULL, 
    [sectionId] INT NOT NULL,
    [isActive] BIT NOT NULL, 
    [createdBy] INT NOT NULL, 
    [createdOn] DATETIME NOT NULL, 
    [modifiedBy] INT NULL, 
    [modifiedOn] DATETIME NULL, 
    CONSTRAINT [FK_mstDesignation_ToTable] FOREIGN KEY ([sectionId]) REFERENCES [mstSection]([sectionId])
)
