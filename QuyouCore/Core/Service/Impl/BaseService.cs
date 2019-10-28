using System.Collections.Generic;
using Lasy.Validator;
using QuyouCore.Core.Entity;
using QuyouCore.Core.Enum;
using StructureMap;

namespace QuyouCore.Core.Service.Impl
{
    public abstract class BaseService
    {
        protected abstract IContainer ConfigureDependencies();//单例配置化
        
        protected string PromptToJson(int prompt)
        {
            return Prompt.ToJson(prompt, EnumCommon.GetPrompt()[prompt]);
        }

        protected string PromptToJson<T>(int prompt, List<T> dataList)
        {
            return Prompt.ToJson(prompt, EnumCommon.GetPrompt()[prompt], dataList);
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
