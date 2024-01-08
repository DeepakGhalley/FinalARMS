

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_deletemappedmenus] 
	-- Add the parameters for the stored procedure here
	@p_role_id INTEGER

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	--select pm.parentmenu, cm.* from tbl_childmenu cm 
	--left join tbl_parentmenu pm on cm.parentmenu_id = pm.parentmenu_id
	--where cm.childmenu_id in (select childmenu_id from tbl_menumap
	--where role_id = 1)

	delete from tbl_menumap where role_id = @p_role_id and 
	is_add is not null and is_edit is not null and is_view is not null


END
GO


