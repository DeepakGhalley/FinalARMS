﻿CREATE TABLE [dbo].[mstUser]
(
    [userId] [int] IDENTITY(1,1) NOT NULL,
	[roleId] [int] NOT NULL,     
    [divisionId] INT NULL, 
	[sectionId] [int] NULL, 
    [titleId] INT NOT NULL, 
    [firstName] VARCHAR(250) NULL, 
    [middleName] VARCHAR(250) NULL, 
    [lastName] VARCHAR(250) NULL, 
    [cid] VARCHAR(50) NULL, 
    [eid] VARCHAR(50) NULL, 
     [dob] DATE NOT NULL, 
    [userName] [varchar](350) NOT NULL,
	[password] [varchar](350) NOT NULL,	
	[isActive] [bit] NOT NULL,
	[createdBy] [int] NOT NULL,
	[createdOn] [datetime] NOT NULL,
	[modifiedOn] [datetime] NULL,
	[modifiedBy] [int] NULL, 
      CONSTRAINT [FK_mstUser_ToTable] FOREIGN KEY ([roleId]) REFERENCES [tbl_role]([roleId]), 
    CONSTRAINT [FK_mstUser_ToTable_1] FOREIGN KEY ([sectionId]) REFERENCES [mstSection]([sectionId]), 
    CONSTRAINT [PK_mstUser] PRIMARY KEY ([userId]), 
    CONSTRAINT [FK_mstUser_ToTable_2] FOREIGN KEY ([titleId]) REFERENCES [enumTitle]([titleId]), 
    CONSTRAINT [FK_mstUser_ToTable_3] FOREIGN KEY ([divisionId]) REFERENCES [mstDivision]([divisionId])
)