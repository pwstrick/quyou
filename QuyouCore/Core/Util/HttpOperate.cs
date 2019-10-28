using System.IO;
using System.Configuration;
namespace QuyouCore.Core.Util
{
    public class HttpOperate
    {
        /// <summary>
        /// 获得网站路径
        /// </summary>
        /// <returns></returns>
        public static string GetHttpLink()
        {
            return Const.RootUrl;
        }

        public static bool CheckHttpImg(string src)
        {
            if (src.Length >= 7 && (src.Substring(0, 7) == "http://" || src.Substring(0, 8) == "https://"))
                return true;
            return false;
        }

        public static string GetHttpSrc(string src, string webLink)
        {
            return !CheckHttpImg(src) ? string.Format("{0}{1}", webLink, src) : src;
        }

        /// <summary>
        /// 获取默认图片或压缩过的图片
        /// </summary>
        /// <param name="src"></param>
        /// <param name="suffix"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="sign"></param>
        /// <returns></returns>
        public static string GetDefaultOrSelectedImg(string src, string suffix, int width, int height, string sign)
        {
            if (CheckHttpImg(src)) return src;
            string sourcePath, newPath, sourcePathAb, newPathAb;
            sourcePath = src;
            newPath = sourcePath + suffix;
            sourcePathAb = System.Web.HttpContext.Current.Server.MapPath("~/" + sourcePath);
            newPathAb = sourcePathAb + suffix;
            if (!File.Exists(newPathAb) && File.Exists(sourcePathAb))
            {
                ImageOperate.MakeThumbnail(sourcePathAb, newPathAb, width, height, sign);
                return newPath;
            }
            if (File.Exists(newPathAb))
                return newPath;
            return Const.DefaultHeadPhoto;
        }
    }
}
