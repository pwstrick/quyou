//=========================================
//
// 作 者：农民伯伯
// 邮 箱：over140@gmail.com
// 博 客：http://over140.cnblogs.com/
// 时 间：2009-7-1 23:11:59
// 描 述：验证类
//
//=========================================

using System;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;

using Lasy.Utility;

namespace Lasy.Validator
{
    /// <summary>
    /// 验证类
    /// </summary>
    public sealed class Validator
    {
        #region Member Variable
        //验证全部
        private bool checkAll;
        private bool setDefaultValue;
        private Type type;
        private IList<IValidator> errors;
        private IDictionary<string, object> valuesResult;
        private bool boolResult = true;
        private IValidator error;

        #endregion

        #region Constructor

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="type"></param>
        public Validator(Type type)
        {
            this.type = type;
        }

        /// <summary>
        /// 构造验证类
        /// </summary>
        /// <param name="type"></param>
        /// <param name="checkAll">是否验证全部，即验证失败也将往下继续验证。</param>
        public Validator(Type type, bool checkAll)
            : this(type, checkAll, false)
        { }

        /// <summary>
        /// 构造验证类
        /// </summary>
        /// <param name="type"></param>
        /// <param name="checkAll">是否验证全部，即验证失败也将往下继续验证。</param>
        /// <param name="setDefaultValue">将错误的数据设置为默认值</param>
        public Validator(Type type, bool checkAll, bool setDefaultValue)
        {
            this.type = type;
            if (checkAll)
            {
                this.checkAll = true;
                if (setDefaultValue)
                {
                    this.setDefaultValue = true;
                    this.valuesResult = new Dictionary<string, object>();
                }
                else
                {
                    this.errors = new List<IValidator>();
                }
            }
        }


        #endregion

        #region Method

        #region Validate NameValueCollection

        /// <summary>
        /// 验证Request数据
        /// </summary>
        /// <param name="request">
        ///     Request.QueryString
        ///     Request.Form
        /// </param>
        /// <returns></returns>
        public Validator Validate(NameValueCollection request)
        {
            return Validate(ConvertUtility.ToDictionary(request), true);
        }

        /// <summary>
        /// 验证Request数据
        /// </summary>
        /// <param name="request">
        ///     Request.QueryString
        ///     Request.Form
        /// </param>
        /// <param name="req_keys">
        ///     选择指定的字段进行验证
        /// </param>
        /// <returns></returns>
        public Validator Validate(NameValueCollection request, params string[] req_keys)
        {
            IDictionary<string, object> dict = new Dictionary<string, object>();

            IList<string> allKeys = new List<string>(request.AllKeys);

            foreach (string req_key in req_keys)
            {
                if (allKeys.Contains(req_key))
                    dict.Add(req_key, request[req_key]);
            }

            return Validate(dict);
        }

        #endregion

        #region Validate IDictionary

        /// <summary>
        /// 验证
        /// </summary>
        /// <param name="dict"></param>
        /// <returns></returns>
        public Validator Validate(IDictionary<string, object> dict)
        {
            return Validate(dict, false);
        }

        internal Validator Validate(IDictionary<string, object> dict, bool isValidKey)
        {
            return Validate(dict, TypeProviderManager.Get(type).Validates, isValidKey);
        }

