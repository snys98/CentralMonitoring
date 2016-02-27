using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Database.Provider
{
    internal abstract class DbContent : IDisposable
    {
        protected DbTransaction transaction;
        public abstract void Dispose();
        /// <summary>
        /// 执行SQL语句，返回影响行数
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public abstract int Execute(string sql, DataParameters parameters = null);
        /// <summary>
        /// 执行存储过程，返回影响行数
        /// </summary>
        /// <param name="procName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public abstract int ExecuteProc(string procName, DataParameters parameters = null);
        /// <summary>
        /// 执行SQL查询语句
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public abstract IEnumerable<T> Query<T>(string sql, DataParameters parameters = null);
        /// <summary>
        /// 执行存储过程查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="procName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public abstract IEnumerable<T> QueryProc<T>(string procName, DataParameters parameters = null);
        /// <summary>
        /// 开启事务
        /// </summary>
        public abstract void BeginTransaction();
        /// <summary>
        /// 提交事务
        /// </summary>
        public abstract void Commit();
        /// <summary>
        /// 回滚事务
        /// </summary>
        public abstract void Rollback();
    }
}
