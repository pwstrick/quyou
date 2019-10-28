//=========================================
//
// 作 者：农民伯伯
// 邮 箱：over140@gmail.com
// 博 客：http://over140.cnblogs.com/
// 时 间：2009-7-2 14:00:02
// 描 述：正则表达式验证器
//
//=========================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Lasy.Validator
{
    /// <summary>
    /// 正则表达式验证器
    /// </summary>
    public sealed class MaskAttribute : BaseValidatorAttribute
    {
        #region Member Variable

        private RegexOptions? option;

        private string pattern;

        #endregion

        #region Constructors

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="pattern"></param>
        public MaskAttribute(string pattern)
        {
            this.FailMessage = "{0}不符合正则表达式[{1}]";
            this.FailDefaultValue = string.Empty;
            this.pattern = pattern;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="option"></param>
        public MaskAttribute(string pattern, RegexOptions option)
            : this(pattern)
        {
            this.option = option;
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
            base.Value = value;

            if (value == null)
                return false;

            if (option.HasValue)
            {
                return Regex.IsMatch(value.ToString(), pattern, option.Value);
            }
            else
                return Regex.IsMatch(value.ToString(), pattern);
        }

        /// <summary>
        /// 用于输出失败信息指定format的value参数
        /// </summary>
        /// <returns></returns>
        public override object[] GetFailFormatValues()
        {
            return new object[] { base.GetFailFormatValues(), base.Value };
        }

        #endregion
    }

}
