using System;
using Lasy.Utility;

namespace Lasy.Validator
{
    public class IntRangeGreaterAttribute : BaseValidatorAttribute
    {
        #region Member Variable

        private readonly int minValue;

        #endregion

        #region Constructors

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="errorNo"></param>
        /// <param name="minValue"></param>
        public IntRangeGreaterAttribute(int errorNo, int minValue)
        {
            FailMessage = PromptToJson(errorNo);
            FailDefaultValue = string.Empty;
            this.minValue = minValue;
        }

        #endregion

        #region Method

        /// <summary>
        /// 验证
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool IsValid(object value)
        {
            Value = value;

            if (!JudgeUtility.IsInt(value))
                return false;

            var convValue = Convert.ToInt32(value);

            return convValue >= minValue;
        }

        /// <summary>
        /// 用于输出失败信息指定format的value参数
        /// </summary>
        /// <returns></returns>
        public override object[] GetFailFormatValues()
        {
            return new object[] { base.GetFailFormatValues(), minValue};
        }

        #endregion
    }
}
