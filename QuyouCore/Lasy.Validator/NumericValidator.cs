using Lasy.Utility;
namespace Lasy.Validator
{
    /// <summary>
    /// 数字验证器
    /// </summary>
    public sealed class NumericAttribute : BaseValidatorAttribute
    {
        #region Constructors

        /// <summary>
        /// 构造函数
        /// </summary>
        public NumericAttribute()
        {
            FailMessage = "{0}不是一个数字";
            FailDefaultValue = 0;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public NumericAttribute(int errorNo)
        {
            FailMessage = PromptToJson(errorNo);
            FailDefaultValue = 0;
        }

        #endregion

        #region Method

        /// <summary>
        /// 数据验证
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool IsValid(object value)
        {
            Value = value;
            return JudgeUtility.IsNumeric(value);
        }
        #endregion
    }
}
