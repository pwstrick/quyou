//=========================================
//
// 作 者：农民伯伯
// 邮 箱：over140@gmail.com
// 博 客：http://over140.cnblogs.com/
// 时 间：2009-2-20 22:19:12
// 描 述：非空验证器
//
//=========================================

using System;
using System.Collections.Generic;
using System.Text;
using Lasy.Utility;

namespace Lasy.Validator
{
    /// <summary>
    /// 非空验证器
    /// </summary>
    public sealed class RequiredAttribute : BaseValidatorAttribute
    {
        #region Constructors

        /// <summary>
        /// 构造函数
        /// </summary>
        public RequiredAttribute()
        {
            this.FailMessage = "{0}不能为空";
            this.FailDefaultValue = string.Empty;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public RequiredAttribute(int errorNo)
        {
            FailMessage = PromptToJson(errorNo);
            //SetFailMessageParams = false;
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
            return !JudgeUtility.IsNullOrEmpty(value);
        }

        #endregion
    }
}
