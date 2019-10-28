using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace QuyouCore.Core.Domain
{
    /// <summary>
    /// 数据列表
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    public class DataPageList<T> : IEnumerable
    {
        #region 成员变量

        private System.Linq.IQueryable<T> query;
        private int allRecordCount;
        private int thisPageRecordCount;
        private int pageSize;
        private int pageCount;
        private int indexPage;
        private bool canFirstPage;
        private bool canPrevPage;
        private bool canNextPage;
        private bool canLastpage;
        private List<T> listValue;

        #endregion


        #region 构造函数

        //私有构造函数，只能通过内部构造
        private DataPageList(System.Linq.IQueryable<T> Query, int IndexPage, int PageSize)
        {
            query = Query;
            indexPage = IndexPage;
            pageSize = PageSize;
            PageAttrList = new List<PageAttr>();
            Update();
        }

        private DataPageList(System.Linq.IQueryable<T> Query)
            : this(Query, 1, 0)
        {
        }

        #endregion


        #region 属性

        public int AllRecordCount
        {
            get { return allRecordCount; }
        }

        public int ThisPageRecordCount
        {
            get { return thisPageRecordCount; }
        }

        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
        }

        public int PageCount
        {
            get { return pageCount; }
        }

        public int IndexPage
        {
            get { return indexPage; }
            set { indexPage = value; }
        }

        public bool CanFirstPage
        {
            get { return canFirstPage; }
        }

        public bool CanPrevPage
        {
            get { return canPrevPage; }
        }

        public bool CanNextPage
        {
            get { return canNextPage; }
        }

        public bool CanLastPage
        {
            get { return canLastpage; }
        }

        public List<T> Value
        {
            get { return listValue; }
        }

        public class PageAttr
        {
            public int Page { get; set; }
        }

        public List<PageAttr> PageAttrList
        {
            get; set;
        }
        #endregion

        #region 索引器

        public T this[int index]
        {
            get { return listValue[index]; }
            set { listValue[index] = value; }
        }

        #endregion

        #region 公开方法

        /**/

        /// <summary>
        /// 创建自身实例
        /// </summary>
        /// <typeparam name="N">类型，如果此处为匿名类型，请用var 定义实体，且类后的T为object(其实什么也不重要，只是用于可以调用当前类的静态方法)</typeparam>
        /// <param name="Query">Linq查询语句</param>
        /// <param name="type">元素类型</param>
        /// <param name="IndexPage">开始页</param>
        /// <param name="PageSize">每页大小</param>
        /// <returns></returns>
        public static DataPageList<N> Create<N>(System.Linq.IQueryable Query, int IndexPage, int PageSize)
        {
            System.Linq.IQueryable<N> query = (System.Linq.IQueryable<N>) Query;
            return new DataPageList<N>(query, IndexPage, PageSize);
        }

        //public static DataPageList<N> Create<N>(System.Linq.IQueryable Query, int IndexPage, int PageSize)
        //{
        //    return Create<N>(Query, IndexPage, PageSize);
        //}

        /**/

        /// <summary>
        /// 更新数据
        /// </summary>
        public virtual void Update()
        {
            allRecordCount = query.Count();
            PageAttrList.Clear();
            if (pageSize > 0)
            {
                query = query.Skip((indexPage - 1) * pageSize).Take(pageSize);
                thisPageRecordCount = query.Count();
                //计算分页结果
                pageCount = (allRecordCount%pageSize == 0) ? (allRecordCount/pageSize) : allRecordCount/pageSize + 1;
                if (indexPage > 1) canFirstPage = true;
                canPrevPage = true;
                if (indexPage < pageCount) canNextPage = true;
                canLastpage = true;
            }
            else
            {
                thisPageRecordCount = allRecordCount;
                pageCount = indexPage = 1;
                canFirstPage = canPrevPage = canNextPage = canLastpage = false;
            }
            for (var cur = 1; cur <= pageCount; cur++)
            {
                PageAttrList.Add(new PageAttr {Page = cur});
            }
            listValue = query.ToList();
        }

        /**/

        /// <summary>
        /// 实现枚举接口，不过返回的是object
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            return listValue.GetEnumerator();
        }

        #endregion
    }
}
