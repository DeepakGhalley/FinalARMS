USE [tt_db]
GO
/****** Object:  StoredProcedure [dbo].[RevenuetransferOpeningbalace]    Script Date: 4/28/2023 12:16:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--  exec [dbo].[RevenuetransferOpeningbalace]  '20230401'

create PROCEDURE [dbo].[RevenuetransferOpeningbalace] 
	@StartDate varchar(200)
	
AS
Select ROW_NUMBER() over(order by(select 1)) as Sl,sum(amount) as TotalAmount
	from tblOpeningBalance pl
   
	where FORMAT (pl.createdOn, 'yyyyMMdd') >= @StartDate	


