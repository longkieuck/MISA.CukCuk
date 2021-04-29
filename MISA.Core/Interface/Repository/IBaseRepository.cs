using System;
using System.Collections.Generic;

namespace MISA.Core.Interface.Repository
{
    public interface IBaseRepository<MISAEntity> where MISAEntity : class
    {
        /// <summary>
        /// Lấy tất cả dữ liệu của đối tượng trong bảng MISAEntity trong database
        /// </summary>
        /// <returns>Danh sách MISAEntity</returns>
        /// /// Created by : KDLong 22/04/2021
        public IEnumerable<MISAEntity> GetAll();
        /// <summary>
        /// Lấy MISAEntity theo ID
        /// </summary>
        /// <param name="entityId">Mã</param>
        /// <returns>MISAEntity</returns>
        /// Created by : KDLong 22/04/2021
        public MISAEntity GetById(Guid entityId);
        /// <summary>
        /// Thêm mới 1 bản ghi
        /// </summary>
        /// <param name="entity">Đối tượng</param>
        /// <returns>Số bản ghi thay đổi trong database</returns>
        /// Created by : KDLong 22/04/2021
        public int Insert(MISAEntity entity);
        /// <summary>
        /// Cập nhật 1 bản ghi
        /// </summary>
        /// <param name="entity">Đối tượng</param>
        /// <returns>Số bản ghi thay đổi trong database</returns>
        /// Created by : KDLong 22/04/2021
        public int Update(MISAEntity entity);
        /// <summary>
        /// Delete 1 bản ghi them Id
        /// </summary>
        /// <param name="entityId">Mã</param>
        /// <returns>Số bản ghi thay đổi trong database</returns>
        /// Created by : KDLong 22/04/2021
        public int Delete(Guid entityId);

    }
}
