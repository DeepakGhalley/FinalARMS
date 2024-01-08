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
    public class RevenueTransferBLL : IRevenueTransfer
    {
        readonly tt_dbContext ctx = new tt_dbContext();

        public bool CheckExistsAsync(int id)
        {
            return ctx.TblRevenueTransfer.Any(e => e.RevenueTransferId == id);
        }

        public async Task Delete(int? id)
        {
            var tblmannualreceipt = await ctx.TblRevenueTransfer
           .FirstOrDefaultAsync(m => m.RevenueTransferId == id);
        }

        public async Task DeleteConfirmed(int id)
        {
            using (TransactionScope s = new TransactionScope())
            {
                var TblRevenueTransfer = ctx.TblRevenueTransfer.Find(id);
                ctx.TblRevenueTransfer.Remove(TblRevenueTransfer);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();

            }
        }

        public async Task<RevenueTransferVM> Details(int? id)
        {
            var data = (from a in ctx.TblRevenueTransfer.Where(aa => aa.RevenueTransferId == id)
                        
                        select new RevenueTransferVM
                        {
                            RevenueTransferId= a.RevenueTransferId,
                            RevenueTransferAmount = a.RevenueTransferAmount,
                            RevenueTransferDate = a.RevenueTransferDate,
                            RevenueTakenBy = a.RevenueTakenBy,

                            Remarks = a.Remarks,
                        


                        });

            return await data.FirstOrDefaultAsync();
        }

       

     

        public IList<RevenueTransferVM> GetAll()
        {
            var data = (from a in ctx.TblRevenueTransfer
                        select new RevenueTransferVM
                        {
                            RevenueTransferId = a.RevenueTransferId,
                            RevenueTransferAmount = a.RevenueTransferAmount,
                            RevenueTransferDate = a.RevenueTransferDate,
                            RevenueTakenBy = a.RevenueTakenBy,
                            CreatedOn = a.CreatedOn,
                            Remarks = a.Remarks,
                          
                        });
            return data.ToList();
        }

        public int Save(RevenueTransferVM obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    int ipk;
                    var entity = new TblRevenueTransfer
                    {
                       
       
                       RevenueTransferId = obj.RevenueTransferId,
                          RevenueTransferAmount = obj.RevenueTransferAmount,
                        RevenueTransferDate = obj.RevenueTransferDate,
                        RevenueTakenBy = obj.RevenueTakenBy,
                        
                        Remarks = obj.Remarks,
                        CreatedBy = obj.CreatedBy,
                        CreatedOn = DateTime.Now,


                    };
                    ctx.TblRevenueTransfer.Add(entity);
                    ctx.SaveChanges();
                    s.Complete();
                    s.Dispose();
                    ipk = entity.RevenueTransferId;

                    return ipk;
                }
            }
            catch (System.Exception)
            {
                return 0;
            }
        }

        public int Update(RevenueTransferVM obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.TblRevenueTransfer.FirstOrDefault(u => u.RevenueTransferId == obj.RevenueTransferId);
                    Data.RevenueTransferAmount = obj.RevenueTransferAmount; Data.RevenueTransferDate = obj.RevenueTransferDate; 
                    Data.RevenueTakenBy = obj.RevenueTakenBy;
                  
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

        //Real cal
        public IList<RevenueIOVM> ROnline(string StartDate, string EndDate)
        {
            string myexc = "";
            try
            {
                var result = ctx.RevenueOnline.FromSqlRaw($"[dbo].[sp_Revenuetransferredonline] {StartDate},{EndDate}");

                return result.ToList();

            }
            catch (Exception ex)
            {
                myexc = ex.ToString();
                return null;

            }
        }

        public IEnumerable<RevenueIOVM> Rtransfer(string StartDate, string EndDate)
        {
            string myexc = "";
            try
            {
                var result = ctx.RevenuetransferRC.FromSqlRaw($"[dbo].[sp_Revenuetransfer] {StartDate},{EndDate}");

                return result.ToList(); 

            }
            catch (Exception ex)
            {
                myexc = ex.ToString();
                return null;

            }
        }
        public IEnumerable<RevenueIOVM> Ropeniingbalance(string StartDate,string EndDate)
        {
            string myexc = "";
            try
            {
                var result = ctx.Revenueopeningbalance.FromSqlRaw($"[dbo].[RevenuetransferOpeningbalace] {StartDate},{EndDate}");

                return result.ToList();

            }
            catch (Exception ex)
            {
                myexc = ex.ToString();
                return null;

            }
        }
        public IEnumerable<RevenueIOVM> Rmannual(string StartDate, string EndDate)
        {
            string myexc = "";
            try
            {
                var result = ctx.RevenueMannual.FromSqlRaw($"[dbo].[RevenuetransferredMannual] {StartDate},{EndDate}");

                return result.ToList();

            }
            catch (Exception ex)
            {
                myexc = ex.ToString();
                return null;

            }
        }




    }
}
