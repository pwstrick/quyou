using Lasy.Validator;
using QuyouCore.Core.Util;

namespace QuyouCore.Core.Entity
{
    public class KeywordTypetData
    {
        [Numeric(Const.PromptKeywordTypeIdInvalid)]
        [IntRangeGreater(Const.PromptKeywordTypeIdInvalid, 1)]
        public string KeywordTypeId
        {
            get;
            set;
        }
        [Numeric(Const.PromptPlayClassInvalid)]
        [IntRange(Const.PromptPlayClassInvalid, 1, 10)]
        public string PlayClass
        {
            get;
            set;
        }
        [Numeric(Const.PromptPlayModelInvalid)]
        [IntRange(Const.PromptPlayModelInvalid, 1, 10)]
        public string PlayModel
        {
            get;
            set;
        }
        [Numeric(Const.PromptPlayTypeInvalid)]
        [IntRange(Const.PromptPlayTypeInvalid, 1, 10)]
        public string PlayType
        {
            get;
            set;
        }
        [Required(Const.PromptKeywordTypeNameInvalid)]
        public string Name
        {
            get;
            set;
        }
        public string AddTime
        {
            get;
            set;
        }
        [Numeric(Const.PromptKeywordTypeSortInvalid)]
        [IntRangeGreater(Const.PromptKeywordTypeSortInvalid, 0)]
        public string Sort
        {
            get;
            set;
        }
        [Numeric(Const.PromptKeywordTypeParentInvalid)]
        [IntRangeGreater(Const.PromptKeywordTypeParentInvalid, 0)]
        public string ParentTypeId
        {
            get;
            set;
        }
    }
}
