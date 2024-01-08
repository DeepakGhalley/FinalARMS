CREATE TABLE [dbo].[mstLandUseSubCategory]
(	
	[landUseSubCategoryId] INT NOT NULL PRIMARY KEY IDENTITY,
	[landUseCategoryId] [int] NOT NULL,
	[landUseSubCategory] [varchar](245) NOT NULL,
	[landUseCategoryDescription] [varchar](300) NULL,
	[landTaxId] INT NOT NULL DEFAULT 1, 
    [udTaxId] INT NOT NULL DEFAULT 9, 
	[isActive] [bit] NOT NULL,
	[createdOn] [datetime] NOT NULL,
	[createdBy] [int] NOT NULL,
	[modifiedOn] [datetime] NULL,
	[modifiedBy] [int] NULL, 
    
    CONSTRAINT [FK_mstLandUseSubCategory_ToTable] FOREIGN KEY ([landUseCategoryId]) REFERENCES [mstLandUseCategory]([landUseCategoryId]), 
    CONSTRAINT [FK_mstLandUseSubCategory_ToTable_1] FOREIGN KEY ([landTaxId]) REFERENCES [mstTaxMaster]([TaxId]), 
    CONSTRAINT [FK_mstLandUseSubCategory_ToTable_2] FOREIGN KEY ([udTaxId]) REFERENCES [mstTaxMaster]([TaxId]) 
)
