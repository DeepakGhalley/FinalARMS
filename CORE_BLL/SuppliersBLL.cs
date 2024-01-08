using CORE_DLL;
using System;
using System.Collections.Generic;
using CORE_BOL;
using CORE_BOL.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Transactions;

namespace CORE_BLL
{
  public  class SuppliersBLL : ISuppliers
    {
        readonly tt_dbContext ctx = new tt_dbContext();
        public IList<SuppliersVM> GetAll()
        {
            try
            {
                var data = (from x in ctx.MstSuppliers
                            select new SuppliersVM
                            {
                                SupplierId = x.SupplierId,
                                SupplierCode = x.SupplierCode,
                                SupplierName = x.SupplierName,
                                SupplierAddress = x.SupplierAddress,
                                SupplierContactPerson = x.SupplierContactPerson,
                                SupplierContactNumber = x.SupplierContactNumber,
                                SupplierFaxNumber = x.SupplierFaxNumber,
                                LicenseNo=x.LicenseNo,
                                IsActive = x.IsActive,
                                CreatedBy = x.CreatedBy,
                                CreatedOn = x.CreatedOn,
                                ModifiedOn = x.ModifiedOn,
                                ModifiedBy = x.ModifiedBy
                            });
                return data.ToList();
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public int Save(SuppliersVM obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    int ipk;
                    var entity = new MstSuppliers
                    {
                        SupplierId = obj.SupplierId,
                        SupplierCode = obj.SupplierCode,
                        SupplierName=obj.SupplierName,
                        SupplierAddress = obj.SupplierAddress,
                        SupplierContactPerson = obj.SupplierContactPerson,
                        SupplierContactNumber = obj.SupplierContactNumber,
                        SupplierFaxNumber = obj.SupplierFaxNumber,
                        LicenseNo = obj.LicenseNo,
                        IsActive = true,
                        CreatedBy = obj.CreatedBy,
                        CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                    };
                    ctx.MstSuppliers.Add(entity);
                    ctx.SaveChanges();
                    s.Complete();
                    s.Dispose();
                    ipk = entity.SupplierId;

                    return ipk;
                }
            }
          
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<SuppliersVM> Details(int? id)
        {
            try
            {

                var data = (from a in ctx.MstSuppliers.Where(aa => aa.SupplierId == id)

                            select new SuppliersVM
                            {
                                SupplierId = a.SupplierId,
                                SupplierCode = a.SupplierCode,
                                SupplierName = a.SupplierName,
                                SupplierAddress = a.SupplierAddress,
                                SupplierContactPerson = a.SupplierContactPerson,
                                SupplierContactNumber = a.SupplierContactNumber,
                                SupplierFaxNumber = a.SupplierFaxNumber,
                                LicenseNo = a.LicenseNo,
                                IsActive = a.IsActive,
                                CreatedBy = a.CreatedBy,
                                CreatedOn = a.CreatedOn,
                                ModifiedBy = a.ModifiedBy,
                                ModifiedOn = a.ModifiedOn,

                            });

                return await data.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public int Update(SuppliersVM obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstSuppliers.FirstOrDefault(u => u.SupplierId == obj.SupplierId);
                    Data.SupplierCode = obj.SupplierCode; Data.SupplierName = obj.SupplierName;
                    Data.SupplierAddress = obj.SupplierAddress; Data.SupplierContactPerson = obj.SupplierContactPerson;
                    Data.SupplierContactNumber = obj.SupplierContactNumber; Data.SupplierFaxNumber = obj.SupplierFaxNumber;
                    Data.LicenseNo=obj.LicenseNo; Data.IsActive = obj.IsActive;Data.ModifiedBy = obj.ModifiedBy; Data.ModifiedOn = obj.ModifiedOn;
                    ctx.SaveChanges();
                    s.Complete();
                    s.Dispose();
                    return 1;
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task Delete(int? id)
        {
            try
            {
                var mstSuppliers = await ctx.MstSuppliers                               
                               .FirstOrDefaultAsync(m => m.SupplierId == id);
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public async Task DeleteConfirmed(int id)
        {
            try
            {

                using (TransactionScope s = new TransactionScope())
                {
                    var mstSuppliers = ctx.MstSuppliers.Find(id);
                    ctx.MstSuppliers.Remove(mstSuppliers);
                    ctx.SaveChanges();
                    s.Complete();
                    s.Dispose();

                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool CheckExists(int id)
        {
            try
            {
                return ctx.MstSuppliers.Any(e => e.SupplierId == id);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool DuplicateCheckOnSave(string LicenseNo)
        {
            return ctx.MstSuppliers.Any(e => e.LicenseNo == LicenseNo);
        }
        public bool DuplicateCheckOnUpdate(string LicenseNo, int Id)
        {
            return ctx.MstSuppliers.Any(e => e.LicenseNo == LicenseNo && e.SupplierId != Id);
        }

    }
}
