using Microsoft.AspNetCore.Mvc;
using MISA.Core.Interface.Service;
using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MISA.Core.Enum;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.Api.Controllers
{
    /// <summary>
    /// CustomerController
    /// </summary>
    /// CreatedBy: KDLong 27/04/2021
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class CustomerController : BaseController<Customer>
    {
        ICustomerService _customerService;

        public CustomerController(ICustomerService customerService) : base(customerService)
        {
            _customerService = customerService;
        }


        /// <summary>
        /// Filter
        /// </summary>
        /// <param name="customerFilter"></param>
        /// <returns>
        /// HttpStatus code 200 - Lấy dữ liệu thành công
        /// HttpStatus code 204 - Không có dữ liệu
        /// </returns>
        /// CreatedBy: KDLong 27/04/2021
        [HttpGet("Filter")]
        public IActionResult GetCustomers([FromQuery] CustomerFilter customerFilter)
        {
            var pagging = _customerService.GetCustomers(customerFilter);

            // Xử lý kết quả trả về cho client.
            if (pagging.Data.Any() && customerFilter.Page >= 0 && customerFilter.PageSize >= 0)
            {
                return Ok(pagging);
            }

            return NoContent();
        }
    }
}
