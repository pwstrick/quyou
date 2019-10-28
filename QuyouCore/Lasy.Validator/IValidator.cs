//=========================================
//
// 作 者：农民伯伯
// 邮 箱：over140@gmail.com
// 博 客：http://over140.cnblogs.com/
// 时 间：2009-2-26 11:19:44
// 描 述：验证器。用于对Model赋值的时候进行验证。
//
//=========================================

using System;
using System.Collections.Generic;
using System.Text;

namespace Lasy.Validator
{
    /// <summary>
    /// 数据验证。用于对Model赋值的时候进行验证。
    /// </summary>
    public interface IValidator
    {
        /// <summary>
        /// 数据验证
        /// </summary>
        /// <param name="value">要验证的数据</param>
        /// <returns></returns>
        bool IsValid(object value);

        /// <summary>
        /// 字段名称，默认属性名
        /// </summary>
        string Key { get; set; }

        /// <summary>
        /// 是否需要参数帮助错误信息拼接
        /// </summary>
        //bool SetFailMessageParams { get; set; }

        /// <summary>
        /// 验证失败后字段说明
        /// </summary>
        string FailKeyDesc { get; set; }

        /// <summary>
        /// 验证失败后显示的错误信息
        /// </summary>
        string FailMessage { get; set; }

        /// <summary>
        /// 验证失败后设置的值
        /// </summary>
        object FailDefaultValue { get; set; }

        /// <summary>
        /// 用于输出失败信息指定format的value参数
        /// </summary>
        /// <returns></returns>
        object[] GetFailFormatValues();

    }
}

///// <summary>
///// 是否从资源文件读取[暂时未用]
///// </summary>
////bool resouce { get; }
//"mask" : "{0}不符合正则表达式[{1}]",   
//"creditCard" : "{0}不是一个合法的信用卡号",   
//"email" : "{0}不是一个合法的Email地址",   
//"intRange" : "{0}不在{1}到{2}之内",   
//"floatRange" : "{0}不在{1}到{2}之内",   
//"maxLength" : "{0}的长度大于{1}",   
//"minLength" : "{0}的长度小于{1}",   
//"required" : "{0}不能为空",   

//errors.required={0} is required.

//errors.minlength={0} cannot be less than {1} characters.

//errors.maxlength={0} cannot be greater than {2} characters.

//errors.invalid={0} is invalid.

//errors.byte={0} must be an byte.

//errors.short={0} must be an short.

//errors.integer={0} must be an integer.

//errors.long={0} must be an long.

//errors.float={0} must be an float.

//errors.double={0} must be an double.

//errors.date={0} is not a date.

//errors.range={0} is not in the range {1} through {2}.

//errors.creditcard={0} is not a valid credit card number.

//errors.email={0} is an invalid e-mail address.
