using System;
using System.Web;
using PwServiceFramework;

namespace PwServiceFramework
{
    /// <summary>
    /// 序列化器提供者接口
    /// </summary>
    public interface ISerializerProvider
    {
        /// <summary>
        /// 反序列化方法
        /// </summary>
        /// <param name="destType"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        object Deserialize(Type destType, HttpRequest request);

        /// <summary>
        /// 序列化方法
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="response"></param>
        void Serializer(object obj, HttpResponse response);
    }

    internal interface IRequireSetServiceInfo
    {
        void SetServiceInfo(ServiceInfo info);
    }
}
