//=========================================
//
// 作 者：农民伯伯
// 邮 箱：over140@gmail.com
// 博 客：http://over140.cnblogs.com/
// 时 间：2009-7-2 13:48:08
// 描 述：整数验证器
//
//=========================================

using System;
using System.Collections.Generic;
using System.Text;

using Lasy.Utility;

namespace Lasy.Validator
{
    /// <summary>
    /// 整数验证器
    /// </summary>
    public sealed class IntegerAttribute : BaseValidatorAttribute
    {
        #region Constructors

        /// <summary>
        /// 构造函数
        /// </summary>
        public IntegerAttribute()
        {
            FailMessage = "{0}不是一个整数";
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
            base.Value = value;
            return JudgeUtility.IsInt(value);
        }

        #endregion
    }
}
