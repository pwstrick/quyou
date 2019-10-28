using System.Collections.Generic;
using QuyouCore.Core.Util;

namespace QuyouCore.Core.Enum
{
    public class EnumCommon
    {
        public static Dictionary<int, string> GetPrompt()
        {
            return new Dictionary<int, string>
            {
                { Const.PromptSuccess, "操作成功！" },
                { Const.PromptFailure, "操作失败！" },

                { Const.PromptPlayClassInvalid, "线路类型无效！" },
                { Const.PromptPlayModelInvalid, "线路版块无效！" },
                { Const.PromptPlayTypeInvalid, "线路分类无效！" },

                { Const.PromptKeywordTypeNameInvalid, "关键字类别名无效！" },
                { Const.PromptKeywordTypeSortInvalid, "关键字类别排序无效！" },
                { Const.PromptKeywordTypeParentInvalid, "关键字类别父级编号无效！" },
                { Const.PromptKeywordTypeIdInvalid, "关键字类别编号无效！"},
                { Const.PromptKeywordNameInvalid, "关键字名无效！"},
                { Const.PromptKeywordIdInvalid, "关键字编号无效！"}
            };
        }
    }
}
