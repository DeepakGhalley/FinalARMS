﻿using CORE_BOL;
using CORE_BOL.Entities;
using CORE_DLL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace CORE_BLL
{
    public class MannualreceiptBLL : IMannualreceipt
    {
        readonly tt_dbContext ctx = new tt_dbContext();

        public bool CheckExistsAsync(int id)
        {
            return ctx.TblManualReceipt.Any(e => e.ManualReceiptId == id);
        }

        public async Task Delete(int? id)
        {
            var tblmannualreceipt = await ctx.TblManualReceipt
           .FirstOrDefaultAsync(m => m.ManualReceiptId == id);
        }

        public async Task DeleteConfirmed(int id)
        {
            using (TransactionScope s = new TransactionScope())
            {
                var tblmannualreceipt = ctx.TblManualReceipt.Find(id);
                ctx.TblManualReceipt.Remove(tblmannualreceipt);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();

            }
        }

        public async Task<ManualReceiptVM> Details(int? id)
        {
            var data = (from a in ctx.TblManualReceipt.Where(aa => aa.ManualReceiptId == id)
                        
                        select new ManualReceiptVM
                        {
                            ManualReceiptId= a.ManualReceiptId,
                            ManualReceiptNo = a.ManualReceiptNo,
                            ManualTaxName = a.ManualTaxName,
                            Amount = a.Amount,
                            CreatedBy = a.CreatedBy,
                            Remarks = a.Remarks,
                          CollectedBy = a.CollectedBy


                        });

            return await data.FirstOrDefaultAsync();
        }

       

     

        public IList<ManualReceiptVM> GetAll()
        {
            var data = (from a in ctx.TblManualReceipt
                        select new ManualReceiptVM
                        {
                            ManualReceiptId = a.ManualReceiptId,
                            ManualReceiptNo = a.ManualReceiptNo,
                            ManualTaxName = a.ManualTaxName,
                            Amount = a.Amount,
                            CreatedBy = a.CreatedBy,
                            Remarks = a.Remarks,
                            ModifiedBy = a.ModifiedBy,
                            CollectedBy = a.CollectedBy,
                            ReceiptDates = a.ReceiptDate.ToString("yyyy/MM/dd")
                        });
            return data.ToList();
        }

        public int Save(ManualReceiptVM obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    int ipk;
                    var entity = new TblManualReceipt
                    {
                       
       
                       ManualReceiptId = obj.ManualReceiptId,
                          ManualTaxName = obj.ManualTaxName,
                        ManualReceiptNo = obj.ManualReceiptNo,
                        ReceiptDate = obj.ReceiptDate,
                        Amount = obj.Amount,
                        CollectedBy = obj.CollectedBy,
                        Remarks = obj.Remarks,
                        CreatedBy = obj.CreatedBy,
                        CreatedOn = DateTime.Now
                      
                    };
                    ctx.TblManualReceipt.Add(entity);
                    ctx.SaveChanges();
                    s.Complete();
                    s.Dispose();
                    ipk = entity.ManualReceiptId;

                    return ipk;
                }
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        public int Update(ManualReceiptVM obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.TblManualReceipt.FirstOrDefault(u => u.ManualReceiptId == obj.ManualReceiptId);
                    Data.ManualReceiptNo = obj.ManualReceiptNo; Data.ManualTaxName = obj.ManualTaxName; 
                    Data.ReceiptDate = obj.ReceiptDate;
                    Data.Amount = obj.Amount;
                    Data.CollectedBy = obj.CollectedBy;
                    Data.Remarks = obj.Remarks;
                    Data.ModifiedBy = obj.ModifiedBy; Data.ModifiedOn = DateTime.Now;
                    ctx.SaveChanges();
                    s.Complete();
                    s.Dispose();
                    return 1;
                }

            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}