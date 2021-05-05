using Microsoft.AspNetCore.Mvc;
using MISA.Core.Enum;
using MISA.Core.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Controllers
{
    /// <summary>
    /// Controller dùng chung
    /// </summary>
    /// <typeparam name="MISAEntity"></typeparam>
    /// Created by KDLong 27/04/2021
    public class BaseController<MISAEntity> : Controller where MISAEntity : class
    {
        IBaseService<MISAEntity> _baseService;

        public BaseController(IBaseService<MISAEntity> baseService)
        {
            _baseService = baseService;
        }

        /// <summary>
        /// Lấy dữ liệu toàn bộ đối tượng
        /// </summary>
        /// <returns>
        /// HttpStatusCode 200 - Lấy dữ liệu thành công
        /// HttpStatusCode 204 - Không có dữ liệu
        /// </returns>
        /// Created by KDLong 27/04/2021

        // GET: api/<entityController>
        [HttpGet]
        public IActionResult Get()
        {
            var entities = _baseService.GetAll();
            if (entities.Count() > 0)
            {
                return Ok(entities);
            }
            return NoContent();
        }

        /// <summary>
        /// Lấy dữ liệu đối tượng theo Id
        /// </summary>
        /// <param name="entityId">id đối tượng</param>
        /// <returns>
        /// HttpStatus code 200 - Thành công
        /// HttpStatus code 204 - Không có dữ liệu trả về
        /// </returns>
        /// CreatedBy KDLong 27/04/2021

        [HttpGet("{entityId}")]
        public IActionResult Get(Guid entityId)
        {

            var entity = _baseService.GetById(entityId);
            if (entity != null)
            {
                return Ok(entity);
            }
            return NoContent();
        }
        /// <summary>
        /// Thêm mới 1 đối tượng
        /// </summary>
        /// <param name="entity">Dữ liệu đối tượng cần thêm mới</param>
        /// <returns>
        /// HttpStatus code 201 - Thêm thành công
        /// HttpStatus code 204 - Thêm thất bại
        /// </returns>
        /// CreatedBy KDLong 27/04/2021
        [HttpPost]
        public IActionResult Post([FromBody] MISAEntity entity)
        {
            var res = _baseService.Insert(entity);
            if (res > 0)
            {
                return StatusCode(201, res);
            }
            return NoContent();
        }
        /// <summary>
        /// Sửa thông tin 1 đối tượng
        /// </summary>
        /// <param name="entity">Dữ liệu đối tượng cần cập nhật</param>
        /// <returns>
        /// HttpStatus code 200 - Sửa thành công
        /// HttpStatus code 204 - Sửa thất bại
        /// </returns>
        /// CreatedBy KDLong 27/04/2021
        [HttpPut]
        public IActionResult Put([FromBody] MISAEntity entity)
        {
            var rowAffects = _baseService.Update(entity);

            // số bản ghi được sửa đổi
            if (rowAffects > 0)
            {
                return Ok(MISAConstant.Update_Success);
            }
            return StatusCode(204, MISAConstant.Update_Fail);
        }
        /// <summary>
        /// Xóa thông tin 1 đối tượng
        /// </summary>
        /// <param name="entityId">Id đối tượng cần xóa</param>
        /// <returns>
        /// HttpStatus code 200 - Xóa thành công
        /// HttpStatus code 204 - Xóa thất bại
        /// </returns>
        /// CreatedBy KDLong 27/04/2021

        [HttpDelete("{entityId}")]
        public IActionResult Delete(Guid entityId)
        {
            var rowsAffect = _baseService.Delete(entityId);
            if (rowsAffect > 0)
            {
                return Ok(MISAConstant.Delete_Success);
            }
            return StatusCode(204, MISAConstant.Update_Fail);
        }

    }
}
