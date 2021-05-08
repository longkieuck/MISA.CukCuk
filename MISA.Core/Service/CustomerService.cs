using MISA.Core.Interface.Service;
using MISA.Core.Interface.Repository;
using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISA.Core.Exceptions;
using MISA.Core.Enum;

namespace MISA.Core.Service
{
    /// <summary>
    /// Các service dùng riêng của Customer
    /// </summary>
    /// CreatedBy: KDLong 27/04/2021
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository) : base(customerRepository)
        {
            _customerRepository = customerRepository;
        }
        /// <summary>
        /// Service phân trang,Lọc theo điều kiện
        /// </summary>
        /// <param name="customerFilter">
        /// Page,PageSize,FullName,PhoneNumber,CustomerGroupId
        /// </param>
        /// <returns>PageSize bản ghi của trang Page</returns>
        /// CreatedBy: KDLong 27/04/2021
        public Pagging<Customer> GetCustomers(CustomerFilter customerFilter)
        {
            var pagging = _customerRepository.GetCustomers(customerFilter);
            return pagging;
        }
        /// <summary>
        /// Validate riêng của customer
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="isInsert">
        /// Nếu là thêm mới bản ghi thì isInsert = true
        /// và ngược lại
        /// </param>
        /// CreatedBy: KDLong 27/04/2021
        //protected override void CustomValidate(Customer entity, bool isInsert)
        //{
        //    if (entity is Customer)
        //    {
        //        var customer = entity as Customer;

        //        var isCustomerCodeExist = _customerRepository.CheckCustomerCodeExist(customer.CustomerCode);
        //        var isEmailExist = _customerRepository.CheckEmailExist(customer.Email);
        //        var isPhoneNumberExist = _customerRepository.CheckPhoneNumberExist(customer.PhoneNumber);

        //        if (!isInsert)
        //        {
        //            ///Check trùng với các mã đã có trong hệ thống
        //            var customerCode = _customerRepository.GetCustomerCodeById(customer.CustomerId);
        //            if (isCustomerCodeExist && customerCode != customer.CustomerCode)
        //            {
        //                throw new BaseException("CustomerCode" + MISAConstant.Dev_Msg_Exist);
        //            }
        //            ///Check trùng email
        //            var email = _customerRepository.GetEmailById(customer.CustomerId);
        //            if (isEmailExist && email != customer.Email)
        //            {
        //                throw new BaseException("Email" + MISAConstant.Dev_Msg_Exist);
        //            }
        //            ///Check trùng SĐT
        //            var phoneNumber = _customerRepository.GetPhoneNumberById(customer.CustomerId);
        //            if (isPhoneNumberExist && phoneNumber != customer.PhoneNumber)
        //            {
        //                throw new BaseException("PhoneNumber" + MISAConstant.Dev_Msg_Exist);
        //            }
        //        }
        //        else
        //        {
        //            // Check trùng mã
        //            if (isCustomerCodeExist == true)
        //            {
        //                throw new BaseException("CustomerCode" + MISAConstant.Dev_Msg_Exist);
        //            }
        //            // Check trùng email
        //            if (isEmailExist == true)
        //            {
        //                throw new BaseException("Email" + MISAConstant.Dev_Msg_Exist);
        //            }
        //            // Check trùng mã
        //            if (isPhoneNumberExist == true)
        //            {
        //                throw new BaseException("PhoneNumber" + MISAConstant.Dev_Msg_Exist);
        //            }
        //        }
        //    }
        //}
    }
}
