using System.Collections.Generic;
using QuyouCore.Core.DataAccess;
using QuyouCore.Core.DataAccess.Impl;
using QuyouCore.Core.Domain;
using StructureMap;
using QuyouCore.Core.Util;
namespace QuyouCore.Core.Service.Impl
{
    public class KeywordService : BaseService, IKeywordService
    {
        protected override IContainer ConfigureDependencies()
        {
            return new Container(x =>
            {
                x.For<IKeywordTypeRepository>().Use<KeywordTypeRepository>();
                x.For<IKeywordRepository>().Use<KeywordRepository>();
            });
        }
        private IKeywordTypeRepository InitKeywordTypeRepository()
        {
            var container = ConfigureDependencies();
            return container.GetInstance<IKeywordTypeRepository>();
        }
        private IKeywordRepository InitKeywordRepository()
        {
            var container = ConfigureDependencies();
            return container.GetInstance<IKeywordRepository>();
        }

        public string Insert(tb_Keyword data)
        {
            var keywordRepository = InitKeywordRepository();
            var result = keywordRepository.Insert(data);
            return PromptToJson(result > 0 ? Const.PromptSuccess : Const.PromptFailure);
        }

        public string Update(tb_Keyword data)
        {
            var keywordRepository = InitKeywordRepository();
            keywordRepository.Update(data);
            return PromptToJson(Const.PromptSuccess);
        }

        public string Delete(int id)
        {
            var keywordRepository = InitKeywordRepository();
            keywordRepository.Delete(id);
            return PromptToJson(Const.PromptSuccess);
        }

        public string GetSelectedKeywords(tb_KeywordType data)
        {
            var typeRepository = InitKeywordTypeRepository();
            var keywordRepository = InitKeywordRepository();

            data.Active = true;
            data.ParentTypeId = 0;
            //根据线路类型 版块 类别查询出关键字类别
            var allTypes = new List<tb_KeywordType>(); //一级 二级的关键字类别 现在只分到二级 TODO
            var types = typeRepository.GetSelectedTypesByParentId(data);
            foreach (var tbKeywordType in types)
            {
                allTypes.Add(tbKeywordType);
                data.ParentTypeId = tbKeywordType.KeywordTypeId;
                var children = typeRepository.GetSelectedTypesByParentId(data);
                if (children.Count <= 0) continue;
                allTypes.AddRange(children);
            }

            //查询关键字内容
            //var allKeywords = new List<tb_Keyword>();
            var allKeywords = new List<tb_KeywordType>();
            var condition = new tb_Keyword {Active = true};
            foreach (var tbKeywordType in allTypes)
            {
                //allKeywords.Add(new tb_Keyword
                //{
                //    KeywordTypeName = tbKeywordType.Name,
                //    IsKeywordType = true,
                //    Pinyin = string.Empty,
                //    Name = string.Empty
                //});
                condition.KeywordTypeId = tbKeywordType.KeywordTypeId;
                var keywords = keywordRepository.GetKeywordsByTypeId(condition);
                if (keywords.Count <= 0)
                {
                    allKeywords.Add(tbKeywordType);
                    continue;
                }
                tbKeywordType.Keywords = keywords;
                allKeywords.Add(tbKeywordType);
            }
            return PromptToJson(Const.PromptSuccess, allKeywords);
        }
    }
}
