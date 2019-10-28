//=========================================
//
// 作 者：农民伯伯
// 邮 箱：over140@gmail.com
// 博 客：http://over140.cnblogs.com/
// 时 间：2009-7-1 22:53:42
// 描 述：Attribute验证器提取管理类
//
//=========================================

using System;
using System.Collections.Generic;

namespace Lasy.Validator
{
    /// <summary>
    /// Attribute验证器提取管理类
    /// </summary>
    public sealed class TypeProviderManager
    {
        #region Member Variable

        private static IDictionary<string, TypeProvider> types = new Dictionary<string, TypeProvider>();

        #endregion

        #region Method

        /// <summary>
        /// 取得Attribute验证器
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static TypeProvider Get(Type type)
        {
            if (type != null)
            {
                string key = type.FullName;
                if (!types.ContainsKey(key))
                    types.Add(key, new TypeProvider(type));
                return types[key];
            }
            return null;
        }

        /// <summary>
        /// 删除Attribute验证器
        /// </summary>
        /// <param name="type"></param>
        public static void Remove(Type type)
        {
            if (type != null)
            {
                string key = type.FullName;
                if (types.ContainsKey(key))
                    types.Remove(key);
            }
        }

        /// <summary>
        /// 清空Attribute验证器
        /// </summary>
        public static void Clear()
        {
            types.Clear();
        }

        #endregion
    }
}
