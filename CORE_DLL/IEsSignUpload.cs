using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CORE_BOL;
using Microsoft.AspNetCore.Http;

namespace CORE_DLL
{
    public interface IEsSignUpload
    {
        IList<EsSignUploadsModel> GetAll();
        Task<EsSignUploadsModel> Details(int? id);
        int Save(EsSignUploadsModel obj, IFormFile SourceFile);
        int Update(EsSignUploadsModel obj, IFormFile SourceFile);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        bool DuplicateCheckOnSave(int UserId);
        bool DuplicateCheckOnUpdate(int UserId, int Id);
    }
}
