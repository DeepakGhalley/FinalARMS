
CREATE TABLE [dbo].[enumServiceAccessibilityType](
	[serviceAccessibilityId] [int] IDENTITY(1,1) NOT NULL,
	[serviceAccessibilityType] [varchar](45) NOT NULL,
 CONSTRAINT [PK_enumgarbagecollectionusestatus_ID] PRIMARY KEY CLUSTERED 
(
	[serviceAccessibilityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
