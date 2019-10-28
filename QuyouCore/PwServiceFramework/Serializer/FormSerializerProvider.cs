using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;

namespace PwServiceFramework
{
    /// <summary>
    /// 从表单和查询字符串中构造参数对象。
    /// 注意：这里的实现很简单，仅做为示例使用。
    /// </summary>
    internal class FormSerializerProvider : ISerializerProvider, IRequireSetServiceInfo
    {
        private ServiceInfo _info;

        public void SetServiceInfo(ServiceInfo info)
        {
            _info = info;
        }

        public object Deserialize(Type destType, HttpRequest request)
        {
            if (destType.IsPrimitive || destType == typeof(string) || destType == typeof(decimal))
            {
                string input = request[_info.InvokeInfo.MethodAttrInfo.ParamName];
                if (input == null)
                    //throw new ArgumentException("没有找到合适的参数数据。");
                    return null;

                return Convert.ChangeType(input, destType);
            }


            object param = Activator.CreateInstance(destType);

            // 直接使用反射，不考虑性能。  如果需要优化，可以修改这里。
            PropertyInfo[] pInfos = destType.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (PropertyInfo pi in pInfos)
                this.SetMemberValue(param, pi, request);

            FieldInfo[] fInfo = destType.GetFields(BindingFlags.Instance | BindingFlags.Public);
            foreach (FieldInfo pi in fInfo)
                this.SetMemberValue(param, pi, request);

            return param;
        }

        private void SetMemberValue(object obj, PropertyInfo pi, HttpRequest request)
        {
            string val = request.QueryString[pi.Name];
            if (string.IsNullOrEmpty(val))
                val = request.Form[pi.Name];

            if (string.IsNullOrEmpty(val))
                return;

            try
            {
                object v = Convert.ChangeType(val, pi.PropertyType);
                pi.SetValue(obj, v, null);
            }
            catch { /* 这里的异常直接忽略，所以只能处理简单的数据类型，不过，也应该够用了。  */ }
        }

        private void SetMemberValue(object obj, FieldInfo pi, HttpRequest request)
        {
            string val = request.QueryString[pi.Name];
            if (string.IsNullOrEmpty(val))
                val = request.Form[pi.Name];

            if (string.IsNullOrEmpty(val))
                return;

            try
            {
                object v = Convert.ChangeType(val, pi.FieldType);
                pi.SetValue(obj, v);
            }
            catch { /* 这里的异常直接忽略，所以只能处理简单的数据类型，不过，也应该够用了。  */ }
        }

        public void Serializer(object obj, HttpResponse response)
        {
            if (obj == null)
                return;

            response.ContentType = "text/plain";

            response.Write(obj.ToString());
        }


    }
}
