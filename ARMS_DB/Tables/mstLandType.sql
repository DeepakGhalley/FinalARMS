CREATE TABLE [dbo].[mstLandType]
(
	[landTypeId] INT NOT NULL PRIMARY KEY IDENTITY,
	[landTypeName] [varchar](245) NOT NULL,
	[isActive] [bit] NOT NULL,
	[createdOn] [datetime] NOT NULL,
	[createdBy] [int] NOT NULL,
	[modifiedOn] [datetime] NULL,
	[modifiedBy] [int] NULL,
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Previous Property Type is Land Type No',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'mstLandType',
    @level2type = N'COLUMN',
    @level2name = N'landTypeId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Previous Property Type is Land Type No',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'mstLandType',
    @level2type = N'COLUMN',
    @level2name = N'landTypeName'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Previous Property Type is Land Type No',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'mstLandType',
    @level2type = N'COLUMN',
    @level2name = N'isActive'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Previous Property Type is Land Type No',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'mstLandType',
    @level2type = N'COLUMN',
    @level2name = N'createdOn'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Previous Property Type is Land Type No',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'mstLandType',
    @level2type = N'COLUMN',
    @level2name = N'createdBy'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Previous Property Type is Land Type No',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'mstLandType',
    @level2type = N'COLUMN',
    @level2name = N'modifiedOn'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Previous Property Type is Land Type No',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'mstLandType',
    @level2type = N'COLUMN',
    @level2name = N'modifiedBy'