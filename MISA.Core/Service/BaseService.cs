using MISA.Core.AttributeCustom;
using MISA.Core.Entities;
using MISA.Core.Exceptions;
using MISA.Core.Interface.Repository;
using MISA.Core.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MISA.Core.Service
{
    /// <summary>
    /// BaseService các service dùng chung
    /// </summary>
    /// <typeparam name="MISAEntity"></typeparam>
    /// CreatedBy: KDLong 27/04/2021
    public abstract class BaseService<MISAEntity> : IBaseService<MISAEntity> where MISAEntity : class
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
            Validate(entity);
            return _baseRepository.Insert(entity);
        }
        /// <summary>
        /// Cập nhật 1 bản ghi
        /// </summary>
        /// <param name="entity">Bản ghi cần cập nhật</param>
        /// <returns>Số bản ghi thay đổi trong database</returns>
        public int Update(MISAEntity entity)
        {
            //Validate(entity, false);
            return _baseRepository.Update(entity);
        }

        private void Validate(MISAEntity entity)
        {
            var properties = typeof(MISAEntity).GetProperties();
            foreach (var property in properties)
            {
                //Check trống
                var requiredProperties = property.GetCustomAttributes(typeof(MISARequired), true);
                if (requiredProperties.Length > 0)
                {

                    //Lấy giá trị
                    var propertyValue = property.GetValue(entity);
                    //Kiểm tra giá trị
                    if (string.IsNullOrEmpty(propertyValue.ToString()))
                    {
                        var msgError = (requiredProperties[0] as MISARequired).MsgError;
                        throw new BaseException(property.Name + msgError);
                    }

                }
                ////Check max length
                //var maxLengthProperties = property.GetCustomAttributes(typeof(MISAMaxLength), true);
                //if (maxLengthProperties.Length > 0)
                //{

                //    //Lấy giá trị
                //    var propertyValue = property.GetValue(entity);
                //    var maxLength = (maxLengthProperties[0] as MISAMaxLength).MaxLength;
                //    //Kiểm tra giá trị
                //    if (propertyValue.ToString().Length > maxLength)
                //    {
                //        var msgError = (maxLengthProperties[0] as MISAMaxLength).MsgError;
                //        throw new BaseException(property.Name + " " + msgError);
                //    }

                //}
                ////Check format
                //var formatProperties = property.GetCustomAttributes(typeof(MISAFormat), true);
                //if (formatProperties.Length > 0)
                //{

                //    //Lấy giá trị
                //    var propertyValue = property.GetValue(entity);
                //    var regex = (formatProperties[0] as MISAFormat).Regex;
                //    var re = new Regex(regex);

                //    if (!re.IsMatch(propertyValue.ToString()))
                //    {
                //        var msgError = (formatProperties[0] as MISAFormat).MsgError;
                //        throw new BaseException(property.Name + " " + msgError);
                //    }
                //}

            }
            CustomValidate(entity);
        }
        /// <summary>
        /// Đối với từng đối tượng khác nhau sẽ có những trường cần validate riêng
        /// </summary>
        /// <param name="entity">Đối tượng</param>
        protected virtual void CustomValidate(MISAEntity entity)
        {

        }
    }
}
