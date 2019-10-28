using Lasy.Validator;
using QuyouCore.Core.Util;

namespace QuyouCore.Core.Entity
{
    public class KeywordtData
    {
        [Numeric(Const.PromptKeywordIdInvalid)]
        [IntRangeGreater(Const.PromptKeywordIdInvalid, 1)]
        public string KeywordId
        {
            get;
            set;
        }
        [Numeric(Const.PromptKeywordTypeIdInvalid)]
        [IntRangeGreater(Const.PromptKeywordIdInvalid, 1)]
        public string KeywordTypeId
        {
            get; set;
        }
        [Required(Const.PromptKeywordNameInvalid)]
        public string Name
        {
            get;
            set;
        }
    }
}
