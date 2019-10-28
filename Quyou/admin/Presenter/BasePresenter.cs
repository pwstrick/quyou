using System.Collections.Generic;
using Lasy.Validator;
using StructureMap;
using QuyouCore.Core.Util;
using QuyouCore.Core.Entity;
using QuyouCore.Core.Enum;

namespace Quyou.admin.Presenter
{
    public abstract class BasePresenter
    {
        protected abstract IContainer ConfigureDependencies();//单例配置化

        private NHtmlFilter _nHtmlFilter;
        /// <summary>
        /// 初始化一次
        /// </summary>
        private void GetNHtmlFilterInstance()
        {
            if (_nHtmlFilter == null)
                _nHtmlFilter = new NHtmlFilter();
        }
        /// <summary>
        /// 过滤字符串
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        protected string FilterParamters(string value)
        {
            value = value ?? string.Empty;
            GetNHtmlFilterInstance();
            return _nHtmlFilter.filter(value.Trim());
        }

        protected string PromptToJson(int prompt)
        {
            return Prompt.ToJson(prompt, EnumCommon.GetPrompt()[prompt]);
        }

        /// <summary>
        /// 用Attribute做字段验证
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dict"></param>
        /// <returns></returns>
        protected string ValidateParameters<T>(Dictionary<string, object> dict)
        {
            var validator = new Validator(typeof(T));
            if (!validator.Validate(dict).BoolResult)
            {
                return validator.Validate(dict).ErrorStringWithoutFormat;
            }
            return string.Empty;
        }
    }
}
