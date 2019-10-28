//=========================================
//
// 作 者：农民伯伯
// 邮 箱：over140@gmail.com
// 博 客：http://over140.cnblogs.com/
// 时 间：2009-7-2 13:48:13
// 描 述：整数范围验证器
//
//=========================================

using System;
using System.Collections.Generic;
using System.Text;

using Lasy.Utility;

namespace Lasy.Validator
{
    /// <summary>
    /// 整数范围验证器
    /// </summary>
    public sealed class IntRangeAttribute : BaseValidatorAttribute
    {
        #region Member Variable

        private readonly int minValue;

        private readonly int maxValue;

        #endregion

        #region Constructors

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        public IntRangeAttribute(int minValue, int maxValue)
        {
            this.FailMessage = "{0}不在{1}到{2}的范围之内{0}";
            this.FailDefaultValue = string.Empty;
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="errorNo"></param>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        public IntRangeAttribute(int errorNo, int minValue, int maxValue)
        {
            FailMessage = PromptToJson(errorNo);
            FailDefaultValue = string.Empty;
            this.minValue = minValue;
            this.maxValue = maxValue;
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
            base.Value = value;

            if (!JudgeUtility.IsInt(value))
                return false;

            int convValue = Convert.ToInt32(value);

            return convValue >= minValue && convValue <= maxValue;
        }

        /// <summary>
        /// 用于输出失败信息指定format的value参数
        /// </summary>
        /// <returns></returns>
        public override object[] GetFailFormatValues()
        {
            return new object[] { base.GetFailFormatValues(), minValue, maxValue };
        }

        #endregion
    }
}
