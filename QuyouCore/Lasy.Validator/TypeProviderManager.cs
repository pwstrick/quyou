//=========================================
//
// �� �ߣ�ũ�񲮲�
// �� �䣺over140@gmail.com
// �� �ͣ�http://over140.cnblogs.com/
// ʱ �䣺2009-7-1 22:53:42
// �� ����Attribute��֤����ȡ������
//
//=========================================

using System;
using System.Collections.Generic;

namespace Lasy.Validator
{
    /// <summary>
    /// Attribute��֤����ȡ������
    /// </summary>
    public sealed class TypeProviderManager
    {
        #region Member Variable

        private static IDictionary<string, TypeProvider> types = new Dictionary<string, TypeProvider>();

        #endregion

        #region Method

        /// <summary>
        /// ȡ��Attribute��֤��
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
        /// ɾ��Attribute��֤��
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
        /// ���Attribute��֤��
        /// </summary>
        public static void Clear()
        {
            types.Clear();
        }

        #endregion
    }
}
