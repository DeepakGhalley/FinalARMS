
CREATE TABLE [dbo].[enumOccupancyType](
	[occupancyTypeId] [int] IDENTITY(3,1) NOT NULL,
	[occupancyType] [varchar](45) NOT NULL,
 CONSTRAINT [PK_enumoccupancytype_OccupancyTypeID] PRIMARY KEY CLUSTERED 
(
	[occupancyTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
