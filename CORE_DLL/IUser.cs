﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CORE_BOL;
using CORE_BOL.Entities;

namespace CORE_DLL
{
    public interface IUser
    {
      IList<UserDTO> GetAll(); 
        //Task<IEnumerable<TblMstUser>> Details(int? id);
        Task<UserDTO> Details(int? id);
      int SaveUser(UserDTO obj);
        int UpdateUser(UserDTO obj);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
       bool CheckExists(int id);
       bool DuplicateCheckOnSave(string UserName);
        bool DuplicateCheckOnUpdate(string UserName,int Id);
        Task<UserDTO> DetailsByUserId(string EmailId);
        List<UserProfileVM> GetUserDetails(string email);
        List<UserProfileVM> GetAllUserDetails();
        long UpdateInfoByAmin(UserProfileVM obj);
        List<UserProfileVM> GetDetails(int UserId);
        bool GetEmails(string email, int userid);
        long UpdatePersonalInfo(UserProfileVM obj);
        long Activate(UserProfileVM obj);
        long Deactivate(UserProfileVM obj);
        List<UserProfileVM> GetPersonalDetails(int UserId);
        bool GetPersonalEmails(string email, int userid);
        List<UserProfileVM> GetUserInfo(int UserId);
        //Task<IEnumerable<UsersModel>> GetAllUsers(int fiscal_year);
    }
}
