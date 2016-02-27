using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Configuration;

namespace CMS.Database.Provider
{
    internal class SqlDbContent : DbContent
    {
        private SqlConnection connection;
        private bool isTransaction;

        private static string _connectionString;

        protected static string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_connectionString))
                {
                    _connectionString = ConfigurationManager.AppSettings["ConnectionString"];
                }
                return _connectionString;
            }
        }

        public SqlDbContent()
        {
            connection = new SqlConnection(ConnectionString);
            connection.Open();
        }

        public override void BeginTransaction()
        {
            transaction = connection.BeginTransaction();
            isTransaction = true;
        }

        public override void Commit()
        {
            if (!isTransaction)
                return;
            transaction.Commit();
            isTransaction = false;
            transaction = null;
        }

        public override void Dispose()
        {
            if (isTransaction)
                transaction.Rollback();
            connection.Close();
        }

        public override int Execute(string sql, DataParameters parameters = null)
        {
            return connection.Execute(sql, parameters, isTransaction ? transaction : null, null, System.Data.CommandType.Text);
        }

        public override int ExecuteProc(string procName, DataParameters parameters = null)
        {
            return connection.Execute(procName, parameters, isTransaction ? transaction : null, null, System.Data.CommandType.StoredProcedure);
        }

        public override IEnumerable<T> Query<T>(string sql, DataParameters parameters = null)
        {
            return connection.Query<T>(sql, parameters, isTransaction ? transaction : null, true, null, System.Data.CommandType.Text);
        }

        public override IEnumerable<T> QueryProc<T>(string procName, DataParameters parameters = null)
        {
            return connection.Query<T>(procName, parameters, isTransaction ? transaction : null, true, null, System.Data.CommandType.StoredProcedure);
        }

        public override void Rollback()
        {
            if (!isTransaction)
                return;
            transaction.Rollback();
            isTransaction = false;
            transaction = null;
        }
    }
}
