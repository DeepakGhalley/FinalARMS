﻿CREATE TABLE [dbo].[tblWaterMeterReading]
(
	[waterMeterReadingId] BIGINT NOT NULL PRIMARY KEY IDENTITY,
	[waterConnectionId] INT NOT NULL, 
      [transactionId] BIGINT NULL, 
    [waterConnectionTypeId] INT NOT NULL,    
    [waterMeterTypeId] INT NOT NULL,     
    [waterLineTypeId] INT NOT NULL, 
    [waterConnectionStatusId] INT NOT NULL,    
    [bucid] INT NULL, 
    [zoneId] INT NOT NULL,    
    [reading] INT NOT NULL,     
    [isRead] BIT NOT NULL DEFAULT 0,
     [readingDate] DATE NOT NULL,
    [previousReading] INT NOT NULL, 
    [previousReadingDate] DATE NOT NULL,    
    [readBy] INT NOT NULL,        
    [noOfUnit] INT NOT NULL,   
    [consumption] INT NOT NULL,  
    [standardConsumption] INT NULL, 
    [isPermanentConnection] BIT NOT NULL, 
    [sewerage] BIT NOT NULL, 
    [solidWaste] BIT NOT NULL,         
    [remarks] VARCHAR(250) NULL,  
     [flatNo] [varchar](45) NULL,
    [billingAddress] VARCHAR(350) NOT NULL, 
 
    [primaryMobileNo] VARCHAR(150) NOT NULL, 
    [secondaryMobileNo] VARCHAR(150) NULL,    
    [isActive] BIT NOT NULL DEFAULT 1 , 
    [isDisconnected] BIT NOT NULL DEFAULT 0,    
    [createdOn] [datetime] NOT NULL,
	[createdBy] [int] NOT NULL,
	[modifiedOn] [datetime] NULL,
	[modifiedBy] [int] NULL,
    [createTransactionId] BIGINT NULL, 
    CONSTRAINT [FK_tblWaterMeterReading_ToTable] FOREIGN KEY ([waterConnectionId]) REFERENCES [mstWaterConnection]([waterConnectionId]), 
    CONSTRAINT [FK_tblWaterMeterReading_ToTable_1] FOREIGN KEY ([waterConnectionTypeId]) REFERENCES [mstWaterConnectionType]([waterConnectionTypeId]), 
    CONSTRAINT [FK_tblWaterMeterReading_ToTable_2] FOREIGN KEY ([waterMeterTypeId]) REFERENCES [mstWaterMeterType]([waterMeterTypeId]), 
    CONSTRAINT [FK_tblWaterMeterReading_ToTable_3] FOREIGN KEY ([waterLineTypeId]) REFERENCES [mstWaterLineType]([waterLineTypeId]), 
    CONSTRAINT [FK_tblWaterMeterReading_ToTable_4] FOREIGN KEY ([waterConnectionStatusId]) REFERENCES [enumWaterConnectionStatus]([waterConnectionStatusId]), 
    CONSTRAINT [FK_tblWaterMeterReading_ToTable_5] FOREIGN KEY ([transactionId]) REFERENCES [tblTransactionDetail]([transactionId]), 
    CONSTRAINT [FK_tblWaterMeterReading_ToTable_7] FOREIGN KEY ([zoneId]) REFERENCES [mstZone]([zoneId]) ,
    CONSTRAINT [FK_tblWaterMeterReading_ToTable_6] FOREIGN KEY ([createTransactionId]) REFERENCES [tblTransactionDetail]([transactionId]), 
 
)