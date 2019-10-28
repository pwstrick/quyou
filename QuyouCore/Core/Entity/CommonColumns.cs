using Lasy.Validator;
using QuyouCore.Core.Util;

namespace QuyouCore.Core.Entity
{
    public class CommonColumns
    {
        private int _page;
        private int _count;
        /// <summary>
        /// 只能赋值一次StrPage
        /// </summary>
        public int Page
        {
            get
            {
                if (_page > 0) return _page;
                int.TryParse(StrPage, out _page);
                if (_page <= 0) _page = 1;
                return _page;
            }
        }

        public string StrPage
        {
            get; 
            set;
        }
        /// <summary>
        /// 只能赋值一次StrCount
        /// </summary>
        public int Count
        {
            get
            {
                if (_count > 0) return _count;
                int.TryParse(StrCount, out _count);
                if (_count <= 0) _count = 1;
                return _count;
            }
        }

        public string StrCount
        {
            get; 
            set;
        }
    }
}
