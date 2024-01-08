CREATE TABLE [dbo].[mstPavaRate]
(
	[pavaRateId] INT NOT NULL PRIMARY KEY IDENTITY,
    [landUseSubCategoryId] [int] NOT NULL,
	[landValue] [decimal](18, 2) NOT NULL,
	[applicableDate] [date] NOT NULL,
	 [isActive] BIT NOT NULL, 
    [createdBy] INT NOT NULL, 
    [createdOn] DATETIME NOT NULL, 
    [modifiedBy] INT NULL, 
    [modifiedOn] DATETIME NULL, 
    CONSTRAINT [FK_mstPavaRate_ToTable] FOREIGN KEY ([landUseSubCategoryId]) REFERENCES [mstLandUseSubCategory]([landUseSubCategoryId])
)
