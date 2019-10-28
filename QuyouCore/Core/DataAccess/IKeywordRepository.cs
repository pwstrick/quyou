using System.Collections.Generic;
using QuyouCore.Core.Domain;

namespace QuyouCore.Core.DataAccess
{
    public interface IKeywordRepository : IBaseRepository<tb_Keyword>
    {
        List<tb_Keyword> GetKeywordsByTypeId(tb_Keyword data);
    }
}