        internal Validator Validate(IDictionary<string, object> dict, IDictionary<string, IList<IValidator>> validates, bool isValidKey)
        {

            ResetValidator();

            if (dict == null || dict.Count == 0)
            {
                return this;
            }

            if (validates == null || validates.Count == 0)
            {
                return this;
            }

            ICollection<string> keys = isValidKey ? validates.Keys : dict.Keys;

            //是否全部验证
            if (checkAll)
            {
                //设置默认值
                if (setDefaultValue)
                {
                    foreach (string key in keys)
                    {
                        if (dict.ContainsKey(key) && validates.ContainsKey(key))
                        {
                            foreach (IValidator validator in validates[key])
                            {
                                object value = validator.IsValid(dict[key]) ? dict[key] : validator.FailDefaultValue;
                                if (valuesResult.ContainsKey(key))
                                    valuesResult.Add(key, value);
                                else
                                    valuesResult[key] = value;
                            }
                        }
                    }
                }
                else
                {
                    //返回错误信息
                    foreach (string key in keys)
                    {
                        if (dict.ContainsKey(key) && validates.ContainsKey(key))
                        {
                            foreach (IValidator validator in validates[key])
                            {
                                if (!validator.IsValid(dict[key]))
                                {
                                    errors.Add(validator);
                                    if (boolResult)
                                        boolResult = false;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                foreach (string key in keys)
                {
                    if (dict.ContainsKey(key) && validates.ContainsKey(key))
                    {
                        foreach (IValidator validator in validates[key])
                        {
                            //验证
                            if (!validator.IsValid(dict[key]))
                            {
                                error = validator;
                                boolResult = false;
                                return this;
                            }
                        }
                    }
                }
            }
            return this;
        }

        #endregion

        #region Validate Controls

        /// <summary>
        /// 验证服务器端控件集合
        /// </summary>
        /// <param name="controls">控件集</param>
        /// <returns></returns>
        public Validator Validate(params Control[] controls)
        {
            return Validate(WebControlUtility.GetAllValue(controls));
        }

        /// <summary>
        /// 验证服务器端控件集合
        /// </summary>
        /// <param name="controls">控件集</param>
        /// <returns></returns>
        public Validator Validate(ControlCollection controls)
        {
            return Validate(WebControlUtility.GetAllValue(controls));
        }

        /// <summary>
        /// 验证服务器端控件集合
        /// </summary>
        /// <param name="controls"></param>
        /// <param name="controls_key">选择指定的字段进行验证</param>
        /// <returns></returns>
        public Validator Validate(Control[] controls, params string[] controls_key)
        {
            IDictionary<string, object> dict = new Dictionary<string, object>();

            IDictionary<string, object> allDict = WebControlUtility.GetAllValue(controls);

            foreach (string req_key in controls_key)
            {
                if (allDict.ContainsKey(req_key))
                    dict.Add(req_key, allDict[req_key]);
            }

            return Validate(dict);
        }

        #endregion

        #region Reset

        internal void ResetValidator()
        {
            errors = null;
            valuesResult = null;
            error = null;
            boolResult = true;
        }

        #endregion

        #endregion

        #region Properties

        /// <summary>
        /// 返回验证失败的错误信息
        /// </summary>
        public IValidator ErrorResult
        {
            get
            {
                if (error != null)
                {
                    error.FailMessage = string.Format(error.FailMessage, error.GetFailFormatValues());
                }
                return error;
            }
        }

        /// <summary>
        /// 返回验证失败的错误字符串 拼接后的
        /// </summary>
        public string ErrorStringResult
        {
            get
            {
                if (error != null)
                    return string.Format(error.FailMessage, error.GetFailFormatValues());
                return string.Empty;
            }
        }

        /// <summary>
        /// 返回验证失败的错误字符串 未拼接的
        /// </summary>
        public string ErrorStringWithoutFormat
        {
            get
            {
                if (error != null)
                    return error.FailMessage;
                return string.Empty;
            }
        }

        /// <summary>
        /// 返回验证失败的错误信息
        /// </summary>
        public IList<IValidator> ErrorsResult
        {
            get
            {
                if (errors != null)
                {
                    for (int i = 0, j = errors.Count; i < j; i++)
                    {
                        errors[i].FailMessage = string.Format(errors[i].FailMessage, errors[i].GetFailFormatValues());
                    }
                }
                return errors;
            }
        }

        /// <summary>
        /// 验证所有数据，并将错误的数据设置为默认值
        /// </summary>
        public IDictionary<string, object> ValuesResult
        {
            get
            {
                return valuesResult;
            }
        }

        /// <summary>
        /// 验证结果
        /// </summary>
        public bool BoolResult
        {
            get
            {
                return boolResult;
            }
        }

        #endregion
    }
}
