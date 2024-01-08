using CORE_BOL;
using CORE_BOL.Entities;
using CORE_DLL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;


namespace CORE_BLL
{
    public class TaxPayerProfileBLL : ITaxPayerProfile
    {
        readonly tt_dbContext ctx = new tt_dbContext();

        public bool CheckExists(int id)
        {
            return ctx.MstTaxPayerProfile.Any(e => e.TaxPayerId == id); ;
        }

        public async Task Delete(int? id)
        {
            var MstTaxPayerProfile = await ctx.MstTaxPayerProfile
            .FirstOrDefaultAsync(m => m.TaxPayerId == id);
        }

        public async Task DeleteConfirmed(int id)
        {
            using (TransactionScope s = new TransactionScope())
            {
                var MstTaxPayerProfile = ctx.MstTaxPayerProfile.Find(id);
                ctx.MstTaxPayerProfile.Remove(MstTaxPayerProfile);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
            }
        }

        public async Task<TaxPayerProfileModel> Details(int? id)
        {
           var data =(from a in ctx.MstTaxPayerProfile.Where(aa => aa.TaxPayerId == id)
                      join z in ctx.EnumTaxPayerType on a.TaxPayerTypeId equals z.TaxPayerTypeId
                      into tpt_temp
                      from tpt_value in tpt_temp.DefaultIfEmpty() //left join

                      //join b in ctx.MstVillage on a.PVillageId equals b.VillageId
                      //into v_temp
                      //from v_value in v_temp.DefaultIfEmpty()

                      //join c in ctx.MstDzongkhag on a.CDzongkhagId equals c.DzongkhagId
                      //into d_temp
                      //from d_value in d_temp.DefaultIfEmpty()

                      join d in ctx.MstOccupation on a.OccupationId equals d.OccupationId
                      into o_temp
                      from o_value in o_temp.DefaultIfEmpty()

                      join e in ctx.EnumGender on a.GenderId equals e.GenderId
                      into eg_temp
                      from eg_value in eg_temp.DefaultIfEmpty()

                      //join f in ctx.MstBankBranch on a.BankBranchId equals f.BankBranchId
                      //into bb_temp
                      //from bb_value in bb_temp.DefaultIfEmpty()

                      join g in ctx.EnumTitle on a.TitleId equals g.TitleId
                      into et_temp
                      from et_value in et_temp.DefaultIfEmpty()

                      //join h in ctx.MstGewog on v_value.GewogId equals h.GewogId
                      //into g_temp
                      //from g_value in g_temp.DefaultIfEmpty()

                      //join i in ctx.MstDzongkhag on g_value.DzongkhagId equals i.DzongkhagId
                      //join j in ctx.MstBank on bb_value.BankId equals j.BankId

                      join v in ctx.EnumVendorType on a.VendorTypeId equals v.VendorTypeId
                      into vt_temp
                      from vt_value in vt_temp.DefaultIfEmpty()

                      select new TaxPayerProfileModel
                        {
                            Name = a.FirstName + " " + a.MiddleName + " " + a.LastName,
                            TaxPayerId = a.TaxPayerId,
                            VendorTypeId = vt_value.VendorTypeId,
                            TaxPayerTypeId = a.TaxPayerTypeId,
                            TaxPayerType = tpt_value.TaxPayerType,
                            Ttin = a.Ttin,
                            Cid = a.Cid,
                            Tpn = a.Tpn,
                            TitleId = (int)a.TitleId,
                            Title = et_value.Title,
                            FirstName = a.FirstName,
                            MiddleName = a.MiddleName,
                            LastName = a.LastName,
                            Dob = a.Dob,
                            GenderId = a.GenderId,
                            Gender = eg_value.Gender,

                            //DzongkhagId = g_value.DzongkhagId,
                            //GewogId= g_value.GewogId,
                            //PVillageId = a.PVillageId,
                            //VillageName = v_value.VillageName,
                            //CDzongkhagId = (int)a.CDzongkhagId,
                            //DzongkhagName = d_value.DzongkhagName,

                            CAddress = a.CAddress,
                            OccupationId = a.OccupationId,
                            Occupation = o_value.Occupation,
                            WorkingAgency = a.WorkingAgency,
                            PhoneNo = a.PhoneNo,
                            MobileNo = a.MobileNo,
                            Email = a.Email,
                            Fax = a.Fax,
                            ContactPerson = a.ContactPerson,

                            //BankAccountNo = a.BankAccountNo,
                            //BankBranchId = (int)a.BankBranchId,
                            //BankId = j.BankId,
                            //BranchName = bb_value.BranchName,

                            CreatedBy = a.CreatedBy,
                            CreatedOn = a.CreatedOn,
                        });

            return await data.FirstOrDefaultAsync();
        }


