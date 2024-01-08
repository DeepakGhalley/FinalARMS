CREATE TABLE [dbo].[mstLogoSignMap]
(
	[logoSignMapId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [logoId] INT NOT NULL, 
    [esSignId] INT NOT NULL, 
    [dcdSignId] INT NOT NULL,
    [isActive] BIT NOT NULL, 
    [createdBy] INT NOT NULL, 
    [createdOn] DATETIME NOT NULL, 
    [modifiedBy] INT NULL, 
    [modifiedOn] DATETIME NULL, 
    CONSTRAINT [FK_mstLogoSignMap_ToTable] FOREIGN KEY ([logoId]) REFERENCES [mstLogoUpload]([logoId]), 
    CONSTRAINT [FK_mstLogoSignMap_ToTable_1] FOREIGN KEY ([dcdSignId]) REFERENCES [mstDCDSignUpload]([dcdSignId]), 
    CONSTRAINT [FK_mstLogoSignMap_ToTable_2] FOREIGN KEY ([esSignId]) REFERENCES [mstEsSignUpload]([esSignId]), 
)
