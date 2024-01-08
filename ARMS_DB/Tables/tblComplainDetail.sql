﻿CREATE TABLE [dbo].[tblComplainDetail]
(
	[complainDetailId] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [waterConnectionId] INT NOT NULL, 
    [complainTypeId] INT NOT NULL, 
    [complainStatusId] INT NOT NULL DEFAULT 1,
    [instruction] VARCHAR(350) NOT NULL, 
    [deadLine] DATETIME NOT NULL,   
    [createdOn] [date] NOT NULL,
	[createdBy] [int] NOT NULL,
	[modifiedOn] DATETIME NULL,
	[modifiedBy] [int] NULL, 
    [complainReviewedBy] INT NULL, 
    [complainReviewRemarks] VARCHAR(300) NULL, 
    [complainReviewedOn] DATETIME NULL, 
    [complainRejectedBy] INT NULL, 
    [complainRejectRemarks] VARCHAR(300) NULL, 
    [complainRejectedOn] DATETIME NULL, 
    [complainApprovedBy] INT NULL, 
    [complainApprovalRemarks] VARCHAR(300) NULL, 
    [complainApprovedOn] DATETIME NULL, 
    CONSTRAINT [FK_tblComplainDetail_ToTable] FOREIGN KEY ([complainTypeId]) REFERENCES [enumComplainType]([complainTypeId]), 
    CONSTRAINT [FK_tblComplainDetail_ToTable_1] FOREIGN KEY ([complainStatusId]) REFERENCES [enumComplainStatus]([complainStatusId]), 
    CONSTRAINT [FK_tblComplainDetail_ToTable_2] FOREIGN KEY ([waterConnectionId]) REFERENCES [mstWaterConnection]([waterConnectionId]), 
   )