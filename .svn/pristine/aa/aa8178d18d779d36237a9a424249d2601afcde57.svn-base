CREATE TABLE [dbo].[tblInchargeCollection]
(
	[inchargeCollectionId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [userId] INT NOT NULL, 
    [checkedAmount] DECIMAL(18, 2) NOT NULL, 
    [collectionStartDate] DATE NOT NULL, 
    [collectionEndDate] DATE NOT NULL,
    [createdOn] DATETIME NOT NULL, 
    [createdBy] INT NOT NULL, 
    --CONSTRAINT [FK_tblInchargeCollection_ToTable] FOREIGN KEY ([userId]) REFERENCES [AspNetUsers]([userId]), 
    --CONSTRAINT [FK_tblInchargeCollection_ToTable_1] FOREIGN KEY ([createdBy]) REFERENCES [AspNetUsers]([userId]), 

)
