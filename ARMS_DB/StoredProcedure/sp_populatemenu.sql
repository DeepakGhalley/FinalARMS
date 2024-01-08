CREATE PROCEDURE [dbo].[sp_populatemenu] 
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

	select distinct * from tbl_menu cm 
	where cm.isactive=1 and cm.menu_id 
in (select childmenu_id from tbl_menumap where role_id IS NULL OR role_id = @p_role_id)
	order by cm.menu_parent_id asc,cm.menuSequence asc
	
END
