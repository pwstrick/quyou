namespace QuyouCore.Core.Util
{
    public class Const
    {
        public const string RootUrl = "http://localhost:45407/";
        public const string WapUrl = RootUrl + "wap/";
        public const string DefaultHeadPhoto = "upload/userface/user_large.jpg";
        public const char CharSplitSign = '|';

        public const int PromptSuccess = 1;//操作成功
        public const int PromptFailure = 2;//操作失败

        //3--100共用提示
        public const int PromptPositiveNumberInvalid = 5;//正整数无效

        //101--140
        public const int PromptPlayClassInvalid = 101;//线路类型无效
        public const int PromptPlayModelInvalid = 102;//线路版块无效
        public const int PromptPlayTypeInvalid = 103;//线路分类无效
        //141--160
        public const int PromptKeywordTypeNameInvalid = 141;//关键字类别名字无效
        public const int PromptKeywordTypeSortInvalid = 142;//关键字类别排序无效
        public const int PromptKeywordTypeParentInvalid = 143;//关键字类别父级编号无效
        public const int PromptKeywordTypeIdInvalid = 144;//关键字类别编号无效
        public const int PromptKeywordNameInvalid = 145;//关键字名字无效
        public const int PromptKeywordIdInvalid = 146;//关键字编号无效
    }
}
