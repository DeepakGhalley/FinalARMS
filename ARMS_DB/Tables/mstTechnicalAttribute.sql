CREATE TABLE [dbo].[mstTechnicalAttribute]
(
	[technicalAttributeId] INT NOT NULL PRIMARY KEY IDENTITY,
    [parentAttributeId] int NOT NULL,
	[technicalAttribute] VARCHAR(250) NOT NULL, 
    [technicalAttributeDescription] VARCHAR(350)  NULL, 
    [isActive] BIT NOT NULL, 
    [createdBy] INT NOT NULL, 
    [createdOn] DATETIME NOT NULL, 
    [modifiedBy] INT NULL, 
    [modifiedOn] DATETIME NULL, 
    CONSTRAINT [FK_mstTechnicalAttribute_ToTable] FOREIGN KEY ([parentAttributeId]) REFERENCES [mstParentAttribute]([parentAttributeId]), 
   )
