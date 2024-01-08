CREATE TABLE [dbo].[tblaudit]
([ID] [int] IDENTITY(1,1) NOT NULL,
	[Type] [char](1) NULL,
	[TableName] [varchar](150) NULL,
	[PK] [varchar](500) NULL,
	[ColumnName] [varchar](150) NULL,
	[OldValue] [varchar](5000) NULL,
	[NewValue] [varchar](5000) NULL,
	[UpdateDate] [datetime] NULL,
	[UserID] [int] NULL, 
    CONSTRAINT [PK_tblaudit] PRIMARY KEY ([ID]),
)
