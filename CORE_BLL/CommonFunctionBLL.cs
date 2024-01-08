﻿using CORE_BOL;
using CORE_BOL.Entities;
using CORE_DLL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CORE_BLL
{
    public class CommonFunctionBLL : ICommonFunction
    {
        readonly tt_dbContext ctx = new tt_dbContext();
        #region DDLSAMPLE
        public IEnumerable<CommonFunctionModel> SelectListTaxByTransactionType(int? TransactionTypeId)
        {
            try
            {

                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = (from a in ctx.MstTransactionTypeTaxMap.Where(x => x.TransactionTypeId == TransactionTypeId)//.OrderBy(x => x.ParentAttributeId)
                                  join b in ctx.MstTaxMaster on a.TaxId equals b.TaxId
                                  select new
                                  {
                                      TaxId = b.TaxId,
                                      //AttributeName = a.AttributeName,
                                      TaxName = b.TaxName
                                  }
                                  ).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.TaxId;
                            smast.Text = (item.TaxName);//+ "=>" + item.AttributeName);
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }
        }
      

        public IEnumerable<CommonFunctionModel> SelectListStallType()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstStallType.Where(x => 1 == 1).OrderBy(x => x.StallType).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.StallTypeId;
                            smast.Text = item.StallType;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }
        }

        //public IEnumerable SelectListRole()
        //{
        //    var list = from a in ctx.TblMstRole
        //               orderby a.RoleName ascending
        //               select new
        //               {
        //                   Value = a.RoleId,
        //                   Text = a.RoleName
        //               };

        //    return list.ToList();
        //}
        #endregion
        #region ENUMSTART
        //***********ASSET ENUM START*****************//
        public IEnumerable SelectListMonths()
        {
            var list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Text = "-- Select One --", Value = "0" });
            list.AddRange(DateTimeFormatInfo
                  .InvariantInfo
                  .MonthNames
                  .Where(m => !String.IsNullOrEmpty(m))
                  .Select((monthName, index) => new SelectListItem
                  {
                      Value = (index + 1).ToString(),
                      Text = monthName
                  }).ToList());
            return list;
        }
        public IEnumerable SelectListCalYear()
        {
            var list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Text = "-- Select One --", Value = "0" });
            for (int i = 0; i >= -10; i--)
            {
                list.Add(new SelectListItem() { Text = DateTime.Now.AddYears(i).ToString("yyyy"), Value = DateTime.Now.AddYears(i).ToString("yyyy") });
            }           
            return list;
        }
        
        public IEnumerable SelectListGender()
        {
            try
            {
                List<CommonFunctionModel> lst = new List<CommonFunctionModel>();
                lst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                lst.Add(new CommonFunctionModel { Value = 1, Text = "Male" });
                lst.Add(new CommonFunctionModel { Value = 2, Text = "Female" });
                lst.Add(new CommonFunctionModel { Value = 3, Text = "Others" });
                return lst;
            }
            catch (Exception ex)
            {
                List<CommonFunctionModel> lst = null;
                return lst;
            }
        }
        public IEnumerable<CommonFunctionModel> SelectListTitle()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.EnumTitle.OrderBy(x => x.TitleId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.TitleId;
                            smast.Text = item.Title;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();

            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<CommonFunctionModel> SelectListTaxPeriod()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstTaxPeriod.OrderBy(x => x.TaxPeriodId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.TaxPeriodId;
                            smast.Value = (int)item.PenaltyOrRate;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();

            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<CommonFunctionModel> SelectListECUseType()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.EnumEcuseType.OrderBy(x => x.EcUseTypeId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.EcUseTypeId;
                            smast.Text = item.EcUseType;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();

            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<CommonFunctionModel> SelectListRates()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstRate.OrderBy(x => x.RateId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.RateId;
                            smast.Value = (int)item.Rate;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();

            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<CommonFunctionModel> SelectListStallDetails()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.TblStallDetail.OrderBy(x => x.StallDetailId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.StallDetailId;
                            smast.Text = item.StallName;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();

            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<CommonFunctionModel> SelectListHouseDetails()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.TblHouseDetail.OrderBy(x => x.HouseDetailId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.HouseDetailId;
                            smast.Text = item.HouseAddress;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();

            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<CommonFunctionModel> SelectListVendorType()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.EnumVendorType.OrderBy(x => x.VendorTypeId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.VendorTypeId;
                            smast.Text = item.VendorType;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();

            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<CommonFunctionModel> SelectListStallAllocations()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.TblStallAllocation.OrderBy(x => x.StallAllocationId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.StallAllocationId;
                            smast.Text = item.Remarks;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();

            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<CommonFunctionModel> SelectListHouseAllocations()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.TblHouseAllocation.OrderBy(x => x.HouseAllocationId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.HouseAllocationId;
                            smast.Text = item.Remarks;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();

            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<CommonFunctionModel> SelectListTaxPayerProfile()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstTaxPayerProfile.OrderBy(x => x.TaxPayerId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.TaxPayerId;
                            smast.Text = item.Cid;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();

            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<CommonFunctionModel> SelectListBillingSchedule()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.EnumBillingSchedule.OrderBy(x => x.BillingScheduleId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.BillingScheduleId;
                            smast.Text = item.BillingSchedule;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();

            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<CommonFunctionModel> SelectListLeaseType()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.EnumLeaseType.OrderBy(x => x.LeaseTypeId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.LeaseTypeId;
                            smast.Text = item.LeaseType;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();

            }
            catch
            {
                return null;
            }
        }

     
        public IEnumerable<CommonFunctionModel> SelectListLeaseActivityType()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.EnumLeaseActivityType.OrderBy(x => x.LeaseActivityTypeId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.LeaseActivityTypeId;
                            smast.Text = item.LeaseActivity;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();

            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<CommonFunctionModel> SelectListIndustryType()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.EnumIndustryType.OrderBy(x => x.IndustryTypeId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.IndustryTypeId;
                            smast.Text = item.IndustryTypeName;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();

            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<CommonFunctionModel> SelectListMeterReplacementType()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.EnumMeterReplacementType.OrderBy(x => x.ReplacementTypeId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.ReplacementTypeId;
                            smast.Text = item.ReplacementType;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();

            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<CommonFunctionModel> SelectListOccupancyType()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.EnumOccupancyType.OrderBy(x => x.OccupancyTypeId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.OccupancyTypeId;
                            smast.Text = item.OccupancyType;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();

            }
            catch
            {
                return null;
            }
        }
       
        public IEnumerable<CommonFunctionModel> SelectListOccupation()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
        SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstOccupation.OrderBy(x => x.OccupationId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
    smast.Value = item.OccupationId;
                            smast.Text = item.Occupation;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
{
    CommonFunctionModel smast = new CommonFunctionModel();
    SerLst.Add(smast);
}
                }
                return SerLst.ToList();

            }
            catch
{
    return null;
}
        }
       
        public IEnumerable<CommonFunctionModel> SelectListPaymentModeType()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.EnumPaymentMode.OrderBy(x => x.PaymentModeId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.PaymentModeId;
                            smast.Text = item.PaymentMode;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();

            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<CommonFunctionModel> SelectListPaymentModeTypeOffLine()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                  //  var result = ctx.EnumPaymentMode.Where(x=>x.PaymentModeId!=1 && x.PaymentModeId != 2 && x.PaymentModeId != 7 && x.PaymentModeId != 9 && x.PaymentModeId != 10 && x.PaymentModeId != 11 && x.PaymentModeId != 13).OrderBy(x => x.PaymentModeId).ToList();
                    var result = ctx.EnumPaymentMode.Where(x => x.PaymentModeId == 1 || x.PaymentModeId == 2 || x.PaymentModeId == 13).OrderBy(x => x.PaymentModeId).ToList();

                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.PaymentModeId;
                            smast.Text = item.PaymentMode;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();

            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<CommonFunctionModel> SelectListPaymentModeTypePaymentFailure()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.EnumPaymentMode.Where(x => x.PaymentModeId != 1 && x.PaymentModeId != 2 && x.PaymentModeId != 7 && x.PaymentModeId != 9 && x.PaymentModeId != 10 && x.PaymentModeId != 11 && x.PaymentModeId != 13).OrderBy(x => x.PaymentModeId).ToList();

                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.PaymentModeId;
                            smast.Text = item.PaymentMode;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();

            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<CommonFunctionModel> SelectListProjectStatus()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.EnumProjectStatus.OrderBy(x => x.ProjectStatusId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.ProjectStatusId;
                            smast.Text = item.ProjectStatus;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();

            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<CommonFunctionModel> SelectListServiceAccessibilityType()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.EnumServiceAccessibilityType.OrderBy(x => x.ServiceAccessibilityId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.ServiceAccessibilityId;
                            smast.Text = item.ServiceAccessibilityType;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();

            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<CommonFunctionModel> SelectListBuildingclass()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstBuildingClass.OrderBy(x => x.BuildingClassId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.BuildingClassId;
                            smast.Text = item.BuildingClassName;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();

            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<CommonFunctionModel> SelectListAssetAttribute()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = (from a in ctx.MstAssetAttribute.Where(x => x.IsActive == true).OrderBy(x => x.ParentAttributeId)
                                  join b in ctx.MstParentAttribute on a.ParentAttributeId equals b.ParentAttributeId
                                  select new 
                                  { AssetAttributeId=a.AssetAttributeId ,
                                      AttributeName = a.AttributeName,
                                      ParentAttribute = b.ParentAttribute
                                  }
                                  ).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.AssetAttributeId;
                            smast.Text = (item.ParentAttribute+"=>"+ item.AttributeName);
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<CommonFunctionModel> SelectListStoreyType()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.EnumStoryType.OrderBy(x => x.StoryTypeId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.StoryTypeId;
                            smast.Text = item.StoryType;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();

            }
            catch
            {
                return null;
            }
        }



        //***********ASSET ENUM END*****************//

        #endregion

        #region REVENUE_ENUM_START
        //***********REVENUE_ENUM_START*****************//
        public IEnumerable<CommonFunctionModel> SelectListWorkLevel()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstEcactivityType.OrderBy(x => x.EcActivityTypeId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.EcActivityTypeId;
                            smast.Text = item.ActivityType;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();

            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<CommonFunctionModel> SelectListECAcitvityType()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstEcactivityType.OrderBy(x => x.EcActivityTypeId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.EcActivityTypeId;
                            smast.Text = item.ActivityType;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();

            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<CommonFunctionModel> SelectListApprovslStatus()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.EnumApprovalStatus.OrderBy(x => x.ApprovalStatusId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.ApprovalStatusId;
                            smast.Text = item.ApprovalStatus;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();

            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<CommonFunctionModel> SelectListBuildingEditReason()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.EnumBuildingEditReason.OrderBy(x => x.BuildingEditReasonId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.BuildingEditReasonId;
                            smast.Text = item.BuildingEditReason;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();

            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<CommonFunctionModel> SelectListFeeType()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.EnumFeeType.OrderBy(x => x.FeeTypeId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.FeeTypeId;
                            smast.Text = item.FeeType;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();

            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<CommonFunctionModel> SelectListOwnerType()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.EnumOwnerType.OrderBy(x => x.OwnerTypeId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.OwnerTypeId;
                            smast.Text = item.OwnerType;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();

            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<CommonFunctionModel> SelectListWaterBIllEditReason()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.EnumWaterBillEditReason.OrderBy(x => x.WaterBillEditReasonId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.WaterBillEditReasonId;
                            smast.Text = item.WaterBillEditReason;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();

            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<CommonFunctionModel> SelectListWaterConnectionStatus()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.EnumWaterConnectionStatus.OrderBy(x => x.WaterConnectionStatusId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.WaterConnectionStatusId;
                            smast.Text = item.WaterConnectionStatus;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();

            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<CommonFunctionModel> SelectListTaxPayerType()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.EnumTaxPayerType.OrderBy(x => x.TaxPayerTypeId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.TaxPayerTypeId;
                            smast.Text = item.TaxPayerType;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();

            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<CommonFunctionModel> SelectListLandOwnershipType()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.EnumLandOwnershipType.OrderBy(x => x.LandOwnershipTypeId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.LandOwnershipTypeId;
                            smast.Text = item.LandOwnershipType;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();

            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<CommonFunctionModel> SelectListStreetName()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstStreetName.OrderBy(x => x.StreetNameId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.StreetNameId;
                            smast.Text = item.StreetName;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();

            }
            catch
            {
                return null;
            }
        }
        //***********REVENUE_ENUM_END*****************//
        #endregion



        #region ASSET_MASTER_START

        //***********ASSET_MASTER_START*****************//
        public IEnumerable<CommonFunctionModel> SelectListLandServiceType()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstLandServiceType.Where(x => x.IsActive == true).OrderBy(x => x.LandServiceTypeId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.LandServiceTypeId;
                            smast.Text = item.LandServiceType;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }

        }
        public IEnumerable<CommonFunctionModel> SelectListDivision()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstDivision.Where(x => x.IsActive == true).OrderBy(x => x.DivisionId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.DivisionId;
                            smast.Text = item.DivisionName;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }

        }

        public IEnumerable<CommonFunctionModel> SelectListSection()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstSection.Where(x => x.IsActive == true).OrderBy(x => x.SectionId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.SectionId;
                            smast.Text = item.SectionName;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<CommonFunctionModel> SelectListArea()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstArea.Where(x => x.IsActive == true).OrderBy(x => x.AreaId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.AreaId;
                            smast.Text = item.AreaName;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }

        }
        public IEnumerable<CommonFunctionModel> SelectListDesignation()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstDesignation.Where(x => x.IsActive == true).OrderBy(x => x.DesignationId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.DesignationId;
                            smast.Text = item.Designation;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<CommonFunctionModel> SelectListPrimaryHead()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstPrimaryAccountHead.Where(x => x.IsActive == true).OrderBy(x => x.PrimaryAccountHeadId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.PrimaryAccountHeadId;
                            smast.Text = item.PrimaryAccountHeadName;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<CommonFunctionModel> SelectListSecondaryHead()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstSecondaryAccountHead.Where(x => x.IsActive == true).OrderBy(x => x.SecondaryAccountHeadId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.SecondaryAccountHeadId;
                            smast.Text = item.SecondaryAccountHeadName;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<CommonFunctionModel> SelectListTertiaryHead()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstTertiaryAccountHead.Where(x => x.IsActive == true).OrderBy(x => x.TertiaryAccountHeadId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.TertiaryAccountHeadId;
                            smast.Text = item.TertiaryAccountHeadName;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<CommonFunctionModel> SelectListLap()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstLap.Where(x => x.IsActive == true).OrderBy(x => x.LapId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.LapId;
                            smast.Text = item.LapName;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<CommonFunctionModel> SelectListTransactionType()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    //var result = ctx.MstTransactionType.Where(x => x.IsActive == true && x.HasApprovalProcess == true).OrderBy(x => x.TransactionTypeId).ToList();
                    var result = ctx.MstTransactionType.Where(x => x.IsActive == true ).OrderBy(x => x.TransactionTypeId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.TransactionTypeId;
                            smast.Text = item.TransactionType;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        public IEnumerable<CommonFunctionModel> SelectListTransactionTypeForG2CServices()
        {
            try
            {
                int[] values = new[] { 2,5,6,7,8,32 };

                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstTransactionType.Where(x => x.IsActive == true && values.Contains(x.TransactionTypeId)).OrderBy(x => x.TransactionTypeId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.TransactionTypeId;
                            smast.Text = item.TransactionType;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch (Exception ex)
            {
                return null; 
            }
        }

        public IEnumerable<CommonFunctionModel> SelectListMiscellaneousTransactionType()
        {
            try
            {

                int[] TransactionTypeIds = { 10, 12, 23, 24, 25, 26, 27, 28, 29, 30, 32, 33,49,50 };

                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    //var result = ctx.MstTransactionType.Where(x => x.IsActive == true).OrderBy(x => x.TransactionTypeId).ToList();
                    var result = (from a in ctx.MstTransactionType.Where(x => x.IsActive == true).OrderBy(x => x.TransactionType)
                                  join b in ctx.MstTransactionTypeTaxMap on a.TransactionTypeId equals b.TransactionTypeId
                                  //join c in ctx.MstTaxMaster on b.TaxId equals c.TaxId
                                  //join d in ctx.MstDetailHead on c.DetailHeadId equals d.DetailHeadId
                                  where TransactionTypeIds.Contains(a.TransactionTypeId) || a.TransactionTypeId > 50
                                  select new CommonFunctionModel
                                  {
                                      Value = a.TransactionTypeId,
                                      Text = a.TransactionType
                                  }).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.Value;
                            smast.Text = item.Text;
                            SerLst.Add(smast);
                        }
                    }
                    //SerLst.Concat(result).ToList();
                    //SerLst.Append(result);
                    //SerLst.Add(result.ToArray());
                    //SerLst = result ;
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<CommonFunctionModel> SelectListPlotWithOwnership(int TaxPayerId)
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    
                    var result = (from a in ctx.TblLandOwnershipDetail.Where(x => x.TaxPayerId == TaxPayerId).OrderBy(x => x.LandDetailId)
                                  join b in ctx.MstLandDetail on a.LandDetailId equals b.LandDetailId

                                  select new CommonFunctionModel
                                  {
                                      Value = a.TaxPayerId,
                                      Text = b.PlotNo

                                      //SerLst.Add(smast);
                                  }).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.Value;
                            smast.Text = item.Text;
                            SerLst.Add(smast);
                        }
                    }
                    //SerLst.Concat(result).ToList();
                    //SerLst.Append(result);
                    //SerLst.Add(result.ToArray());
                    //SerLst = result ;
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<CommonFunctionModel> SelectListAttributeUnitMap(int AssetAttributeId)
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                //SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
               
                    var result = (from a in ctx.MstAttributeUnitMap.Where(x => x.IsActive == true && x.AssetAttributeId == AssetAttributeId).OrderBy(x => x.AssetAttributeId)
                                  join b in ctx.MstMeasurementUnit on a.MeasurementUnitId equals b.MeasurementUnitId
                                  select new CommonFunctionModel
                                  {
                                      Value = a.MeasurementUnitId,
                                      Text = b.MeasurementUnit//(a.MeasurementUnit + "( " + b.MeasurementUnitSymbol + " )"),
                                      //MeasurementUnitSymbol = b.MeasurementUnitSymbol
                                  }
                           );
                    //if (result.Count < 0 && result.Count == 0)
                    //{
                    //    CommonFunctionModel smast = new CommonFunctionModel();
                    //    SerLst.Add(smast);
                    //}

                    return result.ToList();
                
               
            }
            catch
            {
                return null;
            }
        }

        //***********ASSET_MASTER_END*****************//

        #endregion


        #region REVENUE_MASTER_START

        //***********REVENUE_MASTER_START*****************//
        public IEnumerable<CommonFunctionModel> SelectListUser()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.AspNetUsers.ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.UserId;
                            smast.Text = item.FirstName + " " + ((item.MiddleName == null || item.MiddleName.Trim() == string.Empty) ? string.Empty : (item.MiddleName + " ")) + ((item.LastName == null || item.LastName.Trim() == string.Empty) ? string.Empty : (item.LastName + " "));

                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<CommonFunctionModel> SelectListRole()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.TblRole.Where(x => x.IsActive == true).OrderBy(x => x.RoleId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.RoleId;
                            smast.Text = item.RoleName;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<CommonFunctionModel> SelectListMajorHead()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstMajorHead.Where(x => x.IsActive == true).OrderBy(x => x.MajorHeadId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.MajorHeadId;
                            smast.Text = item.MajorHeadName;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }

        }

       
        public IEnumerable<CommonFunctionModel> SelectListMinorHead()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstMinorHead.Where(x => x.IsActive == true).OrderBy(x => x.MinorHeadId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.MinorHeadId;
                            smast.Text = item.MinorHeadName;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<CommonFunctionModel> SelectListMajorDetailHead()
        {

            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstDetailHead.Where(x => x.IsActive == true).OrderBy(x => x.DetailHeadId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.DetailHeadId;
                            smast.Text = item.DetailHeadName;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<CommonFunctionModel> SelectListZone()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstZone.Where(x => x.IsActive == true).OrderBy(x => x.ZoneName).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.ZoneId;
                            smast.Text = item.ZoneName;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<CommonFunctionModel> SelectListZoneReader()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstZone.Where(x => x.IsActive == true).OrderBy(x => x.ZoneReader).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.ZoneId;
                            smast.Text = item.ZoneReader;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<CommonFunctionModel> SelectListDemkhong()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstDemkhong.Where(x => x.IsActive == true).OrderBy(x => x.DemkhongId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.DemkhongId;
                            smast.Text = item.DemkhongName;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<CommonFunctionModel> SelectListFinancialYear()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstFinancialYear.Where(x => x.IsActive == true).OrderBy(x => x.FinancialYearId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.FinancialYearId;
                            smast.Text = item.FinancialYear;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<CommonFunctionModel> SelectListSupplier()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstSuppliers.Where(x => x.IsActive == true).OrderBy(x => x.SupplierId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.SupplierId;
                            smast.Text = item.SupplierName;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<CommonFunctionModel> SelectListModificationReason()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstModificationReason.Where(x => x.IsActive == true).OrderBy(x => x.ModificationReasonId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.ModificationReasonId;
                            smast.Text = item.ModificationReason;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<CommonFunctionModel> SelectListParentAttribute()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstParentAttribute.Where(x => x.IsActive == true).OrderBy(x => x.ParentAttributeId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.ParentAttributeId;
                            smast.Text = item.ParentAttribute;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<CommonFunctionModel> SelectListDisposalType()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstDisposalType.Where(x => x.IsActive == true).OrderBy(x => x.DisposalTypeId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.DisposalTypeId;
                            smast.Text = item.DisposalType;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<CommonFunctionModel> SelectListMaintenanceType()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstMaintenanceType.Where(x => x.IsActive == true).OrderBy(x => x.MaintenanceTypeId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.MaintenanceTypeId;
                            smast.Text = item.MaintenanceType;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<CommonFunctionModel> SelectListInspectionType()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstInspectionType.Where(x => x.IsActive == true).OrderBy(x => x.InspectionTypeId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.InspectionTypeId;
                            smast.Text = item.InspectionType;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<CommonFunctionModel> SelectListDepreciationType()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstDepreciationType.Where(x => x.IsActive == true).OrderBy(x => x.DepreciationTypeId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.DepreciationTypeId;
                            smast.Text = item.DepreciationType;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<CommonFunctionModel> SelectListConditionRating()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstConditionRating.Where(x => x.IsActive == true).OrderBy(x => x.ConditionRatingId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.ConditionRatingId;
                            smast.Text = item.ConditionRating;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<CommonFunctionModel> SelectListAssetFunction()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstAssetFunction.Where(x => x.IsActive == true).OrderBy(x => x.AssetFunctionId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.AssetFunctionId;
                            smast.Text = item.AssetFunctionName;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<CommonFunctionModel> SelectListMeasurementUnit()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstMeasurementUnit.Where(x => x.IsActive == true).OrderBy(x => x.MeasurementUnitId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.MeasurementUnitId;
                            smast.Text = item.MeasurementUnit;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<CommonFunctionModel> SelectListTaxMaster()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstTaxMaster.Where(x => x.IsActive == true).OrderBy(x => x.TaxId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.TaxId;
                            smast.Text = item.TaxName;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<CommonFunctionModel> SelectListTaxMasterTransactionTypeId(int id) 
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstTaxMaster.Where(x => x.IsActive == true && x.TaxId==id).OrderBy(x => x.TaxId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.TaxId;
                            smast.Text = item.TaxName;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<CommonFunctionModel> SelectListDetailHead()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstDetailHead.Where(x => x.IsActive == true).OrderBy(x => x.DetailHeadId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.DetailHeadId;
                            smast.Text = item.DetailHeadName;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<CommonFunctionModel> SelectListDzongkhag()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstDzongkhag.Where(x => x.IsActive == true).OrderBy(x => x.DzongkhagId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.DzongkhagId;
                            smast.Text = item.DzongkhagName;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<CommonFunctionModel> SelectListGewog()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstGewog.Where(x => x.IsActive == true).OrderBy(x => x.GewogId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.GewogId;
                            smast.Text = item.GewogName;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<CommonFunctionModel> SelectListVillage()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstVillage.Where(x => x.IsActive == true).OrderBy(x => x.VillageId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.VillageId;
                            smast.Text = item.VillageName;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }
        }
       
        public IEnumerable<CommonFunctionModel> SelectListLandType()
        {
            try
            {

                int[] LandTypeIds = { 1,2,4,5,6 };

                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    //var result = ctx.MstTransactionType.Where(x => x.IsActive == true).OrderBy(x => x.TransactionTypeId).ToList();
                    var result = (from a in ctx.MstLandType.Where(x => x.IsActive == true).OrderBy(x => x.LandTypeId)
                             
                                  
                                  where LandTypeIds.Contains(a.LandTypeId)
                                  select new CommonFunctionModel
                                  {
                                      Value = a.LandTypeId,
                                      Text = a.LandTypeName
                                  }).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.Value;
                            smast.Text = item.Text;
                            SerLst.Add(smast);
                        }
                    }
                    //SerLst.Concat(result).ToList();
                    //SerLst.Append(result);
                    //SerLst.Add(result.ToArray());
                    //SerLst = result ;
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public IEnumerable<CommonFunctionModel> SelectListLandUseCategory()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstLandUseCategory.Where(x => x.IsActive == true).OrderBy(x => x.LandUseCategoryId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.LandUseCategoryId;
                            smast.Text = item.LandUseCategory;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<CommonFunctionModel> SelectListLandUseSubCategory()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstLandUseSubCategory.Where(x => x.IsActive == true).OrderBy(x => x.LandUseSubCategoryId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.LandUseSubCategoryId;
                            smast.Text = item.LandUseSubCategory;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<CommonFunctionModel> SelectListWaterConnectionType()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstWaterConnectionType.Where(x => x.IsActive == true).OrderBy(x => x.WaterConnectionTypeId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.WaterConnectionTypeId;
                            smast.Text = item.WaterConnectionType;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<CommonFunctionModel> SelectListWaterLineType()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstWaterLineType.Where(x => x.IsActive == true).OrderBy(x => x.WaterLineTypeId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.WaterLineTypeId;
                            smast.Text = item.WaterLineType;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<CommonFunctionModel> SelectListWaterMeterType()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstWaterMeterType.Where(x => x.IsActive == true).OrderBy(x => x.WaterMeterTypeId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.WaterMeterTypeId;
                            smast.Text = item.WaterMeterType;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<CommonFunctionModel> SelectListBank()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstBank.Where(x => x.IsActive == true).OrderBy(x => x.BankId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.BankId;
                            smast.Text = item.BankName;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<CommonFunctionModel> SelectListBankBranch()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstBankBranch.Where(x => x.IsActive == true).OrderBy(x => x.BankBranchId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.BankBranchId;
                            smast.Text = item.BranchName;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<CommonFunctionModel> SelectListBuildingUnitClass()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstBuildingUnitClass.Where(x => x.IsActive == true).OrderBy(x => x.BuildingUnitClassId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.BuildingUnitClassId;
                            smast.Text = item.BuildingUnitClassName;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<CommonFunctionModel> SelectListTechnicalAttribute()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstTechnicalAttribute.Where(x => x.IsActive == true).OrderBy(x => x.TechnicalAttributeId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.TechnicalAttributeId;
                            smast.Text = item.TechnicalAttribute;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<CommonFunctionModel> SelectListDetailTechnicalAttribute()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstDetailTechnicalAttribute.Where(x => x.IsActive == true).OrderBy(x => x.DetailTechnicalAttributeId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.DetailTechnicalAttributeId;
                            smast.Text = item.DetailTechnicalAttribute;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<CommonFunctionModel> SelectListCalendarYear()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstCalendarYear.Where(x => x.IsActive == true).OrderBy(x => x.CalendarYearId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.CalendarYearId;
                            smast.Text = item.CalendarYear;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<CommonFunctionModel> SelectListAttributeUnitMaps()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstAttributeUnitMap.Where(x => x.IsActive == true).OrderBy(x => x.AttributeUnitMapId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.AttributeUnitMapId;
                            smast.Text = item.AttributeUnitMapName;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<CommonFunctionModel> SelectListAssetRegister()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstAsset.Where(x => x.IsActive == true).OrderBy(x => x.AssetId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.AssetId;
                            smast.Text = item.AssetName;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }
        }

      
        public IEnumerable<CommonFunctionModel> SelectListApplicantDetail()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstEcapplicantdetail.Where(x => x.IsActive == true).OrderBy(x => x.ApplicantId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.ApplicantId;
                            smast.Text = item.Cid;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<CommonFunctionModel> SelectListAssetStatus()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstAssetStatus.Where(x => x.IsActive == true).OrderBy(x => x.AssetStatusId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.AssetStatusId;
                            smast.Text = item.AssetStatus;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }
        }



        public IEnumerable<CommonFunctionModel> SelectListBoundaryType()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstBoundaryType.Where(x => x.IsActive == true).OrderBy(x => x.BoundaryTypeId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.BoundaryTypeId;
                            smast.Text = item.BoundaryType;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<CommonFunctionModel> SelectListBuildingColour()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstBuildingColour.Where(x => x.IsActive == true).OrderBy(x => x.BuildingColourId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.BuildingColourId;
                            smast.Text = item.BuildingColourType;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<CommonFunctionModel> SelectListConstructionType()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstConstructionType.Where(x => x.IsActive == true).OrderBy(x => x.ConstructionTypeId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.ConstructionTypeId;
                            smast.Text = item.ConstructionType;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<CommonFunctionModel> SelectListLandDetail()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstLandDetail.Where(x => 1 == 1).OrderBy(x => x.LandDetailId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.LandDetailId;
                            smast.Text = item.PlotNo;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<CommonFunctionModel> SelectListMaterialType()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstMaterialType.Where(x => x.IsActive == true).OrderBy(x => x.MaterialTypeId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.MaterialTypeId;
                            smast.Text = item.MaterialType;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<CommonFunctionModel> SelectListParkingSlot()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstParkingSlot.Where(x => x.IsActive == true).OrderBy(x => x.ParkingSlotId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.ParkingSlotId;
                            smast.Text = item.ParkingSlotName;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<CommonFunctionModel> SelectListStructureCategory()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstStructureCategory.Where(x => x.IsActive == true).OrderBy(x => x.StructureCategoryId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.StructureCategoryId;
                            smast.Text = item.StructureCategory;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<CommonFunctionModel> SelectListStructureType()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstStructureType.Where(x => x.IsActive == true).OrderBy(x => x.StructureTypeId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.StructureTypeId;
                            smast.Text = item.StructureType;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<CommonFunctionModel> SelectListWaterTankLocation()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.EnumWaterTankLocation.Where(x => 1 == 1).OrderBy(x => x.WaterTankLocationId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.WaterTankLocationId;
                            smast.Text = item.WaterTankLocation;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<CommonFunctionModel> SelectListBuildingDetail()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstBuildingDetail.Where(x => 1 == 1).OrderBy(x => x.BuildingDetailId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.BuildingDetailId;
                            smast.Text = item.BuildingNo;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<CommonFunctionModel> SelectListBuildingUnitUseType()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstBuildingUnitUseType.Where(x => 1 == 1).OrderBy(x => x.BuildingUnitUseTypeId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.BuildingUnitUseTypeId;
                            smast.Text = item.BuildingUnitUseType;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<CommonFunctionModel> SelectListFloorName()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstFloorName.Where(x => 1 == 1).OrderBy(x => x.FloorNameId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.FloorNameId;
                            smast.Text = item.FloorName;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<CommonFunctionModel> SelectListUnitOwnerType()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.EnumUnitOwnerType.Where(x => 1 == 1).OrderBy(x => x.UnitOwnerTypeId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.UnitOwnerTypeId;
                            smast.Text = item.UnitOwnerType;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<CommonFunctionModel> SelectListSlabFor()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.EnumSlabFor.Where(x => 1 == 1).OrderBy(x => x.SlabForId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.SlabForId;
                            smast.Text = item.SlabFor;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<CommonFunctionModel> SelectListSlab()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstSlab.Where(x => 1 == 1).OrderBy(x => x.SlabId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.SlabId;
                            smast.Text = item.SlabName;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }
        }
      
        public IEnumerable<CommonFunctionModel> SelectListTaxTypeClassification()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstTaxTypeClassification.Where(x => 1 == 1).OrderBy(x => x.TaxTypeClassificationId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.TaxTypeClassificationId;
                            smast.Text = item.TaxTypeClassificationName;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<CommonFunctionModel> SelectListRoofingType()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstRoofingType.Where(x => 1 == 1).OrderBy(x => x.RoofingTypeId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.RoofingTypeId;
                            smast.Text = item.RoofingType;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }
        }

        public List<CommonFunctionModel> SelectListApplicantDetails(int ApplicationId)
        {
            throw new NotImplementedException();
        }


        //***********REVENUE_MASTER_START_END*****************//
        #endregion

        #region ENV_CLEARANCE
        public IEnumerable<CommonFunctionModel> SelectListECDetails()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.TblEcdetail.OrderBy(x => x.EcDetailId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.EcDetailId;
                            smast.Text = item.ProjectName;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<CommonFunctionModel> SelectListStallLocations()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstStallLocation.OrderBy(x => x.StallLocation).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.StallLocationId;
                            smast.Text = item.StallLocation;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<CommonFunctionModel> SelectListParkingZones()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstParkingZone.OrderBy(x => x.ParkingzoneName).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.ParkingZoneId;
                            smast.Text = item.ParkingzoneName;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<CommonFunctionModel> SelectListPropertyType()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.EnumPropertyType.OrderBy(x => x.PropertyType).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.PropertyTypeId;
                            smast.Text = item.PropertyType;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }
        }
        #endregion

        public IEnumerable<DemandYearsModel> VendorDemandYears(string StartDate, string EndDate)
        {
            try 
            {
                var result = ctx.DemandYearsModel.FromSqlRaw($"GetDemandYears {StartDate},{EndDate}");

                return result.ToList();

            }
            catch (Exception ex)
            {
                return null;

            }
        }

        public IEnumerable<CommonFunctionModel> SelectListComplainType()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.EnumComplainType.OrderBy(x => x.ComplainTypeId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.ComplainTypeId;
                            smast.Text = item.ComplainType;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<CommonFunctionModel> SelectListAssetTransferType()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.EnumAssetTransferType.OrderBy(x => x.AssetTransferTypeId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.AssetTransferTypeId;
                            smast.Text = item.AssetTransferType;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<CommonFunctionModel> SelectListLogoUpload()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstLogoUpload.OrderBy(x => x.LogoId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.LogoId;
                            smast.Text = item.LogoName;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<CommonFunctionModel> SelectListEsSignUpload()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstEsSignUpload.OrderBy(x => x.EsSignId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.EsSignId;
                            smast.Text = item.SignPath;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<CommonFunctionModel> SelectListDcdSignUpload()
        {
            try
            {
                List<CommonFunctionModel> SerLst = new List<CommonFunctionModel>();
                SerLst.Add(new CommonFunctionModel { Value = 0, Text = "-- Select One --" });
                using (tt_dbContext ctx = new tt_dbContext())
                {
                    var result = ctx.MstDcdsignUpload.OrderBy(x => x.DcdSignId).ToList();
                    if (result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            CommonFunctionModel smast = new CommonFunctionModel();
                            smast.Value = item.DcdSignId;
                            smast.Text = item.SignPath;
                            SerLst.Add(smast);
                        }
                    }
                    if (result.Count < 0 && result.Count == 0)
                    {
                        CommonFunctionModel smast = new CommonFunctionModel();
                        SerLst.Add(smast);
                    }
                }
                return SerLst.ToList();
            }
            catch
            {
                return null;
            }
        }
    }
}

