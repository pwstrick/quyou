using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Compilation;

namespace PwServiceFramework
{
    internal static class ReflectionHelper
    {
        private static List<TypeAndAttrInfo> s_typeList;

        static ReflectionHelper()
        {
            InitServiceTypes();
        }

        /// <summary>
        /// 加载所有的服务类型，判断方式就是检查类型是否有MyServiceAttribute
        /// </summary>
        private static void InitServiceTypes()
        {
            s_typeList = new List<TypeAndAttrInfo>(256);

            ICollection assemblies = BuildManager.GetReferencedAssemblies();
            foreach (Assembly assembly in assemblies)
            {
                // 过滤以【System.】开头的程序集，加快速度
                if (assembly.FullName.StartsWith("System.", StringComparison.OrdinalIgnoreCase))
                    continue;

                try
                {
                    (from t in assembly.GetExportedTypes()
                        let a = (PwServiceAttribute[]) t.GetCustomAttributes(typeof (PwServiceAttribute), false)
                        where a.Length > 0
                        select new TypeAndAttrInfo
                        {
                            ServiceType = t,
                            Attr = a[0],
                            AuthorizeAttr = t.GetClassAuthorizeAttribute()
                        }
                        ).ToList().ForEach(b => s_typeList.Add(b));
                }
                catch
                {
                }
            }
        }

        private static AuthorizeAttribute GetClassAuthorizeAttribute(this Type t)
        {
            AuthorizeAttribute[] attrs =
                (AuthorizeAttribute[]) t.GetCustomAttributes(typeof (AuthorizeAttribute), false);
            return (attrs.Length > 0 ? attrs[0] : null);
        }

        /// <summary>
        /// 根据一个名称获取对应的服务类型（从缓存中获取类型）
        /// </summary>
        /// <param name="typeName"></param>
        /// <returns></returns>
        private static TypeAndAttrInfo GetServiceType(string typeName)
        {
            if (string.IsNullOrEmpty(typeName))
                throw new ArgumentNullException("typeName");


            // 查找类型的方式：如果有点号，则按全名来查找(包含命名空间)，否则只看名字。
            // 本框架对于多个匹配条件的类型，将返回第一个匹配项。
            if (typeName.IndexOf('.') > 0)
                return s_typeList.FirstOrDefault(t => string.Compare(t.ServiceType.FullName, typeName, true) == 0);
            else
                return s_typeList.FirstOrDefault(t => string.Compare(t.ServiceType.Name, typeName, true) == 0);
        }



        private static Hashtable s_methodTable = Hashtable.Synchronized(
            new Hashtable(4096, StringComparer.OrdinalIgnoreCase));

        /// <summary>
        /// 根据指定的类型以及方法名称，获取对应的方法信息
        /// </summary>
        /// <param name="type"></param>
        /// <param name="methodName"></param>
        /// <returns></returns>
        private static MethodAndAttrInfo GetServiceMethod(Type type, string methodName)
        {
            if (type == null)
                throw new ArgumentNullException("type");
            if (string.IsNullOrEmpty(methodName))
                throw new ArgumentNullException("methodName");

            // 首先尝试从缓存中读取
            string key = methodName + "@" + type.FullName;
            MethodAndAttrInfo mi = (MethodAndAttrInfo) s_methodTable[key];

            if (mi == null)
            {
                // 注意：这里不考虑方法的重载。
                MethodInfo method = type.GetMethod(methodName,
                    BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase);

                if (method == null)
                    return null;

                PwServiceMethodAttribute[] attrs = (PwServiceMethodAttribute[])
                    method.GetCustomAttributes(typeof (PwServiceMethodAttribute), false);
                if (attrs.Length != 1)
                    return null;


                // 由于服务方法的参数来源于反序列化，此时只可能包含一个参数。
                ParameterInfo[] paraInfos = method.GetParameters();
                if (paraInfos.Length != 1)
                    throw new ArgumentNullException("指定的方法虽找到，但该方法的参数数量不是1");

                AuthorizeAttribute[] auths =
                    (AuthorizeAttribute[]) method.GetCustomAttributes(typeof (AuthorizeAttribute), false);

                mi = new MethodAndAttrInfo
                {
                    MethodInfo = method,
                    ParamType = paraInfos[0].ParameterType,
                    ParamName = paraInfos[0].Name,
                    Attr = attrs[0],
                    AuthorizeAttr = (auths.Length > 0 ? auths[0] : null)
                };

                s_methodTable[key] = mi;
            }

            return mi;
        }


        /// <summary>
        /// 根据类型名称以及方法名称返回要调用的相关信息
        /// </summary>
        /// <param name="pair">包含类型名称以及方法名称的对象</param>
        /// <returns></returns>
        public static InvokeInfo GetInvokeInfo(NamesPair pair)
        {
            if (pair == null)
                throw new ArgumentNullException("pair");

            InvokeInfo vkInfo = new InvokeInfo();

            vkInfo.ServiceTypeInfo = GetServiceType(pair.ServiceName);
            if (vkInfo.ServiceTypeInfo == null)
                return null;

            vkInfo.MethodAttrInfo = GetServiceMethod(vkInfo.ServiceTypeInfo.ServiceType, pair.MethodName);
            if (vkInfo.MethodAttrInfo == null)
                return null;


            if (vkInfo.MethodAttrInfo.MethodInfo.IsStatic == false)
                vkInfo.ServiceInstance = Activator.CreateInstance(vkInfo.ServiceTypeInfo.ServiceType);


            return vkInfo;
        }
    }
}
