
CREATE TABLE [dbo].[tbl_menumap](
	[menumap_id] [int] NOT NULL IDENTITY,
	[role_id] [int] NULL,
	[childmenu_id] [int] NULL,
	[is_add] [int] NULL,
	[is_view] [int] NULL,
	[is_edit] [int] NULL,
 CONSTRAINT [PK_tbl_menumap] PRIMARY KEY CLUSTERED 
(
	[menumap_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY], 
    CONSTRAINT [FK_tbl_menumap_ToTable] FOREIGN KEY ([role_id]) REFERENCES [tbl_role]([roleid])
) ON [PRIMARY]
GO


