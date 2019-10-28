using System;

namespace PwServiceFramework
{
    /// <summary>
    /// 用于标注一个方法是【服务方法】的修饰属性
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class PwServiceMethodAttribute : Attribute
    {
    }
}
