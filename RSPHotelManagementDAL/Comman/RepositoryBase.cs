using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSPHotelManagementDAL.Comman
{
    public abstract class RepositoryBase<T> where T : class, new()
    {
        protected virtual string ConnectionString { get; set; }

        protected RepositoryBase()
        {
            this.ConnectionString = GetConnectionString();
        }
        private string GetConnectionString(string ConnectionName = "connectionString")
        {
            return ConfigurationManager.ConnectionStrings[ConnectionName].ConnectionString;

        }
        protected string GetTestDBConnectionString()
        {
            return GetConnectionString("ConnectionString");
        }

        protected virtual List<T> ExecuteReader(string storedProcedureName, List<SqlParameter> parameters, Action<T, SqlDataReader, string[]> setupRow, int timeOut)
        {
            var resultList = new List<T>();
            using (var connection = new SqlConnection(this.ConnectionString))
            {
                using (var command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddRange(parameters.ToArray());
                    command.CommandTimeout = timeOut;
                    connection.Open();
                    using (var dataReader = command.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        while (dataReader.Read())
                        {
                            var newObject = new T();
                            var columnName = this.GetColumnName(dataReader);
                            setupRow(newObject, dataReader, columnName);
                            resultList.Add(newObject);
                        }
                    }
                }
            }
            return resultList;
        }

        protected virtual List<Y> ManualExecuteReader<Y>(string storedprocedureName, List<SqlParameter> parameters, Action<Y, SqlDataReader, string[]> setupRow, int timeOut) where Y : class, new()
        {
            var resultList = new List<Y>();
            using (var connection = new SqlConnection(this.ConnectionString))
            {
                using (var command = new SqlCommand(storedprocedureName, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddRange(parameters.ToArray());
                    command.CommandTimeout = timeOut;
                    connection.Open();
                    using (var dataReader = command.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        while (dataReader.Read())
                        {
                            var newObject = new Y();
                            var columnName = this.GetColumnName(dataReader);
                            setupRow(newObject, dataReader, columnName);
                            resultList.Add(newObject);
                        }
                    }
                }
            }
            return resultList;

        }
        protected virtual Y ExecuteScalar<Y>(string storedProcedureName, List<SqlParameter> parameters, int timeOut)
        {
            var result = default(Y);
            using (var connection = new SqlConnection(this.ConnectionString))
            {
                using (var command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddRange(parameters.ToArray());
                    command.CommandTimeout = timeOut;
                    connection.Open();
                    var objResult = command.ExecuteScalar();
                    result = (Y)objResult;
                }
            }
            return result;
        }
        protected string[] GetColumnName(SqlDataReader dataReader)
        {
            return Enumerable.Range(0, dataReader.FieldCount).Select(dataReader.GetName).ToArray();
        }
        protected int GetColumnOrdinal(string[] columnNameList, string columnName)
        {
            for (int i = 0; i < columnNameList.Length; i++)
            {
                if (string.Equals(columnName, columnNameList[i], StringComparison.InvariantCultureIgnoreCase))
                {
                    return i;
                }
            }
            return -1;
        }
        protected virtual int ExecuteNonQuery(string storedProcedureName, List<SqlParameter> parameters, int timeOut)
        {
            using (var connection = new SqlConnection(this.ConnectionString))
            {
                using (var command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddRange(parameters.ToArray());
                    command.CommandTimeout = timeOut;
                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    return result;
                }
            }
        }
        protected virtual int ExecuteNonQuery(string text, int timeOut)
        {
            using (var connection = new SqlConnection(this.ConnectionString))
            {
                using (var command = new SqlCommand(text, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandTimeout = timeOut;
                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    return result;
                }
            }
        }
        protected virtual int ExecuteScalar(string text, int timeOut)
        {
            using (var connection = new SqlConnection(this.ConnectionString))
            {
                using (var command = new SqlCommand(text, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandTimeout = timeOut;
                    connection.Open();
                    var result = command.ExecuteScalar();
                    return (int)result;
                }
            }
        }
    }
}
