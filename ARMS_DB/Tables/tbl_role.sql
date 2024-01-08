
CREATE TABLE [dbo].[tbl_role](
	[roleId] [int] IDENTITY(1,1) NOT NULL,
	[roleName] [varchar](150) NOT NULL,
	[description] [varchar](150) NULL,
	[isActive] [bit] NOT NULL,
	[createdBy] [int] NOT NULL,
	[createdOn] [datetime] NOT NULL,
	[modifiedOn] [datetime] NULL,
	[modifiedBy] [int] NULL,
 CONSTRAINT [PK_tbl_role] PRIMARY KEY CLUSTERED 
(
	[roleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


