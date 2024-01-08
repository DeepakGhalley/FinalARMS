using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CORE_BOL;
using Microsoft.AspNetCore.Http;

namespace CORE_DLL
{
    public interface ILogoUpload
    {
        IList<LogoUploadModel> GetAll();
        Task<LogoUploadModel> Details(int? id);
        int Save(LogoUploadModel obj, IFormFile SourceFile);
        int Update(LogoUploadModel obj, IFormFile SourceFile);
        Task Delete(int? id);
        Task DeleteConfirmed(int id);
        bool CheckExists(int id);
        bool DuplicateCheckOnSave(string LogoName);
        bool DuplicateCheckOnUpdate(int LogoId, string LogoName);
    }
}
