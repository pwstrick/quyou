//=========================================
//
// 作 者：农民伯伯
// 邮 箱：over140@gmail.com
// 博 客：http://over140.cnblogs.com/
// 时 间：2009-7-2 14:00:02
// 描 述：信用卡验证器
//
//=========================================

using System;
using System.Collections.Generic;
using System.Text;

using Lasy.Utility;

namespace Lasy.Validator
{
    /// <summary>
    /// 信用卡验证器
    /// </summary>
    public sealed class CreditCardAttribute : BaseValidatorAttribute
    {
        #region Constructors

        /// <summary>
        /// 构造函数
        /// </summary>
        public CreditCardAttribute()
        {
            this.FailMessage = "{0}不是一个合法的信用卡号";
            this.FailDefaultValue = string.Empty;
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
            return JudgeUtility.IsCreditCard(value);
        }

        #endregion
    }
}
