﻿using CORE_DLL;
using System;
using System.Collections.Generic;
using CORE_BOL;
using CORE_BOL.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Transactions;
using System.Data;

using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
//using System.Security.Cryptography.X509Certificat
namespace CORE_BLL
{
    public class UserBLL : IUser
    {
        readonly tt_dbContext ctx = new tt_dbContext();
      
        public IList<UserDTO> GetAll()
        {
            var data = (from x in ctx.AspNetUsers
                        join b in ctx.TblRole on x.RoleId equals b.RoleId
                        //join c in ctx.EnumTitle on x.TitleId equals c.TitleId
                        join d in ctx.MstSection on x.SectionId equals d.SectionId into d_temp
                        from d_value in d_temp.DefaultIfEmpty() //left join

                        select new UserDTO
                        {
                            UserId = x.UserId,
                            SectionId = x.SectionId,
                            PhoneNo = x.PhoneNumber,
                            RoleId = (int)x.RoleId,
                            UserName = x.UserName,
                            //Password = x.Password,
                            FirstName = x.FirstName,
                            MiddleName = x.MiddleName,
                            LastName = x.LastName,
                            Cid = x.Cid,
                            Eid = x.Eid,
                            //Dob = x.Dob,
                            //IsActive = x.IsActive,
                            //Title = c.Title,
                            SectionName = d_value.SectionName,
                            RoleName = b.RoleName,
                            FullName = String.Concat(x.FirstName, " ", x.MiddleName, " ", x.LastName)
                        });
            return data.ToList();

        }
        

        public async Task<UserDTO> Details(int? id)
        {
            
            var data = (from a in ctx.AspNetUsers.Where(aa => aa.UserId == id)
                        
                        select new UserDTO
                        {
                            UserId = a.UserId,
                            RoleId = (int)a.RoleId,
                            SectionId = a.SectionId,
                            UserName = a.UserName,
                            Password = a.PasswordHash,
                            
                            FirstName = a.FirstName,
                            MiddleName = a.MiddleName,
                            LastName = a.LastName,
                            Cid = a.Cid,
                            Eid = a.Eid,
                            Dob = (DateTime)a.Dob,
                            
                           

                        });

            return await data.FirstOrDefaultAsync();

        }
        
