using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Core.Interface.Service;
using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class CustomerGroupController : ControllerBase
    {
        ICustomerGroupService _customerGroupService;

        public CustomerGroupController(ICustomerGroupService customerGroupService)
        {
            _customerGroupService = customerGroupService;
        }
        /// <summary>
        /// Lấy dữ liệu toàn bộ nhóm khách hàng
        /// </summary>
        /// <returns>
        /// HttpStatusCode 200 - Lấy dữ liệu thành công
        /// HttpStatusCode 204 - Không có dữ liệu
        /// </returns>
        /// Created by KDLong 27/04/2021
        [HttpGet]
        public IActionResult Get()
        {
            var customerGroups = _customerGroupService.GetAll();
            if (customerGroups.Count() > 0)
            {
                return Ok(customerGroups);
            }
            return NoContent();
        }
        /// <summary>
        /// Lấy dữ liệu nhóm khách hàng theo Id
        /// </summary>
        /// <param name="customerId">id nhóm khách hàng</param>
        /// <returns>
        /// HttpStatus code 200 - Thành công
        /// HttpStatus code 204 - Không có dữ liệu trả về
        /// </returns>
        /// CreatedBy KDLong 27/04/2021
        [HttpGet("{customerGroupId}")]
        public IActionResult GetById(Guid customerGroupId)
        {
            var customerGroup = _customerGroupService.GetById(customerGroupId);
            if (customerGroup == null)
            {
                return NoContent();
            }
            return Ok(customerGroup);
        }
        /// <summary>
        /// Thêm mới 1 nhóm khách hàng
        /// </summary>
        /// <param name="customer">Dữ liệu nhóm khách hàng cần thêm mới</param>
        /// <returns>
        /// HttpStatus code 201 - Thêm thành công
        /// HttpStatus code 204 - Thêm thất bại
        /// </returns>
        /// CreatedBy KDLong 27/04/2021
        [HttpPost]
        public IActionResult Post(CustomerGroup customerGroup)
        {
            var res = _customerGroupService.Insert(customerGroup);
            if (res > 0) return StatusCode(200, res);
            return NoContent();
        }
        /// <summary>
        /// Sửa thông tin 1 nhóm khách hàng
        /// </summary>
        /// <param name="customer">Dữ liệu nhóm khách hàng cần cập nhật</param>
        /// <returns>
        /// HttpStatus code 200 - Sửa thành công
        /// HttpStatus code 204 - Sửa thất bại
        /// </returns>
        /// CreatedBy KDLong 27/04/2021
        [HttpPut("{customerGroupId}")]
        public IActionResult Put([FromBody] CustomerGroup customerGroup)
        {
            var rowAffects = _customerGroupService.Update(customerGroup);

            // số bản ghi được sửa đổi
            if (rowAffects > 0)
            {
                return Ok("Sửa thành công");
            }
            return NoContent();
        }

        /// <summary>
        /// Xóa thông tin 1 nhóm khách hàng
        /// </summary>
        /// <param name="customerId">Id nhóm khách hàng cần xóa</param>
        /// <returns>
        /// HttpStatus code 200 - Xóa thành công
        /// HttpStatus code 204 - Xóa thất bại
        /// </returns>
        /// CreatedBy KDLong 27/04/2021
        [HttpDelete("{customerGroupId}")]
        public IActionResult Delete(Guid customerGroupId)
        {
            var rowsAffect = _customerGroupService.Delete(customerGroupId);
            if (rowsAffect > 0)
            {
                return Ok("Xóa thành công");
            }
            return NoContent();
        }
    }
}
