
CREATE TABLE [dbo].[enumPaymentMode](
	[paymentModeId] [int] IDENTITY(1,1) NOT NULL,
	[paymentMode] [varchar](250) NOT NULL,
	[paymentModeDetails] [varchar](45) NULL,
 CONSTRAINT [PK_enumpaymentmode_PaymentModeID] PRIMARY KEY CLUSTERED 
(
	[paymentModeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO