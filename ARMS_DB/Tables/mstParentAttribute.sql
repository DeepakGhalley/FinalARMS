CREATE TABLE [dbo].[mstParentAttribute]
(
	[parentAttributeId] INT NOT NULL PRIMARY KEY IDENTITY,
    [tertiaryAccountHeadId] int NOT NULL,
	[parentAttribute] VARCHAR(250) NOT NULL, 
    [parentAttributeDescription] VARCHAR(350)  NULL, 
    [isActive] BIT NOT NULL, 
    [createdBy] INT NOT NULL, 
    [createdOn] DATETIME NOT NULL, 
    [modifiedBy] INT NULL, 
    [modifiedOn] DATETIME NULL, 
    CONSTRAINT [FK_mstParentAttribute_ToTable] FOREIGN KEY ([tertiaryAccountHeadId]) REFERENCES [mstTertiaryAccountHead]([tertiaryAccountHeadId]), 
   
)
