//=========================================
//
// 作 者：农民伯伯
// 邮 箱：over140@gmail.com
// 博 客：http://over140.cnblogs.com/
// 时 间：2009-2-20 22:19:12
// 描 述：EMail验证器
//
//=========================================

using System;
using Lasy.Utility;

namespace Lasy.Validator
{

    /// <summary>
    /// EMail验证器
    /// </summary>
    public sealed class EmailAttribute : BaseValidatorAttribute
    {
        #region Constructors

        /// <summary>
        /// 构造函数
        /// </summary>
        public EmailAttribute() 
        {
            this.FailMessage = "{0}不是一个合法的Email地址";
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
            return JudgeUtility.IsEmail(value);
        }

        #endregion

    }
}
