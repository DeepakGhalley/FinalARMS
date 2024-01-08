CREATE TABLE [dbo].[mstDetailTechnicalAttribute]
(
	[detailTechnicalAttributeId] INT NOT NULL PRIMARY KEY IDENTITY,
    [technicalAttributeId] int NOT NULL,
	[detailTechnicalAttribute] VARCHAR(250) NOT NULL, 
    [detailTechnicalAttributeDescription] VARCHAR(350)  NULL, 
    [isActive] BIT NOT NULL, 
    [createdBy] INT NOT NULL, 
    [createdOn] DATETIME NOT NULL, 
    [modifiedBy] INT NULL, 
    [modifiedOn] DATETIME NULL, 
    CONSTRAINT [FK_mstDetailTechnicalAttribute_ToTable] FOREIGN KEY ([technicalAttributeId]) REFERENCES [mstTechnicalAttribute]([technicalAttributeId]) 
)

