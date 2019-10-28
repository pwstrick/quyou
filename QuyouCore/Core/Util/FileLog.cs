using System.Globalization;
using System.IO;
using System.Text;

namespace QuyouCore.Core.Util
{
    public class FileLog : TextWriter
    {
        public FileLog()
        {
            FileInfo = new StringBuilder();
        }
        #region 重写TextWriter
        public override Encoding Encoding
        {
            get
            {
                return new UnicodeEncoding(false, false);
            }
        }


        public override void Write(char value)
        {
            WriteFile(value.ToString(CultureInfo.InvariantCulture));
        }

        public override void Write(string value)
        {
            if (value != null)
            {
                WriteFile(value);
            }
        }

        public override void Write(char[] buffer, int index, int count)
        {
            if (index < 0 || count < 0 || buffer.Length - index < count)
            {
                base.Write(buffer, index, count);
            }
            WriteFile(new string(buffer, index, count));
        }

        #endregion

        #region 属性

        public static StringBuilder FileInfo
        {
            get;
            set;
        }
        /**/

        /// <summary>
        /// FileLog Factory
        /// </summary>
        public static FileLog Out
        {
            get
            {
                return new FileLog();
            }
        }

        #endregion

        #region 方法
        /**/

        /// <summary>
        /// 写文件
        /// </summary>
        /// <param name="message"></param>
        public void WriteFile(string message)
        {
            FileInfo.Append(message);
        }
        #endregion
    }
}
