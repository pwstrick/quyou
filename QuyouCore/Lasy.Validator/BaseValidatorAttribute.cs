//=========================================
//
// 作 者：农民伯伯
// 邮 箱：over140@gmail.com
// 博 客：http://over140.cnblogs.com/
// 时 间：2009-6-30 10:02:00
// 描 述：验证器父类
//
//=========================================

using System;
using System.Collections.Generic;
using System.Text;
using QuyouCore.Core.Entity;
using QuyouCore.Core.Enum;

namespace Lasy.Validator
{
    /// <summary>
    /// 验证器父类
    /// </summary>
    public abstract class BaseValidatorAttribute : Attribute, IValidator
    {
        #region Member Variable

        //错误信息
        private string message;
        //默认值
        private object defalutValue;
        //项说明
        private string keyDesc;
        //项名称
        private string key;
        //值
        private object value;

        #endregion

        #region Mehtod

        /// <summary>
        /// 验证
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public abstract bool IsValid(object value);

        /// <summary>
        /// 输出验证器内容
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder results = new StringBuilder();
            results.Append("Lasy.Validator: Key=");
            results.Append(key);
            results.Append("  FailKeyDesc=");
            results.Append(keyDesc);
            results.Append("  Value=");
            results.Append(value);
            results.Append("  FailDefaultValue=");
            results.Append(defalutValue);
            results.Append("  FailMessage=");
            results.Append(message);
            results.Append("\n");
            return results.ToString();
        }

        /// <summary>
        /// 用于输出JSON格式
        /// </summary>
        /// <param name="prompt"></param>
        /// <returns></returns>
        protected string PromptToJson(int prompt)
        {
            return Prompt.ToJson(prompt, EnumCommon.GetPrompt()[prompt]);
        }

        /// <summary>
        /// 用于输出失败信息指定format的value参数
        /// </summary>
        /// <returns></returns>
        public virtual object[] GetFailFormatValues()
        {
            if (string.IsNullOrEmpty(keyDesc))
                return new object[] { key };
            return new object[] { keyDesc };
        }

        #endregion

        #region Properties

        /// <summary>
        /// 验证失败后设置的值
        /// </summary>
        public object FailDefaultValue
        {
            get { return defalutValue; }
            set { defalutValue = value; }
        }

        /// <summary>
        /// 验证失败后设置的值
        /// </summary>
        public string FailMessage
        {
            get { return message; }
            set { message = value; }
        }

        /// <summary>
        /// 验证失败后字段说明
        /// </summary>
        public string FailKeyDesc
        {
            get { return keyDesc; }
            set { keyDesc = value; }
        }

        /// <summary>
        /// 段名称，默认属性名
        /// </summary>
        public string Key
        {
            get { return key; }
            set { key = value; }
        }

        /// <summary>
        /// 设置值
        /// </summary>
        protected object Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        //public bool SetFailMessageParams 
        //{
        //    get;
        //    set;
        //}

        #endregion
    }
}
