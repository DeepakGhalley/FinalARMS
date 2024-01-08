CREATE TABLE [dbo].[mstCalendarYear]
(
	[calendarYearId] [int] NOT NULL IDENTITY,
	[calendarYear] [varchar](45) NOT NULL,
	[startDate] [date] NOT NULL,
	[endDate] [date] NOT NULL, 
	[isActive] [bit] NOT NULL,
	[createdOn] [datetime] NOT NULL,
	[createdBy] [int] NOT NULL,
	[modifiedOn] [datetime] NULL,
	[modifiedBy] [int] NULL,
   CONSTRAINT [PK_mstCalendarYear] PRIMARY KEY ([calendarYearId]),
)
