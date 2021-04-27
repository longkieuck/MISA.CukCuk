using MISA.Core.Interface;
using MISA.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Service
{
    public class BaseService<MISAEntity> : IBaseService<MISAEntity> where MISAEntity : class
    {
        IBaseRepository<MISAEntity> _baseRepository;

        public BaseService(IBaseRepository<MISAEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        /// <summary>
        /// Xóa đối tượng theo Id
        /// </summary>
        /// <param name="entityId">Id</param>
        /// <returns>Số bản ghi thay đổi</returns>
        /// Created by KDLong 27/04/2021
        public int Delete(Guid entityId)
        {
            return _baseRepository.Delete(entityId);
        }

        /// <summary>
        /// Lấy toàn bộ bản ghi
        /// </summary>
        /// <returns>Toàn bộ bản ghi</returns>
        /// Created by KDLong 27/04/2021
        public IEnumerable<MISAEntity> GetAll()
        {
            return _baseRepository.GetAll();
        }
        /// <summary>
        /// Lấy bản ghi theo Id
        /// </summary>
        /// <param name="entityId">Id</param>
        /// <returns>Bản ghi</returns>
        /// Created by KDLong 27/04/2021
        public MISAEntity GetById(Guid entityId)
        {
            return _baseRepository.GetById(entityId);
        }
        /// <summary>
        /// Thêm mới 1 bản ghi
        /// </summary>
        /// <param name="entity">Bản ghi cần thêm mới</param>
        /// <returns>Số bản ghi thay đổi trong database</returns>
        public int Insert(MISAEntity entity)
        {
            return _baseRepository.Insert(entity);
        }
        /// <summary>
        /// Cập nhật 1 bản ghi
        /// </summary>
        /// <param name="entity">Bản ghi cần cập nhật</param>
        /// <returns>Số bản ghi thay đổi trong database</returns>
        public int Update(MISAEntity entity)
        {
            return _baseRepository.Update(entity);
        }
    }
}
