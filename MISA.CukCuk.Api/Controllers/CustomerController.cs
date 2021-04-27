﻿using Microsoft.AspNetCore.Mvc;
using MISA.Core.Interface;
using MISA.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.Api.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        /// <summary>
        /// Lấy dữ liệu toàn bộ khách hàng
        /// </summary>
        /// <returns>
        /// HttpStatusCode 200 - Lấy dữ liệu thành công
        /// HttpStatusCode 204 - Không có dữ liệu
        /// </returns>
        /// Created by KDLong 22/04/2021

        // GET: api/<CustomerController>
        [HttpGet]
        public IActionResult Get()
        {
            var customers = _customerService.GetAll();
            if (customers.Count() > 0)
            {
                return Ok(customers);
            }
            return NoContent();
        }

        /// <summary>
        /// Lấy dữ liệu khách hàng theo Id
        /// </summary>
        /// <param name="customerId">id khách hàng</param>
        /// <returns>
        /// HttpStatus code 200 - Thành công
        /// HttpStatus code 204 - Không có dữ liệu trả về
        /// </returns>
        /// CreatedBy KDLong 27/04/2021
        // GET api/<CustomerController>/5

        [HttpGet("{customerId}")]
        public IActionResult Get(Guid customerId)
        {

            var customer = _customerService.GetById(customerId);
            if (customer != null)
            {
                return Ok(customer);
            }
            return NoContent();
        }
        /// <summary>
        /// Thêm mới 1 khách hàng
        /// </summary>
        /// <param name="customer">Dữ liệu khách hàng cần thêm mới</param>
        /// <returns>
        /// HttpStatus code 201 - Thêm thành công
        /// HttpStatus code 204 - Thêm thất bại
        /// </returns>
        /// CreatedBy KDLong 27/04/2021
        // POST api/<CustomerController>
        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            var res = _customerService.Insert(customer);
            if (res > 0)
            {
                return StatusCode(201, res);
            }
            return NoContent();
        }
        /// <summary>
        /// Sửa thông tin 1 khách hàng
        /// </summary>
        /// <param name="customer">Dữ liệu khách hàng cần cập nhật</param>
        /// <returns>
        /// HttpStatus code 200 - Sửa thành công
        /// HttpStatus code 204 - Sửa thất bại
        /// </returns>
        /// CreatedBy KDLong 27/04/2021
        // PUT api/<CustomerController>/5
        [HttpPut("{CustomerId}")]
        public IActionResult Put([FromBody] Customer customer)
        {
            var rowAffects = _customerService.Update(customer);

            // số bản ghi được sửa đổi
            if (rowAffects > 0)
            {
                return Ok("Sửa thành công");
            }
            return NoContent();
        }
        /// <summary>
        /// Xóa thông tin 1 khách hàng
        /// </summary>
        /// <param name="customerId">Id khách hàng cần xóa</param>
        /// <returns>
        /// HttpStatus code 200 - Xóa thành công
        /// HttpStatus code 204 - Xóa thất bại
        /// </returns>
        /// CreatedBy KDLong 27/04/2021
        // DELETE api/<CustomerController>/5

        [HttpDelete("{customerId}")]
        public IActionResult Delete(Guid customerId)
        {
            var rowsAffect = _customerService.Delete(customerId);
            if (rowsAffect > 0)
            {
                return Ok("Xóa thành công");
            }
            return NoContent();
        }
    }
}
