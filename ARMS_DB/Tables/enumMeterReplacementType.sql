
CREATE TABLE [dbo].[enumMeterReplacementType](
	[replacementTypeId] [int] IDENTITY(1,1) NOT NULL,
	[replacementType] [varchar](45) NOT NULL,
 CONSTRAINT [PK_enumchangetype_ID] PRIMARY KEY CLUSTERED 
(
	[replacementTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO