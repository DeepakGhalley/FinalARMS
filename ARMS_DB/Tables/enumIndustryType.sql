

CREATE TABLE [dbo].[enumIndustryType](
	[industryTypeId] [int] IDENTITY(1,1) NOT NULL,
	[industryTypeName] [varchar](250) NOT NULL,
 CONSTRAINT [PK_enumindustrytype_IndustryTypeID] PRIMARY KEY CLUSTERED 
(
	[industryTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO