using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interface.Service
{
    /// <summary>
    /// Các service dùng chung
    /// </summary>
    /// <typeparam name="MISAEntity"></typeparam>
    /// CreatedBy: KDLong 27/04/2021
    public interface IBaseService<MISAEntity>
    {
        /// <summary>
        /// Lấy tất cả bản ghi
        /// </summary>
        /// <returns>Tất cả các bản ghi</returns>
        /// CreatedBy: KDLong 27/04/2021
        public IEnumerable<MISAEntity> GetAll();
        /// <summary>
        /// Lấy một bản ghi theo Id
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns>Một bản ghi</returns>
        /// CreatedBy: KDLong 27/04/2021
        public MISAEntity GetById(Guid entityId);
        /// <summary>
        /// Thêm mới 1 bản ghi
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Số bản ghi thay đổi trong database</returns>
        /// CreatedBy: KDLong 27/04/2021
        public int Insert(MISAEntity entity);
        /// <summary>
        /// Cập nhật
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Số bản ghi thay đổi</returns>
        /// CreatedBy: KDLong 27/04/2021
        public int Update(MISAEntity entity);
        /// <summary>
        /// Xóa
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns>Số bản ghi thay đổi</returns>
        public int Delete(Guid entityId);
    }
}
