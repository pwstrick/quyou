using System.Collections.Generic;
using System.Linq;
using QuyouCore.Core.Domain;

namespace QuyouCore.Core.DataAccess.Impl
{
    public class KeywordRepository : BaseRepository, IKeywordRepository
    {
        public int Insert(tb_Keyword data)
        {
            using (var cd = Conn.GetClubContext())
            {
                cd.tb_Keyword.InsertOnSubmit(data);
                cd.SubmitChanges();
                return data.KeywordTypeId;
            }
        }

        /// <summary>
        /// 根据主键更新表内容
        /// </summary>
        public void Update(tb_Keyword data)
        {
            using (var cd = Conn.GetClubContext())
            {
                var update = cd.tb_Keyword.Single(t => t.KeywordId == data.KeywordId);
                update.KeywordTypeId = data.KeywordTypeId;
                update.Name = data.Name;
                update.Pinyin = data.Pinyin;
                cd.SubmitChanges();
            }
        }

        /// <summary>
        /// 根据编号将信息更新为删除状态
        /// </summary>
        public void Delete(int id)
        {
            using (var cd = Conn.GetClubContext())
            {
                var update = cd.tb_Keyword.Single(t => t.KeywordId == id);
                update.Active = false;
                cd.SubmitChanges();
            }
        }

        public List<tb_Keyword> GetKeywordsByTypeId(tb_Keyword data)
        {
            return GetEntities<tb_Keyword>(
                t => t.Active == data.Active &&
                     t.KeywordTypeId == data.KeywordTypeId
                );
        }
    }
}
