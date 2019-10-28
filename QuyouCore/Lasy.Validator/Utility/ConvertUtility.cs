//=========================================
//
// 作 者：农民伯伯
// 邮 箱：over140@gmail.com
// 博 客：http://over140.cnblogs.com/
// 时 间：2009-6-2 20:41:05
// 描 述：转换工具类
//
//=========================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;
using System.Web.UI;

namespace Lasy.Utility
{
    /// <summary>
    /// 转换工具类
    /// </summary>
    public static class ConvertUtility
    {
        #region bool

        /// <summary>
        /// 转换bool，转换失败将返回false
        /// </summary>
        /// <param name="bObj">待验证的值</param>
        /// <returns></returns>
        public static bool ToBoolean(object bObj)
        {
            return ToBoolean(bObj, false);
        }

        /// <summary>
        /// 转换bool
        /// </summary>
        /// <param name="bObj">待验证的值</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static bool ToBoolean(object bObj, bool defaultValue)
        {
            return bObj is bool ? Convert.ToBoolean(bObj) : defaultValue;
        }

        #endregion

        #region int

        /// <summary>
        /// 转换int
        /// </summary>
        /// <param name="iObj">待验证的值</param>
        /// <returns></returns>
        public static int ToInt(object iObj)
        {
            return ToInt(iObj, default(int));
        }

        /// <summary>
        /// 转换int
        /// </summary>
        /// <param name="iObj">待验证的值</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static int ToInt(object iObj, int defaultValue)
        {
            if (iObj == null)
                return defaultValue;

            if (iObj is int)
                return Convert.ToInt32(iObj);

            int result;

            return int.TryParse(iObj.ToString(), out result) ? result : defaultValue;
        }

        #endregion

        #region IDictionary<string, object>

        /// <summary>
        /// 转换NameValueCollection为IDictionary
        /// </summary>
        /// <param name="nvc"></param>
        /// <returns></returns>
        public static IDictionary<string, object> ToDictionary(NameValueCollection nvc)
        {
            IDictionary<string, object> result = new Dictionary<string, object>();

            if (nvc == null || nvc.Keys.Count == 0)
                return result;

            foreach (string key in nvc.Keys)
            {
                result.Add(key, nvc[key]);
            }

            return result;
        }



        #endregion

    }
}
