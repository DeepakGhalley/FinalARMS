using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CORE_BOL;
using Microsoft.AspNetCore.Http;

namespace CORE_DLL
{
    public interface IDcdSignUpload
    {
        IList<DcdsignUploadModel> GetAll();
        Task<DcdsignUploadModel> Details(int? id);
        int Save(DcdsignUploadModel obj, IFormFile SourceFile);
        int Update(DcdsignUploadModel obj, IFormFile SourceFile);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        bool DuplicateCheckOnSave(int UserId);
        bool DuplicateCheckOnUpdate(int UserId, int Id);
    }
}
