
CREATE TABLE [dbo].[enumProjectStatus](
	[projectStatusId] [int] IDENTITY(1,1) NOT NULL,
	[projectStatus] [varchar](250) NOT NULL,
 CONSTRAINT [PK_enumprojectstatus_ProjectStatusID] PRIMARY KEY CLUSTERED 
(
	[projectStatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