        public bool DuplicateCheckOnSave(string Cid)
        {
            return ctx.MstTaxPayerProfile.Any(e => e.Cid == Cid);
        }
        public List<MstVillage> fetchPV(int id)
        {
            var data = (from a in ctx.MstVillage.Where(x => x.GewogId == id)

                        select new MstVillage
                        {
                            VillageId = a.VillageId,
                            VillageName = a.VillageName

                        });


            return data.ToList();
        }
        public List<MstGewog> fetchPG(int id)
        {
            var data = (from a in ctx.MstGewog.Where(x => x.DzongkhagId == id)
                        select new MstGewog
                        {
                            GewogId = a.GewogId,
                            GewogName = a.GewogName
                        });
            return data.ToList();
        }
        public List<MstBankBranch> fetchBB(int id)
        {
            var data = (from a in ctx.MstBankBranch.Where(x => x.BankId == id)
                        select new MstBankBranch
                        {
                            BankBranchId = a.BankBranchId,
                            BranchName = a.BranchName
                        });
            return data.ToList();
        }

        public IList<TaxPayerProfileModel> GetAll(int? id)
        {


            var data = (from x in ctx.MstTaxPayerProfile.Where(x => x.TaxPayerTypeId == id)
                        join a in ctx.EnumTaxPayerType on x.TaxPayerTypeId equals a.TaxPayerTypeId
                        join b in ctx.MstVillage on x.PVillageId equals b.VillageId
                        join c in ctx.MstDzongkhag on x.CDzongkhagId equals c.DzongkhagId
                        join d in ctx.MstOccupation on x.OccupationId equals d.OccupationId
                        join e in ctx.EnumGender on x.GenderId equals e.GenderId
                        join f in ctx.MstBankBranch on x.BankBranchId equals f.BankBranchId
                        join g in ctx.EnumTitle on x.TitleId equals g.TitleId

                        select new TaxPayerProfileModel
                        {
                            Name =   x.FirstName + " " + ((x.MiddleName == null || x.MiddleName.Trim() == string.Empty) ? string.Empty : (x.MiddleName + " ")) + ((x.LastName == null || x.LastName.Trim() == string.Empty) ? string.Empty : (x.LastName + " ")),
                            TaxPayerId = x.TaxPayerId,
                            TaxPayerTypeId = x.TaxPayerTypeId,
                            Ttin = x.Ttin,
                            Cid = x.Cid,
                            Tpn = x.Tpn,
                            TitleId = (int)x.TitleId,
                            FirstName = x.FirstName,
                            MiddleName = x.MiddleName,
                            LastName = x.LastName,
                            Dob = x.Dob,
                            GenderId = x.GenderId,
                            PVillageId = x.PVillageId,
                            CDzongkhagId = (int)x.CDzongkhagId,
                            CAddress = x.CAddress,
                            OccupationId = x.OccupationId,
                            WorkingAgency = x.WorkingAgency,
                            PhoneNo = x.PhoneNo,
                            MobileNo = x.MobileNo,
                            Email = x.Email,
                            Fax = x.Fax,
                            ContactPerson = x.ContactPerson,
                            BankAccountNo = x.BankAccountNo,
                            BankBranchId = (int)x.BankBranchId,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedDate = (DateTime)x.ModifiedDate,
                            ModifiedBy = x.ModifiedBy,
                            TaxPayerType = a.TaxPayerType,
                            VillageName = b.VillageName,
                            DzongkhagName = c.DzongkhagName,
                            Occupation = d.Occupation,
                            Gender = e.Gender,
                            BranchName = f.BranchName,
                            Title = g.Title,
                        });
            return data.ToList();
        }

