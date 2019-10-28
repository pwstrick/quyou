using System;
using QuyouCore.Core.Entity;

namespace QuyouCore.Core.Util
{
    public class DateOperate
    {
        /// <summary>
        /// 设置月数间隔
        /// </summary>
        /// <param name="playMonth"></param>
        /// <returns></returns>
        public static DateDiff SetMonthInterval(int playMonth)
        {
            var dt = new DateTime(DateTime.Today.Year, playMonth, 1);
            var strStart = dt.ToString();
            var strEnd = dt.AddMonths(1).ToString();
            return new DateDiff { Start = strStart, End = strEnd };
        }

        /// <summary>
        /// 设置时间间隔
        /// </summary>
        /// <param name="playTime"></param>
        /// <returns></returns>
        public static DateDiff SetTimeInterval(int playTime)
        {
            var strStart = string.Empty;
            var strEnd = string.Empty;
            var year = DateTime.Today.Year;
            var dt = new DateTime(year, 1, 1);
            //已选节日
            switch (playTime)
            {
                case 1://元旦
                    dt = new DateTime(year, 1, 1);
                    strStart = dt.ToString();
                    strEnd = dt.AddDays(3).ToString();
                    break;
                case 2://春节
                    dt = new DateTime(year, 1, 31);
                    strStart = dt.ToString();
                    strEnd = dt.AddDays(7).ToString();
                    break;
                case 3://清明
                    dt = new DateTime(year, 4, 5);
                    strStart = dt.ToString();
                    strEnd = dt.AddDays(3).ToString();
                    break;
                case 4://五一
                    dt = new DateTime(year, 5, 1);
                    strStart = dt.ToString();
                    strEnd = dt.AddDays(3).ToString();
                    break;
                case 5://端午
                    dt = new DateTime(year, 5, 31);
                    strStart = dt.ToString();
                    strEnd = dt.AddDays(3).ToString();
                    break;
                case 6://中秋
                    dt = new DateTime(year, 9, 6);
                    strStart = dt.ToString();
                    strEnd = dt.AddDays(3).ToString();
                    break;
                case 7://国庆
                    dt = new DateTime(year, 10, 1);
                    strStart = dt.ToString();
                    strEnd = dt.AddDays(7).ToString();
                    break;
                case 8://圣诞
                    dt = new DateTime(year, 12, 25);
                    strStart = dt.ToString();
                    strEnd = dt.AddDays(3).ToString();
                    break;
            }
            return new DateDiff { Start = strStart, End = strEnd };
        }
    }
}
