//=========================================
//
// 作 者：农民伯伯
// 邮 箱：over140@gmail.com
// 博 客：http://over140.cnblogs.com/
// 时 间：2009-6-9 13:50:13
// 描 述：大于长度验证器
//
//=========================================

using System;
using System.Collections.Generic;
using System.Text;

using Lasy.Utility;

namespace Lasy.Validator
{
    /// <summary>
    /// 大于长度验证器
    /// </summary>
    public sealed class MaxLengthAttribute : BaseValidatorAttribute
    {
        #region Member Variable

        private readonly int maxValue;

        #endregion

        #region Constructors

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="maxValue"></param>
        public MaxLengthAttribute(int maxValue)
        {
            this.FailMessage = "{0}的长度大于{1}";
            this.FailDefaultValue = string.Empty;
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

            if (value == null)
                return false;

            return value.ToString().Length < maxValue;
        }

        /// <summary>
        /// 用于输出失败信息指定format的value参数
        /// </summary>
        /// <returns></returns>
        public override object[] GetFailFormatValues()
        {
            return new object[] { base.GetFailFormatValues(), maxValue };
        }

        /// <summary>
        /// 输出验证器内容
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder results = new StringBuilder();
            results.Append("Lasy.Validator: Key=");
            results.Append(Key);
            results.Append("  FailKeyDesc=");
            results.Append(FailKeyDesc);
            results.Append("  Value=");
            results.Append(Value);
            results.Append("  maxValue=");
            results.Append(maxValue);
            results.Append("  FailDefaultValue=");
            results.Append(FailDefaultValue);
            results.Append("  FailMessage=");
            results.Append(FailMessage);
            results.Append("\n");
            return results.ToString();
        }

        #endregion
    }
}
