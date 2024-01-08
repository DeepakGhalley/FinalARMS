


-- exec [dbo].[rptDemandCancelReport] '07-01-2021','08-31-2021',''

-- exec [dbo].[rptDemandCancelReport] '','','TTDN/2021/1002'

-- exec [dbo].[rptDemandCancelReport] '07-01-2021','07-31-2021','TTDN/2021/1002'

CREATE  PROCEDURE [dbo].[rptDemandCancelReport]
@FromDate  date, @ToDate  date, @DemandNo varchar(50)


AS
BEGIN
SET NOCOUNT ON;

if(@DemandNo = '')
BEGIN

SELECT  ROW_NUMBER() OVER(
        ORDER BY (select 1)) AS Sl, 
FORMAT(@FromDate, 'dd/MM/yyyy') as FromDate, FORMAT (@ToDate, 'dd/MM/yyyy') as ToDate, 
dn.demandNo as DemandNo,  
 dc.totalCancelAmount as TotalCancelAmount, tp.FirstName+' '+ISNULL(tp.MiddleName,'')+' '+ISNULL(tp.LastName,'') as TaxPayerName,
tp.cid as CID, tp.ttin as TTIN,dc.remarks

from tblDemandCancel dc
left join tblDemandNo dn on dc.demandNoId = dn.demandNoId
left join tblDemand dd on dn.demandNoId = dd.demandNoId
left join mstTaxPayerProfile tp on dd.taxPayerId = tp.taxPayerId

where 
convert(varchar,dc.createdOn, 112)>=convert (varchar,@FromDate, 112) 
and convert (varchar,dc.createdOn, 112)<=convert (varchar,@ToDate, 112)
group by dn.demandNo, dc.totalCancelAmount,tp.firstName,tp.middleName,tp.lastName, tp.cid, tp.ttin,dc.remarks
END

ELSE IF(@FromDate = '' and @ToDate = '' )
BEGIN
SELECT  ROW_NUMBER() OVER(
        ORDER BY (select 1)) AS Sl, 
isnull(FORMAT (@FromDate, '-'),'-') as FromDate, isnull(FORMAT (@ToDate, '-'),'-') as ToDate, 
 dn.demandNo as DemandNo,  
 dc.totalCancelAmount as TotalCancelAmount, tp.FirstName+' '+ISNULL(tp.MiddleName,'')+' '+ISNULL(tp.LastName,'') as TaxPayerName,
tp.cid as CID, tp.ttin as TTIN,dc.remarks

from tblDemandCancel dc
left join tblDemandNo dn on dc.demandNoId = dn.demandNoId
left join tblDemand dd on dn.demandNoId = dd.demandNoId
left join mstTaxPayerProfile tp on dd.taxPayerId = tp.taxPayerId

where 
dn.demandNo = @DemandNo
group by  dn.demandNo, dc.totalCancelAmount,tp.firstName,tp.middleName,tp.lastName, tp.cid, tp.ttin,dc.remarks
END

else
BEGIN
SELECT  ROW_NUMBER() OVER(
        ORDER BY (select 1)) AS Sl, 
FORMAT(@FromDate, 'dd/MM/yyyy') as FromDate, FORMAT (@ToDate, 'dd/MM/yyyy') as ToDate, 
dn.demandNo as DemandNo,  
 dc.totalCancelAmount as TotalCancelAmount, tp.FirstName+' '+ISNULL(tp.MiddleName,'')+' '+ISNULL(tp.LastName,'') as TaxPayerName,
tp.cid as CID, tp.ttin as TTIN,dc.remarks

from tblDemandCancel dc
left join tblDemandNo dn on dc.demandNoId = dn.demandNoId
left join tblDemand dd on dn.demandNoId = dd.demandNoId
left join mstTaxPayerProfile tp on dd.taxPayerId = tp.taxPayerId

where 
convert(varchar,dc.createdOn, 112)>=convert (varchar,@FromDate, 112) 
and convert (varchar,dc.createdOn, 112)<=convert (varchar,@ToDate, 112)and
 dn.demandNo = @DemandNo
group by dn.demandNo, dc.totalCancelAmount,tp.firstName,tp.middleName,tp.lastName, tp.cid, tp.ttin,dc.remarks
END
END