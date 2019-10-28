using System.Web;

namespace PwServiceFramework
{
    internal class AjaxServiceHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            NamesPair pair = UrlPatternHelper.ParseNamesPair(context.Request, UrlPatternHelper.AjaxPattern);
            if (pair == null)
                ExceptionHelper.Throw404Exception(context);

            ServiceExecutor.ProcessRequest(context, pair);
        }

        public bool IsReusable
        {
            get { return false; }
        }

    }
}
