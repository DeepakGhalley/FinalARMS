CREATE TABLE [dbo].[mstModificationReason]
(
	[modificationReasonId] INT NOT NULL PRIMARY KEY IDENTITY,
      [modificationReason] VARCHAR(50) NOT NULL, 
            [reasonDescription] VARCHAR(50)  NULL, 
                  [reasonCode] VARCHAR(50)  NULL, 
	[isActive] BIT NOT NULL, 
    [createdBy] INT NOT NULL, 
    [createdOn] DATETIME NOT NULL, 
    [modifiedBy] INT NULL, 
    [modifiedOn] DATETIME NULL, 
)
