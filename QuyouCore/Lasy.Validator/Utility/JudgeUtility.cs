//=========================================
//
// 作 者：农民伯伯
// 邮 箱：over140@gmail.com
// 博 客：http://over140.cnblogs.com/
// 时 间：2008-12-13 10:48:17
// 描 述：bool判断工具类
//
//=========================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Lasy.Utility
{
    /// <summary>
    /// bool判断工具类
    /// </summary>
    public static class JudgeUtility
    {

        #region Member Variable

        /// <summary>
        /// @"^[+-]?\d*$"
        /// </summary>
        private const string PATTERN_INT = @"^[+-]?\d*$";
        /// <summary>
        /// @"^\d*$"
        /// </summary>
        private const string PATTERN_UINT = @"^\d*$";
        /// <summary>
        /// @"^\d*$"
        /// </summary>
        private const string PATTERN_NUMERIC = @"^\d*$";
        /// <summary>
        /// @"^\d*[.]?\d*$"
        /// </summary>
        private const string PATTERN_UNUMERIC = @"^\d*[.]?\d*$";
        /// <summary>
        /// Email 正则表达式
        /// </summary>
        private const string PATTERN_EMAIL = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        /// <summary>
        /// URL 正则表达式
        /// </summary>
        private const string PATTERN_URL = @"^(http|https)\://([a-zA-Z0-9\.\-]+(\:[a-zA-Z0-9\.&%\$\-]+)*@)*((25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])|localhost|([a-zA-Z0-9\-]+\.)*[a-zA-Z0-9\-]+\.(com|edu|gov|int|mil|net|org|biz|arpa|info|name|pro|aero|coop|museum|[a-zA-Z]{1,10}))(\:[0-9]+)*(/($|[a-zA-Z0-9\.\,\?\'\\\+&%\$#\=~_\-]+))*$";
        /// <summary>
        /// @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$"
        /// </summary>
        private const string PATTERN_IPADDRESS = @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$";
        /// <summary>
        /// "^(5[1-5]\d{14})|(4\d{12}(\d{3})?)|(3[47]\d{13})|(6011\d{14})|((30[0-5]|36\d|38\d)\d{11})$"
        /// </summary>
        private const string PATTERN_CREDITCARD = @"^(5[1-5]\d{14})|(4\d{12}(\d{3})?)|(3[47]\d{13})|(6011\d{14})|((30[0-5]|36\d|38\d)\d{11})$";

        #endregion

        #region Is

        #region IsNullOrEmpty

        /// <summary>
        /// 判断集合中元素是不是有空值
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(params string[] values)
        {
            foreach (string value in values)
            {
                if (string.IsNullOrEmpty(value))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 判断是否为空
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(object value)
        {
            return value == null || string.IsNullOrEmpty(value.ToString());
        }

        #endregion

        #region IsInt

        /// <summary>
        /// 是否是整数
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsInt(object value)
        {
            return IsMatch(value, PATTERN_INT);
        }

        #endregion

        #region IsUInt

        /// <summary>
        /// 是否是无符号整数(正数)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsUInt(object value)
        {
            return IsMatch(value, PATTERN_UINT);
        }

        #endregion

        #region IsNumeric

        /// <summary>
        /// 是否是数字
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNumeric(object value)
        {
            if (IsNullOrEmpty(value))
                return false;

            if (value is short || value is int || value is float || value is double || value is long)
                return true;

            return Regex.IsMatch(value.ToString(), PATTERN_NUMERIC);
        }

        #endregion

        #region IsUNumeric

        /// <summary>
        /// 是否是无符号数字(正数)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsUNumeric(object value)
        {
            if (IsNullOrEmpty(value))
                return false;

            if (value is ushort || value is uint || value is ulong)
                return true;

            return Regex.IsMatch(value.ToString(), PATTERN_UNUMERIC);
        }

        #endregion

        #region IsDateTime

        /// <summary>
        /// 判断是否是日期
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static bool IsDateTime(object dateTime)
        {
            if (IsNullOrEmpty(dateTime))
                return false;

            DateTime dt;
            return DateTime.TryParse(dateTime.ToString(), out dt);
        }

        #endregion

        #region IsEmail

        /// <summary>
        /// 否符合email格式 [DZ]
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsEmail(object value)
        {
            return IsMatch(value, PATTERN_EMAIL);
        }

        #endregion

        #region IsURL

        /// <summary>
        /// 是否是正确的Url [DZ]
        /// </summary>
        /// <param name="strUrl">要验证的Url</param>
        /// <returns>判断结果</returns>
        public static bool IsURL(string strUrl)
        {
            return IsMatch(strUrl, PATTERN_URL);
        }

        #endregion

        #region IsCreditCard

        /// <summary>
        /// 是否是合法的信用卡号
        /// </summary>
        /// <param name="value">待验证的值</param>
        /// <returns></returns>
        public static bool IsCreditCard(object value)
        {
            return IsMatch(value, PATTERN_CREDITCARD);
        }

        #endregion

        #region IsIPAddress

        /// <summary>
        /// 是否有IP地址 [DZ]
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsIPAddress(object ip)
        {
            return IsMatch(ip, PATTERN_IPADDRESS);
        }

        #endregion

        #endregion

        #region EndsWith

        /// <summary>
        /// 判定字符串的末尾是否以集合中任何元素匹配
        /// </summary>
        /// <param name="value"></param>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static bool EndsWith(string value, IEnumerable<string> collection)
        {
            foreach (string item in collection)
                if (value.EndsWith(item))
                    return true;
            return false;
        }

        #endregion

        #region Contains

        /// <summary>
        /// 验证字符串是否出现在集合中
        /// </summary>
        /// <param name="value"></param>
        /// <param name="keys"></param>
        /// <returns></returns>
        public static bool Contains(object value, params object[] keys)
        {
            foreach (object key in keys)
            {
                if (key != null && key.Equals(value))
                    return true;
            }
            return false;
        }

        #endregion

        #region Common

        private static bool IsMatch(string input, string pattern)
        {
            if (string.IsNullOrEmpty(input))
                return false;

            return Regex.IsMatch(input, pattern);
        }

        private static bool IsMatch(object input, string pattern)
        {
            if (IsNullOrEmpty(input))
                return false;

            return Regex.IsMatch(input.ToString(), pattern);
        }

        #endregion
    }
}


///// <summary>
///// 是否有Sql危险字符 [DZ]
///// </summary>
///// <param name="str">要判断字符串</param>
///// <returns>判断结果</returns>
//public static bool IsSafeSqlString(string sql)
//{
//    return !Regex.IsMatch(sql, @"[-|;|,|\/|\(|\)|\[|\]|\}|\{|%|@|\*|!|\']");
//}

///// <summary>
///// 是否包含WHERE关键字
///// </summary>
///// <param name="sqlWhere"></param>
///// <returns>判断结果</returns>
//public static bool IsHasWhere(string sqlWhere)
//{
//    return IsMatch(sqlWhere, @"^[ ]*WHERE[ ]+");
//}