        public int Save(TaxPayerProfileModel obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();

                var ttin = "";
                int ttid = (ctx.MstTaxPayerProfile.Max(x => x.TaxPayerId));
                if (ttid == 0)
                {
                    ttin = "000001";

                }
                else if (ttid >= 1 && ttid <= 9)
                {
                    ttin = "00000" + (ttid +1).ToString();

                }
                else if (ttid > 9 && ttid <= 99)
                {
                    ttin = "0000" + (ttid + 1).ToString();

                }
                else if (ttid > 99 && ttid <= 999)
                {
                    ttin = "000" + (ttid + 1).ToString();

                }
                else if(ttid > 999 && ttid <= 9999)
                {
                    ttin = "00" + (ttid + 1).ToString();
                }
                else if(ttid > 9999 && ttid <= 99999)
                {
                    ttin = "0" + (ttid + 1).ToString();
                }
                else
                {
                    ttin = ttid.ToString();
                }

                //Removed Fileds
                if (obj.BankBranchId==0)
                {
                    obj.BankBranchId = null;
                }

                if (obj.PVillageId == 0)
                {
                    obj.PVillageId = 4701;
                }

                if (obj.OccupationId == 0)
                {
                    obj.OccupationId = 9;
                }

                if (obj.CDzongkhagId == 0)
                {
                    obj.CDzongkhagId = 99;
                }

                if (obj.TitleId == 0)
                {
                    obj.TitleId = 13;
                }

                if (obj.GenderId == 0)
                {
                    obj.GenderId = 3;
                }

                if (obj.VendorTypeId == 0)
                {
                    obj.VendorTypeId = 2;
                }

                if(obj.Cid == null)
                {
                    obj.Cid = "-";
                }
          


                int ipk;
                    var entity = new MstTaxPayerProfile
                    {
                        Cid = obj.Cid.Trim(),
                        VendorTypeId = obj.VendorTypeId,
                        Dob = obj.Dob,
                        CDzongkhagId = obj.CDzongkhagId,
                        TaxPayerTypeId = obj.TaxPayerTypeId,
                        Ttin = ttin,
                        TitleId = obj.TitleId,
                        FirstName = obj.FirstName,
                        MiddleName = obj.MiddleName,
                        LastName = obj.LastName,
                        GenderId = obj.GenderId,
                        PVillageId = obj.PVillageId,
                        CAddress = obj.CAddress,
                        OccupationId = obj.OccupationId,
                        MobileNo = obj.MobileNo,
                        Email = obj.Email,
                        BankAccountNo = obj.BankAccountNo,
                        BankBranchId = obj.BankBranchId,
                        IsActive = obj.IsActive,
                        CreatedBy = obj.CreatedBy,
                        CreatedOn = Convert.ToDateTime(obj.CreatedOn),
                    };
                    ctx.MstTaxPayerProfile.Add(entity);
                    ctx.SaveChanges();
                    s.Complete();
                    s.Dispose();
                    ipk = entity.TaxPayerId;
                
                return ipk;

            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        //This Update is for Organisation
        public int Update(TaxPayerProfileModel obj)
            {
                try
                {
                    using (TransactionScope s = new TransactionScope())
                    {
                        var Data = ctx.MstTaxPayerProfile.FirstOrDefault(u => u.TaxPayerId == obj.TaxPayerId);
                        Data.Ttin = obj.Ttin; 
                        //Data.Tpn = obj.Tpn;
                        Data.FirstName = obj.FirstName;
                        Data.CAddress = obj.CAddress; 
                        //Data.PhoneNo = obj.PhoneNo;
                        Data.MobileNo = obj.MobileNo; 
                        Data.Email = obj.Email;
                        //Data.Fax = obj.Fax;Data.ContactPerson = obj.ContactPerson;
                        //Data.BankAccountNo = obj.BankAccountNo; Data.BankBranchId = obj.BankBranchId;
                        Data.ModifiedBy = obj.ModifiedBy; Data.ModifiedDate = obj.ModifiedDate;
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


        //This is for Organisation index
        public List<TaxPayerProfileModel> fetchOrganisation(string ttin, string name)
        {
           // var data = (from a in ctx.MstTaxPayerProfile.Where(x => x.TaxPayerTypeId == 2 && (x.Ttin == ttin) || (x.FirstName + ' ' + x.MiddleName + ' ' + x.LastName) == name)
            var data = (from a in ctx.MstTaxPayerProfile.Where(x => x.TaxPayerTypeId == 2 
                                                                      && (x.Ttin == ttin 
                                                                      ||  x.FirstName .StartsWith(name) 
                                                                      ||  x.MiddleName.StartsWith(name) 
                                                                      ||  x.LastName.StartsWith(name) 
                        
                                                                      ||  x.FirstName .EndsWith(name) 
                                                                      ||  x.MiddleName.EndsWith(name) 
                                                                      ||  x.LastName.EndsWith(name)                                    
                                                                       )

                                                                )
                 
                        select new TaxPayerProfileModel
                        {
                            TaxPayerId = a.TaxPayerId,
                            Cid = a.Cid,
                            Ttin = a.Ttin,
                            Name = a.FirstName + " " + ((a.MiddleName == null || a.MiddleName.Trim() == string.Empty) ? string.Empty : (a.MiddleName + " ")) + ((a.LastName == null || a.LastName.Trim() == string.Empty) ? string.Empty : (a.LastName + " ")),
                            MobileNo = a.MobileNo,
                            Email = a.Email
                        });
            return data.ToList();
        }

        public List<TaxPayerProfileModel> fetchOrganisationAll()
        {
            var data = (from a in ctx.MstTaxPayerProfile.Where(x => x.TaxPayerTypeId == 2)
                        select new TaxPayerProfileModel
                        {
                            TaxPayerId = a.TaxPayerId,
                            Cid = a.Cid,
                            Ttin = a.Ttin,
                            Name = a.FirstName + " " + ((a.MiddleName == null || a.MiddleName.Trim() == string.Empty) ? string.Empty : (a.MiddleName + " ")) + ((a.LastName == null || a.LastName.Trim() == string.Empty) ? string.Empty : (a.LastName + " ")),
                            MobileNo = a.MobileNo,
                            Email = a.Email
                        });
            return data.ToList();
        }


        //This Update is for Individual
        public int IndividualUpdate(TaxPayerProfileModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstTaxPayerProfile.FirstOrDefault(u => u.TaxPayerId == obj.TaxPayerId);
                    Data.Ttin = obj.Ttin;
                    Data.Cid = obj.Cid; 
                    //Data.Tpn = obj.Tpn;
                    //Data.TitleId = obj.TitleId;
                    Data.FirstName = obj.FirstName; Data.MiddleName = obj.MiddleName; Data.LastName = obj.LastName;
                    //Data.Dob = obj.Dob; Data.GenderId = obj.GenderId;
                    //Data.PVillageId = obj.PVillageId; Data.CDzongkhagId = obj.CDzongkhagId;
                    Data.CAddress = obj.CAddress; 
                    //Data.OccupationId = obj.OccupationId;
                    //Data.WorkingAgency = obj.WorkingAgency;
                    //Data.PhoneNo = obj.PhoneNo;
                    Data.MobileNo = obj.MobileNo; 
                    Data.Email = obj.Email;
                    //Data.Fax = obj.Fax; Data.ContactPerson = obj.ContactPerson;
                    //Data.BankAccountNo = obj.BankAccountNo; Data.BankBranchId = obj.BankBranchId;
                    Data.ModifiedBy = obj.ModifiedBy; 
                    Data.ModifiedDate = obj.ModifiedDate;
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

        //This is for Individual index
        public List<TaxPayerProfileModel> fetchIndividual(string cid, string ttin)
        {
            var data = (from a in ctx.MstTaxPayerProfile.Where(x => (x.Cid == cid) || x.Ttin == ttin && x.TaxPayerTypeId == 1)
                        select new TaxPayerProfileModel
                        {
                            TaxPayerId = a.TaxPayerId,
                            Cid = a.Cid,
                            Ttin = a.Ttin,
                            Name = a.FirstName + " " + ((a.MiddleName == null || a.MiddleName.Trim() == string.Empty) ? string.Empty : (a.MiddleName + " ")) + ((a.LastName == null || a.LastName.Trim() == string.Empty) ? string.Empty : (a.LastName + " ")),
                            MobileNo = a.MobileNo,
                            Email = a.Email
                        });
            return data.ToList();
        }

        public List<TaxPayerProfileModel> fetchIndividualAll()
        {
            var data = (from a in ctx.MstTaxPayerProfile.Where(x => x.TaxPayerTypeId == 1)
                        select new TaxPayerProfileModel
                        {
                            TaxPayerId = a.TaxPayerId,
                            Cid = a.Cid,
                            Ttin = a.Ttin,
                            Name = a.FirstName + " " + ((a.MiddleName == null || a.MiddleName.Trim() == string.Empty) ? string.Empty : (a.MiddleName + " ")) + ((a.LastName == null || a.LastName.Trim() == string.Empty) ? string.Empty : (a.LastName + " ")),
                            MobileNo = a.MobileNo,
                            Email = a.Email
                        });
            return data.ToList();
        }


        //This Update is for Vendor
        public int VendorUpdate(TaxPayerProfileModel obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.MstTaxPayerProfile.FirstOrDefault(u => u.TaxPayerId == obj.TaxPayerId);
                    Data.Ttin = obj.Ttin;
                    Data.Cid = obj.Cid;
                    //Data.VendorTypeId = obj.VendorTypeId;
                    //Data.Tpn = obj.Tpn;
                    //Data.TitleId = obj.TitleId;
                    Data.FirstName = obj.FirstName; Data.MiddleName = obj.MiddleName; Data.LastName = obj.LastName;
                    //Data.Dob = obj.Dob; Data.GenderId = obj.GenderId;
                    //Data.PVillageId = obj.PVillageId; Data.CDzongkhagId = obj.CDzongkhagId;
                    Data.CAddress = obj.CAddress; 
                    //Data.OccupationId = obj.OccupationId;
                    //Data.WorkingAgency = obj.WorkingAgency;
                    //Data.PhoneNo = obj.PhoneNo;
                    Data.MobileNo = obj.MobileNo; 
                    Data.Email = obj.Email;
                    //Data.Fax = obj.Fax; Data.ContactPerson = obj.ContactPerson;
                    //Data.BankAccountNo = obj.BankAccountNo; Data.BankBranchId = obj.BankBranchId;
                    Data.ModifiedBy = obj.ModifiedBy; Data.ModifiedDate = obj.ModifiedDate;
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

        //This is for Vendor index
        public List<TaxPayerProfileModel> fetchVendor(/*string cid, */string ttin, string name)
        {

            var data = (from a in ctx.MstTaxPayerProfile.Where(x => x.TaxPayerTypeId == 3
                                                                      && (x.Ttin == ttin
                                                                      || x.FirstName.StartsWith(name)
                                                                      || x.MiddleName.StartsWith(name)
                                                                      || x.LastName.StartsWith(name)

                                                                      || x.FirstName.EndsWith(name)
                                                                      || x.MiddleName.EndsWith(name)
                                                                      || x.LastName.EndsWith(name)
                                                                       )


                                                                )
                        select new TaxPayerProfileModel
                        {
                            TaxPayerId = a.TaxPayerId,
                            Cid = a.Cid,
                            Ttin = a.Ttin,
                            Name = a.FirstName + " " + ((a.MiddleName == null || a.MiddleName.Trim() == string.Empty) ? string.Empty : (a.MiddleName + " ")) + ((a.LastName == null || a.LastName.Trim() == string.Empty) ? string.Empty : (a.LastName + " ")),
                            MobileNo = a.MobileNo,
                            Email = a.Email
                        });
            return data.ToList();
        }


        public List<TaxPayerProfileModel> fetchVendorAll()
        {
            var data = (from a in ctx.MstTaxPayerProfile.Where(x => x.TaxPayerTypeId == 3)
                        select new TaxPayerProfileModel
                        {
                            TaxPayerId = a.TaxPayerId,
                            Cid = a.Cid,
                            Ttin = a.Ttin,
                            Name = a.FirstName + " " + ((a.MiddleName == null || a.MiddleName.Trim() == string.Empty) ? string.Empty : (a.MiddleName + " ")) + ((a.LastName == null || a.LastName.Trim() == string.Empty) ? string.Empty : (a.LastName + " ")),
                            MobileNo = a.MobileNo,
                            Email = a.Email
                        });
            return data.ToList();
        }

        //***end****


        public bool DuplicateCheckOnUpdate(string Cid, int Id)
        {
            return ctx.MstTaxPayerProfile.Any(e => e.Cid == Cid && e.TaxPayerId != Id);
        }

         List<MstTaxPayerProfile> ITaxPayerProfile.fetchCID(string cid, string ttin)
        {
            var data = (from a in ctx.MstTaxPayerProfile.Where(x => x.Cid == cid || x.Ttin == ttin)
                        join b in ctx.EnumTitle on a.TitleId equals b.TitleId
                        select new MstTaxPayerProfile
                        {
                            Cid = a.Cid,
                            Ttin = a.Ttin,
                            TitleId = a.TitleId,
                            //TitleId = b.TitleId,
                            FirstName = a.FirstName,
                            MiddleName = a.MiddleName ?? "",
                            LastName = a.LastName ?? "",
                            TaxPayerId = a.TaxPayerId

                        });
            return data.ToList();
        }

        List<MstTaxPayerProfile> ITaxPayerProfile.fetchTaxPayer(string cid, string ttin)
        {
            var data = (from a in ctx.MstTaxPayerProfile.Where(x => x.Cid == cid || x.Ttin == ttin)
                        join b in ctx.EnumTitle on a.TitleId equals b.TitleId
                        select new MstTaxPayerProfile
                        {
                            Cid = a.Cid,
                            Ttin = a.Ttin,
                            TitleId = a.TitleId,
                            FirstName = a.FirstName,
                            MiddleName = a.MiddleName,
                            LastName = a.LastName,
                            TaxPayerId = a.TaxPayerId

                        });
            return data.ToList();
        }



    }
}     