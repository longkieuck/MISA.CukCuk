
using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interface.Repository
{
    /// <summary>
    /// Repository của Customer
    /// </summary>
    /// CreatedBy: KDLong 27/04/2021
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        /// <summary>
        /// Check xem mã khách hàng đã tồn tại chưa
        /// </summary>
        /// <param name="customerCode"></param>
        /// <returns>bool</returns>
        /// CreatedBy: KDLong 27/04/2021
        public bool CheckCustomerCodeExist(string customerCode);
        /// <summary>
        /// Check xem SĐT đã tồn tại chưa
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns>bool</returns>
        /// CreatedBy: KDLong 27/04/2021
        public bool CheckPhoneNumberExist(string phoneNumber);
        /// <summary>
        /// Check xem Email đã tồn tại chưa
        /// </summary>
        /// <param name="email"></param>
        /// <returns>bool</returns>
        /// CreatedBy: KDLong 27/04/2021
        public bool CheckEmailExist(string email);
        /// <summary>
        /// Lấy CustomerCode theo CustomerId
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns>CustomerCode</returns>
        public string GetCustomerCodeById(Guid customerId);
        /// <summary>
        /// Lấy Emaik theo CustomerId
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns>Email</returns>
        public string GetEmailById(Guid customerId);
        /// <summary>
        /// Lấy SĐT theo CustomerId
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns>SĐT</returns>
        /// CreatedBy: KDLong 27/04/2021
        public string GetPhoneNumberById(Guid customerId);
        /// <summary>
        /// Lấy danh sách khách hàng theo điều kiện
        /// </summary>
        /// <param name="customerFilter">
        /// Page
        /// PageSize
        /// FullName
        /// PhoneNumber
        /// CustomerGroupId
        /// </param>
        /// <returns>Danh sách khách hàng theo điều kiện</returns>
        /// CreatedBy: KDLong 27/04/2021
        public Pagging<Customer> GetCustomers(CustomerFilter customerFilter);
    }
}
