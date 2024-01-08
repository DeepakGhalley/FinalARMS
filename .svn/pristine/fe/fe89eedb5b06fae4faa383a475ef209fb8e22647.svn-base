CREATE TABLE [dbo].[tblStallAllocation]
(
	[stallAllocationId] INT NOT NULL IDENTITY,
     [stallDetailId] INT NOT NULL,
    [taxPayerId] INT NOT NULL, 	
    [billingScheduleId] INT NOT NULL,
    [allocationDate] DATE NOT NULL,
    [rentalAmount] DECIMAL(18, 2) NOT NULL,  
    [hasSecurityDeposit] [bit] NOT NULL,
    [securityAmount] DECIMAL(18, 2) NOT NULL,  
    [remarks] VARCHAR(350) NULL,	
    [isTerminated] [bit] NOT NULL DEFAULT 0,
    [terminateDate] DATE NULL, 
    [terminateReason] VARCHAR(250) NULL, 
    [terminatedBy] INT NULL, 
    [createdBy] INT NOT NULL, 
    [createdOn] DATETIME NOT NULL, 
    [modifiedBy] INT NULL, 
    [modifiedOn] DATETIME NULL, 
    CONSTRAINT [FK_tblStallAllocation_ToTable] FOREIGN KEY ([stallDetailId]) REFERENCES [tblStallDetail]( [stallDetailId]), 
    CONSTRAINT [FK_tblStallAllocation_ToTable_1] FOREIGN KEY ([taxPayerId]) REFERENCES [mstTaxPayerProfile]([taxPayerId]), 
    CONSTRAINT [FK_tblStallAllocation_ToTable_2] FOREIGN KEY ([billingScheduleId]) REFERENCES [enumBillingSchedule]([billingScheduleId]), 
    CONSTRAINT [PK_tblStallAllocation] PRIMARY KEY ([stallAllocationId])    
)
