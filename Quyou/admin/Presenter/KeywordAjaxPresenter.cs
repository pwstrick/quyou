using System;
using NPinyin;
using Quyou.admin.Interface;
using QuyouCore.Core.Domain;
using QuyouCore.Core.Entity;
using QuyouCore.Core.Service;
using QuyouCore.Core.Service.Impl;
using QuyouCore.Core.Util;
using StructureMap;
using System.Collections.Generic;

namespace Quyou.admin.Presenter
{
    public class KeywordAjaxPresenter : BasePresenter, IKeywordAjaxPresenter
    {
        protected override IContainer ConfigureDependencies()
        {
            return new Container(x =>
            {
                x.For<IKeywordTypeService>().Use<KeywordTypeService>();
                x.For<IKeywordService>().Use<KeywordService>();
            });
        }

        private IKeywordTypeService InitKeywordTypeService()
        {
            var container = ConfigureDependencies();
            return container.GetInstance<IKeywordTypeService>();
        }

        private IKeywordService InitKeywordService()
        {
            var container = ConfigureDependencies();
            return container.GetInstance<IKeywordService>();
        }

        private string ValidInsertOrUpdate(KeywordTypetData input)
        {
            input.PlayClass = FilterParamters(input.PlayClass);
            input.PlayModel = FilterParamters(input.PlayModel);
            input.PlayType = FilterParamters(input.PlayType);
            input.Name = FilterParamters(input.Name);
            input.Sort = FilterParamters(input.Sort);
            input.ParentTypeId = FilterParamters(input.ParentTypeId);
            var dict = new Dictionary<string, object>
            {
                {"PlayClass", input.PlayClass},
                {"PlayModel", input.PlayModel},
                {"PlayType", input.PlayType},
                {"Name", input.Name},
                {"Sort", input.Sort},
                {"ParentTypeId", input.ParentTypeId}
            };
            if (!string.IsNullOrEmpty(input.KeywordTypeId))
            {
                input.KeywordTypeId = FilterParamters(input.KeywordTypeId);
                dict.Add("KeywordTypeId", input.KeywordTypeId);
            }
            return ValidateParameters<KeywordTypetData>(dict);
        }
        public string InsertKeywordType(KeywordTypetData input)
        {
            var valid = ValidInsertOrUpdate(input);
            if (valid.Length > 0)
                return valid;

            var keywordType = new tb_KeywordType
            {
                PlayClass = int.Parse(input.PlayClass),
                PlayModel = int.Parse(input.PlayModel),
                PlayType = int.Parse(input.PlayType),
                Name = input.Name,
                AddTime = DateTime.Now,
                Sort = int.Parse(input.Sort),
                ParentTypeId = int.Parse(input.ParentTypeId),
                Active = true
            };
            
            var keywordTypeService = InitKeywordTypeService();
            return keywordTypeService.Insert(keywordType);
        }

        /// <summary>
        /// 修改关键字类别
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string EditKeywordType(KeywordTypetData input)
        {
            var valid = ValidInsertOrUpdate(input);
            if (valid.Length > 0)
                return valid;

            var keywordType = new tb_KeywordType
            {
                KeywordTypeId = int.Parse(input.KeywordTypeId),
                PlayClass = int.Parse(input.PlayClass),
                PlayModel = int.Parse(input.PlayModel),
                PlayType = int.Parse(input.PlayType),
                Name = input.Name,
                Sort = int.Parse(input.Sort),
                ParentTypeId = int.Parse(input.ParentTypeId)
            };

            var keywordTypeService = InitKeywordTypeService();
            return keywordTypeService.Update(keywordType);
        }

        /// <summary>
        /// 删除关键字类别
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string DelKeywordType(KeywordTypetData input)
        {
            input.KeywordTypeId = FilterParamters(input.KeywordTypeId);
            var dict = new Dictionary<string, object>
            {
                {"KeywordTypeId", input.KeywordTypeId}
            };
            var valid = ValidateParameters<KeywordTypetData>(dict);
            if (valid.Length > 0)
                return valid;
            var keywordTypeService = InitKeywordTypeService();
            return keywordTypeService.Delete(int.Parse(input.KeywordTypeId));
        }

        /// <summary>
        /// 添加关键字
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string InsertKeyword(KeywordtData input)
        {
            input.KeywordTypeId = FilterParamters(input.KeywordTypeId);
            input.Name = FilterParamters(input.Name);

            var dict = new Dictionary<string, object>
            {
                {"KeywordTypeId", input.KeywordTypeId},
                {"Name", input.Name}
            };
            var valid = ValidateParameters<KeywordtData>(dict);
            if (valid.Length > 0)
                return valid;

            var keyword = new tb_Keyword
            {
                KeywordTypeId = int.Parse(input.KeywordTypeId),
                Name = input.Name,
                AddTime = DateTime.Now,
                Pinyin = Pinyin.GetPinyin(input.Name),
                Active = true
            };

            var keywordService = InitKeywordService();
            return keywordService.Insert(keyword);
        }

        /// <summary>
        /// 修改关键字
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string EditKeyword(KeywordtData input)
        {
            input.KeywordId = FilterParamters(input.KeywordId);
            input.KeywordTypeId = FilterParamters(input.KeywordTypeId);
            input.Name = FilterParamters(input.Name);

            var dict = new Dictionary<string, object>
            {
                {"KeywordTypeId", input.KeywordTypeId},
                {"Name", input.Name},
                {"KeywordId", input.KeywordId}
            };
            var valid = ValidateParameters<KeywordtData>(dict);
            if (valid.Length > 0)
                return valid;

            var keyword = new tb_Keyword
            {
                KeywordId = int.Parse(input.KeywordId),
                KeywordTypeId = int.Parse(input.KeywordTypeId),
                Name = input.Name,
                Pinyin = Pinyin.GetPinyin(input.Name),
            };

            var keywordService = InitKeywordService();
            return keywordService.Update(keyword);
        }

        /// <summary>
        /// 删除关键字
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string DelKeyword(KeywordtData input)
        {
            input.KeywordId = FilterParamters(input.KeywordId);
            var dict = new Dictionary<string, object>
            {
                {"KeywordId", input.KeywordId}
            };
            var valid = ValidateParameters<KeywordtData>(dict);
            if (valid.Length > 0)
                return valid;
            var keywordService = InitKeywordService();
            return keywordService.Delete(int.Parse(input.KeywordId));
        }

        /// <summary>
        /// 获取关键字列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string GetKeywords(KeywordTypetData input)
        {
            int playClass, playModel, playType;
            int.TryParse(input.PlayClass, out playClass);
            int.TryParse(input.PlayModel, out playModel);
            int.TryParse(input.PlayType, out playType);
            var keywordType = new tb_KeywordType
            {
                PlayClass = playClass,
                PlayModel = playModel,
                PlayType = playType
            };
            var keywordService = InitKeywordService();
            return keywordService.GetSelectedKeywords(keywordType);
        }

        /// <summary>
        /// 显示错误信息的JSON提示
        /// </summary>
        /// <returns></returns>
        public string ShowErrorJson()
        {
            return PromptToJson(Const.PromptFailure);
        }
    }
}
