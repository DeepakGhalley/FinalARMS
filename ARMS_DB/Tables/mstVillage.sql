CREATE TABLE [dbo].[mstVillage]
(
	[villageId] INT NOT NULL PRIMARY KEY IDENTITY,
	 [gewogId] INT NOT NULL, 
	[villageName] [varchar](245) NOT NULL,
	[isActive] [bit] NOT NULL,
	[createdOn] [datetime] NOT NULL,
	[createdBy] [int] NOT NULL,
	[modifiedOn] [datetime] NULL,
	[modifiedBy] [int] NULL, 
  
    CONSTRAINT [FK_mstVillage_ToTable] FOREIGN KEY ([gewogId]) REFERENCES [mstGewog]([gewogId]),

)