        public int SaveUser(UserDTO obj)
        {
            try
            {
                using TransactionScope s = new TransactionScope();
                int ipk;
                var entity = new AspNetUsers
                {
                    Id = obj.Id,
                    UserId = obj.UserId,
                    RoleId = obj.RoleId,
                    UserName = obj.UserName.Trim(),
                    PasswordHash = obj.Password,
                    //IsActive = obj.IsActive,
                    //CreatedBy = obj.CreatedBy,
                    //CreatedOn = obj.CreatedOn,
                    //TitleId = obj.TitleId,
                    SectionId = obj.SectionId,
                    FirstName = obj.FirstName,
                    MiddleName = obj.MiddleName,
                    LastName = obj.LastName,
                    Eid = obj.Eid,
                    Cid = obj.Cid,
                    Dob = obj.Dob
                };
                ctx.AspNetUsers.Add(entity);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                ipk = entity.UserId;

                return ipk;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int UpdateUser(UserDTO obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.AspNetUsers.FirstOrDefault(u => u.UserId == obj.UserId);
                    Data.UserName = obj.UserName;
                    //Data.PasswordHash = obj.Password; 
                    //Data.IsActive = obj.IsActive;
                    Data.RoleId = obj.RoleId;
                    Data.Email = obj.UserName;
                    Data.SectionId = obj.SectionId;
                    //Data.ModifiedBy = obj.ModifiedBy; Data.ModifiedOn = obj.ModifiedOn;
                    Data.Dob = obj.Dob; Data.Eid = obj.Eid; Data.Cid = obj.Cid; Data.FirstName = obj.FirstName;
                    Data.MiddleName = obj.MiddleName; Data.LastName = obj.LastName;
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
        public bool CheckExists(int id)
        {
            return ctx.MstUser.Any(e => e.UserId == id);
        }

        public async Task DeleteConfirmed(int id)
        {
            using (TransactionScope s = new TransactionScope())
            {
                var MstUser = ctx.MstUser.Find(id);
                ctx.MstUser.Remove(MstUser);
                ctx.SaveChanges();
                s.Complete();
                s.Dispose();
                //var user = ctx.TblMstUser.FirstOrDefault(u => u.UserId == obj.UserId);
                //user.UserName = obj.UserName; user.IsActive = obj.IsActive;
                //user.ModifiedBy = obj.ModifiedBy; user.ModifiedOn = obj.ModifiedOn;
                //ctx.SaveChanges();
                //s.Complete();

            }
        }

        public async Task Delete(int? id)
        {
            var MstUser = await ctx.MstUser
                           .Include(t => t.Role).Include(s => s.Section).Include(d => d.Title)
                           .FirstOrDefaultAsync(m => m.UserId == id);
        }

        public bool DuplicateCheckOnSave(string UserName)
        {
            return ctx.AspNetUsers.Any(e => e.UserName == UserName);
        }
        public bool DuplicateCheckOnUpdate(string UserName, int Id)
        {
            return ctx.AspNetUsers.Any(e => e.UserName == UserName && e.UserId != Id);
        }

        public async Task<UserDTO> DetailsByUserId(string EmailId)
        {
            var data = (from a in ctx.AspNetUsers.Where(aa => aa.Email == EmailId)
                            //join b in ctx.TblRole on a.RoleId equals b.RoleId
                            //join c in ctx.EnumTitle on a.TitleId equals c.TitleId
                            //join d in ctx.MstSection on a.SectionId equals d.SectionId
                        select new UserDTO
                        {
                            UserId = a.UserId,
                            RoleId = (int)a.RoleId,
                            //UserName = a.UserName,
                            //Password = a.Password
                            //,
                            IsActive = a.LockoutEnabled,
                            //CreatedBy = a.CreatedBy,
                            //CreatedOn = a.CreatedOn
                            //,
                            //ModifiedBy = a.ModifiedBy,
                            //ModifiedOn = a.ModifiedOn,
                            //RoleId = a.RoleId
                            //,
                            FirstName = a.FirstName,
                            MiddleName = a.MiddleName ?? "",
                            LastName = a.LastName ?? "",
                            Cid = a.Cid,
                            Eid = a.Eid,
                            //Dob = a.Dob,
                            //RoleName = b.RoleName,
                            //SectionName = d.SectionName,
                            //TitleId = a.TitleId,
                            //SectionId = a.SectionId,
                            //Title = c.Title,

                        });

            return await data.FirstOrDefaultAsync();
        }

        //USER UPDATION BY ADMIN
        public List<UserProfileVM> GetUserDetails(string email)
        {
            var data = (from a in ctx.AspNetUsers.Where(x => (string.IsNullOrEmpty(email) || x.Email == email))
                        join b in ctx.TblRole on a.RoleId equals b.RoleId into x
                        from bb in x.DefaultIfEmpty()

                        join c in ctx.MstSection on a.SectionId equals c.SectionId into y
                        from cc in y.DefaultIfEmpty()
                        select new UserProfileVM
                        {
                            Cid = (a.Cid == null || a.Cid.Trim() == string.Empty) ? string.Empty : (a.Cid + " "),
                            Eid = (a.Eid == null || a.Eid.Trim() == string.Empty) ? string.Empty : (a.Eid + " "),
                            FirstName = (a.FirstName == null || a.FirstName.Trim() == string.Empty) ? string.Empty : (a.FirstName + " "),
                            MiddleName = (a.MiddleName == null || a.MiddleName.Trim() == string.Empty) ? string.Empty : (a.MiddleName + " "),
                            LastName = (a.LastName == null || a.LastName.Trim() == string.Empty) ? string.Empty : (a.LastName + " "),
                            Dob = (DateTime)a.Dob ,
                            Email = (a.Email == null || a.Email.Trim() == string.Empty)? string.Empty : (a.Email + " "),
                            PhoneNo = (a.PhoneNumber == null || a.PhoneNumber.Trim() == string.Empty) ? string.Empty : (a.PhoneNumber + " "),
                            UserId = a.UserId,
                            Id = a.Id,
                            RoleId = (int)a.RoleId,
                            RoleName = (bb.RoleName == null || bb.RoleName.Trim() == string.Empty) ? string.Empty : (bb.RoleName + " "),
                            SectionId = (int)a.SectionId,
                            SectionName = (cc.SectionName == null || cc.SectionName.Trim() == string.Empty) ? string.Empty : (cc.SectionName + " ")


                        });
            return data.ToList();
        }
        public long UpdateInfoByAmin(UserProfileVM obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.AspNetUsers.FirstOrDefault(u => u.UserId == obj.UserId);
                    Data.FirstName = obj.FirstName;
                    Data.MiddleName = obj.MiddleName;
                    Data.LastName = obj.LastName;
                    Data.Cid = obj.Cid;
                    Data.Eid = obj.Eid;
                    Data.Email = obj.Email;
                    Data.PhoneNumber = obj.PhoneNo;
                    Data.Dob = obj.Dob;
                    Data.RoleId = obj.RoleId;
                    Data.SectionId = obj.SectionId;
                    Data.UserName = obj.Email;
                    Data.NormalizedEmail = obj.Email;
                    Data.NormalizedUserName = obj.Email;


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
        public List<UserProfileVM> GetDetails(int UserId)
        {
            var data = (from a in ctx.AspNetUsers.Where(x => x.UserId == UserId)
                        join b in ctx.TblRole on a.RoleId equals b.RoleId into x
                        from bb in x.DefaultIfEmpty()
                        join c in ctx.MstSection on a.SectionId equals c.SectionId into y
                        from cc in y.DefaultIfEmpty()
                        //where(a.Email == EmailId && a.UserId!= UserId)

                        select new UserProfileVM
                        {
                            Cid = a.Cid,
                            Eid = a.Eid,
                            FirstName = a.FirstName,
                            MiddleName = a.MiddleName,
                            LastName = a.LastName,
                            Dob = (DateTime)a.Dob,
                            Email = a.Email,
                            PhoneNo = a.PhoneNumber,
                            SectionId = (int)a.SectionId,
                            SectionName = cc.SectionName,
                            RoleId = (int)a.RoleId,
                            RoleName = bb.RoleName




                        });
            return data.ToList();
        }
        public bool GetEmails(string email, int userid)
        {
            return ctx.AspNetUsers.Any(a => a.Email == email && a.UserId != userid);
                
        }

        //UPDATE PERSONAL DETAILS
        public List<UserProfileVM> GetUserInfo(int UserId)
        {
            var data = (from x in ctx.AspNetUsers.Where(x => x.UserId == UserId)
                        join y in ctx.MstSection on x.SectionId equals y.SectionId
                        join z in ctx.MstDivision on y.DivisionId equals z.DivisionId
                        join a in ctx.TblRole on x.RoleId equals a.RoleId

                        select new UserProfileVM
                        {
                            UserId = x.UserId,
                            FirstName = x.FirstName,
                            MiddleName = x.MiddleName,
                            LastName = x.LastName,
                            Cid = x.Cid,
                            Eid = x.Eid,
                            Dob = (DateTime)x.Dob,
                            PhoneNo = x.PhoneNumber,
                            Email = x.Email,
                            RoleId = a.RoleId,
                            RoleName = a.RoleName,
                            SectionId = y.SectionId,
                            SectionName = y.SectionName,
                            DivisionId = z.DivisionId,
                            DivisionName = z.DivisionName
                           
                        });
            return data.ToList();

        }

        public long UpdatePersonalInfo(UserProfileVM obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.AspNetUsers.FirstOrDefault(u => u.UserId == obj.UserId);
                    Data.FirstName = obj.FirstName;
                    Data.MiddleName = obj.MiddleName;
                    Data.LastName = obj.LastName;
                    Data.Cid = obj.Cid;
                    Data.Eid = obj.Eid;
                    Data.Email = obj.Email;
                    Data.PhoneNumber = obj.PhoneNo;
                    Data.Dob = obj.Dob;
                    //Data.UserId = (int)obj.UserId;
                   


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


        public long Activate(UserProfileVM obj)
        {
            try
            {
                using (TransactionScope s = new TransactionScope())
                {
                    var Data = ctx.AspNetUsers.FirstOrDefault(u => u.UserId == obj.UserId);
                    Data.LockoutEnabled = true;
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

            public long Deactivate(UserProfileVM obj)
            {
                try
                {
                    using (TransactionScope s = new TransactionScope())
                    {
                        var Data = ctx.AspNetUsers.FirstOrDefault(u => u.UserId == obj.UserId);
                        Data.LockoutEnabled = false;
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
            public List<UserProfileVM> GetPersonalDetails(int UserId)
        {
            var data = (from a in ctx.AspNetUsers.Where(x => x.UserId == UserId)
                        join x in ctx.TblRole on a.RoleId equals x.RoleId
                        join y in ctx.MstSection on a.SectionId equals y.SectionId
                        join z in ctx.MstDivision on y.DivisionId equals z.DivisionId
                        select new UserProfileVM
                        {
                            Cid = a.Cid,
                            Eid = a.Eid,
                            FirstName = a.FirstName,
                            MiddleName = a.MiddleName,
                            LastName = a.LastName,
                            Dob = (DateTime)a.Dob,
                            Email = a.Email,
                            PhoneNo = a.PhoneNumber,
                            UserId = a.UserId,
                            RoleName = x.RoleName,
                            DivisionName = z.DivisionName,
                            SectionName = y.SectionName
                                                
                        });
            return data.ToList();
        }
        public bool GetPersonalEmails(string email, int userid)
        {
            return ctx.AspNetUsers.Any(a => a.Email == email && a.UserId != userid);
        }

        public List<UserProfileVM> GetAllUserDetails()
        {
            var data = (from a in ctx.AspNetUsers
                        join b in ctx.TblRole on a.RoleId equals b.RoleId into x
                        from bb in x.DefaultIfEmpty()

                        join c in ctx.MstSection on a.SectionId equals c.SectionId into y
                        from cc in y.DefaultIfEmpty()
                        select new UserProfileVM
                        {
                            Cid = (a.Cid == null || a.Cid.Trim() == string.Empty) ? string.Empty : (a.Cid + " "),
                            Eid = (a.Eid == null || a.Eid.Trim() == string.Empty) ? string.Empty : (a.Eid + " "),
                            FirstName = (a.FirstName == null || a.FirstName.Trim() == string.Empty) ? string.Empty : (a.FirstName + " "),
                            MiddleName = (a.MiddleName == null || a.MiddleName.Trim() == string.Empty) ? string.Empty : (a.MiddleName + " "),
                            LastName = (a.LastName == null || a.LastName.Trim() == string.Empty) ? string.Empty : (a.LastName + " "),
                            RoleId = (int)a.RoleId,
                            RoleName = (bb.RoleName == null || bb.RoleName.Trim() == string.Empty) ? string.Empty : (bb.RoleName + " "),
                            SectionId = (int)a.SectionId,
                            SectionName = (cc.SectionName == null || cc.SectionName.Trim() == string.Empty) ? string.Empty : (cc.SectionName + " "),
                            UserName = (a.UserName == null || a.UserName.Trim() == string.Empty) ? string.Empty : (a.UserName + " "),
                            UserId = a.UserId

                        });
            return data.ToList();
        }
    }
}
