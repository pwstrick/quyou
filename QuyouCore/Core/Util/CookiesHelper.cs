using System;
using System.Text;
using System.Web;

namespace QuyouCore.Core.Util
{
    public class CookiesHelper
    {
        /// <summary>
        /// 创建新Cookie
        /// </summary>
        /// <param name="strname">cookie名字</param>
        /// <param name="strvalue">cookie内容</param>
        /// <param name="intdate">cookie有效时间</param>
        public static void CreateCookie(string strname, string strvalue, int intdate)
        {
            try
            {
                strvalue = HttpUtility.UrlEncode(strvalue, Encoding.UTF8);
                var cookie = new HttpCookie(strname, strvalue);
                if (intdate != 0)
                    cookie.Expires = DateTime.Now.AddDays(intdate);
                HttpContext.Current.Response.AppendCookie(cookie); //写入Cookie
            }
            catch (Exception e)
            {
                throw e; //抛出异常
            }
        }
        /// <summary>
        /// 判断是否有这个Cookie名称
        /// </summary>
        /// <param name="name">cookie名字</param>
        /// <returns></returns>
        public static bool CheckCookie(string name)
        {
            if (HttpContext.Current.Request.Cookies[name] == null)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// 读取Cookie值
        /// </summary>
        /// <param name="name">cookie名字</param>
        /// <returns></returns>
        public static string GetCookie(string name)
        {
            if (HttpContext.Current.Request.Cookies[name] == null)
            {
                return null;
            }
            return HttpUtility.UrlDecode(HttpContext.Current.Request.Cookies[name].Value, Encoding.UTF8);

        }
        /// <summary>
        /// 删除Cookie
        /// </summary>
        /// <param name="strname">cookie名字</param>
        public static void DelCookie(string strname)
        {
            if (HttpContext.Current.Request.Cookies[strname] != null)
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies[strname];
                cookie.Expires = DateTime.Now;
                HttpContext.Current.Response.AppendCookie(cookie);
            }
        }

        /// <summary>
        /// 获取选中的区域
        /// </summary>
        public static string GetSelectArea()
        {
            var selected = Const.SelectArea;
            var area = GetCookie(selected);
            if (string.IsNullOrEmpty(area))
            {
                area = Const.Qysh;
            }
            DelCookie(selected);
            CreateCookie(selected, area, 0);
            return area;
        }
    }
}
