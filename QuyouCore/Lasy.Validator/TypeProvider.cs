//=========================================
//
// 作 者：农民伯伯
// 邮 箱：over140@gmail.com
// 博 客：http://over140.cnblogs.com/
// 时 间：2009-7-1 23:11:59
// 描 述：Attribute验证器提取
//
//=========================================

using System;
using System.Collections.Generic;
using System.Reflection;

namespace Lasy.Validator
{
    /// <summary>
    /// Attribute验证器提取
    /// </summary>
    public sealed class TypeProvider
    {
        #region Member Variables

        private readonly IDictionary<string, IList<IValidator>> validates;

        #endregion

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        public TypeProvider(Type type)
        {

            validates = new Dictionary<string, IList<IValidator>>();
            foreach (PropertyInfo Property in type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
            {
                string pName = Property.Name;

                foreach (object attribute in Property.GetCustomAttributes(false))
                {
                    if (attribute is IValidator)
                    {
                        IValidator validator = (IValidator)attribute;

                        if (string.IsNullOrEmpty(validator.Key))
                            validator.Key = pName;
                        else
                            pName = validator.Key;

                        if (validates.ContainsKey(pName) && !validates[pName].Contains(validator))
                            validates[pName].Add(validator);
                        else
                            validates.Add(pName, new List<IValidator>(new IValidator[] { validator }));
                    }
                }
            }
        }

        #endregion

        #region Properties

        /// <summary>
        ///    Key      :    属性(Property)名
        ///    Value   :    验证器类型
        /// </summary>
        public IDictionary<string, IList<IValidator>> Validates
        {
            get { return validates; }
        }

        #endregion

    }
}