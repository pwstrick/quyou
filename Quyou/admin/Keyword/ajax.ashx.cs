using System.Web;
using System.Web.Services;
using Quyou.admin.Interface;
using Quyou.admin.Presenter;
using QuyouCore.Core.Entity;
using StructureMap;

namespace Quyou.admin.Keyword
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class ajax1 : IHttpHandler
    {
        private IContainer ConfigureDependencies()
        {
            return new Container(x => x.For<IKeywordAjaxPresenter>().Use<KeywordAjaxPresenter>());
        }
        public void ProcessRequest(HttpContext context)
        {
            var container = ConfigureDependencies();
            var presenter = container.GetInstance<IKeywordAjaxPresenter>();
            context.Response.ContentType = "application/json";
            var operate = context.Request["operate"];
            string json;
            switch (operate)
            {
                case "addKeywordType":
                    json = InsertKeywordType(context, presenter);
                    break;
                case "getKeywords":
                    json = GetKeywords(context, presenter);
                    break;
                case "editKeywordType":
                    json = EditKeywordType(context, presenter);
                    break;
                case "delKeywordType":
                    json = DelKeywordType(context, presenter);
                    break;
                case "addKeyword":
                    json = InsertKeyword(context, presenter);
                    break;
                case "editKeyword":
                    json = EditKeyword(context, presenter);
                    break;
                case "delKeyword":
                    json = DelKeyword(context, presenter);
                    break;
                default:
                    json = presenter.ShowErrorJson();
                    break;
            }
            context.Response.Write(json);
        }

        private string InsertKeyword(HttpContext context, IKeywordAjaxPresenter presenter)
        {
            var input = new KeywordtData
            {
                KeywordTypeId = context.Request["typeid"],
                Name = context.Request["word"]
            };
            return presenter.InsertKeyword(input);
        }

        private string DelKeyword(HttpContext context, IKeywordAjaxPresenter presenter)
        {
            var input = new KeywordtData
            {
                KeywordId = context.Request["wordid"]
            };
            return presenter.DelKeyword(input);
        }

        private string EditKeyword(HttpContext context, IKeywordAjaxPresenter presenter)
        {
            var input = new KeywordtData
            {
                KeywordId = context.Request["wordid"],
                KeywordTypeId = context.Request["typeid"],
                Name = context.Request["word"]
            };
            return presenter.EditKeyword(input);
        }


        private string InsertKeywordType(HttpContext context, IKeywordAjaxPresenter presenter)
        {
            var input = new KeywordTypetData
            {
                PlayClass = context.Request["pclass"],
                PlayModel = context.Request["pmodel"],
                PlayType = context.Request["ptype"],
                Name = context.Request["wtype"],
                ParentTypeId = context.Request["parentid"],
                Sort = context.Request["sort"]
            };
            return presenter.InsertKeywordType(input);
        }

        private string EditKeywordType(HttpContext context, IKeywordAjaxPresenter presenter)
        {
            var input = new KeywordTypetData
            {
                KeywordTypeId = context.Request["typeid"],
                PlayClass = context.Request["pclass"],
                PlayModel = context.Request["pmodel"],
                PlayType = context.Request["ptype"],
                Name = context.Request["wtype"],
                ParentTypeId = context.Request["parentid"],
                Sort = context.Request["sort"]
            };
            return presenter.EditKeywordType(input);
        }

        private string DelKeywordType(HttpContext context, IKeywordAjaxPresenter presenter)
        {
            var input = new KeywordTypetData
            {
                KeywordTypeId = context.Request["typeid"]
            };
            return presenter.DelKeywordType(input);
        }

        private string GetKeywords(HttpContext context, IKeywordAjaxPresenter presenter)
        {
            var input = new KeywordTypetData
            {
                PlayClass = context.Request["pclass"],
                PlayModel = context.Request["pmodel"],
                PlayType = context.Request["ptype"],
                Name = context.Request["wtype"],
                ParentTypeId = context.Request["parentid"],
                Sort = context.Request["sort"]
            };
            return presenter.GetKeywords(input);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
