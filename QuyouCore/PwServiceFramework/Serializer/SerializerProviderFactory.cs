using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace PwServiceFramework
{
    /// <summary>
    /// 序列化器提供者的创建工厂
    /// </summary>
    public static class SerializerProviderFactory
    {
        private static readonly Hashtable s_dict;

        static SerializerProviderFactory()
        {
            s_dict = Hashtable.Synchronized(new Hashtable(10, StringComparer.OrdinalIgnoreCase));
            //s_dict.Add("json", typeof(JsonSerializerProvider));
            //s_dict.Add("xml", typeof(XmlSerializerProvider));

            RegisterSerializerProvider("form", typeof(FormSerializerProvider));
            RegisterSerializerProvider("json", typeof(JsonSerializerProvider));
            RegisterSerializerProvider("xml", typeof(XmlSerializerProvider));
        }


        /// <summary>
        /// 注册序列化提供者
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void RegisterSerializerProvider(string name, Type type)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");

            if (type == null)
                throw new ArgumentNullException("type");

            if (typeof(ISerializerProvider).IsAssignableFrom(type) == false)
                throw new ArgumentException("指定的类型并没有实现ISerializerProvider接口。");

            s_dict[name] = type;
        }

        /// <summary>
        /// 根据消息头的序列化标记，返回一个具体的序列化器。
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static ISerializerProvider GetSerializerProvider(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");


            Type t = (Type)s_dict[name];
            if (t == null)
                throw new ArgumentOutOfRangeException("name");

            return Activator.CreateInstance(t) as ISerializerProvider;
        }
    }
}
