using QuyouCore.Core.Entity;
namespace Quyou.admin.Interface
{
    public interface IKeywordAjaxPresenter
    {
        string InsertKeywordType(KeywordTypetData input);
        string EditKeywordType(KeywordTypetData input);
        string DelKeywordType(KeywordTypetData input);
        string InsertKeyword(KeywordtData input);
        string EditKeyword(KeywordtData input);
        string DelKeyword(KeywordtData input);
        string GetKeywords(KeywordTypetData input);
        string ShowErrorJson();
    }
}
