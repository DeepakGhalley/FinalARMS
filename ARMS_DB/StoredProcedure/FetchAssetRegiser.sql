
Create PROCEDURE [dbo].[FetchAssetRegiser]
	@PrimaryHeadId int
AS
--	EXEC  [dbo].[FetchAssetRegiser] 1

begin
			 select ROW_NUMBER() over(order by(select 1)) as Sl, s.secondaryAccountHeadName as Assetname,s.secondaryAccountHeadId as SecondaryAccountHeadId, count(s.secondaryAccountHeadName) as Qty from mstAsset a
left join mstTertiaryAccountHead t on a.tertiaryAccountHeadId = t.TertiaryAccountHeadId
left join mstSecondaryAccountHead s on t.secondaryAccountHeadId = s.secondaryAccountHeadId
left join mstPrimaryAccountHead p on s.primaryAccountHeadId = p.primaryAccountHeadId
 where p.primaryAccountHeadId = @PrimaryHeadId
group by s.secondaryAccountHeadName,s.secondaryAccountHeadId
			
 end
 


 RETURN 0