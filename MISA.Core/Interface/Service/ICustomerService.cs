using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interface.Service
{
    /// <summary>
    /// Service riêng của Customer
    /// </summary>
    /// CreatedBy: KDLong 27/04/2021
    public interface ICustomerService : IBaseService<Customer>
    {
        /// <summary>
        /// Lấy danh sách Customers theo điều kiện
        /// </summary>
        /// <param name="customerFilter">
        /// Page
        /// PageSize
        /// FullName
        /// PhoneNumber
        /// CustomerGroupId
        /// </param>
        /// <returns>Danh sách customer theo điều kiện</returns>
        public Pagging<Customer> GetCustomers(CustomerFilter customerFilter);
    }
}
