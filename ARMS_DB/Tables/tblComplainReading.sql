CREATE TABLE [dbo].[tblComplainReading]
(
	[complainReadingId] BIGINT NOT NULL PRIMARY KEY IDENTITY,   
    [complainDetailId] BIGINT NOT NULL,
    [remarks] VARCHAR(350) NULL, 
    [complainPhotoPath] VARCHAR(350) NOT NULL, 
    [createdOn] [date] NOT NULL,
	[createdBy] [int] NOT NULL,
	[modifiedOn] DATETIME NULL,
	[modifiedBy] [int] NULL, 
    
    CONSTRAINT [FK_tblComplainReading_ToTable] FOREIGN KEY (complainDetailId) REFERENCES [tblComplainDetail](complainDetailId), 
)
