using Dapper;
using MISA.Core.Interface.Repository;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;

namespace MISA.Infrastructure.Repository
{
    /// <summary>
    /// Repository dùng chung
    /// </summary>
    /// <typeparam name="MISAEntity"></typeparam>
    /// CreatedBy: KDLong 27/04/2021
    public class BaseRepository<MISAEntity> : IBaseRepository<MISAEntity> where MISAEntity : class
    {
        string tableName = typeof(MISAEntity).Name;
        protected string connectionString = "" +
           "Host = 47.241.69.179;" +
           "Port = 3306;" +
           "Database = MF822_Import_KDLong;" +
           "User Id= dev;" +
           "Password = 12345678;";
        protected IDbConnection dbConnection;

        /// <summary>
        /// Xóa một thực thể theo Id
        /// </summary>
        /// <param name="entityId">Id</param>
        /// <returns>Số bản ghi thay đổi</returns>
        /// CreatedBy KDLong 27/04/2021
        public int Delete(Guid entityId)
        {
            using (dbConnection = new MySqlConnection(connectionString))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add($"@{tableName}Id", entityId);
                var rowsAffect = dbConnection.Execute($"Proc_Delete{tableName}", param: parameters, commandType: CommandType.StoredProcedure);
                return rowsAffect;
            }
        }
        /// <summary>
        /// Lấy tất cả bản ghi
        /// </summary>
        /// <returns>Tất cả bản ghi</returns>
        /// CreatedBy KDLong 27/04/2021
        public IEnumerable<MISAEntity> GetAll()
        {
            using (dbConnection = new MySqlConnection(connectionString))
            {
                var entities = dbConnection.Query<MISAEntity>($"Proc_Get{tableName}s", commandType: CommandType.StoredProcedure);
                return entities;
            }
        }
        /// <summary>
        /// Lấy bản ghi theo Id
        /// </summary>
        /// <param name="entityId">Id</param>
        /// <returns>Bản ghi</returns>
        /// CreatedBy KDLong 27/04/2021
        public MISAEntity GetById(Guid entityId)
        {
            using (dbConnection = new MySqlConnection(connectionString))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add($"@{tableName}Id", entityId);
                var entity = dbConnection.QueryFirstOrDefault<MISAEntity>($"Proc_Get{tableName}ById", param: parameters, commandType: CommandType.StoredProcedure);
                return entity;
            }
        }
        /// <summary>
        /// Thêm mới 1 bản ghi
        /// </summary>
        /// <param name="entity">Bản ghi cần thêm mới</param>
        /// <returns>Số bản ghi thay đổi</returns>
        /// CreatedBy KDLong 27/04/2021
        public int Insert(MISAEntity entity)
        {
            using (dbConnection = new MySqlConnection(connectionString))
            {
                var rowsAffect = dbConnection.Execute($"Proc_Insert{tableName}", param: entity, commandType: CommandType.StoredProcedure);
                return rowsAffect;
            }
        }
        /// <summary>
        /// Cập nhật 1 bản ghi
        /// </summary>
        /// <param name="entity">Bản ghi cần cập nhật</param>
        /// <returns>Số bản ghi thay đổi</returns>
        /// CreatedBy KDLong 27/04/2021
        public int Update(MISAEntity entity)
        {
            using (dbConnection = new MySqlConnection(connectionString))
            {
                var rowsAffect = dbConnection.Execute($"Proc_Update{tableName}", param: entity, commandType: CommandType.StoredProcedure);
                return rowsAffect;
            }
        }
    }
}
