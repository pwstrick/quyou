﻿//=========================================
//
// 作 者：农民伯伯
// 邮 箱：over140@gmail.com
// 博 客：http://over140.cnblogs.com/
// 时 间：2009-2-20 22:19:12
// 描 述：日期验证器
//
//=========================================

using System;
using System.Collections.Generic;
using System.Text;
using Lasy.Utility;

namespace Lasy.Validator
{
    /// <summary>
    /// 日期验证器
    /// </summary>
    public sealed class DateAttribute : BaseValidatorAttribute
    {
        #region Constructors

        /// <summary>
        /// 构造函数
        /// </summary>
        public DateAttribute() 
        {
            this.FailMessage = "{0}不是一个有效的日期";
            this.FailDefaultValue = DateTime.Now.ToShortDateString();
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
            return JudgeUtility.IsDateTime(value);
        }

        #endregion
    }
}
