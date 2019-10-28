using System;
using System.Web;

namespace PwServiceFramework
{
    /// <summary>
    /// 框架中的一些规则的定义
    /// </summary>
    public static class FrameworkRules
    {
        private static string Internal_GetSerializerFormat(HttpRequest request)
        {
            string flag = request.Headers["Serializer-Format"];
            return (string.IsNullOrEmpty(flag) ? "form" : flag);
        }

        private static Func<HttpRequest, string> _serializerFormatRule = Internal_GetSerializerFormat;

        /// <summary>
        /// 此委托用来判断客户端发起的请求中，数据是以什么方式序列化的。
        /// 返回的结果将会交给SerializerProviderFactory.GetSerializerProvider()来获取序列化提供者
        /// 默认的实现是检查请求头："Serializer-Format"
        /// </summary>
        public static Func<HttpRequest, string> GetSerializerFormat
        {
            internal get { return _serializerFormatRule; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                _serializerFormatRule = value;
            }
        }


        private static Func<HttpRequest, NamesPair> _parseNamesPairRule = UrlPatternHelper.ParseNamesPair;

        /// <summary>
        /// 此委托用来判断客户端发起的请求最后解析到哪个服务类和相应的服务方法
        /// 默认的实现的是由一个正则表达式来判断的：@"/service/(?&lt;name&gt;[^/]+)/(?&lt;method&gt;[^/]+)[/\?]?"
        /// </summary>
        public static Func<HttpRequest, NamesPair> ParseNamesPair
        {
            internal get { return _parseNamesPairRule; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                _parseNamesPairRule = value;
            }
        }
    }
}
