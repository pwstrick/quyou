//=========================================
//
// 作 者：农民伯伯
// 邮 箱：over140@gmail.com
// 博 客：http://over140.cnblogs.com/
// 时 间：2009-7-3 9:35:11
// 描 述：
//
//=========================================

using System;
using System.Collections.Generic;
using System.Text;

namespace Lasy.Validator
{
    /// <summary>
    /// 空验证器
    /// </summary>
    public sealed class NoValidatorAttribute : BaseValidatorAttribute
    {
        /// <summary>
        /// 验证
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool IsValid(object value)
        {
            return true;
        }
    }
}
