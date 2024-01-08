


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[sp_populatemenusByRoleID] 
	-- Add the parameters for the stored procedure here
	@p_role_id INTEGER

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    select menu_id, menu_name, sum(is_add) as is_add, sum(is_view) as is_view, sum(is_edit) as is_edit from (
	(select menu_parent_id,menu_id, menu_name, 0 as is_add, 0 as is_view, 0 as is_edit from tbl_menu 
	where menu_parent_id > 0)
	union all
	(select m.menu_parent_id, mm.childmenu_id as menu_id, m.menu_name, is_add, is_view, is_edit from tbl_menumap mm
	left join tbl_menu m on mm.childmenu_id = m.menu_id
	where role_id = @p_role_id and is_add is not null and is_view is not null and is_edit is not null)
	) T group by menu_id, menu_name, menu_parent_id
	order by menu_parent_id


END
