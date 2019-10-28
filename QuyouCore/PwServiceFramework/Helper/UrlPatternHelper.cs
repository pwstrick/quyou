using System;
using System.Text.RegularExpressions;
using System.Web;

namespace PwServiceFramework
{
    internal static class UrlPatternHelper
    {
        // 为了演示简单，我只定义一个URL模式。【因为我认为对于服务来说，一个就够了】
        // 如果希望适用性更广，可以从配置文件中读取，并且可支持多组URL模式。
        // URL中加了"/service/"只是为了能更好地区分其它请求，如果您的网站没有子目录，删除它也是可以的。
        internal static readonly string ServicePattern = @"/service/(?<name>[^/]+)/(?<method>[^/]+)[/\?]?";

        // 用于匹配Ajax请求的正则表达式，
        // 可以匹配的URL：/AjaxClass.method.xx?id=2
        // 注意：类名必须Ajax做为前缀
        internal static readonly string AjaxPattern = @"/(?<name>(\w[\./\w]*)?(?=Ajax)\w+)[/\.](?<method>\w+)\.[a-zA-Z]+";



        public static NamesPair ParseNamesPair(HttpRequest request)
        {
            return ParseNamesPair(request, ServicePattern);
        }

        public static NamesPair ParseNamesPair(HttpRequest request, string pattern)
        {
            if (request == null)
                throw new ArgumentNullException("request");
            if (string.IsNullOrEmpty(pattern))
                throw new ArgumentNullException("pattern");

            Match match = Regex.Match(request.Path, pattern);
            if (match.Success == false)
                return null;

            return new NamesPair
            {
                ServiceName = match.Groups["name"].Value,
                MethodName = match.Groups["method"].Value
            };
        }

    }
}
