using QuyouCore.Core.Domain;
namespace QuyouCore.Core.Service
{
    public interface IKeywordService
    {
        string Insert(tb_Keyword data);
        string Update(tb_Keyword data);
        string Delete(int data);
        string GetSelectedKeywords(tb_KeywordType data);
    }
}
