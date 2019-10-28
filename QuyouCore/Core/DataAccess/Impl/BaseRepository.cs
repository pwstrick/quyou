using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using QuyouCore.Core.Domain;
using QuyouCore.Core.Enum;
using QuyouCore.Core.Util;
using System;
using System.Linq.Expressions;
namespace QuyouCore.Core.DataAccess.Impl
{
    public class BaseRepository
    {
        protected BaseRepository()
        {
            Conn = new Connection();
            DataContext = new RepositoryContext(Conn.ConnString);
        }
        #region Properties
        /// <summary>
        /// Gets or sets the data context.
        /// </summary>
        /// <value>The data context.</value>
        private RepositoryContext DataContext { get; set; }
        protected Connection Conn { get; set; }
        #endregion

        #region Entity and metadata functions
        /// <summary>
        /// 分页
        /// </summary>
        protected DataPageList<TEntity> GetEntitiesByPage<TEntity>(IQueryable query, int page, int size, DataContext context)
        {
            context.Log = FileLog.Out;
            var data = DataPageList<TEntity>.Create<TEntity>(query, page, size);
            WriteLog(FileLog.FileInfo.ToString());
            return data;
        }
        /// <summary>
        /// 根据条件获取一条数据
        /// </summary>
        protected TEntity GetEntity<TEntity>(Expression<Func<TEntity, bool>> queryFunc) where TEntity : class //Entity
        {
            DataContext.Log = FileLog.Out;
            var results = from entity in DataContext.GetTable<TEntity>()
                          select entity;
            results = results.Where(queryFunc);
            var result = results.FirstOrDefault();
            WriteLog(FileLog.FileInfo.ToString());
            return result;
        }
        /// <summary>
        /// 根据条件获取数据信息列
        /// </summary>
        protected List<TEntity> GetEntities<TEntity>(Expression<Func<TEntity, bool>> queryFunc) where TEntity : class //Entity 
        {
            DataContext.Log = FileLog.Out;
            var query = from entity in DataContext.GetTable<TEntity>()
                          select entity;
            query = query.Where(queryFunc);
            var results = query.ToList();
            WriteLog(FileLog.FileInfo.ToString());
            return results;
        }
        protected List<TEntity> GetEntities<TEntity>(IQueryable<TEntity> query) where TEntity : class //Entity 
        {
            DataContext.Log = FileLog.Out;
            var results = query.ToList();
            WriteLog(FileLog.FileInfo.ToString());
            return results;
        }
        protected IQueryable<TEntity> GetQueryEntities<TEntity>(Expression<Func<TEntity, bool>> queryFunc) where TEntity : class //Entity 
        {
            var query = from entity in DataContext.GetTable<TEntity>()
                        select entity;
            return query.Where(queryFunc);
        }
        /// <summary>
        /// 获取所有数据
        /// </summary>
        protected List<TEntity> GetEntities<TEntity>() where TEntity : class //Entity 
        {
            DataContext.Log = FileLog.Out;
            var query = from entity in DataContext.GetTable<TEntity>()
                          select entity;
            var results = query.ToList();
            WriteLog(FileLog.FileInfo.ToString());
            return results;
        }
        #endregion


        protected void WriteLog(string log)
        {
            WriteLog(log, EnumLog.Level.Info);
        }
        protected void WriteLog(string log, EnumLog.Level level)
        {
            switch (level)
            {
                case EnumLog.Level.Debug: 
                    LogHelper.GetInstance().Debug(log);
                    break;
                case EnumLog.Level.Error:
                    LogHelper.GetInstance().Error(log);
                    break;
                case EnumLog.Level.Warn:
                    LogHelper.GetInstance().Warn(log);
                    break;
                case EnumLog.Level.Fatal:
                    LogHelper.GetInstance().Fatal(log);
                    break;
                case EnumLog.Level.Info:
                    LogHelper.GetInstance().Info(log);
                    break;
                default:
                    LogHelper.GetInstance().Info(log);
                    break;
            }
            //LogHelper.GetInstance().Logger.Repository.Shutdown();
        }
    }
}
