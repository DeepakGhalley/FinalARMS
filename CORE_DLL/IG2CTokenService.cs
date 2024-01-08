using CORE_BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CORE_DLL
{
    public interface IG2CTokenService 
    {
        Task<G2CAPIToken> GetG2CToken();
    }
}
