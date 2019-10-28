using System;
using System.Web;

namespace PwServiceFramework
{
    /// <summary>
    /// 最终调用服务方法的工具类。
    /// </summary>
    public static class ServiceExecutor
    {
        internal static void ProcessRequest(HttpContext context, ServiceInfo info)
        {
            if (context == null)
                throw new ArgumentNullException("context");
            if (info == null || info.InvokeInfo == null)
                throw new ArgumentNullException("info");

            //if( context.Request.InputStream.Length == 0 )
            //    throw new InvalidDataException("没有调用数据，请将调用数据以请求体的方式传入。");

            if (info.InvokeInfo.AuthenticateRequest(context) == false)
                ExceptionHelper.Throw403Exception(context);

            // 获取客户端的数据序列化格式。	
            //   默认实现方式：request.Headers["Serializer-Format"];
            //   注意：这是我自定义的请求头名称，也可以不指定，默认为：form (表单)
            string serializerFormat = FrameworkRules.GetSerializerFormat(context.Request);

            ISerializerProvider serializerProvider =
                        SerializerProviderFactory.GetSerializerProvider(serializerFormat);

            if (serializerProvider is IRequireSetServiceInfo)
                ((IRequireSetServiceInfo)serializerProvider).SetServiceInfo(info);

            // 获取要调用方法的参数类型
            Type destType = info.InvokeInfo.MethodAttrInfo.ParamType;

            // 获取要调用的参数
            context.Request.InputStream.Position = 0;	// 防止其它Module读取过，但没有归位。
            object param = serializerProvider.Deserialize(destType, context.Request);

            // 调用服务方法
            object result = info.InvokeInfo.MethodAttrInfo.MethodInfo.Invoke(
                                    info.InvokeInfo.ServiceInstance, new object[] { param });

            // 写输出结果
            if (result != null)
                serializerProvider.Serializer(result, context.Response);
        }

        /// <summary>
        /// 【外部接口】用于根据服务的类名和方法名执行某个请求
        /// </summary>
        /// <param name="context"></param>
        /// <param name="pair"></param>
        public static void ProcessRequest(HttpContext context, NamesPair pair)
        {
            if (context == null)
                throw new ArgumentNullException("context");
            if (pair == null)
                throw new ArgumentNullException("pair");

            if (string.IsNullOrEmpty(pair.ServiceName) || string.IsNullOrEmpty(pair.MethodName))
                ExceptionHelper.Throw404Exception(context);


            InvokeInfo vkInfo = ReflectionHelper.GetInvokeInfo(pair);
            if (vkInfo == null)
                ExceptionHelper.Throw404Exception(context);

            ServiceInfo info = new ServiceInfo(pair, vkInfo);

            ProcessRequest(context, info);
        }


    }
}
